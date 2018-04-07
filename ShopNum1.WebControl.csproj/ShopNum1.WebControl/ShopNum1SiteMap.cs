using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class ShopNum1SiteMap : BaseWebControl
	{
		private string string_0 = "ShopNum1SiteMap.ascx";
		private SiteMapPath siteMapPath_0;
		public ShopNum1SiteMap()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.siteMapPath_0 = (SiteMapPath)skin.FindControl("siteMapPath");
			SiteMap.SiteMapResolve += new SiteMapResolveEventHandler(this.method_0);
			if (this.Page.IsPostBack)
			{
			}
		}
		private SiteMapNode method_0(object object_0, SiteMapResolveEventArgs siteMapResolveEventArgs_0)
		{
			SiteMapNode siteMapNode = null;
			if (SiteMap.CurrentNode != null)
			{
				siteMapNode = SiteMap.CurrentNode.Clone(true);
				SiteMapNodeCollection siteMapNodeCollection = new SiteMapNodeCollection();
				ShopNum1_SiteMap_Action shopNum1_SiteMap_Action = (ShopNum1_SiteMap_Action)LogicFactory.CreateShopNum1_SiteMap_Action();
				string guid = string.Empty;
				string title = string.Empty;
				if (SiteMap.CurrentNode.Url == Globals.ApplicationPath + "/GuidBuyList.aspx")
				{
					if (HttpContext.Current.Request.QueryString["guid"] != null)
					{
						guid = ((HttpContext.Current.Request.QueryString["guid"] == null) ? "0" : HttpContext.Current.Request.QueryString["guid"]);
						title = shopNum1_SiteMap_Action.Search("ShopNum1_GuidInfo", guid);
					}
					SiteMapNode siteMapNode2 = new SiteMapNode(siteMapResolveEventArgs_0.Provider, "newNode", "GuidBuyList.aspx", title);
					siteMapNode2.ParentNode = siteMapNode;
					siteMapNodeCollection.Add(siteMapNode2);
					siteMapNode.ChildNodes = siteMapNodeCollection;
					siteMapNode = siteMapNode2;
				}
				else if (SiteMap.CurrentNode.Url == Globals.ApplicationPath + "/OrganizBuyDetail.aspx")
				{
					if (HttpContext.Current.Request.QueryString["guid"] != null)
					{
						guid = ((HttpContext.Current.Request.QueryString["guid"] == null) ? "0" : HttpContext.Current.Request.QueryString["guid"]);
						title = shopNum1_SiteMap_Action.SearchOrganizBuyInfoName(guid);
					}
					SiteMapNode siteMapNode2 = new SiteMapNode(siteMapResolveEventArgs_0.Provider, "newNode", "OrganizBuyDetail.aspx", title);
					siteMapNode2.ParentNode = siteMapNode;
					SiteMapNode siteMapNode3 = siteMapNode;
					siteMapNode3.Url = Globals.ApplicationPath + "/OrganizBuyList.aspx";
					siteMapNodeCollection.Add(siteMapNode2);
					siteMapNode.ChildNodes = siteMapNodeCollection;
					siteMapNode = siteMapNode2;
				}
				else if (SiteMap.CurrentNode.Url == Globals.ApplicationPath + "/AuctionInfoDetail.aspx")
				{
					if (HttpContext.Current.Request.QueryString["guid"] != null)
					{
						guid = ((HttpContext.Current.Request.QueryString["guid"] == null) ? "0" : HttpContext.Current.Request.QueryString["guid"]);
						title = shopNum1_SiteMap_Action.Search("ShopNum1_AuctionInfo", guid);
					}
					SiteMapNode siteMapNode2 = new SiteMapNode(siteMapResolveEventArgs_0.Provider, "newNode", "AuctionInfoDetail.aspx", title);
					siteMapNode2.ParentNode = siteMapNode;
					SiteMapNode siteMapNode3 = siteMapNode;
					siteMapNode3.Url = Globals.ApplicationPath + "/AuctionInfoList.aspx";
					siteMapNodeCollection.Add(siteMapNode2);
					siteMapNode.ChildNodes = siteMapNodeCollection;
					siteMapNode = siteMapNode2;
				}
				else if (SiteMap.CurrentNode.Url == Globals.ApplicationPath + "/LongAuctionInfoDetail.aspx")
				{
					if (HttpContext.Current.Request.QueryString["guid"] != null)
					{
						guid = ((HttpContext.Current.Request.QueryString["guid"] == null) ? "0" : HttpContext.Current.Request.QueryString["guid"]);
						title = shopNum1_SiteMap_Action.Search("ShopNum1_LongAuctionInfo", guid);
					}
					SiteMapNode siteMapNode2 = new SiteMapNode(siteMapResolveEventArgs_0.Provider, "newNode", "LongAuctionInfoDetail.aspx", title);
					siteMapNode2.ParentNode = siteMapNode;
					SiteMapNode siteMapNode3 = siteMapNode;
					siteMapNode3.Url = Globals.ApplicationPath + "/LongAuctionInfoList.aspx";
					siteMapNodeCollection.Add(siteMapNode2);
					siteMapNode.ChildNodes = siteMapNodeCollection;
					siteMapNode = siteMapNode2;
				}
				else if (SiteMap.CurrentNode.Url == Globals.ApplicationPath + "/ArticleDetail.aspx")
				{
					if (HttpContext.Current.Request.QueryString["guid"] != null)
					{
						guid = ((HttpContext.Current.Request.QueryString["guid"] == null) ? "0" : HttpContext.Current.Request.QueryString["guid"]);
						title = shopNum1_SiteMap_Action.SearchTitle("ShopNum1_Article", guid);
					}
					SiteMapNode siteMapNode2 = new SiteMapNode(siteMapResolveEventArgs_0.Provider, "newNode", "ArticleDetail.aspx", title);
					siteMapNode2.ParentNode = siteMapNode;
					SiteMapNode siteMapNode3 = siteMapNode;
					siteMapNode3.Url = Globals.ApplicationPath + "/ArticleList.aspx";
					siteMapNodeCollection.Add(siteMapNode2);
					siteMapNode.ChildNodes = siteMapNodeCollection;
					siteMapNode = siteMapNode2;
				}
				else if (SiteMap.CurrentNode.Url == Globals.ApplicationPath + "/HelpList.aspx")
				{
					if (HttpContext.Current.Request.QueryString["guid"] != null)
					{
						guid = ((HttpContext.Current.Request.QueryString["guid"] == null) ? "0" : HttpContext.Current.Request.QueryString["guid"]);
						title = shopNum1_SiteMap_Action.SearchTitle("ShopNum1_Help", guid);
					}
					SiteMapNode siteMapNode2 = new SiteMapNode(siteMapResolveEventArgs_0.Provider, "newNode", "HelpList.aspx", title);
					siteMapNode2.ParentNode = siteMapNode;
					SiteMapNode siteMapNode3 = siteMapNode;
					siteMapNode3.Url = Globals.ApplicationPath + "/HelpList.aspx";
					siteMapNodeCollection.Add(siteMapNode2);
					siteMapNode.ChildNodes = siteMapNodeCollection;
					siteMapNode = siteMapNode2;
				}
				else if (SiteMap.CurrentNode.Url == Globals.ApplicationPath + "/AnnouncementDetail.aspx")
				{
					if (HttpContext.Current.Request.QueryString["guid"] != null)
					{
						guid = ((HttpContext.Current.Request.QueryString["guid"] == null) ? "0" : HttpContext.Current.Request.QueryString["guid"]);
						title = shopNum1_SiteMap_Action.SearchTitle("ShopNum1_Announcement", guid);
					}
					SiteMapNode siteMapNode2 = new SiteMapNode(siteMapResolveEventArgs_0.Provider, "newNode", "AnnouncementDetail.aspx", title);
					siteMapNode2.ParentNode = siteMapNode;
					SiteMapNode siteMapNode3 = siteMapNode;
					siteMapNode3.Url = Globals.ApplicationPath + "/AnnouncementDetail.aspx";
					siteMapNodeCollection.Add(siteMapNode2);
					siteMapNode.ChildNodes = siteMapNodeCollection;
					siteMapNode = siteMapNode2;
				}
				else if (SiteMap.CurrentNode.Url == Globals.ApplicationPath + "/ProductListCategory.aspx")
				{
					if (HttpContext.Current.Request.QueryString["id"] != null)
					{
						guid = ((HttpContext.Current.Request.QueryString["id"] == null) ? "0" : HttpContext.Current.Request.QueryString["id"]);
						title = shopNum1_SiteMap_Action.SearchNameByID("ShopNum1_ProductCategory", guid);
					}
					SiteMapNode siteMapNode2 = new SiteMapNode(siteMapResolveEventArgs_0.Provider, "newNode", "ProductListCategory.aspx", title);
					siteMapNode2.ParentNode = siteMapNode;
					SiteMapNode siteMapNode3 = siteMapNode;
					siteMapNode3.Url = Globals.ApplicationPath + "/ProductListCategory.aspx";
					siteMapNodeCollection.Add(siteMapNode2);
					siteMapNode.ChildNodes = siteMapNodeCollection;
					siteMapNode = siteMapNode2;
				}
				else if (SiteMap.CurrentNode.Url == Globals.ApplicationPath + "/BrandDetail.aspx")
				{
					if (HttpContext.Current.Request.QueryString["BrandGuid"] != null)
					{
						guid = ((HttpContext.Current.Request.QueryString["BrandGuid"] == null) ? "0" : HttpContext.Current.Request.QueryString["BrandGuid"]);
						title = shopNum1_SiteMap_Action.Search("ShopNum1_Brand", guid);
					}
					SiteMapNode siteMapNode2 = new SiteMapNode(siteMapResolveEventArgs_0.Provider, "newNode", "BrandDetail.aspx", title);
					siteMapNode2.ParentNode = siteMapNode;
					SiteMapNode siteMapNode3 = siteMapNode;
					siteMapNode3.Url = Globals.ApplicationPath + "/BrandList.aspx";
					siteMapNodeCollection.Add(siteMapNode2);
					siteMapNode.ChildNodes = siteMapNodeCollection;
					siteMapNode = siteMapNode2;
				}
				else if (SiteMap.CurrentNode.Url == Globals.ApplicationPath + "/ProductDetail.aspx")
				{
					if (HttpContext.Current.Request.QueryString["guid"] != null)
					{
						guid = ((HttpContext.Current.Request.QueryString["guid"] == null) ? "0" : HttpContext.Current.Request.QueryString["guid"]);
						title = shopNum1_SiteMap_Action.Search("ShopNum1_Product", guid);
					}
					SiteMapNode siteMapNode2 = new SiteMapNode(siteMapResolveEventArgs_0.Provider, "newNode", "ProductDetail.aspx", title);
					siteMapNode2.ParentNode = siteMapNode;
					SiteMapNode siteMapNode3 = siteMapNode;
					siteMapNode3.Url = Globals.ApplicationPath + "/ProductListRecommand.aspx";
					siteMapNodeCollection.Add(siteMapNode2);
					siteMapNode.ChildNodes = siteMapNodeCollection;
					siteMapNode = siteMapNode2;
				}
			}
			return siteMapNode;
		}
	}
}
