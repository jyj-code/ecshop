﻿<%@ Control Language="C#" EnableViewState="false" %>
<%@ Import Namespace="ShopNum1.Common" %>

<% 
    if (ShopSettings.GetValue("IsTransferPay") == "1")
    {
        IsTransfer.Visible = true;
    }
    %>
<div id="list_main" class="list_main1">
    <ul id="sidebar">
        <li class='<%=Common.ReqStr("type")=="0"||Common.ReqStr("type")==""?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="A_AdPayTransfer.aspx?type=0" style="text-decoration: none;">转账</a></li>
        <li class='<%=Common.ReqStr("type")=="1"?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="A_AdPayTransfer.aspx?type=1" style="text-decoration: none;">转出列表</a></li>
       <li class='<%=Common.ReqStr("type")=="2"?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="A_AdPayTransfer.aspx?type=2" style="text-decoration: none;">转入列表</a></li>
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
                        收款人ID：
                    </td>
                    <td>
                        <input name="input" type="text" class="textwb" id="txt_TransferID" runat="server"
                            onblur="funCheckTransferID()" /><span class="star" id="errTransferID">*</span>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        确认收款人ID：
                    </td>
                    <td>
                        <input name="input" type="text" class="textwb" id="txt_ConfirmTransferID" runat="server"
                            onblur="funSameName()" /><span class="star" id="errConfirmTransferID">*</span>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        转账金额：
                    </td>
                    <td>
                        <input name="input" type="text" class="textwb" id="txt_Transfer" runat="server" value="0.00"
                            style="width: 100px;" onblur="funTransfer()" /><span class="star">元</span><span id="errTransfer"
                                style="color: Red"></span>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        商城支付密码：
                    </td>
                    <td>
                        <input name="input" type="password" class="textwb" id="input_PayPwd" runat="server"
                            onblur="funCheckPayPwd()" /><span class="star" id="errPwd">*</span>
                    </td>
                </tr>
                <tr  class="trshowx" runat="server" id="IsTransfer" visible="false"> 
                    <td class="tab_r">
                        短信确认码：
                    </td>
                    <td>
                        <input name="input" type="text" class="textwb" id="txtMobileCode" runat="server" onblur="funChecktxtMobileCode()"  />                        
                        <input type="button" id="butGetCode" value="获取验证码" /><span class="gray1" style="color: Red" id="errtxtMobileCode">*</span>
                        <script type="text/javascript" language="javascript">
                            var timerId;
                            $(function () {
                                $("#A_AdPayTransfer_ctl00_txtMobileCode").val("");
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
                            height: 90px; margin-top: 5px;" runat="server" onchange="CheckFull(this,200)"></textarea><br />(会员转账备注长度不能大于100个字符)
                        <span class="gray1" style="color: Red">&nbsp;</span>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        &nbsp;
                    </td>
                    <td style="padding: 10px 0px 10px 0px;">
                        <asp:Button ID="Btn_Confirm" runat="server" Text="确认" CssClass="baocbtn" OnClientClick=" return funCheckButton()" />
                    </td>
                </tr>
            </table>
        </div>
        <div style='<%=Common.ReqStr("type")=="0"||Common.ReqStr("type")==""? "display:none": "display:block"%>'>
            <div class="pad">
                <table border="0" cellspacing="0" cellpadding="0" class="lineh">
                    <tr class="up_spac">
                        <td align="right">
                            转账单号：
                        </td>
                        <td>
                            <input type="text" runat="server" id="txt_OrderNum" class="ss_nr1" />
                        </td>
                        <td align="right" class="ss_nr_spac">
                            操作时间：
                        </td>
                        <td>
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
                                </tr>
                            </table>
                        </td>
                        <td>
                            <asp:Button ID="Btn_Select" runat="server" Text="查询" CssClass="chax btn_spc" />
                        </td>
                    </tr>
                </table>
            </div>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="btntable_top">
                <tr>
                    <td style="border-left: solid 1px #e3e3e3; text-align: left;">
                        &nbsp;&nbsp;&nbsp; 转账笔数：<span style="color: #ff0000; font-weight: bold;"><asp:Label
                            ID="lab_PayNum" runat="server" Text="0"></asp:Label>
                        </span>笔 &nbsp;&nbsp;&nbsp; 转账金额： ￥<span style="color: #ff0000; font-weight: bold;"><asp:Label
                            ID="lab_PayTransfer" runat="server" Text="0.00"></asp:Label>
                        </span>
                    </td>
                </tr>
            </table>
            <table border="0" cellspacing="1" cellpadding="0" class="biaodhd1" width="100%">
                <tr>
                    <th>
                        转账单号
                    </th>
                    <th>
                        操作日期
                    </th>
                    <th>
                        转账金额
                    </th>
                    <th>
                        收款人ID
                    </th>
                    <th>
                        备注
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="Rep_PayTransfer">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%# DataBinder.Eval(Container.DataItem, "OrderNumber")%>
                            </td>
                            <td>
                                <%# DataBinder.Eval(Container.DataItem, "Date")%>
                            </td>
                            <td style="color: Red">
                                <%=Common.ReqStr("type")=="2"?"+":"-"%><%# DataBinder.Eval(Container.DataItem, "OperateMoney")%>
                            </td>
                            <td>
                                <%# DataBinder.Eval(Container.DataItem, "RMemberID")%>
                            </td>
                            <td class="picture">
                                <span style="display:none;"><%#Eval("Memo").ToString() %></span>
                                <%#(Eval("Memo").ToString().Length > 15? Eval("Memo").ToString().Substring(0, 15) + "..." : Eval("Memo").ToString())%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Repeater ID="Rep_NoValue" runat="server" Visible="false">
                    <ItemTemplate>
                        <tr>
                            <td style="height:86px;"
                                colspan="5">
                                <div class="no_data">
                                    <%# DataBinder.Eval(Container.DataItem, "NoValue")%>
                                </div>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
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
    <input type="hidden" value="" id="havaUser" runat="server" />
    <input type="hidden" value="" id="HiddenPayPwd" runat="server" />
    <%--    <script type="text/javascript" language="javascript">--%>
    <script type="text/javascript" language="javascript">
//         function ontoPage(txtId)
//         {
//               location.href='?sort=<%=Common.ReqStr("sort")%>&typeid=<%=Common.ReqStr("typeid")%>&pageid='+$("#txtIndex").val();
//         }
         $(function(){
                //标题提示效果处
                var sweetTitles = {
	                x : 10,	y : 20,tipElements : ".picture",	init : function() {
		                $(this.tipElements).mouseover(function(e){
			                var myTitle=$(this).find("span").html();  var tooltip = "";
			                tooltip = "<div id='tooltip'><p>"+myTitle+"</p></div>";
			                $('#tooltip').css({"opacity":"0.8","top":(e.pageY+20)+"px","left":(e.pageX-50)+"px"}).show('fast');	$('body').append(tooltip);
		                }).mouseout(function(){$('#tooltip').remove();}).mousemove(function(e){$('#tooltip').css({"top":(e.pageY+20)+"px","left":(e.pageX-50)+"px"});});
	                }
                };
                 sweetTitles.init();
         });
        </script>
    
    <script>
    
    function funCheckButton()
    {
        if($("#A_AdPayTransfer_ctl00_txt_Remark").val().length>100)
        {
            alert("会员转账备注长度不能大于100个字符！");return false;
        }
        funCheckTransferID();funTransfer();funCheckPayPwd();
        if($("#A_AdPayTransfer_ctl00_havaUser").val()=="1" && funTransfer() && $("#<%=HiddenPayPwd.ClientID %>").val()=="1")
        {
            return true;
        }
        return false;
    }
    
    function funCheckPayPwd()
            {
                var payPwd=$("#A_AdPayTransfer_ctl00_input_PayPwd").val();
                if(payPwd!="")
                {
                    $("#errPwd").html("查询中...");
                    $.ajax({
                 type: "get",
                 url: "/Api/ShopAdmin/S_AdminOpt.ashx?date="+new Date(),
                 async: false,
                 data: "type=paypwd&payPwd="+payPwd,
                 dataType: "html",
                 success: function (ajaxData) {
                    if(ajaxData!="")
                    {
                            if(ajaxData=="false")
                             {
                                $("#errPwd").html("支付密码错误！")
                                $("#<%=HiddenPayPwd.ClientID %>").val("0");
                                return true;
                             }
                             else if(ajaxData=="true")
                             {
                                $("#errPwd").html("*")
                                $("#<%=HiddenPayPwd.ClientID %>").val("1");
                                return false;
                             }
                    }
                 }
                }); 
                }
                else
                {
                    $("#errPwd").html("支付密码不能为空！")
                }
                
            }
    
        function funTransfer()
        {
            var Transfer=$("#A_AdPayTransfer_ctl00_txt_Transfer").val()
            if(Transfer!="")
            {
                var oo = /^(-)?(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/;
                if(!oo.test(Transfer))
                {
                    $("#errTransfer").html("转账金额格式错误！");
                    return false;
                }
                else
                {
                    if(parseFloat(Transfer)>0)
                    {
                        var txtMoney=parseFloat($("#A_AdPayTransfer_ctl00_Lab_AdPayment").text());
                        if(txtMoney<parseFloat(Transfer))
                        {
                            $("#errTransfer").html("转账金额不能大于当前预存款！");
                            return false;
                        }
                        else
                        {
                            $("#errTransfer").html("");
                            return true;
                        }
                    }
                    else
                    {
                            $("#errTransfer").html("转账金额不能为0或者负数！");
                            return false;
                    }
                    
                }
                return false;
            }
            else
            {
                $("#errTransfer").html("转账金额不能为空！");
                return false;
            }
        }
    
        function funSameName()
        {
            var samename=$("#A_AdPayTransfer_ctl00_txt_ConfirmTransferID").val();
            var yuanname=$("#A_AdPayTransfer_ctl00_txt_TransferID").val();
            if(samename!=yuanname)
            {
                $("#errConfirmTransferID").html("确认收款人ID输入不正确！");
                return false;
            }
            else
            {
                $("#errConfirmTransferID").html("*");
                return true;
            }
        }
    
    
        function funCheckTransferID()
        {
            var TransferID=$("#A_AdPayTransfer_ctl00_txt_TransferID").val();
            if(TransferID!="")
            {
                if($("#A_AdPayTransfer_ctl00_Lab_MemLoginID").text()==TransferID)
                {
                    $("#errTransferID").html("不能给自己转账！");
                    return false;
                }
                else
                {
                   //收款人是否存在
                    $.ajax
                    ({
                        url: "/api/CheckMemberLogin.ashx",
                        data: encodeURI("type=userisexist&UserID="+TransferID+""),//中文编码
                        success: function(result) 
                        {
                              if(result!=null)
                              {
                                  if(result)
                                  {
                                      $("#errTransferID").html("*");
                                      $("#A_AdPayTransfer_ctl00_havaUser").val("1")                                
                                       return true;
                                  }
                                  else
                                  {
                                        //$("#errTransferID").html("收款人不存在！");
                                        $("#A_AdPayTransfer_ctl00_havaUser").val("0")                                   
                                        return false;
                                   }
                               }
                              else
                              {
                                return false;
                              }
                        }
                    })
            
                $("#errTransferID").html("");
                }
            }else{ $("#errTransferID").html("收款人不能为空！");return false;}
        }
        
        function funChecktxtMobileCode()
            {
                
                var txtMobileCode=$("#A_AdPayTransfer_ctl00_txtMobileCode").val();
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
