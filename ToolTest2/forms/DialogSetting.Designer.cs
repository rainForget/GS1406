namespace ToolTest2.forms
{
    partial class DialogSetting
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
            pictureBox1 = new PictureBox();
            checkBoxGetColor = new CheckBox();
            checkBoxSetColor = new CheckBox();
            checkBoxGetHardVersion = new CheckBox();
            checkBoxSetHardVersion = new CheckBox();
            checkBoxGetSoftVersion = new CheckBox();
            checkBoxGetBattery = new CheckBox();
            checkBoxGetMfi = new CheckBox();
            checkBoxGetSerialNum = new CheckBox();
            checkBoxSetSerialNum = new CheckBox();
            checkBoxEnterDut = new CheckBox();
            checkBoxEnterShip = new CheckBox();
            label1 = new Label();
            textBoxVersion = new TextBox();
            buttonOK = new Button();
            buttonCancle = new Button();
            label2 = new Label();
            PortList = new ComboBox();
            labelPwd = new Label();
            textBoxPwd = new TextBox();
            checkBoxGetChannel = new CheckBox();
            checkBoxResetMode = new CheckBox();
            comboBox5 = new ComboBox();
            label5 = new Label();
            comboBox4 = new ComboBox();
            label4 = new Label();
            comboBox3 = new ComboBox();
            label3 = new Label();
            comboBox2 = new ComboBox();
            label7 = new Label();
            comboBox1 = new ComboBox();
            label8 = new Label();
            pictureBox2 = new PictureBox();
            textBox1 = new TextBox();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ActiveCaption;
            pictureBox1.Location = new Point(12, 445);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(536, 210);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // checkBoxGetColor
            // 
            checkBoxGetColor.BackColor = SystemColors.ActiveCaption;
            checkBoxGetColor.Checked = true;
            checkBoxGetColor.CheckState = CheckState.Checked;
            checkBoxGetColor.Location = new Point(21, 27);
            checkBoxGetColor.Name = "checkBoxGetColor";
            checkBoxGetColor.Size = new Size(110, 30);
            checkBoxGetColor.TabIndex = 1;
            checkBoxGetColor.Text = "获取设备颜色";
            checkBoxGetColor.TextAlign = ContentAlignment.MiddleCenter;
            checkBoxGetColor.UseVisualStyleBackColor = false;
            checkBoxGetColor.CheckedChanged += checkBoxGetColor_CheckedChanged;
            // 
            // checkBoxSetColor
            // 
            checkBoxSetColor.BackColor = SystemColors.ActiveCaption;
            checkBoxSetColor.Checked = true;
            checkBoxSetColor.CheckState = CheckState.Checked;
            checkBoxSetColor.Location = new Point(143, 27);
            checkBoxSetColor.Name = "checkBoxSetColor";
            checkBoxSetColor.Size = new Size(110, 30);
            checkBoxSetColor.TabIndex = 2;
            checkBoxSetColor.Text = "设置设备颜色";
            checkBoxSetColor.TextAlign = ContentAlignment.MiddleCenter;
            checkBoxSetColor.UseVisualStyleBackColor = false;
            checkBoxSetColor.CheckedChanged += checkBoxSetColor_CheckedChanged;
            // 
            // checkBoxGetHardVersion
            // 
            checkBoxGetHardVersion.BackColor = SystemColors.ActiveCaption;
            checkBoxGetHardVersion.Checked = true;
            checkBoxGetHardVersion.CheckState = CheckState.Checked;
            checkBoxGetHardVersion.Location = new Point(21, 75);
            checkBoxGetHardVersion.Name = "checkBoxGetHardVersion";
            checkBoxGetHardVersion.Size = new Size(110, 30);
            checkBoxGetHardVersion.TabIndex = 5;
            checkBoxGetHardVersion.Text = "获取硬件版本";
            checkBoxGetHardVersion.TextAlign = ContentAlignment.MiddleCenter;
            checkBoxGetHardVersion.UseVisualStyleBackColor = false;
            checkBoxGetHardVersion.CheckedChanged += checkBoxGetHardVersion_CheckedChanged;
            // 
            // checkBoxSetHardVersion
            // 
            checkBoxSetHardVersion.BackColor = SystemColors.ActiveCaption;
            checkBoxSetHardVersion.Checked = true;
            checkBoxSetHardVersion.CheckState = CheckState.Checked;
            checkBoxSetHardVersion.Location = new Point(143, 75);
            checkBoxSetHardVersion.Name = "checkBoxSetHardVersion";
            checkBoxSetHardVersion.Size = new Size(110, 30);
            checkBoxSetHardVersion.TabIndex = 6;
            checkBoxSetHardVersion.Text = "设置硬件版本";
            checkBoxSetHardVersion.TextAlign = ContentAlignment.MiddleCenter;
            checkBoxSetHardVersion.UseVisualStyleBackColor = false;
            checkBoxSetHardVersion.CheckedChanged += checkBoxSetHardVersion_CheckedChanged;
            // 
            // checkBoxGetSoftVersion
            // 
            checkBoxGetSoftVersion.BackColor = SystemColors.ActiveCaption;
            checkBoxGetSoftVersion.Checked = true;
            checkBoxGetSoftVersion.CheckState = CheckState.Checked;
            checkBoxGetSoftVersion.Location = new Point(21, 122);
            checkBoxGetSoftVersion.Name = "checkBoxGetSoftVersion";
            checkBoxGetSoftVersion.Size = new Size(110, 30);
            checkBoxGetSoftVersion.TabIndex = 9;
            checkBoxGetSoftVersion.Text = "获取软件版本";
            checkBoxGetSoftVersion.TextAlign = ContentAlignment.MiddleCenter;
            checkBoxGetSoftVersion.UseVisualStyleBackColor = false;
            checkBoxGetSoftVersion.CheckedChanged += checkBoxGetSoftVersion_CheckedChanged;
            // 
            // checkBoxGetBattery
            // 
            checkBoxGetBattery.BackColor = SystemColors.ActiveCaption;
            checkBoxGetBattery.Checked = true;
            checkBoxGetBattery.CheckState = CheckState.Checked;
            checkBoxGetBattery.Location = new Point(143, 122);
            checkBoxGetBattery.Name = "checkBoxGetBattery";
            checkBoxGetBattery.Size = new Size(110, 30);
            checkBoxGetBattery.TabIndex = 10;
            checkBoxGetBattery.Text = "获取耳机电量";
            checkBoxGetBattery.TextAlign = ContentAlignment.MiddleCenter;
            checkBoxGetBattery.UseVisualStyleBackColor = false;
            checkBoxGetBattery.CheckedChanged += checkBoxGetBattery_CheckedChanged;
            // 
            // checkBoxGetMfi
            // 
            checkBoxGetMfi.BackColor = SystemColors.ActiveCaption;
            checkBoxGetMfi.Checked = true;
            checkBoxGetMfi.CheckState = CheckState.Checked;
            checkBoxGetMfi.Location = new Point(273, 75);
            checkBoxGetMfi.Name = "checkBoxGetMfi";
            checkBoxGetMfi.Size = new Size(110, 30);
            checkBoxGetMfi.TabIndex = 7;
            checkBoxGetMfi.Text = "获取MFI状态";
            checkBoxGetMfi.TextAlign = ContentAlignment.MiddleCenter;
            checkBoxGetMfi.UseVisualStyleBackColor = false;
            checkBoxGetMfi.CheckedChanged += checkBoxGetMfi_CheckedChanged;
            // 
            // checkBoxGetSerialNum
            // 
            checkBoxGetSerialNum.BackColor = SystemColors.ActiveCaption;
            checkBoxGetSerialNum.Checked = true;
            checkBoxGetSerialNum.CheckState = CheckState.Checked;
            checkBoxGetSerialNum.Location = new Point(273, 27);
            checkBoxGetSerialNum.Name = "checkBoxGetSerialNum";
            checkBoxGetSerialNum.Size = new Size(110, 30);
            checkBoxGetSerialNum.TabIndex = 3;
            checkBoxGetSerialNum.Text = "获取序列号";
            checkBoxGetSerialNum.TextAlign = ContentAlignment.MiddleCenter;
            checkBoxGetSerialNum.UseVisualStyleBackColor = false;
            checkBoxGetSerialNum.CheckedChanged += checkBoxGetSerialNum_CheckedChanged;
            // 
            // checkBoxSetSerialNum
            // 
            checkBoxSetSerialNum.BackColor = SystemColors.ActiveCaption;
            checkBoxSetSerialNum.Checked = true;
            checkBoxSetSerialNum.CheckState = CheckState.Checked;
            checkBoxSetSerialNum.Location = new Point(404, 27);
            checkBoxSetSerialNum.Name = "checkBoxSetSerialNum";
            checkBoxSetSerialNum.Size = new Size(110, 30);
            checkBoxSetSerialNum.TabIndex = 4;
            checkBoxSetSerialNum.Text = "设置序列号";
            checkBoxSetSerialNum.TextAlign = ContentAlignment.MiddleCenter;
            checkBoxSetSerialNum.UseVisualStyleBackColor = false;
            checkBoxSetSerialNum.CheckedChanged += checkBoxSetSerialNum_CheckedChanged;
            // 
            // checkBoxEnterDut
            // 
            checkBoxEnterDut.BackColor = SystemColors.ActiveCaption;
            checkBoxEnterDut.Checked = true;
            checkBoxEnterDut.CheckState = CheckState.Checked;
            checkBoxEnterDut.Location = new Point(21, 158);
            checkBoxEnterDut.Name = "checkBoxEnterDut";
            checkBoxEnterDut.Size = new Size(110, 30);
            checkBoxEnterDut.TabIndex = 11;
            checkBoxEnterDut.Text = "DUT模式";
            checkBoxEnterDut.TextAlign = ContentAlignment.MiddleCenter;
            checkBoxEnterDut.UseVisualStyleBackColor = false;
            checkBoxEnterDut.CheckedChanged += checkBoxEnterDut_CheckedChanged;
            // 
            // checkBoxEnterShip
            // 
            checkBoxEnterShip.BackColor = SystemColors.ActiveCaption;
            checkBoxEnterShip.Checked = true;
            checkBoxEnterShip.CheckState = CheckState.Checked;
            checkBoxEnterShip.Location = new Point(143, 158);
            checkBoxEnterShip.Name = "checkBoxEnterShip";
            checkBoxEnterShip.Size = new Size(110, 30);
            checkBoxEnterShip.TabIndex = 12;
            checkBoxEnterShip.Text = "SHIP模式";
            checkBoxEnterShip.TextAlign = ContentAlignment.MiddleCenter;
            checkBoxEnterShip.UseVisualStyleBackColor = false;
            checkBoxEnterShip.CheckedChanged += checkBoxEnterShip_CheckedChanged;
            // 
            // label1
            // 
            label1.BackColor = SystemColors.ActiveCaption;
            label1.Location = new Point(21, 195);
            label1.Name = "label1";
            label1.Size = new Size(110, 30);
            label1.TabIndex = 14;
            label1.Text = "软件版本";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxVersion
            // 
            textBoxVersion.Location = new Point(143, 199);
            textBoxVersion.Name = "textBoxVersion";
            textBoxVersion.Size = new Size(110, 23);
            textBoxVersion.TabIndex = 15;
            textBoxVersion.Text = "0.3.5";
            textBoxVersion.Leave += textBoxVersion_Leave;
            // 
            // buttonOK
            // 
            buttonOK.Location = new Point(80, 535);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(128, 44);
            buttonOK.TabIndex = 80;
            buttonOK.Text = "确认";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // buttonCancle
            // 
            buttonCancle.Location = new Point(311, 535);
            buttonCancle.Name = "buttonCancle";
            buttonCancle.Size = new Size(128, 44);
            buttonCancle.TabIndex = 81;
            buttonCancle.Text = "取消";
            buttonCancle.UseVisualStyleBackColor = true;
            buttonCancle.Click += buttonCancle_Click;
            // 
            // label2
            // 
            label2.BackColor = SystemColors.ActiveCaption;
            label2.Location = new Point(273, 199);
            label2.Name = "label2";
            label2.Size = new Size(110, 30);
            label2.TabIndex = 16;
            label2.Text = "串口号";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PortList
            // 
            PortList.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            PortList.FormattingEnabled = true;
            PortList.ItemHeight = 17;
            PortList.Location = new Point(404, 199);
            PortList.Name = "PortList";
            PortList.Size = new Size(107, 25);
            PortList.TabIndex = 17;
            PortList.SelectedIndexChanged += PortList_SelectedIndexChanged;
            // 
            // labelPwd
            // 
            labelPwd.BackColor = SystemColors.ActiveCaption;
            labelPwd.Location = new Point(21, 240);
            labelPwd.Name = "labelPwd";
            labelPwd.Size = new Size(110, 30);
            labelPwd.TabIndex = 18;
            labelPwd.Text = "密码";
            labelPwd.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxPwd
            // 
            textBoxPwd.Location = new Point(144, 243);
            textBoxPwd.Name = "textBoxPwd";
            textBoxPwd.Size = new Size(109, 23);
            textBoxPwd.TabIndex = 19;
            textBoxPwd.Text = "1.0";
            textBoxPwd.TextChanged += textBoxPwd_TextChanged;
            // 
            // checkBoxGetChannel
            // 
            checkBoxGetChannel.BackColor = SystemColors.ActiveCaption;
            checkBoxGetChannel.Checked = true;
            checkBoxGetChannel.CheckState = CheckState.Checked;
            checkBoxGetChannel.Location = new Point(404, 75);
            checkBoxGetChannel.Name = "checkBoxGetChannel";
            checkBoxGetChannel.Size = new Size(110, 30);
            checkBoxGetChannel.TabIndex = 8;
            checkBoxGetChannel.Text = "获取通道";
            checkBoxGetChannel.TextAlign = ContentAlignment.MiddleCenter;
            checkBoxGetChannel.UseVisualStyleBackColor = false;
            checkBoxGetChannel.CheckedChanged += checkBoxGetChannel_CheckedChanged;
            // 
            // checkBoxResetMode
            // 
            checkBoxResetMode.BackColor = SystemColors.ActiveCaption;
            checkBoxResetMode.Checked = true;
            checkBoxResetMode.CheckState = CheckState.Checked;
            checkBoxResetMode.Location = new Point(273, 158);
            checkBoxResetMode.Name = "checkBoxResetMode";
            checkBoxResetMode.Size = new Size(110, 30);
            checkBoxResetMode.TabIndex = 13;
            checkBoxResetMode.Text = "重置模式";
            checkBoxResetMode.TextAlign = ContentAlignment.MiddleCenter;
            checkBoxResetMode.UseVisualStyleBackColor = false;
            checkBoxResetMode.CheckedChanged += checkBoxResetMode_CheckedChanged;
            // 
            // comboBox5
            // 
            comboBox5.FormattingEnabled = true;
            comboBox5.Items.AddRange(new object[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" });
            comboBox5.Location = new Point(106, 374);
            comboBox5.Name = "comboBox5";
            comboBox5.Size = new Size(98, 25);
            comboBox5.TabIndex = 59;
            comboBox5.Visible = false;
            comboBox5.SelectedIndexChanged += comboBox5_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.Location = new Point(26, 374);
            label5.Name = "label5";
            label5.Size = new Size(60, 23);
            label5.TabIndex = 58;
            label5.Text = "Color";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            label5.Visible = false;
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Items.AddRange(new object[] { "SC", "PC" });
            comboBox4.Location = new Point(369, 336);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(98, 25);
            comboBox4.TabIndex = 57;
            comboBox4.Visible = false;
            comboBox4.SelectedIndexChanged += comboBox4_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.Location = new Point(289, 336);
            label4.Name = "label4";
            label4.Size = new Size(60, 23);
            label4.TabIndex = 56;
            label4.Text = "Family";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            label4.Visible = false;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52" });
            comboBox3.Location = new Point(106, 336);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(98, 25);
            comboBox3.TabIndex = 55;
            comboBox3.Visible = false;
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.Location = new Point(26, 336);
            label3.Name = "label3";
            label3.Size = new Size(60, 23);
            label3.TabIndex = 54;
            label3.Text = "Week";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            label3.Visible = false;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "22", "23", "24", "25", "26", "27", "28" });
            comboBox2.Location = new Point(369, 292);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(98, 25);
            comboBox2.TabIndex = 53;
            comboBox2.Visible = false;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.Location = new Point(289, 292);
            label7.Name = "label7";
            label7.Size = new Size(60, 23);
            label7.TabIndex = 52;
            label7.Text = "Yaer";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            label7.Visible = false;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "GS", "GP" });
            comboBox1.Location = new Point(106, 292);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(98, 25);
            comboBox1.TabIndex = 51;
            comboBox1.Visible = false;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.Location = new Point(26, 292);
            label8.Name = "label8";
            label8.Size = new Size(60, 23);
            label8.TabIndex = 50;
            label8.Text = "Vendor";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            label8.Visible = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = SystemColors.ActiveCaption;
            pictureBox2.Location = new Point(12, 272);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(536, 176);
            pictureBox2.TabIndex = 32;
            pictureBox2.TabStop = false;
            pictureBox2.Visible = false;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(405, 243);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(109, 23);
            textBox1.TabIndex = 83;
            textBox1.Text = "80";
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label6
            // 
            label6.BackColor = SystemColors.ActiveCaption;
            label6.Location = new Point(273, 240);
            label6.Name = "label6";
            label6.Size = new Size(110, 30);
            label6.TabIndex = 82;
            label6.Text = "电量设置";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DialogSetting
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 667);
            Controls.Add(textBox1);
            Controls.Add(label6);
            Controls.Add(comboBox5);
            Controls.Add(label5);
            Controls.Add(comboBox4);
            Controls.Add(label4);
            Controls.Add(comboBox3);
            Controls.Add(label3);
            Controls.Add(comboBox2);
            Controls.Add(label7);
            Controls.Add(comboBox1);
            Controls.Add(label8);
            Controls.Add(checkBoxResetMode);
            Controls.Add(checkBoxGetChannel);
            Controls.Add(textBoxPwd);
            Controls.Add(labelPwd);
            Controls.Add(PortList);
            Controls.Add(label2);
            Controls.Add(buttonCancle);
            Controls.Add(buttonOK);
            Controls.Add(textBoxVersion);
            Controls.Add(label1);
            Controls.Add(checkBoxEnterShip);
            Controls.Add(checkBoxEnterDut);
            Controls.Add(checkBoxSetSerialNum);
            Controls.Add(checkBoxGetSerialNum);
            Controls.Add(checkBoxGetMfi);
            Controls.Add(checkBoxGetBattery);
            Controls.Add(checkBoxGetSoftVersion);
            Controls.Add(checkBoxSetHardVersion);
            Controls.Add(checkBoxGetHardVersion);
            Controls.Add(checkBoxSetColor);
            Controls.Add(checkBoxGetColor);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox2);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "DialogSetting";
            StartPosition = FormStartPosition.CenterParent;
            Text = "DialogSetting";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private CheckBox checkBoxGetColor;
        private CheckBox checkBoxSetColor;
        private CheckBox checkBoxGetHardVersion;
        private CheckBox checkBoxSetHardVersion;
        private CheckBox checkBoxGetSoftVersion;
        private CheckBox checkBoxGetBattery;
        private CheckBox checkBoxGetMfi;
        private CheckBox checkBoxGetSerialNum;
        private CheckBox checkBoxSetSerialNum;
        private CheckBox checkBoxEnterDut;
        private CheckBox checkBoxEnterShip;
        private Label label1;
        private TextBox textBoxVersion;
        private Button buttonOK;
        private Button buttonCancle;
        private Label label2;
        private ComboBox PortList;
        private Label labelPwd;
        private TextBox textBoxPwd;
        private CheckBox checkBoxGetChannel;
        private CheckBox checkBoxResetMode;
        private ComboBox comboBox5;
        private Label label5;
        private ComboBox comboBox4;
        private Label label4;
        private ComboBox comboBox3;
        private Label label3;
        private ComboBox comboBox2;
        private Label label7;
        private ComboBox comboBox1;
        private Label label8;
        private PictureBox pictureBox2;
        private TextBox textBox1;
        private Label label6;
    }
}