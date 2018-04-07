using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Control;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_User_List : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected HtmlHead Head1;
	protected System.Web.UI.WebControls.TextBox TextBoxSRealName;
	protected System.Web.UI.WebControls.DropDownList DropDownListSDept;
	protected Label LabelSIsForbid;
	protected System.Web.UI.WebControls.DropDownList DropdownListSIsForbid;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected LinkButton ButtonDelete;
	protected MessageShow MessageShow;
	protected Num1GridView Num1GridViewShow;
	protected ObjectDataSource ObjectDataSourceData;
	protected HiddenField CheckGuid;
	protected HiddenField hiddenGuid;
	protected HiddenField HiddenFieldSubstationID;
	protected HtmlForm form1;
	private int int_0;
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
			this.method_6();
			this.method_7();
		}
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.method_5();
	}
	private void method_5()
	{
		this.Num1GridViewShow.DataBind();
	}
	private void method_6()
	{
		ShopNum1_Dept_Action shopNum1_Dept_Action = (ShopNum1_Dept_Action)LogicFactory.CreateShopNum1_Dept_Action();
		DataView defaultView = shopNum1_Dept_Action.Search(0).DefaultView;
		foreach (DataRow dataRow in defaultView.Table.Rows)
		{
			ListItem listItem = new ListItem();
			listItem.Text = dataRow["Name"].ToString().Trim();
			listItem.Value = dataRow["GUID"].ToString().Trim();
			this.DropDownListSDept.Items.Add(listItem);
		}
	}
	private void method_7()
	{
		ShopNum1_Group_Action shopNum1_Group_Action = (ShopNum1_Group_Action)LogicFactory.CreateShopNum1_Group_Action();
		DataView defaultView = shopNum1_Group_Action.Search(0).DefaultView;
		foreach (DataRow dataRow in defaultView.Table.Rows)
		{
			ListItem listItem = new ListItem();
			listItem.Text = dataRow["Name"].ToString().Trim();
			listItem.Value = dataRow["GUID"].ToString().Trim();
		}
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		if (this.CheckGuid.Value.Trim().Replace("'", "").ToUpper() == "8ea30851-571b-4ffa-8870-05a7e5134aa9".ToUpper())
		{
			MessageBox.Show("系统默认管理员不允许被删除!");
		}
		else
		{
			ShopNum1_User_Action shopNum1_User_Action = (ShopNum1_User_Action)LogicFactory.CreateShopNum1_User_Action();
			int num = shopNum1_User_Action.Delete(this.CheckGuid.Value.ToString());
			if (num > 0)
			{
				this.MessageShow.ShowMessage("DelYes");
				this.MessageShow.Visible = true;
				this.method_5();
			}
			else
			{
				this.MessageShow.ShowMessage("DelNo");
				this.MessageShow.Visible = true;
			}
		}
	}
	protected void ButtonEditByLink_Click(object sender, EventArgs e)
	{
	}
	protected DataTable GetUser(string strGuid)
	{
		ShopNum1_User_Action shopNum1_User_Action = (ShopNum1_User_Action)LogicFactory.CreateShopNum1_User_Action();
		return shopNum1_User_Action.GetUserByGuid(strGuid, 0);
	}
	public string ChangeIsForbid(string strFobid)
	{
		string result;
		if (strFobid == "0")
		{
			result = "images/shopNum1Admin-right.gif";
		}
		else if (strFobid == "1")
		{
			result = "images/shopNum1Admin-wrong.gif";
		}
		else
		{
			result = "";
		}
		return result;
	}
	public string FormatDate(string strDate)
	{
		string result;
		if (strDate.Substring(0, 4) == "1900")
		{
			result = "";
		}
		else
		{
			result = strDate;
		}
		return result;
	}
	public string ChangeAge(string strSex)
	{
		string result;
		if (strSex == "0")
		{
			result = "女";
		}
		else if (strSex == "1")
		{
			result = "男";
		}
		else if (strSex == "2")
		{
			result = "保密";
		}
		else
		{
			result = "";
		}
		return result;
	}
	protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
	{
		string text = "";
		if (base.Request.Cookies["AdminLoginCookie"] != null)
		{
			HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
			HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
			text = httpCookie.Values["Guid"].ToString();
		}
		LinkButton linkButton = (LinkButton)sender;
		string text2 = "'" + linkButton.CommandArgument + "'";
		if (text2.Replace("'", "").ToUpper() == text.ToUpper())
		{
			MessageBox.Show("该用户正在使用中!");
		}
		else if (text2.Replace("'", "").ToUpper() == "8ea30851-571b-4ffa-8870-05a7e5134aa9".ToUpper())
		{
			MessageBox.Show("系统默认管理员不允许被删除!");
		}
		else
		{
			ShopNum1_User_Action shopNum1_User_Action = (ShopNum1_User_Action)LogicFactory.CreateShopNum1_User_Action();
			int num = shopNum1_User_Action.Delete(text2);
			if (num > 0)
			{
				this.method_5();
				this.MessageShow.ShowMessage("DelYes");
				this.MessageShow.Visible = true;
			}
			else
			{
				this.MessageShow.ShowMessage("DelNo");
				this.MessageShow.Visible = true;
			}
		}
	}
}
