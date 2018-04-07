using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopWebControl
{
	[ParseChildren(true)]
	public class ShopCommentList : BaseWebControl
	{
		private string string_0 = "ShopCommentList.ascx";
		private Repeater repeater_0;
		private LinkButton linkButton_0;
		private LinkButton linkButton_1;
		private LinkButton linkButton_2;
		private LinkButton linkButton_3;
		private Label label_0;
		private HyperLink hyperLink_0;
		private HyperLink hyperLink_1;
		private HyperLink hyperLink_2;
		private HyperLink hyperLink_3;
		private Literal literal_0;
		private Panel panel_0;
		private string string_1 = string.Empty;
		private string string_2;
		private string string_3 = string.Empty;
		[CompilerGenerated]
		private int int_0;
		[CompilerGenerated]
		private string string_4;
		public int ShowCount
		{
			get;
			set;
		}
		public string MemLoginID
		{
			get;
			set;
		}
		public ShopCommentList()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.string_3 = ((this.Page.Request.QueryString["ShopID"] == null) ? "0" : this.Page.Request.QueryString["ShopID"].ToString());
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = new ShopNum1_ShopInfoList_Action();
			shopNum1_ShopInfoList_Action.GetShopMemLoginIdByShopID(this.string_3).ToString();
			this.string_1 = ((this.Page.Request.QueryString["commentType"] == null) ? "3" : this.Page.Request.QueryString["commentType"]);
			this.string_2 = ((this.Page.Request.QueryString["guid"] == null) ? "-1" : this.Page.Request.QueryString["guid"]);
			this.panel_0 = (Panel)skin.FindControl("Panelpager");
			this.linkButton_0 = (LinkButton)skin.FindControl("LinkButtonAll");
			this.linkButton_0.Click += new EventHandler(this.linkButton_0_Click);
			this.linkButton_1 = (LinkButton)skin.FindControl("LinkButtonGood");
			this.linkButton_1.Click += new EventHandler(this.linkButton_1_Click);
			this.linkButton_2 = (LinkButton)skin.FindControl("LinkButtonMid");
			this.linkButton_2.Click += new EventHandler(this.linkButton_2_Click);
			this.linkButton_3 = (LinkButton)skin.FindControl("LinkButtonBad");
			this.linkButton_3.Click += new EventHandler(this.linkButton_3_Click);
			this.hyperLink_0 = (HyperLink)skin.FindControl("lnkPrev");
			this.hyperLink_1 = (HyperLink)skin.FindControl("lnkFirst");
			this.hyperLink_2 = (HyperLink)skin.FindControl("lnkNext");
			this.hyperLink_3 = (HyperLink)skin.FindControl("lnkLast");
			this.label_0 = (Label)skin.FindControl("LabelPageMessage");
			this.literal_0 = (Literal)skin.FindControl("lnkTo");
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterShow");
			HtmlGenericControl htmlGenericControl = (HtmlGenericControl)skin.FindControl("div" + this.string_1);
			htmlGenericControl.Style["background"] = "url(Themes/Skin_Default/images/wany.gif) no-repeat; width:87px; height:27px; line-height:27px; text-align:center; color:#fff;";
			if (this.Page.IsPostBack)
			{
			}
			this.method_0();
		}
		private void linkButton_3_Click(object sender, EventArgs e)
		{
			this.string_1 = "0";
			if (this.string_2 == "-1")
			{
				this.Page.Response.Redirect(GetPageName.RetUrl("ShopComment", "commentType=" + this.string_1 + "&guid=" + this.string_2));
			}
			else
			{
				this.Page.Response.Redirect(GetPageName.RetUrl("ProductDetail", "commentType=" + this.string_1 + "&guid=" + this.string_2));
			}
		}
		private void linkButton_2_Click(object sender, EventArgs e)
		{
			this.string_1 = "1";
			if (this.string_2 == "-1")
			{
				this.Page.Response.Redirect(GetPageName.RetUrl("ShopComment", "commentType=" + this.string_1 + "&guid=" + this.string_2));
			}
			else
			{
				this.Page.Response.Redirect(GetPageName.RetUrl("ProductDetail", "commentType=" + this.string_1 + "&guid=" + this.string_2));
			}
		}
		private void linkButton_0_Click(object sender, EventArgs e)
		{
			this.string_1 = "3";
			if (this.string_2 == "-1")
			{
				this.Page.Response.Redirect(GetPageName.RetUrl("ShopComment", "commentType=" + this.string_1 + "&guid=" + this.string_2));
			}
			else
			{
				this.Page.Response.Redirect(GetPageName.RetUrl("ProductDetail", "commentType=" + this.string_1 + "&guid=" + this.string_2));
			}
		}
		private void linkButton_1_Click(object sender, EventArgs e)
		{
			this.string_1 = "2";
			if (this.string_2 == "-1")
			{
				this.Page.Response.Redirect(GetPageName.RetUrl("ShopComment", "commentType=" + this.string_1 + "&guid=" + this.string_2));
			}
			else
			{
				this.Page.Response.Redirect(GetPageName.RetUrl("ProductDetail", "commentType=" + this.string_1 + "&guid=" + this.string_2));
			}
		}
		private void method_0()
		{
			Shop_ProductComment_Action shop_ProductComment_Action = (Shop_ProductComment_Action)LogicFactory.CreateShop_ProductComment_Action();
			DataTable dataTable = shop_ProductComment_Action.CommentListStatReport(this.string_3, this.string_2);
			if (dataTable.Rows.Count > 0)
			{
				this.linkButton_1.Text = "好评" + dataTable.Rows[0]["GoodNum"].ToString();
				this.linkButton_2.Text = "中评" + dataTable.Rows[0]["MidNum"].ToString();
				this.linkButton_3.Text = "差评" + dataTable.Rows[0]["BadNum"].ToString();
			}
			if (this.string_1 == "3")
			{
				this.string_1 = "-1";
			}
			DataTable dataTable2 = shop_ProductComment_Action.CommentList(this.MemLoginID, this.string_1, this.string_2);
			if (dataTable2.Rows.Count > 0)
			{
				PagedDataSource pagedDataSource = new PagedDataSource();
				pagedDataSource.DataSource = dataTable2.DefaultView;
				pagedDataSource.AllowPaging = true;
				pagedDataSource.PageSize = this.ShowCount;
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
				this.literal_0.Text = num1WebControlCommon.AppendPage(this.Page, pagedDataSource.PageCount, num, "commentType=" + this.string_1 + "&guid=" + this.string_2);
				this.hyperLink_0.NavigateUrl = string.Concat(new object[]
				{
					this.Page.Request.CurrentExecutionFilePath,
					"?Page=",
					Convert.ToInt32(num - 1),
					"&commentType=",
					this.string_1,
					"&guid=",
					this.string_2
				});
				this.hyperLink_1.NavigateUrl = string.Concat(new string[]
				{
					this.Page.Request.CurrentExecutionFilePath,
					"?Page=1&commentType=",
					this.string_1,
					"&guid=",
					this.string_2
				});
				this.hyperLink_2.NavigateUrl = string.Concat(new object[]
				{
					this.Page.Request.CurrentExecutionFilePath,
					"?Page=",
					Convert.ToInt32(num + 1),
					"&commentType=",
					this.string_1,
					"&guid=",
					this.string_2
				});
				this.hyperLink_3.NavigateUrl = string.Concat(new object[]
				{
					this.Page.Request.CurrentExecutionFilePath,
					"?Page=",
					pagedDataSource.PageCount,
					"&commentType=",
					this.string_1,
					"&guid=",
					this.string_2
				});
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
				this.panel_0.Visible = true;
			}
			else
			{
				this.panel_0.Visible = false;
			}
		}
		public static string CommentValue(object commentType)
		{
			string text = commentType.ToString();
			string result;
			if (text != null)
			{
				if (text == "0")
				{
					result = "[差评]";
					return result;
				}
				if (text == "1")
				{
					result = "[中评]";
					return result;
				}
				if (text == "2")
				{
					result = "[好评]";
					return result;
				}
			}
			result = "";
			return result;
		}
	}
}
