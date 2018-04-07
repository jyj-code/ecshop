using ShopNum1.MultiBaseWebControl;
using System;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class SupplyUnderArticle : BaseWebControl
	{
		private string string_0 = "SupplyUnderArticle.ascx";
		private Repeater repeater_0;
		[CompilerGenerated]
		private int int_0;
		[CompilerGenerated]
		private int int_1;
		[CompilerGenerated]
		private string string_1;
		public int ArticleCategoryID
		{
			get;
			set;
		}
		public int ShowCount
		{
			get;
			set;
		}
		public string Sort
		{
			get;
			set;
		}
		public SupplyUnderArticle()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterArticleFirst");
		}
	}
}
