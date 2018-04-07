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
	public class A_AdPayTransfer : BaseMemberWebControl
	{
		private string string_0 = "A_AdPayTransfer.ascx";
		private Label label_0;
		private Label label_1;
		private Button button_0;
		private HtmlInputText htmlInputText_0;
		private HtmlInputText htmlInputText_1;
		private HtmlInputText htmlInputText_2;
		private HtmlInputText htmlInputText_3;
		private HtmlTextArea htmlTextArea_0;
		private HtmlInputPassword htmlInputPassword_0;
		private HtmlInputText htmlInputText_4;
		private Repeater repeater_0;
		private Repeater repeater_1;
		private HtmlGenericControl htmlGenericControl_0;
		private Button button_1;
		private HtmlInputText htmlInputText_5;
		private HtmlInputText htmlInputText_6;
		private HtmlInputText htmlInputText_7;
		private Label label_2;
		private Label label_3;
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
		public string AdPayment
		{
			get;
			set;
		}
		public string OrderNumber
		{
			get;
			set;
		}
		public A_AdPayTransfer()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.htmlInputText_0 = (HtmlInputText)skin.FindControl("txt_Transfer");
			this.htmlInputText_2 = (HtmlInputText)skin.FindControl("txt_TransferID");
			this.htmlTextArea_0 = (HtmlTextArea)skin.FindControl("txt_Remark");
			this.htmlInputText_1 = (HtmlInputText)skin.FindControl("txt_RealName");
			this.htmlInputText_3 = (HtmlInputText)skin.FindControl("txt_ConfirmTransferID");
			this.label_1 = (Label)skin.FindControl("Lab_AdPayment");
			this.label_0 = (Label)skin.FindControl("Lab_MemLoginID");
			this.htmlInputPassword_0 = (HtmlInputPassword)skin.FindControl("input_PayPwd");
			this.htmlInputText_4 = (HtmlInputText)skin.FindControl("txtMobileCode");
			this.button_0 = (Button)skin.FindControl("Btn_Confirm");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.repeater_0 = (Repeater)skin.FindControl("Rep_PayTransfer");
			this.repeater_1 = (Repeater)skin.FindControl("Rep_NoValue");
			this.htmlInputText_5 = (HtmlInputText)skin.FindControl("txt_OrderNum");
			this.htmlInputText_6 = (HtmlInputText)skin.FindControl("txt_StartTime");
			this.htmlInputText_7 = (HtmlInputText)skin.FindControl("txt_EndTime");
			this.label_2 = (Label)skin.FindControl("lab_PayNum");
			this.label_3 = (Label)skin.FindControl("lab_PayTransfer");
			this.button_1 = (Button)skin.FindControl("Btn_Select");
			this.button_1.Click += new EventHandler(this.button_1_Click);
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
				this.htmlInputText_5.Value = this.strOrderNum;
				this.method_1();
			}
		}
		private void button_1_Click(object sender, EventArgs e)
		{
			this.strStartTime = this.htmlInputText_6.Value;
			this.strEndTime = this.htmlInputText_7.Value;
			this.strOrderNum = this.htmlInputText_5.Value;
			string text = Common.ReqStr("Type");
			text = ((text == "") ? "0" : text);
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				"A_AdPayTransfer.aspx?Type=",
				text,
				"&pageid=1&StartTime=",
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
			if (ShopSettings.GetValue("IsTransferPay") == "1")
			{
				int num = 0;
				try
				{
					string nameById = Common.GetNameById("mobile", "shopnum1_member", " and memloginId='" + this.MemLoginID + "' and mobile!=''");
					ShopNum1_MemberActivate_Action shopNum1_MemberActivate_Action = (ShopNum1_MemberActivate_Action)LogicFactory.CreateShopNum1_MemberActivate_Action();
					if (shopNum1_MemberActivate_Action.CheckMobileCode(this.htmlInputText_4.Value, nameById, "2") != "0")
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
				string md5SecondHash = Encryption.GetMd5SecondHash(this.htmlInputPassword_0.Value.Trim());
				if (payPwd != md5SecondHash)
				{
					MessageBox.Show("支付密码不正确!");
				}
				else
				{
					DataTable dataTable = new DataTable();
					if (this.htmlInputText_3.Value.Trim() != this.htmlInputText_2.Value.Trim())
					{
						MessageBox.Show("转账id不匹配");
					}
					else if (this.htmlInputText_2.Value.Trim() == this.MemLoginID)
					{
						MessageBox.Show("您不能转账给自己！");
					}
					else if (shopNum1_Member_Action.CheckmemLoginID(this.htmlInputText_2.Value.Trim()) > 0)
					{
						string payPwd2 = shopNum1_Member_Action.GetPayPwd(this.MemLoginID);
						if (Encryption.GetMd5SecondHash(this.htmlInputPassword_0.Value.Trim()) == payPwd2)
						{
							dataTable = shopNum1_Member_Action.SearchByMemLoginID(this.htmlInputText_2.Value.ToString());
							int num2 = shopNum1_Member_Action.Transfer(this.MemLoginID, this.htmlInputText_2.Value, Operator.FilterDouhao(this.htmlInputText_0.Value.Trim()));
							if (num2 == -1)
							{
								MessageBox.Show("预存款不足！");
							}
							else if (num2 == 0)
							{
								MessageBox.Show("转账失败！");
							}
							else if (num2 == 1)
							{
								try
								{
									ShopNum1_PreTransfer shopNum1_PreTransfer = new ShopNum1_PreTransfer();
									shopNum1_PreTransfer.Guid = Guid.NewGuid();
									shopNum1_PreTransfer.IsDeleted = new byte?(0);
									shopNum1_PreTransfer.MemLoginID = this.MemLoginID;
									shopNum1_PreTransfer.RMemberID = this.htmlInputText_2.Value.ToString();
									if (string.IsNullOrEmpty(this.htmlTextArea_0.Value))
									{
										this.htmlTextArea_0.Value = "转账给" + this.htmlInputText_2.Value;
									}
									shopNum1_PreTransfer.Memo = this.htmlTextArea_0.Value;
									shopNum1_PreTransfer.OperateMoney = Operator.FilterDouhao(this.htmlInputText_0.Value);
									shopNum1_PreTransfer.OperateStatus = new byte?(0);
									shopNum1_PreTransfer.type = new int?(1);
									shopNum1_PreTransfer.OperateStatus = new byte?(1);
									shopNum1_PreTransfer.Date = new DateTime?(DateTime.Now.ToLocalTime());
									Order order = new Order();
									this.OrderNumber = (shopNum1_PreTransfer.OrderNumber = "Z" + order.CreateOrderNumber());
									this.method_0(shopNum1_PreTransfer);
								}
								catch
								{
								}
								this.MoneyModifyLog(this.MemLoginID, this.htmlInputText_0.Value.Trim(), this.label_1.Text.Trim(), "0", "您转账给会员" + this.htmlInputText_2.Value.ToString() + "￥" + this.htmlInputText_0.Value.Trim());
								this.MoneyModifyLog(this.htmlInputText_2.Value.Trim(), this.htmlInputText_0.Value.Trim(), dataTable.Rows[0]["AdvancePayment"].ToString(), "1", string.Concat(new string[]
								{
									"会员",
									this.MemLoginID,
									"转账￥",
									this.htmlInputText_0.Value.Trim(),
									"给您"
								}));
								this.GetMemInfo();
								this.method_1();
								MessageBox.Show("转账成功！");
								this.Page.Response.Redirect("A_AdPayTransfer.aspx?type=1");
							}
						}
						else
						{
							MessageBox.Show("支付密码有误！");
						}
					}
					else
					{
						MessageBox.Show("该用户不存在！");
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
					this.label_1.Text = ((dataTable.Rows[0]["AdvancePayment"].ToString() == "") ? "0.00" : dataTable.Rows[0]["AdvancePayment"].ToString());
					this.AdPayment = this.label_1.Text;
				}
			}
			catch
			{
			}
		}
		private void method_0(ShopNum1_PreTransfer shopNum1_PreTransfer_0)
		{
			ShopNum1_PreTransfer_Action shopNum1_PreTransfer_Action = new ShopNum1_PreTransfer_Action();
			shopNum1_PreTransfer_Action.InsertPay(shopNum1_PreTransfer_0);
		}
		protected void MoneyModifyLog(string memloginID, string money, string CurrentAdvancePayment, string type, string string_8)
		{
			ShopNum1_AdvancePaymentModifyLog shopNum1_AdvancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog();
			shopNum1_AdvancePaymentModifyLog.Guid = new Guid?(Guid.NewGuid());
			shopNum1_AdvancePaymentModifyLog.OperateType = 6;
			shopNum1_AdvancePaymentModifyLog.CurrentAdvancePayment = Convert.ToDecimal(Operator.FilterDouhao(CurrentAdvancePayment));
			shopNum1_AdvancePaymentModifyLog.OperateMoney = Convert.ToDecimal(Operator.FilterDouhao(money));
			if (type == "0")
			{
				shopNum1_AdvancePaymentModifyLog.LastOperateMoney = Convert.ToDecimal(Operator.FilterDouhao(CurrentAdvancePayment)) - Convert.ToDecimal(Operator.FilterDouhao(money));
			}
			else
			{
				shopNum1_AdvancePaymentModifyLog.LastOperateMoney = Convert.ToDecimal(Operator.FilterDouhao(CurrentAdvancePayment)) + Convert.ToDecimal(Operator.FilterDouhao(money));
			}
			shopNum1_AdvancePaymentModifyLog.Date = DateTime.Now;
			shopNum1_AdvancePaymentModifyLog.Memo = string_8;
			shopNum1_AdvancePaymentModifyLog.MemLoginID = memloginID;
			shopNum1_AdvancePaymentModifyLog.CreateUser = this.MemLoginID;
			shopNum1_AdvancePaymentModifyLog.CreateTime = new DateTime?(DateTime.Now);
			shopNum1_AdvancePaymentModifyLog.IsDeleted = new int?(0);
			new Order();
			shopNum1_AdvancePaymentModifyLog.OrderNumber = this.OrderNumber;
			shopNum1_AdvancePaymentModifyLog.UserMemo = this.htmlTextArea_0.Value;
			ShopNum1_AdvancePaymentModifyLog_Action shopNum1_AdvancePaymentModifyLog_Action = (ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
			shopNum1_AdvancePaymentModifyLog_Action.OperateMoney(shopNum1_AdvancePaymentModifyLog);
		}
		private void method_1()
		{
			ShopNum1_AdvancePaymentModifyLog_Action shopNum1_AdvancePaymentModifyLog_Action = (ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
			try
			{
				string text = string.Empty;
				if (!string.IsNullOrEmpty(this.MemLoginID))
				{
					if (Common.ReqStr("type") == "0")
					{
						return;
					}
					if (Common.ReqStr("type") == "1")
					{
						text = text + "  AND  MemLoginID=  '" + this.MemLoginID + "'   ";
						text = this.method_2(text);
					}
					else
					{
						text = text + "  AND  Rmemberid=  '" + this.MemLoginID + "'   ";
						text = this.method_2(text);
					}
				}
				CommonPageModel commonPageModel = new CommonPageModel();
				commonPageModel.Condition = "  AND   1=1   " + text + "     AND  IsDeleted=0 ";
				commonPageModel.Currentpage = this.pageid.ToString();
				commonPageModel.Tablename = "ShopNum1_PreTransfer";
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
				PageListBll pageListBll = new PageListBll("main/Account/A_AdPayTransfer.aspx", true);
				this.htmlGenericControl_0.InnerHtml = pageListBll.GetPageListNew(pageList);
				commonPageModel.Resultnum = "1";
				DataTable dataTable2 = shopNum1_AdvancePaymentModifyLog_Action.SelectAdvPaymentModifyLog_List(commonPageModel);
				string nameById = Common.GetNameById("SUM(cast(OperateMoney as float))", "ShopNum1_PreTransfer", text);
				if (!string.IsNullOrEmpty(nameById))
				{
					this.label_3.Text = nameById;
				}
				else
				{
					this.label_3.Text = "0";
				}
				string nameById2 = Common.GetNameById("COUNT(Guid)", "ShopNum1_PreTransfer", text);
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
					this.repeater_0.DataSource = dataTable2;
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
		private string method_2(string string_8)
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
			return string_8;
		}
		protected int GetID()
		{
			string columnName = "ID";
			string tableName = "ShopNum1_AdvancePaymentApplyLog";
			return 1 + ShopNum1_Common_Action.ReturnMaxID(columnName, tableName);
		}
	}
}
