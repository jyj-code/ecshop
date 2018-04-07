namespace ShopNum1.TbLinq
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name = "dbo.ShopNum1_TbSystem")]
    public class ShopNum1_TbSystem : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private bool? _hasTbOrder;
        private bool? _hasTbRate;
        private int _Id;
        private bool? _isOpen;
        private string _Memlogid;
        private bool? _siteCount;
        private bool? _siteDesc;
        private bool? _siteImg;
        private bool? _siteItemName;
        private bool? _siteItemPrice;
        private bool? _siteSellCat;
        private bool? _tbCount;
        private bool? _tbDesc;
        private bool? _tbImg;
        private bool? _tbItemName;
        private bool? _tbItemPrice;
        private bool? _tbSellCat;
        private string _tbShopName;
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

        [Column(Storage = "_hasTbOrder", DbType = "Bit")]
        public bool? hasTbOrder
        {
            get
            {
                return this._hasTbOrder;
            }
            set
            {
                if (this._hasTbOrder != value)
                {
                    this.SendPropertyChanging();
                    this._hasTbOrder = value;
                    this.SendPropertyChanged("hasTbOrder");
                }
            }
        }

        [Column(Storage = "_hasTbRate", DbType = "Bit")]
        public bool? hasTbRate
        {
            get
            {
                return this._hasTbRate;
            }
            set
            {
                if (this._hasTbRate != value)
                {
                    this.SendPropertyChanging();
                    this._hasTbRate = value;
                    this.SendPropertyChanged("hasTbRate");
                }
            }
        }

        [Column(Storage = "_Id", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                if (this._Id != value)
                {
                    this.SendPropertyChanging();
                    this._Id = value;
                    this.SendPropertyChanged("Id");
                }
            }
        }

        [Column(Storage = "_isOpen", DbType = "Bit")]
        public bool? isOpen
        {
            get
            {
                return this._isOpen;
            }
            set
            {
                if (this._isOpen != value)
                {
                    this.SendPropertyChanging();
                    this._isOpen = value;
                    this.SendPropertyChanged("isOpen");
                }
            }
        }

        [Column(Storage = "_Memlogid", DbType = "VarChar(100) NOT NULL", CanBeNull = false)]
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

        [Column(Storage = "_siteCount", DbType = "Bit")]
        public bool? siteCount
        {
            get
            {
                return this._siteCount;
            }
            set
            {
                if (this._siteCount != value)
                {
                    this.SendPropertyChanging();
                    this._siteCount = value;
                    this.SendPropertyChanged("siteCount");
                }
            }
        }

        [Column(Storage = "_siteDesc", DbType = "Bit")]
        public bool? siteDesc
        {
            get
            {
                return this._siteDesc;
            }
            set
            {
                if (this._siteDesc != value)
                {
                    this.SendPropertyChanging();
                    this._siteDesc = value;
                    this.SendPropertyChanged("siteDesc");
                }
            }
        }

        [Column(Storage = "_siteImg", DbType = "Bit")]
        public bool? siteImg
        {
            get
            {
                return this._siteImg;
            }
            set
            {
                if (this._siteImg != value)
                {
                    this.SendPropertyChanging();
                    this._siteImg = value;
                    this.SendPropertyChanged("siteImg");
                }
            }
        }

        [Column(Storage = "_siteItemName", DbType = "Bit")]
        public bool? siteItemName
        {
            get
            {
                return this._siteItemName;
            }
            set
            {
                if (this._siteItemName != value)
                {
                    this.SendPropertyChanging();
                    this._siteItemName = value;
                    this.SendPropertyChanged("siteItemName");
                }
            }
        }

        [Column(Storage = "_siteItemPrice", DbType = "Bit")]
        public bool? siteItemPrice
        {
            get
            {
                return this._siteItemPrice;
            }
            set
            {
                if (this._siteItemPrice != value)
                {
                    this.SendPropertyChanging();
                    this._siteItemPrice = value;
                    this.SendPropertyChanged("siteItemPrice");
                }
            }
        }

        [Column(Storage = "_siteSellCat", DbType = "Bit")]
        public bool? siteSellCat
        {
            get
            {
                return this._siteSellCat;
            }
            set
            {
                if (this._siteSellCat != value)
                {
                    this.SendPropertyChanging();
                    this._siteSellCat = value;
                    this.SendPropertyChanged("siteSellCat");
                }
            }
        }

        [Column(Storage = "_tbCount", DbType = "Bit")]
        public bool? tbCount
        {
            get
            {
                return this._tbCount;
            }
            set
            {
                if (this._tbCount != value)
                {
                    this.SendPropertyChanging();
                    this._tbCount = value;
                    this.SendPropertyChanged("tbCount");
                }
            }
        }

        [Column(Storage = "_tbDesc", DbType = "Bit")]
        public bool? tbDesc
        {
            get
            {
                return this._tbDesc;
            }
            set
            {
                if (this._tbDesc != value)
                {
                    this.SendPropertyChanging();
                    this._tbDesc = value;
                    this.SendPropertyChanged("tbDesc");
                }
            }
        }

        [Column(Storage = "_tbImg", DbType = "Bit")]
        public bool? tbImg
        {
            get
            {
                return this._tbImg;
            }
            set
            {
                if (this._tbImg != value)
                {
                    this.SendPropertyChanging();
                    this._tbImg = value;
                    this.SendPropertyChanged("tbImg");
                }
            }
        }

        [Column(Storage = "_tbItemName", DbType = "Bit")]
        public bool? tbItemName
        {
            get
            {
                return this._tbItemName;
            }
            set
            {
                if (this._tbItemName != value)
                {
                    this.SendPropertyChanging();
                    this._tbItemName = value;
                    this.SendPropertyChanged("tbItemName");
                }
            }
        }

        [Column(Storage = "_tbItemPrice", DbType = "Bit")]
        public bool? tbItemPrice
        {
            get
            {
                return this._tbItemPrice;
            }
            set
            {
                if (this._tbItemPrice != value)
                {
                    this.SendPropertyChanging();
                    this._tbItemPrice = value;
                    this.SendPropertyChanged("tbItemPrice");
                }
            }
        }

        [Column(Storage = "_tbSellCat", DbType = "Bit")]
        public bool? tbSellCat
        {
            get
            {
                return this._tbSellCat;
            }
            set
            {
                if (this._tbSellCat != value)
                {
                    this.SendPropertyChanging();
                    this._tbSellCat = value;
                    this.SendPropertyChanged("tbSellCat");
                }
            }
        }

        [Column(Storage = "_tbShopName", DbType = "NVarChar(100) NOT NULL", CanBeNull = false)]
        public string tbShopName
        {
            get
            {
                return this._tbShopName;
            }
            set
            {
                if (this._tbShopName != value)
                {
                    this.SendPropertyChanging();
                    this._tbShopName = value;
                    this.SendPropertyChanged("tbShopName");
                }
            }
        }
    }
}
