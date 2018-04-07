namespace ShopNum1.TbLinq
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name = "dbo.ShopNum1_TbTopKey")]
    public class ShopNum1_TbTopKey : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private string _AppKey;
        private string _AppSecret;
        private DateTime? _CreateTime;
        private string _CreateUser;
        private System.Guid _Guid;
        private int _IsForbid;
        private string _MemloginID;
        private DateTime? _ModifyTime;
        private string _ModifyUser;
        private string _URL;
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

        [Column(Storage = "_AppKey", DbType = "NVarChar(200) NOT NULL", CanBeNull = false)]
        public string AppKey
        {
            get
            {
                return this._AppKey;
            }
            set
            {
                if (this._AppKey != value)
                {
                    this.SendPropertyChanging();
                    this._AppKey = value;
                    this.SendPropertyChanged("AppKey");
                }
            }
        }

        [Column(Storage = "_AppSecret", DbType = "NVarChar(200) NOT NULL", CanBeNull = false)]
        public string AppSecret
        {
            get
            {
                return this._AppSecret;
            }
            set
            {
                if (this._AppSecret != value)
                {
                    this.SendPropertyChanging();
                    this._AppSecret = value;
                    this.SendPropertyChanged("AppSecret");
                }
            }
        }

        [Column(Storage = "_CreateTime", DbType = "DateTime")]
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

        [Column(Storage = "_CreateUser", DbType = "NVarChar(50)")]
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

        [Column(Storage = "_Guid", DbType = "UniqueIdentifier NOT NULL", IsPrimaryKey = true)]
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

        [Column(Storage = "_IsForbid", DbType = "Int NOT NULL")]
        public int IsForbid
        {
            get
            {
                return this._IsForbid;
            }
            set
            {
                if (this._IsForbid != value)
                {
                    this.SendPropertyChanging();
                    this._IsForbid = value;
                    this.SendPropertyChanged("IsForbid");
                }
            }
        }

        [Column(Storage = "_MemloginID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
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

        [Column(Storage = "_ModifyTime", DbType = "DateTime")]
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

        [Column(Storage = "_ModifyUser", DbType = "NVarChar(50)")]
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

        [Column(Storage = "_URL", DbType = "NVarChar(100) NOT NULL", CanBeNull = false)]
        public string URL
        {
            get
            {
                return this._URL;
            }
            set
            {
                if (this._URL != value)
                {
                    this.SendPropertyChanging();
                    this._URL = value;
                    this.SendPropertyChanged("URL");
                }
            }
        }
    }
}
