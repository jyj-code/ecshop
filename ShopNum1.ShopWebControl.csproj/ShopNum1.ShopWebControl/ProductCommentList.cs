using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopWebControl
{
	[ParseChildren(true)]
	public class ProductCommentList : BaseWebControl
	{
		private string string_0 = "ProductCommentList.ascx";
		private Repeater repeater_0;
		private Repeater repeater_1;
		private Label label_0;
		private HyperLink hyperLink_0;
		private HyperLink hyperLink_1;
		private HyperLink hyperLink_2;
		private HyperLink hyperLink_3;
		private Literal literal_0;
		private Label label_1;
		private Label label_2;
		private Label label_3;
		private Label label_4;
		private Label label_5;
		private HtmlInputHidden htmlInputHidden_0;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		public string Type
		{
			get;
			set;
		}
		public string ProductGuid
		{
			get;
			set;
		}
		public string MemLoginID
		{
			get;
			set;
		}
		public ProductCommentList()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.label_1 = (Label)skin.FindControl("lblGoodCount");
			this.label_2 = (Label)skin.FindControl("lblMiddelCount");
			this.label_3 = (Label)skin.FindControl("lblBadCount");
			this.label_4 = (Label)skin.FindControl("lblTotal");
			this.label_5 = (Label)skin.FindControl("lblContinue");
			this.hyperLink_0 = (HyperLink)skin.FindControl("lnkPrev");
			this.hyperLink_1 = (HyperLink)skin.FindControl("lnkFirst");
			this.hyperLink_2 = (HyperLink)skin.FindControl("lnkNext");
			this.hyperLink_3 = (HyperLink)skin.FindControl("lnkLast");
			this.label_0 = (Label)skin.FindControl("LabelPageMessage");
			this.literal_0 = (Literal)skin.FindControl("lnkTo");
			this.htmlInputHidden_0 = (HtmlInputHidden)skin.FindControl("hidType");
			this.htmlInputHidden_0.Value = this.Type;
			string memloginId = (this.Page.Request.QueryString["ShopID"] == null) ? "0" : this.Page.Request.QueryString["ShopID"].ToString();
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = new ShopNum1_ShopInfoList_Action();
			this.MemLoginID = shopNum1_ShopInfoList_Action.GetShopMemLoginIdByShopID(memloginId).ToString();
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterShow");
			this.ProductGuid = ((ShopNum1.Common.Common.ReqStr("guid") == "") ? "0" : ShopNum1.Common.Common.ReqStr("guid"));
			this.repeater_1 = (Repeater)skin.FindControl("RepeaterStat");
			if (!this.Page.IsPostBack)
			{
				this.method_0();
			}
		}
		private void method_0()
		{
			string value = ShopSettings.GetValue("ProductCommentPageCount");
			try
			{
				int.Parse(value);
			}
			catch
			{
			}
			Shop_ProductComment_Action shop_ProductComment_Action = (Shop_ProductComment_Action)LogicFactory.CreateShop_ProductComment_Action();
			DataSet dataSet = shop_ProductComment_Action.ProductCommentListByGuidAndMemLoginID(this.ProductGuid, this.MemLoginID, this.Type);
			if (dataSet.Tables[1].Rows.Count > 0)
			{
				this.repeater_1.DataSource = dataSet.Tables[0];
				this.repeater_1.DataBind();
				if (dataSet.Tables[1].Rows.Count > 0)
				{
					string text = dataSet.Tables[1].Rows[0]["py"].ToString();
					this.label_4.Text = text.Split(new char[]
					{
						'-'
					})[0];
					this.label_1.Text = text.Split(new char[]
					{
						'-'
					})[1];
					this.label_2.Text = text.Split(new char[]
					{
						'-'
					})[2];
					this.label_3.Text = text.Split(new char[]
					{
						'-'
					})[3];
					this.label_5.Text = text.Split(new char[]
					{
						'-'
					})[4];
				}
			}
		}
		public static string SetNoNull(object value)
		{
			string result;
			if (value.ToString() == "")
			{
				result = "0";
			}
			else
			{
				result = value.ToString();
			}
			return result;
		}
	}
}
