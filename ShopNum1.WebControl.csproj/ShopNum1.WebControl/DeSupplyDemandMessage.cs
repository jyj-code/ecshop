using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class DeSupplyDemandMessage : BaseWebControl
	{
		private string string_0 = "DeSupplyDemandMessage.ascx";
		private Repeater repeater_0;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		public string code
		{
			get;
			set;
		}
		public string ShowCount
		{
			get;
			set;
		}
		public DeSupplyDemandMessage()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterBrand");
			if (this.Page.IsPostBack)
			{
			}
			this.method_0();
		}
		private void method_0()
		{
			ShopNum1_SupplyDemandCheck_Action shopNum1_SupplyDemandCheck_Action = (ShopNum1_SupplyDemandCheck_Action)LogicFactory.CreateShopNum1_SupplyDemandCheck_Action();
			DataTable titleByCodeTrade = shopNum1_SupplyDemandCheck_Action.GetTitleByCodeTrade(0, this.code, this.ShowCount);
			if (titleByCodeTrade != null && titleByCodeTrade.Rows.Count > 0)
			{
				this.repeater_0.DataSource = titleByCodeTrade.DefaultView;
				this.repeater_0.DataBind();
			}
		}
	}
}
