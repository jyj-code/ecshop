using ShopNum1.BusinessLogic;
using ShopNum1.CityFactory;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_SubstationManage_Operate : PageBase, IRequiresSessionState
{
	protected ScriptManager ScriptManager1;
	protected Label LabelPageTitle;
	protected DropDownList DropDownListProductGuid1;
	protected DropDownList DropDownListProductGuid2;
	protected DropDownList DropDownListProductGuid3;
	protected Label Label10;
	protected RequiredFieldValidator RequiredFieldValidator6;
	protected UpdatePanel UpdatePanel1;
	protected Label LabelCity;
	protected Label LabelID;
	protected TextBox TextBoxID;
	protected Label Label3;
	protected RequiredFieldValidator RequiredFieldValidatorName;
	protected RegularExpressionValidator RegularExpressionValidatorLogoName;
	protected Label LabelName;
	protected TextBox TextBoxName;
	protected Label Label2;
	protected RequiredFieldValidator RequiredFieldValidator1;
	protected RegularExpressionValidator RegularExpressionValidatorLogoWebSite;
	protected HiddenField HiddenFieldSubstationName;
	protected Label LabelKeywords;
	protected TextBox TextBoxDomainName;
	protected Label Label1;
	protected RequiredFieldValidator RequiredFieldValidator2;
	protected RegularExpressionValidator RegularExpressionValidatorLogoKeywords;
	protected Label LabelPeople;
	protected TextBox TextBoxPeople;
	protected Label Label5;
	protected RequiredFieldValidator RequiredFieldValidatorOrderID;
	protected Label LabelPhone;
	protected TextBox TextBoxPhone;
	protected Label Label4;
	protected RequiredFieldValidator RequiredFieldValidator3;
	protected RegularExpressionValidator RegularExpressionValidator1;
	protected Label Label6;
	protected TextBox TextBoxManageNumber;
	protected Label Label7;
	protected RequiredFieldValidator RequiredFieldValidator4;
	protected RegularExpressionValidator RegularExpressionValidator2;
	protected Label Label8;
	protected TextBox TextBoxManagePwd;
	protected Label Label9;
	protected RequiredFieldValidator RequiredFieldValidator5;
	protected Panel PanelShowRegiesr;
	protected CheckBox CheckBoxIsDisabled;
	protected CheckBox CheckBoxIsHot;
	protected Label LabelRemarks;
	protected TextBox TextBoxRemarks;
	protected RegularExpressionValidator RegularExpressionValidator3;
	protected Button ButtonConfirm;
	protected Button Button3;
	protected MessageShow MessageShow;
	protected HiddenField hiddenFieldGuid;
	protected HiddenField HiddenFieldCode;
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
		this.hiddenFieldGuid.Value = ((base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"]);
		if (!this.Page.IsPostBack)
		{
			this.DropDownListProductGuidBind();
			if (this.hiddenFieldGuid.Value != "0")
			{
				this.PanelShowRegiesr.Visible = false;
				this.UpdatePanel1.Visible = false;
				this.TextBoxID.ReadOnly = true;
				this.TextBoxManageNumber.ReadOnly = true;
				this.TextBoxManagePwd.ReadOnly = true;
				this.LabelPageTitle.Text = "编辑分站";
				this.GetCityInfo();
			}
		}
	}
	protected void DropDownListProductGuidBind()
	{
		this.DropDownListProductGuid1.Items.Clear();
		this.DropDownListProductGuid1.Items.Add(new ListItem("-请选择-", "-1"));
		ShopNum1_WebSite_Action shopNum1_WebSite_Action = (ShopNum1_WebSite_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_WebSite_Action();
		DataTable list = shopNum1_WebSite_Action.GetList("0");
		for (int i = 0; i < list.Rows.Count; i++)
		{
			this.DropDownListProductGuid1.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(), list.Rows[i]["Code"].ToString() + "/" + list.Rows[i]["ID"].ToString()));
		}
		this.DropDownListProductGuid1_SelectedIndexChanged(null, null);
	}
	protected void DropDownListProductGuid1_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.DropDownListProductGuid2.Items.Clear();
		this.DropDownListProductGuid2.Items.Add(new ListItem("-请选择-", "-1"));
		if (this.DropDownListProductGuid1.SelectedValue != "-1")
		{
			ShopNum1_WebSite_Action shopNum1_WebSite_Action = (ShopNum1_WebSite_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_WebSite_Action();
			DataTable list = shopNum1_WebSite_Action.GetList(this.DropDownListProductGuid1.SelectedValue.Split(new char[]
			{
				'/'
			})[1]);
			for (int i = 0; i < list.Rows.Count; i++)
			{
				this.DropDownListProductGuid2.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(), list.Rows[i]["Code"].ToString() + "/" + list.Rows[i]["ID"].ToString()));
			}
		}
		this.DropDownListProductGuid2_SelectedIndexChanged(null, null);
	}
	protected void DropDownListProductGuid2_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.DropDownListProductGuid3.Items.Clear();
		this.DropDownListProductGuid3.Items.Add(new ListItem("-请选择-", "-1"));
		if (this.DropDownListProductGuid2.SelectedValue != "-1")
		{
			ShopNum1_WebSite_Action shopNum1_WebSite_Action = (ShopNum1_WebSite_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_WebSite_Action();
			DataTable list = shopNum1_WebSite_Action.GetList(this.DropDownListProductGuid2.SelectedValue.Split(new char[]
			{
				'/'
			})[1]);
			for (int i = 0; i < list.Rows.Count; i++)
			{
				this.DropDownListProductGuid3.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(), list.Rows[i]["Code"].ToString() + "/" + list.Rows[i]["ID"].ToString()));
			}
		}
	}
	public void returnProductCategory()
	{
		if (this.DropDownListProductGuid3.SelectedValue != "-1")
		{
			this.HiddenFieldCode.Value = this.DropDownListProductGuid3.SelectedValue.Split(new char[]
			{
				'/'
			})[0];
		}
		else if (this.DropDownListProductGuid2.SelectedValue != "-1")
		{
			this.HiddenFieldCode.Value = this.DropDownListProductGuid2.SelectedValue.Split(new char[]
			{
				'/'
			})[0];
		}
		else if (this.DropDownListProductGuid1.SelectedValue != "-1")
		{
			this.HiddenFieldCode.Value = this.DropDownListProductGuid1.SelectedValue.Split(new char[]
			{
				'/'
			})[0];
		}
		else
		{
			this.HiddenFieldCode.Value = "-1";
		}
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		if (this.hiddenFieldGuid.Value == "0")
		{
			if (this.DropDownListProductGuid1.SelectedValue == "-1")
			{
				MessageBox.Show("分站地区必须选择！");
			}
			else if (!this.HaveSubstationID(this.TextBoxID.Text.Trim()))
			{
				MessageBox.Show("分站ID不能重复！");
			}
			else if (!this.HaveDomainName(this.TextBoxDomainName.Text.Trim()))
			{
				MessageBox.Show("分站域名不能重复！");
			}
			else
			{
				Regex regex = new Regex("[a-z0-9A-Z_]+");
				Match match = regex.Match(this.TextBoxID.Text.Trim());
				if (!match.Success)
				{
					MessageBox.Show("分站ID必须都是数字或者英文！");
				}
				else
				{
					Match match2 = regex.Match(this.TextBoxDomainName.Text.Trim());
					if (!match2.Success)
					{
						MessageBox.Show("分站域名必须都是数字或者英文！");
					}
					else if (this.TextBoxRemarks.Text.Length > 200)
					{
						MessageBox.Show("备注字符不得大于200个！");
					}
					else if (this.TextBoxID.Text == "all" || this.TextBoxID.Text == "All" || this.TextBoxID.Text == "-1")
					{
						MessageBox.Show("分站ID不能命名为all、All、-1 等特殊字符！");
					}
					else
					{
						ShopNum1_User_Action shopNum1_User_Action = (ShopNum1_User_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_User_Action();
						DataTable userByLoginID = shopNum1_User_Action.GetUserByLoginID(this.TextBoxManageNumber.Text.Trim(), 0);
						if (userByLoginID != null && userByLoginID.Rows.Count > 0)
						{
							MessageBox.Show("分站管理员账号已存在，请更换！");
						}
						else
						{
							this.ButtonConfirm.Enabled = false;
							this.Add();
						}
					}
				}
			}
		}
		else
		{
			ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_SubstationManage_Action();
			DataTable dataTable = shopNum1_SubstationManage_Action.Search(this.hiddenFieldGuid.Value.Replace("'", ""));
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				if (this.TextBoxDomainName.Text != dataTable.Rows[0]["DomainName"].ToString() && !this.HaveDomainName(this.TextBoxDomainName.Text.Trim()))
				{
					MessageBox.Show("分站域名不能重复！");
				}
				else
				{
					this.Edit();
				}
			}
		}
	}
	public void GetCityInfo()
	{
		ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_SubstationManage_Action();
		DataTable dataTable = shopNum1_SubstationManage_Action.Search(this.hiddenFieldGuid.Value.Replace("'", ""));
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			this.HiddenFieldSubstationName.Value = dataTable.Rows[0]["Name"].ToString();
			this.TextBoxID.Text = dataTable.Rows[0]["SubstationID"].ToString();
			this.TextBoxName.Text = dataTable.Rows[0]["Name"].ToString();
			this.TextBoxDomainName.Text = dataTable.Rows[0]["DomainName"].ToString();
			this.TextBoxPeople.Text = dataTable.Rows[0]["People"].ToString();
			this.TextBoxPhone.Text = dataTable.Rows[0]["Phone"].ToString();
			if (dataTable.Rows[0]["IsDisabled"].ToString() == "0")
			{
				this.CheckBoxIsDisabled.Checked = true;
			}
			else if (dataTable.Rows[0]["IsDisabled"].ToString() == "1")
			{
				this.CheckBoxIsDisabled.Checked = false;
			}
			this.TextBoxRemarks.Text = dataTable.Rows[0]["Remarks"].ToString();
			this.LabelCity.Text = this.GetCityName(dataTable.Rows[0]["CityCode"].ToString());
			if (dataTable.Rows[0]["IsHot"].ToString() == "0")
			{
				this.CheckBoxIsHot.Checked = false;
			}
			else if (dataTable.Rows[0]["IsHot"].ToString() == "1")
			{
				this.CheckBoxIsHot.Checked = true;
			}
		}
	}
	public string GetCityName(string code)
	{
		string result;
		try
		{
			string text = string.Empty;
			ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_SubstationManage_Action();
			if (code.Length == 3)
			{
				DataTable cityNameByCode = shopNum1_SubstationManage_Action.GetCityNameByCode(code);
				if (cityNameByCode != null && cityNameByCode.Rows.Count > 0)
				{
					text = cityNameByCode.Rows[0]["Name"].ToString();
				}
			}
			else if (code.Length == 6)
			{
				string text2 = string.Empty;
				string text3 = string.Empty;
				DataTable cityNameByCode2 = shopNum1_SubstationManage_Action.GetCityNameByCode(code.Substring(0, 3));
				if (cityNameByCode2 != null && cityNameByCode2.Rows.Count > 0)
				{
					text2 = cityNameByCode2.Rows[0]["Name"].ToString();
				}
				DataTable cityNameByCode3 = shopNum1_SubstationManage_Action.GetCityNameByCode(code);
				if (cityNameByCode3 != null && cityNameByCode3.Rows.Count > 0)
				{
					text3 = cityNameByCode3.Rows[0]["Name"].ToString();
				}
				text = text2 + "/" + text3;
			}
			else if (code.Length == 9)
			{
				string text2 = string.Empty;
				string text3 = string.Empty;
				string text4 = string.Empty;
				DataTable cityNameByCode2 = shopNum1_SubstationManage_Action.GetCityNameByCode(code.Substring(0, 3));
				if (cityNameByCode2 != null && cityNameByCode2.Rows.Count > 0)
				{
					text2 = cityNameByCode2.Rows[0]["Name"].ToString();
				}
				DataTable cityNameByCode3 = shopNum1_SubstationManage_Action.GetCityNameByCode(code.Substring(0, 6));
				if (cityNameByCode3 != null && cityNameByCode3.Rows.Count > 0)
				{
					text3 = cityNameByCode3.Rows[0]["Name"].ToString();
				}
				DataTable cityNameByCode4 = shopNum1_SubstationManage_Action.GetCityNameByCode(code);
				if (cityNameByCode4 != null && cityNameByCode4.Rows.Count > 0)
				{
					text4 = cityNameByCode4.Rows[0]["Name"].ToString();
				}
				text = string.Concat(new string[]
				{
					text2,
					"/",
					text3,
					"/",
					text4
				});
			}
			result = text;
		}
		catch (Exception)
		{
			result = "";
		}
		return result;
	}
	public void Add()
	{
		if (!this.HaveSameName(this.TextBoxName.Text.Trim()))
		{
			MessageBox.Show("分站名称重名，请重新填写！");
		}
		else
		{
			ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_SubstationManage_Action();
			ShopNum1_SubstationManage shopNum1_SubstationManage = new ShopNum1_SubstationManage();
			this.returnProductCategory();
			shopNum1_SubstationManage.CityCode = this.HiddenFieldCode.Value;
			shopNum1_SubstationManage.CreateTime = new DateTime?(DateTime.Now);
			shopNum1_SubstationManage.CreateUser = "admin";
			shopNum1_SubstationManage.DomainName = this.TextBoxDomainName.Text.Trim();
			shopNum1_SubstationManage.Guid = Guid.NewGuid();
			shopNum1_SubstationManage.IsDeleted = new int?(0);
			shopNum1_SubstationManage.IsDisabled = new int?(0);
			shopNum1_SubstationManage.ModifyTime = new DateTime?(DateTime.Now);
			shopNum1_SubstationManage.ModifyUser = "admin";
			shopNum1_SubstationManage.Name = this.TextBoxName.Text.Trim();
			shopNum1_SubstationManage.People = this.TextBoxPeople.Text.Trim();
			shopNum1_SubstationManage.Phone = this.TextBoxPhone.Text.Trim();
			shopNum1_SubstationManage.Remarks = this.TextBoxRemarks.Text.Trim();
			shopNum1_SubstationManage.SubstationID = this.TextBoxID.Text.Trim();
			shopNum1_SubstationManage.Letter = shopNum1_SubstationManage_Action.GetLetterByName(this.TextBoxName.Text.Trim().ToUpper().Substring(0, 1));
			shopNum1_SubstationManage.AdvancePayment = new decimal?(0m);
			if (this.CheckBoxIsHot.Checked)
			{
				shopNum1_SubstationManage.IsHot = new int?(1);
			}
			else
			{
				shopNum1_SubstationManage.IsHot = new int?(0);
			}
			try
			{
				int num = shopNum1_SubstationManage_Action.Add(shopNum1_SubstationManage);
				if (num > 0)
				{
					this.AddUser(this.TextBoxManageNumber.Text.Trim());
					this.method_5(this.TextBoxID.Text.Trim(), "Skin_Default.zip");
					this.CreateMenu();
					MessageBox.Show("成功开启分站！");
					this.ButtonConfirm.Enabled = true;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("开站失败！错误原因：" + ex.Message);
			}
		}
	}
	public void AddUser(string user)
	{
		ShopNum1_User_Action shopNum1_User_Action = (ShopNum1_User_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_User_Action();
		shopNum1_User_Action.Add(new ShopNum1_User
		{
			Guid = Guid.NewGuid(),
			LoginId = user,
			Pwd = Encryption.GetSHA1SecondHash(this.TextBoxManagePwd.Text.Trim()),
			RealName = this.TextBoxPeople.Text.Trim(),
			Sex = 1,
			Age = 0,
			WorkNumber = "",
			Email = "",
			Telephone = this.TextBoxPhone.Text.Trim(),
			IsForbid = 0,
			LoginTimes = 0,
			LastLoginTime = new DateTime?(DateTime.Now),
			LastLoginIP = string.Empty,
			LastModifyPasswordTime = new DateTime?(DateTime.Now),
			CreateUser = base.ShopNum1LoginID,
			CreateTime = DateTime.Now,
			ModifyUser = base.ShopNum1LoginID,
			ModifyTime = DateTime.Now,
			IsDeleted = 0,
			SubstationID = this.TextBoxID.Text.Trim(),
			PeopleType = new int?(0)
		}, new List<string>
		{
			new ShopNum1_GroupUser
			{
				GroupGuid = new Guid("237a876a-6cea-4e72-9f7f-a12a5d02ccbe")
			}.GroupGuid.ToString()
		});
	}
	private void method_5(string string_5, string string_6)
	{
		string path = "~/Template/CityTemplate/" + string_6;
		if (!File.Exists(this.Page.Server.MapPath("~/Template/CityTemplate/" + string_6)))
		{
			path = "~/Template/Shop/Skin_Default.zip";
		}
		string path2 = "";
		path2 = "~/ImgUpload/";
		string text = "~/City/" + string_5.ToString() + "/";
		if (!Directory.Exists(this.Page.Server.MapPath(text)))
		{
			try
			{
				Directory.CreateDirectory(this.Page.Server.MapPath(text));
				string path3 = text + Path.GetFileName(this.Page.Server.MapPath(path));
				File.Copy(this.Page.Server.MapPath(path), this.Page.Server.MapPath(path3));
				ShopNum1UnZipClass.UnZip(this.Page.Server.MapPath(path3), this.Page.Server.MapPath(text), null);
				File.Delete(this.Page.Server.MapPath(path3));
				goto IL_1BF;
			}
			catch
			{
				goto IL_1BF;
			}
		}
		try
		{
			if (!Directory.Exists(this.Page.Server.MapPath(path)))
			{
				string path3 = text + Path.GetFileName(this.Page.Server.MapPath(path));
				File.Copy(this.Page.Server.MapPath(path), this.Page.Server.MapPath(path3));
				ShopNum1UnZipClass.UnZip(this.Page.Server.MapPath(path3), this.Page.Server.MapPath(text), null);
				File.Delete(this.Page.Server.MapPath(path3));
			}
		}
		catch
		{
		}
		IL_1BF:
		if (!Directory.Exists(this.Page.Server.MapPath(path2)))
		{
			Directory.CreateDirectory(this.Page.Server.MapPath(path2));
		}
	}
	public void Edit()
	{
		if (this.HiddenFieldSubstationName.Value != this.TextBoxName.Text.Trim() && !this.HaveSameName(this.TextBoxName.Text.Trim()))
		{
			MessageBox.Show("分站名称重名，请重新填写！");
		}
		else
		{
			ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_SubstationManage_Action();
			ShopNum1_SubstationManage shopNum1_SubstationManage = new ShopNum1_SubstationManage();
			shopNum1_SubstationManage.DomainName = this.TextBoxDomainName.Text.Trim();
			if (this.CheckBoxIsDisabled.Checked)
			{
				shopNum1_SubstationManage.IsDisabled = new int?(0);
			}
			else
			{
				shopNum1_SubstationManage.IsDisabled = new int?(1);
			}
			shopNum1_SubstationManage.ModifyTime = new DateTime?(DateTime.Now);
			shopNum1_SubstationManage.ModifyUser = "admin";
			shopNum1_SubstationManage.Name = this.TextBoxName.Text.Trim();
			shopNum1_SubstationManage.People = this.TextBoxPeople.Text.Trim();
			shopNum1_SubstationManage.Phone = this.TextBoxPhone.Text.Trim();
			shopNum1_SubstationManage.Remarks = this.TextBoxRemarks.Text.Trim();
			shopNum1_SubstationManage.Guid = new Guid(this.hiddenFieldGuid.Value.Replace("'", ""));
			shopNum1_SubstationManage.Letter = shopNum1_SubstationManage_Action.GetLetterByName(this.TextBoxName.Text.Trim().ToUpper().Substring(0, 1));
			if (this.CheckBoxIsHot.Checked)
			{
				shopNum1_SubstationManage.IsHot = new int?(1);
			}
			else
			{
				shopNum1_SubstationManage.IsHot = new int?(0);
			}
			if (this.CheckBoxIsDisabled.Checked)
			{
				shopNum1_SubstationManage.IsDisabled = new int?(0);
			}
			else
			{
				shopNum1_SubstationManage.IsDisabled = new int?(1);
			}
			try
			{
				int num = shopNum1_SubstationManage_Action.Updata(shopNum1_SubstationManage);
				if (num > 0)
				{
					MessageBox.Show("修改成功！");
					base.Response.Redirect("SubstationManage_List.aspx");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("修改失败！错误原因：" + ex.Message);
			}
		}
	}
	public bool HaveSubstationID(string SubstationID)
	{
		ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_SubstationManage_Action();
		DataTable dataBySubstationID = shopNum1_SubstationManage_Action.GetDataBySubstationID(SubstationID);
		return dataBySubstationID == null || dataBySubstationID.Rows.Count <= 0;
	}
	public bool HaveDomainName(string DomainName)
	{
		ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_SubstationManage_Action();
		DataTable dataTable = shopNum1_SubstationManage_Action.SearchByDomainName(DomainName);
		return dataTable == null || dataTable.Rows.Count <= 0;
	}
	public bool HaveSameName(string Name)
	{
		ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_SubstationManage_Action();
		DataTable dataTable = shopNum1_SubstationManage_Action.SearchByName(Name);
		return dataTable == null || dataTable.Rows.Count <= 0;
	}
	public void CreateMenu()
	{
		ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_SubstationManage_Action();
		try
		{
			shopNum1_SubstationManage_Action.InsertSubstationManageNav(this.TextBoxID.Text.Trim());
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}
}
