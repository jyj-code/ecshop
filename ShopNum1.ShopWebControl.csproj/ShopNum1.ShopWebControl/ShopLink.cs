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
	public class ShopLink : BaseWebControl
	{
		private string string_0 = "ShopLink.ascx";
		private Repeater repeater_0;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		public string MemLoginID
		{
			get;
			set;
		}
		public string ShowCount
		{
			get;
			set;
		}
		public ShopLink()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			string memloginId = (this.Page.Request.QueryString["ShopID"] == null) ? "0" : this.Page.Request.QueryString["ShopID"].ToString();
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = new ShopNum1_ShopInfoList_Action();
			this.MemLoginID = shopNum1_ShopInfoList_Action.GetShopMemLoginIdByShopID(memloginId).ToString();
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterShow");
			if (this.Page.IsPostBack)
			{
			}
			this.method_0();
		}
		private void method_0()
		{
			if (int.Parse(this.ShowCount) > 0)
			{
				Shop_ShopLink_Action shop_ShopLink_Action = (Shop_ShopLink_Action)LogicFactory.CreateShop_ShopLink_Action();
				DataTable dataSource = shop_ShopLink_Action.Show(this.MemLoginID, this.ShowCount);
				this.repeater_0.DataSource = dataSource;
				this.repeater_0.DataBind();
			}
		}
	}
}
