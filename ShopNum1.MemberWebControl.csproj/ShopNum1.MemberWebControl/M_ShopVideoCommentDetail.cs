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
	public class M_ShopVideoCommentDetail : BaseMemberWebControl
	{
		private string string_0 = "M_ShopVideoCommentDetail.ascx";
		private Repeater repeater_0;
		private Button button_0;
		public M_ShopVideoCommentDetail()
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
			Shop_VideoComment_Action shop_VideoComment_Action = (Shop_VideoComment_Action)LogicFactory.CreateShop_VideoComment_Action();
			DataTable videoCommentDetail = shop_VideoComment_Action.GetVideoCommentDetail(guid);
			if (videoCommentDetail != null && videoCommentDetail.Rows.Count > 0)
			{
				this.repeater_0.DataSource = videoCommentDetail.DefaultView;
				this.repeater_0.DataBind();
			}
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			this.Page.Response.Redirect("M_Comment.aspx?type=1&pageid=1");
		}
	}
}
