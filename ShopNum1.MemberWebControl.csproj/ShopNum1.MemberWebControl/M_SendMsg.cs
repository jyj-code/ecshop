using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;
using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.MemberWebControl
{
	[ParseChildren(true)]
	public class M_SendMsg : BaseMemberWebControl
	{
		private string string_0 = "M_SendMsg.ascx";
		private Button button_0;
		private HtmlInputText htmlInputText_0;
		private HtmlInputText htmlInputText_1;
		private HtmlTextArea htmlTextArea_0;
		private HiddenField hiddenField_0;
		public M_SendMsg()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.hiddenField_0 = (HiddenField)skin.FindControl("HiddenFieldUser");
			this.htmlInputText_0 = (HtmlInputText)skin.FindControl("txtTitle");
			this.htmlInputText_1 = (HtmlInputText)skin.FindControl("txtUser");
			this.htmlTextArea_0 = (HtmlTextArea)skin.FindControl("txtMsg");
			this.button_0 = (Button)skin.FindControl("butSure");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			if (!this.Page.IsPostBack)
			{
				if (ShopNum1.Common.Common.ReqStr("ordernumber").IndexOf("|") == -1)
				{
					this.htmlInputText_1.Value = ShopNum1.Common.Common.GetNameById("shopid", "shopnum1_orderinfo", " and ordernumber='" + ShopNum1.Common.Common.ReqStr("ordernumber") + "'");
				}
				else
				{
					this.htmlInputText_1.Value = ShopNum1.Common.Common.GetNameById("memloginid", "shopnum1_orderinfo", " and ordernumber='" + ShopNum1.Common.Common.ReqStr("ordernumber").Split(new char[]
					{
						'|'
					})[0] + "'");
				}
			}
			this.hiddenField_0.Value = this.MemLoginID;
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			ShopNum1_MemberMessage_Action shopNum1_MemberMessage_Action = (ShopNum1_MemberMessage_Action)LogicFactory.CreateShopNum1_MemberMessage_Action();
			ShopNum1_MemberMessage shopNum1_MemberMessage = new ShopNum1_MemberMessage();
			shopNum1_MemberMessage.SendLoginID = this.MemLoginID;
			if (this.htmlInputText_1.Value.IndexOf(',') != -1)
			{
				string[] array = this.htmlInputText_1.Value.Split(new char[]
				{
					','
				});
				for (int i = 0; i < array.Length; i++)
				{
					shopNum1_MemberMessage.ReLoginID = array[i].ToString();
					shopNum1_MemberMessage.Content = this.htmlTextArea_0.Value;
					shopNum1_MemberMessage.Title = this.htmlInputText_0.Value;
					shopNum1_MemberMessage_Action.Add_MemberMsg(shopNum1_MemberMessage);
				}
			}
			else
			{
				shopNum1_MemberMessage.ReLoginID = this.htmlInputText_1.Value;
				shopNum1_MemberMessage.Content = this.htmlTextArea_0.Value;
				shopNum1_MemberMessage.Title = this.htmlInputText_0.Value;
				shopNum1_MemberMessage_Action.Add_MemberMsg(shopNum1_MemberMessage);
			}
			MessageBox.Show("发送成功！");
			this.htmlTextArea_0.Value = "";
			this.htmlInputText_0.Value = "";
		}
	}
}
