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
	public class ArticleNewList : BaseWebControl
	{
		private string string_0 = "all";
		private string string_1 = "ArticleNewList.ascx";
		private Repeater repeater_0;
		private Literal literal_0;
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		public string Title
		{
			get;
			set;
		}
		public string ShowCount
		{
			get;
			set;
		}
		public ArticleNewList()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_1;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			if (this.Page.Request.QueryString["SubstationID"] != null && !string.IsNullOrEmpty(this.Page.Request.QueryString["SubstationID"].ToString()))
			{
				this.string_0 = this.Page.Request.QueryString["SubstationID"].ToString();
			}
			this.repeater_0 = (Repeater)skin.FindControl("DataListAriticleNew");
			this.literal_0 = (Literal)skin.FindControl("LiteralTitle");
			if (this.Page.IsPostBack)
			{
			}
			this.method_0();
		}
		private void method_0()
		{
			this.literal_0.Text = this.Title;
			ShopNum1_Article_Action shopNum1_Article_Action = (ShopNum1_Article_Action)LogicFactory.CreateShopNum1_Article_Action();
			DataTable dataTable = shopNum1_Article_Action.SearchNewArticle(Convert.ToInt32(this.ShowCount), this.string_0);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				this.repeater_0.DataSource = dataTable.DefaultView;
				this.repeater_0.DataBind();
			}
		}
	}
}
