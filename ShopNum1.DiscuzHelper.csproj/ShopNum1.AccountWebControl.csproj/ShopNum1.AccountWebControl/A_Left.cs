using ShopNum1.MultiBaseWebControl;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.AccountWebControl
{
	[ParseChildren(true)]
	public class A_Left : BaseMemberWebControl
	{
		private string string_0 = "A_Left.cs";
		private Label label_0;
		private LinkButton linkButton_0;
		public A_Left()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
		}
	}
}
