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
    public partial class AddStrand : Form
    {
        SidePanel dis = new SidePanel();
        public AddStrand(SidePanel dis)
        {
            InitializeComponent();
            this.dis = dis;
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text.Equals("Save"))
            {
                AllStrand.SaveStrand(txtStrandCode.Text, txtDescription.Text);

                var myForm = new ManageStrandList(dis);
                AllForms.MyForms(myForm, dis);
            }
        }
    }
}
