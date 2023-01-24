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

namespace testNo3.FORMS.Discount
{
    public partial class ManageDiscount : Form
    {
        SidePanel dis = new SidePanel();
        public ManageDiscount(SidePanel dis)
        {
            InitializeComponent();
            this.dis = dis;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StudentDiscount.ShowDiscount(dgvDiscount);

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var myForm = new AddDiscount(dis);
            AllForms.MyForms(myForm, dis);
        }



    }
}
