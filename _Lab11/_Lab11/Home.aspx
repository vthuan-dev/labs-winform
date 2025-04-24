<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="_Lab11.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="title" runat="server" Text="TRANG CHỦ"></asp:Label>
        <div class="info_cont">
            <asp:Label ID="Label2" runat="server" Text="Chào "></asp:Label>
            <asp:Label ID="txtName" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Danh Sách Các Môn/Lớp"></asp:Label>
        </div>
        <div>
            <asp:GridView ID="tableCourse" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" OnSelectedIndexChanged="tableCourse_SelectedIndexChanged" AutoGenerateColumns ="false">
                <FooterStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:BoundField DataField="MaMon" HeaderText="Mã Môn" />
                    <asp:BoundField DataField="TenMon" HeaderText="Tên Môn" />
                    <asp:BoundField DataField="MaLop" HeaderText="Mã Lớp" />
                    <asp:BoundField DataField="TenLop" HeaderText="Tên Lớp" />
                    <asp:HyperLinkField DataNavigateUrlFormatString="DanhSachSinhVien.aspx?MaMon={0}&MaLop={1}" 
                    DataNavigateUrlFields="MaMon,MaLop" Text="Nhập điểm" HeaderText="Nhập điểm" />

                </Columns>
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                <RowStyle BackColor="White" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
        </div>
    </form>
</body>
</html>
