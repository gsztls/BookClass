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
            //NeedDay = Convert.ToInt32(dtSystem.Tables[0].Rows[0][2].ToString());
            NeedDay = Convert.ToInt32(dtSystem.Tables[0].Rows[0][1].ToString());
        }
        if (!IsPostBack)
        {
            DropTimeBind();
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
    public void DropTimeBind()//以下代码为Drop_StartTime 、Drop_EndTime绑定数据
    {

        ArrayList ArrTime = new ArrayList();
        for (int i = NeedDay ; i <= BookDay; i++)
        {
            int IntSelectYear = DateTime.Now.AddDays(i).Year;
            int IntSelectMonth = DateTime.Now.AddDays(i).Month;
            int IntSelectDay = DateTime.Now.AddDays(i).Day;
            string SelectDate = IntSelectYear.ToString() + "年" + IntSelectMonth.ToString() + "月" + IntSelectDay.ToString() + "日";
            //for (int j = 0; j <= DtClass.Tables[0].Rows.Count; i++)
            //{
            //    DataSet DsBook = SqlHelper.ExecuteDataset(CommandType.Text, "SELECT * FROM [BookClass].[dbo].[BookList] WHERE Address ='"+DtClass.Tables[0].Rows[1][j]+"'AND ClassNum='"+DtClass.Tables[0].Rows[2][j]+"'");
            //    if (DsBook.Tables[0].Rows.Count != 6 && DtClass.Tables[0].Rows.Count != 0)
            //    {
            //        SqlHelper.ExecuteNonQuery(CommandType.Text, "INSERT INTO [BookClass].[dbo].[BookList](Address,ClassNum,BookDate,StartTime,EndTime,IsBooked) VALUES ('" + DtClass.Tables[0].Rows[1][j].ToString() + "','" + DtClass.Tables[0].Rows[2][j].ToString() + "','" + SelectDate + "','8:00', '10:00','0')");
            //        SqlHelper.ExecuteNonQuery(CommandType.Text, "INSERT INTO [BookClass].[dbo].[BookList](Address,ClassNum,BookDate,StartTime,EndTime,IsBooked) VALUES ('" + DtClass.Tables[0].Rows[1][j].ToString() + "','" + DtClass.Tables[0].Rows[2][j].ToString() + "','" + SelectDate + "','10:00','12:00','0')");
            //        SqlHelper.ExecuteNonQuery(CommandType.Text, "INSERT INTO [BookClass].[dbo].[BookList](Address,ClassNum,BookDate,StartTime,EndTime,IsBooked) VALUES ('" + DtClass.Tables[0].Rows[1][j].ToString() + "','" + DtClass.Tables[0].Rows[2][j].ToString() + "','" + SelectDate + "','12:00','14:00','0')");
            //        SqlHelper.ExecuteNonQuery(CommandType.Text, "INSERT INTO [BookClass].[dbo].[BookList](Address,ClassNum,BookDate,StartTime,EndTime,IsBooked) VALUES ('" + DtClass.Tables[0].Rows[1][j].ToString() + "','" + DtClass.Tables[0].Rows[2][j].ToString() + "','" + SelectDate + "','14:00','18:00','0')");
            //        SqlHelper.ExecuteNonQuery(CommandType.Text, "INSERT INTO [BookClass].[dbo].[BookList](Address,ClassNum,BookDate,StartTime,EndTime,IsBooked) VALUES ('" + DtClass.Tables[0].Rows[1][j].ToString() + "','" + DtClass.Tables[0].Rows[2][j].ToString() + "','" + SelectDate + "','19:00','21:00','0')");
            //        SqlHelper.ExecuteNonQuery(CommandType.Text, "INSERT INTO [BookClass].[dbo].[BookList](Address,ClassNum,BookDate,StartTime,EndTime,IsBooked) VALUES ('" + DtClass.Tables[0].Rows[1][j].ToString() + "','" + DtClass.Tables[0].Rows[2][j].ToString() + "','" + SelectDate + "','21:00','23:00','0')");
            //    }
            //}
            ArrTime.Add(SelectDate);
        }
        Drop_StartTime.DataSource = ArrTime;
        Drop_StartTime.DataBind();
        if (Drop_EndTime.DataSource == null)
        {
            Drop_EndTime.DataSource = ArrTime;
            Drop_EndTime.DataBind();
        }
    }

    public void CheckLogin() //以下代码检测用户登录参数是否正确
    {

        String StuId = (string)Session["StuId"];
        DataSet dt = SqlHelper.ExecuteDataset(CommandType.Text, "SELECT * FROM [BookClass].[dbo].[UserInfo] WHERE StuId ='" + StuId + "'AND Type = 'Student'");
        if (dt.Tables[0].Rows.Count == 0)
        {
            Session.Abandon();
            Console.Write("您的参数有误，请尝试重新登录。");
            //  System.Threading.Thread.Sleep(10000); 
            Response.Redirect("login.aspx");
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

    protected void Drop_StartTime_SelectedIndexChanged(object sender, EventArgs e)   //开始时间改变后为Drop_EndTime绑定数据
    {
        ArrayList ArrEndTime = new ArrayList();
        DateTime StartTime = Convert.ToDateTime(Drop_StartTime.SelectedValue.ToString());
        for (int i = 0; i <= NeedDay; i++)
        {
            int IntSelectEndYear = StartTime.AddDays(i).Year;
            int IntSelectEndMonth = StartTime.AddDays(i).Month;
            int IntSelectEndDay = StartTime.AddDays(i).Day;
            if (IntSelectEndDay > DateTime.Now.Day + NeedDay) break;
            string SelectEndDate = IntSelectEndYear.ToString() + "年" + IntSelectEndMonth.ToString() + "月" + IntSelectEndDay.ToString() + "日";
            ArrEndTime.Add(SelectEndDate);
        }
        Drop_EndTime.DataSource = ArrEndTime;
        Drop_EndTime.DataBind();
    }

    protected void GridView_BookListBind()    //为GridView绑定数据
    {
        if (Drop_Address.SelectedValue == "——请选择——")
        {
            Response.Write("<script>alert('请选择教室地址和编号！')</script>");
            return;
        }
        DataSet DtClass = SqlHelper.ExecuteDataset(CommandType.Text, "SELECT * FROM [BookClass].[dbo].[ClassList] WHERE [Address]='"+Drop_Address.SelectedValue+"' AND [ClassNum] ='"+Drop_ClassNum.SelectedValue+"'");
        SqlDataAdapter AdaBook = new SqlDataAdapter("SELECT ID,Address,ClassNum,BookDate,StartTime,EndTime , IsBooked  FROM [BookList]", strcon);
        DataTable DtBook = new DataTable();
        AdaBook.Fill(DtBook);
        DataTable DtGrid = DtBook;
        DtGrid.Rows.Clear();
        string[] DayStartClock = new string[] { "8:00", "10:00", "12:00", "14:00", "16:00", "19:00", "21:00" };
        string[] DayEndClock = new string[] { "10:00", "12:00", "14:00", "16:00", "18:00", "21:00", "23:00" };
        DateTime AssStartDate = Convert.ToDateTime(Drop_StartTime.SelectedValue);
        DateTime AssEndDate = Convert.ToDateTime(Drop_StartTime.SelectedValue);
        int RowsCount=0;
        for (int i = 0; i < DtClass.Tables[0].Rows.Count; i++)
        {
            for (int k = 0; k <= BookDay ; k++)
            {
                DateTime RAssDate = AssStartDate.AddDays(k);
                for (int l = 0; l < DayStartClock.Count(); l++)      //按时段检索修改DtGrid
                {
                    RowsCount += 1;
                    DataSet DsBook = SqlHelper.ExecuteDataset(CommandType.Text, "SELECT * FROM [BookClass].[dbo].[BookList] WHERE [Address] = '" + DtClass.Tables[0].Rows[i]["Address"] + "' AND ClassNum = '" + DtClass.Tables[0].Rows[i]["ClassNum"] + "' AND BookDate = '" + RAssDate.ToLongDateString() + "' AND StartTime = '" + DayStartClock[l] + "' AND IsBooked <>'3'");
                    if (DsBook.Tables[0].Rows.Count > 0)
                    {
                        DtGrid.Rows.Add( RowsCount ,DtClass.Tables[0].Rows[i]["Address"], DtClass.Tables[0].Rows[i]["ClassNum"], RAssDate.ToLongDateString(), DayStartClock[l], DayEndClock[l], "已预约");
                    }
                    else 
                    {
                        DtGrid.Rows.Add( RowsCount , DtClass.Tables[0].Rows[i]["Address"], DtClass.Tables[0].Rows[i]["ClassNum"], RAssDate.ToLongDateString(), DayStartClock[l], DayEndClock[l], "可预约");
                    }
                    
                }
                if (RAssDate.ToLongDateString() == Drop_EndTime.SelectedValue) break;
            }
        }
        GridView_BookList.DataSource = DtGrid;
        GridView_BookList.DataKeyNames = new string[] { "ID" };
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
        CheckLogin();
        string ID = GridView_BookList.DataKeys[e.RowIndex].Value.ToString(); 
        string Address = ((Label)(GridView_BookList.Rows[e.RowIndex].FindControl("Label1"))).Text.ToString().Trim();
        string ClassNum = ((Label)(GridView_BookList.Rows[e.RowIndex].FindControl("Label2"))).Text.ToString().Trim();
        string BookDate = ((Label)(GridView_BookList.Rows[e.RowIndex].FindControl("Label3"))).Text.ToString().Trim();
        string StartTime = ((Label)(GridView_BookList.Rows[e.RowIndex].FindControl("Label4"))).Text.ToString().Trim();
        string EndTime = ((Label)(GridView_BookList.Rows[e.RowIndex].FindControl("Label5"))).Text.ToString().Trim();
        string IsBooked = "等待管理员通过";
        string BookStuNum = (string)Session["StuId"];
        DataSet DsUserinfo = SqlHelper.ExecuteDataset(CommandType.Text,"SELECT * FROM [BookClass].[dbo].[UserInfo] WHERE StuId = '"+BookStuNum+"'");
        string BookStuName = DsUserinfo.Tables[0].Rows[0]["UserName"].ToString();
        string BookReason = ((TextBox)(GridView_BookList.Rows[e.RowIndex].FindControl("TextBox1"))).Text.ToString().Trim();
        DataSet DsBookList = SqlHelper.ExecuteDataset(CommandType.Text, "SELECT * FROM [BookClass].[dbo].[BookList] WHERE Address = '"+Address+"' AND ClassNum ='"+ClassNum+"' AND BookDate = '"+BookDate+"' AND StartTime = '"+StartTime+"'AND IsBooked = '等待管理员通过'");
        DataSet DsBookList1 = SqlHelper.ExecuteDataset(CommandType.Text, "SELECT * FROM [BookClass].[dbo].[BookList] WHERE Address = '" + Address + "' AND ClassNum ='" + ClassNum + "' AND BookDate = '" + BookDate + "' AND StartTime = '" + StartTime + "'AND IsBooked = '管理员已同意'");
        if (DsBookList.Tables[0].Rows.Count>0 || DsBookList1.Tables[0].Rows.Count >0)
        {
            Response.Write("<script>alert('此教室已经被预约！')</script>");
            GridView_BookList.EditIndex = -1;
            GridView_BookListBind();
            return;
        }
        if (BookReason == "")
        {
            Response.Write("<script>alert('预约用途不能为空！')</script>");
            return;
        }
        int JudgeNum = SqlHelper.ExecuteNonQuery(CommandType.Text,"INSERT INTO [BookClass].[dbo].[BookList](Address,ClassNum,BookDate,StartTime,EndTime,BookStuNum,IsBooked,BookReason,BookStuName) VALUES ('"+Address+"','"+ClassNum+"','"+BookDate+"','"+StartTime+"','"+EndTime+"','"+BookStuNum+"','"+IsBooked+"','"+BookReason+"','"+BookStuName+"')");
        GridView_BookList.EditIndex = -1;
        GridView_BookListBind();
        if (JudgeNum > 0)
        {
            Response.Write("<script>alert('预约成功，请等待管理员审核。')</script>");
        }
        else
        {
            Response.Write("<script>alert('预约失败。')</script>");
            return;
        }
    }
}