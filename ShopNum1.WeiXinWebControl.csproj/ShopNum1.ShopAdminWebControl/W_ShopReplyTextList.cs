using ShopNum1.MultiBaseWebControl;
using ShopNum1.WeiXinBusinessLogic;
using ShopNum1.WeiXinInterface;
using System;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class W_ShopReplyTextList : BaseShopWebControl
	{
		private string string_0 = "W_ShopReplyTextList.ascx";
		private Repeater repeater_0;
		public W_ShopReplyTextList()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("rep_rule");
			this.method_0();
		}
		private void method_0()
		{
			IShopNum1_Weixin_ReplyRule_Active shopNum1_Weixin_ReplyRule_Active = new ShopNum1_Weixin_ReplyRule_Active();
			DataSet dataSet = shopNum1_Weixin_ReplyRule_Active.SelectReplyRule(this.MemLoginID, 0);
			if (dataSet.Tables.Count != 0)
			{
				DataTable dataTable = dataSet.Tables[0];
				dataTable.Columns.Add("keyword", typeof(string));
				dataTable.Columns.Add("content", typeof(string));
				foreach (DataRow dataRow in dataTable.Rows)
				{
					DataRow[] array = dataSet.Tables[1].Select(string.Format("ruleid = '{0}'", dataRow["ID"].ToString()));
					DataRow[] array2 = dataSet.Tables[2].Select(string.Format("ruleid = '{0}'", dataRow["ID"].ToString()));
					StringBuilder stringBuilder = new StringBuilder();
					DataRow[] array3 = array;
					for (int i = 0; i < array3.Length; i++)
					{
						DataRow dataRow2 = array3[i];
						stringBuilder.AppendFormat("{0} ", dataRow2["KeyWord"].ToString());
					}
					string text = (array2.Length != 0) ? array2[0]["RepMsgContent"].ToString() : string.Empty;
					if (text.Length > 20)
					{
						text = text.Substring(0, 20) + "...";
					}
					string text2 = stringBuilder.ToString().Trim();
					dataRow["keyword"] = ((text2.Length > 8) ? (text2.Substring(0, 8) + "...") : text2);
					dataRow["content"] = ((text.Length > 12) ? (text.Substring(0, 12) + "...") : text);
				}
				this.repeater_0.DataSource = dataTable;
				this.repeater_0.DataBind();
			}
		}
	}
}
