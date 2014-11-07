using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms.Calendar;

namespace LessonPlanOrganizer
{
    class LessonPlanYearControl : Calendar
    {
        public LessonPlanYearControl() : base()
        {
            _lessonPlans = new List<LessonPlan>();
            _subjects = new List<Subject>();
        }
        private List<LessonPlan> _lessonPlans;
        public List<LessonPlan> GetLessonPlans()
        {
            return _lessonPlans;
        }
        public void SetLessonPlans(List<LessonPlan> lessons)
        {
            _lessonPlans = lessons;
        }

        private List<Subject> _subjects;
        public List<Subject> GetSubjects()
        {
            if (_subjects == null)
                return new List<Subject>();
            return _subjects;
        }
        public void SetSubjects(List<Subject> subjects)
        {
            _subjects = subjects;
        }
        

        public void loadLessonsIntoUIDisplay(DateTime start, DateTime end)
        {
            //targetDt.Ticks > d1.Ticks && targetDt.Ticks < d2.Ticks
            List<LessonPlan> passLessons = _lessonPlans.Where(l => (l.StartDate.Ticks >= start.Ticks && l.StartDate.Ticks <= end.Ticks)).ToList<LessonPlan>();
            if(passLessons != null)
                this.Items.AddRange(passLessons);
        }
    }  
}
