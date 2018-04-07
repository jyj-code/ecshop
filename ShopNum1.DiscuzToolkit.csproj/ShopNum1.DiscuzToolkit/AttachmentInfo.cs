using Newtonsoft.Json;
using System;
using System.Xml.Serialization;
namespace ShopNum1.DiscuzToolkit
{
	public class AttachmentInfo
	{
		private int int_0;
		private int int_1;
		private int int_2;
		private int int_3;
		private string string_0;
		private int int_4;
		private string string_1;
		private string string_2;
		private string string_3;
		private long long_0;
		private string string_4;
		private int int_5;
		private int int_6;
		private int int_7;
		private string string_5;
		private int int_8;
		private int int_9;
		private int int_10;
		private string string_6 = string.Empty;
		private int int_11 = 0;
		private int int_12 = 0;
		[JsonProperty("download_perm"), XmlElement("download_perm")]
		public int Getattachperm
		{
			get
			{
				return this.int_8;
			}
			set
			{
				this.int_8 = value;
			}
		}
		[JsonProperty("is_image"), XmlElement("is_image")]
		public int Attachimgpost
		{
			get
			{
				return this.int_9;
			}
			set
			{
				this.int_9 = value;
			}
		}
		[JsonProperty("allow_read"), XmlElement("allow_read")]
		public int Allowread
		{
			get
			{
				return this.int_10;
			}
			set
			{
				this.int_10 = value;
			}
		}
		[JsonProperty("preview"), XmlElement("preview")]
		public string Preview
		{
			get
			{
				return this.string_6;
			}
			set
			{
				this.string_6 = value;
			}
		}
		[JsonProperty("is_bought"), XmlElement("is_bought")]
		public int Isbought
		{
			get
			{
				return this.int_11;
			}
			set
			{
				this.int_11 = value;
			}
		}
		[JsonProperty("inserted"), XmlElement("inserted")]
		public int Inserted
		{
			get
			{
				return this.int_12;
			}
			set
			{
				this.int_12 = value;
			}
		}
		[JsonProperty("aid"), XmlElement("aid")]
		public int Aid
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_0 = value;
			}
		}
		[JsonProperty("uid"), XmlElement("uid")]
		public int Uid
		{
			get
			{
				return this.int_1;
			}
			set
			{
				this.int_1 = value;
			}
		}
		[JsonProperty("tid"), XmlElement("tid")]
		public int Tid
		{
			get
			{
				return this.int_2;
			}
			set
			{
				this.int_2 = value;
			}
		}
		[JsonProperty("pid"), XmlElement("pid")]
		public int Pid
		{
			get
			{
				return this.int_3;
			}
			set
			{
				this.int_3 = value;
			}
		}
		[JsonProperty("post_date_time"), XmlElement("post_date_time")]
		public string Postdatetime
		{
			get
			{
				return this.string_0;
			}
			set
			{
				this.string_0 = value;
			}
		}
		[JsonProperty("read_perm"), XmlElement("read_perm")]
		public int Readperm
		{
			get
			{
				return this.int_4;
			}
			set
			{
				this.int_4 = value;
			}
		}
		[JsonProperty("file_name"), XmlElement("file_name")]
		public string Filename
		{
			get
			{
				return this.string_1;
			}
			set
			{
				this.string_1 = value;
			}
		}
		[JsonProperty("description"), XmlElement("description")]
		public string Description
		{
			get
			{
				return this.string_2;
			}
			set
			{
				this.string_2 = value;
			}
		}
		[JsonProperty("file_type"), XmlElement("file_type")]
		public string Filetype
		{
			get
			{
				return this.string_3;
			}
			set
			{
				this.string_3 = value;
			}
		}
		[JsonProperty("file_size"), XmlElement("file_size")]
		public long Filesize
		{
			get
			{
				return this.long_0;
			}
			set
			{
				this.long_0 = value;
			}
		}
		[JsonProperty("original_file_name"), XmlElement("original_file_name")]
		public string Attachment
		{
			get
			{
				return this.string_4;
			}
			set
			{
				this.string_4 = value;
			}
		}
		[JsonProperty("download_count"), XmlElement("download_count")]
		public int Downloads
		{
			get
			{
				return this.int_5;
			}
			set
			{
				this.int_5 = value;
			}
		}
		[JsonProperty("price"), XmlElement("price")]
		public int Attachprice
		{
			get
			{
				return this.int_6;
			}
			set
			{
				this.int_6 = value;
			}
		}
		[JsonIgnore, XmlIgnore]
		public int Sys_index
		{
			get
			{
				return this.int_7;
			}
			set
			{
				this.int_7 = value;
			}
		}
		[JsonIgnore, XmlIgnore]
		public string Sys_noupload
		{
			get
			{
				return this.string_5;
			}
			set
			{
				this.string_5 = value;
			}
		}
	}
}
