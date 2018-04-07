using ShopNum1.Common;
using System;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
public class Admin_SubstationManage_Install : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected HtmlHead Head1;
	protected Localize LocalizeName;
	protected TextBox TextBoxName;
	protected Label Label1;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxName;
	protected Localize LocalizeTitle;
	protected TextBox TextBoxTitle;
	protected Label Label2;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxTitle;
	protected Localize LocalizeDescription;
	protected TextBox TextBoxDescription;
	protected Label Label3;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxDescription;
	protected Localize LocalizeKeyWords;
	protected TextBox TextBoxKeyWords;
	protected Label Label4;
	protected RequiredFieldValidator RequiredFieldValidator4;
	protected Localize LocalizeCopyright;
	protected TextBox TextBoxCopyright;
	protected Label Label5;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxCopyright;
	protected Localize Localize3;
	protected TextBox txtShopUrl;
	protected Label Label10;
	protected Localize Localize9;
	protected TextBox TextBoxCopyrightLink;
	protected Label Label22;
	protected Localize LocalizeLogo;
	protected HiddenField HiddenFieldOriginalImge;
	protected HtmlImage ImageOriginalImge;
	protected Label Label11;
	protected Localize LocalizeLink;
	protected TextBox TextBoxLink;
	protected Label Label23;
	protected Localize Localize2;
	protected TextBox TextBoxShopOriginalImge;
	protected HtmlImage ImageShopOriginalImge;
	protected Label Label6;
	protected Localize Localize10;
	protected HiddenField hfPhoneEWM;
	protected HtmlImage imgPhoneEWM;
	protected Localize Localize11;
	protected HiddenField hfMicroEWM;
	protected HtmlImage ImgMicroEWM;
	protected Localize Localize4;
	protected TextBox TextBoxButtomInfo;
	protected Button ButtonEdit;
	protected MessageShow MessageShow;
	protected HiddenField HiddenFieldXmlPath;
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
			try
			{
				if (this.Page.Request.QueryString["SubstationID"] != null)
				{
					this.HiddenFieldXmlPath.Value = base.Server.MapPath(Globals.ApplicationPath + "/City/" + this.Page.Request.QueryString["SubstationID"].ToString() + "/Settings/ShopSetting.xml");
				}
				this.BindSetting();
			}
			catch (Exception)
			{
				MessageBox.Show("数据异常!可能是分站文件不存在！");
			}
		}
	}
	protected void BindSetting()
	{
		XmlNodeList xmlNodeList = XmlOperator.ReadXmlReturnNodeList(this.HiddenFieldXmlPath.Value, "ShopSetting");
		foreach (XmlNode xmlNode in xmlNodeList)
		{
			foreach (XmlNode xmlNode2 in xmlNode.ChildNodes)
			{
				string name = xmlNode2.Name;
				switch (name)
				{
				case "PersonShopUrl":
					this.txtShopUrl.Text = xmlNode2.InnerText;
					break;
				case "Name":
					this.TextBoxName.Text = xmlNode2.InnerText;
					break;
				case "Title":
					this.TextBoxTitle.Text = xmlNode2.InnerText;
					break;
				case "Description":
					this.TextBoxDescription.Text = xmlNode2.InnerText;
					break;
				case "KeyWords":
					this.TextBoxKeyWords.Text = xmlNode2.InnerText;
					break;
				case "Copyright":
					this.TextBoxCopyright.Text = xmlNode2.InnerText;
					break;
				case "CopyrightLink":
					this.TextBoxCopyrightLink.Text = xmlNode2.InnerText;
					break;
				case "Logo":
					this.HiddenFieldOriginalImge.Value = xmlNode2.InnerText;
					this.ImageOriginalImge.Src = this.Page.ResolveUrl(this.HiddenFieldOriginalImge.Value);
					break;
				case "Link":
					this.TextBoxLink.Text = xmlNode2.InnerText;
					break;
				case "ButtomInfo":
					this.TextBoxButtomInfo.Text = xmlNode2.InnerText;
					break;
				case "PhoneEWM":
					this.hfPhoneEWM.Value = xmlNode2.InnerText;
					this.imgPhoneEWM.Src = this.Page.ResolveUrl(this.hfPhoneEWM.Value);
					break;
				case "MicroEWM":
					this.hfMicroEWM.Value = xmlNode2.InnerText;
					this.ImgMicroEWM.Src = this.Page.ResolveUrl(this.hfMicroEWM.Value);
					break;
				}
			}
		}
	}
	protected void ButtonEdit_Click(object sender, EventArgs e)
	{
		int num = 1;
		try
		{
			XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/Name", this.TextBoxName.Text);
			XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/Title", this.TextBoxTitle.Text);
			XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/Description", this.TextBoxDescription.Text);
			XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/KeyWords", this.TextBoxKeyWords.Text);
			XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/Copyright", this.TextBoxCopyright.Text);
			XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/CopyrightLink", this.TextBoxCopyrightLink.Text);
			XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/Logo", this.HiddenFieldOriginalImge.Value);
			XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/Link", this.TextBoxLink.Text.Trim());
			XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ButtomInfo", this.TextBoxButtomInfo.Text.Trim());
			XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/PersonShopUrl", this.txtShopUrl.Text);
			XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/PhoneEWM", this.hfPhoneEWM.Value);
			XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/MicroEWM", this.hfMicroEWM.Value);
			ShopSettings.ResetShopSetting();
		}
		catch
		{
			this.MessageShow.ShowMessage("权限设置，请联系管理员");
			this.MessageShow.Visible = true;
			return;
		}
		if (num > 0)
		{
			this.MessageShow.ShowMessage("EditYes");
			this.MessageShow.Visible = true;
			ShopSettings.ResetShopSetting();
			this.ImageOriginalImge.Src = this.Page.ResolveUrl(this.HiddenFieldOriginalImge.Value);
			this.imgPhoneEWM.Src = this.Page.ResolveUrl(this.hfPhoneEWM.Value);
			this.ImgMicroEWM.Src = this.Page.ResolveUrl(this.hfMicroEWM.Value);
		}
		else
		{
			this.MessageShow.ShowMessage("EditNo");
			this.MessageShow.Visible = true;
		}
	}
	protected bool FileUpload(FileUpload fileUpload, string filepath, out string strext)
	{
		new Random();
		string fileName = fileUpload.PostedFile.FileName;
		FileInfo fileInfo = new FileInfo(fileName);
		string text = "~/Upload/";
		fileName.Substring(fileName.LastIndexOf(".") + 1);
		string arg_3E_0 = fileUpload.PostedFile.ContentType;
		int contentLength = fileUpload.PostedFile.ContentLength;
		bool result;
		if (fileName != "")
		{
			if (contentLength < 1024000)
			{
				if (!Directory.Exists(base.Server.MapPath(text)))
				{
					Directory.CreateDirectory(base.Server.MapPath(text));
				}
				fileUpload.PostedFile.SaveAs(base.Server.MapPath(text + fileInfo.Name));
				strext = fileName;
				result = true;
			}
			else
			{
				strext = "文件不能大于1M！";
				result = false;
			}
		}
		else
		{
			strext = "upload 为空！";
			result = false;
		}
		return result;
	}
}
