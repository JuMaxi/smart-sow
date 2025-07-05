document.addEventListener('DOMContentLoaded', function () {

    // Function to register a tray Http post
    async function registerTray(){
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
            const response = await fetch('/Tray', {
                method: 'POST', // HTTP method
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

    // It calls the function to register the user and prevents the form data be displayed in the query string 
    document.getElementById("register-tray").addEventListener("submit", async function(event) {
        event.preventDefault();  
        await registerTray();
    });

   
});