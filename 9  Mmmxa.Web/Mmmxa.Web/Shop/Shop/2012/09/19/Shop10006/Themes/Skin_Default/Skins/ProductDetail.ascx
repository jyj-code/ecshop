<%@ Control Language="C#" EnableViewState="false"%>
<%@ Import Namespace="ShopNum1.ShopWebControl" %>
<%@ Import Namespace="System.Data" %>
<input type="hidden" id="hidgotoId" />
<div class="detail">
    <div class="DetailImage">
        <h1 class="title">
            <span><asp:Label ID="LabelName" runat="server"></asp:Label></span>
        </h1>
        <div class="content">
            <!--预览图片-->
            <div class="ProductImg fl">
                <div id="preview">
                    <div id="spec-n1" class="jqzoom">
                         <asp:Literal ID="lblProductImgUrl" runat="server"></asp:Literal>
                     </div>
                    <div class="clear"></div>
                    <div id="spec-n5" class="tb_thumb">
                        <div id="tb_gallery" class="tb_gallery">
                             <ul class="list-h">
                                 <asp:Repeater ID="RepeaterDateImage" runat="server">
                                    <ItemTemplate>
                                        <li class="tb_diply">
                                            <div class="tb-pic tb-stn">
                                              <a><img id="Img1" height="60" width="60" runat="server" src='<%# Eval("imgurl")+"_60x60.jpg" %>' onerror="javascript:this.src='/ImgUpload/noImg.jpg_60x60.jpg'"  lang='<%# Eval("imgurl")%>' /></a>  
                                            </div>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
            <!--购买详情-->
            <div class="BuyInfo fr"> <input type="hidden" runat="server" id="hidSaleType" value="0"/>
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td class="collection" colspan="2">
                            <span class="enshrine">
                                <asp:Button ID="ButtonCollect" runat="server" title="收藏该商品" Text="收藏该商品" OnClientClick="return loadLogin();"  CssClass="sc" />
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td class="NameWid">市 场 价：</td>
                        <td class="MarketPrice">
                            <b>￥
                            <asp:Label ID="LabelMarketPrice" runat="server"></asp:Label>
                            </b>元
                        </td>
                    </tr>
                    <tr id="trShopPrice" runat="server">
                        <td><asp:Label ID="lblPriceTxt" runat="server" Text="本 店 价："></asp:Label></td>
                        <td class="ShopPrice">
                            ￥<asp:Label ID="LabelShopPrice" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trDisCount" runat="server" visible="false">
                        <td>参加促销：</td>
                        <td>
                            <input type="hidden" runat="server" id="hidDisCount" />
                            <span id="spansaletxt" runat="server" class="disCount" style="color:White; background:red;">限时折扣</span>
                            <strong style="margin-right: 6px;"><b class="jg_store">￥<asp:Label ID="lblPromotionPrice" runat="server"></asp:Label></b></strong>
                            <asp:Label ID="lblTipDisCount" runat="server" Visible="false"></asp:Label><span id="spTimego"><asp:Literal ID="literTime" runat="server"></asp:Literal></span>
                        </td>
                    </tr>
                    <tr>
                        <td>品&nbsp;&nbsp;&nbsp;&nbsp;牌：</td>
                        <td class="freight">
                            <asp:Label ID="lblBrand" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="cellFee1" runat="server">
                        <td>运&nbsp;&nbsp;&nbsp;&nbsp;费：</td>
                        <td class="freight">
                            <asp:Label ID="lblFee" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="cellFee2" runat="server">
                        <td>配&nbsp;&nbsp;&nbsp;&nbsp;送：</td>
                        <td>
                            <div class="area_tn">
                                至
                                <a href="javascript:ShowHideRegion('show')" id="ahrefregionname">全国</a>
                                <img class="jiantou" src="Themes/Skin_Default/Images/dp_bg.png" alt="xl" onclick="javascript:ShowHideRegion('show')" />
                                <!--物流-->
                                <div id="divProvinceRegion" class="SelectAera">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr> 
                                            <td>
                                                <a href="javascript:void(0)" title="所有地区" code="000">全国<s></s></a>
                                            </td>
                                            <td>
                                                <a href="javascript:void(0)" title="北京市" code="001">北京<s></s></a>
                                            </td>
                                            <td>
                                                <a href="javascript:void(0)" title="天津市" code="002">天津<s></s></a>
                                            </td>
                                            <td>
                                                <a href="javascript:void(0)" title="河北省" code="003">河北<s></s></a>
                                            </td>
                                        </tr>
                                        <tr style="display:none;">
                                            <td colspan="4">
                                                <div class="SubArea clearfix">
                                                    <a>全国</a><a>全国</a><a>全国</a><a>全国</a><a>全国</a><a>全国</a>
                                                    <a>全国</a><a>全国</a><a>全国</a><a>全国</a><a>全国</a><a>全国</a><a>全国</a>
                                                    <a>全国</a><a>全国</a><a>全国</a><a>全国</a><a>全国</a>
                                                </div>
                                                <div class="SubArea clearfix">
                                                    <a>全国</a><a>全国</a><a>全国</a><a>全国</a><a>全国</a><a>全国</a>
                                                    <a>全国</a><a>全国</a><a>全国</a><a>全国</a><a>全国</a><a>全国</a><a>全国</a>
                                                    <a>全国</a><a>全国</a><a>全国</a><a>全国</a><a>全国</a>
                                                </div>
                                                <div class="SubArea clearfix">
                                                    <a>全国</a><a>全国</a><a>全国</a><a>全国</a><a>全国</a><a>全国</a>
                                                    <a>全国</a><a>全国</a><a>全国</a><a>全国</a><a>全国</a><a>全国</a><a>全国</a>
                                                    <a>全国</a><a>全国</a><a>全国</a><a>全国</a><a>全国</a>
                                                </div>
                                                <div class="SubArea clearfix">
                                                    <a>全国</a><a>全国</a><a>全国</a><a>全国</a><a>全国</a><a>全国</a>
                                                    <a>全国</a><a>全国</a><a>全国</a><a>全国</a><a>全国</a><a>全国</a><a>全国</a>
                                                    <a>全国</a><a>全国</a><a>全国</a><a>全国</a><a>全国</a>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <a href="javascript:void(0)" title="山西省" code="004">山西<s></s></a>
                                            </td>
                                            <td>
                                                <a href="javascript:void(0)" title="内蒙古区" code="005">内蒙古<s></s></a>
                                            </td>
                                            <td>
                                                <a href="javascript:void(0)" title="辽宁省" code="006">辽宁<s></s></a>
                                            </td>
                                            <td>
                                                <a href="javascript:void(0)" title="吉林省" code="007">吉林<s></s></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <a href="javascript:void(0)" title="黑龙江省" code="008">黑龙江<s></s></a>
                                            </td>
                                            <td>
                                                <a href="javascript:void(0)" title="上海市" code="009">上海<s></s></a>
                                            </td>
                                            <td>
                                                <a href="javascript:void(0)" title="江苏省" code="010">江苏<s></s></a>
                                            </td>
                                            <td>
                                                <a href="javascript:void(0)" title="浙江省" code="011">浙江<s></s></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <a href="javascript:void(0)" title="安徽省" code="012">安徽<s></s></a>
                                            </td>
                                            <td>
                                                <a href="javascript:void(0)" title="福建省" code="013">福建<s></s></a>
                                            </td>
                                            <td>
                                                <a href="javascript:void(0)" title="江西省" code="014">江西<s></s></a>
                                            </td>
                                            <td>
                                                <a href="javascript:void(0)" title="山东省" code="015">山东<s></s></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <a href="javascript:void(0)" title="河南省" code="016">河南<s></s></a>
                                            </td>
                                            <td>
                                                <a href="javascript:void(0)" title="湖北省" code="017">湖北<s></s></a>
                                            </td>
                                            <td>
                                                <a href="javascript:void(0)" title="湖南省" code="018">湖南<s></s></a>
                                            </td>
                                            <td>
                                                <a href="javascript:void(0)" title="广东省" code="019">广东<s></s></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <a href="javascript:void(0)" title="广西区" code="020">广西<s></s></a>
                                            </td>
                                            <td>
                                                <a href="javascript:void(0)" title="海南省" code="021">海南<s></s></a>
                                            </td>
                                            <td>
                                                <a href="javascript:void(0)" title="重庆市" code="022">重庆市<s></s></a>
                                            </td>
                                            <td>
                                                <a href="javascript:void(0)" title="四川省" code="023">四川<s></s></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <a href="javascript:void(0)" title="贵州省" code="024">贵州<s></s></a>
                                            </td>
                                            <td>
                                                <a href="javascript:void(0)" title="云南省" code="025">云南<s></s></a>
                                            </td>
                                            <td>
                                                <a href="javascript:void(0)" title="西藏区" code="026">西藏<s></s></a>
                                            </td>
                                            <td>
                                                <a href="javascript:void(0)" title="陕西省" code="027">陕西<s></s></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <a href="javascript:void(0)" title="甘肃省" code="028">甘肃<s></s></a>
                                            </td>
                                            <td>
                                                <a href="javascript:void(0)" title="青海省" code="029">青海<s></s></a>
                                            </td>
                                            <td>
                                                <a href="javascript:void(0)" title="宁夏区" code="030">宁夏<s></s></a>
                                            </td>
                                            <td>
                                                <a href="javascript:void(0)" title="新疆区" code="031">新疆<s></s></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <a href="javascript:void(0)" title="台湾省" code="032">台湾<s></s></a>
                                            </td>
                                            <td>
                                                <a href="javascript:void(0)" title="香港特区" code="033">香港<s></s></a>
                                            </td>
                                            <td>
                                                <a href="javascript:void(0)" title="澳门特区" code="034">澳门<s></s></a>
                                            </td>
                                            <td>
                                                <a href="javascript:void(0)" title="海外" code="035">海外<s></s></a>
                                            </td>
                                        </tr>
                                    </table>                                                
                                </div>
                            </div>
                            <span id="spanFee" class="stamp_tn">
                                <asp:Label ID="LabelPost" runat="server" Text='平邮' Visible="false"></asp:Label>
                                <asp:Label ID="LabelPost_Fee" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="LabelExpress" runat="server" Text='快递' Visible="false"></asp:Label>
                                <asp:Label ID="LabelExpress_fee" runat="server"   Visible="false"></asp:Label>
                                <asp:Label ID="LabelEms" runat="server" Text='EMS' Visible="false"></asp:Label>
                                <asp:Label ID="LabelEms_fee" runat="server" Visible="false"></asp:Label>
                            </span>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td>购物返积分：</td>
                        <td>
                            <span style="color: #3C3C3C; font-size: 12px; width: 150px;"></span><span style="color: #D40000;font-size: 13px;"></span>分/<asp:Label ID="lblUnitName" runat="server"></asp:Label>
                            <span style="color: #3C3C3C; font-size: 12px; width: 150px;">单 &nbsp;&nbsp; 位</span>：
                           <%=lblUnitName.Text==""?"件":lblUnitName.Text%>
                        </td>
                    </tr>
                    <tr>
                        <td>累计售出：</td>
                        <td class="stock">
                            <span class="scan"><asp:Label ID="lblSaleNumber" runat="server" ForeColor="Green"></asp:Label></span><%=lblUnitName.Text==""?"件":lblUnitName.Text%>
                        </td>
                    </tr>
                    <tr>
                        <td>浏览次数：</td>
                        <td>
                            <span class="scan"><asp:Label ID="lblClickCount" runat="server"></asp:Label>次
                        </td>
                    </tr>
                    <tr>
                        <td>收&nbsp;&nbsp;&nbsp;&nbsp;藏：</td>
                        <td>
                            <span class="stow"><asp:Label ID="lblCollectCount" runat="server"></asp:Label></span>次
                        </td>
                    </tr>
                    <tr>
                        <td>数&nbsp;&nbsp;&nbsp;&nbsp;量：</td>
                        <td>
                            <dl class="BuyingNum clearfix">
                                <dd class="clearfix">
                                    <span class="decrease"></span> 
                                    <asp:TextBox ID="TextBoxBuyNum" CssClass="amount_widget" runat="server" Text="1" />
                                    <span class="increase"></span>
                                    库存<asp:Label ID="LabelRepertoryCount" CssClass="storage" runat="server"></asp:Label><%=lblUnitName.Text==""?"件":lblUnitName.Text%>
                                </dd>
                            </dl>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <%if (RepeaterProductSepc.Items.Count == 0) { hideSpecDiv.Visible = false; } %>
                            <div class="restrict errorselect" id="hideSpecDiv" runat="server">
                                <asp:Repeater ID="RepeaterProductSepc" runat="server" EnableViewState="false">
                                    <ItemTemplate>
                                        <dl class="tb_prop clearfix">
                                            <dt>
                                                <%#((DataRowView)Container.DataItem).Row["specname"]%>：</dt>
                                            <dd>
                                                <ul>
                                                    <asp:Repeater ID="RepeaterProductSepcDetail" runat="server" EnableViewState="false">
                                                        <ItemTemplate>
                                                            <li specvalue='<%#Eval("SpecDetailName")%>' spc='<%#Eval("SpecDetail")%>' spcv='<%#Eval("SpecDetailv")%>'>
                                                            <a href="javascript:void(0)">
                                                                <input type="hidden" name="hidImgPath" value='<%#Eval("ImagePath")%>' />
                                                                <input type="hidden" name="hidProductImg" value='<%#Eval("productimage")%>' />
                                                                <input type="hidden" name="hidSpecValueName" value='<%#Eval("SpecValueName") %>' />
                                                                <span>
                                                                  <%--  <%#((DataRowView)Container.DataItem).Row["productimage"].ToString() != "" ? "<img src='" + ((DataRowView)Container.DataItem).Row["productimage"] + "_25x25.jpg' lang='" + ((DataRowView)Container.DataItem).Row["productimage"] + "' width=\"25\" height=\"25\" title='" + ((DataRowView)Container.DataItem).Row["SpecValueName"] + "'/>" : ((DataRowView)Container.DataItem).Row["SpecValueName"]%>--%>
                                                                </span></a></li>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </ul>
                                            </dd>
                                        </dl>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <div id="divnoSelect" style="clear: both; padding-top: 6px; padding-top: 0px\9;">
                                            <span style="font-weight: bold; clear: both;">请选择</span>：<span id="spanNoSelect"
                                                style="font-weight: bold; clear: both;" runat="server">"颜色" </span>
                                        </div>
                                        <div id="divSelect" style="clear: both; display: none;">
                                            <span style="font-weight: bold; clear: both;">已选择</span>：<span class="selected"></span></div>
                                        </div>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="ButtonBuy" runat="server" title="立刻购买" CssClass="bnt_buynow fl" OnClientClick="return checkSubmit(1)" />
                            <asp:Button ID="ButtonShopCar" runat="server" title="加入购物车" CssClass="bnt_addcart fl" OnClientClick="return checkSpec();" />
                            <div id="undercarriage" runat="server" visible="false" style="color:#C31B18; font-size:18px; font-weight:bold;">您好！此商品已下架如有需要请联系店家。</div>
                            <div class="shopcart_popup" style="display:none;">
                                <dl>
                                    <dt>
                                        <h3>成功添加到购物车</h3>
                                        <a onclick="$('.shopcart_popup').css({'display':'none'});" title="关闭">关闭</a>
                                    </dt>
                                    <dd>
                                        <p class="mb5">购物车共有 <strong id="bold_num">1</strong> 种商品 总金额为：<em class="price" id="bold_mly">￥99.00</em></p>
                                        <p>
                                        <input type="submit" onclick="location.href='http://www.multibuy.cn/index.php?act=cart'" value="查看购物车" name="" class="btn1">
                                        <input type="submit" onclick="$('.shopcart_popup').css({'display':'none'});" value="继续购物" name="" class="btn2">
                                        </p>
                                    </dd>
                                </dl>
                            </div>
                        </td>
                    </tr>
                    <%--<asp:Repeater ID="RepeaterDateImage" runat="server" Visible="false">
                        <ItemTemplate>
                            <img id="Img1" runat="server" src='<%# ((DataRowView)Container.DataItem).Row["imgurl"] %>'
                                width="100" height="100" />
                        </ItemTemplate>
                    </asp:Repeater>--%>
                </table>
            </div>
            <div class="clear"></div>
        </div>
    </div>
    <input type="hidden" id="hidFeeTemplate" runat="server"/>
    <input type="hidden" id="hidFeeType" runat="server" value='1' />
    <input type="hidden" id="hidIsReal" runat="server"/>
    <input type="hidden" id="hidProductNum" runat="server"/>
    <input type="hidden" id="hidShopName" runat="server"/>
    <input type="hidden" id="hidMemloginId" runat="server"  />
    <input type="hidden" id="hidProductImgurl" runat="server" />
    <input type="hidden" id="hidCityCode" runat="server" />
    <asp:HiddenField ID="HiddenFieldGuid" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldGuiGe" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldGuiGev" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldSpecName" runat="server" Value="0" />
    <%if (Page.Request.Cookies["MemberLoginCookie"] == null)
      { %>
         <input type="hidden" id="hidlogin" value='0' />
    <%} %>
</div>
<script type="text/javascript" language="javascript">
    var shoppath = '<%=ShopUrlOperate.GetShopPath() %>'; //店铺路径
    var ycity = '<%=ShopUrlOperate.GetUserCity() %>';
    var locurl = 'http://<%=Request.Url.Host %>/poplogin.html?vj=shopcar&backurl=' + encodeURIComponent('http://<%=Request.Url.Host %>/productdetail.aspx?guid=<%=Request.QueryString["guid"] %>');
</script>
<div id="loginbox" style="display:none;">
    <div class="box_mod">
    </div>
    <div class="box_area">
        <h3>
            <span class="b_dl">您尚未登录</span> <span class="b_colse">close</span>
        </h3>
        <div class="pkese">
        <iframe id="mylogingo" src="" width="100%" height="400" frameborder="0" scrolling="no"></iframe></div>
    </div>
</div>

<!--搭配套餐-->  
    <div class="combination" id="divCombin" runat="server">
        <div class="data">
            <h3>搭配套餐</h3>
            <ul class="data-list clearfix">
               <%DataTable dt_PackAge = ProductDetail.dt_PackAge;
                 if (dt_PackAge != null)
                 {
                     for (int i = 0; i < dt_PackAge.Rows.Count; i++)
                     {
                         string strUrl=ShopUrlOperate.shopDetailHref(dt_PackAge.Rows[i]["guid"].ToString(),dt_PackAge.Rows[i]["memloginid"].ToString(),"ProductDetail");
                         string strProductPic=dt_PackAge.Rows[i]["originalimage"].ToString();
                         string strPname=dt_PackAge.Rows[i]["name"].ToString();
                         string strShopPrice=dt_PackAge.Rows[i]["shopprice"].ToString();
                         %>
                       
                                   <%if (i == 0)
                                     { %>   
                                  <li class="data-main">
                                    <div class="tb-pic tb-s80">
                                        <a href="<%=strUrl %>"><img src="<%=strProductPic %>_60x60.jpg" alt="<%=strPname %>"
                                            onerror="javascript:this.src='/ImgUpload/noimg.jpg_60x60.jpg'" /></a>
                                    </div>
                                    <a href="<%=strUrl %>" class="tb-title"><%=strPname %></a>
                                    <em class="tb-price tb-rmb-num">原价：<em class="tb-rmb">¥</em><%=strShopPrice %></em>
                                </li>
                                 <%}
                                     else if (i == 1)
                                     { %>
                                     
                                     <li>
                                        <div class="tb-pic tb-s80">
                                            <a href="<%=strUrl %>"><img src="<%=strProductPic %>_60x60.jpg" alt="<%=strPname %>"
                                                onerror="javascript:this.src='/ImgUpload/noimg.jpg_60x60.jpg'" /></a>
                                        </div>
                                        <a href="<%=strUrl %>" class="tb-title"><%=strPname%></a>
                                        <em class="tb-price tb-rmb-num">原价：<em class="tb-rmb">¥</em><%=strShopPrice%></em>
                                    </li>
                     <%}
                                     else { 
                                     %>
                                     
                                      <li>
                                        <div class="tb-pic tb-s80">
                                            <a href="<%=strUrl %>"><img src="<%=strProductPic %>_60x60.jpg" alt="<%=strPname %>"
                                                onerror="javascript:this.src='/ImgUpload/noimg.jpg_60x60.jpg'" /></a>
                                        </div>
                                        <a href="<%=strUrl %>" class="tb-title"><%=strPname%></a>
                                        <em class="tb-price tb-rmb-num">原价：<em class="tb-rmb">¥</em><%=strShopPrice%></em>
                                    </li>
                                     
                                     <%}
                     }
                 }
                    %>
                       
      
            </ul>
            <div class="data-info">
                <p class="tb-total">
                    <span>套餐价格：</span>
                    <em class="tb-rmb">¥</em>
                    <em class="tb-rmb-num"><asp:Label ID="lblPackSalePrice" runat="server"></asp:Label></em>
                </p>
                <p class="tb-save">
                    <span>节省：</span>
                    <em class="tb-rmb">¥</em>
                    <em class="tb-rmb-num"><asp:Label ID="lblSavePrice" runat="server"></asp:Label></em>
                </p>
                <a runat="server" id="aviewshow">查看套餐</a>
            </div>
            <div class="clear"></div>
        </div>
</div>
 <!--搭配套餐-->
 <script type="text/javascript">
var HiddenFieldGuiGev='#<%=HiddenFieldGuiGev.ClientID %>';
var HiddenFieldSpecName='#<%=HiddenFieldSpecName.ClientID %>';
var HiddenFieldGuiGe='#<%=HiddenFieldGuiGe.ClientID %>';
var hidSaleType='#<%=hidSaleType.ClientID %>';
var LabelShopPrice='#<%=LabelShopPrice.ClientID %>';
var hidDisCount='#<%=hidDisCount.ClientID %>';
var lblPromotionPrice='#<%=lblPromotionPrice.ClientID %>';
var LabelRepertoryCount='#<%=LabelRepertoryCount.ClientID %>';
var TextBoxBuyNum='#<%=LabelRepertoryCount.ClientID %>';
var LabelRepertoryCount='#<%=LabelRepertoryCount.ClientID %>';
var HiddenFieldGuid='#<%=HiddenFieldGuid.ClientID %>';
var hidMemloginId='#<%=hidMemloginId.ClientID %>';
var shoppath='<%=ShopUrlOperate.GetShopPath() %>';//店铺路径
var ycity='<%=ShopUrlOperate.GetUserCity() %>';
var locurl='http://<%=Request.Url.Host %>/poplogin.html?vj=shopcar&backurl='+encodeURIComponent('http://<%=Request.Url.Host %>/productdetail.aspx?guid=<%=Request.QueryString["guid"] %>');
</script>