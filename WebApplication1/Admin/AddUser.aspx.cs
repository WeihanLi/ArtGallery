using System;
using System.Web.UI;

namespace WebApplication1.Admin
{
    public partial class AddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            Model.User u = new Model.User() { UserName= txtUid.Text,UserPassword=txtPwd.Text,AddTime=DateTime.Now};
            if (String.IsNullOrEmpty(u.UserName)||String.IsNullOrEmpty(u.UserPassword)||!cvPwd.IsValid)
            {
                return;
            }
            u.UserPassword = Common.SecurityHelper.Encrypt(u.UserPassword);
            BLL.UserBLL helper = new BLL.UserBLL();
            if (helper.ExistUserName(u.UserName))
            {
                Response.Write("<script>alert('添加失败！该用户名已经存在')</script>");
                return;
            }
            if (helper.Add(u))
            {
                Response.Redirect("UserManage.aspx");
            }
            else
            {
                Response.Write("<script>alert('添加失败！请稍后重试')</script>");
            }
        }
    }
}