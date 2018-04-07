namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_ProductCategoryAndProductBranDrelation")]
    public class ShopNum1_ProductCategoryAndProductBranDrelation : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private Guid? _BrandGuid;
        private DateTime? _CreateTime;
        private int _ID;
        private int? _ProductCategoryCategoryLevel;
        private string _ProductCategoryCode;
        private int? _ProductCategoryID;
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

        [Column(Storage="_CreateTime", DbType="DateTime")]
        public DateTime? CreateTime
        {
            get
            {
                return this._CreateTime;
            }
            set
            {
                if (this._CreateTime != value)
                {
                    this.SendPropertyChanging();
                    this._CreateTime = value;
                    this.SendPropertyChanged("CreateTime");
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

        [Column(Storage="_ProductCategoryCategoryLevel", DbType="Int")]
        public int? ProductCategoryCategoryLevel
        {
            get
            {
                return this._ProductCategoryCategoryLevel;
            }
            set
            {
                if (this._ProductCategoryCategoryLevel != value)
                {
                    this.SendPropertyChanging();
                    this._ProductCategoryCategoryLevel = value;
                    this.SendPropertyChanged("ProductCategoryCategoryLevel");
                }
            }
        }

        [Column(Storage="_ProductCategoryCode", DbType="NVarChar(9)")]
        public string ProductCategoryCode
        {
            get
            {
                return this._ProductCategoryCode;
            }
            set
            {
                if (this._ProductCategoryCode != value)
                {
                    this.SendPropertyChanging();
                    this._ProductCategoryCode = value;
                    this.SendPropertyChanged("ProductCategoryCode");
                }
            }
        }

        [Column(Storage="_ProductCategoryID", DbType="Int")]
        public int? ProductCategoryID
        {
            get
            {
                return this._ProductCategoryID;
            }
            set
            {
                if (this._ProductCategoryID != value)
                {
                    this.SendPropertyChanging();
                    this._ProductCategoryID = value;
                    this.SendPropertyChanged("ProductCategoryID");
                }
            }
        }
    }
}

