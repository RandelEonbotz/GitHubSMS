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
    public partial class AddFees : Form
    {
        public int strucID;
        SidePanel dis = new SidePanel();

        List<int> trueIndexes = new List<int>();
        public AddFees(SidePanel dis)
        {
            InitializeComponent();
            this.dis = dis;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            alldatagrid.DatagridCategory(dgvAcctList);
            alldatagrid.DatagridSelectedAcctList(dgvSelectedList, strucID);

        }





        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void dgvAcctList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string id = dgvAcctList.Rows[dgvAcctList.CurrentRow.Index].Cells[0].Value?.ToString();
            fees.SaveSelectedAcct(strucID, id);
            alldatagrid.DatagridSelectedAcctList(dgvSelectedList, strucID);
        }

        private void dgvAcctList_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvAcctList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
