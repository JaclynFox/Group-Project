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
            this.Load += NewUserEditForm_Load;
        }

        private void UploadFilesButton_Click(object sender, EventArgs e)
        {

        }
        /*Upon clicking the submit button the system will write a new user and password to Users.txt using 
         * the first and last name as the user and the email as the password.
         * This is just placeholder for testing until the database is implemented.*/
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\CSharp.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand com = new SqlCommand("INSERT INTO Users(UserName, Password, FirstName, LastName, street, city, zip, email, phone, YOE) VALUES(@username, @password, @fn, @ln, @street, @city, @zip, @email, @phone, @yoe)", con);
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
                    com.Parameters.AddWithValue("@username", Program.GetBytes(login.un));
                    com.Parameters.AddWithValue("@password", Program.GetBytes(login.pw));
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

        private void YearsExperienceDropBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void NewUserEditForm_Load(object sender, EventArgs e)
        {
            //This populates the YearsExperienceDropBox from 1 - 60
            for (int i = 1; i <= 60; i++)
            {
                YearsExperienceDropBox.Items.Add(i);
            }

            // string to connect to database
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\CSharp.mdf;Integrated Security=True;Connect Timeout=30";

            // GRABS STATE DATA FROM DATABASE AND POPULATES IT IN StateDropBox
            // creating and opening a connection called StateCon, 
            // createing a SqlCommand called SelectAllState that (Select * FROM State) using the StateCon connection
            // creating a SqlDataReader called myReader to read the data
            // use a while loop to read the data from SqlDataReader to put in StateDropBox
            // the SqlConnection and SqlDataReader will close when program steps out of the key-word 'using' body
            using (SqlConnection StateCon = new SqlConnection())
            {
                StateCon.ConnectionString = connectionString;
                StateCon.Open();
                SqlCommand SelcectAllState = new SqlCommand("SELECT * FROM State", StateCon);

                using (SqlDataReader myReader = SelcectAllState.ExecuteReader())
                {
                    while (myReader.Read())
                    {
                        StateDropBox.Items.Add(myReader[1]);
                    }
                }
            }

            // GRABS STATUS DATA FROM DATABASE AND POPULATES IT IN StatusDropBox
            using (SqlConnection StatusCon = new SqlConnection())
            {
                StatusCon.ConnectionString = connectionString;
                StatusCon.Open();
                SqlCommand selectAllStatus = new SqlCommand("SELECT * FROM Status", StatusCon);

                using (SqlDataReader myReader = selectAllStatus.ExecuteReader())
                {
                    while (myReader.Read())
                    {
                        StatusDropBox.Items.Add(myReader[1]);
                    }
                }
            }

            // GRABS EDUCATION DATA FROM DATABASE AND POPULATES IT IN EducationDropBox
            using (SqlConnection EducationCon = new SqlConnection())
            {
                EducationCon.ConnectionString = connectionString;
                EducationCon.Open();
                SqlCommand selectAllEducation = new SqlCommand("SELECT * FROM Education", EducationCon);

                using (SqlDataReader myReader = selectAllEducation.ExecuteReader())
                {
                    while (myReader.Read())
                    {
                        EducationDropBox.Items.Add(myReader[1]);
                    }
                }
            }

        }
    }
}
