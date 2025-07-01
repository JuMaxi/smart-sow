document.addEventListener('DOMContentLoaded', function () {

    window.togglePassword = function(inputId, el) {
        const input = document.getElementById(inputId);
        const icon = el.querySelector('i');
        if (input.type === "password") {
            input.type = "text";
            icon.classList.remove('fa-eye-slash');
            icon.classList.add('fa-eye');
        } else {
            input.type = "password";
            icon.classList.remove('fa-eye');
            icon.classList.add('fa-eye-slash');
        }
    };

    // Utility: Check if user is logged in (adjust logic as needed)
    function isUserLoggedIn() {
        return !!localStorage.getItem('userLoggedIn');
    }

    // Show only login form if user is not logged in
    function showLoginOnly() {
        // Register section fieldset
        const registerSection = document.querySelector('section fieldset');
        // Login section form (with .my-4)
        const loginSection = document.querySelector('section form.my-4');

        if (!isUserLoggedIn()) {
            if (registerSection) registerSection.style.display = "none";
            if (loginSection) loginSection.style.display = "block";
        } else {
            // If logged in, you may want to hide both or redirect
            if (registerSection) registerSection.style.display = "none";
            if (loginSection) loginSection.style.display = "none";
        }
    }

    // Handle "Create one" link to show register form
    function setupCreateAccountLink() {
        const registerSection = document.querySelector('section fieldset');
        const loginSection = document.querySelector('section form.my-4');
        const createOneLink = loginSection
            ? loginSection.querySelector('a[href="#register"]')
            : null;

        if (createOneLink && registerSection && loginSection) {
            createOneLink.addEventListener('click', function (e) {
                e.preventDefault();
                loginSection.style.display = "none";
                registerSection.style.display = "block";
                registerSection.scrollIntoView({behavior: 'smooth'});
            });
        }
    }

    // Initial state: show only login if not logged in
    showLoginOnly();
    setupCreateAccountLink();
});