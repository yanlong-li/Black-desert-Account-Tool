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
using Dama2Lib;
using System.Drawing.Imaging;
using System.Threading.Tasks;

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


        private bool debug = false;

        //帮助窗体
        public static help help;

        //半自动状态
        private bool auto = false;


        //dama2
        //private uint ulRequestID = 0;
        private uint ulVCodeID = 0;

        private String m_softKey = "a355b6d8f99298dad0371fd341a2584a";







        public Form1()
        {
            InitializeComponent();
            startopentext = DateTime.Now;
            listBox1.Items.Add(startopentext.ToString());
            listBox1.Items.Add("请选择账号文件");
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
            CheckForIllegalCrossThreadCalls = false;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = this.openFileDialog1;
            openFileDialog.InitialDirectory = Application.StartupPath;
            //openFileDialog.ShowDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //return;
                listBox1.Items.Add(DateTime.Now.ToString());
                listBox1.Items.Add("已选择账号档案正在加载。。。。。。");
                listBox1.Items.Add("档案地址："+fName);
                listBox1.Items.Add(DateTime.Now.ToString());
                listBox1.Items.Add("加载成功正在分析。。。。。。");
                fName = openFileDialog.FileName.ToString();
                txtSelect.Text = fName;
                openFile(fName);
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
                if (debug) { 
                foreach (Cookie ck in response.Cookies)
                {
                    listBox1.Items.Add(ck.Name + ":" + ck.Value);
                }
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
            try { 
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
                    if (debug) { 
                foreach(Cookie ck in response.Cookies)
                {
                    listBox1.Items.Add(ck.Name+":"+ck.Value);
                }
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
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
                return "URL错误";
            }

        }
        #endregion

        private void rwtxt(string Txt,string filename= "log.txt")
        {
            if (!debug) { return; }
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
                if (debug)
                {
                    foreach (Cookie ck in response.Cookies)
                    {
                        listBox1.Items.Add(ck.Name + ":" + ck.Value);
                    }
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

        public byte[] ImageToBytes(Image image)
        {
            ImageFormat format = image.RawFormat;
            using (MemoryStream ms = new MemoryStream())
            {
                if (format.Equals(ImageFormat.Jpeg))
                {
                    image.Save(ms, ImageFormat.Jpeg);
                }
                else if (format.Equals(ImageFormat.Png))
                {
                    image.Save(ms, ImageFormat.Png);
                }
                else if (format.Equals(ImageFormat.Bmp))
                {
                    image.Save(ms, ImageFormat.Bmp);
                }
                else if (format.Equals(ImageFormat.Gif))
                {
                    image.Save(ms, ImageFormat.Gif);
                }
                else if (format.Equals(ImageFormat.Icon))
                {
                    image.Save(ms, ImageFormat.Icon);
                }
                byte[] buffer = new byte[ms.Length];
                //Image.Save()会改变MemoryStream的Position，需要重新Seek到Begin
                ms.Seek(0, SeekOrigin.Begin);
                ms.Read(buffer, 0, buffer.Length);
                return buffer;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("调试模式已关闭");
            if (debug)
            {
                debug = false;
                MessageBox.Show("调试模式已关闭");
            }
            else
            {
                debug = true;
                MessageBox.Show("调试模式已开启");
            }
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
            if (Addressbar.Text.Length <= 3) { return; }
            //获取get返回内容
            content = SendDataByGET(Addressbar.Text, "", ref cc);

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
            if (guild_id.Text.Length<=1) { MessageBox.Show("请填写工会ID");return; }
            accSelectNo = 0;
            if (auto)
            {
                auto = false;
                button11.Text = "自动操作";
            }
            else
            {
                auto = true;
                button11.Text = "停止";
                var task1 = new Task(() =>
                {
                    auto1();
                });
                task1.Start();
                //task1.e
            }
            
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
            rwtxt(content, "getLogin.html");

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


            //调试打印返回内容
            rwtxt(content, "postLogin.html");

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
                        dataGridView1.Rows[Convert.ToInt32(numericUpDown1.Value + accSelectNo - 1)].Cells[3].Value = "2";
                        Dama2.ReportResult(ulVCodeID,0);
                }
                listBox1.Items.Add("您输入的验证码错误");
                //重新加载验证码
                //pictureBox1.Image = getImg("https://sso.woniu.com/captcha", "", ref cc);
                auto1();
                return false;
            }
            else if (Regex.IsMatch(content, "登录成功") || Regex.IsMatch(content, "您已经成功登录中央认证系统"))
            {
                if (auto)
                {
                    dataGridView1.Rows[Convert.ToInt32(numericUpDown1.Value + accSelectNo-1)].Cells[3].Value = "1";
                }
                listBox1.Items.Add(inputusername.Text+":账号登陆成功");
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
            else if (Regex.IsMatch(content, "您输入的帐号不存在"))
            {
                if (auto)
                {
                    dataGridView1.Rows[Convert.ToInt32(numericUpDown1.Value + accSelectNo - 1)].Cells[3].Value = "5";
                }
                listBox1.Items.Add("您输入的帐号不存在");
                return false;
            }else if (Regex.IsMatch(content, "为了您账号安全，请前往蜗牛盾内确认本次登录。"))
            {
                listBox1.Items.Add("暂不支持开启蜗牛盾账号！");

                if (auto)
                {
                    dataGridView1.Rows[Convert.ToInt32(numericUpDown1.Value + accSelectNo - 1)].Cells[3].Value = "6";
                    return true;
                }
                
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


            //清空附加url参数
            tmpurl = "";

            //二次不带参数请求url地址
            string Urlcontent = this.SendDataByPost("https://sso.woniu.com/login_embedded?service=http://gwact.woniu.com/passport/ssologin?goto=http://www.woniu.com/account/ssoLoginSuccess.html&regurl=http://www.woniu.com/account/register/?gameid=105&pagename=http://bd.woniu.com&goto=http://bd.woniu.com/static/guild/index.html", "", ref cc);


            string Regexstr = @"href\s*=\s*\""(?<url>[\w:/?=.&-_]*)";

            Match Url = Regex.Match(Urlcontent, Regexstr);
            if (debug) { 
                listBox1.Items.Add("返回URL：" + Url.Groups[1].ToString());
            }
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
            if (sss[2].ToString() != "1")
            {
                if (auto)
                {
                    dataGridView1.Rows[Convert.ToInt32(numericUpDown1.Value + accSelectNo - 1)].Cells[4].Value = Decode(sss[4].ToString());
                }
                listBox1.Items.Add("昵称绑定失败:" + sss[2] + "    错误信息:" + Decode(sss[4].ToString()));
            }
            else
            {
                if (auto)
                {
                    dataGridView1.Rows[Convert.ToInt32(numericUpDown1.Value + accSelectNo - 1)].Cells[4].Value = "1";
                }
                listBox1.Items.Add("昵称绑定成功:" + sss[2] + "    返回信息:" + Decode(sss[4].ToString()));
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
                listBox1.Items.Add("入会失败:" + sss[1] + "    错误信息:" + Decode(sss[3].ToString()));
            }
            else
            {
                if (auto)
                {
                    dataGridView1.Rows[Convert.ToInt32(numericUpDown1.Value + accSelectNo - 1)].Cells[4].Value = "1";
                }
                listBox1.Items.Add("入会提交:" + sss[1] + "    返回信息:" + Decode(sss[3].ToString()));
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
                listBox1.Items.Add("签到失败:" + sss[1] + "    返回信息:" + Decode(sss[3].ToString()));
            }
            else
            {
                if (auto)
                {
                    dataGridView1.Rows[Convert.ToInt32(numericUpDown1.Value + accSelectNo - 1)].Cells[5].Value = "1";
                }
                listBox1.Items.Add("签到成功:" + sss[1] + "    返回信息:" + Decode(sss[3].ToString()));
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
                    if (checkBoxAutoDama2.Checked)
                    {
                        listBox1.Items.Add("当前已开启自动打码，手动打码无效");
                    }
                    else
                    {
                        Login();

                    }
                   
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

            if (!auto || (numericUpDown3.Value != 0 && accSelectNo>= numericUpDown3.Value) || accSelectNo+numericUpDown1.Value>numericUpDown2.Value) {
                accSelectNo = 0;
                auto = false;
                button11.Text = "自动操作";
                listBox1.Items.Add("自动执行结束");
                return;
            }

            //todo 读取参数，账号列表及当前序号
            decimal select =  numericUpDown1.Value+ accSelectNo-1;

            if (dataGridView1.Rows.Count - 1 > select) {
                dataGridView1.Rows[Convert.ToInt32(select)].Selected = true;
                label17.Text = (dataGridView1.Rows[Convert.ToInt32(select)].Cells[0].Value).ToString();
                inputusername.Text = (dataGridView1.Rows[Convert.ToInt32( select)].Cells[1].Value).ToString();
                string nicknamecc =  prefixNickName.Text + inputusername.Text;
                if (nicknamecc.Length > 8)
                {
                    nicknamecc = nicknamecc.Substring(0, 7);
                }
                nickname.Text = nicknamecc;
                inputpassword.Text = (dataGridView1.Rows[Convert.ToInt32(select)].Cells[2].Value).ToString();
                //加载验证码
                LoadCode();

                if (checkBoxAutoDama2.Visible == true && checkBoxAutoDama2.Checked == true)
                {
                    //请求答题
                    byte[] pImageData = ImageToBytes(pictureBox1.Image);

                    StringBuilder VCodeText = new StringBuilder(100);

                    int ret = Dama2.D2Buf(m_softKey,dama2UsernameInput.Text,dama2PasswordInput.Text,pImageData, (uint)pImageData.Length, 120, 42, VCodeText);
                    if (ret > 0)
                    {
                        code.Text = VCodeText.ToString();
                        //写入该验证码ID；
                        ulVCodeID = (uint)ret;
                        auto2();
                    }
                    else if(ret == -101)
                    {
                        listBox1.Items.Add("打码兔余额不足");
                    }else if(ret == -206)
                    {
                        listBox1.Items.Add("请点击“重载打码兔”后登陆打码兔");
                    }
                    else
                    {
                        listBox1.Items.Add("识别验证码失败,正在重试");
                        var task1 = new Task(() =>
                        {
                            auto1();
                        });
                        task1.Start();
                    }
                }

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
                //1绑定昵称
                if (checkBoxNickName.Checked) { bindnickname(); }
                //2入会
                if (checkBoxruhui.Checked) { ruhui(); }
                //3签到
                if (checkBoxqiandao.Checked) { qiandao(); };
                //仅登陆
                //if (radioButton3.Checked) { };
                


                //清空cookie
                cc = new CookieContainer();
                listBox1.Items.Add(inputusername.Text + "：已关闭");


                //todo 读取参数，账号列表及当前序号
                decimal select = numericUpDown1.Value + accSelectNo - 1;
                dataGridView1.Rows[Convert.ToInt32(select)].Selected = false;
                accSelectNo++;
                if (numericUpDown4.Value > 0) { 
                    System.Threading.Thread.Sleep((int)numericUpDown4.Value*1000);
                }
                auto1();
            }
            else
            {
                //验证码等错误
                //等待重新输入
                LoadCode();


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
            accSelectNo++;
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            cc = new CookieContainer();
            if (inputusername.TextLength >= 1) { listBox1.Items.Add(inputusername.Text + ":已退出"); }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            accSelectNo--;
            auto1();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start( "http://www.dama2.com/index/ureg?tj=1982740&vali=9f808161627a93b5d658ed3c04c9e242");
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
        }

        private void button16_Click(object sender, EventArgs e)
        {
            uint pulBalance = 0;
            int ret = Dama2.D2Balance(m_softKey, dama2UsernameInput.Text, dama2PasswordInput.Text, ref pulBalance);
            if (ret == 0)
            {
                label14.Text = pulBalance.ToString();
            }
            else
            {
                label14.Text = "查询失败";
            }
        }
    }

}

