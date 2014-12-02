namespace LessonPlanOrganizer
{
    partial class MainForm
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
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange1 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange2 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange3 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange4 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange5 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItemSubject = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItemSubject = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItemSubject = new System.Windows.Forms.ToolStripMenuItem();
            this.lessonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItemLesson = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItemLesson = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItemLesson = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subjectStatisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tlpLessonPlanYear = new System.Windows.Forms.TableLayoutPanel();
            this.tlpLeftPane = new System.Windows.Forms.TableLayoutPanel();
            this.pTop = new System.Windows.Forms.Panel();
            this.monthView = new System.Windows.Forms.Calendar.MonthView();
            this.bToday = new System.Windows.Forms.Button();
            this.subjectsView1 = new LessonPlanOrganizer.subjectsView();
            this.calendar1 = new System.Windows.Forms.Calendar.Calendar();
            this.labelHeaderFill = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tlpLessonPlanYear.SuspendLayout();
            this.tlpLeftPane.SuspendLayout();
            this.pTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.yearToolStripMenuItem,
            this.subjectsToolStripMenuItem,
            this.lessonToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripMenuItem2,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "&Save";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.saveFileStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(149, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.quitToolStripMenuItem.Text = "&Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitFileStripMenuItem_Click);
            // 
            // yearToolStripMenuItem
            // 
            this.yearToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.yearToolStripMenuItem.Name = "yearToolStripMenuItem";
            this.yearToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.yearToolStripMenuItem.Text = "&Year";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newYearMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.editToolStripMenuItem.Text = "&Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editYearStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "&Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteYearStripMenuItem_Click);
            // 
            // subjectsToolStripMenuItem
            // 
            this.subjectsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItemSubject,
            this.editToolStripMenuItemSubject,
            this.deleteToolStripMenuItemSubject});
            this.subjectsToolStripMenuItem.Name = "subjectsToolStripMenuItem";
            this.subjectsToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.subjectsToolStripMenuItem.Text = "&Subjects";
            this.subjectsToolStripMenuItem.Click += new System.EventHandler(this.subjectsToolStripMenuItem_Click);
            // 
            // newToolStripMenuItemSubject
            // 
            this.newToolStripMenuItemSubject.Name = "newToolStripMenuItemSubject";
            this.newToolStripMenuItemSubject.Size = new System.Drawing.Size(107, 22);
            this.newToolStripMenuItemSubject.Text = "&New";
            this.newToolStripMenuItemSubject.Click += new System.EventHandler(this.newSubjectStripMenuItem_Click);
            // 
            // editToolStripMenuItemSubject
            // 
            this.editToolStripMenuItemSubject.Name = "editToolStripMenuItemSubject";
            this.editToolStripMenuItemSubject.Size = new System.Drawing.Size(107, 22);
            this.editToolStripMenuItemSubject.Text = "&Edit";
            this.editToolStripMenuItemSubject.Click += new System.EventHandler(this.editSubjectStripMenuItem_Click);
            // 
            // deleteToolStripMenuItemSubject
            // 
            this.deleteToolStripMenuItemSubject.Name = "deleteToolStripMenuItemSubject";
            this.deleteToolStripMenuItemSubject.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItemSubject.Text = "&Delete";
            this.deleteToolStripMenuItemSubject.Click += new System.EventHandler(this.deleteSubjectStripMenuItem_Click);
            // 
            // lessonToolStripMenuItem
            // 
            this.lessonToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItemLesson,
            this.editToolStripMenuItemLesson,
            this.deleteToolStripMenuItemLesson});
            this.lessonToolStripMenuItem.Name = "lessonToolStripMenuItem";
            this.lessonToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.lessonToolStripMenuItem.Text = "&Lessons";
            this.lessonToolStripMenuItem.Click += new System.EventHandler(this.lessonToolStripMenuItem_Click);
            // 
            // newToolStripMenuItemLesson
            // 
            this.newToolStripMenuItemLesson.Name = "newToolStripMenuItemLesson";
            this.newToolStripMenuItemLesson.Size = new System.Drawing.Size(107, 22);
            this.newToolStripMenuItemLesson.Text = "&New";
            this.newToolStripMenuItemLesson.Click += new System.EventHandler(this.newLessonStripMenuItem_Click);
            // 
            // editToolStripMenuItemLesson
            // 
            this.editToolStripMenuItemLesson.Name = "editToolStripMenuItemLesson";
            this.editToolStripMenuItemLesson.Size = new System.Drawing.Size(107, 22);
            this.editToolStripMenuItemLesson.Text = "&Edit";
            this.editToolStripMenuItemLesson.Click += new System.EventHandler(this.editLessonStripMenuItem_Click);
            // 
            // deleteToolStripMenuItemLesson
            // 
            this.deleteToolStripMenuItemLesson.Name = "deleteToolStripMenuItemLesson";
            this.deleteToolStripMenuItemLesson.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItemLesson.Text = "&Delete";
            this.deleteToolStripMenuItemLesson.Click += new System.EventHandler(this.deleteLessonStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subjectStatisticsToolStripMenuItem,
            this.toolStripMenuItem3});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "&Reports";
            // 
            // subjectStatisticsToolStripMenuItem
            // 
            this.subjectStatisticsToolStripMenuItem.Name = "subjectStatisticsToolStripMenuItem";
            this.subjectStatisticsToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.subjectStatisticsToolStripMenuItem.Text = "&Subject Statistics";
            this.subjectStatisticsToolStripMenuItem.Click += new System.EventHandler(this.subjectStatisticsReportStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(162, 22);
            this.toolStripMenuItem3.Text = "&Lesson Plan";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.lessonPlanReportStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutHelpStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tlpLessonPlanYear, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelHeaderFill, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 538);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tlpLessonPlanYear
            // 
            this.tlpLessonPlanYear.ColumnCount = 2;
            this.tlpLessonPlanYear.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 230F));
            this.tlpLessonPlanYear.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLessonPlanYear.Controls.Add(this.tlpLeftPane, 0, 0);
            this.tlpLessonPlanYear.Controls.Add(this.calendar1, 1, 0);
            this.tlpLessonPlanYear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLessonPlanYear.Location = new System.Drawing.Point(3, 4);
            this.tlpLessonPlanYear.Name = "tlpLessonPlanYear";
            this.tlpLessonPlanYear.RowCount = 1;
            this.tlpLessonPlanYear.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLessonPlanYear.Size = new System.Drawing.Size(778, 531);
            this.tlpLessonPlanYear.TabIndex = 0;
            // 
            // tlpLeftPane
            // 
            this.tlpLeftPane.ColumnCount = 1;
            this.tlpLeftPane.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLeftPane.Controls.Add(this.pTop, 0, 0);
            //this.tlpLeftPane.Controls.Add(this.subjectsView1, 0, 1);
            this.tlpLeftPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLeftPane.Location = new System.Drawing.Point(3, 3);
            this.tlpLeftPane.Name = "tlpLeftPane";
            this.tlpLeftPane.RowCount = 2;
            this.tlpLeftPane.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 190F));
            this.tlpLeftPane.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLeftPane.Size = new System.Drawing.Size(224, 525);
            this.tlpLeftPane.TabIndex = 2;
            // 
            // pTop
            // 
            this.pTop.Controls.Add(this.monthView);
            this.pTop.Controls.Add(this.bToday);
            this.pTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pTop.Location = new System.Drawing.Point(3, 3);
            this.pTop.Name = "pTop";
            this.pTop.Size = new System.Drawing.Size(218, 184);
            this.pTop.TabIndex = 1;
            // 
            // monthView
            // 
            this.monthView.ArrowsColor = System.Drawing.SystemColors.Window;
            this.monthView.ArrowsSelectedColor = System.Drawing.Color.Gold;
            this.monthView.DayBackgroundColor = System.Drawing.Color.Empty;
            this.monthView.DayGrayedText = System.Drawing.SystemColors.GrayText;
            this.monthView.DaySelectedBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.monthView.DaySelectedColor = System.Drawing.SystemColors.WindowText;
            this.monthView.DaySelectedTextColor = System.Drawing.SystemColors.HighlightText;
            this.monthView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monthView.ItemPadding = new System.Windows.Forms.Padding(2);
            this.monthView.Location = new System.Drawing.Point(0, 23);
            this.monthView.MonthTitleColor = System.Drawing.SystemColors.ActiveCaption;
            this.monthView.MonthTitleColorInactive = System.Drawing.SystemColors.InactiveCaption;
            this.monthView.MonthTitleTextColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.monthView.MonthTitleTextColorInactive = System.Drawing.SystemColors.InactiveCaptionText;
            this.monthView.Name = "monthView";
            this.monthView.Size = new System.Drawing.Size(218, 161);
            this.monthView.TabIndex = 0;
            this.monthView.Text = "monthView1";
            this.monthView.TodayBorderColor = System.Drawing.Color.Maroon;
            this.monthView.SelectionChanged += new System.EventHandler(this.monthView_SelectionChanged);
            // 
            // bToday
            // 
            this.bToday.Dock = System.Windows.Forms.DockStyle.Top;
            this.bToday.Location = new System.Drawing.Point(0, 0);
            this.bToday.Name = "bToday";
            this.bToday.Size = new System.Drawing.Size(218, 23);
            this.bToday.TabIndex = 0;
            this.bToday.Text = "Today";
            this.bToday.UseVisualStyleBackColor = true;
            this.bToday.Click += new System.EventHandler(this.bToday_Click);
            // 
            // subjectsView1
            // 
            this.subjectsView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subjectsView1.Location = new System.Drawing.Point(3, 193);
            this.subjectsView1.Name = "subjectsView1";
            this.subjectsView1.Size = new System.Drawing.Size(218, 329);
            this.subjectsView1.TabIndex = 2;
            // 
            // calendar1
            // 
            this.calendar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calendar1.Font = new System.Drawing.Font("Segoe UI", 9F);
            calendarHighlightRange1.DayOfWeek = System.DayOfWeek.Monday;
            calendarHighlightRange1.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange1.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange2.DayOfWeek = System.DayOfWeek.Tuesday;
            calendarHighlightRange2.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange2.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange3.DayOfWeek = System.DayOfWeek.Wednesday;
            calendarHighlightRange3.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange3.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange4.DayOfWeek = System.DayOfWeek.Thursday;
            calendarHighlightRange4.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange4.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange5.DayOfWeek = System.DayOfWeek.Friday;
            calendarHighlightRange5.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange5.StartTime = System.TimeSpan.Parse("08:00:00");
            this.calendar1.HighlightRanges = new System.Windows.Forms.Calendar.CalendarHighlightRange[] {
        calendarHighlightRange1,
        calendarHighlightRange2,
        calendarHighlightRange3,
        calendarHighlightRange4,
        calendarHighlightRange5};
            this.calendar1.Location = new System.Drawing.Point(233, 3);
            this.calendar1.Name = "calendar1";
            this.calendar1.Size = new System.Drawing.Size(542, 525);
            this.calendar1.TabIndex = 3;
            this.calendar1.Text = "calendar1";
            this.calendar1.LoadItems += new System.Windows.Forms.Calendar.Calendar.CalendarLoadEventHandler(this.calendar1_LoadItems);
            this.calendar1.ItemDoubleClick += new System.Windows.Forms.Calendar.Calendar.CalendarItemEventHandler(this.calendar1_ItemDoubleClick);
            // 
            // labelHeaderFill
            // 
            this.labelHeaderFill.AutoSize = true;
            this.labelHeaderFill.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelHeaderFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelHeaderFill.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelHeaderFill.Location = new System.Drawing.Point(3, 0);
            this.labelHeaderFill.Name = "labelHeaderFill";
            this.labelHeaderFill.Size = new System.Drawing.Size(778, 1);
            this.labelHeaderFill.TabIndex = 1;
            this.labelHeaderFill.Text = "-";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Lesson Plan Organizer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tlpLessonPlanYear.ResumeLayout(false);
            this.tlpLeftPane.ResumeLayout(false);
            this.pTop.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subjectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItemSubject;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItemSubject;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItemSubject;
        private System.Windows.Forms.ToolStripMenuItem lessonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItemLesson;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItemLesson;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItemLesson;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subjectStatisticsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tlpLessonPlanYear;
        private System.Windows.Forms.Calendar.MonthView monthView;
        private System.Windows.Forms.TableLayoutPanel tlpLeftPane;
        private System.Windows.Forms.Panel pTop;
        private System.Windows.Forms.Button bToday;
        private System.Windows.Forms.Label labelHeaderFill;
        private System.Windows.Forms.Calendar.Calendar calendar1;
        private subjectsView subjectsView1;



    }
}

