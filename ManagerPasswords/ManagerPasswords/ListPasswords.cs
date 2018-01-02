using firebaseApplication.controller;
using firebaseApplication.model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace firebaseApplication
{
    /*
     * Class for manager password
     * 
     * 
     */
    public partial class ListPasswords : Form
    {
        Controller controller;
        IReadOnlyCollection<Firebase.Database.FirebaseObject<Passwords>> passWordFirebase;

        public ListPasswords(Controller controller)
        {
            this.controller = controller;
            InitializeComponent();
            //render columns and values of table
            listView1.View = View.Details;
            //show lines between cell of th table
            listView1.GridLines = true;
            //allows to select line of the table
            listView1.FullRowSelect = true;
            //render passwords in table
            this.renderPasswords();
        }

        /*
         * method for to render passwords of the user in table
         * 
         */
        public async void renderPasswords()
        {
            try
            {

                this.passWordFirebase = (IReadOnlyCollection<Firebase.Database.FirebaseObject<Passwords>>) await this.controller.getListPasswords();
                // clean table to render the updated password list
                listView1.Items.Clear();
                // position of the element in the table for find direct in list
                int count = 0;
                foreach (var passwordCurrent in this.passWordFirebase)
                {
                    
                    count++;
                    Passwords aux = (Passwords)passwordCurrent.Object;
                    ListViewItem itm = new ListViewItem(new String[3] { count.ToString(), aux.Login, aux.Password });
                    listView1.Items.Add(itm);
                }
                // clears data in login and password of the selected item in the list
                this.textBoxLoginView.Text = "";
                this.textBoxPasswordView.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /*
         * create password
         * 
         */
        private void button1_Click(object sender, EventArgs e)
        {
            using (AddPassword signUp = new AddPassword(this.controller))
            {
                new AddPassword(this.controller).ShowDialog();
                this.renderPasswords();
            }
        }

        /*
         * method for select a password
         * 
         * 
         */
        private void listView1_Click(object sender, EventArgs e)
        {
            //item selected
            var itemSelected = listView1.SelectedItems[0];
            //get password by id of the selected
            var aux = (Passwords)this.passWordFirebase.ElementAt(Int32.Parse(itemSelected.SubItems[0].Text) - 1).Object;
            // fill in the data with the selected password
            this.textBoxLoginView.Text = aux.Login;
            this.textBoxPasswordView.Text = aux.decrypt();
        }

        /*
         * update values of the password
         * 
         */
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var itemSelected = listView1.SelectedItems[0];
                var aux = this.passWordFirebase.ElementAt(Int32.Parse(itemSelected.SubItems[0].Text) - 1);
                this.controller.updatePassword(aux.Key, new Passwords(this.textBoxLoginView.Text, this.textBoxPasswordView.Text).encrypt());
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


        /*
         * Delete password
         * 
         */
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var itemSelected = listView1.SelectedItems[0];
                var aux = this.passWordFirebase.ElementAt(Int32.Parse(itemSelected.SubItems[0].Text) - 1);
                this.controller.deletePassword(aux.Key);
                MessageBox.Show("Deleted with success");
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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
