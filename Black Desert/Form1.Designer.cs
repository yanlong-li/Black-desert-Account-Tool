namespace Black_Desert
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.txtSelect = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.account = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusdl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusrh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusqd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountbz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.code = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.Addressbar = new System.Windows.Forms.TextBox();
            this.AddressbarGet = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.guild_id = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.nickname = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button10 = new System.Windows.Forms.Button();
            this.checkBoxNickName = new System.Windows.Forms.CheckBox();
            this.prefixNickName = new System.Windows.Forms.TextBox();
            this.button11 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.inputusername = new System.Windows.Forms.TextBox();
            this.inputpassword = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.checkBoxruhui = new System.Windows.Forms.CheckBox();
            this.checkBoxqiandao = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.dama2UsernameInput = new System.Windows.Forms.TextBox();
            this.dama2PasswordInput = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.checkBoxAutoDama2 = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.button16 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "蜗牛账号.txt";
            this.openFileDialog1.Filter = "文本文件(*.txt)|*.txt";
            this.openFileDialog1.Title = "请选择存放账号的文本文件";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 13F);
            this.button1.Location = new System.Drawing.Point(347, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 60);
            this.button1.TabIndex = 0;
            this.button1.Text = "选择账号";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtSelect
            // 
            this.txtSelect.Location = new System.Drawing.Point(54, 12);
            this.txtSelect.Name = "txtSelect";
            this.txtSelect.Size = new System.Drawing.Size(411, 21);
            this.txtSelect.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.account,
            this.password,
            this.statusdl,
            this.statusrh,
            this.statusqd,
            this.accountbz});
            this.dataGridView1.Location = new System.Drawing.Point(12, 133);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(476, 486);
            this.dataGridView1.TabIndex = 3;
            // 
            // id
            // 
            this.id.Frozen = true;
            this.id.HeaderText = "序号";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 60;
            // 
            // account
            // 
            this.account.HeaderText = "账号";
            this.account.Name = "account";
            this.account.ReadOnly = true;
            // 
            // password
            // 
            this.password.HeaderText = "密码";
            this.password.Name = "password";
            this.password.ReadOnly = true;
            // 
            // statusdl
            // 
            this.statusdl.HeaderText = "登陆";
            this.statusdl.Name = "statusdl";
            this.statusdl.ReadOnly = true;
            // 
            // statusrh
            // 
            this.statusrh.HeaderText = "入会";
            this.statusrh.Name = "statusrh";
            this.statusrh.ReadOnly = true;
            // 
            // statusqd
            // 
            this.statusqd.HeaderText = "签到";
            this.statusqd.Name = "statusqd";
            this.statusqd.ReadOnly = true;
            // 
            // accountbz
            // 
            this.accountbz.HeaderText = "备注";
            this.accountbz.Name = "accountbz";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 13F);
            this.button2.Location = new System.Drawing.Point(65, 54);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 60);
            this.button2.TabIndex = 4;
            this.button2.Text = "清空账号";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("宋体", 13F);
            this.button3.Location = new System.Drawing.Point(203, 54);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(118, 60);
            this.button3.TabIndex = 5;
            this.button3.Text = "未使用按钮";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("宋体", 13F);
            this.button4.Location = new System.Drawing.Point(225, 23);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(118, 39);
            this.button4.TabIndex = 6;
            this.button4.Text = "登陆";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(847, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "开始序号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(846, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "结束序号";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(905, 14);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(61, 21);
            this.numericUpDown1.TabIndex = 11;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(905, 45);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(61, 21);
            this.numericUpDown2.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(986, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "0为全部";
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(1045, 16);
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(61, 21);
            this.numericUpDown3.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(986, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "最多次数";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1117, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 16;
            this.label5.Text = "0为不限制";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(505, 291);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(648, 328);
            this.listBox1.TabIndex = 17;
            // 
            // pictureBox1
            // 
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.Location = new System.Drawing.Point(641, 72);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 33);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(621, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 19;
            this.label6.Text = "验证码";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // code
            // 
            this.code.Location = new System.Drawing.Point(668, 119);
            this.code.Name = "code";
            this.code.Size = new System.Drawing.Size(84, 21);
            this.code.TabIndex = 20;
            this.code.KeyDown += new System.Windows.Forms.KeyEventHandler(this.code_KeyDown);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("宋体", 13F);
            this.button5.Location = new System.Drawing.Point(494, 107);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(118, 33);
            this.button5.TabIndex = 21;
            this.button5.Text = "刷新验证码";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(1189, 41);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 22;
            this.button6.Text = "调试";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(1071, 298);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 23;
            this.button7.Text = "清空日志";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // Addressbar
            // 
            this.Addressbar.Location = new System.Drawing.Point(769, 140);
            this.Addressbar.Name = "Addressbar";
            this.Addressbar.Size = new System.Drawing.Size(337, 21);
            this.Addressbar.TabIndex = 24;
            // 
            // AddressbarGet
            // 
            this.AddressbarGet.Location = new System.Drawing.Point(1189, 72);
            this.AddressbarGet.Name = "AddressbarGet";
            this.AddressbarGet.Size = new System.Drawing.Size(75, 23);
            this.AddressbarGet.TabIndex = 25;
            this.AddressbarGet.Text = "读取链接";
            this.AddressbarGet.UseVisualStyleBackColor = true;
            this.AddressbarGet.Click += new System.EventHandler(this.AddressbarGet_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(349, 21);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 26;
            this.button8.Text = "入会";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // guild_id
            // 
            this.guild_id.Location = new System.Drawing.Point(668, 12);
            this.guild_id.Name = "guild_id";
            this.guild_id.Size = new System.Drawing.Size(73, 21);
            this.guild_id.TabIndex = 27;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(621, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 28;
            this.label7.Text = "工会ID";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(349, 50);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 29;
            this.button9.Text = "签到";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // nickname
            // 
            this.nickname.Location = new System.Drawing.Point(118, 74);
            this.nickname.Name = "nickname";
            this.nickname.Size = new System.Drawing.Size(73, 21);
            this.nickname.TabIndex = 31;
            this.nickname.DoubleClick += new System.EventHandler(this.suijinicheng);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(35, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 30;
            this.label8.Text = "绑定昵称";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(349, 77);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 32;
            this.button10.Text = "绑定昵称";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // checkBoxNickName
            // 
            this.checkBoxNickName.AutoSize = true;
            this.checkBoxNickName.Location = new System.Drawing.Point(769, 74);
            this.checkBoxNickName.Name = "checkBoxNickName";
            this.checkBoxNickName.Size = new System.Drawing.Size(108, 16);
            this.checkBoxNickName.TabIndex = 33;
            this.checkBoxNickName.Text = "账号昵称  前缀";
            this.checkBoxNickName.UseVisualStyleBackColor = true;
            // 
            // prefixNickName
            // 
            this.prefixNickName.Location = new System.Drawing.Point(905, 72);
            this.prefixNickName.Name = "prefixNickName";
            this.prefixNickName.Size = new System.Drawing.Size(73, 21);
            this.prefixNickName.TabIndex = 34;
            // 
            // button11
            // 
            this.button11.Font = new System.Drawing.Font("宋体", 13F);
            this.button11.Location = new System.Drawing.Point(494, 6);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(118, 60);
            this.button11.TabIndex = 38;
            this.button11.Text = "自动操作";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(503, 81);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 12);
            this.label9.TabIndex = 39;
            this.label9.Text = "均需要手动填写验证码";
            // 
            // inputusername
            // 
            this.inputusername.Location = new System.Drawing.Point(85, 20);
            this.inputusername.Name = "inputusername";
            this.inputusername.Size = new System.Drawing.Size(134, 21);
            this.inputusername.TabIndex = 40;
            // 
            // inputpassword
            // 
            this.inputpassword.Location = new System.Drawing.Point(85, 47);
            this.inputpassword.Name = "inputpassword";
            this.inputpassword.Size = new System.Drawing.Size(134, 21);
            this.inputpassword.TabIndex = 41;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(35, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 42;
            this.label10.Text = "账号";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(35, 50);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 43;
            this.label11.Text = "密码";
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(618, 39);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(63, 23);
            this.button12.TabIndex = 44;
            this.button12.Text = "下个账号";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(1189, 10);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(75, 23);
            this.button13.TabIndex = 45;
            this.button13.Text = "帮助";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // checkBoxruhui
            // 
            this.checkBoxruhui.AutoSize = true;
            this.checkBoxruhui.Location = new System.Drawing.Point(769, 42);
            this.checkBoxruhui.Name = "checkBoxruhui";
            this.checkBoxruhui.Size = new System.Drawing.Size(72, 16);
            this.checkBoxruhui.TabIndex = 46;
            this.checkBoxruhui.Text = "自动入会";
            this.checkBoxruhui.UseVisualStyleBackColor = true;
            // 
            // checkBoxqiandao
            // 
            this.checkBoxqiandao.AutoSize = true;
            this.checkBoxqiandao.Location = new System.Drawing.Point(769, 12);
            this.checkBoxqiandao.Name = "checkBoxqiandao";
            this.checkBoxqiandao.Size = new System.Drawing.Size(72, 16);
            this.checkBoxqiandao.TabIndex = 47;
            this.checkBoxqiandao.Text = "自动签到";
            this.checkBoxqiandao.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button14);
            this.groupBox1.Controls.Add(this.inputusername);
            this.groupBox1.Controls.Add(this.inputpassword);
            this.groupBox1.Controls.Add(this.nickname);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.button10);
            this.groupBox1.Controls.Add(this.button8);
            this.groupBox1.Controls.Add(this.button9);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Location = new System.Drawing.Point(505, 165);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(441, 113);
            this.groupBox1.TabIndex = 48;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "手动区域";
            // 
            // button14
            // 
            this.button14.Font = new System.Drawing.Font("宋体", 13F);
            this.button14.Location = new System.Drawing.Point(225, 68);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(118, 39);
            this.button14.TabIndex = 44;
            this.button14.Text = "退出";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(689, 39);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(63, 23);
            this.button15.TabIndex = 49;
            this.button15.Text = "上个账号";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // dama2UsernameInput
            // 
            this.dama2UsernameInput.Location = new System.Drawing.Point(81, 30);
            this.dama2UsernameInput.Name = "dama2UsernameInput";
            this.dama2UsernameInput.Size = new System.Drawing.Size(134, 21);
            this.dama2UsernameInput.TabIndex = 45;
            // 
            // dama2PasswordInput
            // 
            this.dama2PasswordInput.Location = new System.Drawing.Point(81, 57);
            this.dama2PasswordInput.Name = "dama2PasswordInput";
            this.dama2PasswordInput.Size = new System.Drawing.Size(134, 21);
            this.dama2PasswordInput.TabIndex = 50;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.button16);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.linkLabel1);
            this.groupBox2.Controls.Add(this.dama2UsernameInput);
            this.groupBox2.Controls.Add(this.dama2PasswordInput);
            this.groupBox2.Location = new System.Drawing.Point(961, 172);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(303, 100);
            this.groupBox2.TabIndex = 53;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "打码兔";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.Red;
            this.linkLabel1.Location = new System.Drawing.Point(108, 13);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(65, 12);
            this.linkLabel1.TabIndex = 55;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "注册打码兔";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // checkBoxAutoDama2
            // 
            this.checkBoxAutoDama2.AutoSize = true;
            this.checkBoxAutoDama2.Location = new System.Drawing.Point(769, 107);
            this.checkBoxAutoDama2.Name = "checkBoxAutoDama2";
            this.checkBoxAutoDama2.Size = new System.Drawing.Size(72, 16);
            this.checkBoxAutoDama2.TabIndex = 54;
            this.checkBoxAutoDama2.Text = "自动打码";
            this.checkBoxAutoDama2.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 33);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 55;
            this.label12.Text = "账号：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 61);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 12);
            this.label13.TabIndex = 56;
            this.label13.Text = "密码：";
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(222, 27);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(75, 23);
            this.button16.TabIndex = 55;
            this.button16.Text = "查余额";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(226, 61);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(17, 12);
            this.label14.TabIndex = 55;
            this.label14.Text = "--";
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Location = new System.Drawing.Point(1090, 51);
            this.numericUpDown4.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(61, 21);
            this.numericUpDown4.TabIndex = 55;
            this.numericUpDown4.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(1055, 54);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 12);
            this.label15.TabIndex = 56;
            this.label15.Text = "延迟";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(1157, 53);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(17, 12);
            this.label16.TabIndex = 57;
            this.label16.Text = "秒";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 624);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.numericUpDown4);
            this.Controls.Add(this.checkBoxAutoDama2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkBoxqiandao);
            this.Controls.Add(this.checkBoxruhui);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.prefixNickName);
            this.Controls.Add(this.checkBoxNickName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.guild_id);
            this.Controls.Add(this.AddressbarGet);
            this.Controls.Add(this.Addressbar);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.code);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDown3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtSelect);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "黑色沙漠批量小号申请加入公会 By Yanlongli";
            this.Deactivate += new System.EventHandler(this.Form1_Deactivate);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtSelect;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox code;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox Addressbar;
        private System.Windows.Forms.Button AddressbarGet;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox guild_id;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.TextBox nickname;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.CheckBox checkBoxNickName;
        private System.Windows.Forms.TextBox prefixNickName;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn account;
        private System.Windows.Forms.DataGridViewTextBoxColumn password;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusdl;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusrh;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusqd;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountbz;
        private System.Windows.Forms.TextBox inputusername;
        private System.Windows.Forms.TextBox inputpassword;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.CheckBox checkBoxruhui;
        private System.Windows.Forms.CheckBox checkBoxqiandao;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.TextBox dama2UsernameInput;
        private System.Windows.Forms.TextBox dama2PasswordInput;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBoxAutoDama2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
    }
}

