namespace LessonPlanOrganizer
{
    partial class ReportUI
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
            this.label1 = new System.Windows.Forms.Label();
            this.reportTypeLabel = new System.Windows.Forms.Label();
            this.reportTypeComboBox = new System.Windows.Forms.ComboBox();
            this.startDateLabel = new System.Windows.Forms.Label();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endDateLabel = new System.Windows.Forms.Label();
            this.EndDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.subjectLabel = new System.Windows.Forms.Label();
            this.subjectComboBox = new System.Windows.Forms.ComboBox();
            this.requiredTimeLabel = new System.Windows.Forms.Label();
            this.requiredTimeTextBox = new System.Windows.Forms.TextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Your Report Parameters";
            // 
            // reportTypeLabel
            // 
            this.reportTypeLabel.AutoSize = true;
            this.reportTypeLabel.Location = new System.Drawing.Point(16, 50);
            this.reportTypeLabel.Name = "reportTypeLabel";
            this.reportTypeLabel.Size = new System.Drawing.Size(69, 13);
            this.reportTypeLabel.TabIndex = 1;
            this.reportTypeLabel.Text = "Report Type:";
            // 
            // reportTypeComboBox
            // 
            this.reportTypeComboBox.FormattingEnabled = true;
            this.reportTypeComboBox.Items.AddRange(new object[] {
            "Subject Statistics Report",
            "Lesson Plan Report"});
            this.reportTypeComboBox.Location = new System.Drawing.Point(92, 46);
            this.reportTypeComboBox.Name = "reportTypeComboBox";
            this.reportTypeComboBox.Size = new System.Drawing.Size(188, 21);
            this.reportTypeComboBox.TabIndex = 2;
            // 
            // startDateLabel
            // 
            this.startDateLabel.AutoSize = true;
            this.startDateLabel.Location = new System.Drawing.Point(16, 82);
            this.startDateLabel.Name = "startDateLabel";
            this.startDateLabel.Size = new System.Drawing.Size(58, 13);
            this.startDateLabel.TabIndex = 3;
            this.startDateLabel.Text = "Start Date:";
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Location = new System.Drawing.Point(80, 78);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.startDateTimePicker.TabIndex = 4;
            // 
            // endDateLabel
            // 
            this.endDateLabel.AutoSize = true;
            this.endDateLabel.Location = new System.Drawing.Point(16, 111);
            this.endDateLabel.Name = "endDateLabel";
            this.endDateLabel.Size = new System.Drawing.Size(55, 13);
            this.endDateLabel.TabIndex = 5;
            this.endDateLabel.Text = "End Date:";
            // 
            // EndDateTimePicker
            // 
            this.EndDateTimePicker.Location = new System.Drawing.Point(80, 107);
            this.EndDateTimePicker.Name = "EndDateTimePicker";
            this.EndDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.EndDateTimePicker.TabIndex = 6;
            // 
            // subjectLabel
            // 
            this.subjectLabel.AutoSize = true;
            this.subjectLabel.Location = new System.Drawing.Point(19, 141);
            this.subjectLabel.Name = "subjectLabel";
            this.subjectLabel.Size = new System.Drawing.Size(46, 13);
            this.subjectLabel.TabIndex = 7;
            this.subjectLabel.Text = "Subject:";
            // 
            // subjectComboBox
            // 
            this.subjectComboBox.FormattingEnabled = true;
            this.subjectComboBox.Items.AddRange(new object[] {
            "English",
            "Math",
            "Science"});
            this.subjectComboBox.Location = new System.Drawing.Point(80, 137);
            this.subjectComboBox.Name = "subjectComboBox";
            this.subjectComboBox.Size = new System.Drawing.Size(200, 21);
            this.subjectComboBox.TabIndex = 8;
            // 
            // requiredTimeLabel
            // 
            this.requiredTimeLabel.AutoSize = true;
            this.requiredTimeLabel.Location = new System.Drawing.Point(19, 175);
            this.requiredTimeLabel.Name = "requiredTimeLabel";
            this.requiredTimeLabel.Size = new System.Drawing.Size(135, 13);
            this.requiredTimeLabel.TabIndex = 9;
            this.requiredTimeLabel.Text = "Required Time (in minutes):";
            // 
            // requiredTimeTextBox
            // 
            this.requiredTimeTextBox.Location = new System.Drawing.Point(159, 172);
            this.requiredTimeTextBox.Name = "requiredTimeTextBox";
            this.requiredTimeTextBox.Size = new System.Drawing.Size(100, 20);
            this.requiredTimeTextBox.TabIndex = 10;
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(120, 211);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 23);
            this.submitButton.TabIndex = 11;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(205, 211);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 12;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // ReportUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 246);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.requiredTimeTextBox);
            this.Controls.Add(this.requiredTimeLabel);
            this.Controls.Add(this.subjectComboBox);
            this.Controls.Add(this.subjectLabel);
            this.Controls.Add(this.EndDateTimePicker);
            this.Controls.Add(this.endDateLabel);
            this.Controls.Add(this.startDateTimePicker);
            this.Controls.Add(this.startDateLabel);
            this.Controls.Add(this.reportTypeComboBox);
            this.Controls.Add(this.reportTypeLabel);
            this.Controls.Add(this.label1);
            this.Name = "ReportUI";
            this.Text = "ReportUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        /*
         * ******************************
         * PUBLIC METHODS
         * ******************************
        */

        public void hideUIItemsForLessonPlanReport()
        {
            subjectLabel.Visible = false;
            requiredTimeLabel.Visible = false;
            subjectComboBox.Visible = false;
            requiredTimeTextBox.Visible = false;
        }


        /*
         * ********************************
         * PRIVATE METHODS
         * ********************************
         */
        



        /*
         * ***********************************
         * PRIVATE ATTRIBUTES
         * ***********************************
         */


        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label reportTypeLabel;
        private System.Windows.Forms.ComboBox reportTypeComboBox;
        private System.Windows.Forms.Label startDateLabel;
        private System.Windows.Forms.DateTimePicker startDateTimePicker;
        private System.Windows.Forms.Label endDateLabel;
        private System.Windows.Forms.DateTimePicker EndDateTimePicker;
        private System.Windows.Forms.Label subjectLabel;
        private System.Windows.Forms.ComboBox subjectComboBox;
        private System.Windows.Forms.Label requiredTimeLabel;
        private System.Windows.Forms.TextBox requiredTimeTextBox;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button cancelButton;
    }
}