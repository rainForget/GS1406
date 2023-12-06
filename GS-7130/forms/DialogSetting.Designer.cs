namespace GS_7130.forms
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
            checkBoxSetSN = new CheckBox();
            textBoxSKU = new TextBox();
            label6 = new Label();
            textBoxPwd = new TextBox();
            labelPwd = new Label();
            PortList = new ComboBox();
            label2 = new Label();
            textBoxVersion = new TextBox();
            label1 = new Label();
            buttonOK = new Button();
            buttonCancle = new Button();
            SuspendLayout();
            // 
            // checkBoxSetSN
            // 
            checkBoxSetSN.Location = new Point(119, 48);
            checkBoxSetSN.Name = "checkBoxSetSN";
            checkBoxSetSN.Size = new Size(110, 35);
            checkBoxSetSN.TabIndex = 0;
            checkBoxSetSN.Text = "设置序列号";
            checkBoxSetSN.UseVisualStyleBackColor = true;
            checkBoxSetSN.CheckedChanged += checkBoxSetSN_CheckedChanged;
            // 
            // textBoxSKU
            // 
            textBoxSKU.Location = new Point(503, 151);
            textBoxSKU.MaxLength = 10;
            textBoxSKU.Name = "textBoxSKU";
            textBoxSKU.Size = new Size(109, 23);
            textBoxSKU.TabIndex = 91;
            textBoxSKU.Text = "80";
            textBoxSKU.Leave += textBoxSKU_Leave;
            // 
            // label6
            // 
            label6.BackColor = SystemColors.ActiveCaption;
            label6.Location = new Point(371, 148);
            label6.Name = "label6";
            label6.Size = new Size(110, 30);
            label6.TabIndex = 90;
            label6.Text = "SKU";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxPwd
            // 
            textBoxPwd.Location = new Point(242, 151);
            textBoxPwd.Name = "textBoxPwd";
            textBoxPwd.Size = new Size(109, 23);
            textBoxPwd.TabIndex = 89;
            textBoxPwd.Text = "1.0";
            textBoxPwd.Leave += textBoxPwd_Leave;
            // 
            // labelPwd
            // 
            labelPwd.BackColor = SystemColors.ActiveCaption;
            labelPwd.Location = new Point(119, 148);
            labelPwd.Name = "labelPwd";
            labelPwd.Size = new Size(110, 30);
            labelPwd.TabIndex = 88;
            labelPwd.Text = "密码";
            labelPwd.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PortList
            // 
            PortList.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            PortList.FormattingEnabled = true;
            PortList.ItemHeight = 17;
            PortList.Location = new Point(502, 107);
            PortList.Name = "PortList";
            PortList.Size = new Size(107, 25);
            PortList.TabIndex = 87;
            PortList.SelectedIndexChanged += PortList_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.BackColor = SystemColors.ActiveCaption;
            label2.Location = new Point(371, 107);
            label2.Name = "label2";
            label2.Size = new Size(110, 30);
            label2.TabIndex = 86;
            label2.Text = "串口号";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxVersion
            // 
            textBoxVersion.Location = new Point(241, 107);
            textBoxVersion.Name = "textBoxVersion";
            textBoxVersion.Size = new Size(110, 23);
            textBoxVersion.TabIndex = 85;
            textBoxVersion.Text = "0.3.5";
            textBoxVersion.Leave += textBoxVersion_Leave;
            // 
            // label1
            // 
            label1.BackColor = SystemColors.ActiveCaption;
            label1.Location = new Point(119, 103);
            label1.Name = "label1";
            label1.Size = new Size(110, 30);
            label1.TabIndex = 84;
            label1.Text = "软件版本";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonOK
            // 
            buttonOK.Location = new Point(119, 293);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(128, 44);
            buttonOK.TabIndex = 92;
            buttonOK.Text = "确认";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // buttonCancle
            // 
            buttonCancle.Location = new Point(481, 293);
            buttonCancle.Name = "buttonCancle";
            buttonCancle.Size = new Size(128, 44);
            buttonCancle.TabIndex = 93;
            buttonCancle.Text = "取消";
            buttonCancle.UseVisualStyleBackColor = true;
            buttonCancle.Click += buttonCancle_Click;
            // 
            // DialogSetting
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonCancle);
            Controls.Add(buttonOK);
            Controls.Add(textBoxSKU);
            Controls.Add(label6);
            Controls.Add(textBoxPwd);
            Controls.Add(labelPwd);
            Controls.Add(PortList);
            Controls.Add(label2);
            Controls.Add(textBoxVersion);
            Controls.Add(label1);
            Controls.Add(checkBoxSetSN);
            Name = "DialogSetting";
            Text = "DialogSetting";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox checkBoxSetSN;
        private TextBox textBoxSKU;
        private Label label6;
        private TextBox textBoxPwd;
        private Label labelPwd;
        private ComboBox PortList;
        private Label label2;
        private TextBox textBoxVersion;
        private Label label1;
        private Button buttonOK;
        private Button buttonCancle;
    }
}