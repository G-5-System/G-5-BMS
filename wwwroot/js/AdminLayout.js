$(document).ready(function () {
    $('#toggleSidebar').on('click', function () {
        $('#sidebar').toggle(); 
    });
});


document.addEventListener('DOMContentLoaded', function () {
    const sidebarLinks = document.querySelectorAll('.sidebar ul li a');

    sidebarLinks.forEach(link => {
        link.addEventListener('click', function () {

            sidebarLinks.forEach(item => item.classList.remove('active'));

            this.classList.add('active');
        });
    });

    sidebarLinks.forEach(link => {
        if (link.href === window.location.href) {
            link.classList.add('active');
        }
    });
});
