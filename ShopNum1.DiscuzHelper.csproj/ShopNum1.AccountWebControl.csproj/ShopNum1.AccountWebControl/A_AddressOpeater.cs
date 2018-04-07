using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.AccountWebControl
{
	[ParseChildren(true)]
	public class A_AddressOpeater : BaseMemberWebControl
	{
		private string string_0 = "A_AddressOpeater.cs";
		private HtmlInputText htmlInputText_0;
		private HtmlInputText htmlInputText_1;
		private HtmlInputText htmlInputText_2;
		private HtmlInputText htmlInputText_3;
		private HtmlInputText htmlInputText_4;
		private Button button_0;
		private HtmlInputHidden htmlInputHidden_0;
		private HtmlInputHidden htmlInputHidden_1;
		private HtmlInputText htmlInputText_5;
		[CompilerGenerated]
		private string string_1;
		public string Guid
		{
			get;
			set;
		}
		public A_AddressOpeater()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.htmlInputText_0 = (HtmlInputText)skin.FindControl("txt_UserName");
			this.htmlInputText_1 = (HtmlInputText)skin.FindControl("txt_Email");
			this.htmlInputText_2 = (HtmlInputText)skin.FindControl("txt_Address");
			this.htmlInputText_3 = (HtmlInputText)skin.FindControl("txt_Post");
			this.htmlInputText_4 = (HtmlInputText)skin.FindControl("txt_Mobile");
			this.button_0 = (Button)skin.FindControl("btn_Save");
			this.button_0.Click += new EventHandler(this.btn_Save_Click);
			this.htmlInputHidden_0 = (HtmlInputHidden)skin.FindControl("hid_Area");
			this.htmlInputHidden_1 = (HtmlInputHidden)skin.FindControl("hid_AreaCode");
			this.htmlInputText_5 = (HtmlInputText)skin.FindControl("txt_Tel");
			try
			{
				this.Guid = new Guid(Common.ReqStr("Guid").ToString()).ToString();
			}
			catch
			{
				this.Guid = "";
			}
			if (!this.Page.IsPostBack && this.Guid != "")
			{
				this.method_0(this.Guid);
			}
		}
		protected void btn_Save_Click(object sender, EventArgs e)
		{
			ShopNum1_Address_Action shopNum1_Address_Action = (ShopNum1_Address_Action)LogicFactory.CreateShopNum1_Address_Action();
			ShopNum1_Address shopNum1_Address = new ShopNum1_Address();
			shopNum1_Address.MemLoginID = this.MemLoginID;
			if (this.Guid != "")
			{
				shopNum1_Address.Guid = new Guid(this.Guid);
				shopNum1_Address.IsDefault = 0;
			}
			else
			{
				shopNum1_Address.Guid = System.Guid.NewGuid();
			}
			shopNum1_Address.Name = this.htmlInputText_0.Value;
			shopNum1_Address.Email = this.htmlInputText_1.Value;
			shopNum1_Address.Postalcode = this.htmlInputText_3.Value;
			shopNum1_Address.Mobile = this.htmlInputText_4.Value;
			shopNum1_Address.Address = this.htmlInputText_2.Value;
			shopNum1_Address.ModifyTime = DateTime.Now;
			shopNum1_Address.ModifyUser = this.MemLoginID;
			shopNum1_Address.AddressCode = this.htmlInputHidden_1.Value;
			shopNum1_Address.AddressValue = this.htmlInputHidden_0.Value;
			shopNum1_Address.Area = this.GetAddressDetil(shopNum1_Address.AddressValue);
			shopNum1_Address.Tel = this.htmlInputText_5.Value;
			shopNum1_Address.CreateTime = DateTime.Now;
			try
			{
				if (this.Guid != "")
				{
					shopNum1_Address_Action.Update(shopNum1_Address);
					MessageBox.Show("收货地址更新成功");
				}
				else
				{
					shopNum1_Address_Action.Add(shopNum1_Address);
					MessageBox.Show("收货地址添加成功");
				}
				this.Page.Response.Redirect("A_ShipAddress.aspx");
			}
			catch (Exception)
			{
				throw;
			}
		}
		private void method_0(string string_2)
		{
			ShopNum1_Address_Action shopNum1_Address_Action = (ShopNum1_Address_Action)LogicFactory.CreateShopNum1_Address_Action();
			DataTable dataTable = new DataTable();
			try
			{
				dataTable = shopNum1_Address_Action.Search(string_2);
				if (dataTable.Rows.Count > 0)
				{
					this.htmlInputText_0.Value = dataTable.Rows[0]["Name"].ToString();
					this.htmlInputText_3.Value = dataTable.Rows[0]["Postalcode"].ToString();
					this.htmlInputText_4.Value = dataTable.Rows[0]["Mobile"].ToString();
					this.htmlInputText_2.Value = dataTable.Rows[0]["Address"].ToString();
					this.htmlInputText_1.Value = dataTable.Rows[0]["Email"].ToString();
					this.htmlInputHidden_0.Value = dataTable.Rows[0]["AddressValue"].ToString();
					this.htmlInputHidden_1.Value = dataTable.Rows[0]["AddressCode"].ToString();
					this.htmlInputText_5.Value = dataTable.Rows[0]["Tel"].ToString();
				}
			}
			catch
			{
			}
		}
		public string GetAddressDetil(string addressValue)
		{
			string[] array = addressValue.Split(new char[]
			{
				'|'
			});
			string[] array2 = array[0].Split(new char[]
			{
				','
			});
			string result = string.Empty;
			if (array2.Length > 2)
			{
				result = array2[0].ToString() + array2[1].ToString() + array2[2].ToString();
			}
			else if (array2.Length > 1)
			{
				result = array2[0].ToString() + array2[1].ToString();
			}
			else if (array2.Length > 0)
			{
				result = array2[0].ToString();
			}
			return result;
		}
	}
}
