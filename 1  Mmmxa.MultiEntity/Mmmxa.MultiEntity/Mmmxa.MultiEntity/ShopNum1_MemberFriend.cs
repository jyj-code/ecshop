namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_MemberFriends")]
    public class ShopNum1_MemberFriend
    {
        private int _Guid;
        private string _MemberFriends;
        private string _MemLoginID;

        [Column(Storage="_Guid", AutoSync=AutoSync.Always, DbType="Int NOT NULL IDENTITY", IsDbGenerated=true)]
        public int Guid
        {
            get
            {
                return this._Guid;
            }
            set
            {
                if (this._Guid != value)
                {
                    this._Guid = value;
                }
            }
        }

        [Column(Storage="_MemberFriends", DbType="VarChar(5000)")]
        public string MemberFriends
        {
            get
            {
                return this._MemberFriends;
            }
            set
            {
                if (this._MemberFriends != value)
                {
                    this._MemberFriends = value;
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
                    this._MemLoginID = value;
                }
            }
        }
    }
}

