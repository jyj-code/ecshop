﻿$(function(){
    $("#headtest2").hover
    (
        function()
        {
            $(this).addClass("huaguo2");
          
        },
        function()
        {
            $(this).removeClass("huaguo2");
        }
   );

    $("#headtest3").hover
    (
        function()
        {
            $(this).addClass("huaguo3");
          
        },
        function()
        {
            $(this).removeClass("huaguo3");
        }
   );
})

$(function(){
    //鼠标划入时
    $('#DivShangcheng').hover
    (
            function()
            {
                  $(this).children('div').show();
                  $(this).children('span').css("color","#780002");
            },
            //鼠标移除时
            function()
            {
                  $(this).children('div').hide();
                  $(this).children('span').css("color","");
            }
     );
      //鼠标划入时
    $('#DivGouwuche').hover
    (
            function()
            {
                  $(this).children('div').show();
                  $(this).children('span').css("color","#780002");
            
            },
            //鼠标移除时
            function()
            {
                  $(this).children('div').hide();
                  $(this).children('span').css("color","");
            }
     );
})