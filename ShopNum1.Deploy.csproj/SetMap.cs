using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
public class SetMap : PageBase, IRequiresSessionState
{
	protected ScriptManager ScriptManager1;
	protected DropDownList DropDownListDefaultPriority;
	protected CompareValidator CompareDdl;
	protected DropDownList DropDownListDefaultChangefreq;
	protected CompareValidator CompareValidator1;
	protected DropDownList DropDownListProductCategroyPriority;
	protected CompareValidator CompareValidator2;
	protected DropDownList DropDownListProductCategroyChangefreq;
	protected CompareValidator CompareValidator3;
	protected DropDownList DropDownListArticleCategroyPriority;
	protected CompareValidator CompareValidator6;
	protected DropDownList DropDownListArticleCategroyChangefreq;
	protected CompareValidator CompareValidator7;
	protected DropDownList DropDownListArticlePriority;
	protected CompareValidator CompareValidator8;
	protected DropDownList DropDownListArticleChangefreq;
	protected CompareValidator CompareValidator9;
	protected DropDownList DropDownListSupplyDemandPriority;
	protected CompareValidator CompareValidatorDropDownListSupplyDemandPriority;
	protected DropDownList DropDownListSupplyDemandChangefreq;
	protected CompareValidator CompareValidatorDropDownListSupplyDemandChangefreq;
	protected DropDownList DropDownListOtherPriority;
	protected CompareValidator CompareValidator14;
	protected DropDownList DropDownListOtherChangefreq;
	protected CompareValidator CompareValidator15;
	protected Button ButtonConfirm;
	protected Literal LiteralURL;
	protected HtmlForm form1;
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
	protected void Page_Load(object sender, EventArgs e)
	{
		base.CheckLogin();
		if (!base.IsPostBack)
		{
			this.BindDropDownList(this.DropDownListDefaultChangefreq, this.DropDownListDefaultPriority);
			this.BindDropDownList(this.DropDownListProductCategroyChangefreq, this.DropDownListProductCategroyPriority);
			this.BindDropDownList(this.DropDownListArticleCategroyChangefreq, this.DropDownListArticleCategroyPriority);
			this.BindDropDownList(this.DropDownListArticleChangefreq, this.DropDownListArticlePriority);
			this.BindDropDownList(this.DropDownListOtherChangefreq, this.DropDownListOtherPriority);
			this.BindDropDownList(this.DropDownListSupplyDemandChangefreq, this.DropDownListSupplyDemandPriority);
		}
	}
	public void BindDropDownList(DropDownList DropDownListChangefreq, DropDownList DropDownListPriority)
	{
		DropDownListChangefreq.Items.Clear();
		DropDownListPriority.Items.Clear();
		DropDownListChangefreq.Items.Add(new ListItem("一直更新", "always"));
		DropDownListChangefreq.Items.Add(new ListItem("小时", "hourly"));
		DropDownListChangefreq.Items.Add(new ListItem("日", "daily"));
		DropDownListChangefreq.Items.Add(new ListItem("周", "weekly"));
		DropDownListChangefreq.Items.Add(new ListItem("月", "mothly"));
		DropDownListChangefreq.Items.Add(new ListItem("年", "yearly"));
		DropDownListChangefreq.Items.Add(new ListItem("不更新", "never"));
		DropDownListPriority.Items.Add(new ListItem("1.0", "1.0"));
		for (int i = 9; i > 0; i--)
		{
			DropDownListPriority.Items.Add(new ListItem("0." + i.ToString(), "0." + i.ToString()));
		}
	}
	protected void ButtonConfirm_Click(object sender, EventArgs e)
	{
		string text = base.Server.MapPath("~/SiteMap.xml");
		File.Delete(text);
		this.AddWebSiteMap(base.Server.MapPath("~/SiteMap.xml"));
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.Load(text);
		XmlNode documentElement = xmlDocument.DocumentElement;
		XmlAttribute xmlAttribute = xmlDocument.CreateAttribute("xmlns");
		xmlAttribute.Value = "http://www.sitemaps.org/schemas/sitemap/0.9";
		documentElement.Attributes.Append(xmlAttribute);
		xmlDocument.Save(text);
		XmlDocument xmlDocument2 = new XmlDocument();
		xmlDocument2.Load(text);
		DataSet dataSet = new DataSet();
		dataSet.ReadXml(base.Server.MapPath("~/Settings/ShopSetting.xml"));
		DataRow dataRow = dataSet.Tables["ShopSetting"].Rows[0];
		string a = dataRow["OverrideUrl"].ToString();
		XmlNode documentElement2 = xmlDocument2.DocumentElement;
		if (documentElement2 != null)
		{
			string string_ = DateTime.Now.ToShortDateString();
			string siteDomain = ShopSettings.siteDomain;
			ShopNum1_ExtendSiteMapXml_Action shopNum1_ExtendSiteMapXml_Action = (ShopNum1_ExtendSiteMapXml_Action)LogicFactory.CreateShopNum1_ExtendSiteMapXml_Action();
			XmlElement newChild = SetMap.smethod_0(xmlDocument2, "http://" + siteDomain, string_, this.DropDownListDefaultChangefreq.SelectedValue, this.DropDownListDefaultPriority.SelectedValue);
			documentElement2.InsertAfter(newChild, documentElement2.LastChild);
			DataTable dataTable = shopNum1_ExtendSiteMapXml_Action.SearchProductCategoryID();
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				if (a == "true")
				{
					newChild = SetMap.smethod_0(xmlDocument2, string.Concat(new string[]
					{
						"http://",
						siteDomain,
						"/productlist/",
						dataTable.Rows[i]["Code"].ToString(),
						".html"
					}), string_, this.DropDownListProductCategroyChangefreq.SelectedValue, this.DropDownListProductCategroyPriority.SelectedValue);
				}
				else
				{
					newChild = SetMap.smethod_0(xmlDocument2, "http://" + siteDomain + "/productlist.aspx?Code=" + dataTable.Rows[i]["Code"].ToString(), string_, this.DropDownListProductCategroyChangefreq.SelectedValue, this.DropDownListProductCategroyPriority.SelectedValue);
				}
				documentElement2.InsertAfter(newChild, documentElement2.LastChild);
			}
			DataTable dataTable2 = shopNum1_ExtendSiteMapXml_Action.SearchArticleCategoryID();
			for (int i = 0; i < dataTable2.Rows.Count; i++)
			{
				if (a == "true")
				{
					newChild = SetMap.smethod_0(xmlDocument2, string.Concat(new string[]
					{
						"http://",
						siteDomain,
						"/articlelist/",
						dataTable2.Rows[i]["ID"].ToString(),
						".html"
					}), string_, this.DropDownListArticleCategroyChangefreq.SelectedValue, this.DropDownListArticleCategroyPriority.SelectedValue);
				}
				else
				{
					newChild = SetMap.smethod_0(xmlDocument2, "http://" + siteDomain + "/articlelist.aspx?id=" + dataTable2.Rows[i]["ID"].ToString(), string_, this.DropDownListArticleCategroyChangefreq.SelectedValue, this.DropDownListArticleCategroyPriority.SelectedValue);
				}
				documentElement2.InsertAfter(newChild, documentElement2.LastChild);
			}
			DataTable dataTable3 = shopNum1_ExtendSiteMapXml_Action.SearchArticle();
			for (int i = 0; i < dataTable3.Rows.Count; i++)
			{
				if (a == "true")
				{
					newChild = SetMap.smethod_0(xmlDocument2, string.Concat(new string[]
					{
						"http://",
						siteDomain,
						"/ArticleDetail/",
						dataTable3.Rows[i]["Guid"].ToString(),
						".html"
					}), string_, this.DropDownListArticleChangefreq.SelectedValue, this.DropDownListArticlePriority.SelectedValue);
				}
				else
				{
					newChild = SetMap.smethod_0(xmlDocument2, "http://" + siteDomain + "/ArticleDetail.aspx?guid=" + dataTable3.Rows[i]["Guid"].ToString(), string_, this.DropDownListArticleChangefreq.SelectedValue, this.DropDownListArticlePriority.SelectedValue);
				}
				documentElement2.InsertAfter(newChild, documentElement2.LastChild);
			}
			DataTable dataTable4 = shopNum1_ExtendSiteMapXml_Action.SearchSupplyDemandCatagoryCode();
			for (int i = 0; i < dataTable4.Rows.Count; i++)
			{
				if (a == "true")
				{
					newChild = SetMap.smethod_0(xmlDocument2, string.Concat(new string[]
					{
						"http://",
						siteDomain,
						"/supplylist/",
						dataTable4.Rows[i]["Code"].ToString(),
						".html"
					}), string_, this.DropDownListSupplyDemandChangefreq.SelectedValue, this.DropDownListSupplyDemandPriority.SelectedValue);
				}
				else
				{
					newChild = SetMap.smethod_0(xmlDocument2, "http://" + siteDomain + "/supplylist.aspx?Code=" + dataTable4.Rows[i]["Code"].ToString(), string_, this.DropDownListSupplyDemandChangefreq.SelectedValue, this.DropDownListSupplyDemandPriority.SelectedValue);
				}
				documentElement2.InsertAfter(newChild, documentElement2.LastChild);
			}
			string[] files = Directory.GetFiles(base.Server.MapPath("~/"), "*.aspx");
			for (int i = 0; i < files.Length; i++)
			{
				if (a == "true")
				{
					newChild = SetMap.smethod_0(xmlDocument2, "http://" + siteDomain + "/" + files[i].Substring(files[i].LastIndexOf('\\') + 1).Replace("aspx", "html"), string_, this.DropDownListOtherChangefreq.SelectedValue, this.DropDownListOtherChangefreq.SelectedValue);
				}
				else
				{
					newChild = SetMap.smethod_0(xmlDocument2, "http://" + siteDomain + "/" + files[i].Substring(files[i].LastIndexOf('\\') + 1), string_, this.DropDownListOtherChangefreq.SelectedValue, this.DropDownListOtherChangefreq.SelectedValue);
				}
				documentElement2.InsertAfter(newChild, documentElement2.LastChild);
			}
			xmlDocument2.Save(text);
			this.LiteralURL.Text = string.Concat(new string[]
			{
				"站点地图生成成功，点击浏览<a href=\"http://",
				ShopSettings.siteDomain,
				"/sitemap.xml\" target=\"_blank\" >http://",
				ShopSettings.siteDomain,
				"/sitemap.xml</a>"
			});
		}
	}
	private static XmlElement smethod_0(XmlDocument xmlDocument_0, string string_5, string string_6, string string_7, string string_8)
	{
		XmlElement xmlElement = xmlDocument_0.CreateElement("url");
		XmlElement xmlElement2 = xmlDocument_0.CreateElement("loc");
		xmlElement2.InnerText = string_5;
		xmlElement.AppendChild(xmlElement2);
		XmlElement xmlElement3 = xmlDocument_0.CreateElement("lastmod");
		xmlElement3.InnerText = string_6;
		xmlElement.AppendChild(xmlElement3);
		XmlElement xmlElement4 = xmlDocument_0.CreateElement("changefreq");
		xmlElement4.InnerText = string_7;
		xmlElement.AppendChild(xmlElement4);
		XmlElement xmlElement5 = xmlDocument_0.CreateElement("priority");
		xmlElement5.InnerText = string_8;
		xmlElement.AppendChild(xmlElement5);
		return xmlElement;
	}
	public void AddWebSiteMap(string path)
	{
		XmlWriter xmlWriter = XmlWriter.Create(path);
		xmlWriter.WriteComment("动态生成的站点地图");
		xmlWriter.WriteStartElement("urlset");
		xmlWriter.WriteEndElement();
		xmlWriter.Close();
	}
}
