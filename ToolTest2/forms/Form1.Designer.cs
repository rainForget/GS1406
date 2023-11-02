namespace ToolTest2
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
            timer1 = new System.Windows.Forms.Timer(components);
            textBox1 = new TextBox();
            textBoxStatus = new TextBox();
            textBoxList = new TextBox();
            menuStrip1 = new MenuStrip();
            菜单ToolStripMenuItem = new ToolStripMenuItem();
            设置ToolStripMenuItem = new ToolStripMenuItem();
            buttonGetBatteryLevel = new Button();
            labelBattertLevel = new Label();
            buttonEnterDutMode = new Button();
            buttonEnterShipMode = new Button();
            textSerialNumber = new TextBox();
            buttonSetSerialNumber = new Button();
            buttonGetSerialNumber = new Button();
            labelSerialNumber = new Label();
            buttonGetMFIStatus = new Button();
            labelMfi = new Label();
            buttonGetSoftVersion = new Button();
            labelSoftVersion = new Label();
            textBoxHardVersion = new TextBox();
            buttonSetHardVersion = new Button();
            buttonGetHardVersion = new Button();
            labelHardVersion = new Label();
            comboBox1 = new ComboBox();
            buttonSetDeviceColor = new Button();
            buttonGetColor = new Button();
            labelColor = new Label();
            buttonDis = new Button();
            pictureBox1 = new PictureBox();
            textBoxMessage = new TextBox();
            buttonGetChannel = new Button();
            labelChanel = new Label();
            buttonResetMode = new Button();
            button1 = new Button();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 200;
            timer1.Tick += timer1_Tick;
            // 
            // textBox1
            // 
            textBox1.CharacterCasing = CharacterCasing.Upper;
            textBox1.Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(138, 28);
            textBox1.MaxLength = 12;
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(221, 35);
            textBox1.TabIndex = 2;
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBoxStatus
            // 
            textBoxStatus.BorderStyle = BorderStyle.None;
            textBoxStatus.Font = new Font("Microsoft YaHei UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxStatus.Location = new Point(12, 448);
            textBoxStatus.Name = "textBoxStatus";
            textBoxStatus.ReadOnly = true;
            textBoxStatus.Size = new Size(632, 45);
            textBoxStatus.TabIndex = 29;
            // 
            // textBoxList
            // 
            textBoxList.Cursor = Cursors.IBeam;
            textBoxList.Location = new Point(11, 385);
            textBoxList.Multiline = true;
            textBoxList.Name = "textBoxList";
            textBoxList.ReadOnly = true;
            textBoxList.ScrollBars = ScrollBars.Vertical;
            textBoxList.Size = new Size(633, 10);
            textBoxList.TabIndex = 27;
            textBoxList.Visible = false;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { 菜单ToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(653, 25);
            menuStrip1.TabIndex = 12;
            menuStrip1.Text = "menuStrip1";
            // 
            // 菜单ToolStripMenuItem
            // 
            菜单ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 设置ToolStripMenuItem });
            菜单ToolStripMenuItem.Name = "菜单ToolStripMenuItem";
            菜单ToolStripMenuItem.Size = new Size(44, 21);
            菜单ToolStripMenuItem.Text = "菜单";
            // 
            // 设置ToolStripMenuItem
            // 
            设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            设置ToolStripMenuItem.Size = new Size(100, 22);
            设置ToolStripMenuItem.Text = "设置";
            设置ToolStripMenuItem.Click += SettingToolStripMenuItem_Click;
            // 
            // buttonGetBatteryLevel
            // 
            buttonGetBatteryLevel.Location = new Point(380, 182);
            buttonGetBatteryLevel.Name = "buttonGetBatteryLevel";
            buttonGetBatteryLevel.Size = new Size(121, 35);
            buttonGetBatteryLevel.TabIndex = 14;
            buttonGetBatteryLevel.Text = "获取耳机电量";
            buttonGetBatteryLevel.UseVisualStyleBackColor = true;
            buttonGetBatteryLevel.Click += buttonGetBatteryLevel_Click;
            // 
            // labelBattertLevel
            // 
            labelBattertLevel.BackColor = SystemColors.ControlLightLight;
            labelBattertLevel.Location = new Point(523, 182);
            labelBattertLevel.Name = "labelBattertLevel";
            labelBattertLevel.Size = new Size(121, 35);
            labelBattertLevel.TabIndex = 15;
            labelBattertLevel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // buttonEnterDutMode
            // 
            buttonEnterDutMode.Location = new Point(11, 329);
            buttonEnterDutMode.Name = "buttonEnterDutMode";
            buttonEnterDutMode.Size = new Size(121, 35);
            buttonEnterDutMode.TabIndex = 24;
            buttonEnterDutMode.Text = "进入DUT模式";
            buttonEnterDutMode.UseVisualStyleBackColor = true;
            buttonEnterDutMode.Click += buttonEnterDutMode_Click;
            // 
            // buttonEnterShipMode
            // 
            buttonEnterShipMode.Location = new Point(164, 329);
            buttonEnterShipMode.Name = "buttonEnterShipMode";
            buttonEnterShipMode.Size = new Size(121, 35);
            buttonEnterShipMode.TabIndex = 25;
            buttonEnterShipMode.Text = "进入SHIP模式";
            buttonEnterShipMode.UseVisualStyleBackColor = true;
            buttonEnterShipMode.Click += buttonEnterShipMode_Click;
            // 
            // textSerialNumber
            // 
            textSerialNumber.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textSerialNumber.Location = new Point(523, 283);
            textSerialNumber.Name = "textSerialNumber";
            textSerialNumber.Size = new Size(121, 28);
            textSerialNumber.TabIndex = 23;
            // 
            // buttonSetSerialNumber
            // 
            buttonSetSerialNumber.Location = new Point(380, 279);
            buttonSetSerialNumber.Name = "buttonSetSerialNumber";
            buttonSetSerialNumber.Size = new Size(121, 35);
            buttonSetSerialNumber.TabIndex = 22;
            buttonSetSerialNumber.Text = "设置序列号";
            buttonSetSerialNumber.UseVisualStyleBackColor = true;
            buttonSetSerialNumber.Click += buttonSetSerialNumber_Click;
            // 
            // buttonGetSerialNumber
            // 
            buttonGetSerialNumber.Location = new Point(11, 279);
            buttonGetSerialNumber.Name = "buttonGetSerialNumber";
            buttonGetSerialNumber.Size = new Size(121, 35);
            buttonGetSerialNumber.TabIndex = 20;
            buttonGetSerialNumber.Text = "获取序列号";
            buttonGetSerialNumber.UseVisualStyleBackColor = true;
            buttonGetSerialNumber.Click += buttonGetSerialNumber_Click;
            // 
            // labelSerialNumber
            // 
            labelSerialNumber.BackColor = SystemColors.ControlLightLight;
            labelSerialNumber.Location = new Point(164, 279);
            labelSerialNumber.Name = "labelSerialNumber";
            labelSerialNumber.Size = new Size(121, 35);
            labelSerialNumber.TabIndex = 21;
            labelSerialNumber.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // buttonGetMFIStatus
            // 
            buttonGetMFIStatus.Location = new Point(11, 231);
            buttonGetMFIStatus.Name = "buttonGetMFIStatus";
            buttonGetMFIStatus.Size = new Size(121, 35);
            buttonGetMFIStatus.TabIndex = 16;
            buttonGetMFIStatus.Text = "获取MFI状态";
            buttonGetMFIStatus.UseVisualStyleBackColor = true;
            buttonGetMFIStatus.Click += buttonGetMFIStatus_Click;
            // 
            // labelMfi
            // 
            labelMfi.BackColor = SystemColors.ControlLightLight;
            labelMfi.Location = new Point(164, 231);
            labelMfi.Name = "labelMfi";
            labelMfi.Size = new Size(121, 35);
            labelMfi.TabIndex = 17;
            labelMfi.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // buttonGetSoftVersion
            // 
            buttonGetSoftVersion.Location = new Point(11, 182);
            buttonGetSoftVersion.Name = "buttonGetSoftVersion";
            buttonGetSoftVersion.Size = new Size(121, 35);
            buttonGetSoftVersion.TabIndex = 12;
            buttonGetSoftVersion.Text = "获取软件版本";
            buttonGetSoftVersion.UseVisualStyleBackColor = true;
            buttonGetSoftVersion.Click += buttonGetSoftVersion_Click;
            // 
            // labelSoftVersion
            // 
            labelSoftVersion.BackColor = SystemColors.ControlLightLight;
            labelSoftVersion.Location = new Point(164, 182);
            labelSoftVersion.Name = "labelSoftVersion";
            labelSoftVersion.Size = new Size(121, 35);
            labelSoftVersion.TabIndex = 13;
            labelSoftVersion.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxHardVersion
            // 
            textBoxHardVersion.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxHardVersion.Location = new Point(523, 136);
            textBoxHardVersion.Name = "textBoxHardVersion";
            textBoxHardVersion.Size = new Size(121, 28);
            textBoxHardVersion.TabIndex = 11;
            // 
            // buttonSetHardVersion
            // 
            buttonSetHardVersion.Location = new Point(380, 133);
            buttonSetHardVersion.Name = "buttonSetHardVersion";
            buttonSetHardVersion.Size = new Size(121, 35);
            buttonSetHardVersion.TabIndex = 10;
            buttonSetHardVersion.Text = "设置硬件版本";
            buttonSetHardVersion.UseVisualStyleBackColor = true;
            buttonSetHardVersion.Click += buttonSetHardVersion_Click;
            // 
            // buttonGetHardVersion
            // 
            buttonGetHardVersion.Location = new Point(11, 133);
            buttonGetHardVersion.Name = "buttonGetHardVersion";
            buttonGetHardVersion.Size = new Size(121, 35);
            buttonGetHardVersion.TabIndex = 8;
            buttonGetHardVersion.Text = "获取硬件版本";
            buttonGetHardVersion.UseVisualStyleBackColor = true;
            buttonGetHardVersion.Click += buttonGetHardVersion_Click;
            // 
            // labelHardVersion
            // 
            labelHardVersion.BackColor = SystemColors.ControlLightLight;
            labelHardVersion.Location = new Point(164, 133);
            labelHardVersion.Name = "labelHardVersion";
            labelHardVersion.Size = new Size(121, 35);
            labelHardVersion.TabIndex = 9;
            labelHardVersion.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = SystemColors.InactiveCaption;
            comboBox1.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            comboBox1.FormattingEnabled = true;
            comboBox1.IntegralHeight = false;
            comboBox1.ItemHeight = 21;
            comboBox1.Items.AddRange(new object[] { "black", "white" });
            comboBox1.Location = new Point(523, 83);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 29);
            comboBox1.TabIndex = 7;
            // 
            // buttonSetDeviceColor
            // 
            buttonSetDeviceColor.Location = new Point(380, 81);
            buttonSetDeviceColor.Name = "buttonSetDeviceColor";
            buttonSetDeviceColor.Size = new Size(121, 35);
            buttonSetDeviceColor.TabIndex = 6;
            buttonSetDeviceColor.Text = "设置设备颜色";
            buttonSetDeviceColor.UseVisualStyleBackColor = true;
            buttonSetDeviceColor.Click += buttonSetDeviceColor_Click;
            // 
            // buttonGetColor
            // 
            buttonGetColor.Location = new Point(11, 81);
            buttonGetColor.Name = "buttonGetColor";
            buttonGetColor.Size = new Size(121, 35);
            buttonGetColor.TabIndex = 4;
            buttonGetColor.Text = "获取设备颜色";
            buttonGetColor.UseVisualStyleBackColor = true;
            buttonGetColor.Click += buttonGetColor_Click;
            // 
            // labelColor
            // 
            labelColor.BackColor = SystemColors.ControlLightLight;
            labelColor.Location = new Point(164, 77);
            labelColor.Name = "labelColor";
            labelColor.Size = new Size(121, 35);
            labelColor.TabIndex = 5;
            labelColor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // buttonDis
            // 
            buttonDis.Enabled = false;
            buttonDis.Location = new Point(380, 32);
            buttonDis.Name = "buttonDis";
            buttonDis.Size = new Size(121, 35);
            buttonDis.TabIndex = 3;
            buttonDis.Text = "断开连接 复位";
            buttonDis.UseVisualStyleBackColor = true;
            buttonDis.Click += buttonDis_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ActiveCaption;
            pictureBox1.Location = new Point(0, 71);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(653, 306);
            pictureBox1.TabIndex = 42;
            pictureBox1.TabStop = false;
            // 
            // textBoxMessage
            // 
            textBoxMessage.Location = new Point(11, 401);
            textBoxMessage.Multiline = true;
            textBoxMessage.Name = "textBoxMessage";
            textBoxMessage.ReadOnly = true;
            textBoxMessage.ScrollBars = ScrollBars.Vertical;
            textBoxMessage.Size = new Size(633, 41);
            textBoxMessage.TabIndex = 28;
            // 
            // buttonGetChannel
            // 
            buttonGetChannel.Location = new Point(380, 231);
            buttonGetChannel.Name = "buttonGetChannel";
            buttonGetChannel.Size = new Size(121, 35);
            buttonGetChannel.TabIndex = 18;
            buttonGetChannel.Text = "获取通道";
            buttonGetChannel.UseVisualStyleBackColor = true;
            buttonGetChannel.Click += buttonGetChannel_Click;
            // 
            // labelChanel
            // 
            labelChanel.BackColor = SystemColors.ControlLightLight;
            labelChanel.Location = new Point(523, 231);
            labelChanel.Name = "labelChanel";
            labelChanel.Size = new Size(121, 35);
            labelChanel.TabIndex = 19;
            labelChanel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // buttonResetMode
            // 
            buttonResetMode.Location = new Point(380, 329);
            buttonResetMode.Name = "buttonResetMode";
            buttonResetMode.Size = new Size(121, 35);
            buttonResetMode.TabIndex = 26;
            buttonResetMode.Text = "重置模式";
            buttonResetMode.UseVisualStyleBackColor = true;
            buttonResetMode.Click += buttonResetMode_Click;
            // 
            // button1
            // 
            button1.Location = new Point(11, 28);
            button1.Name = "button1";
            button1.Size = new Size(121, 35);
            button1.TabIndex = 1;
            button1.Text = "连接";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(653, 523);
            Controls.Add(button1);
            Controls.Add(buttonResetMode);
            Controls.Add(labelChanel);
            Controls.Add(buttonGetChannel);
            Controls.Add(textBoxMessage);
            Controls.Add(buttonDis);
            Controls.Add(buttonGetBatteryLevel);
            Controls.Add(labelBattertLevel);
            Controls.Add(buttonEnterDutMode);
            Controls.Add(buttonEnterShipMode);
            Controls.Add(textSerialNumber);
            Controls.Add(buttonSetSerialNumber);
            Controls.Add(buttonGetSerialNumber);
            Controls.Add(labelSerialNumber);
            Controls.Add(buttonGetMFIStatus);
            Controls.Add(labelMfi);
            Controls.Add(buttonGetSoftVersion);
            Controls.Add(labelSoftVersion);
            Controls.Add(textBoxHardVersion);
            Controls.Add(buttonSetHardVersion);
            Controls.Add(buttonGetHardVersion);
            Controls.Add(labelHardVersion);
            Controls.Add(comboBox1);
            Controls.Add(buttonSetDeviceColor);
            Controls.Add(buttonGetColor);
            Controls.Add(labelColor);
            Controls.Add(textBoxList);
            Controls.Add(textBoxStatus);
            Controls.Add(textBox1);
            Controls.Add(menuStrip1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TANC-HANC";
            Load += Form1_Load;
            Enter += Form1_Enter;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        public TextBox textBox1;
        private TextBox textBoxStatus;
        private TextBox textBoxList;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem 菜单ToolStripMenuItem;
        private ToolStripMenuItem 设置ToolStripMenuItem;
        private Button buttonGetBatteryLevel;
        private Label labelBattertLevel;
        private Button buttonEnterDutMode;
        private Button buttonEnterShipMode;
        private TextBox textSerialNumber;
        private Button buttonSetSerialNumber;
        private Button buttonGetSerialNumber;
        private Label labelSerialNumber;
        private Button buttonGetMFIStatus;
        private Label labelMfi;
        private Button buttonGetSoftVersion;
        private Label labelSoftVersion;
        private TextBox textBoxHardVersion;
        private Button buttonSetHardVersion;
        private Button buttonGetHardVersion;
        private Label labelHardVersion;
        private ComboBox comboBox1;
        private Button buttonSetDeviceColor;
        private Button buttonGetColor;
        private Label labelColor;
        private Button buttonDis;
        private PictureBox pictureBox1;
        private TextBox textBoxMessage;
        private Button buttonGetChannel;
        private Label labelChanel;
        private Button buttonResetMode;
        private Button button1;
    }
}