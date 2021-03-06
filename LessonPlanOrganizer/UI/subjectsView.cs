﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

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
                e.Item.ForeColor = (PerceivedBrightness(((Subject)e.Model).Color) > 130 ? Color.Black : Color.White);
            };

            EventsControl.SubjectChanged += (o, e) =>
            {
                this.fastObjectListView1.ClearObjects();
                this.fastObjectListView1.AddObjects(LessonPlanYearControl.Instance.getSubjects());
            };
            this.fastObjectListView1.ClearObjects();
            this.fastObjectListView1.AddObjects(LessonPlanYearControl.Instance.getSubjects());
        }
        private int PerceivedBrightness(Color c)
        {
            return (int)Math.Sqrt(
            c.R * c.R * .299 +
            c.G * c.G * .587 +
            c.B * c.B * .114);
        }

        private void fastObjectListView1_DoubleClick(object sender, EventArgs e)
        {
            EditSelected();
        }

        private void fastObjectListView1_CellRightClick(object sender, BrightIdeasSoftware.CellRightClickEventArgs e)
        {
            this.newToolStripMenuItem.Enabled = true;
            this.editToolStripMenuItem.Enabled = this.ItemSelected;
            this.deleteToolStripMenuItem.Enabled = this.ItemSelected;
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
