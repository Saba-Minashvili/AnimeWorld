using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using PresentationProjectDomainDb;
using PresentationProjectDomainModels.Implementation;
using PresentationProjectDomainServices.Abstraction;
using PresentationProjectDomainServices.Implementation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PresentationProject
{
    public partial class Main : Form
    {
        private readonly IApplicationHelperManager _services = default;
        private readonly IAnimeService _animeService = default;
        private Form _mainForm = default;
        private readonly string _allAccountsPath = "allAccounts.json";
        private readonly UserAccount currentUser = default;
        // enter your cloudinary params to let user upload profile imgs
        private readonly Cloudinary _cloud = new Cloudinary(new Account("", "", ""));
        private readonly string _cloudinaryBaseImageUrl = "https://res.cloudinary.com/dkfjpuddb/image/upload/";
        private readonly string accountDbConnectionString = @"Data Source=DESKTOP-0FM65T2;Initial Catalog=Account;Integrated Security=True";
        public Main()
        {
            InitializeComponent();
            _animeService = new AnimeService();
            _services = new ApplicationHelperManager();
            currentUser = _services.GetCurrentUser();
        }

        private void MyApp_Load(object sender, EventArgs e)
        {
            CheckSearchInput();
            SearchAnimeInp.Select();
            var user = currentUser;  
            Username.Text = user.Username;

            var value = "AccountImage";
            var getCurrentUserImageSQL = string.Empty;

            getCurrentUserImageSQL = "Select AccountImage from [AccountTbl] where Username = '" + user.Username + "' AND Password = '" + user.Password + "'";

            var userImageUrl = SQLDatabaseServerConnection.ExecuteSQLByCmd(getCurrentUserImageSQL, accountDbConnectionString, value);
            UserImage.ImageLocation = userImageUrl;

            if(UserImage.Image != null)
            {
                UploadImage.Text = "Change picture";
            }
            else
            {
                UploadImage.Text = default;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateOrShow();
            _services.SignOutUser();
            Username.Text = default;
        }

        private void CreateOrShow()
        {
            if (_mainForm == null || _mainForm.IsDisposed)
            {
                _mainForm = new MainForm();

                _mainForm.FormClosed += ChildFormClosed;
            }

            this.Dispose(true);
            _mainForm.Show();
        }

        void ChildFormClosed(object sender, FormClosedEventArgs args)
        {
            _mainForm.FormClosed -= ChildFormClosed;

            _mainForm = null;
        }

        public bool CheckSearchInput()
        {
            if(SearchAnimeInp.Text == string.Empty)
            {
                GetDataBtn.Enabled = false;
                return true;
            }else
            {
                GetDataBtn.Enabled = true;
                return false;
            }
        }

        public void PrintDataOnView(List<Anime> collection)
        {
            int index1 = 0;
            int index2 = 320;
            int index3 = 0;

            for (var i = 0; i < collection.Count; i++)
            {
                if (i % 3 == 0)
                {
                    GroupBox groupBox = new GroupBox();
                    groupBox.Location = new System.Drawing.Point(73, 330 + index2);
                    groupBox.Size = new System.Drawing.Size(500, 300);
                    groupBox.Text = "";
                    groupBox.Padding = new Padding(3, 3, 3, 3);
                    groupBox.BackColor = Color.LightSkyBlue;
                    if (i == 45 || i == 48)
                    {
                        groupBox.Visible = false;
                    }

                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Location = new System.Drawing.Point(0, 0);
                    pictureBox.ImageLocation = $"{collection[i].ImageUrl}";
                    pictureBox.Size = new System.Drawing.Size(200, 300);
                    pictureBox.SizeMode = PictureBoxSizeMode.Normal;

                    Button favBtn = new Button();
                    favBtn.Location = new System.Drawing.Point(465, 7);
                    favBtn.Size = new System.Drawing.Size(30, 30);
                    favBtn.Text = "+";
                    favBtn.Font = new Font("Microsoft Tai Le", 14, style: FontStyle.Bold);
                    favBtn.TextAlign = ContentAlignment.MiddleCenter;
                    favBtn.BackColor = Color.White;
                    favBtn.MouseClick += favBtn_MouseClick;
                    favBtn.ForeColor = Color.LightGreen;
                    favBtn.TabIndex = Convert.ToInt32(collection[i].Id);

                    Label animeTitle = new Label();
                    animeTitle.Text = $"{collection[i].Title}";
                    animeTitle.Location = new System.Drawing.Point(250, 25);
                    animeTitle.Margin = new Padding(3, 3, 3, 0);
                    animeTitle.Font = new Font("Microsoft Tai Le", 10, style: FontStyle.Bold);
                    animeTitle.Size = new System.Drawing.Size(180, 40);

                    Label animeTitleLabel = new Label();
                    animeTitleLabel.Text = "Title : ";
                    animeTitleLabel.Location = new System.Drawing.Point(215, 25);
                    animeTitleLabel.Margin = new Padding(3, 3, 3, 0);
                    animeTitleLabel.Font = new Font("Microsoft Tai Le", 9, style: FontStyle.Italic);
                    animeTitleLabel.Size = new System.Drawing.Size(247, 17);

                    Label animeType = new Label();
                    animeType.Text = $"{collection[i].Type}";
                    animeType.Location = new System.Drawing.Point(255, 70);
                    animeType.Margin = new Padding(3, 3, 3, 0);
                    animeType.Font = new Font("Microsoft Tai Le", 10, style: FontStyle.Bold);
                    animeType.Size = new System.Drawing.Size(247, 17);

                    Label animeTypeLabel = new Label();
                    animeTypeLabel.Text = "Type : ";
                    animeTypeLabel.Location = new System.Drawing.Point(215, 70);
                    animeTypeLabel.Margin = new Padding(3, 3, 3, 0);
                    animeTypeLabel.Font = new Font("Microsoft Tai Le", 9, style: FontStyle.Italic);
                    animeTypeLabel.Size = new System.Drawing.Size(247, 17);

                    Label animeEpisodes = new Label();
                    animeEpisodes.Text = $"{collection[i].Episodes}";
                    animeEpisodes.Location = new System.Drawing.Point(275, 100);
                    animeEpisodes.Margin = new Padding(3, 3, 3, 0);
                    animeEpisodes.Font = new Font("Microsoft Tai Le", 10, style: FontStyle.Bold);
                    animeEpisodes.Size = new System.Drawing.Size(247, 17);

                    Label animeEpisodesLabel = new Label();
                    animeEpisodesLabel.Text = "Episodes : ";
                    animeEpisodesLabel.Location = new System.Drawing.Point(215, 100);
                    animeEpisodesLabel.Margin = new Padding(3, 3, 3, 0);
                    animeEpisodesLabel.Font = new Font("Microsoft Tai Le", 9, style: FontStyle.Italic);
                    animeEpisodesLabel.Size = new System.Drawing.Size(247, 17);

                    Label animeReleasedDate = new Label();
                    animeReleasedDate.Text = $"{Convert.ToDateTime(collection[i].StartDate)}";
                    animeReleasedDate.Location = new System.Drawing.Point(275, 130);
                    animeReleasedDate.Margin = new Padding(3, 3, 3, 0);
                    animeReleasedDate.Font = new Font("Microsoft Tai Le", 10, style: FontStyle.Bold);
                    animeReleasedDate.Size = new System.Drawing.Size(247, 17);

                    Label animeReleasedDateLabel = new Label();
                    animeReleasedDateLabel.Text = "Released : ";
                    animeReleasedDateLabel.Location = new System.Drawing.Point(215, 130);
                    animeReleasedDateLabel.Margin = new Padding(3, 3, 3, 0);
                    animeReleasedDateLabel.Font = new Font("Microsoft Tai Le", 9, style: FontStyle.Italic);
                    animeReleasedDateLabel.Size = new System.Drawing.Size(247, 17);

                    RichTextBox description = new RichTextBox();
                    description.Text = $"{collection[i].Synopsis}";
                    description.Location = new System.Drawing.Point(290, 160);
                    description.Size = new System.Drawing.Size(180, 160);
                    description.ReadOnly = true;
                    description.BorderStyle = BorderStyle.None;
                    description.ScrollBars = RichTextBoxScrollBars.None;
                    description.BackColor = Color.LightSkyBlue;
                    description.Font = new Font("Microsoft Tai Le", 9, style: FontStyle.Bold);

                    Label descriptionLabel = new Label();
                    descriptionLabel.Text = "Description :  ";
                    descriptionLabel.Location = new System.Drawing.Point(215, 160);
                    descriptionLabel.Margin = new Padding(3, 0, 3, 0);
                    descriptionLabel.Font = new Font("Microsoft Tai Le", 9, style: FontStyle.Italic);
                    descriptionLabel.Size = new System.Drawing.Size(247, 17);

                    this.Controls.Add(groupBox);
                    groupBox.Controls.Add(pictureBox);
                    groupBox.Controls.Add(favBtn);
                    groupBox.Controls.Add(description);
                    groupBox.Controls.Add(descriptionLabel);
                    groupBox.Controls.Add(animeTitle);
                    groupBox.Controls.Add(animeTitleLabel);
                    groupBox.Controls.Add(animeEpisodes);
                    groupBox.Controls.Add(animeEpisodesLabel);
                    groupBox.Controls.Add(animeType);
                    groupBox.Controls.Add(animeTypeLabel);
                    groupBox.Controls.Add(animeReleasedDate);
                    groupBox.Controls.Add(animeReleasedDateLabel);

                    index2 += 320;
                }
                else
                {
                    GroupBox groupBox = new GroupBox();
                    groupBox.Location = new System.Drawing.Point(73 + index1, 330 + index3);
                    groupBox.Size = new System.Drawing.Size(500, 300);
                    groupBox.Text = "";
                    groupBox.Padding = new Padding(3, 3, 3, 3);
                    groupBox.BackColor = Color.LightSkyBlue;
                    if (i == 45 || i == 48)
                    {
                        groupBox.Visible = false;
                    }

                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Location = new System.Drawing.Point(0, 0);
                    pictureBox.Size = new System.Drawing.Size(200, 300);
                    pictureBox.ImageLocation = $"{collection[i].ImageUrl}";
                    pictureBox.SizeMode = PictureBoxSizeMode.Normal;

                    Button favBtn = new Button();
                    favBtn.Location = new System.Drawing.Point(465, 7);
                    favBtn.Size = new System.Drawing.Size(30, 30);
                    favBtn.Text = "+";
                    favBtn.Font = new Font("Microsoft Tai Le", 14, style: FontStyle.Bold);
                    favBtn.TextAlign = ContentAlignment.MiddleCenter;
                    favBtn.MouseClick += favBtn_MouseClick;
                    favBtn.BackColor = Color.White;
                    favBtn.ForeColor = Color.LightGreen;
                    favBtn.TabIndex = Convert.ToInt32(collection[i].Id);

                    Label animeTitle = new Label();
                    animeTitle.Text = $"{collection[i].Title}";
                    animeTitle.Location = new System.Drawing.Point(250, 25);
                    animeTitle.Margin = new Padding(3, 3, 3, 0);
                    animeTitle.Font = new Font("Microsoft Tai Le", 10, style: FontStyle.Bold);
                    animeTitle.Size = new System.Drawing.Size(180, 40);

                    Label animeTitleLabel = new Label();
                    animeTitleLabel.Text = "Title : ";
                    animeTitleLabel.Location = new System.Drawing.Point(215, 25);
                    animeTitleLabel.Margin = new Padding(3, 3, 3, 0);
                    animeTitleLabel.Font = new Font("Microsoft Tai Le", 9, style: FontStyle.Italic);
                    animeTitleLabel.Size = new System.Drawing.Size(247, 17);

                    Label animeType = new Label();
                    animeType.Text = $"{collection[i].Type}";
                    animeType.Location = new System.Drawing.Point(255, 70);
                    animeType.Margin = new Padding(3, 3, 3, 0);
                    animeType.Font = new Font("Microsoft Tai Le", 10, style: FontStyle.Bold);
                    animeType.Size = new System.Drawing.Size(247, 17);

                    Label animeTypeLabel = new Label();
                    animeTypeLabel.Text = "Type : ";
                    animeTypeLabel.Location = new System.Drawing.Point(215, 70);
                    animeTypeLabel.Margin = new Padding(3, 3, 3, 0);
                    animeTypeLabel.Font = new Font("Microsoft Tai Le", 9, style: FontStyle.Italic);
                    animeTypeLabel.Size = new System.Drawing.Size(247, 17);

                    Label animeEpisodes = new Label();
                    animeEpisodes.Text = $"{collection[i].Episodes}";
                    animeEpisodes.Location = new System.Drawing.Point(275, 100);
                    animeEpisodes.Margin = new Padding(3, 3, 3, 0);
                    animeEpisodes.Font = new Font("Microsoft Tai Le", 10, style: FontStyle.Bold);
                    animeEpisodes.Size = new System.Drawing.Size(247, 17);

                    Label animeEpisodesLabel = new Label();
                    animeEpisodesLabel.Text = "Episodes : ";
                    animeEpisodesLabel.Location = new System.Drawing.Point(215, 100);
                    animeEpisodesLabel.Margin = new Padding(3, 3, 3, 0);
                    animeEpisodesLabel.Font = new Font("Microsoft Tai Le", 9, style: FontStyle.Italic);
                    animeEpisodesLabel.Size = new System.Drawing.Size(247, 17);

                    Label animeReleasedDate = new Label();
                    animeReleasedDate.Text = $"{Convert.ToDateTime(collection[i].StartDate)}";
                    animeReleasedDate.Location = new System.Drawing.Point(275, 130);
                    animeReleasedDate.Margin = new Padding(3, 3, 3, 0);
                    animeReleasedDate.Font = new Font("Microsoft Tai Le", 10, style: FontStyle.Bold);
                    animeReleasedDate.Size = new System.Drawing.Size(247, 17);

                    Label animeReleasedDateLabel = new Label();
                    animeReleasedDateLabel.Text = "Released : ";
                    animeReleasedDateLabel.Location = new System.Drawing.Point(215, 130);
                    animeReleasedDateLabel.Margin = new Padding(3, 3, 3, 0);
                    animeReleasedDateLabel.Font = new Font("Microsoft Tai Le", 9, style: FontStyle.Italic);
                    animeReleasedDateLabel.Size = new System.Drawing.Size(247, 17);

                    RichTextBox description = new RichTextBox();
                    description.Text = $"{collection[i].Synopsis}";
                    description.Location = new System.Drawing.Point(290, 160);
                    description.Size = new System.Drawing.Size(180, 160);
                    description.ReadOnly = true;
                    description.ScrollBars = RichTextBoxScrollBars.None;
                    description.BackColor = Color.LightSkyBlue;
                    description.BorderStyle = BorderStyle.None;
                    description.Font = new Font("Microsoft Tai Le", 9, style: FontStyle.Bold);

                    Label descriptionLabel = new Label();
                    descriptionLabel.Text = "Description :  ";
                    descriptionLabel.Location = new System.Drawing.Point(215, 160);
                    descriptionLabel.Margin = new Padding(3, 0, 3, 0);
                    descriptionLabel.Font = new Font("Microsoft Tai Le", 9, style: FontStyle.Italic);
                    descriptionLabel.Size = new System.Drawing.Size(247, 17);


                    this.Controls.Add(groupBox);
                    groupBox.Controls.Add(pictureBox);
                    groupBox.Controls.Add(favBtn);
                    groupBox.Controls.Add(description);
                    groupBox.Controls.Add(descriptionLabel);
                    groupBox.Controls.Add(animeTitle);
                    groupBox.Controls.Add(animeTitleLabel);
                    groupBox.Controls.Add(animeEpisodes);
                    groupBox.Controls.Add(animeEpisodesLabel);
                    groupBox.Controls.Add(animeType);
                    groupBox.Controls.Add(animeTypeLabel);
                    groupBox.Controls.Add(animeReleasedDate);
                    groupBox.Controls.Add(animeReleasedDateLabel);

                    if (index1 == 1220)
                    {
                        index1 = 0;
                    }

                    index1 += 610;
                    if (i > 3 & (i - 1) % 3 == 0)
                    {
                        index3 += 320;
                    }
                }
            }
        }
        public void GetDataFromApi()
        {
            var animeName = SearchAnimeInp.Text;
            var data = _animeService.GetAnimeData(animeName.ToLower()).ToList();

            PrintDataOnView(data);
        }
        public void GetRandomDataFromApi()
        {
            string[] animeNames = { "naruto", "black clover", "attack on titan", "boruto", "one piece", "darlin in the franxx", "my hero academia", "invaded"};
            var getRandAnime = new Random();
            var randAnime = animeNames[getRandAnime.Next(animeNames.Length)];
            var data = _animeService.GetAnimeData(randAnime).ToList();

            int index1 = 0;
            int index2 = 320;
            int index3 = 0;

            for (var i = 0; i < data.Count; i++)
            {
                if (i % 3 == 0)
                {
                    GroupBox groupBox = new GroupBox();

                    groupBox.Location = new System.Drawing.Point(73, 200 + index2);
                    groupBox.Size = new System.Drawing.Size(586, 300);
                    groupBox.Text = "";
                    groupBox.Padding = new Padding(3, 3, 3, 3);
                    groupBox.BackColor = Color.FromArgb(255, 153, 102);
                    if (i == 45 || i == 48)
                    {
                        groupBox.Visible = false;
                    }

                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Location = new System.Drawing.Point(0, 0);
                    pictureBox.Size = new System.Drawing.Size(250, 303);
                    pictureBox.ImageLocation = $"{data[i].ImageUrl}";
                    pictureBox.BackgroundImageLayout = ImageLayout.Stretch;

                    Button favBtn = new Button();
                    favBtn.Location = new System.Drawing.Point(256, 250);
                    favBtn.Size = new System.Drawing.Size(151, 23);
                    favBtn.Text = "Add to favorites";
                    favBtn.Font = new Font("Microsoft Tai Le", 8, style: FontStyle.Bold);
                    favBtn.BackColor = Color.GreenYellow;
                    favBtn.ForeColor = Color.FromArgb(121, 30, 219);
                    favBtn.TabIndex = Convert.ToInt32(data[i].Id);

                    Label label = new Label();
                    label.Text = $"{data[i].Title}";
                    label.Location = new System.Drawing.Point(256, 48);
                    label.Margin = new Padding(3, 0, 3, 0);
                    label.Font = new Font("Microsoft Tai Le", 12, style: FontStyle.Bold);
                    label.Size = new System.Drawing.Size(247, 17);

                    RichTextBox description = new RichTextBox();
                    description.Text = $"{data[i].Synopsis}";
                    description.Location = new System.Drawing.Point(256, 110);
                    description.Size = new System.Drawing.Size(236, 140);
                    description.ReadOnly = true;
                    description.BorderStyle = BorderStyle.None;
                    description.ScrollBars = RichTextBoxScrollBars.None;
                    description.BackColor = Color.FromArgb(255, 153, 102);
                    description.Font = new Font("Microsoft Tai Le", 10, style: FontStyle.Italic);

                    this.Controls.Add(groupBox);
                    groupBox.Controls.Add(pictureBox);
                    groupBox.Controls.Add(label);
                    groupBox.Controls.Add(description);
                    groupBox.Controls.Add(favBtn);

                    index2 += 320;
                }
                else
                {
                    GroupBox groupBox = new GroupBox();
                    groupBox.Location = new System.Drawing.Point(73 + index1, 200 + index3);
                    groupBox.Size = new System.Drawing.Size(586, 300);
                    groupBox.Text = "";
                    groupBox.Padding = new Padding(3, 3, 3, 3);
                    groupBox.BackColor = Color.FromArgb(255, 153, 102);
                    if (i == 45 || i == 48)
                    {
                        groupBox.Visible = false;
                    }

                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Location = new System.Drawing.Point(0, 0);
                    pictureBox.Size = new System.Drawing.Size(250, 303);
                    pictureBox.ImageLocation = $"{data[i].ImageUrl}";
                    pictureBox.BackgroundImageLayout = ImageLayout.Stretch;

                    Button favBtn = new Button();
                    favBtn.Location = new System.Drawing.Point(256, 250);
                    favBtn.Size = new System.Drawing.Size(151, 23);
                    favBtn.Text = "Add to favorites";
                    favBtn.Font = new Font("Microsoft Tai Le", 8, style: FontStyle.Bold);
                    favBtn.BackColor = Color.GreenYellow;
                    favBtn.ForeColor = Color.FromArgb(121, 30, 219);
                    favBtn.TabIndex = Convert.ToInt32(data[i].Id);

                    Label label = new Label();
                    label.Text = $"{data[i].Title}";
                    label.Location = new System.Drawing.Point(256, 48);
                    label.Margin = new Padding(3, 0, 3, 0);
                    label.Font = new Font("Microsoft Tai Le", 12, style: FontStyle.Bold);
                    label.Size = new System.Drawing.Size(247, 17);

                    RichTextBox description = new RichTextBox();
                    description.Text = $"{data[i].Synopsis}";
                    description.Location = new System.Drawing.Point(256, 110);
                    description.Size = new System.Drawing.Size(298, 140);
                    description.ReadOnly = true;
                    description.ScrollBars = RichTextBoxScrollBars.None;
                    description.BackColor = Color.FromArgb(255, 153, 102);
                    description.BorderStyle = BorderStyle.None;
                    description.Font = new Font("Microsoft Tai Le", 10, style: FontStyle.Italic);

                    this.Controls.Add(groupBox);
                    groupBox.Controls.Add(pictureBox);
                    groupBox.Controls.Add(label);
                    groupBox.Controls.Add(description);
                    groupBox.Controls.Add(favBtn);

                    if (index1 == 1220)
                    {
                        index1 = 0;
                    }

                    index1 += 610;
                    if (i > 3 & (i - 1) % 3 == 0)
                    {
                        index3 += 320;
                    }
                }
            }
        }

        private void GetDataBtn_Click(object sender, EventArgs e)
        {
            CheckSearchInput();
            GetDataFromApi();
            SearchAnimeInp.Text = string.Empty;
        }

        public List<Anime> GetFavoriteAnimes()
        {
            var user = currentUser;
            var favAnimes = user.FavoriteAnimes;

            return favAnimes;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if(PreClosingConfirmation() == DialogResult.Yes)
            {
                this.Dispose(true);
                Application.ExitThread();
            }else
            {
                e.Cancel = true;
            }
        }

        private DialogResult PreClosingConfirmation()
        {
            DialogResult res = MessageBox.Show("Do you want to exit ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return res;
        }

        private void SearchAnimeInp_TextChanged(object sender, EventArgs e)
        {
            CheckSearchInput();
        }
        private void SearchAnimeInp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                CheckSearchInput();
                GetDataFromApi();
            }
        }

        public bool CheckFavAnimeExist(long id)
        {
            var user = currentUser;
            var userFavAnimes = user.FavoriteAnimesIds;
            foreach (var animeId in userFavAnimes)
            {
                if (animeId == id)
                {
                    return true;
                }
            }

            return false;
        }

        private void favBtn_MouseClick(object sender, MouseEventArgs e)
        {
            var id = (sender as Button).TabIndex;
            var user = currentUser;
            var currentFavAnime = _animeService.GetSingleAnimeData(id);
            var currentFavAnimeTitle = currentFavAnime.Title;
            if (!CheckFavAnimeExist(id))
            {
                user.FavoriteAnimesIds.Add(id);
                user.FavoriteAnimes.Add(currentFavAnime);
                DbFileWorkerService.WriteInFile(user, _allAccountsPath, false);
                MessageBox.Show($"'{currentFavAnimeTitle}' was successfully added to the favorites");
                (sender as Button).Enabled = false;
            }
            else
            {
                MessageBox.Show("This anime is already on your favorites list ", "", MessageBoxButtons.OK);
            }
        }

        private void FavoriteAnimesBtn_Click(object sender, EventArgs e)
        {
            Form favAnimeListForm = new FavoriteAnimeList();
            favAnimeListForm.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var imageLocation = string.Empty;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png files(*.png)|*.png|jgp files(*.jpg)|*.jpg|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK && MessageBox.Show("are you sure you want to upload it?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var user = currentUser;
                imageLocation = dialog.FileName;
                Image img = new Bitmap(imageLocation);

                var imageUpload = new ImageUploadParams()
                {
                    File = new FileDescription(imageLocation),
                    PublicId = imageLocation.Split('\\').LastOrDefault().Split('.').FirstOrDefault()
                };

                var cloudinaryFullImageUrl = $"{_cloudinaryBaseImageUrl}{imageLocation.Split('\\').LastOrDefault()}";


                string mySQL = string.Empty;

                mySQL += "SELECT * FROM AccountTbl ";
                mySQL += "WHERE Username = '" + user.Username + "'";
                mySQL += "AND Password = '" + user.Password + "'";

                DataTable accountData = SQLDatabaseServerConnection.ExecuteSQL(mySQL, accountDbConnectionString);

                user.AccountImage = cloudinaryFullImageUrl;

                if (accountData.Rows.Count > 0)
                {
                    string userImageSQL = string.Empty;

                    userImageSQL += "UPDATE AccountTbl SET AccountImage = '" + user.AccountImage + "'";
                    userImageSQL += "WHERE Username = '" + user.Username + "' AND Password = '" + user.Password + "'";

                    SQLDatabaseServerConnection.ExecuteSQL(userImageSQL, accountDbConnectionString);
                    UserImage.Image = new Bitmap(img, UserImage.Width, UserImage.Height);
                    _cloud.Upload(imageUpload);
                    MessageBox.Show("The picture was successfully uploaded", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                return;
            }
        }

        private void UserImage_Click(object sender, EventArgs e)
        {

        }
    }
}
