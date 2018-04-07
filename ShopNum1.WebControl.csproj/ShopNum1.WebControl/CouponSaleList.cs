using ShopNum1.BusinessLogic;
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
	public class CouponSaleList : BaseWebControl
	{
		private string string_0 = "CouponSaleList.ascx";
		private DropDownList dropDownList_0;
		private DropDownList dropDownList_1;
		private DropDownList dropDownList_2;
		private Repeater repeater_0;
		private HiddenField hiddenField_0;
		[CompilerGenerated]
		private string string_1;
		public string ShowCount
		{
			get;
			set;
		}
		public CouponSaleList()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.dropDownList_0 = (DropDownList)skin.FindControl("DropDownListRegionCode1");
			this.dropDownList_0.SelectedIndexChanged += new EventHandler(this.DropDownListRegionCode1_SelectedIndexChanged);
			this.dropDownList_1 = (DropDownList)skin.FindControl("DropDownListRegionCode2");
			this.dropDownList_1.SelectedIndexChanged += new EventHandler(this.DropDownListRegionCode2_SelectedIndexChanged);
			this.dropDownList_2 = (DropDownList)skin.FindControl("DropDownListRegionCode3");
			this.dropDownList_2.SelectedIndexChanged += new EventHandler(this.dropDownList_2_SelectedIndexChanged);
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			this.hiddenField_0 = (HiddenField)skin.FindControl("HiddenFieldRegionCode");
			this.DropDownListRegionCode1Bind();
			if (!this.Page.IsPostBack)
			{
				this.CouponsDataBind();
			}
		}
		protected void CouponsDataBind()
		{
			this.SetShopRegionCode();
			try
			{
				int.Parse(this.ShowCount);
			}
			catch
			{
				this.ShowCount = "10";
			}
			ShopNum1_Coupon_Action shopNum1_Coupon_Action = (ShopNum1_Coupon_Action)LogicFactory.CreateShopNum1_Coupon_Action();
			DataTable couponTitleByAdressCode = shopNum1_Coupon_Action.GetCouponTitleByAdressCode(this.hiddenField_0.Value, this.ShowCount);
			if (couponTitleByAdressCode != null && couponTitleByAdressCode.Rows.Count > 0)
			{
				this.repeater_0.DataSource = couponTitleByAdressCode.DefaultView;
				this.repeater_0.DataBind();
			}
			else
			{
				this.repeater_0.DataSource = null;
				this.repeater_0.DataBind();
			}
		}
		public void SetShopRegionCode()
		{
			if (this.dropDownList_2.SelectedValue != "-1")
			{
				this.hiddenField_0.Value = this.dropDownList_2.SelectedValue.Split(new char[]
				{
					'/'
				})[0];
			}
			else if (this.dropDownList_1.SelectedValue != "-1")
			{
				this.hiddenField_0.Value = this.dropDownList_1.SelectedValue.Split(new char[]
				{
					'/'
				})[0];
			}
			else if (this.dropDownList_0.SelectedValue != "-1")
			{
				this.hiddenField_0.Value = this.dropDownList_0.SelectedValue.Split(new char[]
				{
					'/'
				})[0];
			}
			else
			{
				this.hiddenField_0.Value = "-1";
			}
		}
		private void dropDownList_2_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.CouponsDataBind();
		}
		protected void DropDownListRegionCode1Bind()
		{
			this.dropDownList_0.Items.Clear();
			this.dropDownList_0.Items.Add(new ListItem("-省级-", "-1"));
			ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
			shopNum1_ProductCategory_Action.TableName = "ShopNum1_Region";
			DataTable productCategoryName = shopNum1_ProductCategory_Action.GetProductCategoryName("0");
			for (int i = 0; i < productCategoryName.Rows.Count; i++)
			{
				this.dropDownList_0.Items.Add(new ListItem(productCategoryName.Rows[i]["Name"].ToString(), productCategoryName.Rows[i]["Code"].ToString() + "/" + productCategoryName.Rows[i]["ID"].ToString()));
			}
			this.DropDownListRegionCode1_SelectedIndexChanged(null, null);
		}
		protected void DropDownListRegionCode1_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.CouponsDataBind();
			this.dropDownList_1.Items.Clear();
			this.dropDownList_1.Items.Add(new ListItem("-市级-", "-1"));
			if (this.dropDownList_0.SelectedValue != "-1")
			{
				ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
				shopNum1_ProductCategory_Action.TableName = "ShopNum1_Region";
				DataTable productCategoryName = shopNum1_ProductCategory_Action.GetProductCategoryName(this.dropDownList_0.SelectedValue.Split(new char[]
				{
					'/'
				})[1]);
				for (int i = 0; i < productCategoryName.Rows.Count; i++)
				{
					this.dropDownList_1.Items.Add(new ListItem(productCategoryName.Rows[i]["Name"].ToString(), productCategoryName.Rows[i]["Code"].ToString() + "/" + productCategoryName.Rows[i]["ID"].ToString()));
				}
			}
			this.DropDownListRegionCode2_SelectedIndexChanged(null, null);
		}
		protected void DropDownListRegionCode2_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.dropDownList_2.Items.Clear();
			this.dropDownList_2.Items.Add(new ListItem("-县级-", "-1"));
			if (this.dropDownList_1.SelectedValue != "-1")
			{
				this.CouponsDataBind();
				ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
				shopNum1_ProductCategory_Action.TableName = "ShopNum1_Region";
				DataTable productCategoryName = shopNum1_ProductCategory_Action.GetProductCategoryName(this.dropDownList_1.SelectedValue.Split(new char[]
				{
					'/'
				})[1]);
				for (int i = 0; i < productCategoryName.Rows.Count; i++)
				{
					this.dropDownList_2.Items.Add(new ListItem(productCategoryName.Rows[i]["Name"].ToString(), productCategoryName.Rows[i]["Code"].ToString() + "/" + productCategoryName.Rows[i]["ID"].ToString()));
				}
			}
		}
	}
}
