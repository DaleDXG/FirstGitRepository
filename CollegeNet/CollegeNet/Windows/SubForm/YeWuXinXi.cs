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
    public partial class YeWuXinXi : Form
    {
        //业务Flag 1代表预警未处理，2代表处理过
        //计费方式 1代表整月，2代表精确到天
        private bool isAddNew = false;
        bool isZiFeiChanged = false;
        private DataGridViewRow xueShengInformation = null;
        private DataGridViewRow yeWuInformation = null;
        public YeWuXinXi(DataGridViewRow selectedXS, DataGridViewRow selectedRow,bool isAddNew)
        {
            xueShengInformation = selectedXS;
            yeWuInformation = selectedRow;
            this.isAddNew = isAddNew;
            InitializeComponent();
            if (!isAddNew)
            {
                try
                {
                    tbShenFenZhengHao.Text = selectedRow.Cells["shenFenZhengHao"].Value.ToString();
                    tbDianHua.Text = selectedRow.Cells["dianHua"].Value.ToString();
                    tbZhangHao.Text = selectedRow.Cells["zhangHao"].Value.ToString();
                    cbYeWuLeiXing.Text = selectedRow.Cells["yeWuLeiXing"].Value.ToString();
                    cbYeWuLeiXing.Enabled = false;
                    cbZiFei.Text = selectedRow.Cells["ziFeiMing"].Value.ToString();
                    dtpBanLiRiQi.Value = Convert.ToDateTime(selectedRow.Cells["banLiRiQi"].Value.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("信息出现错误，请检查该条数据", "出现一个错误");
                    this.Close();
                }
            }
        }

        private void YeWuXinXi_Load(object sender, EventArgs e)
        {
            cbZiFei.DataSource = SqlHelper.ExecuteDataTable("SELECT ZF_ZiFeiMing FROM T_ZiFei");
            cbZiFei.DisplayMember = "ZF_ZiFeiMing";
            cbZiFei.ValueMember = "ZF_ZiFeiMing";
            cbZiFei.SelectedIndex = -1;
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "";
                SqlParameter[] parameters = null;
                DataRow drZiFei = null;
                if ((isAddNew || cbZiFei.Text != yeWuInformation.Cells["ziFeiMing"].Value.ToString()) && (cbYeWuLeiXing.Text == "新装" || cbYeWuLeiXing.Text == "续费" || cbYeWuLeiXing.Text == "移机"))// (!isAddNew && __)
                {
                    isZiFeiChanged = true;
                    drZiFei = SqlHelper.ExecuteDataTable("SELECT * FROM T_ZiFei WHERE ZF_ZiFeiMing=@ziFeiMing", new SqlParameter("@ziFeiMing", cbZiFei.Text)).Rows[0];
                    if (drZiFei == null && cbYeWuLeiXing.Text != "移机")
                    {
                        MessageBox.Show("所选资费不存在，请检查资费选择。", "出现一个错误");
                        return;
                    }
                }
                if (isAddNew)
                {
                    sql = @"INSERT INTO T_YeWu(YW_XueHao,YW_XingMing,YW_ShenFenZhengHao,YW_DianHua,
YW_ZiFeiMing,YW_YunYingShang,YW_ZhangHao,YW_YeWuLeiXing,YW_ZiFei,YW_DaiKuan,YW_BanLiRiQi,YW_QiXian,
YW_JiFeiLeiXing,YW_LouMing,YW_SuSheHao,YW_Target,YW_MarkJiLu,YW_MarkYouXiao)
VALUES(@xueHao,@xingMing,@shenFenZhengHao,@dianHua,@ziFeiMing,@yunYingShang,@zhangHao,@yeWuLeiXing,
@ziFei,@daiKuan,@banLiRiQi,@qiXian,@jiFeiLeiXing,@louMing,@suSheHao,@target,@markJiLu,@markYouXiao)";
                    parameters = new SqlParameter[18];
                    parameters[0] = new SqlParameter("@xueHao", xueShengInformation.Cells["xueHao"].Value);
                    parameters[1] = new SqlParameter("@xingMing", xueShengInformation.Cells["xingMing"].Value);
                    parameters[2] = new SqlParameter("@shenFenZhengHao", tbShenFenZhengHao.Text);
                    parameters[3] = new SqlParameter("@dianHua", tbDianHua.Text);

                    parameters[6] = new SqlParameter("@zhangHao", tbZhangHao.Text);
                    parameters[7] = new SqlParameter("@yeWuLeiXing", cbYeWuLeiXing.Text);

                    parameters[10] = new SqlParameter("@banLiRiQi", dtpBanLiRiQi.Value);

                    parameters[15] = new SqlParameter("@target", DBNull.Value);

                    if (cbYeWuLeiXing.Text == "新装")
                    {
                        parameters[4] = new SqlParameter("@ziFeiMing", drZiFei["ZF_ZiFeiMing"]);
                        parameters[5] = new SqlParameter("@yunYingShang", drZiFei["ZF_YunYingShang"]);
                        parameters[8] = new SqlParameter("@ziFei", Convert.ToInt32(drZiFei["ZF_ZiFei"]) + Convert.ToInt32(drZiFei["ZF_ZhuangJiFei"]));
                        parameters[9] = new SqlParameter("@daiKuan", drZiFei["ZF_DaiKuan"]);
                        parameters[11] = new SqlParameter("@qiXian", drZiFei["ZF_QiXian"]);
                        parameters[12] = new SqlParameter("@jiFeiLeiXing", drZiFei["ZF_JiFeiLeiXing"]);
                        parameters[13] = new SqlParameter("@louMing", xueShengInformation.Cells["gongYuMingCheng"].Value);
                        parameters[14] = new SqlParameter("@suSheHao", xueShengInformation.Cells["suSheHao"].Value);
                    }
                    else if (cbYeWuLeiXing.Text == "续费")
                    {
                        parameters[4] = new SqlParameter("@ziFeiMing", drZiFei["ZF_ZiFeiMing"]);
                        parameters[5] = new SqlParameter("@yunYingShang", drZiFei["ZF_YunYingShang"]);

                        if (tbLinShiZiFei.Text == String.Empty)
                            parameters[8] = new SqlParameter("@ziFei", Convert.ToInt32(drZiFei["ZF_ZiFei"]));
                        else
                        {
                            if ((string)yeWuInformation.Cells["yeWuLeiXing"].Value != "新装" && (string)yeWuInformation.Cells["yeWuLeiXing"].Value != "续费")
                            {
                                MessageBox.Show("需要选择一条业务。", "提示");
                                return;
                            }
                            parameters[7] = new SqlParameter("@yeWuLeiXing", "临时续费");
                            parameters[8] = new SqlParameter("@ziFei", Convert.ToInt32(tbLinShiZiFei.Text));
                            parameters[15] = new SqlParameter("@target", Convert.ToInt64(yeWuInformation.Cells["YW_ID"].Value));
                        }
                        
                        parameters[9] = new SqlParameter("@daiKuan", drZiFei["ZF_DaiKuan"]);

                        parameters[11] = new SqlParameter("@qiXian", drZiFei["ZF_QiXian"]);
                        parameters[12] = new SqlParameter("@jiFeiLeiXing", drZiFei["ZF_JiFeiLeiXing"]);
                        parameters[13] = new SqlParameter("@louMing", xueShengInformation.Cells["gongYuMingCheng"].Value);
                        parameters[14] = new SqlParameter("@suSheHao", xueShengInformation.Cells["suSheHao"].Value);
                    }
                    else if (cbYeWuLeiXing.Text == "移机")
                    {
                        if ((string)yeWuInformation.Cells["yeWuLeiXing"].Value != "新装" && (string)yeWuInformation.Cells["yeWuLeiXing"].Value != "续费")
                        {
                            MessageBox.Show("需要选择一条业务。", "提示");
                            return;
                        }
                        parameters[4] = new SqlParameter("@ziFeiMing", drZiFei["ZF_ZiFeiMing"]);
                        parameters[5] = new SqlParameter("@yunYingShang", drZiFei["ZF_YunYingShang"]);
                        parameters[8] = new SqlParameter("@ziFei", drZiFei["ZF_ZiFei"]);
                        parameters[9] = new SqlParameter("@daiKuan", drZiFei["ZF_DaiKuan"]);

                        parameters[11] = new SqlParameter("@qiXian", drZiFei["ZF_QiXian"]);
                        parameters[12] = new SqlParameter("@jiFeiLeiXing", drZiFei["ZF_JiFeiLeiXing"]);
                        parameters[13] = new SqlParameter("@louMing", cbLouMing.Text);
                        parameters[14] = new SqlParameter("@suSheHao", tbSuSheHao);
                        parameters[15] = new SqlParameter("@target", Convert.ToInt64(yeWuInformation.Cells["YW_ID"].Value));
                    }
                    else if (cbYeWuLeiXing.Text == "退网")
                    {
                        if ((string)yeWuInformation.Cells["yeWuLeiXing"].Value != "新装" && (string)yeWuInformation.Cells["yeWuLeiXing"].Value != "续费")
                        {
                            MessageBox.Show("需要选择一条业务。", "提示");
                            return;
                        }
                        parameters[4] = new SqlParameter("@ziFeiMing", yeWuInformation.Cells["ziFeiMing"].Value);
                        parameters[5] = new SqlParameter("@yunYingShang", yeWuInformation.Cells["yunYingShang"].Value);
                        parameters[8] = new SqlParameter("@ziFei", -Convert.ToInt32(yeWuInformation.Cells["ziFei"].Value));
                        parameters[9] = new SqlParameter("@daiKuan", DBNull.Value);

                        parameters[11] = new SqlParameter("@qiXian", DBNull.Value);
                        parameters[12] = new SqlParameter("@jiFeiLeiXing", DBNull.Value);

                        parameters[13] = new SqlParameter("@louMing", xueShengInformation.Cells["gongYuMingCheng"].Value);
                        parameters[14] = new SqlParameter("@suSheHao", xueShengInformation.Cells["suSheHao"].Value);
                        parameters[15] = new SqlParameter("@target", Convert.ToInt64(yeWuInformation.Cells["YW_ID"].Value));
                    }
                }
                else
                {
                    sql = @"UPDATE T_YeWu SET YW_ShenFenZhengHao=@shenFenZhengHao,YW_DianHua=@dianHua,YW_ZhangHao=@zhangHao,YW_BanLiRiQi=@banLiRiQi";
                    if (isZiFeiChanged)
                    {
                        sql += ",YW_ZiFeiMing=@ziFeiMing,YW_YunYingShang=@yunYingShang,YW_ZiFei=@ziFei,YW_DaiKuan=@daiKuan,YW_QiXian=@qiXian,YW_JiFeiLeiXing=@jiFeiLeiXing";
                        parameters = new SqlParameter[10];
                        parameters[4] = new SqlParameter("@ziFeiMing", drZiFei == null ? DBNull.Value : drZiFei["ZF_ZiFeiMing"]);
                        parameters[5] = new SqlParameter("@yunYingShang", drZiFei == null ? DBNull.Value : drZiFei["ZF_YunYingShang"]);
                        parameters[6] = new SqlParameter("@ziFei", drZiFei == null ? DBNull.Value : cbYeWuLeiXing.Text == "新装" ? Convert.ToInt32(drZiFei["ZF_ZiFei"]) + Convert.ToInt32(drZiFei["ZF_ZhuangJiFei"]) : drZiFei["ZF_ZiFei"]);
                        parameters[7] = new SqlParameter("@daiKuan", drZiFei == null ? DBNull.Value : drZiFei["ZF_DaiKuan"]);
                        parameters[8] = new SqlParameter("@qiXian", drZiFei == null ? DBNull.Value : drZiFei["ZF_QiXian"]);
                        parameters[9] = new SqlParameter("@jiFeiLeiXing", drZiFei == null ? DBNull.Value : drZiFei["ZF_JiFeiLeiXing"]);
                    }
                    else//if (parameters == null)
                    {
                        parameters = new SqlParameter[4];
                    }
                    parameters[0] = new SqlParameter("@shenFenZhengHao", tbShenFenZhengHao.Text);
                    parameters[1] = new SqlParameter("@dianHua", tbDianHua.Text);
                    parameters[2] = new SqlParameter("@zhangHao", tbZhangHao.Text);
                    parameters[3] = new SqlParameter("@banLiRiQi", dtpBanLiRiQi.Value);
                    sql += " WHERE YW_ID=" + yeWuInformation.Cells["YW_ID"].Value.ToString();
                }
                SqlHelper.ExecuteNonQuery(sql, parameters);
                MessageBox.Show(isAddNew ? "插入业务信息成功！" : "修改业务信息成功！", "成功");
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show("新装、续费请选择一项资费。", "出现一个错误");
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

        //if enter some words in tbLinShiZiFei then cbZiFei is disenable
        private void tbLinShiZiFei_TextChanged(object sender, EventArgs e)
        {
            if (this.Text != String.Empty)
            {
                cbZiFei.Enabled = false;
            }
            else
            {
                cbZiFei.Enabled = true;
            }
        }

        private void cbYeWuLeiXing_SelectedIndexChanged(object sender, EventArgs e)//业务类型变化
        {
            if (cbYeWuLeiXing.Text == String.Empty)
            {
                return;
            }
            else if (cbYeWuLeiXing.Text == "新装")
            {
                lblZiFei.Visible = true;
                moveControlByYeWu(lblZiFei, true, 1);
                cbZiFei.Visible = true;
                moveControlByYeWu(cbZiFei, false, 1);
                lblLinShiZiFei.Visible = false;
                tbLinShiZiFei.Visible = false;
                lblLouMing.Visible = false;
                cbLouMing.Visible = false;
                lblSuSheHao.Visible = false;
                tbSuSheHao.Visible = false;
            }
            else if (cbYeWuLeiXing.Text == "续费")
            {
                lblZiFei.Visible = true;
                moveControlByYeWu(lblZiFei, true, 1);
                cbZiFei.Visible = true;
                moveControlByYeWu(cbZiFei, false, 1);
                lblLinShiZiFei.Visible = true;
                moveControlByYeWu(lblLinShiZiFei, true, 2);
                tbLinShiZiFei.Visible = true;
                moveControlByYeWu(tbLinShiZiFei, false, 2);
                lblLouMing.Visible = false;
                cbLouMing.Visible = false;
                lblSuSheHao.Visible = false;
                tbSuSheHao.Visible = false;
            }
            else if (cbYeWuLeiXing.Text == "移机")
            {
                lblZiFei.Visible = true;
                moveControlByYeWu(lblZiFei, true, 1);
                cbZiFei.Visible = true;
                moveControlByYeWu(cbZiFei, false, 1);
                lblLinShiZiFei.Visible = false;
                tbLinShiZiFei.Visible = false;
                lblLouMing.Visible = true;
                moveControlByYeWu(lblLouMing, true, 2);
                cbLouMing.Visible = true;
                moveControlByYeWu(cbLouMing, false, 2);
                lblSuSheHao.Visible = true;
                moveControlByYeWu(lblSuSheHao, true, 2);
                tbSuSheHao.Visible = true;
                moveControlByYeWu(tbSuSheHao, false, 2);
            }
            else if (cbYeWuLeiXing.Text == "退网")
            {
                lblZiFei.Visible = false;
                cbZiFei.Visible = false;
                lblLinShiZiFei.Visible = false;
                tbLinShiZiFei.Visible = false;
                lblLouMing.Visible = false;
                cbLouMing.Visible = false;
                lblSuSheHao.Visible = false;
                tbSuSheHao.Visible = false;
            }
        }

        private void moveControlByYeWu(Control control, bool isLabel, int y)
        {
            Point cLocation = control.Location;
            cLocation.Y = 120 + 27 * y;
            if (isLabel)
                cLocation.Y += 3;
            control.Location = cLocation;
        }

    }
}
