using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Control;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
public class Main_Admin_Global_Global_CacheManage : PageBase, IRequiresSessionState
{
	protected Button ResetAllCache;
	protected Button ButtonShopSetting;
	protected Button ButtonShopCatergory;
	protected Button ButtonShopShow;
	protected Button ButtonProductCategory;
	protected Button ButtonProductShow;
	protected Button ButtonSupplyDemand;
	protected Button ButtonSupplyShow;
	protected Button ButtonCategory;
	protected Button ButtonCategoryShow;
	protected Button ButtonArticleCategory;
	protected Button ButtonArticleShow;
	protected Button ButtonShopFront;
	protected Button ButtonShopBack;
	protected Button ButtonShopMeto;
	protected Button ButtonSiteMeto;
	protected Button ButtonOnlineMember;
	protected Button ButtonOnlineShop;
	protected Button ButtonSiteImg;
	protected Button ButtonSiteConfig;
	protected HtmlForm Form1;
	protected DefaultProfile Profile
	{
		get
		{
			return (DefaultProfile)this.Context.Profile;
		}
	}
	protected HttpApplication ApplicationInstance
	{
		get
		{
			return this.Context.ApplicationInstance;
		}
	}
	private void method_5(object sender, EventArgs e)
	{
		base.CheckLogin();
		if (this.Page.IsPostBack)
		{
		}
	}
	protected override void OnInit(EventArgs eventArgs_0)
	{
		base.OnInit(eventArgs_0);
		this.ResetAllCache.Click += new EventHandler(this.ResetAllCache_Click);
		this.ButtonShopSetting.Click += new EventHandler(this.ButtonShopSetting_Click);
		this.ButtonShopCatergory.Click += new EventHandler(this.ButtonShopCatergory_Click);
		this.ButtonShopShow.Click += new EventHandler(this.ButtonShopShow_Click);
		this.ButtonProductCategory.Click += new EventHandler(this.ButtonProductCategory_Click);
		this.ButtonProductShow.Click += new EventHandler(this.ButtonProductShow_Click);
		this.ButtonSupplyDemand.Click += new EventHandler(this.ButtonSupplyDemand_Click);
		this.ButtonSupplyShow.Click += new EventHandler(this.ButtonSupplyShow_Click);
		this.ButtonCategory.Click += new EventHandler(this.ButtonCategory_Click);
		this.ButtonCategoryShow.Click += new EventHandler(this.ButtonCategoryShow_Click);
		this.ButtonArticleCategory.Click += new EventHandler(this.ButtonArticleCategory_Click);
		this.ButtonArticleShow.Click += new EventHandler(this.ButtonArticleShow_Click);
		this.ButtonShopFront.Click += new EventHandler(this.ButtonShopFront_Click);
		this.ButtonShopBack.Click += new EventHandler(this.ButtonShopBack_Click);
		this.ButtonShopMeto.Click += new EventHandler(this.ButtonShopMeto_Click);
		this.ButtonSiteMeto.Click += new EventHandler(this.ButtonSiteMeto_Click);
		this.ButtonOnlineMember.Click += new EventHandler(this.ButtonOnlineMember_Click);
		this.ButtonOnlineShop.Click += new EventHandler(this.ButtonOnlineShop_Click);
		this.ButtonSiteImg.Click += new EventHandler(this.ButtonSiteImg_Click);
		this.ButtonSiteConfig.Click += new EventHandler(this.ButtonSiteConfig_Click);
	}
	private void ResetAllCache_Click(object sender, EventArgs e)
	{
		this.method_6();
		Utils.RestartIISProcess();
	}
	private void ButtonSiteConfig_Click(object sender, EventArgs e)
	{
		this.method_6();
		Utils.RestartIISProcess();
	}
	private void ButtonSiteImg_Click(object sender, EventArgs e)
	{
		this.method_6();
	}
	private void ButtonOnlineShop_Click(object sender, EventArgs e)
	{
		this.method_6();
	}
	private void ButtonOnlineMember_Click(object sender, EventArgs e)
	{
		this.method_6();
	}
	private void ButtonSiteMeto_Click(object sender, EventArgs e)
	{
		ShopNum1_ExtendSiteMota_Action.ResetMeto();
		this.method_6();
	}
	private void ButtonShopMeto_Click(object sender, EventArgs e)
	{
		this.method_6();
	}
	private void ButtonShopBack_Click(object sender, EventArgs e)
	{
		this.method_6();
	}
	private void ButtonShopFront_Click(object sender, EventArgs e)
	{
		this.method_6();
	}
	private void ButtonArticleShow_Click(object sender, EventArgs e)
	{
		this.method_6();
	}
	private void ButtonArticleCategory_Click(object sender, EventArgs e)
	{
		ShopNum1_ArticleCategory_Action.ArticleCategoryTable = null;
		this.method_6();
	}
	private void ButtonCategoryShow_Click(object sender, EventArgs e)
	{
		ShopNum1_CategoryChecked_Action.CategoryTable = null;
		this.method_6();
	}
	private void ButtonCategory_Click(object sender, EventArgs e)
	{
		this.method_6();
	}
	private void ButtonSupplyShow_Click(object sender, EventArgs e)
	{
		this.method_6();
	}
	private void ButtonSupplyDemand_Click(object sender, EventArgs e)
	{
		ShopNum1_SupplyDemandCheck_Action.SupplyDemandCategoryTable = null;
		this.method_6();
	}
	private void ButtonProductShow_Click(object sender, EventArgs e)
	{
		this.method_6();
	}
	private void ButtonProductCategory_Click(object sender, EventArgs e)
	{
		this.method_6();
	}
	private void ButtonShopShow_Click(object sender, EventArgs e)
	{
		this.method_6();
	}
	private void ButtonShopCatergory_Click(object sender, EventArgs e)
	{
		this.method_6();
	}
	private void ButtonShopSetting_Click(object sender, EventArgs e)
	{
		ShopSettings.ResetShopSetting();
		this.method_6();
	}
	private void method_6()
	{
		base.RegisterStartupScript("PAGE", "window.location.href='global_cachemanage.aspx';");
	}
}
