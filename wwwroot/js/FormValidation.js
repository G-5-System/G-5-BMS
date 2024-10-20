document.addEventListener('DOMContentLoaded', function () {
    document.getElementById('Form').addEventListener('submit', function (event) {
        event.preventDefault();

        const formData = new FormData(this);
        let confirmationMessage = "Please confirm your details:\n\n";

        formData.forEach((value, key) => {
            if (key !== '__RequestVerificationToken') {
                confirmationMessage += `${key}: ${value}\n`;
            }
        });

        document.getElementById('confirmationMessage').innerText = confirmationMessage;
        document.getElementById('confirmationModal').style.display = "block";

        document.getElementById('confirmButton').onclick = () => {
            document.getElementById('modalMessage').innerText = "The form is being submitted. Please wait for an email. Make sure the email provided is correct.";
            document.getElementById('submissionModal').style.display = "flex";

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
                        document.getElementById('modalMessage').innerText = "Your form has been submitted successfully!";
                        this.reset();
                    } else {
                        document.getElementById('modalMessage').innerText = "Errors: " + data.errors.join(', ');
                    }
                })
                .catch(error => {
                    console.error('Error:', error);
                    document.getElementById('modalMessage').innerText = 'An error occurred while submitting the form. Please try again.';
                })
                .finally(() => {
                    setTimeout(() => {
                        document.getElementById('submissionModal').style.display = "none";
                    }, 5000);
                });

            document.getElementById('confirmationModal').style.display = "none";
        };

        document.getElementById('cancelButton').onclick = () => {
            document.getElementById('confirmationModal').style.display = "none";
        };
    });

    document.getElementById('closeModal').onclick = function () {
        document.getElementById('submissionModal').style.display = "none";
    }

    document.getElementById('closeConfirmation').onclick = function () {
        document.getElementById('confirmationModal').style.display = "none";
    }

    window.onclick = function (event) {
        if (event.target == document.getElementById('submissionModal')) {
            document.getElementById('submissionModal').style.display = "none";
        } else if (event.target == document.getElementById('confirmationModal')) {
            document.getElementById('confirmationModal').style.display = "none";
        }
    }
});
