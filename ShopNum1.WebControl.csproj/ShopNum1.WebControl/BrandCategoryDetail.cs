using ShopNum1.BusinessLogic;
using ShopNum1.Common;
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
	public class BrandCategoryDetail : BaseWebControl
	{
		private string string_0 = "BrandCategoryDetail.ascx";
		private Label label_0;
		private Repeater repeater_0;
		private Label label_1;
		private HyperLink hyperLink_0;
		private HyperLink hyperLink_1;
		private HyperLink hyperLink_2;
		private HyperLink hyperLink_3;
		private Literal literal_0;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		public string code
		{
			get;
			set;
		}
		public string PageCount
		{
			get;
			set;
		}
		public BrandCategoryDetail()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.label_0 = (Label)skin.FindControl("LabelCategory");
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterBrand");
			this.hyperLink_0 = (HyperLink)skin.FindControl("lnkPrev");
			this.hyperLink_1 = (HyperLink)skin.FindControl("lnkFirst");
			this.hyperLink_2 = (HyperLink)skin.FindControl("lnkNext");
			this.hyperLink_3 = (HyperLink)skin.FindControl("lnkLast");
			this.label_1 = (Label)skin.FindControl("LabelPageMessage");
			this.literal_0 = (Literal)skin.FindControl("lnkTo");
			if (this.Page.IsPostBack)
			{
			}
			this.code = ((ShopNum1.Common.Common.ReqStr("code") == null) ? "-1" : ShopNum1.Common.Common.ReqStr("code"));
			this.method_0();
		}
		private void method_0()
		{
			ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
			DataTable productCategoryCode = shopNum1_ProductCategory_Action.GetProductCategoryCode(this.code);
			if (productCategoryCode.Rows.Count == 1)
			{
				this.label_0.Text = productCategoryCode.Rows[0]["Name"].ToString();
			}
			else if (productCategoryCode.Rows.Count > 1)
			{
				this.label_0.Text = "全部";
			}
			else
			{
				this.label_0.Text = "";
			}
			ShopNum1_Brand_Action shopNum1_Brand_Action = (ShopNum1_Brand_Action)LogicFactory.CreateShopNum1_Brand_Action();
			DataTable productBrand = shopNum1_Brand_Action.GetProductBrand(this.code);
			if (productBrand.Rows.Count >= 0 && productBrand != null)
			{
				PagedDataSource pagedDataSource = new PagedDataSource();
				pagedDataSource.DataSource = productBrand.DefaultView;
				pagedDataSource.AllowPaging = true;
				pagedDataSource.PageSize = Convert.ToInt32(this.PageCount);
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
				Num1WebControlCommon num1WebControlCommon = new Num1WebControlCommon();
				this.label_1.Text = num1WebControlCommon.GetPageMessage(pagedDataSource.DataSourceCount, pagedDataSource.PageCount, pagedDataSource.PageSize, num);
				this.literal_0.Text = num1WebControlCommon.AppendPage2(this.Page, pagedDataSource.PageCount, num, "&code=" + this.code);
				this.hyperLink_0.NavigateUrl = GetPageName.GetPage(string.Concat(new object[]
				{
					"?Page=",
					Convert.ToInt32(num - 1),
					"&code=",
					this.code
				}));
				this.hyperLink_1.NavigateUrl = GetPageName.GetPage("?Page=1&code=" + this.code);
				this.hyperLink_2.NavigateUrl = GetPageName.GetPage(string.Concat(new object[]
				{
					"?Page=",
					Convert.ToInt32(num + 1),
					"&code=",
					this.code
				}));
				this.hyperLink_3.NavigateUrl = GetPageName.GetPage(string.Concat(new object[]
				{
					"?Page=",
					pagedDataSource.PageCount,
					"&code=",
					this.code
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
}
