<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="_Lab11.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login_cont">
            <asp:Label ID="Label3" runat="server" Text="Login" CssClass="title"></asp:Label>
            <div class="input-group">
                <asp:Label ID="Label1" runat="server" Text="Mã cán bộ" CssClass="label"></asp:Label>
                <asp:TextBox ID="txtMCB" runat="server" CssClass="textbox"></asp:TextBox>
            </div>
            <div class="input-group">
                <asp:Label ID="Label2" runat="server" Text="Mật khẩu" CssClass="label"></asp:Label>
                <asp:TextBox ID="txtPass" runat="server" CssClass="textbox"></asp:TextBox>
            </div>
            <div class="btn-group">
                <asp:Button ID="Button1" runat="server" Text="Exit" CssClass="btn btn-exit" OnClick="Button1_Click" />
                <asp:Button ID="Button2" runat="server" Text="Login" CssClass="btn btn-login" OnClick="Button2_Click"/>
            </div>
            <asp:Label ID="txtMessage" runat="server" Text="" CssClass="error"></asp:Label>
        </div>
        
        <style>
            body{
                display: flex;
                justify-content: center;
                align-items: center;
                height: 100vh;
                background-color: black;
                margin: 0;
            }
            .title{
                font-size:25px;
                font-weight: bold;
                display: block;
                margin-bottom: 20px;
            }
            .textbox{
                flex: 1;
                padding: 8px;
                border: 1px solid black;
            }
            .input-group {
                display: flex;
                align-items: center;
                justify-content:center;
                margin-bottom: 15px;
            }
            .login_cont {

                background-color: white;
                padding: 40px;
                border-radius: 8px;
                box-shadow: 2px 2px 10px rgba(255, 255, 255, 0.2);
                text-align: center;
                width: 500px;
            }
            .label {
                width: 100px;
                font-size: 14px;
                margin-right: 10px;
                font-weight: bold;
            }
            .btn-group{
                background-color: white;
                display: flex;
                justify-content: space-between;
                align-items: center;
            }
            .btn-group .btn{
                padding: 5px 10px;
                border: none;
                border-radius: 5px;
                cursor: pointer;
                flex: 1;
                margin: 5px 10px;
            }
            .btn-group .btn-exit{
                background-color: darkred;
                color: white;
            }
            .btn-group .btn-login{
                background-color: deepskyblue;
                color: black;
            }
            .error{
                color: red;
            }
        </style>
    </form>
</body>
</html>
