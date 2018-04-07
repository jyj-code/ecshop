<%@ page language="C#" autoeventwireup="true" inherits="Main_Admin_MemberInfo_Operate"   CodeBehind="MemberInfo_Operate.aspx.cs"      %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="GroupFly" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="GroupFly" %>
<%@ Import Namespace="ShopNum1.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>会员详细信息</title>
     <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"></script>
    <script type='text/javascript' src='js/resolution-test.js'></script>
    <script src="/Main/js/location.js" type="text/javascript"></script>
    <script src="/Main/js/areas.js" type="text/javascript"></script>
    <script type="text/javascript">
        window.onload=function(){
            var v_birthday = document.getElementById("TextBoxBirthday");
            if(v_birthday.value == "1900-1-1")
            {
                v_birthday.value = "";
            }        
        }
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
  <asp:ScriptManager ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true"
        runat="server">
    </asp:ScriptManager>
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="会员详细信息"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    
                    <tr>
                        <th align="right" width="150px">
                            会员ID：
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxName" CssClass="tinput" ReadOnly="true" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right" width="150px">
                            会员等级：
                        </th>
                        <td>
                            <asp:Label ID="LabelMemberRankGuid" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelName" runat="server" Text="会员昵称："></asp:Label>
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="TextBoxMemberName" CssClass="tinput" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorRealName" runat="server"
                                ControlToValidate="TextBoxMemberName" Display="Dynamic" ErrorMessage="会员昵称最多50个字符"
                                ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                    <th align="right">
                       
                            <asp:Label ID="LabelRealName" runat="server" Text="会员姓名："></asp:Label>
                        
                    </th>
                    <td>
                            <asp:TextBox ID="TextBoxRealName" runat="server" CssClass="tinput"></asp:TextBox><span> </span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server"
                                ControlToValidate="TextBoxRealName" Display="Dynamic" ErrorMessage="姓名最多50个字符"
                                ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                       
                    </td>
                </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelWebSite" runat="server" Text="出生日期："></asp:Label>
                        </th>
                                    <td>
                                        <asp:TextBox ID="TextBoxBirthday" runat="server" CssClass="tinput" Style="width: 80px;"></asp:TextBox>
                                          <asp:RegularExpressionValidator ID="RegularExpressionValidatorStartDate" runat="server"
                                            ControlToValidate="TextBoxBirthday" Display="Dynamic" ErrorMessage="时间格式不正确"
                                            ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                                            <img id="imgCalendarStartTime" alt="" src="/ImgUpload/Calendar.png" style="width: 16px;
                                             height: 18px; position: relative; top: 3px;" />
                                        <GroupFly:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBoxBirthday"
                                            PopupButtonID="imgCalendarStartTime" CssClass="ajax__calendar">
                                        </GroupFly:CalendarExtender>
                                    </td>
                                
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label14" runat="server" Text="性别："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListSex" runat="server" Width="180px" CssClass="tselect"
                                Style="width: 80px;">
                                <asp:ListItem Selected="True" Value="0">保密</asp:ListItem>
                                <asp:ListItem Value="1">男</asp:ListItem>
                                <asp:ListItem Value="2">女</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                     <tr>
                        <th align="right">
                            <asp:Label ID="LabelMember" runat="server" Text="">会员头像：</asp:Label>
                        </th>
                        <td>
                        
                           <input id="ButtonSelectSingleImage" type="button" value="选择图片" onclick="openSingleChild()"
                                class="selpic" />
                             <img id="ImagePhoto" runat="server" onerror="javascript:this,src='/ImgUpload/noImage.gif'"
                                src="" alt="" width="80" height="80" />
                            <asp:HiddenField ID="HiddenFieldOriginalImge" runat="server" />
                            <span>选择头像</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label7" runat="server" Text="手机号码："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMobile" CssClass="tinput" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="请填写正确的手机号"
                                Display="Dynamic" ControlToValidate="TextBoxMobile" ValidationExpression="^(1[3|5|8][0-9])\d{8}$"></asp:RegularExpressionValidator>
                             <asp:Button ID="ButtonMobile" runat="server" OnClick="ButtonCheckMobile_Click" Text="检测手机号码"
                                CssClass="selpic" CausesValidation="False" />
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelKeywords" runat="server" Text="电子邮箱:"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxEmail" CssClass="tinput" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle9" runat="server"
                                ControlToValidate="TextBoxEmail" Display="Dynamic" ErrorMessage="电子邮箱最多100个字符"
                                ValidationExpression="^[\s\S]{0,100}$"></asp:RegularExpressionValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBoxEmail"
                                Display="Dynamic" ErrorMessage="邮箱格式不正确！" ValidationExpression="^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$"></asp:RegularExpressionValidator>
                               <asp:Button ID="ButtonEmail" runat="server" OnClick="ButtonCheckEmail_Click" Text="检测邮箱"
                                CssClass="selpic" CausesValidation="False" />
                      
                        </td>
                    </tr>
                    
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelOrderID" runat="server" Text="登录密码："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxPwd" runat="server" CssClass="tinput" TextMode="Password"></asp:TextBox>
                            <asp:Label ID="Label1" runat="server" Text="(填写完两次登陆密码后，修改原登陆密码)"></asp:Label>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBoxPwd"
                                Display="Dynamic" ErrorMessage="密码长度限制为6-30位" ValidationExpression="^[\s\S]{6,30}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr> 
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelPwd2" runat="server" Text="登录密码确认："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxPwd2" runat="server" CssClass="tinput" TextMode="Password"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorPwd2" runat="server"
                                ControlToValidate="TextBoxPwd2" Display="Dynamic" ErrorMessage="密码长度限制为6-30位"
                                ValidationExpression="^[\s\S]{6,30}$"></asp:RegularExpressionValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBoxPwd"
                                ControlToValidate="TextBoxPwd2" ErrorMessage="登录密码输入不一致" Display="Dynamic"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelPayPwd" runat="server" Text="支付密码："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxPayPwd" runat="server" CssClass="tinput" TextMode="Password"></asp:TextBox>
                            <asp:Label ID="Label11" runat="server" Text="(填写后两次支付密码后，修改原支付密码)"></asp:Label>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorPayPwd" runat="server"
                                ControlToValidate="TextBoxPayPwd" Display="Dynamic" ErrorMessage="密码长度限制为6-30位"
                                ValidationExpression="^[\s\S]{6,30}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label12" runat="server" Text="支付密码确认："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxPayPwd2" runat="server" CssClass="tinput" TextMode="Password"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TextBoxPayPwd2"
                                Display="Dynamic" ErrorMessage="密码长度限制为6-30位" ValidationExpression="^[\s\S]{6,30}$"></asp:RegularExpressionValidator>
                            <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="TextBoxPayPwd"
                                ControlToValidate="TextBoxPayPwd2" ErrorMessage="支付密码输入不一致" Display="Dynamic"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelRemark" runat="server" Text="会员类型："></asp:Label>
                        </th>
                        <td>
                            <asp:Label ID="LabelMemberType" runat="server" CssClass="tinput"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelArea" runat="server" Text="所在地区："></asp:Label>
                        </th>
                        <td>
                             <div id="p_local" > </div>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelAddress" runat="server" Text="详细地址："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxAddress" CssClass="tinput" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label3" runat="server" Text="从事行业："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxVocation" CssClass="tinput" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorVocation" runat="server"
                                ControlToValidate="TextBoxVocation" Display="Dynamic" ErrorMessage="行业最多50个字符"
                                ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label4" runat="server" Text="邮政编码："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxPostalcode" CssClass="tinput" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle10" runat="server"
                                ControlToValidate="TextBoxPostalcode" Display="Dynamic" ErrorMessage="邮政编码格式不对"
                                ValidationExpression="^[0-9 ]{6}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    
                    <tr>
                    <th align="right">
                       
                            <asp:Label ID="LabelTel" runat="server" Text="电话："></asp:Label>
                      
                    </th>
                    <td>
                       
                            <asp:TextBox ID="TextBoxTel" runat="server" CssClass="tinput"></asp:TextBox><span> </span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle11" runat="server"
                                ControlToValidate="TextBoxTel" Display="Dynamic" ErrorMessage="电话格式不对" ValidationExpression="^(([0\+]\d{2,3}-)?(0\d{2,3})-)?(\d{7,8})(-(\d{3,}))?$"></asp:RegularExpressionValidator>
                        
                    </td>
                </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label9" runat="server" Text="传真号码："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxFax" CssClass="tinput" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle13" runat="server"
                                ControlToValidate="TextBoxFax" Display="Dynamic" ErrorMessage="传真号最多20个字符" ValidationExpression="^[\s\S]{0,20}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    
                    
                    <tr>
                    <tr style=" display:none">
                    <th align="right">
                       
                            <asp:Label ID="LabelCardNum" runat="server" Text="证件号码："></asp:Label>
                       
                    </th>
                    <td>
                        
                            <asp:TextBox ID="TextBoxCardNum" runat="server" CssClass="tinput"></asp:TextBox><span> 有效身份证</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle17" runat="server"
                                ControlToValidate="TextBoxCardNum" Display="Dynamic" ErrorMessage="身份证号最多50个字符"
                                ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        
                    </td>
                </tr>
                        <th align="right">
                            <asp:Label ID="Label16" runat="server" Text="腾讯QQ："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxQQ" CssClass="tinput" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle14" runat="server"
                                ControlToValidate="TextBoxQQ" Display="Dynamic" ErrorMessage="QQ格式不对" ValidationExpression="^[1

-9][0-9]{4,10}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label18" runat="server" Text="个人博客或网站："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxWebSite" CssClass="tinput" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle18" runat="server"
                                ControlToValidate="TextBoxWebSite" Display="Dynamic" ErrorMessage="网站格式不对" ValidationExpression="^[a-zA-z]+://(\w+(-\w+)*)(\.(\w+(-\w+)*))*(\?\S*)?$"></asp:RegularExpressionValidator>
                               <span>(请以http://开头)</span>
                        </td>
                      
                    </tr>
                    <tr style=" display:none">
                        <th align="right">
                            <asp:Label ID="Label19" runat="server" Text="信用额度："></asp:Label>
                        </th>
                        <td>
                            <asp:Label ID="LabelCreditMoney" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label20" runat="server" Text="注册时间："></asp:Label>
                        </th>
                        <td>
                            <asp:Label ID="LabelRegeDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label22" runat="server" Text="上次登录时间："></asp:Label>
                        </th>
                        <td>
                            <asp:Label ID="LabelLastLoginTime" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label24" runat="server" Text="消费积分："></asp:Label>
                        </th>
                        <td>
                            <asp:Label ID="LabelScore" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label26" runat="server" Text="当前冻结预存款："></asp:Label>
                        </th>
                        <td>
                            <asp:Label ID="LabelLockAdvancePayment" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr  style="display:none;">
                        <th align="right">
                            <asp:Label ID="Label21" runat="server" Text="当前冻结积分："></asp:Label>
                        </th>
                        <td>
                            <asp:Label ID="LabelLockSocre" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label25" runat="server" Text="总消费金额："></asp:Label>
                        </th>
                        <td>
                            <asp:Label ID="LabelCostMoney" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonConfirm" runat="server" Text="确定" CssClass="fanh" OnClick="ButtonConfirm_Click" OnClientClick="return CheckSumbit()"/>
                <input id="inputBack" type="button" onclick="javascript: window, location.href = 'Member_List.aspx'"
                    value="返回列表" class="fanh" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldRegionCode" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldRegionValue" runat="server" Value="0" />
    </form>
</body>
</html>

<script type="text/javascript" language="javascript" >
   $(function(){
     $("#p_local").LocationSelect();
 })

</script>
<script type="text/javascript" language="javascript">
 $(document).ready(
 function (){
   var area=$("#HiddenFieldRegionValue").val().split("|");
   var areaCode=$("#HiddenFieldRegionCode").val();
   var code1;
   var code2;
   var code3;
   if(areaCode.length>8)
   {
    //areaCode 有三级
    code1=areaCode.substring(0,3);
    code2=areaCode.substring(4,6);
    code3=areaCode.substring(7,9);
   }
   if($("#HiddenFieldRegionValue").val()!="")
   {
            var areacode=area[1].split(",");
            var areaname=area[0].split(",");
            $("select[name='province']").append("<option value=\""+code1+"\" selected=\"selected\">"+areaname[0]+"</option>");
            $("select[name='city']").append("<option value=\""+code2+"\" selected=\"selected\">"+areaname[1]+"</option>");
            $("select[name='district']").append("<option value=\""+code3+"\" selected=\"selected\">"+areaname[2]+"</option>");
   }
 
 }
 );
</script>
<script language="javascript" type="text/javascript" > 
 function CheckSumbit()
 {
             var info = $("#p_local").getLocation();
             if(info.pcode=="0")
             {
                 $("#p_local").next().show();
             }
             $("#HiddenFieldRegionValue").val(info.province+","+info.city+","+info.district+"|"+info.pcode+","+info.ccode+","+info.dcode);
              if(info.dcode!="0")
              {
               $("#HiddenFieldRegionCode").val(info.dcode);
              }
              else
              {
              if(info.ccode!="0")
              {
                 $("#HiddenFieldRegionCode").val(info.ccode);
              }
              else
              {
                  $("#HiddenFieldRegionCode").val(info.pcode);
              }
              }
              if($("#TextBoxPwd").val()!=""&&$("#TextBoxPwd2").val()!="")
    {
    if($("#TextBoxPwd").val()!=$("#TextBoxPwd2").val())
    {
      return false;
    }}
  if($("#TextBoxPayPwd").val()!=""&&$("#TextBoxPayPwd2").val()!="")
    {
    if($("#TextBoxPayPwd").val()!=$("#TextBoxPayPwd2").val())
    {
      return false;
    }}
    return true;
 }
  
</script>
<script type="text/javascript" language="javascript" >
    var has_showModalDialog = !!window.showModalDialog;//定义一个全局变量判定是否有原生showModalDialog方法  
    if (!has_showModalDialog && !!(window.opener)) {
        window.onbeforeunload = function () {
            window.opener.hasOpenWindow = false;        //弹窗关闭时告诉opener：它子窗口已经关闭  
        }
    }
    //定义window.showModalDialog如果它不存在  
    if (window.showModalDialog == undefined) {
        window.showModalDialog = function (url, mixedVar, features) {
            if (window.hasOpenWindow) {
                alert("您已经打开了一个窗口！请先处理它");//避免多次点击会弹出多个窗口  
                window.myNewWindow.focus();
            }
            window.hasOpenWindow = true;
            if (mixedVar) var mixedVar = mixedVar;
            //因window.showmodaldialog 与 window.open 参数不一样，所以封装的时候用正则去格式化一下参数  
            if (features) var features = features.replace(/(dialog)|(px)/ig, "").replace(/;/g, ',').replace(/\:/g, "=");
            //window.open("Sample.htm",null,"height=200,width=400,status=yes,toolbar=no,menubar=no");  
            //window.showModalDialog("modal.htm",obj,"dialogWidth=200px;dialogHeight=100px");   
            var left = (window.screen.width - parseInt(features.match(/width[\s]*=[\s]*([\d]+)/i)[1])) / 2;
            var top = (window.screen.height - parseInt(features.match(/height[\s]*=[\s]*([\d]+)/i)[1])) / 2;
            window.myNewWindow = window.open(url, "_blank", features);
        }
    }
    var lock=0;
    //选择单图
    function openSingleChild()
    {
        if(lock==0)
        {
        lock=1
        var k = window.showModalDialog

("Image_List_Select.aspx",window,"dialogWidth:820px;status:no;dialogHeight:650px"); 
if(k == null)
    k= window.returnValue;
        if(k != null) 
        {
            var imgvalue = new Array();
            imgvalue = k.split(",");
            document.getElementById("HiddenFieldOriginalImge").value = imgvalue[0];
            document.getElementById("ImagePhoto").src = imgvalue[1];
        }
         lock=0
        }
    } 
</script>
<script type="text/javascript" language="javascript">
    


</script>