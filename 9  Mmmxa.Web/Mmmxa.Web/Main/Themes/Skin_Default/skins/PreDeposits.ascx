<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
 <%
if (ShopSettings.GetValue("IsMobileCheckPay") == "1")
{
    IsPay.Visible = true;
}
%>
<div id="divAgainLogin" runat="server" class="PayPage">
    <div class="PayPageUp">
        <p>您正在使用预存款支付交易...</p>
    </div>
    <div class="PayPageInfo">
        <p>交易号：<asp:TextBox ID="TextBoxOrderID" Enabled="false" runat="server" CssClass="font1"></asp:TextBox></p>
        <p>交易金额：<asp:Label ID="LabelShouldPay" Enabled="false" runat="server" CssClass="font2"></asp:Label>元</p>
        <p class="fenge"><b>预存款账户</b>可交易余额：<asp:Label ID="LabelAdvancePayment" runat="server" CssClass="font3"></asp:Label>元</p>
        <p class="fenge" runat="server" id="noPay"><b> <a target="_blank" href='http://<%=ShopNum1.Common.ShopSettings.siteDomain%>/main/account/A_Index.aspx?toaurl=A_PwdSer.aspx'  style="color:#005ea7;">警告：您尚未设置支付密码，马上去设置支付密码</a></b></p>
        <div class="buzhu" id="xianshi" style="display:none;">
            <p>您的账户没有可交易余额不足，请使用其它方式付款，或<a href="account/A_Index.aspx?toaurl=A_AdPayRecharge.aspx" target="_blank">充值</a>后付款</p>
        </div>
          <script type="text/javascript" language="javascript">
          $(function(){
                  var LabelAdvancePayment=$("#preDeposits_ctl00_LabelAdvancePayment").text();//预存款可交易余额
                  var preDeposits_ctl00_LabelShouldPay=$("#preDeposits_ctl00_LabelShouldPay").text();//订单金额
                 if(parseFloat(LabelAdvancePayment)<parseFloat(preDeposits_ctl00_LabelShouldPay))
                 {
                  document.getElementById("xianshi").style.display="block";
            
                 }else{
                    //$("#preDeposits_ctl00_ButtonPay").attr("disabled","disabled");
                 }
           });
          </script>
        <div id="IsPay" runat="server" visible="false">
            <p class="indent">
                <b class="indextB">短信确认码：</b>
                <asp:TextBox ID="txtMobileCode" runat="server" Text="" CssClass="PwdText"></asp:TextBox><span style="color: Red">*</span>
                <input type="button" id="butGetCode" value="获取验证码"/>
            </p>
             <script type="text/javascript" language="javascript">
                 var timerId;
                 $(function(){$("#preDeposits_ctl00_txtMobileCode").val("");
                      $("#butGetCode").click(function(){
                          
                          
                           $("#butGetCode").attr("disabled","disabled");
                            $.get("/Api/CheckInfo.ashx?type=6",null,function(data){
                                if(data!="1"){alert("短信发送不成功，无法获取验证码！"); $("#butGetCode").val("获取验证码");$("#butGetCode").removeAttr("disabled");   return false;}else{  timerId=setInterval("goTo()",2000);$("#butGetCode").val("已发送验证码(60秒)");}
                            });
                      });
                 });
                 var i=60;
                function goTo()
                {
                    i--;
                    $("#butGetCode").val("已发送验证码("+i+"秒)");
                    if(i==0)
                    {
                        $("#butGetCode").val("获取验证码");
                        $("#butGetCode").removeAttr("disabled");
                        clearInterval(timerId);i=60;
                    }
                }
             </script>
        </div>
        <p class="indent">
            <b>请输入交易密码：</b>
            <ShopNum1:TextBox ID="TextBoxPayPassword" runat="server" TextMode="Password" CanBeNull="必填" IsReplaceInvertedComma="true" MaxLength="30" CssClass="PwdText" />
        </p>
        <p><asp:Button ID="ButtonPay" class="PaySure" runat="server" Text="确定支付" OnClientClick="return checkPay()" /></p>       
        <script type="text/javascript">
         function checkPay(){
                      if($("#preDeposits_ctl00_TextBoxPayPassword").val()=="")
                     {
                     alert("请输入交易密码");
                     return false;
                     }
                   if($("#preDeposits_ctl00_txtMobileCode").is(":visible"))
                   {
                       if($("#preDeposits_ctl00_txtMobileCode").val()==""){alert("手机验证码不能为空！");return false;}
                       else{
//                           $.get("/Api/CheckInfo.ashx?type=7",null,function(data){
//                               if(data!="1"){alert("对不起，请在安全中心绑定手机号码才能完成支付！");return false;}
//                           });
                            $.get("/Api/CheckInfo.ashx?type=8&key="+$("#preDeposits_ctl00_txtMobileCode").val()+"",null,function(data){
                                if(data=="0"){alert("短信无法发送出去，请在后台检测短信接口是否可用！");return false;}else{ return true;}
                            });
                       }
                       
                   }                               
                  
            }
        </script>
    </div>
</div>
