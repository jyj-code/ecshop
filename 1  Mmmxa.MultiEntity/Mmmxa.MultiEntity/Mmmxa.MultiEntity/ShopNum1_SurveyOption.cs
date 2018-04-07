namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_SurveyOption")]
    public class ShopNum1_SurveyOption : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private int _Count;
        private System.Guid _Guid;
        private string _Name;
        private int? _Order;
        private string _SurveyGuid;
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

        [Column(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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

        [Column(Name="[Order]", Storage="_Order", DbType="Int")]
        public int? Order
        {
            get
            {
                return this._Order;
            }
            set
            {
                if (this._Order != value)
                {
                    this.SendPropertyChanging();
                    this._Order = value;
                    this.SendPropertyChanged("Order");
                }
            }
        }

        [Column(Storage="_SurveyGuid", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string SurveyGuid
        {
            get
            {
                return this._SurveyGuid;
            }
            set
            {
                if (this._SurveyGuid != value)
                {
                    this.SendPropertyChanging();
                    this._SurveyGuid = value;
                    this.SendPropertyChanged("SurveyGuid");
                }
            }
        }
    }
}

