namespace detectVideoApp
{
    partial class ServerConfigurationForm
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
            this.components = new System.ComponentModel.Container();
            this.serverTxtBox = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dbTxtBox = new System.Windows.Forms.TextBox();
            this.dbSaveBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // serverTxtBox
            // 
            this.serverTxtBox.Location = new System.Drawing.Point(34, 90);
            this.serverTxtBox.Name = "serverTxtBox";
            this.serverTxtBox.Size = new System.Drawing.Size(287, 22);
            this.serverTxtBox.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // dbTxtBox
            // 
            this.dbTxtBox.Location = new System.Drawing.Point(34, 153);
            this.dbTxtBox.Name = "dbTxtBox";
            this.dbTxtBox.Size = new System.Drawing.Size(287, 22);
            this.dbTxtBox.TabIndex = 2;
            // 
            // dbSaveBtn
            // 
            this.dbSaveBtn.Location = new System.Drawing.Point(396, 166);
            this.dbSaveBtn.Name = "dbSaveBtn";
            this.dbSaveBtn.Size = new System.Drawing.Size(75, 23);
            this.dbSaveBtn.TabIndex = 5;
            this.dbSaveBtn.Text = "save";
            this.dbSaveBtn.UseVisualStyleBackColor = true;
            this.dbSaveBtn.Click += new System.EventHandler(this.DbSaveBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(23, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 55);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(23, 134);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(312, 55);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Database";
            // 
            // ServerConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 216);
            this.Controls.Add(this.dbSaveBtn);
            this.Controls.Add(this.dbTxtBox);
            this.Controls.Add(this.serverTxtBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ServerConfigurationForm";
            this.Text = "Server Configuration";
            this.Load += new System.EventHandler(this.DatabaseConfiguration_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox serverTxtBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox dbTxtBox;
        private System.Windows.Forms.Button dbSaveBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}