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

namespace testNo3.FORMS.Course
{
    public partial class AddGradeLevel : Form
    {
        SidePanel dis = new SidePanel();
        public AddGradeLevel(SidePanel dis)
        {
            InitializeComponent();
            this.dis = dis;
            ShowSection();
            ShowGradelevel();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }
        public void ShowSection()
        {
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
                            cmbSection.Items.Add(mdr["Section"].ToString());
                            cmbSecID.Items.Add(mdr["SectionID"].ToString());
                        }

                    }
                }






                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ShowGradelevel()
        {
            Connection connect = new Connection();
            MySqlConnection conn;
            MySqlCommand cmd;
            MySqlDataReader mdr;
            try
            {
                string sql = $"SELECT * FROM gradelevel";


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
                            cmbGradeLevel.Items.Add(mdr["GradeLevel"].ToString());
                            cmbgradeID.Items.Add(mdr["GradeLevel_ID"].ToString());
                        }

                    }
                }






                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            dis.btnSubjects.PerformClick();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text.Equals("Save"))
            {
                try
                {
                    Connection connect = new Connection();
                    MySqlConnection conn;
                    MySqlCommand cmd;


                    string sql = "INSERT INTO gradelevelsection ( GradeLevel_ID, SectionID,Status) VALUES (@GradeLevel,@Section,'Active');";



                    conn = connect.getcon();
                    conn.Open();
                    using (cmd = new MySqlCommand(sql, conn))
                    {


                        cmd.Parameters.AddWithValue("@GradeLevel", cmbgradeID.Text);
                        cmd.Parameters.AddWithValue("@Section", cmbSecID.Text);







                        cmd.ExecuteNonQuery();

                    }

                    conn.Close();
                    dis.btnSubjects.PerformClick();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void cmbGradeLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbgradeID.SelectedIndex = cmbGradeLevel.SelectedIndex;
        }

        private void cmbSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSecID.SelectedIndex = cmbSection.SelectedIndex;
        }
    }
}
