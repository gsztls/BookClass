<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowNotice.aspx.cs" Inherits="Notice" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    	<meta charset="UTF-8">
	<meta http-equiv="X-UA-Compatible" content="IE=edge">  <!-- 以上代码告诉IE浏览器，IE8/9及以后的版本都会以最高版本IE来渲染页面。 -->  
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<title>查看公告——中南大学教室预约管理系统</title>
	<link rel="stylesheet" href="css/normalize.css">
	<link rel="stylesheet" href="css/common.css">
	<link rel="stylesheet" href="css/notice.css">
</head>
<body>
   <header>
		<div class="logo">
			<img src="images/logo1.png" alt="华中师范大学logo" class="logo-img vertical-center">
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
    
		<div class="notice-content" style = "width:80%;margin:auto">
			
              <center> <a style="font-size: medium"> <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></a>
               <hr/>
               </center>
                <br />
                <br />
                <br />
                <a style="width:100%;text-align:center">&nbsp;<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></a>
           	
		
	</div>
    </form>
</body>
</html>
