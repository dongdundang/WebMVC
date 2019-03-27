'use strict';

var registerForm = document.getElementById("RegisterForm");
var registerButton = document.getElementById("RegisterButton");

anime({
    targets: registerForm,
    translateX: 0,
    scale: 1,
    duration: 2000,
    rotate: '1turn'
});

function registerButtonClick() {
    registerButton.disabled = true;
    anime({
        targets: registerButton,
        keyframes: [
            { translateY: -20, duration: 50 },
            { translateX: 0, duration: 50 },
        ],
        direction: "alternate",
        easing: "easeInOutSine"
    });
    registerForm.submit();

}

function validateUsername() {
    var usernameToCheck = document.getElementById("Username").value;
    var usernameValidator = document.getElementById("UsernameValidator");

    if (usernameToCheck.length < 6) {
        usernameValidator.innerHTML = "Username must be between 6 and 32 characters";
    }
    else {
        var url = "/Account/CheckUsernameExist";
        var param = { username: usernameToCheck };
        var promise = ajaxGet(url, param);
        promise.done(function (data) {
            if (data == 1) {
                usernameValidator.innerHTML = "Username has been taken";
            }
            else {
                usernameValidator.innerHTML = "";
            }
        })
    }
}