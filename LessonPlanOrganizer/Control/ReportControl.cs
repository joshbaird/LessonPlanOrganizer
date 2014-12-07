using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public ReportControl (DateTime startD, DateTime endD, Subject sub, String view, String rptType, int reqTime)
        {
            startDate = startD;
            endDate = endD;
            subject = sub.Name;
            viewType = view;
            requiredTime = reqTime;
            reportType = rptType;

            if (rptType == "Subject Statistics") report = new SubjectStatsReport (startD, endD, subject, reqTime, this);
            if (reportType == "Lesson Plan") report = new LessonPlanReport(startD, endD, viewType, this);
        }


        public void generateReport()
        {
            report.generateReport();
        }


        public void viewReport ()
        {
            if (checkAdobeInstalled() == true)
            {
                reportViewer view = new reportViewer(report.getReportFilePath());
                view.Visible = true;
            }

            else
            {
                String message = "Adobe Reader NOT Found.\nPlease install Adobe Reader and then run your report again.\nhttp://www.adobe.com/products/reader.html";
                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        public List<LessonPlan> getAllLessonPlans ()
        {

            List<LessonPlan> lessons = LessonPlanYearControl.Instance.getLessonPlans();
            return lessons;
        }

        public List<LessonPlan> getLessonPlansForDateRangeSubject ()
        {
            List<LessonPlan> allLessons = LessonPlanYearControl.Instance.getLessonPlans();
            List<LessonPlan> requestedLessons = new List<LessonPlan>();
            //modify start/end dates because the times break the conditional.
            DateTime modifiedStartDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, 0, 0, 0);
            DateTime modifiedEndDate = new DateTime(endDate.Year, endDate.Month, endDate.Day, 23, 59, 59);

            for (int i = 0; i < allLessons.Count; i++)
            {
                int lessonAfterStartDate = DateTime.Compare(allLessons.ElementAt(i).CalendarItem.StartDate, modifiedStartDate);
                int lessonBeforeEndDate = DateTime.Compare(allLessons.ElementAt(i).CalendarItem.StartDate, modifiedEndDate);
                if (lessonAfterStartDate >= 0  && lessonBeforeEndDate <= 0)
                {
                    if (allLessons.ElementAt(i).Subject.Name == subject) requestedLessons.Add(allLessons.ElementAt(i));
                }
            }
            requestedLessons.Sort(new LessonPlanComp());
            return requestedLessons;
        }

        public List<LessonPlan> getLessonPlansForDate (DateTime date)
        {
            List<LessonPlan> allLessons = LessonPlanYearControl.Instance.getLessonPlans();
            List<LessonPlan> requestedLessons = new List<LessonPlan>();

            //modify start/end dates because the times break the conditional.
            DateTime modifiedStartDate = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
            DateTime modifiedEndDate = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);

            for (int i = 0; i < allLessons.Count; i++)
            {
                int lessonAfterStartDate = DateTime.Compare(allLessons.ElementAt(i).CalendarItem.StartDate, modifiedStartDate);
                int lessonBeforeEndDate = DateTime.Compare(allLessons.ElementAt(i).CalendarItem.StartDate, modifiedEndDate);
                if (lessonAfterStartDate >= 0 && lessonBeforeEndDate <= 0)
                {
                    requestedLessons.Add(allLessons.ElementAt(i));
                }
            }
            requestedLessons.Sort(new LessonPlanComp());
            return requestedLessons;
        }


        public Boolean checkAdobeInstalled()
        {
            Boolean acroFound = false;

            //check for 32 bit version 
            RegistryKey adobeReader32 = Registry.LocalMachine.OpenSubKey("Software").OpenSubKey("Adobe");
            if (adobeReader32 != null)
            { 
                RegistryKey acroRead = adobeReader32.OpenSubKey("Acrobat Reader");
                if (acroRead != null) acroFound = true;

                RegistryKey adobeAcro = adobeReader32.OpenSubKey("Adobe Acrobat");
                if (adobeAcro != null) acroFound = true;
            }

            //check for 64 bit version of Acrobat Reader
            RegistryKey adobeReader64 = Registry.LocalMachine.OpenSubKey("Software").OpenSubKey("Wow6432Node");
            if (adobeReader64 != null)
            {
                adobeReader64 = adobeReader64.OpenSubKey("Adobe");
                if (adobeReader64 != null)
                {
                    RegistryKey acroReader = adobeReader64.OpenSubKey("Acrobat Reader");
                    if (acroReader != null) acroFound = true;

                    RegistryKey adobeAcro = adobeReader64.OpenSubKey("Adobe Acrobat");
                    if (adobeAcro != null) acroFound = true;
                }
            }

            return acroFound;
         }
    }
    
}
