<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManageNotice.aspx.cs" Inherits="Notice" %>

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
        <style type="text/css">
            .style3
            {
                width: 1427px;
                height: 66px;
            }
            .style4
            {
                width: 4265px;
                height: 66px;
            }
            .style5
            {
                width: 85px;
                height: 66px;
            }
            .style6
            {
                height: 66px;
            }
        </style>
    <script language="javascript" type="text/javascript">
// <![CDATA[

        function TextArea1_onclick() {

        }

// ]]>
    </script>
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
			<span class="triangle"></span>
		</nav>
    <form id="form1" runat="server">
    
		<div class="notice-content">
			<asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" 
                    Width="840px" CellPadding="4" ForeColor="#333333" 
                style="margin-top: 0px" ondeletecommand="DataList1_DeleteCommand" 
                oncancelcommand="DataList1_CancelCommand" oneditcommand="DataList1_EditCommand" 
                onupdatecommand="DataList1_UpdateCommand">
                    <AlternatingItemStyle BackColor="White" />
                    <EditItemTemplate>
                        公告标题：<asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("Title") %>'></asp:TextBox>
                        <br />
                        公告内容：<asp:TextBox ID="TextBox2" runat="server" Height="167px" 
                            Text='<%# Eval("Text") %>' TextMode="MultiLine" Width="532px"></asp:TextBox>
&nbsp;<asp:LinkButton ID="LinkButton3" runat="server" CommandName="Update" ForeColor="#0066D6">保存</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton4" runat="server" CommandName="Cancel" 
                            ForeColor="#0066D6">取消</asp:LinkButton>
                    </EditItemTemplate>
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#6DBAF0" Font-Bold="True" ForeColor="White" />
                    <HeaderTemplate>
                        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="添加公告" 
                            BackColor="#33CCFF" />
                    </HeaderTemplate>
                    <ItemStyle BackColor="#EFF3FB" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemTemplate>
                        <table style="width:100%;">
                            <tr>
                                <td class="style4">
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Title") %>'></asp:Label>
                                   
                                </td>
                                <td class="style3">
                                     <asp:Label ID="Label2" runat="server" Text='<%# Eval("Time") %>'></asp:Label></td>
                                <td class="style5">
                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edit" 
                                        ForeColor="#0066D6">编辑</asp:LinkButton>
                                </td>
                                <td class="style6">
                                    <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Delete" 
                                        ForeColor="#0066D6">删除</asp:LinkButton>
                                </td>
                            </tr>
                           
                        </table>
                    </ItemTemplate>
                    <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                </asp:DataList>
                
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:BookClassConnectionString %>" 
                    SelectCommand="SELECT [Title], [Text], [Time], [ID] FROM [Notice]">
                </asp:SqlDataSource>
                </td></tr>
            </table>	
		</div>
	</div>
    </form>
</body>
</html>
