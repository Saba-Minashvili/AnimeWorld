using PresentationProjectDomainDb;
using PresentationProjectDomainServices.Abstraction;
using PresentationProjectDomainServices.Implementation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationProject
{
    public partial class ForgotPassword : Form
    {
        private readonly IForgotPasswordService _forgotPasswordService = default;
        public string emailValidationString = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        public ForgotPassword()
        {
            InitializeComponent();
            _forgotPasswordService = new ForgotPasswordService();
        }

        private void ForgotPassword_Load(object sender, EventArgs e)
        {
            ForgotPasswordEmailInp.Select();
        }

        public bool IsValid(string email)
        {
            if(Regex.IsMatch(email, emailValidationString))
            {
                return true;
            }else
            {
                return false;
            }
        }

        private void EmailSendSubmitBtn_Click(object sender, EventArgs e)
        {
            var enteredEmail = ForgotPasswordEmailInp.Text;
            if(IsValid(enteredEmail) && _forgotPasswordService.SendForgotPasswordMessage(enteredEmail))
            {
                MessageBox.Show("Recovery password message sent to your email", "", MessageBoxButtons.OK);
                this.Hide();
                ForgotPasswordEmailInp.Text = string.Empty;
            }
            else if(IsValid(enteredEmail) != true && _forgotPasswordService.SendForgotPasswordMessage(enteredEmail) == false)
            {
                MessageBox.Show("Invalid email. Please try again", "", MessageBoxButtons.OK);
            }
        }
    }
}
