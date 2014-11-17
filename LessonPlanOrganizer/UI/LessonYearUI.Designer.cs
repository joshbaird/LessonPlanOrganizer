namespace LessonPlanOrganizer
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
            this.holidayList = new System.Windows.Forms.ListView();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.subjectsView1 = new LessonPlanOrganizer.subjectsView();
            this.lessonsView1 = new LessonPlanOrganizer.lessonsView();
            this.numEndMin = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numEndHour = new System.Windows.Forms.NumericUpDown();
            this.numStartMin = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.numStartHour = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numEndMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEndHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStartMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStartHour)).BeginInit();
            this.SuspendLayout();
            // 
            // ImportOldYear
            // 
            this.ImportOldYear.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImportOldYear.Location = new System.Drawing.Point(9, 10);
            this.ImportOldYear.Margin = new System.Windows.Forms.Padding(2);
            this.ImportOldYear.Name = "ImportOldYear";
            this.ImportOldYear.Size = new System.Drawing.Size(167, 29);
            this.ImportOldYear.TabIndex = 0;
            this.ImportOldYear.Text = "Import Old Year";
            this.ImportOldYear.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Start Date:";
            // 
            // startDatePicker
            // 
            this.startDatePicker.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startDatePicker.Location = new System.Drawing.Point(104, 60);
            this.startDatePicker.Margin = new System.Windows.Forms.Padding(2);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(266, 30);
            this.startDatePicker.TabIndex = 3;
            this.startDatePicker.Value = new System.DateTime(2014, 11, 9, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 95);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "End Date:";
            // 
            // endDatePicker
            // 
            this.endDatePicker.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endDatePicker.Location = new System.Drawing.Point(104, 95);
            this.endDatePicker.Margin = new System.Windows.Forms.Padding(2);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.Size = new System.Drawing.Size(266, 30);
            this.endDatePicker.TabIndex = 6;
            this.endDatePicker.Value = new System.DateTime(2014, 11, 9, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(404, 57);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Start Time:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(404, 95);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "End Time:";
            // 
            // holidayList
            // 
            this.holidayList.Location = new System.Drawing.Point(607, 152);
            this.holidayList.Margin = new System.Windows.Forms.Padding(2);
            this.holidayList.Name = "holidayList";
            this.holidayList.Size = new System.Drawing.Size(197, 307);
            this.holidayList.TabIndex = 14;
            this.holidayList.UseCompatibleStateImageBehavior = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 133);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Subject";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(191, 133);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Generic Lessons";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(607, 133);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Holidays";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(658, 463);
            this.saveButton.Margin = new System.Windows.Forms.Padding(2);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(68, 26);
            this.saveButton.TabIndex = 19;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(730, 463);
            this.closeButton.Margin = new System.Windows.Forms.Padding(2);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(72, 26);
            this.closeButton.TabIndex = 20;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // subjectsView1
            // 
            this.subjectsView1.Location = new System.Drawing.Point(17, 152);
            this.subjectsView1.Name = "subjectsView1";
            this.subjectsView1.Size = new System.Drawing.Size(171, 307);
            this.subjectsView1.TabIndex = 21;
            // 
            // lessonsView1
            // 
            this.lessonsView1.Location = new System.Drawing.Point(194, 152);
            this.lessonsView1.Name = "lessonsView1";
            this.lessonsView1.Size = new System.Drawing.Size(408, 307);
            this.lessonsView1.TabIndex = 22;
            // 
            // numEndMin
            // 
            this.numEndMin.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numEndMin.Location = new System.Drawing.Point(583, 91);
            this.numEndMin.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numEndMin.Name = "numEndMin";
            this.numEndMin.Size = new System.Drawing.Size(50, 30);
            this.numEndMin.TabIndex = 28;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(563, 94);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 23);
            this.label8.TabIndex = 27;
            this.label8.Text = ":";
            // 
            // numEndHour
            // 
            this.numEndHour.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numEndHour.Location = new System.Drawing.Point(508, 90);
            this.numEndHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.numEndHour.Name = "numEndHour";
            this.numEndHour.Size = new System.Drawing.Size(50, 30);
            this.numEndHour.TabIndex = 26;
            this.numEndHour.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numStartMin
            // 
            this.numStartMin.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numStartMin.Location = new System.Drawing.Point(583, 55);
            this.numStartMin.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numStartMin.Name = "numStartMin";
            this.numStartMin.Size = new System.Drawing.Size(50, 30);
            this.numStartMin.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(563, 58);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 23);
            this.label9.TabIndex = 24;
            this.label9.Text = ":";
            // 
            // numStartHour
            // 
            this.numStartHour.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numStartHour.Location = new System.Drawing.Point(508, 54);
            this.numStartHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.numStartHour.Name = "numStartHour";
            this.numStartHour.Size = new System.Drawing.Size(50, 30);
            this.numStartHour.TabIndex = 23;
            this.numStartHour.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // LessonYearUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 492);
            this.Controls.Add(this.numEndMin);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.numEndHour);
            this.Controls.Add(this.numStartMin);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.numStartHour);
            this.Controls.Add(this.lessonsView1);
            this.Controls.Add(this.subjectsView1);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.holidayList);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.endDatePicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.startDatePicker);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ImportOldYear);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "LessonYearUI";
            this.Text = "LessonYearUI";
            ((System.ComponentModel.ISupportInitialize)(this.numEndMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEndHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStartMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStartHour)).EndInit();
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
        private System.Windows.Forms.ListView holidayList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button closeButton;
        private subjectsView subjectsView1;
        private lessonsView lessonsView1;
        private System.Windows.Forms.NumericUpDown numEndMin;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numEndHour;
        private System.Windows.Forms.NumericUpDown numStartMin;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numStartHour;
    }
}