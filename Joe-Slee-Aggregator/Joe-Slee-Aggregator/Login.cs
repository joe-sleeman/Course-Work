using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Joe_Slee_Aggregator
{
    public partial class Login : Form
    {
        DBManager dbMan;
        public Login()
        {
            InitializeComponent();
            dbMan = new DBManager();
            this.AcceptButton = btnLogin;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Pull data out of input.
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (dbMan.CheckUsernameAndPassword(username, password))
            {
                this.Hide();
                new Home(username).Show();
            }
            else
                MessageBox.Show("Invalid Username/Password combination.", "Invalid Username Or Password");
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Register(this).Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
