<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerList.aspx.cs" Inherits="Register.CustomerList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-top: 0px;
        }

        .hidden-col {
            display: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div style="background-color: #666699; font-weight: bold; color: #FFFFFF; margin-bottom: 10px;">
                <asp:Label ID="Label1" runat="server" Text="Danh sách khách hàng"></asp:Label>
            </div>
        </div>
        <asp:GridView ID="grvCustomerList" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" CssClass="auto-style1" ForeColor="Black" GridLines="Vertical" Height="229px" OnPageIndexChanging="grvCustomerList_PageIndexChanging" OnRowEditing="grvCustomerList_RowEditing" OnRowUpdating="grvCustomerList_RowUpdating" PageSize="5" Width="934px" OnRowCancelingEdit="grvCustomerList_RowCancelingEdit" DataKeyNames="MaKH" OnRowDeleting="grvCustomerList_RowDeleting">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:BoundField DataField="MaKH" HeaderText="Mã KH" HeaderStyle-CssClass="hidden-col" ItemStyle-CssClass="hidden-col" />
                <asp:BoundField DataField="TenDN" HeaderText="Tên đăng nhập" ReadOnly="True">
                <HeaderStyle BorderStyle="None" />
                </asp:BoundField>
                <asp:BoundField DataField="HoTen" HeaderText="Họ tên">
                <HeaderStyle BorderStyle="None" />
                </asp:BoundField>
                <asp:BoundField DataField="NgaySinh" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Ngày sinh">
                <HeaderStyle BorderStyle="None" />
                </asp:BoundField>
                <asp:CheckBoxField DataField="GioiTinh" HeaderText="Phái">
                <HeaderStyle BorderStyle="None" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:CheckBoxField>
                <asp:BoundField DataField="Email" HeaderText="Email">
                <HeaderStyle BorderStyle="None" />
                </asp:BoundField>
                <asp:CommandField SelectText="Chọn" ShowSelectButton="True" ItemStyle-HorizontalAlign="Center">
                <HeaderStyle BorderStyle="None" />
                <ItemStyle BorderStyle="None" />
                </asp:CommandField>
                <asp:CommandField CancelText="Hủy" EditText="Sửa" ShowEditButton="True" UpdateText="Cập nhật" ItemStyle-Width="100" ItemStyle-HorizontalAlign="Center">
                <HeaderStyle BorderStyle="None" />
                <ItemStyle BorderStyle="None" />
                </asp:CommandField>
                <asp:CommandField DeleteText="Xóa" ShowDeleteButton="True" ItemStyle-HorizontalAlign="Center">
                <HeaderStyle BorderStyle="None" />
                <ItemStyle BorderStyle="None" />
                </asp:CommandField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        <p>
            <asp:Label ID="lblErrorMsg" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
