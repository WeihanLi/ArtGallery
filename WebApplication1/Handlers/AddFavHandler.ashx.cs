using System.Web;

namespace WebApplication1.Handlers
{
    /// <summary>
    /// Summary description for AddFavHandler
    /// </summary>
    public class AddFavHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int itemId = -1;
            int.TryParse(context.Request["id"], out itemId);
            if (itemId<=0)
            {
                context.Response.Write("error");
                return;
            }
            BLL.ItemBLL helper = new BLL.ItemBLL();
            if (helper.AddFav(itemId))
            {
                context.Response.Write("true");
            }
            else
            {
                context.Response.Write("error");
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