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
    public partial class AddSection : Form
    {
        SidePanel dis = new SidePanel();
        public AddSection(SidePanel dis)
        {
            InitializeComponent();
            this.dis = dis;
        }

        private void Form1_Load(object sender, EventArgs e)
        {


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


                    string sql = "INSERT INTO sections ( Section) VALUES (@Section);";



                    conn = connect.getcon();
                    conn.Open();
                    using (cmd = new MySqlCommand(sql, conn))
                    {



                        cmd.Parameters.AddWithValue("@Section", txtSection.Text);







                        cmd.ExecuteNonQuery();

                    }

                    conn.Close();
                    //dis.btnSubjects.PerformClick();

                    var myForm = new Course(dis);
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
            }
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            dis.btnSubjects.PerformClick();
        }
    }
}
