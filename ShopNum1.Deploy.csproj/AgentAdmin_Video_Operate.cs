using FredCK.FCKeditorV2;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class AgentAdmin_Video_Operate : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected HtmlHead Head1;
	protected Label LabelPageTitle;
	protected Label LabelTitle;
	protected TextBox TextBoxTitle;
	protected Label Label1;
	protected RequiredFieldValidator RequiredFieldValidatorTitle;
	protected RegularExpressionValidator RegularExpressionValidatorT;
	protected Label Label4;
	protected DropDownList DropDownListCategoryID;
	protected Label Label9;
	protected CompareValidator CompareValidatorArticleCatogory;
	protected Label Label6;
	protected TextBox TextBoxAddress;
	protected Label Label7;
	protected RequiredFieldValidator RequiredFieldValidator2;
	protected RegularExpressionValidator RegularExpressionValidator2;
	protected Label Label2;
	protected TextBox TextBoxImg;
	protected Label Label16;
	protected RequiredFieldValidator RequiredFieldValidator7;
	protected Image ImageSingleImage;
	protected Label Label5;
	protected CheckBox CheckBoxRecommend;
	protected Label Label10;
	protected TextBox TextBoxOrderId;
	protected Label Label11;
	protected RegularExpressionValidator RegularExpressionValidatorRepertoryOrderID;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxOrderId;
	protected Label Label12;
	protected TextBox TextBoxKeyWords;
	protected Label Label13;
	protected RequiredFieldValidator RequiredFieldValidator5;
	protected RegularExpressionValidator RegularExpressionValidator5;
	protected Label LabelKeywordSeo;
	protected TextBox TextBoxKeywordSeo;
	protected Label Label3;
	protected RequiredFieldValidator RequiredFieldValidatorNotNull5;
	protected RegularExpressionValidator RegularExpressionValidatorTitlesize2;
	protected Label LabelDescription;
	protected TextBox TextBoxDescription;
	protected Label Label8;
	protected RequiredFieldValidator RequiredFieldValidatorNotNull7;
	protected RegularExpressionValidator RegularExpressionValidatorTitlesize3;
	protected Label Label14;
	protected FCKeditor FCKeditorRegProtocol;
	protected TextBox FCKeditorRemark;
	protected Button BottonConfirm;
	protected HtmlInputReset inputReset;
	protected Button btnConfirm;
	protected AgentAdmin_MessageShow MessageShow;
	protected HiddenField hiddenFieldGuid;
	protected HtmlForm form1;
	protected string strSapce = "\u3000\u3000";
	protected char charSapce = '\u3000';
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
			this.BindCategory();
			if (this.hiddenFieldGuid.Value != "0")
			{
				this.LabelPageTitle.Text = "视频编辑页";
				this.GetEditInfo();
			}
			else
			{
				this.GetOrderID();
			}
		}
	}
	protected void GetOrderID()
	{
		ShopNum1_Common_Action arg_0A_0 = (ShopNum1_Common_Action)LogicFactory.CreateShopNum1_Common_Action();
		string columnName = "OrderID";
		string tableName = "ShopNum1_Video";
		this.TextBoxOrderId.Text = Convert.ToString(1 + ShopNum1_Common_Action.ReturnMaxID(columnName, tableName));
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		if (this.BottonConfirm.ToolTip == "Update")
		{
			this.Edit();
		}
		else if (this.BottonConfirm.ToolTip == "Submit")
		{
			this.Add();
		}
	}
	protected void Add()
	{
		ShopNum1_Video shopNum1_Video = new ShopNum1_Video();
		shopNum1_Video.Guid = Guid.NewGuid();
		shopNum1_Video.Title = this.TextBoxTitle.Text.Trim();
		shopNum1_Video.ImgAdd = this.TextBoxImg.Text.Trim();
		shopNum1_Video.VideoAdd = this.TextBoxAddress.Text.Trim();
		shopNum1_Video.KeyWords = this.TextBoxKeyWords.Text.Trim();
		shopNum1_Video.Content = base.Server.HtmlEncode(this.FCKeditorRemark.Text.Replace("'", "''"));
		if (this.CheckBoxRecommend.Checked)
		{
			shopNum1_Video.IsRecommend = new int?(1);
		}
		else
		{
			shopNum1_Video.IsRecommend = new int?(0);
		}
		shopNum1_Video.CategoryID = new int?(int.Parse(this.DropDownListCategoryID.SelectedValue));
		shopNum1_Video.OrderID = new int?(Convert.ToInt32(this.TextBoxOrderId.Text.Trim()));
		shopNum1_Video.CreateTime = new DateTime?(DateTime.Now);
		shopNum1_Video.CreateUser = base.ShopNum1LoginID;
		shopNum1_Video.ModifyUser = base.ShopNum1LoginID;
		shopNum1_Video.ModifyTime = new DateTime?(DateTime.Now);
		shopNum1_Video.SubstationID = base.SubstationID;
		shopNum1_Video.Description = this.TextBoxDescription.Text;
		shopNum1_Video.KeyWordsSeo = this.TextBoxKeywordSeo.Text;
		shopNum1_Video.BroadcastCount = new int?(0);
		ShopNum1_Video_Action shopNum1_Video_Action = (ShopNum1_Video_Action)LogicFactory.CreateShopNum1_Video_Action();
		int num = shopNum1_Video_Action.Add(shopNum1_Video);
		if (num > 0)
		{
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "新增" + this.TextBoxTitle.Text.Trim() + "成功",
				OperatorID = base.ShopNum1LoginID,
				IP = Globals.IPAddress,
				PageName = "Video_Operate.aspx",
				Date = DateTime.Now
			});
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
	protected void Edit()
	{
		ShopNum1_Video shopNum1_Video = new ShopNum1_Video();
		shopNum1_Video.Title = this.TextBoxTitle.Text.Trim();
		shopNum1_Video.ImgAdd = this.TextBoxImg.Text.Trim();
		shopNum1_Video.VideoAdd = this.TextBoxAddress.Text.Trim();
		shopNum1_Video.KeyWords = this.TextBoxKeyWords.Text.Trim();
		shopNum1_Video.Content = base.Server.HtmlEncode(this.FCKeditorRemark.Text.Replace("'", "''"));
		if (this.CheckBoxRecommend.Checked)
		{
			shopNum1_Video.IsRecommend = new int?(1);
		}
		else
		{
			shopNum1_Video.IsRecommend = new int?(0);
		}
		shopNum1_Video.CategoryID = new int?(int.Parse(this.DropDownListCategoryID.SelectedValue));
		shopNum1_Video.OrderID = new int?(Convert.ToInt32(this.TextBoxOrderId.Text.Trim()));
		shopNum1_Video.CreateTime = new DateTime?(DateTime.Now);
		shopNum1_Video.CreateUser = base.ShopNum1LoginID;
		shopNum1_Video.ModifyUser = base.ShopNum1LoginID;
		shopNum1_Video.ModifyTime = new DateTime?(DateTime.Now);
		shopNum1_Video.Description = this.TextBoxDescription.Text;
		shopNum1_Video.KeyWordsSeo = this.TextBoxKeywordSeo.Text;
		ShopNum1_Video_Action shopNum1_Video_Action = (ShopNum1_Video_Action)LogicFactory.CreateShopNum1_Video_Action();
		int num = shopNum1_Video_Action.UpDateVideo(this.hiddenFieldGuid.Value, shopNum1_Video);
		if (num > 0)
		{
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "编辑" + this.TextBoxTitle.Text.Trim() + "成功",
				OperatorID = base.ShopNum1LoginID,
				IP = Globals.IPAddress,
				PageName = "Video_Operate.aspx",
				Date = DateTime.Now
			});
			base.Response.Redirect("Video_List.aspx");
		}
		else
		{
			this.MessageShow.ShowMessage("EditNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void GetEditInfo()
	{
		ShopNum1_Video_Action shopNum1_Video_Action = (ShopNum1_Video_Action)LogicFactory.CreateShopNum1_Video_Action();
		DataTable videoByGuid = shopNum1_Video_Action.GetVideoByGuid(this.hiddenFieldGuid.Value);
		this.TextBoxTitle.Text = videoByGuid.Rows[0]["Title"].ToString();
		this.TextBoxImg.Text = videoByGuid.Rows[0]["ImgAdd"].ToString();
		this.TextBoxAddress.Text = videoByGuid.Rows[0]["VideoAdd"].ToString();
		if (videoByGuid.Rows[0]["IsRecommend"].ToString() == "1")
		{
			this.CheckBoxRecommend.Checked = true;
		}
		else
		{
			this.CheckBoxRecommend.Checked = false;
		}
		this.DropDownListCategoryID.SelectedValue = videoByGuid.Rows[0]["CategoryID"].ToString();
		this.TextBoxKeyWords.Text = videoByGuid.Rows[0]["KeyWords"].ToString();
		this.FCKeditorRemark.Text = base.Server.HtmlDecode(videoByGuid.Rows[0]["Content"].ToString());
		this.TextBoxOrderId.Text = videoByGuid.Rows[0]["OrderId"].ToString();
		this.ImageSingleImage.ImageUrl = videoByGuid.Rows[0]["ImgAdd"].ToString();
		this.TextBoxKeywordSeo.Text = videoByGuid.Rows[0]["KeyWordsSeo"].ToString();
		this.TextBoxDescription.Text = videoByGuid.Rows[0]["Description"].ToString();
		this.BottonConfirm.Text = "更新";
		this.BottonConfirm.ToolTip = "Update";
	}
	protected void ClearControl()
	{
		this.TextBoxTitle.Text = string.Empty;
		this.TextBoxAddress.Text = string.Empty;
		this.TextBoxImg.Text = string.Empty;
		this.TextBoxKeyWords.Text = string.Empty;
		this.TextBoxOrderId.Text = string.Empty;
		this.FCKeditorRemark.Text = string.Empty;
	}
	protected void BindCategory()
	{
		ListItem listItem = new ListItem();
		listItem.Text = "-请选择-";
		listItem.Value = "-1";
		this.DropDownListCategoryID.Items.Add(listItem);
		ShopNum1_VideoCategory_Action shopNum1_VideoCategory_Action = (ShopNum1_VideoCategory_Action)LogicFactory.CreateShopNum1_VideoCategory_Action();
		DataView defaultView = shopNum1_VideoCategory_Action.Search(0, 0).DefaultView;
		foreach (DataRow dataRow in defaultView.Table.Rows)
		{
			ListItem listItem2 = new ListItem();
			listItem2.Text = dataRow["Name"].ToString().Trim();
			listItem2.Value = dataRow["ID"].ToString().Trim();
			this.DropDownListCategoryID.Items.Add(listItem2);
			DataTable dataTable = shopNum1_VideoCategory_Action.Search(Convert.ToInt32(dataRow["ID"].ToString().Trim()), 0);
			if (dataTable.Rows.Count > 0)
			{
				this.AddSubCategory(dataTable);
			}
		}
	}
	protected void AddSubCategory(DataTable dataTable)
	{
		ShopNum1_VideoCategory_Action shopNum1_VideoCategory_Action = (ShopNum1_VideoCategory_Action)LogicFactory.CreateShopNum1_VideoCategory_Action();
		foreach (DataRow dataRow in dataTable.Rows)
		{
			ListItem listItem = new ListItem();
			string text = string.Empty;
			for (int i = 0; i < Convert.ToInt32(dataRow["CategoryLevel"].ToString()) - 1; i++)
			{
				text += this.strSapce;
			}
			text += dataRow["Name"].ToString().Trim();
			listItem.Text = text;
			listItem.Value = dataRow["ID"].ToString().Trim();
			this.DropDownListCategoryID.Items.Add(listItem);
			DataTable dataTable2 = shopNum1_VideoCategory_Action.Search(Convert.ToInt32(dataRow["ID"].ToString().Trim()), 0);
			if (dataTable2.Rows.Count > 0)
			{
				this.AddSubCategory(dataTable2);
			}
		}
	}
}
