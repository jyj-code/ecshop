namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_Shipper")]
    public class ShopNum1_Shipper : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private string _Address;
        private DateTime _CreateTime;
        private string _CreateUser;
        private System.Guid _Guid;
        private int _IsDefault;
        private string _Mobile;
        private string _ModifyTime;
        private string _ModifyUser;
        private string _Phone;
        private string _PostalCode;
        private string _RegionCode;
        private string _Remark;
        private string _SendName;
        private string _ShipperName;
        private string _ShopId;
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

        [Column(Storage="_Address", DbType="NVarChar(200) NOT NULL", CanBeNull=false)]
        public string Address
        {
            get
            {
                return this._Address;
            }
            set
            {
                if (this._Address != value)
                {
                    this.SendPropertyChanging();
                    this._Address = value;
                    this.SendPropertyChanged("Address");
                }
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

        [Column(Storage="_CreateUser", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string CreateUser
        {
            get
            {
                return this._CreateUser;
            }
            set
            {
                if (this._CreateUser != value)
                {
                    this.SendPropertyChanging();
                    this._CreateUser = value;
                    this.SendPropertyChanged("CreateUser");
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

        [Column(Storage="_IsDefault", DbType="Int NOT NULL")]
        public int IsDefault
        {
            get
            {
                return this._IsDefault;
            }
            set
            {
                if (this._IsDefault != value)
                {
                    this.SendPropertyChanging();
                    this._IsDefault = value;
                    this.SendPropertyChanged("IsDefault");
                }
            }
        }

        [Column(Storage="_Mobile", DbType="NVarChar(20)")]
        public string Mobile
        {
            get
            {
                return this._Mobile;
            }
            set
            {
                if (this._Mobile != value)
                {
                    this.SendPropertyChanging();
                    this._Mobile = value;
                    this.SendPropertyChanged("Mobile");
                }
            }
        }

        [Column(Storage="_ModifyTime", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string ModifyTime
        {
            get
            {
                return this._ModifyTime;
            }
            set
            {
                if (this._ModifyTime != value)
                {
                    this.SendPropertyChanging();
                    this._ModifyTime = value;
                    this.SendPropertyChanged("ModifyTime");
                }
            }
        }

        [Column(Storage="_ModifyUser", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string ModifyUser
        {
            get
            {
                return this._ModifyUser;
            }
            set
            {
                if (this._ModifyUser != value)
                {
                    this.SendPropertyChanging();
                    this._ModifyUser = value;
                    this.SendPropertyChanged("ModifyUser");
                }
            }
        }

        [Column(Storage="_Phone", DbType="NVarChar(20)")]
        public string Phone
        {
            get
            {
                return this._Phone;
            }
            set
            {
                if (this._Phone != value)
                {
                    this.SendPropertyChanging();
                    this._Phone = value;
                    this.SendPropertyChanged("Phone");
                }
            }
        }

        [Column(Storage="_PostalCode", DbType="NVarChar(20)")]
        public string PostalCode
        {
            get
            {
                return this._PostalCode;
            }
            set
            {
                if (this._PostalCode != value)
                {
                    this.SendPropertyChanging();
                    this._PostalCode = value;
                    this.SendPropertyChanged("PostalCode");
                }
            }
        }

        [Column(Storage="_RegionCode", DbType="NVarChar(100)")]
        public string RegionCode
        {
            get
            {
                return this._RegionCode;
            }
            set
            {
                if (this._RegionCode != value)
                {
                    this.SendPropertyChanging();
                    this._RegionCode = value;
                    this.SendPropertyChanged("RegionCode");
                }
            }
        }

        [Column(Storage="_Remark", DbType="NVarChar(200)")]
        public string Remark
        {
            get
            {
                return this._Remark;
            }
            set
            {
                if (this._Remark != value)
                {
                    this.SendPropertyChanging();
                    this._Remark = value;
                    this.SendPropertyChanged("Remark");
                }
            }
        }

        [Column(Storage="_SendName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string SendName
        {
            get
            {
                return this._SendName;
            }
            set
            {
                if (this._SendName != value)
                {
                    this.SendPropertyChanging();
                    this._SendName = value;
                    this.SendPropertyChanged("SendName");
                }
            }
        }

        [Column(Storage="_ShipperName", DbType="NVarChar(200) NOT NULL", CanBeNull=false)]
        public string ShipperName
        {
            get
            {
                return this._ShipperName;
            }
            set
            {
                if (this._ShipperName != value)
                {
                    this.SendPropertyChanging();
                    this._ShipperName = value;
                    this.SendPropertyChanged("ShipperName");
                }
            }
        }

        [Column(Storage="_ShopId", DbType="NVarChar(50)")]
        public string ShopId
        {
            get
            {
                return this._ShopId;
            }
            set
            {
                if (this._ShopId != value)
                {
                    this.SendPropertyChanging();
                    this._ShopId = value;
                    this.SendPropertyChanged("ShopId");
                }
            }
        }
    }
}

