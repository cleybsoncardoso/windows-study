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
    public partial class SingIn : Form
    {
        Controller c;

        public SingIn()
        {
            InitializeComponent();
            this.c = new Controller();
            this.textBoxEmail.Text = "cley@gmail.com";
            this.TextBoxPassword.Text = "123456";
        }

        void myButton_Click(Object sender, System.EventArgs e)
        {
            MessageBox.Show("Click");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        public void UserCriado(string email)
        {
            this.textBoxEmail.Text = email;
            this.TextBoxPassword.Text = "";
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                FirebaseAuthLink fba = await this.c.login(this.textBoxEmail.Text, this.TextBoxPassword.Text);
                new ListPasswords(this.c).Show();
                this.TextBoxPassword.Text = "";
                this.Hide();
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            new SingUp(this).Show();
            this.Hide();
        }
    }
}
