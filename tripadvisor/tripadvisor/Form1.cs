using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tripadvisor.controller;
using tripadvisor.model;

namespace tripadvisor
{
    public partial class Form1 : Form
    {
        private Controller c;

        public Form1()
        {
            this.c = new Controller();
            this.c.addUser(new User("cley", "123"));
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bool logged = this.c.singin(this.textBox1.Text, this.textBox2.Text);
                if (logged)
                {
                    MessageBox.Show("Logged with success!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
