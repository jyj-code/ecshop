<%@ Control Language="C#" EnableViewState="false" %>
<%@ Import Namespace="ShopNum1.Common" %>

<script>
document.write ('<div class="sp_overlay"  style="display:none" id="sp_overlayDiv"></div>');
function funClose()
{
    $(".sp_dialog_out").css("display","none");
    $(".sp_dialog_cont").css("display","none");
    $(".sp_overlay").css("display","none");
    $(".showpopone").css("display","none");
    $(".showpoptwo").css("display","none");
}
function funOpen(obj)
{
    $("#shopname").text($(obj).attr("lang"));
    $("#product_msg").text($(obj).attr("msg"));
    $("#product_pick").text($(obj).attr("price"));
    $("#textarea_comment").text($(obj).attr("lat"));
    $("input[name='hidGuid']").val($(obj).parent().parent().attr("data-id"));
    if($(obj).attr("type") == "5")
        $("#Radio_5").attr({checked:"checked"});
     if($(obj).attr("type") == "3")
        $("#Radio_3").attr({checked:"checked"});
    if($(obj).attr("type") == "1")
        $("#Radio_1").attr({checked:"checked"});
    $(".sp_dialog_out").css("display","block");
    $(".sp_dialog_cont").css("display","block");
    $(".sp_overlay").css("display","block");
}
function btnSure(){
    var rediovalue =  $("input:checked").val();
    $.ajax
    ({        
        url:"/api/Main/member/feedback.ashx",
        type:"post",      
        data:"type=updatefeed&commenttype="+rediovalue+"&comment="+escape($("#textarea_comment").val())+"&guid="+$("input[name='hidGuid']").val(),
        dataType: "html",
        success:function(result)
        {
            if(result=="ok"){
                alert("修改评价成功");
                funClose();
                window.location.reload();
            }
            else{
                alert("修改评价失败，请重新输入");
            }
        }
     })
}
</script>
<input type="hidden" name="hidGuid" value="" />
<div id="list_main">
    <ul id="sidebar">
        <li class="<%=Common.ReqStr("type")=="1"?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>">
            <a href="?type=1">卖家的评价</a></li>
        <li class="<%=Common.ReqStr("type")==""||Common.ReqStr("type")=="2"?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>">
            <a href="?type=2">给他人的评价</a></li>
    </ul>
    <div id="content" class="ordmain1">
        <div class="biaogenr" id="feedback">
            <table width="100%" border="0" cellspacing="0" cellpadding="5" class="blue_tbw1">
                <tr>
                    <th width="10%" class="th_le">
                        评价
                    </th>
                    <th width="40%">
                        评论内容
                    </th>
                    <th width="20%">
                        <%--<%=Common.ReqStr("type") == "1" ? "评价人" : "被评价店铺"%>--%>
                        店铺名称
                    </th>
                    <th width="30%" class="th_ri">
                        宝贝信息
                    </th>
                    <th width="10%" class="th_ri" style="display: none;">
                        操作
                    </th>
                </tr>
                <asp:Repeater ID="repBingComment" runat="server">
                    <ItemTemplate>
                        <tr class="feedback" data-id="<%#Eval("Guid")%>">
                            <td class="rate th_le">
                                <span class="rate-icon rate-ok">
                                    <%#Common.SetShopCommentTxt(Eval("Commenttype").ToString())%></span>
                                <br />
                                <%--                               <%#Common.SetShopCommentUpdate(Eval("Commenttype").ToString())%>          --%>
                               
                                <%--  <%if (Common.ReqStr("type") == "1")
                                   { %>
                                    
                                    <%}
                                   else
                                   { %><%#Common.SetShopCommentTxt(Eval("BuyerAttitude").ToString())%><%} %> 
                            </td>--%>
                                <%if (Common.ReqStr("type") == "1")
                                  { %>
                                <td class="reviews-cnt">
                                    <div class="reviews-cnt-bd">
                                        <p class="rate" style="text-align: left;word-break: break-all;word-wrap:break-word;">
                                            <%#Eval("reply").ToString() == "" ? "" : Eval("reply").ToString()%>
                                        </p>
                                        <span class="date" style="text-align: right; display: block; color: #999999;">
                                            <%#Eval("replytime").ToString() == "" ? "" : "["+Eval("replytime").ToString()+"]"%></span>
                                    </div>
                                </td>
                                <%}
                                  else
                                  { %>
                                   <%#Eval("commenttype").ToString() == "5" ? "" : "<a href='javascript:void(0)' id='setalbum' class='lmf_btn' onclick='funOpen(this)'  lang='" + Eval("ShopName") + "' lat='" + Eval("continuecomment") + "' type='" + Eval("Commenttype") + "' msg='" + Eval("ProductName") + "' price='" + Eval("ProductPrice") + "' >修改评价</a>"%>
                                <td class="reviews-cnt">
                                    <div class="reviews-cnt-bd">
                                        <p class="rate" style="text-align: left; word-break: break-all;word-wrap:break-word;" mode="wrap">
                                            <%#Eval("comment")%>
                                        </p>
                                        <span class="date" style="text-align: right; display: block; color: #005ea7;">[<%#Eval("commenttime")%>]</span>
                                    </div>
                                    <div class="reviews-cnt-bd" style='<%#Eval("continuecomment").ToString()==""?"display:none": "display:block;"%>'>
                                        <p class="rate" style="text-align: left;word-break: break-all;word-wrap:break-word;" mode="wrap">
                                            <%#Eval("continuecomment")%>
                                        </p>
                                        <span class="date" style="text-align: right; display: block; color: #999999;">[<%#Eval("continuetime")%>]</span>
                                    </div>
                                </td>
                                <%} %>
                                <td>
                                    <a href="<%#ShopUrlOperate.GetShopUrl(Eval("shopid").ToString()) %>" target="_blank"
                                        class="shop_Name"><span>[<%#Eval("ShopName")%>]</span></a>
                                </td>
                                <td style="text-align: left;" class="th_ri">
                                    <div class="auction">
                                        <a href="<%#ShopUrlOperate.shopHref(Eval("productguid").ToString(),Eval("shoploginid").ToString()) %>"
                                            title="<%#Eval("ProductName")%>" target="_blank">
                                            <%#Eval("ProductName")%></a>
                                        <div class="price">
                                            <%#Eval("ProductPrice")%>元</div>
                                    </div>
                                </td>
                                <td class="th_ri" style="display: none;">
                                    &nbsp;
                                </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <%if (repBingComment.Items.Count == 0)
                  { %>
                <tr>
                    <td colspan="5" style="height: 16px;">
                        <div class="no_data">
                            暂无数据</div>
                    </td>
                </tr>
                <%} %>
            </table>
            <!--分页-->
            <div class="btntable_tbg">
                <div id="divPage" runat="server" class="fy">
                </div>
                <!--分页-->
            </div>
        </div>
    </div>
</div>
<!--弹出层-->
<div class="sp_dialog sp_dialog_out" style="display: none;" id="sp_dialog_outDiv">
    <div class="sp_dialog_cont" style="display: none;" id="sp_dialog_contDiv">
        <div class="sp_tan">
            <h4>
                修改评价</h4>
            <div class="sp_close">
                <a onclick="funClose()" href="javascript:void(0)"></a>
            </div>
            <div class="clear">
            </div>
        </div>
        <table cellspacing="0" cellpadding="0" border="0" style="padding-top: 10px; margin: 20px 0 20px 80px;">
            <tr class="up_spac">
                <td align="right">
                    店铺名称：
                </td>
                <td>
                    <label type="text" value="" id="shopname" name="shopname">
                    </label>
                </td>
            </tr>
            <tr class="up_spac">
                <td align="right">
                    宝贝信息：
                </td>
                <td>
                    <label type="text" id="product_msg" name="shopname">
                    </label>
                    <br />
                    <label type="text" id="product_pick" name="shopname">
                    </label>
                </td>
            </tr>
            <tr class="up_spac">
                <td align="right">
                    评价：
                </td>
                <td>
                    <label for="ListCommentType_0"> 
                      <img src="images/pingjhua.jpg" width="16" height="16" /></label>                   
                    <input id="Radio_5" type="radio" value="5" name="radio" />好评&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <label for="ListCommentType_1"> 
                      <img src="images/pingjhua02.jpg" width="16" height="16" /></label>
                    <input id="Radio_3" type="radio" value="3" name="radio" />中评&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <label for="ListCommentType_2">
                      <img src="images/pingjhua03.jpg" width="17" height="17" /></label>
                    <input id="Radio_1" type="radio" value="1" name="radio" />差评&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr class="up_spac">
                <td align="right">
                    评价内容：
                </td>
                <td>
                    <textarea id="textarea_comment" name="description" rows="3" class="ss_nr1" style="font-size: 12px;
                        height: 70px; width: 300px;"></textarea>
                    <%--                    <input type="text" value="" id="name" name="name" class="ss_nr1" maxlength="6"><span class="star">*</span>--%>
                </td>
            </tr>
            <tr class="up_spac">
                <td align="right">
                </td>
                <td>
                    <input type="button" value="提交" onclick="btnSure()" class="baocbtn"><span id="tipmsg"
                        style="color: Red;"></span>
                </td>
            </tr>
        </table>
        <div style="float: right; display: none;">
            <input type="button" id="btnReply" value="确定" /></div>
    </div>
</div>
<!--弹出层-->

<script type="text/javascript" language="javascript">
// 判断是否是数字   
        function checknum(str)
        {
            var re = /^[0-9]+.?[0-9]*$/; 
            if (!re.test(str))
            {
                alert("请输入正确的数字！");
                return false;
            }else{return true;}
        }
          //页面跳转
        function ontoPage(o)
        {
           var pageindex=$(o).parent().parent().prev().prev().find("input").val();
           if(checknum(pageindex))
           {
                var pageEnd=parseInt($(".page_2 b:eq(0)").text());
                if(pageEnd<=pageindex)
                    pageindex=pageEnd;
                location.href="M_Feedback.aspx?pageid="+pageindex;
           }
       }
</script>

