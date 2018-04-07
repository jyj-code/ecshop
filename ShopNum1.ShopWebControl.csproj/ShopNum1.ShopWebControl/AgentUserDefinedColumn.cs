using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopWebControl
{
	[ParseChildren(true)]
	public class AgentUserDefinedColumn : BaseWebControl
	{
		private string string_0 = "AgentUserDefinedColumn.ascx";
		private Literal literal_0;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		public string IfShow
		{
			get;
			set;
		}
		public string ColumnType
		{
			get;
			set;
		}
		protected string ShopID
		{
			get;
			set;
		}
		public AgentUserDefinedColumn()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.literal_0 = (Literal)skin.FindControl("LiteralMenu");
			this.CreateNav();
		}
		public void CreateNav()
		{
			Shop_UserDefinedColumn_Action shop_UserDefinedColumn_Action = (Shop_UserDefinedColumn_Action)LogicFactory.CreateShop_UserDefinedColumn_Action();
			DataTable dataTable = shop_UserDefinedColumn_Action.SearchUserDefinedColumnList(this.IfShow, this.ColumnType);
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("<div id=\"mainNav\"><ul class=\"menuList\">");
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				if (i < dataTable.Rows.Count)
				{
					string text = this.SetUrl(dataTable.Rows[i]["LinkAddress"]);
					string text2 = dataTable.Rows[i]["Name"].ToString();
					string text3 = this.ChangeIfOpen(dataTable.Rows[i]["IfOpen"].ToString());
					if (dataTable.Rows[i]["LinkAddress"].ToString().IndexOf("://") > 0)
					{
						if (this.Page.Request.Cookies["BBsPath"] != null && (dataTable.Rows[i]["LinkAddress"].ToString().ToLower().IndexOf("bbs") > 0 || dataTable.Rows[i]["LinkAddress"].ToString().ToLower().IndexOf("www.sqpai.com") > 0))
						{
							string value = this.Page.Request.Cookies["BBsPath"].Value;
							stringBuilder.Append(string.Concat(new string[]
							{
								"<li><a href=\"",
								value,
								"\" target=\"",
								text3,
								"\">",
								text2,
								"</a></li>"
							}));
						}
						else
						{
							stringBuilder.Append(string.Concat(new object[]
							{
								"<li><a href=\"",
								dataTable.Rows[i]["LinkAddress"],
								"\" target=\"",
								text3,
								"\">",
								text2,
								"</a></li>"
							}));
						}
					}
					else
					{
						string text4 = this.Page.Request.RawUrl.ToLower().Replace(".aspx", ".html");
						if (text4 == "/")
						{
							text4 = "/default.aspx";
						}
						if (text.ToLower().IndexOf(text4) != -1 || (this.Page.Request.Path.ToLower() == "/default.aspx" && text2 == "首页"))
						{
							stringBuilder.Append(string.Concat(new string[]
							{
								"<li><a href=\"",
								text,
								"\" target=\"",
								text3,
								"\" class=\"selectStyle\">",
								text2,
								"</a></li>"
							}));
						}
						else
						{
							stringBuilder.Append(string.Concat(new string[]
							{
								"<li><a href=\"",
								text,
								"\" target=\"",
								text3,
								"\">",
								text2,
								"</a></li>"
							}));
						}
					}
				}
			}
			stringBuilder.Append("</ul></div>");
			this.literal_0.Text = stringBuilder.ToString();
		}
		public string ChangeIfOpen(string ifOpen)
		{
			string result;
			if (ifOpen == "0")
			{
				result = "_self";
			}
			else
			{
				result = "_blank";
			}
			return result;
		}
		public string SetUrl(object object_0)
		{
			return string.Concat(new string[]
			{
				"http://",
				ShopSettings.siteDomain,
				"/",
				object_0.ToString().Replace(".aspx", "").Replace(".html", ""),
				ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName : ".aspx"
			});
		}
	}
}
