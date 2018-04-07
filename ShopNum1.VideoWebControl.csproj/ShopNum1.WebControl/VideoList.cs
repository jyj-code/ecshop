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
	public class VideoList : BaseWebControl
	{
		private string string_0 = "VideoList.ascx";
		private Label label_0;
		private HyperLink hyperLink_0;
		private HyperLink hyperLink_1;
		private HyperLink hyperLink_2;
		private HyperLink hyperLink_3;
		private Literal literal_0;
		private string string_1 = "all";
		private Repeater repeater_0;
		private HtmlGenericControl htmlGenericControl_0;
		private Label label_1;
		[CompilerGenerated]
		private int int_0;
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		public int PageCount
		{
			get;
			set;
		}
		public string VideoCategoryID
		{
			get;
			set;
		}
		public string Keyword
		{
			get;
			set;
		}
		protected override void InitializeSkin(Control skin)
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("pageDiv");
			this.hyperLink_0 = (HyperLink)skin.FindControl("lnkPrev");
			this.hyperLink_1 = (HyperLink)skin.FindControl("lnkFirst");
			this.hyperLink_2 = (HyperLink)skin.FindControl("lnkNext");
			this.hyperLink_3 = (HyperLink)skin.FindControl("lnkLast");
			this.label_0 = (Label)skin.FindControl("LabelPageMessage");
			this.literal_0 = (Literal)skin.FindControl("lnkTo");
			this.label_1 = (Label)skin.FindControl("lblVideoTitle");
			if (this.Page.Request.QueryString["SubstationID"] != null && !string.IsNullOrEmpty(this.Page.Request.QueryString["SubstationID"].ToString()))
			{
				this.string_1 = this.Page.Request.QueryString["SubstationID"].ToString();
			}
			this.VideoCategoryID = ((this.Page.Request.QueryString["guid"] == null) ? "-1" : this.Page.Request.QueryString["guid"].ToString());
			if (this.Page.Request.QueryString["guid"] == null)
			{
				this.VideoCategoryID = ((this.Page.Request.QueryString["CategoryID"] == null) ? "-1" : this.Page.Request.QueryString["CategoryID"].ToString());
			}
			this.Keyword = ((this.Page.Request.QueryString["keyword"] == null) ? "" : this.Page.Request.QueryString["keyword"].ToString());
			if (this.Page.IsPostBack)
			{
			}
			this.BindData();
		}
		protected void BindData()
		{
			try
			{
                this.label_1.Text = ShopNum1.Common.Common.GetNameById("name", "ShopNum1_VideoCategory", " And id='" + ShopNum1.Common.Common.ReqStr("guid") + "'");
			}
			catch
			{
			}
			ShopNum1_Video_Action shopNum1_Video_Action = (ShopNum1_Video_Action)LogicFactory.CreateShopNum1_Video_Action();
			int num = 1;
			try
			{
                num = Convert.ToInt32(ShopNum1.Common.Common.ReqStr("PageID"));
			}
			catch
			{
			}
			PageList1 pageList = new PageList1();
			pageList.PageSize = this.PageCount;
			pageList.PageID = num;
            DataTable dataTable = shopNum1_Video_Action.SearchVideoList("0", this.PageCount.ToString(), num.ToString(), ShopNum1.Common.Common.ReqStr("type"), ShopNum1.Common.Common.ReqStr("guid"), this.string_1);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				pageList.RecordCount = Convert.ToInt32(dataTable.Rows[0][0]);
			}
			else
			{
				pageList.RecordCount = 0;
			}
			PageListBll pageListBll = new PageListBll("Video_ListV82", true);
			pageListBll.ShowRecordCount = true;
			pageListBll.ShowPageCount = false;
			pageListBll.ShowPageIndex = false;
			pageListBll.ShowRecordCount = false;
			pageListBll.ShowNoRecordInfo = false;
			pageListBll.ShowNumListButton = true;
			pageListBll.PrevPageText = "上一页";
			pageListBll.NextPageText = "下一页 ";
			this.htmlGenericControl_0.InnerHtml = pageListBll.GetPageListVk(pageList);
			if ((double)pageList.PageCount < (double)pageList.RecordCount / (double)pageList.PageSize)
			{
				pageList.PageCount++;
			}
			if (num > pageList.PageCount)
			{
				num = pageList.PageCount;
			}
            DataTable dataTable2 = shopNum1_Video_Action.SearchVideoList("1", this.PageCount.ToString(), num.ToString(), ShopNum1.Common.Common.ReqStr("type"), ShopNum1.Common.Common.ReqStr("guid"), this.string_1);
			this.repeater_0.DataSource = dataTable2.DefaultView;
			this.repeater_0.DataBind();
		}
		public static string GetSubstr(object title, int length, bool isEllipsis)
		{
			string text = title.ToString();
			if (text.Length > length)
			{
				text = text.Substring(0, length);
			}
			if (isEllipsis)
			{
				text += "...";
			}
			return text;
		}
	}
}
