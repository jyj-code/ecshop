using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_CategoryAdID_SearchDetail : PageBase, IRequiresSessionState
{
	protected TextBox TextBoxID;
	protected TextBox TextBoxCategoryAdName;
	protected TextBox TextBoxCategoryType;
	protected TextBox TextBoxWidth;
	protected TextBox TextBoxHeight;
	protected Image ImageAdDefalutPic;
	protected TextBox TextBoxAdDefalutLike;
	protected TextBox TextBoxAdflow;
	protected TextBox TextBoxvisitPeople;
	protected CheckBox CheckBoxIsShow;
	protected TextBox TextBoxIntroduce;
	protected Button ButtonBack;
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
		try
		{
			base.CheckLogin();
			string adID = this.Page.Request.QueryString["Guid"].Replace("'", "");
			ShopNum1_CategoryAdID_Action shopNum1_CategoryAdID_Action = (ShopNum1_CategoryAdID_Action)LogicFactory.CreateShopNum1_CategoryAdID_Action();
			DataTable dataTable = shopNum1_CategoryAdID_Action.Search("-1", adID);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				this.TextBoxID.Text = dataTable.Rows[0]["ID"].ToString();
				this.TextBoxCategoryAdName.Text = dataTable.Rows[0]["CategoryAdName"].ToString();
				this.TextBoxCategoryType.Text = this.PageName(dataTable.Rows[0]["CategoryType"]);
				this.TextBoxWidth.Text = dataTable.Rows[0]["Width"].ToString();
				this.TextBoxHeight.Text = dataTable.Rows[0]["Height"].ToString();
				this.ImageAdDefalutPic.ImageUrl = this.Page.ResolveUrl("~/ImgUpload/" + dataTable.Rows[0]["CategoryAdDefalutPic"].ToString());
				this.TextBoxAdDefalutLike.Text = dataTable.Rows[0]["CategoryAdDefalutLike"].ToString();
				this.TextBoxAdflow.Text = dataTable.Rows[0]["CategoryAdflow"].ToString();
				this.TextBoxvisitPeople.Text = dataTable.Rows[0]["visitPeople"].ToString();
				this.CheckBoxIsShow.Checked = !(dataTable.Rows[0]["IsShow"].ToString() == "0");
				this.TextBoxIntroduce.Text = dataTable.Rows[0]["CategoryAdIntroduce"].ToString();
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}
	public string PageName(object object_0)
	{
		string a = object_0.ToString();
		string result;
		if (a == "1")
		{
			result = "商品分类";
		}
		else if (a == "2")
		{
			result = "分类信息分类";
		}
		else if (a == "3")
		{
			result = "供求分类";
		}
		else if (a == "4")
		{
			result = "店铺分类";
		}
		else if (a == "5")
		{
			result = "资讯分类";
		}
		else if (a == "6")
		{
			result = "品牌分类";
		}
		else
		{
			result = "非法页面";
		}
		return result;
	}
	protected void ButtonBack_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("CategoryAdBuyAudit_List.aspx");
	}
}
