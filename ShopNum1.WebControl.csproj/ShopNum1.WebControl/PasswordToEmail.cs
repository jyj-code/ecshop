using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class PasswordToEmail : BaseWebControl
	{
		private string string_0 = "PasswordReminderUrl.ascx";
		private LinkButton linkButton_0;
		public PasswordToEmail()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.linkButton_0 = (LinkButton)skin.FindControl("LinkButtonEmail");
			if (!this.Page.IsPostBack && this.Page.Request.QueryString["email"] != null)
			{
				this.GetUrl(this.Page.Request.QueryString["email"].ToString());
			}
		}
		public void GetUrl(string email)
		{
			int num = Convert.ToInt32(email.LastIndexOf(".")) - Convert.ToInt32(email.LastIndexOf("@"));
			string b = email.Substring(email.LastIndexOf("@") + 1, num - 1);
			DataTable xmlDataTable = this.GetXmlDataTable();
			if (xmlDataTable != null && xmlDataTable.Rows.Count > 0)
			{
				for (int i = 0; i < xmlDataTable.Rows.Count; i++)
				{
					if (xmlDataTable.Rows[i]["sign"].ToString() == b)
					{
						if (xmlDataTable.Rows[i]["url"].ToString().Contains("http://") || xmlDataTable.Rows[i]["url"].ToString().Contains("https://"))
						{
							this.linkButton_0.PostBackUrl = xmlDataTable.Rows[i]["url"].ToString();
						}
						else
						{
							this.linkButton_0.PostBackUrl = "http://" + xmlDataTable.Rows[i]["url"].ToString();
						}
					}
				}
			}
		}
		public DataTable GetXmlDataTable()
		{
			DataSet dataSet = new DataSet();
			dataSet.ReadXml(this.Page.Server.MapPath("~/Settings/email.xml"));
			DataTable result;
			if (dataSet == null || dataSet.Tables.Count == 0)
			{
				result = null;
			}
			else
			{
				result = dataSet.Tables[0];
			}
			return result;
		}
	}
}
