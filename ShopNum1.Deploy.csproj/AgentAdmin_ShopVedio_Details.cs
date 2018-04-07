using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class AgentAdmin_ShopVedio_Details : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected HtmlHead Head1;
	protected Label LabelTitle;
	protected Localize LocalizeAssociatedCategoryGuid;
	protected TextBox TextBoxCategoryGuid;
	protected Localize LocalizeTitle;
	protected TextBox TextBoxTitle;
	protected Localize LocalizeCreateTime;
	protected TextBox TextBoxCreateTime;
	protected Localize LocalizeMember;
	protected TextBox TextBoxMemberLoginID;
	protected Localize LocalizeKeywords;
	protected TextBox TextBoxKeywords;
	protected Localize LocalizeVideo;
	protected TextBox TextBoxVideo;
	protected Localize LocalizeImgage;
	protected Image Image;
	protected Button Button1;
	protected Button ButtonCancelAudit;
	protected Button ButtonBack;
	protected AgentAdmin_MessageShow MessageShow;
	protected HiddenField hiddenFieldGuid;
	protected Literal LiteralShowVodie;
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
		string guid = base.Request.QueryString["guid"];
		ShopNum1_VedioCommentChecked_Action shopNum1_VedioCommentChecked_Action = (ShopNum1_VedioCommentChecked_Action)LogicFactory.CreateShopNum1_VedioCommentChecked_Action();
		DataTable shopVideoByGuid = shopNum1_VedioCommentChecked_Action.GetShopVideoByGuid(guid);
		if (shopVideoByGuid != null && shopVideoByGuid.Rows.Count > 0)
		{
			this.TextBoxCreateTime.Text = shopVideoByGuid.Rows[0]["CreateTime"].ToString();
			this.TextBoxTitle.Text = shopVideoByGuid.Rows[0]["Title"].ToString();
			this.Image.ImageUrl = shopVideoByGuid.Rows[0]["ImgAdd"].ToString();
			this.TextBoxVideo.Text = shopVideoByGuid.Rows[0]["VideoAdd"].ToString();
			this.LiteralShowVodie.Text = shopVideoByGuid.Rows[0]["VideoAdd"].ToString();
			this.TextBoxKeywords.Text = shopVideoByGuid.Rows[0]["KeyWords"].ToString();
			this.TextBoxCategoryGuid.Text = shopVideoByGuid.Rows[0]["name"].ToString();
			this.TextBoxMemberLoginID.Text = shopVideoByGuid.Rows[0]["MemLoginID"].ToString();
		}
	}
	protected void ButtonBack_Click(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(this.Page.Request.QueryString["type"]) && this.Page.Request.QueryString["type"].ToString() == "Checked")
		{
			this.Page.Response.Redirect("ShopVedioChecked_List.aspx");
		}
		else
		{
			this.Page.Response.Redirect("ShopVedio_List.aspx");
		}
	}
	protected void ButtonAudit_Click(object sender, EventArgs e)
	{
		ShopNum1_Vedio_List_Action shopNum1_Vedio_List_Action = (ShopNum1_Vedio_List_Action)LogicFactory.CreateShopNum1_Vedio_List_Action();
		if (shopNum1_Vedio_List_Action.UpdateAudit(this.Page.Request.QueryString["guid"].ToString(), 1) > 0)
		{
			this.MessageShow.ShowMessage("Audit2Yes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("Audit2No");
			this.MessageShow.Visible = true;
		}
	}
	protected void ButtonCancelAudit_Click(object sender, EventArgs e)
	{
		ShopNum1_Vedio_List_Action shopNum1_Vedio_List_Action = (ShopNum1_Vedio_List_Action)LogicFactory.CreateShopNum1_Vedio_List_Action();
		if (shopNum1_Vedio_List_Action.UpdateAudit(this.Page.Request.QueryString["guid"].ToString(), 2) > 0)
		{
			this.MessageShow.ShowMessage("Audit2Yes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("Audit2No");
			this.MessageShow.Visible = true;
		}
	}
}
