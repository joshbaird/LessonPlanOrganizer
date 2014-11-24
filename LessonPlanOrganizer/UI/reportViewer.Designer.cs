namespace LessonPlanOrganizer
{
    partial class reportViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(reportViewer));
            this.AcroViewer = new AxAcroPDFLib.AxAcroPDF();
            ((System.ComponentModel.ISupportInitialize)(this.AcroViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // AcroViewer
            // 
            this.AcroViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AcroViewer.Enabled = true;
            this.AcroViewer.Location = new System.Drawing.Point(0, 0);
            this.AcroViewer.Name = "AcroViewer";
            this.AcroViewer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("AcroViewer.OcxState")));
            this.AcroViewer.Size = new System.Drawing.Size(615, 407);
            this.AcroViewer.TabIndex = 0;
            // 
            // reportViewer
            // 
            this.ClientSize = new System.Drawing.Size(611, 406);
            this.Controls.Add(this.AcroViewer);
            this.Name = "reportViewer";
            ((System.ComponentModel.ISupportInitialize)(this.AcroViewer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxAcroPDFLib.AxAcroPDF AcroViewer;
    }
}