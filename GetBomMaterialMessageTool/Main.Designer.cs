namespace GetBomMaterialMessageTool
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.tmclose = new System.Windows.Forms.ToolStripMenuItem();
            this.btnimport = new System.Windows.Forms.Button();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmclose});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(246, 25);
            this.Menu.TabIndex = 0;
            this.Menu.Text = "menuStrip1";
            // 
            // tmclose
            // 
            this.tmclose.Name = "tmclose";
            this.tmclose.Size = new System.Drawing.Size(44, 21);
            this.tmclose.Text = "退出";
            // 
            // btnimport
            // 
            this.btnimport.Location = new System.Drawing.Point(12, 28);
            this.btnimport.Name = "btnimport";
            this.btnimport.Size = new System.Drawing.Size(102, 23);
            this.btnimport.TabIndex = 1;
            this.btnimport.Text = "导入EXCEL";
            this.btnimport.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 55);
            this.ControlBox = false;
            this.Controls.Add(this.btnimport);
            this.Controls.Add(this.Menu);
            this.MainMenuStrip = this.Menu;
            this.Name = "Main";
            this.Text = "批量获取BOM相关物料信息工具";
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem tmclose;
        private System.Windows.Forms.Button btnimport;
    }
}

