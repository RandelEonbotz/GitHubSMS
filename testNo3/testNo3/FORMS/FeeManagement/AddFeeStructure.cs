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

namespace testNo3.FORMS.FeeManagement
{
    public partial class AddFeeStructure : Form
    {
        SidePanel dis = new SidePanel();
        public AddFeeStructure(SidePanel dis)
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
                fees.SaveFeeStructure(txtStructure.Text);

                var myForm = new FeeStructure(dis);
                AllForms.MyForms(myForm, dis);
            }



        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            var myForm = new FeeStructure(dis);
            AllForms.MyForms(myForm, dis);
        }
    }
}
