using ShopNum1.BusinessLogic;
using ShopNum1.CityFactory;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Web.UI;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_ShowMyShop : BaseMemberWebControl
	{
		private string string_0 = "S_ShowMyShop.ascx";
		public S_ShowMyShop()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.Page.Response.Redirect(this.GetUrl());
		}
		public string GetUrl()
		{
			IShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopInfoList_Action();
			DataTable shopIDByMemLoginID = shopNum1_ShopInfoList_Action.GetShopIDByMemLoginID(this.MemLoginID);
			string text = string.Empty;
			string text2 = string.Empty;
			if (shopIDByMemLoginID.Rows.Count > 0)
			{
				text = shopIDByMemLoginID.Rows[0]["ShopUrl"].ToString();
				text2 = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
			}
			ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_SubstationManage_Action();
			DataTable substationByShopInfo = shopNum1_SubstationManage_Action.GetSubstationByShopInfo(this.MemLoginID);
			string text3 = string.Empty;
			string text4 = string.Empty;
			if (substationByShopInfo != null && substationByShopInfo.Rows.Count > 0)
			{
				text3 = substationByShopInfo.Rows[0]["SubstationID"].ToString();
			}
			if (text3 != "all")
			{
				text4 = shopNum1_SubstationManage_Action.GetDomainNameBySubstationID(text3);
			}
			return string.Concat(new string[]
			{
				"http://",
				text,
				".",
				text4,
				text2
			});
		}
	}
}
