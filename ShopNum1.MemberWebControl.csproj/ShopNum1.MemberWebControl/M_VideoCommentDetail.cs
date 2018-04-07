using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.MemberWebControl
{
	[ParseChildren(true)]
	public class M_VideoCommentDetail : BaseMemberWebControl
	{
		private string string_0 = "M_VideoCommentDetail.ascx";
		private Repeater repeater_0;
		private Button button_0;
		public M_VideoCommentDetail()
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
			ShopNum1_VedioCommentChecked_Action shopNum1_VedioCommentChecked_Action = (ShopNum1_VedioCommentChecked_Action)LogicFactory.CreateShopNum1_VedioCommentChecked_Action();
			DataTable videoCommentDetailByGuid = shopNum1_VedioCommentChecked_Action.GetVideoCommentDetailByGuid(guid);
			if (videoCommentDetailByGuid != null && videoCommentDetailByGuid.Rows.Count > 0)
			{
				this.repeater_0.DataSource = videoCommentDetailByGuid.DefaultView;
				this.repeater_0.DataBind();
			}
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			this.Page.Response.Redirect("M_Comment.aspx?type=2&pageid=1");
		}
	}
}
