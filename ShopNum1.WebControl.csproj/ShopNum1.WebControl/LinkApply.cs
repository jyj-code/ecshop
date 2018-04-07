using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class LinkApply : BaseWebControl
	{
		private string string_0 = "LinkApply.ascx";
		private TextBox textBox_0;
		private TextBox textBox_1;
		private TextBox textBox_2;
		private TextBox textBox_3;
		private Button button_0;
		[CompilerGenerated]
		private static string string_1;
		[CompilerGenerated]
		private static string string_2;
		public static string Name
		{
			get;
			set;
		}
		public static string NetName
		{
			get;
			set;
		}
		public LinkApply()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxName");
			this.textBox_1 = (TextBox)skin.FindControl("TextBoxHref");
			this.textBox_2 = (TextBox)skin.FindControl("TextBoxDescription");
			this.textBox_3 = (TextBox)skin.FindControl("TextBoxMemo");
			this.button_0 = (Button)skin.FindControl("ButtonApply");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			if (this.Page.IsPostBack)
			{
			}
			LinkApply.Name = ShopSettings.GetValue("Name");
			LinkApply.NetName = ShopSettings.siteDomain;
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			if (!this.CheckIsDuplication())
			{
				MessageBox.Show("已提交过申请！");
			}
			else
			{
				ShopNum1_Link shopNum1_Link = new ShopNum1_Link();
				shopNum1_Link.Guid = Guid.NewGuid();
				shopNum1_Link.Href = "http://" + this.textBox_1.Text.Trim().Replace("http://", "");
				shopNum1_Link.Description = this.textBox_2.Text.Trim();
				shopNum1_Link.Memo = this.textBox_3.Text.Trim();
				shopNum1_Link.Name = this.textBox_0.Text.Trim();
				shopNum1_Link.ImgADD = string.Empty;
				shopNum1_Link.LinkType = 0;
				shopNum1_Link.ImgType = string.Empty;
				shopNum1_Link.CreateTime = DateTime.Now;
				shopNum1_Link.ModifyTime = DateTime.Now;
				shopNum1_Link.CreateUser = this.textBox_0.Text.Trim();
				shopNum1_Link.ModifyUser = this.textBox_0.Text.Trim();
				string columnName = "OrderID";
				string tableName = "ShopNum1_Link";
				int orderID = 1 + ShopNum1_Common_Action.ReturnMaxID(columnName, tableName);
				shopNum1_Link.OrderID = orderID;
				shopNum1_Link.IsShow = 0;
				shopNum1_Link.IsDeleted = 0;
				ShopNum1_Link_Action shopNum1_Link_Action = (ShopNum1_Link_Action)LogicFactory.CreateShopNum1_Link_Action();
				int num = shopNum1_Link_Action.Add(shopNum1_Link);
				if (num > 0)
				{
					MessageBox.Show("申请成功");
				}
				else
				{
					MessageBox.Show("申请失败");
				}
			}
		}
		protected bool CheckIsDuplication()
		{
			string link = "http://" + this.textBox_1.Text.Trim().Replace("http://", "");
			ShopNum1_Link_Action shopNum1_Link_Action = (ShopNum1_Link_Action)LogicFactory.CreateShopNum1_Link_Action();
			DataTable dataTable = shopNum1_Link_Action.CheckIsDuplication(link);
			return dataTable.Rows[0][0].ToString() == "0";
		}
	}
}
