using System;
using System.Collections.Generic;
using System.Web;

namespace WebApplication1.Admin
{
    /// <summary>
    /// Summary description for SelectNewsTypeHandler
    /// </summary>
    public class SelectNewsTypeHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //Model.FormatModel.JsonMsgModel msg = null;
            try
            {
                List<Model.Category> types = new BLL.CategoryBLL().Select();
                //msg = new Model.FormatModel.JsonMsgModel() { Data = types, Msg = "success", Status = 0 };
                string jsonData = Common.ConverterHelper.ObjectToJson(types);
                context.Response.Write(jsonData);
            }
            catch (Exception ex)
            {
                new Common.LogHelper(typeof(SelectNewsTypeHandler)).Error(ex);
                context.Response.Write("Fail");
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