<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddColumn.aspx.cs" Inherits="WebApplication1.Admin.AddColumn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content_hea">
        <div id="content_hea_o">
            信息管理 / 栏目管理
        </div>
    </div>
    <div id="addcolumn">
        <div id="addcolumn_hea">添加栏目</div>
        <table id="addcolumn_tab">
            <tr>
                <td class="addcolumn_left">栏目名称</td>
                <td class="addcolumn_right">
                    <asp:TextBox runat="server" ID="txtColumn"/> 
                </td>
            </tr>
        </table>
        <div class="addcolumn_button">
            <div class="addcolumn_but"> 
                <asp:ImageButton ID="btnAdd" OnClick="btnAdd_Click" ImageUrl="~/images/cms_add.jpg" runat="server" /></div>
                <div class="addcolumn_but"><a href="Default.aspx"><img src="../images/cms_cancel.jpg" /></a></div>
        </div>
    </div>
</asp:Content>
