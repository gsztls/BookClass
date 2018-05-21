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
    public string strcon = ConfigurationManager.AppSettings["strconnection"];
    public DataSet DtClass = SqlHelper.ExecuteDataset(CommandType.Text, "SELECT * FROM [BookClass].[dbo].[ClassList]");

    protected void Page_Load(object sender, EventArgs e)
    {
       // CheckLogin();

        //以下代码用于获取管理员设置的教室可提前预约的天数
        DataSet dtSystem = SqlHelper.ExecuteDataset(CommandType.Text, "SELECT * FROM [BookClass].[dbo].[System]");
        if (dtSystem.Tables[0].Rows[0][1] != null)    //如果有设置则为设置的值
        {
            BookDay = Convert.ToInt32(dtSystem.Tables[0].Rows[0][1].ToString());
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
        for (int i = 0; i <= BookDay; i++)
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
        DataSet dt = SqlHelper.ExecuteDataset(CommandType.Text, "SELECT * FROM [BookClass].[dbo].[Admin] WHERE StuId ='" + StuId + "'");
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
        DateTime StartTime = Convert.ToDateTime(Drop_StartTime.SelectedValue .ToString());
        for (int i = 0; i <= BookDay; i++)
        {
            int IntSelectEndYear = StartTime.AddDays(i).Year;
            int IntSelectEndMonth = StartTime.AddDays(i).Month;
            int IntSelectEndDay = StartTime.AddDays(i).Day;
            if (IntSelectEndDay > DateTime.Now.Day + BookDay) break;
            string SelectEndDate = IntSelectEndYear.ToString() + "年" + IntSelectEndMonth.ToString() + "月" + IntSelectEndDay.ToString() + "日";
            ArrEndTime.Add(SelectEndDate);
        }
        Drop_EndTime.DataSource = ArrEndTime;
        Drop_EndTime.DataBind();
    }

    protected void GridView_BookListBind()    //为GridView绑定数据
    {
        SqlDataAdapter AdaBook = new SqlDataAdapter("SELECT Address AS '地址',ClassNum AS '教室编号',BookDate AS '预约日期',StartTime AS '开始时间',EndTime AS '结束时间' , IsBooked AS '预约情况' FROM [BookList] WHERE Address = '"+Drop_Address.SelectedValue+"' AND ClassNum='"+Drop_ClassNum.SelectedValue+"' AND BookDate ='"+Drop_StartTime+"' AND IsBooked ='1'", strcon);
        DataTable DtBook = new DataTable();
        AdaBook.Fill(DtBook);
        DataTable DtGrid =DtBook;
        DtGrid.Rows.Clear();
        string [] DayStartClock = new string[]{"8:00","10:00","12:00","14:00","16:00","19:00","21:00" };
        string[] DayEndClock = new string[] { "10:00", "12:00", "14:00", "16:00", "18:00", "21:00", "23:00"};
        for (int i = 0; i < DtClass.Tables[0].Rows.Count; i++ )
        {
            for (int j = 0; j <= DtBook.Rows.Count; j++)
            {
                if (DtClass.Tables[0].Rows[i]["Address"] == DtBook.Rows[j]["Address"] && DtClass.Tables[0].Rows[i]["ClassNum"] == DtBook.Rows[j]["ClassNum"])  //教室列表和预约列表的教室相对应
                {
                    DateTime AssStartDate = Convert.ToDateTime(Drop_StartTime.SelectedValue);
                    DateTime AssEndDate = Convert.ToDateTime(Drop_StartTime.SelectedValue);
                    for (int k = 0; k <= BookDay; k++)
                    {
                        DateTime RAssDate = AssStartDate.AddDays(k);
                        for (int l = 0; l < DayStartClock.Count(); l++)      //按时段检索修改DtGrid
                        {
                            if (Convert.ToDateTime(DtBook.Rows[j]["BookDate"]) == RAssDate && DtBook.Rows[j]["StartTime"].ToString() == DayStartClock[k] && DtBook.Rows[j]["IsBooked"].ToString() == "1")
                            {
                                DtGrid.Rows.Add(i + 1, DtClass.Tables[0].Rows[i]["Address"], DtClass.Tables[0].Rows[i]["ClassNum"], DtBook.Rows[j]["BookDate"], DtBook.Rows[j]["StartTime"], DtBook.Rows[j]["EndTime"], DtBook.Rows[j]["BookStuNum"], "已预约");
                            }
                            else
                            {
                                DtGrid.Rows.Add(i + 1, DtClass.Tables[0].Rows[i]["Address"], DtClass.Tables[0].Rows[i]["ClassNum"], Drop_StartTime.SelectedValue.ToString(), DtBook.Rows[j]["StartTime"], DtBook.Rows[j]["EndTime"], DtBook.Rows[j]["BookStuNum"], "点击预约");
                            }
                        }
                        if (RAssDate == Convert.ToDateTime(Drop_EndTime)) break;   //不在选择时间段则跳出循环
                    }
                }
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
}