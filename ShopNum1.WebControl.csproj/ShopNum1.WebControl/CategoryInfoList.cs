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
	public class CategoryInfoList : BaseWebControl
	{
		private string string_0 = "CategoryInfoList.ascx";
		private Repeater repeater_0;
		private Button button_0;
		private Button button_1;
		private Button button_2;
		private CheckBox checkBox_0;
		private Label label_0;
		private HyperLink hyperLink_0;
		private HyperLink hyperLink_1;
		private HyperLink hyperLink_2;
		private HyperLink hyperLink_3;
		private Literal literal_0;
		[CompilerGenerated]
		private int int_0;
		[CompilerGenerated]
		private string string_1;
		public int ShowCount
		{
			get;
			set;
		}
		public string MemberLoginID
		{
			get;
			set;
		}
		public CategoryInfoList()
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
			this.button_0 = (Button)skin.FindControl("ButtonDelete");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.button_0.Attributes.Add("onclick", "javascript:return confirm('您确认要删除吗?')");
			this.button_1 = (Button)skin.FindControl("ButtonAdd");
			this.button_1.Click += new EventHandler(this.button_1_Click);
			this.button_2 = (Button)skin.FindControl("ButtonEdit");
			this.button_2.Click += new EventHandler(this.button_2_Click);
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
			ShopNum1_CategoryChecked_Action shopNum1_CategoryChecked_Action = (ShopNum1_CategoryChecked_Action)LogicFactory.CreateShopNum1_CategoryChecked_Action();
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
					int num = shopNum1_CategoryChecked_Action.Delete(text);
					if (num > 0)
					{
						this.method_0();
					}
				}
			}
			catch
			{
			}
		}
		private void method_0()
		{
			ShopNum1_CategoryChecked_Action shopNum1_CategoryChecked_Action = (ShopNum1_CategoryChecked_Action)LogicFactory.CreateShopNum1_CategoryChecked_Action();
			DataTable dataTable = shopNum1_CategoryChecked_Action.SearchCategoryInfo(this.MemberLoginID, "-1");
			PagedDataSource pagedDataSource = new PagedDataSource();
			pagedDataSource.DataSource = dataTable.DefaultView;
			pagedDataSource.AllowPaging = true;
			this.ShowCount = 10;
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
		private void button_1_Click(object sender, EventArgs e)
		{
			this.Page.Response.Redirect("CategoryInfoOperate.aspx");
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
				MessageBox.Show("请选择您要编辑的记录！");
			}
			else if (num == 1)
			{
				text = text.Trim().Replace("\n", "");
				this.Page.Response.Redirect("CategoryInfoOperate.aspx?guid=" + text);
			}
			else if (num > 1)
			{
				MessageBox.Show("请每次只能选择一个记录编辑！");
			}
		}
	}
}
