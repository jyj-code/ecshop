using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class W_WelcomeWx : BaseShopWebControl
	{
		private string string_0 = "W_WelcomeWx.ascx";
		private HtmlInputHidden htmlInputHidden_0;
		private HtmlInputHidden htmlInputHidden_1;
		private HtmlInputHidden htmlInputHidden_2;
		private HtmlInputHidden htmlInputHidden_3;
		private HtmlInputHidden htmlInputHidden_4;
		private HtmlInputHidden htmlInputHidden_5;
		private HtmlInputHidden htmlInputHidden_6;
		private HtmlInputHidden htmlInputHidden_7;
		private Label label_0;
		private HtmlAnchor htmlAnchor_0;
		private Button button_0;
		public W_WelcomeWx()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.htmlInputHidden_1 = (HtmlInputHidden)skin.FindControl("hidShowWeiXin");
			this.htmlInputHidden_2 = (HtmlInputHidden)skin.FindControl("hidOpenTime");
			this.htmlInputHidden_3 = (HtmlInputHidden)skin.FindControl("hidEndTime");
			this.htmlInputHidden_0 = (HtmlInputHidden)skin.FindControl("hidIsTip");
			this.htmlInputHidden_4 = (HtmlInputHidden)skin.FindControl("hidWxPayMoney");
			this.htmlInputHidden_5 = (HtmlInputHidden)skin.FindControl("hidPayTime");
			this.htmlInputHidden_7 = (HtmlInputHidden)skin.FindControl("hidDepartTime");
			this.htmlInputHidden_6 = (HtmlInputHidden)skin.FindControl("hidMyShouldPay");
			this.label_0 = (Label)skin.FindControl("lblIsHavePayPwd");
			this.htmlAnchor_0 = (HtmlAnchor)skin.FindControl("Apaypwdalink");
			this.button_0 = (Button)skin.FindControl("BtnPay");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			if (!this.Page.IsPostBack)
			{
				this.method_0();
			}
		}
		private void method_0()
		{
            DataTable tableById = ShopNum1.Common.Common.GetTableById("IsWeixin,wOpenTime,wEndTime,wDepartTime,wPayMoney", "shopnum1_shopinfo", " And memloginId='" + this.MemLoginID + "'");
			if (tableById.Rows.Count > 0)
			{
				this.htmlInputHidden_1.Value = tableById.Rows[0]["IsWeixin"].ToString();
				this.htmlInputHidden_2.Value = tableById.Rows[0]["wOpenTime"].ToString();
				this.htmlInputHidden_3.Value = tableById.Rows[0]["wEndTime"].ToString();
				string text = tableById.Rows[0]["wDepartTime"].ToString();
				this.htmlInputHidden_7.Value = text;
				string text2 = text;
				if (text2 != null)
				{
					if (text2 == "1")
					{
						this.htmlInputHidden_5.Value = "1个月";
						goto IL_188;
					}
					if (text2 == "3")
					{
						this.htmlInputHidden_5.Value = "3个月";
						goto IL_188;
					}
					if (text2 == "6")
					{
						this.htmlInputHidden_5.Value = "6个月";
						goto IL_188;
					}
					if (text2 == "12")
					{
						this.htmlInputHidden_5.Value = "1年";
						goto IL_188;
					}
					if (text2 == "24")
					{
						this.htmlInputHidden_5.Value = "2年";
						goto IL_188;
					}
				}
				this.htmlInputHidden_5.Value = "1年";
				IL_188:
				if (this.htmlInputHidden_1.Value == "1")
				{
					if (this.htmlInputHidden_3.Value != "")
					{
						if (Convert.ToDateTime(this.htmlInputHidden_3.Value).AddMonths(-1) < DateTime.Now.ToLocalTime())
						{
							this.htmlInputHidden_0.Value = "1";
						}
					}
					else
					{
						this.htmlInputHidden_0.Value = "0";
					}
				}
				else
				{
					this.htmlInputHidden_0.Value = "3";
				}
				string nameById =ShopNum1.Common.Common.GetNameById("cast(advancepayment as varchar(20))+'|'+isnull(paypwd,0)", "shopnum1_member", " And memloginId='" + this.MemLoginID + "'");
				this.htmlInputHidden_6.Value = nameById.Split(new char[]
				{
					'|'
				})[0];
				if (nameById.Split(new char[]
				{
					'|'
				})[1] == "0")
				{
					this.label_0.Visible = true;
					this.htmlAnchor_0.Visible = true;
				}
				string text3 = tableById.Rows[0]["wPayMoney"].ToString();
				if (text3 == "")
				{
					text3 = ShopSettings.GetValue("WxPayMoney");
				}
				this.htmlInputHidden_4.Value = text3;
			}
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			string value = this.htmlInputHidden_1.Value;
			decimal num = 0m;
			decimal num2 = Convert.ToDecimal(this.htmlInputHidden_4.Value);
			if (!string.IsNullOrEmpty(this.htmlInputHidden_6.Value))
			{
				num = Convert.ToDecimal(this.htmlInputHidden_6.Value);
			}
			if (num < num2)
			{
				MessageBox.Show("预存款不足，请及时充值！");
			}
			else
			{
				ShopNum1_AdvancePaymentModifyLog_Action shopNum1_AdvancePaymentModifyLog_Action = (ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
				ShopNum1_AdvancePaymentModifyLog shopNum1_AdvancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog();
				shopNum1_AdvancePaymentModifyLog.Guid = new Guid?(Guid.NewGuid());
				shopNum1_AdvancePaymentModifyLog.OperateType = 3;
				shopNum1_AdvancePaymentModifyLog.CurrentAdvancePayment = num;
				shopNum1_AdvancePaymentModifyLog.OperateMoney = num2;
				shopNum1_AdvancePaymentModifyLog.LastOperateMoney = Convert.ToDecimal(num) - num2;
				shopNum1_AdvancePaymentModifyLog.Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
				shopNum1_AdvancePaymentModifyLog.MemLoginID = this.MemLoginID;
				shopNum1_AdvancePaymentModifyLog.CreateUser = this.MemLoginID;
				shopNum1_AdvancePaymentModifyLog.CreateTime = new DateTime?(Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
				shopNum1_AdvancePaymentModifyLog.IsDeleted = new int?(0);
				int months = 12;
				try
				{
					months = Convert.ToInt32(this.htmlInputHidden_7.Value);
				}
				catch
				{
				}
				if (value == "0" || value == "")
				{
                    ShopNum1.Common.Common.UpdateInfo(string.Concat(new object[]
					{
						"isWeixin=1,wopentime='",
						DateTime.Now.ToLocalTime(),
						"',wEndTime='",
						DateTime.Now.ToLocalTime().AddMonths(months),
						"'"
					}), "shopnum1_shopinfo", " And memloginId='" + this.MemLoginID + "'");
					shopNum1_AdvancePaymentModifyLog.Memo = "微信商城功能开启成功";
					shopNum1_AdvancePaymentModifyLog_Action.OperateMoney(shopNum1_AdvancePaymentModifyLog);
					this.Page.RegisterClientScriptBlock("pop", "<script>alert('微信商城功能开启成功！');window.parent.location.href='s_index.aspx';</script>");
				}
				else
				{
                    ShopNum1.Common.Common.UpdateInfo("wEndTime='" + DateTime.Now.ToLocalTime().AddMonths(12) + "'", "shopnum1_shopinfo", " And memloginId='" + this.MemLoginID + "'");
					shopNum1_AdvancePaymentModifyLog.Memo = "微信商城功能续费成功";
					shopNum1_AdvancePaymentModifyLog_Action.OperateMoney(shopNum1_AdvancePaymentModifyLog);
					this.Page.RegisterClientScriptBlock("pop", "<script>alert('微信商城功能续费成功！');location.href='W_WelcomeWX.aspx';</script>");
				}
			}
		}
	}
}
