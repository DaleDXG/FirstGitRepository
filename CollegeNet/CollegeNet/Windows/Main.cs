using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollegeNet
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            tsbtnYvjing_Click(this, new EventArgs());
        }

        #region Mdi父子窗体
        private bool ShowChildrenForm(string name)
        {
            int i;
            for (i = 0; i < this.MdiChildren.Length; i++)
            {
                if (this.MdiChildren[i].Text == name)
                {
                    this.MdiChildren[i].Activate();
                    this.MdiChildren[i].WindowState = FormWindowState.Maximized;
                    //this.MdiChildren[i].Close();
                    return true;
                }
            }
            return false;
        }

        //private void toolStripButton1_Click(object sender, EventArgs e)
        //{
        //    string childrenFormText = "流通系统";
        //    if (!ShowChildrenForm(childrenFormText))
        //    {
        //        liutong lt = new liutong();
        //        lt.MdiParent = this;
        //        lt.Show();
        //    }
        //}

        private void stbtnLuru_Click(object sender, EventArgs e)
        {
            string childrenFormText = "录入";
            if (!ShowChildrenForm(childrenFormText))
            {
                Chaxun cx = new Chaxun();
                cx.MdiParent = this;
                cx.Text = "录入";

                if (LoginUser.role == "管理员")
                {

                }
                else if (LoginUser.role == "录入员")
                {
                    cx.Controls["groupBox1"].Controls["btnXSChange"].Visible = false;
                    cx.Controls["groupBox1"].Controls["btnXSDelete"].Visible = false;
                    cx.Controls["groupBox2"].Controls["btnYWChange"].Visible = false;
                    cx.Controls["groupBox2"].Controls["btnYWDelete"].Visible = false;
                    cx.Controls["groupBox3"].Controls["btnSHChange"].Visible = false;
                    cx.Controls["groupBox3"].Controls["btnSHDelete"].Visible = false;
                }

                cx.Show();
            }
        }

        private void tsbtnChaxun_Click(object sender, EventArgs e)
        {
            string childrenFormText = "查询";
            if (!ShowChildrenForm(childrenFormText))
            {
                Chaxun cx = new Chaxun();
                cx.MdiParent = this;
                cx.Controls["groupBox1"].Controls["btnXSAdd"].Visible = false;
                cx.Controls["groupBox1"].Controls["btnXSChange"].Visible = false;
                cx.Controls["groupBox1"].Controls["btnXSDelete"].Visible = false;
                cx.Controls["groupBox2"].Controls["btnYWAdd"].Visible = false;
                cx.Controls["groupBox2"].Controls["btnYWChange"].Visible = false;
                cx.Controls["groupBox2"].Controls["btnYWDelete"].Visible = false;
                cx.Controls["groupBox3"].Controls["btnSHAdd"].Visible = false;
                cx.Controls["groupBox3"].Controls["btnSHChange"].Visible = false;
                cx.Controls["groupBox3"].Controls["btnSHDelete"].Visible = false;
                cx.Show();
            }
        }

        private void tsbtnYvjing_Click(object sender, EventArgs e)
        {
            string childrenFormText = "预警";
            if (!ShowChildrenForm(childrenFormText))
            {
                Yvjing yj = new Yvjing();
                yj.MdiParent = this;
                yj.Show();
            }
        }

        private void 概况数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string childrenFormText = "概况统计";
            if (!ShowChildrenForm(childrenFormText))
            {
                Gaikuangshuju tj = new Gaikuangshuju();
                tj.MdiParent = this;
                tj.Show();
            }
        }

        private void 按宿舍统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string childrenFormText = "按宿舍统计";
            if (!ShowChildrenForm(childrenFormText))
            {
                Ansushetongji tj = new Ansushetongji();
                tj.MdiParent = this;
                tj.Show();
            }
        }

        private void 按运营商统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string childrenFormText = "按运营商统计";
            if (!ShowChildrenForm(childrenFormText))
            {
                Anyunyingshangtongji tj = new Anyunyingshangtongji();
                tj.MdiParent = this;
                tj.Show();
            }
        }

        private void 按学生统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string childrenFormText = "按学生统计";
            if (!ShowChildrenForm(childrenFormText))
            {
                Anxueshengtongji tj = new Anxueshengtongji();
                tj.MdiParent = this;
                tj.Show();
            }
        }

        private void tsbtnQita_Click(object sender, EventArgs e)
        {
            string childrenFormText = "其他";
            if (!ShowChildrenForm(childrenFormText))
            {
                Qita qt = new Qita();
                qt.MdiParent = this;
                qt.Show();
            }
        }
        private void 日结统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string childrenFormText = "按日汇总";
            if (!ShowChildrenForm(childrenFormText))
            {
                Qita qt = new Qita();
                qt.MdiParent = this;
                qt.Show();
            }
        }

        private void 月结统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string childrenFormText = "月结统计";
            if (!ShowChildrenForm(childrenFormText))
            {
                Qita qt = new Qita();
                qt.MdiParent = this;
                qt.Show();
            }
        }
        #endregion

        #region 导入
        DataTable dt = new DataTable();
        string connString = SqlHelper.connstr;
        SqlConnection conn;
        DataRow drStuNow;
        long rowSequence = -1;

        bool isInsertStudent = true;

        private void tsmDaoruFromExcel_Click(object sender, EventArgs e)//从Excel导入按钮
        {
            if (askForBeiFen())
            {
                isInsertStudent = true;

                System.Windows.Forms.OpenFileDialog fd = new OpenFileDialog();
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    string fileName = fd.FileName;
                    bind(fileName);
                }
            }
        }
        private void bind(string fileName)
        {
            //Microsoft.Jet.OLEDB.4.0
            string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                 "Data Source=" + fileName + ";" +
                 "Extended Properties='Excel 8.0; HDR=Yes; IMEX=1'";
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT *  FROM [Sheet1$]", strConn);//SELECT *  FROM [student$]
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds);
                dt = ds.Tables[0];
                Insert();
                //this.dataGridView1.DataSource = dt;
            }
            catch (Exception err)
            {
                MessageBox.Show("操作失败！" + err.ToString());
            }
        }

        //将Datagridview1的记录插入到数据库    
        private void Insert()
        {
            conn = new SqlConnection(connString);
            conn.Open();
            if (dt.Rows.Count > 0)
            {
                if (isInsertStudent)
                {
                    //清除原有数据
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "DELETE FROM T_Student";
                        cmd.ExecuteNonQuery();
                    }

                    //清除不需要记录的业务
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "DELETE FROM T_YeWu WHERE YW_XueHao NOT IN (SELECT DISTINCT YW_XueHao FROM T_YeWu WHERE dateadd(month,YW_QiXian,YW_BanLiRiQi)>dateadd(month,-6,getdate()))";
                        //SELECT * FROM T_YeWu WHERE YW_XueHao NOT IN (SELECT DISTINCT YW_XueHao FROM T_YeWu WHERE dateadd(month,YW_QiXian,YW_BanLiRiQi)>dateadd(month,-6,getdate()));
                        cmd.ExecuteNonQuery();
                    }

                    SqlHelper.ExecuteProcedure("[dbo].[Proc_Student_getBuildingNameToDic]", null);
                    ////-自动整理宿舍楼名称
                    //using (SqlCommand cmd = conn.CreateCommand())
                    //{
                    //    //--删除原有的宿舍楼名称
                    //    cmd.CommandText = "DELETE FROM T_Dic WHERE D_Name='宿舍楼名称'";
                    //    cmd.ExecuteNonQuery();
                    //}
                    ////--整理新的宿舍楼名称
                    //DataTable suSheLouMingCheng = SqlHelper.ExecuteDataTable("SELECT DISTINCT Stu_GongYuMingCheng FROM T_Student");
                    //for (int i = 0; i < suSheLouMingCheng.Rows.Count; i++)
                    //{
                    //    if (suSheLouMingCheng.Rows[i][0].ToString() != String.Empty)
                    //    {
                    //        using (SqlCommand cmd = conn.CreateCommand())
                    //        {
                    //            cmd.CommandText = "INSERT INTO T_Dic(D_Name,D_Value) VALUES('宿舍楼名称','" + suSheLouMingCheng.Rows[i][0].ToString() + "')";
                    //            cmd.ExecuteNonQuery();
                    //        }
                    //    }
                    //}
                }

                DataRow dr = null;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dr = dt.Rows[i];
                    insertToSql(dr);
                }

                //conn.Close();
                MessageBox.Show("导入成功！");
            }
            else
            {
                MessageBox.Show("没有数据！");
            }
            conn.Close();
        }
        private void insertToSql(DataRow dr)
        {
            //excel表中的列名和数据库中的列名一定要对应  
            //string name = dr["StudentName"].ToString();
            //string sex = dr["Sex"].ToString();
            //string no = dr["StudentIDNO"].ToString();
            //string major = dr["Major"].ToString();
            //string sql = "insert into student values('" + name + "','" + sex + "','" + no + "','" + major + "')";
            //SqlCommand cmd = new SqlCommand(sql, conn);
            //cmd.ExecuteNonQuery();

            using (SqlCommand cmd = conn.CreateCommand())
            {
                //excel表中的列名和数据库中的列名一定要对应
                //try
                //{
                if (dr["公寓名称"].ToString() != String.Empty)
                {
                    if (isInsertStudent)
                    {
                        //添加学生
                        string DangAnBianHao = dr["档案编号"].ToString();
                        string XueHao = dr["学号"].ToString();
                        string XingMing = dr["姓名"].ToString();
                        string XingBie = dr["性别"].ToString();
                        string GongYuMingCheng = dr["公寓名称"].ToString();
                        string SuSheHao = dr["宿舍号"].ToString();
                        string ChuangHao = dr["床号"].ToString();
                        string FangJianLeiXing = dr["房间类型"].ToString();
                        string ZhuanYe = dr["专业"].ToString();
                        string XueYuan = dr["学院"].ToString();
                        string NianJi = dr["年级"].ToString();
                        string XueLi = dr["学历"].ToString();
                        string XueZhi = dr["学制"].ToString();
                        string BiYeShiJian = dr["毕业时间"].ToString();
                        string sql = @"insert into T_Student(Stu_DangAnBianHao,Stu_XueHao,Stu_XingMing,Stu_XingBie,Stu_GongYuMingCheng,
Stu_SuSheHao,Stu_ChuangHao,Stu_FangJianLeiXing,Stu_ZhuanYe,Stu_XueYuan,Stu_NianJi,Stu_XueLi,Stu_XueZhi,Stu_BiYeShiJian
) values('" + DangAnBianHao + "','" + XueHao + "','" + XingMing
                            + "','" + XingBie + "','" + GongYuMingCheng + "','" + SuSheHao + "','" + ChuangHao + "','"
                            + FangJianLeiXing + "','" + ZhuanYe + "','" + XueYuan + "','" + NianJi + "','" + XueLi
                            + "','" + XueZhi + "','" + BiYeShiJian + "')";

                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();
                    }

                    //if (dr["业务类型"].ToString() != String.Empty && dr["业务类型"].ToString() != "0")
                    if (dr["业务类型"].ToString() == "新装" || dr["业务类型"].ToString() == "续费")//|| dr["业务类型"].ToString() == "移机" || dr["业务类型"].ToString() == "退网")
                    {
                        string sql = @"insert into T_YeWu(YW_XueHao,YW_XingMing,YW_ShenFenZhengHao,YW_DianHua,YW_ZiFeiMing,YW_YunYingShang,
YW_ZhangHao,YW_YeWuLeiXing,YW_ZiFei,YW_DaiKuan,YW_BanLiRiQi,YW_QiXian,YW_JiFeiLeiXing,YW_LouMing,YW_SuSheHao,YW_Flag,YW_Target) values(@xueHao,@xingMing,
@shenFenZhengHao,@dianHua,@ziFeiMing,@yunYingShang,@zhangHao,@yeWuLeiXing,@ziFei,@daiKuan,@banLiRiQi,@qiXian,@jiFeiLeiXing,@louMing,@suSheHao,@flag,@target);SELECT @@IDENTITY";
                        SqlParameter[] parameters = new SqlParameter[17];
                        parameters[0] = new SqlParameter("@xueHao", dr["学号"].ToString());
                        parameters[1] = new SqlParameter("@xingMing", dr["姓名"]);
                        parameters[2] = new SqlParameter("@shenFenZhengHao", dr["身份证号"].ToString());
                        parameters[3] = new SqlParameter("@dianHua", dr["电话"].ToString());
                        parameters[4] = new SqlParameter("@ziFeiMing", dr["运营商"].ToString() + dr["带宽"].ToString());
                        parameters[5] = new SqlParameter("@yunYingShang", dr["运营商"]);
                        parameters[6] = new SqlParameter("@zhangHao", dr["账号"].ToString());
                        parameters[7] = new SqlParameter("@yeWuLeiXing", dr["业务类型"]);
                        parameters[8] = new SqlParameter("@ziFei", dr["资费"]);
                        parameters[9] = new SqlParameter("@daiKuan", dr["带宽"].ToString());
                        parameters[10] = new SqlParameter("@banLiRiQi", dr["办理日期"]);
                        parameters[11] = new SqlParameter("@qiXian", dr["期限（月）"]);
                        parameters[12] = new SqlParameter("@jiFeiLeiXing", dr["计费类型"]);
                        parameters[13] = new SqlParameter("@louMing", dr["公寓名称"]);
                        parameters[14] = new SqlParameter("@suSheHao", dr["宿舍号"].ToString());
                        parameters[15] = new SqlParameter("@flag", 1);
                        if (dr["业务类型"].ToString() == "移机" || dr["业务类型"].ToString() == "退网")
                        {
                            parameters[16] = new SqlParameter("@target", rowSequence);
                        }
                        else
                        {
                            parameters[16] = new SqlParameter("@target", DBNull.Value);
                        }
                        rowSequence = Convert.ToInt64(SqlHelper.ExecuteScalar(sql, parameters));
                    }
                    drStuNow = dr;
                }
                else
                {
                    //if (dr["业务类型"].ToString() != String.Empty)
                    if (dr["业务类型"].ToString() == "新装" || dr["业务类型"].ToString() == "续费")//|| dr["业务类型"].ToString() == "移机" || dr["业务类型"].ToString() == "退网")
                    {
                        string sql = @"insert into T_YeWu(YW_XueHao,YW_XingMing,YW_ShenFenZhengHao,YW_DianHua,YW_ZiFeiMing,YW_YunYingShang,
YW_ZhangHao,YW_YeWuLeiXing,YW_ZiFei,YW_DaiKuan,YW_BanLiRiQi,YW_QiXian,YW_JiFeiLeiXing,YW_LouMing,YW_SuSheHao,YW_Flag,YW_Target) values(@xueHao,@xingMing,
@shenFenZhengHao,@dianHua,@ziFeiMing,@yunYingShang,@zhangHao,@yeWuLeiXing,@ziFei,@daiKuan,@banLiRiQi,@qiXian,@jiFeiLeiXing,@louMing,@suSheHao,@flag,@target);SELECT @@IDENTITY";
                        SqlParameter[] parameters = new SqlParameter[17];
                        parameters[0] = new SqlParameter("@xueHao", drStuNow["学号"].ToString());
                        parameters[1] = new SqlParameter("@xingMing", drStuNow["姓名"]);
                        parameters[2] = new SqlParameter("@shenFenZhengHao", dr["身份证号"].ToString());
                        parameters[3] = new SqlParameter("@dianHua", dr["电话"].ToString());//Convert.ToInt32(dr["电话"]).ToString();
                        parameters[4] = new SqlParameter("@ziFeiMing", dr["运营商"].ToString() + dr["带宽"].ToString());
                        parameters[5] = new SqlParameter("@yunYingShang", dr["运营商"]);
                        parameters[6] = new SqlParameter("@zhangHao", dr["账号"].ToString());
                        parameters[7] = new SqlParameter("@yeWuLeiXing", dr["业务类型"]);
                        parameters[8] = new SqlParameter("@ziFei", dr["资费"]);
                        parameters[9] = new SqlParameter("@daiKuan", dr["带宽"].ToString());
                        parameters[10] = new SqlParameter("@banLiRiQi", dr["办理日期"]);
                        parameters[11] = new SqlParameter("@qiXian", dr["期限（月）"]);
                        parameters[12] = new SqlParameter("@jiFeiLeiXing", dr["计费类型"]);
                        parameters[13] = new SqlParameter("@louMing", drStuNow["公寓名称"]);
                        parameters[14] = new SqlParameter("@suSheHao", drStuNow["宿舍号"].ToString());
                        parameters[15] = new SqlParameter("@flag", 1);
                        if (dr["业务类型"].ToString() == "移机" || dr["业务类型"].ToString() == "退网")
                        {
                            parameters[16] = new SqlParameter("@target", rowSequence);
                        }
                        else
                        {
                            parameters[16] = new SqlParameter("@target", DBNull.Value);
                        }
                        rowSequence = Convert.ToInt64(SqlHelper.ExecuteScalar(sql, parameters));
                    }
                }

                //添加已有的业务信息，以[办理日期]来判断
                //if (dr["办理日期"].ToString().Trim() != String.Empty)
                //{
                //    cmd.CommandText = "SELECT COUNT(*) FROM T_YeWu WHERE YW_XueHao='" + XueHao + "' AND YW_ZiFei="+dr["资费"].ToString()+" AND YW_BanLiRiQi";
                //}

                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.ToString() + "\n" + drStuNow["学号"].ToString() + "\n" + dr.ToString(), "出现一个错误");
                //}
            }
        }

        private void 从Excel文件导入业务信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (askForBeiFen())
            {
                isInsertStudent = false;

                System.Windows.Forms.OpenFileDialog fd = new OpenFileDialog();
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    string fileName = fd.FileName;
                    bind(fileName);
                }
            }
        }
        #endregion

        #region 导入2(无用）
        //private void tsmDaoruFromExcel_Click(object sender, EventArgs e)//从Excel导入按钮
        //{
        //    //测试，将excel中的student导入到sqlserver的db_test中，如果sql中的数据表不存在则创建        
        //    string connString = "server = (local); uid = sa; pwd = sa; database = db_test";
        //    System.Windows.Forms.OpenFileDialog fd = new OpenFileDialog();
        //    if (fd.ShowDialog() == DialogResult.OK)
        //    {
        //        TransferData(fd.FileName, "student", connString);
        //    }
        //}
        //public void TransferData(string excelFile, string sheetName, string connectionString)
        //{
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        //获取全部数据     
        //        string strConn = "Provider = Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + excelFile + ";" + "Extended Properties = Excel 8.0;";
        //        OleDbConnection conn = new OleDbConnection(strConn);
        //        conn.Open();
        //        string strExcel = "";
        //        OleDbDataAdapter myCommand = null;
        //        strExcel = string.Format("select * from [{0}$]", sheetName);
        //        myCommand = new OleDbDataAdapter(strExcel, strConn);
        //        myCommand.Fill(ds, sheetName);

        //        //如果目标表不存在则创建,excel文件的第一行为列标题,从第二行开始全部都是数据记录     
        //        string strSql = string.Format("if not exists(select * from sysobjects where name = '{0}') create table {0}(", sheetName);   //以sheetName为表名     

        //        foreach (System.Data.DataColumn c in ds.Tables[0].Columns)
        //        {
        //            strSql += string.Format("[{0}] varchar(255),", c.ColumnName);
        //        }
        //        strSql = strSql.Trim(',') + ")";

        //        using (System.Data.SqlClient.SqlConnection sqlconn = new System.Data.SqlClient.SqlConnection(connectionString))
        //        {
        //            sqlconn.Open();
        //            System.Data.SqlClient.SqlCommand command = sqlconn.CreateCommand();
        //            command.CommandText = strSql;
        //            command.ExecuteNonQuery();
        //            sqlconn.Close();
        //        }
        //        //用bcp导入数据        
        //        //excel文件中列的顺序必须和数据表的列顺序一致，因为数据导入时，是从excel文件的第二行数据开始，不管数据表的结构是什么样的，反正就是第一列的数据会插入到数据表的第一列字段中，第二列的数据插入到数据表的第二列字段中，以此类推，它本身不会去判断要插入的数据是对应数据表中哪一个字段的     
        //        using (System.Data.SqlClient.SqlBulkCopy bcp = new System.Data.SqlClient.SqlBulkCopy(connectionString))
        //        {
        //            bcp.SqlRowsCopied += new System.Data.SqlClient.SqlRowsCopiedEventHandler(bcp_SqlRowsCopied);
        //            bcp.BatchSize = 100;//每次传输的行数        
        //            bcp.NotifyAfter = 100;//进度提示的行数        
        //            bcp.DestinationTableName = sheetName;//目标表        
        //            bcp.WriteToServer(ds.Tables[0]);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show(ex.Message);
        //    }
        //}

        ////进度显示        
        //void bcp_SqlRowsCopied(object sender, System.Data.SqlClient.SqlRowsCopiedEventArgs e)
        //{
        //    this.Text = e.RowsCopied.ToString();
        //    this.Update();
        //}

        #endregion

        private void tsmBeifenSqlServer_Click(object sender, EventArgs e)
        {
            //System.Windows.Forms.OpenFileDialog fd = new OpenFileDialog();
            //if (fd.ShowDialog() == DialogResult.OK)
            //{
            //    string fileName = fd.FileName;
            //}
            string sql = "BACKUP DATABASE CollegeNet TO DISK='" + ConfigurationManager.AppSettings["backupLocation"].ToString() + "\\CollegeNet" + DateTime.Now.ToString("_yyyy_MM_dd_HH_mm_ss") + ".bak' With init";
            SqlHelper.ExecuteNonQuery(sql);
            MessageBox.Show("备份成功。", "提示");
        }

        private bool askForBeiFen()
        {
            DialogResult result = MessageBox.Show("导入前是否先进行备份？", "提示", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                tsmBeifenSqlServer_Click(this, new EventArgs());
                return true;
            }
            else if (result == DialogResult.No)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
