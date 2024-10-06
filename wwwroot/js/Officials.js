document.addEventListener("DOMContentLoaded", function () {
    const officialsContainer = document.getElementById('officialsContainer');
    const dropdownButton = document.getElementById('dropdownButton');
    const dropdownMenu = document.getElementById('dropdownMenu');

    dropdownButton.addEventListener('click', function () {
        dropdownMenu.style.display = dropdownMenu.style.display === 'block' ? 'none' : 'block';
    });

    const dropdownItems = dropdownMenu.querySelectorAll('.dropdown-item');
    dropdownItems.forEach(item => {
        item.addEventListener('click', function (event) {
            event.preventDefault();
            const councilType = event.target.getAttribute('data-council');


            officialsContainer.innerHTML = '';

            let officials;

            if (councilType === 'barangay') {
                officials = [
                    { title: "Barangay Captain" },
                    { title: "Kagawad 1" },
                    { title: "Kagawad 2" },
                    { title: "Kagawad 3" },
                    { title: "Kagawad 4" },
                    { title: "Kagawad 5" },
                    { title: "Kagawad 6" },
                    { title: "Secretary" }
                ];
            } else {
                officials = [
                    { title: "Brgy Chairman" },
                    { title: "Kagawad 1" },
                    { title: "Kagawad 2" },
                    { title: "Kagawad 3" },
                    { title: "Kagawad 4" },
                    { title: "Kagawad 5" },
                    { title: "Kagawad 6" },
                    { title: "Secretary" }
                ];
            }

            officials.forEach(official => {
                const card = document.createElement('div');
                card.className = 'inner-card';
                card.innerHTML = `
                    <div class="inner-card-row">
                        <button class="btn-data btn-danger btn-sm">X</button>
                        <div class="inner-card-title">${official.title}</div>
                        <button class="btn-data btn-primary btn-sm">Edit</button>
                    </div>
                `;
                officialsContainer.appendChild(card);
            });

            dropdownMenu.style.display = 'none';
        });
    });

    document.addEventListener('click', function (event) {
        if (!dropdownButton.contains(event.target) && !dropdownMenu.contains(event.target)) {
            dropdownMenu.style.display = 'none';
        }
    });
});
