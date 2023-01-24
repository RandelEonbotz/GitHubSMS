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
    public partial class LockerModule : Form
    {
        public LockerModule()
        {
            InitializeComponent();
            ShowSettings();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        public void ShowSettings()
        {

            Connection connect = new Connection();
            MySqlConnection conn;
            MySqlCommand cmd;
            MySqlDataReader mdr;
            try
            {
                string sql = $"SELECT * FROM settings";


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
                            if (Convert.ToInt32(mdr["NewStudent"]) == 1)
                            {
                                tglStudRec.Check = true;
                            }
                            else
                            {
                                tglStudRec.Check = false;
                            }

                            if (Convert.ToInt32(mdr["Enrollment"]) == 1)
                            {
                                tglEnrollment.Check = true;
                            }
                            else
                            {
                                tglEnrollment.Check = false;
                            }

                            if (Convert.ToInt32(mdr["Payment"]) == 1)
                            {
                                tglPayment.Check = true;
                            }
                            else
                            {
                                tglPayment.Check = false;
                            }

                            if (Convert.ToInt32(mdr["Rate"]) == 1)
                            {
                                tglRate.Check = true;
                            }
                            else
                            {
                                tglRate.Check = false;
                            }

                            if (Convert.ToInt32(mdr["DownPayment"]) == 1)
                            {
                                tglDP.Check = true;
                            }
                            else
                            {
                                tglDP.Check = false;
                            }

                            if (Convert.ToInt32(mdr["Subject"]) == 1)
                            {
                                tglSubject.Check = true;
                            }
                            else
                            {
                                tglSubject.Check = false;
                            }

                            if (Convert.ToInt32(mdr["ADSubject"]) == 1)
                            {
                                tglAD.Check = true;
                            }
                            else
                            {
                                tglAD.Check = false;
                            }

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
    }
}
