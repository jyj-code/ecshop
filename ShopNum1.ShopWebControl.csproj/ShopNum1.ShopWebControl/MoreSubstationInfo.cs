using ShopNum1.MultiBaseWebControl;
using System;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopWebControl
{
	[ParseChildren(true)]
	public class MoreSubstationInfo : BaseWebControl
	{
		private Repeater repeater_0;
		private string string_0 = "MoreSubstationInfo.ascx";
		public MoreSubstationInfo()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			this.method_0();
		}
		private void method_0()
		{
			this.repeater_0.DataBind();
		}
		public static string returnAgentUlr(object object_0)
		{
			return "http://" + object_0.ToString() + ConfigurationManager.AppSettings["Domain"].ToString();
		}
	}
}
