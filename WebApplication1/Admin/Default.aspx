<%@ Page Title="内容管理" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1.Admin.Default" %>
<%@ Register Src="~/CustomControls/MyContentList.ascx" TagPrefix="uc1" TagName="MyContentList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function DeleteNews(index) {
            if (confirm("确定删除？")) {
                $.post("DeleteNewsHandler.ashx", { "id": index }, function (data) {
                    if (data == "true") {
                        var box = document.getElementById("news-" + index);
                        box.style.display = 'none';
                    }
                    else {
                        alert("删除失败，请稍后重试" + data);
                    }
                });
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content_hea">
            <div id="content_hea_o">
                信息管理
            </div>
            </div>
            <div id="content_column">
                <table cellspacing="0">
                    <tr style="background:#f5f5f5;"><td></td></tr>
                    <asp:Repeater ID="repColumns" runat="server">
                        <ItemTemplate>                    
                            <tr><td><a href='<%# Eval("CategoryId", "Default-{0}.aspx") %>'><%#  Eval("CategoryName")%> </a></td></tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
            <div id="content_con_top">
                <div class="button_content"><a href="ContentManage.aspx"><img src="../images/cms_addcontent.jpg" /></a></div>
            </div>
            <div id="content_content">
                <table id="content_con_tab" cellspacing="0">
                    <tr style="background:#f5f5f5;">
                        <td class="con_td_left" align="center">作品名称</td>
                        <td class="con_td_center"></td>
                        <td class="con_td_right"></td>
                    </tr>
                    <uc1:MyContentList runat="server" id="MyContentList" />
                </table>
            </div> 
</asp:Content>
