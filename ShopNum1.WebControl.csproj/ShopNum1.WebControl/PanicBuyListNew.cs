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
	public class PanicBuyListNew : BaseWebControl
	{
		private string string_0 = "PanicBuyList.ascx";
		private Repeater repeater_0;
		private LinkButton linkButton_0;
		private LinkButton linkButton_1;
		private Label label_0;
		private Label label_1;
		private Label label_2;
		private string string_1 = "all";
		private int int_0 = 1;
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		[CompilerGenerated]
		private string string_4;
		public string PageCount
		{
			get;
			set;
		}
		public string CategoryCode
		{
			get;
			set;
		}
		protected string OtherPage
		{
			get;
			set;
		}
		public PanicBuyListNew()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			this.linkButton_0 = (LinkButton)skin.FindControl("LinkButtonNext");
			this.linkButton_0.Click += new EventHandler(this.linkButton_0_Click);
			this.linkButton_1 = (LinkButton)skin.FindControl("LinkButtonLast");
			this.linkButton_1.Click += new EventHandler(this.linkButton_1_Click);
			this.label_0 = (Label)skin.FindControl("LabelCount");
			this.label_2 = (Label)skin.FindControl("LabelPageCount");
			this.label_1 = (Label)skin.FindControl("LabelIndex");
			if (this.Page.Request.QueryString["SubstationID"] != null && !string.IsNullOrEmpty(this.Page.Request.QueryString["SubstationID"].ToString()))
			{
				this.string_1 = this.Page.Request.QueryString["SubstationID"].ToString();
			}
			if (this.Page.Request.QueryString["pindex"] != null)
			{
				this.label_1.Text = this.Page.Request.QueryString["pindex"].ToString();
				this.int_0 = Convert.ToInt32(this.Page.Request.QueryString["pindex"].ToString());
			}
			else
			{
				this.label_1.Text = "1";
				this.int_0 = 1;
			}
			this.PanicBuyDataBind(this.int_0);
		}
		private void linkButton_1_Click(object sender, EventArgs e)
		{
			if (this.int_0 == 2)
			{
				this.label_1.Text = "1";
				this.linkButton_1.Enabled = false;
				this.linkButton_1.CssClass = "page_up";
				this.int_0 = 1;
			}
			else
			{
				this.linkButton_0.Enabled = true;
				this.linkButton_0.CssClass = "page_down";
				this.label_1.Text = (this.int_0 - 1).ToString();
				this.int_0--;
			}
			this.Page.Response.Redirect(string.Concat(new object[]
			{
				"http://",
				ShopSettings.siteDomain,
				"/Main/panicbuylist.aspx?tag=7&pindex=",
				this.int_0
			}));
		}
		private void linkButton_0_Click(object sender, EventArgs e)
		{
			if (int.Parse(this.label_1.Text) == int.Parse(this.label_2.Text) - 1)
			{
				this.label_1.Text = (int.Parse(this.label_1.Text) + 1).ToString();
				this.int_0 = int.Parse(this.label_1.Text);
				this.linkButton_0.Enabled = false;
				this.linkButton_0.CssClass = "page_down_false";
			}
			else if (this.label_2.Text == this.label_1.Text)
			{
				this.linkButton_1.Enabled = false;
				this.linkButton_0.Enabled = true;
			}
			else
			{
				this.linkButton_1.Enabled = true;
				this.linkButton_1.CssClass = "page_up_true";
				this.label_1.Text = (int.Parse(this.label_1.Text) + 1).ToString();
				this.int_0++;
			}
			this.Page.Response.Redirect(string.Concat(new object[]
			{
				"http://",
				ShopSettings.siteDomain,
				"/Main/panicbuylist.aspx?tag=7&pindex=",
				this.int_0
			}));
		}
		protected void PanicBuyDataBind(int pindex)
		{
			try
			{
				int.Parse(this.PageCount);
			}
			catch
			{
				this.PageCount = "5";
			}
			ShopNum1_Common_Action shopNum1_Common_Action = (ShopNum1_Common_Action)LogicFactory.CreateShopNum1_Common_Action();
			string text = string.Empty;
			if (this.string_1 == "all")
			{
				text = " ProductState=1 and EndTime>getdate() and IsAudit=1 and IsSell=1 and starttime<=getdate()    ";
			}
			else
			{
				text = " ProductState=1 and EndTime>getdate() and IsAudit=1 and IsSell=1 and starttime<=getdate()  AND   SubstationID='" + this.string_1 + "'  ";
			}
			if (this.CategoryCode != "-1")
			{
				text = text + "  and productcategorycode like '" + this.CategoryCode + "%'";
			}
			this.label_0.Text = shopNum1_Common_Action.CommonGetPageCount(this.PageCount, "ShopNum1_Shop_Product", text).Tables[0].Rows[0][0].ToString();
			this.label_2.Text = shopNum1_Common_Action.CommonGetPageCount(this.PageCount, "ShopNum1_Shop_Product", text).Tables[1].Rows[0][0].ToString();
			ShopNum1_ProuductChecked_Action shopNum1_ProuductChecked_Action = (ShopNum1_ProuductChecked_Action)LogicFactory.CreateShopNum1_ProuductChecked_Action();
			DataTable panceProductByCategoryCode = shopNum1_ProuductChecked_Action.GetPanceProductByCategoryCode(this.CategoryCode, this.PageCount, pindex.ToString());
			if (panceProductByCategoryCode != null & panceProductByCategoryCode.Rows.Count > 0)
			{
				this.repeater_0.DataSource = panceProductByCategoryCode.DefaultView;
				this.repeater_0.DataBind();
			}
			if (this.label_2.Text == "0")
			{
				this.linkButton_1.Enabled = false;
				this.linkButton_0.Enabled = false;
				this.linkButton_1.CssClass = "page_up_false";
				this.linkButton_0.CssClass = "page_down_false";
				this.repeater_0.DataSource = null;
				this.repeater_0.DataBind();
			}
			else if (this.label_2.Text == "1")
			{
				this.linkButton_1.Enabled = false;
				this.linkButton_0.Enabled = false;
				this.linkButton_1.CssClass = "page_up_false";
				this.linkButton_0.CssClass = "page_down_false";
			}
			else if (int.Parse(this.label_1.Text) == 1)
			{
				this.linkButton_1.Enabled = false;
				this.linkButton_0.Enabled = true;
				this.linkButton_1.CssClass = "page_up_false";
			}
			else if (int.Parse(this.label_1.Text) == int.Parse(this.label_2.Text))
			{
				this.linkButton_0.Enabled = false;
				this.linkButton_0.CssClass = "page_down_false";
			}
			else
			{
				this.linkButton_1.CssClass = "page_up_true";
				this.linkButton_0.CssClass = "page_down_true";
				this.linkButton_1.Enabled = true;
				this.linkButton_0.Enabled = true;
			}
		}
	}
}
