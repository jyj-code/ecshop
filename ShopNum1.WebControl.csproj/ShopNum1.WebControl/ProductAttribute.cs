using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	public class ProductAttribute : BaseWebControl
	{
		private string string_0 = "ProductAttribute.ascx";
		private Repeater repeater_0;
		private Repeater repeater_1;
		private HtmlGenericControl htmlGenericControl_0;
		private HtmlGenericControl htmlGenericControl_1;
		private HiddenField hiddenField_0;
		private ShopNum1_Brand_Action shopNum1_Brand_Action_0 = (ShopNum1_Brand_Action)LogicFactory.CreateShopNum1_Brand_Action();
		private ShopNum1_ShopProductProp_Action shopNum1_ShopProductProp_Action_0 = (ShopNum1_ShopProductProp_Action)LogicFactory.CreateShopNum1_ShopProductProp_Action();
		private ShopNum1_ShopProductPropValue_Action shopNum1_ShopProductPropValue_Action_0 = (ShopNum1_ShopProductPropValue_Action)LogicFactory.CreateShopNum1_ShopProductPropValue_Action();
		private string string_1;
		private string string_2;
		private string string_3;
		private Dictionary<string, string> dictionary_0;
		private string string_4;
		private bool bool_0 = false;
		private bool bool_1 = false;
		[CompilerGenerated]
		private string string_5;
		private string strProductName
		{
			get;
			set;
		}
		public ProductAttribute()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterShopProductProp");
			this.repeater_0.ItemDataBound += new RepeaterItemEventHandler(this.repeater_0_ItemDataBound);
			this.repeater_1 = (Repeater)skin.FindControl("RepeaterPtoudctBrand");
			this.repeater_1.ItemDataBound += new RepeaterItemEventHandler(this.repeater_1_ItemDataBound);
			this.string_1 = ((this.Page.Request.QueryString["Code"] == null) ? "0" : this.Page.Request.QueryString["Code"].ToString());
			this.string_2 = ((this.Page.Request.QueryString["brandguid"] == null) ? "-1" : this.Page.Request.QueryString["brandguid"].ToString());
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("BrandBorder");
			this.htmlGenericControl_1 = (HtmlGenericControl)skin.FindControl("PropBorder");
			this.string_3 = ((this.Page.Request.QueryString["pvalue"] == null) ? "-1" : this.Page.Request.QueryString["pvalue"].ToString());
			Func<string, bool> func = new Func<string, bool>(this.method_5);
			if (this.string_3 != "-1")
			{
				func(this.string_3);
			}
			bool flag = this.method_2();
			bool flag2 = this.method_0();
			if (!flag)
			{
				this.htmlGenericControl_0.Visible = false;
			}
			if (!flag2)
			{
				this.htmlGenericControl_1.Visible = false;
			}
			if (flag2 && !flag)
			{
				this.htmlGenericControl_1.Style.Add("border-top", "1px solid #674E40;");
			}
			this.strProductName = this.Page.Request.QueryString["productName"];
			if (this.strProductName != null)
			{
				this.htmlGenericControl_0.Visible = false;
				this.htmlGenericControl_1.Visible = false;
			}
		}
		private bool method_0()
		{
			bool result;
			if (this.string_1 != "0" && this.string_1.Length > 5)
			{
				DataTable searchListPropByCode = this.shopNum1_ShopProductProp_Action_0.GetSearchListPropByCode(this.string_1);
				if (searchListPropByCode != null && searchListPropByCode.Rows.Count > 0)
				{
					DataTable dataTable = searchListPropByCode;
					dataTable.Columns.Add("linkurl", typeof(string));
					this.string_4 = string.Empty;
					foreach (DataRow dataRow in dataTable.Rows)
					{
						this.string_4 = this.string_4 + dataRow["ID"].ToString() + "m0-";
					}
					if (this.string_4 != string.Empty)
					{
						this.string_4 = this.string_4.Substring(0, this.string_4.Length - 1);
					}
					foreach (DataRow dataRow in dataTable.Rows)
					{
						string text = this.string_4;
						if (this.dictionary_0 != null)
						{
							foreach (KeyValuePair<string, string> current in this.dictionary_0)
							{
								if (current.Key != null && current.Value != null && current.Key != dataRow["ID"].ToString())
								{
									text = text.Replace(current.Key + "m0", current.Key + "m" + current.Value);
								}
							}
						}
						dataRow["linkurl"] = this.method_4(this.string_1, this.string_2, text);
					}
					this.repeater_0.DataSource = dataTable;
					this.repeater_0.DataBind();
					result = true;
				}
				else
				{
					result = false;
				}
			}
			else
			{
				result = false;
			}
			return result;
		}
		private void repeater_0_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			Repeater repeater = (Repeater)e.Item.FindControl("RepeaterShopProductPropValue");
			repeater.ItemDataBound += new RepeaterItemEventHandler(this.method_1);
			this.hiddenField_0 = (HiddenField)e.Item.FindControl("HiddenFieldPropID");
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				this.bool_1 = false;
				string a = string.Empty;
				int num = -1;
				DataTable dataTable = this.shopNum1_ShopProductPropValue_Action_0.BindProductPropValue(this.hiddenField_0.Value);
				if (dataTable != null && dataTable.Rows.Count > 0)
				{
					if (this.dictionary_0 != null)
					{
						foreach (KeyValuePair<string, string> current in this.dictionary_0)
						{
							if (current.Key == this.hiddenField_0.Value)
							{
								a = current.Value;
							}
						}
					}
					DataTable dataTable2 = dataTable;
					dataTable2.Columns.Add("linkurl", typeof(string));
					DataRow dataRow = dataTable2.NewRow();
					dataRow["name"] = "不限";
					dataRow["id"] = "0";
					dataRow["linkurl"] = "";
					dataRow["PropID"] = this.hiddenField_0.Value;
					dataTable2.Rows.InsertAt(dataRow, 0);
					DataRow dataRow2 = dataTable2.NewRow();
					dataTable2.AcceptChanges();
					foreach (DataRow dataRow3 in dataTable2.Rows)
					{
						string text = this.string_4;
						if (this.dictionary_0 != null)
						{
							using (Dictionary<string, string>.Enumerator enumerator = this.dictionary_0.GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									KeyValuePair<string, string> current2 = enumerator.Current;
									if (current2.Key != dataRow3["PropID"].ToString())
									{
										text = text.Replace(current2.Key + "m0", current2.Key + "m" + current2.Value);
									}
									else
									{
										text = text.Replace(current2.Key + "m0", current2.Key + "m" + dataRow3["id"].ToString());
									}
								}
								goto IL_2F2;
							}
							goto IL_2A2;
						}
						goto IL_2A2;
						IL_2F2:
						dataRow3["linkurl"] = this.method_4(this.string_1, this.string_2, text);
						if (a == dataRow3["id"].ToString() && a != "0")
						{
							dataRow2["name"] = dataRow3["name"];
							dataRow2["PropID"] = dataRow3["PropID"];
							dataRow2["id"] = dataRow3["id"];
							dataRow2["linkurl"] = dataRow3["linkurl"];
							num = dataTable2.Rows.IndexOf(dataRow3);
							continue;
						}
						continue;
						IL_2A2:
						text = text.Replace(dataRow3["PropID"].ToString() + "m0", dataRow3["PropID"].ToString() + "m" + dataRow3["id"].ToString());
						goto IL_2F2;
					}
					if (num != -1 && num != 0)
					{
						dataTable2.Rows.RemoveAt(num);
						dataTable2.AcceptChanges();
					}
					if (a != string.Empty && a != "0")
					{
						dataTable2.Rows.InsertAt(dataRow2, 1);
					}
					repeater.DataSource = dataTable2;
					repeater.DataBind();
					if (!this.bool_1)
					{
						HtmlGenericControl htmlGenericControl = (HtmlGenericControl)repeater.Items[0].FindControl("SpanPropValue");
						htmlGenericControl.Attributes.Add("class", "buxian");
					}
				}
			}
		}
		private void method_1(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				HiddenField hiddenField = (HiddenField)e.Item.FindControl("HiddenFieldPropValueID");
				HtmlGenericControl htmlGenericControl = (HtmlGenericControl)e.Item.FindControl("SpanPropValue");
				if (this.dictionary_0 != null)
				{
					foreach (KeyValuePair<string, string> current in this.dictionary_0)
					{
						if (current.Key != null && current.Value != null && current.Key == this.hiddenField_0.Value && current.Value == hiddenField.Value)
						{
							this.bool_1 = true;
							htmlGenericControl.Attributes.Add("class", "buxian");
						}
					}
				}
			}
		}
		private bool method_2()
		{
			bool result;
			if (this.string_1.Length > 3)
			{
				DataTable dataTable = this.shopNum1_Brand_Action_0.BindProductBrand(this.string_1);
				if (dataTable != null && dataTable.Rows.Count > 0)
				{
					DataTable dataTable2 = dataTable;
					dataTable2.Columns.Add("linkurl", typeof(string));
					DataRow dataRow = dataTable2.NewRow();
					dataRow["name"] = "不限";
					dataRow["Guid"] = Guid.Empty.ToString();
					dataRow["linkurl"] = "";
					dataTable2.Rows.InsertAt(dataRow, 0);
					DataRow dataRow2 = dataTable2.NewRow();
					foreach (DataRow dataRow3 in dataTable2.Rows)
					{
						if (this.string_3 != "-1")
						{
							if (dataRow3["Guid"].ToString() != "00000000-0000-0000-0000-000000000000")
							{
								dataRow3["linkurl"] = this.method_4(this.string_1, dataRow3[0].ToString(), this.string_3);
							}
							else
							{
								dataRow3["linkurl"] = this.method_4(this.string_1, "-1", this.string_3);
							}
						}
						else if (dataRow3["Guid"].ToString() != "00000000-0000-0000-0000-000000000000")
						{
							dataRow3["linkurl"] = this.method_3(this.string_1, dataRow3[0].ToString());
						}
						else
						{
							dataRow3["linkurl"] = this.method_3(this.string_1, "-1");
						}
						if (dataRow3["Guid"].ToString() == this.string_2 && this.string_2 != Guid.Empty.ToString() && this.string_2 != "-1")
						{
							dataRow2["name"] = dataRow3[1];
							dataRow2["Guid"] = dataRow3[0];
							dataRow2["linkurl"] = dataRow3[3];
							dataRow3.Delete();
						}
					}
					if (dataRow2["Guid"].ToString() == this.string_2 && this.string_2 != Guid.Empty.ToString() && this.string_2 != "-1")
					{
						dataTable2.Rows.InsertAt(dataRow2, 1);
					}
					this.repeater_1.DataSource = dataTable2;
					this.repeater_1.DataBind();
					if (!this.bool_0)
					{
						HtmlContainerControl htmlContainerControl = (HtmlContainerControl)this.repeater_1.Items[0].FindControl("SpanBrand");
						htmlContainerControl.Attributes.Add("class", "buxian");
					}
					result = true;
				}
				else
				{
					result = false;
				}
			}
			else
			{
				this.htmlGenericControl_0.Visible = false;
				result = false;
			}
			return result;
		}
		private void repeater_1_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				HiddenField hiddenField = (HiddenField)e.Item.FindControl("HiddenFieldGuid");
				HtmlContainerControl htmlContainerControl = (HtmlContainerControl)e.Item.FindControl("SpanBrand");
				if (this.string_2 == hiddenField.Value)
				{
					this.bool_0 = true;
					htmlContainerControl.Attributes.Add("class", "buxian");
				}
			}
		}
		private string method_3(string string_6, string string_7)
		{
			string format = "code={0}&brandguid={1}";
			return string.Format(format, string_6, string_7);
		}
		private string method_4(string string_6, string string_7, string string_8)
		{
			string format = "code={0}&brandguid={1}&Pvalue={2}";
			return string.Format(format, string_6, string_7, string_8);
		}
		[CompilerGenerated]
		private bool method_5(string string_6)
		{
			string[] array = string_6.Split(new char[]
			{
				'-'
			});
			if (array.Length != 0)
			{
				this.dictionary_0 = new Dictionary<string, string>();
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					string text = array2[i];
					string[] array3 = text.Split(new char[]
					{
						'm'
					});
					if (array3.Length == 2)
					{
						this.dictionary_0.Add(array3[0], array3[1]);
					}
				}
			}
			return true;
		}
	}
}
