using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.Control
{
	[ParseChildren(true)]
	public class VerifyCodeColorAdminImg : System.Web.UI.WebControls.WebControl
	{
		private int int_0;
		[CompilerGenerated]
		private string string_0;
		[CompilerGenerated]
		private string string_1;
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
		public string BackgroundColor
		{
			get;
			set;
		}
		public string PrefixCookieName
		{
			get;
			set;
		}
		protected override void Render(HtmlTextWriter writer)
		{
			this.method_1(this.method_0());
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
		private void method_1(string string_2)
		{
			Bitmap bitmap = new Bitmap((int)Math.Ceiling((double)string_2.Length * 13.5), 22);
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
				LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, bitmap.Width, bitmap.Height), Color.Green, Color.Green, 1.2f, true);
				graphics.DrawString(string_2, font, brush, 2f, 2f);
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
		[CompilerGenerated]
		private string method_2(string string_2)
		{
			if (this.isSession == 1)
			{
				HttpContext.Current.Session["code"] = string_2;
			}
			else
			{
				string text = "VerifyCode";
				if (!string.IsNullOrEmpty(this.PrefixCookieName))
				{
					text = this.PrefixCookieName + text;
				}
				this.Page.Response.Cookies.Remove(text);
				this.Page.Response.Cookies.Add(new HttpCookie(text, string_2));
			}
			return string_2;
		}
	}
}
