using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonPlanOrganizer
{
    class ReportControl
    {
        DateTime startDate, endDate;
        String reportType, subject, viewType;
        int requiredTime;
        Report report;

        /*
         * Code to add later:
         * Report report;
         */

        public ReportControl (DateTime startD, DateTime endD, String sub, String view, String rptType, int reqTime)
        {
            startDate = startD;
            endDate = endD;
            subject = sub;
            viewType = view;
            requiredTime = reqTime;
            reportType = rptType;

            if (rptType == "Subject Statistics") report = new SubjectStatsReport (startD, endD, sub, reqTime);
            if (reportType == "Lesson Plan") report = new LessonPlanReport(startD, endD, viewType);
        }


        public void generateReport()
        {
            report.generateReport();
        }


        public void viewReport ()
        {
            reportViewer view = new reportViewer (report.getReportFilePath());
            view.Visible = true;
            
        }




    }
}
