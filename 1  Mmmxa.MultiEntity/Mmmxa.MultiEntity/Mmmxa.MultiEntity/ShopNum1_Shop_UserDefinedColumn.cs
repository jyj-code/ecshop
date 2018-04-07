namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_Shop_UserDefinedColumn")]
    public class ShopNum1_Shop_UserDefinedColumn : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private System.Guid _Guid;
        private int _IfOpen;
        private int _IsShow;
        private string _LinkAddress;
        private string _MemLoginID;
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

        [Column(Storage="_IfOpen", DbType="Int NOT NULL")]
        public int IfOpen
        {
            get
            {
                return this._IfOpen;
            }
            set
            {
                if (this._IfOpen != value)
                {
                    this.SendPropertyChanging();
                    this._IfOpen = value;
                    this.SendPropertyChanged("IfOpen");
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

        [Column(Storage="_LinkAddress", DbType="NVarChar(150) NOT NULL", CanBeNull=false)]
        public string LinkAddress
        {
            get
            {
                return this._LinkAddress;
            }
            set
            {
                if (this._LinkAddress != value)
                {
                    this.SendPropertyChanging();
                    this._LinkAddress = value;
                    this.SendPropertyChanged("LinkAddress");
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

