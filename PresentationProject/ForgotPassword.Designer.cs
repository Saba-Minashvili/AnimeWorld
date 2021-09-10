namespace PresentationProject
{
    partial class ForgotPassword
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
            this.label2 = new System.Windows.Forms.Label();
            this.ForgotPasswordEmailInp = new System.Windows.Forms.TextBox();
            this.EmailErrorMessage = new System.Windows.Forms.Label();
            this.EmailSendSubmitBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.label1.Location = new System.Drawing.Point(50, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reset your password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.Location = new System.Drawing.Point(90, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Enter your email to reset your password :";
            // 
            // ForgotPasswordEmailInp
            // 
            this.ForgotPasswordEmailInp.Location = new System.Drawing.Point(93, 131);
            this.ForgotPasswordEmailInp.Multiline = true;
            this.ForgotPasswordEmailInp.Name = "ForgotPasswordEmailInp";
            this.ForgotPasswordEmailInp.Size = new System.Drawing.Size(263, 21);
            this.ForgotPasswordEmailInp.TabIndex = 2;
            // 
            // EmailErrorMessage
            // 
            this.EmailErrorMessage.AutoSize = true;
            this.EmailErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.EmailErrorMessage.Location = new System.Drawing.Point(90, 115);
            this.EmailErrorMessage.Name = "EmailErrorMessage";
            this.EmailErrorMessage.Size = new System.Drawing.Size(124, 13);
            this.EmailErrorMessage.TabIndex = 3;
            this.EmailErrorMessage.Text = "Email could not be found";
            this.EmailErrorMessage.Visible = false;
            // 
            // EmailSendSubmitBtn
            // 
            this.EmailSendSubmitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.EmailSendSubmitBtn.Location = new System.Drawing.Point(93, 168);
            this.EmailSendSubmitBtn.Name = "EmailSendSubmitBtn";
            this.EmailSendSubmitBtn.Size = new System.Drawing.Size(75, 27);
            this.EmailSendSubmitBtn.TabIndex = 4;
            this.EmailSendSubmitBtn.Text = "Submit";
            this.EmailSendSubmitBtn.UseVisualStyleBackColor = true;
            this.EmailSendSubmitBtn.Click += new System.EventHandler(this.EmailSendSubmitBtn_Click);
            // 
            // ForgotPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 278);
            this.Controls.Add(this.EmailSendSubmitBtn);
            this.Controls.Add(this.EmailErrorMessage);
            this.Controls.Add(this.ForgotPasswordEmailInp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ForgotPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ForgotPassword";
            this.Load += new System.EventHandler(this.ForgotPassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ForgotPasswordEmailInp;
        private System.Windows.Forms.Label EmailErrorMessage;
        private System.Windows.Forms.Button EmailSendSubmitBtn;
    }
}