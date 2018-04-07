using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class nofindsearch : BaseWebControl
	{
		private string string_0 = "nofindsearch.ascx";
		private Label label_0;
		public nofindsearch()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.label_0 = (Label)skin.FindControl("LabelProtectSearch");
			string text = "";
			if (ShopNum1.Common.Common.ReqStr("pv") != "")
			{
				string text2 = HttpUtility.HtmlDecode(this.Page.Request.QueryString["search"].ToString()).Replace("%2f", "/");
				this.label_0.Text = ((text2.Length > 20) ? text2.Substring(0, 20) : text2);
				string text3 = ShopNum1.Common.Common.ReqStr("pv");
				if (text3 != null)
				{
					if (!(text3 == "1"))
					{
						if (!(text3 == "2"))
						{
							if (!(text3 == "3"))
							{
								if (text3 == "4" && ShopNum1.Common.Common.ReturnExist("count(*)", "ShopNum1_SupplyDemand", " and title like '%" + text2 + "%' and IsAudit=3 "))
								{
									text = "/SupplyDemandListSearch.html?search=" + ShopNum1.Common.Common.ReqStr("search");
								}
							}
							else if (ShopNum1.Common.Common.ReturnExist("count(*)", "ShopNum1_Article", " and title like '%" + text2 + "%' and isaudit=1"))
							{
								text = "/ArticleListSearch.html?search=" + ShopNum1.Common.Common.ReqStr("search");
							}
						}
						else if (ShopNum1.Common.Common.ReturnExist("count(*)", "ShopNum1_ShopInfo", " and shopname like '%" + text2 + "%' and isaudit=1"))
						{
							text = "/ShopListSearch.html?search=" + ShopNum1.Common.Common.ReqStr("search");
						}
					}
					else if (ShopNum1.Common.Common.ReturnExist("count(*)", "ShopNum1_Shop_Product", " and name like '%" + text2 + "%' and isaudit=1 and issell=1 and issaled=1"))
					{
						text = "/Search_productlist.html?search=" + ShopNum1.Common.Common.ReqStr("search");
					}
				}
				if (text.ToString() != "")
				{
					this.Page.Response.Redirect(text);
				}
			}
		}
	}
}
