﻿namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_ArticleComment")]
    public class ShopNum1_ArticleComment : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private System.Guid _ArticleGuid;
        private string _Content;
        private System.Guid _Guid;
        private string _IPAddress;
        private int _IsAudit;
        private int _IsDeleted;
        private int _IsReply;
        private string _MemLoginID;
        private int _Rank;
        private string _ReplyContent;
        private DateTime? _ReplyTime;
        private string _ReplyUser;
        private DateTime _SendTime;
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

        [Column(Storage="_ArticleGuid", DbType="UniqueIdentifier NOT NULL")]
        public System.Guid ArticleGuid
        {
            get
            {
                return this._ArticleGuid;
            }
            set
            {
                if (this._ArticleGuid != value)
                {
                    this.SendPropertyChanging();
                    this._ArticleGuid = value;
                    this.SendPropertyChanged("ArticleGuid");
                }
            }
        }

        [Column(Storage="_Content", DbType="NText", UpdateCheck=UpdateCheck.Never)]
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

        [Column(Storage="_IPAddress", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
        public string IPAddress
        {
            get
            {
                return this._IPAddress;
            }
            set
            {
                if (this._IPAddress != value)
                {
                    this.SendPropertyChanging();
                    this._IPAddress = value;
                    this.SendPropertyChanged("IPAddress");
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

        [Column(Storage="_IsReply", DbType="Int NOT NULL")]
        public int IsReply
        {
            get
            {
                return this._IsReply;
            }
            set
            {
                if (this._IsReply != value)
                {
                    this.SendPropertyChanging();
                    this._IsReply = value;
                    this.SendPropertyChanged("IsReply");
                }
            }
        }

        [Column(Storage="_MemLoginID", DbType="NVarChar(50)")]
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

        [Column(Storage="_Rank", DbType="Int NOT NULL")]
        public int Rank
        {
            get
            {
                return this._Rank;
            }
            set
            {
                if (this._Rank != value)
                {
                    this.SendPropertyChanging();
                    this._Rank = value;
                    this.SendPropertyChanged("Rank");
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

        [Column(Storage="_ReplyUser", DbType="NVarChar(50)")]
        public string ReplyUser
        {
            get
            {
                return this._ReplyUser;
            }
            set
            {
                if (this._ReplyUser != value)
                {
                    this.SendPropertyChanging();
                    this._ReplyUser = value;
                    this.SendPropertyChanged("ReplyUser");
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

        [Column(Storage="_Title", DbType="NVarChar(200)")]
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

