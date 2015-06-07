using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Admin
{
    public partial class AddColumn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            if (String.IsNullOrEmpty(txtColumn.Text))
            {
                return;
            }
            Model.Category c = new Model.Category() { CategoryName = txtColumn.Text };
            if (new BLL.CategoryBLL().Add(c))
            {
                Response.Redirect("default.aspx");
            }
            else
            {
                Response.Write("<script>alert('添加失败，请稍后重试！')</script>");
            }
        }
    }
}