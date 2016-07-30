using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollegeNet
{
    public partial class Gaikuangshuju : Form
    {
        public Gaikuangshuju()
        {
            InitializeComponent();
        }

        private void Gaikuangshuju_Load(object sender, EventArgs e)
        {

        }

        private void btnTongJi1_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime time = dtpJieZhi1.Value;
                DataTable dtResult = SqlHelper.ExecuteDataTable(@"
SELECT YW_YunYingShang AS C1,COUNT(*) AS C2,SUM(YW_ZiFei) AS C3,Round(SUM(YW_ZiFei)/COUNT(*),2) AS C4 FROM T_YeWu 
WHERE (YW_YeWuLeiXing='新装' OR YW_YeWuLeiXing='续费') AND YW_BanLiRiQi<@time AND
((YW_JiFeiLeiXing='整月' AND dateadd(month, datediff(month, 0, YW_BanLiRiQi)+YW_QiXian, 0)>@time) 
OR (YW_JiFeiLeiXing='按日' AND dateadd(month,YW_QiXian,YW_BanLiRiQi)>@time))
AND YW_ID NOT IN (SELECT YW_Target FROM T_YeWu WHERE YW_YeWuLeiXing='退网')
 GROUP BY YW_YunYingShang",
                    new SqlParameter("@time", time));
                DataRow drHeJi = dtResult.NewRow();
                drHeJi["C1"] = "合计";
                int c2HeJi = 0, c3HeJi = 0;
                foreach (DataRow dr in dtResult.Rows)
                {
                    c2HeJi += Convert.ToInt32(dr["C2"]);
                    c3HeJi += Convert.ToInt32(dr["C3"]);
                }
                drHeJi["C2"] = c2HeJi;
                drHeJi["C3"] = c3HeJi;
                drHeJi["C4"] = Math.Round((decimal)c3HeJi / c2HeJi, 2);
                dtResult.Rows.Add(drHeJi);
                dataGridView1.DataSource = dtResult;

                int countRooms = Convert.ToInt32(SqlHelper.ExecuteScalar("SELECT COUNT(*) FROM (SELECT COUNT(*) AS A FROM T_Student GROUP BY Stu_GongYuMingCheng,Stu_SuSheHao) ID;"));
                int countNetRooms = Convert.ToInt32(SqlHelper.ExecuteScalar(@"
SELECT COUNT(*) FROM (
SELECT DISTINCT YW_LouMing,YW_SuSheHao FROM (
SELECT * FROM T_YeWu 
WHERE (YW_YeWuLeiXing='新装' OR YW_YeWuLeiXing='续费') AND YW_BanLiRiQi<@time AND
((YW_JiFeiLeiXing='整月' AND dateadd(month, datediff(month, 0, YW_BanLiRiQi)+YW_QiXian, 0)>@time) 
OR (YW_JiFeiLeiXing='按日' AND dateadd(month,YW_QiXian,YW_BanLiRiQi)>@time))
AND YW_ID NOT IN (SELECT DISTINCT YW_Target FROM T_YeWu WHERE YW_YeWuLeiXing='退网' OR YW_YeWuLeiXing='移机')
UNION
SELECT * FROM T_YeWu AS A WHERE YW_YeWuLeiXing='移机' 
AND YW_Target IN (SELECT DISTINCT YW_ID FROM T_YeWu WHERE (YW_JiFeiLeiXing='整月' AND dateadd(month, datediff(month, 0, YW_BanLiRiQi)+YW_QiXian, 0)>@time) 
OR (YW_JiFeiLeiXing='按日' AND dateadd(month,YW_QiXian,YW_BanLiRiQi)>@time)) AND YW_BanLiRiQi<@time
AND YW_ID IN (SELECT TOP 1 YW_ID FROM T_YeWu WHERE A.YW_Target=YW_Target ORDER BY YW_BanLiRiQi DESC)
) AS B) AS C",
                    new SqlParameter("@time", time)));
                int countNoNetBiYeShengRooms = Convert.ToInt32(SqlHelper.ExecuteScalar(@"
SELECT COUNT(*) FROM (
SELECT DISTINCT Stu_GongYuMingCheng,Stu_SuSheHao FROM T_Student 
WHERE DATEADD(YEAR,-1,CONVERT(DATE,Stu_BiYeShiJian,111)) < GETDATE() AND Stu_XueHao!=''
EXCEPT (
SELECT DISTINCT YW_LouMing,YW_SuSheHao FROM (
SELECT * FROM T_YeWu 
WHERE (YW_YeWuLeiXing='新装' OR YW_YeWuLeiXing='续费') AND YW_BanLiRiQi<GETDATE() AND
((YW_JiFeiLeiXing='整月' AND dateadd(month, datediff(month, 0, YW_BanLiRiQi)+YW_QiXian, 0)>GETDATE()) 
OR (YW_JiFeiLeiXing='按日' AND dateadd(month,YW_QiXian,YW_BanLiRiQi)>GETDATE()))
AND YW_ID NOT IN (SELECT DISTINCT YW_Target FROM T_YeWu WHERE YW_YeWuLeiXing='退网' OR YW_YeWuLeiXing='移机')
UNION
SELECT * FROM T_YeWu AS A WHERE YW_YeWuLeiXing='移机' 
AND YW_Target IN (SELECT DISTINCT YW_ID FROM T_YeWu WHERE (YW_JiFeiLeiXing='整月' AND dateadd(month, datediff(month, 0, YW_BanLiRiQi)+YW_QiXian, 0)>GETDATE()) 
OR (YW_JiFeiLeiXing='按日' AND dateadd(month,YW_QiXian,YW_BanLiRiQi)>GETDATE())) AND YW_BanLiRiQi<GETDATE()
AND YW_ID IN (SELECT TOP 1 YW_ID FROM T_YeWu WHERE A.YW_Target=YW_Target ORDER BY YW_BanLiRiQi DESC)
) AS B)) AS C",
                    new SqlParameter("@time", time)));
                lblGongYuTGaiKuang.Text = "公寓住宿宿舍共计" + countRooms + "间，已入网宿舍" + countNetRooms + "间，入网率" + Math.Round((decimal)countNetRooms / countRooms * 100, 2) + "%，未入网宿舍" + (countRooms - countNetRooms) + "间，其中未入网毕业生宿舍占" + Math.Round((decimal)countNoNetBiYeShengRooms / (countRooms - countNetRooms) * 100, 2) + "%。";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "出现一个错误");
            }
        }

        private void btnDayin1_Click(object sender, EventArgs e)
        {
            PrintDGV.Print_DataGridView(this.dataGridView1);

            //System.Data.DataTable dt = new System.Data.DataTable();
            //DataRow dr;
            ////设置列表头
            //foreach (DataGridViewColumn headerCell in dataGridView1.Columns)
            //{
            //    dt.Columns.Add(headerCell.HeaderText);
            //}
            //foreach (DataGridViewRow item in dataGridView1.Rows)
            //{
            //    dr = dt.NewRow();
            //    for (int i = 0; i < dt.Columns.Count; i++)
            //    {
            //        dr[i] = item.Cells[i].Value.ToString();

            //    }
            //    dt.Rows.Add(dr);
            //}
            //DataSet dy= new DataSet();
            //dy.Tables.Add(dt);
            //MyDLL.TakeOver(dy);
        }

        private void btnWeiruwangxiangqing_Click(object sender, EventArgs e)
        {
            Weiruwangsushexiangqing winWrwssxq = new Weiruwangsushexiangqing();
            winWrwssxq.Show();
        }

        private void btnTongJi2_Click(object sender, EventArgs e)
        {

        }

        private void btnDayin2_Click(object sender, EventArgs e)
        {

        }

        private void dtpJieZhi1_ValueChanged(object sender, EventArgs e)
        {
            if (dtpJieZhi1.Value.Date == DateTime.Now.Date)
            {
                btnWeiruwangxiangqing.Enabled = true;
            }
            else
            {
                btnWeiruwangxiangqing.Enabled = false;
            }
        }
    }
}
