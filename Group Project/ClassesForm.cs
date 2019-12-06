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
    public partial class ClassesForm : Form
    {
        private String gobackto;
        private int dropAdd;
        private bool admin = true;
        public ClassesForm(int num, string selected, String gbt)
        {
            InitializeComponent();
            gobackto = gbt;
            dropAdd = num;

            if (dropAdd == 1)                           //if dropping
            {
                DropGroup.Visible = true;
                AddGroup.Visible = false;
                SecondGroupBox.Visible = false;
                this.Size = new System.Drawing.Size(400, 420);
                label1.Text = selected;
            }
            else if (dropAdd == 2)                    //if adding
            {
                DropGroup.Visible = false;
                SecondGroupBox.Visible = true;
                this.Size = new System.Drawing.Size(400, 600);
                label1.Text = selected;
            } 
            else if (dropAdd == 3)                      //deleting current class
            {
                DropGroup.Visible = true;
                AddGroup.Visible = false;
                SecondGroupBox.Visible = false;
                this.Size = new System.Drawing.Size(400, 420);
                DropSubmitButton.Text = "Delete";
                label1.Text = "Delete A Class From List";
            }
            else if (dropAdd == 4)                      //adding new class
            {
                DropGroup.Visible = false;
                SecondGroupBox.Visible = true;
                this.Size = new System.Drawing.Size(400, 600);
                DropSubmitButton.Text = "Create";
                label1.Text = "Add A New Class";
            }
            
        }
            
        

        private void ExitButton_Click(object sender, EventArgs e)
        {
            if (gobackto == "admin")
            {
                this.Hide();
                var adminform = new AdminForm();
                adminform.Closed += (s, args) => this.Close();
                adminform.Show();
            }
            else if (gobackto == "new")
            {
                this.Hide();
                var newform = new NewUserEditForm();
                newform.Closed += (s, args) => this.Close();
                newform.Show();
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Action Completed (But was it?).");
        }

        private void DropExitButton_Click(object sender, EventArgs e)
        {
            if (gobackto == "admin")
            {
                this.Hide();
                var adminform = new AdminForm();
                adminform.Closed += (s, args) => this.Close();
                adminform.Show();
            }
            else if (gobackto == "new")
            {
                this.Hide();
                var newform = new NewUserEditForm();
                newform.Closed += (s, args) => this.Close();
                newform.Show();
            }
        }
    }
}
