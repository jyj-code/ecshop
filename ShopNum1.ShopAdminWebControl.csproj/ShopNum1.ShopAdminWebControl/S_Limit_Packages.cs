using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_Limit_Packages : BaseShopWebControl
	{
		private string string_0 = "S_Limit_Packages.ascx";
		private HtmlGenericControl htmlGenericControl_0;
		public static DataTable dt_LimitPackages = null;
		[CompilerGenerated]
		private int int_0;
		public int PageSize
		{
			get;
			set;
		}
		public S_Limit_Packages()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("pageDiv");
			if (!this.Page.IsPostBack)
			{
				this.method_0();
			}
		}
		private void method_0()
		{
			Shop_LimtPackages_Action shop_LimtPackages_Action = new Shop_LimtPackages_Action();
			string condition = " and Memloginid='" + this.MemLoginID + "'";
			int pageID = 1;
			if (ShopNum1.Common.Common.ReqStr("pageid") != "")
			{
				pageID = Convert.ToInt32(ShopNum1.Common.Common.ReqStr("pageid"));
			}
			DataTable dataTable = shop_LimtPackages_Action.SelectLimtPackage(this.PageSize.ToString(), pageID.ToString(), condition, "0");
			int recordCount = Convert.ToInt32(dataTable.Rows[0][0]);
			PageListBll pageListBll = new PageListBll("shop/ShopAdmin/S_Limit_Packages.aspx", true);
			PageList1 pageList = new PageList1();
			pageList.PageSize = this.PageSize;
			pageList.PageID = pageID;
			pageList.RecordCount = recordCount;
			this.htmlGenericControl_0.InnerHtml = pageListBll.GetPageListNew(pageList);
			S_Limit_Packages.dt_LimitPackages = shop_LimtPackages_Action.SelectLimtPackage(this.PageSize.ToString(), pageID.ToString(), condition, "1");
		}
	}
}
