$(document).ready(function () {
    $('#clearanceForm').submit(function (event) {
        event.preventDefault(); // Prevent the default form submission

        $.ajax({
            url: $(this).attr('action'),
            type: $(this).attr('method'),
            data: $(this).serialize(),
            success: function (response) {
                if (response.success) {
                    $('#successMessage').show(); // Show success message
                    $('#clearanceForm')[0].reset(); // Reset the form
                } else {
                    // Handle errors (optional)
                    alert("There were errors in the form submission: " + response.errors.join(", "));
                }
            },
            error: function () {
                alert("An error occurred. Please try again.");
            }
        });
    });
});