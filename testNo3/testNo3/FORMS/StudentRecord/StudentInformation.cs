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
using testNo3.FORMS.NewApplicants;

namespace testNo3.FORMS.StudentRecord
{
    public partial class StudentInformation : Form
    {
        SidePanel dis = new SidePanel();
        public StudentInformation(SidePanel dis)
        {
            InitializeComponent();
            this.dis = dis;

        }

        public static void disableButton(Button[] values)
        {
            foreach (var value in values)
            {
                value.Enabled = true;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            disPaging();
            selectlimits();
        }

        public void disPaging()
        {

            Button[] allBtn = { btnBack, btnFirst, btnNext, btnLast };
            disableButton(allBtn);




            holder.limit = 10;
            holder.offset_ = 0;
            holder.total = 0;
            holder.page = 1;

            holder.lastpage = 0;
            holder.lastP = 0;
            holder.value = 0;









            // ====== Start ====== paging =====================

            if (tabControl1.SelectedIndex == 0)
            {
                displayData(holder.limit, holder.offset_);
                //comboBox3.SelectedIndex = 0;
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                displayJHStudent(holder.limit, holder.offset_);
                //comboBox3.SelectedIndex = 0;
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                displaySHStudent(holder.limit, holder.offset_);
                //comboBox3.SelectedIndex = 0;
            }



            comboBox3.SelectedIndex = 0;
            if (holder.offset_ == 0)
            {
                btnBack.Enabled = false;
                btnFirst.Enabled = false;
            }
            if (holder.offset_ >= holder.total - holder.limit)
            {
                btnNext.Enabled = false;
                btnLast.Enabled = false;
            }
            label5.Text = holder.page.ToString();


            // ====== end ====== paging =====================


        }


        public void displayData(int limits, int offset)
        {

            dgvStudents.Rows.Clear();
            Connection connect = new Connection();

            MySqlDataReader mdr;


            try
            {



                string sql = $"select count(*) total from (select * from student) foo01";


                connect.conn = connect.getcon();
                connect.conn.Open();
                connect.cmd = new MySqlCommand(sql, connect.conn);
                mdr = connect.cmd.ExecuteReader();



                if (mdr.HasRows)
                {
                    while (mdr.Read())
                    {

                        if (!mdr.IsDBNull(0))
                        {
                            holder.total = Convert.ToInt32(mdr["total"]);

                            txttotalpages.Text = holder.total.ToString();

                        }

                    }
                }




                connect.conn.Close();



            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("doesn't exist"))
                {
                    MessageBox.Show("view table are missing");
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }

            }





            try
            {



                string sql = $"select * from student LIMIT {limits} OFFSET {offset}";


                connect.conn = connect.getcon();
                connect.conn.Open();
                connect.cmd = new MySqlCommand(sql, connect.conn);
                mdr = connect.cmd.ExecuteReader();



                if (mdr.HasRows)
                {
                    while (mdr.Read())
                    {

                        if (!mdr.IsDBNull(0))
                        {
                            //   total = Convert.ToInt32(mdr["total"]);

                            //  txttotalpages.Text = total.ToString();

                            dgvStudents.Rows.Add(mdr["RegisterID"].ToString(), $"{mdr["LastName"]}, {mdr["FirstName"]} {mdr["MiddleName"]} {mdr["Suffix"]}", mdr["Gender"].ToString(), Convert.ToDateTime(mdr["DateRegistered"]).ToString("MMM dd, yyyy"));

                        }

                    }
                }




                connect.conn.Close();

                this.dgvStudents.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                this.dgvStudents.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                this.dgvStudents.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("doesn't exist"))
                {
                    MessageBox.Show("table are missing");
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }

            }



        }




        public void displayJHStudent(int limits, int offset)
        {

            dgvJHStudents.Rows.Clear();
            Connection connect = new Connection();

            MySqlDataReader mdr;


            try
            {



                string sql = $"select count(*) total from (select * from jhstudentrecord where Status = 'Inactive') foo01";


                connect.conn = connect.getcon();
                connect.conn.Open();
                connect.cmd = new MySqlCommand(sql, connect.conn);
                mdr = connect.cmd.ExecuteReader();



                if (mdr.HasRows)
                {
                    while (mdr.Read())
                    {

                        if (!mdr.IsDBNull(0))
                        {
                            holder.total = Convert.ToInt32(mdr["total"]);

                            txttotalpages.Text = holder.total.ToString();

                        }

                    }
                }




                connect.conn.Close();



            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("doesn't exist"))
                {
                    MessageBox.Show("view table are missing");
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }

            }





            try
            {



                string sql = $"call Show_JHStudent( {limits},{offset},'Inactive');";


                connect.conn = connect.getcon();
                connect.conn.Open();
                connect.cmd = new MySqlCommand(sql, connect.conn);
                mdr = connect.cmd.ExecuteReader();



                if (mdr.HasRows)
                {
                    while (mdr.Read())
                    {

                        if (!mdr.IsDBNull(0))
                        {
                            //   total = Convert.ToInt32(mdr["total"]);

                            //  txttotalpages.Text = total.ToString();

                            dgvJHStudents.Rows.Add(mdr["SRID"].ToString(), mdr["RegisterID"].ToString(), mdr["StudentID"].ToString(), $"{mdr["LastName"]}, {mdr["FirstName"]} {mdr["MiddleName"]} {mdr["Suffix"]}", mdr["Gender"].ToString(), mdr["GradeLevel"].ToString(), Convert.ToDateTime(mdr["DateRecord"]).ToString("MMM dd, yyyy"));

                        }

                    }
                }




                connect.conn.Close();

                this.dgvJHStudents.Columns[3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                this.dgvJHStudents.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                this.dgvJHStudents.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("doesn't exist"))
                {
                    MessageBox.Show("table are missing");
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }

            }



        }

        public void displaySHStudent(int limits, int offset)
        {

            dgvSHStudents.Rows.Clear();
            Connection connect = new Connection();

            MySqlDataReader mdr;


            try
            {



                string sql = $"select count(*) total from (select * from shstudentrecord where Status = 'Inactive') foo01";


                connect.conn = connect.getcon();
                connect.conn.Open();
                connect.cmd = new MySqlCommand(sql, connect.conn);
                mdr = connect.cmd.ExecuteReader();



                if (mdr.HasRows)
                {
                    while (mdr.Read())
                    {

                        if (!mdr.IsDBNull(0))
                        {
                            holder.total = Convert.ToInt32(mdr["total"]);

                            txttotalpages.Text = holder.total.ToString();

                        }

                    }
                }




                connect.conn.Close();



            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("doesn't exist"))
                {
                    MessageBox.Show("view table are missing");
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }

            }





            try
            {



                string sql = $"call Show_SHStudent( {limits},{offset},'Inactive');";


                connect.conn = connect.getcon();
                connect.conn.Open();
                connect.cmd = new MySqlCommand(sql, connect.conn);
                mdr = connect.cmd.ExecuteReader();



                if (mdr.HasRows)
                {
                    while (mdr.Read())
                    {

                        if (!mdr.IsDBNull(0))
                        {
                            //   total = Convert.ToInt32(mdr["total"]);

                            //  txttotalpages.Text = total.ToString();

                            dgvSHStudents.Rows.Add(mdr["SSRID"].ToString(), mdr["RegisterID"].ToString(), mdr["StudentID"].ToString(), $"{mdr["LastName"]}, {mdr["FirstName"]} {mdr["MiddleName"]} {mdr["Suffix"]}", mdr["Gender"].ToString(), mdr["GradeLevel"].ToString(), mdr["Term"].ToString(), Convert.ToDateTime(mdr["DateRecord"]).ToString("MMM dd, yyyy"));

                        }

                    }
                }




                connect.conn.Close();

                this.dgvSHStudents.Columns[3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                this.dgvSHStudents.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                this.dgvSHStudents.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("doesn't exist"))
                {
                    MessageBox.Show("table are missing");
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }

            }



        }




        public void selectlimits()
        {
            holder.value = 0;

            holder.lastpage = 0;

            holder.offset_ = 0;

            holder.page = 1;
            holder.limit = Convert.ToInt32(comboBox3.SelectedItem);
            if (tabControl1.SelectedIndex == 0)
            {

                displayData(holder.limit, holder.offset_);
            }
            else if (tabControl1.SelectedIndex == 1)
            {

                displayJHStudent(holder.limit, holder.offset_);
            }
            else if (tabControl1.SelectedIndex == 2)
            {

                displaySHStudent(holder.limit, holder.offset_);
            }


            //count();
            if (holder.offset_ == 0)
            {
                btnBack.Enabled = false;
                btnFirst.Enabled = false;
            }
            else
            {
                btnNext.Enabled = true;
                btnLast.Enabled = true;
            }
            if (holder.offset_ >= holder.total - holder.limit)
            {
                btnNext.Enabled = false;
                btnLast.Enabled = false;
            }
            else
            {
                btnNext.Enabled = true;
                btnLast.Enabled = true;
            }
            label5.Text = holder.page.ToString();

            holder.value = Convert.ToDecimal(comboBox3.SelectedItem);

            holder.lastpage = holder.total / Convert.ToInt32(holder.value);




            if ((holder.total % holder.value) > 0)
            {

                holder.lastP = holder.lastpage * Convert.ToInt32(comboBox3.SelectedItem);


            }
            else
            {

                holder.lastP = holder.lastpage * Convert.ToInt32(comboBox3.SelectedItem);
                holder.lastP -= Convert.ToInt32(comboBox3.SelectedItem);
                holder.lastpage -= 1;
            }
        }


        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {


            selectlimits();

        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            if (btnBack.Enabled == false)
            {
                btnBack.Enabled = true;
                btnFirst.Enabled = true;
            }

            if (holder.offset_ < holder.total)
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    displayData(holder.limit, holder.offset_ += holder.limit);
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    displayJHStudent(holder.limit, holder.offset_ += holder.limit);
                }
                else if (tabControl1.SelectedIndex == 2)
                {
                    displaySHStudent(holder.limit, holder.offset_ += holder.limit);
                }

                holder.page++;
                label5.Text = holder.page.ToString();

            }
            if (holder.offset_ >= holder.total - holder.limit)
            {
                btnNext.Enabled = false;
                btnLast.Enabled = false;
            }

        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (btnBack.Enabled == false)
            {
                btnBack.Enabled = true;
                btnFirst.Enabled = true;
            }

            if (holder.offset_ < holder.total)
            {
                holder.offset_ = holder.lastP;
                holder.page = holder.lastpage;

                if (tabControl1.SelectedIndex == 0)
                {
                    displayData(holder.limit, holder.offset_);
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    displayJHStudent(holder.limit, holder.offset_);
                }
                else if (tabControl1.SelectedIndex == 2)
                {
                    displaySHStudent(holder.limit, holder.offset_);
                }

                holder.page++;
                label5.Text = holder.page.ToString();

            }
            if (holder.offset_ >= holder.total - holder.limit)
            {
                btnNext.Enabled = false;
                btnLast.Enabled = false;
            }



        }

        private void btnBack_Click(object sender, EventArgs e)
        {

            if (btnNext.Enabled == false)
            {
                btnNext.Enabled = true;
                btnLast.Enabled = true;
            }

            if (holder.offset_ != 0)
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    displayData(holder.limit, holder.offset_ -= holder.limit);
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    displayJHStudent(holder.limit, holder.offset_ -= holder.limit);
                }
                else if (tabControl1.SelectedIndex == 2)
                {
                    displaySHStudent(holder.limit, holder.offset_ -= holder.limit);
                }

                holder.page--;
                label5.Text = holder.page.ToString();
            }
            if (holder.offset_ == 0)
            {
                btnBack.Enabled = false;
                btnFirst.Enabled = false;
            }



        }

        private void btnFirst_Click(object sender, EventArgs e)
        {

            if (btnNext.Enabled == false)
            {
                btnNext.Enabled = true;
                btnLast.Enabled = true;
            }

            if (holder.offset_ != 0)
            {
                holder.page = 1;



                holder.offset_ = 0;

                if (tabControl1.SelectedIndex == 0)
                {
                    displayData(holder.limit, holder.offset_);
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    displayJHStudent(holder.limit, holder.offset_);
                }
                else if (tabControl1.SelectedIndex == 2)
                {
                    displaySHStudent(holder.limit, holder.offset_);
                }


                // page-= lastpage;
                label5.Text = holder.page.ToString();
            }
            if (holder.offset_ == 0)
            {
                btnBack.Enabled = false;
                btnFirst.Enabled = false;
            }


        }

        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvStudents.Columns[e.ColumnIndex].Name;
            string id = dgvStudents.Rows[dgvStudents.CurrentRow.Index].Cells[0].Value.ToString();

            if (colName.Equals("Register"))
            {
                var myForm = new RegisterStudent(dis);
                dis.pnlShow.Controls.Clear();
                //myForm.TopLevel = false;
                //myForm.AutoScroll = false;
                //dis.pnlShow.Controls.Add(myForm);
                myForm.txtRegisterNo.Text = id;
                myForm.ShowStudent(id);
                AllForms.MyForms(myForm, dis);
                //myForm.Show();
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectlimits();
        }


        private void dgvJHStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvJHStudents.Columns[e.ColumnIndex].Name;
            string id = dgvJHStudents.Rows[dgvJHStudents.CurrentRow.Index].Cells[0].Value?.ToString();
            string Rid = dgvJHStudents.Rows[dgvJHStudents.CurrentRow.Index].Cells[1].Value?.ToString();
            string studid = dgvJHStudents.Rows[dgvJHStudents.CurrentRow.Index].Cells[2].Value?.ToString();
            string gl = dgvJHStudents.Rows[dgvJHStudents.CurrentRow.Index].Cells[5].Value?.ToString();

            if (colName.Equals("btnEditJHS"))
            {

                var myForm = new RegisterStudent(dis);
                dis.pnlShow.Controls.Clear();
                myForm.TopLevel = false;
                myForm.AutoScroll = false;
                dis.pnlShow.Controls.Add(myForm);
                myForm.txtRegisterNo.Text = id;
                myForm.btnSave.Text = "Update";
                myForm.ShowStudent(Rid);
                myForm.txtStudentID.Text = studid;
                myForm.ShowGradelevel();
                myForm.GLevel = gl;
                myForm.cmbGradeLevel.Text = gl;
                myForm.Show();
            }
            else if (colName.Equals("btnDeleteJHS"))
            {
                DialogResult dialogResult = MessageBox.Show($"You want to Remove student: {studid}?", "Notification", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    studinfo.RemoveJHStudent(id);
                    systemlogs.userlogs($"student: {studid} Has been Removed from the list");
                    selectlimits();
                    studinfo.mbs($"student: {studid}\nHas been Removed from the list");


                }
                else
                {

                }
            }
            //else if (colName.Equals("btnActivateJHS"))
            //{
            //    DialogResult dialogResult = MessageBox.Show($"You want to Activate student: {studid}?", "Notification", MessageBoxButtons.YesNo);
            //    if (dialogResult == DialogResult.Yes)
            //    {
            //        studinfo.ActivateJHStudent(id);

            //        systemlogs.userlogs($"student: {studid} Has been activated");
            //        selectlimits();
            //        studinfo.mbs($"student: {studid}\nHas been activated");


            //    }
            //    else
            //    {

            //    }
            //}
        }

        private void dgvSHStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvSHStudents.Columns[e.ColumnIndex].Name;
            string id = dgvSHStudents.Rows[dgvSHStudents.CurrentRow.Index].Cells[0].Value?.ToString();
            string studid = dgvSHStudents.Rows[dgvSHStudents.CurrentRow.Index].Cells[2].Value?.ToString();

            if (colName.Equals("btnEditSHS"))
            {
                MessageBox.Show("Edit");
                //var myForm = new RegisterStudent(dis);
                //dis.pnlShow.Controls.Clear();
                //myForm.TopLevel = false;
                //myForm.AutoScroll = false;
                //dis.pnlShow.Controls.Add(myForm);
                //myForm.txtRegisterNo.Text = id;
                //myForm.ShowStudent(id);
                //myForm.Show();
            }
            else if (colName.Equals("btnDeleteSHS"))
            {
                DialogResult dialogResult = MessageBox.Show($"You want to Remove student: {studid}?", "Notification", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    studinfo.RemoveSHStudent(id);
                    systemlogs.userlogs($"student: {studid} Has been Removed from the list");
                    selectlimits();
                    studinfo.mbs($"student: {studid}\nHas been Removed from the list");


                }
                else
                {

                }
            }
            //else if (colName.Equals("btnActivateSHS"))
            //{
            //    DialogResult dialogResult = MessageBox.Show($"You want to Activate student: {studid}?", "Notification", MessageBoxButtons.YesNo);
            //    if (dialogResult == DialogResult.Yes)
            //    {
            //        studinfo.ActivateSHStudent(id);

            //        systemlogs.userlogs($"student: {studid} Has been activated");
            //        selectlimits();
            //        studinfo.mbs($"student: {studid}\nHas been activated");


            //    }
            //    else
            //    {

            //    }
            //}
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var myForm = new AddNewApplicants(dis);
            AllForms.MyForms(myForm, dis);
        }
    }
}
