document.addEventListener("DOMContentLoaded", function () {
    console.log("DOM fully loaded and parsed.");

    const fileInput = document.getElementById('file-input');
    if (fileInput) {
        fileInput.addEventListener('change', function (event) {
            console.log("File input changed.");
            const reader = new FileReader();
            const photoPreview = document.getElementById('photo-preview');

            reader.onload = function () {
                photoPreview.style.backgroundImage = `url(${reader.result})`;
                photoPreview.style.backgroundSize = 'cover';
                photoPreview.style.color = 'transparent';
            }

            if (event.target.files[0]) {
                reader.readAsDataURL(event.target.files[0]);
            }
        });
    } else {
        console.error("File input element not found.");
    }

    const editButtons = document.querySelectorAll('.edit-button');
    if (editButtons.length > 0) {
        editButtons.forEach(button => {
            button.addEventListener('click', function () {
                const field = this.getAttribute('data-field');
                const inputElement = document.getElementById(`${field}-input`);

                if (inputElement) {
                    console.log(`Edit button clicked for field: ${field}`);

                    if (inputElement.hasAttribute('readonly')) {
                        inputElement.removeAttribute('readonly');
                        inputElement.focus();
                        this.innerHTML = '<i class="bi bi-check-circle"></i>';
                    } else {
                        inputElement.setAttribute('readonly', true);
                        this.innerHTML = '<i class="bi bi-pencil"></i>';
                    }
                } else {
                    console.error(`Input element not found for field: ${field}`);
                }
            });
        });
    } else {
        console.error("Edit buttons not found.");
    }
});
