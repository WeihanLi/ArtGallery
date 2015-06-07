using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Admin
{
    public partial class ContentEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InitPage();
            }
        }
        
        private void InitPage()
        {
            int id = -1;
            int.TryParse(Request.QueryString["id"], out id);
            if (id <= 0)
            {
                Response.Redirect("default.aspx");
            }
            itemId.Value = Convert.ToString(id);
        }
    }
}