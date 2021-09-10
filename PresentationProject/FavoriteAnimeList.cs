using PresentationProjectDomainDb;
using PresentationProjectDomainModels.Implementation;
using PresentationProjectDomainServices.Abstraction;
using PresentationProjectDomainServices.Implementation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationProject
{
    public partial class FavoriteAnimeList : Form
    {
        private readonly UserAccount currentUser = default;
        private readonly IApplicationHelperManager _services = default;
        private readonly string _allAccountsPath = "allAccounts.json";

        public FavoriteAnimeList()
        {
            InitializeComponent();
            _services = new ApplicationHelperManager();
            currentUser = _services.GetCurrentUser();
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
                    groupBox.Location = new Point(73, 300 + index2);
                    groupBox.Size = new Size(500, 300);
                    groupBox.Text = "";
                    groupBox.Padding = new Padding(3, 3, 3, 3);
                    groupBox.BackColor = Color.LightSkyBlue;
                    if (i == 45 || i == 48)
                    {
                        groupBox.Visible = false;
                    }

                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Location = new Point(0, 0);
                    pictureBox.ImageLocation = $"{collection[i].ImageUrl}";
                    pictureBox.Size = new Size(200, 300);
                    pictureBox.SizeMode = PictureBoxSizeMode.Normal;

                    Button delBtn = new Button();
                    delBtn.Location = new Point(465, 7);
                    delBtn.Size = new Size(30, 30);
                    delBtn.Text = "-";
                    delBtn.Font = new Font("Microsoft Tai Le", 14, style: FontStyle.Bold);
                    delBtn.TextAlign = ContentAlignment.MiddleCenter;
                    delBtn.BackColor = Color.White;
                    delBtn.MouseClick += delBtn_MouseClick;
                    delBtn.ForeColor = Color.Red;
                    delBtn.TabIndex = Convert.ToInt32(collection[i].Id);

                    Label animeTitle = new Label();
                    animeTitle.Text = $"{collection[i].Title}";
                    animeTitle.Location = new Point(250, 25);
                    animeTitle.Margin = new Padding(3, 3, 3, 0);
                    animeTitle.Font = new Font("Microsoft Tai Le", 10, style: FontStyle.Bold);
                    animeTitle.Size = new Size(180, 40);

                    Label animeTitleLabel = new Label();
                    animeTitleLabel.Text = "Title : ";
                    animeTitleLabel.Location = new Point(215, 25);
                    animeTitleLabel.Margin = new Padding(3, 3, 3, 0);
                    animeTitleLabel.Font = new Font("Microsoft Tai Le", 9, style: FontStyle.Italic);
                    animeTitleLabel.Size = new Size(247, 17);

                    Label animeType = new Label();
                    animeType.Text = $"{collection[i].Type}";
                    animeType.Location = new Point(255, 70);
                    animeType.Margin = new Padding(3, 3, 3, 0);
                    animeType.Font = new Font("Microsoft Tai Le", 10, style: FontStyle.Bold);
                    animeType.Size = new Size(247, 17);

                    Label animeTypeLabel = new Label();
                    animeTypeLabel.Text = "Type : ";
                    animeTypeLabel.Location = new Point(215, 70);
                    animeTypeLabel.Margin = new Padding(3, 3, 3, 0);
                    animeTypeLabel.Font = new Font("Microsoft Tai Le", 9, style: FontStyle.Italic);
                    animeTypeLabel.Size = new Size(247, 17);

                    Label animeEpisodes = new Label();
                    animeEpisodes.Text = $"{collection[i].Episodes}";
                    animeEpisodes.Location = new Point(275, 100);
                    animeEpisodes.Margin = new Padding(3, 3, 3, 0);
                    animeEpisodes.Font = new Font("Microsoft Tai Le", 10, style: FontStyle.Bold);
                    animeEpisodes.Size = new Size(247, 17);

                    Label animeEpisodesLabel = new Label();
                    animeEpisodesLabel.Text = "Episodes : ";
                    animeEpisodesLabel.Location = new Point(215, 100);
                    animeEpisodesLabel.Margin = new Padding(3, 3, 3, 0);
                    animeEpisodesLabel.Font = new Font("Microsoft Tai Le", 9, style: FontStyle.Italic);
                    animeEpisodesLabel.Size = new Size(247, 17);

                    Label animeReleasedDate = new Label();
                    animeReleasedDate.Text = $"{Convert.ToDateTime(collection[i].StartDate)}";
                    animeReleasedDate.Location = new Point(275, 130);
                    animeReleasedDate.Margin = new Padding(3, 3, 3, 0);
                    animeReleasedDate.Font = new Font("Microsoft Tai Le", 10, style: FontStyle.Bold);
                    animeReleasedDate.Size = new Size(247, 17);

                    Label animeReleasedDateLabel = new Label();
                    animeReleasedDateLabel.Text = "Released : ";
                    animeReleasedDateLabel.Location = new Point(215, 130);
                    animeReleasedDateLabel.Margin = new Padding(3, 3, 3, 0);
                    animeReleasedDateLabel.Font = new Font("Microsoft Tai Le", 9, style: FontStyle.Italic);
                    animeReleasedDateLabel.Size = new Size(247, 17);

                    RichTextBox description = new RichTextBox();
                    description.Text = $"{collection[i].Synopsis}";
                    description.Location = new Point(290, 160);
                    description.Size = new Size(180, 160);
                    description.ReadOnly = true;
                    description.BorderStyle = BorderStyle.None;
                    description.ScrollBars = RichTextBoxScrollBars.None;
                    description.BackColor = Color.LightSkyBlue;
                    description.Font = new Font("Microsoft Tai Le", 8, style: FontStyle.Bold);

                    Label descriptionLabel = new Label();
                    descriptionLabel.Text = "Description :  ";
                    descriptionLabel.Location = new Point(215, 160);
                    descriptionLabel.Margin = new Padding(3, 0, 3, 0);
                    descriptionLabel.Font = new Font("Microsoft Tai Le", 9, style: FontStyle.Italic);
                    descriptionLabel.Size = new Size(247, 17);

                    this.Controls.Add(groupBox);
                    groupBox.Controls.Add(pictureBox);
                    groupBox.Controls.Add(delBtn);
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
                    groupBox.Location = new Point(73 + index1, 300 + index3);
                    groupBox.Size = new Size(500, 300);
                    groupBox.Text = "";
                    groupBox.Padding = new Padding(3, 3, 3, 3);
                    groupBox.BackColor = Color.LightSkyBlue;
                    if (i == 45 || i == 48)
                    {
                        groupBox.Visible = false;
                    }

                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Location = new Point(0, 0);
                    pictureBox.Size = new Size(200, 300);
                    pictureBox.ImageLocation = $"{collection[i].ImageUrl}";
                    pictureBox.SizeMode = PictureBoxSizeMode.Normal;

                    Button delBtn = new Button();
                    delBtn.Location = new Point(465, 7);
                    delBtn.Size = new Size(30, 30);
                    delBtn.Text = "-";
                    delBtn.Font = new Font("Microsoft Tai Le", 14, style: FontStyle.Bold);
                    delBtn.TextAlign = ContentAlignment.MiddleCenter;
                    delBtn.BackColor = Color.White;
                    delBtn.MouseClick += delBtn_MouseClick;
                    delBtn.ForeColor = Color.Red;
                    delBtn.TabIndex = Convert.ToInt32(collection[i].Id);

                    Label animeTitle = new Label();
                    animeTitle.Text = $"{collection[i].Title}";
                    animeTitle.Location = new Point(250, 25);
                    animeTitle.Margin = new Padding(3, 3, 3, 0);
                    animeTitle.Font = new Font("Microsoft Tai Le", 10, style: FontStyle.Bold);
                    animeTitle.Size = new Size(180, 40);

                    Label animeTitleLabel = new Label();
                    animeTitleLabel.Text = "Title : ";
                    animeTitleLabel.Location = new Point(215, 25);
                    animeTitleLabel.Margin = new Padding(3, 3, 3, 0);
                    animeTitleLabel.Font = new Font("Microsoft Tai Le", 9, style: FontStyle.Italic);
                    animeTitleLabel.Size = new Size(247, 17);

                    Label animeType = new Label();
                    animeType.Text = $"{collection[i].Type}";
                    animeType.Location = new Point(255, 70);
                    animeType.Margin = new Padding(3, 3, 3, 0);
                    animeType.Font = new Font("Microsoft Tai Le", 10, style: FontStyle.Bold);
                    animeType.Size = new Size(247, 17);

                    Label animeTypeLabel = new Label();
                    animeTypeLabel.Text = "Type : ";
                    animeTypeLabel.Location = new Point(215, 70);
                    animeTypeLabel.Margin = new Padding(3, 3, 3, 0);
                    animeTypeLabel.Font = new Font("Microsoft Tai Le", 9, style: FontStyle.Italic);
                    animeTypeLabel.Size = new Size(247, 17);

                    Label animeEpisodes = new Label();
                    animeEpisodes.Text = $"{collection[i].Episodes}";
                    animeEpisodes.Location = new Point(275, 100);
                    animeEpisodes.Margin = new Padding(3, 3, 3, 0);
                    animeEpisodes.Font = new Font("Microsoft Tai Le", 10, style: FontStyle.Bold);
                    animeEpisodes.Size = new Size(247, 17);

                    Label animeEpisodesLabel = new Label();
                    animeEpisodesLabel.Text = "Episodes : ";
                    animeEpisodesLabel.Location = new Point(215, 100);
                    animeEpisodesLabel.Margin = new Padding(3, 3, 3, 0);
                    animeEpisodesLabel.Font = new Font("Microsoft Tai Le", 9, style: FontStyle.Italic);
                    animeEpisodesLabel.Size = new Size(247, 17);

                    Label animeReleasedDate = new Label();
                    animeReleasedDate.Text = $"{Convert.ToDateTime(collection[i].StartDate)}";
                    animeReleasedDate.Location = new Point(275, 130);
                    animeReleasedDate.Margin = new Padding(3, 3, 3, 0);
                    animeReleasedDate.Font = new Font("Microsoft Tai Le", 10, style: FontStyle.Bold);
                    animeReleasedDate.Size = new Size(247, 17);

                    Label animeReleasedDateLabel = new Label();
                    animeReleasedDateLabel.Text = "Released : ";
                    animeReleasedDateLabel.Location = new Point(215, 130);
                    animeReleasedDateLabel.Margin = new Padding(3, 3, 3, 0);
                    animeReleasedDateLabel.Font = new Font("Microsoft Tai Le", 9, style: FontStyle.Italic);
                    animeReleasedDateLabel.Size = new Size(247, 17);

                    RichTextBox description = new RichTextBox();
                    description.Text = $"{collection[i].Synopsis}";
                    description.Location = new Point(290, 160);
                    description.Size = new Size(180, 160);
                    description.ReadOnly = true;
                    description.ScrollBars = RichTextBoxScrollBars.None;
                    description.BackColor = Color.LightSkyBlue;
                    description.BorderStyle = BorderStyle.None;
                    description.Font = new Font("Microsoft Tai Le", 8, style: FontStyle.Bold);

                    Label descriptionLabel = new Label();
                    descriptionLabel.Text = "Description :  ";
                    descriptionLabel.Location = new Point(215, 160);
                    descriptionLabel.Margin = new Padding(3, 0, 3, 0);
                    descriptionLabel.Font = new Font("Microsoft Tai Le", 9, style: FontStyle.Italic);
                    descriptionLabel.Size = new Size(247, 17);


                    this.Controls.Add(groupBox);
                    groupBox.Controls.Add(pictureBox);
                    groupBox.Controls.Add(delBtn);
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
        private void FavoriteAnimeList_Load(object sender, EventArgs e)
        {
            var user = currentUser;
            var userFavAnimes = user.FavoriteAnimes;
            PrintDataOnView(userFavAnimes);
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

        private void delBtn_MouseClick(object sender, MouseEventArgs e)
        {
            var id = (sender as Button).TabIndex;
            var user = currentUser;
            var currentFavAnime = user.FavoriteAnimes.FirstOrDefault(o => o.Id == id);
            var currentFavAnimeTitle = currentFavAnime.Title;
            if (ConfirmationOfDelete() == DialogResult.Yes)
            {
                user.FavoriteAnimesIds.Remove(id);
                user.FavoriteAnimes.Remove(currentFavAnime);
                DbFileWorkerService.WriteInFile(user, _allAccountsPath, false);
                MessageBox.Show($"'{currentFavAnimeTitle}' was successfully deleted from favorite list");
                (sender as Button).Enabled = false;
                PrintDataOnView(user.FavoriteAnimes);
            }
            else
            {
                MessageBox.Show("Something went wrong please try again.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DialogResult ConfirmationOfDelete()
        {
            DialogResult res = MessageBox.Show("Are you sure you want to delete this anime from your favorite list? ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return res;
        }
    }
}
