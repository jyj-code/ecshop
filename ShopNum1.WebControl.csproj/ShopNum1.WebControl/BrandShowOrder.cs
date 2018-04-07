using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class BrandShowOrder : BaseWebControl
	{
		private string string_0 = "BrandShowOrder.ascx";
		private Label label_0;
		private Repeater repeater_0;
		private Repeater repeater_1;
		private Repeater repeater_2;
		private ImageButton imageButton_0;
		private ImageButton imageButton_1;
		private ImageButton imageButton_2;
		private DropDownList dropDownList_0;
		private DropDownList dropDownList_1;
		private Label label_1;
		private HyperLink hyperLink_0;
		private HyperLink hyperLink_1;
		private HyperLink hyperLink_2;
		private HyperLink hyperLink_3;
		private Literal literal_0;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		public string BrandGuid
		{
			get;
			set;
		}
		public string PageShowCount
		{
			get;
			set;
		}
		public BrandShowOrder()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.label_0 = (Label)skin.FindControl("LabelBrandName");
			this.repeater_0 = (Repeater)skin.FindControl("Repeater1");
			this.repeater_1 = (Repeater)skin.FindControl("Repeater2");
			this.repeater_2 = (Repeater)skin.FindControl("Repeater3");
			this.imageButton_0 = (ImageButton)skin.FindControl("ImageButtonList");
			this.imageButton_1 = (ImageButton)skin.FindControl("ImageButtonGrid");
			this.imageButton_2 = (ImageButton)skin.FindControl("ImageButtontext");
			this.hyperLink_0 = (HyperLink)skin.FindControl("lnkPrev");
			this.hyperLink_1 = (HyperLink)skin.FindControl("lnkFirst");
			this.hyperLink_2 = (HyperLink)skin.FindControl("lnkNext");
			this.hyperLink_3 = (HyperLink)skin.FindControl("lnkLast");
			this.label_1 = (Label)skin.FindControl("LabelPageMessage");
			this.literal_0 = (Literal)skin.FindControl("lnkTo");
			this.imageButton_1.Click += new ImageClickEventHandler(this.imageButton_1_Click);
			this.imageButton_0.Click += new ImageClickEventHandler(this.imageButton_0_Click);
			this.imageButton_2.Click += new ImageClickEventHandler(this.imageButton_2_Click);
			this.dropDownList_0 = (DropDownList)skin.FindControl("DropDownListSort1");
			this.dropDownList_0.SelectedIndexChanged += new EventHandler(this.dropDownList_0_SelectedIndexChanged);
			this.dropDownList_1 = (DropDownList)skin.FindControl("DropDownListSort2");
			this.dropDownList_1.SelectedIndexChanged += new EventHandler(this.dropDownList_1_SelectedIndexChanged);
			if (ShopNum1.Common.Common.ReqStr("guid") != null)
			{
				this.BrandGuid = ShopNum1.Common.Common.ReqStr("guid");
			}
			else
			{
				this.BrandGuid = "-1";
			}
			if (this.ViewState["ShowStyle"] == null)
			{
				this.ViewState["ShowStyle"] = "Grid";
			}
			this.method_0(this.ViewState["ShowStyle"].ToString());
		}
		private void dropDownList_0_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.method_0(this.ViewState["ShowStyle"].ToString());
		}
		private void dropDownList_1_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.method_0(this.ViewState["ShowStyle"].ToString());
		}
		private void imageButton_2_Click(object sender, ImageClickEventArgs e)
		{
			this.ViewState["ShowStyle"] = "Text";
			this.method_0("Text");
		}
		private void imageButton_1_Click(object sender, ImageClickEventArgs e)
		{
			this.ViewState["ShowStyle"] = "Grid";
			this.method_0("Grid");
		}
		private void imageButton_0_Click(object sender, ImageClickEventArgs e)
		{
			this.ViewState["ShowStyle"] = "List";
			this.method_0("List");
		}
		private void method_0(string string_3)
		{
			ShopNum1_Brand_Action shopNum1_Brand_Action = (ShopNum1_Brand_Action)LogicFactory.CreateShopNum1_Brand_Action();
			DataTable dataTable = shopNum1_Brand_Action.SearchProductByBrandGuid(this.BrandGuid, this.dropDownList_0.SelectedValue, this.dropDownList_1.SelectedValue);
			if (dataTable.Rows.Count > 0)
			{
				this.label_0.Text = dataTable.Rows[0]["BrandName"].ToString();
			}
			PagedDataSource pagedDataSource = new PagedDataSource();
			pagedDataSource.DataSource = dataTable.DefaultView;
			pagedDataSource.AllowPaging = true;
			if (Operator.FormatToEmpty(this.PageShowCount) == string.Empty)
			{
				pagedDataSource.PageSize = 8;
			}
			else
			{
				pagedDataSource.PageSize = Convert.ToInt32(this.PageShowCount);
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
			this.label_1.Text = num1WebControlCommon.GetPageMessage(pagedDataSource.DataSourceCount, pagedDataSource.PageCount, pagedDataSource.PageSize, num);
			string otherParam = "&&BrandGuid=" + this.BrandGuid + "&&ShowStyle=" + string_3;
			this.literal_0.Text = num1WebControlCommon.AppendPage(this.Page, pagedDataSource.PageCount, num, otherParam);
			this.hyperLink_0.NavigateUrl = GetPageName.GetPage(string.Concat(new object[]
			{
				"?Page=",
				Convert.ToInt32(num - 1),
				"&&BrandGuid=",
				this.BrandGuid,
				"&&ShowStyle=",
				string_3
			}));
			this.hyperLink_1.NavigateUrl = GetPageName.GetPage("?Page=1&&BrandGuid=" + this.BrandGuid + "&&ShowStyle=" + string_3);
			this.hyperLink_2.NavigateUrl = GetPageName.GetPage(string.Concat(new object[]
			{
				"?Page=",
				Convert.ToInt32(num + 1),
				"&&BrandGuid=",
				this.BrandGuid,
				"&&ShowStyle=",
				string_3
			}));
			this.hyperLink_3.NavigateUrl = GetPageName.GetPage(string.Concat(new object[]
			{
				"?Page=",
				pagedDataSource.PageCount,
				"&&BrandGuid=",
				this.BrandGuid,
				"&&ShowStyle=",
				string_3
			}));
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
			if (string_3.ToLower() == "Grid".ToLower())
			{
				this.repeater_0.Visible = true;
				this.repeater_1.Visible = false;
				this.repeater_2.Visible = false;
				this.repeater_0.DataSource = pagedDataSource;
				this.repeater_0.DataBind();
			}
			else if (string_3.ToLower() == "List".ToLower())
			{
				this.repeater_1.Visible = true;
				this.repeater_0.Visible = false;
				this.repeater_2.Visible = false;
				this.repeater_1.DataSource = pagedDataSource;
				this.repeater_1.DataBind();
			}
			else if (string_3.ToLower() == "Text".ToLower())
			{
				this.repeater_1.Visible = false;
				this.repeater_0.Visible = false;
				this.repeater_2.Visible = true;
				this.repeater_2.DataSource = pagedDataSource;
				this.repeater_2.DataBind();
			}
		}
	}
}
