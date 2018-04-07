using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.MemberWebControl
{
	[ParseChildren(true)]
	public class M_ShopNewsCommentDetail : BaseMemberWebControl
	{
		private string string_0 = "M_ShopNewsCommentDetail.ascx";
		private Repeater repeater_0;
		private Button button_0;
		public M_ShopNewsCommentDetail()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterShow");
			this.button_0 = (Button)skin.FindControl("ButtonGoBack");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			if (this.Page.Request.QueryString["guid"] != null)
			{
				this.GetData(this.Page.Request.QueryString["guid"].ToString());
			}
		}
		public void GetData(string guid)
		{
			Shop_News_Action shop_News_Action = (Shop_News_Action)LogicFactory.CreateShop_News_Action();
			DataTable newsCommentDetail = shop_News_Action.GetNewsCommentDetail(guid);
			if (newsCommentDetail != null && newsCommentDetail.Rows.Count > 0)
			{
				this.repeater_0.DataSource = newsCommentDetail.DefaultView;
				this.repeater_0.DataBind();
			}
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			this.Page.Response.Redirect("M_Comment.aspx?type=4&pageid=1");
		}
	}
}
