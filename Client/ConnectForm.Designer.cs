namespace Client
{
    partial class ConnectForm
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
      this.lblIPAdress = new System.Windows.Forms.Label();
      this.txtBoxIPAddress = new System.Windows.Forms.TextBox();
      this.lblUserName = new System.Windows.Forms.Label();
      this.txtBoxUserName = new System.Windows.Forms.TextBox();
      this.btnSubmit = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // lblIPAdress
      // 
      this.lblIPAdress.AutoSize = true;
      this.lblIPAdress.Font = new System.Drawing.Font("Times New Roman", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblIPAdress.Location = new System.Drawing.Point(6, 5);
      this.lblIPAdress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.lblIPAdress.Name = "lblIPAdress";
      this.lblIPAdress.Size = new System.Drawing.Size(103, 16);
      this.lblIPAdress.TabIndex = 0;
      this.lblIPAdress.Text = "Enter IP Address";
      // 
      // txtBoxIPAddress
      // 
      this.txtBoxIPAddress.Location = new System.Drawing.Point(9, 22);
      this.txtBoxIPAddress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.txtBoxIPAddress.Name = "txtBoxIPAddress";
      this.txtBoxIPAddress.Size = new System.Drawing.Size(172, 20);
      this.txtBoxIPAddress.TabIndex = 1;
      this.txtBoxIPAddress.Text = "localhost";
      // 
      // lblUserName
      // 
      this.lblUserName.AutoSize = true;
      this.lblUserName.Font = new System.Drawing.Font("Times New Roman", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblUserName.Location = new System.Drawing.Point(9, 42);
      this.lblUserName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.lblUserName.Name = "lblUserName";
      this.lblUserName.Size = new System.Drawing.Size(105, 16);
      this.lblUserName.TabIndex = 2;
      this.lblUserName.Text = "Enter User Name";
      // 
      // txtBoxUserName
      // 
      this.txtBoxUserName.Location = new System.Drawing.Point(9, 60);
      this.txtBoxUserName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.txtBoxUserName.Name = "txtBoxUserName";
      this.txtBoxUserName.Size = new System.Drawing.Size(172, 20);
      this.txtBoxUserName.TabIndex = 3;
      this.txtBoxUserName.Text = "HardlyDifficult";
      // 
      // btnSubmit
      // 
      this.btnSubmit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnSubmit.Location = new System.Drawing.Point(98, 97);
      this.btnSubmit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.btnSubmit.Name = "btnSubmit";
      this.btnSubmit.Size = new System.Drawing.Size(81, 27);
      this.btnSubmit.TabIndex = 4;
      this.btnSubmit.Text = "Submit";
      this.btnSubmit.UseVisualStyleBackColor = true;
      this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
      // 
      // ConnectForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(287, 145);
      this.Controls.Add(this.btnSubmit);
      this.Controls.Add(this.txtBoxUserName);
      this.Controls.Add(this.lblUserName);
      this.Controls.Add(this.txtBoxIPAddress);
      this.Controls.Add(this.lblIPAdress);
      this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.Name = "ConnectForm";
      this.Text = "Form1";
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIPAdress;
        private System.Windows.Forms.TextBox txtBoxIPAddress;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtBoxUserName;
        private System.Windows.Forms.Button btnSubmit;
    }
}

