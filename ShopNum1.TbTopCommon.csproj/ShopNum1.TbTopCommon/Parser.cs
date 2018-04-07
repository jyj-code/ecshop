using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;
using System.Xml;
namespace ShopNum1.TbTopCommon
{
	public class Parser
	{
		public int XmlToTotalResults(string strXml, string rootName)
		{
			int num = 0;
			int result;
			try
			{
				if (strXml.Trim() == "")
				{
					result = 0;
					return result;
				}
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.LoadXml(strXml);
				if (xmlDocument.SelectNodes(rootName + "_response/total_results").Count != 0)
				{
					num = Convert.ToInt32(xmlDocument.SelectSingleNode(rootName + "_response/total_results").InnerText);
				}
			}
			catch (Exception)
			{
			}
			result = num;
			return result;
		}
		public string XmlToNodeText(string strXml, string nodePath)
		{
			string result;
			if (strXml.Trim() == "")
			{
				result = "";
			}
			else
			{
				try
				{
					XmlDocument xmlDocument = new XmlDocument();
					xmlDocument.LoadXml(strXml);
					if (xmlDocument.SelectSingleNode(nodePath) != null)
					{
						result = xmlDocument.SelectSingleNode(nodePath).InnerText;
					}
					else
					{
						result = "";
					}
				}
				catch (Exception)
				{
					result = "";
				}
			}
			return result;
		}
		public bool XmlToObject2(string strXml, string rootName, string childName, object object_0, ErrorRsp errorRsp_0)
		{
			bool result;
			try
			{
				if (strXml.Trim() == "")
				{
					result = false;
				}
				else
				{
					string xpath = (childName.Trim() != "") ? (rootName + "_response/" + childName) : (rootName + "_response");
					XmlDocument xmlDocument = new XmlDocument();
					xmlDocument.LoadXml(strXml);
					if (xmlDocument.SelectNodes(xpath).Count != 0)
					{
						XmlNodeList xmlNodeList = xmlDocument.SelectNodes(xpath);
						foreach (XmlNode xmlNode in xmlNodeList)
						{
							foreach (XmlNode xmlNode2 in xmlNode)
							{
								if (xmlNode2.ChildNodes.Count == 1)
								{
									this.XmlToObject(object_0, xmlNode2.Name, xmlNode2.InnerText);
								}
								else
								{
									for (int i = 0; i < xmlNode2.ChildNodes.Count; i++)
									{
										this.XmlToObject(xmlNode2.Name, object_0, xmlNode2.ChildNodes[i].Name, xmlNode2.ChildNodes[i].InnerText);
									}
								}
							}
						}
						result = true;
					}
					else if (this.IsXmlError2(xmlDocument, errorRsp_0))
					{
						result = false;
					}
					else
					{
						errorRsp_0.code = "-1";
						result = false;
					}
				}
			}
			catch (Exception ex)
			{
				errorRsp_0.args = strXml;
				errorRsp_0.IsError = true;
				errorRsp_0.code = "8008";
				errorRsp_0.msg = "连接服务器发生错误！" + ex.Message;
				result = false;
			}
			return result;
		}
		public bool XmlToObject2(string strXml, string rootName, object object_0, ErrorRsp errorRsp_0)
		{
			return this.XmlToObject2(strXml, rootName, "", object_0, errorRsp_0);
		}
		public bool XmlToObject2<T>(string strXml, string rootName, string childName, List<T> objs)
		{
			return this.XmlToObject2<T>(strXml, rootName, childName, objs, new ErrorRsp());
		}
		public bool XmlToObject2<T>(string strXml, string rootName, string childName, List<T> objs, ErrorRsp errorRsp_0)
		{
			bool result;
			try
			{
				if (strXml.Trim() == "")
				{
					result = false;
				}
				else
				{
					XmlDocument xmlDocument = new XmlDocument();
					xmlDocument.LoadXml(strXml);
					if (xmlDocument.SelectNodes(rootName + "_response").Count != 0)
					{
						XmlNodeList xmlNodeList = xmlDocument.SelectNodes((childName.Trim() != "") ? (rootName + "_response/" + childName) : (rootName + "_response"));
						foreach (XmlNode xmlNode in xmlNodeList)
						{
							T t = (T)((object)Activator.CreateInstance(typeof(T)));
							foreach (XmlNode xmlNode2 in xmlNode)
							{
								if (xmlNode2.ChildNodes.Count == 1)
								{
									this.XmlToObject(t, xmlNode2.Name, xmlNode2.InnerText);
								}
								else
								{
									for (int i = 0; i < xmlNode2.ChildNodes.Count; i++)
									{
										this.XmlToObject(xmlNode2.Name, t, xmlNode2.ChildNodes[i].Name, xmlNode2.ChildNodes[i].InnerText);
									}
								}
							}
							objs.Add(t);
						}
						result = true;
					}
					else if (this.IsXmlError2(xmlDocument, errorRsp_0))
					{
						result = false;
					}
					else
					{
						errorRsp_0.code = "-1";
						result = false;
					}
				}
			}
			catch (Exception ex)
			{
				errorRsp_0.args = strXml;
				errorRsp_0.IsError = true;
				errorRsp_0.code = "8008";
                errorRsp_0.msg = "连接服务器发生错误！" + ex.Message;
				result = false;
			}
			return result;
		}
		public bool XmlToObject2<T>(string strXml, string rootName, string childName, string childKeyValue, string grandChildName, List<T> objs)
		{
			return this.XmlToObject2<T>(strXml, rootName, childName, childKeyValue, grandChildName, objs, new ErrorRsp());
		}
		public bool XmlToObject2<T>(string strXml, string rootName, string childName, string childKeyValue, string grandChildName, List<T> objs, ErrorRsp errorRsp_0)
		{
			bool result;
			try
			{
				if (strXml.Trim() == "")
				{
					result = false;
				}
				else
				{
					XmlDocument xmlDocument = new XmlDocument();
					xmlDocument.LoadXml(strXml);
					if (xmlDocument.SelectNodes(rootName + "_response").Count != 0)
					{
						XmlNodeList xmlNodeList = xmlDocument.SelectNodes((childName.Trim() != "") ? (rootName + "_response/" + childName) : (rootName + "_response"));
						foreach (XmlNode xmlNode in xmlNodeList)
						{
							if (xmlNode.InnerText.Contains(childKeyValue))
							{
								XmlNodeList xmlNodeList2 = xmlNode.SelectNodes(grandChildName);
								if (xmlNodeList2.Count > 0)
								{
									foreach (XmlNode xmlNode2 in xmlNodeList2)
									{
										if (xmlNode2.ParentNode.ParentNode.InnerText.Contains(childKeyValue))
										{
											T t = (T)((object)Activator.CreateInstance(typeof(T)));
											foreach (XmlNode xmlNode3 in xmlNode2)
											{
												if (xmlNode3.ChildNodes.Count == 1)
												{
													this.XmlToObject(t, xmlNode3.Name, xmlNode3.InnerText);
												}
												else
												{
													for (int i = 0; i < xmlNode3.ChildNodes.Count; i++)
													{
														this.XmlToObject(xmlNode3.Name, t, xmlNode3.ChildNodes[i].Name, xmlNode3.ChildNodes[i].InnerText);
													}
												}
											}
											objs.Add(t);
										}
									}
								}
							}
						}
						result = true;
					}
					else if (this.IsXmlError2(xmlDocument, errorRsp_0))
					{
						result = false;
					}
					else
					{
						errorRsp_0.code = "-1";
						result = false;
					}
				}
			}
			catch (Exception ex)
			{
				errorRsp_0.args = strXml;
				errorRsp_0.IsError = true;
				errorRsp_0.code = "8008";
                errorRsp_0.msg = "连接服务器发生错误！" + ex.Message;
				result = false;
			}
			return result;
		}
		public bool IsXmlError2(XmlDocument xmlDocument_0, ErrorRsp errorRsp_0)
		{
			bool result;
			if (xmlDocument_0.SelectNodes("error_response").Count != 0)
			{
				this.XmlErrorToObject2(xmlDocument_0, errorRsp_0);
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}
		public void XmlErrorToObject2(XmlDocument xmlDocument_0, ErrorRsp errorRsp_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			XmlNodeList xmlNodeList = xmlDocument_0.SelectNodes("error_response/args/arg");
			foreach (XmlNode xmlNode in xmlNodeList)
			{
				if (xmlNode.Name == "arg")
				{
					stringBuilder.Append(xmlNode.SelectNodes("key").Item(0).InnerText + "=" + xmlNode.SelectNodes("value").Item(0).InnerText + "|");
				}
			}
			errorRsp_0.args = stringBuilder.ToString();
			errorRsp_0.IsError = true;
			errorRsp_0.code = xmlDocument_0.SelectSingleNode("error_response/code").InnerText;
            errorRsp_0.msg = xmlDocument_0.SelectSingleNode("error_response/msg").InnerText;
			errorRsp_0.sub_code = ((xmlDocument_0.SelectSingleNode("error_response/sub_code") != null) ? xmlDocument_0.SelectSingleNode("error_response/sub_code").InnerText : "");
			errorRsp_0.sub_msg = ((xmlDocument_0.SelectSingleNode("error_response/sub_msg") != null) ? xmlDocument_0.SelectSingleNode("error_response/sub_msg").InnerText : "");
		}
		protected void XmlToObject(object oPut, string name, string value)
		{
			PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(oPut).Find(name, true);
			if (propertyDescriptor != null && (propertyDescriptor.PropertyType == typeof(int) || propertyDescriptor.PropertyType == typeof(int?) || propertyDescriptor.PropertyType == typeof(long) || propertyDescriptor.PropertyType == typeof(long?) || propertyDescriptor.PropertyType == typeof(string) || propertyDescriptor.PropertyType == typeof(DateTime) || propertyDescriptor.PropertyType == typeof(DateTime?) || propertyDescriptor.PropertyType == typeof(bool) || propertyDescriptor.PropertyType == typeof(bool?) || propertyDescriptor.PropertyType == typeof(decimal) || propertyDescriptor.PropertyType == typeof(decimal?) || propertyDescriptor.PropertyType == typeof(DateTime) || propertyDescriptor.PropertyType == typeof(DateTime?)))
			{
				if (propertyDescriptor.PropertyType == typeof(int))
				{
					propertyDescriptor.SetValue(oPut, Convert.ToInt32(value));
				}
				else if (propertyDescriptor.PropertyType == typeof(int?))
				{
					propertyDescriptor.SetValue(oPut, Convert.ToInt32(value));
				}
				else if (propertyDescriptor.PropertyType == typeof(long))
				{
					propertyDescriptor.SetValue(oPut, Convert.ToInt64(value));
				}
				else if (propertyDescriptor.PropertyType == typeof(long?))
				{
					propertyDescriptor.SetValue(oPut, Convert.ToInt64(value));
				}
				else if (propertyDescriptor.PropertyType == typeof(double))
				{
					propertyDescriptor.SetValue(oPut, Convert.ToDouble(value));
				}
				else if (propertyDescriptor.PropertyType == typeof(double?))
				{
					propertyDescriptor.SetValue(oPut, Convert.ToDouble(value));
				}
				else if (propertyDescriptor.PropertyType == typeof(bool))
				{
					propertyDescriptor.SetValue(oPut, Convert.ToBoolean(value));
				}
				else if (propertyDescriptor.PropertyType == typeof(bool?))
				{
					propertyDescriptor.SetValue(oPut, Convert.ToBoolean(value));
				}
				else if (propertyDescriptor.PropertyType == typeof(decimal))
				{
					propertyDescriptor.SetValue(oPut, Convert.ToDecimal(value));
				}
				else if (propertyDescriptor.PropertyType == typeof(decimal?))
				{
					propertyDescriptor.SetValue(oPut, Convert.ToDecimal(value));
				}
				else if (propertyDescriptor.PropertyType == typeof(DateTime))
				{
					propertyDescriptor.SetValue(oPut, Convert.ToDateTime(value));
				}
				else if (propertyDescriptor.PropertyType == typeof(DateTime?))
				{
					propertyDescriptor.SetValue(oPut, Convert.ToDateTime(value));
				}
				else
				{
					propertyDescriptor.SetValue(oPut, value);
				}
			}
		}
		protected void XmlToObject(string parentName, object oPut, string name, string value)
		{
			PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(oPut).Find(parentName, true);
			if (propertyDescriptor != null)
			{
				PropertyDescriptor propertyDescriptor2 = TypeDescriptor.GetProperties(propertyDescriptor.GetValue(oPut)).Find(name, true);
				if (propertyDescriptor2 != null && (propertyDescriptor2.PropertyType == typeof(int) || propertyDescriptor2.PropertyType == typeof(int?) || propertyDescriptor2.PropertyType == typeof(long) || propertyDescriptor2.PropertyType == typeof(long?) || propertyDescriptor2.PropertyType == typeof(string) || propertyDescriptor2.PropertyType == typeof(DateTime) || propertyDescriptor2.PropertyType == typeof(DateTime?) || propertyDescriptor2.PropertyType == typeof(bool) || propertyDescriptor2.PropertyType == typeof(bool?) || propertyDescriptor2.PropertyType == typeof(decimal) || propertyDescriptor2.PropertyType == typeof(decimal?) || propertyDescriptor2.PropertyType == typeof(DateTime) || propertyDescriptor2.PropertyType == typeof(DateTime?)))
				{
					if (propertyDescriptor2.PropertyType == typeof(int))
					{
						propertyDescriptor2.SetValue(propertyDescriptor.GetValue(oPut), Convert.ToInt32(value));
					}
					else if (propertyDescriptor2.PropertyType == typeof(int?))
					{
						propertyDescriptor2.SetValue(propertyDescriptor.GetValue(oPut), value);
					}
					else if (propertyDescriptor2.PropertyType == typeof(long))
					{
						propertyDescriptor2.SetValue(propertyDescriptor.GetValue(oPut), Convert.ToInt64(value));
					}
					else if (propertyDescriptor2.PropertyType == typeof(long?))
					{
						propertyDescriptor2.SetValue(propertyDescriptor.GetValue(oPut), Convert.ToInt64(value));
					}
					else if (propertyDescriptor2.PropertyType == typeof(bool))
					{
						propertyDescriptor2.SetValue(propertyDescriptor.GetValue(oPut), Convert.ToBoolean(value));
					}
					else if (propertyDescriptor2.PropertyType == typeof(bool?))
					{
						propertyDescriptor2.SetValue(propertyDescriptor.GetValue(oPut), Convert.ToBoolean(value));
					}
					else if (propertyDescriptor2.PropertyType == typeof(decimal))
					{
						propertyDescriptor2.SetValue(propertyDescriptor.GetValue(oPut), Convert.ToDecimal(value));
					}
					else if (propertyDescriptor2.PropertyType == typeof(decimal?))
					{
						propertyDescriptor2.SetValue(propertyDescriptor.GetValue(oPut), Convert.ToDecimal(value));
					}
					else if (propertyDescriptor2.PropertyType == typeof(DateTime?))
					{
						propertyDescriptor2.SetValue(propertyDescriptor.GetValue(oPut), Convert.ToDateTime(value));
					}
					else if (propertyDescriptor2.PropertyType == typeof(DateTime?))
					{
						propertyDescriptor2.SetValue(propertyDescriptor.GetValue(oPut), Convert.ToDateTime(value));
					}
					else
					{
						propertyDescriptor2.SetValue(propertyDescriptor.GetValue(oPut), value);
					}
				}
			}
		}
		public string GetParameters(string parameters, string string_0)
		{
			string result = string.Empty;
			try
			{
				string text = this.Base64ToString(parameters);
				string[] array = text.Split(new char[]
				{
					'&'
				});
				for (int i = 0; i < array.Length; i++)
				{
					string[] array2 = array[i].Split(new char[]
					{
						'='
					});
					if (array2[0].ToLower() == string_0.ToLower())
					{
						result = array2[1];
						break;
					}
				}
			}
			catch (Exception)
			{
			}
			return result;
		}
		public SqlParameter[] ConvertToParams(object object_0)
		{
			return this.ConvertToParams(object_0, null);
		}
		public SqlParameter[] ConvertToParams(object object_0, params SqlParameter[] commandParameters)
		{
			IDictionary<string, string> dictionary = new SortedDictionary<string, string>();
			PropertyInfo[] properties = object_0.GetType().GetProperties();
			PropertyInfo[] array = properties;
			for (int i = 0; i < array.Length; i++)
			{
				PropertyInfo propertyInfo = array[i];
				string name = propertyInfo.Name;
				if (propertyInfo.PropertyType == typeof(int) || propertyInfo.PropertyType == typeof(long) || propertyInfo.PropertyType == typeof(string) || propertyInfo.PropertyType == typeof(DateTime) || propertyInfo.PropertyType == typeof(bool) || propertyInfo.PropertyType == typeof(double))
				{
					string value = Convert.ToString(propertyInfo.GetValue(object_0, null));
					if (propertyInfo.PropertyType == typeof(int))
					{
						dictionary.Add(name, value);
					}
					else if (propertyInfo.PropertyType == typeof(long))
					{
						dictionary.Add(name, value);
					}
					else
					{
						dictionary.Add(name, value);
					}
				}
				else if (!propertyInfo.PropertyType.IsGenericType)
				{
					PropertyInfo[] properties2 = propertyInfo.GetValue(object_0, null).GetType().GetProperties();
					PropertyInfo[] array2 = properties2;
					for (int j = 0; j < array2.Length; j++)
					{
						PropertyInfo propertyInfo2 = array2[j];
						string name2 = propertyInfo2.Name;
						if (propertyInfo2.PropertyType == typeof(int) || propertyInfo2.PropertyType == typeof(long) || propertyInfo2.PropertyType == typeof(string) || propertyInfo2.PropertyType == typeof(DateTime) || propertyInfo2.PropertyType == typeof(bool) || propertyInfo2.PropertyType == typeof(double))
						{
							string value = Convert.ToString(propertyInfo2.GetValue(propertyInfo.GetValue(object_0, null), null));
							dictionary.Add(name + name2, value);
						}
					}
				}
			}
			SqlParameter[] array3 = new SqlParameter[dictionary.Count + ((commandParameters != null) ? commandParameters.Length : 0)];
			int num = 0;
			foreach (KeyValuePair<string, string> current in dictionary)
			{
				if (current.Key.Contains("price") || current.Key.Contains("_fee") || current.Key.Contains("payment"))
				{
					array3[num] = new SqlParameter("@" + current.Key.Replace("_", ""), SqlDbType.Money);
					array3[num].Value = current.Value;
				}
				else if (current.Key.Contains("time") || current.Key.Contains("modified"))
				{
					array3[num] = new SqlParameter("@" + current.Key.Replace("_", ""), SqlDbType.DateTime);
					array3[num].Value = current.Value;
				}
				else if (current.Key.Contains("desc"))
				{
					array3[num] = new SqlParameter("@" + current.Key.Replace("_", ""), SqlDbType.NText);
					array3[num].Value = current.Value;
				}
				else
				{
					array3[num] = new SqlParameter("@" + current.Key.Replace("_", ""), current.Value);
				}
				num++;
			}
			if (commandParameters != null)
			{
				for (int i = 0; i < commandParameters.Length; i++)
				{
					SqlParameter sqlParameter = commandParameters[i];
					array3[num] = sqlParameter;
					num++;
				}
			}
			return array3;
		}
		public bool NewXmlToObject2<T>(string strXml, string rootName, string childName, List<T> objs, ErrorRsp errorRsp_0, string string_0, string name)
		{
			bool result;
			try
			{
				if (strXml.Trim() != "")
				{
					XmlDocument xmlDocument = new XmlDocument();
					xmlDocument.LoadXml(strXml);
					if (xmlDocument.SelectNodes(rootName + "_response").Count != 0)
					{
						XmlNodeList xmlNodeList = xmlDocument.SelectNodes((childName.Trim() != "") ? (rootName + "_response/" + childName) : (rootName + "_response"));
						foreach (XmlNode xmlNode in xmlNodeList)
						{
							if (xmlNode.ParentNode.PreviousSibling.Name == name && xmlNode.ParentNode.PreviousSibling.InnerText == string_0)
							{
								T t = (T)((object)Activator.CreateInstance(typeof(T)));
								foreach (XmlNode xmlNode2 in xmlNode)
								{
									if (xmlNode2.ChildNodes.Count == 1)
									{
										this.XmlToObject(t, xmlNode2.Name, xmlNode2.InnerText);
									}
									else
									{
										for (int i = 0; i < xmlNode2.ChildNodes.Count; i++)
										{
											this.XmlToObject(xmlNode2.Name, t, xmlNode2.ChildNodes[i].Name, xmlNode2.ChildNodes[i].InnerText);
										}
									}
								}
								objs.Add(t);
							}
						}
						result = true;
						return result;
					}
					if (this.IsXmlError2(xmlDocument, errorRsp_0))
					{
						result = false;
						return result;
					}
					errorRsp_0.code = "-1";
				}
				result = false;
			}
			catch (Exception ex)
			{
				errorRsp_0.args = strXml;
				errorRsp_0.IsError = true;
				errorRsp_0.code = "8008";
                errorRsp_0.msg = "连接服务器发生错误！" + ex.Message;
				result = false;
			}
			return result;
		}
		public string StringToBase64(string string_0)
		{
			return Convert.ToBase64String(Encoding.Default.GetBytes(string_0));
		}
		public string Base64ToString(string string_0)
		{
			return Encoding.Default.GetString(Convert.FromBase64String(string_0));
		}
	}
}
