using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_ShopCategoryOperate : BaseShopWebControl
	{
		private string string_0 = "S_ShopCategoryOperate.ascx";
		private TextBox textBox_0;
		private Button button_0;
		private Button button_1;
		private HtmlInputHidden htmlInputHidden_0;
		private HtmlInputHidden htmlInputHidden_1;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		public new string MemLoginID
		{
			get;
			set;
		}
		protected string OldBrandName
		{
			get;
			set;
		}
		protected string OldBrandGuid
		{
			get;
			set;
		}
		public S_ShopCategoryOperate()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.htmlInputHidden_0 = (HtmlInputHidden)skin.FindControl("hidShopCategoryCode");
			this.htmlInputHidden_1 = (HtmlInputHidden)skin.FindControl("hidShopCategoryName");
			this.button_1 = (Button)skin.FindControl("ButtonLink");
			this.button_1.Click += new EventHandler(this.button_1_Click);
			if (this.Page.Request.Cookies["MemberLoginCookie"] == null)
			{
				GetUrl.RedirectTopLogin();
			}
			else
			{
				this.textBox_0 = (TextBox)skin.FindControl("TextBoxRemarks");
				HttpCookie cookie = this.Page.Request.Cookies["MemberLoginCookie"];
				HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
				string a = httpCookie.Values["MemberType"].ToString();
				if (a != "2")
				{
					GetUrl.RedirectTopLogin();
				}
				else
				{
					this.MemLoginID = httpCookie.Values["MemLoginID"].ToString();
					this.button_0 = (Button)skin.FindControl("ButtonEnsure");
					this.button_0.Click += new EventHandler(this.ButtonEnsure_Click);
				}
			}
		}
		private void button_1_Click(object sender, EventArgs e)
		{
			this.Page.Response.Redirect("S_ApplyShopCategory.aspx");
		}
		public void ButtonEnsure_Click(object sender, EventArgs e)
		{
			Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)LogicFactory.CreateShop_ShopInfo_Action();
			DataTable applyCatetoryList = shop_ShopInfo_Action.GetApplyCatetoryList(this.MemLoginID, "0", "-1", "-1");
			if (applyCatetoryList != null && applyCatetoryList.Rows.Count > 0)
			{
				MessageBox.Show("您已提交过申请，请待审核后再提交！");
			}
			else
			{
				ShopNum1_Shop_ApplyCateGory shopNum1_Shop_ApplyCateGory = new ShopNum1_Shop_ApplyCateGory();
				shopNum1_Shop_ApplyCateGory.Guid = Guid.NewGuid();
				shopNum1_Shop_ApplyCateGory.ShopCategoryName = this.htmlInputHidden_1.Value;
				shopNum1_Shop_ApplyCateGory.NewShopCateGoryCode = this.htmlInputHidden_0.Value;
				shopNum1_Shop_ApplyCateGory.BrandName = "其他";
				shopNum1_Shop_ApplyCateGory.NewBrandGuid = new Guid("00000000-0000-0000-0000-000000000000");
				shopNum1_Shop_ApplyCateGory.Remarks = this.textBox_0.Text.Trim();
				shopNum1_Shop_ApplyCateGory.ShopID = this.MemLoginID.ToString();
				shopNum1_Shop_ApplyCateGory.OldBrandName = this.OldBrandName;
				try
				{
					shopNum1_Shop_ApplyCateGory.OldBrandGuid = new Guid?(new Guid(this.OldBrandGuid));
				}
				catch
				{
					shopNum1_Shop_ApplyCateGory.OldBrandGuid = new Guid?(default(Guid));
				}
				string nameById = ShopNum1.Common.Common.GetNameById("shopcategoryid", "shopnum1_shopinfo", " And MemloginId='" + this.MemLoginID + "'");
				string nameById2 = ShopNum1.Common.Common.GetNameById("name", "ShopNum1_ShopCategory", " And Code='" + nameById + "'");
				shopNum1_Shop_ApplyCateGory.OldShopCategoryName = nameById2;
				shopNum1_Shop_ApplyCateGory.OldShopCategoryCode = nameById;
				int num = shop_ShopInfo_Action.AddApplyCateGory(shopNum1_Shop_ApplyCateGory);
				if (num > 0)
				{
					MessageBox.Show("修改申请已经提交,请等待审核！");
				}
				else
				{
					MessageBox.Show("申请失败！");
				}
			}
		}
	}
}
