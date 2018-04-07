namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_GroupPage")]
    public class ShopNum1_GroupPage
    {
        private DateTime _CreateTime;
        private string _CreateUser;
        private Guid _GroupGuid;
        private int _IsDeleted;
        private DateTime _ModifyTime;
        private string _ModifyUser;
        private string _PageGuid;

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
                    this._CreateTime = value;
                }
            }
        }

        [Column(Storage="_CreateUser", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string CreateUser
        {
            get
            {
                return this._CreateUser;
            }
            set
            {
                if (this._CreateUser != value)
                {
                    this._CreateUser = value;
                }
            }
        }

        [Column(Storage="_GroupGuid", DbType="UniqueIdentifier NOT NULL")]
        public Guid GroupGuid
        {
            get
            {
                return this._GroupGuid;
            }
            set
            {
                if (this._GroupGuid != value)
                {
                    this._GroupGuid = value;
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

        [Column(Storage="_ModifyTime", DbType="DateTime NOT NULL")]
        public DateTime ModifyTime
        {
            get
            {
                return this._ModifyTime;
            }
            set
            {
                if (this._ModifyTime != value)
                {
                    this._ModifyTime = value;
                }
            }
        }

        [Column(Storage="_ModifyUser", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string ModifyUser
        {
            get
            {
                return this._ModifyUser;
            }
            set
            {
                if (this._ModifyUser != value)
                {
                    this._ModifyUser = value;
                }
            }
        }

        [Column(Storage="_PageGuid", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string PageGuid
        {
            get
            {
                return this._PageGuid;
            }
            set
            {
                if (this._PageGuid != value)
                {
                    this._PageGuid = value;
                }
            }
        }
    }
}

