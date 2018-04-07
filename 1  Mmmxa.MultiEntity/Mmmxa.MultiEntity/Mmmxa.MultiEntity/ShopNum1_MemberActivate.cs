namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_MemberActivate")]
    public class ShopNum1_MemberActivate
    {
        private string _Email;
        private DateTime? _extireTime;
        private System.Guid? _Guid;
        private byte? _isinvalid;
        private string _key;
        private string _MemberID;
        private string _Phone;
        private string _pwd;
        private byte? _type;

        [Column(Storage="_Email", DbType="NVarChar(50)")]
        public string Email
        {
            get
            {
                return this._Email;
            }
            set
            {
                if (this._Email != value)
                {
                    this._Email = value;
                }
            }
        }

        [Column(Storage="_extireTime", DbType="DateTime")]
        public DateTime? extireTime
        {
            get
            {
                return this._extireTime;
            }
            set
            {
                if (this._extireTime != value)
                {
                    this._extireTime = value;
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

        [Column(Storage="_isinvalid", DbType="TinyInt")]
        public byte? isinvalid
        {
            get
            {
                return this._isinvalid;
            }
            set
            {
                if (this._isinvalid != value)
                {
                    this._isinvalid = value;
                }
            }
        }

        [Column(Name="[key]", Storage="_key", DbType="NVarChar(50)")]
        public string key
        {
            get
            {
                return this._key;
            }
            set
            {
                if (this._key != value)
                {
                    this._key = value;
                }
            }
        }

        [Column(Storage="_MemberID", DbType="NVarChar(50)")]
        public string MemberID
        {
            get
            {
                return this._MemberID;
            }
            set
            {
                if (this._MemberID != value)
                {
                    this._MemberID = value;
                }
            }
        }

        [Column(Storage="_Phone", DbType="NVarChar(20)")]
        public string Phone
        {
            get
            {
                return this._Phone;
            }
            set
            {
                if (this._Phone != value)
                {
                    this._Phone = value;
                }
            }
        }

        [Column(Storage="_pwd", DbType="NVarChar(50)")]
        public string pwd
        {
            get
            {
                return this._pwd;
            }
            set
            {
                if (this._pwd != value)
                {
                    this._pwd = value;
                }
            }
        }

        [Column(Storage="_type", DbType="TinyInt")]
        public byte? type
        {
            get
            {
                return this._type;
            }
            set
            {
                if (this._type != value)
                {
                    this._type = value;
                }
            }
        }
    }
}

