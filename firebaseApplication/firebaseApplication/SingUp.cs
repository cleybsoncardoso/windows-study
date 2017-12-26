﻿using firebaseApplication.controller;
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
    public partial class SingUp : Form
    {

        Controller c = new Controller();
        SingIn singIn;

        public SingUp(SingIn singIn)
        {
            InitializeComponent();
            this.singIn = singIn;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine(this.textBoxEmail.Text);
                Console.WriteLine(this.TextBoxPassword.Text);
                this.c.createUser(this.textBoxEmail.Text, this.TextBoxPassword.Text);
                MessageBox.Show("create with success");
                this.singIn.Show();
                this.singIn.UserCriado(this.textBoxEmail.Text);
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
