<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Notice.aspx.cs" Inherits="Notice" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    	<meta charset="UTF-8">
	<meta http-equiv="X-UA-Compatible" content="IE=edge">  <!-- 以上代码告诉IE浏览器，IE8/9及以后的版本都会以最高版本IE来渲染页面。 -->  
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<title>公告栏——中南大学教室预约管理系统</title>
	<link rel="stylesheet" href="css/normalize.css">
	<link rel="stylesheet" href="css/common.css">
	<link rel="stylesheet" href="css/notice.css">
        <style type="text/css">
            .style1
            {
                width: 519px;
            }
            .style2
            {
                width: 987px;
            }
            .style3
            {
                width: 95px;
            }
            </style>
</head>
<body>
   <header>
		<div class="logo">
			<img src="images/logo1.png" alt="华中师范大学logo" class="logo-img vertical-center" />
			<h1 class="vertical-center">教室预约管理系统</h1>
		</div>
		<div class="logoff">
			<a href="#"><span><asp:label id="label_user" runat="server" Text="这里是姓名"></asp:label>（<asp:label ID="label_stuNum" runat="server" Text="这里是学号"></asp:label>）</span></a>
			<a href="LogOff.aspx" ><img src="images/out.png" alt="注销登录"/></a>
		</div>
	</header><!-- header结束 -->
    <div class="container">
		<nav class="nav-list">
			<a href="index.aspx" class="nav-item" id="nav-item1">
				<span class="iconfont">&#xe63e;</span>
				<span class="item-info">主页</span>
			</a>
			<a href="RoomSelect.aspx" class="nav-item" id="nav-item2">
				<span class="iconfont">&#xe604;</span>
				<span class="item-info">教室预约</span>
			</a>
			<a href="ContactManager.aspx" class="nav-item" id="nav-item3">
				<span class="iconfont">&#xe601;</span>
				<span class="item-info">联系管理员</span>
			</a>
			<a href="CancelBook.aspx" class="nav-item" id="nav-item4">
				<span class="iconfont">&#xe64a;</span>
				<span class="item-info">取消预约</span>
			</a>
			<a href="ClassList.aspx" class="nav-item" id="nav-item5">
				<span class="iconfont">&#xe751;</span>
				<span class="item-info">可借教室</span>
			</a>
			<a href="BookRecord.aspx" class="nav-item" id="nav-item6">
				<span class="iconfont">&#xe610;</span>
				<span class="item-info">预约记录</span>
			</a>
			<a href="Notice.aspx" class="nav-item" id="nav-item8">
				<span class="iconfont">&#xe600;</span>
				<span class="item-info">公告栏</span>
			</a>
			<span class="triangle"></span>
		</nav>
    <form id="form1" runat="server" style="background:#fff">
    
		<div class="notice-content" style = "height:800px">
			<div id="content1">
            <asp:DataList ID="DataList1" runat="server" Width="948px" CellPadding="4" 
                    DataSourceID="SqlDataSource1" ForeColor="#333333" Height="225px" 
                    onitemcommand="DataList1_ItemCommand" style="margin-top: 0px" 
                    ItemStyle-Width="100%"   ItemStyle-Height="100%" 
                    onitemdatabound="DataList1_ItemDataBound" DataKeyField="ID" >
                <AlternatingItemStyle BackColor="White" />
                <FooterStyle BackColor="#EFF3FB" Font-Bold="True" ForeColor="White" />
                <FooterTemplate>
                    <table style="color: #000000"><tr><td class="style3"><asp:Label ID="LabCurrentPage" runat="server" ForeColor="Black" Text="Label"></asp:Label>
                        /<asp:Label ID="LabPageCount" runat="server" ForeColor="Black" Text="Label"></asp:Label></td><td> <asp:LinkButton ID="LnkbtnFirst" runat="server" CommandName="first">首页</asp:LinkButton></td><td><asp:LinkButton ID="LnkbtnFront" runat="server" CommandName="pre">上一页</asp:LinkButton></td>
                        <td><asp:LinkButton ID="LnkbtnNext" runat="server" ForeColor="Black" 
                                CommandName="next">下一页</asp:LinkButton></td>
                        <td><asp:LinkButton ID="LnkbtnLast" runat="server" ForeColor="Black" 
                                CommandName="last">尾页</asp:LinkButton></td><td> 跳转至：<asp:TextBox 
                            ID="txtPage" runat="server" Height="19px" Width="140px"></asp:TextBox></td><td><asp:Button ID="Button1" runat="server" Text="GO" CommandName="search" /></td></tr></table>
                </FooterTemplate>
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <ItemStyle BackColor="#EFF3FB" />
                <ItemTemplate>   
                <table><tr><td class="style2"><asp:LinkButton ID="LinkButton1" runat="server" Text='<%# Eval("Title") %>' 
                        CommandName="Select"></asp:LinkButton></td><td class="style1"><asp:Label ID="Label1" runat="server" Text='<%# Eval("Time") %>'></asp:Label></td></tr></table>   
                   

                </ItemTemplate>
                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            </asp:DataList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:BookClassConnectionString %>" 
                    SelectCommand="SELECT * FROM [Notice] ORDER BY [Time] DESC"></asp:SqlDataSource>
            </div>		
		</div>
	
    </form>
</body>
</html>
