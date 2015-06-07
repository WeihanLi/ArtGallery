using System;
using System.Collections.Generic;
using System.Web;
using System.Web.SessionState;

namespace WebApplication1.Admin
{
    /// <summary>
    /// Summary description for LogOutHandler
    /// </summary>
    public class LogOutHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Session.Clear();
            context.Response.Write("true");
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