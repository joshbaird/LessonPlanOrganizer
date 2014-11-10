using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms.Calendar;

namespace LessonPlanOrganizer
{
    class LessonPlanYearControl
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

        internal System.Collections.ICollection getSubjects()
        {
            return LessonPlanYear.Instance.Subjects;
        }

        internal void addLessonPlans(LessonPlan item)
        {
            LessonPlanYear.Instance.LessonPlans.Add(item);
        }

        internal void addSubject(Subject item)
        {
            LessonPlanYear.Instance.Subjects.Add(item);
        }
    }  
}
