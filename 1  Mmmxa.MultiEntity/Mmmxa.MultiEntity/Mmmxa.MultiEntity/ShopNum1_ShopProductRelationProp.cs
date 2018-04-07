namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_ShopProductRelationProp")]
    public class ShopNum1_ShopProductRelationProp : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private int _ID;
        private string _Memlogid;
        private Guid _ProdGuid;
        private int _PropID;
        private int? _PropValueID;
        private string _PropValueName;
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

        [Column(Storage="_Memlogid", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string Memlogid
        {
            get
            {
                return this._Memlogid;
            }
            set
            {
                if (this._Memlogid != value)
                {
                    this.SendPropertyChanging();
                    this._Memlogid = value;
                    this.SendPropertyChanged("Memlogid");
                }
            }
        }

        [Column(Storage="_ProdGuid", DbType="UniqueIdentifier NOT NULL")]
        public Guid ProdGuid
        {
            get
            {
                return this._ProdGuid;
            }
            set
            {
                if (this._ProdGuid != value)
                {
                    this.SendPropertyChanging();
                    this._ProdGuid = value;
                    this.SendPropertyChanged("ProdGuid");
                }
            }
        }

        [Column(Storage="_PropID", DbType="Int NOT NULL")]
        public int PropID
        {
            get
            {
                return this._PropID;
            }
            set
            {
                if (this._PropID != value)
                {
                    this.SendPropertyChanging();
                    this._PropID = value;
                    this.SendPropertyChanged("PropID");
                }
            }
        }

        [Column(Storage="_PropValueID", DbType="Int")]
        public int? PropValueID
        {
            get
            {
                return this._PropValueID;
            }
            set
            {
                if (this._PropValueID != value)
                {
                    this.SendPropertyChanging();
                    this._PropValueID = value;
                    this.SendPropertyChanged("PropValueID");
                }
            }
        }

        [Column(Storage="_PropValueName", DbType="NVarChar(500) NOT NULL", CanBeNull=false)]
        public string PropValueName
        {
            get
            {
                return this._PropValueName;
            }
            set
            {
                if (this._PropValueName != value)
                {
                    this.SendPropertyChanging();
                    this._PropValueName = value;
                    this.SendPropertyChanged("PropValueName");
                }
            }
        }
    }
}

