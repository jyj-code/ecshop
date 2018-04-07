namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_AttachMent")]
    public class ShopNum1_AttachMent : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private System.Guid _AssociatedCategoryGuid;
        private string _AttachmentURL;
        private string _Description;
        private System.Guid _Guid;
        private string _Title;
        private DateTime _UploadTime;
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

        [Column(Storage="_AssociatedCategoryGuid", DbType="UniqueIdentifier NOT NULL")]
        public System.Guid AssociatedCategoryGuid
        {
            get
            {
                return this._AssociatedCategoryGuid;
            }
            set
            {
                if (this._AssociatedCategoryGuid != value)
                {
                    this.SendPropertyChanging();
                    this._AssociatedCategoryGuid = value;
                    this.SendPropertyChanged("AssociatedCategoryGuid");
                }
            }
        }

        [Column(Storage="_AttachmentURL", DbType="NVarChar(250) NOT NULL", CanBeNull=false)]
        public string AttachmentURL
        {
            get
            {
                return this._AttachmentURL;
            }
            set
            {
                if (this._AttachmentURL != value)
                {
                    this.SendPropertyChanging();
                    this._AttachmentURL = value;
                    this.SendPropertyChanged("AttachmentURL");
                }
            }
        }

        [Column(Storage="_Description", DbType="NVarChar(150)")]
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

        [Column(Storage="_Title", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string Title
        {
            get
            {
                return this._Title;
            }
            set
            {
                if (this._Title != value)
                {
                    this.SendPropertyChanging();
                    this._Title = value;
                    this.SendPropertyChanged("Title");
                }
            }
        }

        [Column(Storage="_UploadTime", DbType="DateTime NOT NULL")]
        public DateTime UploadTime
        {
            get
            {
                return this._UploadTime;
            }
            set
            {
                if (this._UploadTime != value)
                {
                    this.SendPropertyChanging();
                    this._UploadTime = value;
                    this.SendPropertyChanged("UploadTime");
                }
            }
        }
    }
}

