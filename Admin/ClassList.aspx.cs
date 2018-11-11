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

    protected void Log_Off(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("login.aspx");
    }

    protected void GridView_BookListBind()    //为GridView绑定数据
    {
        if (Drop_Address.SelectedValue == "——请选择——")
        {
            Response.Write("<script>alert('请选择教室地址和编号！')</script>");
            return;
        }
        DataSet DtClass = SqlHelper.ExecuteDataset(CommandType.Text, "SELECT * FROM [BookClass].[dbo].[ClassList] WHERE [Address]='" + Drop_Address.SelectedValue + "'");
        GridView_BookList.DataSourceID = null;
        GridView_BookList.DataSource = DtClass.Tables[0];
        GridView_BookList.DataBind();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        GridView_BookListBind();
        GridView_BookList.Visible = true;
    }
    protected void GridView_BookList_PageIndexChanging(object sender, GridViewPageEventArgs e)   //分页
    {
        GridView_BookList.PageIndex = e.NewPageIndex;
        GridView_BookListBind();
    }
    
}