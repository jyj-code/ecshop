using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class ShopAgentMallCategory : BaseWebControl
	{
		private string string_0 = "ShopAgentMall.ascx";
		private Repeater repeater_0;
		private string string_1 = "";
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		[CompilerGenerated]
		private string string_4;
		[CompilerGenerated]
		private string string_5;
		[CompilerGenerated]
		private string string_6;
		public string ShowCount
		{
			get;
			set;
		}
		public string ShopCategoryID
		{
			get;
			set;
		}
		public string IsRecommend
		{
			get;
			set;
		}
		public string OrderWord
		{
			get;
			set;
		}
		public string OrderType
		{
			get;
			set;
		}
		public ShopAgentMallCategory()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			if (this.Page.Request.QueryString["SubstationID"] != null && !string.IsNullOrEmpty(this.Page.Request.QueryString["SubstationID"].ToString()))
			{
				this.string_1 = this.Page.Request.QueryString["SubstationID"].ToString();
			}
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterShopByType");
			if (!this.Page.IsPostBack)
			{
			}
			try
			{
				this.method_0();
			}
			catch
			{
			}
		}
		private void method_0()
		{
			if (string.IsNullOrEmpty(this.IsRecommend))
			{
				this.IsRecommend = "-1";
			}
			if (string.IsNullOrEmpty(this.ShowCount))
			{
				this.ShowCount = "10";
			}
			if (string.IsNullOrEmpty(this.OrderWord))
			{
				this.OrderWord = "OrderID";
			}
			if (string.IsNullOrEmpty(this.OrderType))
			{
				this.OrderType = "DESC";
			}
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
			DataTable allShopList = shopNum1_ShopInfoList_Action.GetAllShopList(this.ShopCategoryID, this.string_1, Convert.ToInt32(this.ShowCount), Convert.ToInt32(this.IsRecommend), this.OrderWord, this.OrderType);
			try
			{
				if (allShopList.Rows.Count > 0 && allShopList != null)
				{
					this.repeater_0.DataSource = allShopList.DefaultView;
					this.repeater_0.DataBind();
				}
			}
			catch
			{
			}
		}
	}
}
