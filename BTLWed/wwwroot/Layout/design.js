
function login(){
    var email = document.getElementById("user");
    let pass = document.getElementById("pass").value;
    if(email.value !=""){
        if(pass !=""){
            return true;
        }else{
            alert('vui lòng nhập mật khẩu');
            pass = document.getElementById("pass").focus();
            return false;
        }
    }{
        if(pass != ''){
            alert('vui lòng nhập tài khoản');
            document.getElementById("user").focus();
            return false;
        } else {
            alert('vui lòng nhập tài khoản và mật khẩu');
            return false;
        }
    }
}

function register(){
    var name = document.getElementById("name").value;
    var email = document.getElementById("email").value;
    var pwd = document.getElementById("pwd").value;
    var pw = document.getElementById("pw").value;
    var phone = document.getElementById("phone").value;
    var birth = document.getElementById("birth").value;
    
    if(birth  == '' || name == '' || email == ' ' || pwd == ' ' || pw == '' || phone == ''){
        alert('vui lòng điền đầy đủ thông tin');
        return false;
    }
    if(pw != pwd){
         alert('mật khẩu không trùng khớp');
         pw.focus();
         return false;
    }
    alert('dang ki thanh cong');
    return true;
}