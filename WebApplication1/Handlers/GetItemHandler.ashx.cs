using System;
using System.Web;

namespace WebApplication1.Handlers
{
    /// <summary>
    /// Summary description for GetItemHandler
    /// </summary>
    public class GetItemHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int itemId = -1;
            int.TryParse(context.Request["id"], out itemId);
            if (itemId <= 0)
            {
                context.Response.Write("error");
                return;
            }
            string action = context.Request["action"];
            try
            {
                BLL.ItemBLL helper = new BLL.ItemBLL();
                Model.Item item = null;
                if (action == "next")
                {
                    item = helper.SelectNext(itemId);
                }
                else
                {
                    item = helper.SelectPrevious(itemId);
                }
                if (item != null)
                {
                    context.Response.Write(item.ItemPath);
                }
            }
            catch (Exception ex)
            {
                context.Response.Write("error");
                new Common.LogHelper(typeof(GetItemHandler)).Error(ex);
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