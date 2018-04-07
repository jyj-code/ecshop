namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_WebSite")]
    public class ShopNum1_WebSite : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private string _addressCode;
        private string _addressName;
        private string _domain;
        private int _ID;
        private bool _isAvailable;
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

        [Column(Storage="_addressCode", DbType="NVarChar(50)")]
        public string addressCode
        {
            get
            {
                return this._addressCode;
            }
            set
            {
                if (this._addressCode != value)
                {
                    this.SendPropertyChanging();
                    this._addressCode = value;
                    this.SendPropertyChanged("addressCode");
                }
            }
        }

        [Column(Storage="_addressName", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
        public string addressName
        {
            get
            {
                return this._addressName;
            }
            set
            {
                if (this._addressName != value)
                {
                    this.SendPropertyChanging();
                    this._addressName = value;
                    this.SendPropertyChanged("addressName");
                }
            }
        }

        [Column(Storage="_domain", DbType="VarChar(250) NOT NULL", CanBeNull=false)]
        public string domain
        {
            get
            {
                return this._domain;
            }
            set
            {
                if (this._domain != value)
                {
                    this.SendPropertyChanging();
                    this._domain = value;
                    this.SendPropertyChanged("domain");
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

        [Column(Storage="_isAvailable", DbType="Bit NOT NULL")]
        public bool isAvailable
        {
            get
            {
                return this._isAvailable;
            }
            set
            {
                if (this._isAvailable != value)
                {
                    this.SendPropertyChanging();
                    this._isAvailable = value;
                    this.SendPropertyChanged("isAvailable");
                }
            }
        }
    }
}

