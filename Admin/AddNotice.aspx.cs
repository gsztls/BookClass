using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class Notice : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckLogin();
    }
    public void CheckLogin() //以下代码检测用户登录参数是否正确
    {

        String StuId = (string)Session["StuId"];
        DataSet dt = SqlHelper.ExecuteDataset(CommandType.Text, "SELECT * FROM [BookClass].[dbo].[UserInfo] WHERE StuId ='" + StuId + "'AND Type = '管理员'");
        if (dt.Tables[0].Rows.Count == 0)
        {
            Session.Abandon();
            Console.Write("您的参数有误，请尝试重新登录。");
            //  System.Threading.Thread.Sleep(10000); 
            Response.Redirect("../login.aspx");
            return;
        }
        else
        {
            DataSet dt1 = SqlHelper.ExecuteDataset(CommandType.Text, "SELECT * FROM [BookClass].[dbo].[UserInfo] WHERE StuId ='" + StuId + "'");
            label_stuNum.Text = dt1.Tables[0].Rows[0][1].ToString();
            label_user.Text = dt1.Tables[0].Rows[0][3].ToString();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string Title = TxtTitle.Text;
        string Text = TxtText.Text;
        string Time = DateTime.Now.ToLongDateString();
        if (Title == "" || Text == "")
        {
            Response.Write("alert('信息输入不完整！')");
            return;
        }
        int JudgeNum = SqlHelper.ExecuteNonQuery(CommandType.Text,"INSERT INTO [BookClass].[dbo].[Notice](Title , Text , Time) VALUES ('"+Title+"','"+Text+"','"+Time+"')");
        if (JudgeNum > 0)
        {
            Response.Write("<script>alert('添加成功！');window.location = 'ManageNotice.aspx';</script>");
        }
        else
        {
            Response.Write("<script>alert('添加失败！');</script>");
            return;
        }
    }
}