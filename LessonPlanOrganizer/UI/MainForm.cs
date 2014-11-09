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

            lessonPlanYearControl = new LessonPlanYearControl();

            // test load items from Lesson Year Plan
            LessonPlan item = new LessonPlan(calendar1, new DateTime(2014, 11, 6), new TimeSpan(1, 0, 0, 0), "Testing");
            item.ApplyColor(Color.Red);
            LessonPlan item2 = new LessonPlan(calendar1, new DateTime(2014, 11, 10), new TimeSpan(1, 0, 0, 0), "Testing2");
            item2.ApplyColor(Color.Blue);
            lessonPlanYearControl.addLessonPlans(item);
            lessonPlanYearControl.addLessonPlans(item2);

            // test load some subjecs
            Subject testSub1 = new Subject();
            testSub1.Name = "Math";
            testSub1.Color = Color.Red;
            Subject testSub2 = new Subject();
            testSub2.Name = "ELA";
            testSub2.Color = Color.Blue;
            lessonPlanYearControl.addSubject(testSub1);
            lessonPlanYearControl.addSubject(testSub2);

            InitObjectListView();
        }

        private LessonPlanYearControl lessonPlanYearControl;

        private void InitObjectListView()
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

            this.fastObjectListView1.AddObjects(lessonPlanYearControl.getSubjects());
        }
        
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
            Subject newSub = new Subject();
            newSub.Name = "Subject Name";
            newSub.Color = Color.RoyalBlue;
            SubjectUI subjectSetupUI = new SubjectUI(newSub);
            if(subjectSetupUI.ShowDialog() == DialogResult.OK)
            {
                lessonPlanYearControl.addSubject(newSub);
                this.fastObjectListView1.ClearObjects();
                this.fastObjectListView1.AddObjects(lessonPlanYearControl.getSubjects());
            }
            // TODO handle close and return
        }

        private void editSubjectStripMenuItem_Click(object sender, EventArgs e)
        {
            if(sender is BrightIdeasSoftware.FastObjectListView)
            {
                Subject sub = (Subject)((BrightIdeasSoftware.FastObjectListView)sender).SelectedObject;
                SubjectUI subjectSetupUI = new SubjectUI(sub);
                subjectSetupUI.ShowDialog();
            }
            
            // TODO handle close and return
        }

        private void deleteSubjectStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO display list of all subjects and allow user to remove.
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


    }
}
