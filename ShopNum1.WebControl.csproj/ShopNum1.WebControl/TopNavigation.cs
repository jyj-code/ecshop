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
	public class TopNavigation : BaseWebControl
	{
		private string string_0 = "TopNavigation.ascx";
		private Repeater repeater_0;
		[CompilerGenerated]
		private string string_1;
		public string ShowCount
		{
			get;
			set;
		}
		public TopNavigation()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			if (this.Page.IsPostBack)
			{
			}
			this.method_0();
		}
		private void method_0()
		{
			ShopNum1_UserDefinedColumn_Action shopNum1_UserDefinedColumn_Action = (ShopNum1_UserDefinedColumn_Action)LogicFactory.CreateShopNum1_UserDefinedColumn_Action();
			DataTable topNavigation = shopNum1_UserDefinedColumn_Action.GetTopNavigation(this.ShowCount);
			this.repeater_0.DataSource = topNavigation.DefaultView;
			this.repeater_0.DataBind();
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
