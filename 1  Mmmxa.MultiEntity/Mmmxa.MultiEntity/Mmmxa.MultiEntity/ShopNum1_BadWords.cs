namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_BadWords")]
    public class ShopNum1_BadWords : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private string _CreateUser;
        private string _find;
        private int _id;
        private string _replacement;
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

        [Column(Storage="_CreateUser", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
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

        [Column(Storage="_find", DbType="NVarChar(250) NOT NULL", CanBeNull=false)]
        public string find
        {
            get
            {
                return this._find;
            }
            set
            {
                if (this._find != value)
                {
                    this.SendPropertyChanging();
                    this._find = value;
                    this.SendPropertyChanged("find");
                }
            }
        }

        [Column(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
        public int id
        {
            get
            {
                return this._id;
            }
            set
            {
                if (this._id != value)
                {
                    this.SendPropertyChanging();
                    this._id = value;
                    this.SendPropertyChanged("id");
                }
            }
        }

        [Column(Storage="_replacement", DbType="NVarChar(250) NOT NULL", CanBeNull=false)]
        public string replacement
        {
            get
            {
                return this._replacement;
            }
            set
            {
                if (this._replacement != value)
                {
                    this.SendPropertyChanging();
                    this._replacement = value;
                    this.SendPropertyChanged("replacement");
                }
            }
        }
    }
}

