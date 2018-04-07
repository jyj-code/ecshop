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
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_ShopURLManageEdit : BaseShopWebControl
	{
		private string string_0 = "S_ShopURLManageEdit.aspx";
		private Label label_0;
		private TextBox textBox_0;
		private HiddenField hiddenField_0;
		private Button button_0;
		private Button button_1;
		private Label label_1;
		private Shop_URLManage_Action shop_URLManage_Action_0 = (Shop_URLManage_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_URLManage_Action();
		public S_ShopURLManageEdit()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.label_0 = (Label)skin.FindControl("LabelTitle");
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxDoMain");
			this.hiddenField_0 = (HiddenField)skin.FindControl("HiddenFieldID");
			this.button_0 = (Button)skin.FindControl("ButtonSubmit");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.button_1 = (Button)skin.FindControl("ButtonBackList");
			this.button_1.Click += new EventHandler(this.button_1_Click);
			this.label_1 = (Label)skin.FindControl("LabelDomain");
			string str = string.Empty;
			try
			{
				string nameById = ShopNum1.Common.Common.GetNameById("SubstationID", "ShopNum1_ShopInfo", "  and  MemLoginID='" + this.MemLoginID + "'  ");
				str = ShopNum1.Common.Common.GetNameById("DomainName", "ShopNum1_SubstationManage", "  and   SubstationID='" + nameById + "'  ");
			}
			catch (Exception)
			{
			}
			this.label_1.Text = "." + str + ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf('.'));
			if (this.Page.Request.QueryString["ID"] != null)
			{
				this.GetInfo();
				this.hiddenField_0.Value = this.Page.Request.QueryString["ID"].ToString();
				this.label_0.Text = "编辑域名";
			}
			else
			{
				this.label_0.Text = "添加域名";
			}
		}
		public void GetInfo()
		{
			Shop_URLManage_Action shop_URLManage_Action = (Shop_URLManage_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_URLManage_Action();
			DataTable editInfo = shop_URLManage_Action.GetEditInfo(this.Page.Request.QueryString["ID"].ToString());
			if (editInfo != null && editInfo.Rows.Count > 0)
			{
				this.textBox_0.Text = editInfo.Rows[0]["DoMain"].ToString();
				if (!(editInfo.Rows[0]["IsAudit"].ToString() == "1"))
				{
				}
			}
		}
		private void button_1_Click(object sender, EventArgs e)
		{
			this.Page.Response.Redirect("S_ShopURLManage.aspx");
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			if (this.Page.Request.QueryString["ID"] != null)
			{
				this.method_1();
			}
			else
			{
				this.method_0();
			}
		}
		private void method_0()
		{
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopInfoList_Action();
			shopNum1_ShopInfoList_Action.GetShopIDByMemLoginID(this.MemLoginID).Rows[0]["ShopID"].ToString();
			ShopNum1_ShopURLManage shopNum1_ShopURLManage = new ShopNum1_ShopURLManage();
			shopNum1_ShopURLManage.MemLoginID = this.MemLoginID;
			shopNum1_ShopURLManage.IsAudit = 0;
			shopNum1_ShopURLManage.DoMain = this.textBox_0.Text.Trim();
			shopNum1_ShopURLManage.SiteNumber = "";
			string str = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
			string str2 = string.Empty;
			try
			{
				string nameById = ShopNum1.Common.Common.GetNameById("SubstationID", "ShopNum1_ShopInfo", "   and  MemLoginID='" + this.MemLoginID + "'   ");
				string nameById2 = ShopNum1.Common.Common.GetNameById("DomainName", "ShopNum1_SubstationManage", "   and    SubstationID='" + nameById + "'   ");
				if (!string.IsNullOrEmpty(nameById2))
				{
					str2 = "." + nameById2;
				}
			}
			catch (Exception)
			{
			}
			shopNum1_ShopURLManage.GoUrl = shopNum1_ShopInfoList_Action.GetShopIDByMemLoginID(this.MemLoginID).Rows[0]["ShopUrl"].ToString() + str2 + str;
			if (this.shop_URLManage_Action_0.AddURLManage(shopNum1_ShopURLManage) > 0)
			{
				MessageBox.Show("申请成功，等待审核！");
				this.textBox_0.Text = "";
				this.Page.Response.Redirect("S_ShopURLManage.aspx");
			}
			else
			{
				MessageBox.Show("申请失败！");
			}
		}
		private void method_1()
		{
			ShopNum1_ShopURLManage shopNum1_ShopURLManage = new ShopNum1_ShopURLManage();
			shopNum1_ShopURLManage.ID = Convert.ToInt32(this.Page.Request.QueryString["ID"].ToString());
			shopNum1_ShopURLManage.MemLoginID = this.MemLoginID;
			shopNum1_ShopURLManage.IsAudit = 0;
			shopNum1_ShopURLManage.SiteNumber = "";
			shopNum1_ShopURLManage.DoMain = this.textBox_0.Text;
			if (this.shop_URLManage_Action_0.UpdateURLManage(shopNum1_ShopURLManage) > 0)
			{
				MessageBox.Show("编辑成功！");
			}
			else
			{
				MessageBox.Show("编辑失败!");
			}
		}
	}
}
