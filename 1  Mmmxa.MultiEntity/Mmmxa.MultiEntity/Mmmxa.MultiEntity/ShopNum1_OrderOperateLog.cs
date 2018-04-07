namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_OrderOperateLog")]
    public class ShopNum1_OrderOperateLog : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private string _CreateUser;
        private string _CurrentStateMsg;
        private System.Guid _Guid;
        private int _IsDeleted;
        private string _Memo;
        private string _NextStateMsg;
        private int _OderStatus;
        private DateTime _OperateDateTime;
        private System.Guid _OrderInfoGuid;
        private int _PaymentStatus;
        private int _ShipmentStatus;
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

        [Column(Storage="_CurrentStateMsg", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
        public string CurrentStateMsg
        {
            get
            {
                return this._CurrentStateMsg;
            }
            set
            {
                if (this._CurrentStateMsg != value)
                {
                    this.SendPropertyChanging();
                    this._CurrentStateMsg = value;
                    this.SendPropertyChanged("CurrentStateMsg");
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

        [Column(Storage="_Memo", DbType="NVarChar(200)")]
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

        [Column(Storage="_NextStateMsg", DbType="NVarChar(100)")]
        public string NextStateMsg
        {
            get
            {
                return this._NextStateMsg;
            }
            set
            {
                if (this._NextStateMsg != value)
                {
                    this.SendPropertyChanging();
                    this._NextStateMsg = value;
                    this.SendPropertyChanged("NextStateMsg");
                }
            }
        }

        [Column(Storage="_OderStatus", DbType="Int NOT NULL")]
        public int OderStatus
        {
            get
            {
                return this._OderStatus;
            }
            set
            {
                if (this._OderStatus != value)
                {
                    this.SendPropertyChanging();
                    this._OderStatus = value;
                    this.SendPropertyChanged("OderStatus");
                }
            }
        }

        [Column(Storage="_OperateDateTime", DbType="DateTime NOT NULL")]
        public DateTime OperateDateTime
        {
            get
            {
                return this._OperateDateTime;
            }
            set
            {
                if (this._OperateDateTime != value)
                {
                    this.SendPropertyChanging();
                    this._OperateDateTime = value;
                    this.SendPropertyChanged("OperateDateTime");
                }
            }
        }

        [Column(Storage="_OrderInfoGuid", DbType="UniqueIdentifier NOT NULL")]
        public System.Guid OrderInfoGuid
        {
            get
            {
                return this._OrderInfoGuid;
            }
            set
            {
                if (this._OrderInfoGuid != value)
                {
                    this.SendPropertyChanging();
                    this._OrderInfoGuid = value;
                    this.SendPropertyChanged("OrderInfoGuid");
                }
            }
        }

        [Column(Storage="_PaymentStatus", DbType="Int NOT NULL")]
        public int PaymentStatus
        {
            get
            {
                return this._PaymentStatus;
            }
            set
            {
                if (this._PaymentStatus != value)
                {
                    this.SendPropertyChanging();
                    this._PaymentStatus = value;
                    this.SendPropertyChanged("PaymentStatus");
                }
            }
        }

        [Column(Storage="_ShipmentStatus", DbType="Int NOT NULL")]
        public int ShipmentStatus
        {
            get
            {
                return this._ShipmentStatus;
            }
            set
            {
                if (this._ShipmentStatus != value)
                {
                    this.SendPropertyChanging();
                    this._ShipmentStatus = value;
                    this.SendPropertyChanged("ShipmentStatus");
                }
            }
        }
    }
}

