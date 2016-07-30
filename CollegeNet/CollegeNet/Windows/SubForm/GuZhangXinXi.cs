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
    public partial class GuZhangXinXi : Form
    {
        private bool isAddNew = false;
        private long YW_ID;
        private DataGridViewRow guZhangInformation = null;
        public GuZhangXinXi(long YW_ID)
        {
            isAddNew = true;
            this.YW_ID = YW_ID;
            InitializeComponent();
        }
        public GuZhangXinXi(long YW_ID,DataGridViewRow selectedRow)
        {
            this.YW_ID = YW_ID;
            guZhangInformation = selectedRow;
            InitializeComponent();
            try
            {
                tbShouHouNeiRong.Text = selectedRow.Cells["GZ_ShouHouNeiRong"].Value.ToString();
                if(selectedRow.Cells["GZ_SongBaoShiJian"].Value.ToString()!=String.Empty)
                    dtpSongBaoShiJian.Value = Convert.ToDateTime(selectedRow.Cells["GZ_SongBaoShiJian"].Value.ToString());
                if (selectedRow.Cells["GZ_ChuLiShiJian"].Value.ToString() != String.Empty)
                    dtpChuLiShiJian.Value = Convert.ToDateTime(selectedRow.Cells["GZ_ChuLiShiJian"].Value.ToString());
                tbJieDaiRen.Text = selectedRow.Cells["GZ_JieDaiRen"].Value.ToString();
                tbHuiFangRen.Text = selectedRow.Cells["GZ_HuiFangRen"].Value.ToString();
                checkBoxXiuFu.Checked = (bool)selectedRow.Cells["GZ_FlagXiuFu"].Value;
                checkBoxJiShi.Checked = (bool)selectedRow.Cells["GZ_FlagJiShi"].Value;
                checkBoxManYi.Checked = (bool)selectedRow.Cells["GZ_FlagManYi"].Value;
                tbBeiZhu.Text = selectedRow.Cells["GZ_BeiZhu"].Value.ToString();
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
                SqlParameter[] parameters = new SqlParameter[10];
                parameters[0]=new SqlParameter("@GZ_YWID", YW_ID);
                parameters[1]=new SqlParameter("@GZ_ShouHouNeiRong", tbShouHouNeiRong.Text);
                parameters[2]=new SqlParameter("@GZ_SongBaoShiJian", dtpSongBaoShiJian.Value);
                parameters[3]=new SqlParameter("@GZ_ChuLiShiJian", dtpChuLiShiJian.Value);
                parameters[4]=new SqlParameter("@GZ_JieDaiRen", tbJieDaiRen.Text);
                parameters[5]=new SqlParameter("@GZ_HuiFangRen", tbHuiFangRen.Text);
                parameters[6]=new SqlParameter("@GZ_FlagXiuFu", checkBoxXiuFu.Checked);
                parameters[7]=new SqlParameter("@GZ_FlagJiShi", checkBoxJiShi.Checked);
                parameters[8]=new SqlParameter("@GZ_FlagManYi", checkBoxManYi.Checked);
                parameters[9] = new SqlParameter("@GZ_BeiZhu", tbBeiZhu.Text);
                if (isAddNew)
                {
                    sql = @"INSERT INTO T_GuZhang(GZ_YWID,GZ_ShouHouNeiRong,GZ_SongBaoShiJian,
GZ_ChuLiShiJian,GZ_JieDaiRen,GZ_HuiFangRen,GZ_FlagXiuFu,GZ_FlagJiShi,GZ_FlagManYi,GZ_BeiZhu)
VALUES(@GZ_YWID,@GZ_ShouHouNeiRong,@GZ_SongBaoShiJian,@GZ_ChuLiShiJian,@GZ_JieDaiRen,@GZ_HuiFangRen,
@GZ_FlagXiuFu,@GZ_FlagJiShi,@GZ_FlagManYi,@GZ_BeiZhu)";
                }
                else
                {
                    sql = @"UPDATE T_GuZhang SET GZ_YWID=@GZ_YWID,GZ_ShouHouNeiRong=@GZ_ShouHouNeiRong,
GZ_SongBaoShiJian=@GZ_SongBaoShiJian,GZ_ChuLiShiJian=@GZ_ChuLiShiJian,GZ_JieDaiRen=@GZ_JieDaiRen,
GZ_HuiFangRen=@GZ_HuiFangRen,GZ_FlagXiuFu=@GZ_FlagXiuFu,GZ_FlagJiShi=@GZ_FlagJiShi,GZ_FlagManYi=@GZ_FlagManYi,
GZ_BeiZhu=@GZ_BeiZhu WHERE GZ_ID=" + guZhangInformation.Cells["GZ_ID"].Value.ToString();
                }
                SqlHelper.ExecuteNonQuery(sql, parameters);
                MessageBox.Show(isAddNew ? "插入故障信息成功！" : "修改故障信息成功！", "成功");
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
