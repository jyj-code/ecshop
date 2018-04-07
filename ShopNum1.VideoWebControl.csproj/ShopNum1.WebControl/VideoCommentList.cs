using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class VideoCommentList : BaseWebControl
	{
		private string string_0 = "VideoCommentList.ascx";
		private Repeater repeater_0;
		private HtmlGenericControl htmlGenericControl_0;
		private Label label_0;
		private TextBox textBox_0;
		private Button button_0;
		private string string_1 = GetPageName.RetDomainUrl("VideoDetail");
		private int int_0;
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private int int_1;
		public string Guid
		{
			get;
			set;
		}
		public int ShowCount
		{
			get;
			set;
		}
		public VideoCommentList()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("pageDiv");
			this.label_0 = (Label)skin.FindControl("LabelPageCount");
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxIndex");
			this.button_0 = (Button)skin.FindControl("ButtonSure");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			this.Guid = ((this.Page.Request.QueryString["Guid"] == null) ? "" : this.Page.Request.QueryString["Guid"].ToString());
			this.int_0 = 1;
			try
			{
				this.int_0 = int.Parse(this.Page.Request.QueryString["PageID"]);
			}
			catch
			{
				this.int_0 = 1;
			}
			if (this.Page.IsPostBack)
			{
			}
			this.method_0();
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			string text = this.textBox_0.Text.Trim();
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_1,
				"?Guid=",
				this.Guid,
				"&pageid=",
				text
			}));
		}
		private void method_0()
		{
			PageList1 pageList = new PageList1();
			pageList.PageSize = this.ShowCount;
			pageList.PageID = this.int_0;
			ShopNum1_VideoComment_Action shopNum1_VideoComment_Action = (ShopNum1_VideoComment_Action)LogicFactory.CreateShopNum1_VideoComment_Action();
			DataSet pageVideoComment = shopNum1_VideoComment_Action.GetPageVideoComment(this.Guid, this.ShowCount.ToString(), this.int_0.ToString(), "1");
			if (pageVideoComment != null && pageVideoComment.Tables[0].Rows.Count > 0)
			{
				pageList.RecordCount = Convert.ToInt32(pageVideoComment.Tables[0].Rows[0][0]);
			}
			else
			{
				pageList.RecordCount = 0;
			}
			PageListBll pageListBll = new PageListBll("videodetail", true);
			pageListBll.ShowRecordCount = true;
			pageListBll.ShowPageCount = false;
			pageListBll.ShowPageIndex = false;
			pageListBll.ShowRecordCount = false;
			pageListBll.ShowNoRecordInfo = false;
			pageListBll.ShowNumListButton = true;
			pageListBll.PrevPageText = "<上一页";
			pageListBll.NextPageText = "下一页>";
			this.textBox_0.Text = this.int_0.ToString();
			this.htmlGenericControl_0.InnerHtml = pageListBll.GetPageListVk(pageList);
			this.label_0.Text = pageList.PageCount.ToString();
			DataSet pageVideoComment2 = shopNum1_VideoComment_Action.GetPageVideoComment(this.Guid, this.ShowCount.ToString(), this.int_0.ToString(), "0");
			if (pageVideoComment2 != null && pageVideoComment2.Tables[0].Rows.Count > 0)
			{
				this.repeater_0.DataSource = pageVideoComment2.Tables[0];
				this.repeater_0.DataBind();
			}
		}
	}
}
