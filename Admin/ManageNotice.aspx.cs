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
        if (!IsPostBack)
        {
            DataList1Bind();
        }
    }
    protected void DataList1Bind()
    {
        DataSet DsNotice = SqlHelper.ExecuteDataset(CommandType.Text, "SELECT * FROM [BookClass].[dbo].[Notice]");
        DataList1.DataKeyField = "ID";  //将主键存入到DataKeys集合当中，以便后面对某一条数据进行编辑。  
        DataList1.DataSource = DsNotice.Tables[0];
        DataList1.DataSourceID = null;
        DataList1.DataBind();  
    }
    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            string ID = DataList1.DataKeys[e.Item.ItemIndex].ToString();
            Response.Redirect("ShowNotice.Aspx?UrlID=" + System.Web.HttpContext.Current.Server.UrlEncode(ID) + "");
            
        }  

    }
    protected void DataList1_DeleteCommand(object source, DataListCommandEventArgs e)
    {
        string ID = DataList1.DataKeys[e.Item.ItemIndex].ToString();
        int JudgeNum = SqlHelper.ExecuteNonQuery(CommandType.Text,"delete from [BookClass].[dbo].[Notice] where ID='" + ID + "'");
        DataList1.EditItemIndex = -1;
        DataList1Bind(); 
        if(JudgeNum>0)
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
    protected void DataList1_CancelCommand(object source, DataListCommandEventArgs e)
    {
        DataList1.EditItemIndex = -1;  //当EditItemIndex属性值为-1时，表示不显示EditItemTemplate模板  
        DataList1Bind();
    }
    protected void DataList1_UpdateCommand(object source, DataListCommandEventArgs e)
    {
        string ID = DataList1.DataKeys[e.Item.ItemIndex].ToString();
        string Title = ((TextBox)e.Item.FindControl("TextBox1")).Text;
        string Text = ((TextBox)e.Item.FindControl("TextBox2")).Text;
        string Time = DateTime.Now.ToLongDateString();
        int JudgeNum = SqlHelper.ExecuteNonQuery(CommandType.Text, "UPDATE [BookClass].[dbo].[Notice] SET Title='"+Title+"',Text ='"+Text+"',Time ='"+Time+"'");
        DataList1.EditItemIndex = -1;
        DataList1Bind();
        if (JudgeNum > 0)
        {
            Response.Write("<script>alert('保存成功！')</script>");
            return;
        }
        else
        {
            Response.Write("<script>alert('保存失败！')</script>");
            return;
        }

    }
    protected void DataList1_EditCommand(object source, DataListCommandEventArgs e)
    {
        DataList1.EditItemIndex = e.Item.ItemIndex;   //e.Item表示DataList中发生事件的那一项  
        DataList1Bind();  

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddNotice.aspx");
    }
}