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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();        }

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
