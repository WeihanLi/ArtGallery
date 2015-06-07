using System;

namespace WebApplication1.Admin
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
              ControlsDataBind();
        }

        private void ControlsDataBind()
        {
                repColumns.DataSource = new BLL.CategoryBLL().Select();
                repColumns.DataBind();
        }
    }
}