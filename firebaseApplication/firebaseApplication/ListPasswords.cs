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
    public partial class ListPasswords : Form
    {
        Controller c;
        IReadOnlyCollection<Firebase.Database.FirebaseObject<Passwords>> passWordFirebase;

        public ListPasswords(Controller c)
        {
            this.c = c;
            InitializeComponent();
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            this.renderPasswords();
            //this.c.getListPasswords("Y2xleUBnbWFpbC5jb20=").Subscribe(d => d.ToString());
        }

        public async void renderPasswords()
        {
            try
            {

            this.passWordFirebase = await this.c.getListPasswords().OnceAsync<Passwords>();
            listView1.Items.Clear();
            int count = 1;
            foreach (var passwordCurrent in this.passWordFirebase)
            {
                Passwords aux = (Passwords)passwordCurrent.Object;
                ListViewItem itm = new ListViewItem(new String[3] { count.ToString(), aux.Login, aux.Password });
                listView1.Items.Add(itm);
                count++;
            }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new AddPassword(this, this.c).Show();
        }

        private Passwords getItem(String login)
        {
            return null;
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            var itemSelected = listView1.SelectedItems[0];
            var aux = (Passwords)this.passWordFirebase.ElementAt(Int32.Parse(itemSelected.SubItems[0].Text) - 1).Object;
            this.textBoxLoginView.Text = aux.Login;
            this.textBoxPasswordView.Text = aux.Password;
            Console.WriteLine(aux.Login);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var itemSelected = listView1.SelectedItems[0];
                var aux = this.passWordFirebase.ElementAt(Int32.Parse(itemSelected.SubItems[0].Text) - 1);
                this.c.updatePassword(aux.Key, new Passwords(this.textBoxLoginView.Text, this.textBoxPasswordView.Text));
                MessageBox.Show("Update success");
                this.renderPasswords();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show("Select a password");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var itemSelected = listView1.SelectedItems[0];
                var aux = this.passWordFirebase.ElementAt(Int32.Parse(itemSelected.SubItems[0].Text) - 1);
                this.c.deletePassword(aux.Key);
                MessageBox.Show("Deleted with success");
                this.textBoxLoginView.Text = "";
                this.textBoxPasswordView.Text = "";
                this.renderPasswords();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show("Select a password");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
