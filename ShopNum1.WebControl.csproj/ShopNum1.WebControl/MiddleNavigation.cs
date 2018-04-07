using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Configuration;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class MiddleNavigation : BaseWebControl
	{
		private string string_0 = "MiddleNavigation.ascx";
		private Literal literal_0;
		private string string_1 = "all";
		private Literal literal_1;
		private HtmlGenericControl htmlGenericControl_0;
		private HtmlGenericControl htmlGenericControl_1;
		private HtmlGenericControl htmlGenericControl_2;
		private HtmlGenericControl htmlGenericControl_3;
		private Repeater repeater_0;
		private Label label_0;
		private LinkButton linkButton_0;
		[CompilerGenerated]
		private string string_2;
		public string ShowCount
		{
			get;
			set;
		}
		public MiddleNavigation()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.literal_0 = (Literal)skin.FindControl("literLi");
			if (this.Page.Request.QueryString["SubstationID"] != null && !string.IsNullOrEmpty(this.Page.Request.QueryString["SubstationID"].ToString()))
			{
				this.string_1 = this.Page.Request.QueryString["SubstationID"].ToString();
			}
			this.literal_1 = (Literal)skin.FindControl("LiteralCartCount");
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("login");
			this.htmlGenericControl_1 = (HtmlGenericControl)skin.FindControl("loginOut");
			this.htmlGenericControl_2 = (HtmlGenericControl)skin.FindControl("shopcart1");
			this.htmlGenericControl_3 = (HtmlGenericControl)skin.FindControl("shopcart2");
			this.label_0 = (Label)skin.FindControl("LabelMemLoginID");
			this.linkButton_0 = (LinkButton)skin.FindControl("LinkButtonLoginOut");
			this.linkButton_0.Click += new EventHandler(this.linkButton_0_Click);
			this.repeater_0 = (Repeater)skin.FindControl("RepterNav");
			if (HttpContext.Current.Request.Cookies["MemberLoginCookie"] == null)
			{
				this.htmlGenericControl_0.Visible = true;
				this.htmlGenericControl_1.Visible = false;
				this.linkButton_0.Visible = false;
				this.htmlGenericControl_2.Visible = true;
				this.htmlGenericControl_3.Visible = false;
				try
				{
					this.method_1(this.label_0.Text.Trim());
					goto IL_24C;
				}
				catch (Exception)
				{
					goto IL_24C;
				}
			}
			HttpCookie cookie = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
			HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
			this.label_0.Text = httpCookie.Values["MemLoginID"].ToString();
			this.htmlGenericControl_0.Visible = false;
			this.htmlGenericControl_1.Visible = true;
			this.htmlGenericControl_2.Visible = false;
			this.htmlGenericControl_3.Visible = true;
			this.method_1(this.label_0.Text.Trim());
			IL_24C:
			this.method_0();
		}
		private void method_0()
		{
			IShopNum1_UserDefinedColumn_Action shopNum1_UserDefinedColumn_Action = LogicFactory.CreateShopNum1_UserDefinedColumn_Action();
			DataTable dataTable = shopNum1_UserDefinedColumn_Action.SearchMiddleNavigation(this.ShowCount, 1, this.string_1);
			if (dataTable != null)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.AppendLine("<ul>");
				string a = string.Empty;
				if (this.Page.Request.QueryString["tag"] != null)
				{
					a = this.Page.Request.QueryString["tag"].ToString();
				}
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					stringBuilder.AppendLine("<li>");
					string text = dataTable.Rows[i]["LinkAddress"].ToString();
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
					else if (this.string_1 == "all")
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
							"?tag=",
							i,
							"'"
						}));
					}
					else
					{
						string text2 = string.Empty;
						try
						{
							text2 = ShopNum1.Common.Common.GetNameById("DomainName", "ShopNum1_SubstationManage", "   AND SubstationID='" + this.string_1 + "'    ");
							goto IL_37F;
						}
						catch (Exception)
						{
							goto IL_37F;
						}
						goto IL_21C;
						IL_37F:
						stringBuilder.Append(string.Concat(new object[]
						{
							"<a id=lia",
							i,
							" href='http://",
							text2,
							ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf('.')),
							"/",
							text,
							this.GetOverrideUrlName(),
							"?tag=",
							i,
							"'"
						}));
					}
					IL_21C:
					if (a == string.Empty && this.Page.Request.RawUrl.ToLower().Contains("default") && i == 0)
					{
						stringBuilder.Append(" class=\"curr\" ");
						stringBuilder.Append(" target='" + this.method_2(dataTable.Rows[i]["IfOpen"].ToString()) + "'>");
						stringBuilder.Append(dataTable.Rows[i]["Name"] + "</a>");
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
						stringBuilder.Append(" target='" + this.method_2(dataTable.Rows[i]["IfOpen"].ToString()) + "'>");
						stringBuilder.Append(dataTable.Rows[i]["Name"] + "</a>");
						stringBuilder.AppendLine("</li>");
					}
				}
				stringBuilder.AppendLine("</ul>");
				this.literal_0.Text = stringBuilder.ToString();
			}
		}
		private void method_1(string string_3)
		{
			if (this.literal_1 != null)
			{
				IShopNum1_Cart_Action shopNum1_Cart_Action = LogicFactory.CreateShopNum1_Cart_Action();
				if (!string.IsNullOrEmpty(string_3))
				{
					this.literal_1.Text = shopNum1_Cart_Action.GetMemCartCount(string_3).ToString();
				}
				else
				{
					try
					{
						string text = string.Empty;
						HttpCookie cookie = this.Page.Request.Cookies["Visitor_LoginCookie"];
						HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
						text = httpCookie.Values["MemLoginID"].ToString();
						if (!string.IsNullOrEmpty(text))
						{
							this.literal_1.Text = shopNum1_Cart_Action.GetMemCartCount(text).ToString();
						}
					}
					catch (Exception)
					{
					}
				}
			}
		}
		private void linkButton_0_Click(object sender, EventArgs e)
		{
			HttpCookie httpCookie = this.Page.Request.Cookies["MemberLoginCookie"];
			if (HttpContext.Current.Request.Cookies["MemberLoginCookie"] != null)
			{
				HttpContext.Current.Request.Cookies["MemberLoginCookie"].Expires = DateTime.Now.AddDays(-5.0);
				httpCookie.Domain = ConfigurationManager.AppSettings["CookieDomain"].ToString();
				HttpContext.Current.Response.Cookies.Add(HttpContext.Current.Request.Cookies["MemberLoginCookie"]);
			}
			string url = GetPageName.RetDomainUrl("login");
			this.Page.Response.Redirect(url);
		}
		private string method_2(string string_3)
		{
			if (string_3 == "0")
			{
				string_3 = "_self";
			}
			else if (string_3 == "1")
			{
				string_3 = "_blank";
			}
			return string_3;
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
