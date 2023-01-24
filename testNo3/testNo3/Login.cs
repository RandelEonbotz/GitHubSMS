using MySql.Data.MySqlClient;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testNo3
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbUser.SelectedIndex = 0;

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void label9_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Release the mouse capture started by the mouse down.
                this.Capture = false; //select control

                // Create and send a WM_NCLBUTTONDOWN message.
                const int WM_NCLBUTTONDOWN = 0x00A1;
                const int HTCAPTION = 2;
                Message msg =
                    Message.Create(this.Handle, WM_NCLBUTTONDOWN,
                        new IntPtr(HTCAPTION), IntPtr.Zero);
                this.DefWndProc(ref msg);
            }
        }

        private void label10_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(0);
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

        private void btnSignin_Click(object sender, EventArgs e)
        {
            //kini mao ning tinuod nga source code
            try
            {
                var query = DBContext.GetContext().Query("users")
                    .Where("status", "Active")
                    .Where(new
                    {
                        username = txtUsername.Text,
                        password = txtPassword.Text,

                    }).First();

                if (query.macAddress.Equals(GetMacAddress()))
                {




                    smsUsers.name = query.name;
                    smsUsers.role = query.userrole;
                    smsUsers.Users = query.username;

                    //finalDashboard myfrm2 = new finalDashboard();
                    // SplashScreen myfrm = new SplashScreen();
                    // 
                    SidePanel myfrm = new SidePanel();

                    myfrm.btnAdmin.Text = query.userrole;
                    // myfrm.label2.Text = query.userrole;

                    systemlogs.userlogs($"login to SMS");

                    //try
                    //{
                    //    Connection connect = new Connection();
                    //    MySqlConnection conn;
                    //    MySqlCommand cmd;
                    //    MySqlDataReader mdr;

                    //    string sql = "INSERT INTO logs (Name, Role, Marks,DateOp) VALUES (@Name,@Role,@Marks,CURRENT_TIMESTAMP);";



                    //    conn = connect.getcon();
                    //    conn.Open();
                    //    using (cmd = new MySqlCommand(sql, conn))
                    //    {
                    //        // cmd.Parameters.AddWithValue("@username", query.username);

                    //        cmd.Parameters.AddWithValue("@Name", query.name);
                    //        cmd.Parameters.AddWithValue("@Role", query.userrole);
                    //        cmd.Parameters.AddWithValue("@Marks", "login to SMS");



                    //        //cmd.Parameters.AddWithValue("@Course", cbCourse.Text);
                    //        //cmd.Parameters.AddWithValue("@AcademicYearID", cbDesignation.Text);


                    //        cmd.ExecuteNonQuery();

                    //    }

                    //    conn.Close();
                    //}
                    //catch (Exception ex)
                    //{
                    //    MessageBox.Show(ex.Message);
                    //}




                    myfrm.Show();
                    this.Hide();
                }

                else
                {

                    MessageBox.Show("You cant login other role to another pc", "Message Info", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid credentials");
            }

            //currentsemester();
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

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                btnSignin.PerformClick();
            }
        }

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Release the mouse capture started by the mouse down.
                panel4.Capture = false; //select control

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
