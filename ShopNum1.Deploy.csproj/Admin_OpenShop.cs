using ShopNum1.BusinessLogic;
using ShopNum1.CityFactory;
using ShopNum1.Common;
using ShopNum1.Email;
using ShopNum1.Factory;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_OpenShop : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected Label Label2;
	protected Label LabelMemLoginID;
	protected DropDownList DropDownListLv;
	protected RequiredFieldValidator RequiredFieldValidator1;
	protected Label Label10;
	protected RadioButton RadioButtonGr;
	protected RadioButton RadioButtonQy;
	protected Label LabelKeywords;
	protected TextBox TextBoxShopName;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxShopName;
	protected DropDownList DropDownListSubstationID;
	protected RequiredFieldValidator RequiredFieldValidator5;
	protected Label LabelOrderID;
	protected DropDownList DropDownListShopCategoryCode1;
	protected DropDownList DropDownListShopCategoryCode2;
	protected DropDownList DropDownListShopCategoryCode3;
	protected RequiredFieldValidator RequiredFieldValidator3;
	protected Label Label11;
	protected TextBox TextBoxMainGoods;
	protected RequiredFieldValidator RequiredFieldValidator2;
	protected Label LabelIsShow;
	protected DropDownList DropDownListRegionCode1;
	protected DropDownList DropDownListRegionCode2;
	protected DropDownList DropDownListRegionCode3;
	protected CompareValidator CompareValidatorDropDownListRegionCode1;
	protected Label LabelLogo;
	protected TextBox TextBoxdetailAddress;
	protected Label Label12;
	protected TextBox TextBoxPostalCode;
	protected Label Label13;
	protected TextBox TextBoxTel;
	protected Label Label14;
	protected TextBox TextBoxPhone;
	protected Label LabelWebSite;
	protected TextBox TextBoxIdentityCard;
	protected RequiredFieldValidator RequiredFieldValidator4;
	protected RegularExpressionValidator RegularExpressionValidatorTextBoxIdentityCard;
	protected Label Label7;
	protected FileUpload FileUploadBusinessLicense;
	protected Panel PanelBusinessLicense;
	protected Label Label8;
	protected FileUpload FileUploadCardImage;
	protected Panel PanelCardImage;
	protected Button ButtonSubmit;
	protected HiddenField HiddenFieldCode;
	protected HiddenField HiddenFieldRegionCode;
	protected HiddenField HiddenFieldRegion;
	protected HiddenField HiddenFieldGuid;
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
			this.HiddenFieldGuid.Value = ((base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"]);
			this.GetSubstationID();
			this.GetMemberName();
			this.DropDownListShopCategoryCode1Bind();
			this.DropDownListRegionCode1Bind();
			this.GetShopRank();
		}
	}
	protected void RadioButtonGr_CheckedChanged(object sender, EventArgs e)
	{
		this.PanelBusinessLicense.Visible = false;
	}
	protected void RadioButtonQy_CheckedChanged(object sender, EventArgs e)
	{
		this.PanelBusinessLicense.Visible = true;
	}
	public void GetShopRank()
	{
		Shop_Rank_Action shop_Rank_Action = (Shop_Rank_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Rank_Action();
		DataTable dataTable = shop_Rank_Action.Search(0);
		this.DropDownListLv.Items.Clear();
		this.DropDownListLv.Items.Add(new ListItem("-请选择-", "-1"));
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			foreach (DataRow dataRow in dataTable.Rows)
			{
				this.DropDownListLv.Items.Add(new ListItem(dataRow["Name"].ToString(), dataRow["Guid"].ToString()));
			}
		}
	}
	protected void BindShopCategory(string ShopCategoryCode)
	{
		if (ShopCategoryCode.Length >= 3)
		{
			for (int i = 0; i < this.DropDownListShopCategoryCode1.Items.Count; i++)
			{
				if (this.DropDownListShopCategoryCode1.Items[i].Value.ToString().StartsWith(ShopCategoryCode.Substring(0, 3) + "/"))
				{
					this.DropDownListShopCategoryCode1.SelectedValue = this.DropDownListShopCategoryCode1.Items[i].Value.ToString();
					IL_8A:
					this.DropDownListShopCategoryCode1_SelectedIndexChanged(null, null);
					goto IL_92;
				}
			}
            //goto IL_8A;
		}
		IL_92:
		if (ShopCategoryCode.Length >= 6)
		{
			for (int i = 0; i < this.DropDownListShopCategoryCode2.Items.Count; i++)
			{
				if (this.DropDownListShopCategoryCode2.Items[i].Value.ToString().StartsWith(ShopCategoryCode.Substring(0, 6) + "/"))
				{
					this.DropDownListShopCategoryCode2.SelectedValue = this.DropDownListShopCategoryCode2.Items[i].Value.ToString();
                    //IL_11C:
					this.DropDownListShopCategoryCode2_SelectedIndexChanged(null, null);
					goto IL_124;
				}
			}
            //goto IL_11C;
		}
		IL_124:
		if (ShopCategoryCode.Length >= 9)
		{
			for (int i = 0; i < this.DropDownListShopCategoryCode3.Items.Count; i++)
			{
				if (this.DropDownListShopCategoryCode3.Items[i].Value.ToString().StartsWith(ShopCategoryCode.Substring(0, 9) + "/"))
				{
					this.DropDownListShopCategoryCode3.SelectedValue = this.DropDownListShopCategoryCode3.Items[i].Value.ToString();
					break;
				}
			}
		}
	}
	protected void BindRegionCategory(string RegionCategory)
	{
		if (RegionCategory.Length >= 3)
		{
			for (int i = 0; i < this.DropDownListRegionCode1.Items.Count; i++)
			{
				if (this.DropDownListRegionCode1.Items[i].Value.ToString().StartsWith(RegionCategory.Substring(0, 3) + "/"))
				{
					this.DropDownListRegionCode1.SelectedValue = this.DropDownListRegionCode1.Items[i].Value.ToString();
                    //IL_8A:
					this.DropDownListRegionCode1_SelectedIndexChanged(null, null);
					goto IL_92;
				}
			}
            //goto IL_8A;
		}
		IL_92:
		if (RegionCategory.Length >= 6)
		{
			for (int i = 0; i < this.DropDownListRegionCode2.Items.Count; i++)
			{
				if (this.DropDownListRegionCode2.Items[i].Value.ToString().StartsWith(RegionCategory.Substring(0, 6) + "/"))
				{
					this.DropDownListRegionCode2.SelectedValue = this.DropDownListRegionCode2.Items[i].Value.ToString();
					IL_11C:
					this.DropDownListRegionCode2_SelectedIndexChanged(null, null);
					goto IL_124;
				}
			}
            //goto IL_11C;
		}
		IL_124:
		if (RegionCategory.Length >= 9)
		{
			for (int i = 0; i < this.DropDownListRegionCode3.Items.Count; i++)
			{
				if (this.DropDownListRegionCode3.Items[i].Value.ToString().StartsWith(RegionCategory + "/"))
				{
					this.DropDownListRegionCode3.SelectedValue = this.DropDownListRegionCode3.Items[i].Value.ToString();
					break;
				}
			}
		}
	}
	private string method_5(string string_5)
	{
		ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopInfoList_Action();
		string result;
		if (shopNum1_ShopInfoList_Action.CheckShopName(string_5) > 0)
		{
			result = "1";
		}
		else
		{
			result = "0";
		}
		return result;
	}
	public void ButtonSubmit_Click(object sender, EventArgs e)
	{
		string nameById = Common.GetNameById("Guid", "ShopNum1_ShopInfo", "  AND  ShopName='" + this.TextBoxShopName.Text.Trim() + "'");
		if (!string.IsNullOrEmpty(nameById))
		{
			MessageBox.Show("店铺名称已经存在！");
		}
		else
		{
			string nameById2 = Common.GetNameById("IdentityCard", "ShopNum1_ShopInfo", "  AND  IdentityCard='" + this.TextBoxIdentityCard.Text.Trim() + "'");
			if (!string.IsNullOrEmpty(nameById2))
			{
				MessageBox.Show("身份证已经存在！");
			}
			else
			{
				this.Add();
			}
		}
	}
	protected void Add()
	{
		ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopInfoList_Action();
		shopNum1_ShopInfoList_Action.UpdateMemberType(this.HiddenFieldGuid.Value, 2);
		ShopNum1_ShopInfo shopNum1_ShopInfo = new ShopNum1_ShopInfo();
		this.SetShopCategoryCode();
		this.SetShopRegionCode();
		shopNum1_ShopInfo.ShopCategoryID = this.HiddenFieldCode.Value.Trim();
		string cardImage = this.FileUpload(this.FileUploadCardImage, "IdentityCard");
		string businessLicense = "";
		shopNum1_ShopInfo.ShopName = this.TextBoxShopName.Text;
		shopNum1_ShopInfo.SalesRange = string.Concat(new string[]
		{
			this.DropDownListRegionCode1.SelectedItem.Text,
			",",
			this.DropDownListRegionCode2.SelectedItem.Text,
			",",
			this.DropDownListRegionCode3.SelectedItem.Text
		});
		shopNum1_ShopInfo.AddressValue = string.Concat(new string[]
		{
			this.DropDownListRegionCode1.SelectedItem.Text,
			",",
			this.DropDownListRegionCode2.SelectedItem.Text,
			",",
			this.DropDownListRegionCode3.SelectedItem.Text
		});
		shopNum1_ShopInfo.AddressCode = string.Concat(new string[]
		{
			this.DropDownListRegionCode1.SelectedValue.Split(new char[]
			{
				'/'
			})[0],
			",",
			this.DropDownListRegionCode2.SelectedValue.Split(new char[]
			{
				'/'
			})[0],
			",",
			this.DropDownListRegionCode3.SelectedValue.Split(new char[]
			{
				'/'
			})[0]
		});
		shopNum1_ShopInfo.Banner = "~/Shop/ShopAdmin/images/logodfwe.jpg";
		shopNum1_ShopInfo.CollectCount = 0;
		shopNum1_ShopInfo.ApplyTime = new DateTime?(DateTime.Now);
		shopNum1_ShopInfo.OpenTime = new DateTime?(DateTime.Now);
		shopNum1_ShopInfo.ModifyUser = this.LabelMemLoginID.Text;
		shopNum1_ShopInfo.ModifyTime = new DateTime?(DateTime.Now);
		shopNum1_ShopInfo.ShopRank = new Guid(this.DropDownListLv.SelectedValue);
		if (this.RadioButtonGr.Checked)
		{
			shopNum1_ShopInfo.ShopType = new int?(0);
		}
		else if (this.RadioButtonQy.Checked)
		{
			shopNum1_ShopInfo.ShopType = new int?(1);
		}
		shopNum1_ShopInfo.Tel = this.TextBoxTel.Text.Trim();
		shopNum1_ShopInfo.Phone = this.TextBoxPhone.Text.Trim();
		shopNum1_ShopInfo.MainGoods = this.TextBoxMainGoods.Text.Trim();
		if (this.GetDropDownListShopCategoryCodeName() == "-1")
		{
			shopNum1_ShopInfo.ShopCategory = "";
		}
		else
		{
			shopNum1_ShopInfo.ShopCategory = this.GetDropDownListShopCategoryCodeName();
		}
		shopNum1_ShopInfo.OrderID = new int?(ShopNum1_Common_Action.ReturnMaxID("OrderID", "ShopNum1_ShopInfo"));
		shopNum1_ShopInfo.MemLoginID = this.LabelMemLoginID.Text;
		shopNum1_ShopInfo.IsAudit = 1;
		shopNum1_ShopInfo.IsDeleted = new int?(0);
		shopNum1_ShopInfo.Name = this.LabelMemLoginID.Text;
		shopNum1_ShopInfo.IdentityCard = this.TextBoxIdentityCard.Text;
		shopNum1_ShopInfo.Address = this.TextBoxdetailAddress.Text;
		shopNum1_ShopInfo.CardImage = cardImage;
		shopNum1_ShopInfo.TemplateType = "";
		shopNum1_ShopInfo.RegistrationNum = "";
		shopNum1_ShopInfo.CompanName = "";
		shopNum1_ShopInfo.LegalPerson = "";
		shopNum1_ShopInfo.RegisteredCapital = 0m;
		shopNum1_ShopInfo.BusinessTerm = "";
		shopNum1_ShopInfo.BusinessScope = "";
		shopNum1_ShopInfo.BusinessLicense = businessLicense;
		shopNum1_ShopInfo.CompanIsAudit = -1;
		shopNum1_ShopInfo.IdentityIsAudit = -1;
		shopNum1_ShopInfo.Latitude = "";
		shopNum1_ShopInfo.Longitude = "";
		shopNum1_ShopInfo.SubstationID = this.DropDownListSubstationID.SelectedValue.ToString();
		try
		{
			shopNum1_ShopInfo.ShopID = int.Parse(ShopSettings.GetValue("InitialShopID"));
		}
		catch
		{
			shopNum1_ShopInfo.ShopID = 10000;
		}
		int shopIdMax = shopNum1_ShopInfoList_Action.GetShopIdMax();
		if (shopIdMax >= shopNum1_ShopInfo.ShopID)
		{
			shopNum1_ShopInfo.ShopID = shopIdMax + 1;
		}
		shopNum1_ShopInfo.ShopUrl = ShopSettings.GetValue("PersonShopUrl") + shopNum1_ShopInfo.ShopID.ToString();
		if (shopNum1_ShopInfoList_Action.RegistShopMember(shopNum1_ShopInfo) > 0)
		{
			ShopSettings.GetValue("ApplyOpenShopIsEmail");
			string shopGuid = shopNum1_ShopInfoList_Action.GetShopGuid(this.LabelMemLoginID.Text);
			base.Response.Redirect("UpdateShopURL.aspx?guid='" + shopGuid + "'&type=openshop");
		}
		else
		{
			MessageBox.Show("提交失败!");
		}
	}
	public void GetSubstationID()
	{
		this.DropDownListSubstationID.Items.Clear();
		this.DropDownListSubstationID.Items.Add(new ListItem("-请选择-", "-1"));
		ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_SubstationManage_Action();
		DataTable dataTable = shopNum1_SubstationManage_Action.Search(0);
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			foreach (DataRow dataRow in dataTable.Rows)
			{
				this.DropDownListSubstationID.Items.Add(new ListItem(dataRow["Name"].ToString(), dataRow["SubstationID"].ToString()));
			}
		}
	}
	public void SendMailForRegister(string MemLoginID, string Email, string Emailkey, string Phone, string strTitle, string emailTemplentGuid, string emailBody)
	{
		ShopNum1_MemberEmailExec_Action shopNum1_MemberEmailExec_Action = (ShopNum1_MemberEmailExec_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_MemberEmailExec_Action();
		int num = shopNum1_MemberEmailExec_Action.MemberEmailInsert(new ShopNum1_MemberEmailExec
		{
			ExtireTime = new DateTime?(DateTime.Now.AddHours(24.0)),
			Email = Email,
			Emailkey = Emailkey,
			Guid = new Guid?(Guid.NewGuid()),
			Isinvalid = new byte?(0),
			MemberID = MemLoginID,
			Phone = Phone,
			Type = 0
		});
		if (num > 0)
		{
			SendEmail sendEmail = new SendEmail();
			sendEmail.Emails(Email, MemLoginID, strTitle, emailTemplentGuid, emailBody);
		}
	}
	protected string FileUpload(FileUpload ControlName, string ImageName)
	{
		string result;
		if (ControlName.HasFile)
		{
			string fileName = ControlName.PostedFile.FileName;
			FileInfo fileInfo = new FileInfo(fileName);
			string text = "~/ImgUpload/ShopCertification";
			string path = string.Concat(new string[]
			{
				text,
				"/",
				ImageName,
				this.LabelMemLoginID.Text,
				fileInfo.Extension
			});
			string contentType = ControlName.PostedFile.ContentType;
			if (contentType == "image/bmp" || contentType == "image/gif" || contentType == "image/jpeg" || contentType == "image/x-png" || contentType == "image/png" || contentType == "image/jpg")
			{
				try
				{
					if (!Directory.Exists(this.Page.Server.MapPath(text)))
					{
						Directory.CreateDirectory(this.Page.Server.MapPath(text));
						ControlName.PostedFile.SaveAs(this.Page.Server.MapPath(path));
						result = ImageName + this.LabelMemLoginID.Text + fileInfo.Extension;
						return result;
					}
					if (File.Exists(this.Page.Server.MapPath(path)))
					{
						File.Delete(this.Page.Server.MapPath(path));
					}
					ControlName.PostedFile.SaveAs(this.Page.Server.MapPath(path));
					result = ImageName + this.LabelMemLoginID.Text + fileInfo.Extension;
					return result;
				}
				catch
				{
					MessageBox.Show("上传出错啦！");
					result = "0";
					return result;
				}
			}
			MessageBox.Show("图片格式不正确！");
			result = "0";
		}
		else
		{
			result = "0";
		}
		return result;
	}
	protected void DropDownListShopCategoryCode1Bind()
	{
		this.DropDownListShopCategoryCode1.Items.Clear();
		this.DropDownListShopCategoryCode1.Items.Add(new ListItem("-请选择-", "-1"));
		ShopNum1_ShopCategory_Action shopNum1_ShopCategory_Action = (ShopNum1_ShopCategory_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopCategory_Action();
		DataTable list = shopNum1_ShopCategory_Action.GetList("0");
		for (int i = 0; i < list.Rows.Count; i++)
		{
			this.DropDownListShopCategoryCode1.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(), list.Rows[i]["Code"].ToString() + "/" + list.Rows[i]["ID"].ToString()));
		}
		this.DropDownListShopCategoryCode1_SelectedIndexChanged(null, null);
	}
	protected void DropDownListShopCategoryCode1_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.DropDownListShopCategoryCode2.Items.Clear();
		this.DropDownListShopCategoryCode2.Items.Add(new ListItem("-请选择-", "-1"));
		if (this.DropDownListShopCategoryCode1.SelectedValue != "-1")
		{
			ShopNum1_ShopCategory_Action shopNum1_ShopCategory_Action = (ShopNum1_ShopCategory_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopCategory_Action();
			DataTable list = shopNum1_ShopCategory_Action.GetList(this.DropDownListShopCategoryCode1.SelectedValue.Split(new char[]
			{
				'/'
			})[1]);
			for (int i = 0; i < list.Rows.Count; i++)
			{
				this.DropDownListShopCategoryCode2.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(), list.Rows[i]["Code"].ToString() + "/" + list.Rows[i]["ID"].ToString()));
			}
		}
		this.DropDownListShopCategoryCode2_SelectedIndexChanged(null, null);
	}
	protected void DropDownListShopCategoryCode2_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.DropDownListShopCategoryCode3.Items.Clear();
		this.DropDownListShopCategoryCode3.Items.Add(new ListItem("-请选择-", "-1"));
		if (this.DropDownListShopCategoryCode2.SelectedValue != "-1")
		{
			ShopNum1_ShopCategory_Action shopNum1_ShopCategory_Action = (ShopNum1_ShopCategory_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopCategory_Action();
			DataTable list = shopNum1_ShopCategory_Action.GetList(this.DropDownListShopCategoryCode2.SelectedValue.Split(new char[]
			{
				'/'
			})[1]);
			for (int i = 0; i < list.Rows.Count; i++)
			{
				this.DropDownListShopCategoryCode3.Items.Add(new ListItem(list.Rows[i]["Name"].ToString(), list.Rows[i]["Code"].ToString() + "/" + list.Rows[i]["ID"].ToString()));
			}
		}
	}
	protected void DropDownListRegionCode1Bind()
	{
		this.DropDownListRegionCode1.Items.Clear();
		this.DropDownListRegionCode1.Items.Add(new ListItem("-省级-", "-1"));
		ShopNum1_Region_Action shopNum1_Region_Action = (ShopNum1_Region_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Region_Action();
		DataTable dataTable = shopNum1_Region_Action.SearchtRegionCategory(0, 0);
		for (int i = 0; i < dataTable.Rows.Count; i++)
		{
			this.DropDownListRegionCode1.Items.Add(new ListItem(dataTable.Rows[i]["Name"].ToString(), dataTable.Rows[i]["Code"].ToString() + "/" + dataTable.Rows[i]["ID"].ToString()));
		}
		this.DropDownListRegionCode1_SelectedIndexChanged(null, null);
	}
	protected void DropDownListRegionCode1_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.DropDownListRegionCode2.Items.Clear();
		this.DropDownListRegionCode2.Items.Add(new ListItem("-市级-", "-1"));
		if (this.DropDownListRegionCode1.SelectedValue != "-1")
		{
			ShopNum1_Region_Action shopNum1_Region_Action = (ShopNum1_Region_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Region_Action();
			DataTable dataTable = shopNum1_Region_Action.SearchtRegionCategory(Convert.ToInt32(this.DropDownListRegionCode1.SelectedValue.Split(new char[]
			{
				'/'
			})[1]), 0);
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				this.DropDownListRegionCode2.Items.Add(new ListItem(dataTable.Rows[i]["Name"].ToString(), dataTable.Rows[i]["Code"].ToString() + "/" + dataTable.Rows[i]["ID"].ToString()));
			}
		}
		this.DropDownListRegionCode2_SelectedIndexChanged(null, null);
	}
	protected void DropDownListRegionCode2_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.DropDownListRegionCode3.Items.Clear();
		this.DropDownListRegionCode3.Items.Add(new ListItem("-县级-", "-1"));
		if (this.DropDownListRegionCode2.SelectedValue != "-1")
		{
			ShopNum1_Region_Action shopNum1_Region_Action = (ShopNum1_Region_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Region_Action();
			DataTable dataTable = shopNum1_Region_Action.SearchtRegionCategory(Convert.ToInt32(this.DropDownListRegionCode2.SelectedValue.Split(new char[]
			{
				'/'
			})[1]), 0);
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				this.DropDownListRegionCode3.Items.Add(new ListItem(dataTable.Rows[i]["Name"].ToString(), dataTable.Rows[i]["Code"].ToString() + "/" + dataTable.Rows[i]["ID"].ToString()));
			}
		}
	}
	public void SetShopCategoryCode()
	{
		if (this.DropDownListShopCategoryCode3.SelectedValue != "-1")
		{
			this.HiddenFieldCode.Value = this.DropDownListShopCategoryCode3.SelectedValue.ToString().Split(new char[]
			{
				'/'
			})[0];
		}
		else if (this.DropDownListShopCategoryCode2.SelectedValue != "-1")
		{
			this.HiddenFieldCode.Value = this.DropDownListShopCategoryCode2.SelectedValue.ToString().Split(new char[]
			{
				'/'
			})[0];
		}
		else if (this.DropDownListShopCategoryCode1.SelectedValue != "-1")
		{
			this.HiddenFieldCode.Value = this.DropDownListShopCategoryCode1.SelectedValue.ToString().Split(new char[]
			{
				'/'
			})[0];
		}
		else
		{
			this.HiddenFieldCode.Value = "-1";
		}
	}
	public void SetShopRegionCode()
	{
		if (this.Page.Request["OpenShop$ctl00$DropDownListRegionCode3"] != null && this.Page.Request["OpenShop$ctl00$DropDownListRegionCode3"] != "-1")
		{
			this.HiddenFieldRegionCode.Value = this.Page.Request["OpenShop$ctl00$DropDownListRegionCode3"].ToString().Split(new char[]
			{
				'/'
			})[0];
			this.HiddenFieldRegion.Value = this.Page.Request["HiddenRegion1"].ToString() + this.Page.Request["HiddenRegion2"].ToString() + this.Page.Request["HiddenRegion3"].ToString();
		}
		else if (this.Page.Request["OpenShop$ctl00$DropDownListRegionCode2"] != null && this.Page.Request["OpenShop$ctl00$DropDownListRegionCode2"] != "-1")
		{
			this.HiddenFieldRegionCode.Value = this.Page.Request["OpenShop$ctl00$DropDownListRegionCode2"].ToString().Split(new char[]
			{
				'/'
			})[0];
			this.HiddenFieldRegion.Value = this.Page.Request["HiddenRegion1"].ToString() + this.Page.Request["HiddenRegion2"].ToString();
		}
		else if (this.Page.Request["OpenShop$ctl00$DropDownListRegionCode1"] != null && this.Page.Request["OpenShop$ctl00$DropDownListRegionCode1"] != "-1")
		{
			this.HiddenFieldRegionCode.Value = this.Page.Request["OpenShop$ctl00$DropDownListRegionCode1"].ToString().Split(new char[]
			{
				'/'
			})[0];
			this.HiddenFieldRegion.Value = this.Page.Request["HiddenRegion1"].ToString();
		}
		else
		{
			this.HiddenFieldRegion.Value = "-1";
		}
	}
	public string GetDropDownListShopCategoryCodeName()
	{
		string result;
		if (this.DropDownListShopCategoryCode3.SelectedValue != "-1")
		{
			result = string.Concat(new string[]
			{
				this.DropDownListShopCategoryCode1.SelectedItem.Text,
				"/",
				this.DropDownListShopCategoryCode2.SelectedItem.Text,
				"/",
				this.DropDownListShopCategoryCode3.SelectedItem.Text
			});
		}
		else if (this.DropDownListShopCategoryCode2.SelectedValue != "-1")
		{
			result = this.DropDownListShopCategoryCode1.SelectedItem.Text + "/" + this.DropDownListShopCategoryCode2.SelectedItem.Text;
		}
		else if (this.DropDownListShopCategoryCode1.SelectedValue != "-1")
		{
			result = this.DropDownListShopCategoryCode1.SelectedItem.Text;
		}
		else
		{
			result = "-1";
		}
		return result;
	}
	public void GetMemberName()
	{
		ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
		this.LabelMemLoginID.Text = shopNum1_Member_Action.GetMemLoginIDByGuid(this.HiddenFieldGuid.Value.ToString());
	}
}
