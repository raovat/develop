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

namespace Admin
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                getdata();
        }
        private void getdata() 
        {
            var objCate = SingletonIpl.GetInstance<CategoryIpl>(DataHelper.GetSchemaString());
            pager1.PageSize = 30;
            var lst = objCate.GetListCategory(pager1.CurrentIndex,pager1.PageSize);
            var item = lst.FirstOrDefault();
            pager1.ItemCount = item.row_count;
            grvtest.DataSource = lst.ToList();
            grvtest.DataBind();
        }
        //Phan trang
        protected void pager1_Command(object sender, CommandEventArgs e)
        {
            int currnetPageIndx = Convert.ToInt32(e.CommandArgument);
            pager1.CurrentIndex = currnetPageIndx;
            getdata();
        }
    }
}