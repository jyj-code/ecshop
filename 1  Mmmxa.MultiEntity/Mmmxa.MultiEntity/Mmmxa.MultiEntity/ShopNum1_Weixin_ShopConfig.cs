namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_Weixin_ShopConfig")]
    public class ShopNum1_Weixin_ShopConfig : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private byte? _ConfigType;
        private int _ID;
        private int? _ShopID;
        private string _Url;
        private string _Value;
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

        [Column(Storage="_ConfigType", DbType="TinyInt")]
        public byte? ConfigType
        {
            get
            {
                return this._ConfigType;
            }
            set
            {
                if (this._ConfigType != value)
                {
                    this.SendPropertyChanging();
                    this._ConfigType = value;
                    this.SendPropertyChanged("ConfigType");
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

        [Column(Storage="_ShopID", DbType="Int")]
        public int? ShopID
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

        [Column(Storage="_Url", DbType="VarChar(300)")]
        public string Url
        {
            get
            {
                return this._Url;
            }
            set
            {
                if (this._Url != value)
                {
                    this.SendPropertyChanging();
                    this._Url = value;
                    this.SendPropertyChanged("Url");
                }
            }
        }

        [Column(Storage="_Value", DbType="VarChar(300)")]
        public string Value
        {
            get
            {
                return this._Value;
            }
            set
            {
                if (this._Value != value)
                {
                    this.SendPropertyChanging();
                    this._Value = value;
                    this.SendPropertyChanged("Value");
                }
            }
        }
    }
}

