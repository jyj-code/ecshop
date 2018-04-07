using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopWebControl
{
	[ParseChildren(true)]
	public class ScoreProductDetailMeto : BaseWebControl
	{
		private string string_0 = "ScoreProductDetailMeto.ascx";
		private Literal literal_0;
		private Literal literal_1;
		private Literal literal_2;
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
		public ScoreProductDetailMeto()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.literal_0 = (Literal)skin.FindControl("LiteralPageTitle");
			this.literal_1 = (Literal)skin.FindControl("LiteralPagekeywords");
			this.literal_2 = (Literal)skin.FindControl("LiteralPagedescription");
			string nameById = ShopNum1.Common.Common.GetNameById("Name", "ShopNum1_Shop_ScoreProduct", "   AND  Guid='" + this.Page.Request.QueryString["guid"].ToString() + "'");
			string nameById2 = ShopNum1.Common.Common.GetNameById("Meto_Keywords", "ShopNum1_Shop_ScoreProduct", "   AND  Guid='" + this.Page.Request.QueryString["guid"].ToString() + "'");
			string nameById3 = ShopNum1.Common.Common.GetNameById("Meto_Description", "ShopNum1_Shop_ScoreProduct", "   AND  Guid='" + this.Page.Request.QueryString["guid"].ToString() + "'");
			this.literal_0.Text = string.Concat(new string[]
			{
				"\n<title>",
				nameById,
				"_",
				ShopSettings.GetValue("Title"),
				ShopNum1.Common.Common.GetCopyright(),
				"</title>\n"
			});
			if (!string.IsNullOrEmpty(nameById2))
			{
				this.literal_1.Text = "<meta name=\"keywords\" content=\"" + nameById2 + ShopNum1.Common.Common.GetCopyright() + "\">\n";
			}
			else
			{
				this.literal_1.Text = "<meta name=\"keywords\" content=\"" + nameById + ShopNum1.Common.Common.GetCopyright() + "\">\n";
			}
			if (!string.IsNullOrEmpty(nameById3))
			{
				this.literal_2.Text = "<meta name=\"description\" content=\"" + nameById3 + ShopNum1.Common.Common.GetCopyright() + "\">\n";
			}
			else
			{
				this.literal_2.Text = "<meta name=\"description\" content=\"" + nameById + ShopNum1.Common.Common.GetCopyright() + "\">\n";
			}
		}
	}
}
