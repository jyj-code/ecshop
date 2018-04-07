using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	public class S_GroupProductOperate : BaseShopWebControl
	{
		private string string_0 = "S_GroupProductOperate.ascx";
		private HtmlSelect htmlSelect_0;
		private Button button_0;
		private HtmlInputHidden htmlInputHidden_0;
		private HtmlInputHidden htmlInputHidden_1;
		private HtmlInputText htmlInputText_0;
		private HtmlInputText htmlInputText_1;
		private HtmlInputText htmlInputText_2;
		private HtmlInputText htmlInputText_3;
		private HtmlInputText htmlInputText_4;
		private HtmlTextArea htmlTextArea_0;
		private FileUpload fileUpload_0;
		private HtmlImage htmlImage_0;
		private HtmlInputHidden htmlInputHidden_2;
		private HtmlGenericControl htmlGenericControl_0;
		private Image image_0;
		private HiddenField hiddenField_0;
		private ShopNum1_Group_Product shopNum1_Group_Product_0 = new ShopNum1_Group_Product();
		private Shop_GroupProduct_Action shop_GroupProduct_Action_0 = new Shop_GroupProduct_Action();
		public S_GroupProductOperate()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.htmlSelect_0 = (HtmlSelect)skin.FindControl("SubstationIDName");
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("spanstock");
			this.button_0 = (Button)skin.FindControl("btnSub");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.htmlInputHidden_0 = (HtmlInputHidden)skin.FindControl("hidGuid");
			this.htmlInputHidden_1 = (HtmlInputHidden)skin.FindControl("hidAid");
			this.htmlInputHidden_2 = (HtmlInputHidden)skin.FindControl("hidAname");
			this.htmlInputText_0 = (HtmlInputText)skin.FindControl("txtGroupName");
			this.htmlInputText_1 = (HtmlInputText)skin.FindControl("txtGroupPrice");
			this.htmlInputText_2 = (HtmlInputText)skin.FindControl("txtGroupStock");
			this.htmlInputText_3 = (HtmlInputText)skin.FindControl("txtVitualNum");
			this.htmlInputText_4 = (HtmlInputText)skin.FindControl("txtLimtNum");
			this.htmlTextArea_0 = (HtmlTextArea)skin.FindControl("txtGroupIntroduce");
			this.fileUpload_0 = (FileUpload)skin.FindControl("fileUpload");
			this.htmlImage_0 = (HtmlImage)skin.FindControl("GroupPic");
			this.image_0 = (Image)skin.FindControl("ImageGroup");
			this.hiddenField_0 = (HiddenField)skin.FindControl("HiddenFieldGroup");
			this.htmlInputHidden_0 = (HtmlInputHidden)skin.FindControl("hidGuid");
			if (!this.Page.IsPostBack)
			{
				this.method_0();
			}
		}
		private void method_0()
		{
			if (ShopNum1.Common.Common.ReqStr("id") != "")
			{
				DataTable groupProductById = this.shop_GroupProduct_Action_0.GetGroupProductById(ShopNum1.Common.Common.ReqStr("id"), this.MemLoginID);
				if (groupProductById.Rows.Count > 0)
				{
					this.htmlInputHidden_1.Value = groupProductById.Rows[0]["aid"].ToString();
					this.htmlInputHidden_0.Value = groupProductById.Rows[0]["productguid"].ToString();
					this.htmlInputText_0.Value = groupProductById.Rows[0]["name"].ToString();
					this.htmlInputText_1.Value = groupProductById.Rows[0]["GroupPrice"].ToString();
					this.htmlInputText_2.Value = groupProductById.Rows[0]["GroupStock"].ToString();
					this.htmlTextArea_0.Value = groupProductById.Rows[0]["introduce"].ToString();
					this.image_0.ImageUrl = groupProductById.Rows[0]["groupsmallimg"].ToString();
					this.hiddenField_0.Value = groupProductById.Rows[0]["groupsmallimg"].ToString();
					if (groupProductById.Rows[0]["SubstationID"].ToString() == "all")
					{
						this.htmlSelect_0.Value = "all";
					}
					else
					{
						this.htmlSelect_0.Value = "city";
					}
				}
			}
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			string substationID = string.Empty;
			try
			{
				if (this.htmlSelect_0.Value == "city")
				{
					substationID = ShopNum1.Common.Common.GetNameById("SubstationID", "ShopNum1_ShopInfo", "   AND  MemLoginID='" + this.MemLoginID + "'   ");
				}
				else
				{
					substationID = "all";
				}
			}
			catch (Exception)
			{
			}
			this.shopNum1_Group_Product_0.SubstationID = substationID;
			this.shopNum1_Group_Product_0.Aid = new int?(Convert.ToInt32(this.htmlInputHidden_1.Value));
			this.shopNum1_Group_Product_0.ProductGuId = new Guid?(new Guid(this.htmlInputHidden_0.Value));
			this.shopNum1_Group_Product_0.Name = this.htmlInputText_0.Value;
			this.shopNum1_Group_Product_0.GroupStock = new int?(Convert.ToInt32(this.htmlInputText_2.Value));
			this.shopNum1_Group_Product_0.GroupPrice = new decimal?(Convert.ToDecimal(this.htmlInputText_1.Value));
			string text = this.htmlTextArea_0.Value;
			string pattern = "<(?!img|br|a|span|p|/p).*?>";
			text = Regex.Replace(text, pattern, string.Empty, RegexOptions.IgnoreCase);
			this.shopNum1_Group_Product_0.Introduce = text;
			this.shopNum1_Group_Product_0.ShopName = ShopNum1.Common.Common.GetNameById("shopname", "shopnum1_shopinfo", " and memloginid='" + this.MemLoginID + "'");
			this.shopNum1_Group_Product_0.MemLoginId = this.MemLoginID;
			this.shopNum1_Group_Product_0.Aname = this.htmlInputHidden_2.Value;
			string value = ShopSettings.GetValue("AddSpellBuyProductIsAudit");
			if (value == "0")
			{
				this.shopNum1_Group_Product_0.State = new int?(1);
			}
			else
			{
				this.shopNum1_Group_Product_0.State = new int?(0);
			}
			string text2 = string.Empty;
			text2 = this.hiddenField_0.Value;
			this.shopNum1_Group_Product_0.GroupImg = text2;
			this.shopNum1_Group_Product_0.GroupSmallImg = text2;
			if (ShopNum1.Common.Common.ReqStr("id") == "")
			{
				this.shop_GroupProduct_Action_0.AddGroupProduct(this.shopNum1_Group_Product_0);
			}
			else
			{
				this.shopNum1_Group_Product_0.Id = Convert.ToInt32(ShopNum1.Common.Common.ReqStr("id"));
				this.shop_GroupProduct_Action_0.UpdateGroupProduct(this.shopNum1_Group_Product_0);
			}
			this.Page.Response.Redirect("S_GroupProduct.aspx");
		}
	}
}
