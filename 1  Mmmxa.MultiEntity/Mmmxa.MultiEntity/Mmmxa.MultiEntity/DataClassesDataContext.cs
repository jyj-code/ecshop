namespace ShopNum1MultiEntity
{
    using System;
    using System.Data;
    using System.Data.Linq;
    using System.Data.Linq.Mapping;
    using ShopNum1MultiEntity.Properties;

    [Database(Name="CityMallV8.2.1")]
    public class DataClassesDataContext : DataContext
    {
        private static MappingSource mappingSource = new AttributeMappingSource();

        public DataClassesDataContext() : base(Settings.Default.CityMallV8_2_1ConnectionString, mappingSource)
        {
        }

        public DataClassesDataContext(IDbConnection connection) : base(connection, mappingSource)
        {
        }

        public DataClassesDataContext(string connection) : base(connection, mappingSource)
        {
        }

        public DataClassesDataContext(IDbConnection connection, MappingSource mappingSource) : base(connection, mappingSource)
        {
        }

        public DataClassesDataContext(string connection, MappingSource mappingSource) : base(connection, mappingSource)
        {
        }

        public Table<Advertisement> Advertisements
        {
            get
            {
                return base.GetTable<Advertisement>();
            }
        }

        public Table<Agent__VideoComment> Agent__VideoComments
        {
            get
            {
                return base.GetTable<Agent__VideoComment>();
            }
        }

        public Table<BoutiqueEnroll> BoutiqueEnrolls
        {
            get
            {
                return base.GetTable<BoutiqueEnroll>();
            }
        }

        public Table<DefaultAdImg> DefaultAdImgs
        {
            get
            {
                return base.GetTable<DefaultAdImg>();
            }
        }

        public Table<PageAdID> PageAdIDs
        {
            get
            {
                return base.GetTable<PageAdID>();
            }
        }

        public Table<PageInfo> PageInfos
        {
            get
            {
                return base.GetTable<PageInfo>();
            }
        }

        public Table<ShopNum1_Address> ShopNum1_Addresses
        {
            get
            {
                return base.GetTable<ShopNum1_Address>();
            }
        }

        public Table<ShopNum1_AdvancePaymentApplyLog> ShopNum1_AdvancePaymentApplyLogs
        {
            get
            {
                return base.GetTable<ShopNum1_AdvancePaymentApplyLog>();
            }
        }

        public Table<ShopNum1_AdvancePaymentFreezeLog> ShopNum1_AdvancePaymentFreezeLogs
        {
            get
            {
                return base.GetTable<ShopNum1_AdvancePaymentFreezeLog>();
            }
        }

        public Table<ShopNum1_AdvancePaymentModifyLog> ShopNum1_AdvancePaymentModifyLogs
        {
            get
            {
                return base.GetTable<ShopNum1_AdvancePaymentModifyLog>();
            }
        }

        public Table<ShopNum1_AdvertisementImage> ShopNum1_AdvertisementImages
        {
            get
            {
                return base.GetTable<ShopNum1_AdvertisementImage>();
            }
        }

        public Table<ShopNum1_AdvertPay> ShopNum1_AdvertPays
        {
            get
            {
                return base.GetTable<ShopNum1_AdvertPay>();
            }
        }

        public Table<ShopNum1_AgentPaymentApplyLog> ShopNum1_AgentPaymentApplyLogs
        {
            get
            {
                return base.GetTable<ShopNum1_AgentPaymentApplyLog>();
            }
        }

        public Table<ShopNum1_AnnouncementCategory> ShopNum1_AnnouncementCategories
        {
            get
            {
                return base.GetTable<ShopNum1_AnnouncementCategory>();
            }
        }

        public Table<ShopNum1_Announcement> ShopNum1_Announcements
        {
            get
            {
                return base.GetTable<ShopNum1_Announcement>();
            }
        }

        public Table<ShopNum1_ArticleCategory> ShopNum1_ArticleCategories
        {
            get
            {
                return base.GetTable<ShopNum1_ArticleCategory>();
            }
        }

        public Table<ShopNum1_ArticleComment> ShopNum1_ArticleComments
        {
            get
            {
                return base.GetTable<ShopNum1_ArticleComment>();
            }
        }

        public Table<ShopNum1_Article> ShopNum1_Articles
        {
            get
            {
                return base.GetTable<ShopNum1_Article>();
            }
        }

        public Table<ShopNum1_AttachMentCateGory> ShopNum1_AttachMentCateGories
        {
            get
            {
                return base.GetTable<ShopNum1_AttachMentCateGory>();
            }
        }

        public Table<ShopNum1_AttachMent> ShopNum1_AttachMents
        {
            get
            {
                return base.GetTable<ShopNum1_AttachMent>();
            }
        }

        public Table<ShopNum1MultiEntity.ShopNum1_BadWords> ShopNum1_BadWords
        {
            get
            {
                return base.GetTable<ShopNum1MultiEntity.ShopNum1_BadWords>();
            }
        }

        public Table<ShopNum1_Brand> ShopNum1_Brands
        {
            get
            {
                return base.GetTable<ShopNum1_Brand>();
            }
        }

        public Table<ShopNum1_Category> ShopNum1_Categories
        {
            get
            {
                return base.GetTable<ShopNum1_Category>();
            }
        }

        public Table<ShopNum1_CategoryAdID> ShopNum1_CategoryAdIDs
        {
            get
            {
                return base.GetTable<ShopNum1_CategoryAdID>();
            }
        }

        public Table<ShopNum1_CategoryAdPayMent> ShopNum1_CategoryAdPayMents
        {
            get
            {
                return base.GetTable<ShopNum1_CategoryAdPayMent>();
            }
        }

        public Table<ShopNum1_CategoryAdvertisement> ShopNum1_CategoryAdvertisements
        {
            get
            {
                return base.GetTable<ShopNum1_CategoryAdvertisement>();
            }
        }

        public Table<ShopNum1_CategoryComment> ShopNum1_CategoryComments
        {
            get
            {
                return base.GetTable<ShopNum1_CategoryComment>();
            }
        }

        public Table<ShopNum1_CategoryInfo> ShopNum1_CategoryInfos
        {
            get
            {
                return base.GetTable<ShopNum1_CategoryInfo>();
            }
        }

        public Table<ShopNum1_CategoryType> ShopNum1_CategoryTypes
        {
            get
            {
                return base.GetTable<ShopNum1_CategoryType>();
            }
        }

        public Table<ShopNum1_City> ShopNum1_Cities
        {
            get
            {
                return base.GetTable<ShopNum1_City>();
            }
        }

        public Table<ShopNum1_City_AdvancePaymentModifyLog> ShopNum1_City_AdvancePaymentModifyLogs
        {
            get
            {
                return base.GetTable<ShopNum1_City_AdvancePaymentModifyLog>();
            }
        }

        public Table<ShopNum1_Comment> ShopNum1_Comments
        {
            get
            {
                return base.GetTable<ShopNum1_Comment>();
            }
        }

        public Table<ShopNum1_ComplaintsManagement> ShopNum1_ComplaintsManagements
        {
            get
            {
                return base.GetTable<ShopNum1_ComplaintsManagement>();
            }
        }

        public Table<ShopNum1_ComplaintsReply> ShopNum1_ComplaintsReplies
        {
            get
            {
                return base.GetTable<ShopNum1_ComplaintsReply>();
            }
        }

        public Table<ShopNum1_ControlData> ShopNum1_ControlDatas
        {
            get
            {
                return base.GetTable<ShopNum1_ControlData>();
            }
        }

        public Table<ShopNum1_Control> ShopNum1_Controls
        {
            get
            {
                return base.GetTable<ShopNum1_Control>();
            }
        }

        public Table<ShopNum1_CreditScoreModifyLog> ShopNum1_CreditScoreModifyLogs
        {
            get
            {
                return base.GetTable<ShopNum1_CreditScoreModifyLog>();
            }
        }

        public Table<ShopNum1_CreditSumModifyLog> ShopNum1_CreditSumModifyLogs
        {
            get
            {
                return base.GetTable<ShopNum1_CreditSumModifyLog>();
            }
        }

        public Table<ShopNum1_Dept> ShopNum1_Depts
        {
            get
            {
                return base.GetTable<ShopNum1_Dept>();
            }
        }

        public Table<ShopNum1_DispatchRegion> ShopNum1_DispatchRegions
        {
            get
            {
                return base.GetTable<ShopNum1_DispatchRegion>();
            }
        }

        public Table<ShopNum1_EmailBook> ShopNum1_EmailBooks
        {
            get
            {
                return base.GetTable<ShopNum1_EmailBook>();
            }
        }

        public Table<ShopNum1_EmailBookType> ShopNum1_EmailBookTypes
        {
            get
            {
                return base.GetTable<ShopNum1_EmailBookType>();
            }
        }

        public Table<ShopNum1_EmailGroupSend> ShopNum1_EmailGroupSends
        {
            get
            {
                return base.GetTable<ShopNum1_EmailGroupSend>();
            }
        }

        public Table<ShopNum1_Email> ShopNum1_Emails
        {
            get
            {
                return base.GetTable<ShopNum1_Email>();
            }
        }

        public Table<ShopNum1_EmailType> ShopNum1_EmailTypes
        {
            get
            {
                return base.GetTable<ShopNum1_EmailType>();
            }
        }

        public Table<ShopNum1_FloorDistribution> ShopNum1_FloorDistributions
        {
            get
            {
                return base.GetTable<ShopNum1_FloorDistribution>();
            }
        }

        public Table<ShopNum1_Group_Product> ShopNum1_Group_Products
        {
            get
            {
                return base.GetTable<ShopNum1_Group_Product>();
            }
        }

        public Table<ShopNum1_GroupPage> ShopNum1_GroupPages
        {
            get
            {
                return base.GetTable<ShopNum1_GroupPage>();
            }
        }

        public Table<ShopNum1_GroupPageWebControl> ShopNum1_GroupPageWebControls
        {
            get
            {
                return base.GetTable<ShopNum1_GroupPageWebControl>();
            }
        }

        public Table<ShopNum1_Group> ShopNum1_Groups
        {
            get
            {
                return base.GetTable<ShopNum1_Group>();
            }
        }

        public Table<ShopNum1_GroupUser> ShopNum1_GroupUsers
        {
            get
            {
                return base.GetTable<ShopNum1_GroupUser>();
            }
        }

        public Table<ShopNum1_Help> ShopNum1_Helps
        {
            get
            {
                return base.GetTable<ShopNum1_Help>();
            }
        }

        public Table<ShopNum1_HelpType> ShopNum1_HelpTypes
        {
            get
            {
                return base.GetTable<ShopNum1_HelpType>();
            }
        }

        public Table<ShopNum1_Image_Type> ShopNum1_Image_Types
        {
            get
            {
                return base.GetTable<ShopNum1_Image_Type>();
            }
        }

        public Table<ShopNum1_ImageCategory> ShopNum1_ImageCategories
        {
            get
            {
                return base.GetTable<ShopNum1_ImageCategory>();
            }
        }

        public Table<ShopNum1_Image> ShopNum1_Images
        {
            get
            {
                return base.GetTable<ShopNum1_Image>();
            }
        }

        public Table<ShopNum1_IPInfo> ShopNum1_IPInfos
        {
            get
            {
                return base.GetTable<ShopNum1_IPInfo>();
            }
        }

        public Table<ShopNum1_IPManage> ShopNum1_IPManages
        {
            get
            {
                return base.GetTable<ShopNum1_IPManage>();
            }
        }

        public Table<ShopNum1MultiEntity.ShopNum1_KeyWords> ShopNum1_KeyWords
        {
            get
            {
                return base.GetTable<ShopNum1MultiEntity.ShopNum1_KeyWords>();
            }
        }

        public Table<ShopNum1_Limt_Package> ShopNum1_Limt_Packages
        {
            get
            {
                return base.GetTable<ShopNum1_Limt_Package>();
            }
        }

        public Table<ShopNum1_Limt_Product> ShopNum1_Limt_Products
        {
            get
            {
                return base.GetTable<ShopNum1_Limt_Product>();
            }
        }

        public Table<ShopNum1_Link> ShopNum1_Links
        {
            get
            {
                return base.GetTable<ShopNum1_Link>();
            }
        }

        public Table<ShopNum1_Logistic> ShopNum1_Logistics
        {
            get
            {
                return base.GetTable<ShopNum1_Logistic>();
            }
        }

        public Table<ShopNum1_MemberActivate> ShopNum1_MemberActivates
        {
            get
            {
                return base.GetTable<ShopNum1_MemberActivate>();
            }
        }

        public Table<ShopNum1_MemberAssignGroup> ShopNum1_MemberAssignGroups
        {
            get
            {
                return base.GetTable<ShopNum1_MemberAssignGroup>();
            }
        }

        public Table<ShopNum1_MemberEmailExec> ShopNum1_MemberEmailExecs
        {
            get
            {
                return base.GetTable<ShopNum1_MemberEmailExec>();
            }
        }

        public Table<ShopNum1_MemberFriend> ShopNum1_MemberFriends
        {
            get
            {
                return base.GetTable<ShopNum1_MemberFriend>();
            }
        }

        public Table<ShopNum1_MemberGroup> ShopNum1_MemberGroups
        {
            get
            {
                return base.GetTable<ShopNum1_MemberGroup>();
            }
        }

        public Table<ShopNum1_MemberMessage> ShopNum1_MemberMessages
        {
            get
            {
                return base.GetTable<ShopNum1_MemberMessage>();
            }
        }

        public Table<ShopNum1_MemberProductCollect> ShopNum1_MemberProductCollects
        {
            get
            {
                return base.GetTable<ShopNum1_MemberProductCollect>();
            }
        }

        public Table<ShopNum1_MemberProfitBonusLog> ShopNum1_MemberProfitBonusLogs
        {
            get
            {
                return base.GetTable<ShopNum1_MemberProfitBonusLog>();
            }
        }

        public Table<ShopNum1_MemberPwd> ShopNum1_MemberPwds
        {
            get
            {
                return base.GetTable<ShopNum1_MemberPwd>();
            }
        }

        public Table<ShopNum1_MemberRank> ShopNum1_MemberRanks
        {
            get
            {
                return base.GetTable<ShopNum1_MemberRank>();
            }
        }

        public Table<ShopNum1_MemberReport> ShopNum1_MemberReports
        {
            get
            {
                return base.GetTable<ShopNum1_MemberReport>();
            }
        }

        public Table<ShopNum1_Member> ShopNum1_Members
        {
            get
            {
                return base.GetTable<ShopNum1_Member>();
            }
        }

        public Table<ShopNum1_MemberShopCollect> ShopNum1_MemberShopCollects
        {
            get
            {
                return base.GetTable<ShopNum1_MemberShopCollect>();
            }
        }

        public Table<ShopNum1_MenberServiceInfo> ShopNum1_MenberServiceInfos
        {
            get
            {
                return base.GetTable<ShopNum1_MenberServiceInfo>();
            }
        }

        public Table<ShopNum1_Menu> ShopNum1_Menus
        {
            get
            {
                return base.GetTable<ShopNum1_Menu>();
            }
        }

        public Table<ShopNum1_MessageBoard> ShopNum1_MessageBoards
        {
            get
            {
                return base.GetTable<ShopNum1_MessageBoard>();
            }
        }

        public Table<ShopNum1_MessageInfo> ShopNum1_MessageInfos
        {
            get
            {
                return base.GetTable<ShopNum1_MessageInfo>();
            }
        }

        public Table<ShopNum1MultiEntity.ShopNum1_MMS> ShopNum1_MMS
        {
            get
            {
                return base.GetTable<ShopNum1MultiEntity.ShopNum1_MMS>();
            }
        }

        public Table<ShopNum1_MMSGroupSend> ShopNum1_MMSGroupSends
        {
            get
            {
                return base.GetTable<ShopNum1_MMSGroupSend>();
            }
        }

        public Table<ShopNum1_MMSMemberAssignGroup> ShopNum1_MMSMemberAssignGroups
        {
            get
            {
                return base.GetTable<ShopNum1_MMSMemberAssignGroup>();
            }
        }

        public Table<ShopNum1_MMSMemberGroup> ShopNum1_MMSMemberGroups
        {
            get
            {
                return base.GetTable<ShopNum1_MMSMemberGroup>();
            }
        }

        public Table<ShopNum1_MMSType> ShopNum1_MMSTypes
        {
            get
            {
                return base.GetTable<ShopNum1_MMSType>();
            }
        }

        public Table<ShopNum1_MobilePayment> ShopNum1_MobilePayments
        {
            get
            {
                return base.GetTable<ShopNum1_MobilePayment>();
            }
        }

        public Table<ShopNum1_Navigation> ShopNum1_Navigations
        {
            get
            {
                return base.GetTable<ShopNum1_Navigation>();
            }
        }

        public Table<ShopNum1_OnlineService> ShopNum1_OnlineServices
        {
            get
            {
                return base.GetTable<ShopNum1_OnlineService>();
            }
        }

        public Table<ShopNum1_OperateLog> ShopNum1_OperateLogs
        {
            get
            {
                return base.GetTable<ShopNum1_OperateLog>();
            }
        }

        public Table<ShopNum1_OrderComplaint> ShopNum1_OrderComplaints
        {
            get
            {
                return base.GetTable<ShopNum1_OrderComplaint>();
            }
        }

        public Table<ShopNum1_OrderExpressInfo> ShopNum1_OrderExpressInfos
        {
            get
            {
                return base.GetTable<ShopNum1_OrderExpressInfo>();
            }
        }

        public Table<ShopNum1_OrderInfo> ShopNum1_OrderInfos
        {
            get
            {
                return base.GetTable<ShopNum1_OrderInfo>();
            }
        }

        public Table<ShopNum1_OrderOperateLog> ShopNum1_OrderOperateLogs
        {
            get
            {
                return base.GetTable<ShopNum1_OrderOperateLog>();
            }
        }

        public Table<ShopNum1_OrderProduct> ShopNum1_OrderProducts
        {
            get
            {
                return base.GetTable<ShopNum1_OrderProduct>();
            }
        }

        public Table<ShopNum1_OrderScore> ShopNum1_OrderScores
        {
            get
            {
                return base.GetTable<ShopNum1_OrderScore>();
            }
        }

        public Table<ShopNum1_Organ> ShopNum1_Organs
        {
            get
            {
                return base.GetTable<ShopNum1_Organ>();
            }
        }

        public Table<ShopNum1_PackAgeRalate> ShopNum1_PackAgeRalates
        {
            get
            {
                return base.GetTable<ShopNum1_PackAgeRalate>();
            }
        }

        public Table<ShopNum1_PackAge> ShopNum1_PackAges
        {
            get
            {
                return base.GetTable<ShopNum1_PackAge>();
            }
        }

        public Table<ShopNum1_Page> ShopNum1_Pages
        {
            get
            {
                return base.GetTable<ShopNum1_Page>();
            }
        }

        public Table<ShopNum1_PageWebControl> ShopNum1_PageWebControls
        {
            get
            {
                return base.GetTable<ShopNum1_PageWebControl>();
            }
        }

        public Table<ShopNum1_Payment> ShopNum1_Payments
        {
            get
            {
                return base.GetTable<ShopNum1_Payment>();
            }
        }

        public Table<ShopNum1_PaymentType> ShopNum1_PaymentTypes
        {
            get
            {
                return base.GetTable<ShopNum1_PaymentType>();
            }
        }

        public Table<ShopNum1_PreTransfer> ShopNum1_PreTransfers
        {
            get
            {
                return base.GetTable<ShopNum1_PreTransfer>();
            }
        }

        public Table<ShopNum1_PreventIp> ShopNum1_PreventIps
        {
            get
            {
                return base.GetTable<ShopNum1_PreventIp>();
            }
        }

        public Table<ShopNum1_Product_Activity> ShopNum1_Product_Activities
        {
            get
            {
                return base.GetTable<ShopNum1_Product_Activity>();
            }
        }

        public Table<ShopNum1_ProductCategory> ShopNum1_ProductCategories
        {
            get
            {
                return base.GetTable<ShopNum1_ProductCategory>();
            }
        }

        public Table<ShopNum1_ProductCategoryAndProductBranDrelation> ShopNum1_ProductCategoryAndProductBranDrelations
        {
            get
            {
                return base.GetTable<ShopNum1_ProductCategoryAndProductBranDrelation>();
            }
        }

        public Table<ShopNum1_RankScoreModifyLog> ShopNum1_RankScoreModifyLogs
        {
            get
            {
                return base.GetTable<ShopNum1_RankScoreModifyLog>();
            }
        }

        public Table<ShopNum1_Refund> ShopNum1_Refunds
        {
            get
            {
                return base.GetTable<ShopNum1_Refund>();
            }
        }

        public Table<ShopNum1_Region> ShopNum1_Regions
        {
            get
            {
                return base.GetTable<ShopNum1_Region>();
            }
        }

        public Table<ShopNum1_RelatedArticle> ShopNum1_RelatedArticles
        {
            get
            {
                return base.GetTable<ShopNum1_RelatedArticle>();
            }
        }

        public Table<ShopNum1_ScoreFreezeLog> ShopNum1_ScoreFreezeLogs
        {
            get
            {
                return base.GetTable<ShopNum1_ScoreFreezeLog>();
            }
        }

        public Table<ShopNum1_ScoreModifyLog> ShopNum1_ScoreModifyLogs
        {
            get
            {
                return base.GetTable<ShopNum1_ScoreModifyLog>();
            }
        }

        public Table<ShopNum1_ScoreOrderInfo> ShopNum1_ScoreOrderInfos
        {
            get
            {
                return base.GetTable<ShopNum1_ScoreOrderInfo>();
            }
        }

        public Table<ShopNum1_ScoreOrderProduct> ShopNum1_ScoreOrderProducts
        {
            get
            {
                return base.GetTable<ShopNum1_ScoreOrderProduct>();
            }
        }

        public Table<ShopNum1_ScoreProductCategory> ShopNum1_ScoreProductCategories
        {
            get
            {
                return base.GetTable<ShopNum1_ScoreProductCategory>();
            }
        }

        public Table<ShopNum1_ServiceLog> ShopNum1_ServiceLogs
        {
            get
            {
                return base.GetTable<ShopNum1_ServiceLog>();
            }
        }

        public Table<ShopNum1_ServiceProduct> ShopNum1_ServiceProducts
        {
            get
            {
                return base.GetTable<ShopNum1_ServiceProduct>();
            }
        }

        public Table<ShopNum1_Shipper> ShopNum1_Shippers
        {
            get
            {
                return base.GetTable<ShopNum1_Shipper>();
            }
        }

        public Table<ShopNum1_Shop_ApplyCateGory> ShopNum1_Shop_ApplyCateGories
        {
            get
            {
                return base.GetTable<ShopNum1_Shop_ApplyCateGory>();
            }
        }

        public Table<ShopNum1_Shop_ApplyEnsure> ShopNum1_Shop_ApplyEnsures
        {
            get
            {
                return base.GetTable<ShopNum1_Shop_ApplyEnsure>();
            }
        }

        public Table<ShopNum1_Shop_ApplyShopRank> ShopNum1_Shop_ApplyShopRanks
        {
            get
            {
                return base.GetTable<ShopNum1_Shop_ApplyShopRank>();
            }
        }

        public Table<ShopNum1_Shop_Cart> ShopNum1_Shop_Carts
        {
            get
            {
                return base.GetTable<ShopNum1_Shop_Cart>();
            }
        }

        public Table<ShopNum1_Shop_Coupon> ShopNum1_Shop_Coupons
        {
            get
            {
                return base.GetTable<ShopNum1_Shop_Coupon>();
            }
        }

        public Table<ShopNum1_Shop_CouponType> ShopNum1_Shop_CouponTypes
        {
            get
            {
                return base.GetTable<ShopNum1_Shop_CouponType>();
            }
        }

        public Table<ShopNum1_Shop_ImageCategory> ShopNum1_Shop_ImageCategories
        {
            get
            {
                return base.GetTable<ShopNum1_Shop_ImageCategory>();
            }
        }

        public Table<ShopNum1_Shop_Image> ShopNum1_Shop_Images
        {
            get
            {
                return base.GetTable<ShopNum1_Shop_Image>();
            }
        }

        public Table<ShopNum1_Shop_Integral> ShopNum1_Shop_Integrals
        {
            get
            {
                return base.GetTable<ShopNum1_Shop_Integral>();
            }
        }

        public Table<ShopNum1_Shop_Link> ShopNum1_Shop_Links
        {
            get
            {
                return base.GetTable<ShopNum1_Shop_Link>();
            }
        }

        public Table<ShopNum1_Shop_MessageBoard> ShopNum1_Shop_MessageBoards
        {
            get
            {
                return base.GetTable<ShopNum1_Shop_MessageBoard>();
            }
        }

        public Table<ShopNum1MultiEntity.ShopNum1_Shop_News> ShopNum1_Shop_News
        {
            get
            {
                return base.GetTable<ShopNum1MultiEntity.ShopNum1_Shop_News>();
            }
        }

        public Table<ShopNum1_Shop_NewsCategory> ShopNum1_Shop_NewsCategories
        {
            get
            {
                return base.GetTable<ShopNum1_Shop_NewsCategory>();
            }
        }

        public Table<ShopNum1_Shop_NewsComment> ShopNum1_Shop_NewsComments
        {
            get
            {
                return base.GetTable<ShopNum1_Shop_NewsComment>();
            }
        }

        public Table<ShopNum1_Shop_OnlineService> ShopNum1_Shop_OnlineServices
        {
            get
            {
                return base.GetTable<ShopNum1_Shop_OnlineService>();
            }
        }

        public Table<ShopNum1_Shop_OtherOrderInfo> ShopNum1_Shop_OtherOrderInfos
        {
            get
            {
                return base.GetTable<ShopNum1_Shop_OtherOrderInfo>();
            }
        }

        public Table<ShopNum1_Shop_Photo> ShopNum1_Shop_Photos
        {
            get
            {
                return base.GetTable<ShopNum1_Shop_Photo>();
            }
        }

        public Table<ShopNum1_Shop_ProductBooking> ShopNum1_Shop_ProductBookings
        {
            get
            {
                return base.GetTable<ShopNum1_Shop_ProductBooking>();
            }
        }

        public Table<ShopNum1_Shop_ProductCategory> ShopNum1_Shop_ProductCategories
        {
            get
            {
                return base.GetTable<ShopNum1_Shop_ProductCategory>();
            }
        }

        public Table<ShopNum1_Shop_ProductComment> ShopNum1_Shop_ProductComments
        {
            get
            {
                return base.GetTable<ShopNum1_Shop_ProductComment>();
            }
        }

        public Table<ShopNum1_Shop_Product> ShopNum1_Shop_Products
        {
            get
            {
                return base.GetTable<ShopNum1_Shop_Product>();
            }
        }

        public Table<ShopNum1_Shop_ProductSpell> ShopNum1_Shop_ProductSpells
        {
            get
            {
                return base.GetTable<ShopNum1_Shop_ProductSpell>();
            }
        }

        public Table<ShopNum1_Shop_ScoreProductCategory> ShopNum1_Shop_ScoreProductCategories
        {
            get
            {
                return base.GetTable<ShopNum1_Shop_ScoreProductCategory>();
            }
        }

        public Table<ShopNum1_Shop_ScoreProduct> ShopNum1_Shop_ScoreProducts
        {
            get
            {
                return base.GetTable<ShopNum1_Shop_ScoreProduct>();
            }
        }

        public Table<ShopNum1_Shop_StarGuide> ShopNum1_Shop_StarGuides
        {
            get
            {
                return base.GetTable<ShopNum1_Shop_StarGuide>();
            }
        }

        public Table<ShopNum1_Shop_Template> ShopNum1_Shop_Templates
        {
            get
            {
                return base.GetTable<ShopNum1_Shop_Template>();
            }
        }

        public Table<ShopNum1_Shop_UserDefinedColumn> ShopNum1_Shop_UserDefinedColumns
        {
            get
            {
                return base.GetTable<ShopNum1_Shop_UserDefinedColumn>();
            }
        }

        public Table<ShopNum1_Shop_VideoCategory> ShopNum1_Shop_VideoCategories
        {
            get
            {
                return base.GetTable<ShopNum1_Shop_VideoCategory>();
            }
        }

        public Table<ShopNum1_Shop_VideoComment> ShopNum1_Shop_VideoComments
        {
            get
            {
                return base.GetTable<ShopNum1_Shop_VideoComment>();
            }
        }

        public Table<ShopNum1_Shop_Video> ShopNum1_Shop_Videos
        {
            get
            {
                return base.GetTable<ShopNum1_Shop_Video>();
            }
        }

        public Table<ShopNum1_ShopCategory> ShopNum1_ShopCategories
        {
            get
            {
                return base.GetTable<ShopNum1_ShopCategory>();
            }
        }

        public Table<ShopNum1_ShopCollect> ShopNum1_ShopCollects
        {
            get
            {
                return base.GetTable<ShopNum1_ShopCollect>();
            }
        }

        public Table<ShopNum1_ShopEnsure> ShopNum1_ShopEnsures
        {
            get
            {
                return base.GetTable<ShopNum1_ShopEnsure>();
            }
        }

        public Table<ShopNum1_ShopInfo> ShopNum1_ShopInfos
        {
            get
            {
                return base.GetTable<ShopNum1_ShopInfo>();
            }
        }

        public Table<ShopNum1_ShopPayment> ShopNum1_ShopPayments
        {
            get
            {
                return base.GetTable<ShopNum1_ShopPayment>();
            }
        }

        public Table<ShopNum1_ShopProduct_Browse> ShopNum1_ShopProduct_Browses
        {
            get
            {
                return base.GetTable<ShopNum1_ShopProduct_Browse>();
            }
        }

        public Table<ShopNum1_ShopProductConsult> ShopNum1_ShopProductConsults
        {
            get
            {
                return base.GetTable<ShopNum1_ShopProductConsult>();
            }
        }

        public Table<ShopNum1_ShopProductProp> ShopNum1_ShopProductProps
        {
            get
            {
                return base.GetTable<ShopNum1_ShopProductProp>();
            }
        }

        public Table<ShopNum1_ShopProductPropValue> ShopNum1_ShopProductPropValues
        {
            get
            {
                return base.GetTable<ShopNum1_ShopProductPropValue>();
            }
        }

        public Table<ShopNum1_ShopProductRelationProp> ShopNum1_ShopProductRelationProps
        {
            get
            {
                return base.GetTable<ShopNum1_ShopProductRelationProp>();
            }
        }

        public Table<ShopNum1_ShopProRelateProp> ShopNum1_ShopProRelateProps
        {
            get
            {
                return base.GetTable<ShopNum1_ShopProRelateProp>();
            }
        }

        public Table<ShopNum1_ShopRank> ShopNum1_ShopRanks
        {
            get
            {
                return base.GetTable<ShopNum1_ShopRank>();
            }
        }

        public Table<ShopNum1_ShopReputation> ShopNum1_ShopReputations
        {
            get
            {
                return base.GetTable<ShopNum1_ShopReputation>();
            }
        }

        public Table<ShopNum1_ShopURLManage> ShopNum1_ShopURLManages
        {
            get
            {
                return base.GetTable<ShopNum1_ShopURLManage>();
            }
        }

        public Table<ShopNum1_SignIn> ShopNum1_SignIns
        {
            get
            {
                return base.GetTable<ShopNum1_SignIn>();
            }
        }

        public Table<ShopNum1_SpecificationManagement> ShopNum1_SpecificationManagements
        {
            get
            {
                return base.GetTable<ShopNum1_SpecificationManagement>();
            }
        }

        public Table<ShopNum1_SpecificationProductImage> ShopNum1_SpecificationProductImages
        {
            get
            {
                return base.GetTable<ShopNum1_SpecificationProductImage>();
            }
        }

        public Table<ShopNum1_SpecProudctDetail> ShopNum1_SpecProudctDetails
        {
            get
            {
                return base.GetTable<ShopNum1_SpecProudctDetail>();
            }
        }

        public Table<ShopNum1_SpecProudct> ShopNum1_SpecProudcts
        {
            get
            {
                return base.GetTable<ShopNum1_SpecProudct>();
            }
        }

        public Table<ShopNum1_Spec> ShopNum1_Specs
        {
            get
            {
                return base.GetTable<ShopNum1_Spec>();
            }
        }

        public Table<ShopNum1_SpecValue> ShopNum1_SpecValues
        {
            get
            {
                return base.GetTable<ShopNum1_SpecValue>();
            }
        }

        public Table<ShopNum1_SubstationManage> ShopNum1_SubstationManages
        {
            get
            {
                return base.GetTable<ShopNum1_SubstationManage>();
            }
        }

        public Table<ShopNum1_SupplyDemandCategory> ShopNum1_SupplyDemandCategories
        {
            get
            {
                return base.GetTable<ShopNum1_SupplyDemandCategory>();
            }
        }

        public Table<ShopNum1_SupplyDemandComment> ShopNum1_SupplyDemandComments
        {
            get
            {
                return base.GetTable<ShopNum1_SupplyDemandComment>();
            }
        }

        public Table<ShopNum1_SupplyDemand> ShopNum1_SupplyDemands
        {
            get
            {
                return base.GetTable<ShopNum1_SupplyDemand>();
            }
        }

        public Table<ShopNum1_SurveyOption> ShopNum1_SurveyOptions
        {
            get
            {
                return base.GetTable<ShopNum1_SurveyOption>();
            }
        }

        public Table<ShopNum1_SurveyTheme> ShopNum1_SurveyThemes
        {
            get
            {
                return base.GetTable<ShopNum1_SurveyTheme>();
            }
        }

        public Table<ShopNum1_ThemeActivity> ShopNum1_ThemeActivities
        {
            get
            {
                return base.GetTable<ShopNum1_ThemeActivity>();
            }
        }

        public Table<ShopNum1_ThemeActivityProduct> ShopNum1_ThemeActivityProducts
        {
            get
            {
                return base.GetTable<ShopNum1_ThemeActivityProduct>();
            }
        }

        public Table<ShopNum1MultiEntity.ShopNum1_ThreePaymentRecord> ShopNum1_ThreePaymentRecord
        {
            get
            {
                return base.GetTable<ShopNum1MultiEntity.ShopNum1_ThreePaymentRecord>();
            }
        }

        public Table<ShopNum1_TypeBrand> ShopNum1_TypeBrands
        {
            get
            {
                return base.GetTable<ShopNum1_TypeBrand>();
            }
        }

        public Table<ShopNum1_TypeProp> ShopNum1_TypeProps
        {
            get
            {
                return base.GetTable<ShopNum1_TypeProp>();
            }
        }

        public Table<ShopNum1_TypeSpec> ShopNum1_TypeSpecs
        {
            get
            {
                return base.GetTable<ShopNum1_TypeSpec>();
            }
        }

        public Table<ShopNum1_UserDefinedColumn> ShopNum1_UserDefinedColumns
        {
            get
            {
                return base.GetTable<ShopNum1_UserDefinedColumn>();
            }
        }

        public Table<ShopNum1_UserMessage> ShopNum1_UserMessages
        {
            get
            {
                return base.GetTable<ShopNum1_UserMessage>();
            }
        }

        public Table<ShopNum1_User> ShopNum1_Users
        {
            get
            {
                return base.GetTable<ShopNum1_User>();
            }
        }

        public Table<ShopNum1_VideoCategory> ShopNum1_VideoCategories
        {
            get
            {
                return base.GetTable<ShopNum1_VideoCategory>();
            }
        }

        public Table<ShopNum1_VideoComment> ShopNum1_VideoComments
        {
            get
            {
                return base.GetTable<ShopNum1_VideoComment>();
            }
        }

        public Table<ShopNum1_Video> ShopNum1_Videos
        {
            get
            {
                return base.GetTable<ShopNum1_Video>();
            }
        }

        public Table<ShopNum1_WebSite> ShopNum1_WebSites
        {
            get
            {
                return base.GetTable<ShopNum1_WebSite>();
            }
        }

        public Table<ShopNum1MultiEntity.ShopNum1_Weixin_ReplyRule> ShopNum1_Weixin_ReplyRule
        {
            get
            {
                return base.GetTable<ShopNum1MultiEntity.ShopNum1_Weixin_ReplyRule>();
            }
        }

        public Table<ShopNum1MultiEntity.ShopNum1_Weixin_ReplyRuleChirldContent> ShopNum1_Weixin_ReplyRuleChirldContent
        {
            get
            {
                return base.GetTable<ShopNum1MultiEntity.ShopNum1_Weixin_ReplyRuleChirldContent>();
            }
        }

        public Table<ShopNum1MultiEntity.ShopNum1_Weixin_ReplyRuleContent> ShopNum1_Weixin_ReplyRuleContent
        {
            get
            {
                return base.GetTable<ShopNum1MultiEntity.ShopNum1_Weixin_ReplyRuleContent>();
            }
        }

        public Table<ShopNum1MultiEntity.ShopNum1_Weixin_ReplyRuleContentArticle> ShopNum1_Weixin_ReplyRuleContentArticle
        {
            get
            {
                return base.GetTable<ShopNum1MultiEntity.ShopNum1_Weixin_ReplyRuleContentArticle>();
            }
        }

        public Table<ShopNum1MultiEntity.ShopNum1_Weixin_ReplyRuleKey> ShopNum1_Weixin_ReplyRuleKey
        {
            get
            {
                return base.GetTable<ShopNum1MultiEntity.ShopNum1_Weixin_ReplyRuleKey>();
            }
        }

        public Table<ShopNum1MultiEntity.ShopNum1_Weixin_ShopConfig> ShopNum1_Weixin_ShopConfig
        {
            get
            {
                return base.GetTable<ShopNum1MultiEntity.ShopNum1_Weixin_ShopConfig>();
            }
        }

        public Table<ShopNum1MultiEntity.ShopNum1_Weixin_ShopMember> ShopNum1_Weixin_ShopMember
        {
            get
            {
                return base.GetTable<ShopNum1MultiEntity.ShopNum1_Weixin_ShopMember>();
            }
        }

        public Table<ShopNum1MultiEntity.ShopNum1_Weixin_ShopMenu> ShopNum1_Weixin_ShopMenu
        {
            get
            {
                return base.GetTable<ShopNum1MultiEntity.ShopNum1_Weixin_ShopMenu>();
            }
        }

        public Table<ShopNum1_WeiXin_ShopUser> ShopNum1_WeiXin_ShopUsers
        {
            get
            {
                return base.GetTable<ShopNum1_WeiXin_ShopUser>();
            }
        }

        public Table<ShopNum1MultiEntity.ShopNum1_Weixin_ShopWeiXinConfig> ShopNum1_Weixin_ShopWeiXinConfig
        {
            get
            {
                return base.GetTable<ShopNum1MultiEntity.ShopNum1_Weixin_ShopWeiXinConfig>();
            }
        }

        public Table<ShopNum1_ZtcApply> ShopNum1_ZtcApplies
        {
            get
            {
                return base.GetTable<ShopNum1_ZtcApply>();
            }
        }

        public Table<ShopNum1MultiEntity.ShopNum1_ZtcGoods> ShopNum1_ZtcGoods
        {
            get
            {
                return base.GetTable<ShopNum1MultiEntity.ShopNum1_ZtcGoods>();
            }
        }
    }
}

