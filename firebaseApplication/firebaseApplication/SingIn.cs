using Firebase.Auth;
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

namespace firebaseApplication
{
    /**
     * Class responsible for sign in
     * 
     */
    public partial class SignIn : Form
    {
        Controller controller;

        public SignIn()
        {
            InitializeComponent();
            this.controller = new Controller();
            this.textBoxEmail.Text = "cley@gmail.com";
            this.TextBoxPassword.Text = "123456";
        }

        //Method responsible for sign in
        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //sign in
                await this.controller.login(this.textBoxEmail.Text, this.TextBoxPassword.Text);
                //redirect for list passwords of the user logged
                new ListPasswords(this.controller).Show();
                //hiden screen SignIn for block for show only screen listPasswords
                this.Hide();
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Method responsible for show screen sign up 
        private void button1_Click_1(object sender, EventArgs e)
        {
            using (SignUp signUp = new SignUp())
            {
                signUp.ShowDialog();
            }
        }
    }
}
