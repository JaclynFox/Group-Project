
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Group_Project
{
    public partial class LoginForm : Form
    {
        public String UserNameForForm;
        public string statusOfCurrent;
        public LoginForm()
        {
            InitializeComponent();

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            Boolean user = true, pass = true;

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\CSharp.mdf;Integrated Security=True;Connect Timeout=30";

            
            using (SqlConnection UserC = new SqlConnection())
            {
                UserC.ConnectionString = connectionString;
                UserC.Open();
                SqlCommand SelcectAllUsers = new SqlCommand("SELECT * FROM Users;", UserC);

                using (SqlDataReader myReader = SelcectAllUsers.ExecuteReader())
                {
                    while (myReader.Read())
                    {
                        if (myReader[1].ToString() == UserNameTextBox.Text)
                        {
                            user = false;
                            if (myReader[2].ToString() == PasswordTextBox.Text)
                            {
                                pass = false;
                            } 
                        }
                    }
                }
            }

            string Status = "";
            //Boolean[] unpw = Program.CheckLogin(UserNameTextBox.Text, PasswordTextBox.Text);
            if (user)//if (unpw[0] == false)
            {
                MessageBox.Show("Bad Username");
                UserNameTextBox.Text = "";
                PasswordTextBox.Text = "";
            }
            else if (pass)       //else if (unpw[1] == false)
            {
                MessageBox.Show("Bad password");
                UserNameTextBox.Text = "";
                PasswordTextBox.Text = "";
            }
            else
            {
                //decides if user needs to go to admin or newusereditpage and passes boolean to form

                //string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\CSharp.mdf;Integrated Security=True;Connect Timeout=30";
               
                UserNameForForm = UserNameTextBox.Text;
                using (SqlConnection UserCon = new SqlConnection())
                {
                    UserCon.ConnectionString = connectionString;
                    UserCon.Open();
                    SqlCommand SelcectAllUsers = new SqlCommand("SELECT * FROM Users;", UserCon);

                    using (SqlDataReader myReader = SelcectAllUsers.ExecuteReader())
                    {
                       while (myReader.Read())
                       {
                            if (myReader[1].ToString() == UserNameForForm)
                            {
                               Status = myReader[13].ToString();
                            }
                       } 
                    }
                }
                //MessageBox.Show(Status);


                if (Status == "2")
                {
                    this.Hide();
                    var Admin = new AdminForm();
                    Admin.UserNameForForm = UserNameForForm;
                    Admin.statusOfCurrent = "admin";
                    Admin.Closed += (s, args) => this.Close();
                    Admin.Show();
                    //MessageBox.Show("this is admin" + Status);
                }
                else if (Status == "3")
                {
                    this.Hide();
                    var newUser = new NewUserEditForm();
                    newUser.UserNameForForm = UserNameForForm;
                    newUser.statusOfCurrent = "professor";
                    //MessageBox.Show("this is Professor" + Status);
                    newUser.Closed += (s, args) => this.Close();
                    newUser.Show();
                }
                else if (Status == "1")
                {
                    this.Hide();
                    var newUser = new NewUserEditForm();
                    newUser.UserNameForForm = UserNameForForm;
                    statusOfCurrent = "student";
                    newUser.statusOfCurrent = "student";
                    newUser.Closed += (s, args) => this.Close();
                    newUser.Show();

                } else
                {
                    MessageBox.Show(UserNameForForm.ToString());
                }
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

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

    }
}
