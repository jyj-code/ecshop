namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_SurveyTheme")]
    public class ShopNum1_SurveyTheme : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private int _Count;
        private DateTime? _EndTime;
        private System.Guid _Guid;
        private int _SimplyOrMultiCheck;
        private DateTime? _StartTime;
        private string _Static;
        private string _Title;
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

        [Column(Storage="_Count", DbType="Int NOT NULL")]
        public int Count
        {
            get
            {
                return this._Count;
            }
            set
            {
                if (this._Count != value)
                {
                    this.SendPropertyChanging();
                    this._Count = value;
                    this.SendPropertyChanged("Count");
                }
            }
        }

        [Column(Storage="_EndTime", DbType="DateTime")]
        public DateTime? EndTime
        {
            get
            {
                return this._EndTime;
            }
            set
            {
                if (this._EndTime != value)
                {
                    this.SendPropertyChanging();
                    this._EndTime = value;
                    this.SendPropertyChanged("EndTime");
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

        [Column(Storage="_SimplyOrMultiCheck", DbType="Int NOT NULL")]
        public int SimplyOrMultiCheck
        {
            get
            {
                return this._SimplyOrMultiCheck;
            }
            set
            {
                if (this._SimplyOrMultiCheck != value)
                {
                    this.SendPropertyChanging();
                    this._SimplyOrMultiCheck = value;
                    this.SendPropertyChanged("SimplyOrMultiCheck");
                }
            }
        }

        [Column(Storage="_StartTime", DbType="DateTime")]
        public DateTime? StartTime
        {
            get
            {
                return this._StartTime;
            }
            set
            {
                if (this._StartTime != value)
                {
                    this.SendPropertyChanging();
                    this._StartTime = value;
                    this.SendPropertyChanged("StartTime");
                }
            }
        }

        [Column(Storage="_Static", DbType="NVarChar(250)")]
        public string Static
        {
            get
            {
                return this._Static;
            }
            set
            {
                if (this._Static != value)
                {
                    this.SendPropertyChanging();
                    this._Static = value;
                    this.SendPropertyChanged("Static");
                }
            }
        }

        [Column(Storage="_Title", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
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
                    this.SendPropertyChanging();
                    this._Title = value;
                    this.SendPropertyChanged("Title");
                }
            }
        }
    }
}

