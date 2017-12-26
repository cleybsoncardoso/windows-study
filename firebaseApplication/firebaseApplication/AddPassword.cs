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
    public partial class AddPassword : Form
    {
        Controller c;
        ListPasswords listPassword;

        public AddPassword(ListPasswords listPassword)
        {
            this.c = new Controller();
            this.listPassword = listPassword;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.c.addPassword(new Passwords(this.textBox1.Text, this.textBox2.Text));
                MessageBox.Show("Password added with success");
                this.listPassword.renderPasswords();
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
