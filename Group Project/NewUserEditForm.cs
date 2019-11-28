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
    public partial class NewUserEditForm : Form
    {
        public NewUserEditForm()
        {
            InitializeComponent();
        }

        private void UploadFilesButton_Click(object sender, EventArgs e)
        {

        }

        /*Upon clicking the submit button the system will write a new user and password to Users.txt using the first and last name as the user and the email as the password.
         * This is just placeholder for testing until the database is implemented.*/
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (FirstNameTextBox.Text != "" && LastNameTextBox.Text != "" && EmailTextBox.Text != "")
            {
                using (StreamWriter sw = File.AppendText("Users.txt"))
                {
                    byte[] salt = new byte[64];
                    new RNGCryptoServiceProvider().GetBytes(salt);
                    var user = new Rfc2898DeriveBytes((FirstNameTextBox.Text + LastNameTextBox.Text), salt, 10000);
                    byte[] hash = user.GetBytes(64);
                    user.Dispose();
                    byte[] hashbytes = new byte[128];
                    Array.Copy(salt, 0, hashbytes, 0, 64);
                    Array.Copy(hash, 0, hashbytes, 64, 64);
                    String userhash = Convert.ToBase64String(hashbytes);
                    sw.WriteLine(userhash);
                    byte[] pepper = new byte[64];
                    new RNGCryptoServiceProvider().GetBytes(pepper);
                    var password = new Rfc2898DeriveBytes(EmailTextBox.Text, pepper, 10000);
                    byte[] passhash = password.GetBytes(64);
                    byte[] passhashbytes = new byte[128];
                    Array.Copy(pepper, 0, passhashbytes, 0, 64);
                    Array.Copy(passhash, 0, passhashbytes, 64, 64);
                    String passhashstring = Convert.ToBase64String(passhashbytes);
                    sw.WriteLine(passhashstring);
                    password.Dispose();
                }
                MessageBox.Show("User Created successfully");
                this.Hide();
                var login = new LoginForm();
                login.Closed += (s, args) => this.Close();
                login.Show();
            }
            else
                MessageBox.Show("Enter first name, last name, and email.");
        }
    }
}
