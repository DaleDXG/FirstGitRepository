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
    public partial class Weiruwangsushexiangqing : Form
    {

        public Weiruwangsushexiangqing()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Weiruwangsushexiangqing_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            //'宿舍楼名称'
            DataTable dtGongYuMingCheng;
            try
            {
                dtGongYuMingCheng = SqlHelper.ExecuteDataTable("SELECT D_Value FROM T_Dic WHERE D_Name='宿舍楼名称'");
                DataRow drSelectionOfAll = dtGongYuMingCheng.NewRow();
                drSelectionOfAll["D_Value"] = "全部";
                dtGongYuMingCheng.Rows.InsertAt(drSelectionOfAll, 0);
                cbGongYuMingCheng.DataSource = dtGongYuMingCheng;
            }
            catch (Exception ex)
            {
                MessageBox.Show("请检查您的数据库连接、网络是否正常。", "出现一个错误");
                return;
            }
            cbGongYuMingCheng.DisplayMember = "D_Value";
            cbGongYuMingCheng.ValueMember = "D_Value";
            cbGongYuMingCheng.SelectedIndex = 0;
        }

        private void cbGongYuLouMingCheng_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbGongYuMingCheng.Text == String.Empty)
            {
                return;
            }
            else
            {
                try
                {
                    //string sql = "SELECT * FROM T_Student WHERE Stu_SuSheHao NOT IN(SELECT Stu_SuSheHao FROM T_Student WHERE Stu_XueHao IN (SELECT DISTINCT YW_XueHao FROM T_YeWu))";
                    //string sql = "SELECT * FROM T_Student AS A, (SELECT DISTINCT Stu_GongYuMingCheng,Stu_SuSheHao FROM T_Student EXCEPT SELECT DISTINCT B.Stu_GongYuMingCheng,B.Stu_SuSheHao FROM T_Student AS B, T_YeWu AS C WHERE B.Stu_XueHao=C.YW_XueHao) AS B WHERE A.Stu_GongYuMingCheng=B.Stu_GongYuMingCheng AND A.Stu_SuSheHao=B.Stu_SuSheHao";
                    string sql = @"
SELECT D.* FROM T_Student AS D, (
SELECT DISTINCT Stu_GongYuMingCheng,Stu_SuSheHao FROM T_Student EXCEPT (
SELECT DISTINCT YW_LouMing,YW_SuSheHao FROM (
SELECT * FROM T_YeWu 
WHERE (YW_YeWuLeiXing='新装' OR YW_YeWuLeiXing='续费') AND 
((YW_JiFeiLeiXing='整月' AND dateadd(month, datediff(month, 0, YW_BanLiRiQi)+YW_QiXian, 0)>GETDATE()) 
OR (YW_JiFeiLeiXing='按日' AND dateadd(month,YW_QiXian,YW_BanLiRiQi)>GETDATE()))
AND YW_ID NOT IN (SELECT DISTINCT YW_Target FROM T_YeWu WHERE YW_YeWuLeiXing='退网' OR YW_YeWuLeiXing='移机')
UNION
SELECT * FROM T_YeWu AS A WHERE YW_YeWuLeiXing='移机' 
AND YW_Target IN (SELECT DISTINCT YW_ID FROM T_YeWu WHERE (YW_JiFeiLeiXing='整月' AND dateadd(month, datediff(month, 0, YW_BanLiRiQi)+YW_QiXian, 0)>GETDATE()) 
OR (YW_JiFeiLeiXing='按日' AND dateadd(month,YW_QiXian,YW_BanLiRiQi)>GETDATE())) 
AND YW_ID IN (SELECT TOP 1 YW_ID FROM T_YeWu WHERE A.YW_Target=YW_Target ORDER BY YW_BanLiRiQi DESC)
) AS B)) AS C
WHERE D.Stu_GongYuMingCheng=C.Stu_GongYuMingCheng AND D.Stu_SuSheHao=C.Stu_SuSheHao";
                    if (cbGongYuMingCheng.SelectedIndex != 0)
                        sql += " AND D.Stu_GongYuMingCheng='" + cbGongYuMingCheng.Text + "'";
                    DataTable dtStudent = SqlHelper.ExecuteDataTable(sql);
                    dataGridView1.DataSource = dtStudent;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "出现一个错误");
                }
            }
        }

        private void cbXingBie_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbXingBie.Text == String.Empty)
            {
                return;
            }
            else
            {
                try
                {
                    dataGridView1.DataSource = SqlHelper.ExecuteDataTable("SELECT * FROM T_Student AS A, (SELECT DISTINCT Stu_GongYuMingCheng,Stu_SuSheHao FROM T_Student EXCEPT SELECT DISTINCT B.Stu_GongYuMingCheng,B.Stu_SuSheHao FROM T_Student AS B, T_YeWu AS C WHERE B.Stu_XueHao=C.YW_XueHao) AS B WHERE A.Stu_GongYuMingCheng=B.Stu_GongYuMingCheng AND A.Stu_SuSheHao=B.Stu_SuSheHao AND Stu_XingBie='"+cbXingBie.Text+"'");
                    //"SELECT * FROM T_Student WHERE Stu_XingBie='"+cbXingBie.Text+"'"
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "出现一个错误");
                }
            }
        }
    }
}
