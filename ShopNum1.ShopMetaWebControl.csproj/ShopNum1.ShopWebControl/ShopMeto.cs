using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
namespace ShopNum1.ShopWebControl
{
	[ParseChildren(true)]
	public class ShopMeto : BaseWebControl
	{
		private string string_0 = "ShopMeto.ascx";
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		protected string ShopID
		{
			get;
			set;
		}
		protected string SetPath
		{
			get;
			set;
		}
		public ShopMeto()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.ShopID = ((this.Page.Request.QueryString["ShopID"] == null) ? "0" : this.Page.Request.QueryString["ShopID"].ToString());
			if (this.ShopID != "0")
			{
				Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ShopInfo_Action();
				DataTable openTimeByShopID = shop_ShopInfo_Action.GetOpenTimeByShopID(this.ShopID);
				if (openTimeByShopID != null && openTimeByShopID.Rows.Count > 0)
				{
					string text = DateTime.Parse(openTimeByShopID.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
					this.SetPath = string.Concat(new string[]
					{
						"~/Shop/Shop/",
						text.Replace("-", "/"),
						"/Shop",
						this.ShopID,
						"/xml/SetMeto.xml"
					});
				}
			}
		}
		public DataTable SelectByID(string PageName)
		{
			ShopNum1_ExtendSiteMota_Action shopNum1_ExtendSiteMota_Action = (ShopNum1_ExtendSiteMota_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ExtendSiteMota_Action();
			return shopNum1_ExtendSiteMota_Action.SelectByName(PageName, this.SetPath);
		}
		protected override void Render(HtmlTextWriter writer)
		{
			string text = string.Empty;
			string physicalPath = this.Page.Request.PhysicalPath;
			string pageName = physicalPath.Substring(physicalPath.LastIndexOf("\\") + 1);
			DataTable dataTable = this.SelectByID(pageName);
			if (dataTable == null || dataTable.Rows.Count == 0)
			{
				text = "\n<title>" + ShopNum1.Common.Common.GetCopyright() + "</title>\r\n";
				text = text + "<meta name=keywords content=\"" + ShopNum1.Common.Common.GetCopyright() + "\">\r\n";
				text = text + "<meta name=\"description\" content=\"" + ShopNum1.Common.Common.GetCopyright() + "\">\r\n";
			}
			else
			{
				text = "\n<title>" + dataTable.Rows[0]["Title"].ToString() + ShopNum1.Common.Common.GetCopyright() + "</title>\r\n";
				text = string.Concat(new string[]
				{
					text,
					"<meta name=keywords content=\"",
					dataTable.Rows[0]["KeyWords"].ToString(),
					ShopNum1.Common.Common.GetCopyright(),
					"\">\r\n"
				});
				text = string.Concat(new string[]
				{
					text,
					"<meta name=\"description\" content=\"",
					dataTable.Rows[0]["Description"].ToString(),
					ShopNum1.Common.Common.GetCopyright(),
					"\">\r\n"
				});
			}
			writer.Write(text);
		}
	}
}
