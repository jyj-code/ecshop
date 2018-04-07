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
	public class AriticleIsHotorIsRecommend : BaseWebControl
	{
		public int int_0 = 0;
		private string string_0 = "AriticleIsHotorIsRecommend.ascx";
		private Repeater repeater_0;
		private Label label_0;
		private string string_1 = "all";
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		[CompilerGenerated]
		private string string_4;
		[CompilerGenerated]
		private string string_5;
		[CompilerGenerated]
		private string string_6;
		public string ISType
		{
			get;
			set;
		}
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
		public string Titel
		{
			get;
			set;
		}
		public string LanguageCode
		{
			get;
			set;
		}
		public AriticleIsHotorIsRecommend()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			if (this.Page.Request.QueryString["SubstationID"] != null && !string.IsNullOrEmpty(this.Page.Request.QueryString["SubstationID"].ToString()))
			{
				this.string_1 = this.Page.Request.QueryString["SubstationID"].ToString();
			}
			this.LanguageCode = ((this.Page.Request.QueryString["LanguageCode"] == null) ? "" : this.Page.Request.QueryString["LanguageCode"].ToString());
			this.label_0 = (Label)skin.FindControl("Labeltitle");
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterCategory");
			if (this.Page.IsPostBack)
			{
			}
			this.method_0();
		}
		private void method_0()
		{
			ShopNum1_Article_Action shopNum1_Article_Action = (ShopNum1_Article_Action)LogicFactory.CreateShopNum1_Article_Action();
			DataTable articleIsHotorIsRecommend = shopNum1_Article_Action.GetArticleIsHotorIsRecommend(this.ShowCount, this.CateforyID, this.ISType, this.string_1);
			if (articleIsHotorIsRecommend != null)
			{
				this.repeater_0.DataSource = articleIsHotorIsRecommend.DefaultView;
				this.repeater_0.DataBind();
			}
			if (!string.IsNullOrEmpty(this.Titel))
			{
				this.label_0.Text = this.Titel;
			}
		}
	}
}
