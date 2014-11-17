using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Calendar;

namespace LessonPlanOrganizer
{
    public partial class LessonUI : Form
    {
        public LessonUI(Object cal)
        {
            InitializeComponent();
            
            this.associatedProject.DisplayMember = "Name";
            this.associatedProject.Items.AddRange(LessonPlanYearControl.Instance.getSubjects().ToArray());

            if (cal is LessonPlan)
            {
                _lessonPlan = (LessonPlan)cal;
            }
            else
            {
                CalendarItem calItem = (cal is CalendarItem) ? (CalendarItem)cal : (((Calendar)cal).Items.Count > 0) ? ((Calendar)cal).Items.FirstOrDefault() : new CalendarItem((Calendar)cal);
                _lessonPlan = new LessonPlan(calItem.Calendar, calItem.StartDate, calItem.EndDate, calItem.Text);
            }
            setupUI();
        }
        private LessonPlan _lessonPlan;

        private void setupUI()
        {
            this.lessonTitle.Text = _lessonPlan.Text;
            this.dateSelection.Value = _lessonPlan.StartDate;
            this.numStartHour.Value = _lessonPlan.StartDate.Hour;
            this.numStartMin.Value = _lessonPlan.StartDate.Minute;
            this.numDurHour.Value = _lessonPlan.Duration.Hours;
            this.numDurMin.Value = _lessonPlan.Duration.Minutes;
            int index = this.associatedProject.Items.IndexOf(_lessonPlan.Subject);
            this.associatedProject.SelectedIndex = index;
            this.textBoxNotes.Text = _lessonPlan.Notes;
        }

        private void setLessonPlan()
        {
            // TODO validate all the fields for lesson plan first...
            this._lessonPlan.Text = this.lessonTitle.Text;
            DateTime startDate = new DateTime(this.dateSelection.Value.Year, this.dateSelection.Value.Month, this.dateSelection.Value.Day, (int)this.numStartHour.Value, (int)this.numStartMin.Value, 0);
            this._lessonPlan.StartDate = startDate;
            DateTime endDate = startDate.AddHours((int)this.numDurHour.Value).AddMinutes((int)this.numDurMin.Value);
            this._lessonPlan.EndDate = endDate;
            this._lessonPlan.Subject = (Subject)this.associatedProject.SelectedItem;
            this._lessonPlan.Notes = this.textBoxNotes.Text;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            setLessonPlan();
            LessonPlanYearControl.Instance.addLessonPlans(this._lessonPlan);
            EventsControl.RaiseLessonChanged(this._lessonPlan, EventArgs.Empty);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            LessonPlanYearControl.Instance.removeLesson(this._lessonPlan);
            this.DialogResult = DialogResult.None;
            this.Close();
        }
    }
}
