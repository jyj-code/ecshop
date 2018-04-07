namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_ZtcApply")]
    public class ShopNum1_ZtcApply : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private DateTime? _ApplyTime;
        private byte? _AuditState;
        private DateTime? _AuditTime;
        private DateTime? _CreateTime;
        private string _CreateUser;
        private int _ID;
        private int? _IsDeleted;
        private string _MemberID;
        private string _OperateRemark;
        private string _OperateUser;
        private byte? _PayState;
        private Guid? _ProductGuid;
        private string _ProductName;
        private string _Remark;
        private string _ShopID;
        private string _ShopName;
        private DateTime? _StartTime;
        private string _SubstationID;
        private byte? _Type;
        private decimal? _Ztc_Money;
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

        [Column(Storage="_ApplyTime", DbType="DateTime")]
        public DateTime? ApplyTime
        {
            get
            {
                return this._ApplyTime;
            }
            set
            {
                if (this._ApplyTime != value)
                {
                    this.SendPropertyChanging();
                    this._ApplyTime = value;
                    this.SendPropertyChanged("ApplyTime");
                }
            }
        }

        [Column(Storage="_AuditState", DbType="TinyInt")]
        public byte? AuditState
        {
            get
            {
                return this._AuditState;
            }
            set
            {
                if (this._AuditState != value)
                {
                    this.SendPropertyChanging();
                    this._AuditState = value;
                    this.SendPropertyChanged("AuditState");
                }
            }
        }

        [Column(Storage="_AuditTime", DbType="DateTime")]
        public DateTime? AuditTime
        {
            get
            {
                return this._AuditTime;
            }
            set
            {
                if (this._AuditTime != value)
                {
                    this.SendPropertyChanging();
                    this._AuditTime = value;
                    this.SendPropertyChanged("AuditTime");
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

        [Column(Storage="_MemberID", DbType="NVarChar(50)")]
        public string MemberID
        {
            get
            {
                return this._MemberID;
            }
            set
            {
                if (this._MemberID != value)
                {
                    this.SendPropertyChanging();
                    this._MemberID = value;
                    this.SendPropertyChanged("MemberID");
                }
            }
        }

        [Column(Storage="_OperateRemark", DbType="NVarChar(400)")]
        public string OperateRemark
        {
            get
            {
                return this._OperateRemark;
            }
            set
            {
                if (this._OperateRemark != value)
                {
                    this.SendPropertyChanging();
                    this._OperateRemark = value;
                    this.SendPropertyChanged("OperateRemark");
                }
            }
        }

        [Column(Storage="_OperateUser", DbType="NVarChar(50)")]
        public string OperateUser
        {
            get
            {
                return this._OperateUser;
            }
            set
            {
                if (this._OperateUser != value)
                {
                    this.SendPropertyChanging();
                    this._OperateUser = value;
                    this.SendPropertyChanged("OperateUser");
                }
            }
        }

        [Column(Storage="_PayState", DbType="TinyInt")]
        public byte? PayState
        {
            get
            {
                return this._PayState;
            }
            set
            {
                if (this._PayState != value)
                {
                    this.SendPropertyChanging();
                    this._PayState = value;
                    this.SendPropertyChanged("PayState");
                }
            }
        }

        [Column(Storage="_ProductGuid", DbType="UniqueIdentifier")]
        public Guid? ProductGuid
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

        [Column(Storage="_ProductName", DbType="NVarChar(100)")]
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

        [Column(Storage="_Remark", DbType="NVarChar(400)")]
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

        [Column(Storage="_ShopID", DbType="VarChar(50)")]
        public string ShopID
        {
            get
            {
                return this._ShopID;
            }
            set
            {
                if (this._ShopID != value)
                {
                    this.SendPropertyChanging();
                    this._ShopID = value;
                    this.SendPropertyChanged("ShopID");
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

        [Column(Storage="_StartTime", DbType="DateTime")]
        public DateTime? StartTime
        {
            get
            {
                return this._StartTime;
            }
            set
            {
                if (this._StartTime != value)
                {
                    this.SendPropertyChanging();
                    this._StartTime = value;
                    this.SendPropertyChanged("StartTime");
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

        [Column(Storage="_Type", DbType="TinyInt")]
        public byte? Type
        {
            get
            {
                return this._Type;
            }
            set
            {
                if (this._Type != value)
                {
                    this.SendPropertyChanging();
                    this._Type = value;
                    this.SendPropertyChanged("Type");
                }
            }
        }

        [Column(Storage="_Ztc_Money", DbType="Decimal(18,2)")]
        public decimal? Ztc_Money
        {
            get
            {
                return this._Ztc_Money;
            }
            set
            {
                decimal? nullable = this._Ztc_Money;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this.SendPropertyChanging();
                    this._Ztc_Money = value;
                    this.SendPropertyChanged("Ztc_Money");
                }
            }
        }
    }
}

