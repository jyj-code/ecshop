namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_PaymentType")]
    public class ShopNum1_PaymentType : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private string _BakcImg;
        private System.Guid _Guid;
        private byte? _IsShopUse;
        private string _Memo;
        private string _Name;
        private int _OrderID;
        private string _PaymentType;
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

        [Column(Storage="_BakcImg", DbType="NVarChar(250)")]
        public string BakcImg
        {
            get
            {
                return this._BakcImg;
            }
            set
            {
                if (this._BakcImg != value)
                {
                    this.SendPropertyChanging();
                    this._BakcImg = value;
                    this.SendPropertyChanged("BakcImg");
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

        [Column(Storage="_IsShopUse", DbType="TinyInt")]
        public byte? IsShopUse
        {
            get
            {
                return this._IsShopUse;
            }
            set
            {
                if (this._IsShopUse != value)
                {
                    this.SendPropertyChanging();
                    this._IsShopUse = value;
                    this.SendPropertyChanged("IsShopUse");
                }
            }
        }

        [Column(Storage="_Memo", DbType="NVarChar(4000)")]
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

        [Column(Storage="_Name", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
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

        [Column(Storage="_PaymentType", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string PaymentType
        {
            get
            {
                return this._PaymentType;
            }
            set
            {
                if (this._PaymentType != value)
                {
                    this.SendPropertyChanging();
                    this._PaymentType = value;
                    this.SendPropertyChanged("PaymentType");
                }
            }
        }
    }
}

