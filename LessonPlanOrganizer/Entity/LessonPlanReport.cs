using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using iTextSharp.text;
using iTextSharp.text.pdf;

namespace LessonPlanOrganizer
{
    class LessonPlanReport : Report
    {
        String viewType;

        LessonPlanPdfEventHandler eventHandler;
        

        public LessonPlanReport(DateTime startD, DateTime endD, String view)
        {
            startDate = startD;
            endDate = endD;
            reportGenerationDate = System.DateTime.Today;
            reportFilePath = generateReportFilePath();
            viewType = view;
            
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
        override protected void addTableHeaderRows (PdfPTable tbl)
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
        private void generateByDay ()
        {
            using (var destinationFileStream = new FileStream(reportFilePath, FileMode.Create))
            {
                Document doc = new Document(iTextSharp.text.PageSize.LETTER.Rotate(), 20, 20, 70, 50);
                PdfWriter wr = PdfWriter.GetInstance(doc, destinationFileStream);
                doc.Open();

                wr.PageEvent = eventHandler;

                addReportDetailsData(doc);

                
                //Add data
                TestData dataHelper = new TestData(5, "Lesson");
                String[,] realData = dataHelper.getData();

                for (int i = 0; i < realData.Length / 4; i++)
                {
                    if (i != 0) doc.NewPage();
                    
                    Paragraph date = new Paragraph("Date: <add variable> \n\n", FontFactory.GetFont(FontFactory.TIMES, 12, iTextSharp.text.Font.BOLD));
                    doc.Add(date);
                    PdfPTable data = new PdfPTable(3);
                    data.HorizontalAlignment = Element.ALIGN_LEFT;
                    data.HeaderRows = 1;
                    data.WidthPercentage = 100;
                    float[] widths = new float[] { 20f, 20f, 50f };
                    data.SetWidths(widths);
                    addTableHeaderRows(data);

                    PdfPCell cell = new PdfPCell(new Phrase(realData[i, 1], fontSetup));
                    data.AddCell(cell);
                    cell.Phrase = new Phrase(realData[i, 2], fontSetup);
                    data.AddCell(cell);
                    cell.Phrase = new Phrase(realData[i, 3], fontSetup);
                    data.AddCell(cell);

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

                Paragraph date = new Paragraph("Week: <add variable> \n\n", FontFactory.GetFont(FontFactory.TIMES, 12, iTextSharp.text.Font.BOLD));
                doc.Add(date);
                PdfPTable data = new PdfPTable(7);
                data.HorizontalAlignment = Element.ALIGN_LEFT;
                data.HeaderRows = 1;
                data.WidthPercentage = 100; 
                addTableHeaderRows(data);


                //Add data
                TestData dataHelper = new TestData(20, "Lesson");
                String[,] realData = dataHelper.getData();

                //add dates to second row with gray background
                for (int j = 0; j < realData.Length / 4; j++ )
                {
                    PdfPCell cell = new PdfPCell(new Phrase(realData[j, 0], fontSetup));
                    cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    data.AddCell(cell);

                }

                //add data from left to right, top to bottom
                for (int i = 0; i < realData.Length / 4; i++)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(realData[i, 1] + "\n" + realData[i, 2] +
                                 "\n\n" + realData[i, 3], fontSetup));
                    data.AddCell(cell);
                        
                }

                doc.Add(data);
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

        }




    }
}
