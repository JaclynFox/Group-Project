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

        public string UserNameForForm;
        public string statusOfCurrent;
        public int statusOfSelected;
        public String filePath;
        public NewUserEditForm()
        {
            InitializeComponent();
            this.Load += NewUserEditForm_Load;
        }

        private void UploadFilesButton_Click(object sender, EventArgs e)
        {
            var result = new DialogResult();
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                result = openFile.ShowDialog();
                if (result == DialogResult.OK)
                {
                    filePath = openFile.FileName;
                    MessageBox.Show(filePath);
                }
            }
        }
        /*Upon clicking the submit button the system will write a new user and password to Users.txt using 
         * the first and last name as the user and the email as the password.
         * This is just placeholder for testing until the database is implemented.*/
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\CSharp.mdf;Integrated Security=True;Connect Timeout=30";
            int state = (Int32.Parse(StateDropBox.SelectedIndex.ToString())) + 51;
            int education = (Int32.Parse(EducationDropBox.SelectedIndex.ToString())) + 1;
            int status = (Int32.Parse(StatusDropBox.SelectedIndex.ToString())) + 1;
            SqlConnection con = new SqlConnection(connectionString);

            //Sorin start of update
            //Update is currently just updating according to the FirstName being 
            //autopoluated. 'NewNameFromForm' data passed from login needs to be edited later 
            //to update to pass username and not firstname
            if (validate())
            {
                if (statusOfCurrent == "admin" || statusOfCurrent == "student" || statusOfCurrent == "professor")
                {
                    SubmitButton.Text = "Update";
                    SqlCommand com = new SqlCommand("UPDATE Users SET FirstName = @fn, LastName = @ln, street = @street, city = @city, zip = @zip, email = @email, phone = @phone, YOE = @yoe WHERE UserName = '" + UserNameForForm + "';", con);
                    com.Parameters.AddWithValue("@fn", FirstNameTextBox.Text);
                    com.Parameters.AddWithValue("@ln", LastNameTextBox.Text);
                    com.Parameters.AddWithValue("@street", StreetTextBox.Text);
                    com.Parameters.AddWithValue("@city", CityTextBox.Text);
                    com.Parameters.AddWithValue("@zip", ZipTextBox.Text);
                    com.Parameters.AddWithValue("@email", EmailTextBox.Text);
                    com.Parameters.AddWithValue("@phone", PhoneTextBox.Text);
                    com.Parameters.AddWithValue("@address", StreetTextBox.Text);

                    if (ProfessorInfoGroupBox.Enabled == false)
                    {
                        com.Parameters.AddWithValue("@yoe", 0);
                    }
                    else
                    {
                        com.Parameters.AddWithValue("@yoe", Int32.Parse(YearsExperienceDropBox.Text));
                    }
                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Inserted");
                }

                //Sorin end of update
                else
                {
                    //--------------------------------------12/8 Brittany -if student is selected it will update database 
                    //with the if statement else it will update database 
                    //in the else statment
                    var result = new DialogResult();
                    if (StatusDropBox.Text == "Student")
                    {
                        SqlCommand coma = new SqlCommand("INSERT INTO Users(UserName, Password, FirstName, LastName, street, city, zip, email, phone, YOE, StateKey, StatusKey) VALUES(@username, @password, @fn, @ln, @street, @city, @zip, @email, @phone, @yoe, @statekey, @statuskey)", con);
                        coma.Parameters.AddWithValue("@fn", FirstNameTextBox.Text);
                        coma.Parameters.AddWithValue("@ln", LastNameTextBox.Text);
                        coma.Parameters.AddWithValue("@street", StreetTextBox.Text);
                        coma.Parameters.AddWithValue("@city", CityTextBox.Text);
                        coma.Parameters.AddWithValue("@zip", ZipTextBox.Text);
                        coma.Parameters.AddWithValue("@email", EmailTextBox.Text);
                        coma.Parameters.AddWithValue("@phone", PhoneTextBox.Text);
                        coma.Parameters.AddWithValue("@address", StreetTextBox.Text);
                        coma.Parameters.AddWithValue("@statekey", state.ToString());
                        coma.Parameters.AddWithValue("@statuskey", status.ToString());
                        //Sorin If student fills out yoe automatically
                        if (ProfessorInfoGroupBox.Enabled == false)
                        {
                            coma.Parameters.AddWithValue("@yoe", 0);
                        }
                        else
                        {
                            coma.Parameters.AddWithValue("@yoe", Int32.Parse(YearsExperienceDropBox.SelectedItem.ToString()));
                        }
                        //Pulls up a form where the user can ACTUALL ENTER A USERNAME! PROGRESS!!!!!!
                        using (var login = new UNPW())
                        {
                            result = login.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                coma.Parameters.AddWithValue("@username", login.un); //Program.GetBytes(login.un));
                                coma.Parameters.AddWithValue("@password", login.pw); //Program.GetBytes(login.pw));
                                con.Open();
                                coma.ExecuteNonQuery();
                                con.Close();
                                MessageBox.Show("Inserted Student");
                            }
                        }
                    }
                    else
                    {
                        SqlCommand coma = new SqlCommand("INSERT INTO Users(UserName, Password, FirstName, LastName, street, city, zip, email, phone, YOE, EducationKey, StateKey, StatusKey) VALUES(@username, @password, @fn, @ln, @street, @city, @zip, @email, @phone, @yoe, @educationkey, @statekey, @statuskey)", con);
                        coma.Parameters.AddWithValue("@fn", FirstNameTextBox.Text);
                        coma.Parameters.AddWithValue("@ln", LastNameTextBox.Text);
                        coma.Parameters.AddWithValue("@street", StreetTextBox.Text);
                        coma.Parameters.AddWithValue("@city", CityTextBox.Text);
                        coma.Parameters.AddWithValue("@zip", ZipTextBox.Text);
                        coma.Parameters.AddWithValue("@email", EmailTextBox.Text);
                        coma.Parameters.AddWithValue("@phone", PhoneTextBox.Text);
                        coma.Parameters.AddWithValue("@educationkey", education.ToString());
                        coma.Parameters.AddWithValue("@statekey", state.ToString());
                        coma.Parameters.AddWithValue("@statuskey", status.ToString());
                        //Sorin If student fills out yoe automatically
                        if (ProfessorInfoGroupBox.Enabled == false)
                        {
                            coma.Parameters.AddWithValue("@yoe", 0);
                        }
                        else
                        {
                            //Change to Text so that if user types it doesn't error out. Mitigated by disabling the ability to type in the dropdowns.
                            coma.Parameters.AddWithValue("@yoe", Int32.Parse(YearsExperienceDropBox.Text));
                        }
                        //Pulls up a form where the user can ACTUALL ENTER A USERNAME! PROGRESS!!!!!!
                        using (var login = new UNPW())
                        {
                            result = login.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                coma.Parameters.AddWithValue("@username", login.un); //Program.GetBytes(login.un));
                                coma.Parameters.AddWithValue("@password", login.pw); //Program.GetBytes(login.pw));
                                con.Open();
                                coma.ExecuteNonQuery();
                                if (filePath != null)
                                {
                                    DataTable table = new DataTable();
                                    DataTable table2 = new DataTable();
                                    using (SqlDataAdapter da = new SqlDataAdapter("SELECT UserKey FROM Users WHERE UserName = '" + login.un + "'", con))
                                        da.Fill(table);
                                    using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Files WHERE UserKey = " + table.Rows[0].Field<int>("UserKey"), con))
                                        da.Fill(table2);
                                    if (table2.Rows.Count != 0)
                                        coma = new SqlCommand("UPDATE Files SET [File] = '" + filePath + "' WHERE UserKey = " + table.Rows[0].Field<int>("UserKey") + ")", con);
                                    else
                                        coma = new SqlCommand("INSERT INTO Files([File], UserKey) VALUES('" + filePath + "', " + table.Rows[0].Field<int>("UserKey") + ")", con);
                                    coma.ExecuteNonQuery();
                                }
                                con.Close();
                                coma.Dispose();
                                if (StatusDropBox.Text == "Admin")
                                {
                                    MessageBox.Show("Inserted Administrator");
                                }
                                else
                                {
                                    MessageBox.Show("Inserted Instructor");
                                }
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("ha");
                            }
                        }
                    }
                    this.Hide();
                    var loginlogin = new LoginForm();
                    loginlogin.Closed += (s, args) => this.Close();
                    loginlogin.Show();
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClassesButton_Click(object sender, EventArgs e)
        {
            //--------------------------------------------------------12/8 Brittany - Needs to have second parameter 
                                                                            // as user being edited and fourth is user editing
            var classesForm = new ClassesForm(2, UserNameForForm, statusOfSelected, UserNameForForm, statusOfCurrent);
            this.Hide();
            
            classesForm.Closed += (s, args) => this.Close();
            classesForm.Show();
        }

        private void DropClassesButton_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            //--------------------------------------------------------12/8 Brittany - Needs to have second parameter 
                                                                                  // as user being edited and fourth is user editing
            var classesForm = new ClassesForm(1, UserNameForForm, statusOfSelected, UserNameForForm, statusOfCurrent);
            classesForm.Closed += (s, args) => this.Close();
            classesForm.Show();
        }

        private void YearsExperienceDropBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void NewUserEditForm_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(statusOfCurrent);

            //manages button visiability and access depending on new user or returning user

            if (statusOfCurrent == "admin" || statusOfCurrent == "student" || statusOfCurrent == "professor")
            {
                if (statusOfCurrent != "admin")
                {
                    StatusLabel.Visible = false;
                    StatusDropBox.Visible = false;
                    StatusDropBox.Enabled = false;
                    FirstNameTextBox.Enabled = false;
                    LastNameTextBox.Enabled = false;
                    if (statusOfCurrent == "student")
                    {
                        ProfessorInfoGroupBox.Visible = false;
                    }
                }
                //MessageBox.Show(UserNameForForm);
                SubmitButton.Text = "Update";

                string CS = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\CSharp.mdf;Integrated Security=True;Connect Timeout=30";

                using (SqlConnection UserCon = new SqlConnection())
                {
                    UserCon.ConnectionString = CS;
                    UserCon.Open();
                    //--------------------------------------12/8 Brittany - variables to store the data for the drop boxes
                    string state="";
                    string education="";
                    string yoe="";
                    //--------------------------------------12/8 Brittany - added a string to concatonate the command and UserNameForForm so it executes on any username
                    //--------------------------------------12/8 Brittany - LINE BELOW WILL BE THE ORIGINAL STRING USED WHEN USERNAME IS UNENCRYPTED
                    //String command = "SELECT * FROM Users WHERE UserName = '" + UserNameForForm + "';";


                    //--------------------------------------12/8 Brittany - the temporary string till username is unencripted
                    String command = "SELECT * FROM Users WHERE UserName = '" + UserNameForForm + "';";
                    SqlCommand SelectAllUser = new SqlCommand(command, UserCon);
                    using (SqlDataReader myReader = SelectAllUser.ExecuteReader())
                    {
                        while (myReader.Read())
                        {

                            FirstNameTextBox.Text = myReader[3].ToString();
                            LastNameTextBox.Text = myReader[4].ToString();
                            StreetTextBox.Text = myReader[5].ToString();
                            CityTextBox.Text = myReader[6].ToString();
                            ZipTextBox.Text = myReader[7].ToString();
                            EmailTextBox.Text = myReader[8].ToString();
                            PhoneTextBox.Text = myReader[9].ToString();
                            yoe = myReader[10].ToString();
                            //YearsExperienceDropBox.SelectedItem = YearsExperienceDropBox.FindStringExact(yoe);
                            YearsExperienceDropBox.SelectedText = myReader[10].ToString();
                            education = myReader[11].ToString();
                            state = myReader[12].ToString();
                        }

                    }
                    
                    String stateCommand = "SELECT * FROM State;";
                    SqlCommand selectState = new SqlCommand(stateCommand, UserCon);
                    using (SqlDataReader myReaderState = selectState.ExecuteReader())
                    {
                        while (myReaderState.Read())
                        {
                            //---------------------------------------------------------if StateKey == number in StateDropBox
                            if (myReaderState[0].ToString() == state)
                            {
                                StateDropBox.SelectedText = myReaderState[1].ToString();
                            }
                        }
                    }

                    String educationCommand = "SELECT * FROM Education;";
                    SqlCommand selectEducation = new SqlCommand(educationCommand, UserCon);
                    using (SqlDataReader myReaderEducation = selectEducation.ExecuteReader())
                    {
                        while (myReaderEducation.Read())
                        {
                            //---------------------------------------------------------if EducationKey == number in StateDropBox
                            if (myReaderEducation[0].ToString() == education)
                            {
                                EducationDropBox.SelectedText = myReaderEducation[1].ToString();
                            }
                        }
                    }
                }
            }
            else
            {
                ProfessorInfoGroupBox.Visible = false;
                ProfessorInfoGroupBox.Enabled = false;
                UserButtonGroupBox.Enabled = false;
                UserButtonGroupBox.Visible = false;
            }

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

                    if (statusOfCurrent != "admin")
                    {
                        EducationDropBox.Items.Remove("High School");
                    }
                }
            }
            foreach (GroupBox gb in this.Controls.OfType<GroupBox>())
                foreach (ComboBox cb in gb.Controls.OfType<ComboBox>())
                    cb.SelectedIndex = 0;


        }
        private Boolean validate()
        {
            Boolean bad = false;
            foreach (GroupBox gb in this.Controls.OfType<GroupBox>())
            {
                if (gb.Name == "PersonalInfoGroupBox" || gb.Name == "ContactInfoGroupBox")
                    foreach (Control c in gb.Controls)
                        if (c.Text == "")
                        {
                            MessageBox.Show(c.Name + " is blank");
                            bad = true;
                            break;
                        }
                if (bad == true)
                    break;
            }
            if (bad == true)
                return false;
            else
                return true;
        }

        private void StatusDropBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if ( StatusDropBox.Text == "Admin")
            {
                ProfessorInfoGroupBox.Visible = true;
                ProfessorInfoGroupBox.Enabled = true;
            }
            if (StatusDropBox.Text == "Student")
            {
                ProfessorInfoGroupBox.Visible = false;
            }
            if (StatusDropBox.Text == "Professor")
            {
                ProfessorInfoGroupBox.Visible = true;
                ProfessorInfoGroupBox.Enabled = true;
            }
        }

        private void OpenFilesButton_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\CSharp.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                con.Open();
                if (statusOfCurrent != null)
                    using (SqlDataAdapter da = new SqlDataAdapter("SELECT [File] FROM Files INNER JOIN Users ON Files.UserKey = Users.UserKey WHERE Users.UserName = '" + UserNameForForm + "'", con)) {
                        da.Fill(table);
                        filePath = table.Rows[0].Field<String>("File");
                    }
                else if (filePath == null)
                    MessageBox.Show("You have not uploaded a file.");
                con.Close();
            }
            if (filePath != null)
            {
                OpenFileDialog open = new OpenFileDialog();
                open.InitialDirectory = filePath.Substring(0, filePath.LastIndexOf("\\"));
                open.FileName = filePath.Substring(filePath.LastIndexOf("\\")+1);
                var result = open.ShowDialog();
                if (result == DialogResult.OK)
                    filePath = open.FileName;
            }
        }
    }
}
