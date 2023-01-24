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

namespace testNo3.FORMS.NewApplicants
{
    public partial class AddNewApplicants : Form
    {
        SidePanel dis = new SidePanel();
        public AddNewApplicants(SidePanel dis)
        {
            InitializeComponent();
            this.dis = dis;
        }
        // ===== Start ======= paging =========
        public int limit = 10;
        public int offset_ = 0;
        public int total = 0;
        public int page = 1;

        int lastpage = 0;
        int lastP = 0;
        decimal value = 0;

        // ===== end ======= paging =========
        private void Form1_Load(object sender, EventArgs e)
        {
            paging();


        }

        public void paging()
        {

            comboBox3.SelectedIndex = 0;

            if (offset_ == 0)
            {
                btnBack.Enabled = false;
            }
            if (offset_ >= total - limit)
            {
                btnNext.Enabled = false;
            }
            label6.Text = page.ToString();

            displaystudentdata(limit, offset_);



        }

        public void refreshpaging()
        {
            value = 0;

            lastpage = 0;

            offset_ = 0;

            page = 1;
            comboBox3.SelectedIndex = 0;
            limit = Convert.ToInt32(comboBox3.SelectedItem);
            displaystudentdata(limit, offset_);

            //count();
            if (offset_ == 0)
            {
                btnBack.Enabled = false;
                btnFirst.Enabled = false;
            }
            else
            {
                btnNext.Enabled = true;
                btnLast.Enabled = true;
            }
            if (offset_ >= total - limit)
            {
                btnNext.Enabled = false;
                btnLast.Enabled = false;
            }
            else
            {
                btnNext.Enabled = true;
                btnLast.Enabled = true;
            }
            label6.Text = page.ToString();

            value = Convert.ToDecimal(comboBox3.SelectedItem);

            lastpage = total / Convert.ToInt32(value);




            if ((total % value) > 0)
            {

                lastP = lastpage * Convert.ToInt32(comboBox3.SelectedItem);


            }
            else
            {

                lastP = lastpage * Convert.ToInt32(comboBox3.SelectedItem);
                lastP -= Convert.ToInt32(comboBox3.SelectedItem);
                lastpage -= 1;
            }

        }



        public void displaystudentdata(int limits, int offset)
        {
            Connection connect = new Connection();
            MySqlConnection conn;
            MySqlCommand cmd;
            MySqlDataReader mdr;


            try
            {
                dgvStudents.Rows.Clear();

                string sql = $" CALL Count_Student();";
                // string sql = $"Call Show_Student({limits} , {offset});";


                conn = connect.getcon();
                conn.Open();
                cmd = new MySqlCommand(sql, conn);
                mdr = cmd.ExecuteReader();


                if (mdr.HasRows)
                {
                    while (mdr.Read())
                    {
                        total = Convert.ToInt32(mdr["total"]);

                        txttotalpages.Text = total.ToString();
                        // dgvStudents.Rows.Add(mdr["RegisterID"].ToString(), $"{mdr["LastName"]}, {mdr["FirstName"]} {mdr["MiddleName"]} {mdr["Suffix"]}");

                    }
                }


                conn.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }





            try
            {
                dgvStudents.Rows.Clear();

                // string sql = $" CALL Count_Student();";
                string sql = $"Call Show_Student({limits} , {offset});";


                conn = connect.getcon();
                conn.Open();
                cmd = new MySqlCommand(sql, conn);
                mdr = cmd.ExecuteReader();


                if (mdr.HasRows)
                {
                    while (mdr.Read())
                    {
                        // total = Convert.ToInt32(mdr["total"]);

                        // txttotalpages.Text = total.ToString();
                        dgvStudents.Rows.Add(mdr["RegisterID"].ToString(), $"{mdr["LastName"]}, {mdr["FirstName"]} {mdr["MiddleName"]} {mdr["Suffix"]}");

                    }
                }


                conn.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.dgvStudents.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dgvStudents.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dgvStudents.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        public void clear()
        {
            txtRegisterID.Clear();
            txtLastName.Clear();
            txtFirstName.Clear();
            txtMiddleName.Clear();
            txtSuffix.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Connection connect = new Connection();
            MySqlConnection conn;
            MySqlCommand cmd;

            if (btnSave.Text == "Save")
            {


                try
                {
                    string sql = "CALL Save_Student(@RegID,@LastName,@FirstName,@MiddleName,@Suffix,@Gender);";
                    conn = connect.getcon();
                    conn.Open();
                    cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@RegID", Convert.ToInt32(txtRegisterID.Text));
                    cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text);
                    cmd.Parameters.AddWithValue("@Suffix", txtSuffix.Text);
                    if (rbMale.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@Gender", "M");
                    }
                    else if (rbFemale.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@Gender", "F");
                    }


                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Saved Successfully!");


                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("Duplicate"))
                    {
                        txtRegisterID.Text = (Convert.ToInt32(txtRegisterID.Text) + 1).ToString();
                        btnSave.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
            else
            {
                try
                {
                    string sql = "CALL Update_Student(@RegID,@LastName,@FirstName,@MiddleName,@Suffix);";
                    conn = connect.getcon();
                    conn.Open();
                    cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@RegID", Convert.ToInt32(txtRegisterID.Text));
                    cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text);
                    cmd.Parameters.AddWithValue("@Suffix", txtSuffix.Text);


                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Updated Successfully!");
                    btnSave.Text = "Save";
                    txtRegisterID.ReadOnly = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            paging();
            refreshpaging();
            clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
            btnSave.Text = "Save";
            txtRegisterID.ReadOnly = false;
            paging();
            refreshpaging();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            value = 0;

            lastpage = 0;

            offset_ = 0;

            page = 1;
            limit = Convert.ToInt32(comboBox3.SelectedItem);
            displaystudentdata(limit, offset_);

            //count();
            if (offset_ == 0)
            {
                btnBack.Enabled = false;
                btnFirst.Enabled = false;
            }
            else
            {
                btnNext.Enabled = true;
                btnLast.Enabled = true;
            }
            if (offset_ >= total - limit)
            {
                btnNext.Enabled = false;
                btnLast.Enabled = false;
            }
            else
            {
                btnNext.Enabled = true;
                btnLast.Enabled = true;
            }
            label6.Text = page.ToString();

            value = Convert.ToDecimal(comboBox3.SelectedItem);

            lastpage = total / Convert.ToInt32(value);




            if ((total % value) > 0)
            {

                lastP = lastpage * Convert.ToInt32(comboBox3.SelectedItem);


            }
            else
            {

                lastP = lastpage * Convert.ToInt32(comboBox3.SelectedItem);
                lastP -= Convert.ToInt32(comboBox3.SelectedItem);
                lastpage -= 1;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (btnBack.Enabled == false)
            {
                btnBack.Enabled = true;
                btnFirst.Enabled = true;
            }

            if (offset_ < total)
            {

                displaystudentdata(limit, offset_ += limit);
                page++;
                label6.Text = page.ToString();

            }
            if (offset_ >= total - limit)
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

            if (offset_ < total)
            {
                offset_ = lastP;
                page = lastpage;

                displaystudentdata(limit, offset_);
                page++;
                label6.Text = page.ToString();

            }
            if (offset_ >= total - limit)
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

            if (offset_ != 0)
            {

                displaystudentdata(limit, offset_ -= limit);
                page--;
                label6.Text = page.ToString();
            }
            if (offset_ == 0)
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

            if (offset_ != 0)
            {
                page = 1;



                offset_ = 0;
                displaystudentdata(limit, offset_);
                // page-= lastpage;
                label6.Text = page.ToString();
            }
            if (offset_ == 0)
            {
                btnBack.Enabled = false;
                btnFirst.Enabled = false;
            }
        }

        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvStudents.Columns[e.ColumnIndex].Name;
            string id = dgvStudents.Rows[dgvStudents.CurrentRow.Index].Cells[0].Value.ToString();
            // string regid = dgvStudents.Rows[dgvStudents.CurrentRow.Index].Cells[0].Value.ToString();

            if (colName.Equals("edit"))
            {



                Connection connect = new Connection();
                MySqlConnection conn;
                MySqlCommand cmd;
                MySqlDataReader mdr;


                try
                {

                    string sql = $"Call Show_Selected_Student({id});";


                    conn = connect.getcon();
                    conn.Open();
                    cmd = new MySqlCommand(sql, conn);
                    mdr = cmd.ExecuteReader();


                    if (mdr.HasRows)
                    {
                        while (mdr.Read())
                        {
                            txtRegisterID.Text = mdr["RegisterID"].ToString();
                            txtLastName.Text = mdr["LastName"].ToString();
                            txtFirstName.Text = mdr["FirstName"].ToString();
                            txtMiddleName.Text = mdr["MiddleName"].ToString();
                            txtSuffix.Text = mdr["Suffix"].ToString();


                        }
                    }


                    conn.Close();

                    txtRegisterID.ReadOnly = true;
                    btnSave.Text = "Update";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }








            }
            else if (colName.Equals("delete"))
            {



                try
                {
                    Connection connect = new Connection();
                    MySqlConnection conn;
                    MySqlCommand cmd;
                    MySqlDataReader mdr;
                    //dgvStudents.Rows.Clear();

                    string sql = $"call Delete_Selected_Student({id});";


                    conn = connect.getcon();
                    conn.Open();
                    cmd = new MySqlCommand(sql, conn);
                    mdr = cmd.ExecuteReader();



                    conn.Close();



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }






                clear();
                btnSave.Text = "Save";
                txtRegisterID.ReadOnly = false;

                paging();
                refreshpaging();


            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtRegisterID_KeyPress(object sender, KeyPressEventArgs e)
        {
            allkeypress.numbersonly(sender, e);
        }
    }
}
