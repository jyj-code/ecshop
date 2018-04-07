namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_Shop_VideoComment")]
    public class ShopNum1_Shop_VideoComment
    {
        private string _Comment;
        private DateTime _CommentTime;
        private int _CommentType;
        private System.Guid _Guid;
        private string _IPAddress;
        private int? _IsAudit;
        private int? _IsDelete;
        private int? _IsReply;
        private string _MemLoginID;
        private string _Reply;
        private DateTime? _ReplyTime;
        private string _ShopID;
        private string _Title;
        private string _VideoGuid;

        [Column(Storage="_Comment", DbType="NVarChar(250) NOT NULL", CanBeNull=false)]
        public string Comment
        {
            get
            {
                return this._Comment;
            }
            set
            {
                if (this._Comment != value)
                {
                    this._Comment = value;
                }
            }
        }

        [Column(Storage="_CommentTime", DbType="DateTime NOT NULL")]
        public DateTime CommentTime
        {
            get
            {
                return this._CommentTime;
            }
            set
            {
                if (this._CommentTime != value)
                {
                    this._CommentTime = value;
                }
            }
        }

        [Column(Storage="_CommentType", DbType="Int NOT NULL")]
        public int CommentType
        {
            get
            {
                return this._CommentType;
            }
            set
            {
                if (this._CommentType != value)
                {
                    this._CommentType = value;
                }
            }
        }

        [Column(Storage="_Guid", DbType="UniqueIdentifier NOT NULL")]
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
                    this._Guid = value;
                }
            }
        }

        [Column(Storage="_IPAddress", DbType="NVarChar(20)")]
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
                    this._IPAddress = value;
                }
            }
        }

        [Column(Storage="_IsAudit", DbType="Int")]
        public int? IsAudit
        {
            get
            {
                return this._IsAudit;
            }
            set
            {
                if (this._IsAudit != value)
                {
                    this._IsAudit = value;
                }
            }
        }

        [Column(Storage="_IsDelete", DbType="Int")]
        public int? IsDelete
        {
            get
            {
                return this._IsDelete;
            }
            set
            {
                if (this._IsDelete != value)
                {
                    this._IsDelete = value;
                }
            }
        }

        [Column(Storage="_IsReply", DbType="Int")]
        public int? IsReply
        {
            get
            {
                return this._IsReply;
            }
            set
            {
                if (this._IsReply != value)
                {
                    this._IsReply = value;
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
                    this._MemLoginID = value;
                }
            }
        }

        [Column(Storage="_Reply", DbType="NVarChar(250)")]
        public string Reply
        {
            get
            {
                return this._Reply;
            }
            set
            {
                if (this._Reply != value)
                {
                    this._Reply = value;
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
                    this._ReplyTime = value;
                }
            }
        }

        [Column(Storage="_ShopID", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string ShopID
        {
            get
            {
                return this._ShopID;
            }
            set
            {
                if (this._ShopID != value)
                {
                    this._ShopID = value;
                }
            }
        }

        [Column(Storage="_Title", DbType="NVarChar(50)")]
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
                    this._Title = value;
                }
            }
        }

        [Column(Storage="_VideoGuid", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string VideoGuid
        {
            get
            {
                return this._VideoGuid;
            }
            set
            {
                if (this._VideoGuid != value)
                {
                    this._VideoGuid = value;
                }
            }
        }
    }
}

