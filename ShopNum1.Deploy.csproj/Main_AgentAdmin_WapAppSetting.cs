using ShopNum1.Common;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_AgentAdmin_WapAppSetting : Page, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected Label LabelTitle;
	protected Repeater rep_PicSet;
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
		if (!this.Page.IsPostBack)
		{
			string text = Common.ReqStr("type");
			text = ((text == "") ? "0" : text);
			this.rep_PicSet.DataSource = Common.GetTableById("ShopID,Value,Url,ConfigType,MemLoginID", "ShopNum1_AdvertisementImage", " And shopid='0' And ConfigType='" + text + "'");
			this.rep_PicSet.DataBind();
		}
	}
}
