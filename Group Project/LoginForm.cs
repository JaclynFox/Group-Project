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
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            using (StreamReader sr = File.OpenText("users.txt"))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    byte[] pepper = new byte[64];
                    byte[] userbyte = Convert.FromBase64String(s);
                    Array.Copy(userbyte, 0, pepper, 0, 64);
                    var userthing = new Rfc2898DeriveBytes(UserNameTextBox.Text, pepper, 10000);
                    byte[] userhash = userthing.GetBytes(64);
                    int un = 1;
                    for (int i = 0; i < 64; i++)
                        if (userbyte[i + 64] != userhash[i])
                            un = 0;
                    if (un == 1)
                    {
                        usernameValid = true;
                    }
                    if (usernameValid == true)
                    {
                        string q = sr.ReadLine();
                        byte[] salt = new byte[64];
                        byte[] hashbyte = Convert.FromBase64String(q);
                        Array.Copy(hashbyte, 0, salt, 0, 64);
                        var passthing = new Rfc2898DeriveBytes(PasswordTextBox.Text, salt, 10000);
                        byte[] hash = passthing.GetBytes(64);
                        int pw = 1;
                        for (int i = 0; i < 64; i++)
                            if (hashbyte[i + 64] != hash[i])
                                pw = 0;
                        if (pw == 1)
                        {
                            passwordValid = true;
                            break;
                        }
                    }
                }
            }
        }

        private void NewUserButton_Click(object sender, EventArgs e)
        {
            Form newUser = new NewUserEditForm();
            this.Hide();
            newUser.Show();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
