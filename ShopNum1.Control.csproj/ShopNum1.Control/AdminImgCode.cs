using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.Control
{
	[ParseChildren(true)]
	public class AdminImgCode : System.Web.UI.WebControls.WebControl
	{
		protected override void Render(HtmlTextWriter writer)
		{
			this.method_0();
		}
		private void method_0()
		{
			Random random = new Random();
			string text = random.Next(1111, 9999).ToString();
			Bitmap bitmap = null;
			Graphics graphics = null;
			SolidBrush solidBrush = null;
			this.method_1(text);
			try
			{
				System.Drawing.Image image = System.Drawing.Image.FromFile(this.Page.Server.MapPath("images/CheckCode/" + text.Substring(0, 1) + ".gif"));
				System.Drawing.Image image2 = System.Drawing.Image.FromFile(this.Page.Server.MapPath("images/CheckCode/" + text.Substring(1, 1) + ".gif"));
				System.Drawing.Image image3 = System.Drawing.Image.FromFile(this.Page.Server.MapPath("images/CheckCode/" + text.Substring(2, 1) + ".gif"));
				System.Drawing.Image image4 = System.Drawing.Image.FromFile(this.Page.Server.MapPath("images/CheckCode/" + text.Substring(3, 1) + ".gif"));
				int width = image.Width + image2.Width + image3.Width + image4.Width + 20;
				int height = image.Height + 5;
				bitmap = new Bitmap(width, height);
				graphics = Graphics.FromImage(bitmap);
				int red = Convert.ToInt32("63", 16);
				int green = Convert.ToInt32("92", 16);
				int blue = Convert.ToInt32("C2", 16);
				solidBrush = new SolidBrush(Color.FromArgb(red, green, blue));
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
				for (int i = 0; i < 2; i++)
				{
					int x = random.Next(80);
					int y5 = random.Next(25);
					int x2 = random.Next(80);
					int y6 = random.Next(25);
					Color color = array[random.Next(array.Length)];
					graphics.DrawLine(new Pen(color), x, y5, x2, y6);
				}
				for (int i = 0; i < 100; i++)
				{
					int x3 = random.Next(bitmap.Width);
					int y7 = random.Next(bitmap.Height);
					bitmap.SetPixel(x3, y7, Color.FromArgb(random.Next()));
				}
				MemoryStream memoryStream = new MemoryStream();
				bitmap.Save(memoryStream, ImageFormat.Bmp);
				this.Page.Response.ClearContent();
				this.Page.Response.ContentType = "image/bmp";
				this.Page.Response.BinaryWrite(memoryStream.ToArray());
			}
			finally
			{
				solidBrush.Dispose();
				graphics.Dispose();
				bitmap.Dispose();
			}
		}
		private void method_1(string string_0)
		{
			HttpCookie httpCookie = new HttpCookie("VerifyCode");
			if (httpCookie != null)
			{
				httpCookie.Value = string_0;
				this.Page.Response.Cookies.Add(httpCookie);
			}
		}
	}
}
