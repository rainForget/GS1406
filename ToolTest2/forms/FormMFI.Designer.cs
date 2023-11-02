namespace GS1406.forms
{
    partial class FormMFI
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
            menuStrip1 = new MenuStrip();
            菜单ToolStripMenuItem = new ToolStripMenuItem();
            设置ToolStripMenuItem = new ToolStripMenuItem();
            textBoxMessage = new TextBox();
            textBoxStatus = new TextBox();
            textBoxList = new TextBox();
            label1 = new Label();
            buttonDis = new Button();
            textBox1 = new TextBox();
            timer1 = new System.Windows.Forms.Timer(components);
            label2 = new Label();
            labelMfi = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { 菜单ToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(646, 25);
            menuStrip1.TabIndex = 39;
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
            设置ToolStripMenuItem.Click += ToolStripMenuItem_Click;
            // 
            // textBoxMessage
            // 
            textBoxMessage.Location = new Point(12, 354);
            textBoxMessage.Multiline = true;
            textBoxMessage.Name = "textBoxMessage";
            textBoxMessage.ReadOnly = true;
            textBoxMessage.ScrollBars = ScrollBars.Vertical;
            textBoxMessage.Size = new Size(633, 41);
            textBoxMessage.TabIndex = 37;
            // 
            // textBoxStatus
            // 
            textBoxStatus.BorderStyle = BorderStyle.None;
            textBoxStatus.Font = new Font("Microsoft YaHei UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxStatus.Location = new Point(13, 401);
            textBoxStatus.Name = "textBoxStatus";
            textBoxStatus.ReadOnly = true;
            textBoxStatus.Size = new Size(632, 45);
            textBoxStatus.TabIndex = 38;
            // 
            // textBoxList
            // 
            textBoxList.Cursor = Cursors.IBeam;
            textBoxList.Location = new Point(12, 131);
            textBoxList.Multiline = true;
            textBoxList.Name = "textBoxList";
            textBoxList.ReadOnly = true;
            textBoxList.ScrollBars = ScrollBars.Vertical;
            textBoxList.Size = new Size(633, 217);
            textBoxList.TabIndex = 36;
            // 
            // label1
            // 
            label1.Location = new Point(9, 32);
            label1.Name = "label1";
            label1.Size = new Size(51, 35);
            label1.TabIndex = 33;
            label1.Text = "地址";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonDis
            // 
            buttonDis.Enabled = false;
            buttonDis.Location = new Point(378, 36);
            buttonDis.Name = "buttonDis";
            buttonDis.Size = new Size(121, 35);
            buttonDis.TabIndex = 35;
            buttonDis.Text = "断开连接 复位";
            buttonDis.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.CharacterCasing = CharacterCasing.Upper;
            textBox1.Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(66, 32);
            textBox1.MaxLength = 12;
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(217, 35);
            textBox1.TabIndex = 34;
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 200;
            timer1.Tick += timer1_Tick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 84);
            label2.Name = "label2";
            label2.Size = new Size(30, 17);
            label2.TabIndex = 40;
            label2.Text = "MFI";
            // 
            // labelMfi
            // 
            labelMfi.BackColor = Color.White;
            labelMfi.Location = new Point(66, 77);
            labelMfi.Name = "labelMfi";
            labelMfi.Size = new Size(104, 34);
            labelMfi.TabIndex = 41;
            // 
            // FormMFI
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(646, 450);
            Controls.Add(labelMfi);
            Controls.Add(label2);
            Controls.Add(menuStrip1);
            Controls.Add(textBoxMessage);
            Controls.Add(textBoxStatus);
            Controls.Add(textBoxList);
            Controls.Add(label1);
            Controls.Add(buttonDis);
            Controls.Add(textBox1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormMFI";
            Text = "TANC-HANC-Check MFI";
            Load += FormMFI_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem 菜单ToolStripMenuItem;
        private ToolStripMenuItem 设置ToolStripMenuItem;
        private TextBox textBoxMessage;
        private TextBox textBoxStatus;
        private TextBox textBoxList;
        private Label label1;
        private Button buttonDis;
        public TextBox textBox1;
        private System.Windows.Forms.Timer timer1;
        private Label label2;
        private Label labelMfi;
    }
}