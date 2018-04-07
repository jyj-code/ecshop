namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_Shop_Image")]
    public class ShopNum1_Shop_Image : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private DateTime _CreateTime;
        private string _CreateUser;
        private string _DisplaySize;
        private int _Id;
        private int _ImageCategoryID;
        private string _ImagePath;
        private double? _ImageSize;
        private string _ImageType;
        private string _Name;
        private int _UseTimes;
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

        [Column(Storage="_CreateTime", DbType="DateTime NOT NULL")]
        public DateTime CreateTime
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

        [Column(Storage="_CreateUser", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string CreateUser
        {
            get
            {
                return this._CreateUser;
            }
            set
            {
                if (this._CreateUser != value)
                {
                    this.SendPropertyChanging();
                    this._CreateUser = value;
                    this.SendPropertyChanged("CreateUser");
                }
            }
        }

        [Column(Storage="_DisplaySize", DbType="VarChar(20)")]
        public string DisplaySize
        {
            get
            {
                return this._DisplaySize;
            }
            set
            {
                if (this._DisplaySize != value)
                {
                    this.SendPropertyChanging();
                    this._DisplaySize = value;
                    this.SendPropertyChanged("DisplaySize");
                }
            }
        }

        [Column(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
        public int Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                if (this._Id != value)
                {
                    this.SendPropertyChanging();
                    this._Id = value;
                    this.SendPropertyChanged("Id");
                }
            }
        }

        [Column(Storage="_ImageCategoryID", DbType="Int NOT NULL")]
        public int ImageCategoryID
        {
            get
            {
                return this._ImageCategoryID;
            }
            set
            {
                if (this._ImageCategoryID != value)
                {
                    this.SendPropertyChanging();
                    this._ImageCategoryID = value;
                    this.SendPropertyChanged("ImageCategoryID");
                }
            }
        }

        [Column(Storage="_ImagePath", DbType="NVarChar(250) NOT NULL", CanBeNull=false)]
        public string ImagePath
        {
            get
            {
                return this._ImagePath;
            }
            set
            {
                if (this._ImagePath != value)
                {
                    this.SendPropertyChanging();
                    this._ImagePath = value;
                    this.SendPropertyChanged("ImagePath");
                }
            }
        }

        [Column(Storage="_ImageSize", DbType="Float")]
        public double? ImageSize
        {
            get
            {
                return this._ImageSize;
            }
            set
            {
                if (this._ImageSize != value)
                {
                    this.SendPropertyChanging();
                    this._ImageSize = value;
                    this.SendPropertyChanged("ImageSize");
                }
            }
        }

        [Column(Storage="_ImageType", DbType="NVarChar(10) NOT NULL", CanBeNull=false)]
        public string ImageType
        {
            get
            {
                return this._ImageType;
            }
            set
            {
                if (this._ImageType != value)
                {
                    this.SendPropertyChanging();
                    this._ImageType = value;
                    this.SendPropertyChanged("ImageType");
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

        [Column(Storage="_UseTimes", DbType="Int NOT NULL")]
        public int UseTimes
        {
            get
            {
                return this._UseTimes;
            }
            set
            {
                if (this._UseTimes != value)
                {
                    this.SendPropertyChanging();
                    this._UseTimes = value;
                    this.SendPropertyChanged("UseTimes");
                }
            }
        }
    }
}

