using System;
using System.Web;
using System.Web.SessionState;

namespace WebApplication1.Admin
{
    /// <summary>
    /// Summary description for AddNewsHandler
    /// </summary>
    public class AddNewsHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //判断Session，验证权限
            if (context.Session["User"] != null)
            {
                string itemName = context.Request["name"], itemDesc = context.Request["desc"], author = context.Request["author"], imgPath = context.Request["imagePath"],type=context.Request["type"];
                int nType = -1;
                int.TryParse(type, out nType);
                //构建路径
                //string path = DateTime.Now.ToString("yyyyMM\\/") + Guid.NewGuid().ToString() + ".html";
                string path = DateTime.Now.ToString("yyyyMM\\/") + DateTime.Now.ToString("yyyyMMddHHmmssfff")+".html";
                //
                string virtualPath = "/works/" + path;
                if (nType<=0|String.IsNullOrEmpty(itemName) || String.IsNullOrEmpty(imgPath) || String.IsNullOrEmpty(path))
                {
                    return;
                }
                Model.Item item = new Model.Item() { ItemName = itemName, ItemDesc = itemDesc,ItemTypeId=nType, ItemAuthor = author, ItemPath = virtualPath, PublishTime = DateTime.Now, ItemImagePath = imgPath };
                if (new BLL.ItemBLL().Add(item))
                {
                    context.Response.Write("true");
                }
                else
                {
                    context.Response.Write("false");
                }
            }
            else
            {
                context.Response.Write("no permission");
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