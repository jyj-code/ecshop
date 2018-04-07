namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_ShopURLManage")]
    public class ShopNum1_ShopURLManage : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private string _DoMain;
        private string _GoUrl;
        private int _ID;
        private int _IsAudit;
        private string _MemLoginID;
        private string _SiteNumber;
        private string _Title;
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

        [Column(Storage="_DoMain", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
        public string DoMain
        {
            get
            {
                return this._DoMain;
            }
            set
            {
                if (this._DoMain != value)
                {
                    this.SendPropertyChanging();
                    this._DoMain = value;
                    this.SendPropertyChanged("DoMain");
                }
            }
        }

        [Column(Storage="_GoUrl", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
        public string GoUrl
        {
            get
            {
                return this._GoUrl;
            }
            set
            {
                if (this._GoUrl != value)
                {
                    this.SendPropertyChanging();
                    this._GoUrl = value;
                    this.SendPropertyChanged("GoUrl");
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

        [Column(Storage="_IsAudit", DbType="Int NOT NULL")]
        public int IsAudit
        {
            get
            {
                return this._IsAudit;
            }
            set
            {
                if (this._IsAudit != value)
                {
                    this.SendPropertyChanging();
                    this._IsAudit = value;
                    this.SendPropertyChanged("IsAudit");
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

        [Column(Storage="_SiteNumber", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string SiteNumber
        {
            get
            {
                return this._SiteNumber;
            }
            set
            {
                if (this._SiteNumber != value)
                {
                    this.SendPropertyChanging();
                    this._SiteNumber = value;
                    this.SendPropertyChanged("SiteNumber");
                }
            }
        }

        [Column(Storage="_Title", DbType="NVarChar(100)")]
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
    }
}

