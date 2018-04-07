namespace ShopNum1.TbLinq
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name = "dbo.ShopNum1_TbItem")]
    public class ShopNum1_TbItem : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private decimal? _after_sale_id;
        private string _approve_status;
        private decimal? _auction_point;
        private string _auto_fill;
        private decimal? _cid;
        private DateTime? _created;
        private DateTime? _delist_time;
        private string _desc;
        private decimal? _ems_fee;
        private decimal? _express_fee;
        private bool? _freight_payer;
        private bool? _has_discount;
        private bool? _has_invoice;
        private bool? _has_showcase;
        private bool? _has_warranty;
        private int _ID;
        private string _increment;
        private string _input_pids;
        private string _input_str;
        private bool? _is_3D;
        private bool? _is_ex;
        private bool? _is_prepay;
        private bool? _is_taobao;
        private bool? _is_timing;
        private bool? _is_virtual;
        private bool? _isTaobao;
        private decimal? _item_img_Id;
        private DateTime? _list_time;
        private int? _location_Id;
        private string _Memlogid;
        private DateTime? _modified;
        private string _nick;
        private decimal? _num;
        private decimal? _num_iid;
        private bool? _one_station;
        private string _pic_url;
        private decimal? _post_fee;
        private decimal? _postage_id;
        private decimal? _price;
        private decimal? _product_id;
        private string _promoted_service;
        private decimal? _prop_imgs_Id;
        private string _property_alias;
        private string _props;
        private string _props_name;
        private decimal? _score;
        private string _second_kill;
        private string _seller_cids;
        private string _ShopName;
        private string _site_Id;
        private decimal? _site_skus_Id;
        private string _skus_Id;
        private string _stuff_status;
        private string _title;
        private string _type;
        private decimal? _valid_thru;
        private string _videos_Id;
        private bool? _violation;
        private decimal? _volume;
        private string _wap_desc;
        private string _wap_detail_url;
        private bool? _ww_status;
        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(string.Empty);

        public event PropertyChangedEventHandler PropertyChanged;

        public event PropertyChangingEventHandler PropertyChanging;

        protected virtual void SendPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected virtual void SendPropertyChanging()
        {
            if (this.PropertyChanging != null)
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        [Column(Storage = "_after_sale_id", DbType = "Decimal(36,0)")]
        public decimal? after_sale_id
        {
            get
            {
                return this._after_sale_id;
            }
            set
            {
                decimal? nullable = this._after_sale_id;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this.SendPropertyChanging();
                    this._after_sale_id = value;
                    this.SendPropertyChanged("after_sale_id");
                }
            }
        }

        [Column(Storage = "_approve_status", DbType = "NVarChar(50)")]
        public string approve_status
        {
            get
            {
                return this._approve_status;
            }
            set
            {
                if (this._approve_status != value)
                {
                    this.SendPropertyChanging();
                    this._approve_status = value;
                    this.SendPropertyChanged("approve_status");
                }
            }
        }

        [Column(Storage = "_auction_point", DbType = "Decimal(18,0)")]
        public decimal? auction_point
        {
            get
            {
                return this._auction_point;
            }
            set
            {
                decimal? nullable = this._auction_point;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this.SendPropertyChanging();
                    this._auction_point = value;
                    this.SendPropertyChanged("auction_point");
                }
            }
        }

        [Column(Storage = "_auto_fill", DbType = "NVarChar(50)")]
        public string auto_fill
        {
            get
            {
                return this._auto_fill;
            }
            set
            {
                if (this._auto_fill != value)
                {
                    this.SendPropertyChanging();
                    this._auto_fill = value;
                    this.SendPropertyChanged("auto_fill");
                }
            }
        }

        [Column(Storage = "_cid", DbType = "Decimal(22,0)")]
        public decimal? cid
        {
            get
            {
                return this._cid;
            }
            set
            {
                decimal? nullable = this._cid;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this.SendPropertyChanging();
                    this._cid = value;
                    this.SendPropertyChanged("cid");
                }
            }
        }

        [Column(Storage = "_created", DbType = "DateTime")]
        public DateTime? created
        {
            get
            {
                return this._created;
            }
            set
            {
                if (this._created != value)
                {
                    this.SendPropertyChanging();
                    this._created = value;
                    this.SendPropertyChanged("created");
                }
            }
        }

        [Column(Storage = "_delist_time", DbType = "DateTime")]
        public DateTime? delist_time
        {
            get
            {
                return this._delist_time;
            }
            set
            {
                if (this._delist_time != value)
                {
                    this.SendPropertyChanging();
                    this._delist_time = value;
                    this.SendPropertyChanged("delist_time");
                }
            }
        }

        [Column(Name = "[desc]", Storage = "_desc", DbType = "NText", UpdateCheck = UpdateCheck.Never)]
        public string desc
        {
            get
            {
                return this._desc;
            }
            set
            {
                if (this._desc != value)
                {
                    this.SendPropertyChanging();
                    this._desc = value;
                    this.SendPropertyChanged("desc");
                }
            }
        }

        [Column(Storage = "_ems_fee", DbType = "Decimal(18,2)")]
        public decimal? ems_fee
        {
            get
            {
                return this._ems_fee;
            }
            set
            {
                decimal? nullable = this._ems_fee;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this.SendPropertyChanging();
                    this._ems_fee = value;
                    this.SendPropertyChanged("ems_fee");
                }
            }
        }

        [Column(Storage = "_express_fee", DbType = "Decimal(18,2)")]
        public decimal? express_fee
        {
            get
            {
                return this._express_fee;
            }
            set
            {
                decimal? nullable = this._express_fee;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this.SendPropertyChanging();
                    this._express_fee = value;
                    this.SendPropertyChanged("express_fee");
                }
            }
        }

        [Column(Storage = "_freight_payer", DbType = "Bit")]
        public bool? freight_payer
        {
            get
            {
                return this._freight_payer;
            }
            set
            {
                if (this._freight_payer != value)
                {
                    this.SendPropertyChanging();
                    this._freight_payer = value;
                    this.SendPropertyChanged("freight_payer");
                }
            }
        }

        [Column(Storage = "_has_discount", DbType = "Bit")]
        public bool? has_discount
        {
            get
            {
                return this._has_discount;
            }
            set
            {
                if (this._has_discount != value)
                {
                    this.SendPropertyChanging();
                    this._has_discount = value;
                    this.SendPropertyChanged("has_discount");
                }
            }
        }

        [Column(Storage = "_has_invoice", DbType = "Bit")]
        public bool? has_invoice
        {
            get
            {
                return this._has_invoice;
            }
            set
            {
                if (this._has_invoice != value)
                {
                    this.SendPropertyChanging();
                    this._has_invoice = value;
                    this.SendPropertyChanged("has_invoice");
                }
            }
        }

        [Column(Storage = "_has_showcase", DbType = "Bit")]
        public bool? has_showcase
        {
            get
            {
                return this._has_showcase;
            }
            set
            {
                if (this._has_showcase != value)
                {
                    this.SendPropertyChanging();
                    this._has_showcase = value;
                    this.SendPropertyChanged("has_showcase");
                }
            }
        }

        [Column(Storage = "_has_warranty", DbType = "Bit")]
        public bool? has_warranty
        {
            get
            {
                return this._has_warranty;
            }
            set
            {
                if (this._has_warranty != value)
                {
                    this.SendPropertyChanging();
                    this._has_warranty = value;
                    this.SendPropertyChanged("has_warranty");
                }
            }
        }

        [Column(Storage = "_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                if (this._ID != value)
                {
                    this.SendPropertyChanging();
                    this._ID = value;
                    this.SendPropertyChanged("ID");
                }
            }
        }

        [Column(Storage = "_increment", DbType = "NVarChar(50)")]
        public string increment
        {
            get
            {
                return this._increment;
            }
            set
            {
                if (this._increment != value)
                {
                    this.SendPropertyChanging();
                    this._increment = value;
                    this.SendPropertyChanged("increment");
                }
            }
        }

        [Column(Storage = "_input_pids", DbType = "NVarChar(100)")]
        public string input_pids
        {
            get
            {
                return this._input_pids;
            }
            set
            {
                if (this._input_pids != value)
                {
                    this.SendPropertyChanging();
                    this._input_pids = value;
                    this.SendPropertyChanged("input_pids");
                }
            }
        }

        [Column(Storage = "_input_str", DbType = "NVarChar(100)")]
        public string input_str
        {
            get
            {
                return this._input_str;
            }
            set
            {
                if (this._input_str != value)
                {
                    this.SendPropertyChanging();
                    this._input_str = value;
                    this.SendPropertyChanged("input_str");
                }
            }
        }

        [Column(Storage = "_is_3D", DbType = "Bit")]
        public bool? is_3D
        {
            get
            {
                return this._is_3D;
            }
            set
            {
                if (this._is_3D != value)
                {
                    this.SendPropertyChanging();
                    this._is_3D = value;
                    this.SendPropertyChanged("is_3D");
                }
            }
        }

        [Column(Storage = "_is_ex", DbType = "Bit")]
        public bool? is_ex
        {
            get
            {
                return this._is_ex;
            }
            set
            {
                if (this._is_ex != value)
                {
                    this.SendPropertyChanging();
                    this._is_ex = value;
                    this.SendPropertyChanged("is_ex");
                }
            }
        }

        [Column(Storage = "_is_prepay", DbType = "Bit")]
        public bool? is_prepay
        {
            get
            {
                return this._is_prepay;
            }
            set
            {
                if (this._is_prepay != value)
                {
                    this.SendPropertyChanging();
                    this._is_prepay = value;
                    this.SendPropertyChanged("is_prepay");
                }
            }
        }

        [Column(Storage = "_is_taobao", DbType = "Bit")]
        public bool? is_taobao
        {
            get
            {
                return this._is_taobao;
            }
            set
            {
                if (this._is_taobao != value)
                {
                    this.SendPropertyChanging();
                    this._is_taobao = value;
                    this.SendPropertyChanged("is_taobao");
                }
            }
        }

        [Column(Storage = "_is_timing", DbType = "Bit")]
        public bool? is_timing
        {
            get
            {
                return this._is_timing;
            }
            set
            {
                if (this._is_timing != value)
                {
                    this.SendPropertyChanging();
                    this._is_timing = value;
                    this.SendPropertyChanged("is_timing");
                }
            }
        }

        [Column(Storage = "_is_virtual", DbType = "Bit")]
        public bool? is_virtual
        {
            get
            {
                return this._is_virtual;
            }
            set
            {
                if (this._is_virtual != value)
                {
                    this.SendPropertyChanging();
                    this._is_virtual = value;
                    this.SendPropertyChanged("is_virtual");
                }
            }
        }

        [Column(Storage = "_isTaobao", DbType = "Bit")]
        public bool? isTaobao
        {
            get
            {
                return this._isTaobao;
            }
            set
            {
                if (this._isTaobao != value)
                {
                    this.SendPropertyChanging();
                    this._isTaobao = value;
                    this.SendPropertyChanged("isTaobao");
                }
            }
        }

        [Column(Storage = "_item_img_Id", DbType = "Decimal(18,0)")]
        public decimal? item_img_Id
        {
            get
            {
                return this._item_img_Id;
            }
            set
            {
                decimal? nullable = this._item_img_Id;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this.SendPropertyChanging();
                    this._item_img_Id = value;
                    this.SendPropertyChanged("item_img_Id");
                }
            }
        }

        [Column(Storage = "_list_time", DbType = "DateTime")]
        public DateTime? list_time
        {
            get
            {
                return this._list_time;
            }
            set
            {
                if (this._list_time != value)
                {
                    this.SendPropertyChanging();
                    this._list_time = value;
                    this.SendPropertyChanged("list_time");
                }
            }
        }

        [Column(Storage = "_location_Id", DbType = "Int")]
        public int? location_Id
        {
            get
            {
                return this._location_Id;
            }
            set
            {
                if (this._location_Id != value)
                {
                    this.SendPropertyChanging();
                    this._location_Id = value;
                    this.SendPropertyChanged("location_Id");
                }
            }
        }

        [Column(Storage = "_Memlogid", DbType = "VarChar(50) NOT NULL", CanBeNull = false)]
        public string Memlogid
        {
            get
            {
                return this._Memlogid;
            }
            set
            {
                if (this._Memlogid != value)
                {
                    this.SendPropertyChanging();
                    this._Memlogid = value;
                    this.SendPropertyChanged("Memlogid");
                }
            }
        }

        [Column(Storage = "_modified", DbType = "DateTime")]
        public DateTime? modified
        {
            get
            {
                return this._modified;
            }
            set
            {
                if (this._modified != value)
                {
                    this.SendPropertyChanging();
                    this._modified = value;
                    this.SendPropertyChanged("modified");
                }
            }
        }

        [Column(Storage = "_nick", DbType = "NVarChar(50)")]
        public string nick
        {
            get
            {
                return this._nick;
            }
            set
            {
                if (this._nick != value)
                {
                    this.SendPropertyChanging();
                    this._nick = value;
                    this.SendPropertyChanged("nick");
                }
            }
        }

        [Column(Storage = "_num", DbType = "Decimal(18,0)")]
        public decimal? num
        {
            get
            {
                return this._num;
            }
            set
            {
                decimal? nullable = this._num;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this.SendPropertyChanging();
                    this._num = value;
                    this.SendPropertyChanged("num");
                }
            }
        }

        [Column(Storage = "_num_iid", DbType = "Decimal(36,0)")]
        public decimal? num_iid
        {
            get
            {
                return this._num_iid;
            }
            set
            {
                decimal? nullable = this._num_iid;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this.SendPropertyChanging();
                    this._num_iid = value;
                    this.SendPropertyChanged("num_iid");
                }
            }
        }

        [Column(Storage = "_one_station", DbType = "Bit")]
        public bool? one_station
        {
            get
            {
                return this._one_station;
            }
            set
            {
                if (this._one_station != value)
                {
                    this.SendPropertyChanging();
                    this._one_station = value;
                    this.SendPropertyChanged("one_station");
                }
            }
        }

        [Column(Storage = "_pic_url", DbType = "NVarChar(200)")]
        public string pic_url
        {
            get
            {
                return this._pic_url;
            }
            set
            {
                if (this._pic_url != value)
                {
                    this.SendPropertyChanging();
                    this._pic_url = value;
                    this.SendPropertyChanged("pic_url");
                }
            }
        }

        [Column(Storage = "_post_fee", DbType = "Decimal(18,2)")]
        public decimal? post_fee
        {
            get
            {
                return this._post_fee;
            }
            set
            {
                decimal? nullable = this._post_fee;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this.SendPropertyChanging();
                    this._post_fee = value;
                    this.SendPropertyChanged("post_fee");
                }
            }
        }

        [Column(Storage = "_postage_id", DbType = "Decimal(18,0)")]
        public decimal? postage_id
        {
            get
            {
                return this._postage_id;
            }
            set
            {
                decimal? nullable = this._postage_id;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this.SendPropertyChanging();
                    this._postage_id = value;
                    this.SendPropertyChanged("postage_id");
                }
            }
        }

        [Column(Storage = "_price", DbType = "Decimal(18,2)")]
        public decimal? price
        {
            get
            {
                return this._price;
            }
            set
            {
                decimal? nullable = this._price;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this.SendPropertyChanging();
                    this._price = value;
                    this.SendPropertyChanged("price");
                }
            }
        }

        [Column(Storage = "_product_id", DbType = "Decimal(36,0)")]
        public decimal? product_id
        {
            get
            {
                return this._product_id;
            }
            set
            {
                decimal? nullable = this._product_id;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this.SendPropertyChanging();
                    this._product_id = value;
                    this.SendPropertyChanged("product_id");
                }
            }
        }

        [Column(Storage = "_promoted_service", DbType = "NVarChar(200)")]
        public string promoted_service
        {
            get
            {
                return this._promoted_service;
            }
            set
            {
                if (this._promoted_service != value)
                {
                    this.SendPropertyChanging();
                    this._promoted_service = value;
                    this.SendPropertyChanged("promoted_service");
                }
            }
        }

        [Column(Storage = "_prop_imgs_Id", DbType = "Decimal(18,0)")]
        public decimal? prop_imgs_Id
        {
            get
            {
                return this._prop_imgs_Id;
            }
            set
            {
                decimal? nullable = this._prop_imgs_Id;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this.SendPropertyChanging();
                    this._prop_imgs_Id = value;
                    this.SendPropertyChanged("prop_imgs_Id");
                }
            }
        }

        [Column(Storage = "_property_alias", DbType = "NVarChar(50)")]
        public string property_alias
        {
            get
            {
                return this._property_alias;
            }
            set
            {
                if (this._property_alias != value)
                {
                    this.SendPropertyChanging();
                    this._property_alias = value;
                    this.SendPropertyChanged("property_alias");
                }
            }
        }

        [Column(Storage = "_props", DbType = "NVarChar(200)")]
        public string props
        {
            get
            {
                return this._props;
            }
            set
            {
                if (this._props != value)
                {
                    this.SendPropertyChanging();
                    this._props = value;
                    this.SendPropertyChanged("props");
                }
            }
        }

        [Column(Storage = "_props_name", DbType = "NVarChar(50)")]
        public string props_name
        {
            get
            {
                return this._props_name;
            }
            set
            {
                if (this._props_name != value)
                {
                    this.SendPropertyChanging();
                    this._props_name = value;
                    this.SendPropertyChanged("props_name");
                }
            }
        }

        [Column(Storage = "_score", DbType = "Decimal(18,0)")]
        public decimal? score
        {
            get
            {
                return this._score;
            }
            set
            {
                decimal? nullable = this._score;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this.SendPropertyChanging();
                    this._score = value;
                    this.SendPropertyChanged("score");
                }
            }
        }

        [Column(Storage = "_second_kill", DbType = "NVarChar(50)")]
        public string second_kill
        {
            get
            {
                return this._second_kill;
            }
            set
            {
                if (this._second_kill != value)
                {
                    this.SendPropertyChanging();
                    this._second_kill = value;
                    this.SendPropertyChanged("second_kill");
                }
            }
        }

        [Column(Storage = "_seller_cids", DbType = "NVarChar(200)")]
        public string seller_cids
        {
            get
            {
                return this._seller_cids;
            }
            set
            {
                if (this._seller_cids != value)
                {
                    this.SendPropertyChanging();
                    this._seller_cids = value;
                    this.SendPropertyChanged("seller_cids");
                }
            }
        }

        [Column(Storage = "_ShopName", DbType = "NVarChar(200)")]
        public string ShopName
        {
            get
            {
                return this._ShopName;
            }
            set
            {
                if (this._ShopName != value)
                {
                    this.SendPropertyChanging();
                    this._ShopName = value;
                    this.SendPropertyChanged("ShopName");
                }
            }
        }

        [Column(Storage = "_site_Id", DbType = "NVarChar(200)")]
        public string site_Id
        {
            get
            {
                return this._site_Id;
            }
            set
            {
                if (this._site_Id != value)
                {
                    this.SendPropertyChanging();
                    this._site_Id = value;
                    this.SendPropertyChanged("site_Id");
                }
            }
        }

        [Column(Storage = "_site_skus_Id", DbType = "Decimal(18,0)")]
        public decimal? site_skus_Id
        {
            get
            {
                return this._site_skus_Id;
            }
            set
            {
                decimal? nullable = this._site_skus_Id;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this.SendPropertyChanging();
                    this._site_skus_Id = value;
                    this.SendPropertyChanged("site_skus_Id");
                }
            }
        }

        [Column(Storage = "_skus_Id", DbType = "NVarChar(100)")]
        public string skus_Id
        {
            get
            {
                return this._skus_Id;
            }
            set
            {
                if (this._skus_Id != value)
                {
                    this.SendPropertyChanging();
                    this._skus_Id = value;
                    this.SendPropertyChanged("skus_Id");
                }
            }
        }

        [Column(Storage = "_stuff_status", DbType = "NVarChar(20)")]
        public string stuff_status
        {
            get
            {
                return this._stuff_status;
            }
            set
            {
                if (this._stuff_status != value)
                {
                    this.SendPropertyChanging();
                    this._stuff_status = value;
                    this.SendPropertyChanged("stuff_status");
                }
            }
        }

        [Column(Storage = "_title", DbType = "NVarChar(60)")]
        public string title
        {
            get
            {
                return this._title;
            }
            set
            {
                if (this._title != value)
                {
                    this.SendPropertyChanging();
                    this._title = value;
                    this.SendPropertyChanged("title");
                }
            }
        }

        [Column(Storage = "_type", DbType = "NVarChar(20)")]
        public string type
        {
            get
            {
                return this._type;
            }
            set
            {
                if (this._type != value)
                {
                    this.SendPropertyChanging();
                    this._type = value;
                    this.SendPropertyChanged("type");
                }
            }
        }

        [Column(Storage = "_valid_thru", DbType = "Decimal(18,0)")]
        public decimal? valid_thru
        {
            get
            {
                return this._valid_thru;
            }
            set
            {
                decimal? nullable = this._valid_thru;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this.SendPropertyChanging();
                    this._valid_thru = value;
                    this.SendPropertyChanged("valid_thru");
                }
            }
        }

        [Column(Storage = "_videos_Id", DbType = "NVarChar(50)")]
        public string videos_Id
        {
            get
            {
                return this._videos_Id;
            }
            set
            {
                if (this._videos_Id != value)
                {
                    this.SendPropertyChanging();
                    this._videos_Id = value;
                    this.SendPropertyChanged("videos_Id");
                }
            }
        }

        [Column(Storage = "_violation", DbType = "Bit")]
        public bool? violation
        {
            get
            {
                return this._violation;
            }
            set
            {
                if (this._violation != value)
                {
                    this.SendPropertyChanging();
                    this._violation = value;
                    this.SendPropertyChanged("violation");
                }
            }
        }

        [Column(Storage = "_volume", DbType = "Decimal(18,0)")]
        public decimal? volume
        {
            get
            {
                return this._volume;
            }
            set
            {
                decimal? nullable = this._volume;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this.SendPropertyChanging();
                    this._volume = value;
                    this.SendPropertyChanged("volume");
                }
            }
        }

        [Column(Storage = "_wap_desc", DbType = "NText", UpdateCheck = UpdateCheck.Never)]
        public string wap_desc
        {
            get
            {
                return this._wap_desc;
            }
            set
            {
                if (this._wap_desc != value)
                {
                    this.SendPropertyChanging();
                    this._wap_desc = value;
                    this.SendPropertyChanged("wap_desc");
                }
            }
        }

        [Column(Storage = "_wap_detail_url", DbType = "NVarChar(200)")]
        public string wap_detail_url
        {
            get
            {
                return this._wap_detail_url;
            }
            set
            {
                if (this._wap_detail_url != value)
                {
                    this.SendPropertyChanging();
                    this._wap_detail_url = value;
                    this.SendPropertyChanged("wap_detail_url");
                }
            }
        }

        [Column(Storage = "_ww_status", DbType = "Bit")]
        public bool? ww_status
        {
            get
            {
                return this._ww_status;
            }
            set
            {
                if (this._ww_status != value)
                {
                    this.SendPropertyChanging();
                    this._ww_status = value;
                    this.SendPropertyChanged("ww_status");
                }
            }
        }
    }
}
