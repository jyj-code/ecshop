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
	public class A_AdPayDecrease : BaseMemberWebControl
	{
		private string string_0 = "A_AdPayDecrease.ascx";
		private Label label_0;
		private Label label_1;
		private Button button_0;
		private HtmlInputText htmlInputText_0;
		private HtmlInputText htmlInputText_1;
		private HtmlInputText htmlInputText_2;
		private HtmlInputText htmlInputText_3;
		private HtmlInputText htmlInputText_4;
		private HtmlInputText htmlInputText_5;
		private HtmlTextArea htmlTextArea_0;
		private HtmlInputPassword htmlInputPassword_0;
		private HtmlInputHidden htmlInputHidden_0;
		private HtmlInputHidden htmlInputHidden_1;
		private HtmlInputHidden htmlInputHidden_2;
		private HiddenField hiddenField_0;
		private HtmlInputText htmlInputText_6;
		private HtmlInputText htmlInputText_7;
		private HtmlInputText htmlInputText_8;
		private HtmlInputText htmlInputText_9;
		private Button button_1;
		private Label label_2;
		private Label label_3;
		private Repeater repeater_0;
		private Repeater repeater_1;
		private HtmlGenericControl htmlGenericControl_0;
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
		public string strSelectBank
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
		public string strHidbank
		{
			get;
			set;
		}
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
		public A_AdPayDecrease()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.htmlInputText_0 = (HtmlInputText)skin.FindControl("txt_Decrease");
			this.htmlInputText_2 = (HtmlInputText)skin.FindControl("txt_Bank");
			this.htmlTextArea_0 = (HtmlTextArea)skin.FindControl("txt_Remark");
			this.htmlInputText_1 = (HtmlInputText)skin.FindControl("txt_RealName");
			this.htmlInputText_3 = (HtmlInputText)skin.FindControl("txt_ConfirmBankID");
			this.label_1 = (Label)skin.FindControl("Lab_AdPayment");
			this.label_0 = (Label)skin.FindControl("Lab_MemLoginID");
			this.htmlInputPassword_0 = (HtmlInputPassword)skin.FindControl("input_PayPwd");
			this.htmlInputHidden_0 = (HtmlInputHidden)skin.FindControl("hid_BankType");
			this.htmlInputText_4 = (HtmlInputText)skin.FindControl("txt_Account");
			this.htmlInputText_5 = (HtmlInputText)skin.FindControl("txtMobileCode");
			this.htmlInputHidden_1 = (HtmlInputHidden)skin.FindControl("hid_RealName");
			this.htmlInputText_9 = (HtmlInputText)skin.FindControl("txt_hidbank");
			this.button_0 = (Button)skin.FindControl("Btn_Confirm");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.repeater_0 = (Repeater)skin.FindControl("Rep_PayDecrease");
			this.repeater_1 = (Repeater)skin.FindControl("Rep_NoValue");
			this.htmlInputHidden_2 = (HtmlInputHidden)skin.FindControl("hidMemberType");
			this.hiddenField_0 = (HiddenField)skin.FindControl("hid_SelectBank");
			this.htmlInputText_6 = (HtmlInputText)skin.FindControl("txt_StartTime");
			this.htmlInputText_7 = (HtmlInputText)skin.FindControl("txt_EndTime");
			this.htmlInputText_8 = (HtmlInputText)skin.FindControl("txt_OrderNum");
			this.button_1 = (Button)skin.FindControl("Btn_Select");
			this.button_1.Click += new EventHandler(this.button_1_Click);
			this.label_2 = (Label)skin.FindControl("lab_PayNum");
			this.label_3 = (Label)skin.FindControl("lab_PayDecrease");
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("pageDiv");
			this.pageid = ((Common.ReqStr("PageID") == "") ? "1" : Common.ReqStr("PageID"));
			this.GetMemInfo();
			if (!this.Page.IsPostBack)
			{
				this.strStartTime = ((Common.ReqStr("StartTime") == "") ? "" : Common.ReqStr("StartTime"));
				this.strEndTime = ((Common.ReqStr("EndTime") == "") ? "" : Common.ReqStr("EndTime"));
				this.strOrderNum = ((Common.ReqStr("OrderNum") == "") ? "" : Common.ReqStr("OrderNum"));
				this.htmlInputText_6.Value = this.strStartTime;
				this.htmlInputText_7.Value = this.strEndTime;
				this.htmlInputText_8.Value = this.strOrderNum;
				this.htmlInputHidden_2.Value = Common.GetNameById("membertype", "shopnum1_member", " And MemloginId='" + this.MemLoginID + "'");
				this.method_0();
			}
		}
		private void button_1_Click(object sender, EventArgs e)
		{
			this.strStartTime = this.htmlInputText_6.Value;
			this.strEndTime = this.htmlInputText_7.Value;
			this.strOrderNum = this.htmlInputText_8.Value;
			this.method_0();
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				"A_AdPayDecrease.aspx?Type=1&pageid=1&StartTime=",
				this.strStartTime,
				"&EndTime=",
				this.strEndTime,
				"&OrderNum=",
				this.strOrderNum
			}));
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
			if (ShopSettings.GetValue("IsDepositPay") == "1")
			{
				int num = 0;
				try
				{
					string nameById = Common.GetNameById("mobile", "shopnum1_member", " and memloginId='" + this.MemLoginID + "' and mobile!=''");
					ShopNum1_MemberActivate_Action shopNum1_MemberActivate_Action = (ShopNum1_MemberActivate_Action)LogicFactory.CreateShopNum1_MemberActivate_Action();
					if (shopNum1_MemberActivate_Action.CheckMobileCode(this.htmlInputText_5.Value, nameById, "2") != "0")
					{
						num = 1;
					}
				}
				catch
				{
				}
				if (num != 1)
				{
					MessageBox.Show("手机验证码不正确！");
					return;
				}
			}
			string payPwd = shopNum1_Member_Action.GetPayPwd(this.MemLoginID);
			if (payPwd == "" || payPwd == null)
			{
				this.Page.Response.Redirect("A_PwdSer.aspx");
			}
			else
			{
				Encryption.GetMd5SecondHash(this.htmlInputPassword_0.Value.Trim());
				if (Convert.ToDecimal(Operator.FilterDouhao(this.htmlInputText_0.Value)) <= 0m)
				{
					MessageBox.Show("交易金额不能为零或者负数！");
				}
				else if (Convert.ToDecimal(Operator.FilterDouhao(this.htmlInputText_0.Value)) > Convert.ToDecimal(Operator.FilterDouhao(this.label_1.Text)))
				{
					MessageBox.Show("提现金额不能大于预存款");
				}
				else if (this.htmlTextArea_0.Value.Length > 300)
				{
					MessageBox.Show("会员备注不能大于300字符");
				}
				else
				{
					ShopNum1_AdvancePaymentApplyLog shopNum1_AdvancePaymentApplyLog = new ShopNum1_AdvancePaymentApplyLog();
					shopNum1_AdvancePaymentApplyLog.Guid = Guid.NewGuid();
					shopNum1_AdvancePaymentApplyLog.OperateType = "0";
					shopNum1_AdvancePaymentApplyLog.CurrentAdvancePayment = Convert.ToDecimal(Operator.FilterDouhao(this.label_1.Text));
					shopNum1_AdvancePaymentApplyLog.OperateMoney = Convert.ToDecimal(Operator.FilterDouhao(this.htmlInputText_0.Value.Trim()));
					shopNum1_AdvancePaymentApplyLog.OperateStatus = 0;
					shopNum1_AdvancePaymentApplyLog.Date = DateTime.Now;
					Order order = new Order();
					shopNum1_AdvancePaymentApplyLog.OrderNumber = "T" + order.CreateOrderNumber();
					shopNum1_AdvancePaymentApplyLog.Memo = this.htmlTextArea_0.Value.ToString();
					shopNum1_AdvancePaymentApplyLog.MemLoginID = this.MemLoginID;
					shopNum1_AdvancePaymentApplyLog.PaymentGuid = new Guid?(Guid.Empty);
					shopNum1_AdvancePaymentApplyLog.PaymentName = string.Empty;
					if (this.htmlInputHidden_0.Value == "线下打款")
					{
						shopNum1_AdvancePaymentApplyLog.Bank = this.htmlInputText_2.Value;
						shopNum1_AdvancePaymentApplyLog.TrueName = this.htmlInputText_1.Value;
						shopNum1_AdvancePaymentApplyLog.Account = this.htmlInputText_3.Value;
					}
					else
					{
						shopNum1_AdvancePaymentApplyLog.Bank = this.htmlInputHidden_0.Value;
						shopNum1_AdvancePaymentApplyLog.TrueName = this.htmlInputHidden_1.Value;
						shopNum1_AdvancePaymentApplyLog.Account = this.htmlInputText_4.Value;
					}
					shopNum1_AdvancePaymentApplyLog.IsDeleted = 0;
					shopNum1_AdvancePaymentApplyLog.ID = new int?(this.method_2() + 1);
					ShopNum1_AdvancePaymentApplyLog_Action shopNum1_AdvancePaymentApplyLog_Action = (ShopNum1_AdvancePaymentApplyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
					int num2 = shopNum1_AdvancePaymentApplyLog_Action.ApplyOperateMoney(shopNum1_AdvancePaymentApplyLog);
					if (num2 > 0)
					{
						try
						{
							ShopNum1_AdvancePaymentModifyLog shopNum1_AdvancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog();
							shopNum1_AdvancePaymentModifyLog.Guid = new Guid?(Guid.NewGuid());
							shopNum1_AdvancePaymentModifyLog.OperateType = 2;
							shopNum1_AdvancePaymentModifyLog.CurrentAdvancePayment = shopNum1_AdvancePaymentApplyLog.CurrentAdvancePayment;
							shopNum1_AdvancePaymentModifyLog.OperateMoney = Convert.ToDecimal(Operator.FilterDouhao(this.htmlInputText_0.Value.Trim()));
							shopNum1_AdvancePaymentModifyLog.LastOperateMoney = Convert.ToDecimal(Operator.FilterDouhao(shopNum1_AdvancePaymentApplyLog.CurrentAdvancePayment)) - Convert.ToDecimal(Operator.FilterDouhao(this.htmlInputText_0.Value.Trim()));
							shopNum1_AdvancePaymentModifyLog.Date = DateTime.Now;
							shopNum1_AdvancePaymentModifyLog.Memo = "会员提现扣除预存款￥" + this.htmlInputText_0.Value.Trim();
							shopNum1_AdvancePaymentModifyLog.MemLoginID = this.MemLoginID;
							shopNum1_AdvancePaymentModifyLog.CreateUser = this.MemLoginID;
							shopNum1_AdvancePaymentModifyLog.CreateTime = new DateTime?(DateTime.Now);
							shopNum1_AdvancePaymentModifyLog.IsDeleted = new int?(0);
							ShopNum1_AdvancePaymentModifyLog_Action shopNum1_AdvancePaymentModifyLog_Action = (ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
							shopNum1_AdvancePaymentModifyLog_Action.OperateMoney(shopNum1_AdvancePaymentModifyLog);
						}
						catch (Exception)
						{
						}
						this.GetMemInfo();
						MessageBox.Show("申请成功");
						this.Page.Response.Redirect("A_AdPayDecrease.aspx?type=1");
					}
				}
			}
		}
		protected void GetMemInfo()
		{
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
			DataTable dataTable = shopNum1_Member_Action.SearchByMemLoginID(this.MemLoginID);
			try
			{
				if (dataTable.Rows.Count > 0)
				{
					this.label_0.Text = dataTable.Rows[0]["MemLoginID"].ToString();
					this.label_1.Text = dataTable.Rows[0]["AdvancePayment"].ToString();
					this.htmlInputHidden_1.Value = dataTable.Rows[0]["RealName"].ToString();
				}
			}
			catch
			{
			}
		}
		private void method_0()
		{
			string arg_0B_0 = this.hiddenField_0.Value;
			ShopNum1_AdvancePaymentApplyLog_Action shopNum1_AdvancePaymentApplyLog_Action = (ShopNum1_AdvancePaymentApplyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
			new DataTable();
			try
			{
				string text = string.Empty;
				if (!string.IsNullOrEmpty(this.label_0.Text.Trim()))
				{
					text = text + "  AND  MemLoginID=  '" + this.MemLoginID + "'  ";
					text = this.method_1(text);
				}
				CommonPageModel commonPageModel = new CommonPageModel();
				commonPageModel.Condition = "  AND   1=1   " + text + "     AND  IsDeleted=0      ";
				commonPageModel.Currentpage = this.pageid.ToString();
				commonPageModel.Resultnum = "0";
				commonPageModel.Tablename = "ShopNum1_AdvancePaymentApplyLog";
				commonPageModel.PageSize = this.PageSize.ToString();
				DataTable dataTable = shopNum1_AdvancePaymentApplyLog_Action.SelectAdvPayment_List(commonPageModel);
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
				PageListBll pageListBll = new PageListBll("main/Account/A_AdPayDecrease.aspx", true);
				this.htmlGenericControl_0.InnerHtml = pageListBll.GetPageListNew(pageList);
				commonPageModel.Resultnum = "1";
				DataTable dataTable2 = shopNum1_AdvancePaymentApplyLog_Action.SelectAdvPayment_List(commonPageModel);
				string nameById = Common.GetNameById("SUM(cast(OperateMoney as float))", "ShopNum1_AdvancePaymentApplyLog", text);
				if (!string.IsNullOrEmpty(nameById))
				{
					this.label_3.Text = nameById;
				}
				else
				{
					this.label_3.Text = "0";
				}
				string nameById2 = Common.GetNameById("COUNT(Guid)", "ShopNum1_AdvancePaymentApplyLog", text);
				if (!string.IsNullOrEmpty(nameById2))
				{
					this.label_2.Text = nameById2;
				}
				else
				{
					this.label_2.Text = "0";
				}
				if (dataTable2.Rows.Count > 0)
				{
					this.repeater_1.Visible = false;
					this.repeater_0.DataSource = dataTable2.DefaultView;
					this.repeater_0.DataBind();
				}
				else
				{
					this.repeater_1.Visible = true;
					DataTable dataTable3 = new DataTable();
					dataTable3.Columns.Add("NoValue", typeof(string));
					DataRow dataRow = dataTable3.NewRow();
					dataRow["NoValue"] = "暂无信息";
					dataTable3.Rows.Add(dataRow);
					this.repeater_1.DataSource = dataTable3;
					this.repeater_1.DataBind();
				}
			}
			catch
			{
			}
		}
		private string method_1(string string_8)
		{
			if (Operator.FormatToEmpty(this.strStartTime) != string.Empty)
			{
				string_8 = string_8 + " AND Date>='" + Operator.FilterString(this.strStartTime) + "' ";
			}
			if (Operator.FormatToEmpty(this.strEndTime) != string.Empty)
			{
				string_8 = string_8 + " AND Date<(SELECT CONVERT(varchar(11),dateadd(day,1,' " + Operator.FilterString(this.strEndTime) + "'),120)  as  a)  ";
			}
			if (Operator.FormatToEmpty(this.strOrderNum) != string.Empty)
			{
				string_8 = string_8 + " AND OrderNumber='" + this.strOrderNum + "'";
			}
			string_8 += "AND  OperateType=0  ";
			return string_8;
		}
		public static string GetState(string type)
		{
			string result;
			if (type == "0")
			{
				result = "未处理";
			}
			else if (type == "1")
			{
				result = "已完成";
			}
			else if (type == "2")
			{
				result = "拒绝申请";
			}
			else
			{
				result = "";
			}
			return result;
		}
		private int method_2()
		{
			int result;
			try
			{
				result = Common.ReturnMaxID("ID", "MemLoginID", this.MemLoginID, "ShopNum1_AdvancePaymentApplyLog");
			}
			catch
			{
				result = 0;
			}
			return result;
		}
	}
}
