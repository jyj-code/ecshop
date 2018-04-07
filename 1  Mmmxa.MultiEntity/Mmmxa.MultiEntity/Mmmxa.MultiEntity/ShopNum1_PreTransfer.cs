namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_PreTransfer")]
    public class ShopNum1_PreTransfer : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private DateTime? _Date;
        private System.Guid _Guid;
        private byte? _IsDeleted;
        private string _MemLoginID;
        private string _Memo;
        private string _OperateMoney;
        private byte? _OperateStatus;
        private string _OrderNumber;
        private string _RMemberID;
        private int? _type;
        private string _YzCode;
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

        [Column(Storage="_Date", DbType="DateTime")]
        public DateTime? Date
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

        [Column(Storage="_IsDeleted", DbType="TinyInt")]
        public byte? IsDeleted
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

        [Column(Storage="_MemLoginID", DbType="NChar(10)")]
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

        [Column(Storage="_Memo", DbType="NChar(10)")]
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

        [Column(Storage="_OperateMoney", DbType="NChar(10)")]
        public string OperateMoney
        {
            get
            {
                return this._OperateMoney;
            }
            set
            {
                if (this._OperateMoney != value)
                {
                    this.SendPropertyChanging();
                    this._OperateMoney = value;
                    this.SendPropertyChanged("OperateMoney");
                }
            }
        }

        [Column(Storage="_OperateStatus", DbType="TinyInt")]
        public byte? OperateStatus
        {
            get
            {
                return this._OperateStatus;
            }
            set
            {
                if (this._OperateStatus != value)
                {
                    this.SendPropertyChanging();
                    this._OperateStatus = value;
                    this.SendPropertyChanged("OperateStatus");
                }
            }
        }

        [Column(Storage="_OrderNumber", DbType="NChar(10)")]
        public string OrderNumber
        {
            get
            {
                return this._OrderNumber;
            }
            set
            {
                if (this._OrderNumber != value)
                {
                    this.SendPropertyChanging();
                    this._OrderNumber = value;
                    this.SendPropertyChanged("OrderNumber");
                }
            }
        }

        [Column(Storage="_RMemberID", DbType="NChar(10)")]
        public string RMemberID
        {
            get
            {
                return this._RMemberID;
            }
            set
            {
                if (this._RMemberID != value)
                {
                    this.SendPropertyChanging();
                    this._RMemberID = value;
                    this.SendPropertyChanged("RMemberID");
                }
            }
        }

        [Column(Storage="_type", DbType="Int")]
        public int? type
        {
            get
            {
                return this._type;
            }
            set
            {
                if (this._type != value)
                {
                    this.SendPropertyChanging();
                    this._type = value;
                    this.SendPropertyChanged("type");
                }
            }
        }

        [Column(Storage="_YzCode", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
        public string YzCode
        {
            get
            {
                return this._YzCode;
            }
            set
            {
                if (this._YzCode != value)
                {
                    this.SendPropertyChanging();
                    this._YzCode = value;
                    this.SendPropertyChanged("YzCode");
                }
            }
        }
    }
}

