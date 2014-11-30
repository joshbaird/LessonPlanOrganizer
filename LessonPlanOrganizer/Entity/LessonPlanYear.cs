using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LessonPlanOrganizer
{
    [System.Serializable]
    public class LessonPlanYear
    {
        // implement singleton
        //private static LessonPlanYear instance;

        public LessonPlanYear() { }
        public LessonPlanYear(DateTime startDate, DateTime endDate, List<Subject> subjects, List<LessonPlan> lessonPlans)
        {
            createLessonPlanYear(startDate, endDate, subjects, lessonPlans);
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

        DateTime _startDate;
        public DateTime StartDate
        {
            get
            {
                if (_startDate == null)
                    _startDate = new DateTime();
                return _startDate;
            }
            set
            {
                _startDate = value;
            }
        }
        DateTime _endDate;
        public DateTime EndDate
        {
            get
            {
                if (_endDate == null)
                    _endDate = new DateTime();
                return _endDate;
            }
            set
            {
                _endDate = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public LessonPlanYear createLessonPlanYear(DateTime startDate, DateTime endDate, List<Subject> subjects, List<LessonPlan> lessonPlans)
        {
            this._startDate = startDate;
            this._endDate = endDate;
            this._subjects = subjects;
            this._lessonPlans = lessonPlans;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public LessonPlanYear displayLessonPlanYear(DateTime startDate, DateTime endDate)
        {
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public LessonPlanYear selectLessonPlanYear(DateTime startDate, DateTime endDate)
        {
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public LessonPlanYear editLessonPlanYear(DateTime startDate, DateTime endDate)
        {
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public LessonPlanYear deleteLessonPlanYear(DateTime startDate, DateTime endDate)
        {
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public LessonPlanYear saveLessonPlanYear(DateTime startDate, DateTime endDate)
        {
            return this;
        }
    }
}
