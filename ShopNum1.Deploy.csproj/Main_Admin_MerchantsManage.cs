using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_MerchantsManage : PageBase, IRequiresSessionState
{
	protected HtmlTextArea ckeditormark;
	protected Button butSave;
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
		if (!this.Page.IsPostBack)
		{
			try
			{
				string path = HttpContext.Current.Server.MapPath("~/main/Themes/Skin_Default/MerchantsIn.html");
				if (File.Exists(path))
				{
					FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
					StreamReader streamReader = new StreamReader(fileStream, Encoding.Default);
					this.ckeditormark.Value = streamReader.ReadToEnd();
					streamReader.Close();
					fileStream.Close();
				}
			}
			catch
			{
				this.ckeditormark.Value = "招商页面拒绝访问，请联系售后增加页面访问权限！";
			}
		}
	}
	protected void butSave_Click(object sender, EventArgs e)
	{
		try
		{
			string path = HttpContext.Current.Server.MapPath("~/main/Themes/Skin_Default/MerchantsIn.html");
			if (File.Exists(path))
			{
				Stream stream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
				StreamWriter streamWriter = new StreamWriter(stream, Encoding.GetEncoding("gb2312"));
				streamWriter.Write(this.ckeditormark.Value);
				streamWriter.Close();
				stream.Close();
			}
			this.Page.ClientScript.RegisterStartupScript(base.GetType(), "msg", "<script>alert('修改成功！');</script>", false);
		}
		catch
		{
			this.ckeditormark.Value = "招商页面拒绝访问，请联系售后增加页面访问权限！";
		}
	}
}
