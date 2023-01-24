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
    public partial class AddMatriculation : Form
    {
        public string id;
        public static string studID;

        SidePanel dis = new SidePanel();
        public AddMatriculation(SidePanel dis)
        {
            InitializeComponent();
            this.dis = dis;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Display();
            refreshgrids();
            SetMatriculation.totsum(dgvAccountItem, txtAccntTotal);

        }
        public void Display()
        {
            studinfo.ShowStudentJHSselected(studID, txtName, txtGradeLevel);
            txtStudentID.Text = studID;
        }

        public void refreshgrids()
        {
            alldatagrid.DatagridSelectedMatpack(dgvAccountItem, studID);
        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            var myForm = new SelectAccountItem();
            myForm.dgv = dgvAccountItem;
            myForm.txt = txtAccntTotal;
            AllForms.MyOtherForms(myForm, this);
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            var myForm = new SelectPackages();
            myForm.dgv = dgvAccountItem;
            myForm.txt = txtAccntTotal;
            AllForms.MyOtherForms(myForm, this);

        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            //studinfo.ActivateSHStudent(id);

            //systemlogs.userlogs($"student: {studID} Has been activated");
            ////selectlimits();
            //studinfo.mbs($"student: {studID}\nHas been activated");
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            var myForm = new SelectDiscount();
            AllForms.MyOtherForms(myForm, this);

        }

        private void dgvAccountItem_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {

        }


        public void accounttotalsum()
        {
            double sum = 0;
            // amount = 0;
            for (int i = 0; i < dgvAccountItem.Rows.Count; i++)
            {
                sum += Convert.ToDouble(dgvAccountItem.Rows[i].Cells[3].Value);


            }
            txtAccntTotal.Text = sum.ToString("N");
        }

        private void dgvAccountItem_RowDirtyStateNeeded(object sender, QuestionEventArgs e)
        {

        }

        private void dgvAccountItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {





        }

        private void dgvAccountItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dgvAccountItem.Rows[dgvAccountItem.CurrentRow.Index].Cells[0].Value?.ToString();
            string Name = dgvAccountItem.Rows[dgvAccountItem.CurrentRow.Index].Cells[1].Value?.ToString();
            DialogResult dialogResult = MessageBox.Show($"You want to Remove: {Name}?", "Notification", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {


                studinfo.mbs($"Item Removed: {Name}");

            }
            else
            {

            }
        }
    }
}
