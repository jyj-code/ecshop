using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class DIV : BaseWebControl
	{
		private string string_0 = "DIV.ascx";
		private HtmlGenericControl htmlGenericControl_0;
		[CompilerGenerated]
		private string string_1;
		public string divID
		{
			get;
			set;
		}
		public DIV()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("AdvertisementDIV");
			this.BindAd();
		}
		public void BindAd()
		{
			ShopNum1_Advertisement_Action shopNum1_Advertisement_Action = (ShopNum1_Advertisement_Action)LogicFactory.CreateShopNum1_Advertisement_Action();
			DataTable dataTable = shopNum1_Advertisement_Action.ShowADByDivID(this.divID);
			if (dataTable != null)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					string type = dataTable.Rows[i]["Type"].ToString();
					string content = dataTable.Rows[i]["Content"].ToString();
					string href = dataTable.Rows[i]["Href"].ToString();
					string width = dataTable.Rows[i]["Width"].ToString();
					string height = dataTable.Rows[i]["Height"].ToString();
					this.InnerHTML(this.htmlGenericControl_0, type, content, href, width, height);
				}
			}
		}
		public void InnerHTML(HtmlGenericControl htmlGenericControl_1, string type, string content, string href, string width, string height)
		{
			if (htmlGenericControl_1 != null && type != null)
			{
				if (!(type == "0"))
				{
					if (!(type == "1"))
					{
						if (!(type == "2"))
						{
							if (type == "3")
							{
								htmlGenericControl_1.InnerHtml = string.Concat(new string[]
								{
									"<object classid='clsid:D27CDB6E-AE6D-11cf-96B8-444553540000' codebase=' http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,28,0' width='",
									width,
									"' height='",
									height,
									"'><param name='movie' value='",
									content,
									"' /><param name='quality' value='high' /><param name='quality' value='high' /><embed src='",
									content,
									"' quality='high' wmode='transparent' pluginspage='http://www.adobe.com/shockwave/download/download.cgi?P1_Prod_Version=ShockwaveFlash' type='application/x-shockwave-flash' width='",
									width,
									"' height='",
									height,
									"'></embed>"
								});
							}
						}
						else
						{
							htmlGenericControl_1.InnerHtml = "";
						}
					}
					else
					{
						htmlGenericControl_1.InnerHtml = string.Concat(new string[]
						{
							"<a href='",
							href,
							"' target='_blank'><img src='",
							Globals.ImagePath,
							content.Substring(content.LastIndexOf('/') + 1),
							"' width='",
							width,
							"' height='",
							height,
							"' border='0' /></a>"
						});
					}
				}
				else if (href == "")
				{
					htmlGenericControl_1.InnerHtml = content;
				}
				else
				{
					htmlGenericControl_1.InnerHtml = string.Concat(new string[]
					{
						"<a href='",
						href,
						"' target='_blank'>",
						content,
						"</a>"
					});
				}
			}
		}
	}
}
