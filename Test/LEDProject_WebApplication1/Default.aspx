<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LEDProject_WebApplication1.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            选择控制卡地址:&nbsp;
            <asp:DropDownList ID="comboBox1" runat="server" Height="31px" OnSelectedIndexChanged="comboBox1_SelectedIndexChanged" Width="188px">
                <asp:ListItem Value="0"></asp:ListItem>
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem Value="2"></asp:ListItem>
                <asp:ListItem Value="3"></asp:ListItem>
                <asp:ListItem Value="4"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <p>
            1、添加节目索引&nbsp; 
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="添加节目" />
&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="删除节目" />
        </p>
        <p>
            <asp:Label ID="label1" runat="server" Text="请先添加节目！"></asp:Label>
        </p>
        <p>
            2、向节目里面添加内容&nbsp; <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" style="height: 27px" Text="添加文本" />
&nbsp;&nbsp;
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="添加单行文本" />
        </p>
        <p>
            <asp:TextBox ID="ZoneText" runat="server" Width="872px">欢迎使用EQ\n二次开发动态\n测试用例开发</asp:TextBox>
        </p>
        <p>
            3、向显示屏发送数据 <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="发送数据" />
        </p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            处理结果：<asp:TextBox ID="txtResult" runat="server" Width="246px"></asp:TextBox>
        </p>
    </form>
</body>
</html>
