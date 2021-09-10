using PresentationProjectDomainDb;
using PresentationProjectDomainDtos;
using PresentationProjectDomainServices.Abstraction;
using PresentationProjectDomainServices.Implementation;
using System;
using System.Data;
using System.Windows.Forms;

namespace PresentationProject
{
    public partial class MainForm : Form
    {
        private Form _registration = default;
        private Form _main = default;
        private Form _forgotPassword = default;
        private readonly string accountDbConnectionString = @"Data Source=DESKTOP-0FM65T2;Initial Catalog=Account;Integrated Security=True";
        private readonly IApplicationHelperManager _services = default;
        public MainForm()
        {
            InitializeComponent();
            _registration = new Registration();
            _services = new ApplicationHelperManager();
            _forgotPassword = new ForgotPassword();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateAccount.LinkBehavior = LinkBehavior.NeverUnderline;
            ForgotPasswordBtn.LinkBehavior = LinkBehavior.NeverUnderline;
        }

        private void SignInBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(UsernameInp.Text) &&
                !string.IsNullOrEmpty(PasswordInp.Text))
            {
                string mySQL = string.Empty;

                mySQL += "SELECT * FROM AccountTbl ";
                mySQL += "WHERE Username = '" + UsernameInp.Text + "'";
                mySQL += "AND Password = '" + PasswordInp.Text + "'";

                DataTable accountData = SQLDatabaseServerConnection.ExecuteSQL(mySQL, accountDbConnectionString);

                if (accountData.Rows.Count > 0)
                {
                    var currentUser = new SignInUserDto
                    {
                        Username = UsernameInp.Text,
                        Password = PasswordInp.Text
                    };

                    _services.SignInUser(currentUser);
                    UsernameInp.Text = string.Empty;
                    PasswordInp.Text = string.Empty;
                    ShowPasswordCheckBox.Checked = false;
                    _main = new Main();
                    _main.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("The Username or Password is incorrect. Try again. ", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    UsernameInp.Text = string.Empty;
                    PasswordInp.Text = string.Empty;
                    UsernameInp.Select();
                }

            }
            else
            {
                MessageBox.Show("Plese enter Username and Password. ", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void CreateAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateOrShow();
            UsernameInp.Select();
        }

        private void CreateOrShow()
        {
            if (_registration == null || _registration.IsDisposed)
            {
                _registration = new Registration();

                _registration.FormClosed += ChildFormClosed;
            }

            _registration.Show();
        }

        void ChildFormClosed(object sender, FormClosedEventArgs args)
        {
            _registration.FormClosed -= ChildFormClosed;

            _registration = null;
        }

        private void ShowPasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowPasswordCheckBox.Checked == true)
            {
                PasswordInp.PasswordChar = default;
            }
            else
            {
                PasswordInp.PasswordChar = '*';
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            this.Dispose(true);
            Application.Exit();
        }

        private void ForgotPasswordBtn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _forgotPassword.Show();
        }
    }
}
