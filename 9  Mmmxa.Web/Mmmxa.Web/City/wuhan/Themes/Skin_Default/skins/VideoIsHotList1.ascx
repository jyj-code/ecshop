﻿<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="System.Data" %>
<ul class="VideoList">
    <asp:Repeater ID="RepeaterShow" runat="server">
        <ItemTemplate>
            <li>
                <a href='<%# ShopUrlOperate.RetUrlNew("VideoDetail",((DataRowView)Container.DataItem).Row["Guid"] )%>'
                target="_blank" class="VideoImg">
                    <img alt="" width="164px" height="164px" src="<%# ((DataRowView)Container.DataItem).Row["ImgAdd"] %>"
                        onerror="javascript:this.src='../Images/noImage.gif'" />                               
                </a>
                <span class="VideoName"><%# ShopNum1.WebControl.VideoIsRecommendOrNewsList.GetSubstr(((DataRowView)Container.DataItem).Row["Title"],10,false)%></span>
                <span class="VideoNum">播放次数 <%#((DataRowView)Container.DataItem).Row["BroadcastCount"] %></span>
            </li>   
        </ItemTemplate>
    </asp:Repeater>
</ul>