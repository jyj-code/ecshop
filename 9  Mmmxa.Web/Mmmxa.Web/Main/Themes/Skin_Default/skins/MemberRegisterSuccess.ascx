<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<script type="text/javascript">
  if (top.location != location) top.location.href = location.href;
</script>
<!--邮箱找回-->
<asp:Panel ID="PanelYes" runat="server" Visible="false">
<table width="100%" border="0" cellspacing="0" cellpadding="0" style="text-align: left;
                height: 180px; text-align:center">
                <tr style="height: 76px; line-height: 70px; ">
                    <td style=" text-align:right; width:40%">
                         <img src="Themes/Skin_Default/Images/dagou.gif" />
                    </td>
                    <td style="color:#029900; font-size:26px; font-weight:bold; text-align:left; width:60%">
                         邮箱验证成功！
                         
                    </td>
                </tr>
                <tr style="height: 76px; line-height: 70px;  text-align:center">
                    
                    <td style="font-size:12px; text-align:left; text-align:center" colspan="2">
                         请点击<asp:LinkButton ID="LinkButtonLogin" runat="server" ForeColor="Red" >【登录】</asp:LinkButton>进入登录界面
                    </td>
                </tr>
            </table>
 </asp:Panel>
 
<asp:Panel ID="PanelNO" runat="server" Visible="false">
<table width="100%" border="0" cellspacing="0" cellpadding="0" style="text-align: left;
                height: 180px; text-align:center">
                <tr style="height: 76px; line-height: 70px; ">
                    <td style=" text-align:right; width:30%">
                         <img src="Themes/Skin_Default/Images/cancel.gif" />
                    </td>
                    <td style="color:Red; font-size:26px; font-weight:bold; text-align:left; width:70%">
                         很遗憾！该链接已经失效。
                    </td>
                </tr>
            </table>
</asp:Panel>
<asp:Panel ID="PanelSan" runat="server" Visible="false">
<table width="100%" border="0" cellspacing="0" cellpadding="0" style="text-align: left;
                height: 190px; text-align:center">
                <tr style="height:100px; line-height: 100px;">
                    <td style=" text-align:right; width:30%">
                         <img src="Themes/Skin_Default/Images/dagou.gif" />
                    </td>
                    <td style="color:Green; font-size:26px; font-weight:bold; text-align:left; width:70%">
                         恭喜您，注册成功！
                    </td>
                </tr>
                <tr style="height: 23px; text-align:center">
                    <td style=" width:30%;">
                    </td>
                    <td style="font-size:12px; text-align:left; vertical-align:text-top; width:70%" colspan="2" >
                         您登陆本商城的用户名为：<asp:Label ID="LabelUserName" runat="server" Text="" Font-Bold="true"></asp:Label>，您随时可以使用此用户名享受便宜又放心的购物乐趣。
                    </td>
                </tr>
                <tr style="height: 67px; line-height:67px; text-align:center">
                    <td style=" width:30%;">
                    </td>
                    <td style="font-size:12px; text-align:left; vertical-align:text-top; width:70%" colspan="2" >
                     <a href='<%=ShopUrlOperate.RetMemberUrl("M_index") %>'><img src="Themes/Skin_Default/Images/entermember.gif"   /></a>&nbsp;&nbsp;&nbsp;<a href='<%=ShopUrlOperate.RetUrl("default") %>'><img src="Themes/Skin_Default/Images/20120912112746_07.gif" /></a>
                    </td>
                </tr>
            </table>
 </asp:Panel>
 <div class="reg-form" style="display:none;">
            <p class="reg-form-tips">只差一步，尊享最安全快捷的网购体验！</p>
            <input type="hidden" value="ff6a0700dc8f6736c0697a84775e81c4" id="k">

            <div class="reg-email">

                <div class="item">
                    <label>您的手机号：</label><input type="text" style="ime-mode:disabled" autocomplete="off" class="text" id="moblie">
                    <input type="button" value="获取短信验证码" class="reg-btn2" id="send-sms">
                </div>
                <div id="smsFocusDiv" class="item hide">
                    <span id="smsFocusMessage" class="sms-tips mobileFocus"></span>
                </div>
                <div id="sms-box" class="item hide">
                    <label>短信验证码：</label><input type="text" style="ime-mode:disabled" class="text text2" id="mobileCode">
                    <span id="successMes" class="sms-tips"></span>
                </div>
                <div id="smsErrorDiv" class="item hide">
                    <span style="padding-left: 70px;_padding-left:73px;color: #FF0000" id="smsErrorMessage" class="sms-tips"></span>
                </div>
                <div id="validateMobileDiv" class="sms-btn hide"><input type="button" class="reg-btn4" value="验证手机" id="toValidate"></div>

            </div>
</div>

<asp:HiddenField ID="HiddenFieldIsEmailYz" runat="server"  Value="0"/>
<script type="text/javascript">
    $(function(){
        if($("#<%=HiddenFieldIsEmailYz.ClientID %>").val()=="1")
        {
            $("#emailsend").hide();
        }
        else
        {
            $("#emailsend").show();
        }
    })
</script>
<div class="reg-form" id="emailsend">
    <p class="reg-form-tips">
        超过<em>80%</em>的用户选择了立即验证邮箱，账户更安全购物更放心。
    </p>
    <div id="sendEmailDiv" class="reg-email">
        <label>您的邮箱：</label>
        <input id="emailStr" class="text" type="text" autocomplete="off" onblur="if(this.value=='') this.value='请输入您常用的电子邮箱'" onfocus="if(this.value=='请输入您常用的电子邮箱') this.value=''" value="请输入您常用的电子邮箱">
        <input id="sendEmail" class="reg-btn2" type="button" value="发送验证邮件" />        
        <span class="clr"></span>
        <div id="email_error" style="color: #FF0000;padding-left:63px;"></div>
        <div id="email_focus" style="padding-left:63px; display:none;">完成验证后，你可以用该邮箱登录本商城，找回密码。</div>
    </div>  
    <div id="identyCode" class="reg-email clearfix" style="margin-top:0;display:none;">
        <label>验证码：</label>
        <input id="txtCode" class="text" type="text"  runat="server" />        
        <span class="vc vf" id="yzMsg" style="display:none">
         <%--请输入验证码--%>
        </span>
        <span class="form_left">
        </span>
       <span class="form_right gw">
            <%-- 验证码是8位数字--%>                    
            <span id="spanYZMIsSend"></span>
        </span>
        <span class="clr"></span>
        <input id="CodeSure" type="button" class="reg-btn2" value="确定" style="margin-left:65px; margin-top:20px; float:none;" />   
    </div> 
</div>

<script type="text/javascript">
    
    $(function () {
　　    $("#emailStr").click(function(event){
            $('#email_focus').show();
            event.stopPropagation();
        });
        
        $('#sendEmail').click(function(){
            $('#identyCode').show();
        });
        
        $(document).click(function(){$('#email_focus').hide();});
        $("#sendEmail").click(function(){
        var email = $("#emailStr").val();
        email = $.trim(email);
        if (email == "" || email == "请输入您要验证的邮箱号") {
            $("#email_error").css("color","red").html("邮箱不能为空");
            return;
        }
        if (isEmail(email) == false) {
            $("#email_error").css("color","red").html("请输入有效的邮箱地址");
            return;
        }
        if (email.length > 30 || email.length < 4) {
            $("#email_error").css("color","red").html("邮箱地址长度应在4-30个字符之间");
            return;
        }
        $.get("/Api/CheckInfo.ashx?type=12&Email="+$("#emailStr").val(),null,function(data)
        {
            var bflag=false;
            if(data=="1")
            {     
                $.get("/Api/CheckInfo.ashx?type=4&Email="+$("#emailStr").val(),null,function(data)
                {
                   if(data != "1")
                   {
                       $("#email_error").css("color","red").text("邮件发送出现异常，请重新验证");
                   }else{
                        
                         $("#email_error").css("color","green").html("邮件发送成功!");
                         $("#sendEmail").css("background","#bfbfbf").attr("disabled",true);
                        
                   }
                });
            }
            else
            {
                 $("#email_error").css("color","red").html("邮箱已经被使用过了");
            }
      });
                     
        });
    });
    
    $("#CodeSure").click(function(){
                
                 if($("#MemberRegisterSuccess_ctl00_txtCode").val()=="")
                 {
                    $("#spanYZMIsSend").get(0).className = "onError1";
                    $("#spanYZMIsSend").text("请输入验证码");
                    return false;
                  }
                 else
                 {
                    $.get("/Api/CheckInfo.ashx?type=5&key="+$("#MemberRegisterSuccess_ctl00_txtCode").val()+"&Email="+$("#emailStr").val(),null,function(data)
                    {
                        if(data=="1")
                        {                           
                           alert("邮箱已激活!");  location.href="/main/account/A_Index.aspx?toaurl=A_PwdSer.aspx";
                        }else
                        {
                            $("#spanYZMIsSend").get(0).className = "onError1";
                            $("#spanYZMIsSend").text("验证码错误或已过期，请重新输入！");
                            return false;
                         }
                    });
                }
            });
            
            
            $("#MemberRegisterSuccess_ctl00_txtCode").focus(function(){
                $("#spanYZMIsSend").get(0).className = "onTips1";
                $("#spanYZMIsSend").text("验证码是8位字符");
                $("#spanConfirm").get(0).className = "";
            });
        
            
</script>

<script type="text/javascript" language="javascript">
        function isEmail(str) {
                return new RegExp("^\\w+((-\\w+)|(\\.\\w+))*\\@[A-Za-z0-9]+((\\.|-)[A-Za-z0-9]+)*\\.[A-Za-z0-9]+$").test(str);
        }
        var emailLoginUrlArrar = ['@gmail.com=http://mail.google.com/',
        '@163.com=http://mail.163.com/',
        '@126.com=http://mail.126.com/',
        '@hotmail.com=http://www.hotmail.com/',
        '@sina.com=http://mail.sina.com/',
        '@vip.sina.com=http://mail.sina.com/',
        '@tom.com=http://mail.tom.com/',
        '@qq.com=http://mail.qq.com/',
        '@139. com=http://mail.10086.cn/',
        '@msn.com=https://login.live.com/login.srf',
        '@sohu.com=http://mail.sohu.com/'];
        
        function getEmailLoginUrl(email) {

            email = email.toLowerCase();
            if (email == "" || !isEmail(email)) {
                return null;
            }
            var index = email.indexOf("@");
            var emailSurfix = email.substring(index, email.length);
            for (var i = 0; i < emailLoginUrlArrar.length; i++) {
                if (emailLoginUrlArrar[i].indexOf(emailSurfix) == 0) {
                    return emailLoginUrlArrar[i].split("=")[1];
                }
            }
            return null;
        }
</script>


 <asp:Panel ID="PanelMobile" runat="server" Visible="false">
<table width="100%" border="0" cellspacing="0" cellpadding="0" style="text-align: left;
                height: 190px; text-align:center">
                <tr style="height:100px; line-height: 100px;">
                    <td style=" text-align:right; width:30%">
                         <img src="Themes/Skin_Default/Images/dagou.gif" />
                    </td>
                    <td style="color:Green; font-size:26px; font-weight:bold; text-align:left; width:70%">
                         恭喜您  手机注册成功！
                    </td>
                </tr>
                <tr style="height: 23px; text-align:center">
                    <td style=" width:30%;">
                    </td>
                    <td style="font-size:12px; text-align:left; vertical-align:text-top; width:70%" colspan="2" >
                         您可直接使用手机：<asp:Label ID="LabelMobile" runat="server" Text="" Font-Bold="true"></asp:Label>登陆，您随时可以使用此用户名享受便宜又放心的购物乐趣。
                    </td>
                </tr>
                <tr style="height: 67px; line-height:67px; text-align:center">
                    <td style=" width:30%;">
                    </td>
                    <td style="font-size:12px; text-align:left; vertical-align:text-top; width:70%" colspan="2" >
                     <a href='<%=ShopUrlOperate.RetMemberUrl("M_index") %>'><img src="Themes/Skin_Default/Images/entermember.gif"   /></a>&nbsp;&nbsp;&nbsp;<a href='<%=ShopUrlOperate.RetUrl("default") %>'><img src="Themes/Skin_Default/Images/20120912112746_07.gif" /></a>
                    </td>
                </tr>
            </table>
 </asp:Panel>