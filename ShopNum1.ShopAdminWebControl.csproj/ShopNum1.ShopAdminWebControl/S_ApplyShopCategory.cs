using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_ApplyShopCategory : BaseShopWebControl
	{
		private string string_0 = "S_ApplyShopCategory.ascx";
		private DropDownList dropDownList_0;
		private TextBox textBox_0;
		private TextBox textBox_1;
		private HiddenField hiddenField_0;
		private Repeater repeater_0;
		private LinkButton linkButton_0;
		private Button button_0;
		[CompilerGenerated]
		private string string_1;
		public new string MemLoginID
		{
			get;
			set;
		}
		public S_ApplyShopCategory()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.dropDownList_0 = (DropDownList)skin.FindControl("dropDownListstate");
			this.textBox_0 = (TextBox)skin.FindControl("textBoxtime1");
			this.textBox_1 = (TextBox)skin.FindControl("textBoxtime2");
			this.hiddenField_0 = (HiddenField)skin.FindControl("CheckGuid");
			this.button_0 = (Button)skin.FindControl("ButtonSearch");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			if (this.Page.Request.Cookies["MemberLoginCookie"] == null)
			{
				GetUrl.RedirectLogin();
			}
			else
			{
				this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
				this.linkButton_0 = (LinkButton)skin.FindControl("ButtonDel");
				this.linkButton_0.Click += new EventHandler(this.linkButton_0_Click);
				HttpCookie cookie = this.Page.Request.Cookies["MemberLoginCookie"];
				HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
				string a = httpCookie.Values["MemberType"].ToString();
				if (a != "2")
				{
					GetUrl.RedirectLogin();
				}
				else
				{
					this.MemLoginID = httpCookie.Values["MemLoginID"].ToString();
					Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ShopInfo_Action();
					shop_ShopInfo_Action.GetMemLoginInfo(this.MemLoginID);
					this.method_0();
					this.method_1();
				}
			}
		}
		public static string IsAudit(string Audit)
		{
			string result;
			if (Audit != null)
			{
				if (Audit == "0")
				{
					result = "等待审核";
					return result;
				}
				if (Audit == "1")
				{
					result = "审核通过";
					return result;
				}
				if (Audit == "2")
				{
					result = "审核未通过";
					return result;
				}
			}
			result = "";
			return result;
		}
		private void linkButton_0_Click(object sender, EventArgs e)
		{
			Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ShopInfo_Action();
			int num = shop_ShopInfo_Action.DelApplyCatetoryByGuid(this.hiddenField_0.Value, this.MemLoginID);
			if (num > 0)
			{
				MessageBox.Show("删除成功！");
				this.method_1();
			}
			else
			{
				MessageBox.Show("删除失败！");
			}
		}
		private void method_0()
		{
			this.dropDownList_0.Items.Add(new ListItem("-全部-", "-1"));
			this.dropDownList_0.Items.Add(new ListItem("审核", "1"));
			this.dropDownList_0.Items.Add(new ListItem("未审核", "0"));
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			this.method_1();
		}
		private void method_1()
		{
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopInfoList_Action();
            //ShopSettings.GetValue("PersonShopUrl") + shopNum1_ShopInfoList_Action.GetShopIDByMemLoginID(this.MemLoginID).Rows[0]["ShopID"].ToString();
			string selectedValue = this.dropDownList_0.SelectedValue;
			string audtitetime = string.IsNullOrEmpty(this.textBox_0.Text) ? "-1" : this.textBox_0.Text;
			string audtitetime2 = string.IsNullOrEmpty(this.textBox_1.Text) ? "-1" : this.textBox_1.Text;
			Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ShopInfo_Action();
			DataTable applyCatetoryList = shop_ShopInfo_Action.GetApplyCatetoryList(this.MemLoginID, selectedValue, audtitetime, audtitetime2);
			this.repeater_0.DataSource = applyCatetoryList;
			this.repeater_0.DataBind();
		}
	}
}
