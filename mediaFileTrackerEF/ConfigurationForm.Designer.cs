namespace detectVideoApp
{
    partial class ConfigurationForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.folderPathsDataGridView = new System.Windows.Forms.DataGridView();
            this.videoExtensDataGridView = new System.Windows.Forms.DataGridView();
            this.photoExtensDataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.deleteConfigurationBtn = new System.Windows.Forms.Button();
            this.displayExistingCamerasComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.folderPathsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoExtensDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.photoExtensDataGridView)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.folderPathsDataGridView);
            this.groupBox1.Controls.Add(this.videoExtensDataGridView);
            this.groupBox1.Controls.Add(this.photoExtensDataGridView);
            this.groupBox1.Location = new System.Drawing.Point(14, 139);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(799, 378);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Change Configuration";
            // 
            // folderPathsDataGridView
            // 
            this.folderPathsDataGridView.AllowUserToOrderColumns = true;
            this.folderPathsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.folderPathsDataGridView.Location = new System.Drawing.Point(120, 51);
            this.folderPathsDataGridView.Name = "folderPathsDataGridView";
            this.folderPathsDataGridView.RowHeadersWidth = 51;
            this.folderPathsDataGridView.RowTemplate.Height = 24;
            this.folderPathsDataGridView.Size = new System.Drawing.Size(511, 147);
            this.folderPathsDataGridView.TabIndex = 39;
            this.folderPathsDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FolderPathsDataGridView_CellContentClick);
            // 
            // videoExtensDataGridView
            // 
            this.videoExtensDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.videoExtensDataGridView.Location = new System.Drawing.Point(376, 199);
            this.videoExtensDataGridView.Name = "videoExtensDataGridView";
            this.videoExtensDataGridView.RowHeadersWidth = 51;
            this.videoExtensDataGridView.RowTemplate.Height = 24;
            this.videoExtensDataGridView.Size = new System.Drawing.Size(255, 147);
            this.videoExtensDataGridView.TabIndex = 41;
            this.videoExtensDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.VideoExtensDataGridView_CellContentClick);
            // 
            // photoExtensDataGridView
            // 
            this.photoExtensDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.photoExtensDataGridView.Location = new System.Drawing.Point(120, 199);
            this.photoExtensDataGridView.Name = "photoExtensDataGridView";
            this.photoExtensDataGridView.RowHeadersWidth = 51;
            this.photoExtensDataGridView.RowTemplate.Height = 24;
            this.photoExtensDataGridView.Size = new System.Drawing.Size(255, 147);
            this.photoExtensDataGridView.TabIndex = 40;
            this.photoExtensDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PhotoExtensDataGridView_CellContentClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.deleteConfigurationBtn);
            this.groupBox3.Controls.Add(this.displayExistingCamerasComboBox);
            this.groupBox3.Location = new System.Drawing.Point(14, 26);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(799, 81);
            this.groupBox3.TabIndex = 42;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Available Cameras";
            // 
            // deleteConfigurationBtn
            // 
            this.deleteConfigurationBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteConfigurationBtn.AutoSize = true;
            this.deleteConfigurationBtn.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.deleteConfigurationBtn.Location = new System.Drawing.Point(507, 33);
            this.deleteConfigurationBtn.Name = "deleteConfigurationBtn";
            this.deleteConfigurationBtn.Size = new System.Drawing.Size(162, 27);
            this.deleteConfigurationBtn.TabIndex = 38;
            this.deleteConfigurationBtn.Text = "Delete Configuration";
            this.deleteConfigurationBtn.UseVisualStyleBackColor = true;
            this.deleteConfigurationBtn.Click += new System.EventHandler(this.DeleteConfigurationBtn_Click);
            // 
            // displayExistingCamerasComboBox
            // 
            this.displayExistingCamerasComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.displayExistingCamerasComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.displayExistingCamerasComboBox.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.displayExistingCamerasComboBox.FormattingEnabled = true;
            this.displayExistingCamerasComboBox.Location = new System.Drawing.Point(120, 33);
            this.displayExistingCamerasComboBox.Name = "displayExistingCamerasComboBox";
            this.displayExistingCamerasComboBox.Size = new System.Drawing.Size(343, 25);
            this.displayExistingCamerasComboBox.TabIndex = 37;
            this.displayExistingCamerasComboBox.SelectedIndexChanged += new System.EventHandler(this.DisplayExistingCamerasComboBox_SelectedIndexChanged);
            // 
            // ConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(825, 533);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.Name = "ConfigurationForm";
            this.Text = "Configuration";
            this.Load += new System.EventHandler(this.ConfigurationForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.folderPathsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoExtensDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.photoExtensDataGridView)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox displayExistingCamerasComboBox;
        private System.Windows.Forms.Button deleteConfigurationBtn;
        private System.Windows.Forms.DataGridView videoExtensDataGridView;
        private System.Windows.Forms.DataGridView photoExtensDataGridView;
        private System.Windows.Forms.DataGridView folderPathsDataGridView;
    }
}