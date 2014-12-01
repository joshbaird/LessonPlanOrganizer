using System;
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
            this.calendar1.SetViewRange(new DateTime(2014,12,1), new DateTime(2014,12,31));
            EventsControl.SubjectChanged += (o, e) =>
                {
                    refreshCalendar();
                };
            EventsControl.LessonChanged += (o, e) =>
                {
                    refreshCalendar();
                };
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

        private void openFileStripMenuItem_Click(object sender, EventArgs e)
        {

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
            // TODO handle close and return

        }

        private void editYearStripMenuItem_Click(object sender, EventArgs e)
        {
            LessonYearUI lessonYearSetup = new LessonYearUI("edit");
            lessonYearSetup.ShowDialog();
            // TODO handle close and return
        }

        private void deleteYearStripMenuItem_Click(object sender, EventArgs e)
        {
            LessonYearUI lessonYearSetup = new LessonYearUI("delete");
            lessonYearSetup.ShowDialog();
            // TODO handle close and return
        }

        // Subject
        private void newSubjectStripMenuItem_Click(object sender, EventArgs e)
        {
            this.subjectsView1.NewSubjectWindow();
            // TODO handle close and return
        }

        private void editSubjectStripMenuItem_Click(object sender, EventArgs e)
        {
            this.subjectsView1.EditSelected();
            // TODO handle close and return
        }

        private void deleteSubjectStripMenuItem_Click(object sender, EventArgs e)
        {
            this.subjectsView1.DeleteSelected();
            // TODO display list of all subjects and allow user to remove.
            // TODO handle close and return
        }

        // lessons
        private void newLessonStripMenuItem_Click(object sender, EventArgs e)
        {
            LessonUI lessonSetupUI = new LessonUI(this.calendar1);
            lessonSetupUI.ShowDialog();
            // TODO handle close and return
        }

        private void calendar1_ItemDoubleClick(object sender, CalendarItemEventArgs e)
        {
            LessonUI lessonSetupUI = new LessonUI(e.Item);
            lessonSetupUI.ShowDialog();
            refreshCalendar();
            // TODO handle close and return
        }

        private void editLessonStripMenuItem_Click(object sender, EventArgs e)
        {
            LessonUI lessonSetupUI = new LessonUI(this.calendar1.GetSelectedItems().FirstOrDefault());
            lessonSetupUI.ShowDialog();
            // TODO handle close and return
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
            MessageBox.Show("Teacher lesson plan, written by Team-C", "About");
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
    }
}
