using ShopNum1.BusinessLogic;
using ShopNum1.Common;
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
	public class ProductConsultList : BaseWebControl
	{
		private string string_0 = "ProductConsultList.ascx";
		private Repeater repeater_0;
		private Label label_0;
		private HyperLink hyperLink_0;
		private HyperLink hyperLink_1;
		private HyperLink hyperLink_2;
		private HyperLink hyperLink_3;
		private Literal literal_0;
		private string string_1 = string.Empty;
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		protected string ShopID
		{
			get;
			set;
		}
		public string ShowCount
		{
			get;
			set;
		}
		public ProductConsultList()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.ShopID = ((this.Page.Request.QueryString["ShopID"] == null) ? "0" : this.Page.Request.QueryString["ShopID"]);
			this.hyperLink_0 = (HyperLink)skin.FindControl("lnkPrev");
			this.hyperLink_1 = (HyperLink)skin.FindControl("lnkFirst");
			this.hyperLink_2 = (HyperLink)skin.FindControl("lnkNext");
			this.hyperLink_3 = (HyperLink)skin.FindControl("lnkLast");
			this.label_0 = (Label)skin.FindControl("LabelPageMessage");
			this.literal_0 = (Literal)skin.FindControl("lnkTo");
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterProductConsultList");
			this.string_1 = ((this.Page.Request.QueryString["guid"] == null) ? "0" : this.Page.Request.QueryString["guid"]);
			this.method_0();
			if (this.Page.IsPostBack)
			{
			}
		}
		private void method_0()
		{
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = new ShopNum1_ShopInfoList_Action();
			string shopID = shopNum1_ShopInfoList_Action.GetShopMemLoginIdByShopID(this.ShopID).ToString();
			Shop_ProductConsult_Action shop_ProductConsult_Action = (Shop_ProductConsult_Action)LogicFactory.CreateShop_ProductConsult_Action();
			DataTable dataTable = shop_ProductConsult_Action.Search(this.string_1, 0, 1, shopID);
			PagedDataSource pagedDataSource = new PagedDataSource();
			pagedDataSource.DataSource = dataTable.DefaultView;
			pagedDataSource.AllowPaging = true;
			pagedDataSource.PageSize = Convert.ToInt32(this.ShowCount);
			int num;
			if (this.Page.Request.QueryString.Get("page") != null)
			{
				num = Convert.ToInt32(this.Page.Request.QueryString.Get("page"));
			}
			else
			{
				num = 1;
			}
			int num2;
			if (this.Page.Request.QueryString.Get("page1") != null)
			{
				num2 = Convert.ToInt32(this.Page.Request.QueryString.Get("page1"));
			}
			else
			{
				num2 = 1;
			}
			pagedDataSource.CurrentPageIndex = num - 1;
			Num1WebControlCommon num1WebControlCommon = new Num1WebControlCommon();
			this.label_0.Text = num1WebControlCommon.GetPageMessage(pagedDataSource.DataSourceCount, pagedDataSource.PageCount, pagedDataSource.PageSize, num);
			this.literal_0.Text = num1WebControlCommon.AppendPage(this.Page, pagedDataSource.PageCount, num, string.Concat(new object[]
			{
				"&&Guid=",
				this.Page.Request.QueryString["Guid"],
				"&&Page1=",
				num2
			}));
			this.hyperLink_0.NavigateUrl = GetPageName.AgentGetPage(string.Concat(new object[]
			{
				"?Page=",
				Convert.ToInt32(num - 1),
				"&&Guid=",
				this.Page.Request.QueryString["Guid"],
				"&&Page1=",
				num2
			}));
			this.hyperLink_1.NavigateUrl = GetPageName.AgentGetPage(string.Concat(new object[]
			{
				"?Page=1&&Guid=",
				this.Page.Request.QueryString["Guid"],
				"&&Page1=",
				num2
			}));
			this.hyperLink_2.NavigateUrl = GetPageName.AgentGetPage(string.Concat(new object[]
			{
				"?Page=",
				Convert.ToInt32(num + 1),
				"&&Guid=",
				this.Page.Request.QueryString["Guid"],
				"&&Page1=",
				num2
			}));
			this.hyperLink_3.NavigateUrl = GetPageName.AgentGetPage(string.Concat(new object[]
			{
				"?Page=",
				pagedDataSource.PageCount,
				"&&Guid=",
				this.Page.Request.QueryString["Guid"],
				"&&Page1=",
				num2
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
			this.repeater_0.DataSource = pagedDataSource;
			this.repeater_0.DataBind();
		}
	}
}
