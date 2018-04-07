$(document).ready(function(){
 
	
	$("#form1").validate({
		rules:{
			TextBoxTitle:{
				required: true,
				maxlength: 50
			},
			TextBoxContent:{
				required: true
			},
			TextBoxKeywords:{
				required: true,
				maxlength: 200
				
			},
			TextBoxTel:{
				required: true,
				number: true,
				maxlength:10
			},
			TextBoxEmail:{
				required: true,
				email: true
			},
			TextBoxDescription:{
			    required: true,
			    maxlength:200
			},
		    TextBoxCode:{
			    required: true,
			    maxlength:4
			},
		    TextBoxOrderID:{
			    required: true,
			    number: true
			},
		
	
		
			TextBoxShopPrice1:{
			    number:true,
			    maxlength:10
			},
			TextBoxShopPrice2:{
			    number:true,
			    maxlength:10
			},
			TextBoxSendTime2:{
			date:true
			},
			TextBoxOtherContactWay:{
			    number:true,
			    maxlength:10
			},
			TextBoxPassWord:{
			   required: true,
			   minlength: 5
			},
			TextBoxNewPWD:{
			   required: true,
               minlength: 5,
               equalTo:"#TextBoxPassWord"
			 },
			TextBoxMemLoginID:{
			   required: true,
			   maxlength: 50
		    },
			TextBox1:{	
				required: true,
				maxlength: 200
			},
			TextBox2:{	
				required: true,
				maxlength: 200
			},
		    TextBoxSendObject:{
		        required: true,
				maxlength: 50
			},
			TextBoxCardnum:{ 
			required:true, 
			    number:true,
			    maxlength:20
			},
			TextBoxCardName:{
			    required: true,
				maxlength: 50
			},
			TextBoxCardDepartment:{
			
			required: true,
			maxlength: 50
			
			},
			TextBoxCardContent:{
			required: true,
			maxlength: 200
			
			
			},
			TextBoxCategoryName:{
			
			
			required: true,
			maxlength: 50
			
			
			},
			TextBoxPublisher:{
			required: true,
			maxlength: 50
			
		},
		TextBoxOrderID:{
		        required:true, 
			    number:true,
			    maxlength:20
		
		}
		
				
	},
		messages:{
			TextBoxTitle:{required:"不得为空",maxlength:"只能输入50个字符"},
			TextBoxContent:{required:"不得为空"},
			TextBoxKeywords: {required:"不得为空",maxlength:"不得大于200"},
			TextBoxTel: {number:"电话号码数字",maxlength:"不得大于10"},
			TextBoxEmail:{email:"email不对"},
			TextBoxDescription: "只能输入200个字符",
			TextBoxCode:"验证码错误",
			TextBoxOrderID:{required:"不得为空",number:"只能输入数字"},
	
		
			TextBoxShopPrice1:{number:"编号为数字",maxlength:"只能输入10个字符"},
			TextBoxShopPrice2:{number:"编号为数字",maxlength:"只能输入10个字符"},
		    TextBoxOtherContactWay:{number:"编号为数字",maxlength:"只能输入10个字符"},
		    TextBoxSendTime2:{date:"必须输入正确格式的日期"},
		    TextBoxPassWord:{required: "请输入密码",minlength: jQuery.format("密码不能小于5个字符")},
			TextBoxNewPWD:{required: "请输入确认密码",minlength: "确认密码不能小于5个字符",equalTo: "两次输入密码不一致"},
            TextBoxMemLoginID:{required:"不得为空",maxlength:"只能输入50个字符"},
    	    TextBox1:{required:"不得为空",maxlength:"只能输入200个字符"},
    	    TextBox2:{required:"不得为空",maxlength:"只能输入200个字符"},
            TextBoxSendObject:{required:"不得为空",maxlength:"只能输入200个字符"},
            TextBoxCardnum:{required:"不得为空",number:"编号为数字",maxlength:"只能输入50个字符"},
            TextBoxCardName:{required:"不得为空",maxlength:"只能输入50个字符"},
            TextBoxCardDepartment:{required:"不得为空",maxlength:"只能输入50个字符"},
            TextBoxCardContent:{required:"不得为空",maxlength:"只能输入200个字符"},
            TextBoxCategoryName:{required:"不得为空",maxlength:"只能输入50个字符"},
            TextBoxPublisher:{ required:"不得为空",maxlength:"只能输入50个字符"},
            TextBoxOrderID:{required:"不得为空",number:"编号为数字",maxlength:"只能输入20个字符"}
            
		}
		
		
		
		
	    })
	

})
