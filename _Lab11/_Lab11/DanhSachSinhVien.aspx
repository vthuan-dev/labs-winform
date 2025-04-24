<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DanhSachSinhVien.aspx.cs" Inherits="_Lab11.Properties.DanhSachSinhVien" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div>
        <asp:Label ID="Label1" runat="server" Text="Danh Sách Sinh Viên "></asp:Label>
        <asp:Label ID="txtDisplay" runat="server" Text=""></asp:Label>
    </div>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="StudentList" runat="server" 
               DataKeyNames="MSSV"
               AutoGenerateColumns="false"
               OnSelectedIndexChanged="StudentList_SelectedIndexChanged" OnRowUpdating="StudentList_RowUpdating"
               OnRowEditing="StudentList_RowEditing" OnRowUpdated="StudentList_RowUpdated"  
                OnRowCancelingEdit="StudentList_RowCancelingEdit">
                <Columns>
                     <asp:BoundField DataField="MSSV" HeaderText="MSSV" ReadOnly="True" />
                     <asp:BoundField DataField="HoTen" HeaderText="Họ Tên" ReadOnly="True" />
                    
                     <asp:TemplateField HeaderText="Điểm"> 
                         <ItemTemplate>
                            <asp:Label ID="lblDiem" runat="server" Text='<%# Eval("Diem") %>'></asp:Label>
                         </ItemTemplate>
                         <EditItemTemplate>
                             <asp:TextBox ID="txtDiem" runat="server" Text='<%# Bind("Diem") %>'></asp:TextBox>
                         </EditItemTemplate>
                     </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True"/>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
