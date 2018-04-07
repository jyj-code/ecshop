using System;
using System.Collections.Generic;
namespace ShopNum1.TbBusinessEntity
{
	public class TbItemProp
	{
		private string string_0 = string.Empty;
		private string string_1 = string.Empty;
		private string string_2 = string.Empty;
		private bool bool_0 = false;
		private bool bool_1 = false;
		private bool bool_2 = false;
		private bool bool_3 = false;
		private bool bool_4 = false;
		private bool bool_5 = false;
		private bool bool_6 = false;
		private bool bool_7 = false;
		private bool bool_8 = false;
		private string string_3 = string.Empty;
		private string string_4 = string.Empty;
		private List<TbPropValue> list_0 = new List<TbPropValue>();
		private string string_5 = string.Empty;
		private string string_6 = string.Empty;
		private int int_0 = 0;
		public string String_0
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
		public string String_1
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
		public string name
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
		public bool is_key_prop
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
			}
		}
		public bool is_sale_prop
		{
			get
			{
				return this.bool_1;
			}
			set
			{
				this.bool_1 = value;
			}
		}
		public bool is_color_prop
		{
			get
			{
				return this.bool_2;
			}
			set
			{
				this.bool_2 = value;
			}
		}
		public bool is_enum_prop
		{
			get
			{
				return this.bool_3;
			}
			set
			{
				this.bool_3 = value;
			}
		}
		public bool is_input_prop
		{
			get
			{
				return this.bool_4;
			}
			set
			{
				this.bool_4 = value;
			}
		}
		public bool is_item_prop
		{
			get
			{
				return this.bool_5;
			}
			set
			{
				this.bool_5 = value;
			}
		}
		public bool child_template
		{
			get
			{
				return this.bool_6;
			}
			set
			{
				this.bool_6 = value;
			}
		}
		public bool must
		{
			get
			{
				return this.bool_7;
			}
			set
			{
				this.bool_7 = value;
			}
		}
		public bool multi
		{
			get
			{
				return this.bool_8;
			}
			set
			{
				this.bool_8 = value;
			}
		}
		public string parent_pid
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
		public string parent_vid
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
		public List<TbPropValue> prop_values
		{
			get
			{
				return this.list_0;
			}
			set
			{
				this.list_0 = value;
			}
		}
		public string status
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
		public string is_allow_alias
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
		public int sort_order
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
	}
}
