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
    public partial class SubStatsReportInputForm : Form
    {
        public SubStatsReportInputForm()
        {
            InitializeComponent();

            this.subjectInputDropDown.DisplayMember = "Name";
            this.subjectInputDropDown.Items.AddRange(LessonPlanYearControl.Instance.getSubjects().ToArray());
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (validateInputs() == true)
            {
                ReportControl rptControl = new ReportControl(startDateTimePicker.Value, endDateTimePicker.Value,
                                                                subjectInputDropDown.SelectedItem.ToString(), " ",
                                                                "Subject Statistics", Convert.ToInt16(requiredTimeInputTextBox.Text));

                this.Visible = false;
                rptControl.generateReport();
                rptControl.viewReport();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private Boolean validateInputs()
        {

            if (subjectInputDropDown.SelectedItem == null)
            {
                MessageBox.Show("Please select a subject!", "Input Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;
            }

            if (requiredTimeInputTextBox.Text == "")
            {
                MessageBox.Show("Please enter a value for required time!", "Input Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;
            }

            int i;
            if (!int.TryParse(requiredTimeInputTextBox.Text, out i))
            {
                MessageBox.Show("Required time must be a number! Please enter a number for required time.", 
                        "Input Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;
            }

            if (endDateTimePicker.Value.Date < startDateTimePicker.Value.Date)
            {
                MessageBox.Show("End date falls before the start date. Please change the end date so it falls on or after the start date.",
                        "Input Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        
    }
}
