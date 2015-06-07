using System;
using System.Collections.Generic;
using System.Web;

namespace WebApplication1.Admin
{
    /// <summary>
    /// Summary description for ExistNameHandler
    /// </summary>
    public class ExistNameHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (new BLL.UserBLL().ExistUserName(context.Request["uid"]))
            {
                context.Response.Write("true");
            }
            else
            {
                context.Response.Write("flase");
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