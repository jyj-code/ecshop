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
	public class Advertisement : BaseWebControl
	{
		private string string_0 = "Advertisement.ascx";
		[CompilerGenerated]
		private string string_1;
		public string FileName
		{
			get;
			set;
		}
		public Advertisement()
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
			DataTable dataTable = shopNum1_Advertisement_Action.ShowAD(text);
			if (dataTable != null)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					HtmlGenericControl htmlGenericControl_ = (HtmlGenericControl)this.Page.FindControl(dataTable.Rows[i]["DivID"].ToString());
					string text2 = dataTable.Rows[i]["Type"].ToString();
					string content = dataTable.Rows[i]["Content"].ToString();
					string href = dataTable.Rows[i]["Href"].ToString();
					string width = dataTable.Rows[i]["Width"].ToString();
					string height = dataTable.Rows[i]["Height"].ToString();
					if (text2 != "2")
					{
						this.InnerHTML(htmlGenericControl_, text2, content, href, width, height);
					}
				}
			}
		}
		public void InnerHTML(HtmlGenericControl htmlGenericControl_0, string type, string content, string href, string width, string height)
		{
			if (htmlGenericControl_0 != null && type != null)
			{
				if (!(type == "0"))
				{
					if (!(type == "1"))
					{
						if (type == "2")
						{
							htmlGenericControl_0.InnerHtml = string.Concat(new string[]
							{
								"<object classid='clsid:D27CDB6E-AE6D-11cf-96B8-444553540000' codebase=' http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0' width='",
								width,
								"' height='",
								height,
								"'><param name='movie' value='",
								Globals.ImagePath,
								content.Substring(content.LastIndexOf('/') + 1),
								"' /><param name='quality' value='high' /><embed src='",
								content,
								"' quality='high' pluginspage=' http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash'></embed></object>"
							});
						}
					}
					else
					{
						htmlGenericControl_0.InnerHtml = string.Concat(new string[]
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
					htmlGenericControl_0.InnerHtml = content;
				}
				else
				{
					htmlGenericControl_0.InnerHtml = string.Concat(new string[]
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
