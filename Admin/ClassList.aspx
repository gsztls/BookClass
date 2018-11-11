<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClassList.aspx.cs" Inherits="ClassList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta charset="UTF-8">
	<meta http-equiv="X-UA-Compatible" content="IE=edge">  <!-- 以上代码告诉IE浏览器，IE8/9及以后的版本都会以最高版本IE来渲染页面。 -->  
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<title>教室列表——中南大学教室预约管理系统</title>
	<link rel="stylesheet" href="../css/normalize.css">
	<link rel="stylesheet" href="../css/common.css">
	<link rel="stylesheet" type="text/css" href="../css/room_operate.css">
</head>
<body>
    <header>
		<div class="logo">
			<img src="../images/logo1.png" alt="华中师范大学logo" class="logo-img vertical-center">
			<h1 class="vertical-center">教室预约管理系统</h1>
		</div>
		<div class="logoff">
			<a href="#"><span><asp:label id="label_user" runat="server" Text="这里是姓名"></asp:label>（<asp:label ID="label_stuNum" runat="server" Text="这里是学号"></asp:label>）</span></a>
			<a href="../LogOff.aspx" ><img src="../images/out.png" alt="注销登录"/></a>
		</div>
	</header><!-- header结束 -->
    <form id="Form1" runat="server">
	<div class="container" style="margin:20px auto">
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
			<span class="triangle" style="left:593px;"></span>
		</nav>
		<div class="reserve-content">
				<div id="info4">
					教室地址：<asp:DropDownList ID="Drop_Address" runat="server"
                        DataSourceID="Sql_Address" DataTextField="Address" 
                        DataValueField="Address" AutoPostBack="true" >
        </asp:DropDownList>
                    <asp:SqlDataSource ID="Sql_Address" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:BookClassConnectionString %>" 
                        SelectCommand="SELECT distinct [Address] FROM [ClassList]"></asp:SqlDataSource>
				    <asp:Button ID="Button1" runat="server" Text="查询" onclick="Button1_Click" />
				    <br />
				</div>
				<div id="info5">
					
					<span class="input">
					
					<span class="iconfont vertical-center">		
					</span>
					</span>
                    <asp:GridView ID="GridView_BookList" runat="server" Height="89px" 
                        Width="1071px" AllowPaging="True" PageSize="16" 
                        CellPadding="4" ForeColor="#333333" GridLines="None" 
                        onpageindexchanging="GridView_BookList_PageIndexChanging" 
                        HorizontalAlign="Center" AutoGenerateColumns="False" 
                        DataSourceID="SqlDataSource1" >
                        <RowStyle HorizontalAlign="Center" />  
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="Address" HeaderText="地址" 
                                SortExpression="Address" />
                            <asp:BoundField DataField="ClassNum" HeaderText="教室编号" 
                                SortExpression="ClassNum" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#6DBAF0" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#6DBAF0" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#6DBAF0" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
				    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:BookClassConnectionString %>" 
                        SelectCommand="SELECT [Address], [ClassNum] FROM [ClassList]">
                    </asp:SqlDataSource>
				</div>
		</div>
	</div>
				<div id="info1">
				</div>
				<div id="info3">
					
					<span class="input">
					
					<span class="iconfont vertical-center">		
					</span>
					</span>
				</div>
			</form><!--  form seat-info结束 -->
</body>
</html>
