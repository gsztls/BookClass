<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RoomSelect.aspx.cs" Inherits="RoomSelect" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta charset="UTF-8"/>
	<meta http-equiv="X-UA-Compatible" content="IE=edge"/>  <!-- 以上代码告诉IE浏览器，IE8/9及以后的版本都会以最高版本IE来渲染页面。 -->  
	<meta name="viewport" content="width=device-width, initial-scale=1"/>
	<title>教室预约——中南大学教室预约系统</title>
	<link rel="stylesheet" href="css/normalize.css"/>
	<link rel="stylesheet" href="css/common.css"/>
	<link rel="stylesheet" href="css/room_select.css"/>
</head>
<body>
	<!--[if lte IE8]>
	<p class="browserupdate">您的浏览器版本太老，请到<a href="http://browsehappy.com">这里</a>更新，以获取最佳的浏览体验。</p>
	<![endif]-->
	<header>
		<div class="logo">
			<img src="images/logo1.png" alt="中南大学logo" class="logo-img vertical-center"/>
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
				<span class="iconfont">&#xe610;</span>
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
			<span class="triangle">
        <br />
        </span>
		</nav>
		<div class="seat-content" style = "height:800px">
			<form runat="server" style="background:#fff">
				<div id="info1" style="margin-left:20px">
					<br />
					教室地址：<asp:DropDownList ID="Drop_Address" runat="server"
                        DataSourceID="Sql_Address" DataTextField="Address" 
                        DataValueField="Address"  
                        onselectedindexchanged="Drop_Address_SelectedIndexChanged" AutoPostBack="true" >
        </asp:DropDownList>
                    <asp:SqlDataSource ID="Sql_Address" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:BookClassConnectionString %>" 
                        SelectCommand="SELECT distinct [Address] FROM [ClassList]"></asp:SqlDataSource>
                    教室编号：<asp:DropDownList ID="Drop_ClassNum" runat="server" 
                        DataSourceID="Sql_ClassNum" DataTextField="ClassNum" 
                        DataValueField="ClassNum">
        </asp:DropDownList>
                    <asp:SqlDataSource ID="Sql_ClassNum" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:BookClassConnectionString %>" 
                        SelectCommand="SELECT [ClassNum] FROM [ClassList] WHERE ([Address] = @Address)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="Drop_Address" Name="Address" 
                                PropertyName="SelectedValue" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    起始时间：<asp:DropDownList ID="Drop_StartTime" runat="server" AutoPostBack="true" 
                        onselectedindexchanged="Drop_StartTime_SelectedIndexChanged" >
        </asp:DropDownList>
                    结束时间：<asp:DropDownList ID="Drop_EndTime" runat="server">
        </asp:DropDownList>
				    <asp:Button ID="Button1" runat="server" Text="查询" onclick="Button1_Click" />
				</div>
				<div id="info3">
					
					<span class="input">
					
					<span class="iconfont vertical-center">		
					</span>
					</span>
                    <asp:GridView ID="GridView_BookList" runat="server" Height="89px" 
                        Width="997px" Visible="False" AllowPaging="True" PageSize="16" 
                        CellPadding="4" ForeColor="#333333" GridLines="None" 
                        onpageindexchanging="GridView_BookList_PageIndexChanging" 
                        HorizontalAlign="Center" onrowediting="GridView_BookList_RowEditing" 
                        AutoGenerateColumns ="false" 
                        onrowcancelingedit="GridView_BookList_RowCancelingEdit" 
                        onrowupdating="GridView_BookList_RowUpdating">
                        <RowStyle HorizontalAlign="Center" />  
                        <AlternatingRowStyle BackColor="White" />
                        <EditRowStyle BackColor="#EFF3FB" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <FooterStyle BackColor="#6DBAF0" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#6DBAF0" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#6DBAF0" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        <Columns>
                            <asp:TemplateField FooterStyle-VerticalAlign="Middle" FooterStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                <EditItemTemplate>
                                    教室地址：<asp:Label ID="Label1" runat="server" Text='<%# Eval("Address") %>'></asp:Label>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 教室编号：<asp:Label ID="Label2" runat="server" Text='<%# Eval("ClassNum") %>'></asp:Label>
                                    &nbsp;<br /> <br />预约日期：<asp:Label ID="Label3" runat="server" 
                                        Text='<%# Eval("BookDate") %>'></asp:Label>
                                    &nbsp;&nbsp;&nbsp; 预约时间段：<asp:Label ID="Label4" runat="server" Text='<%# Eval("StartTime") %>'></asp:Label>
                                    --<asp:Label ID="Label5" runat="server" Text='<%# Eval("EndTime") %>'></asp:Label>
                                    <br />
                                    <br />
                                    预约用途：<br /> <br/> <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" 
                                        ></asp:TextBox>
                                    <br />
                                    <br />
                                    <asp:Button ID="Button2" runat="server" CommandName="Update" Text="提交" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="Button3" runat="server" CommandName="Cancel" Text="取消" />
                                    <br />
                                </EditItemTemplate>
                                <ItemTemplate>
                                <table style="width: 1049px">
                                <tr>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("ID") %>'></asp:Label></td>
                                    <td><asp:Label ID="Label7" runat="server" Text='<%# Eval("Address") %>'></asp:Label>
                                        </td><td><asp:Label ID="Label8" runat="server" Text='<%# Eval("ClassNum") %>'></asp:Label></td><td>
                                            <asp:Label ID="Label9" runat="server" Text='<%# Eval("BookDate") %>'></asp:Label></td><td>
                                                <asp:Label ID="Label10" runat="server" Text='<%# Eval("StartTime") %>'></asp:Label></td><td>
                                                    <asp:Label ID="Label11" runat="server" Text='<%# Eval("EndTime") %>'></asp:Label></td>
                                                    <td><asp:Label ID="Label12" runat="server" Text='<%# Eval("IsBooked") %>'></asp:Label></td>
                                <td><asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edit">点击预约</asp:LinkButton></td>
                                </tr>
                                </table>
                                </ItemTemplate>

<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>

<HeaderStyle HorizontalAlign="Right"></HeaderStyle>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
                            </asp:TemplateField>
                        </Columns>
            </asp:GridView>
				</div>
			</form><!--  form seat-info结束 -->
			<div class="seat-map" id="seat-map"></div>
		</div>
	</div>
</body>
</html>