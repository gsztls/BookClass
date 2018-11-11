<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AccountManagement.aspx.cs" Inherits="Admin_AccountManagement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<meta charset="UTF-8"/>
	<meta http-equiv="X-UA-Compatible" content="IE=edge"/>  <!-- 以上代码告诉IE浏览器，IE8/9及以后的版本都会以最高版本IE来渲染页面。 -->  
	<meta name="viewport" content="width=device-width, initial-scale=1"/>
	<title>账号管理——中南大学教室预约管理系统</title>
	<link rel="stylesheet" href="../css/normalize.css"/>
	<link rel="stylesheet" href="../css/common.css"/>
	<link rel="stylesheet" href="../css/room_select.css"/>
    <style type="text/css">
        .style3
        {
            height: 445px;
            width: 930px;
        }
        .style4
        {
            height: 445px;
            width: 127px;
        }
        .style5
        {
            height: 29px;
        }
        .style6
        {
            height: 36px;
            width: 420px;
        }
        .style8
        {
            height: 36px;
        }
        .style9
        {
            height: 36px;
            width: 931px;
        }
        .style11
        {
            height: 36px;
            width: 1106px;
        }
        .style12
        {
            height: 36px;
            width: 927px;
        }
        .style13
        {
            height: 36px;
            width: 666px;
        }
        .style14
        {
            height: 36px;
            width: 820px;
        }
        .style15
        {
            height: 36px;
            width: 966px;
        }
    </style>
</head>
<body>
	<!--[if lte IE8]>
	<p class="browserupdate">您的浏览器版本太老，请到<a href="http://browsehappy.com">这里</a>更新，以获取最佳的浏览体验。</p>
	<![endif]-->
	<header>
		<div class="logo">
			<img src="../images/logo1.png" alt="中南大学logo" class="logo-img vertical-center"/>
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
				<span class="item-info" style="display:inline">申请处理</span>
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
			<span class="triangle" style="left: 325px;"></span>
		</nav>
		<div class="seat-content"  style = "height:800px">
			<form id="Form1" runat="server">
				<div id="info1">
					<br />
				</div>
				<div id="info3">
					
					<span class="input">
					
					<span class="iconfont vertical-center">		
					</span>
                    <table style="width: 1068px; height: 480px">
                    <tr><td class="style4">
                    <table style="height: 475px; width: 128px">
                    <tr><td align="center" bgcolor="#6DBAF0" class="style5">
                        <a href="AccountManagement.aspx" style="color: #FFFFFF">账号信息管理</a></td></tr>
                    <tr><td align="center" bgcolor="#6DBAF0" class="style5">
                        <a href="AddAccount.aspx" 
                            style="color: #FFFFFF">添加账号</a></td></tr>
                    <tr><td></td></tr>
                    </table>
                    </td>
                    
                    <td class="style3">
                        <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" 
                            Height="450px" Width="928px" CellPadding="4" ForeColor="#333333" 
                            oncancelcommand="DataList1_CancelCommand" 
                            ondeletecommand="DataList1_DeleteCommand" 
                            oneditcommand="DataList1_EditCommand" 
                            onupdatecommand="DataList1_UpdateCommand" DataKeyField="ID" 
                            onitemcommand="DataList1_ItemCommand" onitemdatabound="DataList1_ItemDataBound">
                            <AlternatingItemStyle BackColor="White" />
                            <EditItemTemplate>
                                &nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="TxtStuId" runat="server" Text='<%# Eval("StuId") %>'></asp:TextBox>
                                &nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="TxtName" runat="server" Text='<%# Eval("UserName") %>'></asp:TextBox>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList 
                                    ID="DropType" runat="server" 
                                    DataSourceID="SqlDataSource1" DataTextField="Type" DataValueField="Type" 
                                    Height="21px" SelectedValue='<%# Eval("Type") %>' Width="140px">
                                </asp:DropDownList>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:LinkButton ID="Update" runat="server" CommandName="Update">确定</asp:LinkButton>
                                &nbsp;&nbsp;
                                <asp:LinkButton ID="Cancel" runat="server" CommandName="Cancel">取消</asp:LinkButton>
                            </EditItemTemplate>
                           <FooterStyle BackColor="#EFF3FB" Font-Bold="True" ForeColor="White" />
                <FooterTemplate>
                    <table style="color: #000000; font-size: x-small;"><tr><td class="style6"><asp:Label ID="LabCurrentPage" runat="server" ForeColor="Black" Text="Label"></asp:Label>
                        /<asp:Label ID="LabPageCount" runat="server" ForeColor="Black" Text="Label"></asp:Label></td>
                        <td class="style12"> <asp:LinkButton ID="LnkbtnFirst" runat="server" CommandName="first">首页</asp:LinkButton></td>
                        <td class="style11"><asp:LinkButton ID="LnkbtnFront" runat="server" CommandName="pre">上一页</asp:LinkButton></td>
                        <td class="style14"><asp:LinkButton ID="LnkbtnNext" runat="server" 
                                ForeColor="Black" CommandName="next">下一页</asp:LinkButton></td>
                        <td class="style9"><asp:LinkButton ID="LnkbtnLast" runat="server" ForeColor="Black" 
                                CommandName="last">尾页</asp:LinkButton></td>
                        <td class="style13"> 跳转至：<asp:TextBox 
                            ID="txtPage" runat="server" Height="16px" Width="109px"></asp:TextBox></td>
                        <td class="style8"><asp:Button ID="Button1" runat="server" Text="GO" CommandName="search" /></td></tr></table>
                </FooterTemplate>
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <ItemStyle BackColor="#EFF3FB" />
                            <ItemTemplate>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="LabelStuId" runat="server" Text='<%# Eval("StuId") %>'></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="LabelName" runat="server" Text='<%# Eval("UserName") %>'></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="LabelType" runat="server" Text='<%# Eval("Type") %>'></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:LinkButton ID="Edit" runat="server" CommandName="Edit">编辑</asp:LinkButton>
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:LinkButton ID="Delete" runat="server" CommandName="Delete" OnClientClick="{if(confirm('确定删除？')){return true;}return false;}">删除</asp:LinkButton>
                            </ItemTemplate>
                            <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        </asp:DataList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:BookClassConnectionString %>" 
                            SelectCommand="SELECT [StuId], [Type], [UserName] FROM [UserInfo]">
                        </asp:SqlDataSource>
                        </td></tr>
                    
                    
                    </table>
					</span>
				</div>
			</form><!--  form seat-info结束 -->
			<div class="seat-map" id="seat-map"></div>
		</div>
	</div>
</body>
</html>
