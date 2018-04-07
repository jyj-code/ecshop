using System;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.Control
{
	[ParseChildren(true)]
	public class VerifyCodeColorImg : System.Web.UI.WebControls.WebControl
	{
		private string string_0;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		public string isSession
		{
			get
			{
				return this.string_0;
			}
			set
			{
				this.string_0 = value;
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
			this.method_0();
		}
		private void method_0()
		{
			Random random = new Random();
			string text = random.Next(1111, 9999).ToString();
			int width = 0;
			int height = 0;
			Bitmap bitmap = null;
			Graphics graphics = null;
			SolidBrush solidBrush = null;
			this.method_1(text);
			try
			{
				System.Drawing.Image image = System.Drawing.Image.FromFile(this.Page.Server.MapPath("Themes/Skin_Default/images/CheckCode/" + text.Substring(0, 1) + ".gif"));
				System.Drawing.Image image2 = System.Drawing.Image.FromFile(this.Page.Server.MapPath("Themes/Skin_Default/images/CheckCode/" + text.Substring(1, 1) + ".gif"));
				System.Drawing.Image image3 = System.Drawing.Image.FromFile(this.Page.Server.MapPath("Themes/Skin_Default/images/CheckCode/" + text.Substring(2, 1) + ".gif"));
				System.Drawing.Image image4 = System.Drawing.Image.FromFile(this.Page.Server.MapPath("Themes/Skin_Default/images/CheckCode/" + text.Substring(3, 1) + ".gif"));
				width = image.Width + image2.Width + image3.Width + image4.Width + 20;
				height = image.Height + 5;
				bitmap = new Bitmap(width, height);
				graphics = Graphics.FromImage(bitmap);
				try
				{
					Color color = this.ToColor(this.BackgroundColor);
					solidBrush = new SolidBrush(color);
				}
				catch
				{
					int red = Convert.ToInt32("63", 16);
					int green = Convert.ToInt32("92", 16);
					int blue = Convert.ToInt32("C2", 16);
					solidBrush = new SolidBrush(Color.FromArgb(red, green, blue));
				}
				int num = random.Next(0, 5);
				int num2 = random.Next(0, 5);
				int num3 = random.Next(0, 5);
				random.Next(0, 5);
				int y = random.Next(0, 5);
				int y2 = random.Next(0, 5);
				int y3 = random.Next(0, 5);
				int y4 = random.Next(0, 5);
				graphics.FillRectangle(solidBrush, 0, 0, width, height);
				graphics.DrawImage(image, num, y);
				graphics.DrawImage(image2, image.Width + num + num2, y2);
				graphics.DrawImage(image3, image.Width + image2.Width + num + num2 + num3, y3);
				graphics.DrawImage(image4, image.Width + image2.Width + image3.Width + num + num2 + num3, y4);
				Color[] array = new Color[]
				{
					Color.Black,
					Color.Green,
					Color.Orange,
					Color.Brown
				};
				for (int i = 0; i < 100; i++)
				{
					int x = random.Next(bitmap.Width);
					int y5 = random.Next(bitmap.Height);
					bitmap.SetPixel(x, y5, Color.FromArgb(random.Next()));
				}
				MemoryStream memoryStream = new MemoryStream();
				bitmap.Save(memoryStream, ImageFormat.Bmp);
				this.Page.Response.ClearContent();
				this.Page.Response.ContentType = "image/bmp";
				this.Page.Response.BinaryWrite(memoryStream.ToArray());
			}
			catch
			{
			}
			finally
			{
				solidBrush.Dispose();
				graphics.Dispose();
				bitmap.Dispose();
			}
		}
		public Color ToColor(string color)
		{
			color = color.TrimStart(new char[]
			{
				'#'
			});
			color = Regex.Replace(color.ToLower(), "[g-zG-Z]", "");
			int length = color.Length;
			Color result;
			if (length != 3)
			{
				if (length != 6)
				{
					result = Color.FromName(color);
				}
				else
				{
					char[] array = color.ToCharArray();
					int red = Convert.ToInt32(array[0].ToString() + array[1].ToString(), 16);
					int green = Convert.ToInt32(array[2].ToString() + array[3].ToString(), 16);
					int blue = Convert.ToInt32(array[4].ToString() + array[5].ToString(), 16);
					result = Color.FromArgb(red, green, blue);
				}
			}
			else
			{
				char[] array = color.ToCharArray();
				int red = Convert.ToInt32(array[0].ToString() + array[0].ToString(), 16);
				int green = Convert.ToInt32(array[1].ToString() + array[1].ToString(), 16);
				int blue = Convert.ToInt32(array[2].ToString() + array[2].ToString(), 16);
				result = Color.FromArgb(red, green, blue);
			}
			return result;
		}
		private void method_1(string string_3)
		{
			object obj = ConfigurationManager.AppSettings["CookieName"];
			string text = (obj == null) ? "VerifyCode" : obj.ToString();
			if (!string.IsNullOrEmpty(this.PrefixCookieName))
			{
				text = this.PrefixCookieName + text;
			}
			if (this.isSession != "1")
			{
				HttpCookie httpCookie = new HttpCookie(text);
				if (httpCookie != null)
				{
					httpCookie.Value = string_3;
					this.Page.Response.Cookies.Add(httpCookie);
				}
			}
			else
			{
				HttpContext.Current.Session[text] = string_3;
			}
		}
	}
}
