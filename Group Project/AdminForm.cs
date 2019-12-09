using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group_Project
{
    public partial class AdminForm : Form
    {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\CSharp.mdf;Integrated Security=True;Connect Timeout=30";
        
        public String UserNameForForm;
        private static int num = 0;
        public static Form ClassesForm;
        public int statusOfSelected = 0;
        public string statusOfCurrent;
        public AdminForm()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     

        private void StudentUserButton_Click(object sender, EventArgs e)
        {
            statusOfSelected = 1;
            UsersListBox.Items.Clear();
            AddButton.Visible = true;
            DropButton.Visible = true;
            AddButton.Text = "Add Class to Student";
            DropButton.Text = "Drop Class from Student";


            //--------------------------------------12/8 Brittany - populating UsersListBox with student users
            using (SqlConnection studentUserCon = new SqlConnection())
            {
                studentUserCon.ConnectionString = connectionString;
                studentUserCon.Open();
                SqlCommand SelcectStudentUsers = new SqlCommand("SELECT * FROM Users;", studentUserCon);



                using (SqlDataReader myReader = SelcectStudentUsers.ExecuteReader())
                {
                    while (myReader.Read())
                    {
                        if (myReader[13].ToString() == "1")
                        {
                            UsersListBox.Items.Add(myReader[3].ToString() + " " + myReader[4].ToString());
                        }
                    }
                }
            }
        }

        private void InstructorUserButton_Click(object sender, EventArgs e)
        {
            statusOfSelected = 3;
            UsersListBox.Items.Clear();
            AddButton.Visible = true;
            DropButton.Visible = true;
            AddButton.Text = "Add Class to Instructor";
            DropButton.Text = "Drop Class from Instructor";

            //--------------------------------------12/8 Brittany - populating UsersListBox with instructor users
            using (SqlConnection studentUserCon = new SqlConnection())
            {
                studentUserCon.ConnectionString = connectionString;
                studentUserCon.Open();
                SqlCommand SelcectStudentUsers = new SqlCommand("SELECT * FROM Users;", studentUserCon);

                using (SqlDataReader myReader = SelcectStudentUsers.ExecuteReader())
                {
                    while (myReader.Read())
                    {
                        if (myReader[13].ToString() == "3")
                        {
                            UsersListBox.Items.Add(myReader[3].ToString() + " " + myReader[4].ToString());
                        }
                    }
                }
            }
        }

        private void AdminUserButton_Click(object sender, EventArgs e)
        {
            statusOfSelected = 2;
            UsersListBox.Items.Clear();
            AddButton.Visible = false;
            DropButton.Visible = false;

            //--------------------------------------12/8 Brittany - populating UsersListBox with admin users
            using (SqlConnection studentUserCon = new SqlConnection())
            {
                studentUserCon.ConnectionString = connectionString;
                studentUserCon.Open();
                SqlCommand SelcectStudentUsers = new SqlCommand("SELECT * FROM Users;", studentUserCon);

                using (SqlDataReader myReader = SelcectStudentUsers.ExecuteReader())
                {
                    while (myReader.Read())
                    {
                        if (myReader[13].ToString() == "2")
                        {
                            UsersListBox.Items.Add(myReader[3].ToString() + " " + myReader[4].ToString());
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClassesForm.Show();
        }
        //DropButton
        private void DropButton_Click(object sender, EventArgs e)
        {
            if (UsersListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select from the list.");
            }
            else
            {
                this.Hide();
                var classesForm = new ClassesForm(1, UsersListBox.SelectedItem.ToString(), statusOfSelected, UserNameForForm, statusOfCurrent);
                classesForm.Closed += (s, args) => this.Close();
                classesForm.Show();
            }
        }
        //AddButton
        private void EditClassesButton_Click(object sender, EventArgs e)
        {
            if (UsersListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select from the list.");
            }
            else
            {
                this.Hide();
                //find the index selected from list and send the same index (which is the users username) to classes form             ASFAWEAWE
                int index = UsersListBox.SelectedIndex;
                var classesForm = new ClassesForm(2, UsersListBox.SelectedItem.ToString(), statusOfSelected, UserNameForForm, statusOfCurrent);
                //classesForm.IsAdmin = true;
                //classesForm.UserNameForForm = UserNameForForm;
                classesForm.Closed += (s, args) => this.Close();
                classesForm.Show();
            }
        }
        //PersonalInfoButton
        private void EditPersonalInformationButton_Click(object sender, EventArgs e)
        {
            if (UsersListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select from the list.");
            }
            else
            {
                this.Hide();
                var newUser = new NewUserEditForm();
                DataTable table = new DataTable();
                int space = 0;
                //Finds the space in the string.
                for (int i = 0; i < UsersListBox.SelectedItem.ToString().Length; i++)
                {
                    if (UsersListBox.SelectedItem.ToString().ToCharArray()[i] == ' ')
                    {
                        space = i;
                        break;
                    }

                }
                //changes the UserNameForForm variable to the selected user.
                using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\CSharp.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    con.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter("SELECT UserName FROM Users WHERE FirstName ='" + UsersListBox.SelectedItem.ToString().Substring(0, space) + "' AND LastName = '" + UsersListBox.SelectedItem.ToString().Substring(space + 1) + "'", con))
                        da.Fill(table);
                    con.Close();
                }
                UserNameForForm = table.Rows[0].Field<String>("UserName");
                newUser.UserNameForForm = UserNameForForm;
                newUser.statusOfSelected = statusOfSelected;
                newUser.statusOfCurrent = statusOfCurrent;
                newUser.Closed += (s, args) => this.Close();
                newUser.Show();
            }
        }

        //Admin Add New - for database                                                              SDFBAER
        private void AddNewClassButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var classesForm = new ClassesForm(4, UserNameForForm, statusOfSelected, UserNameForForm, statusOfCurrent);
            //classesForm.IsAdmin = true;
            classesForm.Closed += (s, args) => this.Close();
            classesForm.Show();
        }


        //Admin Delete Existing - from database                         AFGAEREARG
        private void DeleteExistingClassButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var classesForm = new ClassesForm(3, UserNameForForm, statusOfSelected, UserNameForForm, statusOfCurrent);
            //classesForm.IsAdmin = true;
            classesForm.Closed += (s, args) => this.Close();
            classesForm.Show();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            label2.Text = UserNameForForm;
        }
    }
}
