using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using testNo3.FORMS.FeeManagement;
using testNo3.FORMS.Matriculation;

namespace testNo3
{
    public static class holder
    {
        public static bool temp = false;
        public static string connectionstring = "server=192.168.1.2;user id=Randel; password=RandelEonbotz2021;database=amsaismsdbv1;port=3306;SSL Mode=None";

        // ===== Start ======= paging =========
        public static int limit = 10;
        public static int offset_ = 0;
        public static int total = 0;
        public static int page = 1;

        public static int lastpage = 0;
        public static int lastP = 0;
        public static decimal value = 0;
        // ===== end ======= paging =========



    }
    public class systemlogs // ======= start ===== Logs ==========================
    {
        public static void userlogs(string marks)
        {
            try
            {
                Connection connect = new Connection();
                MySqlConnection conn;
                MySqlCommand cmd;


                string sql = "INSERT INTO logs (Name, Role, Marks,DateOp) VALUES (@Name,@Role,@Marks,CURRENT_TIMESTAMP);";



                conn = connect.getcon();
                conn.Open();
                using (cmd = new MySqlCommand(sql, conn))
                {


                    cmd.Parameters.AddWithValue("@Name", smsUsers.Users);
                    cmd.Parameters.AddWithValue("@Role", smsUsers.role);
                    cmd.Parameters.AddWithValue("@Marks", marks);




                    cmd.ExecuteNonQuery();

                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }// ====== end ====== Logs ==========================

    public class allkeypress
    {
        public static void numbersonly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }


    public class studinfo // ====== start ====== Student Information ==========================
    {

        public static void mbs(string msg)
        {
            MessageBox.Show(msg, "Notification", MessageBoxButtons.OK);
        }

        public static void RemoveJHStudent(string sid)
        {
            try
            {
                Connection connect = new Connection();
                MySqlConnection conn;
                MySqlCommand cmd;


                string sql = "call Delete_StudentJHS(@SRID);";



                conn = connect.getcon();
                conn.Open();
                using (cmd = new MySqlCommand(sql, conn))
                {

                    cmd.Parameters.AddWithValue("@SRID", sid);

                    cmd.ExecuteNonQuery();

                }

                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void RemoveSHStudent(string sid)
        {
            try
            {
                Connection connect = new Connection();
                MySqlConnection conn;
                MySqlCommand cmd;


                string sql = "call Delete_StudentSHS(@SSRID);";



                conn = connect.getcon();
                conn.Open();
                using (cmd = new MySqlCommand(sql, conn))
                {

                    cmd.Parameters.AddWithValue("@SSRID", sid);

                    cmd.ExecuteNonQuery();

                }

                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void ActivateJHStudent(string srid)
        {
            try
            {
                Connection connect = new Connection();
                MySqlConnection conn;
                MySqlCommand cmd;


                string sql = "call Activate_JHStudent (@srid);";



                conn = connect.getcon();
                conn.Open();
                using (cmd = new MySqlCommand(sql, conn))
                {

                    cmd.Parameters.AddWithValue("@srid", srid);

                    cmd.ExecuteNonQuery();

                }

                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void ActivateSHStudent(string srid)
        {
            try
            {
                Connection connect = new Connection();
                MySqlConnection conn;
                MySqlCommand cmd;


                string sql = "call Activate_SHStudent (@srid);";



                conn = connect.getcon();
                conn.Open();
                using (cmd = new MySqlCommand(sql, conn))
                {

                    cmd.Parameters.AddWithValue("@srid", srid);

                    cmd.ExecuteNonQuery();

                }

                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void ShowStudentJHSselected(string sid, TextBox Name, TextBox GradeLevel)
        {



            Connection connect = new Connection();
            MySqlConnection conn;
            MySqlCommand cmd;
            MySqlDataReader mdr;



            try
            {
                string sql = $"call Show_StudentJHSselected({sid});";


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
                            Name.Text = $"{mdr["LastName"]}, {mdr["FirstName"]} {mdr["MiddleName"]} {mdr["Suffix"]}";
                            GradeLevel.Text = mdr["GradeLevel"].ToString();
                        }

                    }
                }






                conn.Close();



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



    }// ====== end ====== Student Information ==========================


    public class AllForms// ===== start ======= calling forms ==========================
    {


        public static void MyForms(Form value, SidePanel dis)
        {
            //var myForm = new (value);
            dis.pnlShow.Controls.Clear();
            value.TopLevel = false;
            value.AutoScroll = false;
            dis.pnlShow.Controls.Add(value);
            //myForm.tabControl1.SelectedIndex = 0;
            value.Show();
        }


        public static void MyOtherForms(Form value, AddMatriculation pnl)
        {
            //var myForm = new (value);
            pnl.pnlSelection.Controls.Clear();
            value.TopLevel = false;
            value.AutoScroll = false;
            pnl.pnlSelection.Controls.Add(value);
            //myForm.tabControl1.SelectedIndex = 0;
            value.Show();
        }
    }// ====== end ====== calling forms ==========================




    public class alldatagrid// ====== start ====== datagridviews ==========================
    {
        public static void DatagridSelectedMatpack(DataGridView dgv, string StudID) //========= start =========== Matriculation selected pack =============
        {
            Connection connect = new Connection();
            MySqlConnection conn;
            MySqlCommand cmd;
            MySqlDataReader mdr;

            dgv.Rows.Clear();

            try
            {
                string sql = $"call Show_MatAcctItems({StudID});";


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
                            dgv.Rows.Add(mdr["acctID"].ToString(), mdr["AcctTitle"].ToString(), mdr["Description"].ToString(), Convert.ToDouble(mdr["Amount"]).ToString("N"));
                        }

                    }
                }






                conn.Close();

                dgv.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

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
        }//========= end =========== Matriculation selected pack =============

        public static void DatagridSelectedAcctList(DataGridView dgv, int id) //========= start =========== FeeStructure =============
        {
            Connection connect = new Connection();
            MySqlConnection conn;
            MySqlCommand cmd;
            MySqlDataReader mdr;

            dgv.Rows.Clear();

            try
            {
                string sql = $"call Show_PackageAcctList({id});";


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
                            dgv.Rows.Add(mdr["acctID"].ToString(), mdr["AcctTitle"].ToString(), mdr["Description"].ToString(), Convert.ToDouble(mdr["Amount"]).ToString("N"));
                        }

                    }
                }






                conn.Close();

                dgv.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

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
        }//========= end =========== FeeStructure =============

        public static void DatagridFeeStructure(DataGridView dgv) //========= start =========== FeeStructure =============
        {
            Connection connect = new Connection();
            MySqlConnection conn;
            MySqlCommand cmd;
            MySqlDataReader mdr;

            dgv.Rows.Clear();

            try
            {
                string sql = $"call Show_Packagelist();";


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
                            dgv.Rows.Add(mdr["packageID"].ToString(), mdr["PackageTitle"].ToString(), mdr["ListNo"].ToString(), Convert.ToDouble(mdr["total"]).ToString("N"));
                        }

                    }
                }






                conn.Close();

                dgv.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

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
        }//========= end =========== FeeStructure =============

        public static void DatagridCategory(DataGridView dgv)//========= start =========== Category =============
        {
            Connection connect = new Connection();
            MySqlConnection conn;
            MySqlCommand cmd;
            MySqlDataReader mdr;

            dgv.Rows.Clear();

            try
            {
                string sql = $"SELECT * FROM accountitem";


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
                            dgv.Rows.Add(mdr["acctID"].ToString(), mdr["AcctTitle"].ToString(), mdr["Description"].ToString(), Convert.ToDouble(mdr["Amount"]).ToString("N"));
                        }

                    }
                }






                conn.Close();

                dgv.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

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
        }//========= end =========== Category =============


        public static void DatagridStrand(DataGridView dgv)//========= Start =========== StrandData =============
        {
            Connection connect = new Connection();
            MySqlConnection conn;
            MySqlCommand cmd;
            MySqlDataReader mdr;

            dgv.Rows.Clear();

            try
            {
                string sql = $"SELECT * FROM managestrand";


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
                            dgv.Rows.Add(mdr["strandID"].ToString(), mdr["StrandCode"].ToString(), mdr["Description"].ToString());
                        }

                    }
                }






                conn.Close();

                dgv.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                dgv.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

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
        }//========= end =========== StrandData =============



    }// ====== end ====== datagridviews ==========================

    public class fees// ====== start ====== Fee Structure and Category ==========================
    {


        public static void RemoveFeeStructure(string id, string strucName, DataGridView dgv)
        {
            Connection connect = new Connection();
            MySqlConnection conn;
            MySqlCommand cmd;

            try
            {
                string sql = $"call Delete_Package({id});";



                conn = connect.getcon();
                conn.Open();
                using (cmd = new MySqlCommand(sql, conn))
                {


                    //cmd.Parameters.AddWithValue("@SID", txtStructure.Text);





                    cmd.ExecuteNonQuery();

                }

                conn.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            alldatagrid.DatagridFeeStructure(dgv);

            systemlogs.userlogs($"Package: {strucName} Has been Removed from the list");

            studinfo.mbs($"Package: {strucName} Has been Removed from the list");
        }



        public static void RemoveCategory(string id, string strucName, DataGridView dgv)
        {
            Connection connect = new Connection();
            MySqlConnection conn;
            MySqlCommand cmd;

            try
            {
                string sql = $"call Delete_AccountItem({id});";



                conn = connect.getcon();
                conn.Open();
                using (cmd = new MySqlCommand(sql, conn))
                {


                    //cmd.Parameters.AddWithValue("@SID", txtStructure.Text);





                    cmd.ExecuteNonQuery();

                }

                conn.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            alldatagrid.DatagridCategory(dgv);

            systemlogs.userlogs($"Category: {strucName} Has been Removed from the list");

            studinfo.mbs($"Category: {strucName} Has been Removed from the list");
        }



        public static void SaveSelectedAcct(int packID, string actID)
        {
            Connection connect = new Connection();
            MySqlConnection conn;
            MySqlCommand cmd;

            try
            {
                string sql = "call Save_PackageList(@packID,@actID);";



                conn = connect.getcon();
                conn.Open();
                using (cmd = new MySqlCommand(sql, conn))
                {


                    cmd.Parameters.AddWithValue("@packID", packID);
                    cmd.Parameters.AddWithValue("@actID", actID);






                    cmd.ExecuteNonQuery();

                }

                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public static void SaveFeeStructure(string Sname)
        {
            Connection connect = new Connection();
            MySqlConnection conn;
            MySqlCommand cmd;

            try
            {
                string sql = "call Save_Package(@SName);";



                conn = connect.getcon();
                conn.Open();
                using (cmd = new MySqlCommand(sql, conn))
                {


                    cmd.Parameters.AddWithValue("@SName", Sname);










                    cmd.ExecuteNonQuery();

                }

                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void SaveCategory(string title, string amt, string descrpt)
        {
            Connection connect = new Connection();
            MySqlConnection conn;
            MySqlCommand cmd;
            try
            {
                string sql = "call Save_AccountItem(@title,@amt,@descrpt);";



                conn = connect.getcon();
                conn.Open();
                using (cmd = new MySqlCommand(sql, conn))
                {


                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@amt", amt);
                    cmd.Parameters.AddWithValue("@descrpt", descrpt);









                    cmd.ExecuteNonQuery();

                }

                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void UpdateCategory(string Catid, string cat)
        {
            Connection connect = new Connection();
            MySqlConnection conn;
            MySqlCommand cmd;
            try
            {
                string sql = "call Update_Category(@catID,@cat);";



                conn = connect.getcon();
                conn.Open();
                using (cmd = new MySqlCommand(sql, conn))
                {


                    cmd.Parameters.AddWithValue("@catID", Catid);
                    cmd.Parameters.AddWithValue("@cat", cat);









                    cmd.ExecuteNonQuery();

                }

                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }// ====== end ====== Fee Structure and Category ==========================

    public class AllStrand// ====== Start ====== Strand ==========================
    {
        public static void SaveStrand(string standcode, string descript)
        {
            Connection connect = new Connection();
            MySqlConnection conn;
            MySqlCommand cmd;

            try
            {
                string sql = "call Save_Strand(@standcode,@descript);";



                conn = connect.getcon();
                conn.Open();
                using (cmd = new MySqlCommand(sql, conn))
                {


                    cmd.Parameters.AddWithValue("@standcode", standcode);
                    cmd.Parameters.AddWithValue("@descript", descript);






                    cmd.ExecuteNonQuery();

                }

                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void ShowcmbStrand(ComboBox cmb)
        {
            Connection connect = new Connection();
            MySqlConnection conn;
            MySqlCommand cmd;
            MySqlDataReader mdr;
            try
            {
                string sql = $"SELECT * FROM managestrand;";


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

                            cmb.Items.Add(mdr["StrandCode"].ToString());


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
    }// ====== End ====== Strand ==========================

    public class StudentActive
    {
        public static void ShowSelectedStudent(string rID, TextBox Name, TextBox Grade, TextBox Type, TextBox Gender, TextBox DateOfRegistration)
        {
            Connection connect = new Connection();
            MySqlConnection conn;
            MySqlCommand cmd;
            MySqlDataReader mdr;
            try
            {
                string sql = $"call Show_ActiveStudentJHS({rID})";


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


                            Name.Text = $"{mdr["LastName"]}, {mdr["FirstName"]} {mdr["MiddleName"]} {mdr["Suffix"]}";
                            Grade.Text = mdr["GradeLevel"].ToString();
                            Type.Text = mdr["Type"].ToString();
                            Gender.Text = mdr["Gender"].ToString();
                            DateOfRegistration.Text = Convert.ToDateTime(mdr["DateRecord"]).ToString("MMM dd, yyyy");


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

    public class StudentDiscount
    {
        public static void ShowDiscount(DataGridView dgv)
        {
            Connection connect = new Connection();
            MySqlConnection conn;
            MySqlCommand cmd;
            MySqlDataReader mdr;

            dgv.Rows.Clear();

            try
            {
                string sql = $"SELECT * FROM discount";


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
                            dgv.Rows.Add(mdr["DiscountID"].ToString(), mdr["DiscountName"].ToString(), Convert.ToDouble(mdr["Amount"]).ToString("N"));
                        }

                    }
                }






                conn.Close();

                dgv.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

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
    }

    public class SetMatriculation
    {

        public static void totsum(DataGridView dgv, TextBox txt)
        {
            double sum = 0;
            // amount = 0;
            for (int i = 0; i < dgv.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(dgv.Rows[i].Cells[3].Value);

                // dataGridView1.Rows[i].Cells[4].Value = Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value) * Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value);
            }
            txt.Text = sum.ToString("N");
        }


        public static void SelectPackage(string StudID, string packID)
        {
            Connection connect = new Connection();
            MySqlConnection conn;
            MySqlCommand cmd;

            try
            {
                string sql = $"call Save_AcctItembyPack(@StudID,@packID);";



                conn = connect.getcon();
                conn.Open();
                using (cmd = new MySqlCommand(sql, conn))
                {


                    cmd.Parameters.AddWithValue("@StudID", StudID);
                    cmd.Parameters.AddWithValue("@packID", packID);





                    cmd.ExecuteNonQuery();

                }

                conn.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void SelectAccountItem(string StudID, string acctID)
        {
            Connection connect = new Connection();
            MySqlConnection conn;
            MySqlCommand cmd;

            try
            {
                string sql = $"call Save_AcctItembyItem(@StudID,@acctID);";



                conn = connect.getcon();
                conn.Open();
                using (cmd = new MySqlCommand(sql, conn))
                {


                    cmd.Parameters.AddWithValue("@StudID", StudID);
                    cmd.Parameters.AddWithValue("@acctID", acctID);





                    cmd.ExecuteNonQuery();

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
