<%@ Page Language="C#"%>
<%@ Import Namespace="ShopNum1.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>相册列表</title>
           <script type="text/javascript" language="javascript" src="js/jquery.pack.js"></script>
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <link rel='stylesheet' type='text/css' href='style/lightbox.css' />
    <script type="text/javascript" src="uploadify/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src="uploadify/swfobject.js"></script>
    <script type="text/javascript" src="uploadify/jquery.uploadify.v2.1.4.min.js"></script>
<script type="text/javascript" src="js/jquery.lightbox.js"></script>
        <style type="text/css">
            #tooltip { position:absolute; z-index:1000; max-width:300px; width:auto!important; width:auto; background:#006CDB; border:#FEFFD4 solid 1px; text-align:left; padding:3px;}
#tooltip p { padding:10px;color:#FFFFFE;font:12px verdana,arial,sans-serif; line-height:180%;}
.picture-list { clear: both; width: 100%;z-index:0;}
.picture-list li { float: left;	width: 180px; padding: 6px;z-index:0;}
*+html .picture-list li { float: left;	width: 175px; padding: 6px;z-index:0;}
.picture-list li dl { position: relative; z-index: 1; width: 180px;width: 180px; height: 270px; padding-top:6px;}

.picture-list li dl dt { background-color: #F5F5F5; width: 164px; height: 164px; padding: 2px;margin: 0 6px;z-index:0px;}
*+html .picture-list li dl dt { background-color: #F5F5F5; width: 164px; height: 164px; padding: 2px 0;margin: 0 0px;z-index:0px;}
.picture-list li.normal dl dt .picture { background-color: #FFF; width:160px; height:160px;z-index:0;}
.picture-list li.active dl dt .picture { background-color: #FFF; width:160px; height:160px;z-index:0;}
.picture-list li dl dt .picture { width: 160px; height: 160px; border: 2px solid #FFF; display:block; /*IE7/8/9*/*text-align: center;z-index:0;}
.picture-list li dl dt .checkbox { width: 16px; height: 16px; position: absolute; z-index: 9; top: 10px; left: 10px;}

.picture-list li dl dt .editInput1 { font-size:12px; font-weight: bold; line-height: 20px; color: #555; background-color: transparent; width:140px; height:20px; border:0; }
.picture-list li dl dt .editInput2 { font-size:12px;line-height: 20px; color: #333; background: #FFF; width:140px; height:20px; border: 1px solid #36C;}
.picture-list li dl dt .edit-ico { background: url(images/member/album_bg.gif) no-repeat;width: 20px; height: 20px; position: absolute; z-index: 1; top: 180px; right: 8px;}
.picture-list .normal dl dt .edit-ico{ background-image: none;}
.picture-list .active dl dt .edit-ico { background-position: 0px -250px;}
.picture-list .normal dl dd.date { line-height: 22px; color: #999; width: 160px; height: 60px; position: absolute; z-index: 3; top: 204px; left: 8px; padding: 0 0 0 8px;}
.picture-list .active dl dd.buttons { width: 168px; height: 60px; padding: 0px; position: absolute; top: 250px; left: 8px; z-index: 3;}
.picture-list .active dl dd.date{ display:none;z-index:0;}
.picture-list .active dl dd.buttons a { line-height: 20px; color: #999; background: url(images/member/album_bg.gif) no-repeat; display: block; width: 60px; height: 20px; float: left; padding-left: 24px; margin: 5px 0;}
.picture-list .active dl dd.buttons .change-btn { background-color: #F5F5F5; display: block; 
float: left; width: 84px; height:20px; margin: 5px 0;} 
.picture-list .active dl dd a:hover { text-decoration: underline;color: #36C;}
.picture-list .active dl dd a.change { background-position: 0px -330px;}
.picture-list .active dl dd a.remove { background: url(images/member/album_bg.gif) no-repeat;background-position: 0px -270px; cursor: pointer; }
.picture-list .active dl dd a.cover { background-position: 0px -290px;}
.picture-list .active dl dd a.delete { background-position: 0px -310px;}
.picture-list .active dl dd a:hover.change { background-position: -152px -330px;}
.picture-list .active dl dd a:hover.remove { background-position: -152px -270px;}
.picture-list .active dl dd a:hover.cover {	background-position: -152px -290px;}
.picture-list .active dl dd a:hover.delete { background-position: -152px -310px;}
    em{    display: inline-block;
    height: 16px;
    line-height: 22px;
    margin-right: 5px;
    width: 16px;}
    
.album { }
.album li dl dt .covers { background: url(../images/member/album_bg.gif) no-repeat 0px 0px; /*IE7/8/9*/*text-align: center; width: 150px; height: 150px; padding: 8px 14px 14px 8px; word-wrap:normal;}
.album li{ width: 172px; height: 238px; display: block; float: left; padding: 10px;}
.album li dl { width: 100%; }
.album li dl dt h3 { font-size: 12px; line-height: 24px; white-space: nowrap; width: 156px; height: 24px; padding-left: 8px; margin-top:6px; overflow: hidden;}
.album li dl dt h3 a { color: #555;}
.album li dl dt h5 { font-size: 12px; font-weight: normal; line-height: 20px; color: #999; height: 20px; padding-left: 8px;}
.album li dl dd { height: 14px; margin-top:6px;}
.album li.hidden dl dd { display: none;}
.album li.show dl dd { display: block;}
.album li dl dd a { display: inline; font-weight:600; color: #999; background: url(../images/member/album_bg.gif) no-repeat; line-height: 20px; padding: 0px 12px 0 24px; margin:0 0 0 6px; float: left;}
.album li dl dd a:hover { color: #36C; text-decoration: underline;}
.album li dl dd a.edit2 { background-position: -152px -513px;}
.album li dl dd a:hover.edit2 { background-position: -152px -533px;}
.album li dl dd a.del { background-position: -152px -553px;}
.album li dl dd a:hover.del { background-position: -152px -573px;}


.lineh .upload { background-image: none; width: 112px;height:36px; margin:0;}
.lineh .upload a.hide { font-size: 12px; font-weight: bold; line-height: 20px; color: #999; background: url(../images/member/album_bg.gif) no-repeat 0px -513px; float:right; width: 80px; height: 20px; padding: 8px 0px 8px 32px; cursor: pointer;}
.lineh .upload a:hover.hide { background-position: 0px -550px; color: #36C;}
.lineh .upload a.show , .lineh .upload a:hover.show { font-size: 12px; font-weight: bold; line-height: 20px; color: #36C; background: url(../images/member/album_bg.gif) no-repeat 0px -587px;  float:right; width: 80px; height: 20px; padding: 8px 0 8px 32px; cursor: pointer;}
.upload-wrap { padding: 0 10px 10px 10px; }
.upload-wrap ul { width: 208px; height:auto;  }
        </style>
        <script type="text/javascript">
	$(function() 
	{
	    $(".lightbox").lightbox();
//		$("a.thumb, img.thumb").thumbs();
//		$("a.thumb img, img.thumb").thumbsImg();
		$("#selectall").click(function(){
		         $("input[name='sub_check']").attr("checked",$(this).is(":checked"));
		});
		
		
	});
   function submit_Del()
   {
       var pushId=new Array();
       var pushImg=new Array();
       var isflag=true;
       $("input[name='sub_check']").each(function(){
            if($(this).is(":checked"))
            {
                isflag=false;
                pushId.push($(this).val());
                pushImg.push($(this).attr("check_path"));
            }
       });
       if(isflag)
       {
          alert("请勾选一条数据进行批量删除！");return false;
       }
       if(confirm("是否确认删除？"))
       {
           $("#S_AlbumList_ctl00_hidArryId").val(pushId.join(","));
           $("#S_AlbumList_ctl00_hidPath").val(pushImg.join(","));
           return true;
       }
       return false;
   }
</script>
</head>
<body>  
    <form id="form1" runat="server">
  <div class="dpsc_mian1">
  <p class="ptitle" ><a href="S_Welcome.aspx">我是卖家</a><span class="breadcrume_icon">>></span><a href="S_Album.aspx">图片管理</a><span class="breadcrume_icon">>></span></span><span class="breadcrume_text">图片列表</span></p>
  <div id="list_main">
      <ul id="sidebar">
           <li><a href="S_Album.aspx" style="display:block;text-decoration:none">我的相册</a></li>
           <li id="" class='TabbedPanelsTab TabbedPanelsTabSelected'>图片列表</li>
           <li><a href="S_Album.aspx?type=1" style="display:block; text-decoration:none">水印管理</a></li>
      </ul>
      <div id="content">
       <div class="pad"> 
           <ShopNum1ShopAdmin:S_AlbumList ID="S_AlbumList" runat="server" PageSize="12" SkinFilename="skin/S_AlbumList.ascx" /></div>
         
      </div>  
   </div>
</div>
    </form>
</body>
</html>
