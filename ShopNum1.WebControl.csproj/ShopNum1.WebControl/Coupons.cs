using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.IO;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class Coupons : BaseWebControl
	{
		private string string_0 = "Coupons.ascx";
		private DropDownList dropDownList_0;
		private Repeater repeater_0;
		private HtmlImage htmlImage_0;
		private LinkButton linkButton_0;
		private LinkButton linkButton_1;
		private LinkButton linkButton_2;
		private LinkButton linkButton_3;
		private Label label_0;
		private Label label_1;
		private TextBox textBox_0;
		private Button button_0;
		[CompilerGenerated]
		private string string_1;
		public string ShowCount
		{
			get;
			set;
		}
		public Coupons()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.dropDownList_0 = (DropDownList)skin.FindControl("DropDownListCouponCategory");
			this.dropDownList_0.SelectedIndexChanged += new EventHandler(this.dropDownList_0_SelectedIndexChanged);
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			this.linkButton_0 = (LinkButton)skin.FindControl("LinkButtonFirst");
			this.linkButton_1 = (LinkButton)skin.FindControl("LinkButtonLast");
			this.linkButton_2 = (LinkButton)skin.FindControl("LinkButtonNext");
			this.linkButton_3 = (LinkButton)skin.FindControl("LinkButtonEnd");
			this.label_0 = (Label)skin.FindControl("LabelPageIndex");
			this.label_1 = (Label)skin.FindControl("LabelPageCount");
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxPageNum");
			this.button_0 = (Button)skin.FindControl("ButtonGo");
			this.linkButton_0.Click += new EventHandler(this.linkButton_0_Click);
			this.linkButton_1.Click += new EventHandler(this.linkButton_1_Click);
			this.linkButton_2.Click += new EventHandler(this.linkButton_2_Click);
			this.linkButton_3.Click += new EventHandler(this.linkButton_3_Click);
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.DropDownListCouponCategoryBind();
			this.CouponsDataBind();
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			this.label_0.Text = this.textBox_0.Text;
			this.CouponsDataBind();
		}
		private void linkButton_3_Click(object sender, EventArgs e)
		{
			this.label_0.Text = this.label_1.Text;
			this.CouponsDataBind();
		}
		private void linkButton_2_Click(object sender, EventArgs e)
		{
			this.label_0.Text = (int.Parse(this.label_0.Text) + 1).ToString();
			this.CouponsDataBind();
		}
		private void linkButton_1_Click(object sender, EventArgs e)
		{
			this.label_0.Text = (int.Parse(this.label_0.Text) - 1).ToString();
			this.CouponsDataBind();
		}
		private void linkButton_0_Click(object sender, EventArgs e)
		{
			this.label_0.Text = "1";
			this.CouponsDataBind();
		}
		protected void CouponsDataBind()
		{
			try
			{
				int.Parse(this.ShowCount);
			}
			catch
			{
				this.ShowCount = "9";
			}
			ShopNum1_Common_Action arg_27_0 = (ShopNum1_Common_Action)LogicFactory.CreateShopNum1_Common_Action();
			ShopNum1_Coupon_Action shopNum1_Coupon_Action = new ShopNum1_Coupon_Action();
			if (this.dropDownList_0.SelectedValue != "-1")
			{
                //"Type=" + this.dropDownList_0.SelectedValue;
			}
			this.label_1.Text = shopNum1_Coupon_Action.SearchCouponByCategory(this.dropDownList_0.SelectedValue, this.ShowCount, this.label_0.Text).Tables[1].Rows[0][0].ToString();
			if (this.label_1.Text == "0")
			{
				this.label_0.Text = "0";
				this.repeater_0.DataSource = null;
				this.repeater_0.DataBind();
			}
			else
			{
				if (this.label_1.Text != "0" && this.label_0.Text == "0")
				{
					this.label_0.Text = "1";
				}
				DataTable dataTable = shopNum1_Coupon_Action.SearchCouponByCategory(this.dropDownList_0.SelectedValue, this.ShowCount, this.label_0.Text).Tables[0];
				if (dataTable != null && dataTable.Rows.Count > 0)
				{
					this.repeater_0.DataSource = dataTable.DefaultView;
					this.repeater_0.DataBind();
					for (int i = 0; i < this.repeater_0.Items.Count; i++)
					{
						this.htmlImage_0 = (HtmlImage)this.repeater_0.Items[i].FindControl("imgCoupon");
						this.htmlImage_0.Src = this.Page.ResolveUrl(this.GetWebFilePath(dataTable.Rows[i]["ShopID"].ToString()) + dataTable.Rows[i]["ImgPath"].ToString());
					}
				}
				this.linkButton_0.Enabled = true;
				this.linkButton_1.Enabled = true;
				this.linkButton_2.Enabled = true;
				this.linkButton_3.Enabled = true;
				if (this.label_0.Text == "0")
				{
					this.linkButton_0.Enabled = true;
					this.linkButton_1.Enabled = true;
					this.linkButton_2.Enabled = true;
					this.linkButton_3.Enabled = true;
				}
				if (this.label_0.Text == "1")
				{
					this.linkButton_0.Enabled = false;
					this.linkButton_1.Enabled = false;
				}
				if (this.label_0.Text == this.label_1.Text)
				{
					this.linkButton_2.Enabled = false;
					this.linkButton_3.Enabled = false;
				}
			}
		}
		protected string GetWebFilePath(string ShopID)
		{
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
			DataTable openTimeByShopID = shopNum1_ShopInfoList_Action.GetOpenTimeByShopID(ShopID);
			string text = DateTime.Parse(openTimeByShopID.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
			string text2 = string.Concat(new string[]
			{
				"/ImgUpload/",
				text.Replace("-", "/"),
				"/shop",
				ShopID,
				"/Coupon/"
			});
			if (!Directory.Exists(HttpContext.Current.Server.MapPath(text2)))
			{
				Directory.CreateDirectory(HttpContext.Current.Server.MapPath(text2));
			}
			return text2;
		}
		protected void DropDownListCouponCategoryBind()
		{
			this.dropDownList_0.Items.Clear();
			this.dropDownList_0.Items.Add(new ListItem("-全部-", "-1"));
			ShopNum1_CouponType_Action shopNum1_CouponType_Action = new ShopNum1_CouponType_Action();
			DataTable dataTable = shopNum1_CouponType_Action.search(-1, 1);
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				this.dropDownList_0.Items.Add(new ListItem(dataTable.Rows[i]["Name"].ToString(), dataTable.Rows[i]["ID"].ToString()));
			}
		}
		private void dropDownList_0_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.CouponsDataBind();
		}
	}
}
