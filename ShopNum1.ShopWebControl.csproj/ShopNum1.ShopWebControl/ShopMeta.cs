using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopWebControl
{
	[ParseChildren(true)]
	public class ShopMeta : BaseWebControl
	{
		private string string_0 = "ShopMeta.ascx";
		private Literal literal_0;
		private Literal literal_1;
		private Literal literal_2;
		[CompilerGenerated]
		private static string string_1;
		[CompilerGenerated]
		private string string_2;
		public static string ShopID
		{
			get;
			set;
		}
		public string MemLoginID
		{
			get;
			set;
		}
		public ShopMeta()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.literal_0 = (Literal)skin.FindControl("LiteralPageTitle");
			this.literal_1 = (Literal)skin.FindControl("LiteralPagekeywords");
			this.literal_2 = (Literal)skin.FindControl("LiteralPagedescription");
			ShopMeta.ShopID = ((this.Page.Request.QueryString["ShopID"] == null) ? "0" : this.Page.Request.QueryString["ShopID"].ToString());
			Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)LogicFactory.CreateShop_ShopInfo_Action();
			this.MemLoginID = shop_ShopInfo_Action.GetMemberLoginidByShopid(ShopMeta.ShopID).ToString();
			string text = shop_ShopInfo_Action.GetShopNameByShopid(ShopMeta.ShopID).ToString();
			Shop_ShopInfo_Action shop_ShopInfo_Action2 = (Shop_ShopInfo_Action)LogicFactory.CreateShop_ShopInfo_Action();
			DataTable shopMetaInfo = shop_ShopInfo_Action2.GetShopMetaInfo(this.MemLoginID);
			if (shopMetaInfo.Rows.Count > 0)
			{
				DataSet dataSet = new DataSet();
				dataSet.ReadXml(this.Page.Server.MapPath("~/Agent/Agent/" + shopMetaInfo.Rows[0]["AgentLoginID"].ToString() + "/Agent_Settings.xml"));
				DataRow dataRow = dataSet.Tables["Setting"].Rows[0];
				if (shopMetaInfo.Rows[0]["Title"].ToString() != string.Empty)
				{
					this.literal_0.Text = string.Concat(new string[]
					{
						"\n<title>",
						text,
						"  ",
						shopMetaInfo.Rows[0]["Title"].ToString(),
						"</title>\n"
					});
				}
				else
				{
					this.literal_0.Text = string.Concat(new string[]
					{
						"\n<title>",
						text,
						"   ",
						shopMetaInfo.Rows[0]["Title"].ToString(),
						"</title>\n"
					});
				}
				if (dataRow["KeyWords"].ToString() != string.Empty)
				{
					this.literal_1.Text = string.Concat(new string[]
					{
						"<meta name=\"keywords\" content=\"",
						text,
						"  ",
						dataRow["KeyWords"].ToString(),
						"\">\n"
					});
				}
				else
				{
					this.literal_1.Text = string.Concat(new string[]
					{
						"<meta name=\"keywords\" content=\"",
						text,
						"  ",
						dataRow["Title"].ToString(),
						"\">\n"
					});
				}
				if (dataRow["Description"].ToString() != string.Empty)
				{
					this.literal_2.Text = string.Concat(new string[]
					{
						"<meta name=\"description\" content=\"",
						text,
						"  ",
						dataRow["Description"].ToString(),
						"\">\n"
					});
				}
				else
				{
					this.literal_2.Text = string.Concat(new string[]
					{
						"<meta name=\"description\" content=\"",
						text,
						"  ",
						dataRow["Title"].ToString(),
						"\">\n"
					});
				}
			}
		}
	}
}
