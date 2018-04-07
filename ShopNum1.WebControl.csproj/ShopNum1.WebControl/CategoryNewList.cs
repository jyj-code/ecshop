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
	public class CategoryNewList : BaseWebControl
	{
		private string string_0 = "CategoryNewList.ascx";
		private Repeater repeater_0;
		[CompilerGenerated]
		private string string_1;
		public string showCount
		{
			get;
			set;
		}
		public CategoryNewList()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			this.BindData();
		}
		protected void BindData()
		{
			ShopNum1_CategoryChecked_Action shopNum1_CategoryChecked_Action = (ShopNum1_CategoryChecked_Action)LogicFactory.CreateShopNum1_CategoryChecked_Action();
			DataTable categoryNewList = shopNum1_CategoryChecked_Action.GetCategoryNewList(this.showCount);
			if (categoryNewList != null && categoryNewList.Rows.Count > 0)
			{
				this.repeater_0.DataSource = categoryNewList.DefaultView;
				this.repeater_0.DataBind();
			}
		}
	}
}
