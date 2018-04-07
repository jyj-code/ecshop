using ShopNum1.Common;
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
public class Admin_ShopEnsure_Operate : PageBase, IRequiresSessionState
{
	protected Label Label_Oprate;
	protected Label Label2;
	protected TextBox TextBoxName;
	protected RequiredFieldValidator RequiredFieldValidatorName;
	protected RegularExpressionValidator RegularExpressionValidatorTitle;
	protected Label Label4;
	protected FileUpload FileUploadImage;
	protected Image ImagePath;
	protected Label Label5;
	protected TextBox textBoxhref;
	protected Label LabelSpec;
	protected TextBox TextBoxEnsureMoney;
	protected RegularExpressionValidator RegularExpressionValidatorTextBoxEnsureMoney;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxEnsureMoney;
	protected Label Label1;
	protected TextBox TextBoxRemark;
	protected Button btnConfirm;
	protected Button Button3;
	protected MessageShow MessageShow;
	protected HiddenField CheckGuid;
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
		this.CheckGuid.Value = ((base.Request.QueryString["id"] == null) ? "0" : base.Request.QueryString["id"]);
		if (!this.Page.IsPostBack && this.CheckGuid.Value != "0")
		{
			this.Edit();
			this.Label_Oprate.Text = "编辑店铺担保";
			this.btnConfirm.Text = "更新";
		}
	}
	protected void btnConfirm_Click(object sender, EventArgs e)
	{
		if (this.CheckGuid.Value == "0")
		{
			this.Add();
		}
		else
		{
			this.Updata();
		}
	}
	protected void Add()
	{
		ShopNum1_ShopEnsure shopNum1_ShopEnsure = new ShopNum1_ShopEnsure();
		shopNum1_ShopEnsure.Name = this.TextBoxName.Text;
		shopNum1_ShopEnsure.ImagePath = this.method_5();
		if (shopNum1_ShopEnsure.ImagePath == "flag")
		{
			MessageBox.Show("请上传图片！");
		}
		else
		{
			shopNum1_ShopEnsure.Href = this.textBoxhref.Text;
			shopNum1_ShopEnsure.Remark = this.TextBoxRemark.Text;
			shopNum1_ShopEnsure.EnsureMoney = Convert.ToDecimal(this.TextBoxEnsureMoney.Text);
			Shop_Ensure_Action shop_Ensure_Action = (Shop_Ensure_Action)LogicFactory.CreateShop_Ensure_Action();
			int num = shop_Ensure_Action.Add(shopNum1_ShopEnsure);
			if (num > 0)
			{
				this.MessageShow.Visible = true;
				this.MessageShow.ShowMessage("AddYes");
			}
			else
			{
				this.MessageShow.Visible = true;
				this.MessageShow.ShowMessage("AddNo");
			}
		}
	}
	private string method_5()
	{
		string result;
		if (this.FileUploadImage.HasFile)
		{
			string contentType = this.FileUploadImage.PostedFile.ContentType;
			if (contentType.ToLower() == "image/bmp" || contentType.ToLower() == "image/gif" || contentType.ToLower() == "image/jpeg" || contentType.ToLower() == "image/png" || contentType.ToLower() == "image/pjpeg")
			{
				string fileName = Operator.FilterString(this.FileUploadImage.PostedFile.FileName);
				Random random = new Random();
				string str = (10 + random.Next(70)).ToString();
				string str2 = DateTime.Now.ToString("yyyyMMddHHmmss") + str;
				FileInfo fileInfo = new FileInfo(fileName);
				string str3 = str2 + "_" + fileInfo.Name;
				string text = base.Server.MapPath("~/ImgUpload/ShopEnsureImg/" + str3);
				if (!Directory.Exists(base.Server.MapPath("~/ImgUpload/ShopEnsureImg")))
				{
					Directory.CreateDirectory(text);
				}
				if (File.Exists(text))
				{
					File.Delete(text);
				}
				this.FileUploadImage.SaveAs(text);
				result = "~/ImgUpload/ShopEnsureImg/" + str3;
			}
			else
			{
				MessageBox.Show("请选择正确的图片格式！");
				result = "flag";
			}
		}
		else
		{
			result = "flag";
		}
		return result;
	}
	protected void Edit()
	{
		Shop_Ensure_Action shop_Ensure_Action = (Shop_Ensure_Action)LogicFactory.CreateShop_Ensure_Action();
		DataTable shopEnsure = shop_Ensure_Action.GetShopEnsure(Convert.ToInt32(this.CheckGuid.Value.Replace("'", "")));
		this.TextBoxName.Text = shopEnsure.Rows[0]["Name"].ToString();
		this.textBoxhref.Text = shopEnsure.Rows[0]["Href"].ToString();
		this.TextBoxRemark.Text = shopEnsure.Rows[0]["Remark"].ToString();
		this.TextBoxEnsureMoney.Text = shopEnsure.Rows[0]["EnsureMoney"].ToString();
		this.ImagePath.ImageUrl = this.Page.ResolveClientUrl(shopEnsure.Rows[0]["ImagePath"].ToString());
		this.ViewState["imgPath"] = shopEnsure.Rows[0]["ImagePath"].ToString();
	}
	protected void Updata()
	{
		ShopNum1_ShopEnsure shopNum1_ShopEnsure = new ShopNum1_ShopEnsure();
		shopNum1_ShopEnsure.Name = this.TextBoxName.Text;
		if (this.method_5() != "flag")
		{
			shopNum1_ShopEnsure.ImagePath = this.method_5();
		}
		else
		{
			shopNum1_ShopEnsure.ImagePath = this.ViewState["imgPath"].ToString();
		}
		shopNum1_ShopEnsure.Href = this.textBoxhref.Text;
		shopNum1_ShopEnsure.Remark = this.TextBoxRemark.Text;
		shopNum1_ShopEnsure.EnsureMoney = Convert.ToDecimal(this.TextBoxEnsureMoney.Text);
		shopNum1_ShopEnsure.ID = int.Parse(this.CheckGuid.Value.Replace("'", ""));
		Shop_Ensure_Action shop_Ensure_Action = (Shop_Ensure_Action)LogicFactory.CreateShop_Ensure_Action();
		int num = shop_Ensure_Action.Updata(shopNum1_ShopEnsure);
		if (num > 0)
		{
			base.Response.Redirect("ShopEnsure_List.aspx");
		}
		else
		{
			this.MessageShow.Visible = true;
			this.MessageShow.ShowMessage("UpdateNo1");
		}
	}
}
