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
            // TODO replace dateTimes with actual dates and times.
            _lessonPlanYear = LessonPlanYear.Instance.createLessonPlanYear(new DateTime(), new DateTime());
            EventsControl.AddNewSubject += (o, e) =>
            {
                addSubject(((EventsControl.SubjectEventArgs)e).Subject);
            };
            EventsControl.RemoveSubject += (o, e) =>
            {
                removeSubject(((EventsControl.SubjectEventArgs)e).Subject);
            };
        }

        private LessonPlanYear _lessonPlanYear;

        public List<LessonPlan> GetLessonsForCalendarDisplay(DateTime start, DateTime end)
        {
            return _lessonPlanYear.LessonPlans.Where(l => (l.StartDate.Ticks >= start.Ticks && l.StartDate.Ticks <= end.Ticks)).ToList<LessonPlan>();
        }

        #region Lesson methods
        public void addLessonPlans(LessonPlan item)
        {
            _lessonPlanYear.LessonPlans.Add(item);
            EventsControl.RaiseLessonChanged(this, EventArgs.Empty);
        }
        public System.Collections.ICollection getLessonPlans()
        {
            return _lessonPlanYear.LessonPlans;
        }
        #endregion

        #region Subject methods
        public void addSubject(Subject item)
        {
            _lessonPlanYear.Subjects.Add(item);
            EventsControl.RaiseSubjectChanged(this, EventArgs.Empty);
        }
        public void removeSubject(Subject item)
        {
            _lessonPlanYear.Subjects.Remove(item);
            EventsControl.RaiseSubjectChanged(this, EventArgs.Empty);
        }
        public System.Collections.ICollection getSubjects()
        {
            return _lessonPlanYear.Subjects;
        }
        #endregion
    }  
}
