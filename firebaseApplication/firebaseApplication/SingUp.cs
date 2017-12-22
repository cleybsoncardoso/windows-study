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
        FirebaseAutentication fba;

        public SingUp()
        {
            this.fba = new FirebaseAutentication();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bool created = this.fba.singUp(this.textBoxEmail.Text, this.TextBoxPassword.Text);
                if (created)
                {
                    MessageBox.Show("Criada com sucesso");
                    this.Dispose();
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
