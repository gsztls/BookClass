<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddAccount.aspx.cs" Inherits="Admin_AccountManagement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<meta charset="UTF-8"/>
	<meta http-equiv="X-UA-Compatible" content="IE=edge"/>  <!-- 以上代码告诉IE浏览器，IE8/9及以后的版本都会以最高版本IE来渲染页面。 -->  
	<meta name="viewport" content="width=device-width, initial-scale=1"/>
	<title>账号管理——中南大学教室预约系统管理员</title>
	<link rel="stylesheet" href="../css/normalize.css"/>
	<link rel="stylesheet" href="../css/common.css"/>
	<link rel="stylesheet" href="../css/room_select.css"/>
    <style type="text/css">
        .style3
        {
            height: 445px;
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
            height: 445px;
            width: 93px;
        }
        .style7
        {
            height: 445px;
            width: 693px;
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
				<span class="item-info" style="display: none;">账号管理</span>
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
			<span class="triangle" style="left: 325px;"></span>
		</nav>
		<div class="seat-content">
			<form id="Form1" runat="server">
				<div id="info1">
					<br />
				</div>
				<div id="info3">
					
					<span class="input">
					
					<span class="iconfont vertical-center">		
					</span>
                    <table style="width: 1068px; height: 479px">
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
                    
                    <td class="style6" style="font-size: medium">
                        &nbsp;</td>
                    
                    <td class="style7" style="font-size: medium">
                        学号<a style="font-size:smaller">（或学工号）</a>：<asp:TextBox ID="TxtStuId" 
                            runat="server"></asp:TextBox>
					
					<span class="input">
					
					    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ErrorMessage="学号或学工号不能为空！" ForeColor="Red" ControlToValidate="TxtStuId"></asp:RequiredFieldValidator>
					</span>
				        <br />
                        姓&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 名：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
                        <asp:TextBox ID="TxtName" 
                            runat="server"></asp:TextBox>
					
					<span class="input">
					
					    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ErrorMessage="姓名不能为空！" ForeColor="Red" ControlToValidate="TxtName"></asp:RequiredFieldValidator>
					</span>
				        <br />
                        密&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 码：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                        <asp:TextBox ID="TxtPwd" 
                            runat="server"></asp:TextBox>
					
					<span class="input">
					
					    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ErrorMessage="密码不能为空！" ForeColor="Red" ControlToValidate="TxtPwd"></asp:RequiredFieldValidator>
					</span>
				        <br />
                        确认密码：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; 
                        <asp:TextBox ID="TxtRpwd" runat="server"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" 
                            ControlToCompare="TxtPwd" ControlToValidate="TxtRpwd" ErrorMessage="两次密码不一致！" 
                            ForeColor="Red"></asp:CompareValidator>
                        <br />
                        用户类型：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; 
                        <asp:DropDownList ID="DropType" runat="server">
                        </asp:DropDownList>
                        <br />
                        <br />
                        <br />
                        <asp:Button ID="Button1" runat="server" Text="提交" onclick="Button1_Click" />
                        </td>
                    
                    <td class="style3" style="font-size: medium">
                        &nbsp;</td></tr>
                    
                    
                    </table>
					</span>
				</div>
			</form><!--  form seat-info结束 -->
			<div class="seat-map" id="seat-map"></div>
		</div>
	</div>
</body>
</html>
