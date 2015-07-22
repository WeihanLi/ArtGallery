using System.Web;
using System.Web.SessionState;

namespace WebApplication1.Admin
{
    /// <summary>
    /// Summary description for DeleteNewsHandler
    /// </summary>
    public class DeleteNewsHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            BLL.ItemBLL helper = new BLL.ItemBLL();
            //判断Session，验证权限
            if (context.Session["User"] != null)
            {
                int id = -1;
                int.TryParse(context.Request["id"], out id);
                if (id > 0)
                {
                    string path = context.Server.MapPath(helper.Select(id).ItemPath);
                    if (helper.Delete(id))
                    {
                        try
                        {
                            System.IO.File.Delete(path);
                        }
                        catch (System.Exception)
                        {
                            new Common.LogHelper(typeof(DeleteNewsHandler)).Error("文件删除失败");
                        }
                        context.Response.Write("true");
                        context.Response.End();
                    }
                }
                context.Response.Write("false");
            }
            else
            {
                context.Response.Write("no permission！");
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
