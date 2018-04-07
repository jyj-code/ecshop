namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_OperateLog")]
    public class ShopNum1_OperateLog : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private DateTime _Date;
        private System.Guid _Guid;
        private string _IP;
        private string _OperatorID;
        private string _PageName;
        private string _Record;
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

        [Column(Storage="_IP", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string IP
        {
            get
            {
                return this._IP;
            }
            set
            {
                if (this._IP != value)
                {
                    this.SendPropertyChanging();
                    this._IP = value;
                    this.SendPropertyChanged("IP");
                }
            }
        }

        [Column(Storage="_OperatorID", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string OperatorID
        {
            get
            {
                return this._OperatorID;
            }
            set
            {
                if (this._OperatorID != value)
                {
                    this.SendPropertyChanging();
                    this._OperatorID = value;
                    this.SendPropertyChanged("OperatorID");
                }
            }
        }

        [Column(Storage="_PageName", DbType="NVarChar(150) NOT NULL", CanBeNull=false)]
        public string PageName
        {
            get
            {
                return this._PageName;
            }
            set
            {
                if (this._PageName != value)
                {
                    this.SendPropertyChanging();
                    this._PageName = value;
                    this.SendPropertyChanged("PageName");
                }
            }
        }

        [Column(Storage="_Record", DbType="NVarChar(250) NOT NULL", CanBeNull=false)]
        public string Record
        {
            get
            {
                return this._Record;
            }
            set
            {
                if (this._Record != value)
                {
                    this.SendPropertyChanging();
                    this._Record = value;
                    this.SendPropertyChanged("Record");
                }
            }
        }
    }
}

