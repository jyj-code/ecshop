<%@ page language="C#" autoeventwireup="true" inherits="Main_Admin_MemberInfo_SendMsg"   CodeBehind="MemberInfo_SendMsg.aspx.cs"      %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>发送消息</title>
    <link type="text/css" rel="Stylesheet" href="style/css.css" />



      <script src="js/jquery-1.9.1.js" type="text/javascript"></script>


    <script src="../../JS/msgBox.js" type="text/javascript"></script>
    
    <script type="text/javascript">
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
    var msgBox=null;
    
    $(function(){
    msgBox = new MsgBox({ imghref: "/ImgUpload/MsgImage/" });
    
    $("#btnSend").click(function(){
    $("#errContMsg").hide();
     $("#errTitleMsg").hide();
     $("#errMemListMsg").hide();
    if(validData())
    {
               
     var type= $("input:checked").val();
     var content=$("#txtSendContent").val();
     var sendMems=$("#txtMemList").val().replace(/[\n\r]/gi,",");
     var title=$("#txtTitle").val();
     
     msgBox.showMsgWait("发送中...");
     $.post("MemberInfo_SendMsg.aspx",{sendType:type,sendContent:content,sendMems:sendMems,msgTitle:title},function(obj){
     if(obj.Status=="ok")
     {
     msgBox.showMsgOk(obj.Msg);
     }   
     else
     {
     msgBox.showMsgErr(obj.Msg);
     }

     },"json");
     }
       
    });
    
    
    });
    
    function validData()
    {
    var flag=false;
     if($("#txtMemList").val().length<=0)
    {
     $("#errMemListMsg").text("会员列表不能为空!");
    $("#errMemListMsg").show();
    }
    
     else if($("#txtTitle").val().length<=0||$("#txtTitle").val().length>50)
    {
    
    $("#errTitleMsg").text("消息标题不能为空且长度不能超过50个字符!");
    $("#errTitleMsg").show();
    }
     else   if($("#txtSendContent").val().length<=0||$("#txtSendContent").val().length>100)
    {
    $("#errContMsg").text("消息内容不能为空且长度不能超过200个字符!");
    $("#errContMsg").show();
    }  
    else
    {
         
    flag= true;
    }
    return flag;
    
    }
    
    
    function hideMem()
    {
    $("#MemList").css('display','none');
    $("#MemList1").css('display','none');
    $("#MemList2").css('display','none');
    };
    
        function ShowMem()
    {
    $("#MemList").show();
    $("#MemList1").show();
     $("#MemList2").show();
    }
    
    
    function openSingleChild()
    {
        var k = window.showModalDialog("Member_List_Select.aspx",window,"dialogWidth:820px;status:no;dialogHeight:650px"); 
        if (k == undefined) {k = window.returnValue; }
        if(k != null) 
        {
           
            document.getElementById("txtMemList").value=k;
        }
    } 
    
    </script>

    <style type="text/css">
        .zhezhao
        {
            position: relative;
            margin: 0 auto;
            width: 322px;
        }
    </style>
</head>
<body>
    <div id="right">
        <div class="page-send">
            <div class="rhigth">
                <div class="rl">
                </div>
                <div class="rcon">
                    <h3>会员通知</h3>
                </div>
                <div class="rr">
                </div>
            </div>
            <form id="form1" runat="server">
            <div class="welcon clearfix" style="padding-left: 10px;">
                <table class="tb-type2">
                    <tr class="noborder" style="background-position: initial initial;background-repeat: initial initial;">
                        <td class="required" valign="top" style="width:100px;">
                            发送类型 :
                        </td>
                        <td class="vatop rowform">
                            <ul class="nofloat">
                                <li><input type="radio" name="sendType" value="1" checked="checked" onclick="ShowMem()"/>指定会员</li>
                                <li><input type="radio" name="sendType" value="2" onclick="hideMem()" />全部会员</li>
                                <li><input type="radio" name="sendType" value="3" onclick="hideMem()" />全部店铺</li>
                            </ul>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:100px;">
                            <label class="validation">消息标题:</label>
                        </td>
                        <td align="left">                            
                            <input type="text" id="txtTitle" style="border:1px solid #ddd; height:20px;" /><label style="color: Red; font-size: 12px" id="errTitleMsg" visible="false"></label>
                        </td>
                    </tr>
                    <tr id="MemList1" class="noborder" style="background-color: rgb(255, 255, 255); background-position: initial initial;background-repeat: initial initial;">
                        <td style="width:100px;">
                            <label class="validation">会员列表:</label>
                        </td>
                        <td class="vatop rowform" colspan="2">
                            <textarea cols="40" rows="3" id="txtMemList" style="border:1px solid #ddd;"><%=strCurrentMem %></textarea>
                            <label style="color: Red; font-size: 12px" id="errMemListMsg" visible=" false"></label>
                        </td>
                    </tr>
                    <tr id="MemList2">
                        <td style="width:100px;"></td>
                        <td>
                            <input type="button" id="btnChooseMem" value="选择" class="fanh" onclick="openSingleChild()" />
                        </td>
                    </tr>
                    <tr class="noborder" style="background-color: rgb(255, 255, 255); background-position: initial initial;
                        background-repeat: initial initial;">
                        <td style="width:100px;">
                            <label class="validation">通知内容:</label>
                        </td>
                        <td class="vatop rowform">
                            <textarea cols="40" rows="3" id="txtSendContent" style="border:1px solid #ddd;"></textarea>
                            <label style="color: Red; font-size: 12px" id="errContMsg" visible=" false"></label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:100px;"></td>
                        <td>
                            <input type="button" id="btnSend" value="发送" class="fanh" />
                            <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                        </td>
                    </tr>
                </table>
            </div>
            </form>
        </div>
    </div>
</body>
</html>
