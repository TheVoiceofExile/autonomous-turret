namespace Auto_Turret
{
    partial class CreateSummary
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
            this.FromDate = new System.Windows.Forms.DateTimePicker();
            this.ToDate = new System.Windows.Forms.DateTimePicker();
            this.FromLabel = new System.Windows.Forms.Label();
            this.ToLabel = new System.Windows.Forms.Label();
            this.CreateSummaryButton = new System.Windows.Forms.Button();
            this.FireEventsCheckBox = new System.Windows.Forms.CheckBox();
            this.WarningEventsCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // FromDate
            // 
            this.FromDate.Location = new System.Drawing.Point(48, 12);
            this.FromDate.Name = "FromDate";
            this.FromDate.Size = new System.Drawing.Size(200, 20);
            this.FromDate.TabIndex = 0;
            this.FromDate.Value = new System.DateTime(2017, 6, 25, 21, 3, 50, 0);
            this.FromDate.ValueChanged += new System.EventHandler(this.FromDate_ValueChanged);
            // 
            // ToDate
            // 
            this.ToDate.Location = new System.Drawing.Point(48, 39);
            this.ToDate.Name = "ToDate";
            this.ToDate.Size = new System.Drawing.Size(200, 20);
            this.ToDate.TabIndex = 1;
            this.ToDate.Value = new System.DateTime(2017, 6, 25, 21, 1, 58, 0);
            this.ToDate.ValueChanged += new System.EventHandler(this.ToDate_ValueChanged);
            // 
            // FromLabel
            // 
            this.FromLabel.AutoSize = true;
            this.FromLabel.Location = new System.Drawing.Point(12, 18);
            this.FromLabel.Name = "FromLabel";
            this.FromLabel.Size = new System.Drawing.Size(30, 13);
            this.FromLabel.TabIndex = 2;
            this.FromLabel.Text = "From";
            // 
            // ToLabel
            // 
            this.ToLabel.AutoSize = true;
            this.ToLabel.Location = new System.Drawing.Point(12, 45);
            this.ToLabel.Name = "ToLabel";
            this.ToLabel.Size = new System.Drawing.Size(20, 13);
            this.ToLabel.TabIndex = 3;
            this.ToLabel.Text = "To";
            // 
            // CreateSummaryButton
            // 
            this.CreateSummaryButton.Location = new System.Drawing.Point(15, 87);
            this.CreateSummaryButton.Name = "CreateSummaryButton";
            this.CreateSummaryButton.Size = new System.Drawing.Size(233, 23);
            this.CreateSummaryButton.TabIndex = 4;
            this.CreateSummaryButton.Text = "Create Summary";
            this.CreateSummaryButton.UseVisualStyleBackColor = true;
            this.CreateSummaryButton.Click += new System.EventHandler(this.CreateSummaryButton_Click);
            // 
            // FireEventsCheckBox
            // 
            this.FireEventsCheckBox.AutoSize = true;
            this.FireEventsCheckBox.Checked = true;
            this.FireEventsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FireEventsCheckBox.Location = new System.Drawing.Point(15, 64);
            this.FireEventsCheckBox.Name = "FireEventsCheckBox";
            this.FireEventsCheckBox.Size = new System.Drawing.Size(79, 17);
            this.FireEventsCheckBox.TabIndex = 5;
            this.FireEventsCheckBox.Text = "Fire Events";
            this.FireEventsCheckBox.UseVisualStyleBackColor = true;
            this.FireEventsCheckBox.CheckedChanged += new System.EventHandler(this.FireEventsCheckBox_CheckedChanged);
            // 
            // WarningEventsCheckBox
            // 
            this.WarningEventsCheckBox.AutoSize = true;
            this.WarningEventsCheckBox.Checked = true;
            this.WarningEventsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.WarningEventsCheckBox.Location = new System.Drawing.Point(101, 64);
            this.WarningEventsCheckBox.Name = "WarningEventsCheckBox";
            this.WarningEventsCheckBox.Size = new System.Drawing.Size(102, 17);
            this.WarningEventsCheckBox.TabIndex = 6;
            this.WarningEventsCheckBox.Text = "Warning Events";
            this.WarningEventsCheckBox.UseVisualStyleBackColor = true;
            this.WarningEventsCheckBox.CheckedChanged += new System.EventHandler(this.WarningEventsCheckBox_CheckedChanged);
            // 
            // CreateSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 122);
            this.Controls.Add(this.WarningEventsCheckBox);
            this.Controls.Add(this.FireEventsCheckBox);
            this.Controls.Add(this.CreateSummaryButton);
            this.Controls.Add(this.ToLabel);
            this.Controls.Add(this.FromLabel);
            this.Controls.Add(this.ToDate);
            this.Controls.Add(this.FromDate);
            this.Name = "CreateSummary";
            this.Text = "Create Summary";
            this.Load += new System.EventHandler(this.CreateSummary_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker FromDate;
        private System.Windows.Forms.DateTimePicker ToDate;
        private System.Windows.Forms.Label FromLabel;
        private System.Windows.Forms.Label ToLabel;
        private System.Windows.Forms.Button CreateSummaryButton;
        private System.Windows.Forms.CheckBox FireEventsCheckBox;
        private System.Windows.Forms.CheckBox WarningEventsCheckBox;
    }
}