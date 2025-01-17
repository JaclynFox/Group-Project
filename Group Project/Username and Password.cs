﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group_Project
{
    
    public partial class UNPW : Form
    {
        public string UserNameForForm;
        public String un;
        public String pw;
        public UNPW()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            int validated = 0;
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
                            validated++;
                        }
                    }
                }
            }
            
            if (validated == 0)      //if (Program.UserUnique(UserNameTextBox.Text))
            {
                Boolean answer = TestPassword(PasswordTextBox.Text);
                if (TestPassword(PasswordTextBox.Text)) {
                    this.un = UserNameTextBox.Text;
                    this.pw = PasswordTextBox.Text;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                    MessageBox.Show(" The password has to contain a capital letter, a lower case letter, " +
                        "a special character, a number and at least 8 characters in length.");
            }
            else
                MessageBox.Show("That username is not unique. You need to pick a different one.");
        }
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private Boolean TestPassword(string s)
        {
            // password that checks for at least:
            // 1 upper case letter
            // 1 lower case letter
            // 1 number
            // 1 of the specified characteristics
            // minimum of 8 characters in length
            Regex regex = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
            Match match = regex.Match(s);
            return match.Success;
        }

    }
    
}
