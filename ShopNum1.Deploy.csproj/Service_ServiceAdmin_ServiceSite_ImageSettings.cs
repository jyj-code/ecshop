using ShopNum1.Common;
using ShopNum1MultiEntity;
using System;
using System.Collections;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
public class Service_ServiceAdmin_ServiceSite_ImageSettings : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected Label Label13;
	protected RadioButtonList RadioButtonListIfSetWaterMark;
	protected Label Label14;
	protected TextBox TextBoxWaterMarkOriginalImge;
	protected HtmlImage ImgWaterMarkOriginalImge;
	protected Label Label15;
	protected RadioButtonList RadioButtonListWaterMarkImagePosition;
	protected Label Label16;
	protected TextBox TextBoxImageWaterMarkClarity;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxImageWaterMarkClarity;
	protected RegularExpressionValidator RegularExpressionValidatorImageWaterMarkClarity;
	protected TextBox TextBoxWaterMarkWords;
	protected DropDownList DropDownListWaterMarkWordsFont;
	protected Label Label19;
	protected TextBox TextBoxWaterMarkWordsFontSize;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxWaterMarkWordsFontSize;
	protected RegularExpressionValidator RegularExpressionValidatorWaterMarkWordsFontSize;
	protected Label Label21;
	protected TextBox TextBoxWaterMarkWordsColor;
	protected Label Label20;
	protected RadioButtonList RadioButtonListWordsWaterMarkPosition;
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
			this.HiddenFieldXmlPath.Value = base.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml");
			this.BindSetting();
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
				case "IfSetWaterMark":
					if (xmlNode2.InnerText == "0")
					{
						this.RadioButtonListIfSetWaterMark.SelectedValue = "0";
					}
					if (xmlNode2.InnerText == "1")
					{
						this.RadioButtonListIfSetWaterMark.SelectedValue = "1";
					}
					if (xmlNode2.InnerText == "2")
					{
						this.RadioButtonListIfSetWaterMark.SelectedValue = "2";
					}
					break;
				case "WaterMarkOriginalImge":
					this.TextBoxWaterMarkOriginalImge.Text = xmlNode2.InnerText;
					if (!string.IsNullOrEmpty(this.TextBoxWaterMarkOriginalImge.Text))
					{
						this.ImgWaterMarkOriginalImge.Src = this.TextBoxWaterMarkOriginalImge.Text;
					}
					else
					{
						this.ImgWaterMarkOriginalImge.Src = "/Images/noImage.gif";
					}
					break;
				case "WaterMarkImagePosition":
					this.RadioButtonListWaterMarkImagePosition.SelectedValue = xmlNode2.InnerText;
					break;
				case "ImageWaterMarkClarity":
					this.TextBoxImageWaterMarkClarity.Text = xmlNode2.InnerText;
					break;
				case "WaterMarkWords":
					this.TextBoxWaterMarkWords.Text = xmlNode2.InnerText;
					break;
				case "WaterMarkWordsFont":
				{
					ArrayList arrayList = WaterMarkFont.Font();
					for (int i = 0; i < arrayList.Count; i++)
					{
						this.DropDownListWaterMarkWordsFont.Items.Add(arrayList[i].ToString());
						if (xmlNode2.InnerText == arrayList[i].ToString())
						{
							this.DropDownListWaterMarkWordsFont.SelectedValue = arrayList[i].ToString();
						}
					}
					break;
				}
				case "WaterMarkWordsFontSize":
					this.TextBoxWaterMarkWordsFontSize.Text = xmlNode2.InnerText;
					break;
				case "WaterMarkWordsColor":
					this.TextBoxWaterMarkWordsColor.Text = xmlNode2.InnerText;
					break;
				case "WordsWaterMarkPosition":
					this.RadioButtonListWordsWaterMarkPosition.SelectedValue = xmlNode2.InnerText;
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
			this.Updata();
		}
		catch (Exception)
		{
			num = 0;
		}
		if (num > 0)
		{
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "图片水印设置成功",
				OperatorID = this.Session["AdminLoginCookie"].ToString(),
				IP = Globals.IPAddress,
				PageName = "ServiceSite_ImageSettings.aspx",
				Date = DateTime.Now
			});
			this.MessageShow.ShowMessage("EditYes");
			this.MessageShow.Visible = true;
			ShopSettings.ResetShopSetting();
		}
		else
		{
			this.MessageShow.ShowMessage("EditNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void Updata()
	{
		this.ImgWaterMarkOriginalImge.Src = this.TextBoxWaterMarkOriginalImge.Text;
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/IfSetWaterMark", this.RadioButtonListIfSetWaterMark.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/WaterMarkOriginalImge", this.TextBoxWaterMarkOriginalImge.Text.Trim());
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/WaterMarkImagePosition", this.RadioButtonListWaterMarkImagePosition.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/ImageWaterMarkClarity", this.TextBoxImageWaterMarkClarity.Text.Trim());
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/WaterMarkWords", this.TextBoxWaterMarkWords.Text.Trim());
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/WaterMarkWordsFont", this.DropDownListWaterMarkWordsFont.SelectedValue);
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/WaterMarkWordsFontSize", this.TextBoxWaterMarkWordsFontSize.Text.Trim());
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/WaterMarkWordsColor", this.TextBoxWaterMarkWordsColor.Text.Trim());
		XmlOperator.XmlNodeReplace(this.HiddenFieldXmlPath.Value, "ShopSetting/WordsWaterMarkPosition", this.RadioButtonListWordsWaterMarkPosition.SelectedValue);
		ShopSettings.ResetShopSetting();
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
