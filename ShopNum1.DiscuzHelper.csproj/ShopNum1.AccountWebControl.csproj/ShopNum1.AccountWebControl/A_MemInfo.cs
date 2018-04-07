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
	public class A_MemInfo : BaseMemberWebControl
	{
		private string string_0 = "A_MemInfo.ascx";
		private Button button_0;
		private Button button_1;
		private Label label_0;
		private HtmlInputText htmlInputText_0;
		private HtmlInputText htmlInputText_1;
		private HtmlInputText htmlInputText_2;
		private HtmlInputText htmlInputText_3;
		private HtmlInputText htmlInputText_4;
		private HtmlInputText htmlInputText_5;
		private HtmlInputText htmlInputText_6;
		private HtmlInputText htmlInputText_7;
		private HtmlInputText htmlInputText_8;
		private HtmlInputText htmlInputText_9;
		private HtmlInputText htmlInputText_10;
		private HtmlInputText htmlInputText_11;
		private HtmlSelect htmlSelect_0;
		private HtmlSelect htmlSelect_1;
		private HtmlSelect htmlSelect_2;
		private Image image_0;
		private HtmlInputHidden htmlInputHidden_0;
		private HtmlInputHidden htmlInputHidden_1;
		private HtmlInputHidden htmlInputHidden_2;
		private HtmlInputHidden htmlInputHidden_3;
		private HtmlInputHidden htmlInputHidden_4;
		[CompilerGenerated]
		private string string_1;
		public string StrMemLoginID
		{
			get;
			set;
		}
		public A_MemInfo()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.label_0 = (Label)skin.FindControl("Lab_MemLoginID");
			this.htmlInputHidden_0 = (HtmlInputHidden)skin.FindControl("hid_Sex");
			this.htmlInputText_0 = (HtmlInputText)skin.FindControl("txt_UserName");
			this.htmlInputText_2 = (HtmlInputText)skin.FindControl("txt_PalyName");
			this.htmlInputText_1 = (HtmlInputText)skin.FindControl("txt_Email");
			this.htmlInputText_10 = (HtmlInputText)skin.FindControl("txt_Address");
			this.htmlSelect_0 = (HtmlSelect)skin.FindControl("sel_Prov");
			this.htmlSelect_1 = (HtmlSelect)skin.FindControl("sel_City");
			this.htmlSelect_2 = (HtmlSelect)skin.FindControl("sel_Area");
			this.button_0 = (Button)skin.FindControl("btn_Sure");
			this.button_1 = (Button)skin.FindControl("btn_Save");
			this.htmlInputText_3 = (HtmlInputText)skin.FindControl("txt_QQ");
			this.htmlInputText_4 = (HtmlInputText)skin.FindControl("txt_Mobile");
			this.htmlInputText_5 = (HtmlInputText)skin.FindControl("txt_Tel");
			this.htmlInputText_6 = (HtmlInputText)skin.FindControl("txt_WebSite");
			this.htmlInputText_7 = (HtmlInputText)skin.FindControl("txt_Bth");
			this.htmlInputText_8 = (HtmlInputText)skin.FindControl("txt_Post");
			this.htmlInputText_9 = (HtmlInputText)skin.FindControl("txt_Voc");
			this.htmlInputText_11 = (HtmlInputText)skin.FindControl("txt_Fax");
			this.htmlInputHidden_1 = (HtmlInputHidden)skin.FindControl("hid_AreaCode");
			this.htmlInputHidden_2 = (HtmlInputHidden)skin.FindControl("hid_AreaValue");
			this.htmlInputHidden_3 = (HtmlInputHidden)skin.FindControl("hid_CheckMobile");
			this.htmlInputHidden_4 = (HtmlInputHidden)skin.FindControl("hid_CheckEmail");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.button_1.Click += new EventHandler(this.button_1_Click);
			this.image_0 = (Image)skin.FindControl("ImagePath");
			this.StrMemLoginID = this.MemLoginID;
			this.label_0.Text = this.MemLoginID;
			if (!this.Page.IsPostBack)
			{
				this.method_0(this.StrMemLoginID);
			}
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
			ShopNum1_Member shopNum1_Member = new ShopNum1_Member();
			shopNum1_Member.RealName = this.htmlInputText_2.Value;
			if (this.htmlInputHidden_0.Value != "")
			{
				shopNum1_Member.Sex = new byte?(Convert.ToByte(this.htmlInputHidden_0.Value));
			}
			else
			{
				shopNum1_Member.Sex = new byte?(Convert.ToByte("2"));
			}
			if (this.htmlInputText_1.Value.Trim().ToString() != "" && shopNum1_Member_Action.CheckmemEmail(this.htmlInputText_1.Value.Trim()) > 0 && shopNum1_Member_Action.FindPwdEamil(this.MemLoginID, this.htmlInputText_1.Value.Trim()).Rows.Count == 0)
			{
				MessageBox.Show("邮箱已经被使用了,请换一个邮箱!");
			}
			else if (this.htmlInputText_4.Value.Trim() != "" && shopNum1_Member_Action.CheckMemMobileByMobile(this.htmlInputText_4.Value.Trim()).Rows.Count > 0 && this.MemLoginID != shopNum1_Member_Action.CheckMemMobileByMobile(this.htmlInputText_4.Value).Rows[0]["MemLoginID"].ToString())
			{
				MessageBox.Show("手机号码已经被使用了,请换一个手机号码!");
			}
			else
			{
				shopNum1_Member.QQ = this.htmlInputText_3.Value;
				shopNum1_Member.Email = this.htmlInputText_1.Value;
				shopNum1_Member.Mobile = this.htmlInputText_4.Value;
				shopNum1_Member.ModifyUser = this.StrMemLoginID;
				shopNum1_Member.ModifyTime = new DateTime?(DateTime.Now);
				shopNum1_Member.Name = this.htmlInputText_0.Value;
				shopNum1_Member.Tel = this.htmlInputText_5.Value;
				try
				{
					int num = shopNum1_Member_Action.UpdateMemInfo(this.StrMemLoginID, shopNum1_Member);
					if (num > 0)
					{
						MessageBox.Show("修改成功");
					}
				}
				catch
				{
				}
			}
		}
		private void button_1_Click(object sender, EventArgs e)
		{
			if (this.htmlInputText_10.Value == "")
			{
				MessageBox.Show("地址不能为空");
			}
			else if (this.htmlInputText_8.Value == "")
			{
				MessageBox.Show("邮编不能为空");
			}
			else
			{
				ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
				ShopNum1_Member shopNum1_Member = new ShopNum1_Member();
				shopNum1_Member.AddressCode = this.htmlInputHidden_1.Value;
				shopNum1_Member.AddressValue = this.htmlInputHidden_2.Value;
				shopNum1_Member.Address = this.htmlInputText_10.Value;
				shopNum1_Member.Area = this.GetAdress(shopNum1_Member.AddressValue, shopNum1_Member.Address);
				shopNum1_Member.WebSite = this.htmlInputText_6.Value;
				shopNum1_Member.Fax = this.htmlInputText_11.Value;
				shopNum1_Member.ModifyUser = this.StrMemLoginID;
				shopNum1_Member.ModifyTime = new DateTime?(DateTime.Now);
				if (this.htmlInputText_7.Value != "")
				{
					shopNum1_Member.Birthday = new DateTime?(DateTime.Parse(this.htmlInputText_7.Value));
					if (shopNum1_Member.Birthday > DateTime.Now)
					{
						MessageBox.Show("出生日期填写有误");
						return;
					}
				}
				else
				{
					shopNum1_Member.Birthday = new DateTime?(DateTime.Now);
				}
				shopNum1_Member.Vocation = this.htmlInputText_9.Value;
				shopNum1_Member.Postalcode = this.htmlInputText_8.Value;
				try
				{
					int num = shopNum1_Member_Action.UpdateMemInfoDetail(this.StrMemLoginID, shopNum1_Member);
					if (num > 0)
					{
						MessageBox.Show("信息补充成功");
					}
				}
				catch
				{
				}
			}
		}
		private void method_0(string string_2)
		{
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
			DataTable memInfo = shopNum1_Member_Action.GetMemInfo(string_2);
			try
			{
				if (memInfo.Rows.Count > 0)
				{
					this.label_0.Text = memInfo.Rows[0]["MemLoginID"].ToString();
					this.htmlInputText_0.Value = memInfo.Rows[0]["Name"].ToString();
					this.htmlInputText_1.Value = memInfo.Rows[0]["Email"].ToString();
					this.htmlInputText_10.Value = memInfo.Rows[0]["Address"].ToString();
					this.htmlInputText_4.Value = memInfo.Rows[0]["Mobile"].ToString();
					this.htmlInputText_5.Value = memInfo.Rows[0]["Tel"].ToString();
					this.htmlInputText_9.Value = memInfo.Rows[0]["Vocation"].ToString();
					this.htmlInputText_6.Value = memInfo.Rows[0]["WebSite"].ToString();
					this.htmlInputText_8.Value = memInfo.Rows[0]["Postalcode"].ToString();
					this.htmlInputText_11.Value = memInfo.Rows[0]["Fax"].ToString();
					this.htmlInputText_3.Value = memInfo.Rows[0]["QQ"].ToString();
					this.htmlInputText_7.Value = ((memInfo.Rows[0]["Birthday"].ToString() == string.Empty) ? string.Empty : DateTime.Parse(memInfo.Rows[0]["Birthday"].ToString()).ToString("yyyy-MM-dd"));
					this.htmlInputHidden_0.Value = memInfo.Rows[0]["Sex"].ToString();
					this.htmlInputText_2.Value = memInfo.Rows[0]["RealName"].ToString();
					this.htmlInputHidden_2.Value = memInfo.Rows[0]["AddressValue"].ToString();
					this.htmlInputHidden_1.Value = memInfo.Rows[0]["AddressCode"].ToString();
					this.image_0.ImageUrl = ((memInfo.Rows[0]["Photo"].ToString() == "") ? ShopSettings.GetValue("MemberImage") : memInfo.Rows[0]["Photo"].ToString());
					this.htmlInputHidden_4.Value = memInfo.Rows[0]["IsEmailActivation"].ToString();
					this.htmlInputHidden_3.Value = memInfo.Rows[0]["IsMobileActivation"].ToString();
				}
			}
			catch (InvalidCastException)
			{
			}
		}
		public string GetMemLoginID()
		{
			return this.StrMemLoginID;
		}
		protected string GetAdress(object AddressValue, object Address)
		{
			string result;
			try
			{
				string[] array = AddressValue.ToString().Split(new char[]
				{
					'|'
				});
				string text = array[0].ToString();
				string[] array2 = text.Split(new char[]
				{
					','
				});
				string str = string.Empty;
				if (array2.Length == 3)
				{
					str = array2[0] + array2[1] + array2[2];
				}
				else if (array2.Length == 2)
				{
					str = array2[0] + array2[1];
				}
				else if (array2.Length == 1)
				{
					str = array2[0];
				}
				else
				{
					str = Address.ToString();
				}
				result = str + Address.ToString();
			}
			catch
			{
				result = "";
			}
			return result;
		}
	}
}
