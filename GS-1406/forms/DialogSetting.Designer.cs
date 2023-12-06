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
            checkBoxResetMode = new CheckBox();
            textBox1 = new TextBox();
            label6 = new Label();
            checkBoxSetCaseSN = new CheckBox();
            checkBoxGetCaseSN = new CheckBox();
            checkBoxSetProductId = new CheckBox();
            checkBoxGetProductId = new CheckBox();
            textBox2 = new TextBox();
            label3 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            textBoxHardVersion = new TextBox();
            comboBoxColor = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // checkBoxGetColor
            // 
            checkBoxGetColor.BackColor = SystemColors.ActiveCaption;
            checkBoxGetColor.Checked = true;
            checkBoxGetColor.CheckState = CheckState.Checked;
            checkBoxGetColor.Location = new Point(42, 23);
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
            checkBoxSetColor.Location = new Point(41, 28);
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
            checkBoxGetHardVersion.Location = new Point(196, 23);
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
            checkBoxSetHardVersion.Location = new Point(195, 28);
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
            checkBoxGetSoftVersion.Location = new Point(350, 23);
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
            checkBoxGetBattery.Location = new Point(42, 125);
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
            checkBoxGetMfi.Location = new Point(196, 125);
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
            checkBoxGetSerialNum.Location = new Point(42, 74);
            checkBoxGetSerialNum.Name = "checkBoxGetSerialNum";
            checkBoxGetSerialNum.Size = new Size(110, 30);
            checkBoxGetSerialNum.TabIndex = 3;
            checkBoxGetSerialNum.Text = "获取SN";
            checkBoxGetSerialNum.TextAlign = ContentAlignment.MiddleCenter;
            checkBoxGetSerialNum.UseVisualStyleBackColor = false;
            checkBoxGetSerialNum.CheckedChanged += checkBoxGetSerialNum_CheckedChanged;
            // 
            // checkBoxSetSerialNum
            // 
            checkBoxSetSerialNum.BackColor = SystemColors.ActiveCaption;
            checkBoxSetSerialNum.Checked = true;
            checkBoxSetSerialNum.CheckState = CheckState.Checked;
            checkBoxSetSerialNum.Location = new Point(41, 81);
            checkBoxSetSerialNum.Name = "checkBoxSetSerialNum";
            checkBoxSetSerialNum.Size = new Size(110, 30);
            checkBoxSetSerialNum.TabIndex = 4;
            checkBoxSetSerialNum.Text = "设置SN";
            checkBoxSetSerialNum.TextAlign = ContentAlignment.MiddleCenter;
            checkBoxSetSerialNum.UseVisualStyleBackColor = false;
            checkBoxSetSerialNum.CheckedChanged += checkBoxSetSerialNum_CheckedChanged;
            // 
            // checkBoxEnterDut
            // 
            checkBoxEnterDut.BackColor = SystemColors.ActiveCaption;
            checkBoxEnterDut.Checked = true;
            checkBoxEnterDut.CheckState = CheckState.Checked;
            checkBoxEnterDut.Location = new Point(41, 135);
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
            checkBoxEnterShip.Location = new Point(195, 135);
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
            label1.Location = new Point(13, 436);
            label1.Name = "label1";
            label1.Size = new Size(110, 30);
            label1.TabIndex = 14;
            label1.Text = "软件版本";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxVersion
            // 
            textBoxVersion.Location = new Point(135, 440);
            textBoxVersion.Name = "textBoxVersion";
            textBoxVersion.Size = new Size(110, 23);
            textBoxVersion.TabIndex = 15;
            textBoxVersion.Text = "0.3.5";
            textBoxVersion.Leave += textBoxVersion_Leave;
            // 
            // buttonOK
            // 
            buttonOK.Location = new Point(53, 624);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(128, 44);
            buttonOK.TabIndex = 80;
            buttonOK.Text = "确认";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // buttonCancle
            // 
            buttonCancle.Location = new Point(282, 624);
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
            label2.Location = new Point(265, 440);
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
            PortList.Location = new Point(396, 440);
            PortList.Name = "PortList";
            PortList.Size = new Size(107, 25);
            PortList.TabIndex = 17;
            PortList.SelectedIndexChanged += PortList_SelectedIndexChanged;
            // 
            // labelPwd
            // 
            labelPwd.BackColor = SystemColors.ActiveCaption;
            labelPwd.Location = new Point(1, 142);
            labelPwd.Name = "labelPwd";
            labelPwd.Size = new Size(110, 30);
            labelPwd.TabIndex = 18;
            labelPwd.Text = "密码";
            labelPwd.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxPwd
            // 
            textBoxPwd.Location = new Point(124, 145);
            textBoxPwd.Name = "textBoxPwd";
            textBoxPwd.Size = new Size(109, 23);
            textBoxPwd.TabIndex = 19;
            textBoxPwd.Text = "1.0";
            textBoxPwd.TextChanged += textBoxPwd_TextChanged;
            // 
            // checkBoxResetMode
            // 
            checkBoxResetMode.BackColor = SystemColors.ActiveCaption;
            checkBoxResetMode.Checked = true;
            checkBoxResetMode.CheckState = CheckState.Checked;
            checkBoxResetMode.Location = new Point(349, 135);
            checkBoxResetMode.Name = "checkBoxResetMode";
            checkBoxResetMode.Size = new Size(110, 30);
            checkBoxResetMode.TabIndex = 13;
            checkBoxResetMode.Text = "重置模式";
            checkBoxResetMode.TextAlign = ContentAlignment.MiddleCenter;
            checkBoxResetMode.UseVisualStyleBackColor = false;
            checkBoxResetMode.CheckedChanged += checkBoxResetMode_CheckedChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(397, 484);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(109, 23);
            textBox1.TabIndex = 83;
            textBox1.Text = "80";
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label6
            // 
            label6.BackColor = SystemColors.ActiveCaption;
            label6.Location = new Point(265, 481);
            label6.Name = "label6";
            label6.Size = new Size(110, 30);
            label6.TabIndex = 82;
            label6.Text = "电量设置";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // checkBoxSetCaseSN
            // 
            checkBoxSetCaseSN.BackColor = SystemColors.ActiveCaption;
            checkBoxSetCaseSN.Checked = true;
            checkBoxSetCaseSN.CheckState = CheckState.Checked;
            checkBoxSetCaseSN.Location = new Point(195, 81);
            checkBoxSetCaseSN.Name = "checkBoxSetCaseSN";
            checkBoxSetCaseSN.Size = new Size(110, 30);
            checkBoxSetCaseSN.TabIndex = 86;
            checkBoxSetCaseSN.Text = "设置盒子SN";
            checkBoxSetCaseSN.TextAlign = ContentAlignment.MiddleCenter;
            checkBoxSetCaseSN.UseVisualStyleBackColor = false;
            checkBoxSetCaseSN.CheckedChanged += checkBoxSetCaseSN_CheckedChanged;
            // 
            // checkBoxGetCaseSN
            // 
            checkBoxGetCaseSN.BackColor = SystemColors.ActiveCaption;
            checkBoxGetCaseSN.Checked = true;
            checkBoxGetCaseSN.CheckState = CheckState.Checked;
            checkBoxGetCaseSN.Location = new Point(196, 74);
            checkBoxGetCaseSN.Name = "checkBoxGetCaseSN";
            checkBoxGetCaseSN.Size = new Size(110, 30);
            checkBoxGetCaseSN.TabIndex = 85;
            checkBoxGetCaseSN.Text = "获取盒子SN";
            checkBoxGetCaseSN.TextAlign = ContentAlignment.MiddleCenter;
            checkBoxGetCaseSN.UseVisualStyleBackColor = false;
            checkBoxGetCaseSN.CheckedChanged += checkBoxGetCaseSN_CheckedChanged;
            // 
            // checkBoxSetProductId
            // 
            checkBoxSetProductId.BackColor = SystemColors.ActiveCaption;
            checkBoxSetProductId.Checked = true;
            checkBoxSetProductId.CheckState = CheckState.Checked;
            checkBoxSetProductId.Location = new Point(349, 81);
            checkBoxSetProductId.Name = "checkBoxSetProductId";
            checkBoxSetProductId.Size = new Size(110, 30);
            checkBoxSetProductId.TabIndex = 88;
            checkBoxSetProductId.Text = "设置产品型号";
            checkBoxSetProductId.TextAlign = ContentAlignment.MiddleCenter;
            checkBoxSetProductId.UseVisualStyleBackColor = false;
            checkBoxSetProductId.CheckedChanged += checkBoxSetProductId_CheckedChanged;
            // 
            // checkBoxGetProductId
            // 
            checkBoxGetProductId.BackColor = SystemColors.ActiveCaption;
            checkBoxGetProductId.Checked = true;
            checkBoxGetProductId.CheckState = CheckState.Checked;
            checkBoxGetProductId.Location = new Point(350, 74);
            checkBoxGetProductId.Name = "checkBoxGetProductId";
            checkBoxGetProductId.Size = new Size(110, 30);
            checkBoxGetProductId.TabIndex = 87;
            checkBoxGetProductId.Text = "获取产品型号";
            checkBoxGetProductId.TextAlign = ContentAlignment.MiddleCenter;
            checkBoxGetProductId.UseVisualStyleBackColor = false;
            checkBoxGetProductId.CheckedChanged += checkBoxGetProductId_CheckedChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(136, 480);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(109, 23);
            textBox2.TabIndex = 90;
            textBox2.Text = "1.0";
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label3
            // 
            label3.BackColor = SystemColors.ActiveCaption;
            label3.Location = new Point(13, 477);
            label3.Name = "label3";
            label3.Size = new Size(110, 30);
            label3.TabIndex = 89;
            label3.Text = "产品型号";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(checkBoxSetCaseSN);
            panel1.Controls.Add(checkBoxSetColor);
            panel1.Controls.Add(checkBoxSetProductId);
            panel1.Controls.Add(checkBoxSetHardVersion);
            panel1.Controls.Add(checkBoxSetSerialNum);
            panel1.Controls.Add(checkBoxEnterDut);
            panel1.Controls.Add(checkBoxEnterShip);
            panel1.Controls.Add(checkBoxResetMode);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(517, 198);
            panel1.TabIndex = 91;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveCaption;
            panel2.Controls.Add(checkBoxGetCaseSN);
            panel2.Controls.Add(checkBoxGetColor);
            panel2.Controls.Add(checkBoxGetHardVersion);
            panel2.Controls.Add(checkBoxGetProductId);
            panel2.Controls.Add(checkBoxGetSoftVersion);
            panel2.Controls.Add(checkBoxGetBattery);
            panel2.Controls.Add(checkBoxGetMfi);
            panel2.Controls.Add(checkBoxGetSerialNum);
            panel2.Location = new Point(11, 224);
            panel2.Name = "panel2";
            panel2.Size = new Size(518, 180);
            panel2.TabIndex = 92;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ActiveCaption;
            panel3.Controls.Add(textBoxHardVersion);
            panel3.Controls.Add(comboBoxColor);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(textBoxPwd);
            panel3.Controls.Add(labelPwd);
            panel3.Location = new Point(12, 409);
            panel3.Name = "panel3";
            panel3.Size = new Size(517, 199);
            panel3.TabIndex = 93;
            // 
            // textBoxHardVersion
            // 
            textBoxHardVersion.Location = new Point(123, 110);
            textBoxHardVersion.Name = "textBoxHardVersion";
            textBoxHardVersion.Size = new Size(110, 23);
            textBoxHardVersion.TabIndex = 23;
            textBoxHardVersion.Text = "0.2";
            textBoxHardVersion.TextChanged += textBoxHardVersion_TextChanged;
            // 
            // comboBoxColor
            // 
            comboBoxColor.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxColor.FormattingEnabled = true;
            comboBoxColor.ItemHeight = 17;
            comboBoxColor.Items.AddRange(new object[] { "black", "white" });
            comboBoxColor.Location = new Point(384, 114);
            comboBoxColor.Name = "comboBoxColor";
            comboBoxColor.Size = new Size(107, 25);
            comboBoxColor.TabIndex = 22;
            comboBoxColor.SelectedIndexChanged += comboBoxColor_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.BackColor = SystemColors.ActiveCaption;
            label4.Location = new Point(253, 114);
            label4.Name = "label4";
            label4.Size = new Size(110, 30);
            label4.TabIndex = 21;
            label4.Text = "颜色";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.BackColor = SystemColors.ActiveCaption;
            label5.Location = new Point(1, 110);
            label5.Name = "label5";
            label5.Size = new Size(110, 30);
            label5.TabIndex = 20;
            label5.Text = "硬件版本";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DialogSetting
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(551, 695);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(label6);
            Controls.Add(PortList);
            Controls.Add(label2);
            Controls.Add(buttonCancle);
            Controls.Add(buttonOK);
            Controls.Add(textBoxVersion);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(panel3);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "DialogSetting";
            StartPosition = FormStartPosition.CenterParent;
            Text = "DialogSetting";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
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
        private CheckBox checkBoxResetMode;
        private TextBox textBox1;
        private Label label6;
        private CheckBox checkBoxSetCaseSN;
        private CheckBox checkBoxGetCaseSN;
        private CheckBox checkBoxSetProductId;
        private CheckBox checkBoxGetProductId;
        private TextBox textBox2;
        private Label label3;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private ComboBox comboBoxColor;
        private Label label4;
        private Label label5;
        private TextBox textBoxHardVersion;
    }
}