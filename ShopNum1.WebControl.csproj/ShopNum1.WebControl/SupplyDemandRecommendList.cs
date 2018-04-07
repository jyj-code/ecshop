using ShopNum1.BusinessLogic;
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
	public class SupplyDemandRecommendList : BaseWebControl
	{
		private string string_0 = "SupplyDemandRecommendList.ascx";
		private HtmlAnchor htmlAnchor_0;
		private Repeater repeater_0;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		public string showCount
		{
			get;
			set;
		}
		public string TradeType
		{
			get;
			set;
		}
		public SupplyDemandRecommendList()
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
				this.htmlAnchor_0.HRef = "~/Login.html";
			}
			else
			{
				this.htmlAnchor_0.HRef = "~/index.html";
			}
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			this.BindData();
		}
		protected void BindData()
		{
			ShopNum1_SupplyDemandCheck_Action shopNum1_SupplyDemandCheck_Action = (ShopNum1_SupplyDemandCheck_Action)LogicFactory.CreateShopNum1_SupplyDemandCheck_Action();
			DataTable supplyDemandRecommendList = shopNum1_SupplyDemandCheck_Action.GetSupplyDemandRecommendList(this.showCount, this.TradeType);
			if (supplyDemandRecommendList != null && supplyDemandRecommendList.Rows.Count > 0)
			{
				this.repeater_0.DataSource = supplyDemandRecommendList.DefaultView;
				this.repeater_0.DataBind();
			}
		}
	}
}
