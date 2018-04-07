<%@ WebHandler Language="C#" Class="ThreeClassify" %>

using System;
using System.Web;
using ShopNum1MultiEntity;
using ShopNum1.BusinessLogic;
using ShopNum1.Interface;
using ShopNum1.Common;
using System.Data;
public class ThreeClassify : IHttpHandler
{
    public void ProcessRequest (HttpContext context) {

        try
        {
            if (Common.ReqStr("type") != "")
            {
                string strType = Common.ReqStr("type");//类型
                string FatherID = Common.ReqStr("FatherID");//父ID
                
                
                switch (strType)
                {
                    case "SupplyDemandCategory"://供求分类
                        context.Response.Write(GetSupplyDemandCategory(FatherID));
                        break;
                    case "RegionCode"://地区
                        context.Response.Write(GetRegion(FatherID));
                        break;

                    case "SignIn"://签到
                        context.Response.Write(SignIn());
                        break;
                }
            }
        }
        catch { context.Response.Write("error"); }
    }

    void UpdateRankScore(int Score, int RankScore, string MemLoginID)
    {
        string vScore = Common.GetNameById("cast(memberrank as varchar)+'-'+cast(score as varchar)", "shopnum1_member", " and memloginid='" + MemLoginID + "'");
        int currentscore = 0, rankscore = 0;
        if (vScore != "" && vScore.IndexOf("-") != -1)
        {
            currentscore = Convert.ToInt32(vScore.Split('-')[1]);
            rankscore = Convert.ToInt32(vScore.Split('-')[0]);
        }
        if (Score > 0)
        {
            ShopNum1_ScoreModifyLog ScoreModifyLog = new ShopNum1_ScoreModifyLog();
            ScoreModifyLog.Guid = Guid.NewGuid();
            ScoreModifyLog.OperateType = 1;
            ScoreModifyLog.CurrentScore = (currentscore - Score);
            ScoreModifyLog.OperateScore = Score;
            ScoreModifyLog.LastOperateScore = currentscore;
            ScoreModifyLog.Date = System.DateTime.Now;
            ScoreModifyLog.Memo = "签到送消费积分";
            ScoreModifyLog.MemLoginID = MemLoginID;
            ScoreModifyLog.CreateUser = MemLoginID;
            ScoreModifyLog.CreateTime = System.DateTime.Now;
            ScoreModifyLog.IsDeleted = 0;
            ShopNum1_ScoreModifyLog_Action shopNum1_ScoreModifyLog = (ShopNum1_ScoreModifyLog_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ScoreModifyLog_Action();
            shopNum1_ScoreModifyLog.OperateScore(ScoreModifyLog);
        }
        //等级积分
        if (RankScore > 0)
        {
            ShopNum1_RankScoreModifyLog RankScoreModifyLog = new ShopNum1_RankScoreModifyLog();
            RankScoreModifyLog.Guid = Guid.NewGuid();
            RankScoreModifyLog.OperateType = 1;
            RankScoreModifyLog.CurrentScore = (rankscore - RankScore);
            RankScoreModifyLog.OperateScore = RankScore;
            RankScoreModifyLog.LastOperateScore = rankscore;
            RankScoreModifyLog.Date = System.DateTime.Now;
            RankScoreModifyLog.Memo = "签到送等级积分";
            RankScoreModifyLog.MemLoginID = MemLoginID;
            RankScoreModifyLog.CreateUser = MemLoginID;
            RankScoreModifyLog.CreateTime = System.DateTime.Now;
            RankScoreModifyLog.IsDeleted = 0;
            ShopNum1_RankScoreModifyLog_Action RankScoreModifyLog_Action = (ShopNum1_RankScoreModifyLog_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_RankScoreModifyLog_Action();
            RankScoreModifyLog_Action.OperateScore(RankScoreModifyLog);
        }
    }
    
    
    public bool SignInBool(string MemberLoginID)
    {
        ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
        ShopNum1MultiEntity.ShopNum1_SignIn signIn = new ShopNum1MultiEntity.ShopNum1_SignIn();
        signIn.guid = Guid.NewGuid();
        signIn.CreateTime = DateTime.Now;
        signIn.MemLoginID = MemberLoginID;
        int check = member_Action.AddSignin(signIn);
        if (check > 0)
        {
            //签到成功
            string SignOrSendScore = ShopSettings.GetValue("SignOrSendScore");//签到是否送积分 0表示不送积分，1表示送积分 
            string strRankScore = ShopSettings.GetValue("SignRankScore");//等级积分
            string strSignScore = ShopSettings.GetValue("SignScore");//消费积分

            //送积分
            if (!string.IsNullOrEmpty(SignOrSendScore) && int.Parse(SignOrSendScore) == 1)
            {
                member_Action.UpdateMemberScore(MemberLoginID, Convert.ToInt32(strRankScore), Convert.ToInt32(strSignScore));
                UpdateRankScore(Convert.ToInt32(strSignScore), Convert.ToInt32(strRankScore), MemberLoginID);
            }
            return  true;
        }
        return false;
    }
    
    
    //签到
    public string SignIn()
    {
        HttpCookie cookieShopMemberLogin = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
        HttpCookie decodedCookieShopMemberLogin = HttpSecureCookie.Decode(cookieShopMemberLogin);
        //会员登录ID
        string MemberLoginID = decodedCookieShopMemberLogin.Values["MemLoginID"].ToString();
        ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
        //判断今天是否签到过
        string dayTime = DateTime.Now.ToString("yyyy-MM-dd");
        DataTable dataTable = member_Action.CheckSignin(MemberLoginID, dayTime);
        if (dataTable != null && dataTable.Rows.Count != 0)
        {
            if (Convert.ToInt32(dataTable.Rows[0]["count"]) > 0)
            {
                return "have";
            }
            else
            {
                string SignOrSendScore = ShopSettings.GetValue("SignOrSendScore");//签到是否送积分 0表示不送积分，1表示送积分 
                string strRankScore = ShopSettings.GetValue("SignRankScore");//等级积分
                string strSignScore = ShopSettings.GetValue("SignScore");//消费积分
                if(SignOrSendScore=="1")
                {
                    if (SignInBool(MemberLoginID))
                    {
                        return "true|" + strSignScore + "|" + strRankScore;
                    }
                    else
                    {
                        return "true";
                    }
                }
                
                return "false";
            }
        }
        else
        {
            if (SignInBool(MemberLoginID))
            {
                return "true";
            }
            return "false";
        }
        return "false";
        
    }
    
    
    


    public string GetRegion(string FatherID)
    {
        ShopNum1_Region_Action Region_Action = (ShopNum1_Region_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Region_Action();
        DataTable dataTable = Region_Action.SearchtRegionCategory(Convert.ToInt32(FatherID), 0);
        string strString = string.Empty;
        strString = "<option value=\"-1\">-请选择-</option>";
        if (dataTable != null && dataTable.Rows.Count > 0)
        {
            foreach (DataRow dr in dataTable.Rows)
            {
                strString += "<option value=\"" + dr["ID"].ToString() + "|" + dr["Code"].ToString() + "\">" + dr["Name"].ToString() + "</option>";
            }
        }
        return strString;
    }
    
    
    
    
    /// <summary>
    /// 供求分类
    /// </summary>
    /// <param name="FatherID"></param>
    /// <returns></returns>
    public string GetSupplyDemandCategory(string FatherID)
    {
        ShopNum1_SupplyDemandCategory_Action SupplyDemandCategory_Action = (ShopNum1_SupplyDemandCategory_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_SupplyDemandCategory_Action();
        DataTable dataTable = SupplyDemandCategory_Action.GetDataByFatherID(FatherID);
        string strString = string.Empty;
        strString = "<option value=\"-1\">-请选择-</option>";
        if (dataTable != null && dataTable.Rows.Count>0)
        {
            foreach (DataRow dr in dataTable.Rows)
            {
                strString += "<option value=" + dr["ID"].ToString() + "|" + dr["Code"].ToString() + ">" + dr["Name"].ToString() + "</option>";
            }
        }
        return strString;
    }
   
    public bool IsReusable {
        get {
            return false;
        }
    }

}