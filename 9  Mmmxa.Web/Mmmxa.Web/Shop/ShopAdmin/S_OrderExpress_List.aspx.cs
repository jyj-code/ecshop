using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using ShopNum1.Localization;
using ShopNum1.Factory;
using ShopNum1.Common;
using ShopNum1.BusinessLogic;

public partial class S_OrderExpress_List : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.Num1GridViewShow.DataBind();
        }
    }

    protected void ButtonEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("S_OrderExpress_Operate.aspx?Guid=" + this.CheckGuid.Value);
    }
    protected void ButtonAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("S_OrderExpress_Operate.aspx");
    }
    protected void ButtonDelete_Click(object sender, EventArgs e)
    {
        ShopNum1_OrderExpress_Action orderExpress = new ShopNum1_OrderExpress_Action();
        int check = orderExpress.Delete(this.CheckGuid.Value);
        if (check > 0)
        {
            this.Num1GridViewShow.DataBind(); ;
        }
        else
        {
            MessageBox.Show("删除失败!");
        }
    }
}
