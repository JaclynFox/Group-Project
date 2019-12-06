using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group_Project
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            Boolean[] unpw = Program.CheckLogin(UserNameTextBox.Text, PasswordTextBox.Text);
            if (unpw[0] == false)
            {
                MessageBox.Show("Bad Username");
                UserNameTextBox.Text = "";
                PasswordTextBox.Text = "";
            }
            else if (unpw[1] == false)
            {
                MessageBox.Show("Bad password");
                UserNameTextBox.Text = "";
                PasswordTextBox.Text = "";
            }
            else
            {
                this.Hide();
                var newUser = new NewUserEditForm();
                newUser.Closed += (s, args) => this.Close();
                newUser.Show();
            }
        }
        private void NewUserButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newUser = new NewUserEditForm();
            newUser.Closed += (s, args) => this.Close();
            newUser.Show();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
