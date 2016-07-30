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
    public partial class UserInfo : Form
    {
        //U_Rights 1代表管理员，2代表录入员
        private bool isAddNew = false;
        private DataGridViewRow userInformation = null;
        public UserInfo()
        {
            isAddNew = true;
            InitializeComponent();
        }
        public UserInfo(DataGridViewRow selectedRow)
        {
            userInformation = selectedRow;
            InitializeComponent();
            try
            {
                tbAccountName.Text = selectedRow.Cells["U_AccountName"].Value.ToString();
                tbPassword.Text = selectedRow.Cells["U_Password"].Value.ToString();
                cobRights.Text = selectedRow.Cells["U_Rights"].Value.ToString();
                //if (Convert.ToInt32(selectedRow.Cells["U_Rights"].Value) == 1)
                //{
                //    cobRights.Text = "管理员";
                //}
                //else if (Convert.ToInt32(selectedRow.Cells["U_Rights"]) == 2)
                //{
                //    cobRights.Text = "录入员";
                //}
                //else
                //{
                //    cobRights.SelectedIndex = -1;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("信息出现错误，请检查该条数据", "出现一个错误");
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "";
                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@accountName", tbAccountName.Text);
                parameters[1] = new SqlParameter("@password", tbPassword.Text);
                parameters[2] = new SqlParameter("@rights", cobRights.Text);//== "管理员" ? 1 : cobRights.Text == "录入员" ? 2 : -1);
                if (isAddNew)
                {
                    sql = "INSERT INTO T_User(U_AccountName,U_Password,U_Rights) VALUES(@accountName,@password,@rights)";
                }
                else
                {
                    sql = "UPDATE T_User SET U_AccountName=@accountName,U_Password=@password,U_Rights=@rights WHERE U_ID=" + userInformation.Cells["U_ID"].Value.ToString();
                }
                SqlHelper.ExecuteNonQuery(sql, parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "出现一个错误");
            }
            finally
            {
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
