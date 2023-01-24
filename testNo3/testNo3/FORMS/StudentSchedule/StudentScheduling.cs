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
using testNo3.FORMS.Matriculation;

namespace testNo3.FORMS.StudentSchedule
{
    public partial class StudentScheduling : Form
    {
        public string studentID;
        public string rid;
        SidePanel dis = new SidePanel();
        public StudentScheduling(SidePanel dis)
        {
            InitializeComponent();
            this.dis = dis;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            display();

        }
        public void display()
        {
            txtStudentID.Text = studentID;
            StudentActive.ShowSelectedStudent(rid, txtName, txtGrade, txtType, txtGender, txtDateOfRegistration);
        }

        private void dgvStudentSched_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAddMatriculation_Click(object sender, EventArgs e)
        {
            var myform = new AddMatriculation(dis);
            AllForms.MyForms(myform, dis);
        }
    }
}
