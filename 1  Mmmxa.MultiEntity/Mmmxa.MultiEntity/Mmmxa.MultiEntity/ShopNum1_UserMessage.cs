namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_UserMessage")]
    public class ShopNum1_UserMessage : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private System.Guid _Guid;
        private int _IsDeleted;
        private int _IsRead;
        private System.Guid _MessageInfoGuid;
        private string _ReceiveID;
        private int _ReceiveIsDeleted;
        private string _ReplyContent;
        private DateTime? _ReplyTime;
        private string _SendID;
        private int _SendIsDeleted;
        private DateTime _SendTime;
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

        [Column(Storage="_IsRead", DbType="Int NOT NULL")]
        public int IsRead
        {
            get
            {
                return this._IsRead;
            }
            set
            {
                if (this._IsRead != value)
                {
                    this.SendPropertyChanging();
                    this._IsRead = value;
                    this.SendPropertyChanged("IsRead");
                }
            }
        }

        [Column(Storage="_MessageInfoGuid", DbType="UniqueIdentifier NOT NULL")]
        public System.Guid MessageInfoGuid
        {
            get
            {
                return this._MessageInfoGuid;
            }
            set
            {
                if (this._MessageInfoGuid != value)
                {
                    this.SendPropertyChanging();
                    this._MessageInfoGuid = value;
                    this.SendPropertyChanged("MessageInfoGuid");
                }
            }
        }

        [Column(Storage="_ReceiveID", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string ReceiveID
        {
            get
            {
                return this._ReceiveID;
            }
            set
            {
                if (this._ReceiveID != value)
                {
                    this.SendPropertyChanging();
                    this._ReceiveID = value;
                    this.SendPropertyChanged("ReceiveID");
                }
            }
        }

        [Column(Storage="_ReceiveIsDeleted", DbType="Int NOT NULL")]
        public int ReceiveIsDeleted
        {
            get
            {
                return this._ReceiveIsDeleted;
            }
            set
            {
                if (this._ReceiveIsDeleted != value)
                {
                    this.SendPropertyChanging();
                    this._ReceiveIsDeleted = value;
                    this.SendPropertyChanged("ReceiveIsDeleted");
                }
            }
        }

        [Column(Storage="_ReplyContent", DbType="NText", UpdateCheck=UpdateCheck.Never)]
        public string ReplyContent
        {
            get
            {
                return this._ReplyContent;
            }
            set
            {
                if (this._ReplyContent != value)
                {
                    this.SendPropertyChanging();
                    this._ReplyContent = value;
                    this.SendPropertyChanged("ReplyContent");
                }
            }
        }

        [Column(Storage="_ReplyTime", DbType="DateTime")]
        public DateTime? ReplyTime
        {
            get
            {
                return this._ReplyTime;
            }
            set
            {
                if (this._ReplyTime != value)
                {
                    this.SendPropertyChanging();
                    this._ReplyTime = value;
                    this.SendPropertyChanged("ReplyTime");
                }
            }
        }

        [Column(Storage="_SendID", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string SendID
        {
            get
            {
                return this._SendID;
            }
            set
            {
                if (this._SendID != value)
                {
                    this.SendPropertyChanging();
                    this._SendID = value;
                    this.SendPropertyChanged("SendID");
                }
            }
        }

        [Column(Storage="_SendIsDeleted", DbType="Int NOT NULL")]
        public int SendIsDeleted
        {
            get
            {
                return this._SendIsDeleted;
            }
            set
            {
                if (this._SendIsDeleted != value)
                {
                    this.SendPropertyChanging();
                    this._SendIsDeleted = value;
                    this.SendPropertyChanged("SendIsDeleted");
                }
            }
        }

        [Column(Storage="_SendTime", DbType="DateTime NOT NULL")]
        public DateTime SendTime
        {
            get
            {
                return this._SendTime;
            }
            set
            {
                if (this._SendTime != value)
                {
                    this.SendPropertyChanging();
                    this._SendTime = value;
                    this.SendPropertyChanged("SendTime");
                }
            }
        }
    }
}

