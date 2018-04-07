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
	public class ProductIsPanicBuyList : BaseWebControl
	{
		private string string_0 = "ProductIsPanicBuyList.ascx";
		private Repeater repeater_0;
		[CompilerGenerated]
		private int int_0;
		[CompilerGenerated]
		private string string_1;
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
		protected string productGuid
		{
			get;
			set;
		}
		public ProductIsPanicBuyList()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			string memloginId = (this.Page.Request.QueryString["ShopID"] == null) ? "0" : this.Page.Request.QueryString["ShopID"].ToString();
			this.productGuid = ((this.Page.Request.QueryString["guid"] == null) ? "-1" : this.Page.Request.QueryString["guid"].ToString());
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
			if (this.ShowCount < 1)
			{
				this.ShowCount = 10;
			}
			Shop_Product_Action shop_Product_Action = (Shop_Product_Action)LogicFactory.CreateShop_Product_Action();
			DataTable panicBuyList = shop_Product_Action.GetPanicBuyList(this.MemLoginID, this.ShowCount.ToString(), this.productGuid);
			this.repeater_0.DataSource = panicBuyList;
			this.repeater_0.DataBind();
		}
		public static string SetNoNull(object value)
		{
			string result;
			if (value.ToString() == "")
			{
				result = "0";
			}
			else
			{
				result = value.ToString();
			}
			return result;
		}
		public static string IsBegin(object begin, object object_0)
		{
			string result;
			if (DateTime.Parse(begin.ToString()) > DateTime.Now)
			{
				result = begin.ToString();
			}
			else
			{
				result = object_0.ToString();
			}
			return result;
		}
	}
}
