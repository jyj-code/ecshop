using ShopNum1.MultiBaseWebControl;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
namespace ShopNum1.ShopWebControl
{
	[ParseChildren(true)]
	public class ShopImgCode : BaseWebControl
	{
		private delegate string Delegate0(string string_0);
		private string string_0 = "ShopImgCode.ascx";
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
		public ShopImgCode()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
		}
		private string method_0()
		{
			ShopImgCode.Delegate0 @delegate = new ShopImgCode.Delegate0(this.method_2);
			string arg = string.Empty;
			char[] array = new char[]
			{
				'2',
				'3',
				'4',
				'5',
				'6',
				'8',
				'a',
				'd',
				'e',
				'f',
				'g',
				'9',
				'A',
				'B',
				'C',
				'D',
				'E',
				'F',
				'G',
				'H',
				'J',
				'K',
				'L',
				'M',
				'N',
				'P',
				'R',
				'S',
				'T',
				'W',
				'X',
				'Y'
			};
			Random random = new Random();
			for (int i = 0; i < 4; i++)
			{
				arg += array[random.Next(array.Length)];
			}
			return @delegate(arg);
		}
		private void method_1(string string_1)
		{
			Color[] array = new Color[]
			{
				Color.Black,
				Color.Red,
				Color.Blue,
				Color.Green,
				Color.Orange,
				Color.Brown,
				Color.DarkBlue
			};
			string[] array2 = new string[]
			{
				"Times New Roman",
				"MS Mincho",
				"Book Antiqua",
				"Gungsuh",
				"PMingLiU",
				"Impact"
			};
			Random random = new Random();
			Bitmap bitmap = new Bitmap(80, 25);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.Clear(Color.White);
			for (int i = 0; i < 5; i++)
			{
				int x = random.Next(80);
				int y = random.Next(25);
				int x2 = random.Next(80);
				int y2 = random.Next(25);
				Color color = array[random.Next(array.Length)];
				graphics.DrawLine(new Pen(color), x, y, x2, y2);
			}
			for (int i = 0; i < string_1.Length; i++)
			{
				string familyName = array2[random.Next(array2.Length)];
				Font font = new Font(familyName, 16f);
				Color color = array[random.Next(array.Length)];
				graphics.DrawString(string_1[i].ToString(), font, new SolidBrush(color), (float)i * 20f, 3f);
			}
			for (int i = 0; i < 100; i++)
			{
				int x3 = random.Next(bitmap.Width);
				int y3 = random.Next(bitmap.Height);
				Color color = array[random.Next(array.Length)];
				bitmap.SetPixel(x3, y3, color);
			}
			this.Page.Response.Buffer = true;
			this.Page.Response.ExpiresAbsolute = DateTime.Now.AddMilliseconds(0.0);
			this.Page.Response.Expires = 0;
			this.Page.Response.CacheControl = "no-cache";
			this.Page.Response.AppendHeader("Pragma", "No-Cache");
			MemoryStream memoryStream = new MemoryStream();
			try
			{
				bitmap.Save(memoryStream, ImageFormat.Png);
				this.Page.Response.ClearContent();
				this.Page.Response.ContentType = "image/Png";
				this.Page.Response.BinaryWrite(memoryStream.ToArray());
			}
			finally
			{
				bitmap.Dispose();
				graphics.Dispose();
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
				this.Page.Response.Cookies.Remove("ShopVerifyCode");
				this.Page.Response.Cookies.Add(new HttpCookie("ShopVerifyCode", string_1));
			}
			return string_1;
		}
	}
}
