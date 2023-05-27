namespace taihang_EVM
{
    partial class taihang_EVM
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        [System.Obsolete]
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(taihang_EVM));
            this.My_openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.StatusDate_Clear = new System.Windows.Forms.Button();
            this.Status_TEXT = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.VID_TEXT = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Communicate = new System.Windows.Forms.TabPage();
            this.ReceiveDate = new System.Windows.Forms.Button();
            this.ReceiveDate_Clear = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.RECEIVE_TEXT = new System.Windows.Forms.TextBox();
            this.SEND_BUTTON = new System.Windows.Forms.Button();
            this.SEND_TEXT = new System.Windows.Forms.TextBox();
            this.DFU = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.DownLoad_progressBar = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.SelectedFile_TEXT = new System.Windows.Forms.TextBox();
            this.DownLoad_Button = new System.Windows.Forms.Button();
            this.SelectFile_Button = new System.Windows.Forms.Button();
            this.USB_Conntect_Button = new System.Windows.Forms.Button();
            this.PID_TEXT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DissipateText = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.Communicate.SuspendLayout();
            this.DFU.SuspendLayout();
            this.SuspendLayout();
            // 
            // My_openFileDialog
            // 
            this.My_openFileDialog.Filter = "hex文件|*.hex|dfu文件|.dfu|SREC文件|*.srec|所有文件|*.*";
            this.My_openFileDialog.Title = "请选择要下载的文件";
            // 
            // StatusDate_Clear
            // 
            this.StatusDate_Clear.Location = new System.Drawing.Point(12, 256);
            this.StatusDate_Clear.Name = "StatusDate_Clear";
            this.StatusDate_Clear.Size = new System.Drawing.Size(310, 55);
            this.StatusDate_Clear.TabIndex = 19;
            this.StatusDate_Clear.Text = "Status Clear";
            this.StatusDate_Clear.UseVisualStyleBackColor = true;
            this.StatusDate_Clear.Click += new System.EventHandler(this.StatusDate_Clear_Click);
            // 
            // Status_TEXT
            // 
            this.Status_TEXT.Location = new System.Drawing.Point(12, 87);
            this.Status_TEXT.Multiline = true;
            this.Status_TEXT.Name = "Status_TEXT";
            this.Status_TEXT.ReadOnly = true;
            this.Status_TEXT.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Status_TEXT.Size = new System.Drawing.Size(310, 153);
            this.Status_TEXT.TabIndex = 17;
            this.Status_TEXT.TextChanged += new System.EventHandler(this.Status_TEXT_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "Status:";
            // 
            // VID_TEXT
            // 
            this.VID_TEXT.Location = new System.Drawing.Point(40, 14);
            this.VID_TEXT.Name = "VID_TEXT";
            this.VID_TEXT.Size = new System.Drawing.Size(100, 21);
            this.VID_TEXT.TabIndex = 11;
            this.VID_TEXT.Text = "1234";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Communicate);
            this.tabControl1.Controls.Add(this.DFU);
            this.tabControl1.Location = new System.Drawing.Point(328, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(330, 455);
            this.tabControl1.TabIndex = 18;
            // 
            // Communicate
            // 
            this.Communicate.Controls.Add(this.ReceiveDate);
            this.Communicate.Controls.Add(this.ReceiveDate_Clear);
            this.Communicate.Controls.Add(this.label3);
            this.Communicate.Controls.Add(this.RECEIVE_TEXT);
            this.Communicate.Controls.Add(this.SEND_BUTTON);
            this.Communicate.Controls.Add(this.SEND_TEXT);
            this.Communicate.Location = new System.Drawing.Point(4, 22);
            this.Communicate.Name = "Communicate";
            this.Communicate.Padding = new System.Windows.Forms.Padding(3);
            this.Communicate.Size = new System.Drawing.Size(322, 429);
            this.Communicate.TabIndex = 0;
            this.Communicate.Text = "Communicate";
            this.Communicate.UseVisualStyleBackColor = true;
            // 
            // ReceiveDate
            // 
            this.ReceiveDate.Location = new System.Drawing.Point(237, 77);
            this.ReceiveDate.Name = "ReceiveDate";
            this.ReceiveDate.Size = new System.Drawing.Size(78, 55);
            this.ReceiveDate.TabIndex = 10;
            this.ReceiveDate.Text = "Receive";
            this.ReceiveDate.UseVisualStyleBackColor = true;
            this.ReceiveDate.Click += new System.EventHandler(this.ReceiveDate_Click);
            // 
            // ReceiveDate_Clear
            // 
            this.ReceiveDate_Clear.Location = new System.Drawing.Point(237, 158);
            this.ReceiveDate_Clear.Name = "ReceiveDate_Clear";
            this.ReceiveDate_Clear.Size = new System.Drawing.Size(78, 55);
            this.ReceiveDate_Clear.TabIndex = 9;
            this.ReceiveDate_Clear.Text = "Receive Clear";
            this.ReceiveDate_Clear.UseVisualStyleBackColor = true;
            this.ReceiveDate_Clear.Click += new System.EventHandler(this.ReceiveDate_Clear_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "Receive：";
            // 
            // RECEIVE_TEXT
            // 
            this.RECEIVE_TEXT.Location = new System.Drawing.Point(6, 77);
            this.RECEIVE_TEXT.Multiline = true;
            this.RECEIVE_TEXT.Name = "RECEIVE_TEXT";
            this.RECEIVE_TEXT.ReadOnly = true;
            this.RECEIVE_TEXT.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.RECEIVE_TEXT.Size = new System.Drawing.Size(220, 346);
            this.RECEIVE_TEXT.TabIndex = 7;
            this.RECEIVE_TEXT.TextChanged += new System.EventHandler(this.RECEIVE_TEXT_TextChanged);
            // 
            // SEND_BUTTON
            // 
            this.SEND_BUTTON.Location = new System.Drawing.Point(237, 4);
            this.SEND_BUTTON.Name = "SEND_BUTTON";
            this.SEND_BUTTON.Size = new System.Drawing.Size(78, 55);
            this.SEND_BUTTON.TabIndex = 6;
            this.SEND_BUTTON.Text = "SEND";
            this.SEND_BUTTON.UseVisualStyleBackColor = true;
            this.SEND_BUTTON.Click += new System.EventHandler(this.SEND_BUTTON_Click);
            // 
            // SEND_TEXT
            // 
            this.SEND_TEXT.Location = new System.Drawing.Point(6, 4);
            this.SEND_TEXT.Multiline = true;
            this.SEND_TEXT.Name = "SEND_TEXT";
            this.SEND_TEXT.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SEND_TEXT.Size = new System.Drawing.Size(220, 55);
            this.SEND_TEXT.TabIndex = 5;
            this.SEND_TEXT.Text = "51 01 00 00 00 00 00 52 ";
            this.SEND_TEXT.TextChanged += new System.EventHandler(this.SEND_TEXT_TextChanged);
            // 
            // DFU
            // 
            this.DFU.Controls.Add(this.label6);
            this.DFU.Controls.Add(this.DownLoad_progressBar);
            this.DFU.Controls.Add(this.label4);
            this.DFU.Controls.Add(this.SelectedFile_TEXT);
            this.DFU.Controls.Add(this.DownLoad_Button);
            this.DFU.Controls.Add(this.SelectFile_Button);
            this.DFU.Location = new System.Drawing.Point(4, 22);
            this.DFU.Name = "DFU";
            this.DFU.Padding = new System.Windows.Forms.Padding(3);
            this.DFU.Size = new System.Drawing.Size(322, 429);
            this.DFU.TabIndex = 1;
            this.DFU.Text = "DFU";
            this.DFU.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1, 249);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "Progress:";
            // 
            // DownLoad_progressBar
            // 
            this.DownLoad_progressBar.Location = new System.Drawing.Point(3, 264);
            this.DownLoad_progressBar.Name = "DownLoad_progressBar";
            this.DownLoad_progressBar.Size = new System.Drawing.Size(316, 27);
            this.DownLoad_progressBar.Step = 1;
            this.DownLoad_progressBar.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "Selected File:";
            // 
            // SelectedFile_TEXT
            // 
            this.SelectedFile_TEXT.Location = new System.Drawing.Point(3, 122);
            this.SelectedFile_TEXT.Multiline = true;
            this.SelectedFile_TEXT.Name = "SelectedFile_TEXT";
            this.SelectedFile_TEXT.ReadOnly = true;
            this.SelectedFile_TEXT.Size = new System.Drawing.Size(218, 24);
            this.SelectedFile_TEXT.TabIndex = 2;
            // 
            // DownLoad_Button
            // 
            this.DownLoad_Button.Location = new System.Drawing.Point(227, 237);
            this.DownLoad_Button.Name = "DownLoad_Button";
            this.DownLoad_Button.Size = new System.Drawing.Size(92, 24);
            this.DownLoad_Button.TabIndex = 1;
            this.DownLoad_Button.Text = "DownLoad";
            this.DownLoad_Button.UseVisualStyleBackColor = true;
            this.DownLoad_Button.Click += new System.EventHandler(this.DownLoad_Button_Click);
            // 
            // SelectFile_Button
            // 
            this.SelectFile_Button.Location = new System.Drawing.Point(227, 122);
            this.SelectFile_Button.Name = "SelectFile_Button";
            this.SelectFile_Button.Size = new System.Drawing.Size(92, 24);
            this.SelectFile_Button.TabIndex = 0;
            this.SelectFile_Button.Text = "Select File";
            this.SelectFile_Button.UseVisualStyleBackColor = true;
            this.SelectFile_Button.Click += new System.EventHandler(this.SelectFile_Button_Click);
            // 
            // USB_Conntect_Button
            // 
            this.USB_Conntect_Button.Location = new System.Drawing.Point(146, 14);
            this.USB_Conntect_Button.Name = "USB_Conntect_Button";
            this.USB_Conntect_Button.Size = new System.Drawing.Size(175, 48);
            this.USB_Conntect_Button.TabIndex = 16;
            this.USB_Conntect_Button.Text = "Connect";
            this.USB_Conntect_Button.UseVisualStyleBackColor = true;
            this.USB_Conntect_Button.Click += new System.EventHandler(this.USB_Conntect_Button_Click);
            // 
            // PID_TEXT
            // 
            this.PID_TEXT.Location = new System.Drawing.Point(40, 41);
            this.PID_TEXT.Name = "PID_TEXT";
            this.PID_TEXT.Size = new System.Drawing.Size(100, 21);
            this.PID_TEXT.TabIndex = 14;
            this.PID_TEXT.Text = "1234";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "VID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "PID";
            // 
            // DissipateText
            // 
            this.DissipateText.Location = new System.Drawing.Point(128, 500);
            this.DissipateText.Multiline = true;
            this.DissipateText.Name = "DissipateText";
            this.DissipateText.Size = new System.Drawing.Size(308, 55);
            this.DissipateText.TabIndex = 20;
            // 
            // taihang_EVM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 462);
            this.Controls.Add(this.DissipateText);
            this.Controls.Add(this.StatusDate_Clear);
            this.Controls.Add(this.Status_TEXT);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.VID_TEXT);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.USB_Conntect_Button);
            this.Controls.Add(this.PID_TEXT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "taihang_EVM";
            this.Text = "taihang_EVM_1_0_0_4";
            this.Load += new System.EventHandler(this.taihang_EVM_Load);
            this.tabControl1.ResumeLayout(false);
            this.Communicate.ResumeLayout(false);
            this.Communicate.PerformLayout();
            this.DFU.ResumeLayout(false);
            this.DFU.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog My_openFileDialog;
        private System.Windows.Forms.Button StatusDate_Clear;
        private System.Windows.Forms.TextBox Status_TEXT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox VID_TEXT;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Communicate;
        private System.Windows.Forms.Button ReceiveDate_Clear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox RECEIVE_TEXT;
        private System.Windows.Forms.Button SEND_BUTTON;
        private System.Windows.Forms.TextBox SEND_TEXT;
        private System.Windows.Forms.TabPage DFU;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ProgressBar DownLoad_progressBar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox SelectedFile_TEXT;
        private System.Windows.Forms.Button DownLoad_Button;
        private System.Windows.Forms.Button SelectFile_Button;
        private System.Windows.Forms.Button USB_Conntect_Button;
        private System.Windows.Forms.TextBox PID_TEXT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ReceiveDate;
        private System.Windows.Forms.TextBox DissipateText;
    }
}

