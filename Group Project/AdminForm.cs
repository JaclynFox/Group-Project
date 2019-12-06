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
    public partial class AdminForm : Form
    {
        private static int num = 0;
        public static Form ClassesForm;
        public AdminForm()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
                newUser.Closed += (s, args) => this.Close();
                newUser.Show();
            }
        }

        private void EditClassesButton_Click(object sender, EventArgs e)
        {
            if (UsersListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select from the list.");
            }
            else
            {
                this.Hide();
                var classesForm = new ClassesForm(2, UsersListBox.SelectedItem.ToString(), "admin");
                classesForm.Closed += (s, args) => this.Close();
                classesForm.Show();
            }
        }

        private void StudentUserButton_Click(object sender, EventArgs e)
        {
            UsersListBox.Items.Clear();
            AddButton.Visible = true;
            DropButton.Visible = true;
            AddButton.Text = "Add Class to Student";
            DropButton.Text = "Drop Class from Student";
            int start = 1;
            while (start < 4)
            {
                UsersListBox.Items.Add("Student User " + start.ToString());
                start++;
            }
        }

        private void InstructorUserButton_Click(object sender, EventArgs e)
        {
            UsersListBox.Items.Clear();
            AddButton.Visible = true;
            DropButton.Visible = true;
            AddButton.Text = "Add Class to Instructor";
            DropButton.Text = "Drop Class from Instructor";
            int start = 1;
            while (start < 4)
            {
                UsersListBox.Items.Add("Instructor User " + start.ToString());
                start++;
            }
        }

        private void AdminUserButton_Click(object sender, EventArgs e)
        {
            UsersListBox.Items.Clear();
            AddButton.Visible = false;
            DropButton.Visible = false;
            int start = 1;
            while (start < 4)
            {
                UsersListBox.Items.Add("Admin User " + start.ToString());
                start++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClassesForm.Show();
        }

        private void DropButton_Click(object sender, EventArgs e)
        {
            if (UsersListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select from the list.");
            }
            else
            {
                this.Hide();
                var classesForm = new ClassesForm(1, UsersListBox.SelectedItem.ToString(), "admin");
                classesForm.Closed += (s, args) => this.Close();
                classesForm.Show();
            }
        }

        private void AddNewClassButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var classesForm = new ClassesForm(4, "none", "admin");
            classesForm.Closed += (s, args) => this.Close();
            classesForm.Show();
        }

        private void DeleteExistingClassButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var classesForm = new ClassesForm(3, "none", "admin");
            classesForm.Closed += (s, args) => this.Close();
            classesForm.Show();
        }
    }
}
