namespace GS_7130.forms
{
    partial class FormMainRead
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
            timer1 = new System.Windows.Forms.Timer(components);
            panel1 = new Panel();
            textBoxReProductId = new TextBox();
            textBoxSN = new TextBox();
            textBoxSoftVersion = new TextBox();
            textBoxProductId = new TextBox();
            textBoxScanSN = new TextBox();
            textBoxScanBle = new TextBox();
            labelStatue = new Label();
            panel2 = new Panel();
            label8 = new Label();
            labelSN = new Label();
            labelSoftVersion = new Label();
            labelProductId = new Label();
            labelScanSN = new Label();
            labelScanBle = new Label();
            button1 = new Button();
            label1 = new Label();
            设置ToolStripMenuItem1 = new ToolStripMenuItem();
            设置ToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            panel2.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Location = new Point(12, 97);
            panel1.Name = "panel1";
            panel1.Size = new Size(732, 152);
            panel1.TabIndex = 30;
            // 
            // textBoxReProductId
            // 
            textBoxReProductId.Location = new Point(157, 118);
            textBoxReProductId.Name = "textBoxReProductId";
            textBoxReProductId.ReadOnly = true;
            textBoxReProductId.Size = new Size(487, 23);
            textBoxReProductId.TabIndex = 17;
            // 
            // textBoxSN
            // 
            textBoxSN.Location = new Point(157, 80);
            textBoxSN.Name = "textBoxSN";
            textBoxSN.ReadOnly = true;
            textBoxSN.Size = new Size(487, 23);
            textBoxSN.TabIndex = 16;
            // 
            // textBoxSoftVersion
            // 
            textBoxSoftVersion.Location = new Point(157, 47);
            textBoxSoftVersion.Name = "textBoxSoftVersion";
            textBoxSoftVersion.ReadOnly = true;
            textBoxSoftVersion.Size = new Size(487, 23);
            textBoxSoftVersion.TabIndex = 15;
            // 
            // textBoxProductId
            // 
            textBoxProductId.Location = new Point(190, 201);
            textBoxProductId.Name = "textBoxProductId";
            textBoxProductId.ReadOnly = true;
            textBoxProductId.Size = new Size(196, 23);
            textBoxProductId.TabIndex = 29;
            // 
            // textBoxScanSN
            // 
            textBoxScanSN.Location = new Point(190, 172);
            textBoxScanSN.MaxLength = 14;
            textBoxScanSN.Name = "textBoxScanSN";
            textBoxScanSN.ReadOnly = true;
            textBoxScanSN.Size = new Size(196, 23);
            textBoxScanSN.TabIndex = 28;
            // 
            // textBoxScanBle
            // 
            textBoxScanBle.Location = new Point(190, 142);
            textBoxScanBle.MaxLength = 12;
            textBoxScanBle.Name = "textBoxScanBle";
            textBoxScanBle.Size = new Size(196, 23);
            textBoxScanBle.TabIndex = 27;
            textBoxScanBle.TextChanged += textBoxScanBle_TextChanged;
            // 
            // labelStatue
            // 
            labelStatue.BackColor = Color.Transparent;
            labelStatue.ForeColor = Color.Black;
            labelStatue.Location = new Point(499, 141);
            labelStatue.Name = "labelStatue";
            labelStatue.Size = new Size(178, 83);
            labelStatue.TabIndex = 26;
            labelStatue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveCaption;
            panel2.Controls.Add(textBoxReProductId);
            panel2.Controls.Add(textBoxSN);
            panel2.Controls.Add(textBoxSoftVersion);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(labelSN);
            panel2.Controls.Add(labelSoftVersion);
            panel2.Location = new Point(12, 255);
            panel2.Name = "panel2";
            panel2.Size = new Size(732, 179);
            panel2.TabIndex = 31;
            // 
            // label8
            // 
            label8.BackColor = Color.Transparent;
            label8.ForeColor = Color.Black;
            label8.Location = new Point(14, 118);
            label8.Name = "label8";
            label8.Size = new Size(100, 23);
            label8.TabIndex = 9;
            label8.Text = "回读产品型号";
            label8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelSN
            // 
            labelSN.BackColor = Color.Transparent;
            labelSN.ForeColor = Color.Black;
            labelSN.Location = new Point(14, 80);
            labelSN.Name = "labelSN";
            labelSN.Size = new Size(100, 23);
            labelSN.TabIndex = 8;
            labelSN.Text = "回读SN";
            labelSN.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelSoftVersion
            // 
            labelSoftVersion.BackColor = Color.Transparent;
            labelSoftVersion.ForeColor = Color.Black;
            labelSoftVersion.Location = new Point(14, 47);
            labelSoftVersion.Name = "labelSoftVersion";
            labelSoftVersion.Size = new Size(100, 23);
            labelSoftVersion.TabIndex = 7;
            labelSoftVersion.Text = "软件版本";
            labelSoftVersion.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelProductId
            // 
            labelProductId.BackColor = SystemColors.ActiveCaption;
            labelProductId.ForeColor = Color.Black;
            labelProductId.Location = new Point(47, 201);
            labelProductId.Name = "labelProductId";
            labelProductId.Size = new Size(100, 23);
            labelProductId.TabIndex = 25;
            labelProductId.Text = "产品型号";
            labelProductId.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelScanSN
            // 
            labelScanSN.BackColor = SystemColors.ActiveCaption;
            labelScanSN.ForeColor = Color.Black;
            labelScanSN.Location = new Point(47, 172);
            labelScanSN.Name = "labelScanSN";
            labelScanSN.Size = new Size(100, 23);
            labelScanSN.TabIndex = 24;
            labelScanSN.Text = "扫描SN";
            labelScanSN.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelScanBle
            // 
            labelScanBle.BackColor = SystemColors.ActiveCaption;
            labelScanBle.ForeColor = Color.Black;
            labelScanBle.Location = new Point(47, 141);
            labelScanBle.Name = "labelScanBle";
            labelScanBle.Size = new Size(100, 23);
            labelScanBle.TabIndex = 23;
            labelScanBle.Text = "扫描蓝牙地址";
            labelScanBle.TextAlign = ContentAlignment.MiddleRight;
            // 
            // button1
            // 
            button1.ForeColor = Color.Black;
            button1.Location = new Point(47, 104);
            button1.Name = "button1";
            button1.Size = new Size(100, 27);
            button1.TabIndex = 22;
            button1.Text = "Reset";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.BackColor = SystemColors.MenuHighlight;
            label1.Font = new Font("Microsoft YaHei UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(0, 41);
            label1.Name = "label1";
            label1.Size = new Size(756, 46);
            label1.TabIndex = 21;
            label1.Text = "GS-7130";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // 设置ToolStripMenuItem1
            // 
            设置ToolStripMenuItem1.Name = "设置ToolStripMenuItem1";
            设置ToolStripMenuItem1.Size = new Size(100, 22);
            设置ToolStripMenuItem1.Text = "设置";
            设置ToolStripMenuItem1.Click += SettingToolStripMenuItem_Click;
            // 
            // 设置ToolStripMenuItem
            // 
            设置ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 设置ToolStripMenuItem1 });
            设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            设置ToolStripMenuItem.Size = new Size(44, 21);
            设置ToolStripMenuItem.Text = "菜单";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { 设置ToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(756, 25);
            menuStrip1.TabIndex = 20;
            menuStrip1.Text = "menuStrip1";
            // 
            // FormMainRead
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(756, 450);
            Controls.Add(textBoxProductId);
            Controls.Add(textBoxScanSN);
            Controls.Add(textBoxScanBle);
            Controls.Add(labelStatue);
            Controls.Add(panel2);
            Controls.Add(labelProductId);
            Controls.Add(labelScanSN);
            Controls.Add(labelScanBle);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            Controls.Add(panel1);
            Name = "FormMainRead";
            Text = "GS-7130";
            Load += FormMain_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private Panel panel1;
        private TextBox textBoxReProductId;
        private TextBox textBoxSN;
        private TextBox textBoxSoftVersion;
        private TextBox textBoxProductId;
        private TextBox textBoxScanSN;
        private TextBox textBoxScanBle;
        private Label labelStatue;
        private Panel panel2;
        private Label label8;
        private Label labelSN;
        private Label labelSoftVersion;
        private Label labelProductId;
        private Label labelScanSN;
        private Label labelScanBle;
        private Button button1;
        private Label label1;
        private ToolStripMenuItem 设置ToolStripMenuItem1;
        private ToolStripMenuItem 设置ToolStripMenuItem;
        private MenuStrip menuStrip1;
    }
}