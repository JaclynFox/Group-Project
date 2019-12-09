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
    public partial class ClassesForm : Form
    {
        public Boolean AddNewClassAdmin;
        public String UserNameForForm;
        private int dropAdd;
        private String[] selectedUser = new string[14];
        private int statusOfSelected;
        public string statusOfCurrent;
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\CSharp.mdf;Integrated Security=True;Connect Timeout=30";

        public ClassesForm(int num, String selected, int statusOfSelect, String UserNameFor, String statusOfCurr)
        {
            InitializeComponent();
            statusOfSelected = statusOfSelect;
            statusOfCurrent = statusOfCurr;
            UserNameForForm = UserNameFor;
            dropAdd = num;


            if (dropAdd == 1)                           //if dropping
            {
                DropGroup.Visible = true;
                AddGroup.Visible = false;
                SecondGroupBox.Visible = false;
                this.Size = new System.Drawing.Size(400, 420);
                label1.Text = selected;
                label2.Text = UserNameForForm;

                if (statusOfCurrent == "admin")
                {
                    //tokenizing selected user
                    string str = selected;
                    string[] tokens = str.Split(null);

                    // ---------------------------------------------Grabbing information about selected user from database to array
                    using (SqlConnection UseCon = new SqlConnection())
                    {
                        UseCon.ConnectionString = connectionString;
                        UseCon.Open();
                        SqlCommand selectAllStatus = new SqlCommand("SELECT * FROM Users;", UseCon);
                        //MessageBox.Show(selected);
                        using (SqlDataReader myReader = selectAllStatus.ExecuteReader())
                        {
                            while (myReader.Read())
                            {
                                if (myReader[3].ToString() == tokens[0] && myReader[4].ToString() == tokens[1])
                                {
                                    int i = 0;
                                    while (i < selectedUser.Length)
                                    {
                                        //adding selected user info to array
                                        selectedUser[i] = myReader[i].ToString();
                                        i++;
                                    }
                                }
                            }
                        }
                    }
                    //MessageBox.Show("made list");

                    // finding all the classes the user is in
                    using (SqlConnection ClasCon = new SqlConnection())
                    {
                        ClasCon.ConnectionString = connectionString;
                        ClasCon.Open();
                        string command = "SELECT Class.ClassName " +
                            "FROM StudentClass " +
                            "INNER JOIN Users " +
                                "ON StudentClass.UserKey = Users.UserKey " +
                             "INNER JOIN Class " +
                                "ON StudentClass.ClassKey = Class.ClassKey " +
                                "WHERE StudentClass.UserKey = '" + selectedUser[0] + "';";

                        SqlCommand selectAllClass = new SqlCommand(command, ClasCon);
                        // users id
                        //MessageBox.Show("Users id:");
                        //MessageBox.Show(selectedUser[0]);
                        //MessageBox.Show("the following is ids from studentClass table");
                        using (SqlDataReader myReader = selectAllClass.ExecuteReader())
                        {
                            while (myReader.Read())
                            {
                                //adding all the classes that the user is in to FirstListBox
                                FirstListBox.Items.Add(myReader[0].ToString());
                            }
                        }
                    }

                    //MessageBox.Show("added to list");
                }
                else if (statusOfCurrent == "professor")
                {
                    string str = UserNameForForm;
                    // ------------Grabbing information about user from database to array

                    using (SqlConnection UseCon = new SqlConnection())
                    {
                        UseCon.ConnectionString = connectionString;
                        UseCon.Open();
                        SqlCommand selectAllStatus = new SqlCommand("SELECT * FROM Users;", UseCon);
                        //MessageBox.Show(selected);
                        using (SqlDataReader myReader = selectAllStatus.ExecuteReader())
                        {
                            while (myReader.Read())
                            {
                                if (myReader[1].ToString() == str)
                                {
                                    int i = 0;
                                    while (i < selectedUser.Length)
                                    {
                                        //adding selected user info to array
                                        //FirstListBox.Items.Add(myReader[i].ToString());
                                        selectedUser[i] = myReader[i].ToString();
                                        i++;
                                    }
                                }
                            }
                        }
                    }

                    // finding all the classes the user is in
                    using (SqlConnection ClasCon = new SqlConnection())
                    {
                        ClasCon.ConnectionString = connectionString;
                        ClasCon.Open();
                        string command = "SELECT Class.ClassName " +
                            "FROM StudentClass " +
                            "INNER JOIN Users " +
                                "ON StudentClass.UserKey = Users.UserKey " +
                             "INNER JOIN Class " +
                                "ON StudentClass.ClassKey = Class.ClassKey " +
                                "WHERE StudentClass.UserKey = '" + selectedUser[0] + "';";

                        SqlCommand selectAllClass = new SqlCommand(command, ClasCon);
                        // users id
                        //MessageBox.Show("Users id:");
                        //MessageBox.Show(selectedUser[0]);
                        //MessageBox.Show("the following is ids from studentClass table");
                        using (SqlDataReader myReader = selectAllClass.ExecuteReader())
                        {
                            while (myReader.Read())
                            {
                                //adding all the classes that the user is in to FirstListBox
                                FirstListBox.Items.Add(myReader[0].ToString());
                            }
                        }
                    }
                }
                else if (statusOfCurrent == "student")
                {
                    string str = UserNameForForm;
                    // ------------Grabbing information about user from database to array

                    using (SqlConnection UseCon = new SqlConnection())
                    {
                        UseCon.ConnectionString = connectionString;
                        UseCon.Open();
                        SqlCommand selectAllStatus = new SqlCommand("SELECT * FROM Users;", UseCon);
                        //MessageBox.Show(selected);
                        using (SqlDataReader myReader = selectAllStatus.ExecuteReader())
                        {
                            while (myReader.Read())
                            {
                                if (myReader[1].ToString() == str)
                                {
                                    int i = 0;
                                    while (i < selectedUser.Length)
                                    {
                                        //adding selected user info to array
                                        //FirstListBox.Items.Add(myReader[i].ToString());
                                        selectedUser[i] = myReader[i].ToString();
                                        i++;
                                    }
                                }
                            }
                        }
                    }

                    // finding all the classes the user is in
                    using (SqlConnection ClasCon = new SqlConnection())
                    {
                        ClasCon.ConnectionString = connectionString;
                        ClasCon.Open();
                        string command = "SELECT Class.ClassName " +
                            "FROM StudentClass " +
                            "INNER JOIN Users " +
                                "ON StudentClass.UserKey = Users.UserKey " +
                             "INNER JOIN Class " +
                                "ON StudentClass.ClassKey = Class.ClassKey " +
                                "WHERE StudentClass.UserKey = '" + selectedUser[0] + "';";

                        SqlCommand selectAllClass = new SqlCommand(command, ClasCon);
                        // users id
                        //MessageBox.Show("Users id:");
                        //MessageBox.Show(selectedUser[0]);
                        //MessageBox.Show("the following is ids from studentClass table");
                        using (SqlDataReader myReader = selectAllClass.ExecuteReader())
                        {
                            while (myReader.Read())
                            {
                                //adding all the classes that the user is in to FirstListBox
                                FirstListBox.Items.Add(myReader[0].ToString());
                            }
                        }
                    }
                }


            }
            else if (dropAdd == 2)                    //if adding
            {
                DropGroup.Visible = false;
                SecondGroupBox.Visible = true;
                this.Size = new System.Drawing.Size(400, 600);
                label1.Text = selected;
                label2.Text = UserNameForForm;

                if (statusOfCurrent == "admin")
                {
                    //tokenizing selected user
                    string str = selected;
                    string[] tokens = str.Split(null);

                    // ---------------------------------------------Grabbing information about selected user from database to array
                    using (SqlConnection UseCon = new SqlConnection())
                    {
                        UseCon.ConnectionString = connectionString;
                        UseCon.Open();
                        SqlCommand selectAllStatus = new SqlCommand("SELECT * FROM Users;", UseCon);
                        //MessageBox.Show(selected);
                        using (SqlDataReader myReader = selectAllStatus.ExecuteReader())
                        {
                            while (myReader.Read())
                            {
                                if (myReader[3].ToString() == tokens[0] && myReader[4].ToString() == tokens[1])
                                {
                                    int i = 0;
                                    while (i < selectedUser.Length)
                                    {
                                        //adding selected user info to array
                                        selectedUser[i] = myReader[i].ToString();
                                        i++;
                                    }
                                }
                            }
                        }
                    }
                    //MessageBox.Show("made list");

                    // finding all the classes the user is in
                    using (SqlConnection ClasCon = new SqlConnection())
                    {
                        ClasCon.ConnectionString = connectionString;
                        ClasCon.Open();
                        string command = "SELECT Class.ClassName " +
                            "FROM StudentClass " +
                            "INNER JOIN Users " +
                                "ON StudentClass.UserKey = Users.UserKey " +
                             "INNER JOIN Class " +
                                "ON StudentClass.ClassKey = Class.ClassKey " +
                                "WHERE StudentClass.UserKey = '" + selectedUser[0] + "';";

                        SqlCommand selectAllClass = new SqlCommand(command, ClasCon);
                        // users id
                        //MessageBox.Show("Users id:");
                        //MessageBox.Show(selectedUser[0]);
                        //MessageBox.Show("the following is ids from studentClass table");
                        using (SqlDataReader myReader = selectAllClass.ExecuteReader())
                        {
                            while (myReader.Read())
                            {
                                //adding all the classes that the user is in to FirstListBox
                                FirstListBox.Items.Add(myReader[0].ToString());
                            }
                        }
                    }

                    //MessageBox.Show("added to list");
                }
                else if (statusOfCurrent == "professor")
                {
                    string str = UserNameForForm;
                    // ------------Grabbing information about user from database to array

                    using (SqlConnection UseCon = new SqlConnection())
                    {
                        UseCon.ConnectionString = connectionString;
                        UseCon.Open();
                        SqlCommand selectAllStatus = new SqlCommand("SELECT * FROM Users;", UseCon);
                        //MessageBox.Show(selected);
                        using (SqlDataReader myReader = selectAllStatus.ExecuteReader())
                        {
                            while (myReader.Read())
                            {
                                if (myReader[1].ToString() == str)
                                {
                                    int i = 0;
                                    while (i < selectedUser.Length)
                                    {
                                        //adding selected user info to array
                                        //FirstListBox.Items.Add(myReader[i].ToString());
                                        selectedUser[i] = myReader[i].ToString();
                                        i++;
                                    }
                                }
                            }
                        }
                    }

                    // finding all the classes the user is in
                    using (SqlConnection ClasCon = new SqlConnection())
                    {
                        ClasCon.ConnectionString = connectionString;
                        ClasCon.Open();
                        string command = "SELECT Class.ClassName " +
                            "FROM StudentClass " +
                            "INNER JOIN Users " +
                                "ON StudentClass.UserKey = Users.UserKey " +
                             "INNER JOIN Class " +
                                "ON StudentClass.ClassKey = Class.ClassKey " +
                                "WHERE StudentClass.UserKey = '" + selectedUser[0] + "';";

                        SqlCommand selectAllClass = new SqlCommand(command, ClasCon);
                        // users id
                        //MessageBox.Show("Users id:");
                        //MessageBox.Show(selectedUser[0]);
                        //MessageBox.Show("the following is ids from studentClass table");
                        using (SqlDataReader myReader = selectAllClass.ExecuteReader())
                        {
                            while (myReader.Read())
                            {
                                //adding all the classes that the user is in to FirstListBox
                                FirstListBox.Items.Add(myReader[0].ToString());
                            }
                        }
                    }
                }
                else if (statusOfCurrent == "student")
                {
                    string str = UserNameForForm;
                    // ------------Grabbing information about user from database to array

                    using (SqlConnection UseCon = new SqlConnection())
                    {
                        UseCon.ConnectionString = connectionString;
                        UseCon.Open();
                        SqlCommand selectAllStatus = new SqlCommand("SELECT * FROM Users;", UseCon);
                        //MessageBox.Show(selected);
                        using (SqlDataReader myReader = selectAllStatus.ExecuteReader())
                        {
                            while (myReader.Read())
                            {
                                if (myReader[1].ToString() == str)
                                {
                                    int i = 0;
                                    while (i < selectedUser.Length)
                                    {
                                        //adding selected user info to array
                                        //FirstListBox.Items.Add(myReader[i].ToString());
                                        selectedUser[i] = myReader[i].ToString();
                                        i++;
                                    }
                                }
                            }
                        }
                    }

                    // finding all the classes the user is in
                    using (SqlConnection ClasCon = new SqlConnection())
                    {
                        ClasCon.ConnectionString = connectionString;
                        ClasCon.Open();
                        string command = "SELECT Class.ClassName " +
                            "FROM StudentClass " +
                            "INNER JOIN Users " +
                                "ON StudentClass.UserKey = Users.UserKey " +
                             "INNER JOIN Class " +
                                "ON StudentClass.ClassKey = Class.ClassKey " +
                                "WHERE StudentClass.UserKey = '" + selectedUser[0] + "';";

                        SqlCommand selectAllClass = new SqlCommand(command, ClasCon);
                        // users id
                        //MessageBox.Show("Users id:");
                        //MessageBox.Show(selectedUser[0]);
                        //MessageBox.Show("the following is ids from studentClass table");
                        using (SqlDataReader myReader = selectAllClass.ExecuteReader())
                        {
                            while (myReader.Read())
                            {
                                //adding all the classes that the user is in to FirstListBox
                                FirstListBox.Items.Add(myReader[0].ToString());
                            }
                        }
                    }
                }
            } 
            else if (dropAdd == 3)                      //deleting current class
            {
                DropGroup.Visible = true;
                AddGroup.Visible = false;
                SecondGroupBox.Visible = false;
                this.Size = new System.Drawing.Size(400, 420);
                DropSubmitButton.Text = "Delete";
                label1.Text = "Delete A Class From List";
                label2.Text = UserNameForForm;
            }
            else if (dropAdd == 4)                      //adding new class
            {
                DropGroup.Visible = false;
                SecondGroupBox.Visible = true;
                this.Size = new System.Drawing.Size(400, 600);
                DropSubmitButton.Text = "Create";
                label1.Text = "Add A New Class";
                label2.Text = UserNameForForm;
            }
        }

        //AddSubmitButton
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Action Completed (But was it?).");
        }

        //AddExitButton
        private void ExitButton_Click(object sender, EventArgs e)
        {
            if (statusOfCurrent == "admin")
            {
                this.Hide();
                var adminform = new AdminForm();
                adminform.UserNameForForm = UserNameForForm;
                adminform.statusOfSelected = statusOfSelected;
                adminform.statusOfCurrent = statusOfCurrent;
                adminform.Closed += (s, args) => this.Close();
                adminform.Show();
            }
            else
            {
                this.Hide();
                var newform = new NewUserEditForm();
                newform.UserNameForForm = UserNameForForm;
                newform.statusOfSelected = statusOfSelected;
                newform.statusOfCurrent = statusOfCurrent;
                newform.Closed += (s, args) => this.Close();
                newform.Show();
            }
        }

        //DropSubmitButton
        private void DropSubmitButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Action Completed (But was it?).");
        }

        //DropExitButton
        private void DropExitButton_Click(object sender, EventArgs e)
        {
            if (statusOfCurrent == "admin")
            {
                this.Hide();
                var adminform = new AdminForm();
                adminform.UserNameForForm = UserNameForForm;
                adminform.statusOfSelected = statusOfSelected;
                adminform.statusOfCurrent = statusOfCurrent;
                adminform.Closed += (s, args) => this.Close();
                adminform.Show();
            }
            else
            {
                this.Hide();
                var newform = new NewUserEditForm();
                newform.UserNameForForm = UserNameForForm;
                newform.statusOfSelected = statusOfSelected;
                newform.statusOfCurrent = statusOfCurrent;
                newform.Closed += (s, args) => this.Close();
                newform.Show();
            }
        }
        private void ClassesForm_Load(object sender, EventArgs e)
        {
            AdminClassGroupBox.Visible = false;
            AdminClassGroupBox.Enabled = false;

            if (AddNewClassAdmin)
            {
                AdminClassGroupBox.Location = new Point(50, 100);
                AdminClassGroupBox.Visible = true;
                AdminClassGroupBox.Enabled = true;

                AddGroup.Visible = false;
                AddGroup.Enabled = false;

                DropGroup.Visible = false;
                DropGroup.Enabled = false;

                FirstListBox.Visible = false;
                FirstListBox.Enabled = false;

                FirstGroupBox.Visible = false;
                FirstGroupBox.Enabled = false;

                SecondGroupBox.Visible = false;
                SecondGroupBox.Enabled = false;

                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\CSharp.mdf;Integrated Security=True;Connect Timeout=30";

                using (SqlConnection teacherCon = new SqlConnection())
                {
                    teacherCon.ConnectionString = connectionString;
                    teacherCon.Open();
                    SqlCommand SelcectAllTeachers = new SqlCommand("SELECT FirstName, LastName FROM Users WHERE StatusKey = 3", teacherCon);

                    using (SqlDataReader myReader = SelcectAllTeachers.ExecuteReader())
                    {
                        while (myReader.Read())
                        {

                            TeacherComboBox.Items.Add(myReader[1]);

                        }
                    }
                }


            }
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            string userid = "";

            using (SqlConnection ClasCon = new SqlConnection())
            {
                ClasCon.ConnectionString = connectionString;
                ClasCon.Open();

                String teacherName = TeacherComboBox.SelectedItem.ToString();

                string selectcommand = "SELECT UserKey FROM Users " +
                          "WHERE StatusKey = 3 AND LastName = '" + teacherName + "';";


                SqlCommand selectAllClass = new SqlCommand(selectcommand, ClasCon);
                using (SqlDataReader myReader = selectAllClass.ExecuteReader())
                {
                    while (myReader.Read())
                    {
                        userid = myReader[0].ToString();
                    }
                }

                String ClassName = ClassTextBox.Text;
                MessageBox.Show(ClassName, userid);

                SqlCommand coma = new SqlCommand("INSERT INTO Class(ClassName, UserKey) VALUES(@cl, @us)", ClasCon);
                coma.Parameters.AddWithValue("@cl", ClassTextBox.Text);
                coma.Parameters.AddWithValue("@us", int.Parse(userid));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var adminform = new AdminForm();
            adminform.UserNameForForm = UserNameForForm;
            adminform.statusOfSelected = statusOfSelected;
            adminform.statusOfCurrent = statusOfCurrent;
            adminform.Closed += (s, args) => this.Close();
            adminform.Show();
        }

    }
}
