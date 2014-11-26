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
    class SubjectStatsReport : Report
    {
        String subject;
        int requiredTime, grandTotal;
        SubStatsPdfEventHandler eventHandler;
        

        public SubjectStatsReport(DateTime startD, DateTime endD,
                                    String sub, int reqTime)
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

                //Add data
                TestData dataHelper = new TestData(50, "Stats");
                String[,] realData = dataHelper.getData();

                for (int i = 0; i < realData.Length / 3; i++)
                {
                    
                    PdfPCell cell = new PdfPCell(new Phrase(realData[i, 0], fontSetup));
                    data.AddCell(cell);
                    cell.Phrase = new Phrase(realData[i, 1], fontSetup);
                    data.AddCell(cell);
                    cell.Phrase = new Phrase(realData[i, 2], fontSetup);
                    data.AddCell(cell);
                    grandTotal = grandTotal + Convert.ToInt16(realData[i, 2]);
                    cell.Phrase = new Phrase(Convert.ToString(grandTotal), fontSetup);
                    data.AddCell(cell);
                }


                addSeparatorRows(data);
                addCalculationRows(data, Convert.ToInt16(grandTotal), requiredTime);

                doc.Add(data);

                doc.Close();
                wr.Close();

            }

            addPageNumbers();
        }



        /***************************
         * Private Methods
         ***************************/


        /// <summary>
        /// Generate the report's file path. Uses the current 
        /// user's Temp directory.
        /// </summary>
        /// <returns></returns>
        override protected String generateReportFilePath()
        {
            String filePath = Path.GetTempPath() + "\\Subject Statistics Report -" +
                                System.DateTime.Today.Year + System.DateTime.Today.Month +
                                System.DateTime.Today.Day + System.DateTime.Now.Hour +
                                System.DateTime.Now.Minute + System.DateTime.Now.Second + ".pdf";
            return filePath;
        }

        /// <summary>
        /// Add the report details block on the top of the first 
        /// page.
        /// </summary>
        /// <param name="d"></param>
        override protected void addReportDetailsData(Document d)
        {
            Paragraph dataSet = new Paragraph("Report Generation Date: " + reportGenerationDate.ToShortDateString() + "\n" +
                                                "Subject: " + subject + "\n" +
                                                "Date Range: " + startDate.ToShortDateString() + " - " + endDate.ToShortDateString() + "\n" +
                                                "Required Time (in minutes): " + requiredTime.ToString() + "\n \n",
                                                FontFactory.GetFont(FontFactory.TIMES, 12, iTextSharp.text.Font.NORMAL));
            d.Add(dataSet);
        }

        /// <summary>
        /// Add the header table rows to the report table.
        /// This is only called on the first page, the automated repeat row 
        /// function takes care of all following pages.
        /// </summary>
        /// <param name="tbl"></param>
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


        /// <summary>
        /// Add the separator rows after all data has been added
        /// to the table. 
        /// </summary>
        /// <param name="tbl"></param>
        private void addSeparatorRows(PdfPTable tbl)
        {

            PdfPCell cell = new PdfPCell(new Phrase(" ", fontSetup));
            cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
            tbl.AddCell(cell);
            tbl.AddCell(cell);
            tbl.AddCell(cell);
            tbl.AddCell(cell);

        }

        /// <summary>
        /// Add the grand total, required time, and difference rows 
        /// to the table. 
        /// </summary>
        /// <param name="tbl"></param>
        /// <param name="total"></param>
        /// <param name="reqTime"></param>
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
