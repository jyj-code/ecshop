using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Drawing;
using System.Web;
using System.Web.UI;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class VerifyImageCode : BaseWebControl
	{
		private string string_0 = "ImgCode.ascx";
		public VerifyImageCode()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
		}
		private void method_0()
		{
			string text = "#f6f4f0";
			int textcolor = 1;
			string[] array = text.Split(new char[]
			{
				','
			});
			Color bgcolor = ColorTranslator.FromHtml(text);
			if ((array.Length != 1 || !(text != string.Empty)) && array.Length == 3 && Validator.IsNumericArray(array))
			{
				bgcolor = Color.FromArgb(TypeConverter.StrToInt(array[0], 255), TypeConverter.StrToInt(array[1], 255), TypeConverter.StrToInt(array[2], 255));
			}
			VerifyImageInfo verifyImageInfo = VerifyImageProvider.GetInstance("1.0.8.16").GenerateImage(this.method_1(), 128, 48, bgcolor, textcolor);
			Bitmap image = verifyImageInfo.Image;
			HttpContext.Current.Response.ContentType = verifyImageInfo.ContentType;
			image.Save(this.Page.Response.OutputStream, verifyImageInfo.ImageFormat);
		}
		private string method_1()
		{
			string text = string.Empty;
			Random random = new Random();
			for (int i = 0; i < 6; i++)
			{
				int num = random.Next();
				char c;
				if (num % 2 == 0)
				{
					c = (char)(48 + (ushort)(num % 10));
				}
				else
				{
					c = (char)(97 + (ushort)(num % 26));
				}
				text += c.ToString();
			}
			this.Page.Response.Cookies.Remove("VerifyCode");
			this.Page.Response.Cookies.Add(new HttpCookie("VerifyCode", text));
			return text;
		}
		protected override void Render(HtmlTextWriter writer)
		{
			this.method_0();
		}
	}
}
