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
namespace ShopNum1.ShopNewWebControl
{
	[ParseChildren(true)]
	public class ShopComment : BaseWebControl
	{
		private string string_0 = "ShopCommentNew.ascx";
		private LinkButton linkButton_0;
		private LinkButton linkButton_1;
		private LinkButton linkButton_2;
		private LinkButton linkButton_3;
		private LinkButton linkButton_4;
		private HtmlGenericControl htmlGenericControl_0;
		private HtmlGenericControl htmlGenericControl_1;
		private HtmlGenericControl htmlGenericControl_2;
		private HtmlGenericControl htmlGenericControl_3;
		private Repeater repeater_0;
		private Label label_0;
		private HtmlGenericControl htmlGenericControl_4;
		private Label label_1;
		private TextBox textBox_0;
		private Button button_0;
		private string string_1 = GetPageName.AgentGetPage("");
		private int int_0;
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		[CompilerGenerated]
		private int int_1;
		[CompilerGenerated]
		private string string_4;
		[CompilerGenerated]
		private string string_5;
		private string MemLoginID
		{
			get;
			set;
		}
		private string ShopID
		{
			get;
			set;
		}
		public int ShowCount
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
		public ShopComment()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.htmlGenericControl_4 = (HtmlGenericControl)skin.FindControl("pageDiv");
			this.label_1 = (Label)skin.FindControl("LabelPageCount");
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
			this.ordername = ((this.Page.Request.QueryString["ordername"] == null) ? "a.CommentTime" : this.Page.Request.QueryString["ordername"].ToString());
			this.soft = ((this.Page.Request.QueryString["sort"] == null) ? "desc" : this.Page.Request.QueryString["sort"].ToString());
			this.linkButton_0 = (LinkButton)skin.FindControl("LinkButtonAll");
			this.linkButton_0.Click += new EventHandler(this.linkButton_0_Click);
			this.linkButton_1 = (LinkButton)skin.FindControl("LinkButtonGood");
			this.linkButton_1.Click += new EventHandler(this.linkButton_1_Click);
			this.linkButton_2 = (LinkButton)skin.FindControl("LinkButtonGeneral");
			this.linkButton_2.Click += new EventHandler(this.linkButton_2_Click);
			this.linkButton_3 = (LinkButton)skin.FindControl("LinkButtonBad");
			this.linkButton_3.Click += new EventHandler(this.linkButton_3_Click);
			this.linkButton_4 = (LinkButton)skin.FindControl("LinkButton");
			this.linkButton_4.Click += new EventHandler(this.linkButton_4_Click);
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterShow");
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("All");
			this.htmlGenericControl_1 = (HtmlGenericControl)skin.FindControl("Good");
			this.htmlGenericControl_2 = (HtmlGenericControl)skin.FindControl("General");
			this.htmlGenericControl_3 = (HtmlGenericControl)skin.FindControl("Bad");
			this.method_1(string.Empty);
		}
		private void linkButton_4_Click(object sender, EventArgs e)
		{
			this.method_1("0");
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
		private void linkButton_3_Click(object sender, EventArgs e)
		{
			this.method_1("1");
			this.method_0(this.htmlGenericControl_3);
		}
		private void linkButton_2_Click(object sender, EventArgs e)
		{
			this.method_1("3");
			this.method_0(this.htmlGenericControl_2);
		}
		private void linkButton_1_Click(object sender, EventArgs e)
		{
			this.method_1("5");
			this.method_0(this.htmlGenericControl_1);
		}
		private void linkButton_0_Click(object sender, EventArgs e)
		{
			this.method_1(string.Empty);
			this.method_0(this.htmlGenericControl_0);
		}
		private void method_0(HtmlGenericControl htmlGenericControl_5)
		{
			this.htmlGenericControl_0.Style.Remove("background");
			this.htmlGenericControl_1.Style.Remove("background");
			this.htmlGenericControl_2.Style.Remove("background");
			this.htmlGenericControl_3.Style.Remove("background");
			htmlGenericControl_5.Style.Add("background", "#fff");
		}
		private void method_1(string string_6)
		{
			string text = (this.Page.Request.QueryString["ShopID"].ToString() == null) ? "0" : this.Page.Request.QueryString["ShopID"].ToString();
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = new ShopNum1_ShopInfoList_Action();
			this.MemLoginID = shopNum1_ShopInfoList_Action.GetShopMemLoginIdByShopID(text).ToString();
			Shop_ProductComment_Action shop_ProductComment_Action = (Shop_ProductComment_Action)LogicFactory.CreateShop_ProductComment_Action();
			PageList1 pageList = new PageList1();
			pageList.PageSize = this.ShowCount;
			pageList.PageID = this.int_0;
			DataSet dataSet = shop_ProductComment_Action.ShopCommentNew(text, string_6, this.ordername, this.soft, this.ShowCount.ToString(), this.int_0.ToString(), "1");
			if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
			{
				pageList.RecordCount = Convert.ToInt32(dataSet.Tables[0].Rows[0][0]);
			}
			else
			{
				pageList.RecordCount = 0;
			}
			PageListBll pageListBll = new PageListBll("ShopComment", true);
			pageListBll.ShowPageCount = false;
			pageListBll.ShowPageIndex = false;
			pageListBll.ShowRecordCount = false;
			pageListBll.ShowNoRecordInfo = false;
			pageListBll.ShowNumListButton = true;
			pageListBll.PrevPageText = "上一页";
			pageListBll.NextPageText = "下一页 ";
			this.textBox_0.Text = this.int_0.ToString();
			this.htmlGenericControl_4.InnerHtml = pageListBll.GetPageListVk(pageList);
			this.label_1.Text = pageList.PageCount.ToString();
			if ((double)pageList.PageCount < (double)pageList.RecordCount / (double)pageList.PageSize)
			{
				pageList.PageCount++;
			}
			if (this.int_0 > pageList.PageCount)
			{
				this.int_0 = pageList.PageCount;
			}
			DataSet dataSet2 = shop_ProductComment_Action.ShopCommentNew(text, string_6, this.ordername, this.soft, this.ShowCount.ToString(), this.int_0.ToString(), "0");
			this.repeater_0.DataSource = dataSet2.Tables[0];
			this.repeater_0.DataBind();
			for (int i = 0; i < this.repeater_0.Items.Count; i++)
			{
				this.label_0 = (Label)this.repeater_0.Items[i].FindControl("LabelCommentType");
				string text2 = dataSet2.Tables[0].Rows[i]["CommentType"].ToString();
				if (text2 != null)
				{
					if (!(text2 == "5"))
					{
						if (!(text2 == "3"))
						{
							if (text2 == "1")
							{
								this.label_0.Text = "差评";
							}
						}
						else
						{
							this.label_0.Text = "中评";
						}
					}
					else
					{
						this.label_0.Text = "好评";
					}
				}
			}
		}
	}
}
