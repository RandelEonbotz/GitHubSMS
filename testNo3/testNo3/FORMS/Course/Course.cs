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
using testNo3.FORMS.Course;

namespace testNo3.FORMS.Course
{
    public partial class Course : Form
    {
        SidePanel display = new SidePanel();
        public Course(SidePanel display)
        {
            InitializeComponent();
            ShowSection();
            ShowGradelevelSection();
            this.display = display;
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        public void ShowSection()
        {
            dgvSection.Rows.Clear();
            Connection connect = new Connection();
            MySqlConnection conn;
            MySqlCommand cmd;
            MySqlDataReader mdr;
            try
            {
                string sql = $"SELECT * FROM sections";


                conn = connect.getcon();
                conn.Open();
                cmd = new MySqlCommand(sql, conn);
                mdr = cmd.ExecuteReader();


                if (mdr.HasRows)
                {
                    while (mdr.Read())
                    {
                        if (!mdr.IsDBNull(0))
                        {
                            dgvSection.Rows.Add(mdr["SectionID"].ToString(), mdr["Section"].ToString());
                        }

                    }
                }

                this.dgvSection.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                this.dgvSection.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                this.dgvSection.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;




                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ShowGradelevelSection()
        {
            dgvGradelevelSection.Rows.Clear();
            Connection connect = new Connection();
            MySqlConnection conn;
            MySqlCommand cmd;
            MySqlDataReader mdr;
            try
            {
                string sql = $"Call Show_GradelevelSection()";


                conn = connect.getcon();
                conn.Open();
                cmd = new MySqlCommand(sql, conn);
                mdr = cmd.ExecuteReader();


                if (mdr.HasRows)
                {
                    while (mdr.Read())
                    {
                        if (!mdr.IsDBNull(0))
                        {
                            dgvGradelevelSection.Rows.Add(mdr["glsID"].ToString(), mdr["Gradelevel"].ToString(), mdr["Section"].ToString(), mdr["Status"].ToString());
                        }

                    }
                }

                this.dgvGradelevelSection.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                this.dgvGradelevelSection.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                this.dgvGradelevelSection.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;




                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                var myForm = new AddGradeLevel(display);
                display.pnlShow.Controls.Clear();
                myForm.TopLevel = false;
                myForm.AutoScroll = false;
                display.pnlShow.Controls.Add(myForm);
                myForm.Show();
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                var myForm = new AddSection(display);
                display.pnlShow.Controls.Clear();
                myForm.TopLevel = false;
                myForm.AutoScroll = false;
                display.pnlShow.Controls.Add(myForm);
                myForm.Show();
            }
        }
    }
}
