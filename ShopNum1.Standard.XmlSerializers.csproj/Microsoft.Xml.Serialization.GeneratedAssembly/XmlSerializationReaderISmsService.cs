using System;
using System.Xml;
using System.Xml.Serialization;
namespace Microsoft.Xml.Serialization.GeneratedAssembly
{
	public class XmlSerializationReaderISmsService : XmlSerializationReader
	{
		private string string_0;
		private string string_1;
		private string string_2;
		private string string_3;
		private string string_4;
		private string string_5;
		private string string_6;
		public object[] Read1_accountResponse()
		{
			base.Reader.MoveToContent();
			object[] array = new object[1];
			base.Reader.MoveToContent();
			int num = 0;
			int readerCount = base.ReaderCount;
			while (base.Reader.NodeType != XmlNodeType.EndElement && base.Reader.NodeType != XmlNodeType.None)
			{
				if (base.Reader.IsStartElement(this.string_3, this.string_1))
				{
					bool[] array2 = new bool[1];
					if (base.Reader.IsEmptyElement)
					{
						base.Reader.Skip();
						base.Reader.MoveToContent();
						continue;
					}
					base.Reader.ReadStartElement();
					base.Reader.MoveToContent();
					int num2 = 0;
					int readerCount2 = base.ReaderCount;
					while (base.Reader.NodeType != XmlNodeType.EndElement && base.Reader.NodeType != XmlNodeType.None)
					{
						if (base.Reader.NodeType == XmlNodeType.Element)
						{
							if (!array2[0] && base.Reader.LocalName == this.string_0 && base.Reader.NamespaceURI == this.string_1)
							{
								if (base.ReadNull())
								{
									array[0] = null;
								}
								else
								{
									array[0] = base.Reader.ReadElementString();
								}
								array2[0] = true;
							}
							else
							{
								base.UnknownNode(array, "http://service.ewing.com:out");
							}
						}
						else
						{
							base.UnknownNode(array, "http://service.ewing.com:out");
						}
						base.Reader.MoveToContent();
						base.CheckReaderCount(ref num2, ref readerCount2);
					}
					base.ReadEndElement();
				}
				else
				{
					base.UnknownNode(null, "http://service.ewing.com:accountResponse");
				}
				base.Reader.MoveToContent();
				base.CheckReaderCount(ref num, ref readerCount);
			}
			return array;
		}
		public object[] Read2_accountResponseOutHeaders()
		{
			base.Reader.MoveToContent();
			object[] array = new object[0];
			base.Reader.MoveToContent();
			int num = 0;
			int readerCount = base.ReaderCount;
			while (base.Reader.NodeType != XmlNodeType.EndElement && base.Reader.NodeType != XmlNodeType.None)
			{
				if (base.Reader.NodeType == XmlNodeType.Element)
				{
					base.UnknownNode(array, "");
				}
				else
				{
					base.UnknownNode(array, "");
				}
				base.Reader.MoveToContent();
				base.CheckReaderCount(ref num, ref readerCount);
			}
			return array;
		}
		public object[] Read3_updatePasswordResponse()
		{
			base.Reader.MoveToContent();
			object[] array = new object[1];
			base.Reader.MoveToContent();
			int num = 0;
			int readerCount = base.ReaderCount;
			while (base.Reader.NodeType != XmlNodeType.EndElement && base.Reader.NodeType != XmlNodeType.None)
			{
				if (base.Reader.IsStartElement(this.string_4, this.string_1))
				{
					bool[] array2 = new bool[1];
					if (base.Reader.IsEmptyElement)
					{
						base.Reader.Skip();
						base.Reader.MoveToContent();
						continue;
					}
					base.Reader.ReadStartElement();
					base.Reader.MoveToContent();
					int num2 = 0;
					int readerCount2 = base.ReaderCount;
					while (base.Reader.NodeType != XmlNodeType.EndElement && base.Reader.NodeType != XmlNodeType.None)
					{
						if (base.Reader.NodeType == XmlNodeType.Element)
						{
							if (!array2[0] && base.Reader.LocalName == this.string_0 && base.Reader.NamespaceURI == this.string_1)
							{
								if (base.ReadNull())
								{
									array[0] = null;
								}
								else
								{
									array[0] = base.Reader.ReadElementString();
								}
								array2[0] = true;
							}
							else
							{
								base.UnknownNode(array, "http://service.ewing.com:out");
							}
						}
						else
						{
							base.UnknownNode(array, "http://service.ewing.com:out");
						}
						base.Reader.MoveToContent();
						base.CheckReaderCount(ref num2, ref readerCount2);
					}
					base.ReadEndElement();
				}
				else
				{
					base.UnknownNode(null, "http://service.ewing.com:updatePasswordResponse");
				}
				base.Reader.MoveToContent();
				base.CheckReaderCount(ref num, ref readerCount);
			}
			return array;
		}
		public object[] Read4_Item()
		{
			base.Reader.MoveToContent();
			object[] array = new object[0];
			base.Reader.MoveToContent();
			int num = 0;
			int readerCount = base.ReaderCount;
			while (base.Reader.NodeType != XmlNodeType.EndElement && base.Reader.NodeType != XmlNodeType.None)
			{
				if (base.Reader.NodeType == XmlNodeType.Element)
				{
					base.UnknownNode(array, "");
				}
				else
				{
					base.UnknownNode(array, "");
				}
				base.Reader.MoveToContent();
				base.CheckReaderCount(ref num, ref readerCount);
			}
			return array;
		}
		public object[] Read5_reportResponse()
		{
			base.Reader.MoveToContent();
			object[] array = new object[1];
			base.Reader.MoveToContent();
			int num = 0;
			int readerCount = base.ReaderCount;
			while (base.Reader.NodeType != XmlNodeType.EndElement && base.Reader.NodeType != XmlNodeType.None)
			{
				if (base.Reader.IsStartElement(this.string_2, this.string_1))
				{
					bool[] array2 = new bool[1];
					if (base.Reader.IsEmptyElement)
					{
						base.Reader.Skip();
						base.Reader.MoveToContent();
						continue;
					}
					base.Reader.ReadStartElement();
					base.Reader.MoveToContent();
					int num2 = 0;
					int readerCount2 = base.ReaderCount;
					while (base.Reader.NodeType != XmlNodeType.EndElement && base.Reader.NodeType != XmlNodeType.None)
					{
						if (base.Reader.NodeType == XmlNodeType.Element)
						{
							if (!array2[0] && base.Reader.LocalName == this.string_0 && base.Reader.NamespaceURI == this.string_1)
							{
								if (base.ReadNull())
								{
									array[0] = null;
								}
								else
								{
									array[0] = base.Reader.ReadElementString();
								}
								array2[0] = true;
							}
							else
							{
								base.UnknownNode(array, "http://service.ewing.com:out");
							}
						}
						else
						{
							base.UnknownNode(array, "http://service.ewing.com:out");
						}
						base.Reader.MoveToContent();
						base.CheckReaderCount(ref num2, ref readerCount2);
					}
					base.ReadEndElement();
				}
				else
				{
					base.UnknownNode(null, "http://service.ewing.com:reportResponse");
				}
				base.Reader.MoveToContent();
				base.CheckReaderCount(ref num, ref readerCount);
			}
			return array;
		}
		public object[] Read6_reportResponseOutHeaders()
		{
			base.Reader.MoveToContent();
			object[] array = new object[0];
			base.Reader.MoveToContent();
			int num = 0;
			int readerCount = base.ReaderCount;
			while (base.Reader.NodeType != XmlNodeType.EndElement && base.Reader.NodeType != XmlNodeType.None)
			{
				if (base.Reader.NodeType == XmlNodeType.Element)
				{
					base.UnknownNode(array, "");
				}
				else
				{
					base.UnknownNode(array, "");
				}
				base.Reader.MoveToContent();
				base.CheckReaderCount(ref num, ref readerCount);
			}
			return array;
		}
		public object[] Read7_smsSendResponse()
		{
			base.Reader.MoveToContent();
			object[] array = new object[1];
			base.Reader.MoveToContent();
			int num = 0;
			int readerCount = base.ReaderCount;
			while (base.Reader.NodeType != XmlNodeType.EndElement && base.Reader.NodeType != XmlNodeType.None)
			{
				if (base.Reader.IsStartElement(this.string_5, this.string_1))
				{
					bool[] array2 = new bool[1];
					if (base.Reader.IsEmptyElement)
					{
						base.Reader.Skip();
						base.Reader.MoveToContent();
						continue;
					}
					base.Reader.ReadStartElement();
					base.Reader.MoveToContent();
					int num2 = 0;
					int readerCount2 = base.ReaderCount;
					while (base.Reader.NodeType != XmlNodeType.EndElement && base.Reader.NodeType != XmlNodeType.None)
					{
						if (base.Reader.NodeType == XmlNodeType.Element)
						{
							if (!array2[0] && base.Reader.LocalName == this.string_0 && base.Reader.NamespaceURI == this.string_1)
							{
								if (base.ReadNull())
								{
									array[0] = null;
								}
								else
								{
									array[0] = base.Reader.ReadElementString();
								}
								array2[0] = true;
							}
							else
							{
								base.UnknownNode(array, "http://service.ewing.com:out");
							}
						}
						else
						{
							base.UnknownNode(array, "http://service.ewing.com:out");
						}
						base.Reader.MoveToContent();
						base.CheckReaderCount(ref num2, ref readerCount2);
					}
					base.ReadEndElement();
				}
				else
				{
					base.UnknownNode(null, "http://service.ewing.com:smsSendResponse");
				}
				base.Reader.MoveToContent();
				base.CheckReaderCount(ref num, ref readerCount);
			}
			return array;
		}
		public object[] Read8_smsSendResponseOutHeaders()
		{
			base.Reader.MoveToContent();
			object[] array = new object[0];
			base.Reader.MoveToContent();
			int num = 0;
			int readerCount = base.ReaderCount;
			while (base.Reader.NodeType != XmlNodeType.EndElement && base.Reader.NodeType != XmlNodeType.None)
			{
				if (base.Reader.NodeType == XmlNodeType.Element)
				{
					base.UnknownNode(array, "");
				}
				else
				{
					base.UnknownNode(array, "");
				}
				base.Reader.MoveToContent();
				base.CheckReaderCount(ref num, ref readerCount);
			}
			return array;
		}
		public object[] Read9_moResponse()
		{
			base.Reader.MoveToContent();
			object[] array = new object[1];
			base.Reader.MoveToContent();
			int num = 0;
			int readerCount = base.ReaderCount;
			while (base.Reader.NodeType != XmlNodeType.EndElement && base.Reader.NodeType != XmlNodeType.None)
			{
				if (base.Reader.IsStartElement(this.string_6, this.string_1))
				{
					bool[] array2 = new bool[1];
					if (base.Reader.IsEmptyElement)
					{
						base.Reader.Skip();
						base.Reader.MoveToContent();
						continue;
					}
					base.Reader.ReadStartElement();
					base.Reader.MoveToContent();
					int num2 = 0;
					int readerCount2 = base.ReaderCount;
					while (base.Reader.NodeType != XmlNodeType.EndElement && base.Reader.NodeType != XmlNodeType.None)
					{
						if (base.Reader.NodeType == XmlNodeType.Element)
						{
							if (!array2[0] && base.Reader.LocalName == this.string_0 && base.Reader.NamespaceURI == this.string_1)
							{
								if (base.ReadNull())
								{
									array[0] = null;
								}
								else
								{
									array[0] = base.Reader.ReadElementString();
								}
								array2[0] = true;
							}
							else
							{
								base.UnknownNode(array, "http://service.ewing.com:out");
							}
						}
						else
						{
							base.UnknownNode(array, "http://service.ewing.com:out");
						}
						base.Reader.MoveToContent();
						base.CheckReaderCount(ref num2, ref readerCount2);
					}
					base.ReadEndElement();
				}
				else
				{
					base.UnknownNode(null, "http://service.ewing.com:moResponse");
				}
				base.Reader.MoveToContent();
				base.CheckReaderCount(ref num, ref readerCount);
			}
			return array;
		}
		public object[] Read10_moResponseOutHeaders()
		{
			base.Reader.MoveToContent();
			object[] array = new object[0];
			base.Reader.MoveToContent();
			int num = 0;
			int readerCount = base.ReaderCount;
			while (base.Reader.NodeType != XmlNodeType.EndElement && base.Reader.NodeType != XmlNodeType.None)
			{
				if (base.Reader.NodeType == XmlNodeType.Element)
				{
					base.UnknownNode(array, "");
				}
				else
				{
					base.UnknownNode(array, "");
				}
				base.Reader.MoveToContent();
				base.CheckReaderCount(ref num, ref readerCount);
			}
			return array;
		}
		protected override void InitCallbacks()
		{
		}
		protected override void InitIDs()
		{
			this.string_0 = base.Reader.NameTable.Add("out");
			this.string_1 = base.Reader.NameTable.Add("http://service.ewing.com");
			this.string_2 = base.Reader.NameTable.Add("reportResponse");
			this.string_3 = base.Reader.NameTable.Add("accountResponse");
			this.string_4 = base.Reader.NameTable.Add("updatePasswordResponse");
			this.string_5 = base.Reader.NameTable.Add("smsSendResponse");
			this.string_6 = base.Reader.NameTable.Add("moResponse");
		}
	}
}
