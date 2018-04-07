using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopWebControl
{
	[ParseChildren(true)]
	public class Advertisements : BaseWebControl
	{
		private string string_0 = "Advertisement.ascx";
		private Image image_0;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		[CompilerGenerated]
		private string string_4;
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
		public string MemLoginID
		{
			get;
			set;
		}
		public string PageName
		{
			get;
			set;
		}
		public Advertisements()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.image_0 = (Image)skin.FindControl("ImgAdvertiment");
			string text = (this.Page.Request.QueryString["ShopID"] == null) ? "0" : this.Page.Request.QueryString["ShopID"].ToString();
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = new ShopNum1_ShopInfoList_Action();
			try
			{
				string text2 = shopNum1_ShopInfoList_Action.GetShopOpenTimeByShopID(text);
				if (text2 != "")
				{
					text2 = DateTime.Parse(text2).ToString("yyyy-MM-dd");
					this.SetPath = string.Concat(new string[]
					{
						"~/Shop/Shop/",
						text2.Replace("-", "/"),
						"/",
						ShopSettings.GetValue("PersonShopUrl"),
						text,
						"/Themes/Skin_Default/Advertisement.xml"
					});
					this.BindAd();
				}
			}
			catch
			{
			}
		}
		public void BindAd()
		{
			string arg_10_0 = this.Page.Request.FilePath;
			Shop_Advertisement_Action shop_Advertisement_Action = (Shop_Advertisement_Action)LogicFactory.CreateShop_Advertisement_Action();
			shop_Advertisement_Action.StrPath = this.SetPath;
			if (this.PageName == "Default.aspx")
			{
				DataTable dataTable = shop_Advertisement_Action.ShowAD(this.PageName);
				if (dataTable != null)
				{
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						HtmlGenericControl htmlGenericControl_ = (HtmlGenericControl)this.Page.FindControl(dataTable.Rows[i]["DivID"].ToString());
						string text = dataTable.Rows[i]["Type"].ToString();
						string content = dataTable.Rows[i]["Content"].ToString();
						string href = dataTable.Rows[i]["Href"].ToString();
						string width = dataTable.Rows[i]["Width"].ToString();
						string height = dataTable.Rows[i]["Height"].ToString();
						if (text != "2")
						{
							this.InnerHTML(htmlGenericControl_, text, content, href, width, height);
						}
					}
				}
			}
			else
			{
				DataTable dataTable = shop_Advertisement_Action.ShowAD(this.PageName);
				if (dataTable != null)
				{
					this.image_0.ImageUrl = dataTable.Rows[0]["Content"].ToString();
					this.image_0.ToolTip = dataTable.Rows[0]["pagename"].ToString();
					this.image_0.Width = Convert.ToInt32(dataTable.Rows[0]["Width"].ToString());
					this.image_0.Height = Convert.ToInt32(dataTable.Rows[0]["Height"].ToString());
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
								content,
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
							content,
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
