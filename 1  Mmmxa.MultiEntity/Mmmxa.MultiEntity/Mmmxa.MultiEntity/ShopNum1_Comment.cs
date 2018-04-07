namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_Comment")]
    public class ShopNum1_Comment
    {
        private int _Bad;
        private string _Comment;
        private DateTime _CommentTime;
        private int _CommentType;
        private int _Good;
        private System.Guid _Guid;
        private int _IsDeleted;
        private string _MemberOne;
        private string _MemberTwo;
        private int _Middle;
        private string _OrderId;

        [Column(Storage="_Bad", DbType="Int NOT NULL")]
        public int Bad
        {
            get
            {
                return this._Bad;
            }
            set
            {
                if (this._Bad != value)
                {
                    this._Bad = value;
                }
            }
        }

        [Column(Storage="_Comment", DbType="NVarChar(250)")]
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

        [Column(Storage="_Good", DbType="Int NOT NULL")]
        public int Good
        {
            get
            {
                return this._Good;
            }
            set
            {
                if (this._Good != value)
                {
                    this._Good = value;
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
                    this._IsDeleted = value;
                }
            }
        }

        [Column(Storage="_MemberOne", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string MemberOne
        {
            get
            {
                return this._MemberOne;
            }
            set
            {
                if (this._MemberOne != value)
                {
                    this._MemberOne = value;
                }
            }
        }

        [Column(Storage="_MemberTwo", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string MemberTwo
        {
            get
            {
                return this._MemberTwo;
            }
            set
            {
                if (this._MemberTwo != value)
                {
                    this._MemberTwo = value;
                }
            }
        }

        [Column(Storage="_Middle", DbType="Int NOT NULL")]
        public int Middle
        {
            get
            {
                return this._Middle;
            }
            set
            {
                if (this._Middle != value)
                {
                    this._Middle = value;
                }
            }
        }

        [Column(Storage="_OrderId", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string OrderId
        {
            get
            {
                return this._OrderId;
            }
            set
            {
                if (this._OrderId != value)
                {
                    this._OrderId = value;
                }
            }
        }
    }
}

