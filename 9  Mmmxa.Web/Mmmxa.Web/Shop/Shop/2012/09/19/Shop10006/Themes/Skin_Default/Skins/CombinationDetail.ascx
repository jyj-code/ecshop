<%@ Control Language="C#" EnableViewState="false" %>
<div>
    <div class="Combination_title">
        <h3><asp:Label ID="lblPackName" runat="server"></asp:Label></h3>
    </div>
    <div class="Combination_con">
        <!--图片+属性--> 
        <div class="meta-combo">
            <div class="gallery fl">
                <div class="booth jqzoom" id="boothPic"><asp:Literal ID="literalImg" runat="server"></asp:Literal></div>
                <ul class="thumb clearfix">
                    <asp:Repeater ID="repImg" runat="server">
                    <ItemTemplate>
                         <li class='<%#Container.ItemIndex==0?"selected":""%>' lang='<%#Eval("originalimage") %>'>
                            <div class="pic">
                                <img src='<%#Eval("originalimage")+"_60x60.jpg" %>' />
                            </div>
                        </li>
                     </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <div class="clear"></div>
            </div>
            <div class="property fl">
                <div class="TipBlock" style="display:none;">
                    <div>
                        <img src="Themes/Skin_Default/images/xiaobao.png" />
                        <p>该套餐已加入<a href="#">消保</a>，将保障您的购物资金与运费安全。</p>
                    </div>
                </div>
                <div class="price-combo">
                    <div class="flag">
                        <p>立省</p>
                        <p><span><asp:Label ID="lblSaveMoney" runat="server"></asp:Label></span>元</p>
                    </div>
                    <ul class="meta">
                        <li class="market-price clearfix">
                            <span>原&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;价：</span>
                            <del><asp:Label ID="lblOldPrice" runat="server"></asp:Label></del>元
                        </li>
                        <li class="detail-price clearfix">
                            <span>促 销 价：</span>
                            <i></i>
                            <strong><asp:Label ID="lblSalePrice" runat="server"></asp:Label></strong>元
                        </li>
                    </ul>
                </div>
                <div style="display:none;">
                    <ul>
                        <li class="featureSer">
                            <span>特色服务：</span>
                            <a href="#"><i></i>七天退换</a>
                        </li>
                    </ul>
                </div>
            </div>
            <div class="clear"></div>
        </div>
        <!--套餐商品-->
        <div class="property-combo">
            <h4>本优惠套餐包含以下宝贝:</h4>
            <div>
               <asp:Repeater ID="repPackProduct" runat="server">
                   <ItemTemplate>
                       <input type="hidden" name="hidGuId" value='<%#Eval("guid")%>' />
                       <div class="key">
                        <div class="skin clearfix">
                            <div class="thumb-single fl">
                                <a href='<%#ShopUrlOperate.shopDetailHref(Eval("guid").ToString(),Eval("memloginid").ToString(),"ProductDetail") %>' target="_blank"><img src='<%#Eval("originalimage") %>' /></a>
                            </div>
                            <div class="prop-summary fl">
                                <p><a href='<%#ShopUrlOperate.shopDetailHref(Eval("guid").ToString(),Eval("memloginid").ToString(),"ProductDetail") %>' target="_blank"><%# ShopNum1.Common.Utils.GetUnicodeSubString(Eval("Name").ToString(), 25, "")%> </a></p>
                                <p>
                                    <em><%#Eval("shopprice") %></em>(库存<%#Eval("repertorycount") %>件)
                                </p>
                            </div>
                        </div>
                      </div>
                   </ItemTemplate>
               </asp:Repeater>
                <div class="clear"></div>
                <div class="combo-buy">
                    <p>我 要 买：<input type="text" id="txtBuyNum" runat="server" value="1" onkeyup="NumTxt_Int(this)"/> 套</p>
                    <input type="hidden" id="hidProductGuID" runat="server" />
                     <input type="hidden" id="hidShopName" runat="server" />
                    <input type="hidden" id="hidMemloginId" runat="server" />
                    <p><asp:Button ID="btnBuyPack" runat="server" Text="立即购买" CssClass="ZuHeBtn" OnClientClick="return CheckBuy()" /></p>
                </div>
                <script type="text/javascript" language="javascript">
                        function CheckBuy()
                        {
                             var pidArry=new Array();
                             $("input[name='hidGuId']").each(function(){
                                    pidArry.push("'"+$(this).val()+"'");
                             });
                             if(parseInt($("#CombinationDetail_ctl00_txtBuyNum").val())<1)
                             {
                                alert("购买数量不能为空！");return false;
                             }
                             $("#CombinationDetail_ctl00_hidProductGuID").val(pidArry.join(","));
                             return true;
                        }
                </script>
            </div>
        </div>
    </div>
    <!--套餐详情-->
    <div class="info-combo">
        <div class="info-combo-title"><span>套餐详情</span></div>
        <div class="info-combo-con">
                <asp:Literal ID="literalDetail" runat="server"></asp:Literal>
        </div>
    </div>
    <!--其他套餐-->
    <div class="simple">
        <h4>店铺其他搭配套餐</h4>
        <div class="simple-con">
            <ul class="clearfix">
                <asp:Repeater ID="OtherPackList" runat="server">
                    <ItemTemplate>
                         <li>
                            <div class="item">
                                <div class="pic"><a href='<%#ShopUrlOperate.shopDetailHref(Eval("guid").ToString(),Eval("memloginid").ToString(),"ProductDetail") %>' target="_blank"><img src='<%#Eval("originalimage")+"_100x100.jpg"  %>'/></a></div>
                                <div class="price"><strong><%#Eval("shopprice") %></strong></div>
                                <div class="desc"><a href='<%#ShopUrlOperate.shopDetailHref(Eval("guid").ToString(),Eval("memloginid").ToString(),"ProductDetail") %>'><%# ShopNum1.Common.Utils.GetUnicodeSubString(Eval("Name").ToString(), 25, "")%></a></div>
                            </div>
                         </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>
    <!--免责申明-->
    <div class="box">
        <p>免责声明：本网所展示的宝贝供求信息由买卖双方自行提供，其真实性、准确性和合法性由信息发布人负责。本网不提供任何保证，并不承担任何法律责任。网友情提醒：为保障您的利益，请网上成交，贵重宝贝，请使用<a href="#">支付宝</a>交易</p>
    </div>
</div>