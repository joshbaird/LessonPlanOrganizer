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
    public partial class PdfEventHandler : PdfPageEventHelper
    {
        String rptType, sub;

        public PdfEventHandler(String reportType, String subject)
        {
            rptType = reportType;
            sub = subject;
        }


        public override void OnEndPage(PdfWriter writer, Document doc)
        {
            addHeader(writer, doc);            
        }
            
        
        /* Creates and writes the header to each page. 
         * Called on the OnEndPage event
         */
        private void addHeader (PdfWriter writer, Document doc)
        {
            String headerText;
            if (rptType == "Statistics Report") headerText = rptType + " - " + sub;
            else headerText = rptType + " - " + System.DateTime.Today.ToString();

            Paragraph header = new Paragraph(headerText, FontFactory.GetFont(FontFactory.TIMES, 25, iTextSharp.text.Font.BOLD));

            //Setup header so it is centered at the top of the page.
            header.Alignment = Element.ALIGN_CENTER;
            PdfPTable footerTbl = new PdfPTable(1);
            Rectangle page = doc.PageSize;
            footerTbl.TotalWidth = page.Width - doc.LeftMargin - doc.RightMargin;
            footerTbl.HorizontalAlignment = Element.ALIGN_CENTER;
            PdfPCell cell = new PdfPCell(header);
            cell.Border = 0;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            footerTbl.AddCell(cell);
            int topY = Convert.ToInt32(doc.GetTop(-60));

            //write the header to the page.
            footerTbl.WriteSelectedRows(0, -1, 10, topY, writer.DirectContent);
        }

        
    }
}
