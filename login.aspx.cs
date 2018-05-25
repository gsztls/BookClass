using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        string name = login_num.Text;
        string pwd = login_pwd.Text;
        if (name == "" || pwd == "")
        {
            Response.Write("<script>alert('请将登录信息填写完整！');</script>");
            return;
        }
        DataSet dt =SqlHelper.ExecuteDataset(CommandType.Text,"SELECT * FROM [BookClass].[dbo].[Admin] WHERE StuId ='"+name+"' AND Password = '"+pwd+"'");
        if(dt.Tables[0].Rows.Count >0)
            {
                Session["StuId"] = name;
                     //if(Request.Cookies["StuID"].Value == null)
                     //{
                     //    Response.Cookies["StuId"].Value =name;
                     //    Response.Cookies["Password"].Value =pwd;
                     //}
                Response.Redirect("index.aspx");
            }
        else
            {
                Response.Write("<script>alert('用户名或密码错误！');</script>");
                return;
            }
   }
}