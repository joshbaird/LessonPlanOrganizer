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
            _lessonPlans = new List<LessonPlan>();
            _subjects = new List<Subject>();
        }
        private List<LessonPlan> _lessonPlans;
        public List<LessonPlan> LessonPlans
        {
            get
            {
                if (_lessonPlans == null)
                    return new List<LessonPlan>();
                return _lessonPlans;
            }
            set
            {
                _lessonPlans = value;
            }
        }

        private List<Subject> _subjects;
        public List<Subject> Subjects
        {
            get
            {
                if (_subjects == null)
                    return new List<Subject>();
                return _subjects;
            }
            set
            {
                _subjects = value;
            }
        }
        

        public List<LessonPlan> GetLessonsForCalendarDisplay(DateTime start, DateTime end)
        {
            return LessonPlans.Where(l => (l.StartDate.Ticks >= start.Ticks && l.StartDate.Ticks <= end.Ticks)).ToList<LessonPlan>();
        }
    }  
}
