using AjaxControlToolkit;
using ShopNum1.BusinessLogic;
using ShopNum1.CityFactory;
using ShopNum1.Common;
using ShopNum1.Control;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_MainAdmin_ShopProductComment_List : PageBase, IRequiresSessionState
{
	protected HtmlLink sizestylesheet;
	protected ScriptManager ScriptManager1;
	protected Localize LocalizeTitle;
	protected System.Web.UI.WebControls.TextBox TextBoxTitle;
	protected Localize LocalizeProductName;
	protected System.Web.UI.WebControls.TextBox TextBoxProductName;
	protected Localize LocalizeCreateMember;
	protected System.Web.UI.WebControls.TextBox TextBoxCreateMerber;
	protected Localize LocalizeShopID;
	protected System.Web.UI.WebControls.TextBox TextBoxShopID;
	protected System.Web.UI.WebControls.DropDownList DropDownListSubstationID;
	protected Localize LocalizeCreateTime;
	protected System.Web.UI.WebControls.TextBox TextBoxTime1;
	protected CalendarExtender CalendarExtender4;
	protected RegularExpressionValidator RegularExpressionValidatorTextBoxTime1;
	protected System.Web.UI.WebControls.TextBox TextBoxTime2;
	protected CalendarExtender CalendarExtender1;
	protected RegularExpressionValidator RegularExpressionValidator1;
	protected System.Web.UI.WebControls.Button ButtonSearch;
	protected System.Web.UI.WebControls.DropDownList DropDownListIsAudit;
	protected System.Web.UI.WebControls.Button ButtonSearchDetail;
	protected System.Web.UI.WebControls.Button ButtonAudit;
	protected System.Web.UI.WebControls.Button ButtonCancelAudit;
	protected LinkButton ButtonDelete;
	protected MessageShow MessageShow;
	protected Num1GridView Num1GridViewShow;
	protected ObjectDataSource ObjectDataSourceDate;
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
		if (!base.IsPostBack)
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
	protected void BindGrid()
	{
		this.Num1GridViewShow.DataBind();
	}
	private void method_5()
	{
		ListItem listItem = new ListItem();
		listItem.Text = "已审核";
		listItem.Value = "1";
		this.DropDownListIsAudit.Items.Add(listItem);
	}
	protected void ButtonSearch_Click(object sender, EventArgs e)
	{
		this.BindGrid();
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_ProductComment_Action shopNum1_ProductComment_Action = (ShopNum1_ProductComment_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ProductComment_Action();
		if (shopNum1_ProductComment_Action.DeleteProduct(this.CheckGuid.Value.ToString()) > 0)
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
		string guids = "'" + linkButton.CommandArgument + "'";
		ShopNum1_ProductComment_Action shopNum1_ProductComment_Action = (ShopNum1_ProductComment_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ProductComment_Action();
		if (shopNum1_ProductComment_Action.DeleteProduct(guids) > 0)
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
	protected void ButtonAudit_Click(object sender, EventArgs e)
	{
		try
		{
			ShopNum1_ProductComment_Action shopNum1_ProductComment_Action = (ShopNum1_ProductComment_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ProductComment_Action();
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopInfoList_Action();
			DataTable commentTypeByGuid = shopNum1_ProductComment_Action.GetCommentTypeByGuid(this.CheckGuid.Value);
			string s = (ShopSettings.GetValue("GoodAppraiseReputation") == string.Empty) ? "0" : ShopSettings.GetValue("GoodAppraiseReputation");
			string s2 = (ShopSettings.GetValue("StandardAppraiseReputation") == string.Empty) ? "0" : ShopSettings.GetValue("StandardAppraiseReputation");
			string s3 = (ShopSettings.GetValue("BadAppraiseReputation") == string.Empty) ? "0" : ShopSettings.GetValue("BadAppraiseReputation");
			int score = 0;
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
			int rankscore = (ShopSettings.GetValue("MyMessageRankSorce") == string.Empty) ? 0 : int.Parse(ShopSettings.GetValue("MyMessageRankSorce"));
			int score2 = (ShopSettings.GetValue("MyMessageSorce") == string.Empty) ? 0 : int.Parse(ShopSettings.GetValue("MyMessageSorce"));
			for (int i = 0; i < commentTypeByGuid.Rows.Count; i++)
			{
				if (!(commentTypeByGuid.Rows[i]["IsAudit"].ToString() == "1"))
				{
					if (commentTypeByGuid.Rows[i]["CommentType"].ToString() == "0")
					{
						score = int.Parse(s);
					}
					else if (commentTypeByGuid.Rows[i]["CommentType"].ToString() == "1")
					{
						score = int.Parse(s2);
					}
					else if (commentTypeByGuid.Rows[i]["CommentType"].ToString() == "2")
					{
						score = int.Parse(s3);
					}
					shopNum1_ShopInfoList_Action.UpdateShopReputationByMemLoginID(commentTypeByGuid.Rows[i]["ShopID"].ToString(), score);
					shopNum1_Member_Action.UpdateMemberScore(commentTypeByGuid.Rows[i]["MemLoginID"].ToString(), rankscore, score2);
				}
			}
			if (shopNum1_ProductComment_Action.UpdateProductAudit(this.CheckGuid.Value, "1") > 0)
			{
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
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}
	protected void ButtonCancelAudit_Click(object sender, EventArgs e)
	{
		ShopNum1_ProductComment_Action shopNum1_ProductComment_Action = (ShopNum1_ProductComment_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ProductComment_Action();
		if (shopNum1_ProductComment_Action.UpdateProductAudit(this.CheckGuid.Value, "0") > 0)
		{
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
	public string Is(object object_0)
	{
		string result;
		if (object_0.ToString() == "1")
		{
			result = "已审核";
		}
		else if (object_0.ToString() == "0")
		{
			result = "未审核";
		}
		else if (object_0.ToString() == "2")
		{
			result = "审核未通过";
		}
		else
		{
			result = "非法状态";
		}
		return result;
	}
	protected void ButtonSearchDetail_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ShopProductComment_Detail.aspx?Guid=" + this.CheckGuid.Value.ToString() + "&Type=List");
	}
}
