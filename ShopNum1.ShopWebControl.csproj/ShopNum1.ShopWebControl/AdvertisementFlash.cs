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
	public class AdvertisementFlash : BaseWebControl
	{
		private string string_0 = "Advertisements.ascx";
		private string string_1 = "200";
		private string string_2 = "702";
		private string string_3 = "0xFFFFFF";
		private string string_4 = "0xE14D4D";
		[CompilerGenerated]
		private string string_5;
		[CompilerGenerated]
		private string string_6;
		[CompilerGenerated]
		private string string_7;
		[CompilerGenerated]
		private string string_8;
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
		public string DivFlashID
		{
			get;
			set;
		}
		public string FlashHeight
		{
			get
			{
				return this.string_1;
			}
			set
			{
				this.string_1 = value;
			}
		}
		public string FlashWidth
		{
			get
			{
				return this.string_2;
			}
			set
			{
				this.string_2 = value;
			}
		}
		public string WordColor
		{
			get
			{
				return this.string_3;
			}
			set
			{
				this.string_3 = value;
			}
		}
		public string backcolors
		{
			get
			{
				return this.string_4;
			}
			set
			{
				this.string_4 = value;
			}
		}
		public AdvertisementFlash()
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
					this.BindAd();
				}
			}
		}
		public void BindAd()
		{
			string text = "";
			string text2 = "";
			string text3 = "";
			Shop_Advertisement_Action shop_Advertisement_Action = (Shop_Advertisement_Action)LogicFactory.CreateShop_Advertisement_Action();
			shop_Advertisement_Action.StrPath = this.SetPath;
			DataTable dataTable = shop_Advertisement_Action.ShowADByDivID(this.DivFlashID);
			if (dataTable != null)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					if (dataTable.Rows[i]["type"].ToString() == "3")
					{
						string text4 = dataTable.Rows[i]["Content"].ToString();
						if (text == "")
						{
							text = text4;
						}
						else
						{
							text = text + "|" + text4;
						}
						string text5 = dataTable.Rows[i]["Href"].ToString();
						if (text2 == "")
						{
							text2 = text5;
						}
						else
						{
							text2 = text2 + "|" + text5;
						}
						string text6 = dataTable.Rows[i]["explain"].ToString();
						if (text3 == "")
						{
							text3 = text6;
						}
						else
						{
							text3 = text3 + "|" + text6;
						}
					}
				}
			}
			HtmlGenericControl htmlGenericControl_ = (HtmlGenericControl)this.Page.FindControl(this.DivFlashID);
			this.method_0(htmlGenericControl_, text, text2, text3);
		}
		private void method_0(HtmlGenericControl htmlGenericControl_0, string string_9, string string_10, string string_11)
		{
			string flashWidth = this.FlashWidth;
			string flashHeight = this.FlashHeight;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("<script type=\"text/javascript\">");
			stringBuilder.AppendLine(" var swf_width=" + flashWidth);
			stringBuilder.AppendLine("var swf_height=" + flashHeight);
			stringBuilder.AppendLine(" var files='" + string_9 + "'");
			stringBuilder.AppendLine("var links='" + string_10 + "'");
			stringBuilder.AppendLine("var texts='" + string_11 + "'");
			stringBuilder.AppendLine("document.write('<param name=\"movie\" value=\"bcastr3.swf\"><param name=\"quality\" value=\"high\">');");
			stringBuilder.AppendLine("document.write('<param name=\"menu\" value=\"false\"><param name=wmode value=\"opaque\">');");
			stringBuilder.AppendLine(string.Concat(new string[]
			{
				"document.write('<param name=\"FlashVars\" value=\"bcastr_file='+files+'&bcastr_link='+links+'&bcastr_title='+texts+'&bcastr_config=",
				this.WordColor,
				":文字颜色|1:文字位置|",
				this.backcolors,
				":文字背景颜色|60:文字背景透明度|0x333333:按键文字颜色|0x4A3E28:按键默认颜色|0x4A3E28:按键当前颜色|8:自动播放时间(秒)|2:图片过渡效果|1:是否显示按钮|_blank:打开窗口\">');"
			}));
			stringBuilder.AppendLine(string.Concat(new string[]
			{
				"document.write('<embed src=\"bcastr3.swf\" wmode=\"opaque\" FlashVars=\"bcastr_file='+files+'&bcastr_link='+links+'&bcastr_title='+texts+'&bcastr_config=",
				this.WordColor,
				":文字颜色|1:文字位置|",
				this.backcolors,
				":文字背景颜色|60:文字背景透明度|0xffffff:按键文字颜色|0xdedede:按键默认颜色|0x4A3E28:按键当前颜色|8:自动播放时间(秒)|2:图片过渡效果|1:是否显示按钮|_blank:打开窗口& menu=\"false\" quality=\"high\" width=\"'+ swf_width +'\" height=\"'+ swf_height +'\" type=\"application/x-shockwave-flash\" pluginspage=\"http://www.macromedia.com/go/getflashplayer\" />'); document.write('</object>');"
			}));
			stringBuilder.AppendLine("</script>");
			htmlGenericControl_0.InnerHtml = stringBuilder.ToString();
		}
	}
}
