using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.IO;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_AdvertisementList : BaseShopWebControl
	{
		private string string_0 = "S_AdvertisementList.ascx";
		private HtmlSelect htmlSelect_0;
		private Button button_0;
		private Repeater repeater_0;
		private HtmlInputHidden htmlInputHidden_0;
		private HtmlInputText htmlInputText_0;
		private HtmlInputHidden htmlInputHidden_1;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		public string SetPath
		{
			get;
			set;
		}
		public string OpenTime
		{
			get;
			set;
		}
		public string shopid
		{
			get;
			set;
		}
		public S_AdvertisementList()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("rep_AddvertismentList");
			this.button_0 = (Button)skin.FindControl("ButtonSearch");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.htmlSelect_0 = (HtmlSelect)skin.FindControl("sel_File");
			this.htmlInputHidden_0 = (HtmlInputHidden)skin.FindControl("hid_Seletfile");
			this.htmlInputHidden_1 = (HtmlInputHidden)skin.FindControl("hid_SeletfileValue");
			this.htmlInputText_0 = (HtmlInputText)skin.FindControl("txt_FileName");
			Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)LogicFactory.CreateShop_ShopInfo_Action();
			DataTable memLoginInfo = shop_ShopInfo_Action.GetMemLoginInfo(this.MemLoginID);
			this.shopid = memLoginInfo.Rows[0]["ShopID"].ToString();
			this.OpenTime = DateTime.Parse(memLoginInfo.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
			this.SetPath = string.Concat(new string[]
			{
				"~/Shop/Shop/",
				this.OpenTime.Replace("-", "/"),
				"/shop",
				this.shopid,
				"/Themes/Skin_Default/Advertisement.xml"
			});
			this.GetFileList();
			this.method_0();
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			this.method_0();
		}
		private void method_0()
		{
			Shop_Advertisement_Action shop_Advertisement_Action = (Shop_Advertisement_Action)LogicFactory.CreateShop_Advertisement_Action();
			shop_Advertisement_Action.StrPath = this.SetPath;
			DataTable dataSource = shop_Advertisement_Action.Search(Operator.FilterString(this.htmlInputText_0.Value), this.htmlInputHidden_1.Value);
			this.repeater_0.DataSource = dataSource;
			this.repeater_0.DataBind();
		}
		protected void GetFileList()
		{
			string[] files = Directory.GetFiles(HttpContext.Current.Server.MapPath(string.Concat(new string[]
			{
				"~/shop/shop/",
				this.OpenTime.Replace("-", "/"),
				"/shop",
				this.shopid,
				"/Themes/Skin_Default/"
			})), "*.aspx");
			this.htmlSelect_0.Items.Clear();
			ListItem listItem = new ListItem();
			listItem.Text = "-全部-";
			listItem.Value = "-1";
			this.htmlSelect_0.Items.Add(listItem);
			for (int i = 0; i < files.Length; i++)
			{
				this.htmlSelect_0.Items.Add(new ListItem
				{
					Text = files[i].Substring(files[i].LastIndexOf('\\') + 1),
					Value = files[i].Substring(files[i].LastIndexOf('\\') + 1)
				});
			}
		}
	}
}
