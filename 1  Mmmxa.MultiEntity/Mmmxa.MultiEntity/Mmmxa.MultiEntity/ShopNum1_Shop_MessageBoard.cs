namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_Shop_MessageBoard")]
    public class ShopNum1_Shop_MessageBoard
    {
        private string _Content;
        private System.Guid _Guid;
        private int _IsReply;
        private int _IsShow;
        private string _ManageID;
        private string _ManageReply;
        private DateTime? _ManageTime;
        private string _MemLoginID;
        private int _MessageType;
        private string _ReplyContent;
        private DateTime? _ReplyTime;
        private string _ReplyUser;
        private DateTime _SendTime;
        private string _Title;

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
                    this._Content = value;
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
                    this._IsReply = value;
                }
            }
        }

        [Column(Storage="_IsShow", DbType="Int NOT NULL")]
        public int IsShow
        {
            get
            {
                return this._IsShow;
            }
            set
            {
                if (this._IsShow != value)
                {
                    this._IsShow = value;
                }
            }
        }

        [Column(Storage="_ManageID", DbType="NVarChar(50)")]
        public string ManageID
        {
            get
            {
                return this._ManageID;
            }
            set
            {
                if (this._ManageID != value)
                {
                    this._ManageID = value;
                }
            }
        }

        [Column(Storage="_ManageReply", DbType="NText", UpdateCheck=UpdateCheck.Never)]
        public string ManageReply
        {
            get
            {
                return this._ManageReply;
            }
            set
            {
                if (this._ManageReply != value)
                {
                    this._ManageReply = value;
                }
            }
        }

        [Column(Storage="_ManageTime", DbType="DateTime")]
        public DateTime? ManageTime
        {
            get
            {
                return this._ManageTime;
            }
            set
            {
                if (this._ManageTime != value)
                {
                    this._ManageTime = value;
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
                    this._MemLoginID = value;
                }
            }
        }

        [Column(Storage="_MessageType", DbType="Int NOT NULL")]
        public int MessageType
        {
            get
            {
                return this._MessageType;
            }
            set
            {
                if (this._MessageType != value)
                {
                    this._MessageType = value;
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
                    this._ReplyContent = value;
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
                    this._ReplyUser = value;
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
                    this._SendTime = value;
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
                    this._Title = value;
                }
            }
        }
    }
}

