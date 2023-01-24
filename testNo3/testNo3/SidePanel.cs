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
using testNo3.FORMS;
using testNo3.FORMS.Course;
using testNo3.FORMS.Discount;
using testNo3.FORMS.FeeManagement;
using testNo3.FORMS.FinancialReport;
using testNo3.FORMS.ManageStrand;
using testNo3.FORMS.NewApplicants;
using testNo3.FORMS.Payment;
using testNo3.FORMS.SchoolSettings;
using testNo3.FORMS.StudentActivation;
using testNo3.FORMS.StudentRecord;
using testNo3.FORMS.StudentSchedule;
using testNo3.FORMS.Subjects;
using testNo3.FORMS.TeachersModule;

namespace testNo3
{
    public partial class SidePanel : Form
    {
        public SidePanel()
        {
            InitializeComponent();
            hideSubMenu();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            displaySchoolYear();
            displayYearTerm();

            Button[] allBtn = { btnManageUser, btnSubjectLoads, btnHandleStudents, btnTeachers, btnAcademicMngmt, btnStudentRecords, btnEnrollment, btnTeacherLoads, btnDepartment, btnCourse, btnLock, btnUE, btnLPS, btnUpload };
            Button[] registrarButton = { btnPromi, btnCourse, btnLock, btnEmployees, btnManageUser, btnFeesManagement, btnPayment, iconButton1, btnAccounting, btnUpload, btnLPS };
            Button[] teacher = { btnTeacherLoads, btnSectioning };
            Button[] dev = { btnITLogs };
            if (btnAdmin.Text.Equals("Cashier"))
            {
                hideButton(allBtn);
                hideButton(dev);
                pnlSchoolSettings.SetBounds(200, 200, 200, 78);//Resize


            }
            else if (btnAdmin.Text.Equals("Registrar"))
            {
                hideButton(registrarButton);
                hideButton(teacher);
                hideButton(dev);

            }
            else if (btnAdmin.Text.Equals("Admin"))
            {
                hideButton(dev);
            }
            this.btnDashboard.PerformClick();
            //displayDashboard();
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
        private void hideSubMenu()
        {
            pnlUser.Visible = false;
            pnlLoads.Visible = false;
            pnlEnrollment.Visible = false;
            btnStudentsSchedule.Visible = false;
            pnlStudentRecords.Visible = false;
            pnlSchoolSettings.Visible = false;
            pnlFeesMngmnt.Visible = false;
            pnlAcademic.Visible = false;

            pnlAccounting.Visible = false;

        }
        public static void hideButton(Button[] values)
        {
            foreach (var value in values)
            {
                value.Visible = false;
            }
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        private void btnManageUser_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlUser);
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlSchoolSettings);
        }

        private void btnFeesManagement_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlFeesMngmnt);
        }

        private void btnTeacherLoads_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlLoads);
        }

        private void btnAcademicMngmt_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlAcademic);
        }

        private void btnStudentRecords_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlStudentRecords);
        }

        private void btnEnrollment_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlEnrollment);
        }

        private void btnAccounting_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlAccounting);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("You want to Logout?", "Notification", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                systemlogs.userlogs($"Log Out to SMS");



                var myform = new Login();
                this.Hide();
                myform.ShowDialog();
            }
            else
            {

            }



        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            displayDashboard();
        }

        private void displayDashboard()
        {
            var myForm = new Dashboard();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            myForm.stat = btnAdmin.Text;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
        }

        private void btnAddUsers_Click(object sender, EventArgs e)
        {
            var myForm = new Users(this);
            AllForms.MyForms(myForm, this);

        }

        private void btnDepartment_Click(object sender, EventArgs e)
        {
            var myForm = new AcademicYear();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            var myForm = new DownpaymentFee();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
        }

        private void btnOrNumber_Click(object sender, EventArgs e)
        {
            var myForm = new ORNumberMaintenance();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            var myForm = new LockerModule();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
        }

        private void btnFeeCategory_Click(object sender, EventArgs e)
        {
            var myForm = new FeeManagement(this);
            AllForms.MyForms(myForm, this);

        }

        private void btnFeeStructure_Click(object sender, EventArgs e)
        {
            var myForm = new FeeStructure(this);
            AllForms.MyForms(myForm, this);

        }

        private void btnSubjectLoads_Click(object sender, EventArgs e)
        {
            var myForm = new ViewTeacher();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
        }

        private void btnSubjects_Click(object sender, EventArgs e)
        {
            var myForm = new Course(this);
            AllForms.MyForms(myForm, this);

        }

        private void btnClassSchedule_Click(object sender, EventArgs e)
        {
            var myForm = new Subject();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
        }

        private void btnUE_Click(object sender, EventArgs e)
        {
            var myForm = new NewApplicants(this);
            AllForms.MyForms(myForm, this);

        }

        private void btnAdmitStudent_Click(object sender, EventArgs e)
        {
            var myForm = new StudentInformation(this);
            AllForms.MyForms(myForm, this);

        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            var myForm = new ViewStudentList();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
        }

        private void iconButton8_Click(object sender, EventArgs e)
        {
            var myForm = new ViewAllStudents();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            var myForm = new StudentActivation(this);
            AllForms.MyForms(myForm, this);
        }

        private void iconButton13_Click(object sender, EventArgs e)
        {
            var myForm = new StudentActivatedList(this);
            AllForms.MyForms(myForm, this);

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            var myForm = new StudentPaymentList();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
        }

        private void iconButton11_Click(object sender, EventArgs e)
        {
            var myForm = new FinancialReports();
            pnlShow.Controls.Clear();
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            pnlShow.Controls.Add(myForm);
            myForm.Show();
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Release the mouse capture started by the mouse down.
                panel3.Capture = false; //select control

                // Create and send a WM_NCLBUTTONDOWN message.
                const int WM_NCLBUTTONDOWN = 0x00A1;
                const int HTCAPTION = 2;
                Message msg =
                    Message.Create(this.Handle, WM_NCLBUTTONDOWN,
                        new IntPtr(HTCAPTION), IntPtr.Zero);
                this.DefWndProc(ref msg);
            }
        }

        public void displaySchoolYear()
        {
            //dgvAcademicYear.Rows.Clear();
            Connection connect = new Connection();

            MySqlDataReader mdr;
            try
            {



                string sql = $"select * from gsacademicyear where Status = 'Active'";


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

                            lblSY.Text = $"{mdr["Year1"]}-{mdr["Year2"]}";

                        }

                    }
                }




                connect.conn.Close();



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

            Connection connect = new Connection();

            MySqlDataReader mdr;
            try
            {



                string sql = $"select * from yearterm  where Status = 'Active'";


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

                            lblTerm.Text = mdr["Term"].ToString();

                        }

                    }
                }




                connect.conn.Close();



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

        private void SidePanel_KeyDown(object sender, KeyEventArgs e)
        {





        }

        private void btnAddUsers_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            var myForm = new ManageDiscount(this);
            AllForms.MyForms(myForm, this);

        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            var myForm = new ManageStrandList(this);
            AllForms.MyForms(myForm, this);
        }
    }
}
