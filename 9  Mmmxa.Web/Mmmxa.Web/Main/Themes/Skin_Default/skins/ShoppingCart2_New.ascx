<%@ Control Language="C#" EnableViewState="false"%>
<%@ Import Namespace="ShopNum1.WebControl" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="System.Data" %>
<script language="javascript" type="text/javascript">
//基本参数配置
var hidGuID="#<%= HiddenFieldAddressGuid.ClientID %>";
var AllCount="#<%= labelProtectAllCount.ClientID %>";
var RadioButtonPayment="#ShoppingCart2_New_ctl00_RepeaterShoppingCartPayment_ctl00_RadioButtonPayment";
var LabelPost="#<%= LabelPost.ClientID %>";
var LabelPaymentCharge="#<%= LabelPaymentCharge.ClientID %>";
var LabelShouldPrice="#<%= LabelShouldPrice.ClientID %>";
var LabelAllCartPrice="#<%= LabelAllCartPrice.ClientID %>";
var TextBoxPostalcode="#<%= TextBoxPostalcode.ClientID %>";
var TextBoxAddress="#<%= TextBoxAddress.ClientID %>";
var TextBoxEmail="#<%= TextBoxEmail.ClientID %>";
var TextBoxMobile="#<%= TextBoxMobile.ClientID %>";
var TextBoxName="#<%= TextBoxName.ClientID %>";
var TextBoxTel="#<%= TextBoxTel.ClientID %>";


var HiddenFieldAddressCode="#<%= HiddenFieldAddressCode.ClientID %>";
var HiddenFieldAddressName="#<%= HiddenFieldAddressName.ClientID %>";
var HiddenFieldAllCartPrice="#<%= HiddenFieldAllCartPrice.ClientID %>";
var HiddenFieldFeeTemplateID="#<%= HiddenFieldFeeTemplateIDandNumber.ClientID %>";
</script>
<script language="javascript" type="text/javascript" src="/Main/js/ConfirmOrder.js"></script>
<div class="searchpro">
    <!--店铺 和商品-->
    <div class="order_dateil clearfix">
        <div class="cart-thead clearfix">
            <div class="column order-goods">店铺宝贝</div>
            <div class="column order-price">单价(元)</div>
            <div class="column order-num">数量</div>
            <div class="column order-total">小计(元)</div>
            <div class="column order-action">运送方式</div>
        </div>
        <asp:Repeater ID="RepeaterShopCart2" runat="server">
            <ItemTemplate>
                <div class="dianp">
                    店铺：<span class="dianpspan"><asp:Label ID="LabelSellName" runat="server" Text='<%# ((DataRowView)Container.DataItem).Row["SellName"] %>'></asp:Label></span>卖家：<span
                        class="dianpspan"><asp:Label ID="LabelShopName" runat="server" Text='<%#((DataRowView)Container.DataItem).Row["ShopID"] %>'></asp:Label>
                       <asp:HiddenField ID="hdSellerTel" runat="server" Value='<%# DataBinder.Eval(Container.DataItem,"Tel") %>' />
                    </span>
                </div>
                <table border="0" cellpadding="0" cellspacing="0" class="test">
                    <tr>
                        <td>
                            <!--商品-->
                            <asp:Repeater ID="RepeaterShopProduct" runat="server">
                                <ItemTemplate>
                                    <div class="cart-tbody cart_bottom">
                                        <div class="order_cl order-goods">
                                            <a href="<%#ShopUrlOperate.shopDetailHrefNew(((DataRowView)Container.DataItem).Row["ProductGuid"].ToString(),((DataRowView)Container.DataItem).Row["shopid"].ToString(),"ProductDetail")%>"  class="or_img"  title='<%# ((DataRowView)Container.DataItem).Row["Name"] %>' target="_blank">
                                                <asp:Image ID="ImageProductPic" runat="server" onerror="javascript:this.src='../../ImgUpload/noImage.gif'"
                                                    ImageUrl='<%# ((DataRowView)Container.DataItem).Row["OriginalImge"] %>' Width="53" Height="53" /></a>
                                            <div class="or_name">
                                                <p> 
                                                 <a href="<%#ShopUrlOperate.shopDetailHrefNew(((DataRowView)Container.DataItem).Row["ProductGuid"].ToString(),((DataRowView)Container.DataItem).Row["shopid"].ToString(),"ProductDetail")%>" title='<%# ((DataRowView)Container.DataItem).Row["Name"] %>' target="_blank">
                                                 <asp:Label ID="lbProductName" runat="server" Text='<%# ((DataRowView)Container.DataItem).Row["Name"] %>'></asp:Label>
                                                 </a>
                                                 </p>
                                                <div class="orimgs">
                                                    <asp:Label ID="LabelProductService" runat="server" />
                                                </div>
                                                <div class="or_gg">
                                                    <asp:HiddenField ID="HiddenFieldSpecificationValue" runat="server"  Value='<%#Eval("SpecificationValue") %>'/><%#Eval("specificationname").ToString().Replace(";","&nbsp;&nbsp;&nbsp;") %>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="cartcolumn order-price">
                                            <b><asp:Label ID="labelBuyPrice" runat="server" Text='<%# ((DataRowView)Container.DataItem).Row["BuyPrice"]%>' /></b>
                                        </div>
                                        <div class="or_num order-num">
                                            <asp:Label ID="labelBuyNumber" runat="server" Text='<%# ((DataRowView)Container.DataItem).Row["BuyNumber"]%>' />
                                        </div>
                                        <div class="cartcolumn order-total">
                                            <b><asp:Label ID="labelAll" runat="server" CssClass="labelAll" /></b>
                                        </div>
                                        <div class="HiddenField" style="display: none;">
                                            <img class="ImgDelete" src="Themes/Skin_Default/Images/jj.jpg" />
                                            <asp:TextBox ID="TextBoxBuyNumber" runat="server" Text='<%# ((DataRowView)Container.DataItem).Row["BuyNumber"]%>'
                                                CssClass="or_input"></asp:TextBox>
                                            <img class="ImgAdd" value='<%# ((DataRowView)Container.DataItem).Row["BuyPrice"]%>'
                                                src="Themes/Skin_Default/Images/jiaj.jpg" />
                                            <asp:Label ID="labelProductMarketPrice" runat="server" Text='<%# ((DataRowView)Container.DataItem).Row["MarketPrice"]%>' />
                                            <asp:HiddenField ID="HiddenFieldGuid" Value='<%# ((DataRowView)Container.DataItem).Row["Guid"]%>'
                                                runat="server" />
                                            <asp:HiddenField ID="HiddenFieldMinusFee" Value='<%# ((DataRowView)Container.DataItem).Row["MinusFee"]%>'
                                                runat="server" />
                                            <!--1表示卖家承担，0表示买家承担-->
                                            <asp:HiddenField ID="HiddenFieldFeeType" Value='<%# ((DataRowView)Container.DataItem).Row["FeeType"]%>'
                                                runat="server" />
                                            <asp:HiddenField ID="HiddenFieldProductGuid" Value='<%# ((DataRowView)Container.DataItem).Row["ProductGuid"]%>'
                                                runat="server" />
                                            <!--规格键-->
                                            <asp:HiddenField ID="HiddenFieldSName" Value='<%# ((DataRowView)Container.DataItem).Row["SpecificationName"]%>'
                                                runat="server" />
                                            <!--规格值-->
                                            <asp:HiddenField ID="HiddenFieldSValue" Value='<%# ((DataRowView)Container.DataItem).Row["SpecificationValue"]%>'
                                                runat="server" />
                                        </div>
                                        <div class="clear"></div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </td>
                        <td class="td-yf">
                            <!--邮费-->
                            <div class="yunsong order-action">
                                <asp:DropDownList ID="DropDownListPost" runat="server" CssClass="DropDownListPost" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                        </td>
                    </tr>
                </table>
                <!--留言-->
                <div class="salemessage">
                    <div class="yunleft">
                        <p class="samle">
                            给卖家留言：<textarea class="inputbox" onfocus="if(this.value=='选填，可告诉卖家你对订单的特殊需求。'){ this.value=''; ChangeTextStyle(this,2);}"
                                onblur="if(this.value=='') {this.value='选填，可告诉卖家你对订单的特殊需求。';ChangeTextStyle(this,1);}"
                                onmouseover="this.style.border='#ffad33 1px solid'" onchange="if(this.value!='选填，可告诉卖家你对订单的特殊需求。'){MessageboxChange(this)}"
                                onmouseout="if(this.value!=''){this.style.border='#8ab6dd 1px solid'}">选填，可告诉卖家你对订单的特殊需求。</textarea>
                            <asp:TextBox ID="TextBoxMessage" runat="server" Style="display: none;"></asp:TextBox>
                        </p>
                        <p>
                            是否需要发票：
                            <asp:RadioButtonList ID="RadioButtonListInvoice" runat="server" RepeatLayout="Flow"
                                RepeatDirection="Horizontal" AutoPostBack="false" onclick="GetRadioInvoice(this)">
                                <asp:ListItem Value="0">是</asp:ListItem>
                                <asp:ListItem Value="1" Selected="True">否</asp:ListItem>
                            </asp:RadioButtonList>
                        </p>
                        <asp:Panel ID="PanelInvoice" runat="server" Visible="true" Style="display: none;">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td style="width: 80px;">
                                        <div align="left">
                                            发票抬头：</div>
                                    </td>
                                    <td>
                                        <ShopNum1:TextBox ID="TextBoxInvoicespayable" TextMode="MultiLine" Height="25px" Width="285px" runat="server" MaxLength="50" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div align="left">
                                            发票内容：</div>
                                    </td>
                                    <td>
                                        <ShopNum1:TextBox ID="TextBoxInvoice" TextMode="MultiLine" Height="30px" Width="340px" runat="server" MaxLength="250" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </div>
                    <div class="yunright">
                        商品合计（含运费）<b>￥<asp:Label ID="labelProtectHeji" runat="server" CssClass="labelProtectHeji" /></b>
                    </div>
                    <div class="clear"></div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <!--算钱-->
    <div class="sgest" style="display: none;">
        <span class="fr">购物金额小计为：
            <font class="StorePrice"><%# Globals.MoneySymbol%><asp:Label ID="labelAllPrice" runat="server" Visible="false" />
            <asp:Label ID="LabelOnlyProductPrice" runat="server" Text=""></asp:Label>
            <asp:Label ID="LabelBuyShopPrice" Visible="false" runat="server" /></font> 
        </span>
        <span class="fr">节省了：
            <font class="StorePrice"><%# Globals.MoneySymbol%><asp:Label ID="labelLower" runat="server" /></font>
        </span> 
        <span class="fr">比市场价：
            <font class="Price"><%# Globals.MoneySymbol%><asp:Label ID="labelMaretPrice" runat="server" /></font>
        </span>
    </div>
    <!--收货人信息-->
    <div class="bg_lic">
        <div class="consignee clearfix">
            <div class="conmess">
                 <span class="fl">收货人信息&nbsp;&nbsp;<font id="errormsg" color="red"></font></span>
                <input type="button" id="butReceiveAddress" value="使用新地址" class="shiyong" />
                <span style="display:none"> <asp:Button ID="ButtonAddReceivAddress" runat="server" OnClientClick="return checkSub(this);" Text="确定添加" CssClass="shiyong"/></span>
            </div>
                     <!--手填收货地址-->
                    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="contable">
                        <tr>
                            <td align="right"valign="middle">地区：<span class="red">*</span></td>
                            <td align="left" valign="middle">
                                <div id="localshow" style="float:left; padding-right:65px;"></div>
                                邮政编码：<asp:TextBox ID="TextBoxPostalcode" runat="server"  onkeyup="NumTxt_Int(this)" MaxLength="6"></asp:TextBox>
                            </td>
                        </tr>
                        <tr class="xiangxiadd">
                            <td align="right" valign="middle">
                                收货地址：<span class="red">*</span>
                            </td>
                            <td align="left" valign="middle">
                                <asp:TextBox ID="TextBoxAddress" runat="server" TextMode="MultiLine"
                                    Style="width: 660px; height: 50px; border: 1px solid #98b2d5;"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                收货人姓名：<span class="red">*</span>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TextBoxName" runat="server" CssClass="select1"></asp:TextBox>
                                电子邮件：<asp:TextBox ID="TextBoxEmail" runat="server" CssClass="select1" MaxLength="20"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                电话号码：
                            </td>
                            <td align="left">
                               <asp:TextBox ID="TextBoxTel" runat="server"></asp:TextBox>格式：区号-电话号码-分机号
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                手机号码：<span class="red">*</span>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TextBoxMobile" runat="server"  onkeyup="NumTxt_Int(this)"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <!--收货地址 列表-->
                    <asp:Repeater ID="RepeaterReceivingAddress" runat="server">
                        <ItemTemplate>
                            <div class="contant" lang="<%# Eval("MemloginId")%>" value="<%# Eval("Guid")+"|"+Eval("AddressCode")%>" isdefault="<%# Eval("IsDefault")%>">
                                <p>
                                    <%#Eval("Area").ToString().Replace(",","")%><%#Eval("Address")%></p>
                                <p>
                                    收货人：<%#Eval("Name")%>
                                    手机号码：<%#Eval("Mobile")%>
                                    电话号码：<%#Eval("Tel")%>
                                    邮编：<%#Eval("Postalcode")%></p>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
        </div>
    </div>
    <!--支付方式-->
    <div class="pay">
        <div class="commom xzzf">
            选择支付方式</div>
        <div class="paycon">
                    <table id="tablePayment" border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <th width="8%">&nbsp;</th>
                            <th width="20%">名称</th>
                            <th width="72%">描述</th>
                            <th width="12%" style="display: none">所需费用</th>
                        </tr>
                        <asp:Repeater ID="RepeaterShoppingCartPayment" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <ShopNum1:groupradiobutton id="RadioButtonPayment" runat="server" groupname="RadioButtonPayment">
                                        </ShopNum1:groupradiobutton>
                                        <!--支付方式的Guid -->
                                        <asp:HiddenField ID="HiddenFieldGuid" Value='<%# ((DataRowView)Container.DataItem).Row["Guid"]%>'
                                            runat="server" />
                                        <span runat="server" visible="false" id="guid">
                                            <%# DataBinder.Eval(Container.DataItem, "Guid")%></span>
                                    </td>
                                    <td>
                                        <asp:Label ID="LabelName" runat="server" Text='<%# ((DataRowView)Container.DataItem).Row["Name"]%>' />
                                    </td>
                                    <td>
                                        <%#  ((DataRowView)Container.DataItem).Row["Memo"]%>
                                    </td>
                                    <td style="display: none">
                                        <asp:Label ID="LabelCharge" CssClass="LabelCharge" runat="server" Text='<%# ((DataRowView)Container.DataItem).Row["Charge"]%>' />
                                        <asp:Literal ID="LiteralIsPersent" Text="%" Visible="false" runat="server"></asp:Literal>
                                    </td>
                                    <td style="display: none">
                                        <asp:HiddenField ID="HiddenFieldIsPersent" runat="server" Value='<%# ((DataRowView)Container.DataItem).Row["IsPercent"]%>' />
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
        </div>
    </div>
    <!--商品总价格-->
    <div class="zongprice">
        <p>
            <asp:Label ID="LabelPriceMeto" runat="server" Visible="false"></asp:Label>
            商品总价格：<b><asp:Label ID="labelProtectAllCount" runat="server"></asp:Label></b>元 +
           <span style="display:none;">支付费用：<b><asp:Label ID="LabelPaymentCharge" runat="server"></asp:Label></b>元 + </span> 运费：<b><asp:Label
                ID="LabelPost" runat="server"></asp:Label></b>元 =<b>
                    <asp:Label ID="LabelShouldPrice" runat="server"></asp:Label></b>元
        </p>
        <div class="totalprice">
            <span>总金额：<b>￥<asp:Label ID="LabelAllCartPrice" runat="server"></asp:Label></b></span>
             <asp:Button ID="ButtonCreate" runat="server"  CssClass="tijiao" OnClientClick="return checkSub(this);"  />
                         <img class="append_image" alt="正在加载请稍等候" src="/Main/Themes/Skin_Default/Images/lodding.gif" style="display:none;" />
        </div>
    </div>
</div>
  <script type="text/javascript" language="javascript" src="/main/js/areas.js"></script>
<script type="text/javascript" language="javascript" src="/main/js/location.js"></script>
<script  type="text/javascript" language="javascript">
      $(function(){
              $("#localshow").LocationSelect();
      });
</script>
<!--送货地址Guid -->
<asp:HiddenField ID="HiddenFieldAddressGuid" Value="-1" runat="server" />
<!--送货地址Code -->
<asp:HiddenField ID="HiddenFieldAddressCode" Value="-1" runat="server" />
<!--送货地址Name -->
<asp:HiddenField ID="HiddenFieldAddressName" Value="-1" runat="server" />

<asp:HiddenField ID="HiddenFieldPaymentPriceValue" runat="server" />
<asp:HiddenField ID="HiddenFieldMemLoginID" Value="0" runat="server" />
<!--存配送方式Guid -->
<asp:HiddenField ID="HiddenFieldDispatchModeGuid" Value="0" runat="server" />
<!--存配送方式名称 -->
<asp:HiddenField ID="HiddenFieldDispatchModeName" Value="" runat="server" />
<!--支付方式的Guid -->
<asp:HiddenField ID="HiddenFieldPaymentGuid" Value="0" runat="server" />
<!--支付方式的名称-->
<asp:HiddenField ID="HiddenFieldPaymentName" Value="" runat="server" />
<!--发票类型-->
<asp:HiddenField ID="HiddenFieldInvoiceType" Value="0" runat="server" />

<asp:HiddenField ID="HiddenFieldAllCartPrice" Value="0" runat="server" />
<!--多个店铺Memloginid-->
<asp:HiddenField ID="HiddenFieldMoreMemloginid" Value="0" runat="server" />
<!--邮费模板ID和购买个数-->
<asp:HiddenField ID="HiddenFieldFeeTemplateIDandNumber" Value="0" runat="server" />
<asp:HiddenField ID="HiddenFieldDispatchPrice" Value="0" runat="server"/>
