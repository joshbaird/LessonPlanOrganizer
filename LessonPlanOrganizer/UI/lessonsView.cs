﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Calendar;

namespace LessonPlanOrganizer
{
    public partial class lessonsView : UserControl
    {
        public lessonsView()
        {
            InitializeComponent();
            _calendar = new Calendar();
            initOlv();
        }

        private Calendar _calendar;

        public bool ItemSelected { get { return this.fastObjectListView1.SelectedObject != null; } }

        private void initOlv()
        {
            this.fastObjectListView1.OwnerDraw = true;

            this.olvLessonTitle.AspectGetter = rowObject =>
            {
                return ((LessonPlan)rowObject).Text;
            };
            this.olvSubjects.AspectGetter = rowObject =>
                {
                    return ((LessonPlan)rowObject).Subject.Name;
                };
            this.fastObjectListView1.FormatRow += (o, e) =>
            {
                e.Item.BackColor = ((LessonPlan)e.Model).Subject.Color;
                e.Item.ForeColor = Color.White;
            };

            EventsControl.SubjectChanged += (o, e) =>
            {
                this.fastObjectListView1.ClearObjects();
                this.fastObjectListView1.AddObjects(LessonPlanYearControl.Instance.getLessonPlans());
            };
            EventsControl.LessonChanged += (o, e) =>
            {
                this.fastObjectListView1.ClearObjects();
                this.fastObjectListView1.AddObjects(LessonPlanYearControl.Instance.getLessonPlans());
            };
            this.fastObjectListView1.ClearObjects();
            this.fastObjectListView1.AddObjects(LessonPlanYearControl.Instance.getLessonPlans());
        }

        private void fastObjectListView1_CellRightClick(object sender, BrightIdeasSoftware.CellRightClickEventArgs e)
        {
            this.newToolStripMenuItem.Enabled = true;
            this.editToolStripMenuItem.Enabled = this.ItemSelected;
            this.deleteToolStripMenuItem.Enabled = this.ItemSelected;
            e.MenuStrip = this.cmsRightClick;
        }

        private void fastObjectListView1_DoubleClick(object sender, EventArgs e)
        {
            EditSelected();
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewLessonWindow();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditSelected();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteSelected();
        }

        public void EditSelected()
        {
            LessonUI lessonSetupUI = new LessonUI(this.fastObjectListView1.SelectedObject);
            lessonSetupUI.ShowDialog();
        }

        public void DeleteSelected()
        {
            LessonPlanYearControl.Instance.removeLesson((LessonPlan)this.fastObjectListView1.SelectedObject);
        }

        public void NewLessonWindow()
        {
            LessonUI lessonSetupUI = new LessonUI(this._calendar);
            lessonSetupUI.ShowDialog();
        }


    }
}
