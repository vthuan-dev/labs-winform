<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FillingForm.aspx.cs" Inherits="Register.FillingForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 30%;
            height: 50px;
        }

        .auto-style2 {
            width: 70%;
            height: 50px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-right: auto; margin-left: auto; text-align: center">
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Đăng ký khách hàng"></asp:Label>
        </div>
        <div style="background-color: #3333CC; color: #FFFFFF; font-weight: bold">
            <asp:Label ID="Label3" runat="server" Text="Thông tin đăng nhập"></asp:Label>
        </div>
        <table style="width: 100%">
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label1" runat="server" Text="Tên đăng nhập"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtTenDN" runat="server" Width="400px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rf_TenDN" runat="server" ControlToValidate="txtTenDN" ErrorMessage="Tên đăng nhập không được rỗng">(*)</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label6" runat="server" Text="Mật khẩu"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtMK" runat="server" Width="400px" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rf_MK" runat="server" ControlToValidate="txtMK" ErrorMessage="Mật khẩu không được rỗng">(*)</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 30%" class="auto-style1">
                    <asp:Label ID="Label7" runat="server" Text="Nhập lại mật khẩu"></asp:Label>
                </td>
                <td style="width: 70%" class="auto-style2">
                    <asp:TextBox ID="txtNhapLaiMK" runat="server" Width="400px" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rf_NhapLai" runat="server" ControlToValidate="txtNhapLaiMK" Display="Dynamic" ErrorMessage="Nhập lại mật khẩu không được rỗng">(*)</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cv_NhapLai" runat="server" ControlToCompare="txtMK" ControlToValidate="txtNhapLaiMK" ErrorMessage="Mật khẩu nhập lại chưa đúng">(*)</asp:CompareValidator>
                </td>
            </tr>
        </table>
        <div style="background-color: #3333CC; color: #FFFFFF; font-weight: bold">
            <asp:Label ID="Label4" runat="server" Text="Chi tiết"></asp:Label>
        </div>

        <table style="width: 100%">
            <tr>
                <td class="auto-style1">Họ tên khách hàng</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtKH" runat="server" Width="400px"></asp:TextBox>

                    <asp:RequiredFieldValidator ID="rf_KH" runat="server" ControlToValidate="txtKH" ErrorMessage="Họ tên khách hàng không được rỗng">(*)</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Ngày sinh</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtNgaySinh" runat="server" Width="400px" TextMode="Date"></asp:TextBox>
                    <asp:CompareValidator ID="cv_NgaySinh" runat="server" ControlToValidate="txtNgaySinh" ErrorMessage="Ngày sinh không hợp lệ" Operator="DataTypeCheck" Type="Date">(*)</asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Giới tính</td>
                <td class="auto-style2">
                    <asp:RadioButton ID="radNam" runat="server" Text="Nam" />
                    <asp:RadioButton ID="radNu" runat="server" Text="Nữ" Style="margin-left: 80px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Email</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtEmail" runat="server" Width="400px"></asp:TextBox>

                    <asp:RegularExpressionValidator ID="rev_Email" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email không hợp lệ" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">(!)</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Thu nhập</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtThuNhap" runat="server" Width="400px"></asp:TextBox>
                    <asp:RangeValidator ID="rv_ThuNhap" runat="server" ControlToValidate="txtThuNhap" ErrorMessage="Thu nhập từ 1 đến 50 triệu" MaximumValue="50000000" MinimumValue="1000000">(!)</asp:RangeValidator>
                </td>
            </tr>
        </table>

        <div style="text-align: center">
            <asp:Button ID="btnDangKy" runat="server" Text="Đăng ký" OnClick="btnDangKy_Click" />
            <br />
            <asp:Label ID="lblThongBao" runat="server"></asp:Label>
        </div>
        <div style="text-align: center; list-style-position: inside;">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        </div>
    </form>
</body>
</html>
