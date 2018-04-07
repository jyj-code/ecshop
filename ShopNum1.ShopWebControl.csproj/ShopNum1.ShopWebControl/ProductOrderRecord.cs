using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopWebControl
{
	[ParseChildren(true)]
	public class ProductOrderRecord : BaseWebControl
	{
		private string string_0 = "ProductOrderRecord.ascx";
		private Repeater repeater_0;
		private HtmlGenericControl htmlGenericControl_0;
		private Label label_0;
		private HyperLink hyperLink_0;
		private HyperLink hyperLink_1;
		private HyperLink hyperLink_2;
		private HyperLink hyperLink_3;
		private Literal literal_0;
		[CompilerGenerated]
		private int int_0;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		public int PageCount
		{
			get;
			set;
		}
		public string ProductGuid
		{
			get;
			set;
		}
		public string MemLoginID
		{
			get;
			set;
		}
		public ProductOrderRecord()
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
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("spanOrderCount");
			this.hyperLink_0 = (HyperLink)skin.FindControl("lnkPrev");
			this.hyperLink_1 = (HyperLink)skin.FindControl("lnkFirst");
			this.hyperLink_2 = (HyperLink)skin.FindControl("lnkNext");
			this.hyperLink_3 = (HyperLink)skin.FindControl("lnkLast");
			this.label_0 = (Label)skin.FindControl("LabelPageMessage");
			this.literal_0 = (Literal)skin.FindControl("lnkTo");
			if (this.Page.IsPostBack)
			{
			}
			this.ProductGuid = ((this.Page.Request.QueryString["guid"] == null) ? "0" : this.Page.Request.QueryString["guid"].ToString());
			this.method_0();
		}
		private void method_0()
		{
			ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
			DataSet dataSet = shopNum1_OrderInfo_Action.SearchProductOrderRecord(this.ProductGuid, "-1");
			if (dataSet != null && dataSet.Tables.Count == 2)
			{
				this.htmlGenericControl_0.InnerHtml = "共" + dataSet.Tables[1].Rows[0]["allNum"].ToString() + "条订单记录";
				PagedDataSource pagedDataSource = new PagedDataSource();
				pagedDataSource.DataSource = dataSet.Tables[0].DefaultView;
				pagedDataSource.AllowPaging = true;
				pagedDataSource.PageSize = this.PageCount;
				int num;
				if (this.Page.Request.QueryString.Get("page") != null)
				{
					num = Convert.ToInt32(this.Page.Request.QueryString.Get("page"));
				}
				else
				{
					num = 1;
				}
				pagedDataSource.CurrentPageIndex = num - 1;
				this.repeater_0.DataSource = pagedDataSource;
				this.repeater_0.DataBind();
				Num1WebControlCommon num1WebControlCommon = new Num1WebControlCommon();
				this.label_0.Text = num1WebControlCommon.GetPageMessage(pagedDataSource.DataSourceCount, pagedDataSource.PageCount, pagedDataSource.PageSize, num);
				this.literal_0.Text = num1WebControlCommon.AppendPage(this.Page, pagedDataSource.PageCount, num);
				this.ProductGuid = ((this.Page.Request.QueryString["guid"] == null) ? "0" : this.Page.Request.QueryString["guid"].ToString());
				this.hyperLink_0.NavigateUrl = GetPageName.GetPage(string.Concat(new object[]
				{
					"?Page=",
					Convert.ToInt32(num - 1),
					"&guid=",
					this.ProductGuid
				}));
				this.hyperLink_1.NavigateUrl = GetPageName.GetPage("?Page=1&guid=" + this.ProductGuid);
				this.hyperLink_2.NavigateUrl = GetPageName.GetPage(string.Concat(new object[]
				{
					"?Page=",
					Convert.ToInt32(num + 1),
					"&guid=",
					this.ProductGuid
				}));
				this.hyperLink_3.NavigateUrl = GetPageName.GetPage(string.Concat(new object[]
				{
					"?Page=",
					pagedDataSource.PageCount,
					"&guid=",
					this.ProductGuid
				}));
				if (num <= 1 && pagedDataSource.PageCount <= 1)
				{
					this.hyperLink_1.NavigateUrl = "";
					this.hyperLink_0.NavigateUrl = "";
					this.hyperLink_2.NavigateUrl = "";
					this.hyperLink_3.NavigateUrl = "";
				}
				if (num <= 1 && pagedDataSource.PageCount > 1)
				{
					this.hyperLink_1.NavigateUrl = "";
					this.hyperLink_0.NavigateUrl = "";
				}
				if (num >= pagedDataSource.PageCount)
				{
					this.hyperLink_2.NavigateUrl = "";
					this.hyperLink_3.NavigateUrl = "";
				}
			}
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
		public static string ChangeOperateType(string operateType)
		{
			string result;
			if (operateType == "0")
			{
				result = "未付款";
			}
			else if (operateType == "1")
			{
				result = "已付款";
			}
			else
			{
				result = "";
			}
			return result;
		}
	}
}
