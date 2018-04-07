using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Control;
using ShopNum1.Factory;
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
public class Main_Admin_UptateRank_Operate : PageBase, IRequiresSessionState
{
	protected Label LabelPageTitle;
	protected LinkButton BottonConfirm;
	protected LinkButton Button1;
	protected MessageShow MessageShow;
	protected Num1GridView Num1GridViewShow;
	protected ObjectDataSource ObjectDataSourceDate;
	protected HiddenField CheckGuid;
	protected HiddenField HiddenFieldGuid;
	protected HiddenField HiddenFieldShopRank;
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
		this.HiddenFieldGuid.Value = ((this.Page.Request.QueryString["guid"].ToString() == null) ? "0" : base.Request.QueryString["guid"].ToString());
		if (!this.Page.IsPostBack)
		{
			this.GetShopRank();
			this.DateBind();
		}
	}
	protected void DateBind()
	{
		this.Num1GridViewShow.DataBind();
	}
	protected void GetShopRank()
	{
		ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopInfoList_Action();
		DataTable allShopInfoByGuid = shopNum1_ShopInfoList_Action.GetAllShopInfoByGuid(this.HiddenFieldGuid.Value);
		if (allShopInfoByGuid != null && allShopInfoByGuid.Rows.Count > 0)
		{
			this.HiddenFieldShopRank.Value = allShopInfoByGuid.Rows[0]["ShopRank"].ToString();
		}
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopInfoList_Action();
		int num = shopNum1_ShopInfoList_Action.Update(this.HiddenFieldGuid.Value, this.CheckGuid.Value, "ShopRank");
		if (num > 0)
		{
			string nameById = Common.GetNameById("MemLoginID", "ShopNum1_ShopInfo", "  AND Guid='" + this.HiddenFieldGuid.Value.Replace("'", "") + "'  ");
			Shop_Rank_Action shop_Rank_Action = (Shop_Rank_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Rank_Action();
			DataTable dataTable = shop_Rank_Action.Search("'" + this.CheckGuid.Value.Replace("'", "") + "'", 0);
			int num2 = 0;
			string rankName = string.Empty;
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				num2 = Convert.ToInt32(dataTable.Rows[0]["IsDefault"].ToString());
				rankName = dataTable.Rows[0]["Name"].ToString();
			}
			if (num2 == 1)
			{
				Shop_ShopApplyRank_Action shop_ShopApplyRank_Action = (Shop_ShopApplyRank_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ShopApplyRank_Action();
				try
				{
					shop_ShopApplyRank_Action.DeleteOutRankGuid(this.CheckGuid.Value.Replace("'", ""), nameById);
				}
				catch (Exception)
				{
				}
				ShopNum1_Shop_ApplyShopRank shopNum1_Shop_ApplyShopRank = new ShopNum1_Shop_ApplyShopRank();
				shopNum1_Shop_ApplyShopRank.ApplyTime = new DateTime?(DateTime.Now);
				shopNum1_Shop_ApplyShopRank.IsAudit = 1;
				shopNum1_Shop_ApplyShopRank.MemberLoginID = nameById;
				shopNum1_Shop_ApplyShopRank.IsPayMent = 1;
				shopNum1_Shop_ApplyShopRank.PaymentName = "预存款支付";
				shopNum1_Shop_ApplyShopRank.PaymentType = new Guid("385c9c54-2b58-4b65-8ea9-f01872126715");
				shopNum1_Shop_ApplyShopRank.RankGuid = new Guid(this.CheckGuid.Value.Replace("'", ""));
				shopNum1_Shop_ApplyShopRank.VerifyTime = new DateTime?(DateTime.Now.AddYears(1));
				shopNum1_Shop_ApplyShopRank.RankName = rankName;
				try
				{
					shop_ShopApplyRank_Action.Add(shopNum1_Shop_ApplyShopRank);
				}
				catch (Exception)
				{
					MessageBox.Show("等级记录失败！");
				}
			}
			base.Response.Redirect("ShopInfoList_Manage.aspx");
		}
		else
		{
			this.MessageShow.ShowMessage("EditNO");
			this.MessageShow.Visible = true;
		}
	}
	protected string IsDoMain(object object_0)
	{
		string result;
		if (object_0.ToString() == "0")
		{
			result = "不可以";
		}
		else if (object_0.ToString() == "1")
		{
			result = "可以";
		}
		else
		{
			result = "非法类型";
		}
		return result;
	}
	protected void Num1GridViewShow_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			HtmlInputCheckBox htmlInputCheckBox = (HtmlInputCheckBox)e.Row.Cells[0].FindControl("checkboxItem");
			if (htmlInputCheckBox.Value == this.HiddenFieldShopRank.Value)
			{
				htmlInputCheckBox.Checked = true;
			}
		}
	}
}
