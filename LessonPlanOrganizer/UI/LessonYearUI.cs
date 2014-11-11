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
    public partial class LessonYearUI : Form
    {
        public LessonYearUI(String mode)
        {
            InitializeComponent();

            startTimePicker.ShowUpDown = true;
            startTimePicker.CustomFormat = " hh:mm";
            startTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            endTimePicker.ShowUpDown = true;
            endTimePicker.CustomFormat = " hh:mm";
            endTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
