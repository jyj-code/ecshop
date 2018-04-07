using ShopNum1.Cache;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Xml;
namespace ShopNum1.ShopFeeTemplate
{
	public class Shop_FeeTemplate_Action
	{
		public DataTable GetFeesByIDRegion(string path, string templateid, string regioncode, string feetype, out string strerror)
		{
			strerror = string.Empty;
			DataTable result;
			if (!File.Exists(path))
			{
				strerror = "-1";
				result = null;
			}
			else
			{
				DataSet dataSet = new DataSet();
				dataSet.ReadXml(path);
				if (dataSet == null || dataSet.Tables.Count <= 1)
				{
					strerror = "0";
					result = null;
				}
				else
				{
					string text = "1=1 ";
					if (templateid != "-1")
					{
						text = text + " and templateid='" + templateid + "'";
					}
					if (regioncode == "000")
					{
						text = text + " and groupregioncodes='" + regioncode + "'";
					}
					if (feetype != "-1")
					{
						text = text + " and feetype='" + feetype + "' ";
					}
					try
					{
						DataTable dataTable = dataSet.Tables[1].Select(text, "altertime desc").CopyToDataTable<DataRow>();
						result = dataTable;
					}
					catch (Exception ex)
					{
						strerror = ex.Message;
						result = null;
					}
				}
			}
			return result;
		}
		public DataTable GetFeesByFrontCache(string path, string memlogid, string templateid, string regioncode, string feetype, bool ishavcache)
		{
			DataTable result;
			if (!File.Exists(path))
			{
				result = null;
			}
			else
			{
				DataSet dataSet = new DataSet();
				if (ishavcache)
				{
					object obj = CacheHelper.Get(memlogid);
					if (obj == null)
					{
						dataSet.ReadXml(path);
					}
				}
				else
				{
					dataSet.ReadXml(path);
				}
				if (dataSet == null || dataSet.Tables.Count <= 1)
				{
					result = null;
				}
				else
				{
					string text = "1=1 ";
					if (templateid != "-1")
					{
						text = text + " and templateid=" + templateid + " ";
					}
					if (feetype != "-1")
					{
						text = text + " and feetype=" + feetype + " ";
					}
					if (regioncode == "000")
					{
						text = text + " and groupregioncodes='" + regioncode + "'";
						DataRow[] array = dataSet.Tables[1].Select(text);
						if (array == null || array.Length == 0)
						{
							result = null;
						}
						else
						{
							DataTable dataTable = array.CopyToDataTable<DataRow>();
							result = dataTable;
						}
					}
					else
					{
						try
						{
							DataTable dataTable = dataSet.Tables[1].Select(text).CopyToDataTable<DataRow>();
							DataTable dataTable2 = this.method_0();
							bool flag = false;
							bool flag2 = false;
							bool flag3 = false;
							DataRow dataRow = null;
							DataRow dataRow2 = null;
							DataRow dataRow3 = null;
							foreach (DataRow dataRow4 in dataTable.Rows)
							{
								if ((!(dataRow4["feetype"].ToString() == "1") || !flag2) && (!(dataRow4["feetype"].ToString() == "2") || !flag) && (!(dataRow4["feetype"].ToString() == "2") || !flag3))
								{
									string text2 = dataRow4["groupregioncodes"].ToString();
									if (text2 == "000")
									{
										if (dataRow4["feetype"].ToString() == "1")
										{
											dataRow2 = dataTable2.NewRow();
											dataRow2["feetype"] = dataRow4["feetype"].ToString();
											dataRow2["fee"] = dataRow4["fee"].ToString();
											dataRow2["oneadd"] = dataRow4["oneadd"].ToString();
										}
										else if (dataRow4["feetype"].ToString() == "2")
										{
											dataRow = dataTable2.NewRow();
											dataRow["feetype"] = dataRow4["feetype"].ToString();
											dataRow["fee"] = dataRow4["fee"].ToString();
											dataRow["oneadd"] = dataRow4["oneadd"].ToString();
										}
										else
										{
											dataRow3 = dataTable2.NewRow();
											dataRow3["feetype"] = dataRow4["feetype"].ToString();
											dataRow3["fee"] = dataRow4["fee"].ToString();
											dataRow3["oneadd"] = dataRow4["oneadd"].ToString();
										}
									}
									string[] array2 = text2.Split(new char[]
									{
										','
									});
									for (int i = 0; i < array2.Length; i++)
									{
										string a = array2[i];
										if (a == regioncode)
										{
											DataRow dataRow5 = dataTable2.NewRow();
											dataRow5["feetype"] = dataRow4["feetype"].ToString();
											dataRow5["fee"] = dataRow4["fee"].ToString();
											dataRow5["oneadd"] = dataRow4["oneadd"].ToString();
											if (dataRow4["feetype"].ToString() == "1")
											{
												flag2 = true;
											}
											else if (dataRow4["feetype"].ToString() == "2")
											{
												flag = true;
											}
											else
											{
												flag3 = true;
											}
											dataTable2.Rows.Add(dataRow5);
											break;
										}
									}
								}
							}
							if (!flag3 && dataRow3 != null)
							{
								dataTable2.Rows.Add(dataRow3);
							}
							if (!flag2 && dataRow2 != null)
							{
								dataTable2.Rows.Add(dataRow2);
							}
							if (!flag && dataRow != null)
							{
								dataTable2.Rows.Add(dataRow);
							}
							result = dataTable2;
						}
						catch
						{
							result = null;
						}
					}
				}
			}
			return result;
		}
		private DataTable method_0()
		{
			return new DataTable
			{
				Columns = 
				{

					{
						"feetype",
						typeof(string)
					},

					{
						"fee",
						typeof(string)
					},

					{
						"oneadd",
						typeof(string)
					}
				}
			};
		}
		public bool DelByTemplateID(string templateID, string path)
		{
			bool result;
			if (!File.Exists(path))
			{
				result = false;
			}
			else
			{
				DataSet dataSet = new DataSet();
				dataSet.ReadXml(path);
				if (dataSet == null || dataSet.Tables.Count <= 1)
				{
					result = false;
				}
				else
				{
					string text = "1=1 and templateid='{0}'";
					text = string.Format(text, templateID);
					DataRow[] array = dataSet.Tables[1].Select(text);
					for (int i = 0; i < array.Length; i++)
					{
						DataRow dataRow = array[i];
						dataRow.Delete();
					}
					try
					{
						dataSet.AcceptChanges();
						dataSet.WriteXml(path);
						result = true;
					}
					catch (Exception)
					{
						result = false;
					}
				}
			}
			return result;
		}
		public bool AddFeeTemplates(List<Shop_FeeTemplate> feetemplates, string path, out string strerror)
		{
			strerror = string.Empty;
			bool result;
			if (!File.Exists(path))
			{
				strerror = "-1";
				result = false;
			}
			else
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load(path);
				XmlNode xmlNode = xmlDocument.SelectSingleNode("template/postagetemplaes");
				int num = this.method_1(path);
				foreach (Shop_FeeTemplate current in feetemplates)
				{
					if (current.fee != "")
					{
						XmlElement xmlElement = xmlDocument.CreateElement("postagetemplae");
						xmlElement.SetAttribute("id", num.ToString());
						xmlElement.SetAttribute("templateid", current.templateid);
						xmlElement.SetAttribute("templatename", current.templatename);
						xmlElement.SetAttribute("fee", current.fee);
						xmlElement.SetAttribute("feetype", current.feetype);
						xmlElement.SetAttribute("oneadd", current.oneadd);
						xmlElement.SetAttribute("regioncode", current.regioncode);
						xmlElement.SetAttribute("regionname", current.regionname);
						xmlElement.SetAttribute("groupid", current.groupid);
						xmlElement.SetAttribute("createtime", current.createtime);
						xmlElement.SetAttribute("altertime", current.altertime);
						xmlElement.SetAttribute("orderid", current.orderid);
						xmlElement.SetAttribute("groupregionnames", current.groupregionnames);
						xmlElement.SetAttribute("groupregioncodes", current.groupregioncodes);
						xmlNode.AppendChild(xmlElement);
						num++;
					}
				}
				try
				{
					xmlDocument.Save(path);
					result = true;
				}
				catch (Exception ex)
				{
					strerror = ex.Message.ToString();
					result = false;
				}
			}
			return result;
		}
		public bool CheckTemplateName(string templatename, string path)
		{
			DataSet dataSet = new DataSet();
			dataSet.ReadXml(path);
			bool result;
			if (dataSet == null || dataSet.Tables.Count <= 1)
			{
				result = false;
			}
			else
			{
				DataTable dataTable = dataSet.Tables[1];
				foreach (DataRow dataRow in dataTable.Rows)
				{
					if (dataRow["templatename"].ToString() == templatename)
					{
						result = true;
						return result;
					}
				}
				result = false;
			}
			return result;
		}
		private int method_1(string string_0)
		{
			DataSet dataSet = new DataSet();
			dataSet.ReadXml(string_0);
			int num = 0;
			int result;
			if (dataSet == null || dataSet.Tables.Count <= 1)
			{
				result = 1;
			}
			else
			{
				DataTable dataTable = dataSet.Tables[1];
				foreach (DataRow dataRow in dataTable.Rows)
				{
					if (Convert.ToInt32(dataRow["id"]) > num)
					{
						num = Convert.ToInt32(dataRow["id"]);
					}
				}
				result = num + 1;
			}
			return result;
		}
		public int GetMaxFeeTemplateId(string path)
		{
			DataSet dataSet = new DataSet();
			dataSet.ReadXml(path);
			int num = 0;
			int result;
			if (dataSet == null || dataSet.Tables.Count <= 1)
			{
				result = 1;
			}
			else
			{
				DataTable dataTable = dataSet.Tables[1];
				foreach (DataRow dataRow in dataTable.Rows)
				{
					if (Convert.ToInt32(dataRow["templateid"]) > num)
					{
						num = Convert.ToInt32(dataRow["templateid"]);
					}
				}
				result = num + 1;
			}
			return result;
		}
	}
}
