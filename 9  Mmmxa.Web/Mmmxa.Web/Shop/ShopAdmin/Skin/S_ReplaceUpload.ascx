<%@ Control Language="C#" %>
<link href="http://shop23.0851it.com/templates/default/css/base.css" rel="stylesheet" type="text/css">
<link href="http://shop23.0851it.com/templates/default/css/member.css" rel="stylesheet" type="text/css">
<link href="http://shop23.0851it.com/templates/default/css/member_store.css" rel="stylesheet" type="text/css">
<script type="text/javascript" src="http://shop23.0851it.com/resource/js/jquery.js"></script>
<style type="text/css">
body { background-color: #F5F5F5; margin: 0; padding: 0; position:relative; z-index:0;}
.upload_wrap { padding: 0; border: 0;}
.pic-change-a { font-size:12px; line-height: 20px; color: #999; background: #F5F5F5 url(http://shop23.0851it.com/templates/default/images/member/album_bg.gif) no-repeat 0px -330px ; display: block; width: 60px; height: 20px; float: left; padding-left: 24px; white-space: nowrap;}
.pic-change-b {font-size:12px; text-decoration: underline; color: #36C; line-height: 20px; background: #F5F5F5 url(http://shop23.0851it.com/templates/default/images/member/album_bg.gif) no-repeat -152px -330px; display: block; width: 60px; height: 20px; float: left; padding-left: 24px; white-space: nowrap; }
</style>
<script type="text/javascript">
function submit_form(obj)
{
    obj.attr('disabled', 'disabled');
    $('#image_form').submit();
}
$(function(){
	$('span').hover(
	function(){
		$('#picChange').attr('class','pic-change-b');
	},
	function(){
		$('#picChange').attr('class','pic-change-a');
	});
});
</script>
  <input type="hidden" name="id" value="476">
  <input type="hidden" name="form_submit" value="ok" />
  <span style="height: 20px; position: absolute; left: 0px; top: 0px; width: 84px; z-index: 999;">
  <input onChange="$('#submit_button').click();" type="file" name="file" style=" width: 84px; height: 20px; cursor: pointer;  opacity:0; filter: alpha(opacity=0)" size="1" hidefocus="true" maxlength="0">
  </span> <div class="pic-change-a" id="picChange">替换上传</div>
  <input id="submit_button" style="display:none" type="button" value="提交" onClick="submit_form($(this))" />