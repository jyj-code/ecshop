using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class Bottom : BaseWebControl
	{
		private string string_0 = "Bottom.ascx";
		private string string_1 = "all";
		private Literal literal_0;
		private Label label_0;
		public Bottom()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			if (this.Page.Request.QueryString["SubstationID"] != null && !string.IsNullOrEmpty(this.Page.Request.QueryString["SubstationID"].ToString()))
			{
				this.string_1 = this.Page.Request.QueryString["SubstationID"].ToString();
			}
			this.literal_0 = (Literal)skin.FindControl("LiteralShowMenu");
			this.label_0 = (Label)skin.FindControl("LabelShopCopy");
			this.method_0();
			this.label_0.Text = ShopSettings.GetValue("Copyright");
		}
		private void method_0()
		{
			DataTable tableById = ShopNum1.Common.Common.GetTableById("*", "ShopNum1_UserDefinedColumn", "  AND    ShowLocation=1 AND    IsMember =1 And ifshow=1 and   SubstationID='" + this.string_1 + "'    ORDER  BY   OrderID  DESC    ");
			if (tableById != null)
			{
				StringBuilder stringBuilder = new StringBuilder();
				string a = string.Empty;
				if (this.Page.Request.QueryString["tag"] != null)
				{
					a = this.Page.Request.QueryString["tag"].ToString();
				}
				for (int i = 0; i < tableById.Rows.Count; i++)
				{
					string text = tableById.Rows[i]["LinkAddress"].ToString();
					if (text.Contains("http://"))
					{
						if (text.Contains("?"))
						{
							stringBuilder.Append(string.Concat(new object[]
							{
								"<a id=lia",
								i,
								" href='",
								text,
								"'"
							}));
						}
						else
						{
							stringBuilder.Append(string.Concat(new object[]
							{
								"<a id=lia",
								i,
								" href='",
								text,
								"'"
							}));
						}
					}
					else
					{
						stringBuilder.Append(string.Concat(new object[]
						{
							"<a id=lia",
							i,
							" href='http://",
							ShopSettings.siteDomain,
							"/",
							text,
							this.GetOverrideUrlName(),
							"'"
						}));
					}
					if (a == string.Empty && this.Page.Request.RawUrl.ToLower().Contains("default") && i == 0)
					{
						stringBuilder.Append(" class=\"curr\" ");
						stringBuilder.Append(" target='" + this.method_1(tableById.Rows[i]["IfOpen"].ToString()) + "'>");
						stringBuilder.Append(tableById.Rows[i]["Name"] + "</a>|");
						stringBuilder.AppendLine("</li>");
					}
					else
					{
						if (a == i.ToString())
						{
							stringBuilder.Append(" class=\"curr\" ");
						}
						else
						{
							stringBuilder.Append(" style=''");
						}
						stringBuilder.Append(" target='" + this.method_1(tableById.Rows[i]["IfOpen"].ToString()) + "'>");
						stringBuilder.Append(tableById.Rows[i]["Name"] + "</a>|");
					}
				}
				try
				{
					this.literal_0.Text = stringBuilder.ToString().Substring(0, stringBuilder.ToString().Length - 1);
				}
				catch (Exception)
				{
					this.literal_0.Text = "";
				}
			}
		}
		private string method_1(string string_2)
		{
			if (string_2 == "0")
			{
				string_2 = "_self";
			}
			else if (string_2 == "1")
			{
				string_2 = "_blank";
			}
			return string_2;
		}
		public string GetOverrideUrlName()
		{
			string result;
			if (ShopSettings.IsOverrideUrl)
			{
				result = ShopSettings.overrideUrlName;
			}
			else
			{
				result = ".aspx";
			}
			return result;
		}
	}
}
