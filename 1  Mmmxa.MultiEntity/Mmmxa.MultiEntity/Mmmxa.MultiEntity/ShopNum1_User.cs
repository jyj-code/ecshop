namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_User")]
    public class ShopNum1_User : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private int _Age;
        private DateTime _CreateTime;
        private string _CreateUser;
        private System.Guid _DeptGuid;
        private string _Email;
        private System.Guid _Guid;
        private int _IsDeleted;
        private int _IsForbid;
        private int? _IsSuperAdmin;
        private string _LastLoginIP;
        private DateTime? _LastLoginTime;
        private DateTime? _LastModifyPasswordTime;
        private string _LoginId;
        private int _LoginTimes;
        private DateTime _ModifyTime;
        private string _ModifyUser;
        private int? _PeopleType;
        private string _Pwd;
        private string _RealName;
        private int _Sex;
        private string _SubstationID;
        private string _Telephone;
        private string _WorkNumber;
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

        [Column(Storage="_Age", DbType="Int NOT NULL")]
        public int Age
        {
            get
            {
                return this._Age;
            }
            set
            {
                if (this._Age != value)
                {
                    this.SendPropertyChanging();
                    this._Age = value;
                    this.SendPropertyChanged("Age");
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

        [Column(Storage="_DeptGuid", DbType="UniqueIdentifier NOT NULL")]
        public System.Guid DeptGuid
        {
            get
            {
                return this._DeptGuid;
            }
            set
            {
                if (this._DeptGuid != value)
                {
                    this.SendPropertyChanging();
                    this._DeptGuid = value;
                    this.SendPropertyChanged("DeptGuid");
                }
            }
        }

        [Column(Storage="_Email", DbType="NVarChar(100)")]
        public string Email
        {
            get
            {
                return this._Email;
            }
            set
            {
                if (this._Email != value)
                {
                    this.SendPropertyChanging();
                    this._Email = value;
                    this.SendPropertyChanged("Email");
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

        [Column(Storage="_IsDeleted", DbType="Int NOT NULL")]
        public int IsDeleted
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

        [Column(Storage="_IsForbid", DbType="Int NOT NULL")]
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

        [Column(Storage="_IsSuperAdmin", DbType="Int")]
        public int? IsSuperAdmin
        {
            get
            {
                return this._IsSuperAdmin;
            }
            set
            {
                if (this._IsSuperAdmin != value)
                {
                    this.SendPropertyChanging();
                    this._IsSuperAdmin = value;
                    this.SendPropertyChanged("IsSuperAdmin");
                }
            }
        }

        [Column(Storage="_LastLoginIP", DbType="NVarChar(20)")]
        public string LastLoginIP
        {
            get
            {
                return this._LastLoginIP;
            }
            set
            {
                if (this._LastLoginIP != value)
                {
                    this.SendPropertyChanging();
                    this._LastLoginIP = value;
                    this.SendPropertyChanged("LastLoginIP");
                }
            }
        }

        [Column(Storage="_LastLoginTime", DbType="DateTime")]
        public DateTime? LastLoginTime
        {
            get
            {
                return this._LastLoginTime;
            }
            set
            {
                if (this._LastLoginTime != value)
                {
                    this.SendPropertyChanging();
                    this._LastLoginTime = value;
                    this.SendPropertyChanged("LastLoginTime");
                }
            }
        }

        [Column(Storage="_LastModifyPasswordTime", DbType="DateTime")]
        public DateTime? LastModifyPasswordTime
        {
            get
            {
                return this._LastModifyPasswordTime;
            }
            set
            {
                if (this._LastModifyPasswordTime != value)
                {
                    this.SendPropertyChanging();
                    this._LastModifyPasswordTime = value;
                    this.SendPropertyChanged("LastModifyPasswordTime");
                }
            }
        }

        [Column(Storage="_LoginId", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string LoginId
        {
            get
            {
                return this._LoginId;
            }
            set
            {
                if (this._LoginId != value)
                {
                    this.SendPropertyChanging();
                    this._LoginId = value;
                    this.SendPropertyChanged("LoginId");
                }
            }
        }

        [Column(Storage="_LoginTimes", DbType="Int NOT NULL")]
        public int LoginTimes
        {
            get
            {
                return this._LoginTimes;
            }
            set
            {
                if (this._LoginTimes != value)
                {
                    this.SendPropertyChanging();
                    this._LoginTimes = value;
                    this.SendPropertyChanged("LoginTimes");
                }
            }
        }

        [Column(Storage="_ModifyTime", DbType="DateTime NOT NULL")]
        public DateTime ModifyTime
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

        [Column(Storage="_PeopleType", DbType="Int")]
        public int? PeopleType
        {
            get
            {
                return this._PeopleType;
            }
            set
            {
                if (this._PeopleType != value)
                {
                    this.SendPropertyChanging();
                    this._PeopleType = value;
                    this.SendPropertyChanged("PeopleType");
                }
            }
        }

        [Column(Storage="_Pwd", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string Pwd
        {
            get
            {
                return this._Pwd;
            }
            set
            {
                if (this._Pwd != value)
                {
                    this.SendPropertyChanging();
                    this._Pwd = value;
                    this.SendPropertyChanged("Pwd");
                }
            }
        }

        [Column(Storage="_RealName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string RealName
        {
            get
            {
                return this._RealName;
            }
            set
            {
                if (this._RealName != value)
                {
                    this.SendPropertyChanging();
                    this._RealName = value;
                    this.SendPropertyChanged("RealName");
                }
            }
        }

        [Column(Storage="_Sex", DbType="Int NOT NULL")]
        public int Sex
        {
            get
            {
                return this._Sex;
            }
            set
            {
                if (this._Sex != value)
                {
                    this.SendPropertyChanging();
                    this._Sex = value;
                    this.SendPropertyChanged("Sex");
                }
            }
        }

        [Column(Storage="_SubstationID", DbType="NVarChar(100)")]
        public string SubstationID
        {
            get
            {
                return this._SubstationID;
            }
            set
            {
                if (this._SubstationID != value)
                {
                    this.SendPropertyChanging();
                    this._SubstationID = value;
                    this.SendPropertyChanged("SubstationID");
                }
            }
        }

        [Column(Storage="_Telephone", DbType="NVarChar(100)")]
        public string Telephone
        {
            get
            {
                return this._Telephone;
            }
            set
            {
                if (this._Telephone != value)
                {
                    this.SendPropertyChanging();
                    this._Telephone = value;
                    this.SendPropertyChanged("Telephone");
                }
            }
        }

        [Column(Storage="_WorkNumber", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string WorkNumber
        {
            get
            {
                return this._WorkNumber;
            }
            set
            {
                if (this._WorkNumber != value)
                {
                    this.SendPropertyChanging();
                    this._WorkNumber = value;
                    this.SendPropertyChanged("WorkNumber");
                }
            }
        }
    }
}

