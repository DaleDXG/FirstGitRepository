namespace CollegeNet
{
    partial class ZiFeiXinXi
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
            this.cobYunYingShang = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbZiFeiMing = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbZiFei = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cobDaiKuan = new System.Windows.Forms.ComboBox();
            this.tbQiXian = new System.Windows.Forms.TextBox();
            this.cobJiFeiLeiXing = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnEnter = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tbZhuangJiFei = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "运营商";
            // 
            // cobYunYingShang
            // 
            this.cobYunYingShang.FormattingEnabled = true;
            this.cobYunYingShang.Location = new System.Drawing.Point(72, 10);
            this.cobYunYingShang.Name = "cobYunYingShang";
            this.cobYunYingShang.Size = new System.Drawing.Size(121, 20);
            this.cobYunYingShang.TabIndex = 1;
            this.cobYunYingShang.SelectedIndexChanged += new System.EventHandler(this.cobYunYingShang_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "资费名";
            // 
            // tbZiFeiMing
            // 
            this.tbZiFeiMing.Location = new System.Drawing.Point(72, 36);
            this.tbZiFeiMing.Name = "tbZiFeiMing";
            this.tbZiFeiMing.Size = new System.Drawing.Size(121, 21);
            this.tbZiFeiMing.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "资费";
            // 
            // tbZiFei
            // 
            this.tbZiFei.Location = new System.Drawing.Point(72, 63);
            this.tbZiFei.Name = "tbZiFei";
            this.tbZiFei.Size = new System.Drawing.Size(80, 21);
            this.tbZiFei.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "带宽";
            // 
            // cobDaiKuan
            // 
            this.cobDaiKuan.FormattingEnabled = true;
            this.cobDaiKuan.Location = new System.Drawing.Point(72, 117);
            this.cobDaiKuan.Name = "cobDaiKuan";
            this.cobDaiKuan.Size = new System.Drawing.Size(80, 20);
            this.cobDaiKuan.TabIndex = 1;
            // 
            // tbQiXian
            // 
            this.tbQiXian.Location = new System.Drawing.Point(72, 143);
            this.tbQiXian.Name = "tbQiXian";
            this.tbQiXian.Size = new System.Drawing.Size(80, 21);
            this.tbQiXian.TabIndex = 2;
            // 
            // cobJiFeiLeiXing
            // 
            this.cobJiFeiLeiXing.FormattingEnabled = true;
            this.cobJiFeiLeiXing.Items.AddRange(new object[] {
            "整月",
            "按日"});
            this.cobJiFeiLeiXing.Location = new System.Drawing.Point(72, 170);
            this.cobJiFeiLeiXing.Name = "cobJiFeiLeiXing";
            this.cobJiFeiLeiXing.Size = new System.Drawing.Size(80, 20);
            this.cobJiFeiLeiXing.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "期限（月）";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "计费类型";
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(38, 217);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(75, 23);
            this.btnEnter.TabIndex = 3;
            this.btnEnter.Text = "确认";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(118, 217);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "装机费";
            // 
            // tbZhuangJiFei
            // 
            this.tbZhuangJiFei.Location = new System.Drawing.Point(72, 90);
            this.tbZhuangJiFei.Name = "tbZhuangJiFei";
            this.tbZhuangJiFei.Size = new System.Drawing.Size(80, 21);
            this.tbZhuangJiFei.TabIndex = 2;
            // 
            // ZiFeiXinXi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 260);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.tbQiXian);
            this.Controls.Add(this.tbZhuangJiFei);
            this.Controls.Add(this.tbZiFei);
            this.Controls.Add(this.tbZiFeiMing);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cobJiFeiLeiXing);
            this.Controls.Add(this.cobDaiKuan);
            this.Controls.Add(this.cobYunYingShang);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ZiFeiXinXi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "资费信息";
            this.Load += new System.EventHandler(this.ZiFeiXinXi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cobYunYingShang;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbZiFeiMing;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbZiFei;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cobDaiKuan;
        private System.Windows.Forms.TextBox tbQiXian;
        private System.Windows.Forms.ComboBox cobJiFeiLeiXing;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbZhuangJiFei;
    }
}