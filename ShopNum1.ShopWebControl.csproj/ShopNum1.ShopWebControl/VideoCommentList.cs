using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopWebControl
{
	[ParseChildren(true)]
	public class VideoCommentList : BaseWebControl
	{
		private string string_0 = "VideoCommentList.ascx";
		private Repeater repeater_0;
		private Label label_0;
		private HyperLink hyperLink_0;
		private HyperLink hyperLink_1;
		private HyperLink hyperLink_2;
		private HyperLink hyperLink_3;
		private Literal literal_0;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		public string Guid
		{
			get;
			set;
		}
		public string PageCount
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
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			this.Guid = ((this.Page.Request.QueryString["Guid"] == null) ? "" : this.Page.Request.QueryString["Guid"].ToString());
			if (this.Page.IsPostBack)
			{
			}
			this.hyperLink_0 = (HyperLink)skin.FindControl("lnkPrev");
			this.hyperLink_1 = (HyperLink)skin.FindControl("lnkFirst");
			this.hyperLink_2 = (HyperLink)skin.FindControl("lnkNext");
			this.hyperLink_3 = (HyperLink)skin.FindControl("lnkLast");
			this.label_0 = (Label)skin.FindControl("LabelPageMessage");
			this.literal_0 = (Literal)skin.FindControl("lnkTo");
			if (this.Page.Request.QueryString["guid"] != null && this.Page.Request.QueryString["ShopID"] != null)
			{
				this.method_0(this.Page.Request.QueryString["guid"].ToString(), this.Page.Request.QueryString["ShopID"].ToString());
			}
		}
		private void method_0(string string_3, string string_4)
		{
			Shop_VideoComment_Action shop_VideoComment_Action = (Shop_VideoComment_Action)LogicFactory.CreateShop_VideoComment_Action();
			DataTable videoCommentList = shop_VideoComment_Action.GetVideoCommentList(this.Guid);
			PagedDataSource pagedDataSource = new PagedDataSource();
			pagedDataSource.DataSource = videoCommentList.DefaultView;
			pagedDataSource.AllowPaging = true;
			pagedDataSource.PageSize = 5;
			int num;
			if (this.Page.Request.QueryString.Get("page") != null)
			{
				num = Convert.ToInt32(this.Page.Request.QueryString.Get("page"));
			}
			else
			{
				num = 1;
			}
			pagedDataSource.CurrentPageIndex = num - 1;
			Num1WebControlCommon num1WebControlCommon = new Num1WebControlCommon();
			this.label_0.Text = num1WebControlCommon.GetPageMessage(pagedDataSource.DataSourceCount, pagedDataSource.PageCount, pagedDataSource.PageSize, num);
			this.literal_0.Text = num1WebControlCommon.AppendPageVideo(string.Concat(new string[]
			{
				this.Page.Request.Path,
				"?guid=",
				string_3,
				"&ShopID=",
				string_4
			}), pagedDataSource.PageCount, num);
			this.hyperLink_0.NavigateUrl = string.Concat(new object[]
			{
				this.Page.Request.Path,
				"?guid=",
				string_3,
				"&ShopID=",
				string_4,
				"&Page=",
				Convert.ToInt32(num - 1)
			});
			this.hyperLink_1.NavigateUrl = string.Concat(new string[]
			{
				this.Page.Request.Path,
				"?guid=",
				string_3,
				"&ShopID=",
				string_4,
				"&Page=1"
			});
			this.hyperLink_2.NavigateUrl = string.Concat(new object[]
			{
				this.Page.Request.Path,
				"?guid=",
				string_3,
				"&ShopID=",
				string_4,
				"&Page=",
				Convert.ToInt32(num + 1)
			});
			this.hyperLink_3.NavigateUrl = string.Concat(new object[]
			{
				this.Page.Request.Path,
				"?guid=",
				string_3,
				"&ShopID=",
				string_4,
				"&Page=",
				pagedDataSource.PageCount
			});
			if (num <= 1 && pagedDataSource.PageCount <= 1)
			{
				this.hyperLink_1.Enabled = false;
				this.hyperLink_0.Enabled = false;
				this.hyperLink_2.Enabled = false;
				this.hyperLink_3.Enabled = false;
			}
			if (num <= 1 && pagedDataSource.PageCount > 1)
			{
				this.hyperLink_1.Enabled = false;
				this.hyperLink_0.Enabled = false;
			}
			if (num >= pagedDataSource.PageCount)
			{
				this.hyperLink_2.Enabled = false;
				this.hyperLink_3.Enabled = false;
			}
			this.repeater_0.DataSource = pagedDataSource;
			this.repeater_0.DataBind();
		}
	}
}
