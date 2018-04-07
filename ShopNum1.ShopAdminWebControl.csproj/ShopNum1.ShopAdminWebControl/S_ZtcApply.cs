using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_ZtcApply : BaseMemberWebControl
	{
		private string string_0 = "S_ZtcApply.ascx";
		private DropDownList dropDownList_0;
		public S_ZtcApply()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.dropDownList_0 = (DropDownList)skin.FindControl("DropDownListProductSeriesCode1");
			this.method_0();
		}
		private void method_0()
		{
			Shop_ProductCategory_Action shop_ProductCategory_Action = (Shop_ProductCategory_Action)LogicFactory.CreateShop_ProductCategory_Action();
			shop_ProductCategory_Action.TableName = "ShopNum1_Shop_ProductCategory";
			DataTable shopProductCategoryCode = shop_ProductCategory_Action.GetShopProductCategoryCode("0", this.MemLoginID);
			this.dropDownList_0.Items.Clear();
			this.dropDownList_0.Items.Add(new ListItem("-请选择-", "-1"));
			for (int i = 0; i < shopProductCategoryCode.Rows.Count; i++)
			{
				this.dropDownList_0.Items.Add(new ListItem(shopProductCategoryCode.Rows[i]["Name"].ToString(), shopProductCategoryCode.Rows[i]["ID"].ToString() + "/" + shopProductCategoryCode.Rows[i]["Code"].ToString()));
			}
		}
	}
}
