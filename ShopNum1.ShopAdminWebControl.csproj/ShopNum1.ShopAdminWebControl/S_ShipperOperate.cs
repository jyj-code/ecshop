using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_ShipperOperate : BaseShopWebControl
	{
		private TextBox textBox_0;
		private TextBox textBox_1;
		private TextBox textBox_2;
		private TextBox textBox_3;
		private TextBox textBox_4;
		private TextBox textBox_5;
		private TextBox textBox_6;
		private DropDownList dropDownList_0;
		private DropDownList dropDownList_1;
		private DropDownList dropDownList_2;
		private CheckBox checkBox_0;
		private HiddenField hiddenField_0;
		private Label label_0;
		private Button button_0;
		private IShopNum1_Shipper_Action ishopNum1_Shipper_Action_0 = new ShopNum1_Shipper_Action();
		private string string_0;
		private string string_1;
		private string string_2;
		public S_ShipperOperate()
		{
			if (string.IsNullOrEmpty(base.SkinFilename))
			{
				base.SkinFilename = "S_ShipperOperate.ascx";
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.method_1(skin);
			this.hiddenField_0.Value = ((this.Page.Request.QueryString["Guid"] == null) ? "0" : this.Page.Request.QueryString["Guid"]);
			this.DropDownListDispatchRegionCode1Bind();
			if (this.hiddenField_0.Value != "0")
			{
				this.method_0();
			}
		}
		protected void DropDownListDispatchRegionCode1Bind()
		{
			this.dropDownList_0.Items.Clear();
			this.dropDownList_0.Items.Add(new ListItem("请选择", "-1"));
			this.method_2("0", this.dropDownList_0);
			this.dropDownList_0_SelectedIndexChanged(null, null);
		}
		public void ShowCode(string regionCode)
		{
			if (regionCode.Length >= 3)
			{
				foreach (ListItem listItem in this.dropDownList_0.Items)
				{
					if (listItem.Value.StartsWith(regionCode.Substring(0, 3).ToString() + "/"))
					{
						this.dropDownList_0.SelectedValue = listItem.Value;
						this.dropDownList_0_SelectedIndexChanged(null, null);
					}
				}
			}
			if (regionCode.Length >= 6)
			{
				foreach (ListItem listItem in this.dropDownList_1.Items)
				{
					if (listItem.Value.StartsWith(regionCode.Substring(0, 6).ToString() + "/"))
					{
						this.dropDownList_1.SelectedValue = listItem.Value;
						this.dropDownList_1_SelectedIndexChanged(null, null);
					}
				}
			}
			if (regionCode.Length >= 9)
			{
				foreach (ListItem listItem in this.dropDownList_2.Items)
				{
					if (listItem.Value.StartsWith(regionCode.ToString() + "/"))
					{
						this.dropDownList_2.SelectedValue = listItem.Value;
						this.dropDownList_2_SelectedIndexChanged(null, null);
					}
				}
			}
		}
		private void method_0()
		{
			DataTable editInfo = this.ishopNum1_Shipper_Action_0.GetEditInfo(this.hiddenField_0.Value.ToString());
			this.textBox_0.Text = editInfo.Rows[0]["ShipperName"].ToString();
			this.textBox_1.Text = editInfo.Rows[0]["SendName"].ToString();
			this.textBox_2.Text = editInfo.Rows[0]["Address"].ToString();
			this.textBox_3.Text = editInfo.Rows[0]["Mobile"].ToString();
			this.textBox_4.Text = editInfo.Rows[0]["Phone"].ToString();
			this.textBox_5.Text = editInfo.Rows[0]["PostalCode"].ToString();
			this.ShowCode(editInfo.Rows[0]["RegionCode"].ToString());
			if (editInfo.Rows[0]["IsDefault"].ToString() == "0")
			{
				this.checkBox_0.Checked = false;
			}
			else
			{
				this.checkBox_0.Checked = true;
			}
			this.textBox_6.Text = editInfo.Rows[0]["Remark"].ToString();
			this.button_0.Text = "更新";
			this.button_0.ToolTip = "Update";
			this.label_0.Text = "编辑发货信息";
		}
		private void method_1(Control control_0)
		{
			this.textBox_0 = (control_0.FindControl("TextBoxShipperName") as TextBox);
			this.textBox_1 = (control_0.FindControl("TextBoxSendName") as TextBox);
			this.textBox_2 = (control_0.FindControl("TextBoxAddress") as TextBox);
			this.textBox_3 = (control_0.FindControl("TextBoxMobile") as TextBox);
			this.textBox_4 = (control_0.FindControl("TextBoxPhone") as TextBox);
			this.textBox_5 = (control_0.FindControl("TextBoxPostalCode") as TextBox);
			this.textBox_6 = (control_0.FindControl("TextBoxRemark") as TextBox);
			this.dropDownList_0 = (control_0.FindControl("DropDownListDispatchRegionCode1") as DropDownList);
			this.dropDownList_1 = (control_0.FindControl("DropDownListDispatchRegionCode2") as DropDownList);
			this.dropDownList_2 = (control_0.FindControl("DropDownListDispatchRegionCode3") as DropDownList);
			this.checkBox_0 = (control_0.FindControl("CheckBoxIsDefault") as CheckBox);
			this.button_0 = (control_0.FindControl("ButtonConfirm") as Button);
			this.hiddenField_0 = (control_0.FindControl("hiddenGuid") as HiddenField);
			this.label_0 = (control_0.FindControl("LabelPageTitle") as Label);
			this.dropDownList_0.SelectedIndexChanged += new EventHandler(this.dropDownList_0_SelectedIndexChanged);
			this.dropDownList_1.SelectedIndexChanged += new EventHandler(this.dropDownList_1_SelectedIndexChanged);
			this.dropDownList_2.SelectedIndexChanged += new EventHandler(this.dropDownList_2_SelectedIndexChanged);
			this.button_0.Click += new EventHandler(this.button_0_Click);
		}
		public string GetDropDownListDispatchRegionCode()
		{
			string result;
			if (this.dropDownList_2.SelectedValue != "" && this.dropDownList_2.SelectedValue != "-1")
			{
				result = this.dropDownList_2.SelectedValue.Split(new char[]
				{
					'/'
				})[0];
			}
			else if (this.dropDownList_1.SelectedValue != "" && this.dropDownList_1.SelectedValue != "-1")
			{
				result = this.dropDownList_1.SelectedValue.Split(new char[]
				{
					'/'
				})[0];
			}
			else if (this.dropDownList_0.SelectedValue != "" && this.dropDownList_0.SelectedValue != "-1")
			{
				result = this.dropDownList_0.SelectedValue.Split(new char[]
				{
					'/'
				})[0];
			}
			else
			{
				result = "-1";
			}
			return result;
		}
		protected int OperateLog(ShopNum1_OperateLog operateLog)
		{
			ShopNum1_OperateLog_Action shopNum1_OperateLog_Action = (ShopNum1_OperateLog_Action)LogicFactory.CreateShopNum1_OperateLog_Action();
			return shopNum1_OperateLog_Action.Add(operateLog);
		}
		public void GetAddress(string level)
		{
			if (level != null)
			{
				if (!(level == "1"))
				{
					if (!(level == "2"))
					{
						if (level == "3")
						{
							this.string_2 = this.dropDownList_0.SelectedItem.Text + this.dropDownList_1.SelectedItem.Text + this.dropDownList_2.SelectedItem.Text;
						}
					}
					else
					{
						this.string_1 = this.dropDownList_0.SelectedItem.Text + this.dropDownList_1.SelectedItem.Text;
					}
				}
				else
				{
					this.string_0 = this.dropDownList_0.SelectedItem.Text;
				}
			}
		}
		private void method_2(string string_3, DropDownList dropDownList_3)
		{
			ShopNum1_DispatchRegion_Action shopNum1_DispatchRegion_Action = (ShopNum1_DispatchRegion_Action)LogicFactory.CreateShopNum1_DispatchRegion_Action();
			shopNum1_DispatchRegion_Action.TableName = "ShopNum1_DispatchRegion";
			DataTable dispatchRegionName = shopNum1_DispatchRegion_Action.GetDispatchRegionName(string_3);
			for (int i = 0; i < dispatchRegionName.Rows.Count; i++)
			{
				if (!(string_3 == "0") || !(dispatchRegionName.Rows[i]["Name"].ToString().Trim() == "所有地区"))
				{
					dropDownList_3.Items.Add(new ListItem(dispatchRegionName.Rows[i]["Name"].ToString(), dispatchRegionName.Rows[i]["Code"].ToString() + "/" + dispatchRegionName.Rows[i]["ID"].ToString()));
				}
			}
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			if (this.button_0.ToolTip == "Submit")
			{
				ShopNum1_Shipper shopNum1_Shipper = new ShopNum1_Shipper();
				shopNum1_Shipper.Guid = Guid.NewGuid();
				shopNum1_Shipper.ShipperName = this.textBox_0.Text;
				shopNum1_Shipper.SendName = this.textBox_1.Text;
				shopNum1_Shipper.Address = this.textBox_2.Text;
				shopNum1_Shipper.Mobile = this.textBox_3.Text;
				shopNum1_Shipper.Phone = this.textBox_4.Text;
				shopNum1_Shipper.PostalCode = this.textBox_5.Text;
				shopNum1_Shipper.Remark = this.textBox_6.Text;
				shopNum1_Shipper.CreateUser = this.MemLoginID;
				shopNum1_Shipper.CreateTime = DateTime.Now;
				shopNum1_Shipper.ModifyUser = this.MemLoginID;
				shopNum1_Shipper.ModifyTime = DateTime.Now.ToString();
				shopNum1_Shipper.RegionCode = this.GetDropDownListDispatchRegionCode();
				HttpCookie httpCookie = HttpSecureCookie.Decode(this.Page.Request.Cookies["MemberLoginCookie"]);
				shopNum1_Shipper.ShopId = httpCookie.Values["shopid"];
				if (this.checkBox_0.Checked)
				{
					shopNum1_Shipper.IsDefault = 1;
				}
				else
				{
					shopNum1_Shipper.IsDefault = 0;
				}
				int num = this.ishopNum1_Shipper_Action_0.Insert(shopNum1_Shipper);
				if (num > 0)
				{
					this.OperateLog(new ShopNum1_OperateLog
					{
						Record = "新增" + this.textBox_0.Text.Trim() + "成功",
						OperatorID = this.MemLoginID,
						IP = Globals.IPAddress,
						PageName = "OrderShipper_Operate.aspx",
						Date = DateTime.Now
					});
					this.Page.Response.Redirect("S_OrderShipper_List.aspx");
				}
				else
				{
					MessageBox.Show("添加失败");
				}
			}
			else if (this.button_0.ToolTip == "Update")
			{
				ShopNum1_Shipper shopNum1_Shipper = new ShopNum1_Shipper();
				shopNum1_Shipper.Guid = new Guid(this.hiddenField_0.Value.Replace("'", ""));
				shopNum1_Shipper.ShipperName = this.textBox_0.Text;
				shopNum1_Shipper.SendName = this.textBox_1.Text;
				shopNum1_Shipper.Address = this.textBox_2.Text;
				shopNum1_Shipper.Mobile = this.textBox_3.Text;
				shopNum1_Shipper.Phone = this.textBox_4.Text;
				shopNum1_Shipper.PostalCode = this.textBox_5.Text;
				shopNum1_Shipper.Remark = this.textBox_6.Text;
				shopNum1_Shipper.ModifyUser = this.MemLoginID;
				shopNum1_Shipper.ModifyTime = DateTime.Now.ToString();
				shopNum1_Shipper.RegionCode = this.GetDropDownListDispatchRegionCode();
				if (this.checkBox_0.Checked)
				{
					shopNum1_Shipper.IsDefault = 1;
				}
				else
				{
					shopNum1_Shipper.IsDefault = 0;
				}
				int num = this.ishopNum1_Shipper_Action_0.Update(shopNum1_Shipper);
				if (num > 0)
				{
					this.OperateLog(new ShopNum1_OperateLog
					{
						Record = "编辑" + this.textBox_0.Text.Trim() + "成功",
						OperatorID = this.MemLoginID,
						IP = Globals.IPAddress,
						PageName = "OrderShipper_Operate.aspx",
						Date = DateTime.Now
					});
					this.Page.Response.Redirect("S_OrderShipper_List.aspx");
				}
				else
				{
					MessageBox.Show("更新失败!");
				}
			}
		}
		private void dropDownList_2_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.GetAddress("3");
		}
		private void dropDownList_1_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.dropDownList_2.Visible = false;
			ShopSettings.GetValue("AgentRegionLevel");
			if (this.dropDownList_1.SelectedValue != "-1")
			{
				ShopNum1_DispatchRegion_Action shopNum1_DispatchRegion_Action = (ShopNum1_DispatchRegion_Action)LogicFactory.CreateShopNum1_DispatchRegion_Action();
				shopNum1_DispatchRegion_Action.TableName = "ShopNum1_DispatchRegion";
				DataTable dispatchRegionName = shopNum1_DispatchRegion_Action.GetDispatchRegionName(this.dropDownList_1.SelectedValue.Split(new char[]
				{
					'/'
				})[1]);
				if (dispatchRegionName != null && dispatchRegionName.Rows.Count != 0)
				{
					this.dropDownList_2.Visible = true;
					this.dropDownList_2.Items.Clear();
					this.dropDownList_2.Items.Add(new ListItem("请选择", "-1"));
					this.method_2(this.dropDownList_1.SelectedValue.Split(new char[]
					{
						'/'
					})[1], this.dropDownList_2);
					this.dropDownList_2_SelectedIndexChanged(null, null);
				}
			}
			this.GetAddress("2");
		}
		private void dropDownList_0_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.dropDownList_1.Visible = false;
			this.dropDownList_2.Visible = false;
			if (this.dropDownList_0.SelectedValue != "-1")
			{
				ShopNum1_DispatchRegion_Action shopNum1_DispatchRegion_Action = (ShopNum1_DispatchRegion_Action)LogicFactory.CreateShopNum1_DispatchRegion_Action();
				shopNum1_DispatchRegion_Action.TableName = "ShopNum1_DispatchRegion";
				DataTable dispatchRegionName = shopNum1_DispatchRegion_Action.GetDispatchRegionName(this.dropDownList_0.SelectedValue.Split(new char[]
				{
					'/'
				})[1]);
				if (dispatchRegionName != null && dispatchRegionName.Rows.Count != 0)
				{
					this.dropDownList_1.Visible = true;
					this.dropDownList_1.Items.Clear();
					this.dropDownList_1.Items.Add(new ListItem("请选择", "-1"));
					this.method_2(this.dropDownList_0.SelectedValue.Split(new char[]
					{
						'/'
					})[1], this.dropDownList_1);
					this.dropDownList_1_SelectedIndexChanged(null, null);
				}
			}
			this.GetAddress("1");
		}
	}
}
