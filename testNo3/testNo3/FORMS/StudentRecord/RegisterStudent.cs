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

namespace testNo3.FORMS.StudentRecord
{
    public partial class RegisterStudent : Form
    {
        SidePanel dis = new SidePanel();
        public string GLevel;
        public RegisterStudent(SidePanel dis)
        {
            InitializeComponent();
            this.dis = dis;
            ShowGradelevel();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbGradeLevel.SelectedIndex = 0;
            cmbType.SelectedIndex = 0;

            AllStrand.ShowcmbStrand(cmbStrand);

        }

        public void ShowStudent(string RegID)
        {
            Connection connect = new Connection();
            MySqlConnection conn;
            MySqlCommand cmd;
            MySqlDataReader mdr;
            try
            {
                string sql = $"SELECT * FROM Student where RegisterID = {RegID}";


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
                            txtLastName.Text = mdr["LastName"].ToString();
                            txtFirstName.Text = mdr["FirstName"].ToString();
                            txtMiddleName.Text = mdr["MiddleName"].ToString();
                            txtSuffix.Text = mdr["Suffix"].ToString();
                            txtGender.Text = mdr["Gender"].ToString();




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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text.Equals("Save"))
            {
                try
                {
                    Connection connect = new Connection();
                    MySqlConnection conn;
                    MySqlCommand cmd;


                    switch (cmbGradeLevel.Text)
                    {
                        case "Kindergarten":
                        case "N1":
                        case "N2":

                            break;


                        case "G11":
                        case "G12":

                            try
                            {
                                string sql = "call Save_SHStudentRecord(@RegisterID, @StudentID, @GradeLevel_ID,@strand,@type);";



                                conn = connect.getcon();
                                conn.Open();
                                using (cmd = new MySqlCommand(sql, conn))
                                {


                                    cmd.Parameters.AddWithValue("@RegisterID", txtRegisterNo.Text);
                                    cmd.Parameters.AddWithValue("@StudentID", txtStudentID.Text);
                                    cmd.Parameters.AddWithValue("@GradeLevel_ID", cmbgradeID.Text);
                                    cmd.Parameters.AddWithValue("@strand", cmbStrand.Text);
                                    cmd.Parameters.AddWithValue("@type", cmbType.Text);




                                    cmd.ExecuteNonQuery();

                                }

                                conn.Close();
                                var myForm = new StudentInformation(dis);
                                dis.pnlShow.Controls.Clear();
                                myForm.TopLevel = false;
                                myForm.AutoScroll = false;
                                dis.pnlShow.Controls.Add(myForm);
                                myForm.tabControl1.SelectedIndex = 2;
                                myForm.Show();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

                            break;

                        default: //Grade 1-10

                            try
                            {
                                string sql = "call Save_JHStudentRecord(@RegisterID, @StudentID, @GradeLevel_ID,@type);";



                                conn = connect.getcon();
                                conn.Open();
                                using (cmd = new MySqlCommand(sql, conn))
                                {


                                    cmd.Parameters.AddWithValue("@RegisterID", txtRegisterNo.Text);
                                    cmd.Parameters.AddWithValue("@StudentID", txtStudentID.Text);
                                    cmd.Parameters.AddWithValue("@GradeLevel_ID", cmbgradeID.Text);
                                    cmd.Parameters.AddWithValue("@type", cmbType.Text);







                                    cmd.ExecuteNonQuery();

                                }

                                conn.Close();

                                var myForm = new StudentInformation(dis);
                                dis.pnlShow.Controls.Clear();
                                myForm.TopLevel = false;
                                myForm.AutoScroll = false;
                                dis.pnlShow.Controls.Add(myForm);
                                myForm.tabControl1.SelectedIndex = 1;
                                myForm.Show();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

                            break;
                    }






                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (btnSave.Text.Equals("Update"))
            {

            }
        }

        private void cmbGradeLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbgradeID.SelectedIndex = cmbGradeLevel.SelectedIndex;
            if (cmbGradeLevel.SelectedItem.Equals("G11") || cmbGradeLevel.SelectedItem.Equals("G12"))
            {
                pnlStrand.Visible = true;
            }
            else
            {
                pnlStrand.Visible = false;
            }

        }
    }
}
