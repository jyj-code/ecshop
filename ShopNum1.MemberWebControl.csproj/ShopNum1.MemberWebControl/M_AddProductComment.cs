using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.MemberWebControl
{
	[ParseChildren(true)]
	public class M_AddProductComment : BaseMemberWebControl
	{
		private string string_0 = "M_AddProductComment.ascx";
		public static DataTable dt_Continue = null;
		private HtmlInputHidden htmlInputHidden_0;
		private Button button_0;
		private HtmlTextArea htmlTextArea_0;
		private HtmlInputHidden htmlInputHidden_1;
		private Shop_ProductComment_Action shop_ProductComment_Action_0 = (Shop_ProductComment_Action)LogicFactory.CreateShop_ProductComment_Action();
		public M_AddProductComment()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.button_0 = (Button)skin.FindControl("btnSave");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.htmlInputHidden_0 = (HtmlInputHidden)skin.FindControl("hidCommentC");
			this.htmlTextArea_0 = (HtmlTextArea)skin.FindControl("TextBoxComment");
			this.htmlInputHidden_1 = (HtmlInputHidden)skin.FindControl("hidPGuid");
			if (!this.Page.IsPostBack)
			{
				this.method_0();
			}
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			string[] array = (this.htmlInputHidden_0.Value + ",").Split(new char[]
			{
				','
			});
			string[] array2 = (this.htmlInputHidden_1.Value + ",").Split(new char[]
			{
				','
			});
			for (int i = 0; i < array.Length - 1; i++)
			{
				if (!(array[i] != "") || array[i].Length > 500)
				{
					return;
				}
				this.shop_ProductComment_Action_0.UpdateContinueComment(ShopNum1.Common.Common.ReqStr("orid"), this.MemLoginID, array[i], array2[i]);
			}
			MessageBox.Show("追加评论操作成功！");
			this.Page.Response.Redirect("m_index.aspx?tomurl=M_FeedBack.aspx");
		}
		private void method_0()
		{
			M_AddProductComment.dt_Continue = this.shop_ProductComment_Action_0.GetCommentDetail(ShopNum1.Common.Common.ReqStr("orid"), this.MemLoginID);
			if (M_AddProductComment.dt_Continue.Rows.Count == 0)
			{
				M_AddProductComment.dt_Continue = null;
			}
		}
	}
}
