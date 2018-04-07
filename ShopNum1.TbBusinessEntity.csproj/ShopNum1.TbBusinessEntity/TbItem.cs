using System;
using System.Collections.Generic;
namespace ShopNum1.TbBusinessEntity
{
	public class TbItem
	{
		private string string_0 = string.Empty;
		private string string_1 = string.Empty;
		private string string_2 = string.Empty;
		private string string_3 = string.Empty;
		private string string_4 = string.Empty;
		private string string_5 = string.Empty;
		private string string_6 = string.Empty;
		private string string_7 = string.Empty;
		private string string_8 = string.Empty;
		private string string_9 = string.Empty;
		private string string_10 = string.Empty;
		private string string_11 = string.Empty;
		private string string_12 = string.Empty;
		private string string_13 = string.Empty;
		private string string_14 = string.Empty;
		private string string_15 = string.Empty;
		private string string_16 = string.Empty;
		private string string_17 = string.Empty;
		private TbLocationItem tbLocationItem_0 = new TbLocationItem();
		private string string_18 = "0.00";
		private string string_19 = "0.00";
		private string string_20 = "0.00";
		private string string_21 = "0.00";
		private string string_22 = string.Empty;
		private string string_23 = string.Empty;
		private string string_24 = string.Empty;
		private string string_25 = string.Empty;
		private string string_26 = string.Empty;
		private string string_27 = string.Empty;
		private string string_28 = string.Empty;
		private string string_29 = string.Empty;
		private string string_30 = string.Empty;
		private string string_31 = string.Empty;
		private string string_32 = string.Empty;
		private string string_33 = string.Empty;
		private string string_34 = string.Empty;
		private List<TbItemImg> list_0 = new List<TbItemImg>();
		private List<TbPropImg> list_1 = new List<TbPropImg>();
		private List<TbSku> list_2 = new List<TbSku>();
		private string string_35 = string.Empty;
		private string string_36 = string.Empty;
		private string string_37 = string.Empty;
		private string string_38 = string.Empty;
        public string num
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
		public string detail_url
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
		public string num_iid
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
		public string title
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
		public string nick
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
		public string type
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
		public string String_1
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
		public string seller_cids
		{
			get
			{
				return this.string_7;
			}
			set
			{
				this.string_7 = value;
			}
		}
		public string props
		{
			get
			{
				return this.string_8;
			}
			set
			{
				this.string_8 = value;
			}
		}
		public string input_pids
		{
			get
			{
				return this.string_9;
			}
			set
			{
				this.string_9 = value;
			}
		}
		public string input_str
		{
			get
			{
				return this.string_10;
			}
			set
			{
				this.string_10 = value;
			}
		}
		public string desc
		{
			get
			{
				return this.string_11;
			}
			set
			{
				this.string_11 = value;
			}
		}
		public string pic_url
		{
			get
			{
				return this.string_12;
			}
			set
			{
				this.string_12 = value;
			}
		}
		public string String_2
		{
			get
			{
				return this.string_13;
			}
			set
			{
				this.string_13 = value;
			}
		}
		public string valid_thru
		{
			get
			{
				return this.string_14;
			}
			set
			{
				this.string_14 = value;
			}
		}
		public string list_time
		{
			get
			{
				string result;
				try
				{
					result = (this.string_15 = Convert.ToDateTime(this.string_15).ToString("yyyy-MM-dd HH:mm:ss"));
				}
				catch
				{
					result = ((this.string_15 == string.Empty) ? "1990-1-1 00:00:00" : "1990-1-1 00:00:00");
				}
				return result;
			}
			set
			{
				this.string_15 = value;
			}
		}
		public string delist_time
		{
			get
			{
				string result;
				try
				{
					result = (this.string_16 = Convert.ToDateTime(this.string_16).ToString("yyyy-MM-dd HH:mm:ss"));
				}
				catch
				{
					result = ((this.string_16 == string.Empty) ? "1990-1-1 00:00:00" : "1990-1-1 00:00:00");
				}
				return result;
			}
			set
			{
				this.string_16 = value;
			}
		}
		public string stuff_status
		{
			get
			{
				return this.string_17;
			}
			set
			{
				this.string_17 = value;
			}
		}
		public TbLocationItem location
		{
			get
			{
				return this.tbLocationItem_0;
			}
			set
			{
				this.tbLocationItem_0 = value;
			}
		}
		public string price
		{
			get
			{
				string result;
				try
				{
					result = Convert.ToDouble(this.string_18).ToString("#.00");
				}
				catch
				{
					result = ((this.string_18 != string.Empty) ? "0.00" : "");
				}
				return result;
			}
			set
			{
				this.string_18 = value;
			}
		}
		public string post_fee
		{
			get
			{
				string result;
				try
				{
					result = Convert.ToDouble(this.string_19).ToString(".00");
				}
				catch
				{
					result = ((this.string_19 != string.Empty) ? "0.00" : "");
				}
				return result;
			}
			set
			{
				this.string_19 = value;
			}
		}
		public string express_fee
		{
			get
			{
				string result;
				try
				{
					result = Convert.ToDouble(this.string_20).ToString(".00");
				}
				catch
				{
					result = ((this.string_20 != string.Empty) ? "0.00" : "");
				}
				return result;
			}
			set
			{
				this.string_20 = value;
			}
		}
		public string ems_fee
		{
			get
			{
				string result;
				try
				{
					result = Convert.ToDouble(this.string_21).ToString(".00");
				}
				catch
				{
					result = ((this.string_21 != string.Empty) ? "0.00" : "");
				}
				return result;
			}
			set
			{
				this.string_21 = value;
			}
		}
		public string has_discount
		{
			get
			{
				return this.string_22;
			}
			set
			{
				this.string_22 = value;
			}
		}
		public string freight_payer
		{
			get
			{
				return this.string_23;
			}
			set
			{
				this.string_23 = value;
			}
		}
		public string has_invoice
		{
			get
			{
				return this.string_24;
			}
			set
			{
				this.string_24 = value;
			}
		}
		public string has_warranty
		{
			get
			{
				return this.string_25;
			}
			set
			{
				this.string_25 = value;
			}
		}
		public string has_showcase
		{
			get
			{
				return this.string_26;
			}
			set
			{
				this.string_26 = value;
			}
		}
		public string modified
		{
			get
			{
				string result;
				try
				{
					result = Convert.ToDateTime(this.string_27).ToString("yyyy-MM-dd HH:mm:ss");
				}
				catch
				{
					result = ((this.string_27.Trim() != "") ? "1990-1-1 00:00:00" : "1990-1-1 00:00:00");
				}
				return result;
			}
			set
			{
				this.string_27 = value;
			}
		}
		public string increment
		{
			get
			{
				return this.string_28;
			}
			set
			{
				this.string_28 = value;
			}
		}
		public string auto_repost
		{
			get
			{
				return this.string_29;
			}
			set
			{
				this.string_29 = value;
			}
		}
		public string approve_status
		{
			get
			{
				return this.string_30;
			}
			set
			{
				this.string_30 = value;
			}
		}
		public string postage_id
		{
			get
			{
				return this.string_31;
			}
			set
			{
				this.string_31 = value;
			}
		}
		public string product_id
		{
			get
			{
				return this.string_32;
			}
			set
			{
				this.string_32 = value;
			}
		}
		public string auction_point
		{
			get
			{
				return this.string_33;
			}
			set
			{
				this.string_33 = value;
			}
		}
		public string property_alias
		{
			get
			{
				return this.string_34;
			}
			set
			{
				this.string_34 = value;
			}
		}
		public List<TbItemImg> item_imgs
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
		public List<TbPropImg> prop_imgs
		{
			get
			{
				return this.list_1;
			}
			set
			{
				this.list_1 = value;
			}
		}
		public List<TbSku> skus
		{
			get
			{
				return this.list_2;
			}
			set
			{
				this.list_2 = value;
			}
		}
		public string outer_id
		{
			get
			{
				return this.string_35;
			}
			set
			{
				this.string_35 = value;
			}
		}
		public string is_virtural
		{
			get
			{
				return this.string_36;
			}
			set
			{
				this.string_36 = value;
			}
		}
		public string is_taobao
		{
			get
			{
				return this.string_37;
			}
			set
			{
				this.string_37 = value;
			}
		}
		public string is_ex
		{
			get
			{
				return this.string_38;
			}
			set
			{
				this.string_38 = value;
			}
		}
	}
}
