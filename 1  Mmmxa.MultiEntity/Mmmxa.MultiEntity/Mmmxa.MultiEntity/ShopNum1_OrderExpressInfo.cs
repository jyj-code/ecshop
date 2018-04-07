namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_OrderExpressInfo")]
    public class ShopNum1_OrderExpressInfo : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private System.Guid _Guid;
        private string _hidden;
        private string _imgPath;
        private int _IsDefault;
        private string _LogisticsID;
        private string _name;
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

        [Column(Storage="_hidden", DbType="Text", UpdateCheck=UpdateCheck.Never)]
        public string hidden
        {
            get
            {
                return this._hidden;
            }
            set
            {
                if (this._hidden != value)
                {
                    this.SendPropertyChanging();
                    this._hidden = value;
                    this.SendPropertyChanged("hidden");
                }
            }
        }

        [Column(Storage="_imgPath", DbType="NVarChar(80)")]
        public string imgPath
        {
            get
            {
                return this._imgPath;
            }
            set
            {
                if (this._imgPath != value)
                {
                    this.SendPropertyChanging();
                    this._imgPath = value;
                    this.SendPropertyChanged("imgPath");
                }
            }
        }

        [Column(Storage="_IsDefault", DbType="Int NOT NULL")]
        public int IsDefault
        {
            get
            {
                return this._IsDefault;
            }
            set
            {
                if (this._IsDefault != value)
                {
                    this.SendPropertyChanging();
                    this._IsDefault = value;
                    this.SendPropertyChanged("IsDefault");
                }
            }
        }

        [Column(Storage="_LogisticsID", DbType="VarChar(25)")]
        public string LogisticsID
        {
            get
            {
                return this._LogisticsID;
            }
            set
            {
                if (this._LogisticsID != value)
                {
                    this.SendPropertyChanging();
                    this._LogisticsID = value;
                    this.SendPropertyChanged("LogisticsID");
                }
            }
        }

        [Column(Storage="_name", DbType="NVarChar(50)")]
        public string name
        {
            get
            {
                return this._name;
            }
            set
            {
                if (this._name != value)
                {
                    this.SendPropertyChanging();
                    this._name = value;
                    this.SendPropertyChanged("name");
                }
            }
        }
    }
}

