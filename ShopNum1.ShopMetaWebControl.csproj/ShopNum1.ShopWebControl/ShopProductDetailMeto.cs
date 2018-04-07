using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Web.UI;
namespace ShopNum1.ShopWebControl
{
	[ParseChildren(true)]
	public class ShopProductDetailMeto : BaseWebControl
	{
		private string string_0 = "ShopProductDetailMeto.ascx";
		public ShopProductDetailMeto()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
		}
		protected override void Render(HtmlTextWriter writer)
		{
			string text = (this.Page.Request.QueryString["guid"] == null) ? "0" : this.Page.Request.QueryString["guid"];
			string text2 = string.Empty;
			if (text != "0")
			{
				Shop_Product_Action shop_Product_Action = (Shop_Product_Action)LogicFactory.CreateShop_Product_Action();
				DataTable shopProductDetailMeto = shop_Product_Action.GetShopProductDetailMeto(text);
				if (shopProductDetailMeto == null || shopProductDetailMeto.Rows.Count == 0)
				{
					text2 = "\n<title>" + ShopNum1.Common.Common.GetCopyright() + "</title>\r\n";
					text2 = text2 + "<meta name=keywords content=\"" + ShopNum1.Common.Common.GetCopyright() + "\">\r\n";
					text2 = text2 + "<meta name=\"description\" content=\"" + ShopNum1.Common.Common.GetCopyright() + "\">\r\n";
				}
				else
				{
					text2 = "\n<title>" + shopProductDetailMeto.Rows[0]["Title"].ToString() + ShopNum1.Common.Common.GetCopyright() + "</title>\r\n";
					if (shopProductDetailMeto.Rows[0]["Keywords"].ToString() == string.Empty)
					{
						text2 = string.Concat(new string[]
						{
							text2,
							"<meta name=keywords content=\"",
							shopProductDetailMeto.Rows[0]["Title"].ToString(),
							ShopNum1.Common.Common.GetCopyright(),
							"\">\r\n"
						});
					}
					else
					{
						text2 = string.Concat(new string[]
						{
							text2,
							"<meta name=keywords content=\"",
							shopProductDetailMeto.Rows[0]["Keywords"].ToString(),
							ShopNum1.Common.Common.GetCopyright(),
							"\">\r\n"
						});
					}
					if (shopProductDetailMeto.Rows[0]["Description"].ToString() == string.Empty)
					{
						text2 = string.Concat(new string[]
						{
							text2,
							"<meta name=\"description\" content=\"",
							shopProductDetailMeto.Rows[0]["Title"].ToString(),
							ShopNum1.Common.Common.GetCopyright(),
							"\">\r\n"
						});
					}
					else
					{
						text2 = string.Concat(new string[]
						{
							text2,
							"<meta name=\"description\" content=\"",
							shopProductDetailMeto.Rows[0]["Description"].ToString(),
							ShopNum1.Common.Common.GetCopyright(),
							"\">\r\n"
						});
					}
				}
			}
			writer.Write(text2);
		}
	}
}
