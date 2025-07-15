document.addEventListener('DOMContentLoaded', async function () {

    // Function to show a toast message to the user (when things doesn't work properly)
    function showToast(message) {
        const toastBody = document.getElementById('toast-body');
        toastBody.textContent = message;
        const toastEl = document.getElementById('liveToast');
        const toast = new bootstrap.Toast(toastEl);
        toast.show();
    }

    async function logout(){
        try {
            const response = await fetch('/User/logout', {
                method: 'POST', // HTTP method
            });

            // If logout fail, display error message
            if (!response.ok) {
                showToast(await response.text());
                return;
            }

            // If logout is successful, redirect to my trays page
            window.location.href = "index.html";
        } catch (error) {
            //Show an error message to the user
            showToast("Unexpected error. Please try again.");
            console.error('Error:', error);
        }
    }

    // It calls the function cancel edit when the user clicks the button Cancel
    document.getElementById("logout").addEventListener("click", async function(event) {
        logout();
    });

    // This function hidden the links to my-account, my-trays and logout, if the user is not logged in
    async function updateDropdownMenu() {
        try {
            const response = await fetch('/User', { method: 'GET', redirect: 'manual' });

            if (response.type !== 'opaqueredirect')
            {
                // Logged in: show My account, My trays, Logout; hide Login
                document.getElementById("my-account").style.display = "block";
                document.getElementById("my-trays").style.display = "block";
                document.getElementById("logout").style.display = "block";
                document.getElementById("login").style.display = "none";
            } else {
                // Not logged in: show Login; hide My account, My trays, Logout
                document.getElementById("my-account").style.display = "none";
                document.getElementById("my-trays").style.display = "none";
                document.getElementById("logout").style.display = "none";
                document.getElementById("login").style.display = "block";
            }
        } catch (error) {
            console.error("Error checking login status:", error);
            // Optional: fall back to logged-out view
            document.getElementById("my-account").style.display = "none";
            document.getElementById("my-trays").style.display = "none";
            document.getElementById("logout").style.display = "none";
            document.getElementById("login").style.display = "block";
        }
    }   

    updateDropdownMenu();
});