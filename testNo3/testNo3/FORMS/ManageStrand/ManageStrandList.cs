using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testNo3.FORMS.ManageStrand
{
    public partial class ManageStrandList : Form
    {
        SidePanel dis = new SidePanel();
        public ManageStrandList(SidePanel dis)
        {
            InitializeComponent();
            this.dis = dis;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            alldatagrid.DatagridStrand(dgvStrand);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var myForm = new AddStrand(dis);
            AllForms.MyForms(myForm, dis);
        }
    }
}
