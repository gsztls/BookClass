using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

public partial class Admin_AccountManagement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataList1Bind();
            ArrayList type = new ArrayList();
            type.Add("用  户");
            type.Add("管理员");
        }
    }
    protected void DataList1Bind()
    {
        DataSet DsUserInfo = SqlHelper.ExecuteDataset(CommandType.Text, "SELECT * FROM [BookClass].[dbo].[UserInfo]")
    ;
        DataList1.DataSourceID = null;
        DataList1.DataSource = DsUserInfo.Tables[0];
        DataList1.DataKeyField = "ID";  
        DataList1.DataBind();
    }
  
    protected void DataList1_EditCommand(object source, DataListCommandEventArgs e)
    {
        DataList1.EditItemIndex = e.Item.ItemIndex;  //e.Item表示DataList中发生事件的那一项  
        this.DataList1Bind();  
    }
    protected void DataList1_CancelCommand(object source, DataListCommandEventArgs e)
    {
        DataList1.EditItemIndex = -1;  //当EditItemIndex属性值为-1时，表示不显示EditItemTemplate模板  
        DataList1Bind();
    }
    protected void DataList1_DeleteCommand(object source, DataListCommandEventArgs e)
    {
        string ID = DataList1.DataKeys[e.Item.ItemIndex].ToString();
        int JudgeNum1 = SqlHelper.ExecuteNonQuery(CommandType.Text, "DELETE FROM [BookClass].[dbo].[UserInfo] WHERE ID ='" + ID + "'");
        int JudgeNum2 = SqlHelper.ExecuteNonQuery(CommandType.Text, "DELETE FROM [BookClass].[dbo].[Admin] WHERE ID='" + ID + "'");
        DataList1.EditItemIndex = -1;
        DataList1Bind();
        if (JudgeNum1> 0 && JudgeNum2>0)
        {
            Response.Write("<script>alert('删除成功！')</script>");
            return;
        }
        else
        {
            Response.Write("<script>alert('删除失败！')</script>");
            return;
        }     
    }
    protected void DataList1_UpdateCommand(object source, DataListCommandEventArgs e)
    {
        string ID = DataList1.DataKeys[e.Item.ItemIndex].ToString();
        string Name = ((TextBox)e.Item.FindControl("TxtName")).Text;
        string StuId = ((TextBox)e.Item.FindControl("TxtStuId")).Text;
        string Type = ((DropDownList)e.Item.FindControl("DropType")).SelectedValue;
        int JudgeNum = SqlHelper.ExecuteNonQuery(CommandType.Text, "UPDATE [BookClass].[dbo].[UserInfo] SET StuId='"+StuId+"',Type = '"+Type+"',UserName='"+Name+"' WHERE ID ='"+ID+"'");
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