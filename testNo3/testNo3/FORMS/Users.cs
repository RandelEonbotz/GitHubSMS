using MySql.Data.MySqlClient;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using testNo3.FORMS.User;

namespace testNo3.FORMS
{
    public partial class Users : Form
    {
        SidePanel display = new SidePanel();

        string idd;
        public Users(SidePanel display)
        {
            InitializeComponent();

            this.display = display;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // ====== Start ====== paging =====================
            comboBox3.SelectedIndex = 0;
            if (holder.offset_ == 0)
            {
                btnBack.Enabled = false;
            }
            if (holder.offset_ >= holder.total - holder.limit)
            {
                btnNext.Enabled = false;
            }
            label2.Text = holder.page.ToString();

            displayData(holder.limit, holder.offset_);
            // ====== end ====== paging =====================

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var myForm = new NewUsers(display);
            display.pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            display.pnlShow.Controls.Add(myForm);
            myForm.Show();
        }

        public void displayData(int limits, int offset)
        {

            dgvUsers.Rows.Clear();
            Connection connect = new Connection();

            MySqlDataReader mdr;

            if (smsUsers.role != "Developer")
            {
                try
                {



                    string sql = $"select count(*) total from (select * from users where userrole!='Developer') foo01";


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



                    string sql = $"select * from users where userrole!='Developer' LIMIT {limits} OFFSET {offset}";


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

                                dgvUsers.Rows.Add(mdr["id"].ToString(), mdr["name"].ToString(), mdr["userrole"].ToString(), mdr["status"].ToString());

                            }

                        }
                    }




                    connect.conn.Close();

                    foreach (DataGridViewRow row in dgvUsers.Rows)
                    {
                        if (Convert.ToString(row.Cells[3].Value) == "Active")
                        {
                            row.Cells[3].Style.ForeColor = Color.Green;
                            row.Cells[3].Style.SelectionForeColor = Color.Green;
                        }
                        else
                        {
                            row.Cells[3].Style.ForeColor = Color.Red;
                            row.Cells[3].Style.SelectionForeColor = Color.Red;
                        }

                    }

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
            else
            {

                try
                {



                    string sql = $"select count(*) total from (select * from users) foo01";


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



                    string sql = $"select * from users  LIMIT {limits} OFFSET {offset}";


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

                                dgvUsers.Rows.Add(mdr["id"].ToString(), mdr["name"].ToString(), mdr["userrole"].ToString(), mdr["status"].ToString());

                            }

                        }
                    }




                    connect.conn.Close();

                    foreach (DataGridViewRow row in dgvUsers.Rows)
                    {
                        if (Convert.ToString(row.Cells[3].Value) == "Active")
                        {
                            row.Cells[3].Style.ForeColor = Color.Green;
                            row.Cells[3].Style.SelectionForeColor = Color.Green;
                        }
                        else
                        {
                            row.Cells[3].Style.ForeColor = Color.Red;
                            row.Cells[3].Style.SelectionForeColor = Color.Red;
                        }

                    }

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






        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            holder.value = 0;

            holder.lastpage = 0;

            holder.offset_ = 0;

            holder.page = 1;
            holder.limit = Convert.ToInt32(comboBox3.SelectedItem);
            displayData(holder.limit, holder.offset_);

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
            label2.Text = holder.page.ToString();

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

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (btnBack.Enabled == false)
            {
                btnBack.Enabled = true;
                btnFirst.Enabled = true;
            }

            if (holder.offset_ < holder.total)
            {

                displayData(holder.limit, holder.offset_ += holder.limit);
                holder.page++;
                label2.Text = holder.page.ToString();

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

                displayData(holder.limit, holder.offset_);
                holder.page++;
                label2.Text = holder.page.ToString();

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

                displayData(holder.limit, holder.offset_ -= holder.limit);
                holder.page--;
                label2.Text = holder.page.ToString();
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
                displayData(holder.limit, holder.offset_);
                // page-= lastpage;
                label2.Text = holder.page.ToString();
            }
            if (holder.offset_ == 0)
            {
                btnBack.Enabled = false;
                btnFirst.Enabled = false;
            }
        }

        private void Users_KeyDown(object sender, KeyEventArgs e)
        {

        }



        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvUsers.Columns[e.ColumnIndex].Name;

            if (colName.Equals("activate"))
            {
                if (dgvUsers.SelectedRows[0].Cells[3].Value.Equals("Active"))
                {
                    Validator.AlertDanger("This user is already activated");
                    return;
                }
                else
                {
                    if (Validator.actYear())
                    {
                        DBContext.GetContext().Query("users").Where("id", dgvUsers.SelectedRows[0].Cells[0].Value).Update(new
                        {
                            status = "Active"
                        });
                        // ====== Start ====== paging =====================
                        comboBox3.SelectedIndex = 0;
                        if (holder.offset_ == 0)
                        {
                            btnBack.Enabled = false;
                        }
                        if (holder.offset_ >= holder.total - holder.limit)
                        {
                            btnNext.Enabled = false;
                        }
                        label2.Text = holder.page.ToString();

                        displayData(holder.limit, holder.offset_);
                        // ====== end ====== paging =====================
                        systemlogs.userlogs($"Activate user");

                    }
                }
                //if (dgvUsers.SelectedRows[0].Cells[3].Value.ToString() == "Activate")
                //{
                //    if (Validator.actYear())
                //    {
                //        DBContext.GetContext().Query("users").Where("id", dgvUsers.SelectedRows[0].Cells[0].Value).Update(new
                //        {
                //            status = "Deactivate"
                //        });
                //        displayData();
                //    }
                //}
                //else if (dgvUsers.SelectedRows[0].Cells[3].Value.ToString() == "Deactivate")
                //{
                //    if (Validator.deactYear())
                //    {
                //        DBContext.GetContext().Query("users").Where("id", dgvUsers.SelectedRows[0].Cells[0].Value).Update(new
                //        {
                //            status = "Activate"
                //        });
                //        displayData();
                //    }
                //}
            }
            else if (colName.Equals("deactivate"))
            {
                if (dgvUsers.SelectedRows[0].Cells[3].Value.Equals("Inactive"))
                {
                    Validator.AlertDanger("This user is already deactivated");
                    return;
                }
                else
                {
                    if (Validator.deactYear())
                    {
                        DBContext.GetContext().Query("users").Where("id", dgvUsers.SelectedRows[0].Cells[0].Value).Update(new
                        {
                            status = "Inactive"
                        });
                        // ====== Start ====== paging =====================
                        comboBox3.SelectedIndex = 0;
                        if (holder.offset_ == 0)
                        {
                            btnBack.Enabled = false;
                        }
                        if (holder.offset_ >= holder.total - holder.limit)
                        {
                            btnNext.Enabled = false;
                        }
                        label2.Text = holder.page.ToString();

                        displayData(holder.limit, holder.offset_);
                        // ====== end ====== paging =====================
                        systemlogs.userlogs($"Deactivate user");

                    }
                }
            }
            else if (colName.Equals("edit"))
            {
                idd = dgvUsers.Rows[dgvUsers.CurrentRow.Index].Cells[0].Value.ToString();
                var myForm = new NewUsers(display);
                display.pnlShow.Controls.Clear();
                myForm.TopLevel = false;
                myForm.AutoScroll = false;
                display.pnlShow.Controls.Add(myForm);

                var values = DBContext.GetContext().Query("users")
                    .Where("id", idd).Get();

                foreach (var value in values)
                {
                    myForm.cmbRole.Text = value.userrole;
                    myForm.txtName.Text = value.name;
                    myForm.txtUsername.Text = value.username;
                    //myForm.txtPassword.Text = value.password;
                    myForm.txtMacAddress.Text = value.macAddress;
                }
                myForm.idd = idd;
                myForm.btnSave.Text = "Update";

                myForm.Show();
            }
        }
    }
}
