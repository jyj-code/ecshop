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
	public class ProductIsPanicMeta : BaseWebControl
	{
		private string string_0 = "ProductIsPanicMeta.ascx";
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
		public ProductIsPanicMeta()
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
			Shop_Product_Action shop_Product_Action = (Shop_Product_Action)LogicFactory.CreateShop_Product_Action();
			string memloginId = (this.Page.Request.QueryString["ShopID"] == null) ? "0" : this.Page.Request.QueryString["ShopID"].ToString();
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = new ShopNum1_ShopInfoList_Action();
			this.MemLoginID = shopNum1_ShopInfoList_Action.GetShopMemLoginIdByShopID(memloginId).ToString();
			string guid = (this.Page.Request.QueryString["guid"] == null) ? "-1" : this.Page.Request.QueryString["guid"];
			DataTable panicInfoMeta = shop_Product_Action.GetPanicInfoMeta(this.MemLoginID, guid);
			if (panicInfoMeta.Rows.Count > 0)
			{
				if (!string.IsNullOrEmpty(panicInfoMeta.Rows[0]["Title"].ToString()))
				{
					this.literal_0.Text = "\n<title>" + panicInfoMeta.Rows[0]["Title"].ToString() + "</title>\n";
				}
				else
				{
					this.literal_0.Text = "\n<title>" + panicInfoMeta.Rows[0]["Title"].ToString() + "</title>\n";
				}
				if (!string.IsNullOrEmpty(panicInfoMeta.Rows[0]["KeyWords"].ToString()))
				{
					this.literal_1.Text = "<meta name=\"keywords\" content=\"" + panicInfoMeta.Rows[0]["KeyWords"].ToString() + "\">\n";
				}
				else
				{
					this.literal_1.Text = "<meta name=\"keywords\" content=\"" + panicInfoMeta.Rows[0]["Title"].ToString() + "\">\n";
				}
				if (!string.IsNullOrEmpty(panicInfoMeta.Rows[0]["Description"].ToString()))
				{
					this.literal_2.Text = "<meta name=\"description\" content=\"" + panicInfoMeta.Rows[0]["Description"].ToString() + "\">\n";
				}
				else
				{
					this.literal_2.Text = "<meta name=\"description\" content=\"" + panicInfoMeta.Rows[0]["Title"].ToString() + "\">\n";
				}
			}
		}
	}
}
