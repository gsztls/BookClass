using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_Setting : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckLogin();
        if (!IsPostBack)
        {
            DataList1Bind();
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
    protected void DataList1Bind()
    {
        DataSet DsUserInfo = SqlHelper.ExecuteDataset(CommandType.Text, "SELECT * FROM [BookClass].[dbo].[System]")
    ;
        DataList1.DataSourceID = null;
        DataList1.DataSource = DsUserInfo.Tables[0];
        DataList1.DataKeyField = "ID";
        DataList1.DataBind();
    }
    protected void DataList1_EditCommand(object source, DataListCommandEventArgs e)
    {
        DataList1.EditItemIndex = e.Item.ItemIndex;  //e.Item表示DataList中发生事件的那一项  
        DataList1Bind();
    }
    protected void DataList1_CancelCommand(object source, DataListCommandEventArgs e)
    {
        DataList1.EditItemIndex = -1;  //当EditItemIndex属性值为-1时，表示不显示EditItemTemplate模板  
        DataList1Bind();
    }
    protected void DataList1_UpdateCommand(object source, DataListCommandEventArgs e)
    {
        string ID = DataList1.DataKeys[e.Item.ItemIndex].ToString();
        string BookDay = ((TextBox)e.Item.FindControl("TextBox1")).Text;
        string NeedDay = ((TextBox)e.Item.FindControl("TextBox2")).Text;
        int JudgeNum = SqlHelper.ExecuteNonQuery(CommandType.Text, "UPDATE [BookClass].[dbo].[System] SET BookDay='" + BookDay + "',NeedDay = '" + NeedDay + "'");
        DataList1.EditItemIndex = -1;
        DataList1Bind();
        if (JudgeNum > 0)
        {
            Response.Write("<script>alert('修改成功！')</script>");
            return;
        }
        else
        {
            Response.Write("<script>alert('修改失败！')</script>");
            return;
        }     
    }
}