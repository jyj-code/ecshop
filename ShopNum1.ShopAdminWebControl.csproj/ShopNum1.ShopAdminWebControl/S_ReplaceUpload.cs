using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Web;
using System.Web.UI;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_ReplaceUpload : BaseShopWebControl
	{
		private string string_0 = "S_ReplaceUpload.cs.ascx";
		public S_ReplaceUpload()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			if (this.Page.Request.Files["file"] != null)
			{
				HttpPostedFile httpPostedFile = this.Page.Request.Files["file"];
				MessageBox.Show(httpPostedFile.FileName);
			}
		}
	}
}
