using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace Group_Project
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
        /* Method takes a username and password, then checks it against the ones stored in the database. Made a method for this because it will be used in multiple places.
         * Accessable by calling Program.CheckLogin(username, password). Returns a bool array with position 0 being the username and position 1 being the password so you know which is bad.*/
        public static Boolean[] CheckLogin(String un, String pw)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\CSharp.mdf;Integrated Security=True;Connect Timeout=30");
            DataTable table = new DataTable();
            Boolean[] boo = new Boolean[2];
            con.Open();
            using (SqlDataAdapter da = new SqlDataAdapter("SELECT UserName, Password FROM Users", con))
                da.Fill(table);
            con.Close();
            con.Dispose();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                /*Simple salting and hashing algorithym to check the username since I decided that the username should be hashed as well.
                 * From a security standpoint, this is a very good move, but would increase overhead quite a bit as now both username and
                 * password are stored in a 128 byte binary field. Not much, but if you have 1000 users, that's already 256kb of storage
                 * per user just for their login information. */
                    byte[] pepper = new byte[64];
                    byte[] userbyte = table.Rows[i].Field<byte[]>("UserName");
                    Array.Copy(userbyte, 0, pepper, 0, 64);
                    var userthing = new Rfc2898DeriveBytes(un, pepper, 10000);
                    byte[] userhash = userthing.GetBytes(64);
                    userthing.Dispose();
                    boo[0] = true;
                for (int ii = 0; ii < 64; ii++)
                    if (userbyte[ii + 64] != userhash[ii])
                        boo[0] = false;
                    //Password check
                    if (boo[0] == true)
                    {
                        byte[] salt = new byte[64];
                        byte[] hashbyte = table.Rows[i].Field<byte[]>("Password");
                        Array.Copy(hashbyte, 0, salt, 0, 64);
                        var passthing = new Rfc2898DeriveBytes(pw, salt, 10000);
                        byte[] hash = passthing.GetBytes(64);
                        passthing.Dispose();
                        boo[1] = true;
                        for (int ctDuku = 0; ctDuku < 64; ctDuku++)
                            if (hashbyte[i + 64] != hash[i])
                                boo[1] = false;
                        if (boo[1] == true)
                        {
                            break;
                        }
                    }
                }
            return boo;
            }
        //Checks if the username entered is unique. Pretty self-explanitory.
        public static Boolean UserUnique(String un)
        {
            DataTable table = new DataTable();
            Boolean valid = false;
            using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\CSharp.mdf;Integrated Security=True;Connect Timeout=30"))
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT UserName FROM Users", con))
                   da.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                byte[] pepper = new byte[64];
                byte[] userbyte = table.Rows[i].Field<byte[]>("UserName");
                Array.Copy(userbyte, 0, pepper, 0, 64);
                var userthing = new Rfc2898DeriveBytes(un, pepper, 10000);
                byte[] userhash = userthing.GetBytes(64);
                userthing.Dispose();
                valid = true;
                for (int ii = 0; ii < 64; ii++)
                    if (userbyte[ii + 64] != userhash[ii])
                        valid = false;
                if (valid == true)
                    break;
            }
            if (valid == true)
                return false;
            else
                return true;
        }
        public static byte[] GetBytes(String i)
        {
            byte[] salt = new byte[64];
            var passthing = new Rfc2898DeriveBytes(i, salt, 10000);
            byte[] hash = passthing.GetBytes(64);
            passthing.Dispose();
            byte[] returnthis = new byte[128];
            Array.Copy(salt, 0, returnthis, 0, 64);
            Array.Copy(hash, 0, returnthis, 64, 64);
            return returnthis;
        }
    }
}