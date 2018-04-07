<%@ Control Language="C#" EnableViewState="false" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%
    if (ShopSettings.GetValue("IsChargePay") == "1")
    {
        IsReCharge.Visible = true;
    }
     %>
<script>
    function fundeleteData(val)
    {
        if(confirm("是否删除该记录？"))
        {
            $.get("/Api/ShopAdmin/S_DeleteOp.ashx?type=PaymentApplyLog&delid="+val.title,null,function(data){
                    if(data=="ok"){alert("删除成功！");location.reload(); return false;}
                    else{alert("删除失败！");return false;}
               });
            return true;
        }
        return false;
    }

</script>
<div id="list_main" class="list_main1">
    <ul id="sidebar">
        <li class='<%=Common.ReqStr("type")=="0"||Common.ReqStr("type")==""?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="A_AdPayRecharge.aspx?type=0" style="text-decoration: none;">充值申请</a></li>
        <li class='<%=Common.ReqStr("type")=="1"?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="A_AdPayRecharge.aspx?type=1" style="text-decoration: none;">充值列表</a></li>
    </ul>
    <div id="content">
        <div style='<%=Common.ReqStr("type")=="0"||Common.ReqStr("type")==""? "display:block": "display:none"%>'>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="tabbiao">
                <tr>
                    <td class="tab_r">
                        用户名：
                    </td>
                    <td>
                        <strong style="font-size: 14px;">
                            <asp:Label ID="Lab_MemLoginID" runat="server" Text=""></asp:Label></strong>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        当前预存款：
                    </td>
                    <td>
                        <strong class="red" style="font-size: 14px;">￥<asp:Label ID="Lab_AdPayment" runat="server"
                            Text=""></asp:Label>
                        </strong>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        充值金额：
                    </td>
                    <td>
                        <input name="input" type="text" class="textwb" id="txt_Recharge" runat="server" value="0.00"
                            style="width: 100px;" onchange="funCheckMoney()" /><span class="star">元</span>
                        <span id="errMoney" class="star">*</span>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        支付方式：
                    </td>
                    <td>
                        <select name="sel" size="1" class="tselect" id="sel_PayMent" runat="server" onchange="funCheckPayType()">
                        </select><span class="star" id="errPayMent">*</span>
                    </td>
                </tr>
                
                <tr  class="trshowx" runat="server" id="IsReCharge" visible="false"> 
                    <td class="tab_r">
                        短信确认码：
                    </td>
                    <td>
                        <input name="input" type="text" class="textwb" id="txtMobileCode" runat="server" onblur="funChecktxtMobileCode()"  />                        
                        <input type="button" id="butGetCode" value="获取验证码" /><span class="gray1" style="color: Red" id="errtxtMobileCode">*</span>
                        <script type="text/javascript" language="javascript">
                            var timerId;
                            $(function () {
                                $("#A_AdPayRecharge_ctl00_txtMobileCode").val("");
                                $("#butGetCode").click(function () {


                                    $.get("/Api/CheckInfo.ashx?type=6", null, function (data) {
                                        if (data == "0") {
                                            alert("您尚未绑定手机,无法验证,请绑定手机后重试！");
                                            $("#butGetCode").attr("disabled", "disabled");
                                            $("#butGetCode").val("获取验证码"); $("#butGetCode").removeAttr("disabled");
                                            return false;
                                        }
                                        else {
                                            $("#butGetCode").val("已发送验证码(60秒)");
                                            timerId = setInterval("goTo()", 2000);
                                        }
                                    }, "text");
                                });
                            });
                            var i = 60;
                            function goTo() {
                                i--;
                                $("#butGetCode").val("已发送验证码(" + i + "秒)");
                                if (i == 0) {
                                    $("#butGetCode").val("获取验证码");
                                    $("#butGetCode").removeAttr("disabled");
                                    clearInterval(timerId); i = 60;
                                }
                            }
                       </script>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        会员备注：
                    </td>
                    <td>
                        <textarea id="txt_Remark" cols="20" rows="2" class="textwb" style="width: 430px;
                            height: 90px; margin-top: 5px;" runat="server"></textarea>
                        <span>会员备注不能大于200个字符</span>
                        <span class="gray1">&nbsp;</span>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        &nbsp;
                    </td>
                    <td style="padding: 10px 0px 10px 0px;">
                        <asp:Button ID="Btn_Confirm" runat="server" Text="充值" CssClass="baocbtn" OnClientClick="return funCheckButton()" />
                    </td>
                </tr>
            </table>
            <input id="hid_PayMent" type="hidden" runat="server" />
            <input id="hid_PayMentValue" type="hidden" runat="server" value="-1" />
        </div>
        <div style='<%=Common.ReqStr("type")=="0"||Common.ReqStr("type")==""? "display:none": "display:block"%>'>
            <div class="pad">
                <table border="0" cellspacing="0" cellpadding="0" class="lineh">
                    <tr class="up_spac">
                        <td align="right">
                            充值单号：
                        </td>
                        <td>
                            <input type="text" runat="server" id="txt_OrderNum" class="ss_nr1" />
                        </td>
                        <td align="right" class="ss_nr_spac">
                            充值方式：
                        </td>
                        <td>
                            <select name="sel" size="1" class="tselect" id="sel_PayMentType" runat="server">
                            </select>
                            <input id="hid_SelPayMentType" type="hidden" runat="server" />
                        </td>
                    </tr>
                    <tr class="up_spac">
                        <td align="right">
                            操作日期：
                        </td>
                        <td colspan="3">
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td>
                                        <input type="text" class="ss_nrduan Wdate" runat="server" id="txt_StartTime" onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})" />
                                    </td>
                                    <td class="line_spac">
                                        -
                                    </td>
                                    <td>
                                        <input type="text" class="ss_nrduan Wdate" runat="server" id="txt_EndTime" onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})" />
                                    </td>
                                    <td>
                                        <asp:Button ID="Btn_Select" runat="server" Text="查询" CssClass="chax btn_spc" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="btntable_top">
                <tr>
                    <td style="border-left: solid 1px #e3e3e3; text-align: left;">
                        &nbsp;&nbsp;&nbsp;交易笔数： <span style="color: #ff0000; font-weight: bold;">
                            <asp:Label ID="lab_PayNum" runat="server" Text="0"></asp:Label>
                        </span>笔 &nbsp;&nbsp;&nbsp; 充值金额： ￥<span style="color: #ff0000; font-weight: bold;"><asp:Label
                            ID="lab_PayRecharge" runat="server" Text="0.00"></asp:Label>
                        </span>
                    </td>
                </tr>
            </table>
            <table border="0" cellspacing="1" cellpadding="0" class="biaodhd1" width="100%">
                <tr>
                    <th>
                        充值单号
                    </th>
                    <th width="126">
                        操作日期
                    </th>
                    <th>
                        当前预存款
                    </th>
                    <th>
                        充值金额
                    </th>
                    <th>
                        充值状态
                    </th>
                    <th>
                        充值方式
                    </th>
                    <th>
                        会员备注
                    </th>
                    <th>
                        管理员备注
                    </th>
                    <th>
                        操作
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="Rep_PayRecharge">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%# DataBinder.Eval(Container.DataItem, "OrderNumber")%>
                            </td>
                            <td>
                                <%# DataBinder.Eval(Container.DataItem, "Date")%>
                            </td>
                            <td class="red">
                                <%# DataBinder.Eval(Container.DataItem, "CurrentAdvancePayment")%>
                            </td>
                            <td style="color: Red">
                               +<%# DataBinder.Eval(Container.DataItem, "OperateMoney")%>
                            </td>
                            <td class="blue">
                                <asp:Label ID="LabelOperateStatus" runat="server" Text='<%#ShopNum1.AccountWebControl.A_AdPayRecharge.GetType(Eval("OperateStatus").ToString())%>'></asp:Label>
                            </td>
                            <td>
                                <%# DataBinder.Eval(Container.DataItem, "PaymentName")%>
                            </td>
                            <td class="picture" >
                                <span style="display:none;"><%#Eval("Memo").ToString() %></span>
                                <%#Eval("Memo").ToString().Length > 6 ? Eval("Memo").ToString().Substring(0, 6) + "..." : Eval("Memo").ToString()%>
                            </td>
                            <td class="picture" >
                                <span style="display:none;"><%#Eval("UserMemo").ToString()%></span>
                                <%#(Eval("UserMemo").ToString().Length > 6 ? Eval("UserMemo").ToString().Substring(0, 6) + "..." : Eval("UserMemo").ToString())%>
                            </td>
                            <td>
                                <a href="" runat="server" id="PayUrl" target="_blank">充值</a>
                                <asp:HiddenField ID="HiddenFieldPayMentValue" runat="server"  Value='<%#Eval("PaymentGuid") %>'/>
                                <asp:HiddenField ID="HiddenFieldOrderNumber" runat="server"  Value='<%#Eval("OrderNumber") %>'/>
                                <asp:HiddenField ID="HiddenFieldOperateMoney" runat="server"  Value='<%#Eval("OperateMoney") %>'/>
                                <asp:HiddenField ID="HiddenFieldPaymentName" runat="server"  Value='<%#Eval("PaymentName") %>'/>
                                <a href="javascript:void(0)" title='<%#Eval("Guid")%>' onclick="fundeleteData(this)" runat="server" id="deleteData">删除</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Repeater ID="Rep_NoValue" runat="server" Visible="false">
                    <ItemTemplate>
                        <tr>
                            <td style="height:86px;" colspan="9">
                                <div class="no_data">
                                    <%# DataBinder.Eval(Container.DataItem, "NoValue")%>
                                </div>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="5" class="btntable_t">
            </table>
            <!--分页-->
            <div class="fenye">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="btntable_b">
                    <tr>
                        <td style="border-right: none; border-left: solid 1px #e3e3e3; width: 30px;">
                            &nbsp;
                        </td>
                        <td style="border-left: none;">
                            <div id="pageDiv" runat="server" class="fy">
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <!--分页-->
        </div>
    </div></div>
    <style type="text/css">
    
#tooltip { position:absolute; z-index:1000; max-width:300px; width:auto!important; width:auto; background:#e3e3e3; border:#FEFFD4 solid 1px; text-align:left; padding:3px;}
#tooltip p { padding:10px;color:#FF0000;font:12px verdana,arial,sans-serif; line-height:180%;}
    </style>
    <script type="text/javascript" language="javascript">
         $(function(){
                var reType='<%=Common.ReqStr("RechargeType")%>';
               $("#A_AdPayRecharge_ctl00_sel_PayMentType").find("option[value='"+reType+"']").attr("selected",true);
                //标题提示效果处
                var sweetTitles = {
	                x : 10,	y : 20,tipElements : ".picture",	init : function() {
		                $(this.tipElements).mouseover(function(e){
			                var myTitle=$(this).find("span").html();  
			                var tooltip = "";
			                if(myTitle!="")
			                {
			                    tooltip = "<div id='tooltip'><p>"+myTitle+"</p></div>";
			                }
			                $('#tooltip').css({"opacity":"0.8","top":(e.pageY+20)+"px","left":(e.pageX-50)+"px"}).show('fast');	$('body').append(tooltip);
		                }).mouseout(function(){$('#tooltip').remove();}).mousemove(function(e){$('#tooltip').css({"top":(e.pageY+20)+"px","left":(e.pageX-50)+"px"});});
	                }
                };
                 sweetTitles.init();

	     $("#A_AdPayRecharge_ctl00_sel_PayMent option").each(function(){
			if($(this).text().indexOf("担保")!=-1||$(this).text().indexOf("双向")!=-1)
			{  
 			   $(this).remove();
			}
		});
         
         });
        </script>


    <script type="text/javascript" language="javascript">
    //将选择的银行，赋给 放银行信息的隐藏控件
  $(function(){
     $("#A_AdPayRecharge_ctl00_sel_PayMent").change(function (){
             var payText=$(this).find("option:selected").text();
             var payValue=$(this).find("option:selected").val();
             $("#A_AdPayRecharge_ctl00_hid_PayMent").val(payText);
             $("#A_AdPayRecharge_ctl00_hid_PayMentValue").val(payValue);
             if($(this).find("option:selected").text()=="贝宝支付(PayPal)")
             {
                $("#A_AdPayRecharge_ctl00_txt_Recharge").next().text("美元");
             }
    });
     $("#A_AdPayRecharge_ctl00_sel_PayMentType").change(function (){
         $("#A_AdPayRecharge_ctl00_hid_SelPayMentType").val($("#A_AdPayRecharge_ctl00_sel_PayMentType").find("option:selected").val());
     })
  });

        function funCheckPayType()
        {
            if($("#A_AdPayRecharge_ctl00_sel_PayMent").val()=="-1")
            {
                $("#errPayMent").html("请选择支付方式！");
                return false;
            }
            else
            {
                $("#errPayMent").html("*");
                return true;
            }
            return false;
        }
    
        function funCheckButton()
        {
            if($("#A_AdPayRecharge_ctl00_txt_Remark").val().length>200)
            {
               alert("会员备注长度不能大于200个字符！");return false;
            }
            funCheckMoney();
            funCheckPayType();
            var payPrice=$("#A_AdPayRecharge_ctl00_txt_Recharge").text();
            if(payPrice.indexOf(".")==-1)
                payPrice=payPrice+".00";
            if(funCheckMoney() && funCheckPayType())
            {
                if($("#A_AdPayRecharge_ctl00_sel_PayMent").val()!="4f038afb-debe-45f2-9ca8-e07a23394983")
                {
                    setTimeout("funCheckButton()","5000");
                    this.fromA_AdPayTiXian.target='_blank';
                   // window.location.href=window.location.href+"?response=data";
                }
                return  true;
            }
            return false;
            
        }
    
    
        function funCheckMoney()
        {
            var Transfer=$("#A_AdPayRecharge_ctl00_txt_Recharge").val();
             
            if(Transfer!="")
            {
                var oo = /^\d{1,10}$|^\d{1,10}\.\d{1,2}\w?$/;
                if(!oo.test(Transfer))
                {
                    $("#errMoney").html("充值金额格式错误！");
                    return false;
                }
                else
                {
                    if(parseFloat(Transfer)>0)
                    {
                        $("#errMoney").html("");
                        return true;
                    }
                    else
                    {
                        $("#errMoney").html("充值金额不能为0或者负数！");
                        return false;
                    }
                }
                return false;
            }
            else
            {
                $("#errMoney").html("充值金额不能为空！");
                return false;
            }
        }
        function funChecktxtMobileCode()
            {
                
                var txtMobileCode=$("#A_AdPayRecharge_ctl00_txtMobileCode").val();
                if(txtMobileCode!="")
                {
                    $("#errtxtMobileCode").html("");
                    return true;
                }
                else
                {
                    $("#errtxtMobileCode").html("手机验证码不能为空！");
                }
            }
        
        
    </script>
