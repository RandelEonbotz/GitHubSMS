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

namespace testNo3.FORMS.Matriculation
{
    public partial class SelectAccountItem : Form
    {
        public DataGridView dgv;
        public TextBox txt;
        public SelectAccountItem()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            alldatagrid.DatagridCategory(dgvAccountItem);
        }

        private void dgvAccountItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dgvAccountItem.Rows[dgvAccountItem.CurrentRow.Index].Cells[0].Value?.ToString();
            string Name = dgvAccountItem.Rows[dgvAccountItem.CurrentRow.Index].Cells[1].Value?.ToString();
            DialogResult dialogResult = MessageBox.Show($"You want to add Account Item: {Name}?", "Notification", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SetMatriculation.SelectAccountItem(AddMatriculation.studID, id);

                alldatagrid.DatagridSelectedMatpack(dgv, AddMatriculation.studID);
                SetMatriculation.totsum(dgv, txt);
                studinfo.mbs($"Package Added: {Name}");

            }
            else
            {

            }

        }
    }
}
