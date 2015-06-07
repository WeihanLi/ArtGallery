using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Admin
{
    public partial class UserManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("login.html");
            }
            else if (Session["Admin"] == null)
            {
                //
                Response.Redirect("default.aspx");
            }
            if (!Page.IsPostBack)
            {
                ControlsDataBind();
            }
        }

        private void ControlsDataBind()
        {
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = new BLL.UserBLL().Select();
            pds.AllowPaging = true;
            pds.PageSize = 10;
            int curPage = Convert.ToInt32(lblIndex.Text);
            pds.CurrentPageIndex = curPage - 1;
            lblCount.Text = pds.PageCount.ToString();
            if (curPage == 1)
            {
                btnUp.Enabled = false;
            }
            else
            {
                btnUp.Enabled = true;
            }
            if (curPage == pds.PageCount)
            {
                btnNext.Enabled = false;
            }
            else
            {
                btnNext.Enabled = true;
            }
            repUserList.DataSource = pds;
            repUserList.DataBind();
        }

        protected void btnUp_Click(object sender, EventArgs e)
        {
            lblIndex.Text = (Convert.ToInt32(lblIndex.Text) - 1).ToString();
            ControlsDataBind();
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            lblIndex.Text = (Convert.ToInt32(lblIndex.Text) + 1).ToString();
            ControlsDataBind();
        }
    }
}