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
    public partial class ZiFeiXinXi : Form
    {
        private bool isAddNew = false;
        private DataGridViewRow ziFeiInformation = null;
        public ZiFeiXinXi()
        {
            isAddNew = true;
            InitializeComponent();
        }
        public ZiFeiXinXi(DataGridViewRow selectedRow)
        {
            ziFeiInformation = selectedRow;
            InitializeComponent();
            try
            {
                cobYunYingShang.Text = selectedRow.Cells["ZF_YunYingShang"].Value.ToString();
                tbZiFeiMing.Text = selectedRow.Cells["ZF_ZiFeiMing"].Value.ToString();
                tbZiFei.Text = selectedRow.Cells["ZF_ZiFei"].Value.ToString();
                tbZhuangJiFei.Text = selectedRow.Cells["ZF_ZhuangJiFei"].Value.ToString();
                cobDaiKuan.Text = selectedRow.Cells["ZF_DaiKuan"].Value.ToString();
                tbQiXian.Text = selectedRow.Cells["ZF_QiXian"].Value.ToString();
                cobJiFeiLeiXing.Text = selectedRow.Cells["ZF_JiFeiLeiXing"].Value.ToString();
                //switch(Convert.ToInt32(selectedRow.Cells["ZF_JiFeiLeiXing"].Value)){
                //    case 1:
                //        cobJiFeiLeiXing.Text = "整月";
                //        break;
                //    case 2:
                //        cobJiFeiLeiXing.Text = "按日";
                //        break;
                //    default:
                //        break;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("信息出现错误，请检查该条数据", "出现一个错误");
                this.Close();
            }
        }

        private void ZiFeiXinXi_Load(object sender, EventArgs e)
        {
            try
            {
                cobYunYingShang.DataSource = SqlHelper.ExecuteDataTable("SELECT * FROM T_Dic WHERE D_Name='运营商名称'");
                cobYunYingShang.DisplayMember = "D_Value";
                cobYunYingShang.ValueMember = "D_Value";
                cobDaiKuan.DataSource = SqlHelper.ExecuteDataTable("SELECT * FROM T_Dic WHERE D_Name='带宽'");
                cobDaiKuan.DisplayMember = "D_Value";
                cobDaiKuan.ValueMember = "D_Value";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "出现一个错误");
                this.Close();
            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "";
                SqlParameter[] parameters = new SqlParameter[7];
                parameters[0] = new SqlParameter("@yunYingShang", cobYunYingShang.Text);
                parameters[1] = new SqlParameter("@ziFeiMing", tbZiFeiMing.Text);
                parameters[2] = new SqlParameter("@ziFei", Convert.ToSingle(tbZiFei.Text));
                parameters[3] = new SqlParameter("@zhuangJiFei", Convert.ToSingle(tbZhuangJiFei.Text));
                parameters[4] = new SqlParameter("@daiKuan", cobDaiKuan.Text);
                parameters[5] = new SqlParameter("@qiXian", Convert.ToInt32(tbQiXian.Text));
                parameters[6] = new SqlParameter("@jiFeiLeiXing", cobJiFeiLeiXing.Text);// == "整月" ? 1 : cobJiFeiLeiXing.Text == "按日" ? 2 : -1
                if (isAddNew)
                {
                    sql = "INSERT INTO T_ZiFei(ZF_YunYingShang,ZF_ZiFeiMing,ZF_ZiFei,ZF_ZhuangJiFei,ZF_DaiKuan,ZF_QiXian,ZF_JiFeiLeiXing) VALUES(@yunYingShang,@ziFeiMing,@ziFei,@zhuangJiFei,@daiKuan,@qiXian,@jiFeiLeiXing)";
                }
                else
                {
                    sql = "UPDATE T_ZiFei SET ZF_YunYingShang=@yunYingShang,ZF_ZiFeiMing=@ziFeiMing,ZF_ZiFei=@ziFei,ZF_ZhuangJiFei=@zhuangJiFei,ZF_DaiKuan=@daiKuan,ZF_QiXian=@qiXian,ZF_JiFeiLeiXing=@jiFeiLeiXing WHERE ZF_ID=" + ziFeiInformation.Cells["ZF_ID"].Value.ToString();
                }
                SqlHelper.ExecuteDataTable(sql, parameters);
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

        private void cobYunYingShang_SelectedIndexChanged(object sender, EventArgs e)
        {
            //tbZiFeiMing.Text = cobYunYingShang.Text;//can't get expect
        }
    }
}
