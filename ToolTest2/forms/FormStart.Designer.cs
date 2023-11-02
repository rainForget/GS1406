namespace ToolTest2.forms
{
    partial class FormStart
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
            label1 = new Label();
            comboBox1 = new ComboBox();
            button1 = new Button();
            button2 = new Button();
            comboBoxMode = new ComboBox();
            labelMode = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(80, 26);
            label1.Name = "label1";
            label1.Size = new Size(75, 25);
            label1.TabIndex = 0;
            label1.Text = "项目";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // comboBox1
            // 
            comboBox1.ForeColor = SystemColors.MenuHighlight;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "GS-1406" });
            comboBox1.Location = new Point(215, 26);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 25);
            comboBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(80, 99);
            button1.Name = "button1";
            button1.Size = new Size(75, 35);
            button1.TabIndex = 2;
            button1.Text = "进入";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(261, 99);
            button2.Name = "button2";
            button2.Size = new Size(75, 35);
            button2.TabIndex = 3;
            button2.Text = "退出";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // comboBoxMode
            // 
            comboBoxMode.ForeColor = SystemColors.MenuHighlight;
            comboBoxMode.FormattingEnabled = true;
            comboBoxMode.Items.AddRange(new object[] { "普通", "Check MFI & DUT", "Check MFI" });
            comboBoxMode.Location = new Point(215, 62);
            comboBoxMode.Name = "comboBoxMode";
            comboBoxMode.Size = new Size(121, 25);
            comboBoxMode.TabIndex = 5;
            comboBoxMode.SelectedIndexChanged += comboBoxMode_SelectedIndexChanged;
            // 
            // labelMode
            // 
            labelMode.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            labelMode.Location = new Point(80, 62);
            labelMode.Name = "labelMode";
            labelMode.Size = new Size(75, 25);
            labelMode.TabIndex = 4;
            labelMode.Text = "模式";
            labelMode.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormStart
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(493, 151);
            Controls.Add(comboBoxMode);
            Controls.Add(labelMode);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            MaximizeBox = false;
            Name = "FormStart";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "选择项目";
            Load += FormStart_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private ComboBox comboBox1;
        private Button button1;
        private Button button2;
        private ComboBox comboBoxMode;
        private Label labelMode;
    }
}