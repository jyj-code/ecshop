namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_ThemeActivityProduct")]
    public class ShopNum1_ThemeActivityProduct : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private DateTime _CreateTime;
        private System.Guid _Guid;
        private string _IsAudit;
        private string _MemloginID;
        private string _ProductGuid;
        private string _ProductImage;
        private string _ProductName;
        private decimal _ProductPrice;
        private string _ShopName;
        private string _ThemeGuid;
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

        [Column(Storage="_CreateTime", DbType="DateTime NOT NULL")]
        public DateTime CreateTime
        {
            get
            {
                return this._CreateTime;
            }
            set
            {
                if (this._CreateTime != value)
                {
                    this.SendPropertyChanging();
                    this._CreateTime = value;
                    this.SendPropertyChanged("CreateTime");
                }
            }
        }

        [Column(Storage="_Guid", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
        public System.Guid Guid
        {
            get
            {
                return this._Guid;
            }
            set
            {
                if (this._Guid != value)
                {
                    this.SendPropertyChanging();
                    this._Guid = value;
                    this.SendPropertyChanged("Guid");
                }
            }
        }

        [Column(Storage="_IsAudit", DbType="NChar(10) NOT NULL", CanBeNull=false)]
        public string IsAudit
        {
            get
            {
                return this._IsAudit;
            }
            set
            {
                if (this._IsAudit != value)
                {
                    this.SendPropertyChanging();
                    this._IsAudit = value;
                    this.SendPropertyChanged("IsAudit");
                }
            }
        }

        [Column(Storage="_MemloginID", DbType="NVarChar(50)")]
        public string MemloginID
        {
            get
            {
                return this._MemloginID;
            }
            set
            {
                if (this._MemloginID != value)
                {
                    this.SendPropertyChanging();
                    this._MemloginID = value;
                    this.SendPropertyChanged("MemloginID");
                }
            }
        }

        [Column(Storage="_ProductGuid", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string ProductGuid
        {
            get
            {
                return this._ProductGuid;
            }
            set
            {
                if (this._ProductGuid != value)
                {
                    this.SendPropertyChanging();
                    this._ProductGuid = value;
                    this.SendPropertyChanged("ProductGuid");
                }
            }
        }

        [Column(Storage="_ProductImage", DbType="NVarChar(200) NOT NULL", CanBeNull=false)]
        public string ProductImage
        {
            get
            {
                return this._ProductImage;
            }
            set
            {
                if (this._ProductImage != value)
                {
                    this.SendPropertyChanging();
                    this._ProductImage = value;
                    this.SendPropertyChanged("ProductImage");
                }
            }
        }

        [Column(Storage="_ProductName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string ProductName
        {
            get
            {
                return this._ProductName;
            }
            set
            {
                if (this._ProductName != value)
                {
                    this.SendPropertyChanging();
                    this._ProductName = value;
                    this.SendPropertyChanged("ProductName");
                }
            }
        }

        [Column(Storage="_ProductPrice", DbType="Decimal(18,2) NOT NULL")]
        public decimal ProductPrice
        {
            get
            {
                return this._ProductPrice;
            }
            set
            {
                if (this._ProductPrice != value)
                {
                    this.SendPropertyChanging();
                    this._ProductPrice = value;
                    this.SendPropertyChanged("ProductPrice");
                }
            }
        }

        [Column(Storage="_ShopName", DbType="NVarChar(100)")]
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

        [Column(Storage="_ThemeGuid", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string ThemeGuid
        {
            get
            {
                return this._ThemeGuid;
            }
            set
            {
                if (this._ThemeGuid != value)
                {
                    this.SendPropertyChanging();
                    this._ThemeGuid = value;
                    this.SendPropertyChanged("ThemeGuid");
                }
            }
        }
    }
}

