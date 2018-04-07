namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_ShopProductPropValue")]
    public class ShopNum1_ShopProductPropValue : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private int _ID;
        private string _Name;
        private int? _OrderID;
        private int _PropId;
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

        [Column(Storage="_Name", DbType="NVarChar(250)")]
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

        [Column(Storage="_OrderID", DbType="Int")]
        public int? OrderID
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

        [Column(Storage="_PropId", DbType="Int NOT NULL")]
        public int PropId
        {
            get
            {
                return this._PropId;
            }
            set
            {
                if (this._PropId != value)
                {
                    this.SendPropertyChanging();
                    this._PropId = value;
                    this.SendPropertyChanged("PropId");
                }
            }
        }
    }
}

