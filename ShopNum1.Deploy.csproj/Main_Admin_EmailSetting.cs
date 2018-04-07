using ShopNum1.Common;
using ShopNum1.Email;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
public class Main_Admin_EmailSetting : PageBase, IRequiresSessionState
{
	protected Localize Localize1;
	protected DropDownList selectSendType;
	protected Localize Localize2;
	protected TextBox txtSmtpServer;
	protected Localize LocalizeEmailServer;
	protected TextBox TextBoxServerPort;
	protected Localize Localize3;
	protected CheckBox cbSSL;
	protected Localize LocalizeEmailAccount;
	protected TextBox TextBoxEmailAccount;
	protected Localize LocalizeEmailPassword;
	protected HtmlInputPassword TextBoxEmailPassword;
	protected Localize LocalizeRestoreEmail;
	protected TextBox TextBoxRestoreEmail;
	protected Localize LocalizeEmailCode;
	protected CheckBoxList CheckBoxListEmailCode;
	protected Localize LocalizeEmailAddress;
	protected TextBox TextBoxEmailAddress;
	protected RequiredFieldValidator RequiredFieldValidatorTextBoxEmailAddress;
	protected RegularExpressionValidator RegularExpressionValidatorTextBoxEmailAddress;
	protected Button ButtonSend;
	protected HiddenField HiddenFieldXmlPath;
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
			this.HiddenFieldXmlPath.Value = base.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml");
			if (base.Request.QueryString["op"] != null)
			{
				string text = base.Request.QueryString["op"].ToString();
				if (text != null)
				{
					if (!(text == "getdata"))
					{
						if (text == "savedata")
						{
							base.Response.Write("");
						}
					}
					else
					{
						base.Response.Write(this.method_5(this.GetXmlData()));
					}
				}
			}
		}
	}
	private string method_5(List<string> list_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("[");
		if (list_0.Count > 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				string[] array = list_0[i].Split(new char[]
				{
					'|'
				});
				stringBuilder.Append("{");
				stringBuilder.Append(string.Concat(new string[]
				{
					"\"name\":\"",
					array[0],
					"\",\"tagname\":\"",
					array[1],
					"\",\"value\":\"",
					array[2],
					"\""
				}));
				stringBuilder.Remove(stringBuilder.Length - 1, 1);
				stringBuilder.Append("},");
			}
		}
		stringBuilder.Remove(stringBuilder.Length - 1, 1);
		stringBuilder.Append("]");
		return stringBuilder.ToString();
	}
	protected List<string> GetXmlData()
	{
		List<string> list = new List<string>();
		XmlNodeList xmlNodeList = XmlOperator.ReadXmlReturnNodeList(this.HiddenFieldXmlPath.Value, "ShopSetting");
		foreach (XmlNode xmlNode in xmlNodeList)
		{
			foreach (XmlNode xmlNode2 in xmlNode.ChildNodes)
			{
				string name = xmlNode2.Name;
				switch (name)
				{
				case "EmailServer":
					list.Add("EmailServer|发送方式：|" + xmlNode2.InnerText);
					break;
				case "SSL":
					if (xmlNode2.InnerText == "1")
					{
						this.cbSSL.Checked = true;
					}
					break;
				case "SMTP":
					list.Add("SMTP|SMTP服务器：|" + xmlNode2.InnerText);
					break;
				case "ServerPort":
					list.Add("ServerPort|SMTP服务器端口：|" + xmlNode2.InnerText);
					break;
				case "EmailAccount":
					list.Add("EmailAccount|SMTP用户名： |" + xmlNode2.InnerText);
					break;
				case "EmailPassword":
					list.Add("EmailPassword|SMTP用户密码： |" + xmlNode2.InnerText);
					break;
				case "RestoreEmail":
					list.Add("RestoreEmail|邮件回复地址：|" + xmlNode2.InnerText);
					break;
				}
			}
		}
		return list;
	}
	protected void ButtonSend_Click(object sender, EventArgs e)
	{
		if (!new NetMail
		{
			RecipientEmail = this.TextBoxEmailAddress.Text.Trim(),
			Subject = "发送邮件测试",
			Body = "邮件发送成功！"
		}.Send())
		{
			MessageBox.Show("发送失败！请检查系统邮箱和测试邮箱配置是否正确！");
		}
		else
		{
			MessageBox.Show("发送成功!");
			this.TextBoxEmailAddress.Text = "";
		}
	}
}
