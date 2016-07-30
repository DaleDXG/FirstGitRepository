using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CollegeNet
{
    public partial class winLogin : Form
    {
        public Form front;

        public winLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string accountName = tbAccountName.Text.Trim();
                string password = tbPassword.Text.Trim();
                if (accountName == "" || password == "")
                {
                    MessageBox.Show("Please enter your accountname and password.");
                }
                else
                {
                    int retvalue = 0;
                    SqlParameter[] Params = new SqlParameter[2];
                    Params[0] = new SqlParameter("userName", accountName);
                    Params[1] = new SqlParameter("userPassword", password);
                    SqlHelper.ExecuteProcedure("Proc_User_UserLogin", Params, out retvalue);

                    if (retvalue == -1)
                    {
                        MessageBox.Show("您输入的账号不存在");
                        tbAccountName.Text = "";
                        tbAccountName.Focus();
                        tbPassword.Text = "";
                    }
                    else if (retvalue == -2)
                    {
                        MessageBox.Show("密码输入错误");
                        tbPassword.Text = "";
                        tbPassword.Focus();
                    }
                    else if (retvalue > 0)
                    {
                        //登录成功
                        LoginUser.isLogin = true;
                        LoginUser.id = retvalue;
                        DataRow drUser = SqlHelper.ExecuteDataTable("SELECT * FROM T_User WHERE U_ID=@u_id", new SqlParameter("@u_id", retvalue)).Rows[0];
                        LoginUser.accountName = drUser["U_AccountName"].ToString();
                        LoginUser.role = drUser["U_Rights"].ToString();
                        this.Close();
                        this.front.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "出现一个错误");//"请检查数据库连接"
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
