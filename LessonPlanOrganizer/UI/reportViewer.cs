using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LessonPlanOrganizer
{
    public partial class reportViewer : Form
    {
        public reportViewer(String filePath)
        {
            InitializeComponent();
            AxAcroPDFLib.AxAcroPDF AcroViewer = new AxAcroPDFLib.AxAcroPDF();
            ((System.ComponentModel.ISupportInitialize)(AcroViewer)).BeginInit();
            AcroViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            AcroViewer.Location = new System.Drawing.Point(0, 0);
            AcroViewer.Name = "AcroViewer";
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(reportViewer));
            AcroViewer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("AcroViewer.OcxState")));
            AcroViewer.Size = new System.Drawing.Size(615, 407);
            AcroViewer.TabIndex = 0;
            AcroViewer.CreateControl();
            Controls.Add(AcroViewer);
            ((System.ComponentModel.ISupportInitialize)(AcroViewer)).EndInit();
            AcroViewer.src = filePath;
        }

        
    }
}
