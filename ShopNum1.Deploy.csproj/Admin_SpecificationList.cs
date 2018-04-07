using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Control;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_SpecificationList : PageBase, IRequiresSessionState
{
	public enum ShowTypeImg : uint
	{
		文字,
		图片
	}
	protected HtmlHead Head1;
	protected System.Web.UI.WebControls.TextBox TextBoxName;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected LinkButton ButtonAdd;
	protected LinkButton ButtonDelete;
	protected Num1GridView Num1GridViewShow;
	protected ObjectDataSource ObjectDataSource1;
	protected HiddenField CheckGuid;
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
		HttpContext.Current.Session["order"] = null;
	}
	protected void ButtonEdit_Click(object sender, EventArgs e)
	{
		base.Response.Redirect(string.Format("Specification_Edit.aspx?id={0}", this.CheckGuid.Value.Replace("'", "").Trim()));
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(this.CheckGuid.Value.ToString() + ",");
		if (!(stringBuilder.ToString() == ""))
		{
			ShopNum1_Spec_Action shopNum1_Spec_Action = (ShopNum1_Spec_Action)LogicFactory.CreateShopNum1_Spec_Action();
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "管理员删除规格",
				OperatorID = this.Session["AdminLoginCookie"].ToString(),
				IP = Globals.IPAddress,
				PageName = "Specification_List.aspx",
				Date = DateTime.Now
			});
			if (shopNum1_Spec_Action.Delete(stringBuilder.ToString().Substring(0, stringBuilder.ToString().Length - 1)) > 0)
			{
				MessageBox.Show("删除成功");
				this.Num1GridViewShow.DataBind();
			}
			else
			{
				MessageBox.Show("删除失败");
			}
		}
	}
	protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
	{
		StringBuilder stringBuilder = new StringBuilder();
		LinkButton linkButton = (LinkButton)sender;
		string str = "'" + linkButton.CommandArgument + "'";
		stringBuilder.Append(str + ",");
		if (!(stringBuilder.ToString() == ""))
		{
			ShopNum1_Spec_Action shopNum1_Spec_Action = (ShopNum1_Spec_Action)LogicFactory.CreateShopNum1_Spec_Action();
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "管理员删除规格",
				OperatorID = this.Session["AdminLoginCookie"].ToString(),
				IP = Globals.IPAddress,
				PageName = "Specification_List.aspx",
				Date = DateTime.Now
			});
			if (shopNum1_Spec_Action.Delete(stringBuilder.ToString().Substring(0, stringBuilder.ToString().Length - 1)) > 0)
			{
				MessageBox.Show("删除成功");
				this.Num1GridViewShow.DataBind();
			}
			else
			{
				MessageBox.Show("删除失败");
			}
		}
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.BindGrid();
	}
	protected void ButtonAdd_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("Specification_Operate.aspx");
	}
	protected void BindGrid()
	{
		try
		{
			this.Num1GridViewShow.DataBind();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}
}
