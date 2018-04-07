using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopWebControl
{
	[ParseChildren(true)]
	public class ShopComment : BaseWebControl
	{
		private string string_0 = "ShopComment.ascx";
		private LinkButton linkButton_0;
		private LinkButton linkButton_1;
		private LinkButton linkButton_2;
		private LinkButton linkButton_3;
		private HtmlGenericControl htmlGenericControl_0;
		private HtmlGenericControl htmlGenericControl_1;
		private HtmlGenericControl htmlGenericControl_2;
		private HtmlGenericControl htmlGenericControl_3;
		private Repeater repeater_0;
		private Label label_0;
		private HyperLink hyperLink_0;
		private HyperLink hyperLink_1;
		private HyperLink hyperLink_2;
		private HyperLink hyperLink_3;
		private Literal literal_0;
		public ShopComment()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.linkButton_0 = (LinkButton)skin.FindControl("LinkButtonAll");
			this.linkButton_0.Click += new EventHandler(this.linkButton_0_Click);
			this.linkButton_1 = (LinkButton)skin.FindControl("LinkButtonGood");
			this.linkButton_1.Click += new EventHandler(this.linkButton_1_Click);
			this.linkButton_2 = (LinkButton)skin.FindControl("LinkButtonGeneral");
			this.linkButton_2.Click += new EventHandler(this.linkButton_2_Click);
			this.linkButton_3 = (LinkButton)skin.FindControl("LinkButtonBad");
			this.linkButton_3.Click += new EventHandler(this.linkButton_3_Click);
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterShow");
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("All");
			this.htmlGenericControl_1 = (HtmlGenericControl)skin.FindControl("Good");
			this.htmlGenericControl_2 = (HtmlGenericControl)skin.FindControl("General");
			this.htmlGenericControl_3 = (HtmlGenericControl)skin.FindControl("Bad");
			this.hyperLink_0 = (HyperLink)skin.FindControl("lnkPrev");
			this.hyperLink_1 = (HyperLink)skin.FindControl("lnkFirst");
			this.hyperLink_2 = (HyperLink)skin.FindControl("lnkNext");
			this.hyperLink_3 = (HyperLink)skin.FindControl("lnkLast");
			this.label_0 = (Label)skin.FindControl("LabelPageMessage");
			this.literal_0 = (Literal)skin.FindControl("lnkTo");
			this.method_1(string.Empty);
		}
		private void linkButton_3_Click(object sender, EventArgs e)
		{
			this.method_1("2");
			this.method_0(this.htmlGenericControl_3);
		}
		private void linkButton_2_Click(object sender, EventArgs e)
		{
			this.method_1("1");
			this.method_0(this.htmlGenericControl_2);
		}
		private void linkButton_1_Click(object sender, EventArgs e)
		{
			this.method_1("0");
			this.method_0(this.htmlGenericControl_1);
		}
		private void linkButton_0_Click(object sender, EventArgs e)
		{
			this.method_1(string.Empty);
			this.method_0(this.htmlGenericControl_0);
		}
		private void method_0(HtmlGenericControl htmlGenericControl_4)
		{
			this.htmlGenericControl_0.Style.Remove("background");
			this.htmlGenericControl_1.Style.Remove("background");
			this.htmlGenericControl_2.Style.Remove("background");
			this.htmlGenericControl_3.Style.Remove("background");
			htmlGenericControl_4.Style.Add("background", "#fff");
		}
		private void method_1(string string_1)
		{
			string s = ShopSettings.GetValue("ProductCommentPageCount");
			try
			{
				int.Parse(s);
			}
			catch
			{
				s = "10";
			}
			string text = (this.Page.Request.QueryString["ShopID"].ToString() == null) ? "0" : this.Page.Request.QueryString["ShopID"].ToString();
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = new ShopNum1_ShopInfoList_Action();
			shopNum1_ShopInfoList_Action.GetShopMemLoginIdByShopID(text).ToString();
			Shop_ProductComment_Action shop_ProductComment_Action = (Shop_ProductComment_Action)LogicFactory.CreateShop_ProductComment_Action();
			DataTable dataTable = shop_ProductComment_Action.ShopComment(string_1, text);
			if (dataTable == null || dataTable.Rows.Count == 0)
			{
				this.repeater_0.DataSource = null;
				this.repeater_0.DataBind();
			}
			else
			{
				PagedDataSource pagedDataSource = new PagedDataSource();
				pagedDataSource.DataSource = dataTable.DefaultView;
				pagedDataSource.AllowPaging = true;
				if (int.Parse(s) < 1)
				{
					pagedDataSource.PageSize = 10;
				}
				else
				{
					pagedDataSource.PageSize = int.Parse(s);
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
				for (int i = 0; i < this.repeater_0.Items.Count; i++)
				{
					Label label = (Label)this.repeater_0.Items[i].FindControl("LabelCommentType");
					string text2 = dataTable.Rows[i]["CommentType"].ToString();
					if (text2 != null)
					{
						if (!(text2 == "5"))
						{
							if (!(text2 == "3"))
							{
								if (text2 == "1")
								{
									label.Text = "差评";
								}
							}
							else
							{
								label.Text = "中评";
							}
						}
						else
						{
							label.Text = "好评";
						}
					}
				}
			}
		}
	}
}
