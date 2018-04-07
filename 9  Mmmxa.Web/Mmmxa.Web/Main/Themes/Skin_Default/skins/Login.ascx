﻿<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<script language="javascript" type="text/javascript">

//验证码
 var boolresult=true;
function existcode() 
{  
    var inputcontrol=$("#Login_ctl00_TextBoxCode").val();
    
    
         $("#<%= TextBoxCode.ClientID %>").removeClass("login_text2");
   
    var context = document.getElementById("spanCode");
     if(inputcontrol != "")
     {
        $.ajax
        ({
            url:"/api/CheckMemberLogin.ashx",
            data:"type=getverifycode&code="+inputcontrol+"",
            success:function(result)
            {
                if(result=="true")
                {
//                    context.innerHTML="验证码正确";
//                    context.className="onCorrect";
                   document.getElementById("spanCode").style.display="none";
                   $("spanCode").removeClass("loginError1");
                   boolresult=true;
                    
                }
                else
                {
                    context.innerHTML="验证码错误";
                    context.className="loginError1";
                    boolresult=false;
                }
            }
        })
    }
    else 
    {
        context.innerHTML = "验证码不能为空";
        context.className="loginError1";
        boolresult=false;
    }
    return boolresult;
}</script>
<script type="text/javascript">
var theForm = document.forms[0];
if (!theForm) {
    theForm = document.form1;
}
function SecondLogin(eventTarget, eventArgument) {
 
    if (!theForm.onsubmit || (theForm.onsubmit() != false)) 
    {
    var SE=document.getElementById("secondEVENTTARGET");
    SE=eventTarget;
        theForm.secondEVENTTARGET.value = SE;
        theForm.secondEVENTARGUMENT.value = eventArgument;
      
        theForm.submit();
    }
}
</script>
<script type="text/javascript">
$(document).ready(function(){




$("#Login_ctl00_TextBoxMemLoginID").val("");
//$("#Login_ctl00_LabelLoginInfo").text("");
$("#Login_ctl00_TextBoxCode").val("");




if($("#Login_ctl00_LabelLoginInfo").text()=="")
{
 $("#<%= LabelLoginInfo.ClientID %>").removeClass("loginError2");
// $("#Login_ctl00_LabelLoginInfo").text("");
//else{
  //$("#<%= LabelLoginInfo.ClientID %>").addClass("");
}
      $(".login").show();
//      $(".login_info").hide();
})
function SecondLoginUrl(id)
{
$.ajax
({
  url:"/api/SecondLogin.ashx",
  data:"type=secondlogin&SecondID="+id+"",
  success:function(url){
  if(url!="")
  {
    window.location.href=url;
  }
  }
})
}
//鼠标进入文本框 
function trun()
{   
    $("#<%= TextBoxMemLoginID.ClientID %>").addClass("login_text1");
 // document.getElementById("Login_ctl00_TextBoxMemLoginID").className="login_text1";
    var inputcontrol=$("#<%=TextBoxMemLoginID.ClientID %>").val();
    if(inputcontrol=="用户名/手机/邮箱")
    {
        $("#<%=TextBoxMemLoginID.ClientID %>").val("");
    }
}
//鼠标进入文本框 
function trun1()
{   
//  document.getElementById("Login_ctl00_TextBoxPwd").className="login_text1";
   $("#<%= TextBoxPwd.ClientID %>").addClass("login_text1");
}
//鼠标进入文本框 
function trun2()
{   
  //document.getElementById("Login_ctl00_TextBoxCode").className="login_text2";
  $("#<%= TextBoxCode.ClientID %>").addClass("login_text2");$("#spanCode").hide();
}


//移出文本 
function CheckIsEmalOrMobile()
{   
     var inputcontrol=$("#<%=TextBoxMemLoginID.ClientID %>").val();
     if(inputcontrol=="")
     {
        $("#<%= TextBoxMemLoginID.ClientID %>").removeClass("login_text1");

        $("#<%=TextBoxMemLoginID.ClientID %>").val("用户名/手机/邮箱");
     }
     else
     {$("#<%= TextBoxMemLoginID.ClientID %>").removeClass("login_text1");

        
       document.getElementById("spanMemLogin").style.display="none";
     }
     
     var inputcontrol1=$("#<%=TextBoxPwd.ClientID %>").val();
     if(inputcontrol1!="")
     {
       $("#<%= TextBoxPwd.ClientID %>").removeClass("login_text1");
       
//        document.getElementById("Login_ctl00_TextBoxPwd").className="text login_text";

        document.getElementById("spanPwd").style.display="none";
     }else
     {
   
   $("#<%= TextBoxPwd.ClientID %>").removeClass("login_text1");
      

     }
     
     
   
}
</script>
<!--未登录时显示-->
<div class="fregist" id="divlogin" runat="server" >
    <div class="login_border_right fl">
        <img src="Themes/Skin_Default/Images/LoginLeftImg.jpg" />
    </div>
    <div class="fcon fcon_login fr">
        <div class="form" style="position:relative;">
        
            <table class="login_tab" cellpadding="0" cellspacing="0">
                <tr>
                    <td id="Td1">用户名/手机/邮箱</td>
                </tr>
                <tr class="item item1">
                    <td valign="top">
                        <div style="position:relative;">
                            <asp:TextBox ID="TextBoxMemLoginID" CssClass="text login_text" runat="server" onfocus='trun()' MaxLength="20" onblur="CheckIsEmalOrMobile()"></asp:TextBox>
                            <span id="spanMemLogin" class="null"></span>
                            <i class="i1"></i>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td id="Td2">密码</td>
                </tr>
                <tr class="item item1">
                    <td valign="top">
                        <div style="position:relative;">
                            <asp:TextBox ID="TextBoxPwd" runat="server" CssClass="text login_text" onfocus='trun1()'  TextMode="Password" MaxLength="15" onblur="CheckIsEmalOrMobile()" onkeydown="if(event.keyCode==13){(document.getElementById('<%=ButtonLogin.CilentID %>')).focus();(document.getElementById('<%=ButtonLogin.CilentID %>')).click(); }"></asp:TextBox>
                            <span id="spanPwd" class="null"></span>
                            <s></s>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td id="Td3">验证码</td>
                </tr>
                <tr class="item item1" id="VerifyCode" runat="server">
                    <td valign="top">
                        <div style="position:relative;">
                            <table class="identy_tab" cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td valign="middle" align="left">
                                        <asp:TextBox ID="TextBoxCode" onblur="existcode()" onfocus='trun2()'  onkeydown="if(event.keyCode==13){document.getElementById('Login_ctl00_ButtonLogin').focus();document.getElementById('Login_ctl00_ButtonLogin').click();}" runat="server" CssClass="text textcode login_textcode"></asp:TextBox>
                                    </td>
                                    <td valign="middle" align="left">
                                        <img src="/imagecode.aspx?javascript:Math.random()"  id="safecode" onclick="reloadcode()" alt="看不清?点一下" />
                                    </td>
                                    <td valign="middle" align="left"> <a onclick="reloadcode()">看不清楚?点一下 </a>
                                    </td>
                                    
                                </tr>
                            </table>
                            <span id="spanCode" class="null"></span>
                            <asp:Label ID="LabelLoginInfo" runat="server" Text="" ForeColor="Red" class="loginError2"></asp:Label>
                        </div>
                    </td>
                </tr>
                <asp:Panel ID="panel" runat="server" Visible="false">
                    <tr class="item item1">
                        <td width="120" align="right">有效期：</td>
                        <td height="30" valign="middle">
                            <asp:DropDownList ID="LoginValidity" runat="server">
                                <asp:ListItem Value="" Selected="True">即时</asp:ListItem>
                                <asp:ListItem Value="1h">一小时</asp:ListItem>
                                <asp:ListItem Value="1d">一天</asp:ListItem>
                                <asp:ListItem Value="1w">一星期</asp:ListItem>
                                <asp:ListItem Value="1m">一个月</asp:ListItem>
                                <asp:ListItem Value="1y">一年</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr class="item item1">
                        <td>&nbsp;</td>
                        <td><input type="checkbox" />记住用户名</td>
                        <td><input type="checkbox" />自动登录</td>
                        <td>&nbsp;</td>
                    </tr>
                </asp:Panel>
                <tr class="item item1">
                    <td>
                        <table class="loging_tab" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td valign="middle" align="left">
                                    <span class="login">
                                        <asp:Button ID="ButtonLogin" class="denglu" runat="server" Text="登录" style="margin-top:24px; cursor:pointer;" UseSubmitBehavior="false"
                                            OnClientClick="if(checkLoginID()){this.disabled='disabled';} else{return false;}" />
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td valign="middle" align="left"><span class="login_info"><img src="/Main/Themes/Skin_Default/Images/lodding.gif" />加载中...</span></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            
        </div>
        <div class="cooperate">使用合作网站账号登录：</div>
        <div class="san_caborate">
            <ShopNum1:SecondLogin ID="SecondLogin" runat="server" SkinFilename="SecondLogin.ascx" />
        </div>
    </div>    
    <div class="clear"></div>
</div>
<!--登录后显示-->
<div id="divAgainLogin" runat="server" class="regester">
    <div class="regester_con">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="lmf_padd">
                    <div class="lmf_gth">
                        <span>您好！您已经成功登陆！</span>
                    </div>
                    <div class="member_text">您登陆本商城的用户名为：
                        <span><asp:Label ID="LabelMemLoginID" runat="server" Text=""></asp:Label></span>，您随时可以使用此用户名享受便宜又放心的购物乐趣。 
                    </div>
                    <div class="lmf_member lmf_member1"><a href='<%=ShopUrlOperate.RetMemberUrl("M_index") %>'>进入会员中心</a></div>
                    <div class="lmf_member"><a href='<%=ShopUrlOperate.RetUrl("default") %>'>立刻去购物</a></div>
                </td>
            </tr>
        </table>
    </div>
</div>
<div>
    <input type="hidden" name="secondEVENTTARGET" id="secondEVENTTARGET" value="" />
    <input type="hidden" name="secondEVENTARGUMENT" id="secondEVENTARGUMENT" value="" />
</div>
<script language="javascript" type="text/javascript">
    function reloadcode()
    {
    var verify=document.getElementById('safecode');
    verify.setAttribute('src','/imagecode.aspx?'+Math.random());
    }
function checkLoginID()
{

  //document.getElementById('HiddenFielddelu').value=1;
//$("#<%=LabelLoginInfo.ClientID%>").html("");
   var loginid=document.getElementById('<%=TextBoxMemLoginID.ClientID %>').value;
   var password=document.getElementById('<%=TextBoxPwd.ClientID %>').value;
   var BoxCode=document.getElementById('<%=TextBoxCode.ClientID %>').value;
    
    document.getElementById("spanMemLogin").innerHTML=="";
     document.getElementById("spanPwd").innerHTML="";
   var errc=0;
   $("#spanCode").show();
   if(BoxCode=="")
   {
      document.getElementById("spanCode").innerHTML="请输入验证码";
        document.getElementById("spanCode").className="loginError";
      errc=1;
   }
   if(loginid=="")
   {
    
     document.getElementById("spanMemLogin").innerHTML="请输入用户名";
     document.getElementById("spanMemLogin").className="loginError";
     errc=1;
   }
   
//     var regUser = /^[\u4e00-\u9fa5\da-zA-Z\-\_]{2,12}$/
//     if(regUser.test(loginid)) 
//     { 
//        //是会员名
//        $("#<%=HiddenFieldLoginType.ClientID %>").val("1");
//     }
//     //邮箱验证
//     var regEmail =/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/; 
//     if(regEmail.test(loginid)) 
//     { 
//        //是邮箱
//       $("#<%=HiddenFieldLoginType.ClientID %>").val("2");
//     }
   if(password=="")
   {
   
    document.getElementById("spanPwd").innerHTML="密码不能为空";
    document.getElementById("spanPwd").className="loginError";
    errc=1;
   }
   if(errc==1)
   {
 
   
        $("#<%= LabelLoginInfo.ClientID %>").removeClass("loginError2");

     return false;
   }
 
   if(boolresult==false){

     return false;
   }
    $(".login").hide();
   $(".login_info").show();

   

  
   return true;
}
</script>
<asp:HiddenField ID="HiddenFieldLoginType" runat="server" /><!--1 会员名 2 邮箱-->

<input id="HiddenFielddelu" type="hidden" />