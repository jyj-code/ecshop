using ShopNum1.Common;
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
	public class S_ProductMessageBoardReply : BaseShopWebControl
	{
		private string string_0 = "S_ProductMessageBoardReply.ascx";
		private Label label_0;
		private Label label_1;
		private Label label_2;
		private Label label_3;
		private HtmlTextArea htmlTextArea_0;
		private Label label_4;
		private Label label_5;
		private TextBox textBox_0;
		private Button button_0;
		private Button button_1;
		private string string_1 = string.Empty;
		public S_ProductMessageBoardReply()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.label_0 = (Label)skin.FindControl("LabelProductGuid");
			this.label_1 = (Label)skin.FindControl("LabelMemLoginID");
			this.label_2 = (Label)skin.FindControl("LabelIPAddress");
			this.label_3 = (Label)skin.FindControl("LabelSendTime");
			this.label_5 = (Label)skin.FindControl("LabelIsReply");
			this.htmlTextArea_0 = (HtmlTextArea)skin.FindControl("txtContent");
			this.label_4 = (Label)skin.FindControl("LabelReplyTime");
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
			this.Page.Response.Redirect("S_ProductMessageBoardList.aspx");
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			this.Edit();
		}
		public void Edit()
		{
			Shop_ProductConsult_Action shop_ProductConsult_Action = (Shop_ProductConsult_Action)LogicFactory.CreateShop_ProductConsult_Action();
			int num = shop_ProductConsult_Action.MessageBoardReply(new ShopNum1_ShopProductConsult
			{
				Guid = new Guid(this.string_1),
				ReplyTime = new DateTime?(DateTime.Now),
				ReplyContent = this.textBox_0.Text.Trim()
			});
			if (num > 0)
			{
				this.Page.Response.Redirect("S_ProductMessageBoardList.aspx");
			}
		}
		public void GetEditInfo()
		{
			try
			{
				Shop_ProductConsult_Action shop_ProductConsult_Action = (Shop_ProductConsult_Action)LogicFactory.CreateShop_ProductConsult_Action();
				DataTable dataTable = shop_ProductConsult_Action.SearchByGuid("'" + this.string_1 + "'");
				if (dataTable.Rows.Count > 0)
				{
					this.label_0.Text = dataTable.Rows[0]["Name"].ToString();
					this.label_1.Text = dataTable.Rows[0]["MemLoginID"].ToString();
					this.label_2.Text = dataTable.Rows[0]["IPAddress"].ToString();
					this.label_3.Text = dataTable.Rows[0]["SendTime"].ToString();
					this.htmlTextArea_0.Value = dataTable.Rows[0]["Content"].ToString();
					this.label_4.Text = dataTable.Rows[0]["ReplyTime"].ToString();
					if (dataTable.Rows[0]["IsReply"].ToString() == "0")
					{
						this.label_5.Text = "未回复";
					}
					else
					{
						this.label_5.Text = "已回复";
						this.button_0.Visible = false;
						this.textBox_0.ReadOnly = true;
					}
					this.textBox_0.Text = dataTable.Rows[0]["ReplyContent"].ToString();
				}
				else
				{
					this.button_0.Visible = false;
					this.button_1.Visible = false;
					this.label_0.Text = "商品已下架";
				}
			}
			catch (Exception ex)
			{
				this.Page.Response.Write(ex.Message);
			}
		}
	}
}
