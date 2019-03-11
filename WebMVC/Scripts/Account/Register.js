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