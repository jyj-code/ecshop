using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class NewSaleOrder : BaseWebControl
	{
		private string string_0 = "NewSaleOrder.ascx";
		private Repeater repeater_0;
		[CompilerGenerated]
		private string string_1;
		public string TopSaleNum
		{
			get;
			set;
		}
		public NewSaleOrder()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepNewSaleOrder");
			if (!this.Page.IsPostBack)
			{
				ShopNum1_OrderProduct_Action shopNum1_OrderProduct_Action = (ShopNum1_OrderProduct_Action)LogicFactory.CreateShopNum1_OrderProduct_Action();
				this.repeater_0.DataSource = shopNum1_OrderProduct_Action.GetNewSaleOrder(this.TopSaleNum);
				this.repeater_0.DataBind();
			}
		}
	}
}
