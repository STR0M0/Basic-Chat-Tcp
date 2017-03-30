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
            this.chatTxtBox.Location = new System.Drawing.Point(12, 12);
            this.chatTxtBox.Name = "chatTxtBox";
            this.chatTxtBox.Size = new System.Drawing.Size(525, 400);
            this.chatTxtBox.TabIndex = 0;
            this.chatTxtBox.Text = "";
            // 
            // userTxtBox
            // 
            this.userTxtBox.Location = new System.Drawing.Point(566, 12);
            this.userTxtBox.Name = "userTxtBox";
            this.userTxtBox.Size = new System.Drawing.Size(246, 400);
            this.userTxtBox.TabIndex = 1;
            this.userTxtBox.Text = "";
            // 
            // msgTxtBox
            // 
            this.msgTxtBox.Location = new System.Drawing.Point(18, 434);
            this.msgTxtBox.Name = "msgTxtBox";
            this.msgTxtBox.Size = new System.Drawing.Size(519, 169);
            this.msgTxtBox.TabIndex = 2;
            this.msgTxtBox.Text = "";
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Location = new System.Drawing.Point(600, 500);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(157, 48);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 629);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.msgTxtBox);
            this.Controls.Add(this.userTxtBox);
            this.Controls.Add(this.chatTxtBox);
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