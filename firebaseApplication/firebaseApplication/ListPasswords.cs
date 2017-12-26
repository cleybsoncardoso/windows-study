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
        Controller c = new Controller();
        IReadOnlyCollection<Firebase.Database.FirebaseObject<Passwords>> passWordFirebase;

        public ListPasswords()
        {
            InitializeComponent();
            listView1.View = View.Details;
            this.renderPasswords();
            //this.c.getListPasswords("Y2xleUBnbWFpbC5jb20=").Subscribe(d => d.ToString());
        }

        public async void renderPasswords()
        {
            this.passWordFirebase = await this.c.getListPasswords().OnceAsync<Passwords>();
            listView1.Items.Clear();
            foreach (var passwordCurrent in this.passWordFirebase)
            {
                Passwords aux = (Passwords)passwordCurrent.Object;
                ListViewItem itm = new ListViewItem(aux.ToArray());
                listView1.Items.Add(itm);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new AddPassword(this).Show();
        }
    }
}
