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
    /*
     * Class of sign up users
     */
    public partial class SignUp : Form
    {

        Controller controller = new Controller();

        public SignUp()
        {
            InitializeComponent();
        }

        //method for create of user
        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                await this.controller.createUser(this.textBoxEmail.Text, this.TextBoxPassword.Text);
                MessageBox.Show("create with success");
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
