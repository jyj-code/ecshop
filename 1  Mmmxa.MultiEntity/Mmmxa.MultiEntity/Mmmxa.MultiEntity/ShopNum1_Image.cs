namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_Image")]
    public class ShopNum1_Image : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private string _CreateTime;
        private string _CreateUser;
        private string _Description;
        private System.Guid _Guid;
        private int _ImageCategoryID;
        private string _ImagePath;
        private string _ImageType;
        private int _IsDeleted;
        private int _IsDownload;
        private string _ModifyTime;
        private string _ModifyUser;
        private string _Name;
        private string _SubstationID;
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
        public string CreateTime
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

        [Column(Storage="_Description", DbType="NVarChar(500)")]
        public string Description
        {
            get
            {
                return this._Description;
            }
            set
            {
                if (this._Description != value)
                {
                    this.SendPropertyChanging();
                    this._Description = value;
                    this.SendPropertyChanged("Description");
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

        [Column(Storage="_ImageType", DbType="NVarChar(250)")]
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

        [Column(Storage="_IsDeleted", DbType="Int NOT NULL")]
        public int IsDeleted
        {
            get
            {
                return this._IsDeleted;
            }
            set
            {
                if (this._IsDeleted != value)
                {
                    this.SendPropertyChanging();
                    this._IsDeleted = value;
                    this.SendPropertyChanged("IsDeleted");
                }
            }
        }

        [Column(Storage="_IsDownload", DbType="Int NOT NULL")]
        public int IsDownload
        {
            get
            {
                return this._IsDownload;
            }
            set
            {
                if (this._IsDownload != value)
                {
                    this.SendPropertyChanging();
                    this._IsDownload = value;
                    this.SendPropertyChanged("IsDownload");
                }
            }
        }

        [Column(Storage="_ModifyTime", DbType="DateTime NOT NULL")]
        public string ModifyTime
        {
            get
            {
                return this._ModifyTime;
            }
            set
            {
                if (this._ModifyTime != value)
                {
                    this.SendPropertyChanging();
                    this._ModifyTime = value;
                    this.SendPropertyChanged("ModifyTime");
                }
            }
        }

        [Column(Storage="_ModifyUser", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string ModifyUser
        {
            get
            {
                return this._ModifyUser;
            }
            set
            {
                if (this._ModifyUser != value)
                {
                    this.SendPropertyChanging();
                    this._ModifyUser = value;
                    this.SendPropertyChanged("ModifyUser");
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

        [Column(Storage="_SubstationID", DbType="NVarChar(100)")]
        public string SubstationID
        {
            get
            {
                return this._SubstationID;
            }
            set
            {
                if (this._SubstationID != value)
                {
                    this.SendPropertyChanging();
                    this._SubstationID = value;
                    this.SendPropertyChanged("SubstationID");
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

