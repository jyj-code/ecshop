using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
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
	public class S_Limit_ActivityList : BaseShopWebControl
	{
		private string string_0 = "S_Limit_ActivityList.ascx";
		private HtmlGenericControl htmlGenericControl_0;
		public static DataTable dt_LimitActivity = null;
		[CompilerGenerated]
		private int int_0;
		public int PageSize
		{
			get;
			set;
		}
		public S_Limit_ActivityList()
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
				if (ShopNum1.Common.Common.ReqStr("lid") != "" && ShopNum1.Common.Common.ReqStr("sign") == "del")
				{
					Shop_LimtPackages_Action shop_LimtPackages_Action = new Shop_LimtPackages_Action();
					shop_LimtPackages_Action.DeletePackById(this.MemLoginID, ShopNum1.Common.Common.ReqStr("lid"));
				}
				this.method_0();
			}
		}
		private void method_0()
		{
			ShopNum1_Activity_Action shopNum1_Activity_Action = (ShopNum1_Activity_Action)LogicFactory.CreateShopNum1_Activity_Action();
			string condition = " and MemloginId='" + this.MemLoginID + "' and type=2";
			int pageID = 1;
			if (ShopNum1.Common.Common.ReqStr("pageid") != "")
			{
				pageID = Convert.ToInt32(ShopNum1.Common.Common.ReqStr("pageid"));
			}
			DataTable dataTable = shopNum1_Activity_Action.SelectActivity(this.PageSize.ToString(), pageID.ToString(), condition, "0");
			int recordCount = Convert.ToInt32(dataTable.Rows[0][0]);
			PageListBll pageListBll = new PageListBll("shop/ShopAdmin/S_Limit_ActivityList.aspx", true);
			PageList1 pageList = new PageList1();
			pageList.PageSize = this.PageSize;
			pageList.PageID = pageID;
			pageList.RecordCount = recordCount;
			this.htmlGenericControl_0.InnerHtml = pageListBll.GetPageListNew(pageList);
			S_Limit_ActivityList.dt_LimitActivity = shopNum1_Activity_Action.SelectActivity(this.PageSize.ToString(), pageID.ToString(), condition, "1");
			if (S_Limit_ActivityList.dt_LimitActivity.Rows.Count == 0)
			{
				S_Limit_ActivityList.dt_LimitActivity = null;
			}
		}
	}
}
