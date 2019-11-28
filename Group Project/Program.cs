using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

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
            if (!File.Exists("Users.txt"))
            {
                using (StreamWriter sw = File.CreateText("Users.txt"))
                {
                    byte[] salt = new byte[64];
                    new RNGCryptoServiceProvider().GetBytes(salt);
                    var user = new Rfc2898DeriveBytes("Admin", salt, 10000);
                    byte[] hash = user.GetBytes(64);
                    user.Dispose();
                    byte[] hashbytes = new byte[128];
                    Array.Copy(salt, 0, hashbytes, 0, 64);
                    Array.Copy(hash, 0, hashbytes, 64, 64);
                    String userhash = Convert.ToBase64String(hashbytes);
                    sw.WriteLine(userhash);
                    byte[] pepper = new byte[64];
                    new RNGCryptoServiceProvider().GetBytes(pepper);
                    var password = new Rfc2898DeriveBytes("Pa$$w0rd", pepper, 10000);
                    byte[] passhash = password.GetBytes(64);
                    byte[] passhashbytes = new byte[128];
                    Array.Copy(pepper, 0, passhashbytes, 0, 64);
                    Array.Copy(passhash, 0, passhashbytes, 64, 64);
                    String passhashstring = Convert.ToBase64String(passhashbytes);
                    sw.WriteLine(passhashstring);
                    password.Dispose();
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
