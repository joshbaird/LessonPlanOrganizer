using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LessonPlanOrganizer
{
    class LessonPlan
    {
        public LessonPlan()
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
