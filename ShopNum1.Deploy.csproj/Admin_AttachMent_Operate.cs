using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_AttachMent_Operate : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected Label LabelTitle;
	protected Localize LocalizeTitle;
	protected TextBox TextBoxTitle;
	protected Label Label1;
	protected RequiredFieldValidator RequiredFieldValidatorName;
	protected RegularExpressionValidator RegularExpressionValidatorName;
	protected Localize LocalizeDropDownListAssociatedCategoryGuid;
	protected DropDownList DropDownListDropDownListAssociatedCategoryGuid;
	protected CompareValidator CompareCategoryGuid;
	protected Localize LocalizeAttachmentURL;
	protected FileUpload FileUploadAttachmentURL;
	protected Localize LocalizeDescription;
	protected TextBox TextBoxDescription;
	protected RegularExpressionValidator RegularExpressionValidatorDescription;
	protected Button ButtonConfirm;
	protected Button Button3;
	protected MessageShow MessageShow;
	protected HiddenField hiddenFieldGuid;
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
			this.AssociatedCategoryGuidBind();
		}
	}
	protected void AssociatedCategoryGuidBind()
	{
		ShopNum1_AttachMentCategory_Action shopNum1_AttachMentCategory_Action = (ShopNum1_AttachMentCategory_Action)LogicFactory.CreateShopNum1_AttachMentCategory_Action();
		DataTable dataTable = shopNum1_AttachMentCategory_Action.Search();
		for (int i = 0; i < dataTable.Rows.Count; i++)
		{
			this.DropDownListDropDownListAssociatedCategoryGuid.Items.Add(new ListItem(dataTable.Rows[i]["CategoryName"].ToString(), dataTable.Rows[i]["Guid"].ToString()));
		}
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		string text;
		if (!this.FileUploadAttachmentURL.HasFile)
		{
			MessageBox.Show("请选择要上传的文件！");
		}
		else if (ShopNum1UpLoad.FileUpLoad(this.FileUploadAttachmentURL, "/ImgUpload/attachfile/", out text))
		{
			ShopNum1_AttachMent shopNum1_AttachMent = new ShopNum1_AttachMent();
			shopNum1_AttachMent.Guid = Guid.NewGuid();
			shopNum1_AttachMent.Title = this.TextBoxTitle.Text;
			shopNum1_AttachMent.AttachmentURL = text;
			shopNum1_AttachMent.Description = this.TextBoxDescription.Text;
			shopNum1_AttachMent.AssociatedCategoryGuid = new Guid(this.DropDownListDropDownListAssociatedCategoryGuid.SelectedValue);
			ShopNum1_AttachMent_Action shopNum1_AttachMent_Action = (ShopNum1_AttachMent_Action)LogicFactory.CreateShopNum1_AttachMent_Action();
			int num = shopNum1_AttachMent_Action.Insert(shopNum1_AttachMent);
			if (num > 0)
			{
				base.OperateLog(new ShopNum1_OperateLog
				{
					Record = "新增" + this.TextBoxTitle.Text.Trim() + "成功",
					OperatorID = base.ShopNum1LoginID,
					IP = Globals.IPAddress,
					PageName = "AttachMent_Operate.aspx",
					Date = DateTime.Now
				});
				this.MessageShow.ShowMessage("AddYes");
				this.MessageShow.Visible = true;
				base.Response.Redirect("AttachMent_list.aspx");
			}
			else
			{
				this.MessageShow.ShowMessage("AddNo");
				this.MessageShow.Visible = true;
			}
		}
		else
		{
			MessageBox.Show(text);
		}
	}
	protected bool FileUpload(FileUpload fileUpload_0, string filepath, out string retstr)
	{
		Random random = new Random();
		string fileName = fileUpload_0.PostedFile.FileName;
		string str = HttpContext.Current.Server.MapPath(filepath);
		string str2 = fileName.Substring(fileName.LastIndexOf(".") + 1);
		string str3 = DateTime.Now.ToString("yyyyMMddHHmmss");
		string str4 = str3 + random.Next(100, 999).ToString() + "." + str2;
		bool result;
		if (!File.Exists(str + str4))
		{
			fileUpload_0.PostedFile.SaveAs(str + str4);
			retstr = filepath + str4;
			result = true;
		}
		else
		{
			retstr = "文件已存在！";
			result = false;
		}
		return result;
	}
}
