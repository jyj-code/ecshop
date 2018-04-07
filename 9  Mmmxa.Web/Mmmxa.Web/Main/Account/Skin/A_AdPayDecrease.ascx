<%@ Control Language="C#" EnableViewState="false" %>
<%@ Import Namespace="ShopNum1.Common" %>

<%
    if (ShopSettings.GetValue("IsDepositPay") == "1")
    {
        IsDecrease.Visible = true; 
    }
 %>

<div id="list_main" class="list_main1">
    <ul id="sidebar">
        <li class='<%=Common.ReqStr("type")=="0"||Common.ReqStr("type")==""?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'
            id="0"><a href="A_AdPayDecrease.aspx?type=0" style="text-decoration: none;">提现申请</a></li>
        <li class='<%=Common.ReqStr("type")=="1"?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="A_AdPayDecrease.aspx?type=1" id="1" style="text-decoration: none;">提现列表</a></li>
    </ul>
    <div id="content">
        <div style='<%=Common.ReqStr("type")=="0"||Common.ReqStr("type")==""? "display:block": "display:none"%>'>
		<br/>
		<strong><font color="red">温馨提示：该提现功能目前只针对商家，个人用户暂不支持提现。</font></strong>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="tabbiao">
                <tr>
                    <td class="tab_r">
                        用户名：
                    </td>
                    <td>
                        <strong style="font-size: 14px;">
                            <asp:Label ID="Lab_MemLoginID" runat="server" Text=""></asp:Label>
                        </strong>
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
                <tr class="trshowx">
                    <td class="tab_r">
                        提现金额：
                    </td>
                    <td>
                        <input  type="text" class="textwb" id="txt_Decrease" runat="server" value="0.00"
                            style="width: 100px;" onchange="funChecktxt_Decrease()"  onblur="funChecktxt_Decrease()"/>
                            <span    class="star">元</span>
                            <span    class="star" id="errmoney"></span>
                    </td>
                </tr>
                <tr class="trshowx">
                    <td class="tab_r">
                        提现方式：
                    </td>
                    <td>
                        <select name="sel" size="1" class="tselect" id="sel_Bank">
                            <option value="-1">请选择</option>
                            <option value="1">线下打款</option>
                            <option value="2">网银在线</option>
                            <option value="3">支付宝</option>
                            <option value="4">财付通</option>
                        </select><span class="star" id="errBank">*</span>
                    </td>
                </tr>
                <tr id="tr_RealName"  class="trshowx">
                    <td class="tab_r">
                        收款人姓名：
                    </td>
                    <td>
                        <input name="input" type="text" class="textwb" id="txt_RealName" runat="server" onblur="funRealName()" maxlength="28"  /><span
                            class="star" id="errname">*</span>
                    </td>
                </tr>
                <tr id="tr_Bank"  class="trshowx">
                    <td class="tab_r">
                        收款银行名称：
                    </td>
                    <td>
                        <input name="input" type="text" class="textwb" id="txt_Bank" runat="server"  maxlength="30"    onblur="funtxt_Bank()"  /><span
                            class="star" id="errbank">* </span>
                    </td>
                </tr>
                <tr id="tr_ConfirmBankID"  class="trshowx">
                    <td class="tab_r">
                        收款人银行账号：
                    </td>
                    <td>
                        <input name="input" type="text" class="textwb" id="txt_ConfirmBankID" runat="server"  maxlength="50"     onblur="funConfirmBankID()"  /><span
                            class="star"   id="errConfirmBankID">*</span>
                    </td>
                </tr>
                <tr id="tr_Account" style="display: none"  class="trshowx">
                    <td class="tab_r">
                        收款人账号：
                    </td>
                    <td>
                        <input name="input" type="text" class="textwb" id="txt_Account" runat="server"   maxlength="30"  onblur="funChecktxt_Account()"  />
                        <span class="gray1" style="color: Red" id="errtxt_Account">*</span>
                    </td>
                </tr>
                <tr  class="trshowx">
                    <td class="tab_r">
                        商城支付密码：
                    </td>
                    <td>
                        <input name="input" type="password" class="textwb" id="input_PayPwd" runat="server"
                            onblur="funCheckPayPwd()"   maxlength="25" /><span class="star" id="errPwd">*</span>
                    </td>
                </tr>
                <tr  class="trshowx" runat="server" id="IsDecrease" visible="false"> 
                    <td class="tab_r">
                        短信确认码：
                    </td>
                    <td>
                        <input name="input" type="text" class="textwb" id="txtMobileCode" runat="server" onblur="funChecktxtMobileCode()"  />                        
                        <input type="button" id="butGetCode" value="获取验证码" /><span class="gray1" style="color: Red" id="errtxtMobileCode">*</span>
                        <script type="text/javascript" language="javascript">
                            var timerId;
                            $(function () {
                                $("#A_AdPayDecrease_ctl00_txtMobileCode").val("");
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
                <tr  class="trshowx">
                    <td class="tab_r">
                        会员备注：
                    </td>
                    <td>
                        <textarea id="txt_Remark" cols="20" rows="2" class="textwb" style="width: 430px;
                            height: 90px; margin-top: 4px;" runat="server"></textarea>
                        <span class="gray1">&nbsp;</span>
                    </td>
                </tr>
                <tr class="trshowx">
                    <td class="tab_r">
                        &nbsp;
                    </td>
                    <td style="padding: 10px 0px 10px 0px;">
                        <asp:Button ID="Btn_Confirm" runat="server" Text="确认" CssClass="baocbtn" OnClientClick="return funCheckButon()" />
                    </td>
                </tr>
            </table>
        </div>
        <div style='<%=Common.ReqStr("type")=="0"||Common.ReqStr("type")==""? "display:none": "display:block"%>'>
            <div class="pad">
                <table border="0" cellspacing="0" cellpadding="0" class="lineh">
                    <tr class="up_spac">
                        <td align="right">
                            提现单号：
                        </td>
                        <td>
                            <input type="text" runat="server" id="txt_OrderNum" class="ss_nr1" />
                        </td>
                        <td align="right" class="ss_nr_spac">
                            操作日期：
                        </td>
                        <td>
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td>
                                        <input type="text" class="ss_nrduan" runat="server" id="txt_StartTime" onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})" />
                                    </td>
                                    <td class="line_spac">
                                        -
                                    </td>
                                    <td>
                                        <input type="text" class="ss_nrduan" runat="server" id="txt_EndTime" onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                        <asp:Button ID="Btn_Select" runat="server" Text="查询" CssClass="chax btn_spc" />
                        </td>
                    </tr>
                    <tr class="up_spac" style=" display:none">
                        <td align="right">
                            提现方式：
                        </td>
                        <td colspan="3">
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td>
                                        <select id="sel_hidbank" runat="server" class="tselect" style="width:228px;">
                                            <option value="-1">请选择</option>
                                            <option value="1">线下打款</option>
                                            <option value="2">网银在线</option>
                                            <option value="3">支付宝</option>
                                            <option value="4">财付通</option>
                                        </select>
                                    </td>
                                    <td id="td_bank" style="padding-left:5px; display:none">
                                        <input type="text" runat="server" id="txt_hidbank" class="ss_nr1" style="width: 120px;" />
                                        <span class="star" id="errBank">线下提现的银行</span>
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
                        &nbsp;&nbsp;&nbsp;交易笔数： <span style="color: Red; font-weight:bold;"><asp:Label ID="lab_PayNum" runat="server" Text="0"></asp:Label>
                        </span>笔 &nbsp;&nbsp;&nbsp; 提现金额： ￥<span style="color: Red; font-weight:bold;"><asp:Label ID="lab_PayDecrease" runat="server" Text="0.00"></asp:Label>
                        </span>
                    </td>
                </tr>
            </table>
            <table border="0" cellspacing="1" cellpadding="0" class="biaodhd1" width="100%">
                <tr>
                    <th>
                        提现单号
                    </th>
                    <th>
                        操作日期
                    </th>
                    <th>
                        当前预存款
                    </th>
                    <th>
                        提现金额
                    </th>
                    <th>
                        提现方式
                    </th>
                    <th>
                        提现状态
                    </th>
                    <th>
                        管理员备注
                    </th>
                       <th>
                        会员备注
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="Rep_PayDecrease">
                    <ItemTemplate>
                        <tr>
                            <td style="display: none;">
                                <asp:CheckBox ID="checkboxAll" runat="server" /><span runat="server" visible="false"
                                    id="guid"><%# DataBinder.Eval(Container.DataItem, "Guid") %></span>
                            </td>
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
                                -<%# DataBinder.Eval(Container.DataItem, "OperateMoney")%>
                            </td>
                            <td>
                                <%# DataBinder.Eval(Container.DataItem, "Bank")%>
                            </td>
                            <td class="blue">
                                <%#ShopNum1.AccountWebControl.A_AdPayDecrease.GetState(Eval("OperateStatus").ToString())%>
                            </td>
                            <td class="picture">
                                <span style="display:none;" ><%#Eval("UserMemo").ToString()%></span>
                             <%#(Eval("UserMemo").ToString().Length > 6 ? Eval("UserMemo").ToString().Substring(0, 6) + "..." : Eval("UserMemo").ToString())%> 
                                
                            </td>
                            <td class="picture">
                                <span style="display:none;"><%#Eval("Memo").ToString()%></span>
                             <%#(Eval("Memo").ToString().Length > 6? Eval("Memo").ToString().Substring(0, 6) + "..." : Eval("Memo").ToString())%>
                           </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Repeater ID="Rep_NoValue" runat="server" Visible="false">
                    <ItemTemplate>
                        <tr>
                            <td style="height:86px;" colspan="8">
                                <div class="no_data">
                                    <%# DataBinder.Eval(Container.DataItem, "NoValue")%></div>
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
            <input id="hid_BankType" type="hidden" runat="server" />
            <input id="hid_RealName" type="hidden" runat="server" />
            <asp:HiddenField ID="hid_SelectBank" runat="server" Value="-1" />
        </div>
        <input id="HiddenShow" type="hidden" runat="server"  value="0"/>
        
        <input id="HiddenPayPwd" type="hidden" runat="server"  value="0"/>
        <input type="hidden" id="hidMemberType" runat="server" />
        
        <style type="text/css">
    
#tooltip { position:absolute; z-index:1000; max-width:300px; width:auto!important; width:auto; background:#e3e3e3; border:#FEFFD4 solid 1px; text-align:left; padding:3px;}
#tooltip p { padding:10px;color:#FF0000;font:12px verdana,arial,sans-serif; line-height:180%;}
    </style>
    <script type="text/javascript" language="javascript">
//         function ontoPage(txtId)
//         {
//               location.href='?sort=<%=Common.ReqStr("sort")%>&typeid=<%=Common.ReqStr("typeid")%>&pageid='+$("#txtIndex").val();
//         }
         $(function(){
                 if($("#A_AdPayDecrease_ctl00_hidMemberType").val()=="1")
                 {
                    $(".trshowx").hide();
                 }
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
        
        
        
        
        
        
        <script type="text/javascript" language="javascript">
     //将选择的银行，赋给 放银行信息的隐藏控件
  $(function(){
     $("#sel_Bank").change(function (){
       if($("#sel_Bank").find("option:selected").val()=="1")
       {
            $("#errBank").html("*");
           $("#A_AdPayDecrease_ctl00_HiddenShow").val(0)
           $("#tr_RealName").show();
           $("#tr_Bank").show();
           $("#tr_ConfirmBankID").show();
           $("#tr_Account").hide();
           $("#tr_Account").val("");
           $("#A_AdPayDecrease_ctl00_hid_BankType").val($("#sel_Bank").find("option:selected").text());
       }
       if($("#sel_Bank").find("option:selected").val()!="1"&&$("#sel_Bank").find("option:selected").val()!="-1")
       {
           $("#errBank").html("*");
           $("#A_AdPayDecrease_ctl00_HiddenShow").val(1)
           $("#tr_Account").show();
           $("#tr_RealName").hide();
           $("#tr_Bank").hide();
           $("#tr_ConfirmBankID").hide();
           $("#tr_RealName").val();
           $("#tr_Bank").val();
           $("#tr_ConfirmBankID").val();
           $("#A_AdPayDecrease_ctl00_hid_BankType").val($("#sel_Bank").find("option:selected").text());
       }
       if($("#sel_Bank").find("option:selected").val()=="-1")
       {
            $("#errBank").html("请选择一个银行！");
            $("#A_AdPayDecrease_ctl00_HiddenShow").val(-1)
       }
       
      }
   ),
   
    $("#A_AdPayDecrease_ctl00_sel_hidbank").change(function (){
          $("#A_AdPayDecrease_ctl00_hid_SelectBank").val($("#A_AdPayDecrease_ctl00_sel_hidbank").find("option:selected").val());
//          if($("#A_AdPayDecrease_ctl00_hid_SelectBank").val()=="1")
//          {
//               $("#td_bank").show();
//          }
//          else
//          {
//             $("#td_bank").hide();
//          }
        })
   
   
  })
        </script>
        
        <script>
            function funChecktxt_Decrease()
            {
                var txt_Decrease=$("#A_AdPayDecrease_ctl00_txt_Decrease").val();
                if(txt_Decrease!="")
                {
                    var oo = /^\d{1,10}$|^\d{1,10}\.\d{1,2}\w?$/;
                    if(!oo.test(txt_Decrease))
                    {
                        $("#errmoney").html("提现金额格式错误！");
                        return false;
                    }
                    else
                    {
                        var allMoney=parseFloat($("#A_AdPayDecrease_ctl00_Lab_AdPayment").text())
                        if(parseFloat(txt_Decrease)>0)
                        {
                            if(parseFloat(txt_Decrease)>allMoney)
                            {
                                $("#errmoney").html("提现金额不能大于当前预存款金额！");
                                return false;
                            }
                            else
                            {
                                $("#errmoney").html("");
                                return true;
                            }
                        }
                        else
                        {
                            $("#errmoney").html("提现金额不能为0和负数！");
                            return false;
                        }
                    }
                }
                else
                {
                    $("#errmoney").html("提现金额不能为空！");
                    return false;
                }
                return false;
            } 
            
            function funRealName()
            {
                var RealName=$("#A_AdPayDecrease_ctl00_txt_RealName").val();
                if(RealName!="")
                {
                    $("#errname").html("");
                    return true;
                }
                else
                {
                    $("#errname").html("收款人姓名不能为空！");
                    return false;
                }
            }
            
            function funtxt_Bank()
            {
                var bank=$("#A_AdPayDecrease_ctl00_txt_Bank").val();
                if(bank!="")
                {
                    $("#errbank").html("");
                    return true;
                }
                else
                {
                    $("#errbank").html("收款银行名称必填！");
                    return false;
                }
            }
            
            function funConfirmBankID()
            {
                var ConfirmBankID=$("#A_AdPayDecrease_ctl00_txt_ConfirmBankID").val();
                if(ConfirmBankID!="")
                {
                    $("#errConfirmBankID").html("");
                    return true;
                }
                else
                {
                    $("#errConfirmBankID").html("收款人银行账号不能为空！");
                    return false;
                }
            }
            
            //检查支付密码
            function funCheckPayPwd()
            {
                var payPwd=$("#A_AdPayDecrease_ctl00_input_PayPwd").val();
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
                                $("#errPwd").html("")
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
            
            function funCheckButon()
            {
                //button事件
                funChecktxt_Decrease();
                if($("#sel_Bank").find("option:selected").val()=="-1")
                {
                    $("#errBank").html("请选择一个银行！");
                }
                funRealName();
                funtxt_Bank();
                funConfirmBankID();
                funCheckPayPwd();
                try{
                    if ($("#A_AdPayDecrease_ctl00_txtMobileCode").is(":visible")) {
                        if ($("#A_AdPayDecrease_ctl00_txtMobileCode").val() == "") { $("#errtxtMobileCode").html("手机验证码不能为空！"); return false; }
                    }
                }catch(e){}
                if($("#A_AdPayDecrease_ctl00_HiddenShow").val()=="0")
                {
                    if(funChecktxt_Decrease()&&funRealName()&&funtxt_Bank()&&funConfirmBankID()&&$("#<%=HiddenPayPwd.ClientID %>").val()=="1")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    
                }
                else if($("#A_AdPayDecrease_ctl00_HiddenShow").val()=="1")
                {
                    if(funChecktxt_Account()&&$("#<%=HiddenPayPwd.ClientID %>").val()=="1")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    return false;
                }
                return false;
            }
            
            function funChecktxt_Account()
            {
                var txt_Account=$("#A_AdPayDecrease_ctl00_txt_Account").val();
                if(txt_Account!="")
                {
                    $("#errtxt_Account").html("");
                    return true;
                }
                else
                {
                    $("#errtxt_Account").html("收款人账号不能为空！");
                    return false;
                }
                return false;
            }
            function funChecktxtMobileCode()
            {
                
                var txtMobileCode=$("#A_AdPayDecrease_ctl00_txtMobileCode").val();
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