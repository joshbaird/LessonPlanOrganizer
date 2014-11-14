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

            lessonPlanYearControl = LessonPlanYearControl.Intance;

            EventsControl.SubjectChanged += (o, e) =>
                {
                    refreshCalendar();
                };
            EventsControl.LessonChanged += (o, e) =>
                {
                    refreshCalendar();
                };

            // test load some subjecs
            Subject testSub1 = new Subject();
            testSub1.Name = "Math";
            testSub1.Color = Color.Red;
            Subject testSub2 = new Subject();
            testSub2.Name = "ELA";
            testSub2.Color = Color.Blue;
            lessonPlanYearControl.addSubject(testSub1);
            lessonPlanYearControl.addSubject(testSub2);

            // test load items from Lesson Year Plan
            LessonPlan item = new LessonPlan(calendar1, new DateTime(2014, 11, 6), new TimeSpan(1, 0, 0, 0), "Testing");
            item.Subject = testSub2;
            LessonPlan item2 = new LessonPlan(calendar1, new DateTime(2014, 11, 10), new TimeSpan(1, 0, 0, 0), "Testing2");
            item2.Subject = testSub1;
            lessonPlanYearControl.addLessonPlans(item);
            lessonPlanYearControl.addLessonPlans(item2);


        }

        private LessonPlanYearControl lessonPlanYearControl;

        private void monthView_SelectionChanged(object sender, EventArgs e)
        {
            if ((this.monthView.SelectionEnd - this.monthView.SelectionStart).TotalDays <= this.calendar1.MaximumViewDays)
                this.calendar1.SetViewRange(this.monthView.SelectionStart, this.monthView.SelectionEnd);
            else
                this.calendar1.SetViewRange(this.monthView.SelectionStart, this.monthView.SelectionStart.AddDays(this.calendar1.MaximumViewDays));
        }
        private void bToday_Click(object sender, EventArgs e)
        {
            this.monthView.SelectionStart = DateTime.Now;
            this.monthView.SelectionEnd = DateTime.Now.AddDays(1);
        }
        private void calendar1_LoadItems(object sender, CalendarLoadEventArgs e)
        {
            refreshCalendar();
        }
        private void refreshCalendar()
        {
            calendar1.Items.Clear();
            calendar1.Items.AddRange(lessonPlanYearControl.GetLessonsForCalendarDisplay(monthView.SelectionStart, monthView.SelectionEnd));
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

        private void editLessonStripMenuItem_Click(object sender, EventArgs e)
        {
            LessonUI lessonSetupUI = new LessonUI(this.calendar1);
            lessonSetupUI.ShowDialog();
            // TODO handle close and return
        }

        private void deleteLessonStripMenuItem_Click(object sender, EventArgs e)
        {
            LessonUI lessonSetupUI = new LessonUI(this.calendar1);
            lessonSetupUI.ShowDialog();
            // TODO handle close and return
        }

        // report
        private void subjectStatisticsReportStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportUI reportStats = new ReportUI("statistics");           
            reportStats.ShowDialog();
            // TODO handle close and return 
        }

        private void lessonPlanReportStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportUI reportStats = new ReportUI("statistics");
            reportStats.hideUIItemsForLessonPlanReport();
            reportStats.ShowDialog();
            // TODO handle close and return 
        }

        // help
        private void aboutHelpStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("About", "Teacher lesson plan, written by Team-C");
        }
        #endregion

        private void subjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.newToolStripMenuItemSubject.Enabled = true;
            this.editToolStripMenuItemSubject.Enabled = this.subjectsView1.ItemSelected;
            this.deleteToolStripMenuItemSubject.Enabled = this.subjectsView1.ItemSelected;
        }


    }
}
