
/*Author by Jely  显示热门收藏和热销商品排行*/
 function tab(selfid,targetid,index,count,selfclass,otherclass) {
    for(var i=0;i<count;i++) {
        if(i == index) {loadCollectRank(index);
            document.getElementById(selfid + i).className = selfclass;
            document.getElementById(targetid + i).style.display = "block";
        }
        else {
            document.getElementById(selfid + i).className = otherclass;
            document.getElementById(targetid + i).style.display = "none";
        }
    }
}
var bcollectflag=true;
function loadCollectRank(index)
{
        if(index=="1"&&bcollectflag)
        {
            bcollectflag=false;
            $.get("/Api/Shop/ProductListOp.ashx?type=collectrank&shopid="+$("#hidShopId").val(),null,function(data){
                    if(data!="")
                    {
                        var NewHtml=new Array();
                        var vdata=eval('('+data+')');
                        $.each(vdata,function(m,n){
                              NewHtml.push(SetCollectRankShow(n));
                        });
                        $("#b1").html(NewHtml.join(""));
                    }
            });
        }
}
 $(function(){
      var bflag=true;
      //屏幕滚动显示
      $(window).scroll(function (){ 
           var menuYloc = $(window).scrollTop(); 
           if(menuYloc>1000)
           {
                if(bflag)
                {
                    bflag=false;
                    $.get("/Api/Shop/ProductListOp.ashx?type=salerank&shopid="+$("#hidShopId").val(),null,function(data){
                            if(data!="")
                            {
                            
                                var NewHtml=new Array();
                                var vdata=eval('('+data+')');
                                
                                $.each(vdata,function(m,n){
                                      NewHtml.push(SetSaleRankShow(n));
                                });
                                $("#b0").html(NewHtml.join(""));
                            }
                    });
                }
           }
     }); 
 });
 //销售排行
 function SetSaleRankShow(data)
 {
     var xhtml=new Array();
     xhtml.push("<ul class=\"contsh\"> <li class=\"sel_rank\">");
     xhtml.push("<div class=\"prdt_img\">");
     xhtml.push("<a href=\""+data.url+"\" target=\"_blank\" title=\""+data.name+"\">");
     xhtml.push("<img src=\""+data.originalimage+"_60x60.jpg\" onerror=\"javascript:this.src=/ImgUpload/noimg.jpg_60x60.jpg\" class=\"mar_img\"> </a>");
     xhtml.push("</div>");
     xhtml.push("</li>");
     xhtml.push("<li class=\"sel_info\">");
     xhtml.push("<p>");
     xhtml.push("<a href=\""+data.url+"\" target=\"_blank\" title=\""+data.name+"\">"+data.name.toString().substring(0,18)+"</a>");
     xhtml.push("</p>");
     xhtml.push("<p><strong>￥"+data.shopprice+"元</strong></p>");
     xhtml.push("<p class=\"sale_out\">已售出<span>"+data.salenumber+"</span>笔</p>");
     xhtml.push(" </li>");
     xhtml.push("</ul> ");
     return xhtml.join("");
 }
 //收藏排行
 function SetCollectRankShow(data)
 {
     var xhtml=new Array();
     xhtml.push("<ul class=\"contsh\"> <li class=\"sel_rank\">");
     xhtml.push("<div class=\"prdt_img\">");
     xhtml.push("<a href=\""+data.url+"\" target=\"_blank\" title=\""+data.productname+"\">");
     xhtml.push("<img src=\""+data.originalimage+"_60x60.jpg\" onerror=\"javascript:this.src=/ImgUpload/noimg.jpg_60x60.jpg\" class=\"mar_img\"> </a>");
     xhtml.push("</div>");
     xhtml.push("</li>");
     xhtml.push("<li class=\"sel_info\">");
     xhtml.push("<p>");
     xhtml.push("<a href=\""+data.url+"\" target=\"_blank\" title=\""+data.productname+"\">"+data.productname.toString().substring(0,18)+"</a>");
     xhtml.push("</p>");
     xhtml.push("<p><strong>￥"+data.shopprice+"元</strong></p>");
     xhtml.push("<p class=\"sale_out\">收藏人气 <span>"+data.salenumber+"</span></p>");
     xhtml.push(" </li>");
     xhtml.push("</ul> ");
     return xhtml.join("");
 }
 /*Author by Jely  显示热门收藏和热销商品排行*/