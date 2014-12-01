using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.Calendar;

namespace LessonPlanOrganizer
{
    [System.Serializable]
    public class LessonPlanYearControl
    {
        private static LessonPlanYearControl instance;

        private LessonPlanYearControl()
        {
            // TODO replace dateTimes with actual dates and times.
            _dbWrapper = new DataBaseWrapper("lesson_db.sqlite");
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
            // TODO fill the lesson plan Year with the data from DB.

            LessonPlanYear lpy = _dbWrapper.deserializeLessonPlanYear();
            if (lpy != null)
                _lessonPlanYear = lpy;
            else
                _lessonPlanYear = new LessonPlanYear(new DateTime(), new DateTime(), new List<Subject>(), new List<LessonPlan>());
           
            
            // DT: crude testing of serialization/deserialization of LessonPlanYear object
            // will cause null exception error as subject and lesson plan lists are null.
            // OK for removal...
            //
            // Testing serialization here (serialize first then comment out two lines below)
            //_lessonPlanYear = new LessonPlanYear(DateTime.Today.AddDays(1), DateTime.Today, new List<Subject>(), new List<LessonPlan>());
            //_dbWrapper.serializeLessonPlanYear(_lessonPlanYear);

            // Testing deserialization here (deserialized second, uncomment two lines below after running previous)
            //LessonPlanYear newyear = _dbWrapper.deserializeLessonPlanYear();
            //Console.WriteLine("Deserialized object data for newyear: " + newyear.StartDate);
        }

        public void SavetoDataBase()
        {
            _dbWrapper.serializeLessonPlanYear(_lessonPlanYear);
        }

        public List<CalendarItem> GetLessonCalendarItemsForCalendarDisplay(DateTime start, DateTime end)
        {
            return _lessonPlanYear.LessonPlans.Where(l => (l.StartDate.Ticks >= start.Ticks && l.StartDate.Ticks <= end.Ticks)).Select(c => c.CalendarItem).ToList<CalendarItem>();
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
