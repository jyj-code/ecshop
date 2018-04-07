namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_ShopProductProp")]
    public class ShopNum1_ShopProductProp : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private string _Content;
        private int _ID;
        private bool _IsImport;
        private int _OrderID;
        private string _PropName;
        private byte _ShowType;
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

        [Column(Storage="_Content", DbType="NVarChar(4000)")]
        public string Content
        {
            get
            {
                return this._Content;
            }
            set
            {
                if (this._Content != value)
                {
                    this.SendPropertyChanging();
                    this._Content = value;
                    this.SendPropertyChanged("Content");
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

        [Column(Storage="_IsImport", DbType="Bit NOT NULL")]
        public bool IsImport
        {
            get
            {
                return this._IsImport;
            }
            set
            {
                if (this._IsImport != value)
                {
                    this.SendPropertyChanging();
                    this._IsImport = value;
                    this.SendPropertyChanged("IsImport");
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

        [Column(Storage="_PropName", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
        public string PropName
        {
            get
            {
                return this._PropName;
            }
            set
            {
                if (this._PropName != value)
                {
                    this.SendPropertyChanging();
                    this._PropName = value;
                    this.SendPropertyChanged("PropName");
                }
            }
        }

        [Column(Storage="_ShowType", DbType="TinyInt NOT NULL")]
        public byte ShowType
        {
            get
            {
                return this._ShowType;
            }
            set
            {
                if (this._ShowType != value)
                {
                    this.SendPropertyChanging();
                    this._ShowType = value;
                    this.SendPropertyChanged("ShowType");
                }
            }
        }
    }
}

