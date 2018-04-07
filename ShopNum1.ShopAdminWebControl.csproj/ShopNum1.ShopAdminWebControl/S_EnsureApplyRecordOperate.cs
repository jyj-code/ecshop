using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_EnsureApplyRecordOperate : BaseShopWebControl
	{
		private string string_0 = "S_EnsureApplyRecordOperate.ascx";
		private Label label_0;
		private HtmlInputText htmlInputText_0;
		private HtmlInputText htmlInputText_1;
		private HtmlInputText htmlInputText_2;
		private HtmlSelect htmlSelect_0;
		private HtmlInputHidden htmlInputHidden_0;
		private HtmlInputHidden htmlInputHidden_1;
		private Button button_0;
		private Button button_1;
		private string string_1 = string.Empty;
		private string string_2 = string.Empty;
		private string string_3 = string.Empty;
		private string string_4 = string.Empty;
		private HtmlAnchor htmlAnchor_0;
		public S_EnsureApplyRecordOperate()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.htmlAnchor_0 = (HtmlAnchor)skin.FindControl("GoPayPwd");
			string nameById = ShopNum1.Common.Common.GetNameById("PayPwd", "ShopNum1_Member", "  AND  MemLoginID='" + this.MemLoginID + "'  ");
			if (string.IsNullOrEmpty(nameById))
			{
				this.htmlAnchor_0.Visible = true;
			}
			else
			{
				this.htmlAnchor_0.Visible = false;
			}
			this.label_0 = (Label)skin.FindControl("lab_EnsureName");
			this.htmlInputText_0 = (HtmlInputText)skin.FindControl("txt_AdvPayMent");
			this.htmlInputText_1 = (HtmlInputText)skin.FindControl("txt_EnsureMoney");
			this.htmlInputText_2 = (HtmlInputText)skin.FindControl("txt_Remark");
			this.htmlSelect_0 = (HtmlSelect)skin.FindControl("sel_PayMent");
			this.htmlInputHidden_0 = (HtmlInputHidden)skin.FindControl("hid_payValue");
			this.htmlInputHidden_1 = (HtmlInputHidden)skin.FindControl("hid_payText");
			this.button_1 = (Button)skin.FindControl("btn_Back");
			this.button_1.Click += new EventHandler(this.button_1_Click);
			this.button_0 = (Button)skin.FindControl("btn_Sumbit");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.string_2 = ((ShopNum1.Common.Common.ReqStr("id") == "0") ? "0" : ShopNum1.Common.Common.ReqStr("id"));
			this.string_1 = ((ShopNum1.Common.Common.ReqStr("guid") == "null") ? "0" : ShopNum1.Common.Common.ReqStr("Guid"));
			this.string_3 = ((ShopNum1.Common.Common.ReqStr("type") == null) ? "" : ShopNum1.Common.Common.ReqStr("type"));
			this.string_4 = Encryption.GetMd5Hash(this.string_3);
			this.DateBind();
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			if (Convert.ToDecimal(this.htmlInputText_1.Value) > Convert.ToDecimal(this.htmlInputText_0.Value))
			{
				MessageBox.Show("预存款不足，请充值");
			}
			else
			{
				Shop_Ensure_Action shop_Ensure_Action = (Shop_Ensure_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Ensure_Action();
				if (shop_Ensure_Action.ApplyShopEnsure(new ShopNum1_Shop_ApplyEnsure
				{
					Guid = Guid.NewGuid(),
					EnsureID = int.Parse(this.string_2),
					ApplyTime = DateTime.Now,
					CreateUser = this.MemLoginID,
					ShopID = this.MemLoginID,
					IsPayMent = 1,
					Remarks = this.htmlInputText_2.Value,
					PaymentName = this.htmlInputHidden_1.Value,
					PaymentType = new Guid("9cf4b176-8ade-4211-878c-7b753c69450a"),
					MemberLoginID = this.MemLoginID,
					IsAudit = 1
				}) > 0)
				{
					decimal num = 0m;
					string nameById = ShopNum1.Common.Common.GetNameById("AdvancePayment", "ShopNum1_Member", "   AND    MemLoginID ='" + this.MemLoginID + "'    ");
					if (!string.IsNullOrEmpty(nameById))
					{
						num = Convert.ToDecimal(nameById);
					}
					decimal num2 = Convert.ToDecimal(this.htmlInputText_1.Value);
					if (num2 > 0m)
					{
						ShopNum1_AdvancePaymentModifyLog shopNum1_AdvancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog();
						shopNum1_AdvancePaymentModifyLog.Guid = new Guid?(Guid.NewGuid());
						shopNum1_AdvancePaymentModifyLog.OperateType = 3;
						shopNum1_AdvancePaymentModifyLog.CurrentAdvancePayment = num;
						shopNum1_AdvancePaymentModifyLog.OperateMoney = num2;
						shopNum1_AdvancePaymentModifyLog.LastOperateMoney = Convert.ToDecimal(num) - num2;
						shopNum1_AdvancePaymentModifyLog.Date = DateTime.Now;
						shopNum1_AdvancePaymentModifyLog.Memo = "申请店铺担保";
						shopNum1_AdvancePaymentModifyLog.MemLoginID = this.MemLoginID;
						shopNum1_AdvancePaymentModifyLog.CreateUser = this.MemLoginID;
						shopNum1_AdvancePaymentModifyLog.CreateTime = new DateTime?(DateTime.Now);
						shopNum1_AdvancePaymentModifyLog.IsDeleted = new int?(0);
						ShopNum1_AdvancePaymentModifyLog_Action shopNum1_AdvancePaymentModifyLog_Action = (ShopNum1_AdvancePaymentModifyLog_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
						shopNum1_AdvancePaymentModifyLog_Action.OperateMoney(shopNum1_AdvancePaymentModifyLog);
					}
					this.Page.Response.Redirect("S_EnsureApplyRecordList.aspx");
				}
				else
				{
					MessageBox.Show("购买失败！");
				}
			}
		}
		private void button_1_Click(object sender, EventArgs e)
		{
			this.Page.Response.Redirect("S_EnsureApplyRecordList.aspx");
		}
		protected void DateBind()
		{
			Shop_Ensure_Action shop_Ensure_Action = (Shop_Ensure_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Ensure_Action();
			DataTable shopEnsure = shop_Ensure_Action.GetShopEnsure(int.Parse(this.string_2));
			if (shopEnsure != null && shopEnsure.Rows.Count > 0)
			{
				this.label_0.Text = shopEnsure.Rows[0]["Name"].ToString();
				this.htmlInputText_1.Value = shopEnsure.Rows[0]["EnsureMoney"].ToString();
			}
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
			DataTable dataTable = shopNum1_Member_Action.SearchByMemLoginID(this.MemLoginID);
			this.htmlInputText_0.Value = dataTable.Rows[0]["AdvancePayment"].ToString();
		}
	}
}
