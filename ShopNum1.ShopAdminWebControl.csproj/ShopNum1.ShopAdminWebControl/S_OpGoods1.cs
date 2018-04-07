using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_OpGoods1 : BaseShopWebControl
	{
		private string string_0 = "S_OpGoods1.ascx";
		private HiddenField hiddenField_0;
		private HtmlInputHidden htmlInputHidden_0;
		private string string_1 = string.Empty;
		private string string_2 = string.Empty;
		public static DataTable dt_Specvalue = null;
		public static DataTable dt_Provalue = null;
		private Repeater repeater_0;
		private ShopNum1_Spec_Action shopNum1_Spec_Action_0 = new ShopNum1_Spec_Action();
		private ShopNum1_ShopProductProp_Action shopNum1_ShopProductProp_Action_0 = (ShopNum1_ShopProductProp_Action)LogicFactory.CreateShopNum1_ShopProductProp_Action();
		public S_OpGoods1()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("repStockSet");
			this.string_1 = ShopNum1.Common.Common.ReqStr("pid");
			this.string_2 = ShopNum1.Common.Common.ReqStr("ctype");
			this.hiddenField_0 = (HiddenField)skin.FindControl("hidSetsp");
			this.htmlInputHidden_0 = (HtmlInputHidden)skin.FindControl("hidCategoryName");
			new ShopNum1_CategoryType_Action();
			if (!this.Page.IsPostBack)
			{
				this.method_0();
				this.method_1();
				if (this.string_1 != "0" && this.string_1 != "")
				{
					ShopNum1_SpecProudct_Action shopNum1_SpecProudct_Action = (ShopNum1_SpecProudct_Action)LogicFactory.CreateShopNum1_SpecProudct_Action();
					this.repeater_0.DataSource = shopNum1_SpecProudct_Action.dt_SpecProducts(this.string_1, this.string_2, "");
					this.repeater_0.DataBind();
				}
				ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
				string text = shopNum1_ProductCategory_Action.GetThreeType(ShopNum1.Common.Common.ReqStr("code"));
				if (text == "")
				{
					text = "请重新选择分类";
				}
				this.htmlInputHidden_0.Value = text;
			}
		}
		public static DataTable dt_SubSpecv(string strSpecID)
		{
			ShopNum1_Spec_Action shopNum1_Spec_Action = new ShopNum1_Spec_Action();
			return shopNum1_Spec_Action.dt_SubSpec(strSpecID, ShopNum1.Common.Common.ReqStr("pid"));
		}
		private void method_0()
		{
			if (this.string_2 != "0" || this.string_2 != "")
			{
				string text = ShopNum1.Common.Common.ReqStr("ctype");
				if (!string.IsNullOrEmpty(text))
				{
					S_OpGoods1.dt_Specvalue = this.shopNum1_Spec_Action_0.dt_GetSp(text);
					if (S_OpGoods1.dt_Specvalue.Rows.Count == 0)
					{
						S_OpGoods1.dt_Specvalue = null;
					}
				}
			}
		}
		private void method_1()
		{
			if (this.string_2 != "0" || this.string_2 != "")
			{
				string text = ShopNum1.Common.Common.ReqStr("ctype");
				if (!string.IsNullOrEmpty(text))
				{
					S_OpGoods1.dt_Provalue = this.shopNum1_ShopProductProp_Action_0.dt_GetPro(text);
				}
			}
		}
		public static DataTable dt_SubPropv(string strPropID)
		{
			ShopNum1_ShopProductPropValue_Action shopNum1_ShopProductPropValue_Action = new ShopNum1_ShopProductPropValue_Action();
			return shopNum1_ShopProductPropValue_Action.dt_SubProp(strPropID, ShopNum1.Common.Common.ReqStr("pid"));
		}
	}
}
