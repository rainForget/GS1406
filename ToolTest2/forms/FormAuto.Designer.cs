namespace GS1406.forms
{
    partial class FormAuto
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
            components = new System.ComponentModel.Container();
            button1 = new Button();
            buttonResetMode = new Button();
            textBoxMessage = new TextBox();
            buttonDis = new Button();
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
            textBoxList = new TextBox();
            textBoxStatus = new TextBox();
            textBox1 = new TextBox();
            menuStrip1 = new MenuStrip();
            菜单ToolStripMenuItem = new ToolStripMenuItem();
            设置ToolStripMenuItem = new ToolStripMenuItem();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(11, 84);
            button1.Name = "button1";
            button1.Size = new Size(121, 35);
            button1.TabIndex = 43;
            button1.Text = "连接";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // buttonResetMode
            // 
            buttonResetMode.Location = new Point(347, 385);
            buttonResetMode.Name = "buttonResetMode";
            buttonResetMode.Size = new Size(121, 35);
            buttonResetMode.TabIndex = 69;
            buttonResetMode.Text = "重置模式";
            buttonResetMode.UseVisualStyleBackColor = true;
            buttonResetMode.Click += buttonResetMode_Click;
            // 
            // textBoxMessage
            // 
            textBoxMessage.Location = new Point(11, 457);
            textBoxMessage.Multiline = true;
            textBoxMessage.Name = "textBoxMessage";
            textBoxMessage.ReadOnly = true;
            textBoxMessage.ScrollBars = ScrollBars.Vertical;
            textBoxMessage.Size = new Size(633, 41);
            textBoxMessage.TabIndex = 71;
            // 
            // buttonDis
            // 
            buttonDis.Enabled = false;
            buttonDis.Location = new Point(380, 88);
            buttonDis.Name = "buttonDis";
            buttonDis.Size = new Size(121, 35);
            buttonDis.TabIndex = 45;
            buttonDis.Text = "断开连接 复位";
            buttonDis.UseVisualStyleBackColor = true;
            buttonDis.Click += buttonDis_Click;
            // 
            // buttonGetBatteryLevel
            // 
            buttonGetBatteryLevel.Location = new Point(347, 238);
            buttonGetBatteryLevel.Name = "buttonGetBatteryLevel";
            buttonGetBatteryLevel.Size = new Size(121, 35);
            buttonGetBatteryLevel.TabIndex = 57;
            buttonGetBatteryLevel.Text = "获取耳机电量";
            buttonGetBatteryLevel.UseVisualStyleBackColor = true;
            buttonGetBatteryLevel.Click += buttonGetBatteryLevel_Click;
            // 
            // labelBattertLevel
            // 
            labelBattertLevel.BackColor = SystemColors.ControlLightLight;
            labelBattertLevel.Location = new Point(490, 238);
            labelBattertLevel.Name = "labelBattertLevel";
            labelBattertLevel.Size = new Size(121, 35);
            labelBattertLevel.TabIndex = 58;
            labelBattertLevel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // buttonEnterDutMode
            // 
            buttonEnterDutMode.Location = new Point(11, 385);
            buttonEnterDutMode.Name = "buttonEnterDutMode";
            buttonEnterDutMode.Size = new Size(121, 35);
            buttonEnterDutMode.TabIndex = 67;
            buttonEnterDutMode.Text = "进入DUT模式";
            buttonEnterDutMode.UseVisualStyleBackColor = true;
            buttonEnterDutMode.Click += buttonEnterDutMode_Click;
            // 
            // buttonEnterShipMode
            // 
            buttonEnterShipMode.Location = new Point(164, 385);
            buttonEnterShipMode.Name = "buttonEnterShipMode";
            buttonEnterShipMode.Size = new Size(121, 35);
            buttonEnterShipMode.TabIndex = 68;
            buttonEnterShipMode.Text = "进入SHIP模式";
            buttonEnterShipMode.UseVisualStyleBackColor = true;
            buttonEnterShipMode.Click += buttonEnterShipMode_Click;
            // 
            // textSerialNumber
            // 
            textSerialNumber.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textSerialNumber.Location = new Point(490, 339);
            textSerialNumber.MaxLength = 14;
            textSerialNumber.Name = "textSerialNumber";
            textSerialNumber.Size = new Size(144, 28);
            textSerialNumber.TabIndex = 66;
            textSerialNumber.TextChanged += textSerialNumber_TextChanged;
            // 
            // buttonSetSerialNumber
            // 
            buttonSetSerialNumber.Location = new Point(347, 335);
            buttonSetSerialNumber.Name = "buttonSetSerialNumber";
            buttonSetSerialNumber.Size = new Size(121, 35);
            buttonSetSerialNumber.TabIndex = 65;
            buttonSetSerialNumber.Text = "设置序列号";
            buttonSetSerialNumber.UseVisualStyleBackColor = true;
            buttonSetSerialNumber.Click += buttonSetSerialNumber_Click;
            // 
            // buttonGetSerialNumber
            // 
            buttonGetSerialNumber.Location = new Point(11, 335);
            buttonGetSerialNumber.Name = "buttonGetSerialNumber";
            buttonGetSerialNumber.Size = new Size(121, 35);
            buttonGetSerialNumber.TabIndex = 63;
            buttonGetSerialNumber.Text = "获取序列号";
            buttonGetSerialNumber.UseVisualStyleBackColor = true;
            buttonGetSerialNumber.Click += buttonGetSerialNumber_Click;
            // 
            // labelSerialNumber
            // 
            labelSerialNumber.BackColor = SystemColors.ControlLightLight;
            labelSerialNumber.Location = new Point(164, 335);
            labelSerialNumber.Name = "labelSerialNumber";
            labelSerialNumber.Size = new Size(121, 35);
            labelSerialNumber.TabIndex = 64;
            labelSerialNumber.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // buttonGetMFIStatus
            // 
            buttonGetMFIStatus.Location = new Point(11, 287);
            buttonGetMFIStatus.Name = "buttonGetMFIStatus";
            buttonGetMFIStatus.Size = new Size(121, 35);
            buttonGetMFIStatus.TabIndex = 59;
            buttonGetMFIStatus.Text = "获取MFI状态";
            buttonGetMFIStatus.UseVisualStyleBackColor = true;
            buttonGetMFIStatus.Click += buttonGetMFIStatus_Click;
            // 
            // labelMfi
            // 
            labelMfi.BackColor = SystemColors.ControlLightLight;
            labelMfi.Location = new Point(164, 287);
            labelMfi.Name = "labelMfi";
            labelMfi.Size = new Size(121, 35);
            labelMfi.TabIndex = 60;
            labelMfi.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // buttonGetSoftVersion
            // 
            buttonGetSoftVersion.Location = new Point(11, 238);
            buttonGetSoftVersion.Name = "buttonGetSoftVersion";
            buttonGetSoftVersion.Size = new Size(121, 35);
            buttonGetSoftVersion.TabIndex = 55;
            buttonGetSoftVersion.Text = "获取软件版本";
            buttonGetSoftVersion.UseVisualStyleBackColor = true;
            buttonGetSoftVersion.Click += buttonGetSoftVersion_Click;
            // 
            // labelSoftVersion
            // 
            labelSoftVersion.BackColor = SystemColors.ControlLightLight;
            labelSoftVersion.Location = new Point(164, 238);
            labelSoftVersion.Name = "labelSoftVersion";
            labelSoftVersion.Size = new Size(121, 35);
            labelSoftVersion.TabIndex = 56;
            labelSoftVersion.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxHardVersion
            // 
            textBoxHardVersion.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxHardVersion.Location = new Point(490, 192);
            textBoxHardVersion.Name = "textBoxHardVersion";
            textBoxHardVersion.Size = new Size(121, 28);
            textBoxHardVersion.TabIndex = 53;
            // 
            // buttonSetHardVersion
            // 
            buttonSetHardVersion.Location = new Point(347, 189);
            buttonSetHardVersion.Name = "buttonSetHardVersion";
            buttonSetHardVersion.Size = new Size(121, 35);
            buttonSetHardVersion.TabIndex = 52;
            buttonSetHardVersion.Text = "设置硬件版本";
            buttonSetHardVersion.UseVisualStyleBackColor = true;
            buttonSetHardVersion.Click += buttonSetHardVersion_Click;
            // 
            // buttonGetHardVersion
            // 
            buttonGetHardVersion.Location = new Point(11, 189);
            buttonGetHardVersion.Name = "buttonGetHardVersion";
            buttonGetHardVersion.Size = new Size(121, 35);
            buttonGetHardVersion.TabIndex = 50;
            buttonGetHardVersion.Text = "获取硬件版本";
            buttonGetHardVersion.UseVisualStyleBackColor = true;
            buttonGetHardVersion.Click += buttonGetHardVersion_Click;
            // 
            // labelHardVersion
            // 
            labelHardVersion.BackColor = SystemColors.ControlLightLight;
            labelHardVersion.Location = new Point(164, 189);
            labelHardVersion.Name = "labelHardVersion";
            labelHardVersion.Size = new Size(121, 35);
            labelHardVersion.TabIndex = 51;
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
            comboBox1.Location = new Point(490, 139);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 29);
            comboBox1.TabIndex = 49;
            // 
            // buttonSetDeviceColor
            // 
            buttonSetDeviceColor.Location = new Point(347, 137);
            buttonSetDeviceColor.Name = "buttonSetDeviceColor";
            buttonSetDeviceColor.Size = new Size(121, 35);
            buttonSetDeviceColor.TabIndex = 48;
            buttonSetDeviceColor.Text = "设置设备颜色";
            buttonSetDeviceColor.UseVisualStyleBackColor = true;
            buttonSetDeviceColor.Click += buttonSetDeviceColor_Click;
            // 
            // buttonGetColor
            // 
            buttonGetColor.Location = new Point(11, 137);
            buttonGetColor.Name = "buttonGetColor";
            buttonGetColor.Size = new Size(121, 35);
            buttonGetColor.TabIndex = 46;
            buttonGetColor.Text = "获取设备颜色";
            buttonGetColor.UseVisualStyleBackColor = true;
            buttonGetColor.Click += buttonGetColor_Click;
            // 
            // labelColor
            // 
            labelColor.BackColor = SystemColors.ControlLightLight;
            labelColor.Location = new Point(164, 133);
            labelColor.Name = "labelColor";
            labelColor.Size = new Size(121, 35);
            labelColor.TabIndex = 47;
            labelColor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxList
            // 
            textBoxList.Cursor = Cursors.IBeam;
            textBoxList.Location = new Point(11, 441);
            textBoxList.Multiline = true;
            textBoxList.Name = "textBoxList";
            textBoxList.ReadOnly = true;
            textBoxList.ScrollBars = ScrollBars.Vertical;
            textBoxList.Size = new Size(633, 10);
            textBoxList.TabIndex = 70;
            textBoxList.Visible = false;
            // 
            // textBoxStatus
            // 
            textBoxStatus.BorderStyle = BorderStyle.None;
            textBoxStatus.Font = new Font("Microsoft YaHei UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxStatus.Location = new Point(12, 504);
            textBoxStatus.Name = "textBoxStatus";
            textBoxStatus.ReadOnly = true;
            textBoxStatus.Size = new Size(632, 45);
            textBoxStatus.TabIndex = 72;
            // 
            // textBox1
            // 
            textBox1.CharacterCasing = CharacterCasing.Upper;
            textBox1.Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(138, 84);
            textBox1.MaxLength = 12;
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(221, 35);
            textBox1.TabIndex = 44;
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { 菜单ToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(661, 25);
            menuStrip1.TabIndex = 54;
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
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ActiveCaption;
            pictureBox1.Location = new Point(0, 73);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(661, 360);
            pictureBox1.TabIndex = 73;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.Font = new Font("Microsoft YaHei UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 27);
            label1.Name = "label1";
            label1.Size = new Size(632, 45);
            label1.TabIndex = 74;
            label1.Text = "GS-1406";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 200;
            timer1.Tick += timerAuto_Tick;
            // 
            // FormAuto
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(661, 553);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(buttonResetMode);
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
            Name = "FormAuto";
            Text = "TANC-HANC";
            Load += FormAuto_Load;
            Enter += FormAuto_Enter;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button buttonResetMode;
        private TextBox textBoxMessage;
        private Button buttonDis;
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
        private TextBox textBoxList;
        private TextBox textBoxStatus;
        public TextBox textBox1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem 菜单ToolStripMenuItem;
        private ToolStripMenuItem 设置ToolStripMenuItem;
        private PictureBox pictureBox1;
        private Label label1;
        private System.Windows.Forms.Timer timer1;
    }
}