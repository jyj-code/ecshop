using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class CategoryAdID_Operate : PageBase, IRequiresSessionState
{
	protected TextBox TextBoxAdName;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxAdName;
	protected DropDownList DropDownListPageName;
	protected CompareValidator CompareDdl;
	protected TextBox TextBoxAdWidth;
	protected RegularExpressionValidator RegularExpressionValidatorRepertory;
	protected TextBox TextBoxHeight;
	protected RegularExpressionValidator RegularExpressionValidator1;
	protected TextBox TextBoxAdDefaultPic;
	protected RegularExpressionValidator RegularExpressionValidatorLogo;
	protected HtmlImage ImageOriginalImge;
	protected TextBox TextBoxDefaultLike;
	protected RegularExpressionValidator RegularExpressionValidator2;
	protected TextBox TextBoxCategoryAdflow;
	protected RegularExpressionValidator RegularExpressionValidator3;
	protected TextBox TextBoxvisitPeople;
	protected RegularExpressionValidator RegularExpressionValidator4;
	protected CheckBox CheckBoxIsShow;
	protected TextBox TextBoxAdIntroduce;
	protected Button ButtonConfirm;
	protected Button ButtonBack;
	protected MessageShow MessageShow;
	protected HiddenField hiddenFieldGuid;
	protected HiddenField HiddenFieldADCount;
	protected HiddenField HiddenFieldADGuid;
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
		this.hiddenFieldGuid.Value = ((base.Request.QueryString["ID"] == null) ? "0" : base.Request.QueryString["ID"].Replace("'", ""));
		if (!this.Page.IsPostBack && this.hiddenFieldGuid.Value != "0")
		{
			this.GetEditInfo();
		}
	}
	public void Add()
	{
		ShopNum1_CategoryAdID shopNum1_CategoryAdID = new ShopNum1_CategoryAdID();
		shopNum1_CategoryAdID.CategoryType = this.DropDownListPageName.SelectedValue;
		shopNum1_CategoryAdID.CategoryAdName = this.TextBoxAdName.Text.Trim();
		shopNum1_CategoryAdID.CategoryAdIntroduce = this.TextBoxAdIntroduce.Text.Trim();
		shopNum1_CategoryAdID.Width = int.Parse(this.TextBoxAdWidth.Text.Trim());
		shopNum1_CategoryAdID.Height = int.Parse(this.TextBoxHeight.Text.Trim());
		shopNum1_CategoryAdID.CategoryAdPic = "";
		shopNum1_CategoryAdID.CategoryAdflow = new int?(int.Parse(this.TextBoxCategoryAdflow.Text.Trim()));
		shopNum1_CategoryAdID.visitPeople = new int?(int.Parse(this.TextBoxvisitPeople.Text.Trim()));
		shopNum1_CategoryAdID.CategoryAdDefalutPic = this.TextBoxAdDefaultPic.Text.Trim();
		shopNum1_CategoryAdID.CategoryAdDefalutLike = "http://" + this.TextBoxDefaultLike.Text.Trim().ToLower().Replace("http://", "");
		shopNum1_CategoryAdID.IsShow = (this.CheckBoxIsShow.Checked ? 1 : 0);
		ShopNum1_CategoryAdID_Action shopNum1_CategoryAdID_Action = (ShopNum1_CategoryAdID_Action)LogicFactory.CreateShopNum1_CategoryAdID_Action();
		int num = shopNum1_CategoryAdID_Action.Add(shopNum1_CategoryAdID);
		if (num > 0)
		{
			this.ClearControl();
			this.MessageShow.ShowMessage("AddYes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("AddNo");
			this.MessageShow.Visible = true;
		}
	}
	public void Edit()
	{
		ShopNum1_CategoryAdID shopNum1_CategoryAdID = new ShopNum1_CategoryAdID();
		shopNum1_CategoryAdID.CategoryType = this.DropDownListPageName.SelectedValue;
		shopNum1_CategoryAdID.CategoryAdName = this.TextBoxAdName.Text.Trim();
		shopNum1_CategoryAdID.CategoryAdIntroduce = this.TextBoxAdIntroduce.Text.Trim();
		shopNum1_CategoryAdID.Width = int.Parse(this.TextBoxAdWidth.Text.Trim());
		shopNum1_CategoryAdID.Height = int.Parse(this.TextBoxHeight.Text.Trim());
		shopNum1_CategoryAdID.CategoryAdPic = "";
		shopNum1_CategoryAdID.CategoryAdflow = new int?(0);
		shopNum1_CategoryAdID.visitPeople = new int?(0);
		shopNum1_CategoryAdID.CategoryAdDefalutPic = this.TextBoxAdDefaultPic.Text.Trim();
		shopNum1_CategoryAdID.CategoryAdDefalutLike = this.TextBoxDefaultLike.Text.Trim();
		shopNum1_CategoryAdID.IsShow = (this.CheckBoxIsShow.Checked ? 1 : 0);
		shopNum1_CategoryAdID.ID = int.Parse(this.hiddenFieldGuid.Value);
		ShopNum1_CategoryAdID_Action shopNum1_CategoryAdID_Action = (ShopNum1_CategoryAdID_Action)LogicFactory.CreateShopNum1_CategoryAdID_Action();
		int num = shopNum1_CategoryAdID_Action.Updata(shopNum1_CategoryAdID);
		if (num > 0)
		{
			base.Response.Redirect("CategoryAdID_List.aspx");
		}
		else
		{
			this.MessageShow.ShowMessage("EditNo");
			this.MessageShow.Visible = true;
		}
	}
	public void GetEditInfo()
	{
		ShopNum1_CategoryAdID_Action shopNum1_CategoryAdID_Action = (ShopNum1_CategoryAdID_Action)LogicFactory.CreateShopNum1_CategoryAdID_Action();
		DataTable dataTable = shopNum1_CategoryAdID_Action.Search("-1", this.hiddenFieldGuid.Value);
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			this.ImageOriginalImge.Src = this.Page.ResolveUrl("~/ImgUpload/" + dataTable.Rows[0]["CategoryAdDefalutPic"].ToString());
			this.DropDownListPageName.SelectedValue = dataTable.Rows[0]["CategoryType"].ToString();
			this.TextBoxAdName.Text = dataTable.Rows[0]["CategoryAdName"].ToString();
			this.TextBoxAdIntroduce.Text = dataTable.Rows[0]["CategoryAdIntroduce"].ToString();
			this.TextBoxAdWidth.Text = dataTable.Rows[0]["Width"].ToString();
			this.TextBoxHeight.Text = dataTable.Rows[0]["Height"].ToString();
			this.TextBoxAdDefaultPic.Text = dataTable.Rows[0]["CategoryAdDefalutPic"].ToString();
			this.TextBoxDefaultLike.Text = dataTable.Rows[0]["CategoryAdDefalutLike"].ToString();
			if (dataTable.Rows[0]["IsShow"].ToString() == "0")
			{
				this.CheckBoxIsShow.Checked = false;
			}
		}
	}
	public void ClearControl()
	{
		this.DropDownListPageName.SelectedValue = "-1";
		this.TextBoxAdName.Text = string.Empty;
		this.TextBoxAdIntroduce.Text = string.Empty;
		this.TextBoxAdWidth.Text = string.Empty;
		this.TextBoxHeight.Text = string.Empty;
		this.TextBoxAdDefaultPic.Text = string.Empty;
		this.TextBoxDefaultLike.Text = string.Empty;
		this.ImageOriginalImge.Src = string.Empty;
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		if (this.hiddenFieldGuid.Value != "0")
		{
			this.Edit();
		}
		else
		{
			this.Add();
		}
	}
	protected void ButtonBack_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("CategoryAdID_List.aspx");
	}
}
