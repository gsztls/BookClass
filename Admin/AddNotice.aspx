﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddNotice.aspx.cs" Inherits="Notice" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    	<meta charset="UTF-8">
	<meta http-equiv="X-UA-Compatible" content="IE=edge">  <!-- 以上代码告诉IE浏览器，IE8/9及以后的版本都会以最高版本IE来渲染页面。 -->  
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<title>公告栏</title>
	<link rel="stylesheet" href="../css/normalize.css">
	<link rel="stylesheet" href="../css/common.css">
	<link rel="stylesheet" href="../css/notice.css">
        </head>
<body>
   <header>
		<div class="logo">
			<img src="../images/logo1.png" alt="华中师范大学logo" class="logo-img vertical-center">
			<h1 class="vertical-center">计算机实验室预约管理系统</h1>
		</div>
		<div class="logoff">
			<a href="#"><span><asp:label id="label_user" runat="server" Text="这里是姓名"></asp:label>（<asp:label ID="label_stuNum" runat="server" Text="这里是学号"></asp:label>）</span></a>
			<a href="../LogOff.aspx" ><img src="../images/out.png" alt="注销登录"/></a>
		</div>
	</header><!-- header结束 -->
    <div class="container">
		<nav class="nav-list">
			<a href="index.html" class="nav-item" id="nav-item1">
				<span class="iconfont">&#xe63e;</span>
				<span class="item-info">主页</span>
			</a>
			<a href="room_select.html" class="nav-item" id="nav-item2">
				<span class="iconfont">&#xe604;</span>
				<span class="item-info">预约实验室</span>
			</a>
			<a href="room_register.html" class="nav-item" id="nav-item3">
				<span class="iconfont">&#xe601;</span>
				<span class="item-info">联系管理员</span>
			</a>
			<a href="cancel_reserve.html" class="nav-item" id="nav-item4">
				<span class="iconfont">&#xe64a;</span>
				<span class="item-info">取消预约</span>
			</a>
			<a href="romm_release.html" class="nav-item" id="nav-item5">
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
		</nav>
        <form id="form1" runat="server">
    
		<div class="notice-content">
                </td></tr>
            </table>	
                公告标题：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
            <asp:TextBox ID="TxtTitle" runat="server" Width="548px"></asp:TextBox>
            <span class="input">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="TxtTitle" ErrorMessage="标题不能为空！" ForeColor="Red"></asp:RequiredFieldValidator>
            </span>
            <br />
                公告内容：&nbsp;&nbsp;<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TxtText" runat="server" TextMode="MultiLine"></asp:TextBox>
            <span class="input">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                ControlToValidate="TxtText" ErrorMessage="公告内容不能为空！" ForeColor="Red"></asp:RequiredFieldValidator>
            </span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
            <br />
                <br />
            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="发布公告" />
		&nbsp;&nbsp;&nbsp;
		</div>
	</div>
    </form>
</body>
</html>
