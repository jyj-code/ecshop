using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_EnsureApplyRecordList : BaseShopWebControl
	{
		private string string_0 = "S_EnsureApplyRecordList.ascx";
		private Repeater repeater_0;
		private Repeater repeater_1;
		public S_EnsureApplyRecordList()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("Rep_EnsureApply");
			this.repeater_1 = (Repeater)skin.FindControl("Rep_EnsureNoApply");
			this.repeater_1.ItemCommand += new RepeaterCommandEventHandler(this.repeater_1_ItemCommand);
			this.method_0();
			this.method_1();
		}
		private void repeater_1_ItemCommand(object sender, RepeaterCommandEventArgs e)
		{
			Button arg_15_0 = (Button)e.Item.FindControl("btn_Open");
			HtmlInputHidden htmlInputHidden = (HtmlInputHidden)e.Item.FindControl("hid_Open");
			HtmlInputHidden htmlInputHidden2 = (HtmlInputHidden)e.Item.FindControl("hid_Type");
			HtmlInputHidden htmlInputHidden3 = (HtmlInputHidden)e.Item.FindControl("hid_Guid");
			if (e.CommandName == "open")
			{
				if (htmlInputHidden2.Value == "-1")
				{
					this.Page.Response.Redirect("S_EnsureApplyRecordOperate.aspx?ID=" + htmlInputHidden.Value);
				}
				else if (htmlInputHidden2.Value == "0")
				{
					MessageBox.Show("等待审核");
				}
				else if (htmlInputHidden2.Value == "1")
				{
					this.Page.Response.Redirect(string.Concat(new string[]
					{
						"S_EnsureApplyRecordOperate.aspx?ID=",
						htmlInputHidden.Value,
						"&type=",
						Encryption.GetMd5Hash(htmlInputHidden2.Value),
						"&guid=",
						htmlInputHidden3.Value
					}));
				}
			}
		}
		private void method_0()
		{
			Shop_Ensure_Action shop_Ensure_Action = (Shop_Ensure_Action)LogicFactory.CreateShop_Ensure_Action();
			DataTable shopapplyEnsure = shop_Ensure_Action.GetShopapplyEnsure(this.MemLoginID);
			this.repeater_0.DataSource = shopapplyEnsure;
			this.repeater_0.DataBind();
		}
		private void method_1()
		{
			Shop_Ensure_Action shop_Ensure_Action = (Shop_Ensure_Action)LogicFactory.CreateShop_Ensure_Action();
			DataTable shopNotApplyEnsure = shop_Ensure_Action.GetShopNotApplyEnsure(this.MemLoginID);
			this.repeater_1.DataSource = shopNotApplyEnsure;
			this.repeater_1.DataBind();
		}
		public static string GetImg(object object_0)
		{
			string[] array = object_0.ToString().Split(new char[]
			{
				'~'
			});
			return array[1].ToString();
		}
		public static string GetStatus(object object_0, object obj2, object objid, object objMemID, object objtype)
		{
			string text = string.Empty;
			string text2 = string.Empty;
			if (object_0.ToString() == "0" && obj2.ToString() == "1")
			{
				text = "等待审核";
				text2 = "0";
			}
			if (object_0.ToString() == "0" && obj2.ToString() == "0")
			{
				string ensureid = objid.ToString();
				string shopid = objMemID.ToString();
				Shop_Ensure_Action shop_Ensure_Action = (Shop_Ensure_Action)LogicFactory.CreateShop_Ensure_Action();
				if (shop_Ensure_Action.GetCheckedShopEnsureList(ensureid, shopid).Rows.Count > 0)
				{
					text = "支付";
					text2 = "1";
				}
				else
				{
					text = "申请开通此服务";
					text2 = "-1";
				}
			}
			string result;
			if (objtype.ToString() == "0")
			{
				result = text;
			}
			else
			{
				result = text2;
			}
			return result;
		}
	}
}
