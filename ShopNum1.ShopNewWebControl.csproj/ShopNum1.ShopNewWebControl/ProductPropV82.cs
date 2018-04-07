using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace ShopNum1.ShopNewWebControl
{
	[ParseChildren(true)]
	public class ProductPropV82 : BaseWebControl
	{
		private string string_0 = "ProductPropV82.ascx";
		public static DataTable dt_Prop = null;
		private HtmlGenericControl htmlGenericControl_0;
		private HtmlGenericControl htmlGenericControl_1;
		[CompilerGenerated]
		private string string_1;
		protected string guid
		{
			get;
			set;
		}
		public ProductPropV82()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("divInstrunction");
			this.htmlGenericControl_1 = (HtmlGenericControl)skin.FindControl("divDetials");
			if (this.Page.Request.QueryString["ShopID"] != null)
			{
				this.Page.Request.QueryString["ShopID"].ToString();
			}
			this.guid = ((this.Page.Request.QueryString["guid"] == null) ? "-1" : this.Page.Request.QueryString["guid"]);
			if (this.guid != "-1")
			{
				this.method_0();
			}
		}
		public static DataTable dt_SubPropv(string strPropID)
		{
			ShopNum1_ShopProRelateProp_Action shopNum1_ShopProRelateProp_Action = (ShopNum1_ShopProRelateProp_Action)LogicFactory.CreateShopNum1_ShopProRelateProp_Action();
			return shopNum1_ShopProRelateProp_Action.SelectPropByIdAndPid(strPropID, ShopNum1.Common.Common.ReqStr("guid"));
		}
		public static string GetPropValue(string strID)
		{
			ShopNum1_ShopProductPropValue_Action shopNum1_ShopProductPropValue_Action = new ShopNum1_ShopProductPropValue_Action();
			return shopNum1_ShopProductPropValue_Action.GetPropValue(strID);
		}
		private void method_0()
		{
			ShopNum1_ShopProductProp_Action shopNum1_ShopProductProp_Action = (ShopNum1_ShopProductProp_Action)LogicFactory.CreateShopNum1_ShopProductProp_Action();
			ProductPropV82.dt_Prop = shopNum1_ShopProductProp_Action.SelectProByProductGuid(this.guid);
			DataTable tableById = ShopNum1.Common.Common.GetTableById("Instruction,Detail", "shopnum1_shop_product", " And GuId='" + this.guid + "'");
			if (tableById.Rows.Count > 0)
			{
				this.htmlGenericControl_0.InnerHtml = tableById.Rows[0]["Instruction"].ToString();
				this.htmlGenericControl_1.InnerHtml = tableById.Rows[0]["Detail"].ToString();
			}
		}
	}
}
