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
public class Main_Admin_MemberRank_Operate : PageBase, IRequiresSessionState
{
	protected Label LabelPageTitle;
	protected Label LabelName;
	protected TextBox TextBoxName;
	protected Label Label3;
	protected RequiredFieldValidator RequiredFieldValidatorName;
	protected RegularExpressionValidator RegularExpressionValidatorTitle;
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
	protected TextBox TextBoxpath;
	protected HtmlInputButton ButtonSelectSingleImage;
	protected HtmlImage ImageOriginalImge;
	protected Label Label1;
	protected CheckBox CheckBoxIsDefault;
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
			this.CheckGuid.Value = ((this.Page.Request.QueryString["guid"] == "0") ? "0" : base.Request.QueryString["guid"]);
			if (this.CheckGuid.Value != "0")
			{
				this.LabelPageTitle.Text = "修改会员等级";
				this.method_5();
			}
			else
			{
				ShopNum1_MemberRank_Action shopNum1_MemberRank_Action = (ShopNum1_MemberRank_Action)LogicFactory.CreateShopNum1_MemberRank_Action();
				int maxScore = shopNum1_MemberRank_Action.GetMaxScore();
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
		ShopNum1_MemberRank_Action shopNum1_MemberRank_Action = (ShopNum1_MemberRank_Action)LogicFactory.CreateShopNum1_MemberRank_Action();
		DataTable dataTable = shopNum1_MemberRank_Action.Search(this.CheckGuid.Value, 0);
		this.TextBoxName.Text = dataTable.Rows[0]["name"].ToString();
		this.TextBoxpath.Text = dataTable.Rows[0]["Pic"].ToString();
		this.TextBoxMaxScore.Text = dataTable.Rows[0]["maxScore"].ToString();
		this.TextBoxMinScore.Text = dataTable.Rows[0]["minScore"].ToString();
		this.TextBoxMemo.Text = dataTable.Rows[0]["Memo"].ToString();
		this.ImageOriginalImge.Src = dataTable.Rows[0]["Pic"].ToString();
		if (dataTable.Rows[0]["IsDefault"].ToString() == "1")
		{
			this.CheckBoxIsDefault.Checked = true;
		}
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		if (this.CheckGuid.Value == "0")
		{
			this.method_7();
		}
		else
		{
			this.method_6();
		}
	}
	private void method_6()
	{
		ShopNum1_MemberRank shopNum1_MemberRank = new ShopNum1_MemberRank();
		shopNum1_MemberRank.Name = this.TextBoxName.Text;
		shopNum1_MemberRank.maxScore = int.Parse(this.TextBoxMaxScore.Text);
		shopNum1_MemberRank.minScore = int.Parse(this.TextBoxMinScore.Text);
		shopNum1_MemberRank.Memo = this.TextBoxMemo.Text;
		string text = this.TextBoxpath.Text;
		shopNum1_MemberRank.Pic = text;
		if (this.CheckBoxIsDefault.Checked)
		{
			shopNum1_MemberRank.IsDefault = 1;
		}
		else
		{
			shopNum1_MemberRank.IsDefault = 0;
		}
		shopNum1_MemberRank.ModifyTime = DateTime.Now;
		shopNum1_MemberRank.ModifyUser = "admin";
		shopNum1_MemberRank.Guid = new Guid(this.CheckGuid.Value.Replace("'", ""));
		ShopNum1_MemberRank_Action shopNum1_MemberRank_Action = (ShopNum1_MemberRank_Action)LogicFactory.CreateShopNum1_MemberRank_Action();
		int num = shopNum1_MemberRank_Action.Update(shopNum1_MemberRank);
		if (num == 1)
		{
			base.Response.Redirect("MemberRank_List.aspx");
		}
		else
		{
			this.MessageShow.ShowMessage("EditNo");
			this.MessageShow.Visible = true;
		}
	}
	private void method_7()
	{
		ShopNum1_MemberRank shopNum1_MemberRank = new ShopNum1_MemberRank();
		shopNum1_MemberRank.Name = this.TextBoxName.Text;
		shopNum1_MemberRank.maxScore = int.Parse(this.TextBoxMaxScore.Text);
		shopNum1_MemberRank.minScore = int.Parse(this.TextBoxMinScore.Text);
		shopNum1_MemberRank.Memo = this.TextBoxMemo.Text;
		string text = this.TextBoxpath.Text;
		if (text != "" && text.IndexOf("20x20") == -1)
		{
			string text2 = "/ImgUpload/Main/Rank/";
			if (!Directory.Exists(HttpContext.Current.Server.MapPath(text2)))
			{
				Directory.CreateDirectory(HttpContext.Current.Server.MapPath(text2));
			}
			text2 = text2 + DateTime.Now.ToString("yyyyMMddhhmmss") + ".jpg_20x20.jpg";
			try
			{
				ImageOperator.CreateThumbnailAuto(HttpContext.Current.Server.MapPath(text), HttpContext.Current.Server.MapPath(text2), 20, 20);
			}
			catch
			{
			}
			text = text2;
		}
		shopNum1_MemberRank.Pic = text;
		shopNum1_MemberRank.ModifyTime = DateTime.Now;
		shopNum1_MemberRank.ModifyUser = "admin";
		shopNum1_MemberRank.CreateTime = DateTime.Now;
		shopNum1_MemberRank.CreateUser = "admin";
		if (this.CheckBoxIsDefault.Checked)
		{
			shopNum1_MemberRank.IsDefault = 1;
		}
		else
		{
			shopNum1_MemberRank.IsDefault = 0;
		}
		shopNum1_MemberRank.IsDeleted = 0;
		shopNum1_MemberRank.Guid = Guid.NewGuid();
		ShopNum1_MemberRank_Action shopNum1_MemberRank_Action = (ShopNum1_MemberRank_Action)LogicFactory.CreateShopNum1_MemberRank_Action();
		int num = shopNum1_MemberRank_Action.Add(shopNum1_MemberRank);
		if (num > 0)
		{
			this.method_8();
			this.MessageShow.ShowMessage("AddYes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("AddNo");
			this.MessageShow.Visible = true;
		}
		int maxScore = shopNum1_MemberRank_Action.GetMaxScore();
		if (maxScore == 0)
		{
			this.TextBoxMinScore.Text = "0";
		}
		else
		{
			this.TextBoxMinScore.Text = (maxScore + 1).ToString();
		}
	}
	private void method_8()
	{
		this.TextBoxName.Text = string.Empty;
		this.TextBoxMinScore.Text = string.Empty;
		this.TextBoxMaxScore.Text = string.Empty;
		this.TextBoxMemo.Text = string.Empty;
	}
}
