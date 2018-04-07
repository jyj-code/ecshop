using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_Test : PageBase, IRequiresSessionState
{
	protected HiddenField hfRptColumns;
	protected Repeater rptTest;
	protected Button btnAddNewRow;
	protected Button btnSave;
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
			this.BuildCart();
			this.method_5();
		}
	}
	private void method_5()
	{
		DataTable car = this.GetCar();
		this.rptTest.DataSource = car;
		this.rptTest.DataBind();
	}
	public void BuildCart()
	{
		if (HttpContext.Current.Session["order"] == null)
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("name");
			HttpContext.Current.Session["order"] = dataTable;
		}
	}
	protected void btnSave_Click(object sender, EventArgs e)
	{
		string text = string.Empty;
		foreach (RepeaterItem repeaterItem in this.rptTest.Items)
		{
			TextBox textBox = (TextBox)repeaterItem.FindControl("txtExpenseAmount");
			text += textBox.Text;
			this.AddCart(textBox.Text);
		}
		base.Response.Write(text);
		this.method_5();
	}
	public void AddCart(string name)
	{
		if (HttpContext.Current.Session["order"] == null)
		{
			this.BuildCart();
		}
		else
		{
			DataTable order = HttpContext.Current.Session["order"] as DataTable;
			if (this.ExistProduct(order, name))
			{
				this.UpdateSession(order, name);
			}
		}
	}
	public void Delete(string name)
	{
		if (HttpContext.Current.Session["order"] != null)
		{
			DataTable car = this.GetCar();
			for (int i = 0; i < car.Rows.Count; i++)
			{
				if (car.Rows[i]["name"].ToString() == name)
				{
					car.Rows[i].Delete();
				}
			}
			HttpContext.Current.Session["order"] = car;
		}
	}
	public bool ExistProduct(DataTable order, string name)
	{
		IEnumerator enumerator = order.Rows.GetEnumerator();
		bool result;
		try
		{
			if (enumerator.MoveNext())
			{
				DataRow dataRow = (DataRow)enumerator.Current;
				if (dataRow["name"].ToString().Equals(name))
				{
					result = false;
					return result;
				}
				result = true;
				return result;
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		result = true;
		return result;
	}
	public void UpdateSession(DataTable order, string strname)
	{
		DataRow dataRow = order.NewRow();
		dataRow[0] = strname;
		order.Rows.Add(dataRow);
		HttpContext.Current.Session["order"] = order;
	}
	public DataTable GetCar()
	{
		DataTable result;
		if (HttpContext.Current.Session["order"] != null)
		{
			DataTable dataTable = HttpContext.Current.Session["order"] as DataTable;
			result = dataTable;
		}
		else
		{
			result = null;
		}
		return result;
	}
	public DataTable DefineDataTableSchema(string columns)
	{
		DataTable dataTable = new DataTable();
		string[] array = columns.Split(new char[]
		{
			','
		});
		string[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			string columnName = array2[i];
			dataTable.Columns.Add(columnName);
		}
		return dataTable;
	}
	protected void btnAddNewRow_Click(object sender, EventArgs e)
	{
		DataTable dataTable = this.DefineDataTableSchema(this.hfRptColumns.Value);
		foreach (RepeaterItem repeaterItem in this.rptTest.Items)
		{
			DataRow dataRow = dataTable.NewRow();
			dataRow["name"] = ((TextBox)repeaterItem.FindControl("txtExpenseAmount")).Text;
			dataTable.Rows.Add(dataRow);
		}
		DataRow row = dataTable.NewRow();
		dataTable.Rows.Add(row);
		HttpContext.Current.Session["order"] = dataTable;
		this.rptTest.DataSource = dataTable;
		this.rptTest.DataBind();
	}
	protected void rptTest_OnItemCommand(object sender, RepeaterCommandEventArgs e)
	{
		if (e.CommandName == "del")
		{
			this.Delete(e.CommandArgument.ToString());
			this.method_5();
			base.Response.Write("<script>alert('" + e.CommandArgument + "');</script>");
		}
	}
}
