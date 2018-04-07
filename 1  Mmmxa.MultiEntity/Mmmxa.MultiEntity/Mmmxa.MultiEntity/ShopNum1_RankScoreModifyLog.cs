namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_RankScoreModifyLog")]
    public class ShopNum1_RankScoreModifyLog : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private DateTime? _CreateTime;
        private string _CreateUser;
        private int _CurrentScore;
        private DateTime _Date;
        private System.Guid _Guid;
        private int _IsDeleted;
        private int _LastOperateScore;
        private string _MemLoginID;
        private string _Memo;
        private int _OperateScore;
        private int _OperateType;
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

        [Column(Storage="_CreateUser", DbType="NVarChar(50)")]
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
                    this.SendPropertyChanging();
                    this._CreateUser = value;
                    this.SendPropertyChanged("CreateUser");
                }
            }
        }

        [Column(Storage="_CurrentScore", DbType="Int NOT NULL")]
        public int CurrentScore
        {
            get
            {
                return this._CurrentScore;
            }
            set
            {
                if (this._CurrentScore != value)
                {
                    this.SendPropertyChanging();
                    this._CurrentScore = value;
                    this.SendPropertyChanged("CurrentScore");
                }
            }
        }

        [Column(Storage="_Date", DbType="DateTime NOT NULL")]
        public DateTime Date
        {
            get
            {
                return this._Date;
            }
            set
            {
                if (this._Date != value)
                {
                    this.SendPropertyChanging();
                    this._Date = value;
                    this.SendPropertyChanged("Date");
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
                    this.SendPropertyChanging();
                    this._IsDeleted = value;
                    this.SendPropertyChanged("IsDeleted");
                }
            }
        }

        [Column(Storage="_LastOperateScore", DbType="Int NOT NULL")]
        public int LastOperateScore
        {
            get
            {
                return this._LastOperateScore;
            }
            set
            {
                if (this._LastOperateScore != value)
                {
                    this.SendPropertyChanging();
                    this._LastOperateScore = value;
                    this.SendPropertyChanged("LastOperateScore");
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

        [Column(Storage="_Memo", DbType="NVarChar(250)")]
        public string Memo
        {
            get
            {
                return this._Memo;
            }
            set
            {
                if (this._Memo != value)
                {
                    this.SendPropertyChanging();
                    this._Memo = value;
                    this.SendPropertyChanged("Memo");
                }
            }
        }

        [Column(Storage="_OperateScore", DbType="Int NOT NULL")]
        public int OperateScore
        {
            get
            {
                return this._OperateScore;
            }
            set
            {
                if (this._OperateScore != value)
                {
                    this.SendPropertyChanging();
                    this._OperateScore = value;
                    this.SendPropertyChanged("OperateScore");
                }
            }
        }

        [Column(Storage="_OperateType", DbType="Int NOT NULL")]
        public int OperateType
        {
            get
            {
                return this._OperateType;
            }
            set
            {
                if (this._OperateType != value)
                {
                    this.SendPropertyChanging();
                    this._OperateType = value;
                    this.SendPropertyChanged("OperateType");
                }
            }
        }
    }
}

