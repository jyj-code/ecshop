using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopWebControl
{
	[ParseChildren(true)]
	public class ShopArticleCommentList : BaseWebControl
	{
		private string string_0 = "ShopArticleCommentList.ascx";
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
		private string Guid
		{
			get;
			set;
		}
		public string PageCount
		{
			get;
			set;
		}
		public ShopArticleCommentList()
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
			this.method_0();
		}
		public static string GetValue(object object_0)
		{
			string text = object_0.ToString();
			string result;
			switch (text)
			{
			case "0":
				result = "一般";
				return result;
			case "1":
				result = "一星";
				return result;
			case "2":
				result = "二星";
				return result;
			case "3":
				result = "三星";
				return result;
			case "4":
				result = "四星";
				return result;
			case "5":
				result = "五星";
				return result;
			}
			result = "一般";
			return result;
		}
		private void method_0()
		{
			ShopNum1_ShopArticleComment_Action shopNum1_ShopArticleComment_Action = (ShopNum1_ShopArticleComment_Action)LogicFactory.CreateShopNum1_ShopArticleComment_Action();
			DataTable shopArticleCommentByGuid = shopNum1_ShopArticleComment_Action.GetShopArticleCommentByGuid(this.Guid);
			PagedDataSource pagedDataSource = new PagedDataSource();
			pagedDataSource.DataSource = shopArticleCommentByGuid.DefaultView;
			pagedDataSource.AllowPaging = true;
			try
			{
				if (int.Parse(this.PageCount) < 1)
				{
					pagedDataSource.PageSize = 10;
				}
				else
				{
					pagedDataSource.PageSize = int.Parse(this.PageCount);
				}
			}
			catch
			{
				pagedDataSource.PageSize = 10;
			}
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
			this.literal_0.Text = num1WebControlCommon.AppendPage(this.Page, pagedDataSource.PageCount, num);
			this.hyperLink_0.NavigateUrl = this.Page.Request.CurrentExecutionFilePath + "?Page=" + Convert.ToInt32(num - 1);
			this.hyperLink_1.NavigateUrl = this.Page.Request.CurrentExecutionFilePath + "?Page=1";
			this.hyperLink_2.NavigateUrl = this.Page.Request.CurrentExecutionFilePath + "?Page=" + Convert.ToInt32(num + 1);
			this.hyperLink_3.NavigateUrl = this.Page.Request.CurrentExecutionFilePath + "?Page=" + pagedDataSource.PageCount;
			if (num <= 1 && pagedDataSource.PageCount <= 1)
			{
				this.hyperLink_1.NavigateUrl = "";
				this.hyperLink_0.NavigateUrl = "";
				this.hyperLink_2.NavigateUrl = "";
				this.hyperLink_3.NavigateUrl = "";
			}
			if (num <= 1 && pagedDataSource.PageCount > 1)
			{
				this.hyperLink_1.NavigateUrl = "";
				this.hyperLink_0.NavigateUrl = "";
			}
			if (num >= pagedDataSource.PageCount)
			{
				this.hyperLink_2.NavigateUrl = "";
				this.hyperLink_3.NavigateUrl = "";
			}
			this.repeater_0.DataSource = pagedDataSource;
			this.repeater_0.DataBind();
		}
	}
}
