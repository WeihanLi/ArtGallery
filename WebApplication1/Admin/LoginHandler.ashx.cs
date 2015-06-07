using System;
using System.Collections.Generic;
using System.Web;
using System.Web.SessionState;

namespace WebApplication1.Admin
{
    /// <summary>
    /// LoginHandler
    /// </summary>
    public class LoginHandler : IHttpHandler,IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string uid = context.Request["username"], pwd = context.Request["password"],action=context.Request["action"];
            if (String.IsNullOrEmpty(uid)||String.IsNullOrEmpty(pwd))
            {
                context.Response.Write("<html><body><<script>alert('用户名或密码不完整，请重试');location.href='/Admin/login.html'</script></body></html>");
                context.Response.End();
                return;
            }
            Model.User u = new Model.User { UserName = uid, UserPassword = Common.SecurityHelper.Encrypt(pwd) };
            
            if (action.Equals("login"))
            {
                if (new BLL.UserBLL().Login(u))
                {
                    context.Session["User"] = u;
                    if (new BLL.UserBLL().IsAdmin(u.UserName))
                    {
                        context.Session["Admin"] = u.UserName;
                    }
                    context.Response.Redirect("~/Admin/Default.aspx");
                    //context.Response.Write("true");
                }
                else
                {
                    context.Response.Write("<html><body><script>alert('用户名或密码错误');location.href='/Admin/login.html'</script></body></html>");
                    //context.Response.Redirect("~/Admin/login.html");
                }
            }
            else
            {
                if (new BLL.UserBLL().Login(u))
                {
                    context.Response.Write("true");
                }
                else
                {
                    context.Response.Write("false");
                }
            }
          
            
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}