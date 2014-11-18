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
    public partial class SubjectUI : Form
    {
        public SubjectUI(Subject subject)
        {
            InitializeComponent();
            _subject = (Subject)subject;
            this.colorDialog1.Color = _subject.Color;
            this.textBoxTitle.Text = _subject.Name;
            this.textBoxNotes.Text = String.IsNullOrEmpty(_subject.Notes) ? "subject notes..." : _subject.Notes;
            this.button1.ForeColor = colorDialog1.Color;
            this.button1.BackColor = colorDialog1.Color;
        }

        private Subject _subject;

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.button1.ForeColor = colorDialog1.Color;
                this.button1.BackColor = colorDialog1.Color;
            } 
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            // TODO validate the date before save.
            _subject.Color = colorDialog1.Color;
            _subject.Name = textBoxTitle.Text;
            _subject.Notes = textBoxNotes.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
