using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class AriticlekeyWords : BaseWebControl
	{
		public int int_0 = 0;
		private string string_0 = "AriticlekeyWords.ascx";
		private Repeater repeater_0;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		public string ShowCount
		{
			get;
			set;
		}
		public string CateforyID
		{
			get;
			set;
		}
		public AriticlekeyWords()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterShow");
			if (this.Page.IsPostBack)
			{
			}
			if (this.CateforyID != null)
			{
				this.method_0();
			}
		}
		private void method_0()
		{
			ShopNum1_Article_Action shopNum1_Article_Action = (ShopNum1_Article_Action)LogicFactory.CreateShopNum1_Article_Action();
			DataTable childCategory = shopNum1_Article_Action.GetChildCategory(this.ShowCount, this.CateforyID);
			if (childCategory != null)
			{
				this.repeater_0.DataSource = childCategory.DefaultView;
				this.repeater_0.DataBind();
			}
		}
	}
}
