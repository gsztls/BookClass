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
        DataSet DsNotice = SqlHelper.ExecuteDataset(CommandType.Text, "SELECT * FROM [BookClass].[dbo].[Notice]");
        DataList1.DataKeyField = "ID";  //将主键存入到DataKeys集合当中，以便后面对某一条数据进行编辑。  
        DataList1.DataSource = DsNotice.Tables[0];
        DataList1.DataSourceID =null;
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
}