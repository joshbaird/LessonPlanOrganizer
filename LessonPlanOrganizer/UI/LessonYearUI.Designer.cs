﻿namespace LessonPlanOrganizer
{
    partial class LessonYearUI
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
            this.ImportOldYear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.endTimePicker = new System.Windows.Forms.DateTimePicker();
            this.subjectList = new BrightIdeasSoftware.FastObjectListView();
            this.olvSubjects = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.lessonsList = new System.Windows.Forms.ListView();
            this.holidayList = new System.Windows.Forms.ListView();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.startTimePicker = new System.Windows.Forms.DateTimePicker();
            this.saveButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.subjectList)).BeginInit();
            this.SuspendLayout();
            // 
            // ImportOldYear
            // 
            this.ImportOldYear.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImportOldYear.Location = new System.Drawing.Point(12, 12);
            this.ImportOldYear.Name = "ImportOldYear";
            this.ImportOldYear.Size = new System.Drawing.Size(223, 36);
            this.ImportOldYear.TabIndex = 0;
            this.ImportOldYear.Text = "Import Old Year";
            this.ImportOldYear.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Start Date:";
            // 
            // startDatePicker
            // 
            this.startDatePicker.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startDatePicker.Location = new System.Drawing.Point(139, 74);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(354, 35);
            this.startDatePicker.TabIndex = 3;
            this.startDatePicker.Value = new System.DateTime(2014, 11, 9, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 28);
            this.label2.TabIndex = 5;
            this.label2.Text = "End Date:";
            // 
            // endDatePicker
            // 
            this.endDatePicker.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endDatePicker.Location = new System.Drawing.Point(139, 117);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.Size = new System.Drawing.Size(354, 35);
            this.endDatePicker.TabIndex = 6;
            this.endDatePicker.Value = new System.DateTime(2014, 11, 9, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(539, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 28);
            this.label3.TabIndex = 7;
            this.label3.Text = "Start Time:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(539, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 28);
            this.label4.TabIndex = 8;
            this.label4.Text = "End Time:";
            // 
            // endTimePicker
            // 
            this.endTimePicker.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endTimePicker.Location = new System.Drawing.Point(666, 122);
            this.endTimePicker.Name = "endTimePicker";
            this.endTimePicker.Size = new System.Drawing.Size(361, 35);
            this.endTimePicker.TabIndex = 10;
            this.endTimePicker.TabStop = false;
            this.endTimePicker.Value = new System.DateTime(2014, 11, 9, 22, 22, 0, 0);
            // 
            // subjectList
            // 
            this.subjectList.AllColumns.Add(this.olvSubjects);
            this.subjectList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.subjectList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvSubjects});
            this.subjectList.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjectList.FullRowSelect = true;
            this.subjectList.GridLines = true;
            this.subjectList.Location = new System.Drawing.Point(18, 187);
            this.subjectList.Margin = new System.Windows.Forms.Padding(4);
            this.subjectList.MaximumSize = new System.Drawing.Size(291, 405);
            this.subjectList.MultiSelect = false;
            this.subjectList.Name = "subjectList";
            this.subjectList.ShowGroups = false;
            this.subjectList.Size = new System.Drawing.Size(291, 377);
            this.subjectList.TabIndex = 12;
            this.subjectList.UseCompatibleStateImageBehavior = false;
            this.subjectList.View = System.Windows.Forms.View.Details;
            this.subjectList.VirtualMode = true;
            // 
            // olvSubjects
            // 
            this.olvSubjects.FillsFreeSpace = true;
            this.olvSubjects.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvSubjects.Text = "Subjects";
            this.olvSubjects.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lessonsList
            // 
            this.lessonsList.Location = new System.Drawing.Point(317, 187);
            this.lessonsList.Name = "lessonsList";
            this.lessonsList.Size = new System.Drawing.Size(486, 377);
            this.lessonsList.TabIndex = 13;
            this.lessonsList.UseCompatibleStateImageBehavior = false;
            // 
            // holidayList
            // 
            this.holidayList.Location = new System.Drawing.Point(809, 187);
            this.holidayList.Name = "holidayList";
            this.holidayList.Size = new System.Drawing.Size(261, 377);
            this.holidayList.TabIndex = 14;
            this.holidayList.UseCompatibleStateImageBehavior = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Subject";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(317, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "Generic Lessons";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(809, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 17);
            this.label7.TabIndex = 17;
            this.label7.Text = "Holidays";
            // 
            // startTimePicker
            // 
            this.startTimePicker.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startTimePicker.Location = new System.Drawing.Point(666, 75);
            this.startTimePicker.Name = "startTimePicker";
            this.startTimePicker.Size = new System.Drawing.Size(361, 35);
            this.startTimePicker.TabIndex = 18;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(877, 570);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(91, 32);
            this.saveButton.TabIndex = 19;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(974, 570);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(96, 32);
            this.closeButton.TabIndex = 20;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // LessonYearUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 605);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.startTimePicker);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.holidayList);
            this.Controls.Add(this.lessonsList);
            this.Controls.Add(this.subjectList);
            this.Controls.Add(this.endTimePicker);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.endDatePicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.startDatePicker);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ImportOldYear);
            this.Name = "LessonYearUI";
            this.Text = "LessonYearUI";
            ((System.ComponentModel.ISupportInitialize)(this.subjectList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ImportOldYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker endDatePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker endTimePicker;
        private BrightIdeasSoftware.FastObjectListView subjectList;
        private BrightIdeasSoftware.OLVColumn olvSubjects;
        private System.Windows.Forms.ListView lessonsList;
        private System.Windows.Forms.ListView holidayList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker startTimePicker;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button closeButton;
    }
}