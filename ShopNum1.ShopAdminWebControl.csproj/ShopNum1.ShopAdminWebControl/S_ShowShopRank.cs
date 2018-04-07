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
	public class S_ShowShopRank : BaseShopWebControl
	{
		private string string_0 = "S_ShowShopRank.ascx";
		private Repeater repeater_0;
		private HiddenField hiddenField_0;
		private Button button_0;
		private HiddenField hiddenField_1;
		private Label label_0;
		private Label label_1;
		private HtmlAnchor htmlAnchor_0;
		public S_ShowShopRank()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.hiddenField_0 = (HiddenField)skin.FindControl("HiddenFieldRankGuid");
			this.button_0 = (Button)skin.FindControl("ButtonPay");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.hiddenField_1 = (HiddenField)skin.FindControl("HiddenFieldPayType");
			this.label_0 = (Label)skin.FindControl("LabelYue");
			this.label_1 = (Label)skin.FindControl("LabelIsHavePayPwd");
			this.htmlAnchor_0 = (HtmlAnchor)skin.FindControl("paypwdalink");
			string nameById = ShopNum1.Common.Common.GetNameById("PayPwd", "ShopNum1_Member", "  and  MemLoginID='" + this.MemLoginID + "'");
			string nameById2 = ShopNum1.Common.Common.GetNameById("AdvancePayment", "ShopNum1_Member", "  and  MemLoginID='" + this.MemLoginID + "'");
			this.label_0.Text = "您当前的预存款余额为：￥" + nameById2;
			if (string.IsNullOrEmpty(nameById))
			{
				this.label_1.Visible = true;
				this.htmlAnchor_0.Visible = true;
				this.button_0.Enabled = false;
			}
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterShow");
			this.repeater_0.ItemDataBound += new RepeaterItemEventHandler(this.repeater_0_ItemDataBound);
			this.GetData();
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			Shop_Rank_Action arg_0A_0 = (Shop_Rank_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Rank_Action();
			DataTable tableById = ShopNum1.Common.Common.GetTableById("*", "ShopNum1_ShopRank", " AND  Guid='" + this.hiddenField_0.Value + "'   ");
			string rankName = string.Empty;
			if (tableById != null && tableById.Rows.Count > 0)
			{
				decimal num = Convert.ToDecimal(tableById.Rows[0]["price"].ToString());
				rankName = tableById.Rows[0]["Name"].ToString();
				decimal num2 = 0m;
				string nameById = ShopNum1.Common.Common.GetNameById("AdvancePayment", "ShopNum1_Member", " AND  MemLoginID='" + this.MemLoginID + "'   ");
				if (!string.IsNullOrEmpty(nameById))
				{
					num2 = Convert.ToDecimal(nameById);
				}
				if (num2 < num)
				{
					MessageBox.Show("预存款不足，请及时充值！");
				}
				else
				{
					if (this.hiddenField_1.Value == "升级")
					{
						this.GoUp(num, rankName, num2);
					}
					else if (this.hiddenField_1.Value == "续费")
					{
						this.GoOn(num, num2);
					}
					this.hiddenField_0.Value = "";
					this.hiddenField_1.Value = "";
					this.GetData();
				}
			}
		}
		public void GoUp(decimal price, string RankName, decimal AdvancePayment)
		{
			Shop_ShopApplyRank_Action shop_ShopApplyRank_Action = (Shop_ShopApplyRank_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ShopApplyRank_Action();
			ShopNum1_Shop_ApplyShopRank shopNum1_Shop_ApplyShopRank = new ShopNum1_Shop_ApplyShopRank();
			shopNum1_Shop_ApplyShopRank.ApplyTime = new DateTime?(DateTime.Now);
			shopNum1_Shop_ApplyShopRank.IsAudit = 1;
			shopNum1_Shop_ApplyShopRank.MemberLoginID = this.MemLoginID;
			shopNum1_Shop_ApplyShopRank.IsPayMent = 1;
			shopNum1_Shop_ApplyShopRank.PaymentName = "预存款支付";
			shopNum1_Shop_ApplyShopRank.PaymentType = new Guid("385c9c54-2b58-4b65-8ea9-f01872126715");
			shopNum1_Shop_ApplyShopRank.RankGuid = new Guid(this.hiddenField_0.Value);
			shopNum1_Shop_ApplyShopRank.VerifyTime = new DateTime?(DateTime.Now.AddYears(1));
			shopNum1_Shop_ApplyShopRank.RankName = RankName;
			try
			{
				shop_ShopApplyRank_Action.Add(shopNum1_Shop_ApplyShopRank);
				try
				{
					shop_ShopApplyRank_Action.DeleteOutRankGuid(this.hiddenField_0.Value, this.MemLoginID);
				}
				catch (Exception)
				{
				}
				try
				{
					shop_ShopApplyRank_Action.UpdataShopRank(this.hiddenField_0.Value, this.MemLoginID);
				}
				catch (Exception)
				{
				}
				try
				{
					ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
					shopNum1_Member_Action.UpdateAdvancePayment(1, this.MemLoginID, price);
				}
				catch (Exception)
				{
				}
				ShopNum1_AdvancePaymentModifyLog shopNum1_AdvancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog();
				shopNum1_AdvancePaymentModifyLog.Guid = new Guid?(Guid.NewGuid());
				shopNum1_AdvancePaymentModifyLog.OperateType = 3;
				shopNum1_AdvancePaymentModifyLog.CurrentAdvancePayment = AdvancePayment;
				shopNum1_AdvancePaymentModifyLog.OperateMoney = price;
				shopNum1_AdvancePaymentModifyLog.LastOperateMoney = Convert.ToDecimal(AdvancePayment) - price;
				shopNum1_AdvancePaymentModifyLog.Date = DateTime.Now;
				shopNum1_AdvancePaymentModifyLog.Memo = "升级店铺等级";
				shopNum1_AdvancePaymentModifyLog.MemLoginID = this.MemLoginID;
				shopNum1_AdvancePaymentModifyLog.CreateUser = this.MemLoginID;
				shopNum1_AdvancePaymentModifyLog.CreateTime = new DateTime?(DateTime.Now);
				shopNum1_AdvancePaymentModifyLog.IsDeleted = new int?(0);
				ShopNum1_AdvancePaymentModifyLog_Action shopNum1_AdvancePaymentModifyLog_Action = (ShopNum1_AdvancePaymentModifyLog_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
				shopNum1_AdvancePaymentModifyLog_Action.OperateMoney(shopNum1_AdvancePaymentModifyLog);
				MessageBox.Show("升级成功！");
				this.GetData();
			}
			catch (Exception)
			{
				MessageBox.Show("升级失败！");
			}
		}
		public void GoOn(decimal price, decimal AdvancePayment)
		{
			DateTime dateTime = DateTime.Now;
			Shop_ShopApplyRank_Action shop_ShopApplyRank_Action = (Shop_ShopApplyRank_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ShopApplyRank_Action();
			DataTable nowLv = shop_ShopApplyRank_Action.GetNowLv(this.MemLoginID);
			if (nowLv != null && nowLv.Rows.Count > 0)
			{
				dateTime = Convert.ToDateTime(nowLv.Rows[0]["VerifyTime"].ToString());
			}
			DateTime dateTime2 = dateTime.AddYears(1);
			try
			{
				int num = shop_ShopApplyRank_Action.UpdataVerifyTime(dateTime2.ToString(), this.MemLoginID);
				if (num > 0)
				{
					try
					{
						ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
						shopNum1_Member_Action.UpdateAdvancePayment(1, this.MemLoginID, price);
					}
					catch (Exception)
					{
					}
					ShopNum1_AdvancePaymentModifyLog shopNum1_AdvancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog();
					shopNum1_AdvancePaymentModifyLog.Guid = new Guid?(Guid.NewGuid());
					shopNum1_AdvancePaymentModifyLog.OperateType = 3;
					shopNum1_AdvancePaymentModifyLog.CurrentAdvancePayment = AdvancePayment;
					shopNum1_AdvancePaymentModifyLog.OperateMoney = price;
					shopNum1_AdvancePaymentModifyLog.LastOperateMoney = Convert.ToDecimal(AdvancePayment) - price;
					shopNum1_AdvancePaymentModifyLog.Date = DateTime.Now;
					shopNum1_AdvancePaymentModifyLog.Memo = "续费店铺等级";
					shopNum1_AdvancePaymentModifyLog.MemLoginID = this.MemLoginID;
					shopNum1_AdvancePaymentModifyLog.CreateUser = this.MemLoginID;
					shopNum1_AdvancePaymentModifyLog.CreateTime = new DateTime?(DateTime.Now);
					shopNum1_AdvancePaymentModifyLog.IsDeleted = new int?(0);
					ShopNum1_AdvancePaymentModifyLog_Action shopNum1_AdvancePaymentModifyLog_Action = (ShopNum1_AdvancePaymentModifyLog_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
					shopNum1_AdvancePaymentModifyLog_Action.OperateMoney(shopNum1_AdvancePaymentModifyLog);
					MessageBox.Show(string.Concat(new object[]
					{
						"续费成功！(本次续费，共花费预存款",
						price,
						"元，续费期限延至",
						dateTime2.ToString(),
						")"
					}));
				}
			}
			catch (Exception)
			{
			}
		}
		private void repeater_0_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				HiddenField hiddenField = (HiddenField)e.Item.FindControl("HiddenFieldGuid");
				HiddenField hiddenField2 = (HiddenField)e.Item.FindControl("HiddenFieldIsDefault");
				Label label = (Label)e.Item.FindControl("LabelShopTemplateCount");
				Button button = (Button)e.Item.FindControl("ButtonPayGoOn");
				string text = label.Text;
				string text2 = "0";
				if (!string.IsNullOrEmpty(text))
				{
					string[] array = text.Split(new char[]
					{
						','
					});
					text2 = array.Length.ToString();
				}
				label.Text = text2;
				Button button2 = (Button)e.Item.FindControl("runbutton");
				if (!this.lvCompare(hiddenField.Value))
				{
					button2.Visible = false;
				}
				HtmlTableCell htmlTableCell = (HtmlTableCell)e.Item.FindControl("TdName");
				if (this.GetNowLV(hiddenField.Value))
				{
					htmlTableCell.Attributes["Class"] = "addOnline";
					button.Visible = true;
				}
				if (hiddenField2.Value == "0")
				{
					button2.Visible = false;
					button.Visible = false;
				}
			}
		}
		public bool GetNowLV(string guid)
		{
			Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ShopInfo_Action();
			DataTable dataInfoByMemLoginID = shop_ShopInfo_Action.GetDataInfoByMemLoginID(this.MemLoginID);
			string b = string.Empty;
			if (dataInfoByMemLoginID != null && dataInfoByMemLoginID.Rows.Count > 0)
			{
				b = dataInfoByMemLoginID.Rows[0]["ShopRank"].ToString();
			}
			return guid == b;
		}
		public bool lvCompare(string guid)
		{
			int num = -1;
			int num2 = 0;
			Shop_Rank_Action shop_Rank_Action = (Shop_Rank_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Rank_Action();
			Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ShopInfo_Action();
			DataTable dataInfoByMemLoginID = shop_ShopInfo_Action.GetDataInfoByMemLoginID(this.MemLoginID);
			string str = string.Empty;
			if (dataInfoByMemLoginID != null && dataInfoByMemLoginID.Rows.Count > 0)
			{
				str = dataInfoByMemLoginID.Rows[0]["ShopRank"].ToString();
			}
			DataTable dataTable = shop_Rank_Action.Search("'" + str + "'", 0);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				num = Convert.ToInt32(dataTable.Rows[0]["RankValue"].ToString());
			}
			DataTable dataTable2 = shop_Rank_Action.Search("'" + guid + "'", 0);
			if (dataTable2 != null && dataTable2.Rows.Count > 0)
			{
				num2 = Convert.ToInt32(dataTable2.Rows[0]["RankValue"].ToString());
			}
			return num < num2;
		}
		public void GetData()
		{
			Shop_Rank_Action shop_Rank_Action = (Shop_Rank_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Rank_Action();
			DataTable dataTable = shop_Rank_Action.Search(0);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				this.repeater_0.DataSource = dataTable.DefaultView;
				this.repeater_0.DataBind();
			}
		}
	}
}
