document.getElementById('Form').addEventListener('submit', function (event) {
    event.preventDefault(); // Prevent the default form submission

    // Gather form data
    const formData = new FormData(this);
    let confirmationMessage = "Please confirm your details:\n\n";

    // Add form data to the confirmation message, skipping the request verification token
    formData.forEach((value, key) => {
        // Check if the key is the request verification token and skip it
        if (key !== '__RequestVerificationToken') { // Adjust this key if your token has a different name
            confirmationMessage += `${key}: ${value}\n`;
        }
    });

    // Show confirmation dialog
    if (confirm(confirmationMessage)) {
        // Show the pop-up before sending the form
        document.getElementById('modalMessage').innerText = "The form is being submitted. Please wait for an email. Make sure the email provided is correct.";
        document.getElementById('submissionModal').style.display = "block";

        // Use fetch to submit the form data
        fetch(this.action, {
            method: 'POST',
            body: formData,
            headers: {
                'Accept': 'application/json',
            }
        })
            .then(response => response.json())
            .then(data => {
                if (data.success) {
                    // Show a success message in the pop-up
                    document.getElementById('modalMessage').innerText = "Your form has been submitted successfully!";

                    // Reset all form inputs
                    this.reset(); // Reset the form fields
                } else {
                    // Show validation errors in the pop-up
                    document.getElementById('modalMessage').innerText = "Errors: " + data.errors.join(', ');
                }
            })
            .catch(error => {
                console.error('Error:', error);
                document.getElementById('modalMessage').innerText = 'An error occurred while submitting the form. Please try again.';
            })
            .finally(() => {
                // Optional: Automatically close the modal after a few seconds
                setTimeout(() => {
                    document.getElementById('submissionModal').style.display = "none";
                }, 5000); // Change to the desired timeout duration
            });
    }
});

// Close the modal when the user clicks on <span> (x)
document.getElementById('closeModal').onclick = function () {
    document.getElementById('submissionModal').style.display = "none";
}

// Close the modal when the user clicks anywhere outside of the modal
window.onclick = function (event) {
    if (event.target == document.getElementById('submissionModal')) {
        document.getElementById('submissionModal').style.display = "none";
    }
}
