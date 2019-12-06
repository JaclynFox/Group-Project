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
    
    public partial class UNPW : Form
    {
        public String un { get { return this.un; } set { this.un = value; } }
        public String pw { get { return this.pw; } set { this.pw = value; } }
        public UNPW()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (Program.UserUnique(UserNameTextBox.Text))
            {
                this.un = UserNameTextBox.Text;
                this.pw = PasswordTextBox.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
                MessageBox.Show("That username is not unique. You need to pick a different one.");
        }
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
