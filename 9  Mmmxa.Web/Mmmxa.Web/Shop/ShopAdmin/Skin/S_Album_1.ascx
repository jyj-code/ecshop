<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="ShopNum1.Common" %>

<script type="text/javascript" language="javascript">
$(function(){

    $(".album a").hover(function(){
            $(this).addClass("img_border");
    },function(){
             $(this).removeClass("img_border");
    });
    

    //修改相册名称
    $(".edit2").click(function(){
        if($(this).text()=="修改名称")
        {
           $(this).parent().parent().prev().find("input").show();
           $(this).parent().parent().prev().find("input").prev().hide();
           $(this).text("保存名称");
        }
        
        else if($(this).text()=="保存名称")
        {
            var t_this=$(this);
            $.get("/Api/ShopAdmin/S_Album.ashx?op=editAlbumName&name="+$(this).parent().parent().prev().find("input").val()+"&sort="+$(this).attr("sort")+"&id="+$(this).attr("vlong")+"",null,function(data){
                  t_this.parent().parent().prev().find("input").prev().html(t_this.parent().parent().prev().find("input").val());
                  t_this.parent().parent().prev().find("input").prev().show();
                  t_this.parent().parent().prev().find("input").hide();
                  t_this.text("修改名称");
             });
        }
        
    })

})


</script>

<table width="100%" border="0" cellspacing="0" cellpadding="0" class="lineh" style="border: 1px #e0e0e0 solid;
    background: #f3f3f3; height: 30px; line-height: 30px; padding: 0 15px;">
    <tr>
        <td width="320">
            <a href="javascript:void(0)" id="setalbum" class="shanchu_img lmf_btn">创建相册</a>
        </td>
        <td align="right">
            排序：
        </td>
        <td width="140">
            <select id="imgtype_sort" name="sort">
                <option value="0">按排序从大到小</option>
                <option value="1">按排序从小到大</option>
                <option value="2">按创建时间从晚到早</option>
                <option value="3">按创建时间从早到晚</option>
                <option value="4">按相册名降序</option>
                <option value="5">按相册名升序</option>
            </select>
        </td>
        <td>
            <div class="upload" id="open_uploader" style="display: none;">
                <a class="hide" href="JavaScript:void(0);">上传图片</a></div>
            <div id="showupfiles" style="display: none; position: absolute; border: 1px solid #bfbfbf;
                width: 360px; left: 430px; background: #fff;">
                <div class="upload-wrap">
                    选择图片相册：
                    <select id="select_Album" style="width: 100px;">
                        <option value="1">默认相册</option>
                    </select>
                </div>
                <div class="upload-wrap" style="display: none;">
                    <ul>
                        <li class="btn1">
                            <div id="divSwfuploadContainer">
                                <input type="button" id="fileupload" value="加载上传控件" class="btn_upload" />
                            </div>
                        </li>
                    </ul>
                    <div id="goods_upload_progress">
                    </div>
                    <div class="upload-txt">
                        <span>支持Jpg、Gif、Png格式，大小不超过1024KB的图片上传；浏览文件时可以按住ctrl或shift键多选。</span>
                    </div>
                </div>
            </div>

            <script type="text/javascript" language="javascript">
                 $(function(){
                       $("#imgtype_sort").change(function(){location.href="?sort="+$(this).val(); });
                       var sortvalue='<%=Common.ReqStr("sort") %>';
                       $("#imgtype_sort").find("option[value='"+sortvalue+"']").attr("selected",true);
                       $.get("/Api/S_Album.ashx?op=getalbum",null,function(data){
                              if(data!=""){
                                    var vdata=eval('('+data+')');
                                    var xhtml=new Array();
                                    $.each(vdata,function(m,n){
                                             xhtml.push('<option value="'+m+'">'+n.name+'</option>');
                                    });
                                    $("#select_Album").append(xhtml.join(""));
                               }
                       });
                 });
function NumTxt_Int(o)
{
   o.value=o.value.replace(/\D/g,'');
}
            </script>

            <input type="hidden" id="hid_typeid" value="0" />
        </td>
    </tr>
</table>
<ul class="album">
    <%
        DataTable dt_album = S_Album_1.dt_Album;
        if (dt_album != null)
        {
            for (int i = 0; i < dt_album.Rows.Count; i++)
            {%>
    <!--相册列表循环-->
    <li class="show">
        <dl>
            <dt>
                <div class="covers" style="width: 162px; height: 162px;">
                    <span class="thumb size150"><i></i><a href="S_AlbumList.aspx?typeid=<%=dt_album.Rows[i]["id"]%>">
                        <img width="160" height="160" src="<%=dt_album.Rows[i]["face"]%>"></a></span></div>
                <h3 class="title" style="text-align: center; padding-left: 0; width: auto;">
                    <a href="S_AlbumList.aspx?typeid=<%=dt_album.Rows[i]["id"]%>">
                        <%=dt_album.Rows[i]["name"]%></a>
                    <input type="text" id="txtEditName" class="editInput1" style="display: none;" value='<%=dt_album.Rows[i]["name"]%>' />
                </h3>
                <h5 class="quantity" style="text-align: center; padding-left: 0;">
                    共<a href="S_AlbumList.aspx?typeid=<%=dt_album.Rows[i]["id"]%>" style="color: #ff6600;
                        display: inline-block; padding: 0 5px; font-weight: bold;"><%=dt_album.Rows[i]["imagecount"]%></a>张</h5>
            </dt>
            <dd class="table">
                <span><a class="edit2" href="JavaScript:void(0);" vlong='<%=dt_album.Rows[i]["id"]%>'
                    sort='<%=dt_album.Rows[i]["sort"]%>'>修改名称</a></span>
                <%if (dt_album.Rows[i]["imagecount"].ToString() == "0")
                  { %>
                <a class="del" onclick="if(confirm('您确定进行该操作吗?\n注意：使用中的图片也将被删除')){location.href='?act=del&typeid=<%=dt_album.Rows[i]["id"]%>&sign=del';}"
                    href="javascript:void(0)">删除</a>
                <%} %>
            </dd>
        </dl>
    </li>
    <!--相册列表循环-->
    <%}
        } %>
</ul>
<style type="text/css">
    .editInput
    {
        font-size: 12px;
        font-weight: bold;
        line-height: 20px;
        color: #555;
        background-color: transparent;
        width: 140px;
        height: 20px;
        border: 0;
        z-index: 2;
        top: 180px;
        left: 8px;
    }
    em
    {
        display: inline-block;
        height: 16px;
        line-height: 22px;
        margin-right: 5px;
        width: 16px;
    }
    .album
    {
    }
    .album li dl dt .covers
    {
        background: url(../images/member/album_bg.gif) no-repeat 0px 0px; /*IE7/8/9*/ *text-align:center;width:150px;height:150px;padding:8px14px14px8px;word-wrap:normal;}
    .album li
    {
        width: 172px;
        height: 238px;
        display: block;
        float: left;
        padding: 10px;
    }
    .album li dl
    {
        width: 100%;
    }
    .album li dl dt h3
    {
        font-size: 12px;
        line-height: 24px;
        white-space: nowrap;
        width: 156px;
        height: 24px;
        padding-left: 8px;
        margin-top: 6px;
        overflow: hidden;
    }
    .album li dl dt h3 a
    {
        color: #555;
    }
    .album li dl dt h5
    {
        font-size: 12px;
        font-weight: normal;
        line-height: 20px;
        color: #999;
        height: 20px;
        padding-left: 8px;
    }
    .album li dl dd
    {
        height: 14px;
        margin-top: 6px;
    }
    .album li.hidden dl dd
    {
        display: none;
    }
    .album li.show dl dd
    {
        display: block;
    }
    .album li dl dd a
    {
        display: inline;
        font-weight: 600;
        color: #999;
        background: url(../images/member/album_bg.gif) no-repeat;
        line-height: 20px;
        padding: 0px 12px 0 0;
        margin: 0 0 0 6px;
    }
    .album li dl dd a:hover
    {
        color: #36C;
        text-decoration: underline;
    }
    .album li dl dd a.edit2
    {
        background-position: -152px -513px;
    }
    .album li dl dd a:hover.edit2
    {
        background-position: -152px -533px;
    }
    .album li dl dd a.del
    {
        background-position: -152px -553px;
    }
    .album li dl dd a:hover.del
    {
        background-position: -152px -573px;
    }
    .lineh .upload
    {
        background-image: none;
        width: 112px;
        height: 36px;
        margin: 0;
    }
    .lineh .upload a.hide
    {
        font-size: 12px;
        font-weight: bold;
        line-height: 20px;
        color: #999;
        background: url(../images/member/album_bg.gif) no-repeat 0px -513px;
        float: right;
        width: 80px;
        height: 20px;
        padding: 8px 0px 8px 32px;
        cursor: pointer;
    }
    .lineh .upload a:hover.hide
    {
        background-position: 0px -550px;
        color: #36C;
    }
    .lineh .upload a.show, .lineh .upload a:hover.show
    {
        font-size: 12px;
        font-weight: bold;
        line-height: 20px;
        color: #36C;
        background: url(../images/member/album_bg.gif) no-repeat 0px -587px;
        float: right;
        width: 80px;
        height: 20px;
        padding: 8px 0 8px 32px;
        cursor: pointer;
    }
    .upload-wrap
    {
        padding: 0 10px 10px 10px;
    }
    .upload-wrap ul
    {
        width: 208px;
        height: auto;
    }
</style>
<!--弹出层-->
<div class="sp_dialog sp_dialog_out" style="display: none;" id="sp_dialog_outDiv">
    <div class="sp_dialog_cont" style="display: none;" id="sp_dialog_contDiv">
        <div class="sp_tan">
            <h4>
                创建相册</h4>
            <div class="sp_close">
                <a onclick="funClose()" href="javascript:void(0)"></a>
            </div>
            <div class="clear">
            </div>
        </div>
        <table cellspacing="0" cellpadding="0" border="0" style="padding-top: 10px; margin: 20px 0 20px 80px;">
            <tr class="up_spac">
                <td align="right">
                    相册名称：
                </td>
                <td>
                    <input type="text" value="" id="name" name="name" class="ss_nr1" maxlength="6"><span class="star">*</span>
                </td>
            </tr>
            <tr class="up_spac">
                <td align="right">
                    排序：
                </td>
                <td>
                    <input type="text" value="0" id="sort" name="sort" class="ss_nr1" onkeyup="NumTxt_Int(this)" maxlength="5" />
                </td>
            </tr>
            <tr class="up_spac">
                <td align="right">
                    描述：
                </td>
                <td>
                    <textarea id="description" name="description" rows="3" class="ss_nr1" style="font-size:12px; height:70px; width:300px;"></textarea>
                </td>
            </tr>
            <tr class="up_spac">
                <td align="right">
                </td>
                <td>
                    <input type="button" value="提交" onclick="btnSure()" class="baocbtn"><span id="tipmsg"
                        style="color: Red;"></span>
                </td>
            </tr>
        </table>
        <div style="float: right; display: none;">
            <input type="button" id="btnReply" value="确定" /></div>
    </div>
</div>
<!--弹出层-->
