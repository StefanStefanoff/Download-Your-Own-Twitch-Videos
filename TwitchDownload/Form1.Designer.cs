namespace TwitchDownload
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.channelId = new System.Windows.Forms.TextBox();
            this.authorization = new System.Windows.Forms.TextBox();
            this.dlLocation = new System.Windows.Forms.TextBox();
            this.dirButton = new System.Windows.Forms.Button();
            this.folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.maxLength = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "channelId*";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "authorization*";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(335, 414);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Download All";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Download Location*";
            // 
            // channelId
            // 
            this.channelId.Location = new System.Drawing.Point(178, 22);
            this.channelId.Name = "channelId";
            this.channelId.Size = new System.Drawing.Size(227, 20);
            this.channelId.TabIndex = 5;
            this.channelId.TextChanged += new System.EventHandler(this.channelId_TextChanged);
            // 
            // authorization
            // 
            this.authorization.Location = new System.Drawing.Point(178, 68);
            this.authorization.Name = "authorization";
            this.authorization.Size = new System.Drawing.Size(227, 20);
            this.authorization.TabIndex = 7;
            this.authorization.TextChanged += new System.EventHandler(this.authorization_TextChanged);
            // 
            // dlLocation
            // 
            this.dlLocation.Location = new System.Drawing.Point(178, 125);
            this.dlLocation.Name = "dlLocation";
            this.dlLocation.Size = new System.Drawing.Size(172, 20);
            this.dlLocation.TabIndex = 8;
            this.dlLocation.TextChanged += new System.EventHandler(this.dlLocation_TextChanged);
            // 
            // dirButton
            // 
            this.dirButton.Location = new System.Drawing.Point(356, 125);
            this.dirButton.Name = "dirButton";
            this.dirButton.Size = new System.Drawing.Size(75, 20);
            this.dirButton.TabIndex = 9;
            this.dirButton.Text = "choose";
            this.dirButton.UseVisualStyleBackColor = true;
            this.dirButton.Click += new System.EventHandler(this.dirButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Max Length in Seconds";
            // 
            // maxLength
            // 
            this.maxLength.Location = new System.Drawing.Point(178, 187);
            this.maxLength.Name = "maxLength";
            this.maxLength.Size = new System.Drawing.Size(123, 20);
            this.maxLength.TabIndex = 11;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(178, 245);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(51, 248);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Category";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(304, 190);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Optional";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 466);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.maxLength);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dirButton);
            this.Controls.Add(this.dlLocation);
            this.Controls.Add(this.authorization);
            this.Controls.Add(this.channelId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Download All Videos From Twitch";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox channelId;
        private System.Windows.Forms.TextBox authorization;
        private System.Windows.Forms.TextBox dlLocation;
        private System.Windows.Forms.Button dirButton;
        private System.Windows.Forms.FolderBrowserDialog folderDialog;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox maxLength;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}

