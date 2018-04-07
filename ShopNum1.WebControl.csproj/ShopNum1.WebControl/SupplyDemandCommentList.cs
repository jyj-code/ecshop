using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class SupplyDemandCommentList : BaseWebControl
	{
		private Repeater repeater_0;
		private HtmlGenericControl htmlGenericControl_0;
		private Label label_0;
		private TextBox textBox_0;
		private Button button_0;
		private string string_0 = GetPageName.RetDomainUrl("SupplyDemandDetail");
		private string string_1 = "SupplyDemandCommentList.ascx";
		private int int_0;
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		[CompilerGenerated]
		private int int_1;
		public string Guid
		{
			get;
			set;
		}
		public int ShowCount
		{
			get;
			set;
		}
		public SupplyDemandCommentList()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_1;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("pageDiv");
			this.label_0 = (Label)skin.FindControl("LabelPageCount");
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxIndex");
			this.button_0 = (Button)skin.FindControl("ButtonSure");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.int_0 = 1;
			try
			{
				this.int_0 = int.Parse(this.Page.Request.QueryString["PageID"]);
			}
			catch
			{
				this.int_0 = 1;
			}
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			this.repeater_0.ItemDataBound += new RepeaterItemEventHandler(this.repeater_0_ItemDataBound);
			this.Guid = ((ShopNum1.Common.Common.ReqStr("guid") == "") ? "0" : ShopNum1.Common.Common.ReqStr("guid"));
			this.string_2 = ((ShopNum1.Common.Common.ReqStr("ordername") == "") ? "CreateTime" : ShopNum1.Common.Common.ReqStr("ordername"));
			this.BindData();
		}
		private void repeater_0_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				Image image = (Image)e.Item.FindControl("ImagePhoto");
				HiddenField hiddenField = (HiddenField)e.Item.FindControl("HiddenFieldCreateMerber");
				string nameById = ShopNum1.Common.Common.GetNameById("Photo", "ShopNum1_Member", "  AND MemLoginID='" + hiddenField.Value + "'");
				if (!string.IsNullOrEmpty(nameById))
				{
					image.ImageUrl = nameById;
				}
				else
				{
					image.ImageUrl = "/Main/Themes/Skin_Default/Images/arst.png";
				}
			}
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			this.textBox_0.Text.Trim();
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_0,
				"?guid=",
				this.Guid,
				"&ordername=",
				this.string_2
			}));
		}
		public void BindData()
		{
			PageList1 pageList = new PageList1();
			pageList.PageSize = this.ShowCount;
			pageList.PageID = this.int_0;
			ShopNum1_SupplyDemandComment_Action shopNum1_SupplyDemandComment_Action = (ShopNum1_SupplyDemandComment_Action)LogicFactory.CreateShopNum1_SupplyDemandComment_Action();
			DataSet supplyDemandCommentList = shopNum1_SupplyDemandComment_Action.GetSupplyDemandCommentList(this.ShowCount.ToString(), this.int_0.ToString(), this.Guid, this.string_2, "1");
			if (supplyDemandCommentList != null && supplyDemandCommentList.Tables[0].Rows.Count > 0)
			{
				pageList.RecordCount = Convert.ToInt32(supplyDemandCommentList.Tables[0].Rows[0][0]);
			}
			else
			{
				pageList.RecordCount = 0;
			}
			PageListBll pageListBll = new PageListBll("SupplyDemandDetail", true);
			pageListBll.ShowRecordCount = true;
			pageListBll.ShowPageCount = false;
			pageListBll.ShowPageIndex = false;
			pageListBll.ShowRecordCount = false;
			pageListBll.ShowNoRecordInfo = false;
			pageListBll.ShowNumListButton = true;
			pageListBll.PrevPageText = "<<上一页";
			pageListBll.NextPageText = "下一页>> ";
			this.textBox_0.Text = this.int_0.ToString();
			this.htmlGenericControl_0.InnerHtml = pageListBll.GetPageListVk(pageList);
			this.label_0.Text = pageList.PageCount.ToString();
			DataSet supplyDemandCommentList2 = shopNum1_SupplyDemandComment_Action.GetSupplyDemandCommentList(this.ShowCount.ToString(), this.int_0.ToString(), this.Guid, this.string_2, "0");
			if (supplyDemandCommentList2 != null && supplyDemandCommentList2.Tables[0].Rows.Count > 0)
			{
				this.repeater_0.DataSource = supplyDemandCommentList2.Tables[0];
				this.repeater_0.DataBind();
			}
		}
	}
}
