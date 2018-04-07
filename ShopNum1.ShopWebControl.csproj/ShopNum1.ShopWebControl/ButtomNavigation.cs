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
	public class ButtomNavigation : BaseWebControl
	{
		private string string_0 = "ButtomNavigation.ascx";
		private Repeater repeater_0;
		[CompilerGenerated]
		private string string_1;
		public string ShowCount
		{
			get;
			set;
		}
		public ButtomNavigation()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			if (this.Page.IsPostBack)
			{
			}
			this.method_0();
			if (this.repeater_0.Items.Count >= 1)
			{
				this.repeater_0.Items[this.repeater_0.Items.Count - 1].FindControl("LabelSpilt").Visible = false;
			}
		}
		private void method_0()
		{
			Shop_UserDefinedColumn_Action shop_UserDefinedColumn_Action = (Shop_UserDefinedColumn_Action)LogicFactory.CreateShop_UserDefinedColumn_Action();
			DataTable buttomNavigation = shop_UserDefinedColumn_Action.GetButtomNavigation(this.ShowCount);
			if (buttomNavigation != null && buttomNavigation.Rows.Count > 0)
			{
				this.repeater_0.DataSource = buttomNavigation.DefaultView;
				this.repeater_0.DataBind();
			}
		}
		public static string ShowIsOpen(string ifOpen)
		{
			if (ifOpen == "0")
			{
				ifOpen = "_self";
			}
			else if (ifOpen == "1")
			{
				ifOpen = "_blank";
			}
			return ifOpen;
		}
	}
}
