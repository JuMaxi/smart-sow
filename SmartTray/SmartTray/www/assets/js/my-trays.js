document.addEventListener('DOMContentLoaded', function () {
    // Function to display tooltip when hovering the table icons
    function displayToolTip(){
        var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
        tooltipTriggerList.forEach(function (tooltipTriggerEl) {
            new bootstrap.Tooltip(tooltipTriggerEl);
        });
    }
    
    // Fetch tray data and fill the form http GET
    async function fetchTrayData() {
        try {
            const response = await fetch("/Tray", {
                method: "GET",
            });

            if (!response.ok) {
                showToast(await response.text());
                return;
            }

            // The const data is an array. Itirating over each and save each tray to its the view
            const data = await response.json();

            // Creating the elements to the table body
            let table = document.getElementById("trays");

            for (let i = 0; i < data.length; i++){
                // Create a new row to the table
                let line = document.createElement("tr");

                // Format the date
                let sowingDate = new Date(data[i].sowingDate).toLocaleDateString('en-GB'); // DD/MM/YYYY

                let html = `<td>${data[i].name}</td>
                            <td>${data[i].cropType}</td>
                            <td>${sowingDate}</td>
                            <td>${data[i].status}</td>
                            <td>
                                <a href="edit-tray.html?id=${data[i].id}" class="btn btn-primary btn-sm me-1" data-bs-toggle="tooltip" title="Edit">
                                    <i class="fa-solid fa-pen-to-square"></i>
                                </a>
                                <a href="display-data.html?id=${data[i].id}" class="btn btn-info btn-sm me-1 text-white" data-bs-toggle="tooltip" title="View">
                                    <i class="fa-solid fa-eye"></i>
                                </a>
                                <a href="deactivate-tray.html?id=${data[i].id}" class="btn btn-danger btn-sm" data-bs-toggle="tooltip" title="Deactivate">
                                    <i class="fa-solid fa-ban"></i>
                                </a>
                            </td>`;
                line.innerHTML = html;
                table.appendChild(line)
            }

            // Calling the function to display tool tips above the action button when hovered
            displayToolTip();

        } catch (error) {
            showToast("Unexpected error. Please try again.");
            console.error("Error", error);
        }
    }

    // Call the function to fetch the trays from database
    fetchTrayData();

    // Function to show a toast message to the user (when things doesn't work properly)
    function showToast(message) {
        const toastBody = document.getElementById('toast-body');
        toastBody.textContent = message;
        const toastEl = document.getElementById('liveToast');
        const toast = new bootstrap.Toast(toastEl);
        toast.show();
    }

    

});