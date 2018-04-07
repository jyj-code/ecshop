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
public class Admin_ApplyAdvertisement_List : PageBase, IRequiresSessionState
{
	protected HtmlHead Head1;
	protected ObjectDataSource ObjectDataSourceXml;
	protected System.Web.UI.WebControls.TextBox TextBoxPageName;
	protected System.Web.UI.WebControls.DropDownList DropDownListSubstationID;
	protected System.Web.UI.WebControls.DropDownList DropDownListFileName;
	protected System.Web.UI.WebControls.DropDownList DropDownListIsExamine;
	protected System.Web.UI.WebControls.Button ButtonGet;
	protected LinkButton ButtonIsExamine;
	protected LinkButton LinkButtonIsCancel;
	protected LinkButton LinkButtonRun;
	protected LinkButton ButtonDelete;
	protected MessageShow MessageShow;
	protected Num1GridView Num1GridViewShow;
	protected HiddenField CheckGuid;
	protected HiddenField HiddenFieldCode;
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
		this.HiddenFieldSubstationID.Value = base.SubstationID;
		string value = "0";
		if (base.SubstationID != "all")
		{
			ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)LogicFactory.CreateShopNum1_SubstationManage_Action();
			DataTable dataBySubstationID = shopNum1_SubstationManage_Action.GetDataBySubstationID(base.SubstationID);
			if (dataBySubstationID != null && dataBySubstationID.Rows.Count > 0)
			{
				value = dataBySubstationID.Rows[0]["CityCode"].ToString();
			}
		}
		this.HiddenFieldCode.Value = value;
		if (!this.Page.IsPostBack)
		{
			this.GetAdId();
			this.GetSubstationID();
			this.BindGrid();
		}
	}
	public void GetAdId()
	{
		DefaultAdvertPayOperateNoPath defaultAdvertPayOperateNoPath = new DefaultAdvertPayOperateNoPath();
		try
		{
			if (base.SubstationID == "all")
			{
				defaultAdvertPayOperateNoPath.Path = "~/Main/Themes/Skin_Default/Xml/PayAdImage.xml";
			}
			else
			{
				defaultAdvertPayOperateNoPath.Path = "~/City/" + base.SubstationID + "/Themes/Skin_Default/Xml/PayAdImage.xml";
			}
			this.DropDownListFileName.Items.Clear();
			this.DropDownListFileName.Items.Add(new ListItem("-请选择-", "-1"));
			DataTable xmlDataTable = defaultAdvertPayOperateNoPath.GetXmlDataTable();
			if (xmlDataTable != null && xmlDataTable.Rows.Count > 0)
			{
				foreach (DataRow dataRow in xmlDataTable.Rows)
				{
					this.DropDownListFileName.Items.Add(new ListItem(dataRow["title"].ToString(), dataRow["id"].ToString()));
				}
			}
		}
		catch (Exception)
		{
		}
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
		this.DropDownListSubstationID.Items.Add(new ListItem("-请选择-", "-1"));
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
	public void BindXML()
	{
		DataTable xmlDataTable = new DefaultAdvertPayOperateNoPath
		{
			Path = "~/Main/Themes/Skin_Default/Xml/PayAdImage.xml"
		}.GetXmlDataTable();
		this.DropDownListFileName.Items.Clear();
		this.DropDownListFileName.Items.Add(new ListItem("-请选择-", "-1"));
		if (xmlDataTable != null && xmlDataTable.Rows.Count > 0)
		{
			foreach (DataRow dataRow in xmlDataTable.Rows)
			{
				this.DropDownListFileName.Items.Add(new ListItem(dataRow["title"].ToString(), dataRow["id"].ToString()));
			}
		}
	}
	public void BindXML(string SubstationID)
	{
		DefaultAdvertPayOperateNoPath defaultAdvertPayOperateNoPath = new DefaultAdvertPayOperateNoPath();
		if (SubstationID == "all")
		{
			defaultAdvertPayOperateNoPath.Path = "~/Main/Themes/Skin_Default/Xml/PayAdImage.xml";
		}
		else
		{
			defaultAdvertPayOperateNoPath.Path = "~/City/" + SubstationID + "/Themes/Skin_Default/Xml/PayAdImage.xml";
		}
		DataTable xmlDataTable = defaultAdvertPayOperateNoPath.GetXmlDataTable();
		this.DropDownListFileName.Items.Clear();
		this.DropDownListFileName.Items.Add(new ListItem("-请选择-", "-1"));
		if (xmlDataTable != null && xmlDataTable.Rows.Count > 0)
		{
			foreach (DataRow dataRow in xmlDataTable.Rows)
			{
				this.DropDownListFileName.Items.Add(new ListItem(dataRow["title"].ToString(), dataRow["id"].ToString()));
			}
		}
	}
	protected void ButtonEdit_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("PayAdvertisementImg_Operate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		ShopNum1_AdvertPay_Action shopNum1_AdvertPay_Action = (ShopNum1_AdvertPay_Action)LogicFactory.CreateShopNum1_AdvertPay_Action();
		DataTable dataTable = shopNum1_AdvertPay_Action.SearchAll(this.CheckGuid.Value);
		if (dataTable != null && dataTable.Rows.Count > 0 && dataTable.Rows[0]["IsCancel"].ToString() == "0")
		{
			MessageBox.Show("没有撤销的数据，不能直接删除的！");
		}
		else
		{
			int num = shopNum1_AdvertPay_Action.ChangeIsDeleted(this.CheckGuid.Value, 1);
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
	public string IsTypes(string type)
	{
		string result;
		if (type == "1")
		{
			result = "单图";
		}
		else if (type == "2")
		{
			result = "幻灯片";
		}
		else
		{
			result = "";
		}
		return result;
	}
	public string CheckTime(string IsExamine, string ModifyTime)
	{
		string result;
		if (IsExamine == "1")
		{
			result = ModifyTime;
		}
		else
		{
			result = "未审核";
		}
		return result;
	}
	protected void ButtonGet_Click(object sender, EventArgs e)
	{
		this.BindGrid();
	}
	protected void ButtonIsExamine_Click(object sender, EventArgs e)
	{
		this.Page.Response.Redirect("ApplyAdvertisement_Operate.aspx?guid=" + this.CheckGuid.Value);
	}
	protected void LinkButtonIsCancel_Click(object sender, EventArgs e)
	{
		string[] array = this.CheckGuid.Value.Split(new char[]
		{
			','
		});
		if (array.Length > 1)
		{
			MessageBox.Show("每次只能撤销一个！");
		}
		else
		{
			ShopNum1_AdvertPay_Action shopNum1_AdvertPay_Action = (ShopNum1_AdvertPay_Action)LogicFactory.CreateShopNum1_AdvertPay_Action();
			DataTable dataTable = shopNum1_AdvertPay_Action.SearchAll(this.CheckGuid.Value);
			int num = 0;
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				num = Convert.ToInt32(dataTable.Rows[0]["IsCancel"].ToString());
			}
			if (num == 1)
			{
				MessageBox.Show("该数据已经被撤销了，请勿重复操作！");
			}
			else
			{
				int num2 = shopNum1_AdvertPay_Action.IsCancel(this.CheckGuid.Value, 1);
				if (num2 > 0)
				{
					MessageBox.Show("该数据撤销成功");
					this.SendMsg();
					this.BindGrid();
				}
			}
		}
	}
	public void SendMsg()
	{
		ShopNum1_AdvertPay_Action shopNum1_AdvertPay_Action = (ShopNum1_AdvertPay_Action)LogicFactory.CreateShopNum1_AdvertPay_Action();
		DataTable dataTable = shopNum1_AdvertPay_Action.SearchAll(this.CheckGuid.Value);
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)LogicFactory.CreateShopNum1_SubstationManage_Action();
			if (dataTable.Rows[0]["SubstationID"].ToString() != "all")
			{
				DataTable dataBySubstationID = shopNum1_SubstationManage_Action.GetDataBySubstationID(dataTable.Rows[0]["SubstationID"].ToString());
				if (dataBySubstationID != null && dataBySubstationID.Rows.Count > 0)
				{
					dataBySubstationID.Rows[0]["Name"].ToString();
				}
			}
		}
	}
	protected void LinkButtonRun_Click(object sender, EventArgs e)
	{
		ShopNum1_AdvertPay_Action shopNum1_AdvertPay_Action = (ShopNum1_AdvertPay_Action)LogicFactory.CreateShopNum1_AdvertPay_Action();
		DataTable dataTable = shopNum1_AdvertPay_Action.SearchAll(this.CheckGuid.Value);
		if (dataTable != null && dataTable.Rows.Count > 0 && dataTable.Rows[0]["IsCancel"].ToString() == "0")
		{
			MessageBox.Show("没有撤销的数据，不能启用！");
		}
		else
		{
			this.Page.Response.Redirect("UpdateApplyAdvertisement_Operate.aspx?guid=" + this.CheckGuid.Value);
		}
	}
	protected void DropDownListSubstationID_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.DropDownListSubstationID.SelectedValue != "-1")
		{
			this.BindXML(this.DropDownListSubstationID.SelectedValue);
		}
		else
		{
			this.DropDownListFileName.Items.Clear();
			this.DropDownListFileName.Items.Add(new ListItem("-请选择-", "-1"));
		}
	}
}
