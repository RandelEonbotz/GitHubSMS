using MySql.Data.MySqlClient;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;
using testNo3.FORMS.MainForm;




namespace testNo3
{
    public partial class SelectionForm : Form
    {
        public SelectionForm()
        {

            InitializeComponent();
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {



        }

        private void SelectionForm_Load(object sender, EventArgs e)
        {


        }

        private void timer_Tick(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {

        }

        public string GetMacAddress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }
            return sMacAddress;
        }
        //string macadd;
        //string role;
        private void btnSignin_Click(object sender, EventArgs e)
        {


            //kini mao ning tinuod nga source code
            //try
            //{
            //    var query = //DBContext.GetContext().Query("users")
            //        .Where("status", "Active")
            //        .Where(new
            //        {
            //            username = txtUsername.Text,
            //            password = txtPassword.Text,
            //        }).First();

            //    if (query.macAddress.Equals(GetMacAddress()))
            //    {




            //        smsUsers.name = query.name;
            //        smsUsers.role = query.userrole;
            //        smsUsers.Users = query.username;

            //       // finalDashboard myfrm2 = new finalDashboard();
            //        SplashScreen myfrm = new SplashScreen();
            //        // 

            //        //myfrm2.btnAdmin.Text = query.userrole;
            //        myfrm.label2.Text = query.userrole;



            //        try
            //        {
            //            Connection connect = new Connection();
            //            MySqlConnection conn;
            //            MySqlCommand cmd;
            //            MySqlDataReader mdr;

            //            string sql = "INSERT INTO logs (Name, Role, Marks,DateOp) VALUES (@Name,@Role,@Marks,(SELECT CONVERT_TZ(CURRENT_TIMESTAMP,'+00:00','+08:00')));";



            //            conn = connect.getcon();
            //            conn.Open();
            //            using (cmd = new MySqlCommand(sql, conn))
            //            {
            //                // cmd.Parameters.AddWithValue("@username", query.username);

            //                cmd.Parameters.AddWithValue("@Name", query.name);
            //                cmd.Parameters.AddWithValue("@Role", query.userrole);
            //                cmd.Parameters.AddWithValue("@Marks", "login to SMS");



            //                //cmd.Parameters.AddWithValue("@Course", cbCourse.Text);
            //                //cmd.Parameters.AddWithValue("@AcademicYearID", cbDesignation.Text);


            //                cmd.ExecuteNonQuery();

            //            }

            //            conn.Close();
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show(ex.Message);
            //        }




            //        myfrm.Show();
            //        this.Hide();
            //    }

            //    else
            //    {
            //        Validator.AlertDanger("You cant login other role to another pc");
            //    }
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Invalid credentials");
            //}

            //currentsemester();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        public void currentsemester()
        {
            Connection connect = new Connection();
            MySqlConnection conn;
            MySqlCommand cmd;
            MySqlDataReader mdr;
            try
            {
                string sql = $"SELECT * FROM academicyear WHERE status = 'Active'";


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
                            smsUsers.year1 = mdr["year1"].ToString();
                            smsUsers.year2 = mdr["year2"].ToString();
                            smsUsers.semester = mdr["Term"].ToString();
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


        private void pnlSlide2_Paint(object sender, PaintEventArgs e)
        {
            txtUsername.Focus();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {


        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1 && e.Shift)
                {
                    txtUsername.Text = "DevRandel";
                    txtPassword.Text = "randel";
                    btnSignin.PerformClick();
                }
                else if (e.KeyCode == Keys.F1)
                {
                    txtUsername.Text = "randel";
                    txtPassword.Text = "randel";
                    btnSignin.PerformClick();
                }
                else if (e.KeyCode == Keys.F2 && e.Shift)
                {
                    txtUsername.Text = "DevYobbs";
                    txtPassword.Text = "Yobbs";
                    btnSignin.PerformClick();
                }

                else if (e.KeyCode == Keys.F2)
                {
                    txtUsername.Text = "admin";
                    txtPassword.Text = "admin";
                    btnSignin.PerformClick();
                }
                else if (e.KeyCode == Keys.F6)
                {
                    txtUsername.Text = "admin7";
                    txtPassword.Text = "admin7";
                    btnSignin.PerformClick();
                }
                else if (e.KeyCode == Keys.F3 && e.Shift)
                {
                    txtUsername.Text = "DevKeng";
                    txtPassword.Text = "Keng";
                    btnSignin.PerformClick();
                }
                else if (e.KeyCode == Keys.F3)
                {
                    txtUsername.Text = "keng";
                    txtPassword.Text = "keng";
                    btnSignin.PerformClick();
                }
                else if (e.KeyCode == Keys.Escape)
                {

                    btnLeft.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Release the mouse capture started by the mouse down.
                panel1.Capture = false; //select control

                // Create and send a WM_NCLBUTTONDOWN message.
                const int WM_NCLBUTTONDOWN = 0x00A1;
                const int HTCAPTION = 2;
                Message msg =
                    Message.Create(this.Handle, WM_NCLBUTTONDOWN,
                        new IntPtr(HTCAPTION), IntPtr.Zero);
                this.DefWndProc(ref msg);
            }
        }
    }
}
