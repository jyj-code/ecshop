using ShopNum1.MultiBaseWebControl;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class ImgCode : BaseWebControl
	{
		private string string_0 = "ImgCode.ascx";
		private int int_0;
		public int isSession
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_0 = value;
			}
		}
		public ImgCode()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
		}
		private string method_0()
		{
			Func<string, string> func = new Func<string, string>(this.method_2);
			string text = string.Empty;
			Random random = new Random();
			for (int i = 0; i < 4; i++)
			{
				int num = random.Next();
				char c;
				if (num % 2 == 0)
				{
					c = (char)(48 + (ushort)(num % 10));
				}
				else
				{
					c = (char)(65 + (ushort)(num % 26));
				}
				text += c.ToString();
			}
			return func(text);
		}
		private void method_1(string string_1)
		{
			Bitmap bitmap = new Bitmap((int)Math.Ceiling((double)string_1.Length * 13.5), 22);
			Graphics graphics = Graphics.FromImage(bitmap);
			try
			{
				Random random = new Random();
				graphics.Clear(Color.White);
				for (int i = 0; i < 25; i++)
				{
					int x = random.Next(bitmap.Width);
					int x2 = random.Next(bitmap.Width);
					int y = random.Next(bitmap.Height);
					int y2 = random.Next(bitmap.Height);
					graphics.DrawLine(new Pen(Color.Silver), x, y, x2, y2);
				}
				Font font = new Font("Arial", 12f, FontStyle.Bold | FontStyle.Italic);
				LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, bitmap.Width, bitmap.Height), Color.Blue, Color.DarkRed, 1.2f, true);
				graphics.DrawString(string_1, font, brush, 2f, 2f);
				for (int i = 0; i < 100; i++)
				{
					int x3 = random.Next(bitmap.Width);
					int y3 = random.Next(bitmap.Height);
					bitmap.SetPixel(x3, y3, Color.FromArgb(random.Next()));
				}
				graphics.DrawRectangle(new Pen(Color.Silver), 0, 0, bitmap.Width - 1, bitmap.Height - 1);
				MemoryStream memoryStream = new MemoryStream();
				bitmap.Save(memoryStream, ImageFormat.Gif);
				this.Page.Response.ClearContent();
				this.Page.Response.ContentType = "image/Gif";
				this.Page.Response.BinaryWrite(memoryStream.ToArray());
			}
			finally
			{
				graphics.Dispose();
				bitmap.Dispose();
			}
		}
		protected override void Render(HtmlTextWriter writer)
		{
			this.method_1(this.method_0());
		}
		[CompilerGenerated]
		private string method_2(string string_1)
		{
			if (this.isSession == 1)
			{
				HttpContext.Current.Session["code"] = string_1;
			}
			else
			{
				this.Page.Response.Cookies.Remove("VerifyCode");
				this.Page.Response.Cookies.Add(new HttpCookie("VerifyCode", string_1));
			}
			return string_1;
		}
	}
}
