﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using iTextSharp.text;
using iTextSharp.text.pdf;

namespace LessonPlanOrganizer
{
    class SubjectStatsReport : Report
    {
        String subject;
        int requiredTime, grandTotal;
        SubStatsPdfEventHandler eventHandler;
        

        public SubjectStatsReport(DateTime startD, DateTime endD,
                                    String sub, int reqTime, ReportControl ctrl)
        {
            startDate = startD;
            endDate = endD;
            reportGenerationDate = System.DateTime.Today;
            reportFilePath = generateReportFilePath();
            subject = sub;
            requiredTime = reqTime;
            grandTotal = 0;
            eventHandler = new SubStatsPdfEventHandler(subject);
            fontSetup = FontFactory.GetFont(FontFactory.TIMES, 12, iTextSharp.text.Font.NORMAL);
            controller = ctrl;
        }


        /****************************
         * Public Methods
         ****************************/

        public String getSubject ()
        {
            return subject;
        }

        public int getRequiredTime()
        {
            return requiredTime;
        }

        public int getGrandTotal()
        {
            return grandTotal;
        }


        override public void generateReport()
        {
            using (var destinationFileStream = new FileStream(reportFilePath, FileMode.Create))
            {
                Document doc = new Document(iTextSharp.text.PageSize.LETTER, 20, 20, 70, 50);
                PdfWriter wr = PdfWriter.GetInstance(doc, destinationFileStream);
                doc.Open();
                wr.PageEvent = eventHandler;
                addReportDetailsData(doc);

                //Configure the data table.
                PdfPTable data = new PdfPTable(4);
                data.HorizontalAlignment = Element.ALIGN_LEFT;
                data.HeaderRows = 1;
                addTableHeaderRows(data);

                /*
                 * Testing DB Integration
                 */
                List<LessonPlan> lessons = controller.getLessonPlansForDateRangeSubject();
                
                if (lessons.Count != 0)
                {
                    for (int i = 0; i < lessons.Count; i++)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(lessons.ElementAt(i).CalendarItem.StartDate.ToShortDateString(), fontSetup));
                        data.AddCell(cell);
                        cell.Phrase = new Phrase(lessons.ElementAt(i).CalendarItem.StartDate.ToShortTimeString() + " - " + 
                                                 lessons.ElementAt(i).CalendarItem.EndDate.ToShortTimeString(), fontSetup);
                        data.AddCell(cell);
                        TimeSpan duration = (lessons.ElementAt(i).CalendarItem.EndDate - lessons.ElementAt(i).CalendarItem.StartDate);
                        int numMins = Convert.ToInt32(duration.TotalMinutes);
                        cell.Phrase = new Phrase(numMins.ToString(), fontSetup);
                        data.AddCell(cell);
                        grandTotal = grandTotal + numMins;
                        cell.Phrase = new Phrase(Convert.ToString(grandTotal), fontSetup);
                        data.AddCell(cell);
                    }
                    addSeparatorRows(data);
                    addCalculationRows(data, Convert.ToInt16(grandTotal), requiredTime);
                }
                else
                {
                    PdfPCell cell = new PdfPCell(new Phrase("No Data for Selected Date Range.", fontSetup));
                    cell.Colspan = 4;
                    data.AddCell(cell);
                }
                doc.Add(data);
                doc.Close();
                wr.Close();
            }
            addPageNumbers();
        }



        /***************************
         * Private Methods
         ***************************/

        /*
         * Generate the report's file path. Uses the current 
         * user's Temp directory.
         */
        override protected String generateReportFilePath()
        {
            String filePath = Path.GetTempPath() + "\\Subject Statistics Report -" +
                                System.DateTime.Today.Year + System.DateTime.Today.Month +
                                System.DateTime.Today.Day + System.DateTime.Now.Hour +
                                System.DateTime.Now.Minute + System.DateTime.Now.Second + ".pdf";
            return filePath;
        }


        /*
        * Add the report details block on the top of the first 
        * page.
        */
        override protected void addReportDetailsData(Document d)
        {
            Paragraph dataSet = new Paragraph("Report Generation Date: " + reportGenerationDate.ToShortDateString() + "\n" +
                                                "Subject: " + subject + "\n" +
                                                "Date Range: " + startDate.ToShortDateString() + " - " + endDate.ToShortDateString() + "\n" +
                                                "Required Time (in minutes): " + requiredTime.ToString() + "\n \n",
                                                FontFactory.GetFont(FontFactory.TIMES, 12, iTextSharp.text.Font.NORMAL));
            d.Add(dataSet);
        }


        /*
         * Add the header table rows to the report table.
         * This is only called on the first page, the automated repeat row 
         * function takes care of all following pages.
        */
        override protected void addTableHeaderRows (PdfPTable tbl)
        {
            iTextSharp.text.Font newfontSetup = FontFactory.GetFont(FontFactory.TIMES, 12, iTextSharp.text.Font.BOLD);
            PdfPCell cell = new PdfPCell(new Phrase("Date", newfontSetup));
            cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
            tbl.AddCell(cell);
            cell.Phrase = new Phrase("Time Slot", newfontSetup);
            tbl.AddCell(cell);
            cell.Phrase = new Phrase("Num. Minutes", newfontSetup);
            tbl.AddCell(cell);
            cell.Phrase = new Phrase("Running Total", newfontSetup);
            tbl.AddCell(cell);
        }


        /*
         * Add the separator rows after all data has been added
         * to the table. 
         */
        private void addSeparatorRows(PdfPTable tbl)
        {

            PdfPCell cell = new PdfPCell(new Phrase(" ", fontSetup));
            cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
            tbl.AddCell(cell);
            tbl.AddCell(cell);
            tbl.AddCell(cell);
            tbl.AddCell(cell);

        }


        /*
         * Add the grand total, required time, and difference rows 
         * to the table. 
         */
        private void addCalculationRows(PdfPTable tbl, int total, int reqTime)
        {

            iTextSharp.text.Font newfontSetup = FontFactory.GetFont(FontFactory.TIMES, 12, iTextSharp.text.Font.BOLD);
            //newfontSetup.SetStyle(iTextSharp.text.Font.BOLD);
            PdfPCell cell = new PdfPCell(new Phrase(" ", newfontSetup));

            tbl.AddCell(cell);
            tbl.AddCell(cell);
            cell.Phrase = new Phrase("Grand Total", newfontSetup);
            tbl.AddCell(cell);
            cell.Phrase = new Phrase(total.ToString(), newfontSetup);
            tbl.AddCell(cell);

            cell.Phrase = new Phrase(" ", fontSetup);
            tbl.AddCell(cell);
            cell.Phrase = new Phrase(" ", fontSetup);
            tbl.AddCell(cell);
            cell.Phrase = new Phrase("Required Time", newfontSetup);
            tbl.AddCell(cell);
            cell.Phrase = new Phrase(reqTime.ToString(), newfontSetup);
            tbl.AddCell(cell);

            cell.Phrase = new Phrase(" ", fontSetup);
            tbl.AddCell(cell);
            cell.Phrase = new Phrase(" ", fontSetup);
            tbl.AddCell(cell);
            cell.Phrase = new Phrase("Difference", newfontSetup);
            tbl.AddCell(cell);
            int difference = reqTime - total;
            cell.Phrase = new Phrase(difference.ToString(), newfontSetup);
            tbl.AddCell(cell);

        }


    }
}
