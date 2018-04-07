namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_CategoryComment")]
    public class ShopNum1_CategoryComment : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private string _AssociatedMemberID;
        private System.Guid _CategoryInfoGuid;
        private string _Content;
        private string _CreateIP;
        private string _CreateMember;
        private DateTime _CreateTime;
        private System.Guid _Guid;
        private int _IsAudit;
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

        [Column(Storage="_AssociatedMemberID", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string AssociatedMemberID
        {
            get
            {
                return this._AssociatedMemberID;
            }
            set
            {
                if (this._AssociatedMemberID != value)
                {
                    this.SendPropertyChanging();
                    this._AssociatedMemberID = value;
                    this.SendPropertyChanged("AssociatedMemberID");
                }
            }
        }

        [Column(Storage="_CategoryInfoGuid", DbType="UniqueIdentifier NOT NULL")]
        public System.Guid CategoryInfoGuid
        {
            get
            {
                return this._CategoryInfoGuid;
            }
            set
            {
                if (this._CategoryInfoGuid != value)
                {
                    this.SendPropertyChanging();
                    this._CategoryInfoGuid = value;
                    this.SendPropertyChanged("CategoryInfoGuid");
                }
            }
        }

        [Column(Storage="_Content", DbType="NText NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
        public string Content
        {
            get
            {
                return this._Content;
            }
            set
            {
                if (this._Content != value)
                {
                    this.SendPropertyChanging();
                    this._Content = value;
                    this.SendPropertyChanged("Content");
                }
            }
        }

        [Column(Storage="_CreateIP", DbType="Char(20) NOT NULL", CanBeNull=false)]
        public string CreateIP
        {
            get
            {
                return this._CreateIP;
            }
            set
            {
                if (this._CreateIP != value)
                {
                    this.SendPropertyChanging();
                    this._CreateIP = value;
                    this.SendPropertyChanged("CreateIP");
                }
            }
        }

        [Column(Storage="_CreateMember", DbType="NVarChar(25) NOT NULL", CanBeNull=false)]
        public string CreateMember
        {
            get
            {
                return this._CreateMember;
            }
            set
            {
                if (this._CreateMember != value)
                {
                    this.SendPropertyChanging();
                    this._CreateMember = value;
                    this.SendPropertyChanged("CreateMember");
                }
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
    }
}

