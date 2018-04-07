using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class ShoppingCartShow : BaseWebControl
	{
		private string string_0 = "ShoppingCartShow.ascx";
		private Label label_0;
		private Label label_1;
		private HyperLink hyperLink_0;
		public ShoppingCartShow()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.label_0 = (Label)skin.FindControl("LableProductCount");
			this.label_1 = (Label)skin.FindControl("LabelAllPrice");
			this.hyperLink_0 = (HyperLink)skin.FindControl("shoppingCart");
			if (this.Page.IsPostBack)
			{
			}
			string text = string.Empty;
			if (this.Page.Request.Cookies["MemberLoginCookie"] != null)
			{
				HttpCookie httpCookie = this.Page.Request.Cookies["MemberLoginCookie"];
				if (httpCookie.Values.Count != 0)
				{
					HttpCookie httpCookie2 = HttpSecureCookie.Decode(httpCookie);
					text = httpCookie2.Values["MemLoginID"].ToString();
				}
			}
			else
			{
				this.Page.Response.Redirect(GetPageName.RetUrl("login"));
			}
			this.method_0(text);
			this.hyperLink_0.Target = "_blank";
			this.hyperLink_0.NavigateUrl = GetPageName.RetUrl("ShoppingCart1", text, "LoginID");
		}
		private void method_0(string string_1)
		{
			string text = "0";
			string text2 = "0.00";
			if (string_1 != string.Empty)
			{
				ShopNum1_Cart_Action shopNum1_Cart_Action = (ShopNum1_Cart_Action)LogicFactory.CreateShopNum1_Cart_Action();
				DataTable dataTable = shopNum1_Cart_Action.SearchBuyPriceByMemLoginID(string_1);
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					text = Convert.ToString(Convert.ToInt32(text) + Convert.ToInt32(dataTable.Rows[i]["BuyNumber"].ToString()));
					string value = (Convert.ToDecimal(dataTable.Rows[i]["BuyPrice"].ToString()) * Convert.ToInt32(dataTable.Rows[i]["BuyNumber"].ToString())).ToString();
					text2 = Convert.ToString(Convert.ToDecimal(text2) + Convert.ToDecimal(value));
				}
			}
			this.label_1.Text = text2;
			this.label_0.Text = text;
		}
	}
}
