using firebaseApplication;
using firebaseApplication.controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerPasswords
{
    public partial class SignIn : Form
    {
        Controller controller;

        public SignIn()
        {
            InitializeComponent();
            this.controller = new Controller();
            this.textBoxEmail.Text = "";
            this.TextBoxPassword.Text = "";
        }

        //Method responsible for show screen sign up 
        private void button1_Click(object sender, EventArgs e)
        {
            using (SignUp signUp = new SignUp())
            {
                signUp.ShowDialog();
            }
        }

        //Method responsible for sign in
        private async void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                //sign in
                await this.controller.login(this.textBoxEmail.Text, this.TextBoxPassword.Text);
                //hiden screen SignIn for block for show only screen listPasswords
                this.Hide();
                //redirect for list passwords of the user logged
                using(ListPasswords listPasswords= new ListPasswords(this.controller))
                {
                    listPasswords.ShowDialog();
                    this.TextBoxPassword.Text = "";
                    this.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SignIn_Load(object sender, EventArgs e)
        {

        }
    }
}
