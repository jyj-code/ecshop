<%@ Control Language="C#" %>
<!--左边导航nav-->
<div id="left">
    <div id="left_top">
    </div>
    <div class="sdmenu">
        <div id="ti01" onclick="te_show(1,this)">
            <span class="fh1 fh">交易管理</span></div>
        <div id="te01" style="display: block;" class="lmf_submenu">
            <a target="win" href="S_Order_List.aspx" onclick="subItem(this)" class="lmf_act">订单管理</a>
            <%--            <a target="win" href="S_SaleOrder_List.aspx" onclick="subItem(this)" class="lmf_act">促销订单</a>--%>
            <a target="win" href="S_LifeOrder_List.aspx" onclick="subItem(this)" class="lmf_act">
                生活服务订单管理</a> 
                <a target="win" href="S_CreditHonor.aspx?type=1" onclick="subItem(this)" class="lmf_act">
                    评价管理</a>
        </div>
        <div id="ti03" onclick="te_show(3,this)">
            <span class="fh3 fh">商品管理</span></div>
        <div id="te03" style="display: block;" class="lmf_submenu">
            <a target="win" href="S_ProductCategory.aspx" onclick="subItem(this)" class="lmf_act">
                店铺商品分类</a> <a target="win" href="S_PageGo.aspx?pagetype=0" onclick="subItem(this)"
                    class="lmf_act">发布商品</a> <a target="win" href="S_SellProduct.aspx" onclick="subItem(this)"
                        class="lmf_act">出售中的商品</a> <a target="win" href="S_StoreProduct.aspx" onclick="subItem(this)"
                            class="lmf_act">仓库中的商品</a> <a target="win" href="S_UnAuditProduct.aspx" onclick="subItem(this)"
                                class="lmf_act">待审核的商品</a><a target="win" href="S_RepertoryAlertProduct.aspx" onclick="subItem(this)"
                                class="lmf_act">库存预警</a>
            <%--             <a target="win" href="S_Import.aspx" onclick="subItem(this)" class="lmf_act">商品导出</a>--%>
            <a target="win" href="S_Import.aspx" onclick="subItem(this)" class="lmf_act">淘宝数据包导入</a>
            <a target="win" href="S_PaipaiImport.aspx" onclick="subItem(this)" class="lmf_act">拍拍数据包导入</a>
            <a target="win" href="S_YiquImport.aspx" onclick="subItem(this)" class="lmf_act">易趣数据包导入</a>
        </div>
        <div id="ti04" onclick="te_show(4,this)">
            <span class="fh4 fh">促销管理</span></div>
        <div id="te04" style="display: block;" class="lmf_submenu">
            <a target="win" href="S_GroupProduct.aspx" onclick="subItem(this)" class="lmf_act">团购商品</a>
            <a target="win" href="S_Limit_ActivityList.aspx" onclick="subItem(this)" class="lmf_act">
                限时折扣</a><a target="win" href="S_ThemeList.aspx" onclick="subItem(this)" class="lmf_act">主题活动商品</a>
                 <a target="win" href="S_PackAgeList.aspx" onclick="subItem(this)" class="lmf_act">
                    组合套餐</a> <a target="win" href="S_ZtcApply_List.aspx" onclick="subItem(this)" class="lmf_act">
                        直通车申请</a> <a target="win" href="S_ZtcGoods_List.aspx" onclick="subItem(this)" class="lmf_act">
                            直通车列表</a>
        </div>
        <div id="ti05" onclick="te_show(5,this)">
            <span class="fh5 fh">店铺管理</span></div>
        <div id="te05" style="display: none;" class="lmf_submenu">
            <a target="_blank" href="S_ShowMyShop.aspx" onclick="subItem(this)" class="lmf_act">
                查看我的店铺</a> <a target="win" href="S_ShopInfo.aspx?type=0" onclick="subItem(this)"
                    class="lmf_act">店铺信息</a> <a target="win" href="S_ShowPaymentType.aspx" onclick="subItem(this)"
                        class="lmf_act">店铺支付方式</a> <a target="win" href="S_OnLineServiceList.aspx" onclick="subItem(this)"
                            class="lmf_act">客服管理</a>
                            <a target="win" href="S_ApplyShopCategory.aspx" onclick="subItem(this)"
                            class="lmf_act">申请修改分类</a>
        </div>
        <div id="ti06" onclick="te_show(6,this)">
            <span class="fh6 fh">店铺装修</span></div>
        <div id="te06" style="display: none;" class="lmf_submenu">
            <a target="win" href="S_SkinSelect.aspx" onclick="subItem(this)" class="lmf_act">店铺可用模版</a>
            <a target="win" href="S_SkinBackup.aspx" onclick="subItem(this)" class="lmf_act">店铺模版备份</a>
            <a target="win" href="S_AdvertisementList.aspx" onclick="subItem(this)" class="lmf_act">
                页面广告</a> <a target="win" href="S_UserDefinedColumnList.aspx" onclick="subItem(this)"
                    class="lmf_act">前台导航栏</a>
        </div>
        <div id="ti02" onclick="te_show(2,this)">
            <span class="fh2 fh">物流管理</span></div>
        <div id="te02" style="display: none;" class="lmf_submenu">
            <a target="win" href="S_Logistics.aspx" onclick="subItem(this)" class="lmf_act">邮费模版</a>
            <a target="win" href="S_OrderShipper_List.aspx" onclick="subItem(this)" class="lmf_act">
                发货信息列表</a>
            <a target="win" href="S_OrderExpress_List.aspx" onclick="subItem(this)" class="lmf_act">
                快递单列表</a>
            <a target="win" href="s_tuihdz.html" onclick="subItem(this)" class="lmf_act" style="display: none;">
                退货地址</a>
        </div>
        <div id="ti07" onclick="te_show(7,this)">
            <span class="fh7 fh">营销管理</span></div>
        <div id="te07" style="display: none" class="lmf_submenu">
            <a target="win" href="S_ShopURLManage.aspx" onclick="subItem(this)" class="lmf_act">
                店铺域名</a> <a target="win" href="S_ShopNewsCategory.aspx" onclick="subItem(this)" class="lmf_act">
                    资讯分类</a> <a target="win" href="S_ShopNews.aspx" onclick="subItem(this)" class="lmf_act">
                        资讯管理</a> <a target="win" href="S_ShopVideoCategory.aspx" onclick="subItem(this)"
                            class="lmf_act">视频分类</a> <a target="win" href="S_ShopVideo.aspx" onclick="subItem(this)"
                                class="lmf_act">视频管理</a> <a target="win" href="S_ShopLink.aspx" onclick="subItem(this)"
                                    class="lmf_act">友情链接</a> <a target="win" href="S_ShopSEOManage.aspx" onclick="subItem(this)"
                                        class="lmf_act">SEO设置</a> <a target="win" href="S_ShopCoupon.aspx" onclick="subItem(this)"
                                            class="lmf_act">优惠券管理</a>
                                            <a target="win" href="S_TerracePayList.aspx" onclick="subItem(this)"
                                            class="lmf_act">付费广告</a>
            <%--<a target="win" href="s_yinxiao.html" onclick="subItem(this)" class="lmf_act">商品营销</a>--%>
        </div>
        <asp:Panel ID="PanelScroe" runat="server">
            <div id="ti08" onclick="te_show(8,this)">
                <span class="fh8 fh">积分商城</span></div>
            <div id="te08" style="display: none;" class="lmf_submenu">
                <a target="win" href="/shop/ShopAdmin/S_ScoreOrder_List.aspx" onclick="subItem(this)"
                    class="lmf_act" runat="server" id="ScoreOrder">积分订单</a> <a target="win" href="/shop/ShopAdmin/S_ScoreProduct.aspx?type=1"
                        onclick="subItem(this)" class="lmf_act" runat="server" id="ScoreProduct">积分商品</a>
                <%--<a target="win" href="s_yinxiao.html" onclick="subItem(this)" class="lmf_act">商品营销</a>--%>
            </div>
        </asp:Panel>
        <div id="ti09" onclick="te_show(9,this)">
            <span class="fh9 fh">淘宝互通</span></div>
        <div id="te09" style="display: none;" class="lmf_submenu">
            <a target="win" href="S_PageGo.aspx?pagetype=1" onclick="subItem(this)" class="lmf_act">
                淘宝同步授权</a> <a target="win" href="S_PageGo.aspx?pagetype=2" onclick="subItem(this)"
                    class="lmf_act">淘宝同步设置</a> <a target="win" href="S_PageGo.aspx?pagetype=3" onclick="subItem(this)"
                        class="lmf_act">本地商品分类</a> <a target="win" href="S_PageGo.aspx?pagetype=4" onclick="subItem(this)"
                            class="lmf_act">淘宝数据导入</a> <a target="win" href="S_PageGo.aspx?pagetype=5" onclick="subItem(this)"
                                class="lmf_act">查看淘宝商品</a> <a target="win" href="S_PageGo.aspx?pagetype=6" onclick="subItem(this)"
                                    class="lmf_act">查看淘宝订单</a> <a target="win" href="S_PageGo.aspx?pagetype=7" onclick="subItem(this)"
                                        class="lmf_act">删除淘宝绑定</a> <a target="win" href="S_PageGo.aspx?pagetype=8" onclick="subItem(this)"
                                            class="lmf_act">淘宝TOP参数</a>
        </div>
        <div id="ti010" onclick="te_show(10,this)">
            <span class="fh10 fh">店铺统计</span></div>
        <div id="te010" style="display: none;" class="lmf_submenu lmf_submenu1">
            <a target="win" href="S_SeeBuyRate.aspx" onclick="subItem(this)" class="lmf_act">商品访问统计
            </a><a target="win" href="S_StockReport.aspx#gone" onclick="subItem(this)" class="lmf_act">
                库存报表</a> <a target="win" href="S_ShopSellOrder.aspx" onclick="subItem(this)" class="lmf_act">
                    销售排行</a>
        </div>
        <div id="ti011" onclick="te_show(11,this)">
            <span class="fh11 fh">图片管理</span></div>
        <div id="te011" style="display: none;" class="lmf_submenu lmf_submenu1">
            <a target="win" href="S_Album.aspx" onclick="subItem(this)" class="lmf_act">图片空间</a>
        </div>
        <div id="ti012" onclick="te_show(12,this)">
            <span class="fh12 fh">客户服务</span></div>
        <div id="te012" style="display: none;" class="lmf_submenu lmf_submenu1">
            <a target="win" href="S_EnsureApplyRecordList.aspx" onclick="subItem(this)" class="lmf_act">
                消费者保障服务</a> <a target="win" href="S_ExitManage.aspx" onclick="subItem(this)" class="lmf_act">
                    退款管理</a>  <a target="win" href="S_ExitGoods.aspx" onclick="subItem(this)" class="lmf_act">
                    退货管理</a> <a target="win" href="S_MessageBoardList.aspx" onclick="subItem(this)" class="lmf_act">
                        店铺留言回复</a> <a target="win" href="S_ProductMessageBoardList.aspx" onclick="subItem(this)"
                            class="lmf_act">商品留言</a> <a target="win" href="S_MemberReport.aspx" onclick="subItem(this)"
                                class="lmf_act">举报管理</a> <a target="win" href="S_OrderComplaints.aspx" onclick="subItem(this)"
                                    class="lmf_act">投诉管理</a>
                                    <a target="win" href="S_SearchTicket.aspx" onclick="subItem(this)" class="lmf_act">发票查询</a>
            <%-- <a target="win" href="S_ProductBookingList.aspx" onclick="subItem(this)" class="lmf_act">预约管理</a>--%>
        </div>
        
         <div id="ti013" onclick="te_show(13,this)">
            <span class="fhweixin fh">微信设置</span></div>
        <div id="te013" style="display: none;" class="lmf_submenu lmf_submenu1">
        <asp:Panel ID="panShowWeixin" runat="server">
            <a target="win" href="W_ShopUser.aspx" onclick="subItem(this)" class="lmf_act">个人信息</a>
            <a target="win" href="W_ShopMember.aspx" onclick="subItem(this)" class="lmf_act">微信用户</a>
            <a target="win" href="W_ShopApiConfig.aspx" onclick="subItem(this)" class="lmf_act">
                默认设置</a> <a target="win" href="W_ShopReplyTextList.aspx" onclick="subItem(this)"
                    class="lmf_act">文字回复</a> <a target="win" href="W_ShopReplyImgTxtList.aspx" onclick="subItem(this)"
                        class="lmf_act">图文回复</a><a target="win" href="W_ShopMenu.aspx" onclick="subItem(this)"
                            class="lmf_act">自定义菜单</a><a target="win" href="W_ShopWeiXinApiConfig.aspx" onclick="subItem(this)"
                                class="lmf_act">微信设置</a><a target="win" href="W_ShopConfig.aspx" onclick="subItem(this)"
                                    class="lmf_act">wap配置</a></asp:Panel>
        </div>
    </div>
    <div id="left_bot">
    </div>
</div>
