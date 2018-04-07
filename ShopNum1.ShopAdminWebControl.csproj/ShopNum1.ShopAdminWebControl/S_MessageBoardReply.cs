using ShopNum1.Common;
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
	public class S_MessageBoardReply : BaseShopWebControl
	{
		private string string_0 = "S_MessageBoardReply.ascx";
		private Localize localize_0;
		private Localize localize_1;
		private Localize localize_2;
		private Localize localize_3;
		private Localize localize_4;
		private Localize localize_5;
		private Localize localize_6;
		private Localize localize_7;
		private TextBox textBox_0;
		private Button button_0;
		private Button button_1;
		private string string_1 = string.Empty;
		public S_MessageBoardReply()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.localize_0 = (Localize)skin.FindControl("LocalizeType");
			this.localize_1 = (Localize)skin.FindControl("LocalizeMemLoginID");
			this.localize_2 = (Localize)skin.FindControl("LocalizeTitle");
			this.localize_3 = (Localize)skin.FindControl("LocalizeSendTime");
			this.localize_4 = (Localize)skin.FindControl("LocalizeReplyTime");
			this.localize_5 = (Localize)skin.FindControl("LocalizeIsReply");
			this.localize_6 = (Localize)skin.FindControl("LocalizeIsShow");
			this.localize_7 = (Localize)skin.FindControl("LocalizeContent");
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxReplyContent");
			this.button_0 = (Button)skin.FindControl("btn_OK");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.button_1 = (Button)skin.FindControl("btn_Back");
			this.button_1.Click += new EventHandler(this.button_1_Click);
			this.string_1 = ((ShopNum1.Common.Common.ReqStr("guid") == "") ? "0" : ShopNum1.Common.Common.ReqStr("Guid"));
			if (this.string_1 != "0")
			{
				this.GetEditInfo();
			}
		}
		private void button_1_Click(object sender, EventArgs e)
		{
			this.Page.Response.Redirect("S_MessageBoardList.aspx");
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			this.Edit();
		}
		public void Edit()
		{
			ShopNum1_Shop_MessageBoard shopNum1_Shop_MessageBoard = new ShopNum1_Shop_MessageBoard();
			shopNum1_Shop_MessageBoard.Guid = new Guid(this.string_1);
			shopNum1_Shop_MessageBoard.ReplyTime = new DateTime?(DateTime.Now);
			shopNum1_Shop_MessageBoard.ReplyContent = this.textBox_0.Text;
			Shop_MessageBoard_Action shop_MessageBoard_Action = (Shop_MessageBoard_Action)LogicFactory.CreateShop_MessageBoard_Action();
			int num = shop_MessageBoard_Action.MessageBoardReply(shopNum1_Shop_MessageBoard);
			if (num > 0)
			{
				this.Page.Response.Redirect("S_MessageBoardList.aspx");
			}
		}
		public void GetEditInfo()
		{
			Shop_MessageBoard_Action shop_MessageBoard_Action = (Shop_MessageBoard_Action)LogicFactory.CreateShop_MessageBoard_Action();
			DataTable dataTable = shop_MessageBoard_Action.SearchMessageBoard(this.string_1);
			this.localize_0.Text = this.IsType(dataTable.Rows[0]["MessageType"].ToString());
			this.localize_1.Text = dataTable.Rows[0]["MemLoginID"].ToString();
			this.localize_2.Text = dataTable.Rows[0]["Title"].ToString();
			this.localize_3.Text = dataTable.Rows[0]["SendTime"].ToString();
			this.localize_4.Text = dataTable.Rows[0]["ReplyTime"].ToString();
			this.localize_7.Text = dataTable.Rows[0]["Content"].ToString();
			this.textBox_0.Text = dataTable.Rows[0]["ReplyContent"].ToString();
			if (dataTable.Rows[0]["IsReply"].ToString() == "0")
			{
				this.localize_5.Text = "未回复";
			}
			else
			{
				this.localize_5.Text = "已回复";
			}
			if (dataTable.Rows[0]["IsShow"].ToString() == "0")
			{
				this.localize_6.Text = "不显示";
			}
			else
			{
				this.localize_6.Text = "显示";
			}
			if (dataTable.Rows[0]["IsReply"].ToString() == "1")
			{
				this.textBox_0.ReadOnly = true;
				this.button_0.Enabled = false;
			}
		}
		public string IsType(object object_0)
		{
			string text = object_0.ToString();
			string text2 = text;
			string result;
			if (text2 != null)
			{
				if (text2 == "0")
				{
					result = "询问";
					return result;
				}
				if (text2 == "1")
				{
					result = "求购";
					return result;
				}
				if (text2 == "2")
				{
					result = "售后";
					return result;
				}
				if (text2 == "3")
				{
					result = "其它";
					return result;
				}
			}
			result = "其它";
			return result;
		}
	}
}
