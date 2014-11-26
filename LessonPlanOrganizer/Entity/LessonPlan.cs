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
        private LessonPlan(Calendar year)
        {
            _calendarItem = new CalendarItem(year);
            EventsControl.SubjectChanged += handleSubjectChange;
        }
        private LessonPlan(Calendar calendar, DateTime startDate, DateTime endDate, String text)
        {
            _calendarItem = new CalendarItem(calendar, startDate, endDate, text);
            EventsControl.SubjectChanged += handleSubjectChange;
        }

        private LessonPlan(Calendar year, DateTime start, TimeSpan duration, String title)
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
        /// <param name="year"></param>
        /// <param name="lessonPlanDate"></param>
        /// <param name="lessonPlanTime"></param>
        /// <param name="title"></param>
        /// <param name="notes"></param>
        /// <returns></returns>
        public static LessonPlan createLessonPlan(Calendar year, DateTime lessonPlanDate, TimeSpan lessonPlanTime, String title, String notes = "none")
        {
            LessonPlan lp = new LessonPlan(year, lessonPlanDate, lessonPlanTime, title);
            lp.Notes = notes;
            return lp;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <param name="lessonPlanStartDate"></param>
        /// <param name="lessonPlanEndDate"></param>
        /// <param name="title"></param>
        /// <param name="notes"></param>
        /// <returns></returns>
        public static LessonPlan createLessonPlan(Calendar year, DateTime lessonPlanStartDate, DateTime lessonPlanEndDate, String title, String notes = "none")
        {
            LessonPlan lp = new LessonPlan(year, lessonPlanStartDate, lessonPlanEndDate, title);
            lp.Notes = notes;
            return lp;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <param name="notes"></param>
        /// <returns></returns>
        public static LessonPlan createLessonPlan(Calendar year, String notes = "none")
        {
            LessonPlan lp = new LessonPlan(year);
            lp.Notes = notes;
            return lp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="calItem"></param>
        /// <returns></returns>
        public LessonPlan selectLessonPlan(CalendarItem calItem)
        {
            if (this.CalendarItem.Equals(calItem))
                return this;
            else
                return null;
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
        /// <returns></returns>
        public Boolean deleteLessonPlan()
        {
            this.removeBindings();
            LessonPlanYearControl.Instance.removeLesson(this);
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
