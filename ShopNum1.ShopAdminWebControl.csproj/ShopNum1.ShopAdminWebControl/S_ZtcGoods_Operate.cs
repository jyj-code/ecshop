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
	public class S_ZtcGoods_Operate : BaseMemberWebControl
	{
		private string string_0 = "S_ZtcGoods_Operate.ascx";
		private TextBox textBox_0;
		private Image image_0;
		private TextBox textBox_1;
		private TextBox textBox_2;
		private Label label_0;
		private Label label_1;
		private Label label_2;
		private Label label_3;
		private Label label_4;
		private Button button_0;
		private Button button_1;
		private Button button_2;
		private TextBox textBox_3;
		public S_ZtcGoods_Operate()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxZtcName");
			this.image_0 = (Image)skin.FindControl("ImageProduct");
			this.textBox_1 = (TextBox)skin.FindControl("TextBoxSellPrice");
			this.textBox_2 = (TextBox)skin.FindControl("TextBoxSellCount");
			this.label_0 = (Label)skin.FindControl("LabelZtcMoneyShow");
			this.label_1 = (Label)skin.FindControl("LabelStartTime");
			this.label_2 = (Label)skin.FindControl("LabelCreateTime");
			this.label_3 = (Label)skin.FindControl("LabelState");
			this.label_4 = (Label)skin.FindControl("LabelShowState");
			this.button_0 = (Button)skin.FindControl("ButtonConfirm");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.button_1 = (Button)skin.FindControl("ButtonAddMoney");
			this.button_1.Click += new EventHandler(this.button_1_Click);
			this.button_2 = (Button)skin.FindControl("ButtonBackList");
			this.button_2.Click += new EventHandler(this.button_2_Click);
			this.textBox_3 = (TextBox)skin.FindControl("TextBoxOrganizImg");
			if (this.Page.Request.QueryString["ID"] != null)
			{
				this.GetDataByID(this.Page.Request.QueryString["ID"].ToString());
			}
		}
		public void GetDataByID(string ID)
		{
			ShopNum1_ZtcGoods_Action shopNum1_ZtcGoods_Action = (ShopNum1_ZtcGoods_Action)LogicFactory.CreateShopNum1_ZtcGoods_Action();
			DataTable infoByGuid = shopNum1_ZtcGoods_Action.GetInfoByGuid(ID);
			if (infoByGuid != null && infoByGuid.Rows.Count > 0)
			{
				this.textBox_0.Text = infoByGuid.Rows[0]["ZtcName"].ToString();
				this.image_0.ImageUrl = infoByGuid.Rows[0]["ZtcImg"].ToString();
				this.textBox_3.Text = infoByGuid.Rows[0]["ZtcImg"].ToString();
				this.textBox_1.Text = infoByGuid.Rows[0]["SellPrice"].ToString();
				this.textBox_2.Text = infoByGuid.Rows[0]["SellCount"].ToString();
				this.label_0.Text = infoByGuid.Rows[0]["Ztc_Money"].ToString();
				this.label_1.Text = infoByGuid.Rows[0]["StartTime"].ToString();
				this.label_2.Text = infoByGuid.Rows[0]["CreateTime"].ToString();
				if (infoByGuid.Rows[0]["State"].ToString() == "0")
				{
					this.label_3.Text = "关闭";
				}
				else if (infoByGuid.Rows[0]["State"].ToString() == "1")
				{
					this.label_3.Text = "开启";
				}
				this.label_4.Text = this.GetDay(Convert.ToDecimal(infoByGuid.Rows[0]["Ztc_Money"].ToString()));
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
		private void button_2_Click(object sender, EventArgs e)
		{
			this.Page.Response.Redirect("S_ZtcGoods_List.aspx");
		}
		private void button_1_Click(object sender, EventArgs e)
		{
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			ShopNum1_ZtcGoods_Action shopNum1_ZtcGoods_Action = (ShopNum1_ZtcGoods_Action)LogicFactory.CreateShopNum1_ZtcGoods_Action();
			int num = 0;
			decimal num2 = 0m;
			if (!int.TryParse(this.textBox_2.Text.Trim(), out num))
			{
				MessageBox.Show("销售数量格式有误！");
			}
			else if (!decimal.TryParse(this.textBox_1.Text.Trim(), out num2))
			{
				MessageBox.Show("销售价格格式有误！");
			}
			else
			{
				try
				{
					int num3 = shopNum1_ZtcGoods_Action.Update(this.Page.Request.QueryString["ID"].ToString().Replace("'", ""), this.textBox_0.Text.Trim(), this.textBox_3.Text.Trim(), this.textBox_1.Text.Trim(), this.textBox_2.Text.Trim());
					if (num3 > 0)
					{
						MessageBox.Show("编辑成功！");
						this.GetDataByID(this.Page.Request.QueryString["ID"].ToString());
					}
					else
					{
						MessageBox.Show("编辑失败！");
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("编辑失败！原因：" + ex.Message);
				}
			}
		}
	}
}
