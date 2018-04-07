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
	public class CategoryAllCategory : BaseWebControl
	{
		private string string_0 = "CategoryAllCategory.ascx";
		private Repeater repeater_0;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		public string Guid
		{
			get;
			set;
		}
		public string ShowCountOne
		{
			get;
			set;
		}
		public string ShowCountTwo
		{
			get;
			set;
		}
		public CategoryAllCategory()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			this.repeater_0.ItemDataBound += new RepeaterItemEventHandler(this.repeater_0_ItemDataBound);
			if (this.Page.IsPostBack)
			{
			}
			this.Guid = ((ShopNum1.Common.Common.ReqStr("guid") == "") ? "0" : ShopNum1.Common.Common.ReqStr("guid"));
			this.method_0();
		}
		private void repeater_0_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				Repeater repeater = (Repeater)e.Item.FindControl("RepeaterData2");
				HiddenField hiddenField = (HiddenField)e.Item.FindControl("HiddenFieldID");
				ShopNum1_CategoryChecked_Action shopNum1_CategoryChecked_Action = (ShopNum1_CategoryChecked_Action)LogicFactory.CreateShopNum1_CategoryChecked_Action();
				DataTable dataTable = shopNum1_CategoryChecked_Action.Search(Convert.ToInt32(hiddenField.Value), 0, this.ShowCountTwo);
				if (dataTable != null && dataTable.Rows.Count > 0)
				{
					repeater.DataSource = dataTable.DefaultView;
					repeater.DataBind();
				}
			}
		}
		private void method_0()
		{
			ShopNum1_CategoryChecked_Action shopNum1_CategoryChecked_Action = (ShopNum1_CategoryChecked_Action)LogicFactory.CreateShopNum1_CategoryChecked_Action();
			DataTable dataTable = shopNum1_CategoryChecked_Action.Search(0, 0, this.ShowCountOne);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				this.repeater_0.DataSource = dataTable.DefaultView;
				this.repeater_0.DataBind();
			}
		}
	}
}
