namespace CollegeNet
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.stbtnLuru = new System.Windows.Forms.ToolStripButton();
            this.tsbtnChaxun = new System.Windows.Forms.ToolStripButton();
            this.tsbtnYvjing = new System.Windows.Forms.ToolStripButton();
            this.tsbtnTongji = new System.Windows.Forms.ToolStripDropDownButton();
            this.概况数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.按宿舍统计ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.按运营商统计ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.按学生统计ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.月结统计ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.日结统计ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbtnQita = new System.Windows.Forms.ToolStripButton();
            this.tsbtnDaoru = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmDaoruFromExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.从Excel文件导入业务信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbtnBeifen = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmBeifenSqlServer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stbtnLuru,
            this.tsbtnChaxun,
            this.tsbtnYvjing,
            this.tsbtnTongji,
            this.tsbtnQita,
            this.tsbtnDaoru,
            this.tsbtnBeifen});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1002, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // stbtnLuru
            // 
            this.stbtnLuru.Image = ((System.Drawing.Image)(resources.GetObject("stbtnLuru.Image")));
            this.stbtnLuru.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stbtnLuru.Name = "stbtnLuru";
            this.stbtnLuru.Size = new System.Drawing.Size(52, 22);
            this.stbtnLuru.Text = "录入";
            this.stbtnLuru.Click += new System.EventHandler(this.stbtnLuru_Click);
            // 
            // tsbtnChaxun
            // 
            this.tsbtnChaxun.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnChaxun.Image")));
            this.tsbtnChaxun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnChaxun.Name = "tsbtnChaxun";
            this.tsbtnChaxun.Size = new System.Drawing.Size(76, 22);
            this.tsbtnChaxun.Text = "用户查询";
            this.tsbtnChaxun.Click += new System.EventHandler(this.tsbtnChaxun_Click);
            // 
            // tsbtnYvjing
            // 
            this.tsbtnYvjing.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnYvjing.Image")));
            this.tsbtnYvjing.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnYvjing.Name = "tsbtnYvjing";
            this.tsbtnYvjing.Size = new System.Drawing.Size(52, 22);
            this.tsbtnYvjing.Text = "预警";
            this.tsbtnYvjing.Click += new System.EventHandler(this.tsbtnYvjing_Click);
            // 
            // tsbtnTongji
            // 
            this.tsbtnTongji.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.日结统计ToolStripMenuItem,
            this.月结统计ToolStripMenuItem,
            this.概况数据ToolStripMenuItem,
            this.按宿舍统计ToolStripMenuItem,
            this.按运营商统计ToolStripMenuItem,
            this.按学生统计ToolStripMenuItem});
            this.tsbtnTongji.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnTongji.Image")));
            this.tsbtnTongji.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnTongji.Name = "tsbtnTongji";
            this.tsbtnTongji.Size = new System.Drawing.Size(61, 22);
            this.tsbtnTongji.Text = "统计";
            // 
            // 概况数据ToolStripMenuItem
            // 
            this.概况数据ToolStripMenuItem.Name = "概况数据ToolStripMenuItem";
            this.概况数据ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.概况数据ToolStripMenuItem.Text = "概况数据";
            this.概况数据ToolStripMenuItem.Click += new System.EventHandler(this.概况数据ToolStripMenuItem_Click);
            // 
            // 按宿舍统计ToolStripMenuItem
            // 
            this.按宿舍统计ToolStripMenuItem.Name = "按宿舍统计ToolStripMenuItem";
            this.按宿舍统计ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.按宿舍统计ToolStripMenuItem.Text = "按宿舍统计";
            this.按宿舍统计ToolStripMenuItem.Click += new System.EventHandler(this.按宿舍统计ToolStripMenuItem_Click);
            // 
            // 按运营商统计ToolStripMenuItem
            // 
            this.按运营商统计ToolStripMenuItem.Name = "按运营商统计ToolStripMenuItem";
            this.按运营商统计ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.按运营商统计ToolStripMenuItem.Text = "按运营商统计";
            this.按运营商统计ToolStripMenuItem.Click += new System.EventHandler(this.按运营商统计ToolStripMenuItem_Click);
            // 
            // 按学生统计ToolStripMenuItem
            // 
            this.按学生统计ToolStripMenuItem.Name = "按学生统计ToolStripMenuItem";
            this.按学生统计ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.按学生统计ToolStripMenuItem.Text = "按学生统计";
            this.按学生统计ToolStripMenuItem.Click += new System.EventHandler(this.按学生统计ToolStripMenuItem_Click);
            // 
            // 月结统计ToolStripMenuItem
            // 
            this.月结统计ToolStripMenuItem.Name = "月结统计ToolStripMenuItem";
            this.月结统计ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.月结统计ToolStripMenuItem.Text = "月结统计";
            this.月结统计ToolStripMenuItem.Click += new System.EventHandler(this.月结统计ToolStripMenuItem_Click);
            // 
            // 日结统计ToolStripMenuItem
            // 
            this.日结统计ToolStripMenuItem.Name = "日结统计ToolStripMenuItem";
            this.日结统计ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.日结统计ToolStripMenuItem.Text = "按日汇总";
            this.日结统计ToolStripMenuItem.Click += new System.EventHandler(this.日结统计ToolStripMenuItem_Click);
            // 
            // tsbtnQita
            // 
            this.tsbtnQita.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnQita.Image")));
            this.tsbtnQita.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnQita.Name = "tsbtnQita";
            this.tsbtnQita.Size = new System.Drawing.Size(52, 22);
            this.tsbtnQita.Text = "其他";
            this.tsbtnQita.Click += new System.EventHandler(this.tsbtnQita_Click);
            // 
            // tsbtnDaoru
            // 
            this.tsbtnDaoru.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmDaoruFromExcel,
            this.从Excel文件导入业务信息ToolStripMenuItem});
            this.tsbtnDaoru.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnDaoru.Image")));
            this.tsbtnDaoru.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDaoru.Name = "tsbtnDaoru";
            this.tsbtnDaoru.Size = new System.Drawing.Size(61, 22);
            this.tsbtnDaoru.Text = "导入";
            // 
            // tsmDaoruFromExcel
            // 
            this.tsmDaoruFromExcel.Name = "tsmDaoruFromExcel";
            this.tsmDaoruFromExcel.Size = new System.Drawing.Size(213, 22);
            this.tsmDaoruFromExcel.Text = "从Excel文件导入";
            this.tsmDaoruFromExcel.Click += new System.EventHandler(this.tsmDaoruFromExcel_Click);
            // 
            // 从Excel文件导入业务信息ToolStripMenuItem
            // 
            this.从Excel文件导入业务信息ToolStripMenuItem.Name = "从Excel文件导入业务信息ToolStripMenuItem";
            this.从Excel文件导入业务信息ToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.从Excel文件导入业务信息ToolStripMenuItem.Text = "从Excel文件导入业务信息";
            this.从Excel文件导入业务信息ToolStripMenuItem.Click += new System.EventHandler(this.从Excel文件导入业务信息ToolStripMenuItem_Click);
            // 
            // tsbtnBeifen
            // 
            this.tsbtnBeifen.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmBeifenSqlServer});
            this.tsbtnBeifen.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnBeifen.Image")));
            this.tsbtnBeifen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnBeifen.Name = "tsbtnBeifen";
            this.tsbtnBeifen.Size = new System.Drawing.Size(61, 22);
            this.tsbtnBeifen.Text = "备份";
            // 
            // tsmBeifenSqlServer
            // 
            this.tsmBeifenSqlServer.Name = "tsmBeifenSqlServer";
            this.tsmBeifenSqlServer.Size = new System.Drawing.Size(136, 22);
            this.tsmBeifenSqlServer.Text = "备份数据库";
            this.tsmBeifenSqlServer.Click += new System.EventHandler(this.tsmBeifenSqlServer_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 741);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.Name = "Main";
            this.Text = "公寓网络用户实名制信息管理系统";
            this.Load += new System.EventHandler(this.Main_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnChaxun;
        private System.Windows.Forms.ToolStripButton tsbtnYvjing;
        private System.Windows.Forms.ToolStripDropDownButton tsbtnDaoru;
        private System.Windows.Forms.ToolStripMenuItem tsmDaoruFromExcel;
        private System.Windows.Forms.ToolStripDropDownButton tsbtnBeifen;
        private System.Windows.Forms.ToolStripMenuItem tsmBeifenSqlServer;
        private System.Windows.Forms.ToolStripButton tsbtnQita;
        private System.Windows.Forms.ToolStripDropDownButton tsbtnTongji;
        private System.Windows.Forms.ToolStripMenuItem 概况数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 按宿舍统计ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 按运营商统计ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 按学生统计ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton stbtnLuru;
        private System.Windows.Forms.ToolStripMenuItem 从Excel文件导入业务信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 月结统计ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 日结统计ToolStripMenuItem;
    }
}

