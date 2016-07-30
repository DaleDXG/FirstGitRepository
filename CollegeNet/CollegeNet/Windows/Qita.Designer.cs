namespace CollegeNet
{
    partial class Qita
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.D_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yunYingShangMingCheng = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.U_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.U_AccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.U_Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.U_Rights = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnZFDelete = new System.Windows.Forms.Button();
            this.btnZFChange = new System.Windows.Forms.Button();
            this.btnZFAdd = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnChangeUser = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnDeleteYYS = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.DK_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.daiKuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDeleteDaiKuan = new System.Windows.Forms.Button();
            this.ZF_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ZF_YunYingShang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ZF_ZiFeiMing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ZF_ZiFei = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ZF_ZhuangJiFei = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ZF_DaiKuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ZF_QiXian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ZF_JiFeiLeiXing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "资费设置：";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ZF_ID,
            this.ZF_YunYingShang,
            this.ZF_ZiFeiMing,
            this.ZF_ZiFei,
            this.ZF_ZhuangJiFei,
            this.ZF_DaiKuan,
            this.ZF_QiXian,
            this.ZF_JiFeiLeiXing});
            this.dataGridView1.Location = new System.Drawing.Point(28, 48);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(644, 283);
            this.dataGridView1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(468, 369);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "运营商设置：";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.D_ID,
            this.yunYingShangMingCheng});
            this.dataGridView2.Location = new System.Drawing.Point(470, 394);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(143, 283);
            this.dataGridView2.TabIndex = 1;
            this.dataGridView2.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView2_CellBeginEdit);
            this.dataGridView2.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellEndEdit);
            this.dataGridView2.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridView2_CellValidating);
            // 
            // D_ID
            // 
            this.D_ID.DataPropertyName = "D_ID";
            this.D_ID.HeaderText = "字典ID";
            this.D_ID.Name = "D_ID";
            this.D_ID.Visible = false;
            // 
            // yunYingShangMingCheng
            // 
            this.yunYingShangMingCheng.DataPropertyName = "D_Value";
            this.yunYingShangMingCheng.HeaderText = "运营商名称";
            this.yunYingShangMingCheng.Name = "yunYingShangMingCheng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 369);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "用户设置：";
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.U_ID,
            this.U_AccountName,
            this.U_Password,
            this.U_Rights});
            this.dataGridView3.Location = new System.Drawing.Point(28, 394);
            this.dataGridView3.MultiSelect = false;
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.RowTemplate.Height = 23;
            this.dataGridView3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView3.Size = new System.Drawing.Size(424, 283);
            this.dataGridView3.TabIndex = 1;
            // 
            // U_ID
            // 
            this.U_ID.DataPropertyName = "U_ID";
            this.U_ID.HeaderText = "ID";
            this.U_ID.Name = "U_ID";
            this.U_ID.ReadOnly = true;
            // 
            // U_AccountName
            // 
            this.U_AccountName.DataPropertyName = "U_AccountName";
            this.U_AccountName.HeaderText = "用户名";
            this.U_AccountName.Name = "U_AccountName";
            this.U_AccountName.ReadOnly = true;
            this.U_AccountName.Width = 200;
            // 
            // U_Password
            // 
            this.U_Password.DataPropertyName = "U_Password";
            this.U_Password.HeaderText = "Password";
            this.U_Password.Name = "U_Password";
            this.U_Password.ReadOnly = true;
            this.U_Password.Visible = false;
            // 
            // U_Rights
            // 
            this.U_Rights.DataPropertyName = "U_Rights";
            this.U_Rights.HeaderText = "权限";
            this.U_Rights.Name = "U_Rights";
            this.U_Rights.ReadOnly = true;
            // 
            // btnZFDelete
            // 
            this.btnZFDelete.Location = new System.Drawing.Point(589, 337);
            this.btnZFDelete.Name = "btnZFDelete";
            this.btnZFDelete.Size = new System.Drawing.Size(75, 23);
            this.btnZFDelete.TabIndex = 10;
            this.btnZFDelete.Text = "删除";
            this.btnZFDelete.UseVisualStyleBackColor = true;
            this.btnZFDelete.Click += new System.EventHandler(this.btnZFDelete_Click);
            // 
            // btnZFChange
            // 
            this.btnZFChange.Location = new System.Drawing.Point(508, 337);
            this.btnZFChange.Name = "btnZFChange";
            this.btnZFChange.Size = new System.Drawing.Size(75, 23);
            this.btnZFChange.TabIndex = 11;
            this.btnZFChange.Text = "修改";
            this.btnZFChange.UseVisualStyleBackColor = true;
            this.btnZFChange.Click += new System.EventHandler(this.btnZFChange_Click);
            // 
            // btnZFAdd
            // 
            this.btnZFAdd.Location = new System.Drawing.Point(427, 337);
            this.btnZFAdd.Name = "btnZFAdd";
            this.btnZFAdd.Size = new System.Drawing.Size(75, 23);
            this.btnZFAdd.TabIndex = 12;
            this.btnZFAdd.Text = "新增";
            this.btnZFAdd.UseVisualStyleBackColor = true;
            this.btnZFAdd.Click += new System.EventHandler(this.btnZFAdd_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(216, 683);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(75, 23);
            this.btnAddUser.TabIndex = 12;
            this.btnAddUser.Text = "新增";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // btnChangeUser
            // 
            this.btnChangeUser.Location = new System.Drawing.Point(297, 683);
            this.btnChangeUser.Name = "btnChangeUser";
            this.btnChangeUser.Size = new System.Drawing.Size(75, 23);
            this.btnChangeUser.TabIndex = 11;
            this.btnChangeUser.Text = "修改";
            this.btnChangeUser.UseVisualStyleBackColor = true;
            this.btnChangeUser.Click += new System.EventHandler(this.btnChangeUser_Click);
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Location = new System.Drawing.Point(378, 683);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteUser.TabIndex = 10;
            this.btnDeleteUser.Text = "删除";
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // btnDeleteYYS
            // 
            this.btnDeleteYYS.Location = new System.Drawing.Point(538, 683);
            this.btnDeleteYYS.Name = "btnDeleteYYS";
            this.btnDeleteYYS.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteYYS.TabIndex = 10;
            this.btnDeleteYYS.Text = "删除";
            this.btnDeleteYYS.UseVisualStyleBackColor = true;
            this.btnDeleteYYS.Click += new System.EventHandler(this.btnDeleteYYS_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(629, 369);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "带宽设置：";
            // 
            // dataGridView4
            // 
            this.dataGridView4.AllowUserToDeleteRows = false;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DK_ID,
            this.daiKuan});
            this.dataGridView4.Location = new System.Drawing.Point(631, 394);
            this.dataGridView4.MultiSelect = false;
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.RowTemplate.Height = 23;
            this.dataGridView4.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView4.Size = new System.Drawing.Size(143, 283);
            this.dataGridView4.TabIndex = 1;
            this.dataGridView4.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView4_CellBeginEdit);
            this.dataGridView4.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView4_CellEndEdit);
            this.dataGridView4.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridView4_CellValidating);
            // 
            // DK_ID
            // 
            this.DK_ID.DataPropertyName = "D_ID";
            this.DK_ID.HeaderText = "字典ID";
            this.DK_ID.Name = "DK_ID";
            this.DK_ID.Visible = false;
            // 
            // daiKuan
            // 
            this.daiKuan.DataPropertyName = "D_Value";
            this.daiKuan.HeaderText = "带宽";
            this.daiKuan.Name = "daiKuan";
            // 
            // btnDeleteDaiKuan
            // 
            this.btnDeleteDaiKuan.Location = new System.Drawing.Point(699, 683);
            this.btnDeleteDaiKuan.Name = "btnDeleteDaiKuan";
            this.btnDeleteDaiKuan.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteDaiKuan.TabIndex = 10;
            this.btnDeleteDaiKuan.Text = "删除";
            this.btnDeleteDaiKuan.UseVisualStyleBackColor = true;
            this.btnDeleteDaiKuan.Click += new System.EventHandler(this.btnDeleteDaiKuan_Click);
            // 
            // ZF_ID
            // 
            this.ZF_ID.DataPropertyName = "ZF_ID";
            this.ZF_ID.HeaderText = "资费ID";
            this.ZF_ID.Name = "ZF_ID";
            this.ZF_ID.ReadOnly = true;
            this.ZF_ID.Visible = false;
            // 
            // ZF_YunYingShang
            // 
            this.ZF_YunYingShang.DataPropertyName = "ZF_YunYingShang";
            this.ZF_YunYingShang.HeaderText = "运营商";
            this.ZF_YunYingShang.Name = "ZF_YunYingShang";
            this.ZF_YunYingShang.ReadOnly = true;
            // 
            // ZF_ZiFeiMing
            // 
            this.ZF_ZiFeiMing.DataPropertyName = "ZF_ZiFeiMing";
            this.ZF_ZiFeiMing.HeaderText = "资费名";
            this.ZF_ZiFeiMing.Name = "ZF_ZiFeiMing";
            this.ZF_ZiFeiMing.ReadOnly = true;
            // 
            // ZF_ZiFei
            // 
            this.ZF_ZiFei.DataPropertyName = "ZF_ZiFei";
            this.ZF_ZiFei.HeaderText = "资费";
            this.ZF_ZiFei.Name = "ZF_ZiFei";
            this.ZF_ZiFei.ReadOnly = true;
            // 
            // ZF_ZhuangJiFei
            // 
            this.ZF_ZhuangJiFei.DataPropertyName = "ZF_ZhuangJiFei";
            this.ZF_ZhuangJiFei.HeaderText = "装机费";
            this.ZF_ZhuangJiFei.Name = "ZF_ZhuangJiFei";
            this.ZF_ZhuangJiFei.ReadOnly = true;
            // 
            // ZF_DaiKuan
            // 
            this.ZF_DaiKuan.DataPropertyName = "ZF_DaiKuan";
            this.ZF_DaiKuan.HeaderText = "带宽";
            this.ZF_DaiKuan.Name = "ZF_DaiKuan";
            this.ZF_DaiKuan.ReadOnly = true;
            // 
            // ZF_QiXian
            // 
            this.ZF_QiXian.DataPropertyName = "ZF_QiXian";
            this.ZF_QiXian.HeaderText = "期限";
            this.ZF_QiXian.Name = "ZF_QiXian";
            this.ZF_QiXian.ReadOnly = true;
            // 
            // ZF_JiFeiLeiXing
            // 
            this.ZF_JiFeiLeiXing.DataPropertyName = "ZF_JiFeiLeiXing";
            this.ZF_JiFeiLeiXing.HeaderText = "计费类型";
            this.ZF_JiFeiLeiXing.Name = "ZF_JiFeiLeiXing";
            this.ZF_JiFeiLeiXing.ReadOnly = true;
            this.ZF_JiFeiLeiXing.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Qita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 811);
            this.Controls.Add(this.btnDeleteDaiKuan);
            this.Controls.Add(this.btnDeleteYYS);
            this.Controls.Add(this.btnDeleteUser);
            this.Controls.Add(this.btnZFDelete);
            this.Controls.Add(this.btnChangeUser);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.btnZFChange);
            this.Controls.Add(this.btnZFAdd);
            this.Controls.Add(this.dataGridView4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "Qita";
            this.Text = "其他";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Qita_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Button btnZFDelete;
        private System.Windows.Forms.Button btnZFChange;
        private System.Windows.Forms.Button btnZFAdd;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnChangeUser;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn D_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn yunYingShangMingCheng;
        private System.Windows.Forms.Button btnDeleteYYS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.DataGridViewTextBoxColumn DK_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn daiKuan;
        private System.Windows.Forms.Button btnDeleteDaiKuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn U_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn U_AccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn U_Password;
        private System.Windows.Forms.DataGridViewTextBoxColumn U_Rights;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZF_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZF_YunYingShang;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZF_ZiFeiMing;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZF_ZiFei;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZF_ZhuangJiFei;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZF_DaiKuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZF_QiXian;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZF_JiFeiLeiXing;
    }
}