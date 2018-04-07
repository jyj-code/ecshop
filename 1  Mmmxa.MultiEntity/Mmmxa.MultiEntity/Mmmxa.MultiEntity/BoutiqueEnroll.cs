namespace ShopNum1MultiEntity
{
    using System;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Runtime.CompilerServices;

    [Table(Name="dbo.BoutiqueEnroll")]
    public class BoutiqueEnroll : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private string _Address;
        private string _CheckedName;
        private DateTime? _EnrollTime;
        private int _Id;
        private string _Name;
        private string _Remarks;
        private string _Tel;
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

        [Column(Storage="_Address", DbType="NVarChar(500)")]
        public string Address
        {
            get
            {
                return this._Address;
            }
            set
            {
                if (this._Address != value)
                {
                    this.SendPropertyChanging();
                    this._Address = value;
                    this.SendPropertyChanged("Address");
                }
            }
        }

        [Column(Storage="_CheckedName", DbType="NVarChar(500)")]
        public string CheckedName
        {
            get
            {
                return this._CheckedName;
            }
            set
            {
                if (this._CheckedName != value)
                {
                    this.SendPropertyChanging();
                    this._CheckedName = value;
                    this.SendPropertyChanged("CheckedName");
                }
            }
        }

        [Column(Storage="_EnrollTime", DbType="DateTime")]
        public DateTime? EnrollTime
        {
            get
            {
                return this._EnrollTime;
            }
            set
            {
                if (this._EnrollTime != value)
                {
                    this.SendPropertyChanging();
                    this._EnrollTime = value;
                    this.SendPropertyChanged("EnrollTime");
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

        [Column(Storage="_Name", DbType="NVarChar(50)")]
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

        [Column(Storage="_Remarks", DbType="NVarChar(500)")]
        public string Remarks
        {
            get
            {
                return this._Remarks;
            }
            set
            {
                if (this._Remarks != value)
                {
                    this.SendPropertyChanging();
                    this._Remarks = value;
                    this.SendPropertyChanged("Remarks");
                }
            }
        }

        [Column(Storage="_Tel", DbType="NVarChar(50)")]
        public string Tel
        {
            get
            {
                return this._Tel;
            }
            set
            {
                if (this._Tel != value)
                {
                    this.SendPropertyChanging();
                    this._Tel = value;
                    this.SendPropertyChanged("Tel");
                }
            }
        }
    }
}

