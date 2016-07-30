namespace CollegeNet
{
    partial class Gaikuangshuju
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
            this.yunYingShang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yongHuShuLiang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jinE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.huJunJinE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblGongYuTGaiKuang = new System.Windows.Forms.Label();
            this.btnWeiruwangxiangqing = new System.Windows.Forms.Button();
            this.btnDayin1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.xingBie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zongWangFei = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.banWangSuSheZongLiang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shangWangXueShengZongLiang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.banWangSuShePingJunWangFei = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.renJunWangFei = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDayin2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpJieZhi1 = new System.Windows.Forms.DateTimePicker();
            this.dtpQiShi2 = new System.Windows.Forms.DateTimePicker();
            this.dtpJieZhi2 = new System.Windows.Forms.DateTimePicker();
            this.btnTongJi1 = new System.Windows.Forms.Button();
            this.btnTongJi2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "公寓网络用户概况统计：";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.yunYingShang,
            this.yongHuShuLiang,
            this.jinE,
            this.huJunJinE});
            this.dataGridView1.Location = new System.Drawing.Point(14, 73);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(657, 251);
            this.dataGridView1.TabIndex = 1;
            // 
            // yunYingShang
            // 
            this.yunYingShang.DataPropertyName = "C1";
            this.yunYingShang.HeaderText = "运营商";
            this.yunYingShang.Name = "yunYingShang";
            this.yunYingShang.ReadOnly = true;
            // 
            // yongHuShuLiang
            // 
            this.yongHuShuLiang.DataPropertyName = "C2";
            this.yongHuShuLiang.HeaderText = "用户数量";
            this.yongHuShuLiang.Name = "yongHuShuLiang";
            this.yongHuShuLiang.ReadOnly = true;
            // 
            // jinE
            // 
            this.jinE.DataPropertyName = "C3";
            this.jinE.HeaderText = "金额";
            this.jinE.Name = "jinE";
            this.jinE.ReadOnly = true;
            // 
            // huJunJinE
            // 
            this.huJunJinE.DataPropertyName = "C4";
            this.huJunJinE.HeaderText = "户均金额";
            this.huJunJinE.Name = "huJunJinE";
            this.huJunJinE.ReadOnly = true;
            // 
            // lblGongYuTGaiKuang
            // 
            this.lblGongYuTGaiKuang.AutoSize = true;
            this.lblGongYuTGaiKuang.Location = new System.Drawing.Point(12, 341);
            this.lblGongYuTGaiKuang.Name = "lblGongYuTGaiKuang";
            this.lblGongYuTGaiKuang.Size = new System.Drawing.Size(527, 12);
            this.lblGongYuTGaiKuang.TabIndex = 11;
            this.lblGongYuTGaiKuang.Text = "公寓住宿宿舍共计0间，已入网宿舍0间，入网率0%，未入网宿舍0间，其中未入网毕业生宿舍占0%。";
            // 
            // btnWeiruwangxiangqing
            // 
            this.btnWeiruwangxiangqing.Location = new System.Drawing.Point(561, 380);
            this.btnWeiruwangxiangqing.Name = "btnWeiruwangxiangqing";
            this.btnWeiruwangxiangqing.Size = new System.Drawing.Size(110, 23);
            this.btnWeiruwangxiangqing.TabIndex = 12;
            this.btnWeiruwangxiangqing.Text = "未入网宿舍详情";
            this.btnWeiruwangxiangqing.UseVisualStyleBackColor = true;
            this.btnWeiruwangxiangqing.Click += new System.EventHandler(this.btnWeiruwangxiangqing_Click);
            // 
            // btnDayin1
            // 
            this.btnDayin1.Location = new System.Drawing.Point(557, 41);
            this.btnDayin1.Name = "btnDayin1";
            this.btnDayin1.Size = new System.Drawing.Size(75, 23);
            this.btnDayin1.TabIndex = 13;
            this.btnDayin1.Text = "打印";
            this.btnDayin1.UseVisualStyleBackColor = true;
            this.btnDayin1.Click += new System.EventHandler(this.btnDayin1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 434);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "平均上网费用：";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.xingBie,
            this.zongWangFei,
            this.banWangSuSheZongLiang,
            this.shangWangXueShengZongLiang,
            this.banWangSuShePingJunWangFei,
            this.renJunWangFei});
            this.dataGridView2.Location = new System.Drawing.Point(14, 487);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(657, 183);
            this.dataGridView2.TabIndex = 15;
            // 
            // xingBie
            // 
            this.xingBie.HeaderText = "性别";
            this.xingBie.Name = "xingBie";
            this.xingBie.ReadOnly = true;
            // 
            // zongWangFei
            // 
            this.zongWangFei.HeaderText = "总网费";
            this.zongWangFei.Name = "zongWangFei";
            this.zongWangFei.ReadOnly = true;
            // 
            // banWangSuSheZongLiang
            // 
            this.banWangSuSheZongLiang.HeaderText = "办网宿舍总量";
            this.banWangSuSheZongLiang.Name = "banWangSuSheZongLiang";
            this.banWangSuSheZongLiang.ReadOnly = true;
            this.banWangSuSheZongLiang.Width = 110;
            // 
            // shangWangXueShengZongLiang
            // 
            this.shangWangXueShengZongLiang.HeaderText = "上网学生总量";
            this.shangWangXueShengZongLiang.Name = "shangWangXueShengZongLiang";
            this.shangWangXueShengZongLiang.ReadOnly = true;
            this.shangWangXueShengZongLiang.Width = 110;
            // 
            // banWangSuShePingJunWangFei
            // 
            this.banWangSuShePingJunWangFei.HeaderText = "办网宿舍平均网费";
            this.banWangSuShePingJunWangFei.Name = "banWangSuShePingJunWangFei";
            this.banWangSuShePingJunWangFei.ReadOnly = true;
            this.banWangSuShePingJunWangFei.Width = 110;
            // 
            // renJunWangFei
            // 
            this.renJunWangFei.HeaderText = "人均网费";
            this.renJunWangFei.Name = "renJunWangFei";
            this.renJunWangFei.ReadOnly = true;
            // 
            // btnDayin2
            // 
            this.btnDayin2.Location = new System.Drawing.Point(557, 454);
            this.btnDayin2.Name = "btnDayin2";
            this.btnDayin2.Size = new System.Drawing.Size(75, 23);
            this.btnDayin2.TabIndex = 16;
            this.btnDayin2.Text = "打印";
            this.btnDayin2.UseVisualStyleBackColor = true;
            this.btnDayin2.Click += new System.EventHandler(this.btnDayin2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 459);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(239, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "起始时间：                 - 截止时间：";
            // 
            // dtpJieZhi1
            // 
            this.dtpJieZhi1.Location = new System.Drawing.Point(72, 43);
            this.dtpJieZhi1.Name = "dtpJieZhi1";
            this.dtpJieZhi1.Size = new System.Drawing.Size(117, 21);
            this.dtpJieZhi1.TabIndex = 17;
            this.dtpJieZhi1.ValueChanged += new System.EventHandler(this.dtpJieZhi1_ValueChanged);
            // 
            // dtpQiShi2
            // 
            this.dtpQiShi2.Location = new System.Drawing.Point(72, 453);
            this.dtpQiShi2.Name = "dtpQiShi2";
            this.dtpQiShi2.Size = new System.Drawing.Size(102, 21);
            this.dtpQiShi2.TabIndex = 17;
            // 
            // dtpJieZhi2
            // 
            this.dtpJieZhi2.Location = new System.Drawing.Point(246, 453);
            this.dtpJieZhi2.Name = "dtpJieZhi2";
            this.dtpJieZhi2.Size = new System.Drawing.Size(102, 21);
            this.dtpJieZhi2.TabIndex = 17;
            // 
            // btnTongJi1
            // 
            this.btnTongJi1.Location = new System.Drawing.Point(476, 41);
            this.btnTongJi1.Name = "btnTongJi1";
            this.btnTongJi1.Size = new System.Drawing.Size(75, 23);
            this.btnTongJi1.TabIndex = 13;
            this.btnTongJi1.Text = "统计";
            this.btnTongJi1.UseVisualStyleBackColor = true;
            this.btnTongJi1.Click += new System.EventHandler(this.btnTongJi1_Click);
            // 
            // btnTongJi2
            // 
            this.btnTongJi2.Location = new System.Drawing.Point(476, 454);
            this.btnTongJi2.Name = "btnTongJi2";
            this.btnTongJi2.Size = new System.Drawing.Size(75, 23);
            this.btnTongJi2.TabIndex = 16;
            this.btnTongJi2.Text = "统计";
            this.btnTongJi2.UseVisualStyleBackColor = true;
            this.btnTongJi2.Click += new System.EventHandler(this.btnTongJi2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "截止时间：";
            // 
            // Gaikuangshuju
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 811);
            this.Controls.Add(this.dtpJieZhi2);
            this.Controls.Add(this.dtpQiShi2);
            this.Controls.Add(this.dtpJieZhi1);
            this.Controls.Add(this.btnTongJi2);
            this.Controls.Add(this.btnDayin2);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnTongJi1);
            this.Controls.Add(this.btnDayin1);
            this.Controls.Add(this.btnWeiruwangxiangqing);
            this.Controls.Add(this.lblGongYuTGaiKuang);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "Gaikuangshuju";
            this.Text = "概况数据";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Gaikuangshuju_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblGongYuTGaiKuang;
        private System.Windows.Forms.Button btnWeiruwangxiangqing;
        private System.Windows.Forms.Button btnDayin1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn xingBie;
        private System.Windows.Forms.DataGridViewTextBoxColumn zongWangFei;
        private System.Windows.Forms.DataGridViewTextBoxColumn banWangSuSheZongLiang;
        private System.Windows.Forms.DataGridViewTextBoxColumn shangWangXueShengZongLiang;
        private System.Windows.Forms.DataGridViewTextBoxColumn banWangSuShePingJunWangFei;
        private System.Windows.Forms.DataGridViewTextBoxColumn renJunWangFei;
        private System.Windows.Forms.Button btnDayin2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpJieZhi1;
        private System.Windows.Forms.DateTimePicker dtpQiShi2;
        private System.Windows.Forms.DateTimePicker dtpJieZhi2;
        private System.Windows.Forms.Button btnTongJi1;
        private System.Windows.Forms.Button btnTongJi2;
        private System.Windows.Forms.DataGridViewTextBoxColumn yunYingShang;
        private System.Windows.Forms.DataGridViewTextBoxColumn yongHuShuLiang;
        private System.Windows.Forms.DataGridViewTextBoxColumn jinE;
        private System.Windows.Forms.DataGridViewTextBoxColumn huJunJinE;
        private System.Windows.Forms.Label label4;
    }
}