<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminIndex.aspx.cs" Inherits="index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta charset="UTF-8"/>
	<meta http-equiv="X-UA-Compatible" content="IE=edge"/>  <!-- 以上代码告诉IE浏览器，IE8/9及以后的版本都会以最高版本IE来渲染页面。 -->  
	<meta name="viewport" content="width=device-width, initial-scale=1"/>
	<title>管理员主页——中南大学教室预约系统</title>
	<link rel="stylesheet" href="../css/normalize.css"/>
	<link rel="stylesheet" href="../css/common.css"/>
	<link rel="stylesheet" href="../css/main.css"/>
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
			<a href="#"><span><asp:label class="username" id="label_user" runat="server" Text="这里是姓名"></asp:label>（<asp:label class="usernum" ID="label_stuNum" runat="server" Text="这里是学号"></asp:label>）</span></a>
			<a href="../LogOff.aspx" ><img src="../images/out.png" alt="注销登录"/></a>
		</div>
	</header><!-- header结束 -->
	<div class="container">
		<section class="person-info box">
			<img src="../images/my.png" alt="用户图片" class="horizontal-center"/>
			<div class="horizontal-center">
				<span>姓名：<asp:label ID="label_Ouser" class="username" runat="server" Text="这里是姓名"></asp:label></span>
				<span>学工号：<asp:label ID="label_OstuNum" class="usernum" runat="server" Text="这里是学号"></asp:label></span>
			</div>
		</section>
		<section class="seat-select box">
			<img src="../images/seat1.png" alt="申请处理" class="horizontal-center"/>
			<span class="horizontal-center">申请处理</span>
			<a href="DealRequre.aspx"></a>
		</section>
		<section class="seat-operate">
			<div class="register box">
				<img src="../images/write.png" alt="账号管理" class="vertical-center"/>
				<span class="vertical-center">账号管理</span>
				<a href="AccountManagement.aspx"></a>
			</div>
			<div class="cancel-reserve box">
				<img src="../images/delete.png" alt="系统设置" class="vertical-center"/>
				<span class="vertical-center">系统设置</span>
				<a href="Setting.aspx"></a>
			</div>
		</section>
		<section class="seat-release box">
			<img src="../images/recyle.png" alt="教师列表" class="horizontal-center"/>
			<span class="horizontal-center">教室列表</span>
			<a href="ClassList.aspx"></a>
		</section>
		<section class="reserve-record box">
			<img src="../images/record.png" alt="教室管理" class="vertical-center"/>
			<span class="vertical-center">教室管理</span>
			<a href="ClassManagement.aspx"></a>
		</section>
		<section class="notice-board box">
			<img src="../images/warning.png" alt="公告管理" class="vertical-center"/>
			<div class="notice-info vertical-center">
				<h3>公告管理</h3>
			</div>
			<a href="ManageNotice.aspx"></a>
		</section>
		<section class="default-record box">
			<img src="../images/wrong.png" alt="更多功能" class="vertical-center"/>
			<span class="vertical-center">更多功能研发中……</span>
		</section>
	</div><!-- container结束 -->
</body>
</html>