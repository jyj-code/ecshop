using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Control;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class ArticleComment : BaseWebControl
	{
		private string string_0 = "ArticleComment.ascx";
		private Repeater repeater_0;
		private CheckBox checkBox_0;
		private System.Web.UI.WebControls.Button button_0;
		private System.Web.UI.WebControls.TextBox textBox_0;
		private System.Web.UI.WebControls.TextBox textBox_1;
		private System.Web.UI.WebControls.TextBox textBox_2;
		private ShopNum1.Control.Calendar calendar_0;
		private ShopNum1.Control.Calendar calendar_1;
		private System.Web.UI.WebControls.DropDownList dropDownList_0;
		private System.Web.UI.WebControls.Button button_1;
		private Label label_0;
		private HyperLink hyperLink_0;
		private HyperLink hyperLink_1;
		private HyperLink hyperLink_2;
		private HyperLink hyperLink_3;
		private Literal literal_0;
		[CompilerGenerated]
		private string string_1;
		public string MemberLoginID
		{
			get;
			set;
		}
		public ArticleComment()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			if (this.Page.Request.Cookies["MemberLoginCookie"] == null)
			{
				this.Page.Response.Write("<script> window.alert(\"对不起，请重新登陆！\");  window.location.href='Login.aspx'</script>");
			}
			else
			{
				HttpCookie cookie = this.Page.Request.Cookies["MemberLoginCookie"];
				HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
				this.MemberLoginID = httpCookie.Values["MemLoginID"].ToString();
			}
			this.textBox_0 = (System.Web.UI.WebControls.TextBox)skin.FindControl("TextBoxTitle");
			this.calendar_0 = (ShopNum1.Control.Calendar)skin.FindControl("CalendarTime1");
			this.calendar_1 = (ShopNum1.Control.Calendar)skin.FindControl("CalendarTime2");
			this.textBox_1 = (System.Web.UI.WebControls.TextBox)skin.FindControl("TextBoxArticleTitle");
			this.textBox_2 = (System.Web.UI.WebControls.TextBox)skin.FindControl("TextBoxArticleMemLoginID");
			this.dropDownList_0 = (System.Web.UI.WebControls.DropDownList)skin.FindControl("DropDownListIsAudit");
			this.button_1 = (System.Web.UI.WebControls.Button)skin.FindControl("ButtonSearch");
			this.button_1.Click += new EventHandler(this.button_1_Click);
			this.button_0 = (System.Web.UI.WebControls.Button)skin.FindControl("ButtonSerchDetail");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.hyperLink_0 = (HyperLink)skin.FindControl("lnkPrev");
			this.hyperLink_1 = (HyperLink)skin.FindControl("lnkFirst");
			this.hyperLink_2 = (HyperLink)skin.FindControl("lnkNext");
			this.hyperLink_3 = (HyperLink)skin.FindControl("lnkLast");
			this.label_0 = (Label)skin.FindControl("LabelPageMessage");
			this.literal_0 = (Literal)skin.FindControl("lnkTo");
			this.checkBox_0 = (CheckBox)skin.FindControl("CheckAll");
			this.checkBox_0.CheckedChanged += new EventHandler(this.checkBox_0_CheckedChanged);
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterShow");
			this.method_0();
		}
		private void button_1_Click(object sender, EventArgs e)
		{
			this.method_0();
		}
		private void checkBox_0_CheckedChanged(object sender, EventArgs e)
		{
			foreach (RepeaterItem repeaterItem in this.repeater_0.Items)
			{
				CheckBox checkBox = repeaterItem.FindControl("checkboxAll") as CheckBox;
				if (this.checkBox_0.Checked)
				{
					checkBox.Checked = true;
				}
				else
				{
					checkBox.Checked = false;
				}
			}
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			ShopNum1_ArticleComment_Action arg_0A_0 = (ShopNum1_ArticleComment_Action)LogicFactory.CreateShopNum1_ArticleComment_Action();
			int num = 0;
			string text = string.Empty;
			foreach (RepeaterItem repeaterItem in this.repeater_0.Items)
			{
				CheckBox checkBox = repeaterItem.FindControl("checkboxAll") as CheckBox;
				if (checkBox.Checked)
				{
					HtmlGenericControl htmlGenericControl = repeaterItem.FindControl("guid") as HtmlGenericControl;
					if (text != string.Empty)
					{
						text = text + ",'" + htmlGenericControl.InnerText + "'";
						num++;
					}
					else
					{
						text = text + "'" + htmlGenericControl.InnerText + "'";
						num++;
					}
				}
			}
			if (text == string.Empty)
			{
				MessageBox.Show("请选择要操作的对象！");
			}
			else if (text.IndexOf(',') != -1 || num > 1)
			{
				MessageBox.Show("您每次只能选中一条记录！");
			}
			else
			{
				this.Page.Response.Redirect("MemberArticleCommentDetail.aspx?guid=" + text);
			}
		}
		private void method_0()
		{
			string commenttitle = this.returnTextvalue(this.textBox_0).Trim();
			string articletitle = this.returnTextvalue(this.textBox_1).Trim();
			string createtime = (this.calendar_0.SelectedText == "") ? "-1" : this.calendar_0.SelectedText;
			string createtime2 = (this.calendar_1.SelectedText == "") ? "-1" : this.calendar_1.SelectedText;
			ShopNum1_ArticleComment_Action shopNum1_ArticleComment_Action = (ShopNum1_ArticleComment_Action)LogicFactory.CreateShopNum1_ArticleComment_Action();
			DataTable dataTable = shopNum1_ArticleComment_Action.SearchArticleCommentInfo(this.MemberLoginID, commenttitle, articletitle, this.dropDownList_0.SelectedValue, createtime, createtime2);
			PagedDataSource pagedDataSource = new PagedDataSource();
			pagedDataSource.DataSource = dataTable.DefaultView;
			pagedDataSource.AllowPaging = true;
			ShopSettings shopSettings = new ShopSettings();
			string value = shopSettings.GetValue(this.Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), "MArticleCommentCount");
			try
			{
				pagedDataSource.PageSize = Convert.ToInt32(value);
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
		public string returnTextvalue(System.Web.UI.WebControls.TextBox textBox)
		{
			string result;
			if (string.IsNullOrEmpty(textBox.Text))
			{
				result = "-1";
			}
			else
			{
				result = Operator.FilterString(textBox.Text);
			}
			return result;
		}
	}
}
