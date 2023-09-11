namespace detectVideoApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.startMonitoringBtn = new System.Windows.Forms.Button();
            this.endMonitoringBtn = new System.Windows.Forms.Button();
            this.availableCamerasBtn = new System.Windows.Forms.Button();
            this.availableCamerasCheckListBox = new System.Windows.Forms.CheckedListBox();
            this.statusStopped = new System.Windows.Forms.Label();
            this.statusRunning = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MonitoringDetailsDataGridView = new System.Windows.Forms.DataGridView();
            this.mNavBar = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historyFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mConfiguBar = new System.Windows.Forms.ToolStripMenuItem();
            this.mModifyConfiguBar = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewConfigurationFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyConfigurationFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverConfigurationFormStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monitoringDataGroupBox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.MonitoringDetailsDataGridView)).BeginInit();
            this.mNavBar.SuspendLayout();
            this.monitoringDataGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // startMonitoringBtn
            // 
            this.startMonitoringBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startMonitoringBtn.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startMonitoringBtn.Location = new System.Drawing.Point(676, 52);
            this.startMonitoringBtn.Name = "startMonitoringBtn";
            this.startMonitoringBtn.Size = new System.Drawing.Size(95, 25);
            this.startMonitoringBtn.TabIndex = 3;
            this.startMonitoringBtn.Text = "Start";
            this.startMonitoringBtn.UseVisualStyleBackColor = true;
            this.startMonitoringBtn.Click += new System.EventHandler(this.StartMonitoring_Click);
            // 
            // endMonitoringBtn
            // 
            this.endMonitoringBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.endMonitoringBtn.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.endMonitoringBtn.Location = new System.Drawing.Point(776, 52);
            this.endMonitoringBtn.Name = "endMonitoringBtn";
            this.endMonitoringBtn.Size = new System.Drawing.Size(95, 25);
            this.endMonitoringBtn.TabIndex = 6;
            this.endMonitoringBtn.Text = "Stop";
            this.endMonitoringBtn.UseVisualStyleBackColor = true;
            this.endMonitoringBtn.Click += new System.EventHandler(this.EndMonitoring_Click);
            // 
            // availableCamerasBtn
            // 
            this.availableCamerasBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.availableCamerasBtn.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.availableCamerasBtn.Location = new System.Drawing.Point(262, 52);
            this.availableCamerasBtn.Name = "availableCamerasBtn";
            this.availableCamerasBtn.Size = new System.Drawing.Size(386, 25);
            this.availableCamerasBtn.TabIndex = 9;
            this.availableCamerasBtn.Text = "Available Cameras";
            this.availableCamerasBtn.UseVisualStyleBackColor = true;
            this.availableCamerasBtn.Click += new System.EventHandler(this.AvailableCamerasBtn_Click);
            // 
            // availableCamerasCheckListBox
            // 
            this.availableCamerasCheckListBox.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDown;
            this.availableCamerasCheckListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.availableCamerasCheckListBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.availableCamerasCheckListBox.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.availableCamerasCheckListBox.FormattingEnabled = true;
            this.availableCamerasCheckListBox.Location = new System.Drawing.Point(262, 80);
            this.availableCamerasCheckListBox.Margin = new System.Windows.Forms.Padding(10);
            this.availableCamerasCheckListBox.Name = "availableCamerasCheckListBox";
            this.availableCamerasCheckListBox.Size = new System.Drawing.Size(386, 137);
            this.availableCamerasCheckListBox.TabIndex = 1;
            // 
            // statusStopped
            // 
            this.statusStopped.AutoSize = true;
            this.statusStopped.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statusStopped.ForeColor = System.Drawing.Color.Red;
            this.statusStopped.Location = new System.Drawing.Point(73, 545);
            this.statusStopped.Name = "statusStopped";
            this.statusStopped.Size = new System.Drawing.Size(68, 16);
            this.statusStopped.TabIndex = 11;
            this.statusStopped.Text = "STOPPED";
            // 
            // statusRunning
            // 
            this.statusRunning.AutoSize = true;
            this.statusRunning.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statusRunning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.statusRunning.Location = new System.Drawing.Point(73, 545);
            this.statusRunning.Name = "statusRunning";
            this.statusRunning.Size = new System.Drawing.Size(65, 16);
            this.statusRunning.TabIndex = 12;
            this.statusRunning.Text = "RUNNING";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(10, 545);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Status:";
            // 
            // MonitoringDetailsDataGridView
            // 
            this.MonitoringDetailsDataGridView.AllowUserToAddRows = false;
            this.MonitoringDetailsDataGridView.AllowUserToDeleteRows = false;
            this.MonitoringDetailsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MonitoringDetailsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MonitoringDetailsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MonitoringDetailsDataGridView.Location = new System.Drawing.Point(24, 32);
            this.MonitoringDetailsDataGridView.Name = "MonitoringDetailsDataGridView";
            this.MonitoringDetailsDataGridView.RowHeadersWidth = 51;
            this.MonitoringDetailsDataGridView.RowTemplate.Height = 24;
            this.MonitoringDetailsDataGridView.Size = new System.Drawing.Size(1119, 227);
            this.MonitoringDetailsDataGridView.TabIndex = 14;
            // 
            // mNavBar
            // 
            this.mNavBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.mNavBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mNavBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.historyFormToolStripMenuItem,
            this.mConfiguBar});
            this.mNavBar.Location = new System.Drawing.Point(0, 0);
            this.mNavBar.Name = "mNavBar";
            this.mNavBar.Padding = new System.Windows.Forms.Padding(9, 2, 0, 2);
            this.mNavBar.Size = new System.Drawing.Size(1189, 28);
            this.mNavBar.TabIndex = 55;
            this.mNavBar.Text = "menuStrip2";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlLight;
            this.homeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("homeToolStripMenuItem.Image")));
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(84, 24);
            this.homeToolStripMenuItem.Text = "Home";
            // 
            // historyFormToolStripMenuItem
            // 
            this.historyFormToolStripMenuItem.Checked = true;
            this.historyFormToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.historyFormToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("historyFormToolStripMenuItem.Image")));
            this.historyFormToolStripMenuItem.Name = "historyFormToolStripMenuItem";
            this.historyFormToolStripMenuItem.Size = new System.Drawing.Size(90, 24);
            this.historyFormToolStripMenuItem.Text = "History";
            this.historyFormToolStripMenuItem.Click += new System.EventHandler(this.HistoryFormToolStripMenuItem_Click);
            // 
            // mConfiguBar
            // 
            this.mConfiguBar.BackColor = System.Drawing.SystemColors.Control;
            this.mConfiguBar.Checked = true;
            this.mConfiguBar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mConfiguBar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mModifyConfiguBar,
            this.serverConfigurationFormStripMenuItem});
            this.mConfiguBar.Image = ((System.Drawing.Image)(resources.GetObject("mConfiguBar.Image")));
            this.mConfiguBar.Name = "mConfiguBar";
            this.mConfiguBar.Size = new System.Drawing.Size(134, 24);
            this.mConfiguBar.Text = "Configuration";
            // 
            // mModifyConfiguBar
            // 
            this.mModifyConfiguBar.BackColor = System.Drawing.SystemColors.Control;
            this.mModifyConfiguBar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewConfigurationFormToolStripMenuItem,
            this.modifyConfigurationFormToolStripMenuItem});
            this.mModifyConfiguBar.Image = ((System.Drawing.Image)(resources.GetObject("mModifyConfiguBar.Image")));
            this.mModifyConfiguBar.Name = "mModifyConfiguBar";
            this.mModifyConfiguBar.Size = new System.Drawing.Size(143, 26);
            this.mModifyConfiguBar.Text = "Camera";
            // 
            // addNewConfigurationFormToolStripMenuItem
            // 
            this.addNewConfigurationFormToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.addNewConfigurationFormToolStripMenuItem.Image = global::detectVideoAppEF.Properties.Resources.icons8_add_24;
            this.addNewConfigurationFormToolStripMenuItem.Name = "addNewConfigurationFormToolStripMenuItem";
            this.addNewConfigurationFormToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.addNewConfigurationFormToolStripMenuItem.Text = "Add Configuration";
            this.addNewConfigurationFormToolStripMenuItem.Click += new System.EventHandler(this.AddNewConfigurationFormToolStripMenuItem_Click);
            // 
            // modifyConfigurationFormToolStripMenuItem
            // 
            this.modifyConfigurationFormToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.modifyConfigurationFormToolStripMenuItem.Image = global::detectVideoAppEF.Properties.Resources.icons8_edit_50;
            this.modifyConfigurationFormToolStripMenuItem.Name = "modifyConfigurationFormToolStripMenuItem";
            this.modifyConfigurationFormToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.modifyConfigurationFormToolStripMenuItem.Text = "Modify Configuration";
            this.modifyConfigurationFormToolStripMenuItem.Click += new System.EventHandler(this.ModifyConfigurationFormToolStripMenuItem_Click);
            // 
            // serverConfigurationFormStripMenuItem
            // 
            this.serverConfigurationFormStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("serverConfigurationFormStripMenuItem.Image")));
            this.serverConfigurationFormStripMenuItem.Name = "serverConfigurationFormStripMenuItem";
            this.serverConfigurationFormStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.serverConfigurationFormStripMenuItem.Text = "Server";
            this.serverConfigurationFormStripMenuItem.Click += new System.EventHandler(this.ServerConfigurationFormStripMenuItem_Click);
            // 
            // monitoringDataGroupBox
            // 
            this.monitoringDataGroupBox.Controls.Add(this.MonitoringDetailsDataGridView);
            this.monitoringDataGroupBox.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.monitoringDataGroupBox.Location = new System.Drawing.Point(12, 264);
            this.monitoringDataGroupBox.Name = "monitoringDataGroupBox";
            this.monitoringDataGroupBox.Size = new System.Drawing.Size(1165, 278);
            this.monitoringDataGroupBox.TabIndex = 56;
            this.monitoringDataGroupBox.TabStop = false;
            this.monitoringDataGroupBox.Text = "Camera Monitoring Data";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1189, 566);
            this.Controls.Add(this.mNavBar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusRunning);
            this.Controls.Add(this.statusStopped);
            this.Controls.Add(this.availableCamerasBtn);
            this.Controls.Add(this.endMonitoringBtn);
            this.Controls.Add(this.startMonitoringBtn);
            this.Controls.Add(this.availableCamerasCheckListBox);
            this.Controls.Add(this.monitoringDataGroupBox);
            this.Name = "MainForm";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MonitoringDetailsDataGridView)).EndInit();
            this.mNavBar.ResumeLayout(false);
            this.mNavBar.PerformLayout();
            this.monitoringDataGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button startMonitoringBtn;
        private System.Windows.Forms.Button endMonitoringBtn;
        private System.Windows.Forms.Button availableCamerasBtn;
        private System.Windows.Forms.CheckedListBox availableCamerasCheckListBox;
        private System.Windows.Forms.Label statusStopped;
        private System.Windows.Forms.Label statusRunning;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView MonitoringDetailsDataGridView;
        private System.Windows.Forms.MenuStrip mNavBar;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historyFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mConfiguBar;
        private System.Windows.Forms.ToolStripMenuItem mModifyConfiguBar;
        private System.Windows.Forms.ToolStripMenuItem addNewConfigurationFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyConfigurationFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serverConfigurationFormStripMenuItem;
        private System.Windows.Forms.GroupBox monitoringDataGroupBox;
    }
}

