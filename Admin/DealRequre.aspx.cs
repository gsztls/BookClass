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

public partial class RoomSelect : System.Web.UI.Page
{
    public int BookDay = 7;   //可提前预约的天数，默认可提前7天预约
    public int NeedDay = 3;  //需要提前预约天数，默认必须提前3天预约
    public string strcon = ConfigurationManager.AppSettings["strconnection"];

    protected void Page_Load(object sender, EventArgs e)
    {
        CheckLogin();

        //以下代码用于获取管理员设置的教室可提前预约的天数和需要提前预约的天数
        DataSet dtSystem = SqlHelper.ExecuteDataset(CommandType.Text, "SELECT * FROM [BookClass].[dbo].[System]");
        if (dtSystem.Tables[0].Rows[0][1] != null)    //如果有设置则为设置的值
        {
            BookDay = Convert.ToInt32(dtSystem.Tables[0].Rows[0][1].ToString());
        }
        if (dtSystem.Tables[0].Rows[0][2] != null)    //如果有设置则为设置的值
        {
            NeedDay = Convert.ToInt32(dtSystem.Tables[0].Rows[0][2].ToString());
        }
        if (!IsPostBack)
        {
            GridView_BookListStartBind();
        }
        //以下代码为Drop_Address绑定数据
        //string strcon = ConfigurationSettings.AppSettings["strconnection"];
        //SqlConnection con = new SqlConnection(strcon);
        //SqlDataAdapter adaAddress = new SqlDataAdapter("SELECT * FROM [BookClass].[dbo].[ClassList]", con);
        //DataSet ds = new DataSet();
        //adaAddress.Fill(ds);
        //Drop_Address.DataSource = ds.Tables[0];
        //Drop_Address.DataTextField="Address";
        //Drop_Address.DataValueField = "Address";
        //Drop_Address.DataBind();

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

    protected void Drop_Address_SelectedIndexChanged(object sender, EventArgs e)
    {
        //地址改变后改变对应的教室编号
        string strcon = ConfigurationManager.AppSettings["strconnection"];
        SqlConnection con = new SqlConnection(strcon);
        SqlDataAdapter adaClassNum = new SqlDataAdapter("SELECT * FROM [BookClass].[dbo].[ClassList] WHERE [Address]='" + Drop_Address.SelectedValue + "'", con);
        DataSet ds = new DataSet();
        adaClassNum.Fill(ds);
        Drop_ClassNum.DataSource = ds.Tables[0];
        Drop_ClassNum.DataSourceID = null;
        Drop_ClassNum.DataTextField = "ClassNum";
        Drop_ClassNum.DataValueField = "ClassNum";
        Drop_ClassNum.DataBind();
    }

    protected void GridView_BookListStartBind()    //初始时为GridView绑定数据
    {
        DataSet DtBook = SqlHelper.ExecuteDataset(CommandType.Text, "SELECT * FROM [BookClass].[dbo].[BookList] WHERE BookDate = '" + DateTime.Now.ToLongDateString() + "'AND IsBooked ='等待管理员通过'");
        for (int i = 1; i <= BookDay; i++)
        {
            DataSet DtBook1 = SqlHelper.ExecuteDataset(CommandType.Text, "SELECT * FROM [BookClass].[dbo].[BookList] WHERE BookDate = '" + DateTime.Now.AddDays(i).ToLongDateString() + "'AND IsBooked ='等待管理员通过'");
            DtBook.Merge(DtBook1);
        }
        GridView_BookList.DataSource = DtBook;
        GridView_BookList.DataKeyNames = new string[] { "ID" };  //给前端控件指定主键
        GridView_BookList.DataBind();
    }

    protected void GridView_BookListBind()    //为GridView绑定数据
    {
        if (Drop_Address.SelectedValue == "——请选择——")
        {
            Response.Write("<script>alert('请选择教室地址和编号！')</script>");
            return;
        }
        DataSet DtBook = SqlHelper.ExecuteDataset(CommandType.Text, "SELECT * FROM [BookClass].[dbo].[BookList] WHERE [Address]='" + Drop_Address.SelectedValue + "' AND [ClassNum] ='" + Drop_ClassNum.SelectedValue + "' AND BookDate = '" + DateTime.Now.ToLongDateString() + "'AND IsBooked ='等待管理员通过'");
        for (int i = 1; i <= BookDay; i++)
        {
            DataSet DtBook1 = SqlHelper.ExecuteDataset(CommandType.Text, "SELECT * FROM [BookClass].[dbo].[BookList] WHERE [Address]='" + Drop_Address.SelectedValue + "' AND [ClassNum] ='" + Drop_ClassNum.SelectedValue + "' AND BookDate = '" + DateTime.Now.AddDays(i).ToLongDateString() + "' AND IsBooked ='等待管理员通过'");
            DtBook.Merge(DtBook1);
        }
        GridView_BookList.DataSource = DtBook;
        GridView_BookList.DataKeyNames = new string[] { "ID" };
        GridView_BookList.DataBind();
    }

    protected void Button1_Click(object sender, EventArgs e)   //点击查询后执行
    {
        GridView_BookListBind();
        GridView_BookList.Visible = true;
    }
    protected void GridView_BookList_PageIndexChanging(object sender, GridViewPageEventArgs e)   //分页
    {
        GridView_BookList.PageIndex = e.NewPageIndex;
        GridView_BookListStartBind();
    }
    protected void GridView_BookList_RowEditing(object sender, GridViewEditEventArgs e)  //点击查看后转到相应页面
    {
        GridView_BookList.EditIndex = e.NewEditIndex;
        GridView_BookListStartBind();
    }
    protected void GridView_BookList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)   //点击取消返回
    {
        GridView_BookList.EditIndex = -1;
        GridView_BookListStartBind();
    }
    protected void GridView_BookList_RowUpdating(object sender, GridViewUpdateEventArgs e)  //点击同意后执行
    {
        string ID = GridView_BookList.DataKeys[e.RowIndex].Value.ToString();  //获取当前行数的主键
        int JudgeNum = SqlHelper.ExecuteNonQuery(CommandType.Text, "UPDATE [BookClass].[dbo].[BookList] SET IsBooked ='管理员已同意'WHERE ID ='" + ID + "'");
        GridView_BookList.EditIndex = -1;   //返回之前的页面
        GridView_BookListStartBind();
        if (JudgeNum > 0)
        {
            Response.Write("<script>alert('同意成功！')</script>");
            
        }
        else
        {
            Response.Write("<script>alert('同意失败！')</script>");
            return;
        }
    }
    protected void GridView_BookList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string ID = GridView_BookList.DataKeys[e.RowIndex].Value.ToString(); 
        int JudgeNum = SqlHelper.ExecuteNonQuery(CommandType.Text, "UPDATE [BookClass].[dbo].[BookList] SET IsBooked ='被管理员拒接'WHERE ID ='" + ID + "'");
        GridView_BookList.EditIndex = -1;
        GridView_BookListStartBind();
        if (JudgeNum > 0)
        {
            Response.Write("<script>alert('拒绝成功！')</script>");
        }
        else
        {
            Response.Write("<script>alert('拒绝失败！')</script>");
            return;
        }
    }
}
