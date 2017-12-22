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
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new SingUp().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.c.login(this.textBoxEmail.Text, this.TextBoxPassword.Text);
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
