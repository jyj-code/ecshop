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
	public class DeSupplyDemandDetail : BaseWebControl
	{
		private string string_0 = "DeSupplyDemandDetail.ascx";
		private Repeater repeater_0;
		private Repeater repeater_1;
		private Repeater repeater_2;
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
		public DeSupplyDemandDetail()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData1");
			this.repeater_1 = (Repeater)skin.FindControl("RepeaterData2");
			this.repeater_2 = (Repeater)skin.FindControl("RepeaterData3");
			try
			{
				int.Parse(this.ShowCount);
			}
			catch
			{
				this.ShowCount = "0";
			}
			this.BindData1();
			this.BindData2();
			this.BindData3();
		}
		protected void BindData1()
		{
			ShopNum1_SupplyDemandCheck_Action shopNum1_SupplyDemandCheck_Action = (ShopNum1_SupplyDemandCheck_Action)LogicFactory.CreateShopNum1_SupplyDemandCheck_Action();
			DataTable titleByCodeTrade = shopNum1_SupplyDemandCheck_Action.GetTitleByCodeTrade(0, this.code, this.ShowCount);
			if (titleByCodeTrade != null && titleByCodeTrade.Rows.Count > 0)
			{
				this.repeater_0.DataSource = titleByCodeTrade.DefaultView;
				this.repeater_0.DataBind();
			}
		}
		protected void BindData2()
		{
			ShopNum1_SupplyDemandCheck_Action shopNum1_SupplyDemandCheck_Action = (ShopNum1_SupplyDemandCheck_Action)LogicFactory.CreateShopNum1_SupplyDemandCheck_Action();
			DataTable titleByCodeTrade = shopNum1_SupplyDemandCheck_Action.GetTitleByCodeTrade(1, this.code, this.ShowCount);
			if (titleByCodeTrade != null && titleByCodeTrade.Rows.Count > 0)
			{
				this.repeater_1.DataSource = titleByCodeTrade.DefaultView;
				this.repeater_1.DataBind();
			}
		}
		protected void BindData3()
		{
			ShopNum1_SupplyDemandCheck_Action shopNum1_SupplyDemandCheck_Action = (ShopNum1_SupplyDemandCheck_Action)LogicFactory.CreateShopNum1_SupplyDemandCheck_Action();
			DataTable titleByCodeRecommend = shopNum1_SupplyDemandCheck_Action.GetTitleByCodeRecommend(this.code, this.ShowCount);
			if (titleByCodeRecommend != null && titleByCodeRecommend.Rows.Count > 0)
			{
				this.repeater_2.DataSource = titleByCodeRecommend.DefaultView;
				this.repeater_2.DataBind();
			}
		}
	}
}
