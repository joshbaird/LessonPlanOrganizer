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
            
            this.associatedSubject.DisplayMember = "Name";
            this.associatedSubject.Items.AddRange(LessonPlanYearControl.Instance.getSubjects().ToArray());

            if (cal is LessonPlan)
            {
                _lessonPlan = (LessonPlan)cal;
            }
            else
            {
                CalendarItem calItem;
                Subject sub;
                String notes = "none";
                String id = Guid.NewGuid().ToString("N");
                if (cal is CalendarItem)
                {
                    calItem = (CalendarItem)cal;
                    if (LessonPlanYearControl.Instance.getLessonPlans().Where(l => l.selectLessonPlan(calItem) != null).Count() > 0)
                    {
                        LessonPlan lp = LessonPlanYearControl.Instance.getLessonPlans().Where(l => l.selectLessonPlan(calItem) != null).FirstOrDefault();
                        sub = lp.Subject;
                        notes = lp.Notes;
                        id = lp.ID;
                    }
                        
                    else
                        sub = new Subject();
                }
                else
                {
                    calItem = new CalendarItem((Calendar)cal, DateTime.Now, DateTime.Now.AddHours(1), String.Empty);
                    sub = new Subject();
                }
                _lessonPlan = LessonPlan.createLessonPlan(calItem.Calendar, calItem.StartDate, calItem.EndDate, calItem.Text);
                _lessonPlan.Subject = sub;
                _lessonPlan.Notes = notes;
                _lessonPlan.ID = id;
                _lessonPlan.CalendarItem = calItem;
            }
            setupUI();
        }
        private LessonPlan _lessonPlan;

        private void setupUI()
        {
            this.lessonTitle.Text = _lessonPlan.CalendarItem.Text;
            this.dateSelection.Value = _lessonPlan.CalendarItem.StartDate;
            this.numStartHour.Value = _lessonPlan.CalendarItem.StartDate.Hour;
            this.numStartMin.Value = _lessonPlan.CalendarItem.StartDate.Minute;
            this.numDurHour.Value = _lessonPlan.CalendarItem.Duration.Hours;
            this.numDurMin.Value = _lessonPlan.CalendarItem.Duration.Minutes;
            int index = this.associatedSubject.Items.IndexOf(_lessonPlan.Subject);
            this.associatedSubject.SelectedIndex = index;
            this.textBoxNotes.Text = _lessonPlan.Notes;
        }

        private Boolean setLessonPlan()
        {
            if(String.IsNullOrEmpty(this.lessonTitle.Text) || 
                this.associatedSubject.SelectedItem == null)
            {
                MessageBox.Show("Invalid Data found", "Error in Data");
                return false;
            }
            this._lessonPlan.Title = this.lessonTitle.Text;
            DateTime startDate = new DateTime(this.dateSelection.Value.Year, this.dateSelection.Value.Month, this.dateSelection.Value.Day, (int)this.numStartHour.Value, (int)this.numStartMin.Value, 0);
            this._lessonPlan.StartDate = startDate;
            DateTime endDate = startDate.AddHours((int)this.numDurHour.Value).AddMinutes((int)this.numDurMin.Value);
            this._lessonPlan.EndDate = endDate;
            this._lessonPlan.Subject = (Subject)this.associatedSubject.SelectedItem;
            this._lessonPlan.Notes = this.textBoxNotes.Text;
            return true;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!setLessonPlan())
                return;
            LessonPlanYearControl.Instance.addLessonPlans(this._lessonPlan);
            EventsControl.RaiseLessonChanged(this._lessonPlan, EventArgs.Empty);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            this._lessonPlan.deleteLessonPlan();
            this.DialogResult = DialogResult.None;
            this.Close();
        }
    }
}
