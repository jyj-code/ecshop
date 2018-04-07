namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1__PackAgeRalate")]
    public class ShopNum1_PackAgeRalate : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private int _Id;
        private int? _PackAgeId;
        private Guid? _ProductGuid;
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

        [Column(Storage="_Id", DbType="Int NOT NULL", IsPrimaryKey=true)]
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

        [Column(Storage="_PackAgeId", DbType="Int")]
        public int? PackAgeId
        {
            get
            {
                return this._PackAgeId;
            }
            set
            {
                if (this._PackAgeId != value)
                {
                    this.SendPropertyChanging();
                    this._PackAgeId = value;
                    this.SendPropertyChanged("PackAgeId");
                }
            }
        }

        [Column(Storage="_ProductGuid", DbType="UniqueIdentifier")]
        public Guid? ProductGuid
        {
            get
            {
                return this._ProductGuid;
            }
            set
            {
                if (this._ProductGuid != value)
                {
                    this.SendPropertyChanging();
                    this._ProductGuid = value;
                    this.SendPropertyChanged("ProductGuid");
                }
            }
        }
    }
}

