using ShopNum1.MultiBaseWebControl;
using System;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopWebControl
{
	[ParseChildren(true)]
	public class ShopNewsMeta : BaseWebControl
	{
		private string string_0 = "ShopNewsMeta.ascx";
		private Literal literal_0;
		private Literal literal_1;
		private Literal literal_2;
		[CompilerGenerated]
		private string string_1;
		public string MemLoginID
		{
			get;
			set;
		}
		public ShopNewsMeta()
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
