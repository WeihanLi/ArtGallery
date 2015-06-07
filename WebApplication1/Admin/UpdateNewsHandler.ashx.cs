using System;
using System.Web;
using System.Web.SessionState;

namespace WebApplication1.Admin
{
    /// <summary>
    /// Summary description for UpdateNewsHandler
    /// </summary>
    public class UpdateNewsHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //判断Session，验证权限
            if (context.Session["User"] != null)
            {
                int id = -1,typeId=-1;
                int.TryParse(context.Request["id"],out id);
                string itemName = context.Request["name"], itemDesc = context.Request["desc"], author = context.Request["author"], imgPath = context.Request["imagePath"],type=context.Request["type"];
                int.TryParse(type , out typeId);
                if (typeId<=0||String.IsNullOrEmpty(itemName) || String.IsNullOrEmpty(imgPath))
                {
                    return;
                }
                Model.Item item = new Model.Item() { ItemTypeId=typeId,ItemId=id,ItemName = itemName, ItemDesc = itemDesc, ItemAuthor = author, ItemImagePath = imgPath };
                if (new BLL.ItemBLL().Update(item))
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