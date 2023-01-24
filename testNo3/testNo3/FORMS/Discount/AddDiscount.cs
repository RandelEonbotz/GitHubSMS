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
using testNo3.FORMS.Discount;

namespace testNo3.FORMS.Discount
{
    public partial class AddDiscount : Form
    {
        SidePanel dis = new SidePanel();
        public AddDiscount(SidePanel dis)
        {
            InitializeComponent();
            this.dis = dis;
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Connection connect = new Connection();
            MySqlConnection conn;
            MySqlCommand cmd;
            if (btnSave.Text.Equals("Save"))
            {
                try
                {
                    string sql = "call Save_Discount(@DName, @DAmount);";



                    conn = connect.getcon();
                    conn.Open();
                    using (cmd = new MySqlCommand(sql, conn))
                    {


                        cmd.Parameters.AddWithValue("@DName", txtDiscountName.Text);
                        cmd.Parameters.AddWithValue("@DAmount", txtAmount.Text);








                        cmd.ExecuteNonQuery();

                    }

                    conn.Close();
                    var myForm = new ManageDiscount(dis);
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
            }
        }
    }
}
