document.addEventListener('DOMContentLoaded', async function () {

    // Fetch user data and fill the form
    async function fetchUserData() {
        try {
            const response = await fetch("/User", {
                method: "GET",
            });

            if (!response.ok) {
                showToast(await response.text());
                return;
            }
            console.log(response);
            const data = await response.json();
            // Fill the form fields with the data
            document.getElementById("registerName").value = data.name || "";
            document.getElementById("registerEmail").value = data.email || "";
            document.getElementById("registerPostcode").value = data.postcode || "";

        } catch (error) {
            showToast("Unexpected error. Please try again.");
            console.error("Error", error);
        }
    }

    await fetchUserData();

 
    // Function to show a toast message to the user (when things doesn't work properly)
    function showToast(message) {
        const toastBody = document.getElementById('toast-body');
        toastBody.textContent = message;
        const toastEl = document.getElementById('liveToast');
        const toast = new bootstrap.Toast(toastEl);
        toast.show();
    }

    // This function change the legend, enable the form fields and change the buttons. Is executed when the user click Edit     
    function editForm(){
        document.getElementById("legend").textContent = "Edit Account";
        document.getElementById("registerName").disabled = false;
        document.getElementById("registerEmail").disabled = false;
        document.getElementById("registerPostcode").disabled = false;
        document.getElementById("submit-edit").style.display = "none";
        document.getElementById("delete").style.display = "none";
        document.getElementById("submit").style.display = "inline";
        document.getElementById("cancel").style.display = "inline";
    }

    // This function change the legend, disable the form fields and change the buttons. Is executed when the user click Cancel 
    function cancelEdit(){
        document.getElementById("legend").textContent = "My Account";
        document.getElementById("registerName").disabled = true;
        document.getElementById("registerEmail").disabled = true;
        document.getElementById("registerPostcode").disabled = true;
        document.getElementById("submit-edit").style.display = "inline";
        document.getElementById("delete").style.display = "inline";
        document.getElementById("submit").style.display = "none";
        document.getElementById("cancel").style.display = "none";
    }

    // It prevents the form data be displayed also in the query string
    document.getElementById("account").addEventListener("submit", async function(event) {
        event.preventDefault();  
    });

    // It calls the function edit form when the user clicks the button Edit
    document.getElementById("submit-edit").addEventListener("click", async function(event) {
        editForm();
    });

    // It calls the function cancel edit when the user clicks the button Cancel
    document.getElementById("cancel").addEventListener("click", async function(event) {
        cancelEdit();
    });
});