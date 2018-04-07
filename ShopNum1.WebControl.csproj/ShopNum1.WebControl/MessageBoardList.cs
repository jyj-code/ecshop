using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class MessageBoardList : BaseWebControl
	{
		private string string_0 = "MessageBoardList.ascx";
		private TextBox textBox_0;
		private TextBox textBox_1;
		private Button button_0;
		public MessageBoardList()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.textBox_0 = (skin.FindControl("txtMobile") as TextBox);
			this.textBox_1 = (skin.FindControl("txtRemark") as TextBox);
			this.button_0 = (skin.FindControl("btnSubmit") as Button);
			this.button_0.Click += new EventHandler(this.btnSubmit_Click);
		}
		protected void btnSubmit_Click(object sender, EventArgs e)
		{
			string text = string.Empty;
			if (this.Page.Request.Cookies["MemberLoginCookie"] != null)
			{
				HttpCookie cookie = this.Page.Request.Cookies["MemberLoginCookie"];
				HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
				text = httpCookie.Values["MemLoginID"].ToString();
			}
			ShopNum1_MessageBoard shopNum1_MessageBoard = new ShopNum1_MessageBoard();
			shopNum1_MessageBoard.Guid = Guid.NewGuid();
			shopNum1_MessageBoard.MessageType = "";
			shopNum1_MessageBoard.MemLoginID = text;
			shopNum1_MessageBoard.ReplyUser = this.textBox_0.Text.Trim();
			shopNum1_MessageBoard.Title = "建议反馈";
			shopNum1_MessageBoard.Content = Operator.FilterString(this.textBox_1.Text.Trim());
			shopNum1_MessageBoard.ModifyUser = text;
			shopNum1_MessageBoard.ModifyTime = DateTime.Now;
			ShopNum1_MessageBoard_Action shopNum1_MessageBoard_Action = (ShopNum1_MessageBoard_Action)LogicFactory.CreateShopNum1_MessageBoard_Action();
			shopNum1_MessageBoard_Action.AddMemberMessageBoard(shopNum1_MessageBoard);
		}
	}
}
