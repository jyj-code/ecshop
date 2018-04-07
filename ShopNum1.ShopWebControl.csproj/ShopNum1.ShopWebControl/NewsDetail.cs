using ShopNum1.BusinessLogic;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopWebControl
{
	[ParseChildren(true)]
	public class NewsDetail : BaseWebControl
	{
		private string string_0 = "NewsDetail.ascx";
		private Repeater repeater_0;
		private HiddenField hiddenField_0;
		[CompilerGenerated]
		private int int_0;
		[CompilerGenerated]
		private string string_1;
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
		public NewsDetail()
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
			this.hiddenField_0 = (HiddenField)skin.FindControl("HiddenFieldGuid");
			this.hiddenField_0.Value = ((this.Page.Request.QueryString["guid"] == null) ? "-1" : this.Page.Request.QueryString["guid"]);
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			if (this.Page.IsPostBack)
			{
			}
			this.method_1();
			this.method_0();
		}
		private void method_0()
		{
			try
			{
				Shop_News_Action shop_News_Action = (Shop_News_Action)LogicFactory.CreateShop_News_Action();
				shop_News_Action.UpdateClickCountByGuid(this.hiddenField_0.Value.Replace("'", ""));
			}
			catch
			{
			}
		}
		private void method_1()
		{
			Shop_News_Action shop_News_Action = (Shop_News_Action)LogicFactory.CreateShop_News_Action();
			this.repeater_0.DataSource = shop_News_Action.GetNewsByGuidAndMemLoginID(this.hiddenField_0.Value, this.MemLoginID);
			this.repeater_0.DataBind();
		}
		public static string IsShow(object object_0)
		{
			string a = object_0.ToString();
			string result;
			if (a == "0")
			{
				result = "否";
			}
			else if (a == "1")
			{
				result = "是";
			}
			else
			{
				result = "";
			}
			return result;
		}
	}
}
