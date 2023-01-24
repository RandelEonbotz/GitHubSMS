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
    public partial class FeeStructure : Form
    {
        SidePanel dis = new SidePanel();
        public FeeStructure(SidePanel dis)
        {
            InitializeComponent();
            this.dis = dis;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            alldatagrid.DatagridFeeStructure(dgvFee);


        }



        private void btnAddFeeStruc_Click(object sender, EventArgs e)
        {
            var myForm = new AddFeeStructure(dis);
            AllForms.MyForms(myForm, dis);

        }

        private void dgvFee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvFee.Columns[e.ColumnIndex].Name;
            string id = dgvFee.Rows[dgvFee.CurrentRow.Index].Cells[0].Value?.ToString();
            string strucName = dgvFee.Rows[dgvFee.CurrentRow.Index].Cells[1].Value?.ToString();


            if (colName.Equals("add"))
            {

                var myForm = new AddFees(dis);
                myForm.strucID = Convert.ToInt32(id);
                myForm.struckname.Text = strucName;
                AllForms.MyForms(myForm, dis);



            }
            else if (colName.Equals("delete"))
            {
                DialogResult dialogResult = MessageBox.Show($"You want to Remove this?", "Notification", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {


                    fees.RemoveFeeStructure(id, strucName, dgvFee);



                }
                else
                {

                }
            }

        }
    }
}
