using ShopNum1.Common;
using ShopNum1.ShopBusinessLogic;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
public class Main_Admin_Limit_Product : Page, IRequiresSessionState
{
	protected HtmlGenericControl pageDiv;
	protected HtmlGenericControl pageShow;
	protected HtmlInputHidden CheckGuid;
	protected HtmlForm form1;
	public DataTable dt_Lp = null;
	private Shop_LimtProduct_Action shop_LimtProduct_Action_0 = new Shop_LimtProduct_Action();
	protected DefaultProfile Profile
	{
		get
		{
			return (DefaultProfile)this.Context.Profile;
		}
	}
	protected HttpApplication ApplicationInstance
	{
		get
		{
			return this.Context.ApplicationInstance;
		}
	}
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!this.Page.IsPostBack)
		{
			this.method_0();
		}
	}
	private void method_0()
	{
		string condition = " and lid='" + Common.ReqStr("lid") + "'";
		int pageID = 1;
		int pageSize = 10;
		if (Common.ReqStr("pageid") != "")
		{
			pageID = Convert.ToInt32(Common.ReqStr("pageid"));
		}
		DataTable dataTable = this.shop_LimtProduct_Action_0.SelectLimtProdcut(pageSize.ToString(), pageID.ToString(), condition, "3");
		int num = Convert.ToInt32(dataTable.Rows[0][0]);
		PageListBll pageListBll = new PageListBll("shop/ShopAdmin/S_Limit_ProductList.aspx", true);
		PageList1 pageList = new PageList1();
		pageList.PageSize = pageSize;
		pageList.PageID = pageID;
		pageList.RecordCount = num;
		if (pageList.PageSize > num || pageList.PageCount == 1)
		{
			this.pageShow.Visible = false;
		}
		else
		{
			this.pageShow.Visible = true;
		}
		this.pageDiv.InnerHtml = pageListBll.GetPageListNew(pageList);
		this.dt_Lp = this.shop_LimtProduct_Action_0.SelectLimtProdcut(pageSize.ToString(), pageID.ToString(), condition, "2");
		if (this.dt_Lp.Rows.Count == 0)
		{
			this.dt_Lp = null;
		}
	}
}
