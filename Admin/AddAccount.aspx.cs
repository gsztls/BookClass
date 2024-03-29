﻿using System;
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
        CheckLogin();
        if (!IsPostBack)
        {
            ArrayList type = new ArrayList();
            type.Add("用户");
            type.Add("管理员");
            DropType.DataSource = type;
            DropType.DataBind();
            DropType.Items.Insert(0, new ListItem("--请选择--", ""));
        }
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        string StuId = TxtStuId.Text;
        string Name = TxtName.Text;
        if (Name == ""||StuId=="")
        {
            Response.Write("<script>alert('信息填写不完整！')</script>");
            return;
        }
        
        DataSet DsAdmin = SqlHelper.ExecuteDataset(CommandType.Text,"SELECT * FROM [BookClass].[dbo].[Admin] WHERE StuId ='"+StuId+"'");
        if (DsAdmin.Tables[0].Rows.Count > 0)
        {
            Response.Write("<script>alert('该用户已存在！')</script>");
            return;
        }
        int JudgeNum1 = SqlHelper.ExecuteNonQuery(CommandType.Text,"INSERT INTO [BookClass].[dbo].[UserInfo](StuId,Type,UserName) VALUES ('"+StuId+"','"+Name+"')");
        int JudgeNum2 = SqlHelper.ExecuteNonQuery(CommandType.Text, "INSERT INTO [BookClass].[dbo].[Admin](StuId,PassWord) VALUES ('" + StuId + "')");
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