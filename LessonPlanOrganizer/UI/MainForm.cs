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
           
        }
        
        

        private void monthView1_SelectionChanged(object sender, EventArgs e)
        {
            if ((this.monthView.SelectionEnd - this.monthView.SelectionStart).TotalDays <= this.lessonPlanYearControl.MaximumViewDays)
                this.lessonPlanYearControl.SetViewRange(this.monthView.SelectionStart, this.monthView.SelectionEnd);
            else
                this.lessonPlanYearControl.SetViewRange(this.monthView.SelectionStart, this.monthView.SelectionStart.AddDays(this.lessonPlanYearControl.MaximumViewDays));
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
            SubjectUI subjectSetupUI = new SubjectUI("new");
            subjectSetupUI.ShowDialog();
            // TODO handle close and return
        }

        private void editSubjectStripMenuItem_Click(object sender, EventArgs e)
        {
            SubjectUI subjectSetupUI = new SubjectUI("edit");
            subjectSetupUI.ShowDialog();
            // TODO handle close and return
        }

        private void deleteSubjectStripMenuItem_Click(object sender, EventArgs e)
        {
            SubjectUI subjectSetupUI = new SubjectUI("delete");
            subjectSetupUI.ShowDialog();
            // TODO handle close and return
        }

        // lessons
        private void newLessonStripMenuItem_Click(object sender, EventArgs e)
        {
            LessonUI lessonSetupUI = new LessonUI("new");
            lessonSetupUI.ShowDialog();
            // TODO handle close and return
        }

        private void editLessonStripMenuItem_Click(object sender, EventArgs e)
        {
            LessonUI lessonSetupUI = new LessonUI("edit");
            lessonSetupUI.ShowDialog();
            // TODO handle close and return
        }

        private void deleteLessonStripMenuItem_Click(object sender, EventArgs e)
        {
            LessonUI lessonSetupUI = new LessonUI("delete");
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
            reportStats.ShowDialog();
            // TODO handle close and return 
        }

        // help
        private void aboutHelpStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("About", "Teacher lesson plan, written by Team-C");
        }
        #endregion

        private void bToday_Click(object sender, EventArgs e)
        {
            this.monthView.SelectionStart = DateTime.Now;
            this.monthView.SelectionEnd = DateTime.Now.AddDays(1);
        }

        private void lessonPlanYearControl_LoadItems(object sender, CalendarLoadEventArgs e)
        {
            // load items from Lesson Year Plan
            LessonPlan item = new LessonPlan(lessonPlanYearControl, new DateTime(2014, 11, 6), new TimeSpan(1, 0, 0, 0), "Testing");
            item.ApplyColor(Color.Red);
            LessonPlan item2 = new LessonPlan(lessonPlanYearControl, new DateTime(2014, 11, 10), new TimeSpan(1, 0, 0, 0), "Testing2");
            item2.ApplyColor(Color.Blue);
            lessonPlanYearControl.Items.Add(item);
            lessonPlanYearControl.Items.Add(item2);
        }
    }
}
