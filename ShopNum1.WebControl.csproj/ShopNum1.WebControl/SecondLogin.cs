using ShopNum1.MultiBaseWebControl;
using ShopNum1.Second;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class SecondLogin : BaseWebControl
	{
		private Repeater repeater_0;
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterSecondLogin");
			if (this.repeater_0 != null)
			{
				ShopNum1_SecondTypeBussiness shopNum1_SecondTypeBussiness = new ShopNum1_SecondTypeBussiness();
				DataTable secondByCount = shopNum1_SecondTypeBussiness.GetSecondByCount("10", "1");
				if (secondByCount != null && secondByCount.Rows.Count > 0)
				{
					this.repeater_0.DataSource = secondByCount;
					this.repeater_0.DataBind();
				}
			}
		}
	}
}
