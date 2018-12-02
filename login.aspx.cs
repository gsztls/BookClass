using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.Net;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
using System.Data;

public partial class login : System.Web.UI.Page
{
    private string client_id = "09d24e52ce2ade62";
    private string redirect_uri = "http://www.rosyclouds.top/";
    private string client_secret = "6ccc753fae0e45060e1b4d9e0f3b0b16";

    protected void Page_Load(object sender, EventArgs e)
    {
        readyLogin();
    }

    public void readyLogin()
    {
        string code = Request.QueryString["code"];
        if (code != null)
        {
            string responseToken = GetAccess_token(code, client_id, redirect_uri, client_secret);
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('" + responseToken + "');</script>");
            JObject o1 = JsonConvert.DeserializeObject<JObject>(responseToken);
            string access_token = o1.GetValue("access_token").ToString();
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('" + access_token + "');</script>");
            Response.Write("<script>alert('" + access_token + "')</script>");
            string responseUser = GetUserInfo(access_token);
            //Response.Write("<script>alert('" + responseUser + "')</script>");
            //Response.Write("<script>alert('" + responseUser + "')</script>");
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('" + responseUser + "');</script>");
            JObject o2 = JsonConvert.DeserializeObject<JObject>(responseUser);
            string info = o2.GetValue("info").ToString();
            JObject o3 = JsonConvert.DeserializeObject<JObject>(info);
            JObject jo = (JObject)JsonConvert.DeserializeObject(responseUser);
            string yb_username = o3.GetValue("yb_realname").ToString();
            //yb_username = (string)jo["yb_realname"];
            string yb_schoolname = o3.GetValue("yb_schoolname").ToString();
            //yb_username = (string)jo["yb_schoolname"];
            string yb_studentid = o3.GetValue("yb_studentid").ToString();
             //yb_username = jo["yb_studentid"].ToString();
            string yb_classname = o3.GetValue("yb_classname").ToString();
            // yb_username = jo["yb_classname"].ToString();
            string yb_collegename = o3.GetValue("yb_collegename").ToString();
            // yb_username = jo["yb_collegename"].ToString();
            string yb_employid = o3.GetValue("yb_employid").ToString();
            //  yb_username = jo["yb_employid"].ToString();
            //Response.Write("<script>alert('" + yb_username + "')</script>");
            // Response.Write("<script>alert('" + yb_schoolname + "')</script>");
            // Response.Write("<script>alert('" + yb_studentid + "')</script>");
            // Response.Write("<script>alert('" + yb_classname + "')</script>");
            // Response.Write("<script>alert('" + yb_collegename + "')</script>");
            checkUser(yb_studentid, yb_username, yb_schoolname, yb_collegename, yb_classname, yb_employid);
        }
        else
        {
            string url = "https://openapi.yiban.cn/oauth/authorize";
            string para = "client_id=" + client_id + "&" + "redirect_uri=" + redirect_uri + "&state=STATE";
            GetFunction(url, para);
        }
    }

    public static string GetAccess_token(string code, string client_id, string redirect_uri, string client_secret)
    {
        var url = "https://openapi.yiban.cn/oauth/access_token";
        byte[] byteArray = Encoding.UTF8.GetBytes(string.Format("client_id={0}&client_secret={1}&code={2}&redirect_uri={3}", client_id, client_secret, code, redirect_uri));
        HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(new Uri(url));
        webRequest.Method = "Post";
        webRequest.ContentType = "application/x-www-form-urlencoded";
        webRequest.ContentLength = byteArray.Length;
        Stream newStream = webRequest.GetRequestStream();
        newStream.Write(byteArray, 0, byteArray.Length);
        newStream.Close();
        HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
        StreamReader php = new StreamReader(response.GetResponseStream(), Encoding.Default);
        return php.ReadToEnd();
    }

    public static string GetUserInfo(string access_token)
    {
        var getUrl = "https://openapi.yiban.cn/user/verify_me";
        string url = getUrl + "?access_token=" + access_token;//请求地址 + 参数拼接
        int Timeout = 5000;
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "GET";
        request.ContentType = "text/html;charset=UTF-8";
        request.UserAgent = null;
        request.Timeout = Timeout;
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        Stream myResponseStream = response.GetResponseStream();
        StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
        string retString = myStreamReader.ReadToEnd();
        myStreamReader.Close();
        myResponseStream.Close();
        return retString;
    }

    public void checkUser(string schoolId, string user, string school, string college, string _class, string employId)
    {
        int judNum;
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('准备验证用户身份');</script>");
        if (user.Equals(null) || school.Equals(null) || college.Equals(null) || user.Equals("") || school.Equals("") || college.Equals(""))
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script>alert('未能成功获取用户信息，请确认是否将易班里的学校信息填写完整或者联系网站负责人。');window.location.href='http://www.yiban.cn/school/index/id/5000207';)</script>");
        if (school.Equals("中南大学"))
        {
            DataSet dt = SqlHelper.ExecuteDataset(CommandType.Text, "SELECT * FROM [BookClass].[dbo].[UserInfo] WHERE [StuId] = '" + schoolId + "'OR [StuId] = '" + employId +"'");
            if (dt.Tables[0].Rows.Count > 0)
            {
                if (dt.Tables[0].Rows[0]["Type"].Equals("manager"))
                {
                    Session["StuId"] = employId;
                    Response.Redirect("Admin/AdminIndex.aspx");
                }
                else if (dt.Tables[0].Rows[0]["Type"].Equals("instructor"))
                {
                    Session["StuId"] = employId;
                    Response.Redirect("index.aspx");
                }
                else
                {
                    Session["StuId"] = schoolId;
                    Response.Redirect("index.aspx");
                }
                Session["college"] = college;
                Session["name"] = user;
            }
            else if (!(employId.Equals("") || employId.Equals(null)))
            {
                Console.Write("<script>alert('此用户还没注册')</script>");
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script>alert('此用户还没注册')</script>");
                DataSet dt1 = SqlHelper.ExecuteDataset(CommandType.Text, "SELECT * FROM [BookClass].[dbo].[Instructor] WHERE [Name] = '" + user + "'");
                if (dt1.Tables[0].Rows.Count > 0)
                {
                    Session["StuId"] = employId;
                    Session["college"] = college;
                    Session["name"] = user;
                    //Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script>alert('管理员')</script>");
                    //judNum = SqlHelper.ExecuteNonQuery(CommandType.Text, "INSERT INTO [BookClass].[dbo].[UserInfo]([StuId],[UserName],[Type],[college]) VALUES('" + employId + "','" + user + "','manager','" + "','" + college + "')");
                    judNum = SqlHelper.ExecuteNonQuery(CommandType.Text, "INSERT INTO[BookClass].[dbo].[UserInfo] ([StuId],[Type],[UserName],[college]) VALUES('" + employId + "','manager','" + user + "', '" + college + "')");
                    Response.Redirect("Admin/AdminIndex.aspx");
                    return;
                }
                else
                {
                    Session["StuId"] = employId;
                    Session["college"] = college;
                    Session["name"] = user;
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script>alert('管理员')</script>");
                    judNum = SqlHelper.ExecuteNonQuery(CommandType.Text, "INSERT INTO[BookClass].[dbo].[UserInfo] ([StuId],[Type],[UserName],[college]) VALUES('" + employId + "','instructor','" + user + "', '" + college + "')");
                    Response.Redirect("index.aspx");
                    return;
                }
            }

            else if (schoolId.Equals(null) || schoolId.Equals(""))
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script>alert('无学号')</script>");
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script>alert('未能成功获取用户信息，请确认是否将易班里的学校信息填写完整或者联系网站负责人。');window.location.href='http://www.yiban.cn/school/index/id/5000207';)</script>");
            }
            else
            {
                Session["name"] = user;
                Session["college"] = college;
                Session["StuId"] = schoolId;
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script>alert('学生')</script>");
                judNum = SqlHelper.ExecuteNonQuery(CommandType.Text, "INSERT INTO [BookClass].[dbo].[UserInfo]([StuId],[Type],[UserName],[college]) VALUES('" + schoolId + "','Student','" + user + "', '" + college + "')");
                Response.Redirect("index.aspx");
            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script>alert('您暂时还没有权限使用该系统，请联系网站负责人。');window.location.href='http://www.yiban.cn/school/index/id/5000207';)</script>");
        }
    }

    public void GetFunction(string url, string para)
    {
        string serviceAddress = url + "?" + para;
        Response.Redirect(serviceAddress);
    }
}