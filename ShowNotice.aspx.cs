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
        string ID = System.Web.HttpContext.Current.Server.UrlDecode(Request.QueryString["UrlID"].ToString());
        if (!IsNumberic(ID))
        {
            Response.Write("<script>alert('参数错误,请手动返回主页！')</script>");
            Response.End();
            return;
        }
        DataSet DsNotice = SqlHelper.ExecuteDataset(CommandType.Text, "SELECT * FROM [BookClass].[dbo].[Notice] WHERE ID ='" + ID + "'");
        Label1.Text = DsNotice.Tables[0].Rows[0]["Title"].ToString();
        Label2.Text = DsNotice.Tables[0].Rows[0]["Text"].ToString();
    }

    private bool IsNumberic(string oText)
    {
        try
        {
            int var1 = Convert.ToInt32(oText);
            return true;
        }
        catch
        {
            return false;
        }
    }
}