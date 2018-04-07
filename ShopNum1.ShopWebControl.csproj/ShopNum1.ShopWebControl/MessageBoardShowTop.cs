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
	public class MessageBoardShowTop : BaseWebControl
	{
		private string string_0 = "MessageBoardShowTop.ascx";
		private Repeater repeater_0;
		private LinkButton linkButton_0;
		private LinkButton linkButton_1;
		private LinkButton linkButton_2;
		private LinkButton linkButton_3;
		private LinkButton linkButton_4;
		private LinkButton linkButton_5;
		private LinkButton linkButton_6;
		private HtmlGenericControl htmlGenericControl_0;
		private HtmlGenericControl htmlGenericControl_1;
		private HtmlGenericControl htmlGenericControl_2;
		private HtmlGenericControl htmlGenericControl_3;
		private HtmlGenericControl htmlGenericControl_4;
		private HtmlGenericControl htmlGenericControl_5;
		private Label label_0;
		private HyperLink hyperLink_0;
		private HyperLink hyperLink_1;
		private HyperLink hyperLink_2;
		private HyperLink hyperLink_3;
		private Literal literal_0;
		private string string_1 = "-1";
		[CompilerGenerated]
		private int int_0;
		[CompilerGenerated]
		private string string_2;
		public int PageCount
		{
			get;
			set;
		}
		public string MemLoginID
		{
			get;
			set;
		}
		public MessageBoardShowTop()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			string memloginId = (this.Page.Request.QueryString["ShopID"] == null) ? "0" : this.Page.Request.QueryString["ShopID"].ToString();
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = new ShopNum1_ShopInfoList_Action();
			this.MemLoginID = shopNum1_ShopInfoList_Action.GetShopMemLoginIdByShopID(memloginId).ToString();
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterBoardList");
			this.linkButton_0 = (LinkButton)skin.FindControl("LinkButton0");
			this.linkButton_1 = (LinkButton)skin.FindControl("LinkButton1");
			this.linkButton_2 = (LinkButton)skin.FindControl("LinkButton2");
			this.linkButton_3 = (LinkButton)skin.FindControl("LinkButton3");
			this.linkButton_4 = (LinkButton)skin.FindControl("LinkButton4");
			this.linkButton_5 = (LinkButton)skin.FindControl("LinkButton5");
			this.linkButton_6 = (LinkButton)skin.FindControl("LinkButtonAll");
			this.hyperLink_0 = (HyperLink)skin.FindControl("lnkPrev");
			this.hyperLink_1 = (HyperLink)skin.FindControl("lnkFirst");
			this.hyperLink_2 = (HyperLink)skin.FindControl("lnkNext");
			this.hyperLink_3 = (HyperLink)skin.FindControl("lnkLast");
			this.label_0 = (Label)skin.FindControl("LabelPageMessage");
			this.literal_0 = (Literal)skin.FindControl("lnkTo");
			this.linkButton_0.Click += new EventHandler(this.linkButton_5_Click);
			this.linkButton_1.Click += new EventHandler(this.linkButton_5_Click);
			this.linkButton_2.Click += new EventHandler(this.linkButton_5_Click);
			this.linkButton_3.Click += new EventHandler(this.linkButton_5_Click);
			this.linkButton_4.Click += new EventHandler(this.linkButton_5_Click);
			this.linkButton_5.Click += new EventHandler(this.linkButton_5_Click);
			this.linkButton_6.Click += new EventHandler(this.linkButton_6_Click);
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("div1");
			this.htmlGenericControl_1 = (HtmlGenericControl)skin.FindControl("div2");
			this.htmlGenericControl_2 = (HtmlGenericControl)skin.FindControl("div3");
			this.htmlGenericControl_3 = (HtmlGenericControl)skin.FindControl("div4");
			this.htmlGenericControl_4 = (HtmlGenericControl)skin.FindControl("div5");
			this.htmlGenericControl_5 = (HtmlGenericControl)skin.FindControl("div6");
			if (this.Page.IsPostBack)
			{
			}
			this.method_0();
		}
		private void linkButton_6_Click(object sender, EventArgs e)
		{
			this.string_1 = "-1";
			this.method_0();
		}
		private void linkButton_5_Click(object sender, EventArgs e)
		{
			this.string_1 = ((LinkButton)sender).ID.Replace("LinkButton", "");
			this.method_0();
		}
		private void method_0()
		{
			Shop_MessageBoard_Action shop_MessageBoard_Action = (Shop_MessageBoard_Action)LogicFactory.CreateShop_MessageBoard_Action();
			DataTable dataTable = shop_MessageBoard_Action.SearchMessageBoardList(this.MemLoginID, "1", "-1", this.string_1);
			this.htmlGenericControl_0.Style.Value = "";
			this.htmlGenericControl_1.Style.Value = "";
			this.htmlGenericControl_2.Style.Value = "";
			this.htmlGenericControl_3.Style.Value = "";
			this.htmlGenericControl_4.Style.Value = "";
			this.htmlGenericControl_5.Style.Value = "";
			string text = this.string_1;
			switch (text)
			{
			case "0":
				this.htmlGenericControl_0.Style["background"] = "url(Themes/Skin_Default/images/wany_a.gif) no-repeat; width:87px; height:27px; line-height:27px; text-align:center; color:#fff;";
				break;
			case "1":
				this.htmlGenericControl_1.Style["background"] = "url(Themes/Skin_Default/images/wany_a.gif) no-repeat; width:87px; height:27px; line-height:27px; text-align:center; color:#fff;";
				break;
			case "2":
				this.htmlGenericControl_2.Style["background"] = "url(Themes/Skin_Default/images/wany_a.gif) no-repeat; width:87px; height:27px; line-height:27px; text-align:center; color:#fff;";
				break;
			case "3":
				this.htmlGenericControl_3.Style["background"] = "url(Themes/Skin_Default/images/wany_a.gif) no-repeat; width:87px; height:27px; line-height:27px; text-align:center; color:#fff;";
				break;
			case "4":
				this.htmlGenericControl_4.Style["background"] = "url(Themes/Skin_Default/images/wany_a.gif) no-repeat; width:87px; height:27px; line-height:27px; text-align:center; color:#fff;";
				break;
			case "6":
				this.htmlGenericControl_5.Style["background"] = "url(Themes/Skin_Default/images/wany_a.gif) no-repeat; width:87px; height:27px; line-height:27px; text-align:center; color:#fff;";
				break;
			}
			PagedDataSource pagedDataSource = new PagedDataSource();
			pagedDataSource.DataSource = dataTable.DefaultView;
			pagedDataSource.AllowPaging = true;
			pagedDataSource.PageSize = this.PageCount;
			int num2;
			if (this.Page.Request.QueryString.Get("page") != null)
			{
				num2 = Convert.ToInt32(this.Page.Request.QueryString.Get("page"));
			}
			else
			{
				num2 = 1;
			}
			pagedDataSource.CurrentPageIndex = num2 - 1;
			this.repeater_0.DataSource = pagedDataSource;
			this.repeater_0.DataBind();
			Num1WebControlCommon num1WebControlCommon = new Num1WebControlCommon();
			this.label_0.Text = num1WebControlCommon.GetPageMessage(pagedDataSource.DataSourceCount, pagedDataSource.PageCount, pagedDataSource.PageSize, num2);
			this.literal_0.Text = num1WebControlCommon.AppendPage(this.Page, pagedDataSource.PageCount, num2);
			this.hyperLink_0.NavigateUrl = GetPageName.GetPage("?Page=" + Convert.ToInt32(num2 - 1) + "&guid=");
			this.hyperLink_1.NavigateUrl = GetPageName.GetPage("?Page=1");
			this.hyperLink_2.NavigateUrl = GetPageName.GetPage("?Page=" + Convert.ToInt32(num2 + 1));
			this.hyperLink_3.NavigateUrl = GetPageName.GetPage("?Page=" + pagedDataSource.PageCount);
			if (num2 <= 1 && pagedDataSource.PageCount <= 1)
			{
				this.hyperLink_1.NavigateUrl = "";
				this.hyperLink_0.NavigateUrl = "";
				this.hyperLink_2.NavigateUrl = "";
				this.hyperLink_3.NavigateUrl = "";
			}
			if (num2 <= 1 && pagedDataSource.PageCount > 1)
			{
				this.hyperLink_1.NavigateUrl = "";
				this.hyperLink_0.NavigateUrl = "";
			}
			if (num2 >= pagedDataSource.PageCount)
			{
				this.hyperLink_2.NavigateUrl = "";
				this.hyperLink_3.NavigateUrl = "";
			}
		}
		public static string GetValue(object object_0)
		{
			string text = object_0.ToString();
			string result;
			switch (text)
			{
			case "0":
				result = "售后";
				return result;
			case "1":
				result = "询问";
				return result;
			case "2":
				result = "一般消息";
				return result;
			case "3":
				result = "求购";
				return result;
			case "4":
				result = "留言";
				return result;
			case "5":
				result = "重要消息";
				return result;
			}
			result = "一般消息";
			return result;
		}
	}
}
