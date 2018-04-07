using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class DeShopIsNew : BaseWebControl
	{
		private string string_0 = "DeShopIsNew.ascx";
		private Repeater repeater_0;
		private HtmlGenericControl htmlGenericControl_0;
		public DeShopIsNew()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			this.repeater_0.ItemDataBound += new RepeaterItemEventHandler(this.repeater_0_ItemDataBound);
			this.method_0();
		}
		private void repeater_0_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			this.htmlGenericControl_0 = (HtmlGenericControl)e.Item.FindControl("spanMemLoginID");
			Repeater repeater = e.Item.FindControl("RepeaterImg") as Repeater;
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
			DataTable ensureImagePathBymemberLoginID = shopNum1_ShopInfoList_Action.GetEnsureImagePathBymemberLoginID(this.htmlGenericControl_0.InnerText.Trim());
			if (ensureImagePathBymemberLoginID != null && ensureImagePathBymemberLoginID.Rows.Count > 0)
			{
				repeater.DataSource = ensureImagePathBymemberLoginID.DefaultView;
				repeater.DataBind();
			}
			Repeater repeater2 = e.Item.FindControl("RepeaterProduct") as Repeater;
			string value = ShopSettings.GetValue("ShopMainProductCount");
			ShopNum1_ProuductChecked_Action shopNum1_ProuductChecked_Action = (ShopNum1_ProuductChecked_Action)LogicFactory.CreateShopNum1_ProuductChecked_Action();
			DataTable dataTable = shopNum1_ProuductChecked_Action.SearchProductByMemLoginID(this.htmlGenericControl_0.InnerText.Trim(), value);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				repeater2.DataSource = dataTable.DefaultView;
				repeater2.DataBind();
			}
		}
		private void method_0()
		{
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
			string value = ShopSettings.GetValue("DefaultCategoryShopCount");
			DataTable dataTable = shopNum1_ShopInfoList_Action.SearchNewsShopList(value);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				this.repeater_0.DataSource = dataTable.DefaultView;
				this.repeater_0.DataBind();
			}
		}
	}
}
