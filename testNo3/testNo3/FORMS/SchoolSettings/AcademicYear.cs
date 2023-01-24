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

namespace testNo3.FORMS.SchoolSettings
{
    public partial class AcademicYear : Form
    {
        public AcademicYear()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            displaySchoolYear();
            displayYearTerm();
        }

        private void dgvAcademicYear_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void displaySchoolYear()
        {
            dgvAcademicYear.Rows.Clear();
            Connection connect = new Connection();

            MySqlDataReader mdr;
            try
            {



                string sql = $"select * from gsacademicyear";


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

                            dgvAcademicYear.Rows.Add(mdr["GAcademicYearID"].ToString(), $"{mdr["Year1"]}-{mdr["Year2"]}", mdr["Status"].ToString());

                        }

                    }
                }




                connect.conn.Close();

                foreach (DataGridViewRow row in dgvAcademicYear.Rows)
                {
                    if (Convert.ToString(row.Cells[2].Value) == "Active")
                    {
                        row.Cells[2].Style.ForeColor = Color.Green;
                        row.Cells[2].Style.SelectionForeColor = Color.Green;
                    }
                    else
                    {
                        row.Cells[2].Style.ForeColor = Color.Red;
                        row.Cells[2].Style.SelectionForeColor = Color.Red;
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

        public void displayYearTerm()
        {
            dgvSemester.Rows.Clear();
            Connection connect = new Connection();

            MySqlDataReader mdr;
            try
            {



                string sql = $"select * from yearterm";


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

                            dgvSemester.Rows.Add(mdr["TermID"].ToString(), mdr["Term"].ToString(), mdr["Status"].ToString());

                        }

                    }
                }




                connect.conn.Close();

                foreach (DataGridViewRow row in dgvSemester.Rows)
                {
                    if (Convert.ToString(row.Cells[2].Value) == "Active")
                    {
                        row.Cells[2].Style.ForeColor = Color.Green;
                        row.Cells[2].Style.SelectionForeColor = Color.Green;
                    }
                    else
                    {
                        row.Cells[2].Style.ForeColor = Color.Red;
                        row.Cells[2].Style.SelectionForeColor = Color.Red;
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

        private void btnAddNew_Click(object sender, EventArgs e)
        {

        }
    }
}
