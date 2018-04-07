<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<div class="help_search">
    <table border="0" cellpadding="0" cellspacing="0" class="help_tab">
        <tbody>
            <tr>
                <td>
                    <span class="zhao">找帮助</span>
                </td>
                <td>
                    <input name="TextBox1" type="text" id="TextBox1" class="help_input">
                </td>
                <td>
                    <input type="submit" name="Button1" value="" id="Button1" class="helpbtn">
                </td>
                <td align="right">
                <img src="Themes/Skin_Default/Images/help_phone.jpg" />
                </td>
            </tr>
        </tbody>
    </table>
</div>

<div class="help_contents">
<h5>购物流程</h5>
<div class="liuc">
<div class="liuimg"><img src="Themes/Skin_Default/Images/liuc.jpg" /></div>
<div class="yindao">
<h1>快速引导</h1>
<div class="yindaocont">
<dl>
<dt>账号管理</dt>
<dd><a href="#">注册与激活</a>|<a href="#">登录与开通</a>|<a href="#">账户信息维护</a>|<a href="#">港澳台及海外会员</a></dd>
</dl>
<dl>
<dt>我是卖家</dt>
<dd><a href="#">商品发布与开店</a>|<a href="#">出售商品</a>|<a href="#">交易评价</a>|<a href="#">消费者保障服务</a>
<a href="#">卖家工具及服务</a>|<a href="#">卖家考试</a>|<a href="#">卖家活动报名</a>
</dd>
</dl>


<dl>
<dt>退款& 维权举报</dt>
<dd><a href="#">退款管理 </a>|<a href="#">维权管理</a>|<a href="#">举报管理</a>|<a href="#">处罚</a></dd>
</dl>
<dl>
<dt>我是买家</dt>
<dd><a href="#">挑选商品</a>|<a href="#">购买商品</a>|<a href="#">优惠卡券</a>
</dd>
</dl>


<dl>
<dt>特色频道</dt>
<dd><a href="#">淘宝游戏交易平台 </a>|<a href="#">机票/酒店/彩票/旅游</a>|<a href="#">保险</a>|<a href="#">手机淘宝</a>|<a href="#">淘宝充值平台</a>|<a href="#">良无限</a></dd>
</dl>
<dl>
<dt>阿里旺旺</dt>
<dd><a href="#">下载与安装</a>|<a href="#">登录与退出</a>|<a href="#">优惠卡券</a>|<a href="#">联系人中心</a>|<a href="#">常见问题</a>
</dd>
</dl>

<div class="clear"></div>

</div>


</div>

</div>
</div>


<div class="latest_shop" style=" display:none;">
    <div class="article_list">
        <asp:Repeater ID="RepeaterData" runat="server">
            <ItemTemplate>
                <div class="article_title">
                    <%# ((DataRowView)Container.DataItem).Row["Title"]%></div>
                <div class="article_time">
                    时间：<%# Convert.ToDateTime(((DataRowView)Container.DataItem).Row["CreateTime"]).ToString("yyyy-MM-dd")%>&nbsp&nbsp
                    作者：<%# ((DataRowView)Container.DataItem).Row["CreateUser"]%></div>
                <div class="article_detail article_imgcon">
                    <%# Server.HtmlDecode(((DataRowView)Container.DataItem).Row["Remark"].ToString())%>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <!-- 隔开 -->
    <div class="cle" style="width: 700px; height: 8px; line-height: 8px; overflow: hidden;
        font-size: 8px;">
    </div>
</div>
