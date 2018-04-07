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
	public class VideoCategory : BaseWebControl
	{
		public int int_0 = 0;
		private string string_0 = "VideoCategory.ascx";
		private Repeater repeater_0;
		[CompilerGenerated]
		private int int_1;
		public int ShowCount
		{
			get;
			set;
		}
		public VideoCategory()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterCategory");
			this.repeater_0.ItemDataBound += new RepeaterItemEventHandler(this.repeater_0_ItemDataBound);
			if (this.Page.IsPostBack)
			{
			}
			this.method_0();
		}
		private void repeater_0_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			Repeater repeater = (Repeater)e.Item.FindControl("RepeaterSubCategory");
			HiddenField hiddenField = (HiddenField)e.Item.FindControl("HiddenFieldID");
			ShopNum1_VideoCategory_Action shopNum1_VideoCategory_Action = (ShopNum1_VideoCategory_Action)LogicFactory.CreateShopNum1_VideoCategory_Action();
			DataTable dataTable = shopNum1_VideoCategory_Action.Search2(Convert.ToInt32(hiddenField.Value), 0);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				repeater.DataSource = dataTable.DefaultView;
				repeater.DataBind();
			}
		}
		private void method_0()
		{
			ShopNum1_VideoCategory_Action shopNum1_VideoCategory_Action = (ShopNum1_VideoCategory_Action)LogicFactory.CreateShopNum1_VideoCategory_Action();
			DataTable dataTable = shopNum1_VideoCategory_Action.Search(0, 0, this.ShowCount);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				this.repeater_0.DataSource = dataTable.DefaultView;
				this.repeater_0.DataBind();
			}
		}
	}
}
