document.addEventListener('DOMContentLoaded', function () {

    // Function to display tooltip when hovering the table icons
    function displayToolTip(){
        var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
        tooltipTriggerList.forEach(function (tooltipTriggerEl) {
            new bootstrap.Tooltip(tooltipTriggerEl);
        });
    }

    displayToolTip();

});