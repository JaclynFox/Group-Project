using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace Group_Project
{
    public partial class LoginForm : Form
    {
        bool usernameValid = false, passwordValid = false;
        String login, passwordord;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            using (StreamReader sr = File.OpenText("Users.txt"))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    byte[] pepper = new byte[64];
                    byte[] userbyte = Convert.FromBase64String(s);
                    Array.Copy(userbyte, 0, pepper, 0, 64);
                    var userthing = new Rfc2898DeriveBytes(UserNameTextBox.Text, pepper, 10000);
                    byte[] userhash = userthing.GetBytes(64);
                    userthing.Dispose();
                    usernameValid = true;
                    for (int i = 0; i < 64; i++)
                        if (userbyte[i + 64] != userhash[i])
                            usernameValid = false;
                    if (usernameValid == true)
                    {
                        MessageBox.Show("Username Found");
                        string q = sr.ReadLine();
                        byte[] salt = new byte[64];
                        byte[] hashbyte = Convert.FromBase64String(q);
                        Array.Copy(hashbyte, 0, salt, 0, 64);
                        var passthing = new Rfc2898DeriveBytes(PasswordTextBox.Text, salt, 10000);
                        byte[] hash = passthing.GetBytes(64);
                        passthing.Dispose();
                        passwordValid = true;
                        for (int i = 0; i < 64; i++)
                            if (hashbyte[i + 64] != hash[i])
                                passwordValid = false;
                        if (passwordValid == true)
                        {
                            MessageBox.Show("Password found");
                            passwordValid = true;
                            break;
                        }
                    }
                }
            }
            if (passwordValid == true && usernameValid == true)
            {
                /* this.Hide();
                 var menu = new FrmMenu();
                 menu.Closed += (s, args) => this.Close();
                 menu.Show();
                 Placeholder form switch statement ^*/
                MessageBox.Show("Congratulations, you win!");
            }
            else
            {
                MessageBox.Show("Bad username or password.");
                UserNameTextBox.Text = "";
                PasswordTextBox.Text = "";
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
