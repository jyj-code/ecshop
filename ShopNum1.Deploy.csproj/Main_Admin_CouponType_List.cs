using ShopNum1.Common;
using ShopNum1.Control;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public class Main_Admin_CouponType_List : PageBase, IRequiresSessionState
{
	protected LinkButton ButtonAdd;
	protected LinkButton ButtonDelete;
	protected MessageShow MessageShow;
	protected Num1GridView num1GridViewShow;
	protected ObjectDataSource ObjectDataSourceData;
	protected HiddenField CheckGuid;
	protected HtmlForm form1;
	public string strid = "-1";
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
			this.BindGrid();
		}
	}
	protected void BindGrid()
	{
		this.num1GridViewShow.DataBind();
	}
	protected void ButtonAdd_Click(object sender, EventArgs e)
	{
		this.CheckGuid.Value = "0";
		base.Response.Redirect("CouponType_Operate.aspx?ID=" + this.CheckGuid.Value);
	}
	protected void ButtonDelete_Click(object sender, EventArgs e)
	{
		string[] array = this.CheckGuid.Value.Split(new char[]
		{
			','
		});
		for (int i = 0; i < array.Length; i++)
		{
			string nameById = Common.GetNameById("Guid", "ShopNum1_Shop_Coupon", "   AND  Type=" + array[i].ToString());
			if (!string.IsNullOrEmpty(nameById))
			{
				MessageBox.Show("请首先删除含有分类的优惠券！");
				return;
			}
		}
		Shop_CouponType_Action shop_CouponType_Action = (Shop_CouponType_Action)LogicFactory.CreateShop_CouponType_Action();
		int num = shop_CouponType_Action.Delete(this.CheckGuid.Value.Replace("'", ""));
		if (num > 0)
		{
			base.OperateLog(new ShopNum1_OperateLog
			{
				Record = "删除成功",
				OperatorID = base.ShopNum1LoginID,
				IP = Globals.IPAddress,
				PageName = "AttachMentCateGory_Operate.aspx",
				Date = DateTime.Now
			});
			this.BindGrid();
			this.MessageShow.ShowMessage("DelYes");
			this.MessageShow.Visible = true;
			return;
		}
		this.MessageShow.ShowMessage("DelNo");
		this.MessageShow.Visible = true;
	}
	protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
	{
		Shop_CouponType_Action shop_CouponType_Action = (Shop_CouponType_Action)LogicFactory.CreateShop_CouponType_Action();
		LinkButton linkButton = (LinkButton)sender;
		string commandArgument = linkButton.CommandArgument;
		string nameById = Common.GetNameById("Guid", "ShopNum1_Shop_Coupon", "   AND  Type='" + commandArgument + "' ");
		if (!string.IsNullOrEmpty(nameById))
		{
			MessageBox.Show("请首先删除含有分类的优惠券！");
		}
		else
		{
			int num = shop_CouponType_Action.Delete("'" + commandArgument + "'");
			if (num > 0)
			{
				base.OperateLog(new ShopNum1_OperateLog
				{
					Record = "删除成功",
					OperatorID = base.ShopNum1LoginID,
					IP = Globals.IPAddress,
					PageName = "AttachMentCateGory_Operate.aspx",
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
	}
	protected void ButtonEdit_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("CouponType_Operate.aspx?ID=" + this.CheckGuid.Value);
	}
	public string GetRight(string isshow)
	{
		string result;
		if (isshow == "1")
		{
			result = "images/shopNum1Admin-right.gif";
		}
		else
		{
			result = "images/shopNum1Admin-wrong.gif";
		}
		return result;
	}
}
