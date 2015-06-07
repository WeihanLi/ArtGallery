using System;
using System.Web.UI;

namespace WebApplication1.Admin
{
    public partial class UpdatePwd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnOk_Click(object sender, ImageClickEventArgs e)
        {
            Model.User sessionUser = Session["User"] as Model.User;
            Model.User u = new Model.User() { UserName = sessionUser.UserName , UserPassword = txtOldPwd.Text};
            if (String.IsNullOrEmpty(u.UserName) || String.IsNullOrEmpty(u.UserPassword) || !cvPwd.IsValid)
            {
                return;
            }
            u.UserPassword = Common.SecurityHelper.Encrypt(u.UserPassword);
            if (!sessionUser.UserPassword.Equals(u.UserPassword))
            {
                Response.Write("<script>alert('密码修改失败！原密码有误')</script>");
                return;
            }
            BLL.UserBLL helper = new BLL.UserBLL();
            u.UserPassword = Common.SecurityHelper.Encrypt(txtPwd.Text);
            if (helper.Update(u))
            {
                Session.Abandon();
                Response.Write("<script>alert('密码修改成功！请重新登录~~);location.href='/Admin/login.html'</script>");
            }
            else
            {
                Response.Write("<script>alert('密码修改失败！请稍后重试')</script>");
            }
        }
    }
}