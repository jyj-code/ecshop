namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_CreditSumModifyLog")]
    public class ShopNum1_CreditSumModifyLog : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private DateTime? _CreateTime;
        private string _CreateUser;
        private decimal _CurrentCreditSum;
        private DateTime _Date;
        private System.Guid _Guid;
        private int? _IsDeleted;
        private decimal _LastOperateSum;
        private string _MemLoginID;
        private string _Memo;
        private decimal _OperateSum;
        private int _OperateType;
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

        [Column(Storage="_CurrentCreditSum", DbType="Decimal(18,2) NOT NULL")]
        public decimal CurrentCreditSum
        {
            get
            {
                return this._CurrentCreditSum;
            }
            set
            {
                if (this._CurrentCreditSum != value)
                {
                    this.SendPropertyChanging();
                    this._CurrentCreditSum = value;
                    this.SendPropertyChanged("CurrentCreditSum");
                }
            }
        }

        [Column(Storage="_Date", DbType="DateTime NOT NULL")]
        public DateTime Date
        {
            get
            {
                return this._Date;
            }
            set
            {
                if (this._Date != value)
                {
                    this.SendPropertyChanging();
                    this._Date = value;
                    this.SendPropertyChanged("Date");
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

        [Column(Storage="_LastOperateSum", DbType="Decimal(18,2) NOT NULL")]
        public decimal LastOperateSum
        {
            get
            {
                return this._LastOperateSum;
            }
            set
            {
                if (this._LastOperateSum != value)
                {
                    this.SendPropertyChanging();
                    this._LastOperateSum = value;
                    this.SendPropertyChanged("LastOperateSum");
                }
            }
        }

        [Column(Storage="_MemLoginID", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string MemLoginID
        {
            get
            {
                return this._MemLoginID;
            }
            set
            {
                if (this._MemLoginID != value)
                {
                    this.SendPropertyChanging();
                    this._MemLoginID = value;
                    this.SendPropertyChanged("MemLoginID");
                }
            }
        }

        [Column(Storage="_Memo", DbType="NVarChar(250)")]
        public string Memo
        {
            get
            {
                return this._Memo;
            }
            set
            {
                if (this._Memo != value)
                {
                    this.SendPropertyChanging();
                    this._Memo = value;
                    this.SendPropertyChanged("Memo");
                }
            }
        }

        [Column(Storage="_OperateSum", DbType="Decimal(18,2) NOT NULL")]
        public decimal OperateSum
        {
            get
            {
                return this._OperateSum;
            }
            set
            {
                if (this._OperateSum != value)
                {
                    this.SendPropertyChanging();
                    this._OperateSum = value;
                    this.SendPropertyChanged("OperateSum");
                }
            }
        }

        [Column(Storage="_OperateType", DbType="Int NOT NULL")]
        public int OperateType
        {
            get
            {
                return this._OperateType;
            }
            set
            {
                if (this._OperateType != value)
                {
                    this.SendPropertyChanging();
                    this._OperateType = value;
                    this.SendPropertyChanged("OperateType");
                }
            }
        }
    }
}

