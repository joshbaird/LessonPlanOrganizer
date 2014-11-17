using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LessonPlanOrganizer
{
    public partial class LessonYearUI : Form
    {
        public LessonYearUI(String mode)
        {
            InitializeComponent();
            _oldSubjects = LessonPlanYearControl.Instance.getSubjects().Select(i => i).ToList<Subject>();
            _oldLessons = LessonPlanYearControl.Instance.getLessonPlans().Select(i => i).ToList<LessonPlan>();
            _oldStart = LessonPlanYearControl.Instance.getStartDate();
            _oldEnd = LessonPlanYearControl.Instance.getEndDate();

        }
        private List<Subject> _oldSubjects;
        private List<LessonPlan> _oldLessons;
        private DateTime _oldStart;
        private DateTime _oldEnd;

        private void closeButton_Click(object sender, EventArgs e)
        {
            // restore changes
            LessonPlanYearControl.Instance.createNewYear(_oldStart, _oldEnd, _oldSubjects, _oldLessons);
            EventsControl.RaiseSubjectChanged(this, EventArgs.Empty);
            EventsControl.RaiseLessonChanged(this, EventArgs.Empty);
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            // create new lesson year
            LessonPlanYearControl.Instance.createNewYear(this.startDatePicker.Value, this.endDatePicker.Value, LessonPlanYearControl.Instance.getSubjects(), LessonPlanYearControl.Instance.getLessonPlans());
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
