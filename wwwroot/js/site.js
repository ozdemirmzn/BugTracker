//Make ajax post request to DemoLoginController by submitting admin/superadmin/basic user names
function demoLogin(userName) {
    $.post("/DemoLogin/LoginUser", { userName: userName })
        .done(function (data) {
            $("#overlay").fadeOut(1000); //overlay fadeout

            //Refresh page, otherwise even though user is signed in, the page appears static. 
            //DemoLoginController redirecting to Home / Index.cshtml doesn't work.
            //After page reload user appears to be signed in.
            location.reload();
        });
}