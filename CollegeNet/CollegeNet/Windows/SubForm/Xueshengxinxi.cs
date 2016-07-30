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
    public partial class Xueshengxinxi : Form
    {
        private bool isAddNew = false;
        private DataGridViewRow studentInformation = null;
        public Xueshengxinxi()
        {
            isAddNew = true;
            InitializeComponent();
        }
        public Xueshengxinxi(DataGridViewRow selectedRow)
        {
            studentInformation = selectedRow;
            InitializeComponent();
            try
            {
                tbDangAnBianHao.Text = selectedRow.Cells["dangAnBianHao"].Value.ToString();
                tbXueHao.Text = selectedRow.Cells["xueHao"].Value.ToString();
                tbXingMing.Text = selectedRow.Cells["xingMing"].Value.ToString();
                cbXingBie.Text = selectedRow.Cells["xingBie"].Value.ToString();
                cbGongYuMingCheng.Text = selectedRow.Cells["gongYuMingCheng"].Value.ToString();
                tbSuSheHao.Text = selectedRow.Cells["suSheHao"].Value.ToString();
                cbFangJianLeiXing.Text = selectedRow.Cells["fangJianLeiXing"].Value.ToString();
                cbChuangHao.Text = selectedRow.Cells["chuangHao"].Value.ToString();
                tbZhuanYe.Text = selectedRow.Cells["zhuanYe"].Value.ToString();
                tbXueYuan.Text = selectedRow.Cells["xueYuan"].Value.ToString();
                tbNianJi.Text = selectedRow.Cells["nianJi"].Value.ToString();
                tbXueLi.Text = selectedRow.Cells["xueLi"].Value.ToString();
                tbXueZhi.Text = selectedRow.Cells["xueZhi"].Value.ToString();
                if (selectedRow.Cells["biYeShiJian"].Value.ToString() != String.Empty)
                    dtpBiYeShiJian.Value = Convert.ToDateTime(selectedRow.Cells["biYeShiJian"].Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("学生信息出现错误，请检查该条数据", "出现一个错误");
                this.Close();
            }
        }

        private void Xueshengxinxi_Load(object sender, EventArgs e)
        {
            cbGongYuMingCheng.DataSource = SqlHelper.ExecuteDataTable("SELECT D_Value FROM T_Dic WHERE D_Name='宿舍楼名称'");
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "";
                SqlParameter[] parameters = new SqlParameter[14];
                parameters[0] = new SqlParameter("@dangAnBianHao", tbDangAnBianHao.Text.ToString());
                parameters[1] = new SqlParameter("@xueHao", tbXueHao.Text.ToString());
                parameters[2] = new SqlParameter("@xingMing", tbXingMing.Text);
                parameters[3] = new SqlParameter("@xingBie", cbXingBie.Text);
                parameters[4] = new SqlParameter("@gongYuMingCheng", cbGongYuMingCheng.Text);
                parameters[5] = new SqlParameter("@suSheHao", tbSuSheHao.Text);
                parameters[6] = new SqlParameter("@fangJianLeiXing", cbFangJianLeiXing.Text);
                parameters[7] = new SqlParameter("@chuangHao", cbChuangHao.Text);
                parameters[8] = new SqlParameter("@zhuanYe", tbZhuanYe.Text);
                parameters[9] = new SqlParameter("@xueYuan", tbXueYuan.Text);
                parameters[10] = new SqlParameter("@nianJi", tbNianJi.Text);
                parameters[11] = new SqlParameter("@xueLi", tbXueLi.Text);
                parameters[12] = new SqlParameter("@xueZhi", tbXueZhi.Text);
                parameters[13] = new SqlParameter("@biYeShiJian", dtpBiYeShiJian.Value);
                if (isAddNew)
                {
                    sql = @"INSERT INTO T_Student(Stu_DangAnBianHao,Stu_XueHao,Stu_XingMing,Stu_XingBie,
Stu_GongYuMingCheng,Stu_SuSheHao,Stu_ChuangHao,Stu_FangJianLeiXing,Stu_ZhuanYe,Stu_XueYuan,Stu_NianJi,
Stu_XueLi,Stu_XueZhi,Stu_BiYeShiJian)
VALUES(@dangAnBianHao,@xueHao,@xingMing,@xingBie,@gongYuMingCheng,@suSheHao,@chuangHao,@fangJianLeiXing,
@zhuanYe,@xueYuan,@nianJi,@xueLi,@xueZhi,@biYeShiJian)";
                }
                else
                {
                    sql = @"UPDATE T_Student SET Stu_DangAnBianHao=@dangAnBianHao,
                            Stu_XueHao=@xueHao,
                            Stu_XingMing=@xingMing,
                            Stu_XingBie=@xingBie,
                            Stu_GongYuMingCheng=@gongYuMingCheng,
                            Stu_SuSheHao=@suSheHao,
                            Stu_ChuangHao=@chuangHao,
                            Stu_FangJianLeiXing=@fangJianLeiXing,
                            Stu_ZhuanYe=@zhuanYe,
                            Stu_XueYuan=@xueYuan,
                            Stu_NianJi=@nianJi,
                            Stu_XueLi=@xueLi,
                            Stu_XueZhi=@xueZhi,
                            Stu_BiYeShiJian=@biYeShiJian
                            WHERE Stu_ID=" + studentInformation.Cells["S_ID"].Value.ToString();
                }
                SqlHelper.ExecuteNonQuery(sql, parameters);
                MessageBox.Show(isAddNew?"插入学生信息成功！":"修改学生信息成功！", "成功");
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
