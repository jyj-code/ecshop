using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class FindPasswordSuccess : BaseWebControl, ICallbackEventHandler
	{
		private string string_0 = "FindPasswordSuccess.ascx";
		private LinkButton linkButton_0;
		public FindPasswordSuccess()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.linkButton_0 = (LinkButton)skin.FindControl("LinkButtonLogin");
			if (!this.Page.IsPostBack)
			{
				this.linkButton_0.PostBackUrl = GetPageName.RetDomainUrl("index").ToString();
			}
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
