namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_CategoryAdID")]
    public class ShopNum1_CategoryAdID
    {
        private string _CategoryAdDefalutLike;
        private string _CategoryAdDefalutPic;
        private int? _CategoryAdflow;
        private string _CategoryAdIntroduce;
        private string _CategoryAdName;
        private string _CategoryAdPic;
        private string _CategoryType;
        private int _Height;
        private int _ID;
        private int _IsShow;
        private int? _visitPeople;
        private int _Width;

        [Column(Storage="_CategoryAdDefalutLike", DbType="NVarChar(250)")]
        public string CategoryAdDefalutLike
        {
            get
            {
                return this._CategoryAdDefalutLike;
            }
            set
            {
                if (this._CategoryAdDefalutLike != value)
                {
                    this._CategoryAdDefalutLike = value;
                }
            }
        }

        [Column(Storage="_CategoryAdDefalutPic", DbType="NVarChar(250)")]
        public string CategoryAdDefalutPic
        {
            get
            {
                return this._CategoryAdDefalutPic;
            }
            set
            {
                if (this._CategoryAdDefalutPic != value)
                {
                    this._CategoryAdDefalutPic = value;
                }
            }
        }

        [Column(Storage="_CategoryAdflow", DbType="Int")]
        public int? CategoryAdflow
        {
            get
            {
                return this._CategoryAdflow;
            }
            set
            {
                if (this._CategoryAdflow != value)
                {
                    this._CategoryAdflow = value;
                }
            }
        }

        [Column(Storage="_CategoryAdIntroduce", DbType="NVarChar(MAX)")]
        public string CategoryAdIntroduce
        {
            get
            {
                return this._CategoryAdIntroduce;
            }
            set
            {
                if (this._CategoryAdIntroduce != value)
                {
                    this._CategoryAdIntroduce = value;
                }
            }
        }

        [Column(Storage="_CategoryAdName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string CategoryAdName
        {
            get
            {
                return this._CategoryAdName;
            }
            set
            {
                if (this._CategoryAdName != value)
                {
                    this._CategoryAdName = value;
                }
            }
        }

        [Column(Storage="_CategoryAdPic", DbType="NVarChar(250)")]
        public string CategoryAdPic
        {
            get
            {
                return this._CategoryAdPic;
            }
            set
            {
                if (this._CategoryAdPic != value)
                {
                    this._CategoryAdPic = value;
                }
            }
        }

        [Column(Storage="_CategoryType", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string CategoryType
        {
            get
            {
                return this._CategoryType;
            }
            set
            {
                if (this._CategoryType != value)
                {
                    this._CategoryType = value;
                }
            }
        }

        [Column(Storage="_Height", DbType="Int NOT NULL")]
        public int Height
        {
            get
            {
                return this._Height;
            }
            set
            {
                if (this._Height != value)
                {
                    this._Height = value;
                }
            }
        }

        [Column(Storage="_ID", AutoSync=AutoSync.Always, DbType="Int NOT NULL IDENTITY", IsDbGenerated=true)]
        public int ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                if (this._ID != value)
                {
                    this._ID = value;
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

        [Column(Storage="_visitPeople", DbType="Int")]
        public int? visitPeople
        {
            get
            {
                return this._visitPeople;
            }
            set
            {
                if (this._visitPeople != value)
                {
                    this._visitPeople = value;
                }
            }
        }

        [Column(Storage="_Width", DbType="Int NOT NULL")]
        public int Width
        {
            get
            {
                return this._Width;
            }
            set
            {
                if (this._Width != value)
                {
                    this._Width = value;
                }
            }
        }
    }
}

