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
    public partial class AddFeeCategory : Form
    {
        public string id;
        SidePanel dis = new SidePanel();
        public AddFeeCategory(SidePanel dis)
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
                fees.SaveCategory(txtTitle.Text, txtAmount.Text, txtDescription.Text);

                var myForm = new FeeManagement(dis);
                AllForms.MyForms(myForm, dis);
            }

            //else if (btnSave.Text.Equals("Update"))
            //{
            //    fees.UpdateCategory(id,txtTitle.Text);

            //    var myForm = new FeeManagement(dis);
            //    AllForms.MyForms(myForm, dis);
            //}
        }

        private void txtLabel_Enter(object sender, EventArgs e)
        {
            txtTitle.Focus();
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            allkeypress.numbersonly(sender, e);
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
