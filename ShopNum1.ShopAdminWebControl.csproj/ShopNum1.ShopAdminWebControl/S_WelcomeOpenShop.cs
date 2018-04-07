using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_WelcomeOpenShop : BaseMemberWebControl
	{
		private string string_0 = "S_WelcomeOpenShop.ascx";
		private HtmlAnchor htmlAnchor_0;
		private HtmlGenericControl htmlGenericControl_0;
		private HtmlGenericControl htmlGenericControl_1;
		public S_WelcomeOpenShop()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("divHaveOpen");
			this.htmlGenericControl_1 = (HtmlGenericControl)skin.FindControl("divHaveOpenNo");
			this.htmlAnchor_0 = (HtmlAnchor)skin.FindControl("LinkA");
			try
			{
				Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)LogicFactory.CreateShop_ShopInfo_Action();
				DataTable dataInfoByMemLoginID = shop_ShopInfo_Action.GetDataInfoByMemLoginID(this.MemLoginID);
				if (dataInfoByMemLoginID != null && dataInfoByMemLoginID.Rows.Count > 0)
				{
					this.htmlAnchor_0.HRef = "/Shop/ShopAdmin/S_ShopOpenStep3.aspx?type=have";
				}
				else
				{
					this.htmlAnchor_0.HRef = "/Shop/ShopAdmin/S_ShopOpenStep1.aspx";
				}
			}
			catch (Exception)
			{
				this.htmlAnchor_0.HRef = "/Shop/ShopAdmin/S_ShopOpenStep1.aspx";
			}
			string nameById = ShopNum1.Common.Common.GetNameById("MemberType", "ShopNum1_Member", "  AND  MemLoginID='" + this.MemLoginID + "'  ");
			if (!string.IsNullOrEmpty(nameById) && nameById == "2")
			{
				this.htmlGenericControl_0.Visible = true;
				this.htmlGenericControl_1.Visible = false;
			}
			else
			{
				this.htmlGenericControl_0.Visible = false;
				this.htmlGenericControl_1.Visible = true;
			}
		}
	}
}
