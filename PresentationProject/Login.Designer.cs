namespace PresentationProject
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.PasswordInp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.UsernameInp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SignInBtn = new System.Windows.Forms.Button();
            this.CreateAccount = new System.Windows.Forms.LinkLabel();
            this.ShowPasswordCheckBox = new System.Windows.Forms.CheckBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ForgotPasswordBtn = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // PasswordInp
            // 
            this.PasswordInp.Font = new System.Drawing.Font("Courier New", 12F);
            this.PasswordInp.ForeColor = System.Drawing.Color.Purple;
            this.PasswordInp.Location = new System.Drawing.Point(79, 274);
            this.PasswordInp.Multiline = true;
            this.PasswordInp.Name = "PasswordInp";
            this.PasswordInp.PasswordChar = '*';
            this.PasswordInp.Size = new System.Drawing.Size(278, 24);
            this.PasswordInp.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(74, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(74, 235);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Password";
            // 
            // UsernameInp
            // 
            this.UsernameInp.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameInp.ForeColor = System.Drawing.Color.Purple;
            this.UsernameInp.Location = new System.Drawing.Point(79, 184);
            this.UsernameInp.Multiline = true;
            this.UsernameInp.Name = "UsernameInp";
            this.UsernameInp.Size = new System.Drawing.Size(278, 24);
            this.UsernameInp.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.25F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(132, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 44);
            this.label2.TabIndex = 7;
            this.label2.Text = "Welcome";
            // 
            // SignInBtn
            // 
            this.SignInBtn.BackColor = System.Drawing.Color.White;
            this.SignInBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.SignInBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SignInBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.SignInBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.SignInBtn.ForeColor = System.Drawing.Color.Purple;
            this.SignInBtn.Location = new System.Drawing.Point(79, 360);
            this.SignInBtn.Name = "SignInBtn";
            this.SignInBtn.Size = new System.Drawing.Size(127, 40);
            this.SignInBtn.TabIndex = 8;
            this.SignInBtn.Text = "Sign in";
            this.SignInBtn.UseVisualStyleBackColor = false;
            this.SignInBtn.Click += new System.EventHandler(this.SignInBtn_Click);
            // 
            // CreateAccount
            // 
            this.CreateAccount.ActiveLinkColor = System.Drawing.Color.Purple;
            this.CreateAccount.AutoSize = true;
            this.CreateAccount.BackColor = System.Drawing.Color.Transparent;
            this.CreateAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CreateAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Italic);
            this.CreateAccount.ForeColor = System.Drawing.Color.Transparent;
            this.CreateAccount.LinkColor = System.Drawing.Color.Transparent;
            this.CreateAccount.LinkVisited = true;
            this.CreateAccount.Location = new System.Drawing.Point(75, 424);
            this.CreateAccount.Name = "CreateAccount";
            this.CreateAccount.Size = new System.Drawing.Size(123, 20);
            this.CreateAccount.TabIndex = 10;
            this.CreateAccount.TabStop = true;
            this.CreateAccount.Text = "Create account";
            this.CreateAccount.VisitedLinkColor = System.Drawing.Color.White;
            this.CreateAccount.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.CreateAccount_LinkClicked);
            // 
            // ShowPasswordCheckBox
            // 
            this.ShowPasswordCheckBox.AutoSize = true;
            this.ShowPasswordCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.ShowPasswordCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.ShowPasswordCheckBox.ForeColor = System.Drawing.Color.White;
            this.ShowPasswordCheckBox.Location = new System.Drawing.Point(221, 318);
            this.ShowPasswordCheckBox.Name = "ShowPasswordCheckBox";
            this.ShowPasswordCheckBox.Size = new System.Drawing.Size(136, 22);
            this.ShowPasswordCheckBox.TabIndex = 11;
            this.ShowPasswordCheckBox.Text = "Show Password";
            this.ShowPasswordCheckBox.UseVisualStyleBackColor = false;
            this.ShowPasswordCheckBox.CheckedChanged += new System.EventHandler(this.ShowPasswordCheckBox_CheckedChanged);
            // 
            // CancelButton
            // 
            this.CancelButton.BackColor = System.Drawing.Color.Transparent;
            this.CancelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.CancelButton.ForeColor = System.Drawing.Color.Purple;
            this.CancelButton.Location = new System.Drawing.Point(230, 360);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(127, 40);
            this.CancelButton.TabIndex = 12;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ForgotPasswordBtn
            // 
            this.ForgotPasswordBtn.ActiveLinkColor = System.Drawing.Color.Purple;
            this.ForgotPasswordBtn.AutoSize = true;
            this.ForgotPasswordBtn.BackColor = System.Drawing.Color.Transparent;
            this.ForgotPasswordBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ForgotPasswordBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Italic);
            this.ForgotPasswordBtn.ForeColor = System.Drawing.Color.Transparent;
            this.ForgotPasswordBtn.LinkColor = System.Drawing.Color.Transparent;
            this.ForgotPasswordBtn.LinkVisited = true;
            this.ForgotPasswordBtn.Location = new System.Drawing.Point(74, 301);
            this.ForgotPasswordBtn.Name = "ForgotPasswordBtn";
            this.ForgotPasswordBtn.Size = new System.Drawing.Size(143, 20);
            this.ForgotPasswordBtn.TabIndex = 13;
            this.ForgotPasswordBtn.TabStop = true;
            this.ForgotPasswordBtn.Text = "Forgot password?";
            this.ForgotPasswordBtn.VisitedLinkColor = System.Drawing.Color.White;
            this.ForgotPasswordBtn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ForgotPasswordBtn_LinkClicked);
            // 
            // MainForm
            // 
            this.AcceptButton = this.SignInBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(998, 574);
            this.Controls.Add(this.ForgotPasswordBtn);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ShowPasswordCheckBox);
            this.Controls.Add(this.CreateAccount);
            this.Controls.Add(this.SignInBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UsernameInp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PasswordInp);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Anime World ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox PasswordInp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox UsernameInp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SignInBtn;
        private System.Windows.Forms.LinkLabel CreateAccount;
        private System.Windows.Forms.CheckBox ShowPasswordCheckBox;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.LinkLabel ForgotPasswordBtn;
    }
}

