document.addEventListener('DOMContentLoaded', function () {

    window.togglePassword = function(inputId, el) {
        const input = document.getElementById(inputId);
        const icon = el.querySelector('i');
        if (input.type === "password") {
            input.type = "text";
            // Show open eye when visible
            icon.classList.remove('fa-eye-slash');
            icon.classList.add('fa-eye');
        } else {
            input.type = "password";
            // Show closed eye when hidden
            icon.classList.remove('fa-eye');
            icon.classList.add('fa-eye-slash');
        }
    };

     // Show only login form by default, hide register form
    const forms = document.querySelectorAll('main > form, main > section > form');
    const registerForm = forms[0];
    const loginForm = forms[1];

    if (registerForm && loginForm) {
        registerForm.style.display = "none";
        loginForm.style.display = "block";

        // Handle "Create one" link
        const createOneLink = loginForm.querySelector('a[href="#register"]');
        if (createOneLink) {
            createOneLink.addEventListener('click', function (e) {
                e.preventDefault();
                loginForm.style.display = "none";
                registerForm.style.display = "block";
                registerForm.scrollIntoView({behavior: 'smooth'});
            });
        }
    }
});