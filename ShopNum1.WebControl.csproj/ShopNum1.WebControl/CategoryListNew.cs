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
	public class CategoryListNew : BaseWebControl
	{
		private Repeater repeater_0;
		private string string_0 = "CategoryListNew.ascx";
		[CompilerGenerated]
		private int int_0;
		public int ShowCount
		{
			get;
			set;
		}
		public CategoryListNew()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterShow");
			this.BindData();
		}
		public void BindData()
		{
			ShopNum1_CategoryChecked_Action shopNum1_CategoryChecked_Action = (ShopNum1_CategoryChecked_Action)LogicFactory.CreateShopNum1_CategoryChecked_Action();
			DataTable categoryNewList = shopNum1_CategoryChecked_Action.GetCategoryNewList(this.ShowCount.ToString());
			this.repeater_0.DataSource = categoryNewList;
			this.repeater_0.DataBind();
		}
		public static string GetSubstr(object title, int length, bool isEllipsis)
		{
			string text = title.ToString();
			if (text.Length > length)
			{
				text = text.Substring(0, length);
			}
			if (isEllipsis)
			{
				text += "...";
			}
			return text;
		}
	}
}
