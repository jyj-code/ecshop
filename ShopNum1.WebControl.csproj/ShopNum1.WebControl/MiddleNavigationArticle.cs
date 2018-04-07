using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class MiddleNavigationArticle : BaseWebControl
	{
		private string string_0 = "MiddleNavigationArticle.ascx";
		private Literal literal_0;
		private string string_1 = "all";
		[CompilerGenerated]
		private string string_2;
		public string ShowCount
		{
			get;
			set;
		}
		public MiddleNavigationArticle()
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
			this.method_0();
		}
		private void method_0()
		{
			ShopNum1_ArticleCategory_Action shopNum1_ArticleCategory_Action = (ShopNum1_ArticleCategory_Action)LogicFactory.CreateShopNum1_ArticleCategory_Action();
			DataTable dataTable = shopNum1_ArticleCategory_Action.SearchByFatherID("0", this.ShowCount, "0");
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
					string text = dataTable.Rows[i]["ID"].ToString();
					if (this.string_1 == "all")
					{
						stringBuilder.Append(string.Concat(new object[]
						{
							"<a  href='http://",
							ShopSettings.siteDomain,
							"/ArticleListSearch",
							this.GetOverrideUrlName(),
							"?tag=",
							i,
							"&guid=",
							text,
							"&Category=",
							dataTable.Rows[i]["Name"],
							"'"
						}));
					}
					else
					{
						string text2 = string.Empty;
						try
						{
							text2 = ShopNum1.Common.Common.GetNameById("DomainName", "ShopNum1_SubstationManage", "   AND SubstationID='" + this.string_1 + "'    ");
							goto IL_209;
						}
						catch (Exception)
						{
							goto IL_209;
						}
						goto IL_19F;
						IL_209:
						stringBuilder.Append(string.Concat(new object[]
						{
							"<a  href='http://",
							text2,
							ShopSettings.siteDomain.Substring(3),
							"/ArticleListSearch",
							this.GetOverrideUrlName(),
							"?tag=",
							i,
							"&guid=",
							text,
							"&Category=",
							dataTable.Rows[i]["Name"],
							"'"
						}));
					}
					IL_19F:
					if (a == i.ToString())
					{
						stringBuilder.Append(" style='background:url(Themes/Skin_Default/Images/navbg2.gif) no-repeat center;color:#FFFFFF;' ");
					}
					stringBuilder.Append(">");
					stringBuilder.Append(dataTable.Rows[i]["Name"] + "</a>");
					stringBuilder.AppendLine("</li>");
				}
				stringBuilder.AppendLine("</ul>");
				this.literal_0.Text = stringBuilder.ToString();
			}
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
