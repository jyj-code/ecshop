using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_Limit_AddProduct : BaseShopWebControl
	{
		private string string_0 = "S_Limit_AddProduct.ascx";
		private Label label_0;
		private Label label_1;
		private Label label_2;
		private Label label_3;
		private Label label_4;
		private Label label_5;
		private Label label_6;
		private HtmlGenericControl htmlGenericControl_0;
		public static DataTable dt_LimitProduct = null;
		private Shop_LimtProduct_Action shop_LimtProduct_Action_0 = new Shop_LimtProduct_Action();
		[CompilerGenerated]
		private int int_0;
		public int PageSize
		{
			get;
			set;
		}
		public S_Limit_AddProduct()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.label_0 = (Label)skin.FindControl("lblName");
			this.label_1 = (Label)skin.FindControl("lblStartName");
			this.label_2 = (Label)skin.FindControl("lblEndTime");
			this.label_3 = (Label)skin.FindControl("lblState");
			this.label_4 = (Label)skin.FindControl("lblDisCount");
			this.label_5 = (Label)skin.FindControl("lblLimitPcount");
			this.label_6 = (Label)skin.FindControl("lblSelectProduct");
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("pageDiv");
			if (!this.Page.IsPostBack)
			{
				this.method_0();
				this.method_2();
			}
		}
		private void method_0()
		{
			if (ShopNum1.Common.Common.ReqStr("lid") != "")
			{
				ShopNum1_Activity_Action shopNum1_Activity_Action = (ShopNum1_Activity_Action)LogicFactory.CreateShopNum1_Activity_Action();
				DataTable activityById = shopNum1_Activity_Action.GetActivityById(this.MemLoginID, ShopNum1.Common.Common.ReqStr("lid"));
				if (activityById.Rows.Count > 0)
				{
					this.label_0.Text = activityById.Rows[0]["name"].ToString();
					this.label_1.Text = activityById.Rows[0]["s"].ToString();
					this.label_2.Text = activityById.Rows[0]["e"].ToString();
					this.label_3.Text = this.method_1(activityById.Rows[0]["state"].ToString());
					if (Convert.ToDateTime(this.label_2.Text) < DateTime.Now)
					{
						this.label_3.Text = "已结束";
					}
					this.label_4.Text = activityById.Rows[0]["discount"].ToString();
					this.label_5.Text = activityById.Rows[0]["limitProduct"].ToString();
					this.label_6.Text = activityById.Rows[0]["pc"].ToString();
				}
			}
		}
		private string method_1(string string_1)
		{
			string result;
			if (string_1 != null)
			{
				if (string_1 == "0")
				{
					result = "未发布";
					return result;
				}
				if (string_1 == "1")
				{
					result = "已发布";
					return result;
				}
				if (string_1 == "2")
				{
					result = "已取消";
					return result;
				}
			}
			result = "";
			return result;
		}
		private void method_2()
		{
			string condition = " and memloginid='" + this.MemLoginID + "' and ProductState=0 And guid not in(select productguid from ShopNum1_Group_Product where state=1)";
			int pageID = 1;
			if (ShopNum1.Common.Common.ReqStr("pageid") != "")
			{
				pageID = Convert.ToInt32(ShopNum1.Common.Common.ReqStr("pageid"));
			}
			DataTable limtProdcut = this.shop_LimtProduct_Action_0.GetLimtProdcut(this.PageSize.ToString(), pageID.ToString(), condition, "3", ShopNum1.Common.Common.ReqStr("lid"));
			int recordCount = Convert.ToInt32(limtProdcut.Rows[0][0]);
			PageListBll pageListBll = new PageListBll("shop/ShopAdmin/S_Limit_AddProduct.aspx", true);
			PageList1 pageList = new PageList1();
			pageList.PageSize = this.PageSize;
			pageList.PageID = pageID;
			pageList.RecordCount = recordCount;
			this.htmlGenericControl_0.InnerHtml = pageListBll.GetPageListNew(pageList);
			S_Limit_AddProduct.dt_LimitProduct = this.shop_LimtProduct_Action_0.GetLimtProdcut(this.PageSize.ToString(), pageID.ToString(), condition, "2", ShopNum1.Common.Common.ReqStr("lid"));
			if (S_Limit_AddProduct.dt_LimitProduct.Rows.Count == 0)
			{
				S_Limit_AddProduct.dt_LimitProduct = null;
			}
		}
	}
}
