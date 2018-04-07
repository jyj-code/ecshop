using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class DefaultAdvertisementFlash : BaseWebControl
	{
		private string string_0 = "DefaultAdvertisementFlash.ascx";
		private HtmlGenericControl htmlGenericControl_0;
		private string string_1 = "247";
		private string string_2 = "497";
		private string string_3 = "0x333333";
		private string string_4 = "0xFCEBAF";
		[CompilerGenerated]
		private string string_5;
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
		public DefaultAdvertisementFlash()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("DivFlash");
			this.BindAd();
		}
		public void BindAd()
		{
			string text = "";
			string text2 = "";
			string text3 = "";
			ShopNum1_Advertisement_Action shopNum1_Advertisement_Action = (ShopNum1_Advertisement_Action)LogicFactory.CreateShopNum1_Advertisement_Action();
			DataTable dataTable = shopNum1_Advertisement_Action.ShowADByDivID(this.DivFlashID, "2");
			if (dataTable != null)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
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
			this.method_0(this.htmlGenericControl_0, text, text2, text3);
		}
		private void method_0(HtmlGenericControl htmlGenericControl_1, string string_6, string string_7, string string_8)
		{
			string flashWidth = this.FlashWidth;
			string flashHeight = this.FlashHeight;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("<script type=\"text/javascript\">");
			stringBuilder.AppendLine(" var swf_width=" + flashWidth);
			stringBuilder.AppendLine("var swf_height=" + flashHeight);
			stringBuilder.AppendLine(" var files='" + string_6 + "'");
			stringBuilder.AppendLine("var links='" + string_7 + "'");
			stringBuilder.AppendLine("var texts='" + string_8 + "'");
			stringBuilder.AppendLine("document.write('<param name=\"movie\" value=\"Themes/Skin_Default/bcastr3.swf\"><param name=\"quality\" value=\"high\">');");
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
				"document.write('<embed src=\"Themes/Skin_Default/bcastr3.swf\" wmode=\"opaque\" FlashVars=\"bcastr_file='+files+'&bcastr_link='+links+'&bcastr_title='+texts+'&bcastr_config=",
				this.WordColor,
				":文字颜色|1:文字位置|",
				this.backcolors,
				":文字背景颜色|60:文字背景透明度|0xffffff:按键文字颜色|0xdedede:按键默认颜色|0x4A3E28:按键当前颜色|8:自动播放时间(秒)|2:图片过渡效果|1:是否显示按钮|_blank:打开窗口& menu=\"false\" quality=\"high\" width=\"'+ swf_width +'\" height=\"'+ swf_height +'\" type=\"application/x-shockwave-flash\" pluginspage=\"http://www.macromedia.com/go/getflashplayer\" />'); document.write('</object>');"
			}));
			stringBuilder.AppendLine("</script>");
			htmlGenericControl_1.InnerHtml = stringBuilder.ToString();
		}
	}
}
