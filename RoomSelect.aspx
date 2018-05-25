<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RoomSelect.aspx.cs" Inherits="RoomSelect" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta charset="UTF-8"/>
	<meta http-equiv="X-UA-Compatible" content="IE=edge"/>  <!-- 以上代码告诉IE浏览器，IE8/9及以后的版本都会以最高版本IE来渲染页面。 -->  
	<meta name="viewport" content="width=device-width, initial-scale=1"/>
	<title>中南大学教室预约系统——教室查询</title>
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
			<img src="images/out.png" alt="注销登录" onclick = "Log_Off"/>
		</div>
	</header><!-- header结束 -->
	<div class="container">
		<nav class="nav-list">
			<a href="index.html" class="nav-item" id="nav-item1">
				<span class="iconfont">&#xe63e;</span>
				<span class="item-info">主页</span>
			</a>
			<a href="RoomSelect.aspx" class="nav-item" id="nav-item2">
				<span class="iconfont">&#xe604;</span>
				<span class="item-info">教室查询</span>
			</a>
			<a href="room_register.html" class="nav-item" id="nav-item3">
				<span class="iconfont">&#xe601;</span>
				<span class="item-info">联系管理员</span>
			</a>
			<a href="cancel_reserve.html" class="nav-item" id="nav-item4">
				<span class="iconfont">&#xe64a;</span>
				<span class="item-info">取消预约</span>
			</a>
			<a href="room_release.html" class="nav-item" id="nav-item5">
				<span class="iconfont">&#xe751;</span>
				<span class="item-info">可借教室</span>
			</a>
			<a href="reserve_record.html" class="nav-item" id="nav-item6">
				<span class="iconfont">&#xe610;</span>
				<span class="item-info">释放教室</span>
			</a>
			<a href="default_record.html" class="nav-item" id="nav-item7">
				<span class="iconfont">&#xe65f;</span>
				<span class="item-info">超时使用记录</span>
			</a>
			<a href="notice.html" class="nav-item" id="nav-item8">
				<span class="iconfont">&#xe600;</span>
				<span class="item-info">公告栏</span>
			</a>
			<span class="triangle"></span>
		</nav>
		<div class="seat-content">
			<form runat="server">
				<div id="info1">
					教室地址：<asp:DropDownList ID="Drop_Address" runat="server"
                        DataSourceID="Sql_Address" DataTextField="Address" 
                        DataValueField="Address"  onselectedindexchanged="Drop_Address_SelectedIndexChanged" AutoPostBack="true">
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
                        Width="1071px" Visible="False">
            </asp:GridView>
				</div>
			</form><!--  form seat-info结束 -->
			<div class="seat-map" id="seat-map"></div>
		</div>
	</div>
</body>
</html>