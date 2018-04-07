namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.Agent__VideoComment")]
    public class Agent__VideoComment
    {
        private string _Content;
        private DateTime? _CreateTime;
        private System.Guid? _Guid;
        private string _MemLoginID;
        private string _VideoGuid;

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
                    this._Content = value;
                }
            }
        }

        [Column(Storage="_CreateTime", DbType="DateTime")]
        public DateTime? CreateTime
        {
            get
            {
                return this._CreateTime;
            }
            set
            {
                if (this._CreateTime != value)
                {
                    this._CreateTime = value;
                }
            }
        }

        [Column(Storage="_Guid", DbType="UniqueIdentifier")]
        public System.Guid? Guid
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

        [Column(Storage="_VideoGuid", DbType="NVarChar(50)")]
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

