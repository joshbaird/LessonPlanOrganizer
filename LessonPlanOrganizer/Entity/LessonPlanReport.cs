using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Windows.Forms;

namespace LessonPlanOrganizer
{
    class LessonPlanReport : Report
    {
        String viewType;

        LessonPlanPdfEventHandler eventHandler;


        public LessonPlanReport(DateTime startD, DateTime endD, String view, ReportControl ctrl)
        {
            startDate = startD;
            endDate = endD;
            reportGenerationDate = System.DateTime.Today;
            reportFilePath = generateReportFilePath();
            viewType = view;
            controller = ctrl;
            eventHandler = new LessonPlanPdfEventHandler(viewType);
            fontSetup = FontFactory.GetFont(FontFactory.TIMES, 12, iTextSharp.text.Font.NORMAL);
        }


        /****************************
         * Public Methods
         ****************************/



        override public void generateReport()
        {

            if (viewType == "By Day") generateByDay();
            if (viewType == "By Week") generateByWeek();
            if (viewType == "By Month") generateByMonth();
        }



        /***************************
         * Private/Protected Methods
         ***************************/

        /*
         * Generate the report's file path. Uses the current 
         * user's Temp directory.
         */
        override protected String generateReportFilePath()
        {
            String filePath = Path.GetTempPath() + "\\LessonPlanReport-" +
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
                                                "Date Range: " + startDate.ToShortDateString() + " - " + endDate.ToShortDateString() +
                                                "\n \n",
                                                FontFactory.GetFont(FontFactory.TIMES, 12, iTextSharp.text.Font.NORMAL));
            d.Add(dataSet);
        }


        /*
         * Add the header table rows to the report table.
         * This is only called on the first page, the automated repeat row 
         * function takes care of all following pages.
        */
        override protected void addTableHeaderRows(PdfPTable tbl)
        {
            iTextSharp.text.Font boldfontSetup = FontFactory.GetFont(FontFactory.TIMES, 12, iTextSharp.text.Font.BOLD);

            if (viewType == "By Day")
            {
                PdfPCell cell = new PdfPCell(new Phrase("Time Slot", boldfontSetup));
                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                tbl.AddCell(cell);
                cell.Phrase = new Phrase("Subject", boldfontSetup);
                tbl.AddCell(cell);
                cell.Phrase = new Phrase("Lesson Plan", boldfontSetup);
                tbl.AddCell(cell);
            }

            if (viewType == "By Week")
            {
                PdfPCell cell = new PdfPCell(new Phrase("Monday", boldfontSetup));
                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                tbl.AddCell(cell);
                cell.Phrase = new Phrase("Tuesday", boldfontSetup);
                tbl.AddCell(cell);
                cell.Phrase = new Phrase("Wednesday", boldfontSetup);
                tbl.AddCell(cell);
                cell.Phrase = new Phrase("Thursday", boldfontSetup);
                tbl.AddCell(cell);
                cell.Phrase = new Phrase("Friday", boldfontSetup);
                tbl.AddCell(cell);
                cell.Phrase = new Phrase("Saturday", boldfontSetup);
                tbl.AddCell(cell);
                cell.Phrase = new Phrase("Sunday", boldfontSetup);
                tbl.AddCell(cell);
            }

            if (viewType == "By Month")
            {
                PdfPCell cell = new PdfPCell(new Phrase("Monday", boldfontSetup));
                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                tbl.AddCell(cell);
                cell.Phrase = new Phrase("Tuesday", boldfontSetup);
                tbl.AddCell(cell);
                cell.Phrase = new Phrase("Wednesday", boldfontSetup);
                tbl.AddCell(cell);
                cell.Phrase = new Phrase("Thursday", boldfontSetup);
                tbl.AddCell(cell);
                cell.Phrase = new Phrase("Friday", boldfontSetup);
                tbl.AddCell(cell);
                cell.Phrase = new Phrase("Saturday", boldfontSetup);
                tbl.AddCell(cell);
                cell.Phrase = new Phrase("Sunday", boldfontSetup);
                tbl.AddCell(cell);
            }

        }



        /*
         * Generate report by day.
         */
        private void generateByDay()
        {
            using (var destinationFileStream = new FileStream(reportFilePath, FileMode.Create))
            {
                Document doc = new Document(iTextSharp.text.PageSize.LETTER.Rotate(), 20, 20, 70, 50);
                PdfWriter wr = PdfWriter.GetInstance(doc, destinationFileStream);
                doc.Open();
                wr.PageEvent = eventHandler;
                addReportDetailsData(doc);

                TimeSpan numDays = endDate - startDate;
                int totalDays = Convert.ToInt32(numDays.TotalDays);
                DateTime workingDate = startDate;

                for (int i = 0; i < totalDays + 1; i++)
                {
                    if (i != 0)
                    {
                        doc.NewPage();
                        workingDate = workingDate.AddDays(1);
                    }

                    Paragraph date = new Paragraph("Date: " + workingDate.ToShortDateString() + "\n\n", FontFactory.GetFont(FontFactory.TIMES, 12, iTextSharp.text.Font.BOLD));
                    doc.Add(date);
                    PdfPTable data = new PdfPTable(3);
                    data.HorizontalAlignment = Element.ALIGN_LEFT;
                    data.HeaderRows = 1;
                    data.WidthPercentage = 100;
                    float[] widths = new float[] { 20f, 20f, 50f };
                    data.SetWidths(widths);
                    addTableHeaderRows(data);

                    List<LessonPlan> lessons = controller.getLessonPlansForDate(workingDate);

                    if (lessons.Count != 0)
                    {
                        for (int j = 0; j < lessons.Count; j++)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(lessons.ElementAt(j).CalendarItem.StartDate.ToShortTimeString() + " - " + lessons.ElementAt(j).CalendarItem.EndDate.ToShortTimeString(),
                                    fontSetup));
                            data.AddCell(cell);
                            cell.Phrase = new Phrase(lessons.ElementAt(j).Subject.Name, fontSetup);
                            data.AddCell(cell);
                            cell.Phrase = new Phrase(lessons.ElementAt(j).Notes, fontSetup);
                            data.AddCell(cell);
                        }
                    }
                    else
                    {
                        PdfPCell cell = new PdfPCell(new Phrase("No Data for Selected Date Range.", fontSetup));
                        cell.Colspan = 3;
                        data.AddCell(cell);
                    }
                    doc.Add(data);
                }
                doc.Close();
                wr.Close();
            }
            addPageNumbers();
        }




        /*
         * Generate report by week.
         */
        private void generateByWeek()
        {
            using (var destinationFileStream = new FileStream(reportFilePath, FileMode.Create))
            {
                Document doc = new Document(iTextSharp.text.PageSize.LETTER.Rotate(), 20, 20, 70, 50);
                PdfWriter wr = PdfWriter.GetInstance(doc, destinationFileStream);
                doc.Open();
                wr.PageEvent = eventHandler;
                addReportDetailsData(doc);
               
                List<DateTime> dates = getDates();
                List<List<LessonPlan>> realData = new List<List<LessonPlan>>();

                for (int cycleDates = 0; cycleDates < dates.Count; cycleDates++)
                {
                    realData.Add(controller.getLessonPlansForDate(dates.ElementAt(cycleDates)));
                }


                //get largest array size
                int largestDataArray = 0;
                for (int cycleDataLists = 0; cycleDataLists < realData.Count; cycleDataLists++)
                {
                    if (realData.ElementAt(cycleDataLists).Count > largestDataArray) largestDataArray = realData.ElementAt(cycleDataLists).Count;
                }

                //Add content loop.
                for (int weeks = 0; weeks < dates.Count/7; weeks++)
                {
                    if (weeks != 0) doc.NewPage();

                    DateTime firstDayOfWeek = dates[(weeks * 7)];
                    DateTime lastDayOfWeek = firstDayOfWeek.AddDays(6);
                    Paragraph date = new Paragraph("Week:" + firstDayOfWeek.ToShortDateString() + " - " + 
                                    lastDayOfWeek.ToShortDateString() + "\n\n", FontFactory.GetFont(FontFactory.TIMES, 12, iTextSharp.text.Font.BOLD));
                    doc.Add(date);
                    PdfPTable data = new PdfPTable(7);
                    data.HorizontalAlignment = Element.ALIGN_LEFT;
                    data.HeaderRows = 2;
                    data.WidthPercentage = 100;
                    addTableHeaderRows(data);

                    //setup additional fonts.
                    iTextSharp.text.Font smallfontSetup = FontFactory.GetFont(FontFactory.TIMES, 10, iTextSharp.text.Font.NORMAL);
                    iTextSharp.text.Font boldfontSetup = FontFactory.GetFont(FontFactory.TIMES, 12, iTextSharp.text.Font.BOLD);

                    //Add additional heading row for dates of the week.
                    for (int dateHeadings = 0; dateHeadings < 7; dateHeadings++)
                    {
                        int index = (weeks * 7) + dateHeadings;
                        PdfPCell cell = new PdfPCell(new Phrase(dates.ElementAt(index).ToShortDateString(), boldfontSetup));
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        data.AddCell(cell);
                    }

                    //Add data loop.
                    for (int listLen = 0; listLen < largestDataArray; listLen++)
                    {
                        for (int days = 0; days < 7; days++)
                        {
                            int dateIndex = (weeks * 7) + days;
                            if (listLen < realData.ElementAt(dateIndex).Count)
                            {
                                String cellString = realData.ElementAt(dateIndex).ElementAt(listLen).CalendarItem.StartDate.ToShortTimeString();
                                cellString += " - " + realData.ElementAt(dateIndex).ElementAt(listLen).CalendarItem.EndDate.ToShortTimeString();
                                cellString += "\n" + realData.ElementAt(dateIndex).ElementAt(listLen).Subject.Name;
                                cellString += "\n\n" + realData.ElementAt(dateIndex).ElementAt(listLen).Notes;
                                PdfPCell cell = new PdfPCell(new Phrase(cellString, smallfontSetup));
                                data.AddCell(cell);
                            }
                            else
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(" ", smallfontSetup));
                                data.AddCell(cell);
                            }
                        }
                    }
                    doc.Add(data);
                }
                doc.Close();
                wr.Close();
            }
            addPageNumbers();
        }



        /*
         * Generate report by month.
         */
        private void generateByMonth()
        {
            using (var destinationFileStream = new FileStream(reportFilePath, FileMode.Create))
            {
                Document doc = new Document(iTextSharp.text.PageSize.LETTER.Rotate(), 20, 20, 70, 50);
                PdfWriter wr = PdfWriter.GetInstance(doc, destinationFileStream);
                doc.Open();
                wr.PageEvent = eventHandler;
                addReportDetailsData(doc);

                /*
                 * Remove this line after DB integration
                 */
                //TestData dataHelper = new TestData(6, "Lesson");

                List<DateTime> firstDayOfMonths = getFirstDaysOfMonths();
                for (int cycleMonths = 0; cycleMonths < firstDayOfMonths.Count; cycleMonths++)
                {
                    if (cycleMonths != 0) doc.NewPage();

                    Paragraph date = new Paragraph("Month: " + firstDayOfMonths.ElementAt(cycleMonths).ToString("MMMM") + " " +
                        firstDayOfMonths.ElementAt(cycleMonths).Year.ToString() + "\n\n",
                        FontFactory.GetFont(FontFactory.TIMES, 12, iTextSharp.text.Font.BOLD));
                    doc.Add(date);

                    PdfPTable data = new PdfPTable(7);
                    data.HorizontalAlignment = Element.ALIGN_LEFT;
                    data.HeaderRows = 1;
                    data.WidthPercentage = 100;
                    addTableHeaderRows(data);

                    for (int cycleDays = 0; cycleDays < DateTime.DaysInMonth(firstDayOfMonths.ElementAt(cycleMonths).Year, firstDayOfMonths.ElementAt(cycleMonths).Month); cycleDays++)
                    {
                        DateTime cellDate = new DateTime(firstDayOfMonths.ElementAt(cycleMonths).Year, firstDayOfMonths.ElementAt(cycleMonths).Month, cycleDays+1, 0, 0, 0);
                        String cellString = cellDate.ToShortDateString() + "\n";
                        
                        //Check for first week not start on Monday and add blank cells
                        if (cycleDays == 0)
                        {
                            if(cellDate.DayOfWeek.ToString() != "Monday")
                            {
                                int numBlankDays = getFirstWeekBlankCells(cellDate);
                                for (int i=0; i<numBlankDays; i++)
                                {
                                    data.AddCell(" ");
                                }
                            }
                        }

                        List<LessonPlan> realData = controller.getLessonPlansForDate(cellDate);  
                      
                        if (realData != null)
                        {
                            for (int cycleData = 0; cycleData < realData.Count; cycleData++)
                            {
                                cellString += realData.ElementAt(cycleData).CalendarItem.StartDate.ToShortTimeString();
                                cellString += " : " + realData.ElementAt(cycleData).Subject.Name;
                                if (cycleData != realData.Count - 1) cellString += "\n";
                            }
                        }
                        
                        iTextSharp.text.Font smallfontSetup = FontFactory.GetFont(FontFactory.TIMES, 10, iTextSharp.text.Font.NORMAL);
                        PdfPCell cell = new PdfPCell(new Phrase(cellString, smallfontSetup));
                        data.AddCell(cell);

                        //Check for last day on on Sunday and add blank cells.
                        if (cycleDays == DateTime.DaysInMonth(firstDayOfMonths.ElementAt(cycleMonths).Year, firstDayOfMonths.ElementAt(cycleMonths).Month)-1)
                        {
                            if (cellDate.DayOfWeek.ToString() != "Sunday")
                            {
                                int numBlankDays = getLastWeekBlankCells(cellDate);
                                for (int i = 0; i < numBlankDays; i++)
                                {
                                    data.AddCell(" ");
                                }
                            }
                        }
                    }
                    doc.Add(data);
                }
                doc.Close();
                wr.Close();
            }
            addPageNumbers();
        }


        private int getFirstWeekBlankCells(DateTime date)
        {
            if (date.DayOfWeek.ToString() == "Tuesday") return 1;
            if (date.DayOfWeek.ToString() == "Wednesday") return 2;
            if (date.DayOfWeek.ToString() == "Thursday") return 3;
            if (date.DayOfWeek.ToString() == "Friday") return 4;
            if (date.DayOfWeek.ToString() == "Saturday") return 5;
            if (date.DayOfWeek.ToString() == "Sunday") return 6;
            return 0;
        }


        private int getLastWeekBlankCells (DateTime date)
        {
            if (date.DayOfWeek.ToString() == "Monday") return 6;
            if (date.DayOfWeek.ToString() == "Tuesday") return 5;
            if (date.DayOfWeek.ToString() == "Wednesday") return 4;
            if (date.DayOfWeek.ToString() == "Thursday") return 3;
            if (date.DayOfWeek.ToString() == "Friday") return 2;
            if (date.DayOfWeek.ToString() == "Saturday") return 1;
            return 0;
        }


        private List<DateTime> getDates ()
        {
            DateTime currentDay = startDate;
            List<DateTime> dates = new List<DateTime>();
            dates.Add(currentDay);
            while (currentDay != endDate)
            {
                currentDay = currentDay.AddDays(1);
                dates.Add(currentDay);

            }
            return dates;
        }


        private List<DateTime> getFirstDaysOfMonths ()
        {
            DateTime currentDate = startDate;
            List<DateTime> firstDayOfMonths = new List<DateTime>();
            firstDayOfMonths.Add(startDate);

            if (currentDate.Year == endDate.Year)
            {
                while (currentDate.Month != endDate.Month)
                {
                    currentDate = currentDate.AddMonths(1);
                    firstDayOfMonths.Add(currentDate);
                }
            }

            else
            {
                while (currentDate.Year != endDate.Year)
                {
                    currentDate = currentDate.AddMonths(1);
                    firstDayOfMonths.Add(currentDate);
                }

                while (currentDate.Month != endDate.Month)
                {
                    currentDate = currentDate.AddMonths(1);
                    firstDayOfMonths.Add(currentDate);
                }
            }
            return firstDayOfMonths;
        }


    }     
}
