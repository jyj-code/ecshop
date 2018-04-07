using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace ShopNum1.ShopWebControl
{
	[ParseChildren(true)]
	public class AdvertisementPPT : BaseWebControl
	{
		private string string_0 = "AdvertisementPPT.ascx";
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		public string SetPath
		{
			get;
			set;
		}
		public string OpenTime
		{
			get;
			set;
		}
		public string ShopID
		{
			get;
			set;
		}
		public AdvertisementPPT()
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
				ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = new ShopNum1_ShopInfoList_Action();
				string text = shopNum1_ShopInfoList_Action.GetShopOpenTimeByShopID(this.ShopID);
				if (text != "")
				{
					text = DateTime.Parse(text).ToString("yyyy-MM-dd");
					this.SetPath = string.Concat(new string[]
					{
						"~/Shop/Shop/",
						text.Replace("-", "/"),
						"/",
						ShopSettings.GetValue("PersonShopUrl"),
						this.ShopID,
						"/Themes/Skin_Default/Advertisement.xml"
					});
				}
				this.BindAd();
			}
		}
		public void BindAd()
		{
			string filePath = this.Page.Request.FilePath;
			string text = filePath.Substring(filePath.LastIndexOf('/') + 1);
			if (text == "")
			{
				text = "Default.aspx";
			}
			if (this.ShopID != "0")
			{
				Shop_Advertisement_Action shop_Advertisement_Action = (Shop_Advertisement_Action)LogicFactory.CreateShop_Advertisement_Action();
				shop_Advertisement_Action.StrPath = this.SetPath;
				DataTable dataTable = shop_Advertisement_Action.SearchPPT(text);
				StringBuilder stringBuilder = new StringBuilder();
				StringBuilder stringBuilder2 = new StringBuilder();
				StringBuilder stringBuilder3 = new StringBuilder();
				HtmlGenericControl htmlGenericControl = new HtmlGenericControl();
				int i = 0;
				int num = 1;
				while (i < dataTable.Rows.Count)
				{
					string a = dataTable.Rows[i]["Type"].ToString();
					if (a == "2")
					{
						htmlGenericControl = (HtmlGenericControl)this.Page.FindControl(dataTable.Rows[i]["DivID"].ToString());
						string text2 = dataTable.Rows[i]["Content"].ToString();
						string text3 = dataTable.Rows[i]["Href"].ToString();
						dataTable.Rows[i]["Width"].ToString();
						dataTable.Rows[i]["Height"].ToString();
						string text4 = dataTable.Rows[i]["explain"].ToString();
						if (num == 1)
						{
							stringBuilder2.Append(string.Concat(new object[]
							{
								"<li value=\"",
								i,
								"\"  class=\"cur\"  style=\"display:block;\"> <a target=\"_blank\" href=\"",
								(text3 == "") ? "javascript:" : text3,
								"\"><img src=\"",
								text2,
								"\" alt=\"",
								text4,
								"\" /></a>"
							}));
							stringBuilder.Append("<li class=\"cur\"  style=\"display:block;\"></li>");
							stringBuilder3.Append(string.Concat(new object[]
							{
								"<li value=\"",
								i,
								"\" class=\"cur\" ><a target=\"_blank\" href=\"",
								(text3 == "") ? "javascript:" : text3,
								"\">",
								text4,
								"</a></li>"
							}));
						}
						else
						{
							stringBuilder2.Append(string.Concat(new object[]
							{
								"<li value=\"",
								i,
								"\" > <a target=\"_blank\" href=\"",
								(text3 == "") ? "javascript:" : text3,
								"\"><img src=\"",
								text2,
								"\" alt=\"",
								text4,
								"\" /></a>"
							}));
							stringBuilder.Append("<li></li>");
							stringBuilder3.Append(string.Concat(new object[]
							{
								"<li value=\"",
								i,
								"\" ><a target=\"_blank\" href=\"",
								(text3 == "") ? "javascript:" : text3,
								"\">",
								text4,
								"</a></li>"
							}));
						}
						num++;
					}
					i++;
				}
				if (htmlGenericControl != null && stringBuilder2.Length != 0)
				{
					StringBuilder stringBuilder4 = new StringBuilder();
					stringBuilder4.Append("<div class=\"slides\" name=\"__DT\">");
					stringBuilder4.Append("<a class=\"np1\"></a><ul class=\"slide-pic\">");
					stringBuilder4.Append(stringBuilder2.ToString());
					stringBuilder4.Append("</ul><a class=\"np2\"></a>");
					stringBuilder4.Append("<ul class=\"slide-li op\">");
					stringBuilder4.Append(stringBuilder.ToString());
					stringBuilder4.Append("</ul>");
					stringBuilder4.Append("<div class=\"suibian\">");
					stringBuilder4.Append("<ul class=\"slide-li slide-txt\">");
					stringBuilder4.Append(stringBuilder3.ToString());
					stringBuilder4.Append("</ul>");
					stringBuilder4.Append("</div>");
					stringBuilder4.Append("</div>");
					htmlGenericControl.InnerHtml = stringBuilder4.ToString();
				}
			}
		}
	}
}
