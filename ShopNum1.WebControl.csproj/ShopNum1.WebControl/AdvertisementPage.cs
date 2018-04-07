using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class AdvertisementPage : BaseWebControl
	{
		private string string_0 = "AdvertisementPage.ascx";
		public AdvertisementPage()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.BindAd();
		}
		public void BindAd()
		{
			string filePath = this.Page.Request.FilePath;
			string text = filePath.Substring(filePath.LastIndexOf('/') + 1);
			if (text == "")
			{
				text = "Default.aspx";
			}
			ShopNum1_Advertisement_Action shopNum1_Advertisement_Action = (ShopNum1_Advertisement_Action)LogicFactory.CreateShopNum1_Advertisement_Action();
			DataTable dataTable = shopNum1_Advertisement_Action.SearchPPT(text);
			StringBuilder stringBuilder = new StringBuilder();
			StringBuilder stringBuilder2 = new StringBuilder();
			StringBuilder stringBuilder3 = new StringBuilder();
			HtmlGenericControl htmlGenericControl = new HtmlGenericControl();
			if (dataTable != null)
			{
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
						if (num == 2)
						{
							stringBuilder2.Append(string.Concat(new string[]
							{
								"<li class=\"cur\"> <a target=\"_blank\" href=\"",
								(text3 == "") ? "javascript:" : text3,
								"\"><img src=\"",
								text2,
								"\" alt=\"",
								text4,
								"\" /></a>"
							}));
							stringBuilder.Append("<li class=\"cur\"></li>");
							stringBuilder3.Append(string.Concat(new string[]
							{
								"<li class=\"cur\"><a target=\"_blank\" href=\"",
								(text3 == "") ? "javascript:" : text3,
								"\">",
								text4,
								"</a></li>"
							}));
						}
						else
						{
							stringBuilder2.Append(string.Concat(new string[]
							{
								"<li> <a target=\"_blank\" href=\"",
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
					stringBuilder4.Append("<ul class=\"slide-pic\">");
					stringBuilder4.Append(stringBuilder2.ToString());
					stringBuilder4.Append("</ul>");
					stringBuilder4.Append("<ul class=\"slide-li op\">");
					stringBuilder4.Append(stringBuilder.ToString());
					stringBuilder4.Append("</ul>");
					stringBuilder4.Append("<ul class=\"slide-li slide-txt\">");
					stringBuilder4.Append(stringBuilder3.ToString());
					stringBuilder4.Append("</ul>");
					stringBuilder4.Append("</div>");
					htmlGenericControl.InnerHtml = stringBuilder4.ToString();
				}
			}
		}
	}
}
