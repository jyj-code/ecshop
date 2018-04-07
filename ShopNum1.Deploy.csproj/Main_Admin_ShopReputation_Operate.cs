using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_ShopReputation_Operate : PageBase, IRequiresSessionState
{
	protected Label LabelPageTitle;
	protected Label LabelName;
	protected TextBox TextBoxName;
	protected Label Label3;
	protected RequiredFieldValidator RequiredFieldValidatorName;
	protected RegularExpressionValidator RegularExpressionValidatorTitle;
	protected Label LabelRankType;
	protected DropDownList DropDownListRankType;
	protected Label LabelMinScore;
	protected TextBox TextBoxMinScore;
	protected RegularExpressionValidator RegularExpressionValidatorRepertoryTextBoxMinScore;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxMinScore;
	protected Label LabelMaxScore;
	protected TextBox TextBoxMaxScore;
	protected RegularExpressionValidator RegularExpressionValidator1;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxMaxScore;
	protected CompareValidator CompareDataTime;
	protected Label LabelPic;
	protected HiddenField HiddenFieldpath;
	protected HtmlInputButton ButtonSelectSingleImage;
	protected Image RankImage;
	protected Label LabelMemo;
	protected TextBox TextBoxMemo;
	protected Button ButtonConfirm;
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
		if (!base.IsPostBack)
		{
			this.CheckGuid.Value = ((this.Page.Request.QueryString["guid"] == "0") ? "0" : ("'" + base.Request.QueryString["guid"] + "'"));
			if (this.CheckGuid.Value != "0")
			{
				this.LabelPageTitle.Text = "修改店铺信誉等级";
				this.method_5();
				this.ButtonConfirm.Text = "更新";
			}
			else
			{
				Shop_Reputation_Action shop_Reputation_Action = (Shop_Reputation_Action)LogicFactory.CreateShop_Reputation_Action();
				int maxScore = shop_Reputation_Action.GetMaxScore();
				if (maxScore == 0)
				{
					this.TextBoxMinScore.Text = "0";
				}
				else
				{
					this.TextBoxMinScore.Text = (maxScore + 1).ToString();
				}
			}
		}
	}
	private void method_5()
	{
		Shop_Reputation_Action shop_Reputation_Action = (Shop_Reputation_Action)LogicFactory.CreateShop_Reputation_Action();
		DataTable dataTable = shop_Reputation_Action.Search(this.CheckGuid.Value, 0);
		this.TextBoxName.Text = dataTable.Rows[0]["name"].ToString();
		this.HiddenFieldpath.Value = dataTable.Rows[0]["Pic"].ToString();
		this.TextBoxMaxScore.Text = dataTable.Rows[0]["maxScore"].ToString();
		this.TextBoxMinScore.Text = dataTable.Rows[0]["minScore"].ToString();
		this.TextBoxMemo.Text = dataTable.Rows[0]["Memo"].ToString();
		this.DropDownListRankType.SelectedValue = dataTable.Rows[0]["Type"].ToString();
		this.RankImage.ImageUrl = dataTable.Rows[0]["Pic"].ToString();
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		if (this.CheckGuid.Value == "0")
		{
			this.Add();
		}
		else
		{
			this.method_6();
		}
	}
	private void method_6()
	{
		ShopNum1_ShopReputation shopNum1_ShopReputation = new ShopNum1_ShopReputation();
		shopNum1_ShopReputation.Name = this.TextBoxName.Text;
		shopNum1_ShopReputation.maxScore = int.Parse(this.TextBoxMaxScore.Text);
		shopNum1_ShopReputation.minScore = int.Parse(this.TextBoxMinScore.Text);
		shopNum1_ShopReputation.Memo = this.TextBoxMemo.Text;
		shopNum1_ShopReputation.Pic = this.HiddenFieldpath.Value;
		shopNum1_ShopReputation.ModifyTime = DateTime.Now;
		shopNum1_ShopReputation.ModifyUser = "admin";
		shopNum1_ShopReputation.Type = int.Parse(this.DropDownListRankType.SelectedValue);
		shopNum1_ShopReputation.Guid = new Guid(this.CheckGuid.Value.Replace("'", ""));
		Shop_Reputation_Action shop_Reputation_Action = (Shop_Reputation_Action)LogicFactory.CreateShop_Reputation_Action();
		int num = shop_Reputation_Action.Update(shopNum1_ShopReputation);
		if (num == 1)
		{
			base.Response.Redirect("ShopReputation_List.aspx");
		}
		else
		{
			this.MessageShow.ShowMessage("EditNo");
			this.MessageShow.Visible = true;
		}
	}
	public void Add()
	{
		ShopNum1_ShopReputation shopNum1_ShopReputation = new ShopNum1_ShopReputation();
		shopNum1_ShopReputation.Name = this.TextBoxName.Text;
		shopNum1_ShopReputation.maxScore = int.Parse(this.TextBoxMaxScore.Text);
		shopNum1_ShopReputation.minScore = int.Parse(this.TextBoxMinScore.Text);
		shopNum1_ShopReputation.Memo = this.TextBoxMemo.Text;
		shopNum1_ShopReputation.Pic = this.HiddenFieldpath.Value;
		shopNum1_ShopReputation.ModifyTime = DateTime.Now;
		shopNum1_ShopReputation.ModifyUser = "admin";
		shopNum1_ShopReputation.CreateTime = DateTime.Now;
		shopNum1_ShopReputation.CreateUser = "admin";
		shopNum1_ShopReputation.IsDeleted = 0;
		shopNum1_ShopReputation.Type = int.Parse(this.DropDownListRankType.SelectedValue);
		shopNum1_ShopReputation.Guid = Guid.NewGuid();
		Shop_Reputation_Action shop_Reputation_Action = (Shop_Reputation_Action)LogicFactory.CreateShop_Reputation_Action();
		int num = shop_Reputation_Action.Add(shopNum1_ShopReputation);
		if (num > 0)
		{
			this.method_7();
			this.MessageShow.ShowMessage("AddYes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("AddNo");
			this.MessageShow.Visible = true;
		}
		int maxScore = shop_Reputation_Action.GetMaxScore();
		if (maxScore == 0)
		{
			this.TextBoxMinScore.Text = "0";
		}
		else
		{
			this.TextBoxMinScore.Text = (maxScore + 1).ToString();
		}
	}
	private void method_7()
	{
		this.TextBoxName.Text = string.Empty;
		this.TextBoxMinScore.Text = string.Empty;
		this.TextBoxMaxScore.Text = string.Empty;
		this.TextBoxMemo.Text = string.Empty;
		this.HiddenFieldpath.Value = string.Empty;
		this.DropDownListRankType.SelectedValue = "1";
	}
}
