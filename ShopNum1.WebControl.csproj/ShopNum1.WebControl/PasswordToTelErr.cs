using ShopNum1.MultiBaseWebControl;
using System;
using System.Web.UI;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class PasswordToTelErr : BaseWebControl, ICallbackEventHandler
	{
		private string string_0 = "FindBackPasswordTel.ascx";
		public PasswordToTelErr()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
		}
		public string GetCallbackResult()
		{
			throw new NotImplementedException();
		}
		public void RaiseCallbackEvent(string eventArgument)
		{
			throw new NotImplementedException();
		}
	}
}
