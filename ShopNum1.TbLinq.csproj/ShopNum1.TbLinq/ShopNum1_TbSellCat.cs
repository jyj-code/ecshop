namespace ShopNum1.TbLinq
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name = "dbo.ShopNum1_TbSellCat")]
    public class ShopNum1_TbSellCat : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private decimal _cid;
        private DateTime? _created;
        private int _ID;
        private bool? _isTaobao;
        private string _MemloginId;
        private DateTime? _modified;
        private string _name;
        private decimal _parent_cid;
        private string _pic_url;
        private string _shopname;
        private decimal? _site_cid;
        private decimal? _site_parent_cid;
        private decimal? _sort_order;
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

        [Column(Storage = "_cid", DbType = "Decimal(22,0) NOT NULL")]
        public decimal cid
        {
            get
            {
                return this._cid;
            }
            set
            {
                if (this._cid != value)
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

        [Column(Storage = "_MemloginId", DbType = "VarChar(50) NOT NULL", CanBeNull = false)]
        public string MemloginId
        {
            get
            {
                return this._MemloginId;
            }
            set
            {
                if (this._MemloginId != value)
                {
                    this.SendPropertyChanging();
                    this._MemloginId = value;
                    this.SendPropertyChanged("MemloginId");
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

        [Column(Storage = "_name", DbType = "NVarChar(200)")]
        public string name
        {
            get
            {
                return this._name;
            }
            set
            {
                if (this._name != value)
                {
                    this.SendPropertyChanging();
                    this._name = value;
                    this.SendPropertyChanged("name");
                }
            }
        }

        [Column(Storage = "_parent_cid", DbType = "Decimal(18,0) NOT NULL")]
        public decimal parent_cid
        {
            get
            {
                return this._parent_cid;
            }
            set
            {
                if (this._parent_cid != value)
                {
                    this.SendPropertyChanging();
                    this._parent_cid = value;
                    this.SendPropertyChanged("parent_cid");
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

        [Column(Storage = "_shopname", DbType = "NVarChar(200)")]
        public string shopname
        {
            get
            {
                return this._shopname;
            }
            set
            {
                if (this._shopname != value)
                {
                    this.SendPropertyChanging();
                    this._shopname = value;
                    this.SendPropertyChanged("shopname");
                }
            }
        }

        [Column(Storage = "_site_cid", DbType = "Decimal(22,0)")]
        public decimal? site_cid
        {
            get
            {
                return this._site_cid;
            }
            set
            {
                decimal? nullable = this._site_cid;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this.SendPropertyChanging();
                    this._site_cid = value;
                    this.SendPropertyChanged("site_cid");
                }
            }
        }

        [Column(Storage = "_site_parent_cid", DbType = "Decimal(22,0)")]
        public decimal? site_parent_cid
        {
            get
            {
                return this._site_parent_cid;
            }
            set
            {
                decimal? nullable = this._site_parent_cid;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this.SendPropertyChanging();
                    this._site_parent_cid = value;
                    this.SendPropertyChanged("site_parent_cid");
                }
            }
        }

        [Column(Storage = "_sort_order", DbType = "Decimal(18,0)")]
        public decimal? sort_order
        {
            get
            {
                return this._sort_order;
            }
            set
            {
                decimal? nullable = this._sort_order;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this.SendPropertyChanging();
                    this._sort_order = value;
                    this.SendPropertyChanged("sort_order");
                }
            }
        }
    }
}
