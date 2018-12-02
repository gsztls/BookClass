using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class Notice : System.Web.UI.Page
{
    protected static PagedDataSource pds = new PagedDataSource();
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckLogin();
        if (!IsPostBack)
        {
            BindDataList(0);
        }
    }
    protected void BindDataList(int currentpage)
    {
        pds.AllowPaging = true;
        pds.PageSize = 10;
        pds.CurrentPageIndex = currentpage;
        DataSet DsNotice = SqlHelper.ExecuteDataset(CommandType.Text, "SELECT * FROM [BookClass].[dbo].[Notice] ORDER BY [Time] DESC");
        
        pds.DataSource = DsNotice.Tables[0].DefaultView;
        DataList1.DataSource = pds;
        DataList1.DataSourceID = null;
        DataList1.DataBind();
       // DataList1.DataKeyField = "ID";  //将主键存入到DataKeys集合当中，以便后面对某一条数据进行编辑。  
    }
    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        { 
            string ID = DataList1.DataKeys[e.Item.ItemIndex].ToString();
            Response.Redirect("ShowNotice.Aspx?UrlID=" + System.Web.HttpContext.Current.Server.UrlEncode(ID) + "");
        }
        switch (e.CommandName)
        { 
            case "first":
                pds.CurrentPageIndex = 0;
                BindDataList(pds.CurrentPageIndex);
                break;
            case "pre":
                pds.CurrentPageIndex = pds.CurrentPageIndex - 1;
                BindDataList(pds.CurrentPageIndex);
                break;
            case "next":
                pds.CurrentPageIndex=pds.CurrentPageIndex + 1;
                BindDataList(pds.CurrentPageIndex);
                break;
            case "last":
                pds.CurrentPageIndex = pds.PageCount-1;
                BindDataList(pds.CurrentPageIndex);
                break;
            case "search":
                if (e.Item.ItemType == ListItemType.Footer)
                {
                    int PageCount = int.Parse(pds.PageCount.ToString());
                    TextBox txtPage = e.Item.FindControl("txtPage") as TextBox;
                    int MyPageNum = 0;
                    if (!txtPage.Text.Equals(""))
                        MyPageNum = Convert.ToInt32(txtPage.Text.ToString());
                    if(MyPageNum<=0 || MyPageNum >PageCount) 
                        Response.Write("<script>alert('请输入页数并确认没有超出总页数！</script>");
                    else
                        BindDataList(MyPageNum-1);
                }
                break;
        }

    }
    public void CheckLogin() //以下代码检测用户登录参数是否正确
    {

        String StuId = (string)Session["StuId"];
        DataSet dt = SqlHelper.ExecuteDataset(CommandType.Text, "SELECT * FROM [BookClass].[dbo].[UserInfo] WHERE StuId ='" + StuId + "'AND Type != 'manager'");
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
    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Footer)
        {
            Label CurrentPage = e.Item.FindControl("LabCurrentPage") as Label;
            Label PageCount = e.Item.FindControl("LabPageCount") as Label;
            LinkButton FirstPage = e.Item.FindControl("LnkbtnFirst") as LinkButton;
            LinkButton PrePage = e.Item.FindControl("LnkbtnFront") as LinkButton;
            LinkButton NextPage = e.Item.FindControl("LnkbtnNext") as LinkButton;
            LinkButton LastPage = e.Item.FindControl("LnkbtnLast") as LinkButton;
            CurrentPage.Text = Convert.ToString(pds.CurrentPageIndex + 1);
            PageCount.Text = pds.PageCount.ToString();
            if (pds.IsFirstPage)
            {
                FirstPage.Enabled = false;
                PrePage.Enabled = false;
            }
            if (pds.IsLastPage)
            {
                NextPage.Enabled = false;
                LastPage.Enabled = false;
            }
        }
    }
}