namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_SpecificationProductImage")]
    public class ShopNum1_SpecificationProductImage : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private int _Guid;
        private string _MemLoginID;
        private System.Guid _ProductGuid;
        private string _ProductMultiImage;
        private string _SpecificationValue;
        private string _tbSpecificationValue;
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

        [Column(Storage="_Guid", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
        public int Guid
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

        [Column(Storage="_ProductGuid", DbType="UniqueIdentifier NOT NULL")]
        public System.Guid ProductGuid
        {
            get
            {
                return this._ProductGuid;
            }
            set
            {
                if (this._ProductGuid != value)
                {
                    this.SendPropertyChanging();
                    this._ProductGuid = value;
                    this.SendPropertyChanged("ProductGuid");
                }
            }
        }

        [Column(Storage="_ProductMultiImage", DbType="NVarChar(1000) NOT NULL", CanBeNull=false)]
        public string ProductMultiImage
        {
            get
            {
                return this._ProductMultiImage;
            }
            set
            {
                if (this._ProductMultiImage != value)
                {
                    this.SendPropertyChanging();
                    this._ProductMultiImage = value;
                    this.SendPropertyChanged("ProductMultiImage");
                }
            }
        }

        [Column(Storage="_SpecificationValue", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
        public string SpecificationValue
        {
            get
            {
                return this._SpecificationValue;
            }
            set
            {
                if (this._SpecificationValue != value)
                {
                    this.SendPropertyChanging();
                    this._SpecificationValue = value;
                    this.SendPropertyChanged("SpecificationValue");
                }
            }
        }

        [Column(Storage="_tbSpecificationValue", DbType="VarChar(50)")]
        public string tbSpecificationValue
        {
            get
            {
                return this._tbSpecificationValue;
            }
            set
            {
                if (this._tbSpecificationValue != value)
                {
                    this.SendPropertyChanging();
                    this._tbSpecificationValue = value;
                    this.SendPropertyChanged("tbSpecificationValue");
                }
            }
        }
    }
}

