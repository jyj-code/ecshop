using ShopNum1.MultiBaseWebControl;
using System;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopWebControl
{
	[ParseChildren(true)]
	public class FootNew : BaseWebControl
	{
		private string string_0 = "FootNew.ascx";
		private Literal literal_0;
		private Literal literal_1;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		public string guid
		{
			get;
			set;
		}
		public string MemLoginID
		{
			get;
			set;
		}
		public FootNew()
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
