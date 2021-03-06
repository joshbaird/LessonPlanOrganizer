﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Windows.Forms.Calendar;

namespace LessonPlanOrganizer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            lessonPlanYearControl = LessonPlanYearControl.Instance;
            calendar1.TimeUnitsOffset = -14; // offset display to 7:00 AM
            EventsControl.SubjectChanged += (o, e) =>
                {
                    refreshCalendar();
                };
            EventsControl.LessonChanged += (o, e) =>
                {
                    refreshCalendar();
                };
            lessonPlanYearControl.Calendar = this.calendar1;
            refreshCalendar();
        }

        private LessonPlanYearControl lessonPlanYearControl;
        private Boolean UpdatingDates = false;
        private void monthView_SelectionChanged(object sender, EventArgs e)
        {
            if (UpdatingDates)
                return;
            if (((TimeSpan)(this.monthView.SelectionEnd - this.monthView.SelectionStart)).Days < this.calendar1.MaximumViewDays)
                this.calendar1.SetViewRange(this.monthView.SelectionStart, this.monthView.SelectionEnd);
            else
                this.calendar1.SetViewRange(this.monthView.SelectionStart, this.monthView.SelectionStart.AddDays(this.calendar1.MaximumViewDays - 1));
        }
        private void bToday_Click(object sender, EventArgs e)
        {
            UpdatingDates = true;
            this.monthView.SelectionStart = DateTime.Now;
            this.monthView.SelectionEnd = DateTime.Now.AddMinutes(1);
            UpdatingDates = false;
            monthView_SelectionChanged(this, EventArgs.Empty);
        }
        private void calendar1_LoadItems(object sender, CalendarLoadEventArgs e)
        {
            refreshCalendar();
        }
        private void refreshCalendar()
        {
            calendar1.Items.Clear();
            calendar1.Items.AddRange(lessonPlanYearControl.GetLessonCalendarItemsForCalendarDisplay(monthView.SelectionStart, monthView.SelectionEnd));
        }

        #region menu strip actions

        private void saveFileStripMenuItem_Click(object sender, EventArgs e)
        {
            lessonPlanYearControl.SavetoDataBase();    
        }

        private void quitFileStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Year
        private void newYearMenuItem_Click(object sender, EventArgs e)
        {
            LessonYearUI lessonYearSetup = new LessonYearUI("new");
            lessonYearSetup.ShowDialog();
        }

        private void editYearStripMenuItem_Click(object sender, EventArgs e)
        {
            LessonYearUI lessonYearSetup = new LessonYearUI("edit");
            lessonYearSetup.ShowDialog();
        }

        private void deleteYearStripMenuItem_Click(object sender, EventArgs e)
        {
            LessonYearUI lessonYearSetup = new LessonYearUI("delete");
            lessonYearSetup.ShowDialog();
        }

        // Subject
        private void newSubjectStripMenuItem_Click(object sender, EventArgs e)
        {
            this.subjectsView1.NewSubjectWindow();
        }

        private void editSubjectStripMenuItem_Click(object sender, EventArgs e)
        {
            this.subjectsView1.EditSelected();
        }

        private void deleteSubjectStripMenuItem_Click(object sender, EventArgs e)
        {
            this.subjectsView1.DeleteSelected();
        }

        // lessons
        private void newLessonStripMenuItem_Click(object sender, EventArgs e)
        {
            LessonUI lessonSetupUI = new LessonUI(this.calendar1);
            lessonSetupUI.ShowDialog();
        }

        private void calendar1_ItemDoubleClick(object sender, CalendarItemEventArgs e)
        {
            LessonUI lessonSetupUI = new LessonUI(e.Item);
            lessonSetupUI.ShowDialog();
            refreshCalendar();
        }

        private void editLessonStripMenuItem_Click(object sender, EventArgs e)
        {
            LessonUI lessonSetupUI = new LessonUI(this.calendar1.GetSelectedItems().FirstOrDefault());
            lessonSetupUI.ShowDialog();
        }

        private void deleteLessonStripMenuItem_Click(object sender, EventArgs e)
        {
            lessonPlanYearControl.removeLessonFromCalendarItem(this.calendar1.GetSelectedItems().FirstOrDefault());
        }

        // report
        private void subjectStatisticsReportStripMenuItem_Click(object sender, EventArgs e)
        {
            SubStatsReportInputForm inputForm = new SubStatsReportInputForm();
            inputForm.Visible = true;
        }

        private void lessonPlanReportStripMenuItem_Click(object sender, EventArgs e)
        {
            LessonPlanReportInputForm inputForm = new LessonPlanReportInputForm();
            inputForm.Visible = true;
        }

        // help
        private void aboutHelpStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Lesson Plan Organizer\nWritten by Team-C\n\nJoshua Baird\nCandace Lamoreaux\nAngela Lin\nDavid Tran", "About");
        }
        #endregion

        private void subjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.newToolStripMenuItemSubject.Enabled = true;
            this.editToolStripMenuItemSubject.Enabled = this.subjectsView1.ItemSelected;
            this.deleteToolStripMenuItemSubject.Enabled = this.subjectsView1.ItemSelected;
        }

        private void lessonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.newToolStripMenuItemLesson.Enabled = true;
            this.editToolStripMenuItemLesson.Enabled = this.calendar1.GetSelectedItems().Count() > 0;
            this.deleteToolStripMenuItemLesson.Enabled = this.calendar1.GetSelectedItems().Count() > 0;
        }

        private void calendar1_ItemDatesChanged(object sender, CalendarItemEventArgs e)
        {
            Console.WriteLine(e.Item.Text);
            lessonPlanYearControl.getLessonPlans().Where(l => l.CalendarItem.Equals(e.Item)).FirstOrDefault().SyncCalendar();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            lessonPlanYearControl.SavetoDataBase(); 
        }

        private List<CalendarItem> clipboardOfLessons = new List<CalendarItem>();

        private void calendar1_KeyDown(object sender, KeyEventArgs e)
        {
            List<CalendarItem> selectedItems = new List<CalendarItem>();
            selectedItems.AddRange(this.calendar1.GetSelectedItems());
            if (e.Control && e.KeyCode == Keys.C && selectedItems.Count() > 0)
            {
                clipboardOfLessons.Clear();
                clipboardOfLessons.AddRange(this.calendar1.GetSelectedItems());
                clipboardOfLessons = clipboardOfLessons.OrderBy(o => o.StartDate).ToList();
            }
            if (e.Control && e.KeyCode == Keys.V && this.calendar1.SelectedElementStart != null && clipboardOfLessons.Count > 0)
            {
                DateTime startOffset = this.calendar1.SelectedElementStart.Date;
                DateTime lastEndDate = clipboardOfLessons.FirstOrDefault().StartDate;
                clipboardOfLessons.ForEach(c => {
                    startOffset = startOffset.Add((c.StartDate - lastEndDate).Duration());
                    lastEndDate = c.EndDate;
                    LessonPlan lp = new LessonPlan(this.calendar1, startOffset, startOffset.Add(c.Duration), c.Text);
                    startOffset = startOffset.Add(c.Duration);
                    LessonPlan original = lessonPlanYearControl.getLessonPlans().Where(i => i.CalendarItem.Equals(c)).FirstOrDefault();
                    lp.Subject = original.Subject;
                    lp.Notes = original.Notes;
                    lp.Title = c.Text;
                    lessonPlanYearControl.addLessonPlans(lp);
                });
            }
        }
        private String deleteLessonPlanGUID;
        private void calendar1_ItemDeleting(object sender, CalendarItemCancelEventArgs e)
        {
            deleteLessonPlanGUID = lessonPlanYearControl.getLessonPlans().Where(i => i.CalendarItem.Equals(e.Item)).FirstOrDefault().ID;
        }

        private void calendar1_ItemDeleted(object sender, CalendarItemEventArgs e)
        {
            if (!String.IsNullOrEmpty(deleteLessonPlanGUID))
                lessonPlanYearControl.getLessonPlans().Where(l => String.Equals(deleteLessonPlanGUID, l.ID)).FirstOrDefault().deleteLessonPlan();
            deleteLessonPlanGUID = String.Empty;
        }
    }
}
