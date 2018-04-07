using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.Control
{
	public class ProgressBar : WebControl
	{
		private int int_3 = 0;
		private int int_4 = 20;
		private string string_3 = "";
		private string string_4 = "";
		private string string_5 = "";
		public int PercentageStep
		{
			get
			{
				return 100 / this.int_4;
			}
			set
			{
				if (100 % value != 0)
				{
					throw new ArgumentException("The percentage step value must be divisible by 100");
				}
				this.int_4 = 100 / value;
			}
		}
		public string FillImageUrl
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
		public string BarImageUrl
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
		public string ImageGeneratorUrl
		{
			get
			{
				return this.string_5;
			}
			set
			{
				this.string_5 = value;
			}
		}
		public int Percentage
		{
			get
			{
				return this.int_3;
			}
			set
			{
				if (value > 100)
				{
					this.int_3 = 100;
				}
				else if (value < 0)
				{
					this.int_3 = 0;
				}
				else
				{
					this.int_3 = value;
				}
			}
		}
		public ProgressBar()
		{
			this.BackColor = Color.LightGray;
			this.ForeColor = Color.Blue;
			this.BorderColor = Color.Empty;
			base.Width = Unit.Pixel(100);
			base.Height = Unit.Pixel(16);
		}
		protected override void Render(HtmlTextWriter output)
		{
			if (this.Width.Type != UnitType.Pixel)
			{
				throw new ArgumentException("The width must be in pixels");
			}
			int num = (int)this.Width.Value;
			if (this.ImageGeneratorUrl != "")
			{
				string text = "";
				if (this.BorderColor != Color.Empty)
				{
					text = "&bc=" + ColorTranslator.ToHtml(this.BorderColor);
				}
				output.Write(string.Format("<img src='{0}?w={1}&h={2}&p={3}&fc={4}&bk={5}{6}' border='0' width='{1}' height='{2}'>", new object[]
				{
					this.ImageGeneratorUrl,
					num,
					this.Height.ToString(),
					this.Percentage,
					ColorTranslator.ToHtml(this.ForeColor),
					ColorTranslator.ToHtml(this.BackColor),
					text
				}));
			}
			else
			{
				if (this.BorderColor != Color.Empty)
				{
					output.Write("<table border='0' cellspacing='0' cellpadding='1' bgColor='" + ColorTranslator.ToHtml(this.BorderColor) + "'><tr><td>");
				}
				if (this.BarImageUrl == "")
				{
					output.Write(string.Concat(new object[]
					{
						"<table border='0' cellspacing='0' cellpadding='0' height='",
						this.Height,
						"' bgColor='",
						ColorTranslator.ToHtml(this.BackColor),
						"'><tr>"
					}));
					int num2 = num / this.int_4;
					int num3 = 0;
					int percentageStep = this.PercentageStep;
					string text2 = "";
					if (this.Page.Request.Browser.Browser.ToUpper() == "NETSCAPE")
					{
						if (this.FillImageUrl != "")
						{
							text2 = string.Concat(new object[]
							{
								"<img src='",
								this.FillImageUrl,
								"' border='0' width='",
								num2,
								"'>"
							});
						}
						else
						{
							text2 = "&nbsp;";
						}
					}
					int i = 0;
					while (i < this.int_4)
					{
						string text3;
						if (num3 < this.int_3)
						{
							text3 = " bgColor='" + ColorTranslator.ToHtml(this.ForeColor) + "'";
						}
						else
						{
							text3 = "";
						}
						if (i == 0)
						{
							output.Write(string.Concat(new object[]
							{
								"<td height='",
								this.Height,
								"' width='",
								num2,
								"'",
								text3,
								">",
								text2,
								"</td>"
							}));
						}
						else
						{
							output.Write(string.Concat(new object[]
							{
								"<td width='",
								num2,
								"'",
								text3,
								">",
								text2,
								"</td>"
							}));
						}
						i++;
						num3 += percentageStep;
					}
					output.Write("</tr></table>");
				}
				else
				{
					int num4 = (int)((double)this.int_3 / 100.0 * (double)num);
					output.Write(string.Concat(new object[]
					{
						"<table border='0' cellpadding='0' cellSpacing='0' bgColor='",
						ColorTranslator.ToHtml(this.BackColor),
						"'><tr><td width='",
						num,
						"'>"
					}));
					output.Write(string.Concat(new object[]
					{
						"<img src='",
						this.BarImageUrl,
						"' width='",
						num4,
						"' height='",
						this.Height,
						"'>"
					}));
					output.Write("</td></tr></table>");
				}
				if (this.BorderColor != Color.Empty)
				{
					output.Write("</td></tr></table>");
				}
			}
		}
	}
}
