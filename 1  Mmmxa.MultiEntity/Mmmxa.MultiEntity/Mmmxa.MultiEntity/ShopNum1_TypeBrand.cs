namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_TypeBrand")]
    public class ShopNum1_TypeBrand : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private Guid? _BrandGuid;
        private int _ID;
        private int? _TypeID;
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

        [Column(Storage="_BrandGuid", DbType="UniqueIdentifier")]
        public Guid? BrandGuid
        {
            get
            {
                return this._BrandGuid;
            }
            set
            {
                if (this._BrandGuid != value)
                {
                    this.SendPropertyChanging();
                    this._BrandGuid = value;
                    this.SendPropertyChanged("BrandGuid");
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

        [Column(Storage="_TypeID", DbType="Int")]
        public int? TypeID
        {
            get
            {
                return this._TypeID;
            }
            set
            {
                if (this._TypeID != value)
                {
                    this.SendPropertyChanging();
                    this._TypeID = value;
                    this.SendPropertyChanged("TypeID");
                }
            }
        }
    }
}

