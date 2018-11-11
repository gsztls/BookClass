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
            GridView_BookListStartBind();
        }

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
        DataSet DtClass = SqlHelper.ExecuteDataset(CommandType.Text, "SELECT * FROM [BookClass].[dbo].[ClassList] WHERE [Address]='" + Drop_Address.SelectedValue + "'");
        GridView_BookList.DataSourceID = null;
        GridView_BookList.DataSource = DtClass.Tables[0];
        GridView_BookList.DataKeyNames = new string[] { "ID" };
        GridView_BookList.DataBind();
    }

    protected void GridView_BookListStartBind()    //为GridView绑定数据
    {
        DataSet DtClass = SqlHelper.ExecuteDataset(CommandType.Text, "SELECT * FROM [BookClass].[dbo].[ClassList]");
        GridView_BookList.DataSourceID = null;
        GridView_BookList.DataSource = DtClass.Tables[0];
        GridView_BookList.DataKeyNames = new string[] { "ID" };
        GridView_BookList.DataBind();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        GridView_BookListBind();
    }
    protected void GridView_BookList_PageIndexChanging(object sender, GridViewPageEventArgs e)   //分页
    {
        GridView_BookList.PageIndex = e.NewPageIndex;
        GridView_BookListBind();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddClass.aspx");
    }
    protected void GridView_BookList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView_BookList.EditIndex = e.NewEditIndex;
        GridView_BookListBind();
    }
    protected void GridView_BookList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView_BookList.EditIndex = -1;
        GridView_BookListBind();
    }
    protected void GridView_BookList_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string ID = GridView_BookList.DataKeys[e.RowIndex].Value.ToString(); 
        string Address = ((TextBox)(GridView_BookList.Rows[e.RowIndex].FindControl("TextBox1"))).Text.ToString().Trim();
        string ClassNum = ((TextBox)(GridView_BookList.Rows[e.RowIndex].FindControl("TextBox2"))).Text.ToString().Trim();
        int JudgeNum = SqlHelper.ExecuteNonQuery(CommandType.Text,"UPDATE [BookClass].[dbo].[BookList] SET Address='"+Address+"',ClassNum='"+ClassNum+"'");
        GridView_BookList.EditIndex = -1;
        GridView_BookListBind();
        if (JudgeNum > 0)
        {
            Response.Write("<script>alert('修改成功，请等待管理员审核。')</script>");
        }
        else
        {
            Response.Write("<script>alert('修改失败。')</script>");
            return;
        }
    }
    protected void GridView_BookList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string ID = GridView_BookList.DataKeys[e.RowIndex].Value.ToString();
        int JudgeNum = SqlHelper.ExecuteNonQuery(CommandType.Text, "DELETE FROM [BookClass].[dbo].[ClassList] WHERE ID='" + ID  + "'");
        GridView_BookListStartBind();
        if (JudgeNum > 0)
        {
            Response.Write("<script>alert('删除成功！')</script>");
        }
        else
        {
            Response.Write("<script>alert('删除失败！')</script>");
            return;
        }
    }
}