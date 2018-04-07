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
	public class MemberCategoryCommentList : BaseWebControl
	{
		private string string_0 = "MemberCategoryCommentList.ascx";
		private System.Web.UI.WebControls.TextBox textBox_0;
		private System.Web.UI.WebControls.TextBox textBox_1;
		private System.Web.UI.WebControls.TextBox textBox_2;
		private ShopNum1.Control.Calendar calendar_0;
		private ShopNum1.Control.Calendar calendar_1;
		private System.Web.UI.WebControls.DropDownList dropDownList_0;
		private System.Web.UI.WebControls.Button button_0;
		private Repeater repeater_0;
		private System.Web.UI.WebControls.Button button_1;
		private System.Web.UI.WebControls.Button button_2;
		private CheckBox checkBox_0;
		private Label label_0;
		private HyperLink hyperLink_0;
		private HyperLink hyperLink_1;
		private HyperLink hyperLink_2;
		private HyperLink hyperLink_3;
		private Literal literal_0;
		private HiddenField hiddenField_0;
		[CompilerGenerated]
		private int int_0;
		[CompilerGenerated]
		private string string_1;
		public int PageCount
		{
			get;
			set;
		}
		public string strMemLoginID
		{
			get;
			set;
		}
		public MemberCategoryCommentList()
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
				GetUrl.RedirectTopLogin();
			}
			else
			{
				HttpCookie cookie = this.Page.Request.Cookies["MemberLoginCookie"];
				HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
				this.strMemLoginID = httpCookie.Values["MemLoginID"].ToString();
				this.textBox_0 = (System.Web.UI.WebControls.TextBox)skin.FindControl("TextBoxTitle");
				this.calendar_0 = (ShopNum1.Control.Calendar)skin.FindControl("CalendarTime1");
				this.calendar_1 = (ShopNum1.Control.Calendar)skin.FindControl("CalendarTime2");
				this.textBox_1 = (System.Web.UI.WebControls.TextBox)skin.FindControl("TextBoxCategoryName");
				this.textBox_2 = (System.Web.UI.WebControls.TextBox)skin.FindControl("TextBoxCategoryInfoMerberID");
				this.dropDownList_0 = (System.Web.UI.WebControls.DropDownList)skin.FindControl("DropDownListIsAudit");
				this.button_0 = (System.Web.UI.WebControls.Button)skin.FindControl("ButtonSearch");
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
				if (this.Page.IsPostBack)
				{
				}
				this.button_1 = (System.Web.UI.WebControls.Button)skin.FindControl("ButtonDelete");
				this.button_1.Click += new EventHandler(this.button_1_Click);
				this.button_2 = (System.Web.UI.WebControls.Button)skin.FindControl("ButtonSerchDetail");
				this.button_2.Click += new EventHandler(this.button_2_Click);
				this.method_0();
			}
		}
		private void button_2_Click(object sender, EventArgs e)
		{
			string text = string.Empty;
			int num = 0;
			foreach (RepeaterItem repeaterItem in this.repeater_0.Items)
			{
				CheckBox checkBox = repeaterItem.FindControl("checkboxAll") as CheckBox;
				if (checkBox.Checked)
				{
					HtmlGenericControl htmlGenericControl = repeaterItem.FindControl("guid") as HtmlGenericControl;
					text = htmlGenericControl.InnerText;
					num++;
				}
			}
			if (num == 0)
			{
				MessageBox.Show("请选择要查看的评论！");
			}
			else if (num == 1)
			{
				text = text.Replace("\n", "");
				ShopNum1_CategoryComment_Action shopNum1_CategoryComment_Action = (ShopNum1_CategoryComment_Action)LogicFactory.CreateShopNum1_CategoryComment_Action();
				string categoryGuid = shopNum1_CategoryComment_Action.GetCategoryGuid("'" + text + "'");
				this.Page.Response.Redirect("MemberCategoryCommentDetail.aspx?guid=" + categoryGuid);
			}
			else if (num > 1)
			{
				MessageBox.Show("每次只能选择一条记录！");
			}
		}
		private void button_1_Click(object sender, EventArgs e)
		{
			ShopNum1_CategoryComment_Action shopNum1_CategoryComment_Action = (ShopNum1_CategoryComment_Action)LogicFactory.CreateShopNum1_CategoryComment_Action();
			try
			{
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
						}
						else
						{
							text = text + "'" + htmlGenericControl.InnerText + "'";
						}
					}
				}
				if (text == string.Empty)
				{
					MessageBox.Show("请选择您要删除的记录!");
				}
				else
				{
					int num = shopNum1_CategoryComment_Action.DeleteCategoryComment(text);
					if (num > 0)
					{
						MessageBox.Show("删除成功");
						this.method_0();
					}
				}
			}
			catch
			{
			}
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
			this.method_0();
		}
		private void method_0()
		{
			string commenttitle = this.returnTextvalue(this.textBox_0).Trim();
			string categorytitle = this.returnTextvalue(this.textBox_1).Trim();
			string categoryInfoMerberID = this.returnTextvalue(this.textBox_2).Trim();
			string createtime = (this.calendar_0.SelectedText == "") ? "-1" : this.calendar_0.SelectedText;
			string createtime2 = (this.calendar_1.SelectedText == "") ? "-1" : this.calendar_1.SelectedText;
			ShopNum1_CategoryComment_Action shopNum1_CategoryComment_Action = (ShopNum1_CategoryComment_Action)LogicFactory.CreateShopNum1_CategoryComment_Action();
			DataTable dataTable = shopNum1_CategoryComment_Action.MemberCategoryComment(this.strMemLoginID, commenttitle, categorytitle, categoryInfoMerberID, this.dropDownList_0.SelectedValue, createtime, createtime2);
			PagedDataSource pagedDataSource = new PagedDataSource();
			pagedDataSource.DataSource = dataTable.DefaultView;
			pagedDataSource.AllowPaging = true;
			ShopSettings shopSettings = new ShopSettings();
			string value = shopSettings.GetValue(this.Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), "MCategoryCommentCount");
			pagedDataSource.PageSize = Convert.ToInt32(value);
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
