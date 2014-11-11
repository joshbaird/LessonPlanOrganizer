using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms.Calendar;

namespace LessonPlanOrganizer
{
    public class LessonPlanYearControl
    {
        public LessonPlanYearControl()
        {
            LessonPlanYear.Instance.LessonPlans = new List<LessonPlan>();
            LessonPlanYear.Instance.Subjects = new List<Subject>();
            EventsControl.AddNewSubject += (o, e) =>
            {
                addSubject(((EventsControl.SubjectEventArgs)e).Subject);
            };
            EventsControl.RemoveSubject += (o, e) =>
            {
                removeSubject(((EventsControl.SubjectEventArgs)e).Subject);
            };
        }

        public List<LessonPlan> GetLessonsForCalendarDisplay(DateTime start, DateTime end)
        {
            return LessonPlanYear.Instance.LessonPlans.Where(l => (l.StartDate.Ticks >= start.Ticks && l.StartDate.Ticks <= end.Ticks)).ToList<LessonPlan>();
        }

        #region Lesson methods
        public void addLessonPlans(LessonPlan item)
        {
            LessonPlanYear.Instance.LessonPlans.Add(item);
            EventsControl.RaiseLessonChanged(this, EventArgs.Empty);
        }
        public System.Collections.ICollection getLessonPlans()
        {
            return LessonPlanYear.Instance.LessonPlans;
        }
        #endregion

        #region Subject methods
        public void addSubject(Subject item)
        {
            LessonPlanYear.Instance.Subjects.Add(item);
            EventsControl.RaiseSubjectChanged(this, EventArgs.Empty);
        }
        public void removeSubject(Subject item)
        {
            LessonPlanYear.Instance.Subjects.Remove(item);
            EventsControl.RaiseSubjectChanged(this, EventArgs.Empty);
        }
        public System.Collections.ICollection getSubjects()
        {
            return LessonPlanYear.Instance.Subjects;
        }
        #endregion
    }  
}
