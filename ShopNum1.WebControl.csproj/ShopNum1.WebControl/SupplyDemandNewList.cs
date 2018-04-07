using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class SupplyDemandNewList : BaseWebControl
	{
		private string string_0 = "SupplyDemandNewList.ascx";
		private HtmlAnchor htmlAnchor_0;
		private Repeater repeater_0;
		[CompilerGenerated]
		private string string_1;
		public string showCount
		{
			get;
			set;
		}
		public SupplyDemandNewList()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.htmlAnchor_0 = (HtmlAnchor)skin.FindControl("Href");
			if (this.Page.Request.Cookies["MemberLoginCookie"] == null)
			{
				this.htmlAnchor_0.HRef = GetPageName.RetUrl("Login");
			}
			else
			{
				this.htmlAnchor_0.HRef = GetPageName.RetUrl("index");
			}
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			this.BindData();
		}
		protected void BindData()
		{
			ShopNum1_SupplyDemandCheck_Action shopNum1_SupplyDemandCheck_Action = (ShopNum1_SupplyDemandCheck_Action)LogicFactory.CreateShopNum1_SupplyDemandCheck_Action();
			DataTable supplyDemandNewList = shopNum1_SupplyDemandCheck_Action.GetSupplyDemandNewList(this.showCount);
			if (supplyDemandNewList != null && supplyDemandNewList.Rows.Count > 0)
			{
				this.repeater_0.DataSource = supplyDemandNewList.DefaultView;
				this.repeater_0.DataBind();
			}
		}
	}
}
