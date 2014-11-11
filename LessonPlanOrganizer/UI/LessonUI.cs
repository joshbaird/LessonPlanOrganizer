using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LessonPlanOrganizer
{
    public partial class LessonUI : Form
    {
        public LessonUI(String mode)
        {
            InitializeComponent();

            timeSelection.ShowUpDown = true;
            timeSelection.CustomFormat = " hh:mm";
            timeSelection.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
