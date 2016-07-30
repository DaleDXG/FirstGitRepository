using Allen.Page;
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
    public partial class Chaxun : Form
    {
        public Chaxun()
        {
            InitializeComponent();
        }

        private void Chaxun_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView2.AutoGenerateColumns = false;
            dataGridView3.AutoGenerateColumns = false;
            //'宿舍楼名称'
            try
            {
                cbGongYuMingCheng.DataSource = SqlHelper.ExecuteDataTable("SELECT D_Value FROM T_Dic WHERE D_Name='宿舍楼名称'");
            }
            catch (Exception ex)
            {
                MessageBox.Show("请检查您的数据库连接、网络是否正常。", "出现一个错误");
                return;
            }
            cbGongYuMingCheng.DisplayMember = "D_Value";
            cbGongYuMingCheng.ValueMember = "D_Value";
            cbGongYuMingCheng.SelectedIndex = -1;
        }

        /// <summary>
        /// 点击查询按钮，根据条件得到学生信息，填入dataGridView1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChaXun_Click(object sender, EventArgs e)
        {
            DataTable students;

            #region 拼串检索出学生信息
            if (tbZhangHao.Text.Trim() == String.Empty && tbShenFenZhengHao.Text.Trim() == String.Empty)
            {
                string xingMing = tbXingMing.Text.Trim();
                string xueHao = tbXueHao.Text.Trim();
                //string shenFenZhengHao = tbShenFenZhengHao.Text.Trim();
                //string dianHua = tbDianHua.Text.Trim();
                string gongYuMingCheng = cbGongYuMingCheng.Text;
                string suSheHao = tbSuSheHao.Text.Trim();
                string zhangHao = tbZhangHao.Text.Trim();

                string[] strParams = new string[4];
                strParams[0] = xingMing;
                strParams[1] = xueHao;
                //strParams[2] = shenFenZhengHao;
                //strParams[3] = dianHua;
                strParams[2] = gongYuMingCheng;
                strParams[3] = suSheHao;

                bool[] paramFlag = new bool[4];
                for (int i = 0; i < paramFlag.Length; i++)
                {
                    paramFlag[i] = false;
                }
                int iParamNum = 0;
                for (int i = 0; i < strParams.Length; i++)
                {
                    if (strParams[i] != String.Empty)
                    {
                        paramFlag[i] = true;
                        iParamNum++;
                    }
                }
                SqlParameter[] chaXunParameters = new SqlParameter[iParamNum];

                string sql = "SELECT * FROM T_Student WHERE";
                int iParamNumNow = 0;
                if (paramFlag[0])
                {
                    sql += " Stu_XingMing = @xingMing AND ";
                    chaXunParameters[iParamNumNow] = new SqlParameter("@xingMing", xingMing);
                    iParamNumNow++;
                }
                if (paramFlag[1])
                {
                    sql += " Stu_XueHao = @xueHao AND ";
                    chaXunParameters[iParamNumNow] = new SqlParameter("@xueHao", xueHao);
                    iParamNumNow++;
                }
                //if (paramFlag[2])
                //{
                //    sql += " Stu_ShenFenZhengHao = @shenFenZhengHao AND ";
                //    chaXunParameters[iParamNumNow] = new SqlParameter("@shenFenZhengHao", shenFenZhengHao);
                //    iParamNumNow++;
                //}
                //if (paramFlag[3])
                //{
                //    sql += " Stu_DianHua = @dianHua AND ";
                //    chaXunParameters[iParamNumNow] = new SqlParameter("@dianHua", dianHua);
                //    iParamNumNow++;
                //}
                if (paramFlag[2])
                {
                    sql += " Stu_GongYuMingCheng = @gongYuMingCheng AND ";
                    chaXunParameters[iParamNumNow] = new SqlParameter("@gongYuMingCheng", gongYuMingCheng);
                    iParamNumNow++;
                }
                if (paramFlag[3])
                {
                    sql += " Stu_SuSheHao = @suSheHao AND ";
                    chaXunParameters[iParamNumNow] = new SqlParameter("@suSheHao", suSheHao);
                    iParamNumNow++;
                }
                sql = sql.Substring(0, (sql.Length - 5));
                students = SqlHelper.ExecuteDataTable(sql, chaXunParameters);
            }
            else
            {
                string zhangHao = tbZhangHao.Text.Trim();
                string shenFenZhengHao = tbShenFenZhengHao.Text.Trim();
                string dianHua = tbDianHua.Text.Trim();
                string sql = "SELECT * FROM T_Student WHERE Stu_XueHao IN (SELECT YW_XueHao FROM T_YeWu WHERE";// YW_ZhangHao=@zhangHao)
                int paramNum = 0;
                if(zhangHao != String.Empty) paramNum++;
                if(shenFenZhengHao != String.Empty) paramNum++;
                if(dianHua != String.Empty) paramNum++;
                SqlParameter[] parameters = new SqlParameter[paramNum];
                paramNum = 0;
                if (zhangHao != String.Empty)
                {
                    sql += " YW_ZhangHao=@zhangHao AND ";
                    parameters[paramNum] = new SqlParameter("@zhangHao", zhangHao);
                    paramNum++;
                }
                if (shenFenZhengHao != String.Empty)
                {
                    sql += " YW_ShenFenZhengHao=@shenFenZhengHao AND ";
                    parameters[paramNum] = new SqlParameter("@shenFenZhengHao", shenFenZhengHao);
                    paramNum++;
                }
                if (dianHua != String.Empty)
                {
                    sql += " YW_DianHua=@dianHua AND ";
                    parameters[paramNum] = new SqlParameter("@dianHua", dianHua);
                    paramNum++;
                }
                sql = sql.Substring(0, (sql.Length - 5));
                sql += ")";
                students = SqlHelper.ExecuteDataTable(sql, parameters);
            }

            #endregion

            //将得到的学生信息students装载到dataGridView1
            dataGridView1.DataSource = students;
            //for (int i = 0; i < students.Rows.Count; i++)
            //{
            //    int rowNum = dataGridView1.Rows.Add();
            //    dataGridView1.Rows[rowNum].Cells["dangAnBianHao"].Value = (string)students.Rows[i]["Stu_DangAnBianHao"];
            //    dataGridView1.Rows[rowNum].Cells["xueHao"].Value = (string)students.Rows[i]["Stu_XueHao"];
            //    dataGridView1.Rows[rowNum].Cells["xingMing"].Value = (string)students.Rows[i]["Stu_XingMing"];
            //    dataGridView1.Rows[rowNum].Cells["xingBie"].Value = (string)students.Rows[i]["Stu_XingBie"];
            //    dataGridView1.Rows[rowNum].Cells["gongYuMingCheng"].Value = (string)students.Rows[i]["Stu_GongYuMingCheng"];
            //    dataGridView1.Rows[rowNum].Cells["suSheHao"].Value = (string)students.Rows[i]["Stu_SuSheHao"];
            //    dataGridView1.Rows[rowNum].Cells["chuangHao"].Value = (string)students.Rows[i]["Stu_ChuangHao"];
            //    dataGridView1.Rows[rowNum].Cells["fangJianLeiXing"].Value = (string)students.Rows[i]["Stu_FangJianLeiXing"];
            //    dataGridView1.Rows[rowNum].Cells["zhuanYe"].Value = (string)students.Rows[i]["Stu_ZhuanYe"];
            //    dataGridView1.Rows[rowNum].Cells["xueYuan"].Value = (string)students.Rows[i]["Stu_XueYuan"];
            //    dataGridView1.Rows[rowNum].Cells["nianJi"].Value = (string)students.Rows[i]["Stu_NianJi"];
            //    dataGridView1.Rows[rowNum].Cells["xueLi"].Value = (string)students.Rows[i]["Stu_XueLi"];
            //    dataGridView1.Rows[rowNum].Cells["xueZhi"].Value = (string)students.Rows[i]["Stu_XueZhi"];
            //    dataGridView1.Rows[rowNum].Cells["biYeShiJian"].Value = (string)students.Rows[i]["Stu_BiYeShiJian"];
            //    //dataGridView1.Rows[rowNum].Cells["shenFenZhengHao"].Value = (string)students.Rows[i]["Stu_ShenFenZhengHao"];
            //    //dataGridView1.Rows[rowNum].Cells["dianHua"].Value = (string)students.Rows[i]["Stu_DianHua"];
            //}
        }

        /// <summary>
        /// 选中一条学生信息，得到该学生的业务信息，填入dataGridView2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
            string xueHao = dataGridView1.SelectedRows[0].Cells["xueHao"].Value.ToString();
            //Modified on 2016/1/14
            DataTable dtYeWu = SqlHelper.ExecuteDataTable("SELECT * FROM T_YeWu WHERE YW_XueHao=@xueHao"// AND YW_MarkJiLu=1"
                , new SqlParameter("@xueHao", xueHao));

            dataGridView2.DataSource = dtYeWu;
            //for (int i = 0; i < dtYeWu.Rows.Count; i++)
            //{
            //    int rowNum = dataGridView2.Rows.Add();
            //    dataGridView2.Rows[rowNum].Cells["ziFeiMing"].Value = (string)dtYeWu.Rows[i]["YW_ZiFeiMing"];
            //    dataGridView2.Rows[rowNum].Cells["yunYingShang"].Value = (string)dtYeWu.Rows[i]["YW_YunYingShang"];
            //    dataGridView2.Rows[rowNum].Cells["zhangHao"].Value = (string)dtYeWu.Rows[i]["YW_ZhangHao"];
            //    dataGridView2.Rows[rowNum].Cells["yeWuLeiXing"].Value = (string)dtYeWu.Rows[i]["YW_YeWuLeiXing"];
            //    dataGridView2.Rows[rowNum].Cells["ziFei"].Value = (string)dtYeWu.Rows[i]["YW_ZiFei"];
            //    dataGridView2.Rows[rowNum].Cells["daiKuan"].Value = (string)dtYeWu.Rows[i]["YW_DaiKuan"];
            //    dataGridView2.Rows[rowNum].Cells["banLiRiQi"].Value = (string)dtYeWu.Rows[i]["YW_BanLiRiQi"];
            //    dataGridView2.Rows[rowNum].Cells["qiXian"].Value = (string)dtYeWu.Rows[i]["YW_QiXian"];
            //    dataGridView2.Rows[rowNum].Cells["jiFeiLeiXing"].Value = (string)dtYeWu.Rows[i]["YW_JiFeiLeiXing"];
            //    dataGridView2.Rows[rowNum].Cells["shouHou"].Value = (string)dtYeWu.Rows[i]["YW_ShouHou"];
            //}
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0)
            {
                return;
            }
            string zhangHao = dataGridView2.SelectedRows[0].Cells["zhangHao"].Value.ToString();
            DataTable dtGuZhang = SqlHelper.ExecuteDataTable("SELECT * FROM T_GuZhang WHERE GZ_YWID IN (SELECT YW_ID FROM T_YeWu WHERE YW_ZhangHao=@zhangHao)"
                , new SqlParameter("@zhangHao", zhangHao));

            dataGridView3.DataSource = dtGuZhang;
            //for (int i = 0; i < dtGuZhang.Rows.Count; i++)
            //{
            //    int rowNum = dataGridView3.Rows.Add();
            //    dataGridView3.Rows[rowNum].Cells["mingCheng"].Value = (string)dtGuZhang.Rows[i]["GZ_MingCheng"];
            //    dataGridView3.Rows[rowNum].Cells["miaoShu"].Value = (string)dtGuZhang.Rows[i]["GZ_MiaoShu"];
            //    dataGridView3.Rows[rowNum].Cells["shiJian"].Value = (string)dtGuZhang.Rows[i]["GZ_ShiJian"];
            //    dataGridView3.Rows[rowNum].Cells["flag"].Value = (string)dtGuZhang.Rows[i]["GZ_Flag"];
            //}
        }

        #region 增删改按钮
        private void btnXSAdd_Click(object sender, EventArgs e)//add student information
        {
            Xueshengxinxi xsAdd = new Xueshengxinxi();
            xsAdd.ShowDialog();
            btnChaXun_Click(this, new EventArgs());
        }

        private void btnXSChange_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
            Xueshengxinxi xsChange = new Xueshengxinxi(dataGridView1.SelectedRows[0]);
            xsChange.ShowDialog();
            btnChaXun_Click(this, new EventArgs());
        }

        private void btnXSDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
            try
            {
                SqlHelper.ExecuteNonQuery("DELETE FROM T_Student WHERE Stu_ID=" + dataGridView1.SelectedRows[0].Cells["S_ID"].Value.ToString());
                MessageBox.Show("成功删除此学生信息", "成功");
                btnChaXun_Click(this, new EventArgs());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "出现一个错误");
            }
        }

        private void btnYWAdd_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
            YeWuXinXi ywAdd = new YeWuXinXi(dataGridView1.SelectedRows[0], dataGridView2.SelectedRows.Count == 0 ? null : dataGridView2.SelectedRows[0], true);
            ywAdd.ShowDialog();
            dataGridView1_SelectionChanged(this, new EventArgs());
        }

        private void btnYWChange_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0)
            {
                return;
            }
            YeWuXinXi ywChange = new YeWuXinXi(dataGridView1.SelectedRows[0], dataGridView2.SelectedRows[0], false);
            ywChange.ShowDialog();
            dataGridView1_SelectionChanged(this, new EventArgs());
        }

        private void btnYWDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0)
            {
                return;
            }
            try
            {
                SqlHelper.ExecuteNonQuery("DELETE FROM T_YeWu WHERE YW_ID=" + dataGridView2.SelectedRows[0].Cells["YW_ID"].Value.ToString());
                MessageBox.Show("成功删除此业务信息", "成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "出现一个错误");
            }
        }

        private void btnSHAdd_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0)
            {
                return;
            }
            GuZhangXinXi gzAdd = new GuZhangXinXi(Convert.ToInt64(dataGridView2.SelectedRows[0].Cells["YW_ID"].Value.ToString()));
            gzAdd.ShowDialog();
            dataGridView2_SelectionChanged(this, new EventArgs());
        }

        private void btnSHChange_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count == 0)
            {
                return;
            }
            GuZhangXinXi gzChange = new GuZhangXinXi(Convert.ToInt64(dataGridView2.SelectedRows[0].Cells["YW_ID"].Value.ToString()), dataGridView3.SelectedRows[0]);
            gzChange.ShowDialog();
            dataGridView2_SelectionChanged(this, new EventArgs());
        }

        private void btnSHDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count == 0)
            {
                return;
            }
            try
            {
                SqlHelper.ExecuteNonQuery("DELETE FROM T_GuZhang WHERE GZ_ID=" + dataGridView3.SelectedRows[0].Cells["GZ_ID"].Value.ToString());
                dataGridView2_SelectionChanged(this, new EventArgs());
                MessageBox.Show("成功删除此故障信息", "成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "出现一个错误");
            }
        }
        #endregion

        private void studentInfoChange(object sender, EventArgs e)
        {
            //if (String.IsNullOrEmpty(((TextBox)sender).Text))
            //{
            //    tbShenFenZhengHao.Enabled = true;
            //    tbDianHua.Enabled = true;
            //    tbZhangHao.Enabled = true;
            //}
            //else
            //{
            //    tbShenFenZhengHao.Enabled = false;
            //    tbDianHua.Enabled = false;
            //    tbZhangHao.Enabled = false;
            //}
            if(tbXingMing.Text != String.Empty ||tbXueHao.Text != String.Empty
                || cbGongYuMingCheng.Text != String.Empty || tbSuSheHao.Text != String.Empty)
            {
                tbShenFenZhengHao.Enabled = false;
                tbDianHua.Enabled = false;
                tbZhangHao.Enabled = false;
            }
            else
            {
                tbShenFenZhengHao.Enabled = true;
                tbDianHua.Enabled = true;
                tbZhangHao.Enabled = true;
            }
        }

        private void yewuInfoChange(object sender, EventArgs e)
        {
            //if (String.IsNullOrEmpty(((TextBox)sender).Text))
            //{
            //    tbXingMing.Enabled = true;
            //    tbXueHao.Enabled = true;
            //    cbGongYuMingCheng.Enabled = true;
            //    tbSuSheHao.Enabled = true;
            //}
            //else
            //{
            //    tbXingMing.Enabled = false;
            //    tbXueHao.Enabled = false;
            //    cbGongYuMingCheng.Enabled = false;
            //    tbSuSheHao.Enabled = false;
            //}
            if (tbShenFenZhengHao.Text != String.Empty || tbDianHua.Text != String.Empty
                || tbZhangHao.Text != String.Empty)
            {
                tbXingMing.Enabled = false;
                tbXueHao.Enabled = false;
                cbGongYuMingCheng.Enabled = false;
                tbSuSheHao.Enabled = false;
            }
            else
            {
                tbXingMing.Enabled = true;
                tbXueHao.Enabled = true;
                cbGongYuMingCheng.Enabled = true;
                tbSuSheHao.Enabled = true;
            }
        }

        #region 分页函数
        /*
        //链接字符串
        private string strConn = SqlHelper.connstr;
        private string strProcedure = "PageTest ";
        //总记录数
        public int RecordCount1 = 0;
        public int RecordCount2 = 0;
        public int RecordCount3 = 0;

        /// <summary>
        /// 绑定第Index页的数据
        /// </summary>
        /// <param name="Index"></param>
        private void BindDataWithPage(AllenPage allenPage, int Index)
        {
            allenPage.PageIndex = Index;
            //winFormPager1.PageSize = 10;
            DataTable dt = GetData(allenPage, strConn, strProcedure, Index, allenPage.PageSize);

            if (allenPage == allenPage1)
            {
                dataGridView1.DataSource = dt;
                //获取并设置总记录数
                allenPage1.RecordCount = RecordCount1;
            }
            if (allenPage == allenPage2)
            {
                dataGridView2.DataSource = dt;
                //获取并设置总记录数
                allenPage2.RecordCount = RecordCount2;
            }
            if (allenPage == allenPage3)
            {
                dataGridView3.DataSource = dt;
                //获取并设置总记录数
                allenPage3.RecordCount = RecordCount3;
            }
        }


        /// <summary>
        /// 获取数据源
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="strProcedure"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        private DataTable GetData(AllenPage allenPage, string conn, string strProcedure, int pageIndex, int pageSize)
        {

            using (SqlConnection connection = new SqlConnection(conn))
            {
                SqlCommand command = new SqlCommand(strProcedure, connection);
                command.CommandType = CommandType.StoredProcedure;//采用存储过程
                //存储过程参数
                command.Parameters.Add("@Table", SqlDbType.NVarChar, 1000).Value = "Han";
                command.Parameters.Add("@TIndex", SqlDbType.NVarChar, 100).Value = "ID";
                command.Parameters.Add("@Column", SqlDbType.NVarChar, 2000).Value = "*";
                if (allenPage == allenPage1)
                {
                    command.Parameters.Add("@Sql", SqlDbType.NVarChar, 3000).Value = " [state]=1 ";
                }
                else if (allenPage == allenPage2)
                {
                    command.Parameters.Add("@Sql", SqlDbType.NVarChar, 3000).Value = " [state]=2 ";
                }
                command.Parameters.Add("@PageIndex", SqlDbType.Int, 8).Value = pageIndex.ToString();
                command.Parameters.Add("@PageSize", SqlDbType.Int, 8).Value = pageSize.ToString();
                command.Parameters.Add("@Sort", SqlDbType.NVarChar, 200).Value = " ID desc";
                //打开连接
                if (connection.State != ConnectionState.Open) { connection.Open(); }
                try
                {
                    //填充数据
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    if (allenPage == allenPage1)
                    {
                        //获取总记录数
                        RecordCount1 = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                    }
                    else if (allenPage == allenPage2)
                    {
                        //获取总记录数
                        RecordCount2 = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                    }
                    //返回数据集
                    return ds.Tables[0];

                }
                catch (SqlException err)
                {
                    MessageBox.Show(err.Message, "提示");
                    return null; ;
                }
                finally
                {
                    connection.Close();
                }
            }
        }*/
        #endregion
    }
}
