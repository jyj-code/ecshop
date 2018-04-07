using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class ProductSubCategory : BaseWebControl
	{
		private string string_0 = "all";
		private string string_1 = "ProductSubCategory.ascx";
		private Repeater repeater_0;
		private Literal literal_0;
		private string string_2 = "0";
		private int int_0 = 0;
		private string string_3;
		public string ShowCount
		{
			get
			{
				return this.string_2;
			}
			set
			{
				this.string_2 = value;
			}
		}
		public int CategoryID
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_0 = value;
			}
		}
		public string NewCategoryID
		{
			get
			{
				return this.string_3;
			}
			set
			{
				this.string_3 = value;
			}
		}
		public ProductSubCategory()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_1;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			if (this.Page.Request.QueryString["SubstationID"] != null && !string.IsNullOrEmpty(this.Page.Request.QueryString["SubstationID"].ToString()))
			{
				this.string_0 = this.Page.Request.QueryString["SubstationID"].ToString();
			}
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterDataWenzi");
			this.literal_0 = (Literal)skin.FindControl("moreView_1");
			if (this.Page.IsPostBack)
			{
			}
			this.method_0();
		}
		private void method_0()
		{
			ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
			shopNum1_ProductCategory_Action.TableName = "ShopNum1_ProductCategory";
			DataTable dataTable = shopNum1_ProductCategory_Action.Search(this.CategoryID, 0, this.string_2);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				this.repeater_0.DataSource = dataTable;
				this.repeater_0.DataBind();
			}
			if (this.string_0 == "all")
			{
				this.literal_0.Text = string.Concat(new string[]
				{
					"<a href=\"http://",
					this.Page.Request.Url.Host,
					"/Search_productlist.html?code=",
					this.NewCategoryID,
					"\" target=\"_blank\" class=\"fmore\">更多</a>"
				});
			}
			else
			{
				try
				{
					ShopNum1.Common.Common.GetNameById("DomainName", "ShopNum1_SubstationManage", "   AND SubstationID='" + this.string_0 + "'    ");
				}
				catch (Exception)
				{
				}
				this.literal_0.Text = string.Concat(new string[]
				{
					"<a href=\"http://",
					this.Page.Request.Url.Host,
					"/Search_productlist.html?code=",
					this.NewCategoryID,
					"\" target=\"_blank\" class=\"fmore\">更多</a>"
				});
			}
		}
	}
}
