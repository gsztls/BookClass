<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta charset="UTF-8"/>
	<meta http-equiv="X-UA-Compatible" content="IE=edge"/>  <!-- 以上代码告诉IE浏览器，IE8/9及以后的版本都会以最高版本IE来渲染页面。 -->  
	<meta name="viewport" content="width=device-width, initial-scale=1"/>
	<title>中南大学教室预约管理系统——登录</title>
	<link rel="stylesheet" href="css/normalize.css"/>
	<link rel="stylesheet" href="css/common.css"/>
	<link rel="stylesheet" href="css/main.css"/>
</head>
<body>
	<header>
		<div class="logo">
			<img src="images/logo1.png" alt="中南大学logo" class="logo-img vertical-center"/>
			<h1 class="vertical-center">教室预约管理系统</h1>
		</div>
	</header><!-- header结束 -->
	<div class="login-container">
		<section class="img-display vertical-center">
			<img src="images/library.png" alt=""/>
			<img src="images/books1.png" alt=""/>
			<img src="images/seat.png" alt=""/>
			<img src="images/computer.png" alt=""/>
		</section>
		<section class="login vertical-center">
			<form id="mylogin" runat="server">
				<div><span>学号：</span><asp:TextBox id="login_num" maxlength="11" runat="server"></asp:TextBox>
                   
                </div>
				<div><span>密码：</span><asp:TextBox  id="login_pwd" runat="server" TextMode="Password"></asp:TextBox>
                    
                </div>
				<asp:button class="login-btn" runat ="server" Text="登录" 
                    onclick="Unnamed1_Click"></asp:button>
			</form>
		</section>
	</div>	
</body>
</html>