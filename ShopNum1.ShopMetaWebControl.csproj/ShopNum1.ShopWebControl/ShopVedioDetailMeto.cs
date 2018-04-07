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
	public class ShopVedioDetailMeto : BaseWebControl
	{
		private string string_0 = "ShopVedioDetailMeto.ascx";
		public ShopVedioDetailMeto()
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
				Shop_Video_Action shop_Video_Action = (Shop_Video_Action)LogicFactory.CreateShop_Video_Action();
				DataTable shopVedioDetailMeto = shop_Video_Action.GetShopVedioDetailMeto(text);
				if (shopVedioDetailMeto == null || shopVedioDetailMeto.Rows.Count == 0)
				{
					text2 = "\n<title>" + ShopNum1.Common.Common.GetCopyright() + "</title>\r\n";
					text2 = text2 + "<meta name=keywords content=\"" + ShopNum1.Common.Common.GetCopyright() + "\">\r\n";
					text2 = text2 + "<meta name=\"description\" content=\"" + ShopNum1.Common.Common.GetCopyright() + "\">\r\n";
				}
				else
				{
					text2 = "\n<title>" + shopVedioDetailMeto.Rows[0]["Title"].ToString() + ShopNum1.Common.Common.GetCopyright() + "</title>\r\n";
					if (shopVedioDetailMeto.Rows[0]["Keywords"].ToString() == string.Empty)
					{
						text2 = string.Concat(new string[]
						{
							text2,
							"<meta name=keywords content=\"",
							shopVedioDetailMeto.Rows[0]["Title"].ToString(),
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
							shopVedioDetailMeto.Rows[0]["Keywords"].ToString(),
							ShopNum1.Common.Common.GetCopyright(),
							"\">\r\n"
						});
					}
					if (shopVedioDetailMeto.Rows[0]["Description"].ToString() == string.Empty)
					{
						text2 = string.Concat(new string[]
						{
							text2,
							"<meta name=\"description\" content=\"",
							shopVedioDetailMeto.Rows[0]["Title"].ToString(),
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
							shopVedioDetailMeto.Rows[0]["Description"].ToString(),
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
