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
        /// Generate a subject statistics report
        /// </summary>
        /// <param name="subject">The subject to generate the report for</param>
        /// <param name="startDate">Start date for reporting</param>
        /// <param name="endDate">End date for reporting</param>
        /// <param name="requredTime">Instructional minuets required for subject</param>
        /// <returns>Report object for display</returns>
        public Report generateSubStatsReport(String subject, DateTime startDate, DateTime endDate, int requredTime) 
        {
            // validate inputs:

            // validate connection to database

            // generate report

            // return report
            return this;
        }

        /// <summary>
        /// Generate a Lesson Plan Report
        /// </summary>
        /// <param name="reportType">Report Type</param>
        /// <param name="startDate">Start date for reporting</param>
        /// <param name="endDate">End date for reporting</param>
        /// <returns>Report Object for Display</returns>
        public Report generateLessonPlanReport(String reportType, DateTime startDate, DateTime endDate)
        {
            // validate inputs:

            // validate connection to database

            // validate Lesson Plan Year Created

            // generate report

            // return report
            return this;
        }

        /// <summary>
        /// Sends a Report to the Printer
        /// </summary>
        /// <param name="r">Report for printing</param>
        /// <returns>True if job is printed, false if there was a problem</returns>
        public Boolean printReport(Report r)
        {
            // validate input report is generated and displayed

            // pack and send report to printer.


            return true;
        }
    }
}
