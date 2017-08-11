namespace Black_Desert
{
    partial class help
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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 132);
            this.label1.TabIndex = 0;
            this.label1.Text = "批量小号导入\n第一步：选择账号\n账号和密码需要用特殊符号分割\n如\n“账号：123456----密码：123456”\n“123456分割123456”\n第二步：调整" +
    "参数，\n如登陆/入会（填写入会ID）/签到/绑定昵称等\n第三步：点击半自动\n第四步输入验证码\n接下来就是无限循环填写验证码了";
            // 
            // help
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 214);
            this.Controls.Add(this.label1);
            this.Name = "help";
            this.Text = "help";
            this.Deactivate += new System.EventHandler(this.help_Deactivate);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
    }
}