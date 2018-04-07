namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_Shop_ProductComment")]
    public class ShopNum1_Shop_ProductComment : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private int? _Attitude;
        private int? _BuyerAttitude;
        private int? _Character;
        private string _Comment;
        private DateTime _CommentTime;
        private int _CommentType;
        private string _ContinueComment;
        private string _ContinueReply;
        private DateTime? _ContinueReplyTime;
        private int? _ContinueState;
        private DateTime? _ContinueTime;
        private System.Guid _Guid;
        private int _IsAudit;
        private int _IsDelete;
        private int? _IsNick;
        private string _MemLoginID;
        private string _OrderGuid;
        private string _ProductGuid;
        private string _ProductName;
        private decimal? _ProductPrice;
        private string _Reply;
        private DateTime? _ReplyTime;
        private string _ShopID;
        private string _ShopLoginId;
        private string _ShopName;
        private string _SpecValue;
        private int _Speed;
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

        [Column(Storage="_Attitude", DbType="Int")]
        public int? Attitude
        {
            get
            {
                return this._Attitude;
            }
            set
            {
                if (this._Attitude != value)
                {
                    this.SendPropertyChanging();
                    this._Attitude = value;
                    this.SendPropertyChanged("Attitude");
                }
            }
        }

        [Column(Storage="_BuyerAttitude", DbType="Int")]
        public int? BuyerAttitude
        {
            get
            {
                return this._BuyerAttitude;
            }
            set
            {
                if (this._BuyerAttitude != value)
                {
                    this.SendPropertyChanging();
                    this._BuyerAttitude = value;
                    this.SendPropertyChanged("BuyerAttitude");
                }
            }
        }

        [Column(Storage="_Character", DbType="Int")]
        public int? Character
        {
            get
            {
                return this._Character;
            }
            set
            {
                if (this._Character != value)
                {
                    this.SendPropertyChanging();
                    this._Character = value;
                    this.SendPropertyChanged("Character");
                }
            }
        }

        [Column(Storage="_Comment", DbType="NVarChar(500)")]
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
                    this.SendPropertyChanging();
                    this._Comment = value;
                    this.SendPropertyChanged("Comment");
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
                    this.SendPropertyChanging();
                    this._CommentTime = value;
                    this.SendPropertyChanged("CommentTime");
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
                    this.SendPropertyChanging();
                    this._CommentType = value;
                    this.SendPropertyChanged("CommentType");
                }
            }
        }

        [Column(Storage="_ContinueComment", DbType="NVarChar(250)")]
        public string ContinueComment
        {
            get
            {
                return this._ContinueComment;
            }
            set
            {
                if (this._ContinueComment != value)
                {
                    this.SendPropertyChanging();
                    this._ContinueComment = value;
                    this.SendPropertyChanged("ContinueComment");
                }
            }
        }

        [Column(Storage="_ContinueReply", DbType="NVarChar(250)")]
        public string ContinueReply
        {
            get
            {
                return this._ContinueReply;
            }
            set
            {
                if (this._ContinueReply != value)
                {
                    this.SendPropertyChanging();
                    this._ContinueReply = value;
                    this.SendPropertyChanged("ContinueReply");
                }
            }
        }

        [Column(Storage="_ContinueReplyTime", DbType="DateTime")]
        public DateTime? ContinueReplyTime
        {
            get
            {
                return this._ContinueReplyTime;
            }
            set
            {
                if (this._ContinueReplyTime != value)
                {
                    this.SendPropertyChanging();
                    this._ContinueReplyTime = value;
                    this.SendPropertyChanged("ContinueReplyTime");
                }
            }
        }

        [Column(Storage="_ContinueState", DbType="Int")]
        public int? ContinueState
        {
            get
            {
                return this._ContinueState;
            }
            set
            {
                if (this._ContinueState != value)
                {
                    this.SendPropertyChanging();
                    this._ContinueState = value;
                    this.SendPropertyChanged("ContinueState");
                }
            }
        }

        [Column(Storage="_ContinueTime", DbType="DateTime")]
        public DateTime? ContinueTime
        {
            get
            {
                return this._ContinueTime;
            }
            set
            {
                if (this._ContinueTime != value)
                {
                    this.SendPropertyChanging();
                    this._ContinueTime = value;
                    this.SendPropertyChanged("ContinueTime");
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

        [Column(Storage="_IsDelete", DbType="Int NOT NULL")]
        public int IsDelete
        {
            get
            {
                return this._IsDelete;
            }
            set
            {
                if (this._IsDelete != value)
                {
                    this.SendPropertyChanging();
                    this._IsDelete = value;
                    this.SendPropertyChanged("IsDelete");
                }
            }
        }

        [Column(Storage="_IsNick", DbType="Int")]
        public int? IsNick
        {
            get
            {
                return this._IsNick;
            }
            set
            {
                if (this._IsNick != value)
                {
                    this.SendPropertyChanging();
                    this._IsNick = value;
                    this.SendPropertyChanged("IsNick");
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

        [Column(Storage="_OrderGuid", DbType="NVarChar(50)")]
        public string OrderGuid
        {
            get
            {
                return this._OrderGuid;
            }
            set
            {
                if (this._OrderGuid != value)
                {
                    this.SendPropertyChanging();
                    this._OrderGuid = value;
                    this.SendPropertyChanged("OrderGuid");
                }
            }
        }

        [Column(Storage="_ProductGuid", DbType="NVarChar(2000) NOT NULL", CanBeNull=false)]
        public string ProductGuid
        {
            get
            {
                return this._ProductGuid;
            }
            set
            {
                if (this._ProductGuid != value)
                {
                    this.SendPropertyChanging();
                    this._ProductGuid = value;
                    this.SendPropertyChanged("ProductGuid");
                }
            }
        }

        [Column(Storage="_ProductName", DbType="NVarChar(2000)")]
        public string ProductName
        {
            get
            {
                return this._ProductName;
            }
            set
            {
                if (this._ProductName != value)
                {
                    this.SendPropertyChanging();
                    this._ProductName = value;
                    this.SendPropertyChanged("ProductName");
                }
            }
        }

        [Column(Storage="_ProductPrice", DbType="Decimal(18,2)")]
        public decimal? ProductPrice
        {
            get
            {
                return this._ProductPrice;
            }
            set
            {
                decimal? nullable = this._ProductPrice;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this.SendPropertyChanging();
                    this._ProductPrice = value;
                    this.SendPropertyChanged("ProductPrice");
                }
            }
        }

        [Column(Storage="_Reply", DbType="NVarChar(500)")]
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
                    this.SendPropertyChanging();
                    this._Reply = value;
                    this.SendPropertyChanged("Reply");
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
                    this.SendPropertyChanging();
                    this._ShopID = value;
                    this.SendPropertyChanged("ShopID");
                }
            }
        }

        [Column(Storage="_ShopLoginId", DbType="NVarChar(50)")]
        public string ShopLoginId
        {
            get
            {
                return this._ShopLoginId;
            }
            set
            {
                if (this._ShopLoginId != value)
                {
                    this.SendPropertyChanging();
                    this._ShopLoginId = value;
                    this.SendPropertyChanged("ShopLoginId");
                }
            }
        }

        [Column(Storage="_ShopName", DbType="NVarChar(50)")]
        public string ShopName
        {
            get
            {
                return this._ShopName;
            }
            set
            {
                if (this._ShopName != value)
                {
                    this.SendPropertyChanging();
                    this._ShopName = value;
                    this.SendPropertyChanged("ShopName");
                }
            }
        }

        [Column(Storage="_SpecValue", DbType="NVarChar(100)")]
        public string SpecValue
        {
            get
            {
                return this._SpecValue;
            }
            set
            {
                if (this._SpecValue != value)
                {
                    this.SendPropertyChanging();
                    this._SpecValue = value;
                    this.SendPropertyChanged("SpecValue");
                }
            }
        }

        [Column(Storage="_Speed", DbType="Int NOT NULL")]
        public int Speed
        {
            get
            {
                return this._Speed;
            }
            set
            {
                if (this._Speed != value)
                {
                    this.SendPropertyChanging();
                    this._Speed = value;
                    this.SendPropertyChanged("Speed");
                }
            }
        }
    }
}

