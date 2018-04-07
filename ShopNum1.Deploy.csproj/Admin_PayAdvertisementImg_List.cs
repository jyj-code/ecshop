using ShopNum1.AdXml;
using ShopNum1.BusinessLogic;
using ShopNum1.CityFactory;
using ShopNum1.Common;
using ShopNum1.Control;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Admin_PayAdvertisementImg_List : PageBase, IRequiresSessionState
{
	private DefaultAdvertPayOperate defaultAdvertPayOperate_0 = new DefaultAdvertPayOperate();
	protected HtmlHead Head1;
	protected ObjectDataSource ObjectDataSourceXml;
	protected System.Web.UI.WebControls.DropDownList DropDownListSubstationID;
	protected LinkButton ButtonAdd;
	protected System.Web.UI.WebControls.Button ButtonEdit;
	protected LinkButton LinkButtonRun;
	protected LinkButton LinkButtonRunNo;
	protected LinkButton ButtonDelete;
	protected MessageShow MessageShow;
	protected Num1GridView Num1GridViewShow;
	protected HiddenField CheckGuid;
	protected HiddenField HiddenFieldSubstationID;
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
		this.defaultAdvertPayOperate_0.SubstationID = base.SubstationID;
		this.HiddenFieldSubstationID.Value = base.SubstationID;
		if (!this.Page.IsPostBack)
		{
			this.GetSubstationID();
			this.BindGrid();
		}
	}
	public string GetSelectSub()
	{
		return this.DropDownListSubstationID.SelectedValue;
	}
	public string GetSubName(string SubstationID)
	{
		string result;
		if (SubstationID == "all")
		{
			result = "全国站";
		}
		else
		{
			ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)LogicFactory.CreateShopNum1_SubstationManage_Action();
			DataTable dataBySubstationID = shopNum1_SubstationManage_Action.GetDataBySubstationID(SubstationID);
			if (dataBySubstationID != null && dataBySubstationID.Rows.Count > 0)
			{
				result = dataBySubstationID.Rows[0]["Name"].ToString();
			}
			else
			{
				result = "分站不存在或者已经被删除";
			}
		}
		return result;
	}
	public void GetSubstationID()
	{
		ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)LogicFactory.CreateShopNum1_SubstationManage_Action();
		DataTable dataTable = shopNum1_SubstationManage_Action.Search();
		this.DropDownListSubstationID.Items.Clear();
		this.DropDownListSubstationID.Items.Add(new ListItem("全国站", "all"));
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			foreach (DataRow dataRow in dataTable.Rows)
			{
				this.DropDownListSubstationID.Items.Add(new ListItem(dataRow["Name"].ToString(), dataRow["SubstationID"].ToString()));
			}
		}
	}
	public void BindGrid()
	{
		this.Num1GridViewShow.DataBind();
	}
	protected void ButtonAdd_Click(object sender, EventArgs e)
	{
		this.CheckGuid.Value = "0";
		base.Response.Redirect("PayAdvertisementImg_Operate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonEdit_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("PayAdvertisementImg_Operate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		if (!this.IsCanDelete(this.CheckGuid.Value))
		{
			MessageBox.Show("该广告位下存在广告，请删除相关广告后再次删除！");
		}
		else
		{
			int num = this.defaultAdvertPayOperate_0.Delete(this.CheckGuid.Value);
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
	}
	public bool IsCanDelete(string string_5)
	{
		ShopNum1_AdvertPay_Action shopNum1_AdvertPay_Action = (ShopNum1_AdvertPay_Action)LogicFactory.CreateShopNum1_AdvertPay_Action();
		DataTable dataTable = shopNum1_AdvertPay_Action.SearchNowDataIsDelete(string_5, base.SubstationID);
		return dataTable == null || dataTable.Rows.Count <= 0;
	}
	protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
	{
		if (!this.IsCanDelete(this.CheckGuid.Value))
		{
			MessageBox.Show("该广告位下存在广告，请删除相关广告后再次删除！");
		}
		else
		{
			LinkButton linkButton = (LinkButton)sender;
			string commandArgument = linkButton.CommandArgument;
			int num = this.defaultAdvertPayOperate_0.Delete(commandArgument);
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
	}
	protected void LinkButtonRun_Click(object sender, EventArgs e)
	{
		DefaultAdvertPayOperate defaultAdvertPayOperate = new DefaultAdvertPayOperate();
		defaultAdvertPayOperate.SubstationID = this.DropDownListSubstationID.SelectedValue;
		try
		{
			string value = this.CheckGuid.Value;
			string[] array = value.Split(new char[]
			{
				','
			});
			int num = 0;
			for (int i = 0; i < array.Length; i++)
			{
				int num2 = defaultAdvertPayOperate.UpdateRun(array[i].ToString(), "1");
				if (num2 > 0)
				{
					num++;
				}
			}
			MessageBox.Show(num.ToString() + "条数据启用成功");
			this.BindGrid();
		}
		catch (Exception)
		{
			MessageBox.Show("数据启用失败");
		}
	}
	protected void LinkButtonRunNo_Click(object sender, EventArgs e)
	{
		DefaultAdvertPayOperate defaultAdvertPayOperate = new DefaultAdvertPayOperate();
		defaultAdvertPayOperate.SubstationID = this.DropDownListSubstationID.SelectedValue;
		try
		{
			string value = this.CheckGuid.Value;
			string[] array = value.Split(new char[]
			{
				','
			});
			int num = 0;
			for (int i = 0; i < array.Length; i++)
			{
				int num2 = defaultAdvertPayOperate.UpdateRun(array[i].ToString(), "0");
				if (num2 > 0)
				{
					num++;
				}
			}
			MessageBox.Show(num.ToString() + "条数据禁用成功");
			this.BindGrid();
		}
		catch (Exception)
		{
			MessageBox.Show("数据启用失败");
		}
	}
}
