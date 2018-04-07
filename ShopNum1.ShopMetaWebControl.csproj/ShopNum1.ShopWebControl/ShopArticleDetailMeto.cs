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
	public class ShopArticleDetailMeto : BaseWebControl
	{
		private string string_0 = "ShopArticleDetailMeto.ascx";
		public ShopArticleDetailMeto()
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
				Shop_News_Action shop_News_Action = (Shop_News_Action)LogicFactory.CreateShop_News_Action();
				DataTable shopArticleDetailMeto = shop_News_Action.GetShopArticleDetailMeto(text);
				if (shopArticleDetailMeto == null || shopArticleDetailMeto.Rows.Count == 0)
				{
					text2 = "\n<title>" + ShopNum1.Common.Common.GetCopyright() + "</title>\r\n";
					text2 = text2 + "<meta name=keywords content=\"" + ShopNum1.Common.Common.GetCopyright() + "\">\r\n";
					text2 = text2 + "<meta name=\"description\" content=\"" + ShopNum1.Common.Common.GetCopyright() + "\">\r\n";
				}
				else
				{
					text2 = "\n<title>" + shopArticleDetailMeto.Rows[0]["Title"].ToString() + ShopNum1.Common.Common.GetCopyright() + "</title>\r\n";
					if (shopArticleDetailMeto.Rows[0]["Keywords"].ToString() == string.Empty)
					{
						text2 = string.Concat(new string[]
						{
							text2,
							"<meta name=keywords content=\"",
							shopArticleDetailMeto.Rows[0]["Title"].ToString(),
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
							shopArticleDetailMeto.Rows[0]["Keywords"].ToString(),
							ShopNum1.Common.Common.GetCopyright(),
							"\">\r\n"
						});
					}
					if (shopArticleDetailMeto.Rows[0]["Description"].ToString() == string.Empty)
					{
						text2 = string.Concat(new string[]
						{
							text2,
							"<meta name=\"description\" content=\"",
							shopArticleDetailMeto.Rows[0]["Title"].ToString(),
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
							shopArticleDetailMeto.Rows[0]["Description"].ToString(),
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
