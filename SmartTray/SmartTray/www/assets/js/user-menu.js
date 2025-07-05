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

            // If login fail, display error message
            if (!response.ok) {
                showToast(await response.text());
                return;
            }

            // If login is successful, redirect to my trays page
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
    
    document.getElementById("logout2").addEventListener("click", async function(event) {
        logout();
    });
});