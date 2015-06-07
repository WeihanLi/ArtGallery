<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyContentList.ascx.cs" Inherits="WebApplication1.CustomControl.MyContentList" %>
<asp:Repeater ID="repDataList" runat="server">
    <ItemTemplate>
        <tr id='<%# Eval("ItemId", "news-{0}") %>'>
            <td class="con_td_left"><%# Eval("ItemName") %> </td>
            <td class="con_td_center"><a href='<%# Eval("ItemId", "ContentEdit-{0}.aspx") %>'>编辑</a></td>
            <td class="con_td_right"><a href="#" onclick='<%# Eval("ItemId", "DeleteNews({0})") %>'> <img src="../images/cms_delcontent.jpg" /></a> </td>
        </tr>
    </ItemTemplate>
</asp:Repeater>
<tr><td><asp:Label ID="lblTip" runat="server" Visible="false" Text=""></asp:Label></td></tr>
<tr><td colspan="3" id="page"> <asp:Label ID="lblIndex" runat="server" Text="1"/>/<asp:Label ID="lblCount" runat="server" Text="1"/> 页  <asp:LinkButton ID="btnUp" Enabled="false" OnClick="btnUp_Click" Text="&lt;&lt;上一页" runat="server" /> <asp:LinkButton ID="btnNext" Enabled="false" OnClick="btnNext_Click" Text="下一页&gt;&gt;" runat="server" /></td></tr>
