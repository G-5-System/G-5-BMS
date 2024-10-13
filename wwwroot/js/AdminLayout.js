$(document).ready(function () {
    $('#toggleSidebar').on('click', function () {
        $('#sidebar').toggle(); 
    });
});

// JavaScript to handle the active state for sidebar links
document.addEventListener('DOMContentLoaded', function () {
    const sidebarLinks = document.querySelectorAll('.sidebar ul li a');

    // Add click event listener to each link
    sidebarLinks.forEach(link => {
        link.addEventListener('click', function () {
            // Remove active class from all links
            sidebarLinks.forEach(item => item.classList.remove('active'));

            // Add active class to the clicked link
            this.classList.add('active');
        });
    });

    // Set the active link based on the current page URL
    sidebarLinks.forEach(link => {
        if (link.href === window.location.href) {
            link.classList.add('active');
        }
    });
});
