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
        public ListPasswords()
        {
            InitializeComponent();
            listView1.View = View.Details;

            //Add items in the listview
            foreach (var aux in this.c.getListPasswords("3WJGxiPMCNgwI09yIFuIGVlxmyp1"))
            {

                ListViewItem itm = new ListViewItem(aux.ToArray());
                listView1.Items.Add(itm);
            }

        }
    }
}
