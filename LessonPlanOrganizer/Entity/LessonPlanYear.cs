﻿using System;
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
