﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms.Calendar;
using System.Data.SQLite;

namespace LessonPlanOrganizer
{
    [System.Serializable]
    public class LessonPlanYearControl
    {
        private static LessonPlanYearControl instance;

        private LessonPlanYearControl()
        {
            _dbWrapper = new DataBaseWrapper(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString() + "\\lesson_db.sqlite");
            fillLessonPlanYearFromDb();
            
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
        }
        private Calendar _calendar;
        public Calendar Calendar
        {
            get
            {
                if (_calendar == null)
                    _calendar = new Calendar();
                return _calendar;
            }
            set 
            {
                _calendar = value;
            }
        }


        private LessonPlanYear _lessonPlanYear;
        private DataBaseWrapper _dbWrapper;

        private void fillLessonPlanYearFromDb()
        {
            LessonPlanYear lpy = _dbWrapper.deserializeLessonPlanYear();
            if (lpy != null)
                _lessonPlanYear = lpy;
            else
                _lessonPlanYear = new LessonPlanYear(new DateTime(), new DateTime(), new List<Subject>(), new List<LessonPlan>());
            _lessonPlanYear.LessonPlans.ForEach(l => l.SubScribeBindings());
        }

        public void SavetoDataBase()
        {
            _dbWrapper.serializeLessonPlanYear(_lessonPlanYear);
        }

        public List<CalendarItem> GetLessonCalendarItemsForCalendarDisplay(DateTime start, DateTime end)
        {
            DateTime starting = start.Date;
            return _lessonPlanYear.LessonPlans.Where(l => (l.StartDate.Ticks >= starting.Ticks && l.StartDate.Ticks <= end.Ticks)).Select(c => c.CalendarItem).ToList<CalendarItem>();
        }

        #region Lesson methods
        public void addLessonPlans(LessonPlan item)
        {
            if (_lessonPlanYear.LessonPlans.Contains(item))
                _lessonPlanYear.LessonPlans.Remove(item);
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
            EventsControl.RaiseLessonChanged(this, EventArgs.Empty);
        }
        internal void removeLessonFromCalendarItem(CalendarItem calendarItem)
        {
            removeLesson(_lessonPlanYear.LessonPlans.Find(i => i.CalendarItem.Equals(calendarItem)));
        }

        internal void createNewYear(DateTime start, DateTime end, List<Subject> subjects, List<LessonPlan> lessons)
        {
            _lessonPlanYear = new LessonPlanYear( start, end, subjects, lessons);
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
