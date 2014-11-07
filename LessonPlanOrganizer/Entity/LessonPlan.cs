using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms.Calendar;

namespace LessonPlanOrganizer
{
    [Serializable]
    class LessonPlan : CalendarItem
    {
        public LessonPlan(Calendar year)
            : base(year)
        {
        }

        public LessonPlan(Calendar year, DateTime start, TimeSpan duration, String title)
            : base(year, start, duration, title)
        {
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


    }
}
