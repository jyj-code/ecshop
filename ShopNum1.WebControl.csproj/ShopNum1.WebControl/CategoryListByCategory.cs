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
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class CategoryListByCategory : BaseWebControl
	{
		private string string_0 = "CategoryListByCategory.ascx";
		private HtmlAnchor htmlAnchor_0;
		private Repeater repeater_0;
		private Literal literal_0;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		public string ShowCount
		{
			get;
			set;
		}
		public string CategoryCode
		{
			get;
			set;
		}
		public string Titel
		{
			get;
			set;
		}
		public CategoryListByCategory()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.htmlAnchor_0 = (HtmlAnchor)skin.FindControl("Href");
			this.literal_0 = (Literal)skin.FindControl("LiteralTitel");
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterSupplyFirst");
			if (!string.IsNullOrEmpty(this.CategoryCode))
			{
				this.htmlAnchor_0.HRef = GetPageName.RetUrl("CategoryListSearch", this.CategoryCode, "code");
			}
			else
			{
				this.htmlAnchor_0.HRef = GetPageName.RetUrl("CategoryListSearch");
			}
			this.BindData();
		}
		protected void BindData()
		{
			this.literal_0.Text = this.Titel;
			ShopNum1_CategoryChecked_Action shopNum1_CategoryChecked_Action = (ShopNum1_CategoryChecked_Action)LogicFactory.CreateShopNum1_CategoryChecked_Action();
			DataTable dataTable = shopNum1_CategoryChecked_Action.SearchByCategoryIDFrist(this.CategoryCode);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				this.repeater_0.DataSource = dataTable.DefaultView;
				this.repeater_0.DataBind();
				foreach (RepeaterItem repeaterItem in this.repeater_0.Items)
				{
					HiddenField hiddenField = (HiddenField)repeaterItem.FindControl("HiddenFieldGuid");
					Repeater repeater = (Repeater)repeaterItem.FindControl("RepeaterData");
					DataTable dataTable2 = shopNum1_CategoryChecked_Action.SearchByCategoryIDOther(this.CategoryCode, hiddenField.Value, this.ShowCount.ToString());
					if (dataTable2.Rows.Count > 0)
					{
						repeater.DataSource = dataTable2.DefaultView;
						repeater.DataBind();
					}
				}
			}
		}
	}
}
