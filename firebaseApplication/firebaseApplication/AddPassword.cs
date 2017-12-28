using firebaseApplication.controller;
using firebaseApplication.model;
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
    public partial class AddPassword : Form
    {
        Controller c;

        public AddPassword( Controller c)
        {
            this.c = c;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.c.addPassword(new Passwords(this.textBox1.Text, this.textBox2.Text).encrypt());
                MessageBox.Show("Password added with success");
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
