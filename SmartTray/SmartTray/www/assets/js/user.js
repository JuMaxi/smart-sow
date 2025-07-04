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

    // Utility: Check if user is logged in (adjust logic as needed)
    function isUserLoggedIn() {
        return !!localStorage.getItem('userLoggedIn');
    }

    async function register(){
        let data = {
            name: document.getElementById("registerName").value,
            email: document.getElementById("registerEmail").value,
            password: document.getElementById("registerPassword").value,
            confirmPassword: document.getElementById("confirmPassword").value,
            postcode: document.getElementById("registerPostcode").value
        };
        try {
            const response = await fetch('/User', {
                method: 'POST', // HTTP method
                headers: {
                    'Content-Type': 'application/json' // Tell the server we're sending JSON
                },
                body: JSON.stringify(data) // Convert JS object to JSON string
            });

            if (!response.ok) {
                // TODO: Show an error message to the user
                return;
                //throw new Error(`HTTP error! status: ${response.status}`);
            }

            //const result = await response.json(); // Parse JSON response
            //console.log('Success:', result);
            // TODO: Redirect to /my-trays.html
            //return result;
        } catch (error) {
            // TODO: Show an error message to the user
            console.error('Error:', error);
        }
    }

    document.getElementById("registerForm").addEventListener("submit", async function(event) {
        event.preventDefault();  
        await register();
    });
});