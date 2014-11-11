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

        private void InitObjectListView()
        {
            this.subjectList.OwnerDraw = true;

            this.olvSubjects.AspectGetter = rowObject =>
            {
                return ((Subject)rowObject).Name;
            };
            this.subjectList.FormatRow += (o, e) =>
            {
                e.Item.BackColor = ((Subject)e.Model).Color;
                e.Item.ForeColor = Color.White;
            };

            //this.fastObjectListView1.AddObjects(lessonPlanControl.getSubjects());
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
