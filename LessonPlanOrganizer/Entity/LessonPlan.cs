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
        public LessonPlan() 
        {
        }
        private LessonPlan(Calendar year)
        {
            _startDate = DateTime.Now;
            _endDate = DateTime.Now.Add(new TimeSpan(0, 30, 0));
            _title = "Lesson Title";
            _calendarItem = new CalendarItem(year);
            _id = Guid.NewGuid().ToString("N");
            EventsControl.SubjectChanged += (o,e)=>
            {
                handleSubjectChange(o,e);
            };
        }
        public LessonPlan(Calendar calendar, DateTime startDate, DateTime endDate, String title)
        {
            _startDate = startDate;
            _endDate = endDate;
            _title = title;
            _calendarItem = new CalendarItem(calendar, startDate, endDate, title);
            _id = Guid.NewGuid().ToString("N");
            EventsControl.SubjectChanged += (o, e) =>
            {
                handleSubjectChange(o, e);
            };
        }

        private LessonPlan(Calendar year, DateTime start, TimeSpan duration, String title)
        {
            _startDate = start;
            _endDate = start.Add(duration);
            _title = title;
            _calendarItem = new CalendarItem(year, start, duration, title);
            _id = Guid.NewGuid().ToString("N");
            EventsControl.SubjectChanged += (o, e) =>
            {
                handleSubjectChange(o, e);
            };
        }

        private String _id;
        public String ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        private DateTime _startDate;
        public DateTime StartDate 
        { 
            get 
            {
                if (_startDate == null)
                    _startDate = DateTime.Now;
                return _startDate;
            }
            set 
            {
                _startDate = value;
                CalendarItem.StartDate = _startDate;
            }

        }
        private DateTime _endDate;
        public DateTime EndDate
        {
            get
            {
                if (_endDate == null)
                    _endDate = DateTime.Now;
                return _endDate;
            }
            set
            {
                _endDate = value;
                CalendarItem.EndDate = _endDate;
            }

        }
        private String _title;
        public String Title
        {
            get
            {
                if (_title == null)
                    _title = String.Empty;
                return _title;
            }
            set
            {
                _title = value;
                CalendarItem.Text = _title;
            }
        }

        
        ~LessonPlan()
        {
            removeBindings();
        }

        public void SubScribeBindings()
        {
            EventsControl.SubjectChanged += (o, e) =>
            {
                handleSubjectChange(o, e);
            };
        }

        [System.NonSerialized]
        private CalendarItem _calendarItem;
        public CalendarItem CalendarItem
        {
            get
            {
                if (_calendarItem == null)
                {
                    _calendarItem = new CalendarItem(LessonPlanYearControl.Instance.Calendar, _startDate, _endDate, _title);
                    _calendarItem.BackgroundColor = Subject.Color;
                }
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
            return (String.Equals(this.ID, other.ID));
        }

        internal void removeBindings()
        {
            EventsControl.SubjectChanged -= handleSubjectChange;
        }

        internal void SyncCalendar()
        {
            this._startDate = CalendarItem.StartDate;
            this._endDate = CalendarItem.EndDate;
            this._title = CalendarItem.Text;
        }
    }
}
