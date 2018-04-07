using AjaxControlToolkit;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_Member_Operate : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected HtmlHead Head1;
	protected ScriptManager ScriptManager1;
	protected Label LabelPageTitle;
	protected Label LabelMemLoginID;
	protected TextBox TextBoxMemLoginID;
	protected Label Label3;
	protected RequiredFieldValidator RequiredFieldValidatorMemLoginID;
	protected RegularExpressionValidator RegularExpressionValidator3;
	protected Button ButtonCheckName;
	protected Label LabelRealName;
	protected TextBox TextBoxRealName;
	protected RegularExpressionValidator RegularExpressionValidatorRealName;
	protected Label LabelBirthday;
	protected TextBox TextBoxBirthday;
	protected RegularExpressionValidator RegularExpressionValidatorStartDate;
	protected CalendarExtender CalendarExtender1;
	protected Label LabelMember;
	protected HtmlImage ImagePhoto;
	protected HiddenField HiddenFieldOriginalImge;
	protected Label LabelMobile;
	protected TextBox TextBoxMobile;
	protected Label Label10;
	protected RequiredFieldValidator RequiredFieldValidator3;
	protected RegularExpressionValidator RegularExpressionValidator2;
	protected Button ButtonCheckMobile;
	protected Label LabelEmail;
	protected TextBox TextBoxEmail;
	protected Label Label9;
	protected RequiredFieldValidator RequiredFieldValidator4;
	protected RegularExpressionValidator RegularExpressionValidatorTitle9;
	protected RegularExpressionValidator RegularExpressionValidator1;
	protected Button ButtonEmail;
	protected Label LabelSex;
	protected DropDownList DropDownListSex;
	protected Label Label8;
	protected Label LabelPwd;
	protected TextBox TextBoxPwd;
	protected Label Label1;
	protected RequiredFieldValidator RequiredFieldValidator1;
	protected RegularExpressionValidator RegularExpressionValidatorPwd;
	protected Label LabelPwd2;
	protected TextBox TextBoxPwd2;
	protected Label Label2;
	protected RequiredFieldValidator RequiredFieldValidator2;
	protected RegularExpressionValidator RegularExpressionValidatorPwd2;
	protected CompareValidator CompareValidator1;
	protected Label LabelPayPwd;
	protected TextBox TextBoxPayPwd;
	protected RegularExpressionValidator RegularExpressionValidatorPayPwd;
	protected Label LabelPayPwd2;
	protected TextBox TextBoxPayPwd2;
	protected Label Label11;
	protected RegularExpressionValidator RegularExpressionValidatorPayPwd2;
	protected CompareValidator CompareValidator2;
	protected Label LabelCreditMoney;
	protected TextBox TextBoxCreditMoney;
	protected RegularExpressionValidator RegularExpressionValidatorCreditMoney;
	protected Label LabelVocation;
	protected TextBox TextBoxVocation;
	protected RegularExpressionValidator RegularExpressionValidatorVocation;
	protected Label LabelArea;
	protected Label LabelAddress;
	protected TextBox TextBoxAddress;
	protected RegularExpressionValidator RegularExpressionValidatorTitle8;
	protected Label LabelPostalcode;
	protected TextBox TextBoxPostalcode;
	protected RegularExpressionValidator RegularExpressionValidatorTitle10;
	protected Label LabelTel;
	protected TextBox TextBoxTel;
	protected RegularExpressionValidator RegularExpressionValidatorTitle11;
	protected Label LabelFax;
	protected TextBox TextBoxFax;
	protected RegularExpressionValidator RegularExpressionValidatorTitle13;
	protected Label LabelQQ;
	protected TextBox TextBoxQQ;
	protected RegularExpressionValidator RegularExpressionValidatorTitle14;
	protected Label LabelMsn;
	protected TextBox TextBoxMsn;
	protected RegularExpressionValidator RegularExpressionValidatorTitle16;
	protected Label LabelCardNum;
	protected TextBox TextBoxCardNum;
	protected RegularExpressionValidator RegularExpressionValidatorTitle17;
	protected Label LabelWebSite;
	protected TextBox TextBoxWebSite;
	protected RegularExpressionValidator RegularExpressionValidatorTitle18;
	protected Label LabelQuestion;
	protected DropDownList DropDownListQuestion;
	protected Label LabelAnswer;
	protected TextBox TextBoxAnswer;
	protected RegularExpressionValidator RegularExpressionValidatorTitle19;
	protected Label LabelIsForbid;
	protected DropDownList DropDownListIsForbid;
	protected Button ButtonConfirm;
	protected Button Button3;
	protected MessageShow MessageShow;
	protected HiddenField hiddenGuid;
	protected HiddenField HiddenFieldRegionCode;
	protected HiddenField HiddenFieldRegionValue;
	protected HtmlForm form1;
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
	protected void Page_Load(object sender, EventArgs e)
	{
		base.CheckLogin();
		if (!this.Page.IsPostBack)
		{
			this.hiddenGuid.Value = ((base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"]);
			if (this.hiddenGuid.Value != "0")
			{
				this.LabelPageTitle.Text = "【 编辑会员 】";
			}
		}
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		if (this.ButtonConfirm.ToolTip == "Submit")
		{
			if (this.TextBoxMemLoginID.Text.Trim() == "")
			{
				MessageBox.Show("会员ID不能为空");
			}
			else
			{
				ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
				if (shopNum1_Member_Action.CheckmemLoginID(this.TextBoxMemLoginID.Text.Trim()) > 0)
				{
					MessageBox.Show("该会员名已经存在");
				}
				else if (!string.IsNullOrEmpty(this.TextBoxEmail.Text) && shopNum1_Member_Action.CheckmemEmail(this.TextBoxEmail.Text.Trim()) > 0)
				{
					MessageBox.Show("该邮箱已注册!");
				}
				else if (!string.IsNullOrEmpty(this.TextBoxPwd.Text))
				{
					if (!string.IsNullOrEmpty(this.TextBoxEmail.Text) && shopNum1_Member_Action.CheckMemMobileByMobile1(this.TextBoxMobile.Text.Trim()) > 0)
					{
						MessageBox.Show("该手机已注册!");
					}
					else
					{
						ShopNum1_Member shopNum1_Member = new ShopNum1_Member();
						shopNum1_Member.MemLoginID = this.TextBoxMemLoginID.Text.Trim();
						shopNum1_Member.Email = this.TextBoxEmail.Text.Trim();
						shopNum1_Member.Pwd = Encryption.GetMd5Hash(this.TextBoxPwd.Text.Trim());
						if (this.HiddenFieldRegionCode.Value != "0")
						{
							shopNum1_Member.AddressCode = this.HiddenFieldRegionCode.Value;
							if (this.HiddenFieldRegionValue.Value != ",,|0,0,0")
							{
								shopNum1_Member.AddressValue = this.HiddenFieldRegionValue.Value;
							}
							else
							{
								shopNum1_Member.AddressValue = "";
							}
						}
						else
						{
							shopNum1_Member.AddressCode = "";
							shopNum1_Member.AddressValue = "";
						}
						shopNum1_Member.Name = this.TextBoxRealName.Text.Trim();
						shopNum1_Member.IsDeleted = 0;
						shopNum1_Member.MemberType = new int?(1);
						shopNum1_Member.Score = 0;
						shopNum1_Member.MemberRank = new int?(0);
						shopNum1_Member.LoginTime = new int?(0);
						shopNum1_Member.LockSocre = new int?(0);
						shopNum1_Member.AdvancePayment = new decimal?(0m);
						shopNum1_Member.LockAdvancePayment = new decimal?(0m);
						shopNum1_Member.CostMoney = new decimal?(0m);
						shopNum1_Member.IsMailActivation = new int?(1);
						if (!string.IsNullOrEmpty(this.TextBoxPayPwd2.Text))
						{
							if (this.TextBoxPayPwd.Text != this.TextBoxPayPwd2.Text)
							{
								shopNum1_Member.PayPwd = "";
							}
							else
							{
								shopNum1_Member.PayPwd = Encryption.GetMd5SecondHash(this.TextBoxPayPwd.Text.Trim());
							}
						}
						else
						{
							shopNum1_Member.PayPwd = "";
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
							shopNum1_Member.Birthday = new DateTime?(DateTime.Now);
						}
						shopNum1_Member.IsForbid = new int?(Convert.ToInt32(this.DropDownListIsForbid.SelectedValue));
						shopNum1_Member.Sex = new byte?(Convert.ToByte(this.DropDownListSex.SelectedValue));
						if (this.TextBoxCreditMoney.Text == string.Empty)
						{
							this.TextBoxCreditMoney.Text = "0";
						}
						shopNum1_Member.CreditMoney = new decimal?(Convert.ToDecimal(this.TextBoxCreditMoney.Text.Trim()));
						shopNum1_Member.Photo = this.HiddenFieldOriginalImge.Value.Trim();
						shopNum1_Member.Vocation = this.TextBoxVocation.Text.Trim();
						shopNum1_Member.Address = this.TextBoxAddress.Text;
						shopNum1_Member.Postalcode = this.TextBoxPostalcode.Text.Trim();
						shopNum1_Member.Mobile = this.TextBoxMobile.Text.Trim();
						shopNum1_Member.Fax = this.TextBoxFax.Text.Trim();
						shopNum1_Member.QQ = this.TextBoxQQ.Text.Trim();
						shopNum1_Member.Msn = this.TextBoxMsn.Text.Trim();
						shopNum1_Member.WebSite = this.TextBoxWebSite.Text.Trim();
						shopNum1_Member.Question = this.DropDownListQuestion.SelectedValue.Trim();
						shopNum1_Member.Answer = this.TextBoxAnswer.Text.Trim();
						shopNum1_Member.Tel = this.TextBoxTel.Text.Trim();
						shopNum1_Member.RegeDate = new DateTime?(Convert.ToDateTime(DateTime.Now));
						shopNum1_Member.ModifyUser = "admin";
						shopNum1_Member.ModifyTime = new DateTime?(DateTime.Now);
						shopNum1_Member.PromotionMemLoginID = "";
						shopNum1_Member.IdentityCard = this.TextBoxCardNum.Text.Trim();
						shopNum1_Member.Area = this.GetAdress(shopNum1_Member.AddressValue) + shopNum1_Member.Address;
						ShopNum1_MemberRank_Action shopNum1_MemberRank_Action = (ShopNum1_MemberRank_Action)LogicFactory.CreateShopNum1_MemberRank_Action();
						DataTable defaultMemberRank = shopNum1_MemberRank_Action.GetDefaultMemberRank();
						Guid memberRankGuid = Guid.NewGuid();
						try
						{
							if (defaultMemberRank != null && defaultMemberRank.Rows.Count > 0)
							{
								memberRankGuid = new Guid(defaultMemberRank.Rows[0]["Guid"].ToString());
							}
							else
							{
								memberRankGuid = new Guid("a6da75ad-e1ac-4df8-99ad-980294a16581");
							}
						}
						catch (Exception)
						{
							memberRankGuid = new Guid("a6da75ad-e1ac-4df8-99ad-980294a16581");
						}
						shopNum1_Member.MemberRankGuid = memberRankGuid;
						if (shopNum1_Member_Action.AddByAdmin(shopNum1_Member) == 1)
						{
							this.MessageShow.ShowMessage("AddYes");
							this.MessageShow.Visible = true;
							base.Response.Redirect("Member_List.aspx");
						}
						else
						{
							this.MessageShow.ShowMessage("AddNo");
							this.MessageShow.Visible = true;
						}
					}
				}
			}
		}
	}
	protected void ClearControl()
	{
		this.TextBoxMemLoginID.Text = string.Empty;
		this.TextBoxEmail.Text = string.Empty;
		this.TextBoxPwd.Text = string.Empty;
		this.TextBoxPwd2.Text = string.Empty;
		this.TextBoxPayPwd.Text = string.Empty;
		this.TextBoxPayPwd2.Text = string.Empty;
		this.TextBoxBirthday.Text = string.Empty;
		this.TextBoxCreditMoney.Text = string.Empty;
		this.TextBoxRealName.Text = string.Empty;
		this.TextBoxVocation.Text = string.Empty;
		this.TextBoxAddress.Text = string.Empty;
		this.TextBoxPostalcode.Text = string.Empty;
		this.TextBoxTel.Text = string.Empty;
		this.TextBoxMobile.Text = string.Empty;
		this.TextBoxFax.Text = string.Empty;
		this.TextBoxQQ.Text = string.Empty;
		this.TextBoxMsn.Text = string.Empty;
		this.TextBoxCardNum.Text = string.Empty;
		this.TextBoxWebSite.Text = string.Empty;
		this.DropDownListQuestion.SelectedValue = (this.TextBoxAnswer.Text = string.Empty);
		this.DropDownListIsForbid.SelectedValue = "0";
	}
	protected string GetAdress(string AddressValue)
	{
		string[] array = AddressValue.Split(new char[]
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
			result = AddressValue;
		}
		return result;
	}
	protected void ButtonCheckName_Click(object sender, EventArgs e)
	{
		if (this.TextBoxMemLoginID.Text.Trim() == "")
		{
			MessageBox.Show("会员ID不能为空");
		}
		else
		{
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
			if (shopNum1_Member_Action.CheckmemLoginID(this.TextBoxMemLoginID.Text.Trim()) > 0)
			{
				MessageBox.Show("该会员名已存在!");
			}
			else
			{
				MessageBox.Show("该会员名可用!");
			}
		}
	}
	protected void ButtonCheckEmail_Click(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(this.TextBoxEmail.Text))
		{
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
			if (shopNum1_Member_Action.CheckmemEmail(this.TextBoxEmail.Text.Trim()) > 0)
			{
				MessageBox.Show("该邮箱已注册!");
			}
			else
			{
				MessageBox.Show("该邮箱可用!");
			}
		}
		else
		{
			MessageBox.Show("邮箱不能为空");
		}
	}
	protected void ButtonCheckMobile_Click(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(this.TextBoxMobile.Text))
		{
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
			if (shopNum1_Member_Action.CheckMemMobileByMobile1(this.TextBoxMobile.Text.Trim()) > 0)
			{
				MessageBox.Show("该手机已注册!");
			}
			else
			{
				MessageBox.Show("该手机可用!");
			}
		}
		else
		{
			MessageBox.Show("手机号码为空");
		}
	}
}
