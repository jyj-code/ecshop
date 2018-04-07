﻿<%@ Control Language="C#" EnableViewState="false" %>
<%@ Import Namespace="ShopNum1.WebControl" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="System.Data" %>
<!--购买数量加减-->

<script type="text/javascript">
if (top.location != location) top.location.href = location.href;
</script>
<!--分隔-->
<%if (RepeaterShopCart1.Items.Count == 0)
  {
      hidShopCar.Visible = false; showMsg.Visible = true;
  } %>
<div class="message" id="showMsg" runat="server" visible="false">
      <p>购物车内暂时没有商品，您可以<a href="http://<%=ShopSettings.siteDomain %>">去首页</a>挑选喜欢的商品<!-- ，或<a href="###" class="btn-takeout">取出之前寄存的商品</a> --></p>
</div>
<div class="searchpro orderxy" id="hidShopCar" runat="server">
    <div class="order_tit">购物车详细</div>
    <div class="order_dateil clearfix">
        <div class="cart-thead clearfix">
            <div class="column t-checkbox">
                <asp:CheckBox ID="CheckBoxAllSelect" onclick="javascript:SelectAllCheckboxes(this);" runat="server" Checked="true" />全选
            </div>
            <div class="column t-goods">店铺宝贝</div>
            <div class="column t-price">单价(元)</div>
            <div class="column t-num">数量</div>
            <div class="column t-total">小计(元)</div>
            <div class="column t-action">操作</div>
        </div>
        <asp:Repeater ID="RepeaterShopCart1" runat="server">
            <ItemTemplate>
                <div class="dianp">
                    店铺：<span class="dianpspan"><asp:Label ID="LabelSellName" runat="server" Text='<%#((DataRowView)Container.DataItem).Row["SellName"] %>'></asp:Label></span>卖家：<span
                        class="dianpspan"><asp:Label ID="LabelShopName" runat="server" Text='<%# ((DataRowView)Container.DataItem).Row["ShopID"] %>'></asp:Label></span>
                </div>
                <asp:Repeater ID="RepeaterShopProduct" runat="server">
                    <ItemTemplate>
                        <asp:HiddenField ID="HiddenFieldIsPresent" Value='<%# ((DataRowView)Container.DataItem).Row["IsPresent"]%>'
                            runat="server" />
                        <asp:HiddenField ID="HiddenFieldGuid" Value='<%# ((DataRowView)Container.DataItem).Row["Guid"]%>'
                            runat="server" />
                        <asp:HiddenField ID="HiddenFieldProductGuid" Value='<%# ((DataRowView)Container.DataItem).Row["ProductGuid"]%>'
                            runat="server" />
                        <div class="cart-tbody">
                            <div class="cartcolumn t-checkbox">
                                <asp:CheckBox ID="checkboxAll" name="t_checkbox" runat="server" CssClass="incheck" Checked="true" />
                            </div>
                            <div class="order_cl t-goods">
                                <a href='<%#ShopUrlOperate.shopHrefNew(((DataRowView)Container.DataItem).Row["ProductGuid"].ToString(),((DataRowView)Container.DataItem).Row["ShopID"].ToString() )%>'
                                    class="or_img" title='<%#((DataRowView)Container.DataItem).Row["Name"] %>'>
                                    <asp:Image ID="ImageProductPic" runat="server" onerror="javascript:this.src='/ImgUpload/noImage.gif'"
                                        Width="53" Height="53" ImageUrl='<%# ((DataRowView)Container.DataItem).Row["OriginalImge"] %>' />
                                </a>
                                <div class="or_name">
                                    <p>
                                      <a href='<%#ShopUrlOperate.shopHrefNew(((DataRowView)Container.DataItem).Row["ProductGuid"].ToString(),((DataRowView)Container.DataItem).Row["ShopID"].ToString() )%>' title='<%#((DataRowView)Container.DataItem).Row["Name"] %>'> <%# ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["Name"].ToString(),48,"...")%></a>
                                    </p>
                                    <asp:Label ID="LabelIsPresent" runat="Server" Text="" ForeColor="Red" />
                                    <asp:Label ID="labelMarketPrice" Visible="false" runat="server" Text=' <%# ((DataRowView)Container.DataItem).Row["MarketPrice"]%>' />
                                    <div class="orimgs">
                                        <asp:Label ID="LabelProductService" runat="server"></asp:Label>
                                    </div>
                                    <div class="or_gg">
                                        <asp:HiddenField ID="HiddenFieldSpecificationValue" runat="server"  Value='<%#Eval("SpecificationValue") %>'/><%#Eval("specificationname").ToString().Replace(";","&nbsp;&nbsp;&nbsp;") %>
                                    </div>
                                </div>
                            </div>
                            <div class="cartcolumn t-price">
                                <b>
                                    <asp:Label ID="LabelBuyPrice" runat="server" Text=' <%# ((DataRowView)Container.DataItem).Row["BuyPrice"]%>' /></b>
                            </div>
                            <div class="or_num t-num">
                                <input type="hidden" value='<%#Eval("repertorycount")%>' name="repstock" />
                                <img class="ImgDelete" src="Themes/Skin_Default/Images/jj.jpg" />
                                <asp:TextBox ID="TextBoxBuyNumber" runat="server" Text='<%# ((DataRowView)Container.DataItem).Row["BuyNumber"]%>'
                                    CssClass="or_input" onkeyup="NumTxt_Int(this)" onblur="changPrice(this)"></asp:TextBox><img class="ImgAdd" src="Themes/Skin_Default/Images/jiaj.jpg" />
                                    <input type="hidden" value='<%#Eval("Guid")%>' /><input type="hidden" value='<%#Eval("ProductGuid")%>' />
                                    <div class="J_AmountMsg" style="color:Red;display:none;"><em class="error-msg">最多只能购买<span><%#Eval("repertorycount")%></span>件</em></div>
                            </div>
                            <div class="cartcolumn t-total">
                                <b>
                                    <asp:Label ID="LabelAll" CssClass="LabelAll" runat="server" /></b>
                            </div>
                            <div class="shanchu t-action">
                                <p>
                                    <asp:LinkButton ID="LinkButtonIRemove" CommandArgument='<%#Eval("Guid")+","+Eval("ProductGuid")+","+Eval("SellName")+","+Eval("BuyPrice")+","+Eval("Name")+","+Eval("ShopID")%>'
                                        runat="server">移入收藏夹</asp:LinkButton></p>
                                <p>
                                    <asp:LinkButton ID="LinkButtonIDelete" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Guid")%>'
                                        runat="server" OnClientClick="return confirm('是否确定删除！')">删除</asp:LinkButton></p>
                            </div>
                            <div class="clear"></div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="shangp">
        <div class="shagpleft">
            <asp:CheckBox ID="CheckBoxAllSelectXia" onclick="javascript:SelectAllCheckboxes(this);"
                runat="server" Checked="true" />全选
            <asp:LinkButton ID="LinkButtonDelete" runat="server" OnClientClick="return confirm('是否批量删除？')">批量删除</asp:LinkButton>
            <asp:LinkButton ID="LinkButtonRemove" runat="server">批量移入收藏夹</asp:LinkButton>
            <asp:LinkButton ID="LinkButtonUpdate" runat="server">更新购物车</asp:LinkButton>
        </div>
        <div class="shagpright">
            商品总计(不含运费)<b>￥<asp:Label ID="labelAllPrice" CssClass="labelAllPrice" runat="server" /></b>
        </div>
        <div class="clear">
        </div>
    </div>
    <script type="text/javascript" language="javascript">
     //Checkbox全选
    function SelectAllCheckboxes(obj)
    {
        var theTable = obj.parentNode.parentNode.parentNode.parentNode.parentNode;
        var inputs = theTable.getElementsByTagName('input');
        for(var i = 0;i<inputs.length;i++) 
        {
            if(inputs[i].type == "checkbox") {inputs[i].checked = obj.checked;}
        }
    }
    $(function(){
    $(".or_num input[type='text']").each(function(){
            var t_num=$(this).val();
            var t_hidNum=$(this).prev().prev().val();
            if(parseInt(t_num)>parseInt(t_hidNum))
            {
                $(this).parent().find(".J_AmountMsg").show();
                $(this).parent().parent().find(".t-checkbox input").removeAttr("checked");
                $(this).parent().parent().find(".t-checkbox input").attr("disabled","disabled");
            }else{
                $(this).parent().find(".J_AmountMsg").hide();
                $(this).parent().parent().find(".t-checkbox input").attr("checked",true);
                $(this).parent().parent().find(".t-checkbox input").removeAttr("disabled");
            }
            totalPrice();
    });
    
    //加
    $(".ImgAdd").click
    (
        function()
        {
            var BuyNum=parseInt($(this).prev().val())+1;//购买数量
            if($(this).prev().val()==""){BuyNum="1";}
            
            var nowstock=$(this).parent().find("input[name='repstock']").val();
            if(nowstock<parseInt(BuyNum))
            {
                $(this).parent().find(".J_AmountMsg").show();
                $(this).val($(this).parent().find(".J_AmountMsg span").text());
                return false;
            }
            $(this).prev().val(BuyNum);
            //小计的计算
            var danjia=parseFloat($(this).parent().prev().find("span").text());//单价
            danjia=danjia==""?"1":danjia;
            var labelAll=$(this).parent().next().find("span");//小计
            $(labelAll).text((danjia*BuyNum).toFixed(2));
            
            ////商品合计（不含运费）
            var labelAll=$("span.LabelAll");//.parents(".order_dateil clearfix").find(".labelAll");//所有小计控件
            var NumlabelAll=0;   var checkAll=$("span[name='t_checkbox'] input");
            for(var i=0;i<labelAll.length;i++)
            {
                 if(checkAll[i].checked){NumlabelAll+=parseFloat($(labelAll[i]).text());}
            }
            $(".labelAllPrice").text(NumlabelAll.toFixed(2)); //商品合计（不含运费）￥ 控件
            
            var buyprice=$(this).parent().prev().find("span").text();
            updateNumSet($(this).next().val(),BuyNum,buyprice,$(this).next().next().val());
        }
    );
    //减
    $(".ImgDelete").click
        (
            function()
            {
                var BuyNum=parseInt($(this).next().val());//购买数量
                if(BuyNum>1)
                {
                    $(this).next().val(BuyNum-1)
                    BuyNum=BuyNum-1;
                    //小计的计算
                    var danjia=parseFloat($(this).parent().prev().find("span").text());//单价
                    var labelAll=$(this).parent().next().find("span");//小计
                    $(labelAll).text((danjia*BuyNum).toFixed(2));
                    
                    ////商品合计（不含运费）
                    var labelAll=$("span.LabelAll");//.parents(".order_dateil clearfix").find(".labelAll");//所有小计控件
                    var NumlabelAll=0;   var checkAll=$("span[name='t_checkbox'] input");
                    for(var i=0;i<labelAll.length;i++)
                    {
                          if(checkAll[i].checked){NumlabelAll+=parseFloat($(labelAll[i]).text());}
                    }
                    $(".labelAllPrice").text(NumlabelAll.toFixed(2)); //商品合计（不含运费）￥ 控件
                    var buyprice=$(this).parent().prev().find("span").text();
                    updateNumSet($(this).next().next().next().val(),BuyNum,buyprice,$(this).next().next().next().next().val());
                }
            }
        );
});
        function changPrice(o)
        {   
            if(updateNum(o)){
                    if($(o).val()==""){$(o).val(1);}
                    var buynum=$(o).val();
                    var buyprice=$(o).parent().prev().find("span").text(); 
                    $.get("/Api/Main/ShopCart.ashx?guid="+$(o).next().next().val()+"&num="+buynum+"&pirce="+buyprice+"&pguid="+$(o).next().next().next().val()+"",null,function(data){});
            }
        }
        function updateNumSet(guid,buynum,buyprice,pguid)
        {
           $.get("/Api/Main/ShopCart.ashx?guid="+guid+"&num="+buynum+"&pirce="+buyprice+"&pguid="+pguid+"",null,function(data){});
        }
        function updateNum(o)
        {
            var BuyNum=parseInt($(o).val());//购买数量
            if($(o).val()==""){BuyNum="1";}
            var nowstock=$(o).parent().find("input[name='repstock']").val();
            if(nowstock<parseInt(BuyNum))
            {
                 $(o).parent().find(".J_AmountMsg").show();
                 $(o).val($(o).parent().find(".J_AmountMsg span").text());
                 return false;
            }
            $(o).parent().find(".J_AmountMsg").hide();
            $(o).parent().parent().find(".t-checkbox input").attr("checked","checked");
            $(o).parent().parent().find(".t-checkbox input").removeAttr("disabled");
                
            var danjia=parseFloat($(o).parent().prev().find("span").text());//单价
            danjia=danjia==""?"1":danjia;
            var labelAll=$(o).parent().next().find("span");//小计
            $(labelAll).text((danjia*BuyNum).toFixed(2));
            
            ////商品合计（不含运费）
            var labelAll=$("span.LabelAll");
            var NumlabelAll=0;
            var checkAll=$("span[name='t_checkbox'] input");
            for(var i=0;i<labelAll.length;i++)
            {
                if(checkAll[i].checked){NumlabelAll+=parseFloat($(labelAll[i]).text());}
            }
            $(".labelAllPrice").text(NumlabelAll.toFixed(2)); //商品合计（不含运费）￥ 控件
            return true;
        }
        $(function(){
             $(".b_colse").click(function(){  $("#loginbox").hide();});
             $("span[name='t_checkbox'] input,#ShoppingCart1_ctl00_CheckBoxAllSelectXia,#ShoppingCart1_ctl00_CheckBoxAllSelect").click(function(){totalPrice();});
        })
        function NumTxt_Int(o)
        {
           o.value=o.value.replace(/\D/g,'1');
           if(o.value==""){o.value="1";}
        }
         function Ischeck()
         {
             var bflag=false;
             $(".incheck input").each(function(m,n){if($(this).attr("checked")){bflag=true;}});
             if(!bflag){alert("至少勾选一件商品！");return false;}
             return true;
         }
         
       function totalPrice()
       {
            var price=0;
            $("span[name='t_checkbox'] input").each(function(){
                    if($(this).is(":checked"))
                    {
                       price+=parseFloat($(this).parent().parent().parent().find(".t-total").text());
                    }
            });
            $("#ShoppingCart1_ctl00_labelAllPrice").text(price.toFixed(2));
       }
    </script>
    
    
    <div class="order_btn">
        <asp:ImageButton ID="ImageButtonContinue" runat="server" CssClass="orbtn1" ImageUrl="/Main/Themes/Skin_Default/images/jis.jpg" />
        <!-- 去结算 -->
        <asp:ImageButton ID="ImageButtonPay" runat="server" OnClientClick="return Ischeck()" CssClass="orbtn2" ImageUrl="/Main/Themes/Skin_Default/images/qujies.jpg" />
        <asp:HiddenField ID="HiddenFieldMemLoginID" Value="0" runat="server" />
        <asp:HiddenField ID="HiddenFieldURLReferrer" Value="-1" runat="server" />
    </div>
</div>
<div style="display: none;">
    <asp:Label ID="labelMaretPrice" runat="server" />
    <asp:Label ID="labelLower" runat="server" />
    <asp:ImageButton ID="ImageButtonDelete" runat="server" ImageUrl="/Main/Themes/Skin_Default/Images/shoppingcart_btn01.png" />
    <asp:ImageButton ID="ImageButtonRemove" runat="server" ImageUrl="/Main/Themes/Skin_Default/Images/shoppingcart_btn02.png" />
    <asp:ImageButton ID="ImageButtonUpdate" runat="server" ImageUrl="/Main/Themes/Skin_Default/Images/shoppingcart_btn03.png" />
</div>
<%if (Page.Request.Cookies["MemberLoginCookie"] == null)
      { %>
         <input type="hidden" id="hidlogin" value='0' />
    <%} %>