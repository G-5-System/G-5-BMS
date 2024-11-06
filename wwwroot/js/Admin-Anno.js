document.addEventListener('DOMContentLoaded', function () {
    const modal = document.getElementById("addano");

    // Function to open the modal
    window.openModal = function () {
        modal.style.display = "block";
    };

    // Function to close the modal
    window.closeModal = function () {
        modal.style.display = "none";
    };

    // Close the modal when clicking outside of it
    window.addEventListener('click', function (event) {
        if (event.target === modal) {
            closeModal();
        }
    });

    // Handle form submission
    document.getElementById("announcementForm").addEventListener("submit", function (event) {
        event.preventDefault();
        const title = document.getElementById("announcementTitle").value;
        const body = document.getElementById("announcementBody").value;
        const dateTime = document.getElementById("announcementDateTime").value; // Get the date and time

        // Here you can implement the AJAX call or any logic to handle the submission
        console.log("Title:", title, "Body:", body, "Date & Time:", dateTime);
        closeModal(); // Close the modal after submission
    });
});
