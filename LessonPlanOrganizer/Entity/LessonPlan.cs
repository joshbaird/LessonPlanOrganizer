using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms.Calendar;

namespace LessonPlanOrganizer
{
    [System.Serializable]
    public class LessonPlan: IEquatable<LessonPlan>
    {
        public LessonPlan(Calendar year)
        {
            _calendarItem = new CalendarItem(year);
            EventsControl.SubjectChanged += handleSubjectChange;
        }
        public LessonPlan(Calendar calendar, DateTime startDate, DateTime endDate, String text)
        {
            _calendarItem = new CalendarItem(calendar, startDate, endDate, text);
            EventsControl.SubjectChanged += handleSubjectChange;
        }

        public LessonPlan(Calendar year, DateTime start, TimeSpan duration, String title)
        {
            _calendarItem = new CalendarItem(year, start, duration, title);
            EventsControl.SubjectChanged += handleSubjectChange;
        }
        ~LessonPlan()
        {
            removeBindings();
        }

        private CalendarItem _calendarItem;
        public CalendarItem CalendarItem
        {
            get
            {
                if (_calendarItem == null)
                    _calendarItem = new CalendarItem(new Calendar());
                return _calendarItem;
            }
            set
            {
                _calendarItem = value;
            }
       
        }



        private Subject _subject;

        public Subject Subject
        {
            get
            {
                if (_subject == null)
                    _subject = new Subject();
                return _subject;
            }
            set
            {
                _subject = value;
                this.CalendarItem.BackgroundColor = _subject.Color;
            }
        }

        private String _notes;
        public String Notes
        {
            get
            {
                if (_notes == null)
                    _notes = String.Empty;
                return _notes;
            }
            set
            {
                _notes = value;
            }
        }

        private void handleSubjectChange(Object o, EventArgs e)
        {
            this.CalendarItem.BackgroundColor = _subject.Color;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Year"></param>
        /// <param name="subject"></param>
        /// <param name="lessonPlanDate"></param>
        /// <param name="lessonPlanTime"></param>
        /// <returns></returns>
        public LessonPlan createLessonPlan(LessonPlanYear Year, String subject, DateTime lessonPlanDate, DateTime lessonPlanTime)
        {
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="lessonPlanDate"></param>
        /// <param name="lessonPlanTime"></param>
        /// <returns></returns>
        public LessonPlan selectLessonPlan(String subject, DateTime lessonPlanDate, DateTime lessonPlanTime)
        {
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="lessonPlanDate"></param>
        /// <param name="lessonPlanTime"></param>
        /// <returns></returns>
        public LessonPlan displayLessonPlan(String subject, DateTime lessonPlanDate, DateTime lessonPlanTime)
        {
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Year"></param>
        /// <param name="subject"></param>
        /// <param name="lessonPlanDate"></param>
        /// <param name="lessonPlanTime"></param>
        /// <returns></returns>
        public LessonPlan saveLessonPlan(LessonPlanYear Year, String subject, DateTime lessonPlanDate, DateTime lessonPlanTime)
        {
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="lessonPlanDate"></param>
        /// <param name="lessonPlanTime"></param>
        /// <returns></returns>
        public LessonPlan editLessonPlan (String subject, DateTime lessonPlanDate, DateTime lessonPlanTime)
        {
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="lessonPlanDate"></param>
        /// <param name="lessonPlanTime"></param>
        /// <returns></returns>
        public Boolean deleteLessonPlan(String subject, DateTime lessonPlanDate, DateTime lessonPlanTime)
        {
            return true;
        }

        public bool Equals(LessonPlan other)
        {
            return (String.Equals(this.Notes, other.Notes) &&
                    this.Subject == other.Subject &&
                    this.CalendarItem.Equals(other.CalendarItem));
        }

        internal void removeBindings()
        {
            EventsControl.SubjectChanged -= handleSubjectChange;
        }
    }
}
