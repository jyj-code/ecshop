using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.Payment;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.AccountWebControl
{
	[ParseChildren(true)]
	public class A_AdPayRecharge : BaseMemberWebControl
	{
		private string string_0 = "A_AdPayRecharge.ascx";
		private Label label_0;
		private Label label_1;
		private Button button_0;
		private HtmlSelect htmlSelect_0;
		private HtmlSelect htmlSelect_1;
		private HtmlInputText htmlInputText_0;
		private HtmlInputText htmlInputText_1;
		private HtmlTextArea htmlTextArea_0;
		private Repeater repeater_0;
		private Repeater repeater_1;
		private HtmlInputHidden htmlInputHidden_0;
		private HtmlInputHidden htmlInputHidden_1;
		private HtmlGenericControl htmlGenericControl_0;
		private Button button_1;
		private HtmlInputHidden htmlInputHidden_2;
		private HtmlInputText htmlInputText_2;
		private HtmlInputText htmlInputText_3;
		private HtmlInputText htmlInputText_4;
		private Label label_2;
		private Label label_3;
		private HtmlForm htmlForm_0;
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
		public string RechargeType
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
		public A_AdPayRecharge()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.htmlForm_0 = (HtmlForm)skin.FindControl("fromA_AdPayTiXian");
			this.htmlInputText_0 = (HtmlInputText)skin.FindControl("txt_Recharge");
			this.htmlInputText_1 = (HtmlInputText)skin.FindControl("txtMobileCode");
			this.htmlTextArea_0 = (HtmlTextArea)skin.FindControl("txt_Remark");
			this.label_1 = (Label)skin.FindControl("Lab_AdPayment");
			this.label_0 = (Label)skin.FindControl("Lab_MemLoginID");
			this.button_0 = (Button)skin.FindControl("Btn_Confirm");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.repeater_0 = (Repeater)skin.FindControl("Rep_PayRecharge");
			this.repeater_0.ItemDataBound += new RepeaterItemEventHandler(this.repeater_0_ItemDataBound);
			this.repeater_0.ItemCommand += new RepeaterCommandEventHandler(this.repeater_0_ItemCommand);
			this.repeater_1 = (Repeater)skin.FindControl("Rep_NoValue");
			this.htmlSelect_0 = (HtmlSelect)skin.FindControl("sel_PayMent");
			this.htmlSelect_1 = (HtmlSelect)skin.FindControl("sel_PayMentType");
			this.htmlInputHidden_0 = (HtmlInputHidden)skin.FindControl("hid_PayMent");
			this.htmlInputHidden_1 = (HtmlInputHidden)skin.FindControl("hid_PayMentValue");
			this.htmlInputHidden_2 = (HtmlInputHidden)skin.FindControl("hid_SelPayMentType");
			this.htmlInputText_2 = (HtmlInputText)skin.FindControl("txt_StartTime");
			this.htmlInputText_3 = (HtmlInputText)skin.FindControl("txt_EndTime");
			this.label_2 = (Label)skin.FindControl("lab_PayNum");
			this.label_3 = (Label)skin.FindControl("lab_PayRecharge");
			this.htmlInputText_4 = (HtmlInputText)skin.FindControl("txt_OrderNum");
			this.button_1 = (Button)skin.FindControl("Btn_Select");
			this.button_1.Click += new EventHandler(this.button_1_Click);
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("pageDiv");
			this.pageid = ((Common.ReqStr("PageID") == "") ? "1" : Common.ReqStr("PageID"));
			this.GetMemInfo();
			this.BindPayment();
			if (!this.Page.IsPostBack)
			{
				this.strStartTime = ((Common.ReqStr("StartTime") == "") ? "" : Common.ReqStr("StartTime"));
				this.strEndTime = ((Common.ReqStr("EndTime") == "") ? "" : Common.ReqStr("EndTime"));
				this.strOrderNum = ((Common.ReqStr("OrderNum") == "") ? "" : Common.ReqStr("OrderNum"));
				this.RechargeType = ((Common.ReqStr("RechargeType") == "") ? "-1" : Common.ReqStr("RechargeType"));
				this.htmlInputText_2.Value = this.strStartTime;
				this.htmlInputText_3.Value = this.strEndTime;
				this.htmlInputText_4.Value = this.strOrderNum;
				this.htmlInputHidden_2.Value = this.RechargeType;
				this.method_0();
			}
		}
		private void repeater_0_ItemCommand(object sender, RepeaterCommandEventArgs e)
		{
			if (e.CommandName == "Charge")
			{
				LinkButton linkButton = (LinkButton)sender;
				HiddenField hiddenField = linkButton.Parent.FindControl("HiddenFieldPayMentValue") as HiddenField;
				HiddenField hiddenField2 = linkButton.FindControl("HiddenFieldOrderNumber") as HiddenField;
				HiddenField hiddenField3 = linkButton.FindControl("HiddenFieldOperateMoney") as HiddenField;
				string timetemp = DateTime.Now.AddMinutes(10.0).Ticks.ToString();
				PayUrlOperate payUrlOperate = new PayUrlOperate();
				string payUrl = payUrlOperate.GetPayUrl(hiddenField.Value, hiddenField3.Value.Trim(), ShopSettings.siteDomain + "/main/account/A_Index.aspx", "充值", hiddenField2.Value, "Recharge", "0", "admin", this.MemLoginID, timetemp);
				if (payUrl.Length > 1000)
				{
					Encoding contentEncoding;
					if (payUrl.Split(new char[]
					{
						'|'
					})[0].IndexOf("UTF") != -1)
					{
						contentEncoding = Encoding.UTF8;
					}
					else
					{
						contentEncoding = Encoding.Default;
					}
					this.Page.Response.ContentEncoding = contentEncoding;
					this.Page.Response.Write(payUrl.Split(new char[]
					{
						'|'
					})[1]);
				}
				else if (this.htmlInputHidden_0.Value != "线下支付")
				{
					this.Page.Response.Redirect(payUrl);
				}
				else
				{
					MessageBox.Show("线下支付申请提交成功！请及时汇款！");
				}
			}
		}
		private void repeater_0_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				Label label = (Label)e.Item.FindControl("LabelOperateStatus");
				HtmlAnchor htmlAnchor = (HtmlAnchor)e.Item.FindControl("deleteData");
				HtmlAnchor htmlAnchor2 = (HtmlAnchor)e.Item.FindControl("PayUrl");
				if (label.Text == "未处理")
				{
					htmlAnchor.Visible = true;
					htmlAnchor2.Visible = true;
					HiddenField hiddenField = (HiddenField)e.Item.FindControl("HiddenFieldPayMentValue");
					HiddenField hiddenField2 = (HiddenField)e.Item.FindControl("HiddenFieldOrderNumber");
					HiddenField hiddenField3 = (HiddenField)e.Item.FindControl("HiddenFieldOperateMoney");
					HiddenField hiddenField4 = (HiddenField)e.Item.FindControl("HiddenFieldPaymentName");
					string timetemp = DateTime.Now.AddMinutes(10.0).Ticks.ToString();
					PayUrlOperate payUrlOperate = new PayUrlOperate();
					string payUrl = payUrlOperate.GetPayUrl(hiddenField.Value, hiddenField3.Value.Trim(), ShopSettings.siteDomain + "/main/account/A_Index.aspx", "充值", hiddenField2.Value, "Recharge", "0", "admin", this.MemLoginID, timetemp);
					if (payUrl.Length > 1000)
					{
						htmlAnchor2.HRef = payUrl.Split(new char[]
						{
							'|'
						})[1].ToString();
					}
					else
					{
						htmlAnchor2.HRef = payUrl;
					}
					if (hiddenField4.Value == "线下支付")
					{
						htmlAnchor2.Visible = false;
					}
				}
				else if (label.Text == "已拒绝")
				{
					htmlAnchor.Visible = true;
					htmlAnchor2.Visible = false;
				}
				else
				{
					htmlAnchor2.Visible = false;
					htmlAnchor.Visible = false;
				}
			}
		}
		public static string GetType(string OperateStatus)
		{
			string result;
			if (OperateStatus == "0")
			{
				result = "未处理";
			}
			else if (OperateStatus == "1")
			{
				result = "已处理";
			}
			else if (OperateStatus == "2")
			{
				result = "已拒绝";
			}
			else
			{
				result = "";
			}
			return result;
		}
		private void button_1_Click(object sender, EventArgs e)
		{
			this.strStartTime = this.htmlInputText_2.Value;
			this.strEndTime = this.htmlInputText_3.Value;
			this.RechargeType = this.htmlInputHidden_2.Value;
			this.strOrderNum = this.htmlInputText_4.Value;
			this.method_0();
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				"A_AdPayRecharge.aspx?Type=1&pageid=1&StartTime=",
				this.strStartTime,
				"&EndTime=",
				this.strEndTime,
				"&RechargeType=",
				this.RechargeType,
				"&OrderNum=",
				this.strOrderNum
			}));
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			if (this.htmlInputHidden_1.Value == "-1")
			{
				MessageBox.Show("请选择支付方式！");
			}
			else
			{
				if (ShopSettings.GetValue("IsChargePay") == "1")
				{
					int num = 0;
					try
					{
						string nameById = Common.GetNameById("mobile", "shopnum1_member", " and memloginId='" + this.MemLoginID + "' and mobile!=''");
						ShopNum1_MemberActivate_Action shopNum1_MemberActivate_Action = (ShopNum1_MemberActivate_Action)LogicFactory.CreateShopNum1_MemberActivate_Action();
						if (shopNum1_MemberActivate_Action.CheckMobileCode(this.htmlInputText_1.Value, nameById, "2") != "0")
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
				ShopNum1_AdvancePaymentApplyLog shopNum1_AdvancePaymentApplyLog = new ShopNum1_AdvancePaymentApplyLog();
				shopNum1_AdvancePaymentApplyLog.Guid = Guid.NewGuid();
				shopNum1_AdvancePaymentApplyLog.OperateType = "1";
				shopNum1_AdvancePaymentApplyLog.CurrentAdvancePayment = Convert.ToDecimal(Operator.FilterDouhao(this.label_1.Text));
				shopNum1_AdvancePaymentApplyLog.OperateMoney = Convert.ToDecimal(Operator.FilterDouhao(this.htmlInputText_0.Value));
				shopNum1_AdvancePaymentApplyLog.OperateStatus = 0;
				shopNum1_AdvancePaymentApplyLog.Date = DateTime.Now;
				Order order = new Order();
				string orderNumber = "C" + order.CreateOrderNumber();
				shopNum1_AdvancePaymentApplyLog.OrderNumber = orderNumber;
				shopNum1_AdvancePaymentApplyLog.MemLoginID = this.MemLoginID;
				shopNum1_AdvancePaymentApplyLog.PaymentGuid = new Guid?(new Guid(this.htmlInputHidden_1.Value.ToString()));
				shopNum1_AdvancePaymentApplyLog.PaymentName = this.htmlInputHidden_0.Value;
				shopNum1_AdvancePaymentApplyLog.Memo = this.htmlTextArea_0.Value.Trim();
				shopNum1_AdvancePaymentApplyLog.UserMemo = DateTime.Now.ToLocalTime().ToString("yyyyMMddhhmmss");
				shopNum1_AdvancePaymentApplyLog.IsDeleted = 0;
				shopNum1_AdvancePaymentApplyLog.OrderStatus = new int?(0);
				string value = this.GetID().ToString();
				shopNum1_AdvancePaymentApplyLog.ID = new int?(Convert.ToInt32(value));
				ShopNum1_AdvancePaymentApplyLog_Action shopNum1_AdvancePaymentApplyLog_Action = (ShopNum1_AdvancePaymentApplyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
				int num2 = shopNum1_AdvancePaymentApplyLog_Action.ApplyOperateMoney(shopNum1_AdvancePaymentApplyLog);
				if (num2 > 0)
				{
					string timetemp = DateTime.Now.AddMinutes(10.0).Ticks.ToString();
					PayUrlOperate payUrlOperate = new PayUrlOperate();
					string payUrl = payUrlOperate.GetPayUrl(this.htmlInputHidden_1.Value, this.htmlInputText_0.Value.Trim(), ShopSettings.siteDomain + "/main/account/A_Index.aspx", "充值", shopNum1_AdvancePaymentApplyLog.OrderNumber, "Recharge", "0", "admin", this.MemLoginID, timetemp);
					if (payUrl.Length > 1000)
					{
						Encoding contentEncoding;
						if (payUrl.Split(new char[]
						{
							'|'
						})[0].IndexOf("UTF") != -1)
						{
							contentEncoding = Encoding.UTF8;
						}
						else
						{
							contentEncoding = Encoding.Default;
						}
						this.Page.Response.ContentEncoding = contentEncoding;
						this.Page.Response.Write(payUrl.Split(new char[]
						{
							'|'
						})[1]);
					}
					else if (this.htmlInputHidden_0.Value != "线下支付")
					{
						this.Page.Response.Redirect(payUrl);
					}
					else
					{
						MessageBox.Show("线下支付申请提交成功！请及时汇款！");
					}
					this.GetMemInfo();
					this.BindPayment();
					this.method_2();
				}
				else
				{
					MessageBox.Show("充值失败！");
				}
				this.GetMemInfo();
				this.BindPayment();
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
				}
			}
			catch
			{
			}
		}
		private void method_0()
		{
			ShopNum1_AdvancePaymentApplyLog_Action shopNum1_AdvancePaymentApplyLog_Action = (ShopNum1_AdvancePaymentApplyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
			new DataTable();
			try
			{
				string text = this.method_1();
				CommonPageModel commonPageModel = new CommonPageModel();
				commonPageModel.Condition = "  AND   1=1   " + text + "     AND  IsDeleted=0   ";
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
				PageListBll pageListBll = new PageListBll("main/Account/A_AdPayRecharge.aspx", true);
				this.htmlGenericControl_0.InnerHtml = pageListBll.GetPageListNew(pageList);
				commonPageModel.Resultnum = "1";
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
				DataTable dataTable2 = shopNum1_AdvancePaymentApplyLog_Action.SelectAdvPayment_List(commonPageModel);
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
		private string method_1()
		{
			string str = string.Empty;
			if (!string.IsNullOrEmpty(this.label_0.Text.Trim()))
			{
				str = str + "  AND  MemLoginID=  '" + this.label_0.Text.Trim() + "'   ";
				if (Operator.FormatToEmpty(this.strStartTime) != string.Empty)
				{
					str = str + " AND Date>='" + Operator.FilterString(this.strStartTime) + "'";
				}
				if (Operator.FormatToEmpty(this.strEndTime) != string.Empty)
				{
					str = str + " AND Date<(SELECT CONVERT(varchar(11),dateadd(day,1,' " + Operator.FilterString(this.strEndTime) + "'),120)  as  a)  ";
				}
				if (Operator.FormatToEmpty(this.strOrderNum) != string.Empty)
				{
					str = str + " AND OrderNumber='" + this.strOrderNum + "'";
				}
				if (Operator.FormatToEmpty(this.RechargeType) != string.Empty && Operator.FormatToEmpty(this.RechargeType) != "-1")
				{
					str = str + " AND PaymentGuid='" + this.RechargeType + "'";
				}
			}
			return str + "AND  OperateType=1  ";
		}
		protected void BindPayment()
		{
			this.htmlSelect_0.Items.Clear();
			this.htmlSelect_1.Items.Clear();
			ShopNum1_Payment_Action shopNum1_Payment_Action = (ShopNum1_Payment_Action)LogicFactory.CreateShopNum1_Payment_Action();
			DataTable dataTable = shopNum1_Payment_Action.SearchByShop(1);
			ListItem listItem = new ListItem();
			listItem.Text = "-请选择支付方式-";
			listItem.Value = "-1";
			this.htmlSelect_0.Items.Add(listItem);
			this.htmlSelect_1.Items.Add(listItem);
			if (dataTable != null)
			{
				foreach (DataRow dataRow in dataTable.Rows)
				{
					ListItem listItem2 = new ListItem();
					if (dataRow["Name"].ToString().Trim() != "预存款支付")
					{
						listItem2.Text = dataRow["Name"].ToString().Trim();
						listItem2.Value = dataRow["Guid"].ToString().Trim();
						this.htmlSelect_0.Items.Add(listItem2);
						this.htmlSelect_1.Items.Add(listItem2);
					}
				}
			}
		}
		protected int GetID()
		{
			string columnName = "ID";
			string tableName = "ShopNum1_AdvancePaymentApplyLog";
			return 1 + ShopNum1_Common_Action.ReturnMaxID(columnName, tableName);
		}
		private void method_2()
		{
			this.htmlInputText_0.Value = string.Empty;
			this.htmlTextArea_0.Value = string.Empty;
		}
	}
}
