using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1.ShopFeeTemplate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_LogisticsTemplateOperate : BaseShopWebControl
	{
		private string string_0 = "S_LogisticsTemplateOperate.ascx";
		private HtmlInputCheckBox htmlInputCheckBox_0;
		private HtmlInputCheckBox htmlInputCheckBox_1;
		private HtmlInputCheckBox htmlInputCheckBox_2;
		private HtmlInputText htmlInputText_0;
		private HtmlGenericControl htmlGenericControl_0;
		private Repeater repeater_0;
		private Repeater repeater_1;
		private Repeater repeater_2;
		private Button button_0;
		private HtmlInputHidden htmlInputHidden_0;
		private HtmlInputHidden htmlInputHidden_1;
		private HtmlInputHidden htmlInputHidden_2;
		private HtmlInputText htmlInputText_1;
		private HtmlInputText htmlInputText_2;
		private HtmlInputText htmlInputText_3;
		private HtmlInputText htmlInputText_4;
		private HtmlInputText htmlInputText_5;
		private HtmlInputText htmlInputText_6;
		private HtmlTableCell htmlTableCell_0;
		private HtmlTableCell htmlTableCell_1;
		private HtmlTableCell htmlTableCell_2;
		private DataTable dataTable_0;
		public S_LogisticsTemplateOperate()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.htmlTableCell_0 = (HtmlTableCell)skin.FindControl("postPost");
			this.htmlTableCell_1 = (HtmlTableCell)skin.FindControl("postEms");
			this.htmlTableCell_2 = (HtmlTableCell)skin.FindControl("postExpress");
			this.htmlInputCheckBox_0 = (HtmlInputCheckBox)skin.FindControl("checkboxExpress");
			this.htmlInputCheckBox_1 = (HtmlInputCheckBox)skin.FindControl("checkboxEMS");
			this.htmlInputCheckBox_2 = (HtmlInputCheckBox)skin.FindControl("checkboxPost");
			this.button_0 = (Button)skin.FindControl("btnSub");
			this.htmlInputText_1 = (HtmlInputText)skin.FindControl("express_postage_0");
			this.htmlInputText_2 = (HtmlInputText)skin.FindControl("express_postageplus_0");
			this.htmlInputText_3 = (HtmlInputText)skin.FindControl("ems_postage_0");
			this.htmlInputText_4 = (HtmlInputText)skin.FindControl("ems_postageplus_0");
			this.htmlInputText_5 = (HtmlInputText)skin.FindControl("post_postage_0");
			this.htmlInputText_6 = (HtmlInputText)skin.FindControl("post_postageplus_0");
			this.button_0.Click += new EventHandler(this.btnSub_Click);
			this.htmlInputText_0 = (HtmlInputText)skin.FindControl("texttemplateName");
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("feeTemplateDiv");
			this.repeater_2 = (Repeater)skin.FindControl("RepeaterPost");
			this.repeater_1 = (Repeater)skin.FindControl("RepeaterEMS");
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterExpress");
			this.htmlInputHidden_0 = (HtmlInputHidden)skin.FindControl("hidExpress");
			this.htmlInputHidden_1 = (HtmlInputHidden)skin.FindControl("hidEms");
			this.htmlInputHidden_2 = (HtmlInputHidden)skin.FindControl("hidPost");
			if (!this.Page.IsPostBack && ShopNum1.Common.Common.ReqStr("templateid") != "")
			{
				this.method_0();
			}
		}
		protected void btnSub_Click(object sender, EventArgs e)
		{
			this.ButtonAddEvent();
		}
		private void method_0()
		{
			Shop_FeeTemplate_Action shop_FeeTemplate_Action = new Shop_FeeTemplate_Action();
			string path = this.method_1();
			string templateid = this.Page.Request.QueryString["templateid"].ToString();
			string empty = string.Empty;
			this.dataTable_0 = shop_FeeTemplate_Action.GetFeesByIDRegion(this.Page.Server.MapPath(path), templateid, "-1", "-1", out empty);
			if (this.dataTable_0 != null && this.dataTable_0.Rows.Count != 0)
			{
				this.htmlInputText_0.Value = this.dataTable_0.Rows[0]["templatename"].ToString();
				bool flag = false;
				bool flag2 = false;
				bool flag3 = false;
				foreach (DataRow dataRow in this.dataTable_0.Rows)
				{
					if (dataRow["feetype"].ToString() == "2")
					{
						flag = true;
					}
					else if (dataRow["feetype"].ToString() == "1")
					{
						flag3 = true;
					}
					else
					{
						flag2 = true;
					}
					if (flag2 && flag && flag3)
					{
						break;
					}
				}
				string innerHtml = this.htmlGenericControl_0.InnerHtml;
				if (flag)
				{
					this.htmlInputCheckBox_0.Checked = true;
					DataRow[] array = this.dataTable_0.Select("feetype='2'");
					if (array != null && array.Length > 0)
					{
						DataTable dataTable = array.CopyToDataTable<DataRow>();
						if (dataTable != null && dataTable.Rows.Count > 0)
						{
							DataTable dataTable2 = dataTable;
							this.repeater_0.DataSource = dataTable2;
							this.repeater_0.DataBind();
							if (this.repeater_0.Controls[0] != null)
							{
								HtmlTableCell arg_22C_0 = (HtmlTableCell)this.repeater_0.Controls[0].FindControl("postTd");
								string text = innerHtml.Replace("{delivery}", "express");
								text = text.Replace("{value}", dataTable2.Rows[0]["fee"].ToString());
								text = text.Replace("{plusvalue}", dataTable2.Rows[0]["oneadd"].ToString());
								text = text.Replace("{postnumvalue}", dataTable2.Rows.Count.ToString());
								this.htmlTableCell_2.InnerHtml = text;
							}
						}
					}
				}
				if (flag2)
				{
					this.htmlInputCheckBox_1.Checked = true;
					DataRow[] array = this.dataTable_0.Select("feetype=3 ");
					if (array != null && array.Length > 0)
					{
						DataTable dataTable3 = array.CopyToDataTable<DataRow>();
						if (dataTable3 != null && dataTable3.Rows.Count > 0)
						{
							DataTable dataTable4 = dataTable3;
							this.repeater_1.DataSource = dataTable4;
							this.repeater_1.DataBind();
							if (this.repeater_1.Controls[0] != null)
							{
								HtmlTableCell arg_37E_0 = (HtmlTableCell)this.repeater_1.Controls[0].FindControl("postTd");
								string text = innerHtml.Replace("{delivery}", "ems");
								text = text.Replace("{value}", dataTable4.Rows[0]["fee"].ToString());
								text = text.Replace("{plusvalue}", dataTable4.Rows[0]["oneadd"].ToString());
								text = text.Replace("{postnumvalue}", dataTable4.Rows.Count.ToString());
								this.htmlTableCell_1.InnerHtml = text;
							}
						}
					}
				}
				if (flag3)
				{
					this.htmlInputCheckBox_2.Checked = true;
					DataRow[] array = this.dataTable_0.Select("feetype=1");
					if (array != null && array.Length > 0)
					{
						DataTable dataTable5 = array.CopyToDataTable<DataRow>();
						if (dataTable5 != null && dataTable5.Rows.Count > 0)
						{
							DataTable dataTable6 = dataTable5;
							this.repeater_2.DataSource = dataTable6;
							this.repeater_2.DataBind();
							if (this.repeater_2.Controls[0] != null)
							{
								HtmlTableCell arg_4D0_0 = (HtmlTableCell)this.repeater_2.Controls[0].FindControl("postTd");
								string text = innerHtml.Replace("{delivery}", "post");
								text = text.Replace("{value}", dataTable6.Rows[0]["fee"].ToString());
								text = text.Replace("{plusvalue}", dataTable6.Rows[0]["oneadd"].ToString());
								text = text.Replace("{postnumvalue}", dataTable6.Rows.Count.ToString());
								this.htmlTableCell_0.InnerHtml = text;
							}
						}
					}
				}
			}
		}
		protected void ButtonAddEvent()
		{
			Shop_FeeTemplate_Action shop_FeeTemplate_Action = new Shop_FeeTemplate_Action();
			string path = this.method_1();
			string text = this.Page.Server.MapPath(path);
			string text2 = string.Empty;
			if (ShopNum1.Common.Common.ReqStr("templateid") != "")
			{
				text2 = ShopNum1.Common.Common.ReqStr("templateid");
				if (!shop_FeeTemplate_Action.DelByTemplateID(text2, text))
				{
					return;
				}
			}
			else
			{
				text2 = shop_FeeTemplate_Action.GetMaxFeeTemplateId(text).ToString();
			}
			string templatename = this.htmlInputText_0.Value.Trim();
			List<Shop_FeeTemplate> list = new List<Shop_FeeTemplate>();
			if (this.htmlInputCheckBox_0.Checked)
			{
				string arg_A0_0 = this.htmlInputText_1.Value;
				string arg_AC_0 = this.htmlInputText_2.Value;
				Shop_FeeTemplate shop_FeeTemplate = new Shop_FeeTemplate();
				if (this.htmlInputHidden_0.Value != "0" && this.htmlInputHidden_0.Value != "")
				{
					int num = 1;
					if (this.htmlInputHidden_0.Value.IndexOf("*") != -1)
					{
						string[] array = this.htmlInputHidden_0.Value.Split(new char[]
						{
							'*'
						});
						for (int i = 0; i < array.Length; i++)
						{
							if (array[i].Split(new char[]
							{
								'.'
							})[1] != "")
							{
								Shop_FeeTemplate shop_FeeTemplate2 = new Shop_FeeTemplate();
								shop_FeeTemplate2.createtime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
								shop_FeeTemplate2.altertime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
								shop_FeeTemplate2.feetype = "2";
								shop_FeeTemplate2.groupid = num.ToString();
								shop_FeeTemplate2.oneadd = array[i].Split(new char[]
								{
									'.'
								})[2].Replace("-", ".");
								shop_FeeTemplate2.fee=array[i].Split(new char[]
								{
									'.'
								})[1];
								shop_FeeTemplate2.orderid = "2";
								shop_FeeTemplate2.templateid = text2;
								shop_FeeTemplate2.templatename = templatename;
								shop_FeeTemplate2.regioncode = "";
								shop_FeeTemplate2.regionname = "";
								shop_FeeTemplate2.groupregioncodes = array[i].Split(new char[]
								{
									'.'
								})[0].Split(new char[]
								{
									'|'
								})[0];
								shop_FeeTemplate2.groupregionnames = array[i].Split(new char[]
								{
									'.'
								})[0].Split(new char[]
								{
									'|'
								})[1];
								list.Add(shop_FeeTemplate2);
								num++;
							}
						}
					}
					else
					{
						string[] array = this.htmlInputHidden_0.Value.Split(new char[]
						{
							'.'
						});
						if (array[1] != "" && array[0].IndexOf("全国") == -1)
						{
							Shop_FeeTemplate shop_FeeTemplate2 = new Shop_FeeTemplate();
							shop_FeeTemplate2.createtime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
							shop_FeeTemplate2.altertime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
							shop_FeeTemplate2.feetype = "2";
							shop_FeeTemplate2.groupid = num.ToString();
							shop_FeeTemplate2.oneadd = array[2].Replace("-", ".");
							shop_FeeTemplate2.fee=array[1];
							shop_FeeTemplate2.orderid = "2";
							shop_FeeTemplate2.templateid = text2;
							shop_FeeTemplate2.templatename = templatename;
							shop_FeeTemplate2.regioncode = "";
							shop_FeeTemplate2.regionname = "";
							shop_FeeTemplate2.groupregioncodes = array[0].Split(new char[]
							{
								'|'
							})[0];
							shop_FeeTemplate2.groupregionnames = array[0].Split(new char[]
							{
								'|'
							})[1];
							list.Add(shop_FeeTemplate2);
							num++;
						}
						else
						{
							shop_FeeTemplate.createtime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
							shop_FeeTemplate.altertime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
							shop_FeeTemplate.feetype = "2";
							shop_FeeTemplate.groupid = "0";
							shop_FeeTemplate.oneadd = array[2].Replace("-", ".");
							shop_FeeTemplate.fee=array[1];
							shop_FeeTemplate.orderid = "2";
							shop_FeeTemplate.templateid = text2;
							shop_FeeTemplate.templatename = templatename;
							shop_FeeTemplate.regioncode = "000";
							shop_FeeTemplate.regionname = "全国";
							shop_FeeTemplate.groupregioncodes = "000";
							shop_FeeTemplate.groupregionnames = "全国";
							list.Add(shop_FeeTemplate);
						}
					}
				}
			}
			if (this.htmlInputCheckBox_1.Checked)
			{
				string arg_517_0 = this.htmlInputText_3.Value;
				string arg_523_0 = this.htmlInputText_4.Value;
				Shop_FeeTemplate shop_FeeTemplate3 = new Shop_FeeTemplate();
				if (this.htmlInputHidden_1.Value != "0" && this.htmlInputHidden_1.Value != "")
				{
					int num = 1;
					if (this.htmlInputHidden_1.Value.IndexOf("*") != -1)
					{
						string[] array = this.htmlInputHidden_1.Value.Split(new char[]
						{
							'*'
						});
						for (int i = 0; i < array.Length; i++)
						{
							Shop_FeeTemplate shop_FeeTemplate2 = new Shop_FeeTemplate();
							shop_FeeTemplate2.createtime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
							shop_FeeTemplate2.altertime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
							shop_FeeTemplate2.feetype = "3";
							shop_FeeTemplate2.groupid = num.ToString();
							shop_FeeTemplate2.oneadd = array[i].Split(new char[]
							{
								'.'
							})[2].Replace("-", ".");
							shop_FeeTemplate2.fee=array[i].Split(new char[]
							{
								'.'
							})[1];
							shop_FeeTemplate2.orderid = "3";
							shop_FeeTemplate2.templateid = text2;
							shop_FeeTemplate2.templatename = templatename;
							shop_FeeTemplate2.regioncode = "";
							shop_FeeTemplate2.regionname = "";
							shop_FeeTemplate2.groupregioncodes = array[i].Split(new char[]
							{
								'.'
							})[0].Split(new char[]
							{
								'|'
							})[0];
							shop_FeeTemplate2.groupregionnames = array[i].Split(new char[]
							{
								'.'
							})[0].Split(new char[]
							{
								'|'
							})[1];
							list.Add(shop_FeeTemplate2);
							num++;
						}
					}
					else
					{
						string[] array = this.htmlInputHidden_1.Value.Split(new char[]
						{
							'.'
						});
						if (array[1] != "" && array[0].IndexOf("全国") == -1)
						{
							Shop_FeeTemplate shop_FeeTemplate2 = new Shop_FeeTemplate();
							shop_FeeTemplate2.createtime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
							shop_FeeTemplate2.altertime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
							shop_FeeTemplate2.feetype = "3";
							shop_FeeTemplate2.groupid = num.ToString();
							shop_FeeTemplate2.oneadd = array[2].ToString().Replace("-", ".");
							shop_FeeTemplate2.fee=array[1].ToString();
							shop_FeeTemplate2.orderid = "3";
							shop_FeeTemplate2.templateid = text2;
							shop_FeeTemplate2.templatename = templatename;
							shop_FeeTemplate2.regioncode = "";
							shop_FeeTemplate2.regionname = "";
							shop_FeeTemplate2.groupregioncodes = array[0].Split(new char[]
							{
								'|'
							})[0];
							shop_FeeTemplate2.groupregionnames = array[0].Split(new char[]
							{
								'|'
							})[1];
							list.Add(shop_FeeTemplate2);
							num++;
						}
						else
						{
							shop_FeeTemplate3.createtime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
							shop_FeeTemplate3.altertime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
							shop_FeeTemplate3.feetype = "3";
							shop_FeeTemplate3.groupid = "0";
							shop_FeeTemplate3.oneadd = array[2].ToString().Replace("-", ".");
							shop_FeeTemplate3.fee=array[1].ToString();
							shop_FeeTemplate3.orderid = "3";
							shop_FeeTemplate3.templateid = text2;
							shop_FeeTemplate3.templatename = templatename;
							shop_FeeTemplate3.regioncode = "000";
							shop_FeeTemplate3.regionname = "全国";
							shop_FeeTemplate3.groupregioncodes = "000";
							shop_FeeTemplate3.groupregionnames = "全国";
							list.Add(shop_FeeTemplate3);
						}
					}
				}
			}
			if (this.htmlInputCheckBox_2.Checked)
			{
				string arg_974_0 = this.htmlInputText_5.Value;
				string arg_980_0 = this.htmlInputText_6.Value;
				Shop_FeeTemplate shop_FeeTemplate4 = new Shop_FeeTemplate();
				if (this.htmlInputHidden_2.Value != "0" && this.htmlInputHidden_2.Value != "")
				{
					int num = 1;
					if (this.htmlInputHidden_2.Value.IndexOf("*") != -1)
					{
						string[] array = this.htmlInputHidden_2.Value.Split(new char[]
						{
							'*'
						});
						for (int i = 0; i < array.Length; i++)
						{
							Shop_FeeTemplate shop_FeeTemplate2 = new Shop_FeeTemplate();
							shop_FeeTemplate2.createtime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
							shop_FeeTemplate2.altertime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
							shop_FeeTemplate2.feetype = "1";
							shop_FeeTemplate2.groupid = num.ToString();
							shop_FeeTemplate2.oneadd = array[i].Split(new char[]
							{
								'.'
							})[2].Replace("-", ".");
							shop_FeeTemplate2.fee=array[i].Split(new char[]
							{
								'.'
							})[1];
							shop_FeeTemplate2.orderid = "1";
							shop_FeeTemplate2.templateid = text2;
							shop_FeeTemplate2.templatename = templatename;
							shop_FeeTemplate2.regioncode = "";
							shop_FeeTemplate2.regionname = "";
							shop_FeeTemplate2.groupregioncodes = array[i].Split(new char[]
							{
								'.'
							})[0].Split(new char[]
							{
								'|'
							})[0];
							shop_FeeTemplate2.groupregionnames = array[i].Split(new char[]
							{
								'.'
							})[0].Split(new char[]
							{
								'|'
							})[1];
							list.Add(shop_FeeTemplate2);
							num++;
						}
					}
					else
					{
						string[] array = this.htmlInputHidden_2.Value.Split(new char[]
						{
							'.'
						});
						if (array[1] != "" && array[0].IndexOf("全国") == -1)
						{
							Shop_FeeTemplate shop_FeeTemplate2 = new Shop_FeeTemplate();
							shop_FeeTemplate2.createtime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
							shop_FeeTemplate2.altertime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
							shop_FeeTemplate2.feetype = "1";
							shop_FeeTemplate2.groupid = num.ToString();
							shop_FeeTemplate2.oneadd = array[2].Replace("-", ".");
							shop_FeeTemplate2.fee=array[1];
							shop_FeeTemplate2.orderid = "1";
							shop_FeeTemplate2.templateid = text2;
							shop_FeeTemplate2.templatename = templatename;
							shop_FeeTemplate2.regioncode = "";
							shop_FeeTemplate2.regionname = "";
							shop_FeeTemplate2.groupregioncodes = array[0].Split(new char[]
							{
								'|'
							})[0];
							shop_FeeTemplate2.groupregionnames = array[0].Split(new char[]
							{
								'|'
							})[1];
							list.Add(shop_FeeTemplate2);
							num++;
						}
						else
						{
							shop_FeeTemplate4.createtime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
							shop_FeeTemplate4.altertime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
							shop_FeeTemplate4.feetype = "1";
							shop_FeeTemplate4.groupid = "0";
							shop_FeeTemplate4.oneadd = array[2].Replace("-", ".");
							shop_FeeTemplate4.fee=array[1];
							shop_FeeTemplate4.orderid = "1";
							shop_FeeTemplate4.templateid = text2;
							shop_FeeTemplate4.templatename = templatename;
							shop_FeeTemplate4.regioncode = "000";
							shop_FeeTemplate4.regionname = "全国";
							shop_FeeTemplate4.groupregioncodes = "000";
							shop_FeeTemplate4.groupregionnames = "全国";
							list.Add(shop_FeeTemplate4);
						}
					}
				}
			}
			try
			{
				string empty = string.Empty;
				if (shop_FeeTemplate_Action.AddFeeTemplates(list, text, out empty))
				{
					this.Page.Response.Redirect("S_Logistics.aspx", false);
				}
				else
				{
					this.Page.RegisterClientScriptBlock("msg", "<script>alert(\"" + empty + "\");</script>");
				}
			}
			catch (Exception)
			{
				this.Page.RegisterClientScriptBlock("msg", "<script>alert(\"店铺邮费文件不存在，未能找到路径" + text + "邮费文件！\");</script>");
			}
		}
		private string method_1()
		{
			Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)LogicFactory.CreateShop_ShopInfo_Action();
			DataTable memLoginInfo = shop_ShopInfo_Action.GetMemLoginInfo(this.MemLoginID);
			string text = memLoginInfo.Rows[0]["ShopID"].ToString();
			string text2 = DateTime.Parse(memLoginInfo.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
			return string.Concat(new string[]
			{
				"~/Shop/Shop/",
				text2.Replace("-", "/"),
				"/shop",
				text,
				"/xml/PostageTemplate.xml"
			});
		}
		private string method_2(string string_1, string string_2)
		{
			string result;
			if (string_2 == "get")
			{
				try
				{
					string text = this.Page.Request.QueryString[string_1].ToString();
					if (text == string.Empty)
					{
						result = "-1";
						return result;
					}
					result = text;
					return result;
				}
				catch
				{
					result = "-1";
					return result;
				}
			}
			try
			{
				string text = this.Page.Request.Form[string_1].ToString();
				if (text == string.Empty)
				{
					result = "-1";
				}
				else
				{
					result = text;
				}
			}
			catch
			{
				result = "-1";
			}
			return result;
		}
	}
}
