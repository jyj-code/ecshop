using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Control;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class AgentAdmin_ProductIntegralChecked_List : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected HtmlHead Head1;
	protected ScriptManager ScriptManager1;
	protected Localize LocalizeName;
	protected System.Web.UI.WebControls.TextBox TextBoxName;
	protected Localize Localize1;
	protected System.Web.UI.WebControls.TextBox TextBoxMemLoginID;
	protected Localize LocalizePrice;
	protected System.Web.UI.WebControls.TextBox TextBoxPrice1;
	protected RegularExpressionValidator RegularExpressionValidatorCostPrice1;
	protected System.Web.UI.WebControls.TextBox TextBoxPrice2;
	protected RegularExpressionValidator RegularExpressionValidator1;
	protected System.Web.UI.WebControls.TextBox TextBoxSName;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected System.Web.UI.WebControls.DropDownList DropDownListIsAudit;
	protected LinkButton ButtonSee;
	protected LinkButton ButtonEdit;
	protected LinkButton ButtonCancelAudit;
	protected LinkButton ButtonDelete;
	protected AgentAdmin_MessageShow MessageShow;
	protected Num1GridView Num1GridViewShow;
	protected ObjectDataSource ObjectDataSourceDate;
	protected HiddenField CheckGuid;
	protected HiddenField HiddenFieldCode;
	protected HiddenField HiddenFieldSubstationID;
	protected HtmlForm form1;
	protected System.Web.UI.WebControls.TextBox TextBoxRepertoryNumber;
	protected System.Web.UI.WebControls.DropDownList DropDownListProductGuid1;
	protected System.Web.UI.WebControls.DropDownList DropDownListProductGuid2;
	protected System.Web.UI.WebControls.DropDownList DropDownListProductGuid3;
	protected System.Web.UI.UpdatePanel UpdatePanel1;
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
		this.HiddenFieldSubstationID.Value = base.SubstationID;
		if (!base.IsPostBack)
		{
			this.DropDownListProductGuidBind();
			this.method_6();
			this.method_5();
			this.BindGrid();
		}
	}
	private void method_5()
	{
		this.DropDownListIsAudit.Items.Add(new ListItem("已审核", "1"));
	}
	protected void BindGrid()
	{
		this.Num1GridViewShow.DataBind();
	}
	private void method_6()
	{
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.returnProductCategory();
		this.BindGrid();
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_Shop_ScoreProduct_Action shopNum1_Shop_ScoreProduct_Action = (ShopNum1_Shop_ScoreProduct_Action)LogicFactory.CreateShopNum1_Shop_ScoreProduct_Action();
		if (shopNum1_Shop_ScoreProduct_Action.Delete(this.CheckGuid.Value.ToString()) > 0)
		{
			this.BindGrid();
			this.MessageShow.ShowMessage("DelYes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("DelNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void ButtonOperate_Click(object sender, EventArgs e)
	{
		ShopNum1_Shop_ScoreProduct_Action shopNum1_Shop_ScoreProduct_Action = (ShopNum1_Shop_ScoreProduct_Action)LogicFactory.CreateShopNum1_Shop_ScoreProduct_Action();
		try
		{
			int num = shopNum1_Shop_ScoreProduct_Action.IsAudit(this.CheckGuid.Value, 1);
			if (num > 0)
			{
				MessageBox.Show("审核成功");
				this.BindGrid();
			}
			else
			{
				MessageBox.Show("审核失败!");
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show("审核失败，原因：" + ex.Message);
		}
	}
	protected void ButtonCancelAudit_Click(object sender, EventArgs e)
	{
		ShopNum1_Shop_ScoreProduct_Action shopNum1_Shop_ScoreProduct_Action = (ShopNum1_Shop_ScoreProduct_Action)LogicFactory.CreateShopNum1_Shop_ScoreProduct_Action();
		try
		{
			int num = shopNum1_Shop_ScoreProduct_Action.IsAudit(this.CheckGuid.Value, 2);
			if (num > 0)
			{
				MessageBox.Show("操作成功。");
				this.BindGrid();
			}
			else
			{
				MessageBox.Show("审核失败!");
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show("审核失败，原因：" + ex.Message);
		}
	}
	protected void DropDownListProductGuidBind()
	{
		this.DropDownListProductGuid1.Items.Clear();
		this.DropDownListProductGuid1.Items.Add(new ListItem("-请选择-", "-1"));
		ShopNum1_ScoreProductCategory_Action shopNum1_ScoreProductCategory_Action = (ShopNum1_ScoreProductCategory_Action)LogicFactory.CreateShopNum1_ScoreProductCategory_Action();
		DataTable category = shopNum1_ScoreProductCategory_Action.GetCategory("0");
		for (int i = 0; i < category.Rows.Count; i++)
		{
			this.DropDownListProductGuid1.Items.Add(new ListItem(category.Rows[i]["Name"].ToString(), category.Rows[i]["Code"].ToString() + "/" + category.Rows[i]["ID"].ToString()));
		}
		this.DropDownListProductGuid1_SelectedIndexChanged(null, null);
	}
	protected void DropDownListProductGuid1_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.DropDownListProductGuid2.Items.Clear();
		this.DropDownListProductGuid2.Items.Add(new ListItem("-请选择-", "-1"));
		if (this.DropDownListProductGuid1.SelectedValue != "-1")
		{
			ShopNum1_ScoreProductCategory_Action shopNum1_ScoreProductCategory_Action = (ShopNum1_ScoreProductCategory_Action)LogicFactory.CreateShopNum1_ScoreProductCategory_Action();
			DataTable category = shopNum1_ScoreProductCategory_Action.GetCategory(this.DropDownListProductGuid1.SelectedValue.Split(new char[]
			{
				'/'
			})[1]);
			for (int i = 0; i < category.Rows.Count; i++)
			{
				this.DropDownListProductGuid2.Items.Add(new ListItem(category.Rows[i]["Name"].ToString(), category.Rows[i]["Code"].ToString() + "/" + category.Rows[i]["ID"].ToString()));
			}
		}
		this.DropDownListProductGuid2_SelectedIndexChanged(null, null);
	}
	protected void DropDownListProductGuid2_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.DropDownListProductGuid3.Items.Clear();
		this.DropDownListProductGuid3.Items.Add(new ListItem("-请选择-", "-1"));
		if (this.DropDownListProductGuid2.SelectedValue != "-1")
		{
			ShopNum1_ScoreProductCategory_Action shopNum1_ScoreProductCategory_Action = (ShopNum1_ScoreProductCategory_Action)LogicFactory.CreateShopNum1_ScoreProductCategory_Action();
			DataTable category = shopNum1_ScoreProductCategory_Action.GetCategory(this.DropDownListProductGuid2.SelectedValue.Split(new char[]
			{
				'/'
			})[1]);
			for (int i = 0; i < category.Rows.Count; i++)
			{
				this.DropDownListProductGuid3.Items.Add(new ListItem(category.Rows[i]["Name"].ToString(), category.Rows[i]["Code"].ToString() + "/" + category.Rows[i]["ID"].ToString()));
			}
		}
	}
	public string Is(object object_0)
	{
		string result;
		if (object_0.ToString() == "1")
		{
			result = "已审核";
		}
		else if (object_0.ToString() == "0")
		{
			result = "未审核";
		}
		else if (object_0.ToString() == "2")
		{
			result = "审核未通过";
		}
		else
		{
			result = "";
		}
		return result;
	}
	public string ChangeIsNew(string strIsNew)
	{
		string result;
		if (strIsNew == "0")
		{
			result = "×";
		}
		else if (strIsNew == "1")
		{
			result = "√";
		}
		else
		{
			result = "";
		}
		return result;
	}
	public string ChangeIsBest(string strIsBest)
	{
		string result;
		if (strIsBest == "0")
		{
			result = "×";
		}
		else if (strIsBest == "1")
		{
			result = "√";
		}
		else
		{
			result = "";
		}
		return result;
	}
	public string ChangeIsHot(string strIsHot)
	{
		string result;
		if (strIsHot == "0")
		{
			result = "×";
		}
		else if (strIsHot == "1")
		{
			result = "√";
		}
		else
		{
			result = "";
		}
		return result;
	}
	public string ChangeIsPromotion(string strIsRecommend)
	{
		string result;
		if (strIsRecommend == "0")
		{
			result = "×";
		}
		else if (strIsRecommend == "1")
		{
			result = "√";
		}
		else
		{
			result = "";
		}
		return result;
	}
	public void returnProductCategory()
	{
		if (this.DropDownListProductGuid3.SelectedValue != "-1")
		{
			this.HiddenFieldCode.Value = this.DropDownListProductGuid3.SelectedValue.Split(new char[]
			{
				'/'
			})[0];
		}
		else if (this.DropDownListProductGuid2.SelectedValue != "-1")
		{
			this.HiddenFieldCode.Value = this.DropDownListProductGuid2.SelectedValue.Split(new char[]
			{
				'/'
			})[0];
		}
		else if (this.DropDownListProductGuid1.SelectedValue != "-1")
		{
			this.HiddenFieldCode.Value = this.DropDownListProductGuid1.SelectedValue.Split(new char[]
			{
				'/'
			})[0];
		}
		else
		{
			this.HiddenFieldCode.Value = "-1";
		}
	}
	public string IsSell(object object_0)
	{
		string result;
		if (object_0.ToString() == "0")
		{
			result = "images/shopNum1Admin-wrong.gif";
		}
		else if (object_0.ToString() == "1")
		{
			result = "images/shopNum1Admin-right.gif";
		}
		else
		{
			result = "images/shopNum1Admin-wrong.gif";
		}
		return result;
	}
	public string ChangeIsSaledImg(string strIsSaled)
	{
		string result;
		if (strIsSaled == "0")
		{
			result = "images/shopNum1Admin-wrong.gif";
		}
		else if (strIsSaled == "1")
		{
			result = "images/shopNum1Admin-right.gif";
		}
		else if (strIsSaled == "2")
		{
			result = "images/shopNum1Admin-wrong.gif";
		}
		else
		{
			result = "images/shopNum1Admin-wrong.gif";
		}
		return result;
	}
	protected void ButtonSee_Click1(object sender, EventArgs e)
	{
		this.Page.Response.Redirect("ProductIntegralDetal.aspx?guid=" + this.CheckGuid.Value + "&type=0");
	}
}
