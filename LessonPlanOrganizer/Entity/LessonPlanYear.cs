using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LessonPlanOrganizer
{
    public class LessonPlanYear
    {
        // implement singleton
        private static LessonPlanYear instance;

        private LessonPlanYear() { }

        public static LessonPlanYear Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LessonPlanYear();
                }
                return instance;
            }
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
        DateTime _endDate;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public LessonPlanYear createLessonPlanYear(DateTime startDate, DateTime endDate)
        {
            _startDate = startDate;
            _endDate = endDate;
            _subjects = new List<Subject>();
            _lessonPlans = new List<LessonPlan>();
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
