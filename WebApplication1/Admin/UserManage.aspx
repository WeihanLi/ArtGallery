<%@ Page Title="用户管理" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="UserManage.aspx.cs" Inherits="WebApplication1.Admin.UserManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
    function Delete(id){
        if (confirm('确定删除？')) {
            $.post("DeleteUserHandler.ashx", { "id": id }, function (data) {
                if (data == "true") {
                    $("#user-" + id).hide();
                }
                else {
                    alert("发生异常 "+data);
                }
            });
        }
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content_hea">
            <div id="content_hea_o">
                管理员管理
            </div>
            </div>
            <div id="button_div">
                <div class="button_column"><a href="AddUser.aspx"><img src="../images/cms_adduser.jpg" /></a></div>
            </div>
            <div id="content_user">
               <table id="user_table" cellspacing="0">
                   <tr style="background:#f5f5f5;">
                       <td style="border-right:1px #cdcdcd solid" class="name">账号</td>
                       <td style="border-right:1px #cdcdcd solid"  class="time">创建日期</td>
                       <td style="border-right:1px #cdcdcd solid"  class="user">角色</td>
                       <td style="border-right:1px #cdcdcd solid"  class="user"></td>
                       <td class="td_input"></td>
                   </tr>
                   <tr>
                       <td class="name">admin</td>
                       <td class="time">2015-04-01</td>
                       <td class="user">超级管理员</td>
                       <td class="user"></td>
                       <td class="td_input"></td>
                   </tr>
                   <asp:Repeater ID="repUserList" runat="server">
                       <ItemTemplate>
                           <tr id='<%# Eval("UserId","user-{0}") %>'>
                               <td class="name"><%# Eval("UserName") %> </td>
                               <td class="time"> <%# ((DateTime)Eval("AddTime")).ToString("yyyy-MM-dd") %> </td>
                               <td class="user">管理员</td>
                               <td class="user"></td>
                               <td class="td_input"><%--<input type="image" src="../images/cms_deluser.jpg" onclick='<%# Eval("UserId","Delete({0})") %>' />--%>
                                   <a href="#" onclick='<%# Eval("UserId","Delete({0})") %>'><image src="../images/cms_deluser.jpg" alt="Delete" /> </a>
                               </td>
                           </tr>
                       </ItemTemplate>
                   </asp:Repeater>
               </table>
            </div>
    <div id="page"> <asp:Label ID="lblIndex" runat="server" Text="1"/>/<asp:Label ID="lblCount" runat="server" Text="1"/> 页  <asp:LinkButton ID="btnUp" OnClick="btnUp_Click" Text="上一页" runat="server" /> <asp:LinkButton ID="btnNext" OnClick="btnNext_Click" Text="下一页" runat="server" /></div>
</asp:Content>
