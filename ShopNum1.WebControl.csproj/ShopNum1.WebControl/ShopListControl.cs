using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class ShopListControl : BaseWebControl
	{
		private string string_0 = "ShopListControl.ascx";
		private Label label_0;
		private Repeater repeater_0;
		private string string_1 = "all";
		[CompilerGenerated]
		private int int_0;
		[CompilerGenerated]
		private int int_1;
		[CompilerGenerated]
		private int int_2;
		public int ShopType
		{
			get;
			set;
		}
		public int ShowCount
		{
			get;
			set;
		}
		public int IsSub
		{
			get;
			set;
		}
		public ShopListControl()
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
			this.label_0 = (Label)skin.FindControl("LabelShopType");
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			if (this.ShowCount < 0)
			{
				this.ShowCount = 3;
			}
			this.BindData();
			if (this.Page.IsPostBack)
			{
			}
		}
		protected void BindData()
		{
			Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)LogicFactory.CreateShop_ShopInfo_Action();
			DataTable dataSource = new DataTable();
			switch (this.ShopType)
			{
			case 1:
				this.label_0.Text = "推荐商家";
				dataSource = shop_ShopInfo_Action.GetShopIsrecom(this.ShowCount);
				this.repeater_0.DataSource = dataSource;
				this.repeater_0.DataBind();
				break;
			case 2:
				this.label_0.Text = "最新入驻商家";
				if (this.IsSub == 0)
				{
					dataSource = shop_ShopInfo_Action.GetShopByOpenTime(this.ShowCount);
				}
				else
				{
					dataSource = shop_ShopInfo_Action.GetShopByOpenTime(this.ShowCount, this.string_1);
				}
				this.repeater_0.DataSource = dataSource;
				this.repeater_0.DataBind();
				break;
			case 3:
				this.label_0.Text = "热门商家";
				dataSource = shop_ShopInfo_Action.GetShopHot(this.ShowCount);
				this.repeater_0.DataSource = dataSource;
				this.repeater_0.DataBind();
				break;
			default:
				this.label_0.Text = "推荐商家";
				dataSource = shop_ShopInfo_Action.GetShopIsrecom(this.ShowCount);
				this.repeater_0.DataSource = dataSource;
				this.repeater_0.DataBind();
				break;
			}
		}
	}
}
