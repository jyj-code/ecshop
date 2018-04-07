using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml;
namespace ShopNum1.Second
{
	public class XmlOperate
	{
		public void XmlToObject2<T>(string strXml, string rootName, string childName, T gparam_0, ErrorRsp errorRsp_0)
		{
			try
			{
				if (!(strXml.Trim() == ""))
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
						}
					}
				}
			}
			catch (Exception ex)
			{
				errorRsp_0.args = strXml;
				errorRsp_0.IsError = true;
				errorRsp_0.code = "8008";
				errorRsp_0.String_0 = "连接服务器发生错误！" + ex.Message;
			}
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
					else
					{
						result = false;
					}
				}
			}
			catch (Exception ex)
			{
				errorRsp_0.args = strXml;
				errorRsp_0.IsError = true;
				errorRsp_0.code = "8008";
				errorRsp_0.String_0 = "连接服务器发生错误！" + ex.Message;
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
				errorRsp_0.String_0 = "连接服务器发生错误！" + ex.Message;
				result = false;
			}
			return result;
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
	}
}
