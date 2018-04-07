using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_ShowShopPhoto : BaseMemberWebControl
	{
		private string string_0 = "S_ShowShopPhoto.ascx";
		private Button button_0;
		private HtmlInputText htmlInputText_0;
		private Repeater repeater_0;
		private HtmlGenericControl htmlGenericControl_0;
		private DropDownList dropDownList_0;
		private HtmlInputHidden htmlInputHidden_0;
		private HtmlInputHidden htmlInputHidden_1;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		public string pageid
		{
			get;
			set;
		}
		public string PageSize
		{
			get;
			set;
		}
		public S_ShowShopPhoto()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("pageDiv");
			this.pageid = ((ShopNum1.Common.Common.ReqStr("PageID") == "") ? "1" : ShopNum1.Common.Common.ReqStr("PageID"));
			this.button_0 = (Button)skin.FindControl("ButtonChaxData");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.htmlInputText_0 = (HtmlInputText)skin.FindControl("txtImageName");
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterShow");
			this.dropDownList_0 = (DropDownList)skin.FindControl("DropDownListType");
			this.htmlInputHidden_0 = (HtmlInputHidden)skin.FindControl("hidShopId");
			this.htmlInputHidden_1 = (HtmlInputHidden)skin.FindControl("hidImgCategoryID");
			this.BindImageCategory();
			this.method_0();
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			this.method_0();
		}
		private void method_0()
		{
			Shop_Image_Action shop_Image_Action = (Shop_Image_Action)LogicFactory.CreateShop_Image_Action();
			string text = string.Empty;
			string text2 = HttpUtility.HtmlDecode(ShopNum1.Common.Common.ReqStr("imgname"));
			if (!string.IsNullOrEmpty(text2.Trim()))
			{
				text = text + "  AND  Name  LIKE   '%" + text2 + "%'   ";
				this.htmlInputText_0.Value = text2;
			}
			if (ShopNum1.Common.Common.ReqStr("st") != "")
			{
				text = text + "  AND  ImageCategoryID  ='" + ShopNum1.Common.Common.ReqStr("st") + "'   ";
			}
			else
			{
				text = text + "  AND  ImageCategoryID  ='" + this.htmlInputHidden_1.Value + "'   ";
			}
			CommonPageModel commonPageModel = new CommonPageModel();
			commonPageModel.Condition = string.Concat(new string[]
			{
				"  AND   1=1   ",
				text,
				"     AND  CreateUser='",
				this.MemLoginID,
				"'  "
			});
			commonPageModel.Currentpage = this.pageid.ToString();
			commonPageModel.Resultnum = "0";
			commonPageModel.PageSize = this.PageSize.ToString();
			DataTable dataTable = shop_Image_Action.Select_List(commonPageModel);
			PageList1 pageList = new PageList1();
			pageList.PageSize = Convert.ToInt32(this.PageSize);
			pageList.PageID = Convert.ToInt32(this.pageid.ToString());
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				pageList.RecordCount = Convert.ToInt32(dataTable.Rows[0][0]);
			}
			else
			{
				pageList.RecordCount = 0;
			}
			PageListBll pageListBll = new PageListBll("Shop/ShopAdmin/S_ShowShopPhoto.aspx", true);
			this.htmlGenericControl_0.InnerHtml = pageListBll.GetPageListNew(pageList);
			commonPageModel.Resultnum = "1";
			DataTable dataTable2 = shop_Image_Action.Select_List(commonPageModel);
			this.repeater_0.DataSource = dataTable2.DefaultView;
			this.repeater_0.DataBind();
		}
		public void BindImageCategory()
		{
			Shop_ImageCategory_Action shop_ImageCategory_Action = (Shop_ImageCategory_Action)LogicFactory.CreateShop_ImageCategory_Action();
			DataTable dataTable = shop_ImageCategory_Action.dt_Album_Import(this.MemLoginID);
			this.htmlInputHidden_0.Value = this.MemLoginID;
			this.dropDownList_0.Items.Clear();
			new ListItem();
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				foreach (DataRow dataRow in dataTable.Rows)
				{
					string a = ShopNum1.Common.Common.ReqStr("st");
					ListItem listItem = new ListItem();
					if (a == dataRow["ID"].ToString())
					{
						listItem.Selected = true;
					}
					listItem.Text = dataRow["Name"].ToString();
					listItem.Value = dataRow["ID"].ToString();
					this.dropDownList_0.Items.Add(listItem);
				}
				if (ShopNum1.Common.Common.ReqStr("st") == "")
				{
					this.htmlInputHidden_1.Value = dataTable.Rows[0]["ID"].ToString();
				}
				else
				{
					this.htmlInputHidden_1.Value = ShopNum1.Common.Common.ReqStr("st");
				}
			}
		}
	}
}
