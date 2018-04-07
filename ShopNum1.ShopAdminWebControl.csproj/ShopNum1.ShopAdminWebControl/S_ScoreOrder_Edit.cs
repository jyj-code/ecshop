using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_ScoreOrder_Edit : BaseMemberWebControl
	{
		private string string_0 = "S_ScoreOrder_Edit.ascx";
		private Label label_0;
		private Label label_1;
		private Label label_2;
		private Label label_3;
		private Label label_4;
		private Repeater repeater_0;
		private Label label_5;
		private Label label_6;
		private Label label_7;
		private Label label_8;
		private Label label_9;
		private Button button_0;
		private Button button_1;
		public S_ScoreOrder_Edit()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.label_0 = (Label)skin.FindControl("LabelOrderNumber");
			this.label_1 = (Label)skin.FindControl("LabelOderStatus");
			this.label_2 = (Label)skin.FindControl("LabelMemLoginID");
			this.label_3 = (Label)skin.FindControl("LabelCreateTime");
			this.label_4 = (Label)skin.FindControl("LabelTotalScore");
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterShopCart2");
			this.label_5 = (Label)skin.FindControl("LabelName");
			this.label_6 = (Label)skin.FindControl("LabelEmail");
			this.label_7 = (Label)skin.FindControl("LabelAddress");
			this.label_8 = (Label)skin.FindControl("LabelPostalcode");
			this.label_9 = (Label)skin.FindControl("LabelMobile");
			this.button_0 = (Button)skin.FindControl("ButtonOderStatus");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.button_1 = (Button)skin.FindControl("ButtonBackList");
			this.button_1.Click += new EventHandler(this.button_1_Click);
			if (this.Page.Request.QueryString["guid"] != null)
			{
				this.GetOrderData();
				this.GetOrderProduct();
			}
		}
		private void button_1_Click(object sender, EventArgs e)
		{
			if (this.Page.Request.QueryString["stype"] != null)
			{
				if (this.Page.Request.QueryString["OderStatus"] != null)
				{
					this.Page.Response.Redirect("S_ScoreOrder_List.aspx?stype=" + this.Page.Request.QueryString["stype"].ToString() + "&OderStatus=" + this.Page.Request.QueryString["OderStatus"].ToString());
				}
				else
				{
					this.Page.Response.Redirect("S_ScoreOrder_List.aspx?stype=" + this.Page.Request.QueryString["stype"].ToString());
				}
			}
			else
			{
				this.Page.Response.Redirect("S_ScoreOrder_List.aspx");
			}
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			ShopNum1_ScoreOrderInfo_Action shopNum1_ScoreOrderInfo_Action = (ShopNum1_ScoreOrderInfo_Action)LogicFactory.CreateShopNum1_ScoreOrderInfo_Action();
			try
			{
				int num = shopNum1_ScoreOrderInfo_Action.ChangeOderStatus(this.Page.Request.QueryString["guid"].ToString(), "1");
				if (num > 0)
				{
					MessageBox.Show("操作成功,请及时发货！");
					this.GetOrderData();
				}
			}
			catch (Exception)
			{
			}
		}
		public void GetOrderData()
		{
			ShopNum1_ScoreOrderInfo_Action shopNum1_ScoreOrderInfo_Action = (ShopNum1_ScoreOrderInfo_Action)LogicFactory.CreateShopNum1_ScoreOrderInfo_Action();
			DataTable infoByGuid = shopNum1_ScoreOrderInfo_Action.GetInfoByGuid(this.Page.Request.QueryString["guid"].ToString());
			if (infoByGuid != null && infoByGuid.Rows.Count > 0)
			{
				this.label_0.Text = infoByGuid.Rows[0]["OrderNumber"].ToString();
				if (infoByGuid.Rows[0]["OderStatus"].ToString() == "1")
				{
					this.label_1.Text = "已处理";
					this.button_0.Visible = false;
				}
				else
				{
					this.label_1.Text = "未处理";
				}
				this.label_2.Text = infoByGuid.Rows[0]["MemLoginID"].ToString();
				this.label_3.Text = infoByGuid.Rows[0]["CreateTime"].ToString();
				this.label_4.Text = infoByGuid.Rows[0]["TotalScore"].ToString();
				this.label_5.Text = infoByGuid.Rows[0]["Name"].ToString();
				this.label_6.Text = infoByGuid.Rows[0]["Email"].ToString();
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
				this.label_7.Text = str2 + str;
				this.label_8.Text = infoByGuid.Rows[0]["Postalcode"].ToString();
				this.label_9.Text = infoByGuid.Rows[0]["Mobile"].ToString();
			}
		}
		public void GetOrderProduct()
		{
			ShopNum1_ScoreOrderInfo_Action shopNum1_ScoreOrderInfo_Action = (ShopNum1_ScoreOrderInfo_Action)LogicFactory.CreateShopNum1_ScoreOrderInfo_Action();
			DataTable infoByGuid = shopNum1_ScoreOrderInfo_Action.GetInfoByGuid(this.Page.Request.QueryString["guid"].ToString());
			if (infoByGuid != null && infoByGuid.Rows.Count > 0)
			{
				string orderNumber = infoByGuid.Rows[0]["OrderNumber"].ToString();
				DataTable productByOrderNumber = shopNum1_ScoreOrderInfo_Action.GetProductByOrderNumber(orderNumber);
				if (productByOrderNumber != null && productByOrderNumber.Rows.Count > 0)
				{
					this.repeater_0.DataSource = productByOrderNumber.DefaultView;
					this.repeater_0.DataBind();
				}
			}
		}
	}
}
