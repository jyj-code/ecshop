namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_ShopProRelateProp")]
    public class ShopNum1_ShopProRelateProp
    {
        private int? _CTypeID;
        private string _InputValue;
        private int? _PCategoryID;
        private Guid _ProductGuid;
        private int? _PropID;
        private int? _PropValueID;
        private int? _ShowType;

        [Column(Storage="_CTypeID", DbType="Int")]
        public int? CTypeID
        {
            get
            {
                return this._CTypeID;
            }
            set
            {
                if (this._CTypeID != value)
                {
                    this._CTypeID = value;
                }
            }
        }

        [Column(Storage="_InputValue", DbType="VarChar(200)")]
        public string InputValue
        {
            get
            {
                return this._InputValue;
            }
            set
            {
                if (this._InputValue != value)
                {
                    this._InputValue = value;
                }
            }
        }

        [Column(Storage="_PCategoryID", DbType="Int")]
        public int? PCategoryID
        {
            get
            {
                return this._PCategoryID;
            }
            set
            {
                if (this._PCategoryID != value)
                {
                    this._PCategoryID = value;
                }
            }
        }

        [Column(Storage="_ProductGuid", DbType="UniqueIdentifier NOT NULL")]
        public Guid ProductGuid
        {
            get
            {
                return this._ProductGuid;
            }
            set
            {
                if (this._ProductGuid != value)
                {
                    this._ProductGuid = value;
                }
            }
        }

        [Column(Storage="_PropID", DbType="Int")]
        public int? PropID
        {
            get
            {
                return this._PropID;
            }
            set
            {
                if (this._PropID != value)
                {
                    this._PropID = value;
                }
            }
        }

        [Column(Storage="_PropValueID", DbType="Int")]
        public int? PropValueID
        {
            get
            {
                return this._PropValueID;
            }
            set
            {
                if (this._PropValueID != value)
                {
                    this._PropValueID = value;
                }
            }
        }

        [Column(Storage="_ShowType", DbType="Int")]
        public int? ShowType
        {
            get
            {
                return this._ShowType;
            }
            set
            {
                if (this._ShowType != value)
                {
                    this._ShowType = value;
                }
            }
        }
    }
}

