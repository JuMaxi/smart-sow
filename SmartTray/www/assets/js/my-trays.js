document.addEventListener('DOMContentLoaded', function () {
    // Function to display tooltip when hovering the table icons
    function displayToolTip(){
        var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
        tooltipTriggerList.forEach(function (tooltipTriggerEl) {
            new bootstrap.Tooltip(tooltipTriggerEl);
        });
    }

    // This function fetchs a tray by id and enable the fields to edition by calling the function edit form
    async function showTrayData(id){
        try {
            const response = await fetch(`/Tray/${id}`, {
                method: "GET",
            });

            if (!response.ok) {
                showToast(await response.text());
                return;
            }

            // The const data is a tray
            const data = await response.json();

            // Format the date
            let sowingDate = new Date(data.sowingDate).toISOString().substring(0,10);
            console.log(sowingDate);
            
            // Populate the section to tray edit with data
            document.getElementById("trayName").value = data.name;
            document.getElementById("cropType").value = data.cropType;
            document.getElementById("sowingDate").value = sowingDate;
            document.getElementById("trayTemperature").value = data.settings.temperatureCelsius;
            document.getElementById("trayHumidity").value = data.settings.humidity;
            document.getElementById("traySolarHours").value = data.settings.dailySolarHours;

            // Call function to enable form edition, change legend text content, hide table trays and display form to edit
            EditForm();

            // It calls the function updateTray when the user clicks the button Submit
            document.getElementById("submit").addEventListener("click", async function(event) {
                updateTray(id);
            });
        }
        catch (error) {
            showToast("Unexpected error. Please try again.");
            console.error("Error", error);
        }
    }

    // Function to enable form fields to edition and disable trays table container
    function EditForm(){
        // Make the section to display tray data visible
        document.getElementById("display-tray").style.display = "inline";

        // Hide the section that display all the user trays
        document.getElementById("trays-container").style.display = "none";


        // Enable the form fields to edit
        document.getElementById("trayName").disabled = false;
        document.getElementById("cropType").disabled = false;
        document.getElementById("sowingDate").disabled = false;
        document.getElementById("trayTemperature").disabled = false;
        document.getElementById("trayHumidity").disabled = false;
        document.getElementById("traySolarHours").disabled = false;
    }

    // Function to return to trays table when user cancels edit
    function cancelEdit(){
        // Redirect to my trays page
        window.location.href = "my-trays.html";
    }

    // Creating a pointer to the functions, because the HTML wasn't accessing the functions without it
    // These functions are being called inside the fetchTrayDataList function int the buttons (actions) created via js
    document.showTrayData = showTrayData;
    document.updateTrayStatus = updateTrayStatus;
    
    // Fetch all user trays from database and fill the view form (http GET)
    async function fetchTrayDataList() {
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
                            <td class="text-center">
                                <a class="token" href="#" data-token="${data[i].token}">
                                    <i class="fa-solid fa-lock" style="color: #082b03;"></i>
                                </a>
                            </td>
                            <td class="text-center">
                                <a id="token" href="javascript:document.showTrayData(${data[i].id})" class="btn btn-warning btn-sm me-1 text-white" data-bs-toggle="tooltip" title="Edit">
                                    <i class="fa-solid fa-pen-to-square"></i>
                                </a>
                                <a href="display-data.html?id=${data[i].id}" class="btn btn-info btn-sm me-1 text-white" data-bs-toggle="tooltip" title="View">
                                    <i class="fa-solid fa-eye"></i>
                                </a>
                                <a href="javascript:document.updateTrayStatus(${data[i].id})" class="btn btn-danger btn-sm" data-bs-toggle="tooltip" title="Deactivate">
                                    <i class="fa-solid fa-ban"></i>
                                </a>
                            </td>`;
                line.innerHTML = html;

                let tokenLink = line.querySelector('.token');
                tokenLink.addEventListener('click', function(e) {
                    e.preventDefault();
                    setupTokenToggle(tokenLink);
                });

                table.appendChild(line)
                
                // Call function checks the tray status. If inactive, it disables the buttons Edit and Deactivate
                setDeactivateButtonState(line, data[i].status);
            }

            // Calling the function to display tool tips above the action button when hovered
            displayToolTip();

        } catch (error) {
            showToast("Unexpected error. Please try again.");
            console.error("Error", error);
        }
    }


    // Call the function to fetch the trays from database
    fetchTrayDataList();

    // This function when the icon is clicked, show the token and hides the icon.
    //  And then if clicked again, hides the token and displays the icon.
    function setupTokenToggle(link) {
        const cell = link.parentElement;
        // If currently showing the token (span), switch to icon
        if (cell.querySelector('span')) {
            cell.innerHTML = '';
            cell.appendChild(link);
        } else {
            // Show only the token value, and clicking it restores the icon
            cell.innerHTML = `<span style="cursor:pointer;">${link.getAttribute('data-token')}</span>`;
            const tokenSpan = cell.querySelector('span');
            tokenSpan.addEventListener('click', function(e) {
                e.preventDefault();
                cell.innerHTML = '';
                cell.appendChild(link);
            });
        }
    }

    // It calls the function cancel edit when the user clicks the button Cancel
    document.getElementById("cancel").addEventListener("click", async function(event) {
        cancelEdit();
    });

    // Function to show a toast message to the user (when things doesn't work properly)
    function showToast(message) {
        const toastBody = document.getElementById('toast-body');
        toastBody.textContent = message;
        const toastEl = document.getElementById('liveToast');
        const toast = new bootstrap.Toast(toastEl);
        toast.show();
    }

    // Function to update a tray Http put
    async function updateTray(id){
        let data = {
            name: document.getElementById("trayName").value,
            cropType: document.getElementById("cropType").value,
            sowingDate: document.getElementById("sowingDate").value,
            settings: {
                temperature: document.getElementById("trayTemperature").value,
                humidity: document.getElementById("trayHumidity").value,
                lightTime: document.getElementById("traySolarHours").value,
            }
        }
        
        try {
            const response = await fetch(`/Tray/${id}`, {
                method: "PUT", // HTTP method
                headers: {
                    'Content-Type': 'application/json' // Tell the server we're sending JSON
                },
                body: JSON.stringify(data) // Convert JS object to JSON string
            });

            // If insert tray fail, display error message
            if (!response.ok) {
                showToast(await response.text());
                return;
            }

            // If login is successful, redirect to my trays page
            window.location.href = "my-trays.html";
        } catch (error) {
            //Show an error message to the user
            showToast("Unexpected error. Please try again.");
            console.error('Error:', error);
        }
    }

    // Function to update a tray Status Http put
    async function updateTrayStatus(id){
        try {
            const response = await fetch(`/Tray/deactivate/${id}`, {
                method: "PUT", // HTTP method
                headers: {
                    'Content-Type': 'application/json' // Tell the server we're sending JSON
                },
            });

            // If insert tray fail, display error message
            if (!response.ok) {
                showToast(await response.text());
                return;
            }

            // If login is successful, redirect to my trays page
            window.location.href = "my-trays.html";
        } catch (error) {
            //Show an error message to the user
            showToast("Unexpected error. Please try again.");
            console.error('Error:', error);
        }
    }

    // This function checks the tray status. If inactive, it disables the buttons Edit and Deactivate
    function setDeactivateButtonState(row, status) {
        // Find the deactivate button in the row
        const deactivateBtn = row.querySelector('.btn-danger');
        const deactivateBtnEdit = row.querySelector('.btn-warning');

        const buttons = [deactivateBtn, deactivateBtnEdit];
        
        if (!deactivateBtn) return;

for (let i = 0; i < buttons.length; i++){
    if (!buttons[i]) continue; // skip if button not found
    if (status !== "Active") {
        buttons[i].classList.add('disabled');
        buttons[i].setAttribute('tabindex', '-1');
        buttons[i].setAttribute('aria-disabled', 'true');
        buttons[i].setAttribute('title', 'Inactive');
    } else {
        buttons[i].classList.remove('disabled');
        buttons[i].removeAttribute('tabindex');
        buttons[i].removeAttribute('aria-disabled');
        // Set correct tooltip for each button
        if (buttons[i].classList.contains('btn-warning')) {
            buttons[i].setAttribute('title', 'Edit');
        } else if (buttons[i].classList.contains('btn-danger')) {
            buttons[i].setAttribute('title', 'Deactivate');
        }
    }
}
    }
});