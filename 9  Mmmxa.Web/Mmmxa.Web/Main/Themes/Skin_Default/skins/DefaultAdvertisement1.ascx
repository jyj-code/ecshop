<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="System.Data" %>

<script type="text/javascript">
$(function() {
	var sWidth = $("#focus").width(); //获取焦点图的宽度（显示面积）
	var len = $("#focus ul li").length; //获取焦点图个数
	var index = 0;
	var picTimer;
	
	//以下代码添加数字按钮和按钮后的半透明长条
	var btn = "<div class='btnBg'></div><div class='btn'>";
	for(var i=0; i < len; i++) {
		btn += "<span>" + (i+1) + "</span>";
	}
	btn += "</div>"
	$("#focus").append(btn);
	$("#focus .btnBg").css("opacity",0.5);
	
	//为数字按钮添加鼠标滑入事件，以显示相应的内容
	$("#focus .btn span").mouseenter(function() {
		index = $("#focus .btn span").index(this);
		showPics(index);
	}).eq(0).trigger("mouseenter");
	
	//本例为左右滚动，即所有li元素都是在同一排向左浮动，所以这里需要计算出外围ul元素的宽度
	$("#focus ul").css("width",sWidth * (len + 1));
	
	//鼠标滑入某li中的某div里，调整其同辈div元素的透明度，由于li的背景为黑色，所以会有变暗的效果
	$("#focus ul li div").hover(function() {
		$(this).siblings().css("opacity",0.7);
	},function() {
		$("#focus ul li div").css("opacity",1);
	});
	
	//鼠标滑上焦点图时停止自动播放，滑出时开始自动播放
	$("#focus").hover(function() {
		clearInterval(picTimer);
	},function() {
		picTimer = setInterval(function() {
			if(index == len) { //如果索引值等于li元素个数，说明最后一张图播放完毕，接下来要显示第一张图，即调用showFirPic()，然后将索引值清零
				showFirPic();
				index = 0;
			} else { //如果索引值不等于li元素个数，按普通状态切换，调用showPics()
				showPics(index);
			}
			index++;
		},3000); //此3000代表自动播放的间隔，单位：毫秒
	}).trigger("mouseleave");
	
	//显示图片函数，根据接收的index值显示相应的内容
	function showPics(index) { //普通切换
		var nowLeft = -index*sWidth; //根据index值计算ul元素的left值
		$("#focus ul").stop(true,false).animate({"left":nowLeft},500); //通过animate()调整ul元素滚动到计算出的position
		$("#focus .btn span").removeClass("on").eq(index).addClass("on"); //为当前的按钮切换到选中的效果
	}
	
	function showFirPic() { //最后一张图自动切换到第一张图时专用
		$("#focus ul").append($("#focus ul li:first").clone());
		var nowLeft = -len*sWidth; //通过li元素个数计算ul元素的left值，也就是最后一个li元素的右边
		$("#focus ul").stop(true,false).animate({"left":nowLeft},500,function() {
			//通过callback，在动画结束后把ul元素重新定位到起点，然后删除最后一个复制过去的元素
			$("#focus ul").css("left","0");
			$("#focus ul li:last").remove();
		}); 
		$("#focus .btn span").removeClass("on").eq(0).addClass("on"); //为第一个按钮添加选中的效果
	}
});

</script>

<div class="hd_adver fl" style="display: none;">
    <div class="hd_adver_img">
        <a href="javascript:void(0)">
            <img id="AdBigImg" width="294" height="457" src="Themes/Skin_Default/Images/hd1.jpg"
                runat="server" />
        </a>
    </div>
    <div class="hd_bottom">
    </div>
    <div class="hd_bottom_font" id="smallImgName">
    </div>
    <div class="hd_bottom_img" id="divSmallImg">
        <asp:Repeater ID="RepeaterSmall" runat="server">
            <ItemTemplate>
                <a href='<%#((DataRowView)Container.DataItem).Row["href"]%>'>
                    <img onclick="SmallMover(this)" alt='<%#((DataRowView)Container.DataItem).Row["title"]%>'
                        width="36" height="50" runat="server" onmouseover="SmallMover(this)" onmouseout="ImgInterv(this)"
                        src='<%#((DataRowView)Container.DataItem).Row["imgsrc"] %>' title='<%#((DataRowView)Container.DataItem).Row["title"]%>' />
                </a>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
<div id="focus" class="tsSlide" style="position: relative; z-index: 1;">
    <ul class="tsSlide_list" style="position: absolute; z-index: 2">
        <li>
            <div style="left: 0; top: 0; width: 560px; height: 380px;">
                <a href="#">
                    <img class="imghdp" style="width: 560px; height: 380px;" src="Themes/Skin_Default/Images/a01.jpg"
                        alt="shopnum1" /></a></div>
            <div style="right: 0; top: 0; width: 220px; height: 140px;">
                <a href="#">
                    <img class="imghdp" style="width: 220px; height: 140px;" src="Themes/Skin_Default/Images/a02.jpg"
                        alt="shopnum1" /></a></div>
            <div style="right: 0; top: 140px; width: 220px; height: 140px;">
                <a href="#">
                    <img class="imghdp" style="width: 220px; height: 140px;" src="Themes/Skin_Default/Images/a03.jpg"
                        alt="shopnum1" /></a></div>
            <div style="right: 0; bottom: 0; width: 220px; height: 100px;">
                <a href="#">
                    <img class="imghdp" style="width: 220px; height: 100px;" src="Themes/Skin_Default/Images/a04.jpg"
                        alt="shopnum1" /></a></div>
        </li>
        <li>
            <div style="left: 0; top: 0; width: 780px; height: 380px;">
                <a href="#">
                    <img class="imghdp" style="width: 780px; height: 380px;" src="Themes/Skin_Default/Images/b01.jpg"
                        alt="shopnum1" /></a></div>
        </li>
        <li>
            <div style="left: 0; top: 0; width: 260px; height: 210px;">
                <a href="#">
                    <img class="imghdp" style="width: 260px; height: 210px;" src="Themes/Skin_Default/Images/c01.jpg"
                        alt="shopnum1" /></a></div>
            <div style="left: 260px; top: 0; width: 260px; height: 210px;">
                <a href="">
                    <img class="imghdp" style="width: 260px; height: 210px;" src="Themes/Skin_Default/Images/c02.jpg"
                        alt="shopnum1" /></a></div>
            <div style="left: 0; top: 210px; width: 520px; height: 170px;">
                <a href="#">
                    <img class="imghdp" style="width: 520px; height: 170px;" src="Themes/Skin_Default/Images/c03.jpg"
                        alt="shopnum1" /></a></div>
            <div style="right: 0; top: 0; width: 260px; height: 380px;">
                <a href="#">
                    <img class="imghdp" style="width: 260px; height: 380px;" src="Themes/Skin_Default/Images/c04.jpg"
                        alt="shopnum1" /></a></div>
        </li>
        <li>
            <div style="left: 0; top: 0; width: 560px; height: 380px;">
                <a href="#">
                    <img class="imghdp" style="width: 560px; height: 380px;" src="Themes/Skin_Default/Images/d01.jpg"
                        alt="shopnum1" /></a></div>
            <div style="right: 0; top: 0; width: 220px; height: 140px;">
                <a href="#">
                    <img class="imghdp" style="width: 220px; height: 140px;" src="Themes/Skin_Default/Images/d02.jpg"
                        alt="shopnum1" /></a></div>
            <div style="right: 0; top: 140px; width: 220px; height: 140px;">
                <a href="#">
                    <img class="imghdp" style="width: 220px; height: 140px;" src="Themes/Skin_Default/Images/d03.jpg"
                        alt="shopnum1" /></a></div>
            <div style="right: 0; bottom: 0; width: 220px; height: 100px;">
                <a href="#">
                    <img class="imghdp" style="width: 220px; height: 100px;" src="Themes/Skin_Default/Images/d04.jpg"
                        alt="shopnum1" /></a></div>
        </li>
        <li>
            <div style="left: 0; top: 0; width: 780px; height: 380px;">
                <a href="#">
                    <img class="imghdp" style="width: 780px; height: 380px;" src="Themes/Skin_Default/Images/e01.jpg"
                        alt="shopnum1" /></a></div>
        </li>
    </ul>
</div>
