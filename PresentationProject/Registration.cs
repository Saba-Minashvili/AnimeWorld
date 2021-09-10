using PresentationProjectDomainDb;
using PresentationProjectDomainModels.Abstraction;
using PresentationProjectDomainModels.Implementation;
using PresentationProjectDomainServices.Abstraction;
using PresentationProjectDomainServices.Implementation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace PresentationProject
{
    public partial class Registration : Form
    {
        private readonly IApplicationHelperManager _services = default;
        private readonly IAccountService _accountService = default;
        private readonly IUserService _userService = default;
        private readonly string _allAccountFilePath = "allAccounts.json";
        public string emailValidationString = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        public readonly string accountDbConnectionString = @"Data Source=DESKTOP-0FM65T2;Initial Catalog=Account;Integrated Security=True";

        private readonly List<UserAccount> _allAccount = default;
        public Registration()
        {
            InitializeComponent();
            _services = new ApplicationHelperManager();
            _accountService = new AccountService();
            _userService = new UserService();
            _allAccount = new List<UserAccount>();
        }

        public void ClearInputs()
        {
            NameInp.Text = string.Empty;
            SurnameInp.Text = string.Empty;
            AgeInp.Text = string.Empty;
            EmailInp.Text = string.Empty;
            RegisterUsernameInp.Text = string.Empty;
            RegisterPasswordInp.Text = string.Empty;
            RegisterConfirmPasswordInp.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBoxButtons btn = MessageBoxButtons.OK;
            MessageBoxIcon icon = MessageBoxIcon.Information;

            //checking inputs is empty or not
            if (string.IsNullOrEmpty(NameInp.Text))
            {
                MessageBox.Show("Please enter Name: ", "", btn, icon);
                NameInp.Select();
                return;
            }
            if (string.IsNullOrEmpty(SurnameInp.Text))
            {
                MessageBox.Show("Please enter Surname: ", "", btn, icon);
                SurnameInp.Select();
                return;
            }
            if (string.IsNullOrEmpty(AgeInp.Text))
            {
                MessageBox.Show("Please enter Age: ", "", btn, icon);
                AgeInp.Select();
                return;
            }
            if (string.IsNullOrEmpty(EmailInp.Text))
            {
                MessageBox.Show("Please enter Email: ", "", btn, icon);
                EmailInp.Select();
                return;
            }
            if (string.IsNullOrEmpty(RegisterUsernameInp.Text))
            {
                MessageBox.Show("Please enter Username: ", "", btn, icon);
                RegisterUsernameInp.Select();
                return;
            }
            if (string.IsNullOrEmpty(RegisterPasswordInp.Text))
            {
                MessageBox.Show("Please enter Password: ", "", btn, icon);
                RegisterPasswordInp.Select();
                return;
            }
            if (IsValid(EmailInp.Text) != true)
            {
                MessageBox.Show("Please enter a valid email address", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EmailInp.Text = string.Empty;
                EmailInp.Select();
                return;
            }

            // query to check username already exist or not
            string usernameAlreadyExistSQL = string.Empty;
            usernameAlreadyExistSQL += "SELECT Username FROM AccountTbl WHERE Username = '" + RegisterUsernameInp.Text + "'";

            // query to check email already exist or not
            string emailAlreadyExistSQL = string.Empty;
            emailAlreadyExistSQL += "SELECT Email FROM AccountTbl WHERE Email = '" + EmailInp.Text + "'";

            // getting usernames from Server to check about existing
            DataTable checkDuplicateUsername = SQLDatabaseServerConnection.ExecuteSQL(usernameAlreadyExistSQL, accountDbConnectionString);
            // getting emails from Server to check about existing
            DataTable checkDuplicateEmail = SQLDatabaseServerConnection.ExecuteSQL(emailAlreadyExistSQL, accountDbConnectionString);

            if (checkDuplicateUsername.Rows.Count > 0)
            {
                MessageBox.Show("The Username already exists. Please try another Username.", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                RegisterUsernameInp.Select();
                return;
            }
            else if (checkDuplicateEmail.Rows.Count > 0)
            {
                MessageBox.Show("The Email already exists. Please try another Email.", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                EmailInp.Select();
                return;
            }
            else if(RegisterConfirmPasswordInp.Text != RegisterPasswordInp.Text)
            {
                MessageBox.Show("Those passwords didn't match. Try again", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                RegisterConfirmPasswordInp.Select();
                return;
            }
            else
            {
                _userService.CreateUser(NameInp.Text, SurnameInp.Text, Convert.ToInt32(AgeInp.Text), EmailInp.Text, RegisterUsernameInp.Text, RegisterPasswordInp.Text);
                _accountService.CreateUserAccount(RegisterUsernameInp.Text, RegisterPasswordInp.Text, EmailInp.Text);
                DbFileWorkerService.WriteInFile(new UserAccount() { Username = RegisterUsernameInp.Text, Password = RegisterPasswordInp.Text, Email = EmailInp.Text }, _allAccountFilePath, false);
                MessageBox.Show("Your account has been successfully created ", "", MessageBoxButtons.OK);
            }

            ClearInputs();
            this.Hide();
        }
        public bool IsValid(string email)
        {
            if (Regex.IsMatch(email, emailValidationString))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            ClearInputs();
            NameInp.Select();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            this.Dispose(true);
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            NameInp.Select();
        }
    }
}
