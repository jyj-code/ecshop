using AjaxControlToolkit;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_MemberInfo_Operate : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected HtmlHead Head1;
	protected ScriptManager ScriptManager1;
	protected Label Label2;
	protected TextBox TextBoxName;
	protected Label LabelMemberRankGuid;
	protected Label LabelName;
	protected TextBox TextBoxMemberName;
	protected RegularExpressionValidator RegularExpressionValidatorRealName;
	protected Label LabelRealName;
	protected TextBox TextBoxRealName;
	protected RegularExpressionValidator RegularExpressionValidator5;
	protected Label LabelWebSite;
	protected TextBox TextBoxBirthday;
	protected RegularExpressionValidator RegularExpressionValidatorStartDate;
	protected CalendarExtender CalendarExtender1;
	protected Label Label14;
	protected DropDownList DropDownListSex;
	protected Label LabelMember;
	protected HtmlImage ImagePhoto;
	protected HiddenField HiddenFieldOriginalImge;
	protected Label Label7;
	protected TextBox TextBoxMobile;
	protected RegularExpressionValidator RegularExpressionValidator1;
	protected Button ButtonMobile;
	protected Label LabelKeywords;
	protected TextBox TextBoxEmail;
	protected RegularExpressionValidator RegularExpressionValidatorTitle9;
	protected RegularExpressionValidator RegularExpressionValidator2;
	protected Button ButtonEmail;
	protected Label LabelOrderID;
	protected TextBox TextBoxPwd;
	protected Label Label1;
	protected RegularExpressionValidator RegularExpressionValidator3;
	protected Label LabelPwd2;
	protected TextBox TextBoxPwd2;
	protected RegularExpressionValidator RegularExpressionValidatorPwd2;
	protected CompareValidator CompareValidator1;
	protected Label LabelPayPwd;
	protected TextBox TextBoxPayPwd;
	protected Label Label11;
	protected RegularExpressionValidator RegularExpressionValidatorPayPwd;
	protected Label Label12;
	protected TextBox TextBoxPayPwd2;
	protected RegularExpressionValidator RegularExpressionValidator4;
	protected CompareValidator CompareValidator2;
	protected Label LabelRemark;
	protected Label LabelMemberType;
	protected Label LabelArea;
	protected Label LabelAddress;
	protected TextBox TextBoxAddress;
	protected Label Label3;
	protected TextBox TextBoxVocation;
	protected RegularExpressionValidator RegularExpressionValidatorVocation;
	protected Label Label4;
	protected TextBox TextBoxPostalcode;
	protected RegularExpressionValidator RegularExpressionValidatorTitle10;
	protected Label LabelTel;
	protected TextBox TextBoxTel;
	protected RegularExpressionValidator RegularExpressionValidatorTitle11;
	protected Label Label9;
	protected TextBox TextBoxFax;
	protected RegularExpressionValidator RegularExpressionValidatorTitle13;
	protected Label LabelCardNum;
	protected TextBox TextBoxCardNum;
	protected RegularExpressionValidator RegularExpressionValidatorTitle17;
	protected Label Label16;
	protected TextBox TextBoxQQ;
	protected RegularExpressionValidator RegularExpressionValidatorTitle14;
	protected Label Label18;
	protected TextBox TextBoxWebSite;
	protected RegularExpressionValidator RegularExpressionValidatorTitle18;
	protected Label Label19;
	protected Label LabelCreditMoney;
	protected Label Label20;
	protected Label LabelRegeDate;
	protected Label Label22;
	protected Label LabelLastLoginTime;
	protected Label Label24;
	protected Label LabelScore;
	protected Label Label26;
	protected Label LabelLockAdvancePayment;
	protected Label Label21;
	protected Label LabelLockSocre;
	protected Label Label25;
	protected Label LabelCostMoney;
	protected Button ButtonConfirm;
	protected HiddenField CheckGuid;
	protected HiddenField HiddenFieldRegionCode;
	protected HiddenField HiddenFieldRegionValue;
	protected HtmlForm form1;
	[CompilerGenerated]
	private string string_5;
	protected DefaultProfile Profile
	{
		get
		{
			return (DefaultProfile)this.Context.Profile;
		}
	}
	protected HttpApplication ApplicationInstance
	{
		get
		{
			return this.Context.ApplicationInstance;
		}
	}
	private string ShopID
	{
		get;
		set;
	}
	protected void Page_Load(object sender, EventArgs e)
	{
		base.CheckLogin();
		if (!this.Page.IsPostBack)
		{
			this.method_5();
		}
	}
	private void method_5()
	{
		this.CheckGuid.Value = base.Request.QueryString["guid"];
		ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
		DataTable allShopInfoByGuid = shopNum1_Member_Action.GetAllShopInfoByGuid(this.CheckGuid.Value);
		if (allShopInfoByGuid != null && allShopInfoByGuid.Rows.Count > 0)
		{
			this.TextBoxName.Text = allShopInfoByGuid.Rows[0]["MemLoginID"].ToString();
			this.TextBoxRealName.Text = allShopInfoByGuid.Rows[0]["Name"].ToString();
			this.TextBoxMemberName.Text = allShopInfoByGuid.Rows[0]["RealName"].ToString();
			this.TextBoxMemberName.Text = allShopInfoByGuid.Rows[0]["RealName"].ToString();
			this.LabelCreditMoney.Text = allShopInfoByGuid.Rows[0]["CreditMoney"].ToString();
			this.TextBoxBirthday.Text = ((allShopInfoByGuid.Rows[0]["Birthday"].ToString() == string.Empty) ? "" : allShopInfoByGuid.Rows[0]["Birthday"].ToString());
			this.TextBoxEmail.Text = allShopInfoByGuid.Rows[0]["Email"].ToString();
			this.TextBoxVocation.Text = allShopInfoByGuid.Rows[0]["Vocation"].ToString();
			this.TextBoxPostalcode.Text = allShopInfoByGuid.Rows[0]["Postalcode"].ToString();
			this.TextBoxFax.Text = allShopInfoByGuid.Rows[0]["Fax"].ToString();
			this.ImagePhoto.Src = allShopInfoByGuid.Rows[0]["Photo"].ToString();
			string str = allShopInfoByGuid.Rows[0]["MemberRankGuid"].ToString();
			ShopNum1_MemberRank_Action shopNum1_MemberRank_Action = (ShopNum1_MemberRank_Action)LogicFactory.CreateShopNum1_MemberRank_Action();
			DataTable dataTable = shopNum1_MemberRank_Action.Search("'" + str + "'", 0);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				this.LabelMemberRankGuid.Text = dataTable.Rows[0]["Name"].ToString();
			}
			this.TextBoxQQ.Text = allShopInfoByGuid.Rows[0]["QQ"].ToString();
			this.TextBoxWebSite.Text = allShopInfoByGuid.Rows[0]["WebSite"].ToString();
			this.LabelRegeDate.Text = allShopInfoByGuid.Rows[0]["RegeDate"].ToString();
			this.TextBoxMobile.Text = allShopInfoByGuid.Rows[0]["Mobile"].ToString();
			this.LabelLockSocre.Text = allShopInfoByGuid.Rows[0]["LockSocre"].ToString();
			if (allShopInfoByGuid.Rows[0]["LoginDate"].ToString() == string.Empty)
			{
				this.LabelLastLoginTime.Text = "";
			}
			else if (Convert.ToDateTime(allShopInfoByGuid.Rows[0]["LoginDate"]).ToString("yyyy-MM-dd") == "1900-01-01")
			{
				this.LabelLastLoginTime.Text = "";
			}
			else
			{
				this.LabelLastLoginTime.Text = allShopInfoByGuid.Rows[0]["LoginDate"].ToString();
			}
			this.LabelScore.Text = allShopInfoByGuid.Rows[0]["Score"].ToString();
			this.LabelLockAdvancePayment.Text = allShopInfoByGuid.Rows[0]["LockAdvancePayment"].ToString();
			this.TextBoxAddress.Text = allShopInfoByGuid.Rows[0]["Address"].ToString();
			this.HiddenFieldRegionCode.Value = ((allShopInfoByGuid.Rows[0]["AddressCode"].ToString() == "" || allShopInfoByGuid.Rows[0]["AddressCode"].ToString() == "0") ? "0" : allShopInfoByGuid.Rows[0]["AddressCode"].ToString());
			this.HiddenFieldRegionValue.Value = ((allShopInfoByGuid.Rows[0]["AddressValue"].ToString() == "" || allShopInfoByGuid.Rows[0]["AddressValue"].ToString() == ",,|0,0,0") ? "0" : allShopInfoByGuid.Rows[0]["AddressValue"].ToString());
			this.HiddenFieldOriginalImge.Value = allShopInfoByGuid.Rows[0]["Photo"].ToString();
			this.ImagePhoto.Src = this.Page.ResolveUrl(allShopInfoByGuid.Rows[0]["Photo"].ToString());
			this.TextBoxBirthday.Text = ((allShopInfoByGuid.Rows[0]["Birthday"].ToString() == "") ? "" : Convert.ToDateTime(allShopInfoByGuid.Rows[0]["Birthday"]).ToString("yyyy-MM-dd"));
			this.TextBoxTel.Text = allShopInfoByGuid.Rows[0]["Tel"].ToString();
			this.DropDownListSex.SelectedValue = allShopInfoByGuid.Rows[0]["SEX"].ToString();
			this.LabelCostMoney.Text = allShopInfoByGuid.Rows[0]["CostMoney"].ToString();
			this.ViewState["Pwd"] = allShopInfoByGuid.Rows[0]["Pwd"].ToString();
			this.ViewState["PayPwd"] = allShopInfoByGuid.Rows[0]["PayPwd"].ToString();
			this.ViewState["Birthday"] = allShopInfoByGuid.Rows[0]["Birthday"].ToString();
			this.ViewState["Email"] = allShopInfoByGuid.Rows[0]["Email"].ToString();
			this.ViewState["Mobile"] = allShopInfoByGuid.Rows[0]["Mobile"].ToString();
			this.DropDownListSex.SelectedValue = allShopInfoByGuid.Rows[0]["Sex"].ToString();
			if (allShopInfoByGuid.Rows[0]["MemberType"].ToString() == "1")
			{
				this.LabelMemberType.Text = "个人会员";
			}
			else
			{
				this.LabelMemberType.Text = "店铺会员";
			}
		}
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		ShopNum1_Member shopNum1_Member = new ShopNum1_Member();
		ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
		if (!string.IsNullOrEmpty(this.TextBoxPwd2.Text))
		{
			if (this.TextBoxPwd.Text != this.TextBoxPwd2.Text)
			{
				shopNum1_Member.Pwd = this.ViewState["Pwd"].ToString();
			}
			else
			{
				shopNum1_Member.Pwd = Encryption.GetMd5Hash(this.TextBoxPwd.Text.Trim());
			}
		}
		else
		{
			shopNum1_Member.Pwd = this.ViewState["Pwd"].ToString();
		}
		if (!string.IsNullOrEmpty(this.TextBoxPayPwd2.Text))
		{
			if (this.TextBoxPayPwd.Text != this.TextBoxPayPwd2.Text)
			{
				shopNum1_Member.PayPwd = this.ViewState["PayPwd"].ToString();
			}
			else
			{
				shopNum1_Member.PayPwd = Encryption.GetMd5SecondHash(this.TextBoxPayPwd.Text.Trim());
			}
		}
		else
		{
			shopNum1_Member.PayPwd = this.ViewState["PayPwd"].ToString();
		}
		if (!string.IsNullOrEmpty(this.TextBoxBirthday.Text.Trim()))
		{
			if (Convert.ToDateTime(this.TextBoxBirthday.Text.Trim()) > DateTime.Now)
			{
				MessageBox.Show("出生日期选择有误");
				return;
			}
			shopNum1_Member.Birthday = new DateTime?(Convert.ToDateTime(this.TextBoxBirthday.Text.Trim()));
		}
		else
		{
			try
			{
				shopNum1_Member.Birthday = new DateTime?(Convert.ToDateTime(this.ViewState["Birthday"]));
			}
			catch
			{
			}
		}
		if (!string.IsNullOrEmpty(this.TextBoxEmail.Text.Trim()))
		{
			if (this.method_6())
			{
				MessageBox.Show("该邮箱已被使用!");
				return;
			}
			shopNum1_Member.Email = this.TextBoxEmail.Text.Trim();
		}
		else
		{
			shopNum1_Member.Email = this.ViewState["Email"].ToString();
		}
		if (!string.IsNullOrEmpty(this.TextBoxMobile.Text.Trim()))
		{
			if (this.method_7())
			{
				MessageBox.Show("该手机已被使用!");
				return;
			}
			shopNum1_Member.Mobile = this.TextBoxMobile.Text.Trim();
		}
		else
		{
			shopNum1_Member.Mobile = this.ViewState["Mobile"].ToString();
		}
		shopNum1_Member.MemLoginID = this.TextBoxName.Text.Trim();
		shopNum1_Member.Name = this.TextBoxRealName.Text.Trim();
		shopNum1_Member.LastLoginIP = HttpContext.Current.Request.UserHostAddress;
		shopNum1_Member.Address = this.TextBoxAddress.Text.Trim();
		shopNum1_Member.AddressCode = this.HiddenFieldRegionCode.Value;
		shopNum1_Member.AddressValue = this.HiddenFieldRegionValue.Value;
		shopNum1_Member.Area = this.GetAdress(shopNum1_Member.AddressValue) + shopNum1_Member.Address;
		shopNum1_Member.Vocation = this.TextBoxVocation.Text.Trim();
		shopNum1_Member.Postalcode = this.TextBoxPostalcode.Text.Trim();
		shopNum1_Member.Fax = this.TextBoxFax.Text.Trim();
		shopNum1_Member.ModifyUser = "admin";
		shopNum1_Member.ModifyTime = new DateTime?(DateTime.Now);
		shopNum1_Member.QQ = this.TextBoxQQ.Text.Trim();
		shopNum1_Member.WebSite = this.TextBoxWebSite.Text.Trim();
		shopNum1_Member.Sex = new byte?(Convert.ToByte(this.DropDownListSex.SelectedValue));
		shopNum1_Member.Tel = this.TextBoxTel.Text.Trim();
		shopNum1_Member.RealName = this.TextBoxMemberName.Text;
		try
		{
			if (this.HiddenFieldOriginalImge.Value != "")
			{
				shopNum1_Member.Photo = this.HiddenFieldOriginalImge.Value;
			}
			else
			{
				shopNum1_Member.Photo = "";
			}
			if (shopNum1_Member_Action.Update(shopNum1_Member) > 0)
			{
				base.Response.Redirect("Member_List.aspx");
			}
		}
		catch
		{
		}
	}
	protected void ButtonCheckEmail_Click(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(this.TextBoxEmail.Text))
		{
			this.method_6();
		}
		else
		{
			MessageBox.Show("电子邮箱为空");
		}
	}
	protected void ButtonCheckMobile_Click(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(this.TextBoxMobile.Text))
		{
			this.method_7();
		}
		else
		{
			MessageBox.Show("手机号码为空");
		}
	}
	private bool method_6()
	{
		ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
		bool result;
		if (shopNum1_Member_Action.CheckMemEmailByEmail(this.TextBoxEmail.Text.Trim()).Rows.Count > 0)
		{
			string b = shopNum1_Member_Action.CheckMemEmailByEmail(this.TextBoxEmail.Text.Trim()).Rows[0]["MemLoginID"].ToString();
			if (this.TextBoxName.Text.Trim() == b)
			{
				result = false;
			}
			else
			{
				MessageBox.Show("该邮箱已被使用!");
				result = true;
			}
		}
		else
		{
			result = false;
		}
		return result;
	}
	private bool method_7()
	{
		ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
		bool result;
		if (shopNum1_Member_Action.CheckMemMobileByMobile(this.TextBoxMobile.Text.Trim()).Rows.Count > 0)
		{
			string b = shopNum1_Member_Action.CheckMemMobileByMobile(this.TextBoxMobile.Text.Trim()).Rows[0]["MemLoginID"].ToString();
			if (this.TextBoxName.Text.Trim() == b)
			{
				result = false;
			}
			else
			{
				MessageBox.Show("该手机已被使用!");
				result = true;
			}
		}
		else
		{
			result = false;
		}
		return result;
	}
	protected string GetAdress(string Address)
	{
		string[] array = Address.Split(new char[]
		{
			'|'
		});
		string text = array[0].ToString();
		string[] array2 = text.Split(new char[]
		{
			','
		});
		string result = string.Empty;
		if (array2.Length == 3)
		{
			result = array2[0] + array2[1] + array2[2];
		}
		else if (array2.Length == 2)
		{
			result = array2[0] + array2[1];
		}
		else if (array2.Length == 1)
		{
			result = array2[0];
		}
		else
		{
			result = Address;
		}
		return result;
	}
}
