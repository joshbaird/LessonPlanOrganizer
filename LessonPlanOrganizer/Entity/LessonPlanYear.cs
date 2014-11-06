using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms.Calendar;

namespace LessonPlanOrganizer
{
    class LessonPlanYear
    {
        public LessonPlanYear(Calendar cal)
        {
            Calendar = cal;
        }
        public Calendar Calendar;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public LessonPlanYear createLessonPlanYear(DateTime startDate, DateTime endDate)
        {
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
