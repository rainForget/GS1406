namespace GS_1406
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            textBoxScanSN = new TextBox();
            textBoxScanBle = new TextBox();
            labelStatue = new Label();
            labelScanSN = new Label();
            labelScanBle = new Label();
            button1 = new Button();
            label1 = new Label();
            menuStrip1 = new MenuStrip();
            设置ToolStripMenuItem = new ToolStripMenuItem();
            设置ToolStripMenuItem1 = new ToolStripMenuItem();
            panel1 = new Panel();
            textBoxColor = new TextBox();
            textBoxScanCaseSN = new TextBox();
            labelScanCaseSN = new Label();
            buttonResetMode = new Button();
            buttonEnterShipMode = new Button();
            textBoxHardVersion = new TextBox();
            buttonSetHardVersion = new Button();
            buttonSetDeviceColor = new Button();
            textBoxProductId = new TextBox();
            labelProductId = new Label();
            panel2 = new Panel();
            labelLProduct = new Label();
            label8 = new Label();
            labelRProduct = new Label();
            label23 = new Label();
            labelLCaseSN = new Label();
            label25 = new Label();
            labelRSN = new Label();
            label19 = new Label();
            labelLSN = new Label();
            label21 = new Label();
            labelRMFI = new Label();
            label15 = new Label();
            labelLMFI = new Label();
            label17 = new Label();
            labelRSoftVersion = new Label();
            label11 = new Label();
            labelLSoftVersion = new Label();
            label13 = new Label();
            labelRHardVersion = new Label();
            label6 = new Label();
            labelLHardVersion = new Label();
            label9 = new Label();
            labelRBattery = new Label();
            label5 = new Label();
            labelLBattery = new Label();
            label7 = new Label();
            labelRColor = new Label();
            label3 = new Label();
            labelLColor = new Label();
            label4 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            panel3 = new Panel();
            labelRCaseSN = new Label();
            label10 = new Label();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxScanSN
            // 
            textBoxScanSN.Location = new Point(179, 74);
            textBoxScanSN.MaxLength = 14;
            textBoxScanSN.Name = "textBoxScanSN";
            textBoxScanSN.ReadOnly = true;
            textBoxScanSN.Size = new Size(196, 23);
            textBoxScanSN.TabIndex = 39;
            textBoxScanSN.TextChanged += textBoxScanSN_TextChanged;
            // 
            // textBoxScanBle
            // 
            textBoxScanBle.Location = new Point(179, 44);
            textBoxScanBle.MaxLength = 12;
            textBoxScanBle.Name = "textBoxScanBle";
            textBoxScanBle.Size = new Size(196, 23);
            textBoxScanBle.TabIndex = 38;
            textBoxScanBle.TextChanged += textBoxScanBle_TextChanged;
            // 
            // labelStatue
            // 
            labelStatue.BackColor = Color.White;
            labelStatue.ForeColor = Color.Black;
            labelStatue.Location = new Point(488, 43);
            labelStatue.Name = "labelStatue";
            labelStatue.Size = new Size(178, 83);
            labelStatue.TabIndex = 37;
            labelStatue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelScanSN
            // 
            labelScanSN.BackColor = SystemColors.ActiveCaption;
            labelScanSN.ForeColor = Color.Black;
            labelScanSN.Location = new Point(36, 74);
            labelScanSN.Name = "labelScanSN";
            labelScanSN.Size = new Size(100, 23);
            labelScanSN.TabIndex = 35;
            labelScanSN.Text = "扫描耳机SN";
            labelScanSN.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelScanBle
            // 
            labelScanBle.BackColor = SystemColors.ActiveCaption;
            labelScanBle.ForeColor = Color.Black;
            labelScanBle.Location = new Point(36, 43);
            labelScanBle.Name = "labelScanBle";
            labelScanBle.Size = new Size(100, 23);
            labelScanBle.TabIndex = 34;
            labelScanBle.Text = "扫描蓝牙地址";
            labelScanBle.TextAlign = ContentAlignment.MiddleRight;
            // 
            // button1
            // 
            button1.ForeColor = Color.Black;
            button1.Location = new Point(36, 6);
            button1.Name = "button1";
            button1.Size = new Size(100, 27);
            button1.TabIndex = 33;
            button1.Text = "断开连接";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.BackColor = SystemColors.MenuHighlight;
            label1.Font = new Font("Microsoft YaHei UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(0, 25);
            label1.Name = "label1";
            label1.Size = new Size(756, 35);
            label1.TabIndex = 32;
            label1.Text = "GS-1406/1408";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { 设置ToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(754, 25);
            menuStrip1.TabIndex = 31;
            menuStrip1.Text = "menuStrip1";
            // 
            // 设置ToolStripMenuItem
            // 
            设置ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 设置ToolStripMenuItem1 });
            设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            设置ToolStripMenuItem.Size = new Size(44, 21);
            设置ToolStripMenuItem.Text = "菜单";
            // 
            // 设置ToolStripMenuItem1
            // 
            设置ToolStripMenuItem1.Name = "设置ToolStripMenuItem1";
            设置ToolStripMenuItem1.Size = new Size(100, 22);
            设置ToolStripMenuItem1.Text = "设置";
            设置ToolStripMenuItem1.Click += SettingToolStripMenuItem_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(labelStatue);
            panel1.Controls.Add(textBoxColor);
            panel1.Controls.Add(textBoxProductId);
            panel1.Controls.Add(textBoxScanCaseSN);
            panel1.Controls.Add(textBoxScanSN);
            panel1.Controls.Add(labelScanCaseSN);
            panel1.Controls.Add(textBoxScanBle);
            panel1.Controls.Add(buttonResetMode);
            panel1.Controls.Add(buttonEnterShipMode);
            panel1.Controls.Add(labelProductId);
            panel1.Controls.Add(textBoxHardVersion);
            panel1.Controls.Add(labelScanSN);
            panel1.Controls.Add(buttonSetHardVersion);
            panel1.Controls.Add(labelScanBle);
            panel1.Controls.Add(buttonSetDeviceColor);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(12, 63);
            panel1.Name = "panel1";
            panel1.Size = new Size(732, 259);
            panel1.TabIndex = 41;
            // 
            // textBoxColor
            // 
            textBoxColor.Enabled = false;
            textBoxColor.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxColor.Location = new Point(178, 166);
            textBoxColor.Name = "textBoxColor";
            textBoxColor.Size = new Size(121, 28);
            textBoxColor.TabIndex = 75;
            // 
            // textBoxScanCaseSN
            // 
            textBoxScanCaseSN.Location = new Point(178, 103);
            textBoxScanCaseSN.MaxLength = 15;
            textBoxScanCaseSN.Name = "textBoxScanCaseSN";
            textBoxScanCaseSN.ReadOnly = true;
            textBoxScanCaseSN.Size = new Size(196, 23);
            textBoxScanCaseSN.TabIndex = 74;
            textBoxScanCaseSN.TextChanged += textBoxScanCaseSN_TextChanged;
            // 
            // labelScanCaseSN
            // 
            labelScanCaseSN.BackColor = SystemColors.ActiveCaption;
            labelScanCaseSN.ForeColor = Color.Black;
            labelScanCaseSN.Location = new Point(35, 103);
            labelScanCaseSN.Name = "labelScanCaseSN";
            labelScanCaseSN.Size = new Size(100, 23);
            labelScanCaseSN.TabIndex = 73;
            labelScanCaseSN.Text = "扫描盒子SN";
            labelScanCaseSN.TextAlign = ContentAlignment.MiddleRight;
            // 
            // buttonResetMode
            // 
            buttonResetMode.Location = new Point(178, 213);
            buttonResetMode.Name = "buttonResetMode";
            buttonResetMode.Size = new Size(121, 35);
            buttonResetMode.TabIndex = 72;
            buttonResetMode.Text = "重置模式";
            buttonResetMode.UseVisualStyleBackColor = true;
            buttonResetMode.Click += buttonResetMode_Click;
            // 
            // buttonEnterShipMode
            // 
            buttonEnterShipMode.Location = new Point(35, 213);
            buttonEnterShipMode.Name = "buttonEnterShipMode";
            buttonEnterShipMode.Size = new Size(121, 35);
            buttonEnterShipMode.TabIndex = 71;
            buttonEnterShipMode.Text = "进入SHIP模式";
            buttonEnterShipMode.UseVisualStyleBackColor = true;
            buttonEnterShipMode.Click += buttonEnterShipMode_Click;
            // 
            // textBoxHardVersion
            // 
            textBoxHardVersion.Enabled = false;
            textBoxHardVersion.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxHardVersion.Location = new Point(515, 165);
            textBoxHardVersion.Name = "textBoxHardVersion";
            textBoxHardVersion.Size = new Size(121, 28);
            textBoxHardVersion.TabIndex = 57;
            // 
            // buttonSetHardVersion
            // 
            buttonSetHardVersion.Location = new Point(372, 162);
            buttonSetHardVersion.Name = "buttonSetHardVersion";
            buttonSetHardVersion.Size = new Size(121, 35);
            buttonSetHardVersion.TabIndex = 56;
            buttonSetHardVersion.Text = "设置硬件版本";
            buttonSetHardVersion.UseVisualStyleBackColor = true;
            buttonSetHardVersion.Click += buttonSetHardVersion_Click;
            // 
            // buttonSetDeviceColor
            // 
            buttonSetDeviceColor.Location = new Point(35, 164);
            buttonSetDeviceColor.Name = "buttonSetDeviceColor";
            buttonSetDeviceColor.Size = new Size(121, 35);
            buttonSetDeviceColor.TabIndex = 54;
            buttonSetDeviceColor.Text = "设置设备颜色";
            buttonSetDeviceColor.UseVisualStyleBackColor = true;
            buttonSetDeviceColor.Click += buttonSetDeviceColor_Click;
            // 
            // textBoxProductId
            // 
            textBoxProductId.Location = new Point(179, 131);
            textBoxProductId.Name = "textBoxProductId";
            textBoxProductId.ReadOnly = true;
            textBoxProductId.Size = new Size(196, 23);
            textBoxProductId.TabIndex = 40;
            // 
            // labelProductId
            // 
            labelProductId.BackColor = SystemColors.ActiveCaption;
            labelProductId.ForeColor = Color.Black;
            labelProductId.Location = new Point(36, 131);
            labelProductId.Name = "labelProductId";
            labelProductId.Size = new Size(100, 23);
            labelProductId.TabIndex = 36;
            labelProductId.Text = "产品型号";
            labelProductId.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveCaption;
            panel2.Controls.Add(labelRCaseSN);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(labelLProduct);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(labelRProduct);
            panel2.Controls.Add(label23);
            panel2.Controls.Add(labelLCaseSN);
            panel2.Controls.Add(label25);
            panel2.Controls.Add(labelRSN);
            panel2.Controls.Add(label19);
            panel2.Controls.Add(labelLSN);
            panel2.Controls.Add(label21);
            panel2.Controls.Add(labelRMFI);
            panel2.Controls.Add(label15);
            panel2.Controls.Add(labelLMFI);
            panel2.Controls.Add(label17);
            panel2.Controls.Add(labelRSoftVersion);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(labelLSoftVersion);
            panel2.Controls.Add(label13);
            panel2.Controls.Add(labelRHardVersion);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(labelLHardVersion);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(labelRBattery);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(labelLBattery);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(labelRColor);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(labelLColor);
            panel2.Controls.Add(label4);
            panel2.Location = new Point(32, 274);
            panel2.Name = "panel2";
            panel2.Size = new Size(732, 328);
            panel2.TabIndex = 42;
            // 
            // labelLProduct
            // 
            labelLProduct.BackColor = Color.White;
            labelLProduct.Location = new Point(179, 253);
            labelLProduct.Name = "labelLProduct";
            labelLProduct.Size = new Size(131, 23);
            labelLProduct.TabIndex = 29;
            labelLProduct.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.Location = new Point(36, 253);
            label8.Name = "label8";
            label8.Size = new Size(100, 23);
            label8.TabIndex = 28;
            label8.Text = "左耳产品型号";
            label8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelRProduct
            // 
            labelRProduct.BackColor = Color.White;
            labelRProduct.Location = new Point(515, 253);
            labelRProduct.Name = "labelRProduct";
            labelRProduct.Size = new Size(131, 23);
            labelRProduct.TabIndex = 27;
            labelRProduct.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label23
            // 
            label23.Location = new Point(372, 253);
            label23.Name = "label23";
            label23.Size = new Size(100, 23);
            label23.TabIndex = 26;
            label23.Text = "右耳产品型号";
            label23.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelLCaseSN
            // 
            labelLCaseSN.BackColor = Color.White;
            labelLCaseSN.Location = new Point(178, 293);
            labelLCaseSN.Name = "labelLCaseSN";
            labelLCaseSN.Size = new Size(131, 23);
            labelLCaseSN.TabIndex = 25;
            labelLCaseSN.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label25
            // 
            label25.Location = new Point(35, 293);
            label25.Name = "label25";
            label25.Size = new Size(100, 23);
            label25.TabIndex = 24;
            label25.Text = "左耳盒子SN";
            label25.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelRSN
            // 
            labelRSN.BackColor = Color.White;
            labelRSN.Location = new Point(516, 213);
            labelRSN.Name = "labelRSN";
            labelRSN.Size = new Size(131, 23);
            labelRSN.TabIndex = 23;
            labelRSN.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            label19.Location = new Point(373, 213);
            label19.Name = "label19";
            label19.Size = new Size(100, 23);
            label19.TabIndex = 22;
            label19.Text = "右耳SN";
            label19.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelLSN
            // 
            labelLSN.BackColor = Color.White;
            labelLSN.Location = new Point(179, 213);
            labelLSN.Name = "labelLSN";
            labelLSN.Size = new Size(131, 23);
            labelLSN.TabIndex = 21;
            labelLSN.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            label21.Location = new Point(36, 213);
            label21.Name = "label21";
            label21.Size = new Size(100, 23);
            label21.TabIndex = 20;
            label21.Text = "左耳SN";
            label21.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelRMFI
            // 
            labelRMFI.BackColor = Color.White;
            labelRMFI.Location = new Point(516, 173);
            labelRMFI.Name = "labelRMFI";
            labelRMFI.Size = new Size(131, 23);
            labelRMFI.TabIndex = 19;
            labelRMFI.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            label15.Location = new Point(373, 173);
            label15.Name = "label15";
            label15.Size = new Size(100, 23);
            label15.TabIndex = 18;
            label15.Text = "右耳MFI";
            label15.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelLMFI
            // 
            labelLMFI.BackColor = Color.White;
            labelLMFI.Location = new Point(179, 173);
            labelLMFI.Name = "labelLMFI";
            labelLMFI.Size = new Size(131, 23);
            labelLMFI.TabIndex = 17;
            labelLMFI.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            label17.Location = new Point(36, 173);
            label17.Name = "label17";
            label17.Size = new Size(100, 23);
            label17.TabIndex = 16;
            label17.Text = "左耳MFI";
            label17.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelRSoftVersion
            // 
            labelRSoftVersion.BackColor = Color.White;
            labelRSoftVersion.Location = new Point(516, 93);
            labelRSoftVersion.Name = "labelRSoftVersion";
            labelRSoftVersion.Size = new Size(131, 23);
            labelRSoftVersion.TabIndex = 15;
            labelRSoftVersion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            label11.Location = new Point(373, 93);
            label11.Name = "label11";
            label11.Size = new Size(100, 23);
            label11.TabIndex = 14;
            label11.Text = "右耳软件版本";
            label11.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelLSoftVersion
            // 
            labelLSoftVersion.BackColor = Color.White;
            labelLSoftVersion.Location = new Point(179, 93);
            labelLSoftVersion.Name = "labelLSoftVersion";
            labelLSoftVersion.Size = new Size(131, 23);
            labelLSoftVersion.TabIndex = 13;
            labelLSoftVersion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            label13.Location = new Point(36, 93);
            label13.Name = "label13";
            label13.Size = new Size(100, 23);
            label13.TabIndex = 12;
            label13.Text = "左耳软件版本";
            label13.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelRHardVersion
            // 
            labelRHardVersion.BackColor = Color.White;
            labelRHardVersion.Location = new Point(516, 53);
            labelRHardVersion.Name = "labelRHardVersion";
            labelRHardVersion.Size = new Size(131, 23);
            labelRHardVersion.TabIndex = 11;
            labelRHardVersion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.Location = new Point(373, 53);
            label6.Name = "label6";
            label6.Size = new Size(100, 23);
            label6.TabIndex = 10;
            label6.Text = "右耳硬件版本";
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelLHardVersion
            // 
            labelLHardVersion.BackColor = Color.White;
            labelLHardVersion.Location = new Point(179, 53);
            labelLHardVersion.Name = "labelLHardVersion";
            labelLHardVersion.Size = new Size(131, 23);
            labelLHardVersion.TabIndex = 9;
            labelLHardVersion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            label9.Location = new Point(36, 53);
            label9.Name = "label9";
            label9.Size = new Size(100, 23);
            label9.TabIndex = 8;
            label9.Text = "左耳硬件版本";
            label9.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelRBattery
            // 
            labelRBattery.BackColor = Color.White;
            labelRBattery.Location = new Point(516, 133);
            labelRBattery.Name = "labelRBattery";
            labelRBattery.Size = new Size(131, 23);
            labelRBattery.TabIndex = 7;
            labelRBattery.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.Location = new Point(373, 133);
            label5.Name = "label5";
            label5.Size = new Size(100, 23);
            label5.TabIndex = 6;
            label5.Text = "右耳电量";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelLBattery
            // 
            labelLBattery.BackColor = Color.White;
            labelLBattery.Location = new Point(179, 133);
            labelLBattery.Name = "labelLBattery";
            labelLBattery.Size = new Size(131, 23);
            labelLBattery.TabIndex = 5;
            labelLBattery.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.Location = new Point(36, 133);
            label7.Name = "label7";
            label7.Size = new Size(100, 23);
            label7.TabIndex = 4;
            label7.Text = "左耳电量";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelRColor
            // 
            labelRColor.BackColor = Color.White;
            labelRColor.Location = new Point(516, 13);
            labelRColor.Name = "labelRColor";
            labelRColor.Size = new Size(131, 23);
            labelRColor.TabIndex = 3;
            labelRColor.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Location = new Point(373, 13);
            label3.Name = "label3";
            label3.Size = new Size(100, 23);
            label3.TabIndex = 2;
            label3.Text = "右耳颜色";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelLColor
            // 
            labelLColor.BackColor = Color.White;
            labelLColor.Location = new Point(179, 13);
            labelLColor.Name = "labelLColor";
            labelLColor.Size = new Size(131, 23);
            labelLColor.TabIndex = 1;
            labelLColor.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.Location = new Point(36, 13);
            label4.Name = "label4";
            label4.Size = new Size(100, 23);
            label4.TabIndex = 0;
            label4.Text = "左耳颜色";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // panel3
            // 
            panel3.AutoScroll = true;
            panel3.Controls.Add(panel2);
            panel3.Location = new Point(-20, 54);
            panel3.Name = "panel3";
            panel3.Size = new Size(776, 625);
            panel3.TabIndex = 43;
            // 
            // labelRCaseSN
            // 
            labelRCaseSN.BackColor = Color.White;
            labelRCaseSN.Location = new Point(515, 293);
            labelRCaseSN.Name = "labelRCaseSN";
            labelRCaseSN.Size = new Size(131, 23);
            labelRCaseSN.TabIndex = 31;
            labelRCaseSN.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            label10.Location = new Point(372, 293);
            label10.Name = "label10";
            label10.Size = new Size(100, 23);
            label10.TabIndex = 30;
            label10.Text = "右耳盒子SN";
            label10.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(754, 679);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            Controls.Add(panel1);
            Controls.Add(panel3);
            Name = "Form1";
            Text = "TANC-HANC-读写";
            Load += FormMain_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBoxScanSN;
        private TextBox textBoxScanBle;
        private Label labelStatue;
        private Label labelScanSN;
        private Label labelScanBle;
        private Button button1;
        private Label label1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem 设置ToolStripMenuItem;
        private ToolStripMenuItem 设置ToolStripMenuItem1;
        private Panel panel1;
        private TextBox textBoxProductId;
        private Label labelProductId;
        private TextBox textBoxHardVersion;
        private Button buttonSetHardVersion;
        private Button buttonSetDeviceColor;
        private Button buttonResetMode;
        private Button buttonEnterShipMode;
        private TextBox textBoxScanCaseSN;
        private Label labelScanCaseSN;
        private Panel panel2;
        private Label labelRColor;
        private Label label3;
        private Label labelLColor;
        private Label label4;
        private Label labelRBattery;
        private Label label5;
        private Label labelLBattery;
        private Label label7;
        private Label labelRSoftVersion;
        private Label label11;
        private Label labelLSoftVersion;
        private Label label13;
        private Label labelRHardVersion;
        private Label label6;
        private Label labelLHardVersion;
        private Label label9;
        private Label labelRMFI;
        private Label label15;
        private Label labelLMFI;
        private Label label17;
        private Label labelRSN;
        private Label label19;
        private Label labelLSN;
        private Label label21;
        private Label labelRProduct;
        private Label label23;
        private Label labelLCaseSN;
        private Label label25;
        private System.Windows.Forms.Timer timer1;
        private TextBox textBoxColor;
        private Label labelLProduct;
        private Label label8;
        private Panel panel3;
        private Label labelRCaseSN;
        private Label label10;
    }
}