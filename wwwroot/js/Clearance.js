$(document).ready(function () {
    $('#clearanceForm').submit(function (event) {
        event.preventDefault(); 

        $.ajax({
            url: $(this).attr('action'),
            type: $(this).attr('method'),
            data: $(this).serialize(),
            success: function (response) {
                if (response.success) {
                    $('#successMessage').show(); 
                    $('#clearanceForm')[0].reset(); 
                } else {
                    alert("There were errors in the form submission: " + response.errors.join(", "));
                }
            },
            error: function () {
                alert("An error occurred. Please try again.");
            }
        });
    });
});