﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms.Calendar;

namespace LessonPlanOrganizer
{
    public class LessonPlanYearControl
    {
        private static LessonPlanYearControl instance;

        private LessonPlanYearControl()
        {
            // TODO replace dateTimes with actual dates and times.
            _lessonPlanYear = LessonPlanYear.Instance.createLessonPlanYear(new DateTime(), new DateTime(), new List<Subject>(), new List<LessonPlan>());
            EventsControl.AddNewSubject += (o, e) =>
            {
                addSubject(((Subject)o));
            };
            EventsControl.RemoveSubject += (o, e) =>
            {
                removeSubject((Subject)o);
            };
        }

        public static LessonPlanYearControl Instance
        {
            get
            {
                if (instance == null)
                    instance = new LessonPlanYearControl();
                return instance;
            }
            set
            {
                // TODO need to pass new date Times here
                instance = new LessonPlanYearControl();
            }
        }


        private LessonPlanYear _lessonPlanYear;

        public List<LessonPlan> GetLessonsForCalendarDisplay(DateTime start, DateTime end)
        {
            return _lessonPlanYear.LessonPlans.Where(l => (l.StartDate.Ticks >= start.Ticks && l.StartDate.Ticks <= end.Ticks)).ToList<LessonPlan>();
        }

        #region Lesson methods
        public void addLessonPlans(LessonPlan item)
        {
            if (_lessonPlanYear.LessonPlans.Contains(item))
                return;
            _lessonPlanYear.LessonPlans.Add(item);
            EventsControl.RaiseLessonChanged(this, EventArgs.Empty);
        }
        public List<LessonPlan> getLessonPlans()
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
        public List<Subject> getSubjects()
        {
            return _lessonPlanYear.Subjects;
        }
        #endregion

        internal void removeLesson(LessonPlan lesson)
        {
            _lessonPlanYear.LessonPlans.Remove(lesson);
            lesson.removeBindings();
            EventsControl.RaiseLessonChanged(this, EventArgs.Empty);
        }

        internal void createNewYear(DateTime start, DateTime end, List<Subject> subjects, List<LessonPlan> lessons)
        {
            _lessonPlanYear = LessonPlanYear.Instance.createLessonPlanYear( start, end, subjects, lessons);
        }

        internal DateTime getStartDate()
        {
            return _lessonPlanYear.StartDate;
        }

        internal DateTime getEndDate()
        {
            return _lessonPlanYear.EndDate;
        }
    }  
}
