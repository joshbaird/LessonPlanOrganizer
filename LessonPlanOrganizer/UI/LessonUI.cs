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

            timeSelection.ShowUpDown = true;
            timeSelection.CustomFormat = " hh mm";
            timeSelection.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            timeDuration.ShowUpDown = true;
            timeDuration.CustomFormat = "  hh:mm";
            timeDuration.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            _lessonPlan = new LessonPlan((Calendar)cal);
            this.associatedProject.DisplayMember = "Name";
            this.associatedProject.Items.AddRange(LessonPlanYearControl.Intance.getSubjects().ToArray());

            if (cal is Calendar && ((Calendar)cal).GetSelectedItems().Count() > 0)
            {
                LessonPlan lp = (LessonPlan)((Calendar)cal).GetSelectedItems().FirstOrDefault();
                this.lessonTitle.Text = lp.Text;
                this.dateSelection.Value = lp.StartDate;
                this.timeSelection.Value = lp.StartDate;
                this.timeDuration.Value = new DateTime(lp.StartDate.Year, lp.StartDate.Month, lp.StartDate.Day, lp.Duration.Hours, lp.Duration.Minutes, 0);
                int index = this.associatedProject.Items.IndexOf(lp.Subject);
                this.associatedProject.SelectedIndex = index;
                this.textBoxNotes.Text = lp.Notes;
            }
                



        }
        private LessonPlan _lessonPlan;

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            // TODO validate all the fields for lesson plan first...

            this._lessonPlan.Text = this.lessonTitle.Text;
            DateTime startDate = this.dateSelection.Value.AddHours(this.timeSelection.Value.Hour).AddMinutes(this.timeSelection.Value.Minute);
            this._lessonPlan.StartDate = startDate;
            DateTime endDate = startDate.AddHours(this.timeDuration.Value.Hour).AddMinutes(this.timeDuration.Value.Minute);
            this._lessonPlan.EndDate = endDate;
            this._lessonPlan.Subject = (Subject)this.associatedProject.SelectedItem;
            this._lessonPlan.Notes = this.textBoxNotes.Text;
            LessonPlanYearControl.Intance.addLessonPlans(this._lessonPlan);
            EventsControl.RaiseLessonChanged(this._lessonPlan, EventArgs.Empty);
        }
    }
}
