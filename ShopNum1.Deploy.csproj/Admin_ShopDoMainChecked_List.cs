using ShopNum1.BusinessLogic;
using ShopNum1.CityFactory;
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
public class Admin_ShopDoMainChecked_List : PageBase, IRequiresSessionState
{
	protected const string ShopDoMain_List_Report = "~/Main/Admin/ShopDoMain_List_Report.aspx";
	protected HtmlLink sizestylesheet;
	protected Label Label5;
	protected System.Web.UI.WebControls.DropDownList DropDownListSubstationID;
	protected Label LabelSMemLoginID;
	protected System.Web.UI.WebControls.TextBox TextBoxMemLoginID;
	protected Label Label4;
	protected System.Web.UI.WebControls.DropDownList DropDownListIsAudit;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected LinkButton ButtonReportexl;
	protected LinkButton ButtonReporthtl;
	protected LinkButton ButtonIsAudit1;
	protected LinkButton ButtonIsAudit0;
	protected LinkButton ButtonDelete;
	protected MessageShow MessageShow;
	protected System.Web.UI.WebControls.RadioButtonList RadioButtonListOutPage;
	protected Num1GridView num1GridViewShow;
	protected ObjectDataSource ObjectDataSourceData;
	protected HiddenField CheckGuid;
	protected HiddenField hiddenFieldGuid;
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
			this.GetSubstationID();
			this.method_5();
			this.BindGrid();
		}
	}
	public string GetSubstationIDname(string SubstationID)
	{
		ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_SubstationManage_Action();
		DataTable dataBySubstationID = shopNum1_SubstationManage_Action.GetDataBySubstationID(SubstationID);
		string result;
		if (dataBySubstationID != null && dataBySubstationID.Rows.Count > 0)
		{
			result = dataBySubstationID.Rows[0]["Name"].ToString();
		}
		else
		{
			result = "分站不存在";
		}
		return result;
	}
	public void GetSubstationID()
	{
		this.DropDownListSubstationID.Items.Clear();
		this.DropDownListSubstationID.Items.Add(new ListItem("-请选择-", "-1"));
		ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_SubstationManage_Action();
		DataTable dataTable = shopNum1_SubstationManage_Action.Search(0);
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			foreach (DataRow dataRow in dataTable.Rows)
			{
				this.DropDownListSubstationID.Items.Add(new ListItem(dataRow["Name"].ToString(), dataRow["SubstationID"].ToString()));
			}
		}
	}
	private void method_5()
	{
		this.DropDownListIsAudit.Items.Add(new ListItem("-全部-", "-2"));
		this.DropDownListIsAudit.Items.Add(new ListItem("审核未通过", "2"));
		this.DropDownListIsAudit.Items.Add(new ListItem("未审核", "0"));
	}
	protected void BindGrid()
	{
		this.num1GridViewShow.DataBind();
	}
	public void BindShopLoginID()
	{
		ShopNum1_ShopURLManage_Action shopNum1_ShopURLManage_Action = (ShopNum1_ShopURLManage_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopURLManage_Action();
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
		ShopNum1_ShopURLManage_Action shopNum1_ShopURLManage_Action = (ShopNum1_ShopURLManage_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopURLManage_Action();
		int num = shopNum1_ShopURLManage_Action.Delete(this.CheckGuid.Value.ToString());
		if (num > 0)
		{
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
		LinkButton linkButton = (LinkButton)sender;
		string strID = "'" + linkButton.CommandArgument + "'";
		ShopNum1_ShopURLManage_Action shopNum1_ShopURLManage_Action = (ShopNum1_ShopURLManage_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopURLManage_Action();
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
		else if (strIsAudit == "2")
		{
			result = "审核未通过";
		}
		else
		{
			result = "非法状态";
		}
		return result;
	}
	protected void ButtonIsAudit1_Click(object sender, EventArgs e)
	{
		ShopNum1_ShopURLManage_Action shopNum1_ShopURLManage_Action = (ShopNum1_ShopURLManage_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopURLManage_Action();
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
		ShopNum1_ShopURLManage_Action shopNum1_ShopURLManage_Action = (ShopNum1_ShopURLManage_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopURLManage_Action();
		int num = shopNum1_ShopURLManage_Action.UpdateIsAudit(this.CheckGuid.Value.Replace("'", ""), "2");
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