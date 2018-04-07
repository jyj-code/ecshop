﻿<%@ Control Language="C#"%>
<%@ Import Namespace="ShopNum1.WebControl" %>
<%@ Import Namespace="System.Data" %>
    <asp:Repeater ID="RepeaterShow" runat="server">
    <HeaderTemplate>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="biaod">
    <tr>
        <th colspan="2" scope="col" width="130">店铺资讯评论详细</th>
    </tr>
    </HeaderTemplate>
    <ItemTemplate>
  <tr>
    <td class="bordleft">店铺资讯：</td>
    <td class="bordrig">
        <%#Eval("ShopNewsTitle")%>
    </td>
  </tr>
  <tr>
    <td class="bordleft">店铺：</td>
    <td class="bordrig">
         <%#ShopNum1.MemberWebControl.M_ShopVideoComment.shopname(Eval("ShopID").ToString())%>
    </td>
  </tr>
  <tr style=" display:none">
    <td class="bordleft">评论等级：</td>
    <td class="bordrig">
         <%#ShopNum1.MemberWebControl.M_ShopVideoComment.PJ(Eval("Rank").ToString())%> 
    </td>
  </tr>
  <tr>
    <td class="bordleft">IP地址：</td>
    <td class="bordrig">
         <%#Eval("IPAddress")%> 
    </td>
  </tr>
  <tr>
    <td class="bordleft">评论：</td>
    <td class="bordrig">
         <%#Eval("Content")%> 
    </td>
  </tr>
  <tr>
    <td class="bordleft">评论时间：</td>
    <td class="bordrig">
         <%#Eval("CommentTime")%> 
    </td>
  </tr>
  <tr style=" display:none">
    <td class="bordleft">是否回复：</td>
    <td class="bordrig">
         <%#Eval("IsReply").ToString() == "1" ? "已回复" : "未回复"%> 
    </td>
  </tr>
  <tr style=" display:none">
    <td class="bordleft">回复时间：</td>
    <td class="bordrig">
         <%#Eval("ReplyTime")%> 
    </td>
  </tr>
  <tr style=" display:none">
    <td class="bordleft">回复人：</td>
    <td class="bordrig">
         <%#Eval("ReplyUser")%> 
    </td>
  </tr>
  <tr style=" display:none">
    <td class="bordleft">回复内容：</td>
    <td class="bordrig">
         <%#Eval("ReplyContent")%> 
    </td>
  </tr>
  <tr>
    <td class="bordleft" style="border-bottom: solid 1px #c6dfff;">审核状态：</td>
    <td class="bordrig" style="border-bottom: solid 1px #c6dfff;">
        <%#ShopNum1.MemberWebControl.M_SupplyDemandComment.IsAudit(Eval("IsAudit").ToString())%> 
    </td>
  </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
    </asp:Repeater>
    <div style="text-align:center; margin:20px 0px 50px 0px;" >
       <asp:Button ID="ButtonGoBack" runat="server" Text="返回" CssClass="baocbtn"/>&nbsp;&nbsp;
    </div>

