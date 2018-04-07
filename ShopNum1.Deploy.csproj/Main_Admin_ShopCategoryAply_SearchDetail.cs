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
public class Main_Admin_ShopCategoryAply_SearchDetail : PageBase, IRequiresSessionState
{
	protected Label LabelTitle;
	protected Localize LocalizeName;
	protected TextBox TextBoxShopName;
	protected Localize Localizereplacement;
	protected TextBox TextBoxMemberLoginID;
	protected Localize Localize2;
	protected TextBox TextBoxOldShopCategory;
	protected Localize Localize3;
	protected TextBox TextBoxOldShopBrand;
	protected Localize Localize4;
	protected TextBox TextBoxShopApplyCategory;
	protected Localize Localize5;
	protected TextBox TextBoxShopApplyBrand;
	protected Localize Localize6;
	protected TextBox TextBoxApplyTime;
	protected Localize Localize1;
	protected TextBox TextBoxComment;
	protected Button ButtonOperate;
	protected Button ButtonOperate1;
	protected Button ButtonBack;
	protected AgentAdmin_MessageShow MessageShow;
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
			string str = this.Page.Request.QueryString["Guid"].Replace("'", "");
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
			DataTable shopCategoryInfoByGuid = shopNum1_ShopInfoList_Action.GetShopCategoryInfoByGuid("'" + str + "'");
			this.TextBoxShopName.Text = shopCategoryInfoByGuid.Rows[0]["ShopName"].ToString();
			this.TextBoxMemberLoginID.Text = shopCategoryInfoByGuid.Rows[0]["ShopID"].ToString();
			this.TextBoxOldShopCategory.Text = shopCategoryInfoByGuid.Rows[0]["OldShopCategoryName"].ToString();
			this.TextBoxOldShopBrand.Text = shopCategoryInfoByGuid.Rows[0]["OldBrandName"].ToString();
			this.TextBoxShopApplyCategory.Text = shopCategoryInfoByGuid.Rows[0]["ShopCategoryName"].ToString();
			this.TextBoxShopApplyBrand.Text = shopCategoryInfoByGuid.Rows[0]["BrandName"].ToString();
			this.TextBoxApplyTime.Text = shopCategoryInfoByGuid.Rows[0]["ApplyTime"].ToString();
			this.TextBoxComment.Text = shopCategoryInfoByGuid.Rows[0]["Remarks"].ToString();
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}
	protected void ButtonBack_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ShopCategoryAply_Audit.aspx");
	}
	protected void ButtonOperate_Click(object sender, EventArgs e)
	{
		bool flag = false;
		ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
		if (shopNum1_ShopInfoList_Action.UpdataShopCategoryApplyIsAudit("'" + this.Page.Request.QueryString["guid"].ToString() + "'", "1") > 0)
		{
			string[] array = this.Page.Request.QueryString["guid"].Split(new char[]
			{
				','
			});
			for (int i = 0; i < array.Length; i++)
			{
				DataTable shopCategoryInfoByGuid = shopNum1_ShopInfoList_Action.GetShopCategoryInfoByGuid("'" + array[i] + "'");
				if (shopCategoryInfoByGuid != null && shopCategoryInfoByGuid.Rows.Count > 0)
				{
					string shopCategoryName = shopCategoryInfoByGuid.Rows[i]["ShopCategoryName"].ToString();
					string shopCategoryCode = shopCategoryInfoByGuid.Rows[i]["NewShopCateGoryCode"].ToString();
					string brandName = shopCategoryInfoByGuid.Rows[i]["BrandName"].ToString();
					string brandGuid = shopCategoryInfoByGuid.Rows[i]["NewBrandGuid"].ToString();
					flag = (shopNum1_ShopInfoList_Action.UpdateShopCategoryAndBrandByGuids("'" + array[i] + "'", shopCategoryName, shopCategoryCode, brandName, brandGuid) > 0);
				}
				else
				{
					flag = false;
				}
			}
		}
		else
		{
			flag = false;
		}
		if (flag)
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
	protected void ButtonOperate1_Click(object sender, EventArgs e)
	{
		ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
		if (shopNum1_ShopInfoList_Action.UpdataShopCategoryApplyIsAudit("'" + this.Page.Request.QueryString["guid"].ToString() + "'", "2") > 0)
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
