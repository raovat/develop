using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibCore.Data;
using LibCore.EF;
using Implement;

namespace RongbayApplication
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var objCate = SingletonIpl.GetInstance<CategoryIpl>(DataHelper.GetSchemaString());
            var lst = objCate.GetListCategory(1,10);
            grvtest.DataSource = lst.ToList();
            grvtest.DataBind();
        }
    }
}