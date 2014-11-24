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
    public partial class LessonPlanReportInputForm : Form
    {
        public LessonPlanReportInputForm()
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (validateInputs() == true)
            {
                validateInputs();
                ReportControl rptControl = new ReportControl(startDateTimePicker.Value, endDateTimePicker.Value,
                                                                " ", viewByInputDropDown.SelectedItem.ToString(),
                                                                "Lesson Plan", 0);

                this.Visible = false;
                rptControl.generateReport();
                rptControl.viewReport();
            }

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        private Boolean validateInputs ()
        {
            if (viewByInputDropDown.SelectedItem == null)
            {
                MessageBox.Show("Please enter a View Type!", "Input Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;
            }

            if (endDateTimePicker.Value.Date < startDateTimePicker.Value.Date)
            {
                MessageBox.Show("End date falls before the start date. Please change the end date so it falls on or after the start date.",
                        "Input Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;
            }

            if (viewByInputDropDown.SelectedItem.ToString() == "By Week")
            {
                if (startDateTimePicker.Value.DayOfWeek.ToString() != "Monday")
                {
                    MessageBox.Show("Start date must be a Monday when viewing by week. Please select a start date that falls on a Monday.",
                        "Input Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return false;
                }

                if (endDateTimePicker.Value.DayOfWeek.ToString() != "Sunday")
                {
                    MessageBox.Show("End date must be a Sunday when viewing by week. Please select an end date that falls on a Sunday.",
                        "Input Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return false;
                }
            }

            if (viewByInputDropDown.SelectedItem.ToString() == "By Month")
            {
                if (startDateTimePicker.Value.Day != 1)
                {
                    MessageBox.Show("Start date must be the first of a month when viewing by month. Please select the first day of a month for the start date.",
                    "Input Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return false;
                }

                if (endDateTimePicker.Value.Day != DateTime.DaysInMonth(endDateTimePicker.Value.Year, endDateTimePicker.Value.Month))
                {
                    MessageBox.Show("End date must be the last day of a month when viewing by month. Please select the last day of a month for the end date.",
                    "Input Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

    }
}
