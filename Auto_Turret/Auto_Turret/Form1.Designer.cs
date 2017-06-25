namespace Auto_Turret
{
    partial class Auto_Turret_Main_Page
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Auto_Turret_Main_Page));
            this.GetData_Button = new System.Windows.Forms.Button();
            this.Login_Button = new System.Windows.Forms.Button();
            this.Clear_Button = new System.Windows.Forms.Button();
            this.Wifi_Connect_Button = new System.Windows.Forms.Button();
            this.Exit_Application_Button = new System.Windows.Forms.Button();
            this.DatabaseRecepticle = new System.Windows.Forms.ListView();
            this.EventTypes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EventTimes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TurretNames = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // GetData_Button
            // 
            this.GetData_Button.Location = new System.Drawing.Point(12, 399);
            this.GetData_Button.Name = "GetData_Button";
            this.GetData_Button.Size = new System.Drawing.Size(75, 23);
            this.GetData_Button.TabIndex = 1;
            this.GetData_Button.Text = "Get Data";
            this.GetData_Button.UseVisualStyleBackColor = true;
            this.GetData_Button.Click += new System.EventHandler(this.GetData_Button_Click);
            // 
            // Login_Button
            // 
            this.Login_Button.Location = new System.Drawing.Point(729, 506);
            this.Login_Button.Name = "Login_Button";
            this.Login_Button.Size = new System.Drawing.Size(75, 23);
            this.Login_Button.TabIndex = 2;
            this.Login_Button.Text = "Log In";
            this.Login_Button.UseVisualStyleBackColor = true;
            // 
            // Clear_Button
            // 
            this.Clear_Button.Location = new System.Drawing.Point(943, 399);
            this.Clear_Button.Name = "Clear_Button";
            this.Clear_Button.Size = new System.Drawing.Size(75, 23);
            this.Clear_Button.TabIndex = 3;
            this.Clear_Button.Text = "Clear List";
            this.Clear_Button.UseVisualStyleBackColor = true;
            this.Clear_Button.Click += new System.EventHandler(this.Clear_Button_Click);
            // 
            // Wifi_Connect_Button
            // 
            this.Wifi_Connect_Button.Location = new System.Drawing.Point(810, 506);
            this.Wifi_Connect_Button.Name = "Wifi_Connect_Button";
            this.Wifi_Connect_Button.Size = new System.Drawing.Size(127, 23);
            this.Wifi_Connect_Button.TabIndex = 4;
            this.Wifi_Connect_Button.Text = "Connect to Network";
            this.Wifi_Connect_Button.UseVisualStyleBackColor = true;
            this.Wifi_Connect_Button.Click += new System.EventHandler(this.Wifi_Connect_Button_Click);
            // 
            // Exit_Application_Button
            // 
            this.Exit_Application_Button.Location = new System.Drawing.Point(943, 506);
            this.Exit_Application_Button.Name = "Exit_Application_Button";
            this.Exit_Application_Button.Size = new System.Drawing.Size(75, 23);
            this.Exit_Application_Button.TabIndex = 5;
            this.Exit_Application_Button.Text = "Exit";
            this.Exit_Application_Button.UseVisualStyleBackColor = true;
            this.Exit_Application_Button.Click += new System.EventHandler(this.Exit_Application_Button_Click);
            // 
            // DatabaseRecepticle
            // 
            this.DatabaseRecepticle.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TurretNames,
            this.EventTypes,
            this.EventTimes});
            this.DatabaseRecepticle.FullRowSelect = true;
            this.DatabaseRecepticle.GridLines = true;
            this.DatabaseRecepticle.Location = new System.Drawing.Point(12, 12);
            this.DatabaseRecepticle.Name = "DatabaseRecepticle";
            this.DatabaseRecepticle.Size = new System.Drawing.Size(1006, 381);
            this.DatabaseRecepticle.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.DatabaseRecepticle.TabIndex = 6;
            this.DatabaseRecepticle.UseCompatibleStateImageBehavior = false;
            this.DatabaseRecepticle.View = System.Windows.Forms.View.Details;
            this.DatabaseRecepticle.SelectedIndexChanged += new System.EventHandler(this.DatabaseRecepticle_SelectedIndexChanged_1);
            // 
            // EventTypes
            // 
            this.EventTypes.Text = "Event Types";
            this.EventTypes.Width = 250;
            // 
            // EventTimes
            // 
            this.EventTimes.Text = "Event Times";
            this.EventTimes.Width = 506;
            // 
            // TurretNames
            // 
            this.TurretNames.Text = "Turret Names";
            this.TurretNames.Width = 250;
            // 
            // Auto_Turret_Main_Page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 541);
            this.Controls.Add(this.DatabaseRecepticle);
            this.Controls.Add(this.Exit_Application_Button);
            this.Controls.Add(this.Wifi_Connect_Button);
            this.Controls.Add(this.Clear_Button);
            this.Controls.Add(this.Login_Button);
            this.Controls.Add(this.GetData_Button);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Auto_Turret_Main_Page";
            this.Text = "Auto Turret Controller";
            this.Load += new System.EventHandler(this.Auto_Turret_Main_Page_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button GetData_Button;
        private System.Windows.Forms.Button Login_Button;
        private System.Windows.Forms.Button Clear_Button;
        private System.Windows.Forms.Button Wifi_Connect_Button;
        private System.Windows.Forms.Button Exit_Application_Button;
        private System.Windows.Forms.ListView DatabaseRecepticle;
        private System.Windows.Forms.ColumnHeader TurretNames;
        private System.Windows.Forms.ColumnHeader EventTypes;
        private System.Windows.Forms.ColumnHeader EventTimes;
    }
}

