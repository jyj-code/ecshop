namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_Group_Product")]
    public class ShopNum1_Group_Product : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private int? _Aid;
        private string _Aname;
        private DateTime? _CreateTime;
        private int? _GropuArea;
        private int? _GroupCount;
        private string _GroupImg;
        private decimal? _GroupPrice;
        private string _GroupSmallImg;
        private int? _GroupStock;
        private int? _GroupType;
        private int _Id;
        private string _Introduce;
        private int? _IsRecommond;
        private int? _LimitNum;
        private string _MemLoginId;
        private string _Name;
        private Guid? _ProductGuId;
        private string _ShopName;
        private int? _State;
        private string _SubstationID;
        private int? _VirtualNum;
        private int? _VisitCount;
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

        [Column(Storage="_Aid", DbType="Int")]
        public int? Aid
        {
            get
            {
                return this._Aid;
            }
            set
            {
                if (this._Aid != value)
                {
                    this.SendPropertyChanging();
                    this._Aid = value;
                    this.SendPropertyChanged("Aid");
                }
            }
        }

        [Column(Storage="_Aname", DbType="VarChar(100)")]
        public string Aname
        {
            get
            {
                return this._Aname;
            }
            set
            {
                if (this._Aname != value)
                {
                    this.SendPropertyChanging();
                    this._Aname = value;
                    this.SendPropertyChanged("Aname");
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
                    this.SendPropertyChanging();
                    this._CreateTime = value;
                    this.SendPropertyChanged("CreateTime");
                }
            }
        }

        [Column(Storage="_GropuArea", DbType="Int")]
        public int? GropuArea
        {
            get
            {
                return this._GropuArea;
            }
            set
            {
                if (this._GropuArea != value)
                {
                    this.SendPropertyChanging();
                    this._GropuArea = value;
                    this.SendPropertyChanged("GropuArea");
                }
            }
        }

        [Column(Storage="_GroupCount", DbType="Int")]
        public int? GroupCount
        {
            get
            {
                return this._GroupCount;
            }
            set
            {
                if (this._GroupCount != value)
                {
                    this.SendPropertyChanging();
                    this._GroupCount = value;
                    this.SendPropertyChanged("GroupCount");
                }
            }
        }

        [Column(Storage="_GroupImg", DbType="VarChar(80)")]
        public string GroupImg
        {
            get
            {
                return this._GroupImg;
            }
            set
            {
                if (this._GroupImg != value)
                {
                    this.SendPropertyChanging();
                    this._GroupImg = value;
                    this.SendPropertyChanged("GroupImg");
                }
            }
        }

        [Column(Storage="_GroupPrice", DbType="Decimal(18,2)")]
        public decimal? GroupPrice
        {
            get
            {
                return this._GroupPrice;
            }
            set
            {
                decimal? nullable = this._GroupPrice;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) || (nullable.HasValue != nullable2.HasValue))
                {
                    this.SendPropertyChanging();
                    this._GroupPrice = value;
                    this.SendPropertyChanged("GroupPrice");
                }
            }
        }

        [Column(Storage="_GroupSmallImg", DbType="VarChar(80)")]
        public string GroupSmallImg
        {
            get
            {
                return this._GroupSmallImg;
            }
            set
            {
                if (this._GroupSmallImg != value)
                {
                    this.SendPropertyChanging();
                    this._GroupSmallImg = value;
                    this.SendPropertyChanged("GroupSmallImg");
                }
            }
        }

        [Column(Storage="_GroupStock", DbType="Int")]
        public int? GroupStock
        {
            get
            {
                return this._GroupStock;
            }
            set
            {
                if (this._GroupStock != value)
                {
                    this.SendPropertyChanging();
                    this._GroupStock = value;
                    this.SendPropertyChanged("GroupStock");
                }
            }
        }

        [Column(Storage="_GroupType", DbType="Int")]
        public int? GroupType
        {
            get
            {
                return this._GroupType;
            }
            set
            {
                if (this._GroupType != value)
                {
                    this.SendPropertyChanging();
                    this._GroupType = value;
                    this.SendPropertyChanged("GroupType");
                }
            }
        }

        [Column(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
        public int Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                if (this._Id != value)
                {
                    this.SendPropertyChanging();
                    this._Id = value;
                    this.SendPropertyChanged("Id");
                }
            }
        }

        [Column(Storage="_Introduce", DbType="NText", UpdateCheck=UpdateCheck.Never)]
        public string Introduce
        {
            get
            {
                return this._Introduce;
            }
            set
            {
                if (this._Introduce != value)
                {
                    this.SendPropertyChanging();
                    this._Introduce = value;
                    this.SendPropertyChanged("Introduce");
                }
            }
        }

        [Column(Storage="_IsRecommond", DbType="Int")]
        public int? IsRecommond
        {
            get
            {
                return this._IsRecommond;
            }
            set
            {
                if (this._IsRecommond != value)
                {
                    this.SendPropertyChanging();
                    this._IsRecommond = value;
                    this.SendPropertyChanged("IsRecommond");
                }
            }
        }

        [Column(Storage="_LimitNum", DbType="Int")]
        public int? LimitNum
        {
            get
            {
                return this._LimitNum;
            }
            set
            {
                if (this._LimitNum != value)
                {
                    this.SendPropertyChanging();
                    this._LimitNum = value;
                    this.SendPropertyChanged("LimitNum");
                }
            }
        }

        [Column(Storage="_MemLoginId", DbType="VarChar(50)")]
        public string MemLoginId
        {
            get
            {
                return this._MemLoginId;
            }
            set
            {
                if (this._MemLoginId != value)
                {
                    this.SendPropertyChanging();
                    this._MemLoginId = value;
                    this.SendPropertyChanged("MemLoginId");
                }
            }
        }

        [Column(Storage="_Name", DbType="VarChar(100)")]
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                if (this._Name != value)
                {
                    this.SendPropertyChanging();
                    this._Name = value;
                    this.SendPropertyChanged("Name");
                }
            }
        }

        [Column(Storage="_ProductGuId", DbType="UniqueIdentifier")]
        public Guid? ProductGuId
        {
            get
            {
                return this._ProductGuId;
            }
            set
            {
                if (this._ProductGuId != value)
                {
                    this.SendPropertyChanging();
                    this._ProductGuId = value;
                    this.SendPropertyChanged("ProductGuId");
                }
            }
        }

        [Column(Storage="_ShopName", DbType="VarChar(100)")]
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

        [Column(Storage="_State", DbType="Int")]
        public int? State
        {
            get
            {
                return this._State;
            }
            set
            {
                if (this._State != value)
                {
                    this.SendPropertyChanging();
                    this._State = value;
                    this.SendPropertyChanged("State");
                }
            }
        }

        [Column(Storage="_SubstationID", DbType="NVarChar(100)")]
        public string SubstationID
        {
            get
            {
                return this._SubstationID;
            }
            set
            {
                if (this._SubstationID != value)
                {
                    this.SendPropertyChanging();
                    this._SubstationID = value;
                    this.SendPropertyChanged("SubstationID");
                }
            }
        }

        [Column(Storage="_VirtualNum", DbType="Int")]
        public int? VirtualNum
        {
            get
            {
                return this._VirtualNum;
            }
            set
            {
                if (this._VirtualNum != value)
                {
                    this.SendPropertyChanging();
                    this._VirtualNum = value;
                    this.SendPropertyChanged("VirtualNum");
                }
            }
        }

        [Column(Storage="_VisitCount", DbType="Int")]
        public int? VisitCount
        {
            get
            {
                return this._VisitCount;
            }
            set
            {
                if (this._VisitCount != value)
                {
                    this.SendPropertyChanging();
                    this._VisitCount = value;
                    this.SendPropertyChanged("VisitCount");
                }
            }
        }
    }
}

