using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_ShopZtcApplyDetal : PageBase, IRequiresSessionState
{
	protected ScriptManager ScriptManager1;
	protected Label LabelPageTitle;
	protected Repeater RepeaterShow;
	protected Button ButtonAudit;
	protected Button ButtonCancelAudit;
	protected Button ButtonBack;
	protected MessageShow MessageShow;
	protected HiddenField CheckGuid;
	protected HiddenField HiddenFieldMemLoginID;
	protected HiddenField hiddenFieldGuid;
	protected HiddenField hiddenFieldType;
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
		this.GetData();
	}
	public void GetData()
	{
		ShopNum1_ZtcApply_Action shopNum1_ZtcApply_Action = (ShopNum1_ZtcApply_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ZtcApply_Action();
		DataTable infoByGuid = shopNum1_ZtcApply_Action.GetInfoByGuid(this.Page.Request.QueryString["ID"].ToString());
		if (infoByGuid != null && infoByGuid.Rows.Count > 0)
		{
			this.RepeaterShow.DataSource = infoByGuid.DefaultView;
			this.RepeaterShow.DataBind();
			if (infoByGuid.Rows[0]["AuditState"].ToString() == "1" || infoByGuid.Rows[0]["AuditState"].ToString() == "2")
			{
				this.ButtonAudit.Visible = false;
				this.ButtonCancelAudit.Visible = false;
			}
		}
	}
	public string IsAuditState(string AuditState)
	{
		string result;
		if (AuditState == "0")
		{
			result = "未审核";
		}
		else if (AuditState == "1")
		{
			result = "已审核";
		}
		else if (AuditState == "2")
		{
			result = "审核未通过";
		}
		else
		{
			result = "";
		}
		return result;
	}
	protected void ButtonBack_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ShopZtcApplyAudit_List.aspx");
	}
	protected void ButtonAudit_Click(object sender, EventArgs e)
	{
		try
		{
			string[] array = this.Page.Request.QueryString["ID"].Split(new char[]
			{
				','
			});
			for (int i = 0; i < array.Length; i++)
			{
				if (this.IsCheck(array[i].ToString()))
				{
					this.CreateZtcGoods(array[i].ToString());
				}
			}
			MessageBox.Show("数据审核成功！");
		}
		catch (Exception)
		{
			MessageBox.Show("数据审核失败！");
		}
	}
	protected void ButtonCancelAudit_Click(object sender, EventArgs e)
	{
		ShopNum1_ZtcApply_Action shopNum1_ZtcApply_Action = (ShopNum1_ZtcApply_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ZtcApply_Action();
		try
		{
			string[] array = this.Page.Request.QueryString["ID"].Split(new char[]
			{
				','
			});
			for (int i = 0; i < array.Length; i++)
			{
				if (this.IsCheck(array[i].ToString()))
				{
					shopNum1_ZtcApply_Action.ChangeAuditState(array[i].ToString(), 2);
					DataTable infoByGuid = shopNum1_ZtcApply_Action.GetInfoByGuid(array[i].ToString().Replace("'", ""));
					decimal num = Convert.ToDecimal(infoByGuid.Rows[0]["Ztc_Money"].ToString());
					string text = infoByGuid.Rows[0]["MemberID"].ToString();
					decimal num2 = 0m;
					string nameById = Common.GetNameById("AdvancePayment", "ShopNum1_Member", "  AND  MemLoginID='" + text + "'");
					if (!string.IsNullOrEmpty(nameById))
					{
						num2 = Convert.ToDecimal(nameById);
					}
					ShopNum1_AdvancePaymentModifyLog shopNum1_AdvancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog();
					shopNum1_AdvancePaymentModifyLog.Guid = new Guid?(Guid.NewGuid());
					shopNum1_AdvancePaymentModifyLog.OperateType = 5;
					shopNum1_AdvancePaymentModifyLog.CurrentAdvancePayment = num2;
					shopNum1_AdvancePaymentModifyLog.OperateMoney = num;
					shopNum1_AdvancePaymentModifyLog.LastOperateMoney = Convert.ToDecimal(num2) + num;
					shopNum1_AdvancePaymentModifyLog.Date = DateTime.Now;
					shopNum1_AdvancePaymentModifyLog.Memo = "直通车审核未通过,退款￥" + num + "！";
					shopNum1_AdvancePaymentModifyLog.MemLoginID = text;
					shopNum1_AdvancePaymentModifyLog.CreateUser = base.ShopNum1LoginID;
					shopNum1_AdvancePaymentModifyLog.CreateTime = new DateTime?(DateTime.Now);
					shopNum1_AdvancePaymentModifyLog.IsDeleted = new int?(0);
					ShopNum1_AdvancePaymentModifyLog_Action shopNum1_AdvancePaymentModifyLog_Action = (ShopNum1_AdvancePaymentModifyLog_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
					shopNum1_AdvancePaymentModifyLog_Action.OperateMoney(shopNum1_AdvancePaymentModifyLog);
				}
			}
			MessageBox.Show("操作成功！");
		}
		catch (Exception)
		{
			MessageBox.Show("数据审核失败！");
		}
	}
	public bool IsCheck(string guid)
	{
		ShopNum1_ZtcApply_Action shopNum1_ZtcApply_Action = (ShopNum1_ZtcApply_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ZtcApply_Action();
		DataTable infoByGuid = shopNum1_ZtcApply_Action.GetInfoByGuid(guid);
		return infoByGuid != null && infoByGuid.Rows.Count > 0 && !(infoByGuid.Rows[0]["AuditState"].ToString() == "1") && !(infoByGuid.Rows[0]["AuditState"].ToString() == "2");
	}
	public void CreateZtcGoods(string guid)
	{
		ShopNum1_ZtcGoods_Action shopNum1_ZtcGoods_Action = (ShopNum1_ZtcGoods_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ZtcGoods_Action();
		ShopNum1_ZtcGoods shopNum1_ZtcGoods = new ShopNum1_ZtcGoods();
		ShopNum1_ZtcApply_Action shopNum1_ZtcApply_Action = (ShopNum1_ZtcApply_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ZtcApply_Action();
		DataTable infoByGuid = shopNum1_ZtcApply_Action.GetInfoByGuid(guid);
		string g = string.Empty;
		decimal num = 0m;
		string ztcImg = "";
		string ztcName = "";
		decimal value = 0m;
		string shopName = "";
		DateTime dateTime = DateTime.Now;
		decimal value2 = 0m;
		string substationID = string.Empty;
		string memberID = string.Empty;
		if (infoByGuid != null && infoByGuid.Rows.Count > 0)
		{
			g = infoByGuid.Rows[0]["ProductGuid"].ToString();
			Shop_Product_Action shop_Product_Action = (Shop_Product_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Product_Action();
			DataTable dataTable = shop_Product_Action.SearchProductShopByGuid("'" + infoByGuid.Rows[0]["ProductGuid"].ToString() + "'");
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				num = Convert.ToDecimal(dataTable.Rows[0]["ShopPrice"].ToString());
				ztcImg = dataTable.Rows[0]["OriginalImage"].ToString();
				ztcName = dataTable.Rows[0]["Name"].ToString();
			}
			value = num;
			shopName = infoByGuid.Rows[0]["ShopName"].ToString();
			dateTime = Convert.ToDateTime(infoByGuid.Rows[0]["StartTime"].ToString());
			value2 = Convert.ToDecimal(infoByGuid.Rows[0]["Ztc_Money"].ToString());
			memberID = infoByGuid.Rows[0]["MemberID"].ToString();
			substationID = infoByGuid.Rows[0]["SubstationID"].ToString();
		}
		int num2 = 0;
		try
		{
			num2 = shopNum1_ZtcApply_Action.ChangeAuditState(guid, 1);
		}
		catch (Exception)
		{
		}
		shopNum1_ZtcGoods.CreateTime = new DateTime?(DateTime.Now);
		shopNum1_ZtcGoods.CreateUser = base.ShopNum1LoginID;
		shopNum1_ZtcGoods.IsDeleted = new int?(0);
		shopNum1_ZtcGoods.ModifyTime = new DateTime?(DateTime.Now);
		shopNum1_ZtcGoods.ModifyUser = base.ShopNum1LoginID;
		shopNum1_ZtcGoods.ProductGuid = new Guid?(new Guid(g));
		shopNum1_ZtcGoods.ProductPrice = new decimal?(num);
		shopNum1_ZtcGoods.SellCount = new int?(0);
		shopNum1_ZtcGoods.SellPrice = new decimal?(value);
		shopNum1_ZtcGoods.ShopName = shopName;
		shopNum1_ZtcGoods.SubstationID = substationID;
		if (DateTime.Compare(DateTime.Now, dateTime) == -1)
		{
			shopNum1_ZtcGoods.StartTime = new DateTime?(dateTime);
		}
		else
		{
			shopNum1_ZtcGoods.StartTime = new DateTime?(DateTime.Now);
		}
		shopNum1_ZtcGoods.State = new byte?(1);
		shopNum1_ZtcGoods.Ztc_Money = new decimal?(value2);
		shopNum1_ZtcGoods.ZtcImg = ztcImg;
		shopNum1_ZtcGoods.ZtcName = ztcName;
		shopNum1_ZtcGoods.MemberID = memberID;
		if (num2 > 0)
		{
			shopNum1_ZtcGoods_Action.Add(shopNum1_ZtcGoods);
		}
	}
}
