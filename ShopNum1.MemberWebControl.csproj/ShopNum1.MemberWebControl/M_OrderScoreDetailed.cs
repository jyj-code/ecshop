using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.MemberWebControl
{
	[ParseChildren(true)]
	public class M_OrderScoreDetailed : BaseMemberWebControl
	{
		private string string_0 = "M_OrderScoreDetailed.ascx";
		private Label label_0;
		private Label label_1;
		private Label label_2;
		private Label label_3;
		private Repeater repeater_0;
		private Label label_4;
		private Label label_5;
		private Label label_6;
		private Label label_7;
		private Label label_8;
		private Button button_0;
		private HiddenField hiddenField_0;
		private Label label_9;
		private Label label_10;
		private Label label_11;
		private Label label_12;
		private Label label_13;
		public M_OrderScoreDetailed()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.label_0 = (Label)skin.FindControl("LabelOrderNumber");
			this.label_1 = (Label)skin.FindControl("LabelCreateTime");
			this.label_2 = (Label)skin.FindControl("LabelOderStatus");
			this.label_3 = (Label)skin.FindControl("LabelConfirmTime");
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterProduct");
			this.label_4 = (Label)skin.FindControl("LabelName");
			this.label_5 = (Label)skin.FindControl("LabelPostalcode");
			this.label_6 = (Label)skin.FindControl("LabelMobile");
			this.label_7 = (Label)skin.FindControl("LabelEmail");
			this.label_8 = (Label)skin.FindControl("LabelAddress");
			this.button_0 = (Button)skin.FindControl("ButtonBack");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.hiddenField_0 = (HiddenField)skin.FindControl("HiddenFieldShopMemLoginID");
			this.label_9 = (Label)skin.FindControl("LabelShopID");
			this.label_10 = (Label)skin.FindControl("LabelShopName");
			this.label_11 = (Label)skin.FindControl("LabelShopPhone");
			this.label_12 = (Label)skin.FindControl("LabelShopEmail");
			this.label_13 = (Label)skin.FindControl("LabelShopAddress");
			if (this.Page.Request.QueryString["guid"] != null)
			{
				this.GetOrder();
				this.GetOrderProduct();
				this.GetSellUser();
			}
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			this.Page.Response.Redirect("M_OrderScoreList.aspx");
		}
		public void GetSellUser()
		{
			ShopNum1_ScoreOrderInfo_Action shopNum1_ScoreOrderInfo_Action = (ShopNum1_ScoreOrderInfo_Action)LogicFactory.CreateShopNum1_ScoreOrderInfo_Action();
			DataTable shopInfo = shopNum1_ScoreOrderInfo_Action.GetShopInfo(this.hiddenField_0.Value);
			if (shopInfo != null && shopInfo.Rows.Count > 0)
			{
				this.label_9.Text = this.hiddenField_0.Value;
				this.label_10.Text = shopInfo.Rows[0]["ShopName"].ToString();
				this.label_11.Text = shopInfo.Rows[0]["UserMobile"].ToString();
				this.label_12.Text = shopInfo.Rows[0]["UserEmail"].ToString();
				this.label_13.Text = shopInfo.Rows[0]["Address"].ToString();
			}
		}
		public void GetOrderProduct()
		{
			string orderNumber = string.Empty;
			ShopNum1_ScoreOrderInfo_Action shopNum1_ScoreOrderInfo_Action = (ShopNum1_ScoreOrderInfo_Action)LogicFactory.CreateShopNum1_ScoreOrderInfo_Action();
			DataTable infoByGuid = shopNum1_ScoreOrderInfo_Action.GetInfoByGuid(this.Page.Request.QueryString["guid"].ToString());
			if (infoByGuid != null && infoByGuid.Rows.Count > 0)
			{
				orderNumber = infoByGuid.Rows[0]["OrderNumber"].ToString();
			}
			DataTable productByOrderNumber = shopNum1_ScoreOrderInfo_Action.GetProductByOrderNumber(orderNumber);
			if (productByOrderNumber != null && productByOrderNumber.Rows.Count > 0)
			{
				this.repeater_0.DataSource = productByOrderNumber.DefaultView;
				this.repeater_0.DataBind();
			}
		}
		public void GetOrder()
		{
			ShopNum1_ScoreOrderInfo_Action shopNum1_ScoreOrderInfo_Action = (ShopNum1_ScoreOrderInfo_Action)LogicFactory.CreateShopNum1_ScoreOrderInfo_Action();
			DataTable infoByGuid = shopNum1_ScoreOrderInfo_Action.GetInfoByGuid(this.Page.Request.QueryString["guid"].ToString());
			if (infoByGuid != null && infoByGuid.Rows.Count > 0)
			{
				this.label_0.Text = infoByGuid.Rows[0]["OrderNumber"].ToString();
				this.label_1.Text = infoByGuid.Rows[0]["CreateTime"].ToString();
				if (infoByGuid.Rows[0]["OderStatus"].ToString() == "1")
				{
					this.label_2.Text = "已处理";
				}
				else
				{
					this.label_2.Text = "未处理";
				}
				if (Convert.ToDateTime(infoByGuid.Rows[0]["ConfirmTime"].ToString()) == Convert.ToDateTime("1900-1-1"))
				{
					this.label_3.Text = "未处理";
				}
				else
				{
					this.label_3.Text = infoByGuid.Rows[0]["ConfirmTime"].ToString();
				}
				this.label_4.Text = infoByGuid.Rows[0]["Name"].ToString();
				this.label_5.Text = infoByGuid.Rows[0]["Postalcode"].ToString();
				this.label_6.Text = infoByGuid.Rows[0]["Mobile"].ToString();
				this.label_7.Text = infoByGuid.Rows[0]["Email"].ToString();
				string text = string.Empty;
				string str = string.Empty;
				string str2 = string.Empty;
				if (!string.IsNullOrEmpty(infoByGuid.Rows[0]["Address"].ToString()))
				{
					string[] array = infoByGuid.Rows[0]["Address"].ToString().Split(new char[]
					{
						'|'
					});
					if (array.Length > 0)
					{
						text = array[0].ToString();
						str = array[1].ToString();
					}
					string text2 = string.Empty;
					if (!string.IsNullOrEmpty(text))
					{
						string[] array2 = text.Split(new char[]
						{
							'/'
						});
						if (array2.Length > 0)
						{
							text2 = array2[0].ToString();
						}
					}
					if (text2.Length == 9)
					{
						DataTable adressNameByCode = shopNum1_ScoreOrderInfo_Action.GetAdressNameByCode(text2.Substring(0, 3));
						if (adressNameByCode != null && adressNameByCode.Rows.Count > 0)
						{
							str2 += adressNameByCode.Rows[0]["Name"].ToString();
						}
						DataTable adressNameByCode2 = shopNum1_ScoreOrderInfo_Action.GetAdressNameByCode(text2.Substring(0, 6));
						if (adressNameByCode2 != null && adressNameByCode2.Rows.Count > 0)
						{
							str2 += adressNameByCode2.Rows[0]["Name"].ToString();
						}
						DataTable adressNameByCode3 = shopNum1_ScoreOrderInfo_Action.GetAdressNameByCode(text2);
						if (adressNameByCode3 != null && adressNameByCode3.Rows.Count > 0)
						{
							str2 += adressNameByCode3.Rows[0]["Name"].ToString();
						}
					}
					else if (text2.Length == 6)
					{
						DataTable adressNameByCode = shopNum1_ScoreOrderInfo_Action.GetAdressNameByCode(text2.Substring(0, 3));
						if (adressNameByCode != null && adressNameByCode.Rows.Count > 0)
						{
							str2 += adressNameByCode.Rows[0]["Name"].ToString();
						}
						DataTable adressNameByCode3 = shopNum1_ScoreOrderInfo_Action.GetAdressNameByCode(text2);
						if (adressNameByCode3 != null && adressNameByCode3.Rows.Count > 0)
						{
							str2 += adressNameByCode3.Rows[0]["Name"].ToString();
						}
					}
					else if (text2.Length == 3)
					{
						DataTable adressNameByCode3 = shopNum1_ScoreOrderInfo_Action.GetAdressNameByCode(text2);
						if (adressNameByCode3 != null && adressNameByCode3.Rows.Count > 0)
						{
							str2 += adressNameByCode3.Rows[0]["Name"].ToString();
						}
					}
				}
				this.label_8.Text = str2 + str;
				this.hiddenField_0.Value = infoByGuid.Rows[0]["ShopMemLoginID"].ToString();
			}
		}
	}
}
