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
	public class ProductIsSpellBuy : BaseWebControl
	{
		private string string_0 = "ProductIsCategoryShow.ascx";
		private Repeater repeater_0;
		private Literal literal_0;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		public string ShowCount
		{
			get;
			set;
		}
		public string ProductType
		{
			get;
			set;
		}
		public ProductIsSpellBuy()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.literal_0 = (Literal)skin.FindControl("LiteralTitle");
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			this.method_0();
		}
		private void method_0()
		{
			ShopNum1_ProuductChecked_Action shopNum1_ProuductChecked_Action = (ShopNum1_ProuductChecked_Action)LogicFactory.CreateShopNum1_ProuductChecked_Action();
			DataTable dataTable = shopNum1_ProuductChecked_Action.SearchEspecialProduct(this.ShowCount, this.ProductType);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				this.repeater_0.DataSource = dataTable;
				this.repeater_0.DataBind();
			}
			string productType = this.ProductType;
			switch (productType)
			{
			case "IsRecommend":
				this.literal_0.Text = "推荐商品";
				break;
			case "IsSpellBuy":
				this.literal_0.Text = "团购商品";
				break;
			case "IsPanicBuy":
				this.literal_0.Text = "抢购商品";
				break;
			case "IsPromotion":
				this.literal_0.Text = "促销商品";
				break;
			case "IsHot":
				this.literal_0.Text = "热卖商品";
				break;
			case "IsNew":
				this.literal_0.Text = "最新商品";
				break;
			case "IsBest":
				this.literal_0.Text = "精品商品";
				break;
			}
		}
	}
}
