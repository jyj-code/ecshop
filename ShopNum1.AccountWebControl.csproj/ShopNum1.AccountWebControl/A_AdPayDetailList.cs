using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.AccountWebControl
{
	[ParseChildren(true)]
	public class A_AdPayDetailList : BaseMemberWebControl
	{
		private string string_0 = "A_AdPayDetailList.ascx";
		private HtmlInputHidden htmlInputHidden_0;
		private HtmlInputText htmlInputText_0;
		private HtmlInputText htmlInputText_1;
		private Button button_0;
		private Repeater repeater_0;
		private HtmlGenericControl htmlGenericControl_0;
		private Label label_0;
		private Label label_1;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		[CompilerGenerated]
		private string string_4;
		[CompilerGenerated]
		private string string_5;
		[CompilerGenerated]
		private string string_6;
		[CompilerGenerated]
		private string string_7;
		[CompilerGenerated]
		private string string_8;
		public string pageid
		{
			get;
			set;
		}
		public string PageSize
		{
			get;
			set;
		}
		public string strStartTime
		{
			get;
			set;
		}
		public string strEndTime
		{
			get;
			set;
		}
		public string strOrderNum
		{
			get;
			set;
		}
		public string strPayType
		{
			get;
			set;
		}
		public string StartTime
		{
			get;
			set;
		}
		public string EndTime
		{
			get;
			set;
		}
		public A_AdPayDetailList()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("Rep_PayA_AdPayDetailList");
			this.htmlInputHidden_0 = (HtmlInputHidden)skin.FindControl("hid_type");
			this.htmlInputText_0 = (HtmlInputText)skin.FindControl("txt_StartTime");
			this.htmlInputText_1 = (HtmlInputText)skin.FindControl("txt_EndTime");
			this.label_0 = (Label)skin.FindControl("lab_PayNum");
			this.label_1 = (Label)skin.FindControl("lab_PayDetail");
			this.button_0 = (Button)skin.FindControl("Btn_Select");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("pageDiv");
			this.pageid = ((Common.ReqStr("PageID") == "") ? "1" : Common.ReqStr("PageID"));
			if (!this.Page.IsPostBack)
			{
				this.strStartTime = ((Common.ReqStr("StartTime") == "") ? "" : Common.ReqStr("StartTime"));
				this.strEndTime = ((Common.ReqStr("EndTime") == "") ? "" : Common.ReqStr("EndTime"));
				this.strPayType = ((Common.ReqStr("PayType") == "") ? "-1" : Common.ReqStr("PayType"));
				this.htmlInputText_0.Value = this.strStartTime;
				this.htmlInputText_1.Value = this.strEndTime;
				this.htmlInputHidden_0.Value = this.strPayType;
				this.method_0();
			}
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			this.strStartTime = this.htmlInputText_0.Value;
			this.strEndTime = this.htmlInputText_1.Value;
			this.strPayType = this.htmlInputHidden_0.Value;
			this.method_0();
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				"A_AdPayDetailList.aspx?Type=1&pageid=1&StartTime=",
				this.strStartTime,
				"&EndTime=",
				this.strEndTime,
				"&PayType=",
				this.strPayType
			}));
		}
		private void method_0()
		{
			ShopNum1_AdvancePaymentModifyLog_Action shopNum1_AdvancePaymentModifyLog_Action = (ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
			try
			{
				string text = string.Empty;
				text = this.method_1(text);
				CommonPageModel commonPageModel = new CommonPageModel();
				commonPageModel.Condition = "  AND   1=1   " + text;
				commonPageModel.Currentpage = this.pageid.ToString();
				commonPageModel.Tablename = "ShopNum1_AdvancePaymentModifyLog";
				commonPageModel.Resultnum = "0";
				commonPageModel.PageSize = this.PageSize.ToString();
				DataTable dataTable = shopNum1_AdvancePaymentModifyLog_Action.SelectAdvPaymentModifyLog_List(commonPageModel);
				PageList1 pageList = new PageList1();
				pageList.PageSize = Convert.ToInt32(this.PageSize);
				pageList.PageID = Convert.ToInt32(this.pageid.ToString());
				if (dataTable != null && dataTable.Rows.Count > 0)
				{
					pageList.RecordCount = Convert.ToInt32(dataTable.Rows[0][0]);
				}
				else
				{
					pageList.RecordCount = 0;
				}
				PageListBll pageListBll = new PageListBll("main/Account/A_AdPayDetailList.aspx?", true);
				this.htmlGenericControl_0.InnerHtml = pageListBll.GetPageListNew(pageList);
				commonPageModel.Resultnum = "1";
				DataTable dataTable2 = shopNum1_AdvancePaymentModifyLog_Action.SelectAdvPaymentModifyLog_List(commonPageModel);
				this.repeater_0.DataSource = dataTable2.DefaultView;
				this.repeater_0.DataBind();
				int num = 0;
				string nameById = Common.GetNameById("COUNT(Guid)", "ShopNum1_AdvancePaymentModifyLog", text);
				if (!string.IsNullOrEmpty(nameById))
				{
					num = Convert.ToInt32(nameById);
				}
				this.label_0.Text = num.ToString();
				decimal num2 = 0m;
				string nameById2 = Common.GetNameById("SUM(OperateMoney)", "ShopNum1_AdvancePaymentModifyLog", text);
				if (!string.IsNullOrEmpty(nameById2))
				{
					num2 = Convert.ToDecimal(nameById2);
				}
				this.label_1.Text = num2.ToString();
			}
			catch
			{
			}
		}
		private string method_1(string string_9)
		{
			if (!string.IsNullOrEmpty(this.MemLoginID))
			{
				string_9 = string_9 + "  AND  MemLoginID=  '" + this.MemLoginID + "'   ";
			}
			if (Operator.FormatToEmpty(this.strStartTime) != string.Empty)
			{
				string_9 = string_9 + " AND Date>='" + Operator.FilterString(this.strStartTime) + "' ";
			}
			if (Operator.FormatToEmpty(this.strEndTime) != string.Empty)
			{
				string_9 = string_9 + " AND Date<(SELECT CONVERT(varchar(11),dateadd(day,1,' " + Operator.FilterString(this.strEndTime) + "'),120)  as  a)  ";
			}
			if (Operator.FormatToEmpty(this.strPayType) != string.Empty && Operator.FormatToEmpty(this.strPayType) != "-1")
			{
				string_9 = string_9 + " AND OperateType=" + this.strPayType;
			}
			return string_9;
		}
		public static string ChangeOperateType(string operateType)
		{
			string result;
			if (operateType == "1")
			{
				result = "充值";
			}
			else if (operateType == "2")
			{
				result = "提现";
			}
			else if (operateType == "3")
			{
				result = "消费";
			}
			else if (operateType == "4")
			{
				result = "收入";
			}
			else if (operateType == "5")
			{
				result = "系统";
			}
			else if (operateType == "6")
			{
				result = "转账";
			}
			else
			{
				result = "";
			}
			return result;
		}
		public static string GetMoney(string CurrentAdvancePayment, string LastOperateMoney, string OperateMoney)
		{
			decimal d = Convert.ToDecimal(CurrentAdvancePayment);
			decimal d2 = Convert.ToDecimal(LastOperateMoney);
			string result;
			if (d > d2)
			{
				result = "-" + OperateMoney;
			}
			else if (d < d2)
			{
				result = "+" + OperateMoney;
			}
			else
			{
				result = "";
			}
			return result;
		}
	}
}
