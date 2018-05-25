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
            ArrayList type = new ArrayList();
            type.Add("用  户");
            type.Add("管理员");
            DropType.DataSource = type;
            DropType.DataBind();
            DropType.Items.Insert(0, new ListItem("--请选择--", ""));
        }
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        string Name = TxtName.Text;
        string Pwd = TxtPwd.Text;
        string Rpwd = TxtRpwd.Text;
        String StuId = TxtStuId.Text;
        string Type = DropType.SelectedValue.ToString();
        if (Name == "" || Pwd == "" || Rpwd == "" || StuId == "" || Type == "" || Type == "--请选择--")
        {
            Response.Write("<script>alert('信息填写不完整！')</script>");
            return;
        }
        if (Pwd != Rpwd)
        {
            Response.Write("<script>alert('两次密码不一致！')</script>");
            return;
        }
        DataSet DsAdmin = SqlHelper.ExecuteDataset(CommandType.Text,"SELECT * FROM [BookClass].[dbo].[Admin] WHERE StuId ='"+StuId+"'");
        if (DsAdmin.Tables[0].Rows.Count > 0)
        {
            Response.Write("<script>alert('该用户已存在！')</script>");
            return;
        }
        int JudgeNum1 = SqlHelper.ExecuteNonQuery(CommandType.Text,"INSERT INTO [BookClass].[dbo].[UserInfo](StuId,Type,UserName) VALUES ('"+StuId+"','"+Type+"','"+Name+"')");
        int JudgeNum2 = SqlHelper.ExecuteNonQuery(CommandType.Text, "INSERT INTO [BookClass].[dbo].[Admin](StuId,PassWord) VALUES ('" + StuId + "','"+Pwd+"')");
        if (JudgeNum1 > 0 && JudgeNum2 > 0)
        {
            Response.Write("<script>alert('添加成功！')</script>");
            return;
        }
        else
        {
            Response.Write("<script>alert('添加失败！')</script>");
            return;
        }
    }
}