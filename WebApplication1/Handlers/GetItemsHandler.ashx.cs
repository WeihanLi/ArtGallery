using System;
using System.Collections.Generic;
using System.Web;

namespace WebApplication1.Handlers
{
    /// <summary>
    /// Summary description for GetItemsHandler
    /// </summary>
    public class GetItemsHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int id = int.Parse(context.Request["id"]);
            if (id<=0)
            {
                return;
            }
            try
            {
                List<Model.Item> items = new BLL.ItemBLL().SelectOdd(id, 9);
                string jsons = Common.ConverterHelper.ObjectToJson(items);
                context.Response.Write(jsons);
            }
            catch (Exception ex)
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