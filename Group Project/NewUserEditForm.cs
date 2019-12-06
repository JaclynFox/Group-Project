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
using System.Data.SqlClient;

namespace Group_Project
{
    public partial class NewUserEditForm : Form
    {
        public NewUserEditForm()
        {
            InitializeComponent();
            /*SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\CSharp.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand com = new SqlCommand("SELECT ")
            StateDropBox.Items =
            TODO Add state pull up info.*/
        }

        private void UploadFilesButton_Click(object sender, EventArgs e)
        {

        }
        /*Upon clicking the submit button the system will write a new user and password to Users.txt using the first and last name as the user and the email as the password.
         * This is just placeholder for testing until the database is implemented.*/
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\CSharp.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand com = new SqlCommand("INSERT INTO Users(UserKey, UserName, Password, FirstName, LastName, address, street, city, zip, email, phone, YOE) VALUES(@username, @username, @password, @fn, @ln, @address, @street, @city, @zip, @email, @phone, @yoe)", con);
            com.Parameters.AddWithValue("@fn", FirstNameTextBox.Text);
            com.Parameters.AddWithValue("@ln", LastNameTextBox.Text);
            com.Parameters.AddWithValue("@street", StreetTextBox.Text);
            com.Parameters.AddWithValue("@city", CityTextBox.Text);
            com.Parameters.AddWithValue("@zip", ZipTextBox.Text);
            com.Parameters.AddWithValue("@email", EmailTextBox.Text);
            com.Parameters.AddWithValue("@phone", PhoneTextBox.Text);
            com.Parameters.AddWithValue("@address", StreetTextBox.Text);
            com.Parameters.AddWithValue("@yoe", Int32.Parse(YearsExperienceDropBox.SelectedItem.ToString()));
            //Pulls up a form where the user can ACTUALL ENTER A USERNAME! PROGRESS!!!!!!
            using (var login = new UNPW())
            {
                var result = login.ShowDialog();
                if (result == DialogResult.OK)
                {
                    com.Parameters.AddWithValue("@username", login.un);
                    com.Parameters.AddWithValue("@password", login.pw);
                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Inserted");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClassesButton_Click(object sender, EventArgs e)
        {
            //NEEDS TO ADD THE USER TO THE 'none' OF THE OBJECT
            this.Hide();
            var classesForm = new ClassesForm(2, "none", "new");
            classesForm.Closed += (s, args) => this.Close();
            classesForm.Show();
        }

        private void DropClassesButton_Click(object sender, EventArgs e)
        {
            //NEEDS TO ADD THE USER TO THE 'none' OF THE OBJECT
            this.Hide();
            var classesForm = new ClassesForm(1, "none", "new");
            classesForm.Closed += (s, args) => this.Close();
            classesForm.Show();
        }
    }
}
