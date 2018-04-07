using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Control;
using ShopNum1.Factory;
using ShopNum1.Localization;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class AgentAdmin_ShopDoMain_List : PageBase, IRequiresSessionState
{
	protected const string ShopDoMain_List_Report = "~/Main/Admin/ShopDoMain_List_Report.aspx";
	protected Label LabelSMemLoginID;
	protected System.Web.UI.WebControls.TextBox TextBoxMemLoginID;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected System.Web.UI.WebControls.DropDownList DropDownListIsAudit;
	protected LinkButton ButtonReportexl;
	protected LinkButton ButtonReporthtl;
	protected LinkButton ButtonIsAudit1;
	protected LinkButton ButtonIsAudit0;
	protected LinkButton ButtonDelete;
	protected AgentAdmin_MessageShow MessageShow;
	protected System.Web.UI.WebControls.RadioButtonList RadioButtonListOutPage;
	protected Num1GridView num1GridViewShow;
	protected ObjectDataSource ObjectDataSourceData;
	protected HiddenField CheckGuid;
	protected HiddenField hiddenFieldGuid;
	protected HiddenField hiddenFieldSubstationID;
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
		this.hiddenFieldSubstationID.Value = base.SubstationID;
		if (!this.Page.IsPostBack)
		{
			this.method_5();
			this.BindGrid();
		}
	}
	private void method_5()
	{
		this.DropDownListIsAudit.Items.Add(new ListItem("已审核", "1"));
	}
	protected void BindGrid()
	{
		this.num1GridViewShow.DataBind();
	}
	public void BindShopLoginID()
	{
		ShopNum1_ShopURLManage_Action shopNum1_ShopURLManage_Action = (ShopNum1_ShopURLManage_Action)LogicFactory.CreateShopNum1_ShopURLManage_Action();
		DataTable shopLoginID = shopNum1_ShopURLManage_Action.GetShopLoginID(this.hiddenFieldGuid.Value.Replace("'", ""));
		this.TextBoxMemLoginID.Text = shopLoginID.Rows[0]["MemLoginID"].ToString();
	}
	protected void ButtonEdit_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ShopDoMain_Operate.aspx?guid=" + this.CheckGuid.Value + "&MemLoginID=" + this.hiddenFieldGuid.Value);
	}
	protected void ButtonAdd_Click(object sender, EventArgs e)
	{
		this.CheckGuid.Value = "0";
		base.Response.Redirect("ShopDoMain_Operate.aspx?guid=" + this.CheckGuid.Value + "&MemLoginID=" + this.hiddenFieldGuid.Value);
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_ShopURLManage_Action shopNum1_ShopURLManage_Action = (ShopNum1_ShopURLManage_Action)LogicFactory.CreateShopNum1_ShopURLManage_Action();
		int num = shopNum1_ShopURLManage_Action.Delete(this.CheckGuid.Value.ToString());
		if (num > 0)
		{
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "删除成功",
				OperatorID = base.ShopNum1LoginID,
				IP = Globals.IPAddress,
				PageName = "AgentDoMain_List.aspx",
				Date = DateTime.Now
			});
			this.BindGrid();
			this.MessageShow.ShowMessage("DelYes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("DelNo");
			this.MessageShow.Visible = true;
		}
	}
	protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
	{
		ShopNum1_ShopURLManage_Action shopNum1_ShopURLManage_Action = (ShopNum1_ShopURLManage_Action)LogicFactory.CreateShopNum1_ShopURLManage_Action();
		LinkButton linkButton = (LinkButton)sender;
		string strID = "'" + linkButton.CommandArgument + "'";
		int num = shopNum1_ShopURLManage_Action.Delete(strID);
		if (num > 0)
		{
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "删除成功",
				OperatorID = base.ShopNum1LoginID,
				IP = Globals.IPAddress,
				PageName = "AgentDoMain_List.aspx",
				Date = DateTime.Now
			});
			this.BindGrid();
			this.MessageShow.ShowMessage("DelYes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("DelNo");
			this.MessageShow.Visible = true;
		}
	}
	public string ChangeIsAudit(string strIsAudit)
	{
		string result;
		if (strIsAudit == "0")
		{
			result = LocalizationUtil.GetChangeMessage("MessageBoard_List", "IsAudit", "0");
		}
		else if (strIsAudit == "1")
		{
			result = LocalizationUtil.GetChangeMessage("MessageBoard_List", "IsAudit", "1");
		}
		else
		{
			result = "";
		}
		return result;
	}
	protected void ButtonIsAudit1_Click(object sender, EventArgs e)
	{
		ShopNum1_ShopURLManage_Action shopNum1_ShopURLManage_Action = (ShopNum1_ShopURLManage_Action)LogicFactory.CreateShopNum1_ShopURLManage_Action();
		int num = shopNum1_ShopURLManage_Action.UpdateIsAudit(this.CheckGuid.Value.Replace("'", ""), "1");
		if (num > 0)
		{
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "审核成功",
				OperatorID = base.ShopNum1LoginID,
				IP = Globals.IPAddress,
				PageName = "AgentDoMain_List.aspx",
				Date = DateTime.Now
			});
			this.BindGrid();
			this.MessageShow.ShowMessage("Audit1Yes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("Audit1No");
			this.MessageShow.Visible = true;
		}
	}
	protected void ButtonIsAudit0_Click(object sender, EventArgs e)
	{
		ShopNum1_ShopURLManage_Action shopNum1_ShopURLManage_Action = (ShopNum1_ShopURLManage_Action)LogicFactory.CreateShopNum1_ShopURLManage_Action();
		int num = shopNum1_ShopURLManage_Action.UpdateIsAudit(this.CheckGuid.Value.Replace("'", ""), "0");
		if (num > 0)
		{
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "取消审核成功",
				OperatorID = base.ShopNum1LoginID,
				IP = Globals.IPAddress,
				PageName = "AgentDoMain_List.aspx",
				Date = DateTime.Now
			});
			this.BindGrid();
			this.MessageShow.ShowMessage("Audit2Yes");
			this.MessageShow.Visible = true;
		}
		else
		{
			this.MessageShow.ShowMessage("Audit2No");
			this.MessageShow.Visible = true;
		}
	}
	protected void ButtonReportExcel_Click(object sender, EventArgs e)
	{
		if (this.num1GridViewShow.Rows.Count < 1)
		{
			MessageBox.Show("当前无导出的记录！");
		}
		else
		{
			HttpCookie httpCookie = new HttpCookie("ShopDoMainReportCookie");
			httpCookie.Values.Add("MemLoginID", this.TextBoxMemLoginID.Text.Trim());
			httpCookie.Values.Add("IsAudit", this.DropDownListIsAudit.SelectedValue);
			string text = string.Empty;
			if (this.RadioButtonListOutPage.SelectedValue == "0")
			{
				httpCookie.Values.Add("PageCheck", "1");
				for (int i = 0; i < this.num1GridViewShow.Rows.Count; i++)
				{
					if (i == 0)
					{
						if (this.num1GridViewShow.Rows.Count != 1)
						{
							text = "'" + this.num1GridViewShow.Rows[i].Cells[1].Text.ToString() + "',";
						}
						else
						{
							text = "'" + this.num1GridViewShow.Rows[i].Cells[1].Text.ToString() + "'";
						}
					}
					else if (i == this.num1GridViewShow.Rows.Count - 1)
					{
						text = text + "'" + this.num1GridViewShow.Rows[i].Cells[1].Text.ToString() + "'";
					}
					else
					{
						text = text + "'" + this.num1GridViewShow.Rows[i].Cells[1].Text.ToString() + "',";
					}
				}
				httpCookie.Values.Add("Guids", text);
			}
			else
			{
				httpCookie.Values.Add("PageCheck", "0");
				httpCookie.Values.Add("Guids", "0");
			}
			HttpCookie cookie = HttpSecureCookie.Encode(httpCookie);
			base.Response.AppendCookie(cookie);
			base.Response.Redirect("~/Main/Admin/ShopDoMain_List_Report.aspx?Type=xls");
		}
	}
	protected void ButtonReportHtml_Click(object sender, EventArgs e)
	{
		if (this.num1GridViewShow.Rows.Count < 1)
		{
			MessageBox.Show("当前无导出的记录！");
		}
		else
		{
			HttpCookie httpCookie = new HttpCookie("ShopDoMainReportCookie");
			httpCookie.Values.Add("MemLoginID", this.TextBoxMemLoginID.Text.Trim());
			httpCookie.Values.Add("IsAudit", this.DropDownListIsAudit.SelectedValue);
			string text = string.Empty;
			if (this.RadioButtonListOutPage.SelectedValue == "0")
			{
				httpCookie.Values.Add("PageCheck", "1");
				for (int i = 0; i < this.num1GridViewShow.Rows.Count; i++)
				{
					if (i == 0)
					{
						if (this.num1GridViewShow.Rows.Count != 1)
						{
							text = "'" + this.num1GridViewShow.Rows[i].Cells[1].Text.ToString() + "',";
						}
						else
						{
							text = "'" + this.num1GridViewShow.Rows[i].Cells[1].Text.ToString() + "'";
						}
					}
					else if (i == this.num1GridViewShow.Rows.Count - 1)
					{
						text = text + "'" + this.num1GridViewShow.Rows[i].Cells[1].Text.ToString() + "'";
					}
					else
					{
						text = text + "'" + this.num1GridViewShow.Rows[i].Cells[1].Text.ToString() + "',";
					}
				}
				httpCookie.Values.Add("Guids", text);
			}
			else
			{
				httpCookie.Values.Add("PageCheck", "0");
				httpCookie.Values.Add("Guids", "0");
			}
			HttpCookie cookie = HttpSecureCookie.Encode(httpCookie);
			base.Response.AppendCookie(cookie);
			base.Response.Redirect("~/Main/Admin/ShopDoMain_List_Report.aspx?Type=html");
		}
	}
}
