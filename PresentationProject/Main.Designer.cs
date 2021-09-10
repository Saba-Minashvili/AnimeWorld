namespace PresentationProject
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.SignOut = new System.Windows.Forms.Button();
            this.GetDataBtn = new System.Windows.Forms.Button();
            this.SearchAnimeInp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FavoriteAnimesBtn = new System.Windows.Forms.Button();
            this.UserImage = new System.Windows.Forms.PictureBox();
            this.Username = new System.Windows.Forms.Label();
            this.UploadImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.UserImage)).BeginInit();
            this.SuspendLayout();
            // 
            // SignOut
            // 
            this.SignOut.AutoSize = true;
            this.SignOut.BackColor = System.Drawing.Color.Transparent;
            this.SignOut.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.SignOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.SignOut.ForeColor = System.Drawing.Color.Black;
            this.SignOut.Location = new System.Drawing.Point(1714, 22);
            this.SignOut.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.SignOut.Name = "SignOut";
            this.SignOut.Size = new System.Drawing.Size(163, 44);
            this.SignOut.TabIndex = 0;
            this.SignOut.Text = "Sign Out";
            this.SignOut.UseVisualStyleBackColor = false;
            this.SignOut.Click += new System.EventHandler(this.button1_Click);
            // 
            // GetDataBtn
            // 
            this.GetDataBtn.AutoSize = true;
            this.GetDataBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.GetDataBtn.Location = new System.Drawing.Point(633, 149);
            this.GetDataBtn.Name = "GetDataBtn";
            this.GetDataBtn.Size = new System.Drawing.Size(215, 33);
            this.GetDataBtn.TabIndex = 4;
            this.GetDataBtn.Text = "Search";
            this.GetDataBtn.UseVisualStyleBackColor = true;
            this.GetDataBtn.Click += new System.EventHandler(this.GetDataBtn_Click);
            // 
            // SearchAnimeInp
            // 
            this.SearchAnimeInp.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.SearchAnimeInp.Location = new System.Drawing.Point(633, 93);
            this.SearchAnimeInp.Multiline = true;
            this.SearchAnimeInp.Name = "SearchAnimeInp";
            this.SearchAnimeInp.Size = new System.Drawing.Size(442, 28);
            this.SearchAnimeInp.TabIndex = 6;
            this.SearchAnimeInp.TextChanged += new System.EventHandler(this.SearchAnimeInp_TextChanged);
            this.SearchAnimeInp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SearchAnimeInp_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label1.Location = new System.Drawing.Point(628, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Enter Anime Name";
            // 
            // FavoriteAnimesBtn
            // 
            this.FavoriteAnimesBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.FavoriteAnimesBtn.Location = new System.Drawing.Point(39, 222);
            this.FavoriteAnimesBtn.Name = "FavoriteAnimesBtn";
            this.FavoriteAnimesBtn.Size = new System.Drawing.Size(215, 44);
            this.FavoriteAnimesBtn.TabIndex = 8;
            this.FavoriteAnimesBtn.Text = "My Favorite Animes";
            this.FavoriteAnimesBtn.UseVisualStyleBackColor = true;
            this.FavoriteAnimesBtn.Click += new System.EventHandler(this.FavoriteAnimesBtn_Click);
            // 
            // UserImage
            // 
            this.UserImage.AccessibleDescription = "";
            this.UserImage.AccessibleName = "";
            this.UserImage.BackColor = System.Drawing.Color.Silver;
            this.UserImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UserImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UserImage.Image = ((System.Drawing.Image)(resources.GetObject("UserImage.Image")));
            this.UserImage.Location = new System.Drawing.Point(39, 22);
            this.UserImage.Name = "UserImage";
            this.UserImage.Size = new System.Drawing.Size(185, 171);
            this.UserImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.UserImage.TabIndex = 9;
            this.UserImage.TabStop = false;
            this.UserImage.Click += new System.EventHandler(this.UserImage_Click);
            // 
            // Username
            // 
            this.Username.AutoSize = true;
            this.Username.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username.Location = new System.Drawing.Point(257, 22);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(98, 25);
            this.Username.TabIndex = 10;
            this.Username.Text = "unknown";
            // 
            // UploadImage
            // 
            this.UploadImage.Location = new System.Drawing.Point(262, 170);
            this.UploadImage.Name = "UploadImage";
            this.UploadImage.Size = new System.Drawing.Size(109, 23);
            this.UploadImage.TabIndex = 11;
            this.UploadImage.Text = "Upload picture";
            this.UploadImage.UseVisualStyleBackColor = true;
            this.UploadImage.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.UploadImage);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.UserImage);
            this.Controls.Add(this.FavoriteAnimesBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SearchAnimeInp);
            this.Controls.Add(this.GetDataBtn);
            this.Controls.Add(this.SignOut);
            this.Name = "Main";
            this.Text = "Anime World ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MyApp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UserImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SignOut;
        private System.Windows.Forms.Button GetDataBtn;
        private System.Windows.Forms.TextBox SearchAnimeInp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button FavoriteAnimesBtn;
        private System.Windows.Forms.PictureBox UserImage;
        private System.Windows.Forms.Label Username;
        private System.Windows.Forms.Button UploadImage;
    }
}