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
    public partial class FeeManagement : Form
    {
        SidePanel dis = new SidePanel();
        public FeeManagement(SidePanel dis)
        {
            InitializeComponent();
            this.dis = dis;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            alldatagrid.DatagridCategory(dgvCategories);

        }

        public void Showcategoryfee()
        {

        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            var myForm = new AddFeeCategory(dis);
            AllForms.MyForms(myForm, dis);

        }

        private void dgvCategories_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvCategories.Columns[e.ColumnIndex].Name;
            string id = dgvCategories.Rows[dgvCategories.CurrentRow.Index].Cells[0].Value?.ToString();
            string strucName = dgvCategories.Rows[dgvCategories.CurrentRow.Index].Cells[1].Value?.ToString();
            // string studid = dgvFee.Rows[dgvFee.CurrentRow.Index].Cells[2].Value?.ToString();
            //string gl = dgvCategories.Rows[dgvCategories.CurrentRow.Index].Cells[5].Value?.ToString();

            if (colName.Equals("edit"))
            {

                var myForm = new AddFeeCategory(dis);
                myForm.btnSave.Text = "Update";
                myForm.id = id;
                myForm.txtLabel.Text = "Edit Category Fee";
                myForm.txtTitle.Text = strucName;
                AllForms.MyForms(myForm, dis);

            }
            else if (colName.Equals("delete"))
            {
                DialogResult dialogResult = MessageBox.Show($"You want to Remove this?", "Notification", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    fees.RemoveCategory(id, strucName, dgvCategories);


                }
                else
                {

                }
            }
        }
    }
}
