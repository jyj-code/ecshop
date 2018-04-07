using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopNewWebControl
{
	[ParseChildren(true)]
	public class MessageBoardShow : BaseWebControl
	{
		private string string_0 = "MessageBoardShowNew.ascx";
		private Repeater repeater_0;
		private LinkButton linkButton_0;
		private LinkButton linkButton_1;
		private LinkButton linkButton_2;
		private LinkButton linkButton_3;
		private LinkButton linkButton_4;
		private HtmlGenericControl htmlGenericControl_0;
		private HtmlGenericControl htmlGenericControl_1;
		private HtmlGenericControl htmlGenericControl_2;
		private HtmlGenericControl htmlGenericControl_3;
		private HtmlGenericControl htmlGenericControl_4;
		private HtmlGenericControl htmlGenericControl_5;
		private Label label_0;
		private TextBox textBox_0;
		private Button button_0;
		private string string_1 = GetPageName.AgentGetPage("");
		public string AgentMemberID;
		private int int_0;
		[CompilerGenerated]
		private int int_1;
		[CompilerGenerated]
		private int int_2;
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		[CompilerGenerated]
		private string string_4;
		[CompilerGenerated]
		private string string_5;
		public int ShowCount
		{
			get;
			set;
		}
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
		public string ordername
		{
			get;
			set;
		}
		public string soft
		{
			get;
			set;
		}
		public string type
		{
			get;
			set;
		}
		public MessageBoardShow()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.htmlGenericControl_5 = (HtmlGenericControl)skin.FindControl("pageDiv");
			this.label_0 = (Label)skin.FindControl("LabelPageCount");
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxIndex");
			this.button_0 = (Button)skin.FindControl("ButtonSure");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.int_0 = 1;
			try
			{
				this.int_0 = int.Parse(this.Page.Request.QueryString["PageID"]);
			}
			catch
			{
				this.int_0 = 1;
			}
			this.ordername = ((this.Page.Request.QueryString["ordername"] == null) ? "a.sendtime" : this.Page.Request.QueryString["ordername"].ToString());
			this.soft = ((this.Page.Request.QueryString["sort"] == null) ? "desc" : this.Page.Request.QueryString["sort"].ToString());
			this.type = ((this.Page.Request.QueryString["type"] == null) ? "" : this.Page.Request.QueryString["type"].ToString());
			try
			{
				this.type = Convert.ToInt16(this.type).ToString();
			}
			catch
			{
				this.type = "";
			}
			string shopid = (this.Page.Request.QueryString["ShopID"] == null) ? "0" : this.Page.Request.QueryString["ShopID"].ToString();
			Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)LogicFactory.CreateShop_ShopInfo_Action();
			this.MemLoginID = shop_ShopInfo_Action.GetMemberLoginidByShopid(shopid).ToString();
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterBoardList");
			this.linkButton_4 = (LinkButton)skin.FindControl("LinkButtonAll");
			this.linkButton_0 = (LinkButton)skin.FindControl("LinkButton0");
			this.linkButton_1 = (LinkButton)skin.FindControl("LinkButton1");
			this.linkButton_2 = (LinkButton)skin.FindControl("LinkButton2");
			this.linkButton_3 = (LinkButton)skin.FindControl("LinkButton3");
			this.linkButton_0.Click += new EventHandler(this.linkButton_0_Click);
			this.linkButton_1.Click += new EventHandler(this.linkButton_1_Click);
			this.linkButton_2.Click += new EventHandler(this.linkButton_2_Click);
			this.linkButton_3.Click += new EventHandler(this.linkButton_3_Click);
			this.linkButton_4.Click += new EventHandler(this.linkButton_4_Click);
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("div1");
			this.htmlGenericControl_1 = (HtmlGenericControl)skin.FindControl("div2");
			this.htmlGenericControl_2 = (HtmlGenericControl)skin.FindControl("div3");
			this.htmlGenericControl_3 = (HtmlGenericControl)skin.FindControl("div4");
			try
			{
				this.htmlGenericControl_4 = (HtmlGenericControl)skin.FindControl("div0");
			}
			catch
			{
			}
			if (this.Page.Request.Cookies["AgentLoginCookie"] != null)
			{
				HttpCookie cookie = this.Page.Request.Cookies["AgentLoginCookie"];
				HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
				this.AgentMemberID = httpCookie.Values["AgentLoginID"].ToString();
			}
			if (this.Page.IsPostBack)
			{
			}
			this.method_0();
		}
		private void linkButton_3_Click(object sender, EventArgs e)
		{
			this.type = ((LinkButton)sender).ID.Replace("LinkButton", "");
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				"http://",
				this.Page.Request.Url.Host,
				"/ShopMessageBoard.html?select=",
				ShopNum1.Common.Common.ReqStr("select"),
				"&type=",
				this.type
			}));
		}
		private void linkButton_2_Click(object sender, EventArgs e)
		{
			this.type = ((LinkButton)sender).ID.Replace("LinkButton", "");
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				"http://",
				this.Page.Request.Url.Host,
				"/ShopMessageBoard.html?select=",
				ShopNum1.Common.Common.ReqStr("select"),
				"&type=",
				this.type
			}));
		}
		private void linkButton_1_Click(object sender, EventArgs e)
		{
			this.type = ((LinkButton)sender).ID.Replace("LinkButton", "");
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				"http://",
				this.Page.Request.Url.Host,
				"/ShopMessageBoard.html?select=",
				ShopNum1.Common.Common.ReqStr("select"),
				"&type=",
				this.type
			}));
		}
		private void linkButton_0_Click(object sender, EventArgs e)
		{
			this.type = ((LinkButton)sender).ID.Replace("LinkButton", "");
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				"http://",
				this.Page.Request.Url.Host,
				"/ShopMessageBoard.html?select=",
				ShopNum1.Common.Common.ReqStr("select"),
				"&type=",
				this.type
			}));
		}
		private void linkButton_4_Click(object sender, EventArgs e)
		{
			this.type = "";
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				"http://",
				this.Page.Request.Url.Host,
				"/ShopMessageBoard.html?select=",
				ShopNum1.Common.Common.ReqStr("select"),
				"&type=",
				this.type
			}));
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			string text = this.textBox_0.Text.Trim();
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_1,
				"?sort=",
				this.soft,
				"&ordername=",
				this.ordername,
				"&pageid=",
				text
			}));
		}
		private void method_0()
		{
			Shop_MessageBoard_Action shop_MessageBoard_Action = (Shop_MessageBoard_Action)LogicFactory.CreateShop_MessageBoard_Action();
			PageList1 pageList = new PageList1();
			pageList.PageSize = this.ShowCount;
			pageList.PageID = this.int_0;
			DataSet dataSet = shop_MessageBoard_Action.SearchMessageBoardListNew(this.MemLoginID, this.type, this.ordername, this.soft, this.ShowCount.ToString(), this.int_0.ToString(), "1");
			if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
			{
				pageList.RecordCount = Convert.ToInt32(dataSet.Tables[0].Rows[0][0]);
			}
			else
			{
				pageList.RecordCount = 0;
			}
			PageListBll pageListBll = new PageListBll("ShopMessageBoard", true);
			pageListBll.ShowRecordCount = true;
			pageListBll.ShowPageCount = false;
			pageListBll.ShowPageIndex = false;
			pageListBll.ShowRecordCount = false;
			pageListBll.ShowNoRecordInfo = false;
			pageListBll.ShowNumListButton = true;
			pageListBll.PrevPageText = "上一页";
			pageListBll.NextPageText = "下一页 ";
			pageList.PageCount = pageList.RecordCount / pageList.PageSize;
			pageList.PageCount = pageList.RecordCount / pageList.PageSize;
			if ((double)pageList.PageCount < (double)pageList.RecordCount / (double)pageList.PageSize)
			{
				pageList.PageCount++;
			}
			if (this.int_0 > pageList.PageCount)
			{
				this.int_0 = pageList.PageCount;
			}
			pageList.PageID = this.int_0;
			this.textBox_0.Text = this.int_0.ToString();
			this.label_0.Text = pageList.PageCount.ToString();
			this.htmlGenericControl_5.InnerHtml = pageListBll.GetPageListVk(pageList);
			DataSet dataSet2 = shop_MessageBoard_Action.SearchMessageBoardListNew(this.MemLoginID, this.type, this.ordername, this.soft, this.ShowCount.ToString(), this.int_0.ToString(), "0");
			this.repeater_0.DataSource = dataSet2.Tables[0];
			this.repeater_0.DataBind();
			this.htmlGenericControl_0.Attributes.Remove("class");
			this.htmlGenericControl_1.Attributes.Remove("class");
			this.htmlGenericControl_2.Attributes.Remove("class");
			this.htmlGenericControl_3.Attributes.Remove("class");
			this.htmlGenericControl_4.Attributes.Remove("class");
			string type = this.type;
			if (type != null)
			{
				if (!(type == "0"))
				{
					if (!(type == "1"))
					{
						if (!(type == "2"))
						{
							if (!(type == "3"))
							{
								if (type == "")
								{
									this.htmlGenericControl_4.Attributes.Add("class", "selecttab");
								}
							}
							else
							{
								this.htmlGenericControl_3.Attributes.Add("class", "selecttab");
							}
						}
						else
						{
							this.htmlGenericControl_2.Attributes.Add("class", "selecttab");
						}
					}
					else
					{
						this.htmlGenericControl_1.Attributes.Add("class", "selecttab");
					}
				}
				else
				{
					this.htmlGenericControl_0.Attributes.Add("class", "selecttab");
				}
			}
		}
		public static string GetValue(object object_0)
		{
			string text = object_0.ToString();
			string result;
			if (text != null)
			{
				if (text == "0")
				{
					result = "询问";
					return result;
				}
				if (text == "1")
				{
					result = "求购";
					return result;
				}
				if (text == "2")
				{
					result = "售后";
					return result;
				}
				if (text == "3")
				{
					result = "其它";
					return result;
				}
			}
			result = "其它";
			return result;
		}
	}
}
