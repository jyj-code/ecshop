using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Control;
using ShopNum1.Factory;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_ZtcGoods_List : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected HtmlHead Head1;
	protected ScriptManager ScriptManager1;
	protected Localize LocalizeName;
	protected System.Web.UI.WebControls.TextBox TextBoxName;
	protected Localize LocalizeShopName;
	protected System.Web.UI.WebControls.TextBox TextBoxShopName;
	protected Localize LocalizeState;
	protected System.Web.UI.WebControls.DropDownList DropDownListState;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected LinkButton ButtonOpen;
	protected LinkButton ButtonClose;
	protected LinkButton ButtonDelete;
	protected MessageShow MessageShow;
	protected Num1GridView Num1GridViewShow;
	protected ObjectDataSource ObjectDataSourceDate;
	protected HiddenField CheckGuid;
	protected HiddenField HiddenFieldSubstationID;
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
		this.HiddenFieldSubstationID.Value = base.SubstationID;
		if (!base.IsPostBack)
		{
			this.BindGrid();
		}
	}
	protected void BindGrid()
	{
		this.Num1GridViewShow.DataBind();
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.BindGrid();
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		try
		{
			ShopNum1_ZtcGoods_Action shopNum1_ZtcGoods_Action = (ShopNum1_ZtcGoods_Action)LogicFactory.CreateShopNum1_ZtcGoods_Action();
			shopNum1_ZtcGoods_Action.Delete(this.CheckGuid.Value);
			this.BindGrid();
			this.MessageShow.ShowMessage("DelYes");
			this.MessageShow.Visible = true;
		}
		catch (Exception)
		{
			this.MessageShow.ShowMessage("DelNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void ButtonOpen_Click(object sender, EventArgs e)
	{
		ShopNum1_ZtcGoods_Action shopNum1_ZtcGoods_Action = (ShopNum1_ZtcGoods_Action)LogicFactory.CreateShopNum1_ZtcGoods_Action();
		int num = shopNum1_ZtcGoods_Action.UpdateState(this.CheckGuid.Value, 1);
		if (num > 0)
		{
			MessageBox.Show("开启成功！");
			this.BindGrid();
		}
	}
	protected void ButtonClose_Click(object sender, EventArgs e)
	{
		ShopNum1_ZtcGoods_Action shopNum1_ZtcGoods_Action = (ShopNum1_ZtcGoods_Action)LogicFactory.CreateShopNum1_ZtcGoods_Action();
		int num = shopNum1_ZtcGoods_Action.UpdateState(this.CheckGuid.Value, 0);
		if (num > 0)
		{
			MessageBox.Show("关闭成功！");
			this.BindGrid();
		}
	}
}
