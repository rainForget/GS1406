namespace ToolTest2.forms
{
    partial class DialogCheck
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
            button2 = new Button();
            button1 = new Button();
            label1 = new Label();
            textBoxPWD = new TextBox();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Location = new Point(262, 78);
            button2.Name = "button2";
            button2.Size = new Size(75, 35);
            button2.TabIndex = 3;
            button2.Text = "取消";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(81, 78);
            button1.Name = "button1";
            button1.Size = new Size(75, 35);
            button1.TabIndex = 2;
            button1.Text = "登录";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(81, 24);
            label1.Name = "label1";
            label1.Size = new Size(75, 25);
            label1.TabIndex = 4;
            label1.Text = "密码";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxPWD
            // 
            textBoxPWD.Location = new Point(237, 24);
            textBoxPWD.Name = "textBoxPWD";
            textBoxPWD.PasswordChar = '*';
            textBoxPWD.Size = new Size(100, 23);
            textBoxPWD.TabIndex = 1;
            textBoxPWD.KeyPress += textBoxPWD_KeyPress;
            // 
            // DialogCheck
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(419, 137);
            Controls.Add(textBoxPWD);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DialogCheck";
            Text = "登录";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button2;
        private Button button1;
        private Label label1;
        private TextBox textBoxPWD;
    }
}