using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollegeNet
{
    public partial class Yvjing : Form
    {
        public Yvjing()
        {
            InitializeComponent();
        }

        private void Yvjing_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView2.AutoGenerateColumns = false;

            dataGridView1.DataSource = getYuJing(30);
            dataGridView2.DataSource = getGuZhang();
        }
        #region 按钮相应
        private void btnYuJing_Click(object sender, EventArgs e)
        {
            int daysNum = 0;
            if (rbtnFor10days.Checked)
                daysNum = 10;
            else if (rbtnFor20days.Checked)
                daysNum = 20;
            else if (rbtnForsomedays.Checked)
                try { daysNum = Convert.ToInt32(tbDayNum.Text); }
                catch (System.FormatException ex) { MessageBox.Show("天数需要输入整数", "提示"); return; }
            dataGridView1.DataSource = getYuJing(daysNum);
        }

        private void btnYiChuLi_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
            try
            {
                SqlHelper.ExecuteNonQuery("UPDATE T_YeWu SET YW_Flag=2 WHERE YW_ID=" + dataGridView1.SelectedRows[0].Cells["YW_ID"].Value.ToString());
                MessageBox.Show("信息设置为已处理！", "成功");
                btnYuJing_Click(this,new EventArgs());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "出现一个错误");
            }
        }

        private void btnReflash_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = getGuZhang();
        }

        private void btnYiJieJue_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0)
            {
                return;
            }
            GuZhangXinXi gzChange = new GuZhangXinXi(Convert.ToInt64(dataGridView2.SelectedRows[0].Cells["GZ_YWID"].Value.ToString()), dataGridView2.SelectedRows[0]);
            gzChange.ShowDialog();
            btnReflash_Click(this, new EventArgs());
        }
        #endregion

        private DataTable getYuJing(int daysNum)
        {
            //(1-x)*fanction0+x*fanction1
            //(n-x)/n*f0 //[1-(x-0)][1-(x-1)][1-(x-2)]...
            try
            {
                return SqlHelper.ExecuteDataTable(@"SELECT *,CASE WHEN YW_JiFeiLeiXing='整月' THEN dateadd(month, datediff(month, 0, YW_BanLiRiQi)+YW_QiXian, 0)
WHEN YW_JiFeiLeiXing='按日' THEN dateadd(month,YW_QiXian,YW_BanLiRiQi) END AS YW_DaoQiShiJian FROM T_YeWu WHERE (YW_YeWuLeiXing='新装' OR YW_YeWuLeiXing='续费') AND YW_Flag=1 AND ((YW_JiFeiLeiXing='整月' AND dateadd(month, datediff(month, 0, YW_BanLiRiQi)+YW_QiXian, 0)
<dateadd(day," + daysNum + ",getdate())) OR (YW_JiFeiLeiXing='按日' AND dateadd(month,YW_QiXian,YW_BanLiRiQi)<dateadd(day," + daysNum + ",getdate())))");
            }
            catch (Exception ex)
            {
                MessageBox.Show("请检查您的数据库连接、网络是否正常。", "出现一个错误");
                return null;
            }
        }

        private DataTable getGuZhang()
        {
            try
            {
                return SqlHelper.ExecuteDataTable("SELECT * FROM T_YeWu,T_GuZhang WHERE T_YeWu.YW_ID=T_GuZhang.GZ_YWID AND GZ_FlagXiuFu=0");
            }
            catch (Exception ex)
            {
                MessageBox.Show("请检查您的数据库连接、网络是否正常。", "出现一个错误");
                return null;
            }
        }
    }
}
