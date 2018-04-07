namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_SpecValue")]
    public class ShopNum1_SpecValue : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private int _ID;
        private string _Imagepath;
        private string _Name;
        private int? _OrderId;
        private int? _SpecID;
        private string _tbPropValue;
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

        [Column(Storage="_Imagepath", DbType="VarChar(100)")]
        public string Imagepath
        {
            get
            {
                return this._Imagepath;
            }
            set
            {
                if (this._Imagepath != value)
                {
                    this.SendPropertyChanging();
                    this._Imagepath = value;
                    this.SendPropertyChanged("Imagepath");
                }
            }
        }

        [Column(Storage="_Name", DbType="VarChar(50)")]
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

        [Column(Storage="_OrderId", DbType="Int")]
        public int? OrderId
        {
            get
            {
                return this._OrderId;
            }
            set
            {
                if (this._OrderId != value)
                {
                    this.SendPropertyChanging();
                    this._OrderId = value;
                    this.SendPropertyChanged("OrderId");
                }
            }
        }

        [Column(Storage="_SpecID", DbType="Int")]
        public int? SpecID
        {
            get
            {
                return this._SpecID;
            }
            set
            {
                if (this._SpecID != value)
                {
                    this.SendPropertyChanging();
                    this._SpecID = value;
                    this.SendPropertyChanged("SpecID");
                }
            }
        }

        [Column(Storage="_tbPropValue", DbType="VarChar(50)")]
        public string tbPropValue
        {
            get
            {
                return this._tbPropValue;
            }
            set
            {
                if (this._tbPropValue != value)
                {
                    this.SendPropertyChanging();
                    this._tbPropValue = value;
                    this.SendPropertyChanged("tbPropValue");
                }
            }
        }
    }
}

