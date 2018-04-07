<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<div class="supply_demand_left">
    <div style="display: block;" class="supply_demand_left_img">
            
            <ShopNum1:AdSimpleImage id="AdSimpleImage4" runat="server" AdImgId="18" SkinFilename="AdSimpleImage.ascx"/>        
      
            <ShopNum1:AdSimpleImage id="AdSimpleImage1" runat="server" AdImgId="19" SkinFilename="AdSimpleImageTitlethree.ascx"/> 
        
            <ShopNum1:AdSimpleImage id="AdSimpleImage2" runat="server" AdImgId="20" SkinFilename="AdSimpleImageTitlethree.ascx"/> 
    </div>
</div>
<div class="supply_demand_right fr">
    <div class="supply_demand_right_top supply_demand_right_top1">
        <span class="boldfont "><a href="javascript:void(0)">· 2011夏天变身法式优雅</a> <a href="javascript:void(0)">· 美女抢眼睛搭配！平日也要度假风</a></span><br />
        <a href="javascript:void(0)">· 甜辣小妖精穿出妩媚S线</a> <a href="javascript:void(0)">· 6天造无敌美腿</a> <a href="javascript:void(0)">· 夏日清凉白色衣怎么穿不单调</a>
    </div>
    <div class="supply_demand_right_middle cle" style="float: left; clear: both;">
        <div class="supply_demand_right_middle_leftlist fl">
            <ul>
                <asp:Repeater ID="RepeaterData1" runat="server">
                    <ItemTemplate>
                        <li>· <a href='<%# ShopUrlOperate.RetUrl("ArticleDetail",((DataRowView)Container.DataItem).Row["Guid"]) %>'
                            target="_blank" title='<%# ((DataRowView)Container.DataItem).Row["Title"] %>'>
                            <%# ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["Title"].ToString(),32,"")%>
                        </a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div class="supply_demand_right_middle_leftlist fr">
            <ul>
                <asp:Repeater ID="RepeaterData2" runat="server">
                    <ItemTemplate>
                        <li>· <a href='<%# ShopUrlOperate.RetUrl("ArticleDetail",((DataRowView)Container.DataItem).Row["Guid"]) %>' target="_blank" title='<%# ((DataRowView)Container.DataItem).Row["Title"] %>'>
                         <%# ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["Title"].ToString(),32,"")%>
                            </a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>
    <div class="supply_demand_right_bottom cle fl">
        <div class="dpkt" style="clear: both; width: 465px">
            <div class="dpkt_top fl" style="width: 445px; background: #c2dbe2;">
                <span class="fl red">搭配课堂</span> <span class="fr"></span>
            </div>
            <div class="supply_demand_right_middle_leftlist fl" style="width: 200px;">
                <ul>
                    <asp:Repeater ID="RepeaterData3" runat="server">
                        <ItemTemplate>
                            <li>· <a href='<%# ShopUrlOperate.RetUrl("ArticleDetail",((DataRowView)Container.DataItem).Row["Guid"]) %>' target="_blank" title='<%# ((DataRowView)Container.DataItem).Row["Title"] %>'>
                             <%# ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["Title"].ToString(),30,"")%>
                              </a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
            <ShopNum1:AdSimpleImage id="AdSimpleImage3" runat="server" AdImgId="21" SkinFilename="AdSimpleImageTitleFour.ascx"/> 
        </div>
    </div>
</div>
