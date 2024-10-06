document.getElementById('file-input').addEventListener('change', function (event) {
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