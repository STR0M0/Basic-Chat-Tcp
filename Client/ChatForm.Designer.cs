namespace Simple_Chat_Form_App
{
    partial class ChatForm
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
            this.chatTxtBox = new System.Windows.Forms.RichTextBox();
            this.userTxtBox = new System.Windows.Forms.RichTextBox();
            this.msgTxtBox = new System.Windows.Forms.RichTextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chatTxtBox
            // 
            this.chatTxtBox.Location = new System.Drawing.Point(6, 6);
            this.chatTxtBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chatTxtBox.Name = "chatTxtBox";
            this.chatTxtBox.ReadOnly = true;
            this.chatTxtBox.Size = new System.Drawing.Size(264, 210);
            this.chatTxtBox.TabIndex = 0;
            this.chatTxtBox.Text = "";
            // 
            // userTxtBox
            // 
            this.userTxtBox.Location = new System.Drawing.Point(283, 6);
            this.userTxtBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.userTxtBox.Name = "userTxtBox";
            this.userTxtBox.ReadOnly = true;
            this.userTxtBox.Size = new System.Drawing.Size(125, 210);
            this.userTxtBox.TabIndex = 1;
            this.userTxtBox.Text = "";
            // 
            // msgTxtBox
            // 
            this.msgTxtBox.Location = new System.Drawing.Point(9, 226);
            this.msgTxtBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.msgTxtBox.Name = "msgTxtBox";
            this.msgTxtBox.Size = new System.Drawing.Size(262, 90);
            this.msgTxtBox.TabIndex = 2;
            this.msgTxtBox.Text = "";
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Location = new System.Drawing.Point(300, 260);
            this.btnSend.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(78, 25);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 327);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.msgTxtBox);
            this.Controls.Add(this.userTxtBox);
            this.Controls.Add(this.chatTxtBox);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ChatForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox chatTxtBox;
        private System.Windows.Forms.RichTextBox userTxtBox;
        private System.Windows.Forms.RichTextBox msgTxtBox;
        private System.Windows.Forms.Button btnSend;
    }
}