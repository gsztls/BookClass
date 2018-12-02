using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;


public partial class ClassList : System.Web.UI.Page
{

    public string strcon = ConfigurationManager.AppSettings["strconnection"];

    protected void Page_Load(object sender, EventArgs e)
    {
        CheckLogin();
        if (!IsPostBack)
        {
            GridView_BookListBind();
        }

    }

    public void CheckLogin() //以下代码检测用户登录参数是否正确
    {

        String StuId = (string)Session["StuId"];
        DataSet dt = SqlHelper.ExecuteDataset(CommandType.Text, "SELECT * FROM [BookClass].[dbo].[UserInfo] WHERE StuId ='" + StuId + "'AND Type = 'manager'");
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

    protected void GridView_BookList_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
     //  string ID = GridView_BookList.DataKeys[e.RowIndex].Value.ToString();
       string Address = ((TextBox)(GridView_BookList.Rows[e.RowIndex].FindControl("TextBox3"))).Text.ToString().Trim();
       string ClassNum = ((TextBox)(GridView_BookList.Rows[e.RowIndex].FindControl("TextBox4"))).Text.ToString().Trim();
       if (Address == "" || ClassNum == "")
       {
           Response.Write("<script>alert('请将信息填写完整！')</script>");
           return;
       }
       DataSet DsClass = SqlHelper.ExecuteDataset(CommandType.Text,"SELECT * FROM [BookClass].[dbo].[ClassList] WHERE Address = '"+Address+"' AND ClassNum = '"+ClassNum+"'");
       if (DsClass.Tables[0].Rows.Count > 0)
       {
           Response.Write("<script>alert('该教室已经存在！')</script>");
           return;
       }
       int JudgeNum = SqlHelper.ExecuteNonQuery(CommandType.Text, "INSERT INTO [BookClass].[dbo].[ClassList](Address,ClassNum) VALUES ('" + Address + "','" + ClassNum + "')");
       if (JudgeNum > 0)
       {
           Response.Write("<script>alert('添加成功！');location.href='ClassManagement.aspx';</script>");
       }
       else
       {
           Response.Write("<script>alert('添加失败！')</script>");
           return;
       }
        
    }
    protected void GridView_BookListBind()    //为GridView绑定数据
    {
        DataSet DtClass = SqlHelper.ExecuteDataset(CommandType.Text, "SELECT TOP 1 * FROM [BookClass].[dbo].[ClassList] ");
        GridView_BookList.DataSourceID = null;
        GridView_BookList.DataSource = DtClass.Tables[0];
        GridView_BookList.DataKeyNames = new string[] { "ID" };
        GridView_BookList.DataBind();
    }

}