using System;
using System.Collections.Generic;
using System.Web;

namespace WebApplication1.Handlers
{
    /// <summary>
    /// Summary description for LoadImagesHandler
    /// </summary>
    public class LoadImagesHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int pageIndex = -1, pageSize = -1,order=0,type=-1;
            int.TryParse(context.Request["pIndex"], out pageIndex);
            int.TryParse(context.Request["pSize"], out pageSize);
            int.TryParse(context.Request["order"],out order);
            int.TryParse(context.Request["type"], out type);
            if (pageIndex<=0||pageSize<=0)
            {
                context.Response.Write("error");
                return;
            }
            try
            {
                List<Model.Item> items = null;
                if (type <= 0)
                {
                    items = new BLL.ItemBLL().SelectPageList(pageIndex, order > 0 ? true : false, pageSize);
                }
                else
                {
                    items = new BLL.ItemBLL().SelectPageListByCategory(type, pageIndex, pageSize, order > 0 ? true : false);
                }
                string jsons = Common.ConverterHelper.ObjectToJson(items);
                context.Response.Write(jsons);
            }
            catch (Exception ex)
            {
                context.Response.Write("error");
                new Common.LogHelper(typeof(LoadImagesHandler)).Error(ex);
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