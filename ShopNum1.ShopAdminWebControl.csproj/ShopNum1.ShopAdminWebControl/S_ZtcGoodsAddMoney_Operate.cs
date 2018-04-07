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
	public class S_ZtcGoodsAddMoney_Operate : BaseShopWebControl
	{
		private string string_0 = "S_ZtcGoodsAddMoney_Operate.ascx";
		private Label label_0;
		private Image image_0;
		private Label label_1;
		private Label label_2;
		private Button button_0;
		private Button button_1;
		private TextBox textBox_0;
		private Button button_2;
		private HiddenField hiddenField_0;
		private Label label_3;
		private Label label_4;
		private HtmlAnchor htmlAnchor_0;
		public S_ZtcGoodsAddMoney_Operate()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.hiddenField_0 = (HiddenField)skin.FindControl("HiddenFieldMyMoney");
			this.label_3 = (Label)skin.FindControl("LabelYue");
			this.label_4 = (Label)skin.FindControl("LabelIsHavePayPwd");
			this.htmlAnchor_0 = (HtmlAnchor)skin.FindControl("paypwdalink");
			this.button_2 = (Button)skin.FindControl("ButtonPay");
			this.button_2.Click += new EventHandler(this.button_2_Click);
			this.label_0 = (Label)skin.FindControl("LabelZtcName");
			this.image_0 = (Image)skin.FindControl("ImageProduct");
			this.label_1 = (Label)skin.FindControl("LabelZtcMoneyShow");
			this.label_2 = (Label)skin.FindControl("LabelShowState");
			this.button_0 = (Button)skin.FindControl("ButtonAddMoney");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.button_1 = (Button)skin.FindControl("ButtonBackList");
			this.button_1.Click += new EventHandler(this.button_1_Click);
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxAddMoney");
			if (this.Page.Request.QueryString["ID"] != null)
			{
				this.GetDataByID(this.Page.Request.QueryString["ID"].ToString());
			}
			string nameById = ShopNum1.Common.Common.GetNameById("PayPwd", "ShopNum1_Member", "  and  MemLoginID='" + this.MemLoginID + "'");
			string nameById2 = ShopNum1.Common.Common.GetNameById("AdvancePayment", "ShopNum1_Member", "  and  MemLoginID='" + this.MemLoginID + "'");
			this.label_3.Text = "您当前的预存款余额为：￥" + nameById2;
			this.hiddenField_0.Value = nameById2;
			if (string.IsNullOrEmpty(nameById))
			{
				this.label_4.Visible = true;
				this.htmlAnchor_0.Visible = true;
				this.button_2.Enabled = false;
			}
		}
		private void button_2_Click(object sender, EventArgs e)
		{
			decimal num = 0m;
			if (!decimal.TryParse(this.textBox_0.Text.Trim(), out num))
			{
				MessageBox.Show("输入格式错误！");
			}
			else
			{
				ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
				DataTable dataTable = shopNum1_Member_Action.SearchByMemLoginID(this.MemLoginID);
				if (dataTable != null && dataTable.Rows.Count > 0)
				{
					num = Convert.ToDecimal(dataTable.Rows[0]["AdvancePayment"].ToString());
				}
				if (Convert.ToDecimal(this.textBox_0.Text.Trim()) > num)
				{
					MessageBox.Show("预存款不足！");
				}
				else
				{
					try
					{
						ShopNum1_ZtcGoods_Action shopNum1_ZtcGoods_Action = (ShopNum1_ZtcGoods_Action)LogicFactory.CreateShopNum1_ZtcGoods_Action();
						int num2 = shopNum1_ZtcGoods_Action.UpdateAddMoney(this.Page.Request.QueryString["ID"].ToString().Replace("'", ""), Convert.ToDecimal(this.textBox_0.Text.Trim()));
						if (num2 > 0)
						{
							shopNum1_Member_Action.UpdateAdvancePayment(1, this.MemLoginID, Convert.ToDecimal(this.textBox_0.Text.Trim()));
							ShopNum1_AdvancePaymentModifyLog shopNum1_AdvancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog();
							shopNum1_AdvancePaymentModifyLog.Guid = new Guid?(Guid.NewGuid());
							shopNum1_AdvancePaymentModifyLog.OperateType = 3;
							shopNum1_AdvancePaymentModifyLog.CurrentAdvancePayment = num;
							shopNum1_AdvancePaymentModifyLog.OperateMoney = Convert.ToDecimal(this.textBox_0.Text.Trim());
							shopNum1_AdvancePaymentModifyLog.LastOperateMoney = num - Convert.ToDecimal(this.textBox_0.Text.Trim());
							shopNum1_AdvancePaymentModifyLog.Date = DateTime.Now;
							shopNum1_AdvancePaymentModifyLog.Memo = "续费直通车支付预存款￥" + this.textBox_0.Text.Trim();
							shopNum1_AdvancePaymentModifyLog.MemLoginID = this.MemLoginID;
							shopNum1_AdvancePaymentModifyLog.CreateUser = this.MemLoginID;
							shopNum1_AdvancePaymentModifyLog.CreateTime = new DateTime?(DateTime.Now);
							shopNum1_AdvancePaymentModifyLog.IsDeleted = new int?(0);
							ShopNum1_AdvancePaymentModifyLog_Action shopNum1_AdvancePaymentModifyLog_Action = (ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
							shopNum1_AdvancePaymentModifyLog_Action.OperateMoney(shopNum1_AdvancePaymentModifyLog);
							string g = string.Empty;
							string shopID = string.Empty;
							string shopName = string.Empty;
							string value = string.Empty;
							DataTable infoByGuid = shopNum1_ZtcGoods_Action.GetInfoByGuid(this.Page.Request.QueryString["ID"].ToString());
							if (infoByGuid != null && infoByGuid.Rows.Count > 0)
							{
								g = infoByGuid.Rows[0]["ProductGuid"].ToString();
								shopID = this.GetShopNameAndID(infoByGuid.Rows[0]["MemberID"].ToString(), 1);
								shopName = this.GetShopNameAndID(infoByGuid.Rows[0]["MemberID"].ToString(), 2);
								value = infoByGuid.Rows[0]["StartTime"].ToString();
							}
							ShopNum1_ZtcApply_Action shopNum1_ZtcApply_Action = (ShopNum1_ZtcApply_Action)LogicFactory.CreateShopNum1_ZtcApply_Action();
							int num3 = shopNum1_ZtcApply_Action.Add(new ShopNum1_ZtcApply
							{
								ApplyTime = new DateTime?(DateTime.Now),
								AuditState = new byte?(1),
								AuditTime = new DateTime?(DateTime.Now),
								CreateTime = new DateTime?(DateTime.Now),
								CreateUser = this.MemLoginID,
								IsDeleted = new int?(0),
								MemberID = this.MemLoginID,
								OperateRemark = "续费",
								OperateUser = "",
								PayState = new byte?(1),
								ProductGuid = new Guid?(new Guid(g)),
								ProductName = this.label_0.Text,
								Remark = "续费",
								ShopID = shopID,
								ShopName = shopName,
								StartTime = new DateTime?(Convert.ToDateTime(value)),
								Type = new byte?(1),
								Ztc_Money = new decimal?(Convert.ToDecimal(this.textBox_0.Text.Trim()))
							});
							if (num3 > 0)
							{
								MessageBox.Show("充值成功！");
								this.GetDataByID(this.Page.Request.QueryString["ID"].ToString());
							}
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show("充值失败！错误：" + ex.Message);
					}
				}
			}
		}
		public void GetDataByID(string ID)
		{
			ShopNum1_ZtcGoods_Action shopNum1_ZtcGoods_Action = (ShopNum1_ZtcGoods_Action)LogicFactory.CreateShopNum1_ZtcGoods_Action();
			DataTable infoByGuid = shopNum1_ZtcGoods_Action.GetInfoByGuid(ID);
			if (infoByGuid != null && infoByGuid.Rows.Count > 0)
			{
				this.label_0.Text = infoByGuid.Rows[0]["ZtcName"].ToString();
				this.image_0.ImageUrl = infoByGuid.Rows[0]["ZtcImg"].ToString();
				this.label_1.Text = infoByGuid.Rows[0]["Ztc_Money"].ToString();
				this.label_2.Text = this.GetDay(Convert.ToDecimal(infoByGuid.Rows[0]["Ztc_Money"].ToString()));
			}
		}
		public string GetDay(decimal Ztc_Money)
		{
			decimal num = Convert.ToDecimal(ShopSettings.GetValue("ZtcMoney").ToString());
			string result;
			if (num > Ztc_Money)
			{
				result = "余额不足";
			}
			else
			{
				decimal num2 = Ztc_Money % num;
				if (num2 != 0m)
				{
					if (Convert.ToDouble(num2) / Convert.ToDouble(num) > 0.5)
					{
						result = "余额还可使用" + (Convert.ToInt32(Ztc_Money / num) - 1).ToString() + "天";
					}
					else
					{
						result = "余额还可使用" + Convert.ToInt32(Ztc_Money / num).ToString() + "天";
					}
				}
				else
				{
					result = "余额还可使用" + Convert.ToInt32(Ztc_Money / num).ToString() + "天";
				}
			}
			return result;
		}
		private void button_1_Click(object sender, EventArgs e)
		{
			this.Page.Response.Redirect("S_ZtcGoods_List.aspx");
		}
		private void button_0_Click(object sender, EventArgs e)
		{
		}
		public string GetShopNameAndID(string MemberID, int typeid)
		{
			string result = string.Empty;
			ShopNum1_ZtcGoods_Action shopNum1_ZtcGoods_Action = (ShopNum1_ZtcGoods_Action)LogicFactory.CreateShopNum1_ZtcGoods_Action();
			DataTable dataTable = shopNum1_ZtcGoods_Action.SearchShopInfo(this.MemLoginID);
			string text = "";
			string text2 = "";
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				text = dataTable.Rows[0]["ShopID"].ToString();
				text2 = dataTable.Rows[0]["ShopName"].ToString();
			}
			if (typeid == 1)
			{
				result = text;
			}
			else if (typeid == 2)
			{
				result = text2;
			}
			return result;
		}
	}
}
