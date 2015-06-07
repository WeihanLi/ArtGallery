function login() {
    var uid = document.getElementById("username");
    var pwd = document.getElementById("password");
    if (uid.value == null || uid.value == "" || pwd.value == "" || pwd.value == null) {
        alert('要输入用户名和密码才可以登陆哦~~~');
        return;
    }
    document.getElementById("loginForm").submit();
}
function logOut() {
    $.post("/Admin/LogOutHandler.ashx", function (data) {
        if (data == "true") {
            window.location.href = '/Admin/login.html';
        }
    });
}
function Operate(val) {
    if (val < 0) {
        logOut();
    } else {
        window.location.href = '/Admin/UpdatePwd.aspx';
    }
}
