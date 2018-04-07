namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_FloorDistribution")]
    public class ShopNum1_FloorDistribution : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private int _CategoryLevel;
        private string _Code;
        private DateTime? _CreateTime;
        private string _CreateUser;
        private string _Family;
        private int _FatherID;
        private string _FloorTypeName;
        private int _ID;
        private int? _IsDeleted;
        private int _IsShow;
        private DateTime? _ModifyTime;
        private string _ModifyUser;
        private string _Name;
        private int _OrderID;
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

        [Column(Storage="_CategoryLevel", DbType="Int NOT NULL")]
        public int CategoryLevel
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

        [Column(Storage="_Code", DbType="VarChar(12) NOT NULL", CanBeNull=false)]
        public string Code
        {
            get
            {
                return this._Code;
            }
            set
            {
                if (this._Code != value)
                {
                    this.SendPropertyChanging();
                    this._Code = value;
                    this.SendPropertyChanged("Code");
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

        [Column(Storage="_Family", DbType="NVarChar(250) NOT NULL", CanBeNull=false)]
        public string Family
        {
            get
            {
                return this._Family;
            }
            set
            {
                if (this._Family != value)
                {
                    this.SendPropertyChanging();
                    this._Family = value;
                    this.SendPropertyChanged("Family");
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

        [Column(Storage="_FloorTypeName", DbType="VarChar(100)")]
        public string FloorTypeName
        {
            get
            {
                return this._FloorTypeName;
            }
            set
            {
                if (this._FloorTypeName != value)
                {
                    this.SendPropertyChanging();
                    this._FloorTypeName = value;
                    this.SendPropertyChanged("FloorTypeName");
                }
            }
        }

        [Column(Storage="_ID", DbType="Int NOT NULL", IsPrimaryKey=true)]
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

        [Column(Storage="_IsShow", DbType="Int NOT NULL")]
        public int IsShow
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

        [Column(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                if (this._Name != value)
                {
                    this.SendPropertyChanging();
                    this._Name = value;
                    this.SendPropertyChanged("Name");
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
    }
}

