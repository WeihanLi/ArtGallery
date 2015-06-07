using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Admin
{
    public partial class ColumnManage : System.Web.UI.Page
    {
        public static int PageIndex
        {
            get
            {
                return pageIndex;
            }

            set
            {
                pageIndex = value;
            }
        }

        private static int pageIndex;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //初始化页码
                pageIndex = 1;
                ControlsDataBind();
            }
        }

        private void ControlsDataBind()
        {
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = new BLL.CategoryBLL().Select();
            if (pds.Count > 0)
            {
                pds.AllowPaging = true;
                pds.PageSize = 12;
                pds.CurrentPageIndex = pageIndex - 1;
                lblCount.Text = pds.PageCount.ToString();
                lblIndex.Text = pageIndex.ToString();
                if (pageIndex == 1)
                {
                    btnUp.Enabled = false;
                }
                else
                {
                    btnUp.Enabled = true;
                }
                if (pageIndex == pds.PageCount)
                {
                    btnNext.Enabled = false;
                }
                else
                {
                    btnNext.Enabled = true;
                }
                repColumns.DataSource = pds;
                repColumns.DataBind();
            }
        }

        protected void btnUp_Click(object sender, EventArgs e)
        {
            pageIndex += 1;
            ControlsDataBind();
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            pageIndex -= 1;
            ControlsDataBind();
        }
    }
}