<%@ page language="C#" autoeventwireup="true" inherits="AgentAdmin_Login, ShopNum1.Deploy" %>

<%@ Import Namespace="ShopNum1.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>城市多用户分站系统管理登录页面</title>
    <link type="text/css" rel="Stylesheet" href='<%=ResolveUrl("css/logindex.css") %>' />
 

    <script src="js/jquery-1.9.1.js" type="text/javascript"></script>

    <script src="js/logintanchuDIV2.js" type="text/javascript"></script>

    <script type="text/javascript">
        if (top.location != location) top.location.href = location.href;
    function reloadcode()
    {
        var verify=document.getElementById('ImgCode');
        verify.setAttribute('src','AdminImgCode.aspx?'+Math.random());
    }
    
    
    
    function check()
    {
        var boolresult=false;
        var TextBoxLoginID=$("#TextBoxLoginID").val();
        var pwd=$("#TextBoxPwd").val();
        var txtcode=$(".txtcode").val();
        var Megcontent="";
        if(TextBoxLoginID=="")
        {
            Megcontent="用户名不能为空！";
            $("#TextBoxLoginID").focus();
        }
        else
        {
            if(pwd=="")
            {
                Megcontent="密码不能为空！";
                $("#TextBoxPwd").focus();
            }
            else
            {
                if(txtcode==""||txtcode=="请输入验证码")
                {
                    Megcontent="验证码不能为空！";
                    $(".txtcode").focus();
                }
                else
                {
                loadwindow2(800,600);
               $("#d-content-ButtonLogin").html("登录中...");
               $("#zhezhao").delay(3000).hide(1);
                    $.ajax
                    ({
                        url:"/PageHander/Main/CheckAdminLogin.ashx",
                        async:false,
                        data:"type=checklogin&loginID="+TextBoxLoginID+"&pwd="+pwd+"&code="+txtcode,
                        success:function(result)
                        {
                            if(result=="0")
                            {
                                Megcontent="用户名或密码错误！";
                            }
                            if(result=="-1")
                            {
                                Megcontent="用户被锁定！";
                            }
                            if(result=="-2")
                            {
                                Megcontent="验证码错误！";
                            }
                            if(result=="1")
                            {
                                boolresult=true;
                            }
                        }
                    })
                    
                }
            }
        } 
        if(boolresult==false)
        {        
            loadwindow2(800,600);
            $("#d-content-ButtonLogin").html(Megcontent);
            $("#zhezhao").delay(1000).hide(1);

        }
        $(".d-outer").parent("div").attr("class","artTest").attr("style","");
        $(".d-outer").attr("style","");
        return boolresult;
        
    }
    </script>

    <style type="text/css">
        .d-border, .d-dialog
        {
            border: 0 none;
            margin: 0;
            border-collapse: collapse;
            width: 100%;
        }
        .d-nw, .d-n, .d-ne, .d-w, .d-c, .d-e, .d-sw, .d-s, .d-se, .d-header, .d-main, .d-footer { padding:0; }
        .d-main { text-align:center; vertical-align:middle; min-width:9em;background:url(images/jinggao.jpg) no-repeat 15px 10px; }

        .d-inner { background:#fdfdea; border:1px solid #cccccc; width:320px; height:60px; }
        
        .arttest
        {
            position: relative;
            width: 322px;
            margin: 0 auto;
        }
        .d-outer
        {
            position: absolute;
            width: 322px;
            top: 200px;
        }
        .d-titleBar
        {
            display: none;
        }
        .zhezhao
        {
            position: relative;
            margin: 0 auto;
            width: 322px;
        }
        #Divfahuo
        {
            position: absolute;
            margin: 0 0;
            top:260px;
            z-index: 1;
            overflow-y: hidden;
            overflow-x: hidden;
        }
        .d-content
        {
            display: block; text-align:left; color:#666666; font-size:14px; font-family:"宋体";
        }
        .zhezhao1
        {
            filter: alpha(opacity=30);
            -moz-opacity: 0.3;
            opacity: 0.3;
            position: fixed;
            _position: absolute;
            width: 100%;
            height: 100%;
            top: 0;
            position: absolute;
            width: 100%;
            height: 100%;
        }
    </style>
</head>
<body style="overflow: hidden;">
    <form id="form1" runat="server">
    <!--弹出框-->
    <div id="zhezhao" style="display: none;">
        <div id="Divfahuo" style="display: none; background: #dedede; padding: 3px;">
            <table class="d-border">
                <tbody>
                    <tr>
                        <td class="d-c">
                            <div class="d-inner">
                                <table class="d-dialog">
                                    <tbody>
                                        <tr>
                                            <td style="width: auto; height: auto;" class="d-main">
                                                <div style="padding: 21px 10px 18px 28px; padding-left: 52px;" id="d-content-ButtonLogin" class="d-content">
                                                    用户名不能为空！</div>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
    <div class="alogin_bg">
        <div class="warp">
            <div class="logo">
            </div>
            <div class="admin_login_box">
                <div class="ad" style=" height:auto;">
                    <ul class="admin_login">
                        <li class="left_txt">
                            <asp:Label ID="Label1" runat="server" Text="分站ID："></asp:Label>
                        </li>
                        <li class="right_input">
                            <asp:TextBox ID="TextBoxSubstationID" runat="server" CssClass="text"></asp:TextBox>
                        </li>
                        <li class="left_txt">
                            <asp:Label ID="LabelLoginID" runat="server" Text="用户名："></asp:Label>
                        </li>
                        <li class="right_input">
                            <asp:TextBox ID="TextBoxLoginID" runat="server" CssClass="text"></asp:TextBox>
                        </li>
                        <li class="left_txt">
                            <asp:Label ID="LabelPwd" runat="server" Text=""></asp:Label>
                            密&nbsp;&nbsp;码： </li>
                        <li class="right_input">
                            <asp:TextBox ID="TextBoxPwd" runat="server" CssClass="text" TextMode="Password" onkeydown="if(event.keyCode==13){document.getElementById('<%=ButtonLogin.ClientID %>').focus();document.getElementById('<%=ButtonLogin.ClientID %>').click();}"></asp:TextBox>
                        </li>
                    </ul>
                    <div class="adminbtn" style="margin-top: 5px; *margin-top: 2px; margin-top: 2px\9;
                        _margin-top: 2px;">
                        <asp:Button ID="ButtonLogin" runat="server" OnClick="ButtonLogin_Click" Text="登录"
                            CssClass="bt3" OnClientClick="return check();" />
                            <img src="../../Images/ajax_loading.gif" />
                        <asp:Label ID="Message" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                    </div>
                </div>
                <div class="adcode">
                    <div class="code_left">
                        <asp:Label ID="LabelCheckCode" runat="server" Text="验证码："></asp:Label>
                    </div>
                    <div class="code_rigth">
                        <input name="verifycode" type="text" value="请输入验证码" onfocus="this.value=''" class="txtcode"
                            onkeydown="if(event.keyCode==13){document.getElementById('<%=ButtonLogin.ClientID %>').focus();document.getElementById('<%=ButtonLogin.ClientID %>').click();}" />
                        <img id="ImgCode" src="AdminImgCode.aspx" onclick="javascript:this.src='AdminImgCode.aspx?'+ Math.random()"
                            width="56" height="22" style="height: 22px; overflow: hidden; position: relative;
                            top: 5px;" />
                        <a onclick="reloadcode()" class="on" style="cursor: pointer;">看不清楚？点一下</a>
                    </div>
                    <div class="clear">
                    </div>
                </div>
            </div>
            <div class="clear">
            </div>
        </div>
        <p class="copyright">
            Powered by <a href="http://www.shopnum1.com" target="_blank">ShopNum1</a> V8.2.1 ©
            2002-2014, GroupFly Inc.
        </p>
    </div>
    </form>
</body>
</html>
