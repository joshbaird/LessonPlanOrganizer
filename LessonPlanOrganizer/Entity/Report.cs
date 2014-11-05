using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LessonPlanOrganizer
{
    class Report
    {
        private Report()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="requredTime"></param>
        /// <returns></returns>
        public Report generateSubStatsReport(String subject, DateTime startDate, DateTime endDate, int requredTime) 
        {
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reportType"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public Report generateLessonPlanReport(String reportType, DateTime startDate, DateTime endDate)
        {
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        public void printReport(Report r)
        {

        }
    }
}
