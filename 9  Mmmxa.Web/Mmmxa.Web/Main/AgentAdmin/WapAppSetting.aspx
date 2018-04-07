<%@ page language="C#" autoeventwireup="true" inherits="Main_AgentAdmin_WapAppSetting, ShopNum1.Deploy" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>App Wap广告设置</title>
     <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"></script>
       <script type="text/javascript" language="javascript" src="js/jquery-1.3.2.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabelTitle" runat="server" Text="广告设置"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>

        <div class="welcon clearfix">
            <div class="order_edit">
            <table border="0" cellspacing="0" cellpadding="0" style>
                    <tbody><tr>
                        <td valign="top">
                            <a id="add_menu" class="tianjia2 lmf_btn" href="javascript:__doPostBack('ButtonAdd','')" onclick="return GetCheckedBoxValues();">
                                <span>添加</span>
                            </a>
                        </td>
                        <td valign="top" class="lmf_app">
                             <select id="configtype">
                <option value="0">安卓平台首页广告</option>
                <option value="1">安卓欢迎页广告</option>
                <option value="2">苹果平台广告</option>
                <option value="3">苹果欢迎页广告</option>
                <option value="4">Wap平台广告</option>                
            </select>
                        </td>
                        <td valign="top" class="lmf_app"> <div class="form_actions">
                        <button class="fanh" type="button" id="btn_Save">
                            保存</button>&nbsp;&nbsp;站点幻灯片图片,建议大小(宽320高148)
                   </div></td>
                    </tr>
                </tbody>
                </table>
           
           </div>
            
            <table id="listTable" class="gridview_m" cellpadding="0" cellspacing="0">
                <tr class="list_header">
                    <th style="width: 354px; height: 24px;" scope="col">
                        图片地址
                    </th>
                    <th style="width: 122px; height: 24px;" scope="col">
                    </th>
                    <th style="width: 198px; height: 24px;" scope="col">
                        URL
                    </th>
                    <th style="width: 32px; height: 24px;" scope="col">
                        操作
                    </th>
                </tr>
                <asp:Repeater ID="rep_PicSet" runat="server">
                    <ItemTemplate>
                        <tr style="cursor:default;" onmouseout="Num1GridViewShow_mout(this)" onmouseover="Num1GridViewShow_mover(this)">
                            <td>
                                <img id="img_logoid<%#Container.ItemIndex %>" style="width: 300px; height: 50px;"
                                    src="<%#Eval("Value") %>" onerror="javascript:this.src='/ImgUpload/noImg.jpg_160x160.jpg'">
                                <input id="hid_logoid<%#Container.ItemIndex %>" class="hid_logoid" type="hidden"
                                    value="<%#Eval("Value") %>">
                            </td>
                            <td>
                                <span class="help_inline"><a class="btn_logo" onclick="SelectImage(this)">
                                    浏览</a> </span>
                            </td>
                            <td>
                                <input class="txt_url" type="text" maxlength="200" class="textwb" value="<%#Eval("Url") %>" />
                            </td>
                            <td>
                                <a class="menu_delete" href="javascript:void(0);">删除</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                </table>
         </div>
     </div>
       
<script type="text/javascript">
var imglock=0;
function  SelectImage(linkobject)
{
    var imgName = window.showModalDialog("Image_List_Select.aspx",window,"dialogWidth:820px;location:yes;directories:yes;alwaysRaised:yes;status:no;menubar:yes;dialogHeight:650px");
    if (imgName == undefined) {imgName = window.returnValue; }
    if(imgName!=null && imgName!="")
    {
             var inputs=linkobject.childNodes; 
             var imgUrl=imgName.split(",",1)[0];
//             $("#hid_logoid"+linkobject).val(imgUrl);
//             $("#img_logoid"+linkobject).attr("src",imgUrl);
             $(linkobject).parent().parent().prev().find("img").attr("src",imgUrl);
             $(linkobject).parent().parent().prev().find("input").val(imgUrl);
    }
}

    $(function() {
        try{
        var vtype='<%=ShopNum1.Common.Common.ReqStr("type") %>';
        if(vtype=="")
           vtype="0";
        $("#configtype").find("option[value='"+vtype+"']").attr("selected",true);
        $("#configtype").change(function(){
               location.href="?type="+$(this).find("option:selected").val();
        });
        //动态flash
        $("#add_menu").click(function() {
            if ($("#listTable tr").length < 6) {
                var _menuPtrtmp = "<tr>"
                                       + " <td>"
                                       + "     <img id=\"img_logoid" + $("#listTable tr").length + "\" style=\"width: 300px; height: 50px;\" src=\"/ImgUpload/noimg.jpg_160x160.jpg \" />"
                                       + "     <input class=\"hid_logoid\" type=\"hidden\" id=\"hid_logoid" + $("#listTable tr").length + "\" value=\"\" />"
                                       + " </td>"
                                       + " <td>"
                                       + "     <span class=\"help_inline\"><a class=\"btn_logo\" onclick=\"SelectImage(this)\">浏览</a></span>"
                                       + " </td>"
                                       + " <td>"
                                       + "      <input class=\"txt_url\" type=\"text\" maxlength=\"200\" class=\"textwb\" />"
                                       + " </td>"
                                       + " <td>"
                                       + "     <a class=\"menu_delete\" href=\"javascript:void(0);\" onclick=\"del_\">删除</a>"
                                       + " </td>"
                                   + " </tr>"

                $("#listTable").append(_menuPtrtmp);
            }
            else
            {
                alert("您添加的数据以达到上限!");
            }
        })

        //删除菜单
        $(".menu_delete").live("click", function() {
            $(this).parents("tr").remove();
        })
       
         //Flash
         $("#btn_Save").click(function() {
                try{
                        var flash = "";
                        var flashurl = "";
                        if ($("#listTable tr:not(:first)").length > 0) {
                            $("#listTable tr:not(:first)").each(function(i) {
                                flash += $(this).find(".hid_logoid").val() + ",";
                                flashurl += $(this).find(".txt_url").val() + ",";
                            })
                            flash = flash.substring(0, flash.length - 1);
                        }
                        $.ajax({
                            cache: false,
                            url: "/api/Main/api_ShopSetting.ashx",
                            data: {
                                configtype:vtype,
                                flash: flash,
                                flashurl: flashurl,
                                type: "shop_appconfigop"
                            },
                            dataType: "json",
                            success: function(result) {
                                alert(result.errmsg);
                            },error:function(data){alert(data);}
                        });
              }catch(e){alert(e);}
          })
        }catch(e){alert(e);}
    })
    function ImageUpload(nI) {
        funOpen();
        $("#showiframe").attr("src", "/Shop/ShopAdmin/S_ShowShopPhoto.aspx?txtid=hid_logoid" + nI + "&imgid=img_logoid" + nI);
    }

</script>

<!--弹出层-->
<div class="sp_dialog sp_dialog_out" style="display: none;" id="sp_dialog_outDiv">
    <div class="sp_dialog_cont" style="display: none;" id="sp_dialog_contDiv">
        <div class="sp_tan">
            <h4>
                选择图片</h4>
            <div class="sp_close">
                <a href="javascript:void(0)" onclick="funClose()"></a>
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="sp_tan_content">
            <iframe src="" id="showiframe" width="100%" height="470" frameborder="0" scrolling="no">
            </iframe>
        </div>
    </div>
</div>

    </form>
</body>
</html>
