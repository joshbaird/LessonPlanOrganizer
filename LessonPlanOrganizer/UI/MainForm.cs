using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Windows.Forms.Calendar;

namespace LessonPlanOrganizer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            CalendarItem item = new CalendarItem(calendar1, new DateTime(2014,11,6), new TimeSpan(1,0,0,0), "Testing");
            item.ApplyColor(Color.Red);
            CalendarItem item2 = new CalendarItem(calendar1, new DateTime(2014, 11, 10), new TimeSpan(1, 0, 0, 0), "Testing2");
            item2.ApplyColor(Color.Blue);
            calendar1.Items.Add(item);
            calendar1.Items.Add(item2);
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void monthView1_SelectionChanged(object sender, EventArgs e)
        {
            if((this.monthView1.SelectionEnd - this.monthView1.SelectionStart).TotalDays <= this.calendar1.MaximumViewDays)
                this.calendar1.SetViewRange(this.monthView1.SelectionStart, this.monthView1.SelectionEnd);
            else
                this.calendar1.SetViewRange(this.monthView1.SelectionStart, this.monthView1.SelectionStart.AddDays(this.calendar1.MaximumViewDays));
        }
    }
}
