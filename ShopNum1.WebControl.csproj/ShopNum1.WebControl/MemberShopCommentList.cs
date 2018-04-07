using ShopNum1.BusinessLogic;
using ShopNum1.Common;
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
	public class MemberShopCommentList : BaseWebControl
	{
		private string string_0 = "MemberShopCommentList.ascx";
		private TextBox textBox_0;
		private TextBox textBox_1;
		private TextBox textBox_2;
		private TextBox textBox_3;
		private TextBox textBox_4;
		private DropDownList dropDownList_0;
		private Button button_0;
		private Repeater repeater_0;
		private Button button_1;
		private Button button_2;
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
		public string MemLoginID
		{
			get;
			set;
		}
		public MemberShopCommentList()
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
				this.Page.Response.Redirect("Login.aspx");
			}
			else
			{
				HttpCookie cookie = this.Page.Request.Cookies["MemberLoginCookie"];
				HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
				this.MemLoginID = httpCookie.Values["MemLoginID"].ToString();
			}
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxTitle");
			this.textBox_3 = (TextBox)skin.FindControl("TextBoxTime1");
			this.textBox_4 = (TextBox)skin.FindControl("TextBoxTime2");
			this.textBox_1 = (TextBox)skin.FindControl("TextBoxShopName");
			this.textBox_2 = (TextBox)skin.FindControl("TextBoxCreateMerber");
			this.dropDownList_0 = (DropDownList)skin.FindControl("DropDownListIsAudit");
			this.button_0 = (Button)skin.FindControl("ButtonSearch");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.hyperLink_0 = (HyperLink)skin.FindControl("lnkPrev");
			this.hyperLink_1 = (HyperLink)skin.FindControl("lnkFirst");
			this.hyperLink_2 = (HyperLink)skin.FindControl("lnkNext");
			this.hyperLink_3 = (HyperLink)skin.FindControl("lnkLast");
			this.label_0 = (Label)skin.FindControl("LabelPageMessage");
			this.literal_0 = (Literal)skin.FindControl("lnkTo");
			this.checkBox_0 = (CheckBox)skin.FindControl("CheckAll");
			this.checkBox_0.CheckedChanged += new EventHandler(this.checkBox_0_CheckedChanged);
			this.button_1 = (Button)skin.FindControl("ButtonDelete");
			this.button_1.Click += new EventHandler(this.button_1_Click);
			this.button_2 = (Button)skin.FindControl("ButtonSerchDetail");
			this.button_2.Click += new EventHandler(this.button_2_Click);
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterShow");
			if (this.Page.IsPostBack)
			{
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
			}
			else if (num > 1)
			{
				MessageBox.Show("每次只能选择一条记录！");
			}
		}
		private void button_1_Click(object sender, EventArgs e)
		{
			ShopNum1_ProductComment_Action shopNum1_ProductComment_Action = (ShopNum1_ProductComment_Action)LogicFactory.CreateShopNum1_ProductComment_Action();
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
					int num = shopNum1_ProductComment_Action.DeleteProductComment(text);
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
			ShopNum1_ProductComment_Action shopNum1_ProductComment_Action = (ShopNum1_ProductComment_Action)LogicFactory.CreateShopNum1_ProductComment_Action();
			string commenttitle = this.returnTextvalue(this.textBox_0);
			string productname = this.returnTextvalue(this.textBox_1);
			string shopID = this.returnTextvalue(this.textBox_2);
			string createtime = this.returnTextvalue(this.textBox_3);
			string createtime2 = this.returnTextvalue(this.textBox_4);
			DataTable dataTable = shopNum1_ProductComment_Action.MemberProductComment(this.MemLoginID, commenttitle, productname, shopID, this.dropDownList_0.SelectedValue, createtime, createtime2);
			PagedDataSource pagedDataSource = new PagedDataSource();
			pagedDataSource.DataSource = dataTable.DefaultView;
			pagedDataSource.AllowPaging = true;
			pagedDataSource.PageSize = this.PageCount;
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
				Label label = (Label)this.repeater_0.Items[i].FindControl("LabelIsAudit");
				if (dataTable.Rows[i]["IsAudit"].ToString() == "0")
				{
					label.Text = "未审核";
				}
				else
				{
					label.Text = "已审核";
				}
			}
		}
		public string returnTextvalue(TextBox textBox)
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
