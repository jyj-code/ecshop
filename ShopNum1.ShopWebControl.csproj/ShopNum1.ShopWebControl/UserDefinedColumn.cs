using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopWebControl
{
	[ParseChildren(true)]
	public class UserDefinedColumn : BaseWebControl
	{
		private string string_0 = "UserDefinedColumn.ascx";
		private Repeater repeater_0;
		private Literal literal_0;
		private Literal literal_1;
		private string string_1 = string.Empty;
		[CompilerGenerated]
		private int int_0;
		[CompilerGenerated]
		private string string_2;
		public int ShowCount
		{
			get;
			set;
		}
		public string MemLoginID
		{
			get;
			set;
		}
		public UserDefinedColumn()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.string_1 = ((this.Page.Request.QueryString["ShopID"] == null) ? "0" : this.Page.Request.QueryString["ShopID"].ToString());
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = new ShopNum1_ShopInfoList_Action();
			this.MemLoginID = shopNum1_ShopInfoList_Action.GetShopMemLoginIdByShopID(this.string_1).ToString();
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterShow");
			this.literal_0 = (Literal)skin.FindControl("LiteralMenu");
			this.literal_1 = (Literal)skin.FindControl("Literallogo");
			if (this.Page.IsPostBack)
			{
			}
			this.method_0();
			this.method_1();
		}
		private void method_0()
		{
			Shop_UserDefinedColumn_Action shop_UserDefinedColumn_Action = (Shop_UserDefinedColumn_Action)LogicFactory.CreateShop_UserDefinedColumn_Action();
			DataTable userDefinedColumnList = shop_UserDefinedColumn_Action.GetUserDefinedColumnList(this.MemLoginID, "1");
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("<ul>");
			for (int i = 0; i < userDefinedColumnList.Rows.Count; i++)
			{
				if (i < userDefinedColumnList.Rows.Count)
				{
					string url = UserDefinedColumn.GetUrl(userDefinedColumnList.Rows[i]["LinkAddress"], this.string_1);
					string text = userDefinedColumnList.Rows[i]["Name"].ToString();
					string text2 = this.ChangeIfOpen(userDefinedColumnList.Rows[i]["IfOpen"].ToString());
					string text3 = this.Page.Request.RawUrl.ToLower();
					if (text3 == "/")
					{
						text3 = "/default.aspx";
					}
					if (url.ToLower().IndexOf(text3) != -1 || (this.Page.Request.Path.ToLower() == "/default.aspx" && text == "首页"))
					{
						stringBuilder.Append(string.Concat(new string[]
						{
							"<li class=\"cur\"> <a href=\"",
							url,
							"\" target=\"",
							text2,
							"\" >",
							text,
							"</a></li>"
						}));
					}
					else
					{
						stringBuilder.Append(string.Concat(new string[]
						{
							"<li style=\"text-align:center;height:26px;line-height:26px;\" ><a href=\"",
							url,
							"\" target=\"",
							text2,
							"\" >",
							text,
							"</a></li>"
						}));
					}
				}
			}
			stringBuilder.Append("</ul>");
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
		public static string GetUrl(object object_0, string ShopID)
		{
			string result;
			if (object_0.ToString().IndexOf("http://") != -1)
			{
				result = object_0.ToString();
			}
			else
			{
				result = string.Concat(new string[]
				{
					"http://",
					HttpContext.Current.Request.Url.Host,
					"/",
					object_0.ToString().Replace(".aspx", "").Replace(".html", ""),
					ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName : ".aspx"
				});
			}
			return result;
		}
		public DataTable Top(DataTable dataTable_0, int count)
		{
			int num = (dataTable_0.Rows.Count > count) ? count : dataTable_0.Rows.Count;
			DataTable dataTable = dataTable_0.Clone();
			for (int i = 0; i < num; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				for (int j = 0; j < dataTable_0.Columns.Count; j++)
				{
					dataRow[j] = dataTable_0.Rows[i][j].ToString();
				}
				dataTable.Rows.Add(dataRow);
			}
			return dataTable;
		}
		private void method_1()
		{
			new StringBuilder();
			Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)LogicFactory.CreateShop_ShopInfo_Action();
			DataTable memLoginInfo = shop_ShopInfo_Action.GetMemLoginInfo(this.MemLoginID);
			if (memLoginInfo.Rows.Count > 0)
			{
				string text = DateTime.Parse(memLoginInfo.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
				string text2 = text.Split(new char[]
				{
					'-'
				})[0];
				string text3 = text.Split(new char[]
				{
					'-'
				})[1];
				string text4 = text.Split(new char[]
				{
					'-'
				})[2];
				new XmlDataSource();
				string path = string.Concat(new string[]
				{
					"~/Shop/Shop/",
					text2,
					"/",
					text3,
					"/",
					text4,
					"/",
					ShopSettings.GetValue("PersonShopUrl"),
					this.string_1,
					"/Site_Settings.xml"
				});
				DataSet dataSet = new DataSet();
				dataSet.ReadXml(this.Page.Server.MapPath(path));
				DataRow dataRow = dataSet.Tables["Setting"].Rows[0];
				this.literal_1.Text = string.Concat(new object[]
				{
					"<a href=\"",
					dataRow["Link"],
					"\" target=\"_blank\"><img id=\"ImageOriginalImge\" src=\"",
					dataRow["ShopScroll"],
					"\"  height=\"100\" width=\"1420\" /></a>"
				});
			}
		}
	}
}
