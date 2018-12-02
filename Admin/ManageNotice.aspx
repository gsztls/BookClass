<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManageNotice.aspx.cs" Inherits="Notice" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    	<meta charset="UTF-8">
	<meta http-equiv="X-UA-Compatible" content="IE=edge">  <!-- 以上代码告诉IE浏览器，IE8/9及以后的版本都会以最高版本IE来渲染页面。 -->  
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<title>公告管理——中南大学教室预约管理系统</title>
	<link rel="stylesheet" href="../css/normalize.css">
	<link rel="stylesheet" href="../css/common.css">
	<link rel="stylesheet" href="../css/notice.css">
        <style type="text/css">
            .style7
            {
                width: 293px;
            }
            .style8
            {
                width: 480px;
            }
            .style9
            {
                width: 292px;
            }
            .style11
            {
                width: 163px;
            }
            .style12
            {
                width: 164px;
            }
            .style14
            {
                width: 242px;
            }
            .style15
            {
                width: 729px;
            }
            .style16
            {
                width: 465px;
            }
        </style>
</head>
<body>
   <header>
		<div class="logo">
			<img src="../images/logo1.png" alt="中南大学logo" class="logo-img vertical-center">
			<h1 class="vertical-center">教室预约管理系统</h1>
		</div>
		<div class="logoff">
			<a href="#"><span><asp:label id="label_user" runat="server" Text="这里是姓名"></asp:label>（<asp:label ID="label_stuNum" runat="server" Text="这里是学号"></asp:label>）</span></a>
			<a href="../LogOff.aspx" ><img src="../images/out.png" alt="注销登录"/></a>
		</div>
	</header><!-- header结束 -->
    <div class="container">
		<nav class="nav-list">
			<a href="AdminIndex.aspx" class="nav-item" id="nav-item1">
				<span class="iconfont">&#xe63e;</span>
				<span class="item-info">主页</span>
			</a>
			<a href="DealRequre.aspx" class="nav-item" id="nav-item2">
				<span class="iconfont">&#xe604;</span>
				<span class="item-info">申请处理</span>
			</a>
			<a href="AccountManagement.aspx" class="nav-item" id="nav-item3">
				<span class="iconfont">&#xe601;</span>
				<span class="item-info">账号管理</span>
			</a>
			<a href="Setting.aspx" class="nav-item" id="nav-item4">
				<span class="iconfont">&#xe64a;</span>
				<span class="item-info">系统设置</span>
			</a>
			<a href="ClassList.aspx" class="nav-item" id="nav-item5">
				<span class="iconfont">&#xe751;</span>
				<span class="item-info">教室列表</span>
			</a>
			<a href="ClassManagement.aspx" class="nav-item" id="nav-item6">
				<span class="iconfont">&#xe610;</span>
				<span class="item-info">教室管理</span>
			</a>
			<a href="ManageNotice.aspx" class="nav-item" id="nav-item8">
				<span class="iconfont">&#xe600;</span>
				<span class="item-info">公告管理</span>
			</a>
			<span class="triangle"></span>
		</nav>
    <form id="form1" runat="server" style="background: #fff;">
    
		<div class="notice-content" style = "height:800px">
			<asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" 
                    Width="922px" CellPadding="4" ForeColor="#333333" 
                style="margin-top: 0px" ondeletecommand="DataList1_DeleteCommand" 
                oncancelcommand="DataList1_CancelCommand" oneditcommand="DataList1_EditCommand" 
                onupdatecommand="DataList1_UpdateCommand" 
                onitemcommand="DataList1_ItemCommand1" 
                onitemdatabound="DataList1_ItemDataBound" DataKeyField="ID">
                    <AlternatingItemStyle BackColor="White" />
                    <EditItemTemplate>
                        公告标题：<asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("Title") %>'></asp:TextBox>
                        <br />
                        <br />
                        公告内容：<asp:TextBox ID="TextBox2" runat="server" Height="167px" 
                            Text='<%# Eval("Text") %>' TextMode="MultiLine" Width="532px"></asp:TextBox>
&nbsp;<asp:LinkButton ID="LinkButton3" runat="server" CommandName="Update" ForeColor="#0066D6">保存</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton4" runat="server" CommandName="Cancel" 
                            ForeColor="#0066D6">取消</asp:LinkButton>
                    </EditItemTemplate>
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <FooterStyle BackColor="#EFF3FB" Font-Bold="True" ForeColor="White" />
                <FooterTemplate>
                    <table style="color: #000000"><tr><td class="style7"><asp:Label ID="LabCurrentPage" runat="server" ForeColor="Black" Text="Label"></asp:Label>
                        /<asp:Label ID="LabPageCount" runat="server" ForeColor="Black" Text="Label"></asp:Label></td>
                        <td class="style12"> <asp:LinkButton ID="LnkbtnFirst" runat="server" CommandName="first">首页</asp:LinkButton></td>
                        <td class="style11"><asp:LinkButton ID="LnkbtnFront" runat="server" CommandName="pre">上一页</asp:LinkButton></td>
                        <td class="style14"><asp:LinkButton ID="LnkbtnNext" runat="server" 
                                ForeColor="Black" CommandName="next">下一页</asp:LinkButton></td>
                        <td class="style16"><asp:LinkButton ID="LnkbtnLast" runat="server" 
                                ForeColor="Black" CommandName="last">尾页</asp:LinkButton></td>
                        <td class="style15"> 跳转至：<asp:TextBox 
                            ID="txtPage" runat="server" Height="21px" Width="104px"></asp:TextBox></td>
                        <td class="style8"><asp:Button ID="Button1" runat="server" Text="GO" CommandName="search" /></td></tr></table>
                </FooterTemplate>
                    <HeaderStyle BackColor="#6DBAF0" Font-Bold="True" ForeColor="White" />
                    <HeaderTemplate>
                        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="添加公告" 
                            BackColor="#33CCFF" />
                    </HeaderTemplate>
                    <ItemStyle BackColor="#EFF3FB" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemTemplate>
                        <table style="width:100%; height: 54px;">
                            <tr>
                                <td class="style9" >
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Title") %>'></asp:Label>
                                   
                                </td>
                                <td class="style8">
                                     <asp:Label ID="Label2" runat="server" Text='<%# Eval("Time") %>'></asp:Label></td>
                                <td class="style7" >
                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edit" 
                                        ForeColor="#0066D6">编辑</asp:LinkButton>
                                </td>
                                <td >
                                    <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Delete" 
                                        ForeColor="#0066D6">删除</asp:LinkButton>
                                </td>
                            </tr>
                           
                        </table>
                    </ItemTemplate>
                    <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                </asp:DataList>
                
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:BookClassConnectionString %>" 
                    SelectCommand="SELECT [Title], [Text], [Time], [ID] FROM [Notice] ORDER BY [Time] DESC">
                </asp:SqlDataSource>
		</div>
    </form>
</body>
</html>
