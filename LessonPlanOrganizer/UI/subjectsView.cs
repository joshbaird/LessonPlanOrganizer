using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LessonPlanOrganizer
{
    public partial class subjectsView : UserControl
    {
        public subjectsView()
        {
            InitializeComponent();
            initOlv();
        }

        private void initOlv()
        {
            this.fastObjectListView1.OwnerDraw = true;

            this.olvSubjects.AspectGetter = rowObject =>
            {
                return ((Subject)rowObject).Name;
            };
            this.fastObjectListView1.FormatRow += (o, e) =>
            {
                e.Item.BackColor = ((Subject)e.Model).Color;
                e.Item.ForeColor = Color.White;
            };

            EventsControl.SubjectChanged += (o, e) =>
            {
                this.fastObjectListView1.ClearObjects();
                this.fastObjectListView1.AddObjects(LessonPlanYearControl.Intance.getSubjects());
            };
            this.fastObjectListView1.ClearObjects();
            this.fastObjectListView1.AddObjects(LessonPlanYear.Instance.Subjects);
        }

        private void fastObjectListView1_DoubleClick(object sender, EventArgs e)
        {
            EditSelected();
        }

        private void fastObjectListView1_CellRightClick(object sender, BrightIdeasSoftware.CellRightClickEventArgs e)
        {
            e.MenuStrip = this.cmsRightClick;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewSubjectWindow();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditSelected();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteSelected();
        }

        public bool ItemSelected { get { return this.fastObjectListView1.SelectedObject != null; } }

        public void EditSelected()
        {
            Subject sub = (Subject)this.fastObjectListView1.SelectedObject;
            SubjectUI subjectSetupUI = new SubjectUI(sub);
            subjectSetupUI.ShowDialog();
        }

        public void DeleteSelected()
        {
            Subject sub = (Subject)this.fastObjectListView1.SelectedObject;
            EventsControl.RaiseRemoveSubject(sub);
        }

        public void NewSubjectWindow()
        {
            Subject newSub = new Subject();
            newSub.Name = "Subject Name";
            newSub.Color = Color.RoyalBlue;
            SubjectUI subjectSetupUI = new SubjectUI(newSub);
            if (subjectSetupUI.ShowDialog() == DialogResult.OK)
            {
                EventsControl.RaiseAddNewSubject(newSub);
            }
        }
    }
}
