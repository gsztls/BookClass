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