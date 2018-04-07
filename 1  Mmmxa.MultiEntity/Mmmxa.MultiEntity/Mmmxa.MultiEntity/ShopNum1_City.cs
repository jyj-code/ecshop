namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_City")]
    public class ShopNum1_City : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private string _AddressCode;
        private int? _CategoryLevel;
        private string _CityName;
        private DateTime? _CreateTime;
        private string _CreateUser;
        private int _FatherID;
        private int _ID;
        private int? _IsDeleted;
        private byte? _IsHot;
        private byte? _IsShow;
        private string _Letter;
        private DateTime? _ModifyTime;
        private string _ModifyUser;
        private int _OrderID;
        private string _ShortName;
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

        [Column(Storage="_AddressCode", DbType="VarChar(12) NOT NULL", CanBeNull=false)]
        public string AddressCode
        {
            get
            {
                return this._AddressCode;
            }
            set
            {
                if (this._AddressCode != value)
                {
                    this.SendPropertyChanging();
                    this._AddressCode = value;
                    this.SendPropertyChanged("AddressCode");
                }
            }
        }

        [Column(Storage="_CategoryLevel", DbType="Int")]
        public int? CategoryLevel
        {
            get
            {
                return this._CategoryLevel;
            }
            set
            {
                if (this._CategoryLevel != value)
                {
                    this.SendPropertyChanging();
                    this._CategoryLevel = value;
                    this.SendPropertyChanged("CategoryLevel");
                }
            }
        }

        [Column(Storage="_CityName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string CityName
        {
            get
            {
                return this._CityName;
            }
            set
            {
                if (this._CityName != value)
                {
                    this.SendPropertyChanging();
                    this._CityName = value;
                    this.SendPropertyChanged("CityName");
                }
            }
        }

        [Column(Storage="_CreateTime", DbType="DateTime")]
        public DateTime? CreateTime
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

        [Column(Storage="_CreateUser", DbType="NVarChar(50)")]
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

        [Column(Storage="_FatherID", DbType="Int NOT NULL")]
        public int FatherID
        {
            get
            {
                return this._FatherID;
            }
            set
            {
                if (this._FatherID != value)
                {
                    this.SendPropertyChanging();
                    this._FatherID = value;
                    this.SendPropertyChanged("FatherID");
                }
            }
        }

        [Column(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
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

        [Column(Storage="_IsDeleted", DbType="Int")]
        public int? IsDeleted
        {
            get
            {
                return this._IsDeleted;
            }
            set
            {
                if (this._IsDeleted != value)
                {
                    this.SendPropertyChanging();
                    this._IsDeleted = value;
                    this.SendPropertyChanged("IsDeleted");
                }
            }
        }

        [Column(Storage="_IsHot", DbType="TinyInt")]
        public byte? IsHot
        {
            get
            {
                return this._IsHot;
            }
            set
            {
                if (this._IsHot != value)
                {
                    this.SendPropertyChanging();
                    this._IsHot = value;
                    this.SendPropertyChanged("IsHot");
                }
            }
        }

        [Column(Storage="_IsShow", DbType="TinyInt")]
        public byte? IsShow
        {
            get
            {
                return this._IsShow;
            }
            set
            {
                if (this._IsShow != value)
                {
                    this.SendPropertyChanging();
                    this._IsShow = value;
                    this.SendPropertyChanged("IsShow");
                }
            }
        }

        [Column(Storage="_Letter", DbType="Char(10) NOT NULL", CanBeNull=false)]
        public string Letter
        {
            get
            {
                return this._Letter;
            }
            set
            {
                if (this._Letter != value)
                {
                    this.SendPropertyChanging();
                    this._Letter = value;
                    this.SendPropertyChanged("Letter");
                }
            }
        }

        [Column(Storage="_ModifyTime", DbType="DateTime")]
        public DateTime? ModifyTime
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

        [Column(Storage="_ModifyUser", DbType="NVarChar(50)")]
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

        [Column(Storage="_OrderID", DbType="Int NOT NULL")]
        public int OrderID
        {
            get
            {
                return this._OrderID;
            }
            set
            {
                if (this._OrderID != value)
                {
                    this.SendPropertyChanging();
                    this._OrderID = value;
                    this.SendPropertyChanged("OrderID");
                }
            }
        }

        [Column(Storage="_ShortName", DbType="NVarChar(50)")]
        public string ShortName
        {
            get
            {
                return this._ShortName;
            }
            set
            {
                if (this._ShortName != value)
                {
                    this.SendPropertyChanging();
                    this._ShortName = value;
                    this.SendPropertyChanged("ShortName");
                }
            }
        }
    }
}

