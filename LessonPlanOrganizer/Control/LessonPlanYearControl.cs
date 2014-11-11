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
        }

        public List<LessonPlan> GetLessonsForCalendarDisplay(DateTime start, DateTime end)
        {
            return LessonPlanYear.Instance.LessonPlans.Where(l => (l.StartDate.Ticks >= start.Ticks && l.StartDate.Ticks <= end.Ticks)).ToList<LessonPlan>();
        }

        #region Lesson methods and events
        public static event EventHandler LessonChanged;
        internal void addLessonPlans(LessonPlan item)
        {
            LessonPlanYear.Instance.LessonPlans.Add(item);
            if(LessonChanged != null)
                LessonChanged.Invoke(this, new EventArgs());
        }
        public System.Collections.ICollection getLessonPlans()
        {
            return LessonPlanYear.Instance.LessonPlans;
        }
        #endregion

        #region Subject methods and events
        public static event EventHandler SubjectChanged;
        internal void addSubject(Subject item)
        {
            LessonPlanYear.Instance.Subjects.Add(item);
            if(SubjectChanged != null)
                SubjectChanged.Invoke(this, new EventArgs());
        }
        public System.Collections.ICollection getSubjects()
        {
            return LessonPlanYear.Instance.Subjects;
        }
        #endregion
    }  
}
