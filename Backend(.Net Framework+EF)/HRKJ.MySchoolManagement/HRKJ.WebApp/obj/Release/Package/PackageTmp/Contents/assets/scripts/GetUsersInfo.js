$(function ()
{
    $.post("../../../Manager/LoginManager/GetUsersInfo", function (info) {
        console.log(info);
        if (info.Code == 404) {
            window.location.href = "../../Manager/LoginManager/SignIn";
        }
        else {
            $("#UsersName").text(info.UserName);
            $("#UsersImg").attr("src", "../../../Contents/upload/users/" + info.UserImg);
        }
    }, "json")

})