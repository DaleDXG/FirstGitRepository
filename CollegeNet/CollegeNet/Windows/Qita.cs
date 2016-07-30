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
    public partial class Qita : Form
    {
        public Qita()
        {
            InitializeComponent();
        }

        private void Qita_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView2.AutoGenerateColumns = false;
            dataGridView3.AutoGenerateColumns = false;
            dataGridView4.AutoGenerateColumns = false;
            try
            {
                //DataTable dtZiFei = SqlHelper.ExecuteDataTable("SELECT * FROM T_ZiFei");
                //dtZiFei.Columns.Add("ZF_JiFeiLeiXing2", System.Type.GetType("System.String"));
                //for (int i = 0; i < dtZiFei.Rows.Count; i++)
                //{
                //    if (Convert.ToInt32(dtZiFei.Rows[i]["ZF_JiFeiLeiXing"]) == 1)//整月
                //    {
                //        dtZiFei.Rows[i]["ZF_JiFeiLeiXing2"] = "整月";
                //    }
                //    else if (Convert.ToInt32(dtZiFei.Rows[i]["ZF_JiFeiLeiXing"]) == 2)//按日
                //    {
                //        dtZiFei.Rows[i]["ZF_JiFeiLeiXing2"] = "按日";
                //    }
                //}
                dataGridView1.DataSource = SqlHelper.ExecuteDataTable("SELECT * FROM T_ZiFei");
                dataGridView3.DataSource = SqlHelper.ExecuteDataTable("SELECT * FROM T_User");
                dataGridView2.DataSource = SqlHelper.ExecuteDataTable("SELECT * FROM T_Dic WHERE D_Name='运营商名称'");
                dataGridView4.DataSource = SqlHelper.ExecuteDataTable("SELECT * FROM T_Dic WHERE D_Name='带宽'");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "出现一个错误");
                return;
            }
        }

        private DataTable getYunYingShang()
        {
            try
            {
                return SqlHelper.ExecuteDataTable("SELECT * FROM T_Dic WHERE D_Name='运营商名称'");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "出现一个错误");
                return null;
            }
        }

        #region Button Stuff
        private void btnZFAdd_Click(object sender, EventArgs e)
        {
            ZiFeiXinXi zfadd = new ZiFeiXinXi();
            zfadd.ShowDialog();

            dataGridView1.DataSource = SqlHelper.ExecuteDataTable("SELECT * FROM T_ZiFei");
        }

        private void btnZFChange_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
            ZiFeiXinXi zfChange = new ZiFeiXinXi(dataGridView1.SelectedRows[0]);
            zfChange.ShowDialog();

            dataGridView1.DataSource = SqlHelper.ExecuteDataTable("SELECT * FROM T_ZiFei");
        }

        private void btnZFDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
            try
            {
                SqlHelper.ExecuteNonQuery("DELETE FROM T_ZiFei WHERE ZF_ID=" + dataGridView1.SelectedRows[0].Cells["ZF_ID"].Value.ToString());
                MessageBox.Show("删除成功", "成功");

                dataGridView1.DataSource = SqlHelper.ExecuteDataTable("SELECT * FROM T_ZiFei");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "出现一个错误");
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            UserInfo userAdd = new UserInfo();
            userAdd.ShowDialog();

            dataGridView3.DataSource = SqlHelper.ExecuteDataTable("SELECT * FROM T_User");
        }

        private void btnChangeUser_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count == 0)
            {
                return;
            }
            UserInfo userChange = new UserInfo(dataGridView3.SelectedRows[0]);
            userChange.ShowDialog();

            dataGridView3.DataSource = SqlHelper.ExecuteDataTable("SELECT * FROM T_User");
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count == 0)
            {
                return;
            }
            try
            {
                SqlHelper.ExecuteNonQuery("DELETE FROM T_User WHERE U_ID=" + dataGridView3.SelectedRows[0].Cells["U_ID"].Value.ToString());
                MessageBox.Show("删除成功", "成功");

                dataGridView3.DataSource = SqlHelper.ExecuteDataTable("SELECT * FROM T_User");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "出现一个错误");
            }
        }

        private string strBeforeEdit = "";
        private void dataGridView2_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //string headerText = dataGridView2.Columns[e.ColumnIndex].HeaderText;

            // Abort validation if cell is not in the CompanyName column.
            //if (!headerText.Equals("CompanyName")) return;

            // Confirm that the cell is not empty.
            if (string.IsNullOrEmpty(e.FormattedValue.ToString()))//dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
            {
                dataGridView2.Rows[e.RowIndex].ErrorText =
                    "Can not be empty";
                if (dataGridView2.Rows[e.RowIndex].Cells["D_ID"].Value != null && dataGridView2.Rows[e.RowIndex].Cells["D_ID"].Value != DBNull.Value)//If it start with empty than it can end as empty
                    e.Cancel = true;
            }
        }
        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Clear the row error in case the user presses ESC.
            dataGridView2.Rows[e.RowIndex].ErrorText = String.Empty;

            if (dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null) return;
            if (dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim() != strBeforeEdit)
            {
                if (dataGridView2.Rows[e.RowIndex].Cells["D_ID"].Value.ToString() == String.Empty)//new row
                {
                    long d_id = Convert.ToInt64(SqlHelper.ExecuteScalar("INSERT INTO T_Dic(D_Name,D_Value) VALUES('运营商名称',@yunYingShangMingCheng) select @@identity",
                        new SqlParameter("@yunYingShangMingCheng", dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim())));
                    dataGridView2.Rows[e.RowIndex].Cells["D_ID"].Value = d_id;
                }
                else
                {
                    SqlHelper.ExecuteNonQuery("UPDATE T_Dic SET D_Value=@yunYingShangMingCheng WHERE D_ID=@d_id",
                        new SqlParameter("@yunYingShangMingCheng", dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim()),
                        new SqlParameter("@d_id", Convert.ToInt64(dataGridView2.Rows[e.RowIndex].Cells["D_ID"].Value.ToString())));
                }
            }
        }
        private void dataGridView2_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null) return;
            strBeforeEdit = dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim();
        }

        private void btnDeleteYYS_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0)
            {
                return;
            }
            try
            {
                SqlHelper.ExecuteNonQuery("DELETE FROM T_Dic WHERE D_ID=" + dataGridView2.SelectedRows[0].Cells["D_ID"].Value.ToString());
                MessageBox.Show("删除成功", "成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "出现一个错误");
            }
        }

        private void dataGridView4_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
                dataGridView4.Rows[e.RowIndex].ErrorText =
                    "Can not be empty";
                if (dataGridView4.Rows[e.RowIndex].Cells["DK_ID"].Value != null && dataGridView4.Rows[e.RowIndex].Cells["DK_ID"].Value != DBNull.Value)
                    e.Cancel = true;
            }
        }
        private void dataGridView4_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dataGridView4.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null) return;
            strBeforeEdit = dataGridView4.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim();
        }
        private void dataGridView4_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Clear the row error in case the user presses ESC.
            dataGridView4.Rows[e.RowIndex].ErrorText = String.Empty;

            if (dataGridView4.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null) return;
            if (dataGridView4.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim() != strBeforeEdit)
            {
                if (dataGridView4.Rows[e.RowIndex].Cells["DK_ID"].Value.ToString() == String.Empty)//new row
                {
                    long d_id = Convert.ToInt64(SqlHelper.ExecuteScalar("INSERT INTO T_Dic(D_Name,D_Value) VALUES('带宽',@daiKuan) select @@identity",
                        new SqlParameter("@daiKuan", dataGridView4.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim())));
                    dataGridView4.Rows[e.RowIndex].Cells["DK_ID"].Value = d_id;
                }
                else
                {
                    SqlHelper.ExecuteNonQuery("UPDATE T_Dic SET D_Value=@daiKuan WHERE D_ID=@d_id",
                        new SqlParameter("@daiKuan", dataGridView4.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim()),
                        new SqlParameter("@d_id", Convert.ToInt64(dataGridView4.Rows[e.RowIndex].Cells["DK_ID"].Value.ToString())));
                }
            }
        }
        private void btnDeleteDaiKuan_Click(object sender, EventArgs e)
        {
            if (dataGridView4.SelectedRows.Count == 0)
            {
                return;
            }
            try
            {
                SqlHelper.ExecuteNonQuery("DELETE FROM T_Dic WHERE D_ID=" + dataGridView4.SelectedRows[0].Cells["DK_ID"].Value.ToString());
                MessageBox.Show("删除成功", "成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "出现一个错误");
            }
        }
        #endregion
    }
}
