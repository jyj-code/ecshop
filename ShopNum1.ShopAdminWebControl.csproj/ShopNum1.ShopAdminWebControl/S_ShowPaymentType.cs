using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_ShowPaymentType : BaseShopWebControl
	{
		private string string_0 = "S_ShowPaymentType.ascx";
		private Repeater repeater_0;
		public S_ShowPaymentType()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterShow");
			this.repeater_0.ItemDataBound += new RepeaterItemEventHandler(this.repeater_0_ItemDataBound);
			this.GetData();
		}
		private void repeater_0_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				Label label = (Label)e.Item.FindControl("LabelRun");
				Button button = (Button)e.Item.FindControl("runbutton");
				button.Click += new EventHandler(this.method_0);
				HtmlAnchor htmlAnchor = (HtmlAnchor)e.Item.FindControl("pzcj");
				HiddenField hiddenField = (HiddenField)e.Item.FindControl("HiddenFieldType");
				htmlAnchor.HRef = "../S_DeployPayment.aspx?run=edit&type=" + hiddenField.Value;
				label.Text = this.Run(label.Text);
				if (label.Text == "否")
				{
					button.Text = "安装";
					label.ForeColor = Color.Red;
					htmlAnchor.Visible = false;
				}
				else
				{
					button.Text = "卸载";
					htmlAnchor.Visible = true;
				}
			}
		}
		private void method_0(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			HiddenField hiddenField = button.Parent.FindControl("HiddenFieldType") as HiddenField;
			if (button.Text == "安装")
			{
				this.Page.Response.Redirect("S_DeployPayment.aspx?run=add&type=" + hiddenField.Value);
			}
			else if (button.Text == "卸载")
			{
				button.Text = "卸载中";
				if (this.OutReset(hiddenField.Value))
				{
					MessageBox.Show("卸载成功！");
					this.GetData();
				}
			}
		}
		public bool OutReset(string type)
		{
			ShopNum1_ShopPayment_Action shopNum1_ShopPayment_Action = (ShopNum1_ShopPayment_Action)LogicFactory.CreateShopNum1_ShopPayment_Action();
			int num = shopNum1_ShopPayment_Action.Delete(type, this.MemLoginID);
			return num > 0;
		}
		public void GetData()
		{
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
			DataTable paymentType = shopNum1_Member_Action.GetPaymentType(1);
			if (paymentType != null && paymentType.Rows.Count > 0)
			{
				this.repeater_0.DataSource = paymentType.DefaultView;
				this.repeater_0.DataBind();
			}
		}
		public string Run(string type)
		{
			ShopNum1_ShopPayment_Action shopNum1_ShopPayment_Action = (ShopNum1_ShopPayment_Action)LogicFactory.CreateShopNum1_ShopPayment_Action();
			DataTable paymentKey = shopNum1_ShopPayment_Action.GetPaymentKey(type, this.MemLoginID);
			string result;
			if (paymentKey != null && paymentKey.Rows.Count > 0)
			{
				result = "是";
			}
			else
			{
				result = "否";
			}
			return result;
		}
	}
}
