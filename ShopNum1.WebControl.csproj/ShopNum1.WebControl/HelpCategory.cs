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
	public class HelpCategory : BaseWebControl
	{
		private string string_0 = "HelpCategory.ascx";
		private Repeater repeater_0;
		[CompilerGenerated]
		private int int_0;
		public int ShowCount
		{
			get;
			set;
		}
		public HelpCategory()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterHelpList");
			this.repeater_0.ItemDataBound += new RepeaterItemEventHandler(this.repeater_0_ItemDataBound);
			if (this.Page.IsPostBack)
			{
			}
			this.method_0();
		}
		private void repeater_0_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			ShopNum1_Help_Action shopNum1_Help_Action = (ShopNum1_Help_Action)LogicFactory.CreateShopNum1_Help_Action();
			HiddenField hiddenField = (HiddenField)e.Item.FindControl("HiddenFieldGuid");
			DataTable dataTable = shopNum1_Help_Action.Search(hiddenField.Value, this.ShowCount, 0);
			Repeater repeater = (Repeater)e.Item.FindControl("RepeaterHelp");
			repeater.DataSource = dataTable.DefaultView;
			repeater.DataBind();
		}
		private void method_0()
		{
			ShopNum1_HelpType_Action shopNum1_HelpType_Action = (ShopNum1_HelpType_Action)LogicFactory.CreateShopNum1_HelpType_Action();
			DataTable dataTable = shopNum1_HelpType_Action.Search("0", this.ShowCount);
			this.repeater_0.DataSource = dataTable.DefaultView;
			this.repeater_0.DataBind();
		}
	}
}
