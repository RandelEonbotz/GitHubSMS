using MySql.Data.MySqlClient;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testNo3.FORMS.User
{
    public partial class NewUsers : Form
    {
        SidePanel dis = new SidePanel();

        public string idd;

        public NewUsers(SidePanel dis)
        {
            InitializeComponent();
            this.dis = dis;
        }


        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            dis.btnAddUsers.PerformClick();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            dis.btnAddUsers.PerformClick();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ComboBox[] selCmb = { cmbRole };
            TextBox[] inputs = { txtName, txtUsername, txtPassword, txtConfirmPassword, txtMacAddress };


            if (btnSave.Text.Equals("Update"))
            {
                if (Validator.isEmptyCmb(selCmb) && Validator.isEmpty(inputs) && Validator.UpdateConfirmation())
                {
                    if (txtConfirmPassword.Text != txtPassword.Text)
                    {
                        Validator.AlertDanger("Confirm password doesn't match");
                    }
                    else
                    {
                        DBContext.GetContext().Query("users").Where("id", idd).Update(new
                        {
                            name = txtName.Text.Trim(),
                            username = txtUsername.Text.Trim(),
                            password = txtPassword.Text.Trim(),
                            macAddress = txtMacAddress.Text.Trim()
                        });


                        systemlogs.userlogs($"Update User");



                        dis.btnAddUsers.PerformClick();
                    }

                }
            }
            else if (btnSave.Text.Equals("Save"))
            {
                if (Validator.isEmptyCmb(selCmb) && Validator.isEmpty(inputs) && Validator.AddConfirmation())
                {
                    if (txtConfirmPassword.Text != txtPassword.Text)
                    {
                        Validator.AlertDanger("Confirm password doesn't match");
                    }
                    else
                    {
                        DBContext.GetContext().Query("users").Insert(new
                        {
                            name = txtName.Text.Trim(),
                            username = txtUsername.Text.Trim(),
                            password = txtPassword.Text.Trim(),
                            userrole = cmbRole.Text,
                            macAddress = txtMacAddress.Text.Trim()
                        });

                        systemlogs.userlogs($"Adding User");



                        dis.btnAddUsers.PerformClick();
                    }
                }
            }
        }
    }
}
