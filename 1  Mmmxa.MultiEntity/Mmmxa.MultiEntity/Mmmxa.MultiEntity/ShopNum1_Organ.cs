namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.ShopNum1_Organ")]
    public class ShopNum1_Organ : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private string _Abbreviations;
        private string _Code;
        private int _ID;
        private int _Isshow;
        private int _Isvalid;
        private string _Name;
        private int _Sortid;
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

        [Column(Storage="_Abbreviations", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
        public string Abbreviations
        {
            get
            {
                return this._Abbreviations;
            }
            set
            {
                if (this._Abbreviations != value)
                {
                    this.SendPropertyChanging();
                    this._Abbreviations = value;
                    this.SendPropertyChanged("Abbreviations");
                }
            }
        }

        [Column(Storage="_Code", DbType="Char(8) NOT NULL", CanBeNull=false)]
        public string Code
        {
            get
            {
                return this._Code;
            }
            set
            {
                if (this._Code != value)
                {
                    this.SendPropertyChanging();
                    this._Code = value;
                    this.SendPropertyChanged("Code");
                }
            }
        }

        [Column(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
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
                    this.SendPropertyChanging();
                    this._ID = value;
                    this.SendPropertyChanged("ID");
                }
            }
        }

        [Column(Storage="_Isshow", DbType="Int NOT NULL")]
        public int Isshow
        {
            get
            {
                return this._Isshow;
            }
            set
            {
                if (this._Isshow != value)
                {
                    this.SendPropertyChanging();
                    this._Isshow = value;
                    this.SendPropertyChanged("Isshow");
                }
            }
        }

        [Column(Storage="_Isvalid", DbType="Int NOT NULL")]
        public int Isvalid
        {
            get
            {
                return this._Isvalid;
            }
            set
            {
                if (this._Isvalid != value)
                {
                    this.SendPropertyChanging();
                    this._Isvalid = value;
                    this.SendPropertyChanged("Isvalid");
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

        [Column(Storage="_Sortid", DbType="Int NOT NULL")]
        public int Sortid
        {
            get
            {
                return this._Sortid;
            }
            set
            {
                if (this._Sortid != value)
                {
                    this.SendPropertyChanging();
                    this._Sortid = value;
                    this.SendPropertyChanged("Sortid");
                }
            }
        }
    }
}

