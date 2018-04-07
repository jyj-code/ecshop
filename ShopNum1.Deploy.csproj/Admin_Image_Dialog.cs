using ShopNum1.Common;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_Image_Dialog : Page, IRequiresSessionState
{
	protected Image ImagePack;
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
		this.ImagePack.ImageUrl = Globals.ImagePath + Operator.FilterString(base.Request.QueryString["imagepath"].ToString());
	}
}
