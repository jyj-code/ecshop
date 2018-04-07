using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class SurveyThemeDetail : BaseWebControl
	{
		private string string_0 = "SurveyThemeDetail.ascx";
		private Repeater repeater_0;
		private Label label_0;
		private Label label_1;
		private Label label_2;
		public SurveyThemeDetail()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterSurveyThemeDetail");
			this.label_0 = (Label)skin.FindControl("LabelAllCount1");
			this.label_1 = (Label)skin.FindControl("LabelAllCount2");
			this.label_2 = (Label)skin.FindControl("LabelTitle");
			this.repeater_0.ItemDataBound += new RepeaterItemEventHandler(this.repeater_0_ItemDataBound);
			if (this.Page.IsPostBack)
			{
			}
			string a = (this.Page.Request.QueryString["guid"] == null) ? "0" : this.Page.Request.QueryString["guid"];
			if (a != "0")
			{
				this.method_0();
			}
		}
		private void repeater_0_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				string text = "10";
				string text2 = "10";
				HiddenField hiddenField = (HiddenField)e.Item.FindControl("HiddenFieldCount");
				Label label = (Label)e.Item.FindControl("LabelShow");
				label.Text = string.Concat(new string[]
				{
					"<hr size=",
					text,
					" width=",
					hiddenField.Value,
					" color=",
					text2,
					">"
				});
			}
		}
		private void method_0()
		{
			ShopNum1_SurveyTheme_Action shopNum1_SurveyTheme_Action = (ShopNum1_SurveyTheme_Action)LogicFactory.CreateShopNum1_SurveyTheme_Action();
			DataTable dataTable = shopNum1_SurveyTheme_Action.SearchSurveyOption(this.Page.Request.QueryString["guid"].ToString().Replace("'", ""));
			this.repeater_0.DataSource = dataTable.DefaultView;
			this.repeater_0.DataBind();
			this.label_0.Text = dataTable.Rows[0]["AllCount"].ToString();
			this.label_1.Text = dataTable.Rows[0]["AllCount"].ToString();
			this.label_2.Text = dataTable.Rows[0]["Title"].ToString();
		}
	}
}
