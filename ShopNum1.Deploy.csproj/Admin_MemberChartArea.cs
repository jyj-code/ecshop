using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
public class Admin_MemberChartArea : PageBase, IRequiresSessionState
{
	protected DataTable AreaTable = null;
	protected HtmlLink sizestylesheet;
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
		this.AreaTable = this.GetAreaTable();
	}
	protected DataTable GetAreaTable()
	{
		ShopNum1_DispatchRegion_Action shopNum1_DispatchRegion_Action = (ShopNum1_DispatchRegion_Action)LogicFactory.CreateShopNum1_DispatchRegion_Action();
		ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
		shopNum1_DispatchRegion_Action.TableName = "ShopNum1_Region";
		DataTable dataTable = shopNum1_DispatchRegion_Action.SearchtDispatchRegion(0, 0);
		DataTable dataTable2 = this.method_5();
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			foreach (DataRow dataRow in dataTable.Rows)
			{
				string code = dataRow["Code"].ToString();
				string value = shopNum1_Member_Action.GetMemberCountByCode(code, "0").ToString();
				string value2 = dataRow["Name"].ToString();
				string value3 = dataRow["ID"].ToString();
				DataRow dataRow2 = dataTable2.NewRow();
				dataRow2["regionname"] = value2;
				dataRow2["id"] = value3;
				dataRow2["membercount"] = value;
				dataTable2.Rows.Add(dataRow2);
			}
			string value4 = shopNum1_Member_Action.GetMemberCountByCode("0", "1").ToString();
			DataRow dataRow3 = dataTable2.NewRow();
			dataRow3["regionname"] = "其它";
			dataRow3["id"] = "1";
			dataRow3["membercount"] = value4;
			dataTable2.Rows.Add(dataRow3);
		}
		else
		{
			DataRow dataRow2 = dataTable2.NewRow();
			dataRow2["regionname"] = "全国";
			dataRow2["id"] = "1";
			dataRow2["membercount"] = "0";
			dataTable2.Rows.Add(dataRow2);
		}
		return dataTable2;
	}
	private DataTable method_5()
	{
		return new DataTable
		{
			Columns = 
			{

				{
					"regionname",
					typeof(string)
				},

				{
					"id",
					typeof(string)
				},

				{
					"membercount",
					typeof(string)
				}
			}
		};
	}
}
