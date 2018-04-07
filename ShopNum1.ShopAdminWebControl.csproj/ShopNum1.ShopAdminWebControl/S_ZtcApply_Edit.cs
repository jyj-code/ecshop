using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_ZtcApply_Edit : BaseMemberWebControl
	{
		private string string_0 = "S_ZtcApply_Edit.ascx";
		private Label label_0;
		private HiddenField hiddenField_0;
		private HiddenField hiddenField_1;
		private TextBox textBox_0;
		private TextBox textBox_1;
		private TextBox textBox_2;
		private HiddenField hiddenField_2;
		private Button button_0;
		private HiddenField hiddenField_3;
		private HiddenField hiddenField_4;
		private DropDownList dropDownList_0;
		private Button button_1;
		public S_ZtcApply_Edit()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.label_0 = (Label)skin.FindControl("LabelMoney");
			this.hiddenField_0 = (HiddenField)skin.FindControl("HiddenFieldMoney");
			this.hiddenField_1 = (HiddenField)skin.FindControl("HiddenFieldSelectPrpductGuid");
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxMoney");
			this.textBox_1 = (TextBox)skin.FindControl("TextBoxStartTime");
			this.textBox_2 = (TextBox)skin.FindControl("TextBoxRemark");
			this.hiddenField_2 = (HiddenField)skin.FindControl("HiddenFieldSelectPrpductName");
			this.button_0 = (Button)skin.FindControl("ButtonConfirm");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.hiddenField_3 = (HiddenField)skin.FindControl("HiddenFieldCode");
			this.hiddenField_4 = (HiddenField)skin.FindControl("HiddenFieldIsRight");
			this.dropDownList_0 = (DropDownList)skin.FindControl("DropDownListSubstationID");
			this.button_1 = (Button)skin.FindControl("ButtonBackList");
			this.button_1.Click += new EventHandler(this.button_1_Click);
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
			DataTable dataTable = shopNum1_Member_Action.SearchByMemLoginID(this.MemLoginID);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				this.label_0.Text = "当前拥有预存款:￥" + dataTable.Rows[0]["AdvancePayment"].ToString();
				this.hiddenField_0.Value = dataTable.Rows[0]["AdvancePayment"].ToString();
			}
		}
		private void button_1_Click(object sender, EventArgs e)
		{
			this.Page.Response.Redirect("S_ZtcApply_List.aspx");
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			this.CreateZtcApplyData();
		}
		public void CreateZtcApplyData()
		{
			string shopID = string.Empty;
			string shopName = string.Empty;
			ShopNum1_ZtcGoods_Action shopNum1_ZtcGoods_Action = (ShopNum1_ZtcGoods_Action)LogicFactory.CreateShopNum1_ZtcGoods_Action();
			DataTable dataTable = shopNum1_ZtcGoods_Action.SearchShopInfo(this.MemLoginID);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				shopID = dataTable.Rows[0]["ShopID"].ToString();
				shopName = dataTable.Rows[0]["ShopName"].ToString();
			}
			ShopNum1_ZtcApply_Action shopNum1_ZtcApply_Action = (ShopNum1_ZtcApply_Action)LogicFactory.CreateShopNum1_ZtcApply_Action();
			ShopNum1_ZtcApply shopNum1_ZtcApply = new ShopNum1_ZtcApply();
			shopNum1_ZtcApply.ApplyTime = new DateTime?(DateTime.Now);
			shopNum1_ZtcApply.AuditState = new byte?(0);
			shopNum1_ZtcApply.AuditTime = new DateTime?(Convert.ToDateTime("1900-1-1"));
			shopNum1_ZtcApply.CreateTime = new DateTime?(DateTime.Now);
			shopNum1_ZtcApply.CreateUser = this.MemLoginID;
			shopNum1_ZtcApply.IsDeleted = new int?(0);
			shopNum1_ZtcApply.MemberID = this.MemLoginID;
			shopNum1_ZtcApply.OperateRemark = "";
			shopNum1_ZtcApply.OperateUser = "";
			shopNum1_ZtcApply.PayState = new byte?(1);
			shopNum1_ZtcApply.ProductGuid = new Guid?(new Guid(this.hiddenField_1.Value));
			shopNum1_ZtcApply.ProductName = this.hiddenField_2.Value;
			shopNum1_ZtcApply.Remark = this.textBox_2.Text.Trim();
			shopNum1_ZtcApply.ShopID = shopID;
			shopNum1_ZtcApply.ShopName = shopName;
			shopNum1_ZtcApply.StartTime = new DateTime?(Convert.ToDateTime(this.textBox_1.Text.Trim()));
			shopNum1_ZtcApply.Type = new byte?(0);
			shopNum1_ZtcApply.Ztc_Money = new decimal?(Convert.ToDecimal(this.textBox_0.Text.Trim()));
			if (this.dropDownList_0.SelectedValue == "0")
			{
				string substationID = string.Empty;
				try
				{
					substationID = ShopNum1.Common.Common.GetNameById("SubstationID", "ShopNum1_ShopInfo", "   AND  MemLoginID='" + this.MemLoginID + "'   ");
				}
				catch (Exception)
				{
				}
				shopNum1_ZtcApply.SubstationID = substationID;
			}
			else
			{
				shopNum1_ZtcApply.SubstationID = "all";
			}
			int num = shopNum1_ZtcApply_Action.Add(shopNum1_ZtcApply);
			if (num > 0)
			{
				this.Yck();
				MessageBox.Show("申请成功，请等待审核！");
				this.hiddenField_3.Value = "0";
				this.hiddenField_1.Value = "0";
				this.hiddenField_4.Value = "0";
				this.hiddenField_2.Value = "";
				this.textBox_0.Text = "";
				this.textBox_1.Text = "";
				this.textBox_2.Text = "";
			}
		}
		public void Yck()
		{
			decimal num = 0m;
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
			DataTable dataTable = shopNum1_Member_Action.SearchByMemLoginID(this.MemLoginID);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				num = Convert.ToDecimal(dataTable.Rows[0]["AdvancePayment"].ToString());
			}
			shopNum1_Member_Action.UpdateAdvancePayment(1, this.MemLoginID, Convert.ToDecimal(this.textBox_0.Text.Trim()));
			ShopNum1_AdvancePaymentModifyLog shopNum1_AdvancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog();
			shopNum1_AdvancePaymentModifyLog.Guid = new Guid?(Guid.NewGuid());
			shopNum1_AdvancePaymentModifyLog.OperateType = 3;
			shopNum1_AdvancePaymentModifyLog.CurrentAdvancePayment = num;
			shopNum1_AdvancePaymentModifyLog.OperateMoney = Convert.ToDecimal(this.textBox_0.Text.Trim());
			shopNum1_AdvancePaymentModifyLog.LastOperateMoney = num - Convert.ToDecimal(this.textBox_0.Text.Trim());
			shopNum1_AdvancePaymentModifyLog.Date = DateTime.Now;
			shopNum1_AdvancePaymentModifyLog.Memo = "申请直通车支付预存款￥" + this.textBox_0.Text.Trim();
			shopNum1_AdvancePaymentModifyLog.MemLoginID = this.MemLoginID;
			shopNum1_AdvancePaymentModifyLog.CreateUser = this.MemLoginID;
			shopNum1_AdvancePaymentModifyLog.CreateTime = new DateTime?(DateTime.Now);
			shopNum1_AdvancePaymentModifyLog.IsDeleted = new int?(0);
			ShopNum1_AdvancePaymentModifyLog_Action shopNum1_AdvancePaymentModifyLog_Action = (ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
			shopNum1_AdvancePaymentModifyLog_Action.OperateMoney(shopNum1_AdvancePaymentModifyLog);
		}
	}
}
