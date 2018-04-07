namespace ShopNum1MultiEntity
{
    using System;
    using System.Data.Linq.Mapping;

    [Table(Name="dbo.ShopNum1_RelatedArticle")]
    public class ShopNum1_RelatedArticle
    {
        private Guid _ArticleGuid;
        private DateTime _CreateTime;
        private string _CreateUser;
        private int _IsBoth;
        private Guid _SubArticleGuid;

        [Column(Storage="_ArticleGuid", DbType="UniqueIdentifier NOT NULL")]
        public Guid ArticleGuid
        {
            get
            {
                return this._ArticleGuid;
            }
            set
            {
                if (this._ArticleGuid != value)
                {
                    this._ArticleGuid = value;
                }
            }
        }

        [Column(Storage="_CreateTime", DbType="DateTime NOT NULL")]
        public DateTime CreateTime
        {
            get
            {
                return this._CreateTime;
            }
            set
            {
                if (this._CreateTime != value)
                {
                    this._CreateTime = value;
                }
            }
        }

        [Column(Storage="_CreateUser", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
                    this._CreateUser = value;
                }
            }
        }

        [Column(Storage="_IsBoth", DbType="Int NOT NULL")]
        public int IsBoth
        {
            get
            {
                return this._IsBoth;
            }
            set
            {
                if (this._IsBoth != value)
                {
                    this._IsBoth = value;
                }
            }
        }

        [Column(Storage="_SubArticleGuid", DbType="UniqueIdentifier NOT NULL")]
        public Guid SubArticleGuid
        {
            get
            {
                return this._SubArticleGuid;
            }
            set
            {
                if (this._SubArticleGuid != value)
                {
                    this._SubArticleGuid = value;
                }
            }
        }
    }
}

