using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibCore.Helper;
using LibCore.EF;
using Implement;
using LibCore.Data;

namespace Admin.Pages
{
    public partial class Category : System.Web.UI.Page
    {
        Repeater rptSubCate;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                getParentCategory();
        }
        #region Function GetData
        private void LoadChildCate(Repeater rpt, Literal Literal1, int ParentID)
        {
            if (rpt != null)
            {
                var objCate = SingletonIpl.GetInstance<CategoryIpl>(DataHelper.GetSchemaString());
                var lst = objCate.GetListCategory("1=1 AND Parent =" + ParentID);
                Literal1.Text = "";
                if (lst != null && lst.Count >0)
                {
                    rpt.DataSource = lst;
                    rpt.DataBind();
                    rpt.Visible = true;
                }
                else
                {
                    if (ParentID != 0)
                        Literal1.Text = "Không có dữ liệu!";
                    rpt.Visible = false;
                }
            }
        }

        private void getParentCategory() 
        {
            var objCate = SingletonIpl.GetInstance<CategoryIpl>(DataHelper.GetSchemaString());
            pagerCate.PageSize = 30;
            var lst = objCate.GetListCategory("Parent = 0", pagerCate.CurrentIndex, pagerCate.PageSize);
            var item = lst.FirstOrDefault();
            pagerCate.ItemCount = item.row_count;
            if (item.row_count > 10)
                pagerCate.Visible = true;
            else
                pagerCate.Visible = false;
            grvData.DataSource = lst.ToList();
            grvData.DataBind();
        }
        #endregion
        //Phan trang
        protected void pagerCate_Command(object sender, CommandEventArgs e)
        {
            int currnetPageIndx = Convert.ToInt32(e.CommandArgument);
            pagerCate.CurrentIndex = currnetPageIndx;
            getParentCategory();
        }

        protected void rptSubCate_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            //var objCate = SingletonIpl.GetInstance<CategoryIpl>(DataHelper.GetSchemaString());
            //try
            //{
            //    if (e.CommandName == "Edit")
            //    {
            //        Response.Redirect("Default.aspx?module=Category&ID=" + e.CommandArgument, false);
            //    }
            //    else if (e.CommandName == "Delete")
            //    {
            //        if (objCate.DeleteCategories(Convert.ToInt32(e.CommandArgument)))
            //        {
            //            divMessage.InnerHtml = Utils.Success("Hệ thống", "Xóa dữ liệu thành công!");
            //        }
            //        else
            //        {
            //            divMessage.InnerHtml = Utils.Warning("Hệ thống", "Có lỗi xảy ra. Vui lòng liên hệ với Administrator");
            //        }
            //        GetAllData(int.Parse(ddlLanguage.SelectedValue.ToString()));
            //    }

            //}
            //catch (Exception ex)
            //{
            //    Response.Redirect("Default.aspx");
            //}
        }

        protected void grvData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ImageButton ImageButton1 = (ImageButton)e.Row.FindControl("btnDelete");
            if (ImageButton1 != null)
                ImageButton1.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa không');");

            rptSubCate = (Repeater)e.Row.FindControl("rptSubCate");
        }

        protected void grvData_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(grvData.DataKeys[e.RowIndex].Values[0].ToString());
                GridView grv = (GridView)sender;
                ImageButton btnToggle = (ImageButton)grv.Rows[e.RowIndex].FindControl("btnToggle");
                Literal Literal1 = (Literal)grv.Rows[e.RowIndex].FindControl("Literal1");
                //divMessage.InnerHtml = "";
                if (btnToggle != null)
                {
                    Repeater rpt = (Repeater)grv.Rows[e.RowIndex].FindControl("rptSubCate");
                    if (btnToggle.CssClass.Equals("toggle"))
                    {
                        LoadChildCate(rpt, Literal1, id);
                        btnToggle.CssClass = "toggle_collapse";
                        btnToggle.ImageUrl = "/Images/minus.png";
                    }
                    else
                    {
                        btnToggle.CssClass = "toggle";
                        getParentCategory();
                        btnToggle.ImageUrl = "/Images/plus.png";
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}