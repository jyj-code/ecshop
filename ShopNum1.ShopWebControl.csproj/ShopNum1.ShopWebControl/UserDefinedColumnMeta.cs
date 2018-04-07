using ShopNum1.BusinessLogic;
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
	public class UserDefinedColumnMeta : BaseWebControl
	{
		private string string_0 = "UserDefinedColumnMeta.ascx";
		private Literal literal_0;
		private Literal literal_1;
		private Literal literal_2;
		[CompilerGenerated]
		private string string_1;
		public string MemLoginID
		{
			get;
			set;
		}
		public UserDefinedColumnMeta()
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
			if (this.Page.IsPostBack)
			{
			}
			string memloginId = (this.Page.Request.QueryString["ShopID"] == null) ? "0" : this.Page.Request.QueryString["ShopID"].ToString();
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = new ShopNum1_ShopInfoList_Action();
			this.MemLoginID = shopNum1_ShopInfoList_Action.GetShopMemLoginIdByShopID(memloginId).ToString();
			Shop_UserDefinedColumn_Action shop_UserDefinedColumn_Action = (Shop_UserDefinedColumn_Action)LogicFactory.CreateShop_UserDefinedColumn_Action();
			DataTable dataTable = shop_UserDefinedColumn_Action.MetaGetUserDefinedColumn(this.MemLoginID, this.Page.Request.Url.AbsolutePath.Split(new char[]
			{
				'/'
			})[7].Split(new char[]
			{
				'.'
			})[0]);
			if (dataTable.Rows.Count > 0)
			{
				DataSet dataSet = new DataSet();
				dataSet.ReadXml(this.Page.Server.MapPath("~/Agent/Agent/" + dataTable.Rows[0]["AgentLoginID"].ToString() + "/Agent_Settings.xml"));
				DataRow dataRow = dataSet.Tables["Setting"].Rows[0];
				if (dataTable.Rows[0]["Title"].ToString() != string.Empty)
				{
					this.literal_0.Text = "\n<title>" + dataTable.Rows[0]["Title"].ToString() + "</title>\n";
				}
				else
				{
					this.literal_0.Text = "\n<title>" + dataTable.Rows[0]["Title"].ToString() + "</title>\n";
				}
				if (dataRow["KeyWords"].ToString() != string.Empty)
				{
					this.literal_1.Text = "<meta name=\"keywords\" content=\"" + dataRow["KeyWords"].ToString() + "\">\n";
				}
				else
				{
					this.literal_1.Text = "<meta name=\"keywords\" content=\"" + dataRow["Title"].ToString() + "\">\n";
				}
				if (dataRow["Description"].ToString() != string.Empty)
				{
					this.literal_2.Text = "<meta name=\"description\" content=\"" + dataRow["Description"].ToString() + "\">\n";
				}
				else
				{
					this.literal_2.Text = "<meta name=\"description\" content=\"" + dataRow["Title"].ToString() + "\">\n";
				}
			}
		}
	}
}
