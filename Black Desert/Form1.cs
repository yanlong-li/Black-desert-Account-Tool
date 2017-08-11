using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Web;
using System.Globalization;

namespace Black_Desert
{
    public partial class Form1 : Form
    {
        //当前选择文件路径
        private string fName;
        //已读账号序号
        private int number=0;
        //开始读取账号时间
        private DateTime startopentext;
        //读取账号结束
        private DateTime endopentext;
        //cookie储存
        private CookieContainer cc = new CookieContainer();
        //附加url参数
        private string tmpurl="";

        //帮助窗体
        public static help help;

        //半自动状态
        private bool auto = false;

        public Form1()
        {
            InitializeComponent();
            startopentext = DateTime.Now;
            listBox1.Items.Add(startopentext.ToString());
            listBox1.Items.Add("请选择账号文件");
            listBox1.SelectedIndex = listBox1.Items.Count - 1;

            //Form form2 = new Form2();
            //form2.Show();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = this.openFileDialog1;
            openFileDialog.InitialDirectory = Application.StartupPath;
            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.Add(DateTime.Now.ToString());
                listBox1.Items.Add("已选择账号档案正在加载。。。。。。");
                listBox1.Items.Add("档案地址："+fName);
                listBox1.Items.Add(DateTime.Now.ToString());
                listBox1.Items.Add("加载成功正在分析。。。。。。");
                fName = openFileDialog.FileName.ToString();
                txtSelect.Text = fName;
                this.openFile(fName);
            }
            else {
                listBox1.Items.Add(DateTime.Now.ToString());
                listBox1.Items.Add("加载失败，请重试。");
            }
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }
        private void openFile(string fName)
        {
            System.IO.StreamReader sr = new System.IO.StreamReader(fName);
            #region 字符串匹配
            DataGridViewRow dr = new DataGridViewRow();
            dr.CreateCells(dataGridView1);
            string RegexStr = @"[a-zA-Z0-9_]+";

            string s = sr.ReadLine();//读取每行
            while (s != null) { 
                var acc = Regex.Matches(s, RegexStr);
                try
                {
                    string kk="";
                    dataGridView1.Rows.Add(++number, acc[0], acc[1],kk);
                    s = sr.ReadLine();//读取每行
                }
                catch(Exception exp)
                {
                    listBox1.Items.Add(DateTime.Now.ToString());
                    listBox1.Items.Add(s+"读取失败，"+number+"行。");
                    throw exp;
                };
            }
            endopentext = DateTime.Now;
            listBox1.Items.Add(endopentext.ToString());
            TimeSpan openHS =   endopentext- startopentext;
            listBox1.Items.Add("分析完成，共载入" + (dataGridView1.RowCount-1) + "个账号,耗时："+ openHS.Seconds+"秒。");
            #endregion
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }
        //清空账号
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            listBox1.Items.Add(DateTime.Now.ToString());
            listBox1.Items.Add("已清空");
            number = 0;
            numericUpDown1.Value = 1;

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //登陆
            Login();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //加载验证码
            LoadCode();
        }

        #region 同步通过POST方式发送数据
        /// <summary>
        /// 通过POST方式发送数据
        /// </summary>
        /// <param name="Url">url</param>
        /// <param name="postDataStr">Post数据</param>
        /// <param name="cookie">Cookie容器</param>
        /// <returns></returns>
        public string SendDataByPost(string Url, string postDataStr, ref CookieContainer cookie)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            if (cookie.Count == 0)
            {
                request.CookieContainer = new CookieContainer();
                cookie = request.CookieContainer;
            }
            else
            {
                request.CookieContainer = cookie;
            }
            try { 
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postDataStr.Length;
            Stream myRequestStream = request.GetRequestStream();
            StreamWriter myStreamWriter = new StreamWriter(myRequestStream, Encoding.GetEncoding("gb2312"));
            myStreamWriter.Write(postDataStr);
            myStreamWriter.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                cookie.Add(response.Cookies);
                foreach (Cookie ck in response.Cookies)
                {
                    listBox1.Items.Add(ck.Name + ":" + ck.Value);
                }
                Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
                return retString;
            }
            catch (Exception exp)
            {
                listBox1.Items.Add(exp.Message);
                return exp.Message;
            }
            
        }
        #endregion

        #region 同步通过GET方式发送数据
        /// <summary>
        /// 通过GET方式发送数据
        /// </summary>
        /// <param name="Url">url</param>
        /// <param name="postDataStr">GET数据</param>
        /// <param name="cookie">GET容器</param>
        /// <returns></returns>
        public string SendDataByGET(string Url, string postDataStr, ref CookieContainer cookie)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
            if (cookie.Count == 0)
            {
                request.CookieContainer = new CookieContainer();
                cookie = request.CookieContainer;
            }
            else
            {
                request.CookieContainer = cookie;
            }

            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";

            try { 
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            cookie.Add(response.Cookies);
                foreach(Cookie ck in response.Cookies)
                {
                    listBox1.Items.Add(ck.Name+":"+ck.Value);
                }
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

             string   RegexStr = @"(?is)<input[^/>]* type=[^\w]*hidden[^\w]* name=[^\w]?(?<name>[_\w]*)[^\w]*[^/>]* value=[^\w]?(?<value>[\w-.]*)[^\w<\s]*";

                MatchCollection hidden = Regex.Matches(retString, RegexStr);
                foreach (Match value in hidden)
                {
                    var name = value.Groups[1].Value;
                    var val = value.Groups[2].Value;
                    tmpurl += "&"+value.Groups[1]+"=" + value.Groups[2];
                }
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                return retString;

             
            }
            catch(Exception exp)
            {
                listBox1.Items.Add(exp.Message);
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                return exp.Message;
            }
            
        }
        #endregion

        private void rwtxt(string Txt,string filename= "log.txt")
        {
            if (!File.Exists(Application.StartupPath + "\\"+ filename))
            {
                FileStream fs1 = new FileStream(Application.StartupPath+"\\"+ filename, FileMode.Create, FileAccess.Write);//创建写入文件 
                StreamWriter sw = new StreamWriter(fs1);
                sw.WriteLine(Txt);//开始写入值
                sw.Close();
                fs1.Close();
            }
            else
            {
                FileStream fs = new FileStream(Application.StartupPath + "\\"+ filename, FileMode.Truncate, FileAccess.Write);
                StreamWriter sr = new StreamWriter(fs);
                sr.WriteLine(Txt);//开始写入值
                sr.Close();
                fs.Close();
            }
        }
        /// <summary>
        /// 通过GET方式发送数据
        /// </summary>
        /// <param name="Url">url</param>
        /// <param name="postDataStr">GET数据</param>
        /// <param name="cookie">GET容器</param>
        /// <returns></returns>
        public Image getImg(string Url, string postDataStr, ref CookieContainer cookie)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
            if (cookie.Count == 0)
            {
                request.CookieContainer = new CookieContainer();
                cookie = request.CookieContainer;
            }
            else
            {
                request.CookieContainer = cookie;
            }

            request.Method = "GET";
            request.ContentType = "image/png;charset=UTF-8";
            try { 

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            cookie.Add(response.Cookies);
            foreach (Cookie ck in response.Cookies)
            {
                listBox1.Items.Add(ck.Name + ":" + ck.Value);
            }
            Stream myResponseStream = response.GetResponseStream();
            Image code = Image.FromStream(myResponseStream);
                //pictureBox1.Image = code;
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                return code;
            }catch(Exception exp)
            {
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                listBox1.Items.Add("验证码加载失败：" + exp.Message);
                //return 
                throw exp;
            }
        }

        public string getJson(string Url, string postDataStr, ref CookieContainer cookie)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
            if (cookie.Count == 0)
            {
                request.CookieContainer = new CookieContainer();
                cookie = request.CookieContainer;
            }
            else
            {
                request.CookieContainer = cookie;
            }

            request.Method = "GET";
            request.ContentType = "text/html; charset=utf-8";
            try
            {

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                string retString = myStreamReader.ReadToEnd();

                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                return retString;
            }
            catch (Exception exp)
            {
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                listBox1.Items.Add("验证码加载失败：" + exp.Message);
                //return 
                throw exp;
            }
        }


        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            foreach(Cookie cck in cc.GetCookies(new System.Uri("https://sso.woniu.com/login")))
            {
                listBox1.Items.Add(cck.Name+":"+cck.Value);
            }
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }


        //清空日志
        private void button7_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }


        //加载自定义链接
        private void AddressbarGet_Click(object sender, EventArgs e)
        {
            // 操作代码
            string content;

            //获取get返回内容
            content = SendDataByGET(Addressbar.Text, "", ref cc);
            //加载验证码
           // pictureBox1.Image = getImg("https://sso.woniu.com/captcha", "", ref cc);


            //调试打印返回内容
            rwtxt(content, "addressbar.html");

            listBox1.Items.Add("验证码已加载");
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }

        //入会
        private void button8_Click(object sender, EventArgs e)
        {
            ruhui();
        }

        //签到
        private void button9_Click(object sender, EventArgs e)
        {
            qiandao();

        }

        //解码
        public  string Decode(string s)
        {
            Regex reUnicode = new Regex(@"\\u([0-9a-fA-F]{4})", RegexOptions.Compiled);
            return reUnicode.Replace(s, m =>
            {
                short c;
                if (short.TryParse(m.Groups[1].Value, System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture, out c))
                {
                    return "" + (char)c;
                }
                return m.Value;
            });
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //绑定昵称
            bindnickname();
        }

        //半自动

        private void button11_Click(object sender, EventArgs e)
        {
            auto = true;
            auto1();
        }

        //get请求登陆页并加载验证码
        private void LoadCode()
        {
            //清楚验证码
            code.Text = "";
            // 操作代码
            string content;

            DataGridViewSelectedRowCollection dg1 = dataGridView1.SelectedRows;

            //获取get返回内容
            content = SendDataByGET("https://sso.woniu.com/login", "", ref cc);
            //加载验证码
            pictureBox1.Image = getImg("https://sso.woniu.com/captcha", "", ref cc);


            //调试打印返回内容
            //rwtxt(content, "getLogin.html");

            listBox1.Items.Add("验证码已加载");
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }


        //登陆
        private bool Login()
        {

            string content;

            //清空cookie，防止乱带数据

            //cc.GetCookies(new Uri("http://sso.woniu.com"));

            //content = this.SendDataByPost("https://sso.woniu.com/login_embedded?service=http%3A%2F%2Fgwact.woniu.com%2Fpassport%2Fssologin%3Fgoto%3Dhttp%3A%2F%2Fwww.woniu.com%2Faccount%2FssoLoginSuccess.html&regurl=http%3A%2F%2Fwww.woniu.com%2Faccount%2Fregister%2F%3Fgameid%3D105%26pagename%3Dhttp%3A%2F%2Fbd.woniu.com%26goto%3Dhttp%3A%2F%2Fbd.woniu.com%2Fguild%2F", "username=pv57115&password=aa130520&captcha=" + this.code.Text+ tmpurl, ref cc);
            content = this.SendDataByPost("https://sso.woniu.com/login_embedded?service=http://gwact.woniu.com/passport/ssologin?goto=http://www.woniu.com/account/ssoLoginSuccess.html&regurl=http://www.woniu.com/account/register/?gameid=105&pagename=http://bd.woniu.com&goto=http://bd.woniu.com/static/guild/index.html", "username="+inputusername.Text+"&password="+inputpassword.Text+"&captcha=" + this.code.Text + tmpurl, ref cc);

            //string RegexStr = @"请输入验证码";
            //var c = Regex.IsMatch(content, "请输入验证呵呵呵呵呵");
            if (Regex.Matches(content, "请输入验证码").Count >= 2)
            {
                if (auto)
                {
                    dataGridView1.Rows[Convert.ToInt32(numericUpDown1.Value - 2)].Cells[3].Value = "2";
                }
                listBox1.Items.Add("请输入验证码");
                //重新加载验证码
                pictureBox1.Image = getImg("https://sso.woniu.com/captcha", "", ref cc);

                return false;
            }
            else if (Regex.IsMatch(content, "您输入的验证码错误"))
            {
                if (auto)
                {
                    dataGridView1.Rows[Convert.ToInt32(numericUpDown1.Value - 2)].Cells[3].Value = "2";
                }
                listBox1.Items.Add("您输入的验证码错误");
                //重新加载验证码
                pictureBox1.Image = getImg("https://sso.woniu.com/captcha", "", ref cc);
                return false;
            }
            else if (Regex.IsMatch(content, "登录成功") || Regex.IsMatch(content, "您已经成功登录中央认证系统"))
            {
                if (auto)
                {
                    dataGridView1.Rows[Convert.ToInt32(numericUpDown1.Value + accSelectNo-1)].Cells[3].Value = "1";
                }
                listBox1.Items.Add("账号登陆成功");
            }
            else if (Regex.IsMatch(content, "您输入的帐号或密码不正确"))
            {
                if (auto)
                {
                    dataGridView1.Rows[Convert.ToInt32(numericUpDown1.Value + accSelectNo - 1)].Cells[3].Value = "3";
                }
                listBox1.Items.Add("账号密码错误");
                return false;
            }
            else if (Regex.IsMatch(content, "您输入的帐号不存在"))
            {
                if (auto)
                {
                    dataGridView1.Rows[Convert.ToInt32(numericUpDown1.Value + accSelectNo - 1)].Cells[3].Value = "5";
                }
                listBox1.Items.Add("您输入的帐号不存在");
                return false;
            }
            else
            {
                if (auto)
                {
                    dataGridView1.Rows[Convert.ToInt32(numericUpDown1.Value + accSelectNo - 1)].Cells[3].Value = "4";
                }
                listBox1.Items.Add("未知错误");
                return false;
            }

            //调试打印返回内容
            rwtxt(content, "postLogin.html");

            //清空附加url参数
            tmpurl = "";

            //二次不带参数请求url地址
            string Urlcontent = this.SendDataByPost("https://sso.woniu.com/login_embedded?service=http://gwact.woniu.com/passport/ssologin?goto=http://www.woniu.com/account/ssoLoginSuccess.html&regurl=http://www.woniu.com/account/register/?gameid=105&pagename=http://bd.woniu.com&goto=http://bd.woniu.com/static/guild/index.html", "", ref cc);


            string Regexstr = @"href\s*=\s*\""(?<url>[\w:/?=.&-_]*)";

            Match Url = Regex.Match(Urlcontent, Regexstr);

            listBox1.Items.Add("返回URL：" + Url.Groups[1].ToString());

            rwtxt(content, "post2Login.html");

            //三次请求二次返回的url地址GET

            string content3 = SendDataByGET(Url.Groups[1].ToString(), "", ref cc);


            //四次请求登陆状态
            string content4 = SendDataByGET("http://www.woniu.com/account/ssoLoginSuccess.html", "", ref cc);
            listBox1.SelectedIndex = listBox1.Items.Count - 1;


            return true;
        }

        //绑定昵称
        private void bindnickname()
        {
            string content;
            //获取get返回内容
            content = getJson("http://gwact.woniu.com/guildsystem/pcguild/bindAccount?jsoncallback=jQuery1720005763611509013167_1502427093392&game_id=10&area_id=1&area_title=1&server_id=1&server_title=1&game_name=" + nickname.Text + "&_=1502427172476", "", ref cc);
            rwtxt(content, "绑定昵称.html");

            content = content.Replace(@"""", "");

            string RegexStr = @"[\\\w*]+";

            MatchCollection sss = Regex.Matches(content, RegexStr);
            if (sss[1].ToString() != "1")
            {
                if (auto)
                {
                    dataGridView1.Rows[Convert.ToInt32(numericUpDown1.Value + accSelectNo - 1)].Cells[4].Value = Decode(sss[4].ToString());
                }
                listBox1.Items.Add("错误代码:" + sss[2] + "    返回信息:" + Decode(sss[4].ToString()));
            }
            else
            {
                if (auto)
                {
                    dataGridView1.Rows[Convert.ToInt32(numericUpDown1.Value + accSelectNo - 1)].Cells[4].Value = "1";
                }
                listBox1.Items.Add("操作成功:" + sss[2] + "    返回信息:" + Decode(sss[4].ToString()));
            }
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }

        //入会
        private void ruhui()
        {
            string content;
            //获取get返回内容
            content = SendDataByGET("http://gwact.woniu.com/guildsystem/pcguild/apply?guild_id=" + guild_id.Text + "&game_id=10", "", ref cc);
            rwtxt(content, "入会操作.html");

            //todo 
            content = content.Replace(@"""", "");

            string RegexStr = @"[\\\w*]+";

            MatchCollection sss = Regex.Matches(content, RegexStr);
            if (sss[1].ToString() != "1")
            {
                if (auto)
                {
                    dataGridView1.Rows[Convert.ToInt32(numericUpDown1.Value + accSelectNo - 1)].Cells[4].Value = "2";
                }
                listBox1.Items.Add("错误代码:" + sss[1] + "    返回信息:" + Decode(sss[3].ToString()));
            }
            else
            {
                if (auto)
                {
                    dataGridView1.Rows[Convert.ToInt32(numericUpDown1.Value + accSelectNo - 1)].Cells[4].Value = "1";
                }
                listBox1.Items.Add("操作成功:" + sss[1] + "    返回信息:" + Decode(sss[3].ToString()));
            }
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }
        //签到
        private void qiandao()
        {
            string content;
            //获取get返回内容
            content = getJson("http://gwact.woniu.com/guildsystem/pcguild/sign?game_id=10", "", ref cc);
            rwtxt(content, "签到.html");

            content = content.Replace(@"""", "");

            string RegexStr = @"[\\\w*]+";

            MatchCollection sss = Regex.Matches(content, RegexStr);
            if (sss[1].ToString() != "1")
            {
                if (auto)
                {
                    dataGridView1.Rows[Convert.ToInt32(numericUpDown1.Value + accSelectNo - 1)].Cells[5].Value = "2";
                }
                listBox1.Items.Add("错误代码:" + sss[1] + "    返回信息:" + Decode(sss[3].ToString()));
            }
            else
            {
                if (auto)
                {
                    dataGridView1.Rows[Convert.ToInt32(numericUpDown1.Value + accSelectNo - 1)].Cells[5].Value = "1";
                }
                listBox1.Items.Add("操作成功:" + sss[1] + "    返回信息:" + Decode(sss[3].ToString()));
            }
            listBox1.SelectedIndex = listBox1.Items.Count - 1;

        }

        //随机昵称
        private void suijinicheng()
        {
            Random ran = new Random();
            int RandKey = ran.Next(100, 999);
            nickname.Text  = prefixNickName.Text + RandKey.ToString();
        }

        //当验证码按下回车时
        private void code_KeyDown(object sender, KeyEventArgs e)
        {
            //按下了回车
            if (e.KeyCode == Keys.Enter)
            {
                //半自动关闭
                if (!auto)
                {
                    Login();
                }
                else
                {
                    auto2();
                }
            }
            
        }

        //默认已选择账号id序号
        private decimal accSelectNo = 0;


        //半自动函数1
        private void auto1()
        {

            if (!auto) {
                 accSelectNo = 0;
                auto = false;
                listBox1.Items.Add("半自动执行结束");
                return;
            }

            //todo 读取参数，账号列表及当前序号
            decimal select =  numericUpDown1.Value+ accSelectNo-1;

            if (dataGridView1.Rows.Count - 1 > select) {
                dataGridView1.Rows[Convert.ToInt32(select)].Selected = true;
                nickname.Text = inputusername.Text = (dataGridView1.Rows[Convert.ToInt32( select)].Cells[1].Value).ToString();
                inputpassword.Text = (dataGridView1.Rows[Convert.ToInt32(select)].Cells[2].Value).ToString();

                //加载验证码
                LoadCode();
            }
            else
            {
                accSelectNo = 0;
                auto = false;
                listBox1.Items.Add("半自动执行结束");
            }
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }
        private void auto2()
        {
            //如果已终止
            if (!auto) { return; }

            if (Login())
            {
                //入会
                if (radioButton1.Checked) { ruhui(); }
                //签到
                if (radioButton2.Checked) { qiandao(); };
                //仅登陆
                if (radioButton3.Checked) { };
                //绑定昵称
                if (checkBoxNickName.Checked) { bindnickname(); }
                //清空cookie
                cc = new CookieContainer();
                //todo 读取参数，账号列表及当前序号
                decimal select = numericUpDown1.Value + accSelectNo - 1;
                dataGridView1.Rows[Convert.ToInt32(select)].Selected = false;
                accSelectNo++;
                auto1();
            }
            else
            {
                //验证码等错误
                //等待重新输入



            }


        }

        private void suijinicheng(object sender, EventArgs e)
        {
            suijinicheng();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //清楚验证码
            code.Text = "";
            pictureBox1.Image = getImg("https://sso.woniu.com/captcha", "", ref cc);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            auto1();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form f = Application.OpenForms["help"];  //查找是否打开过Form1窗体  
            if (f == null)  //没打开过  
            {
                help fa = new help();
                fa.Show();   //重新new一个Show出来  
            }
            else
            {
                f.Focus();   //打开过就让其获得焦点  
            }
        }
    }

}

