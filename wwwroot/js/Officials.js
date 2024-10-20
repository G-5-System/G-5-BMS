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
                    { id: 1, title: "Barangay Captain" },
                    { id: 2, title: "Kagawad 1" },
                    { id: 3, title: "Kagawad 2" },
                    { id: 4, title: "Kagawad 3" },
                    { id: 5, title: "Kagawad 4" },
                    { id: 6, title: "Kagawad 5" },
                    { id: 7, title: "Kagawad 6" },
                    { id: 8, title: "Secretary" }
                ];
            } else {
                officials = [
                    { id: 1, title: "Brgy Chairman" },
                    { id: 2, title: "Kagawad 1" },
                    { id: 3, title: "Kagawad 2" },
                    { id: 4, title: "Kagawad 3" },
                    { id: 5, title: "Kagawad 4" },
                    { id: 6, title: "Kagawad 5" },
                    { id: 7, title: "Kagawad 6" },
                    { id: 8, title: "Secretary" }
                ];
            }

            officials.forEach(official => {
                const card = document.createElement('div');
                card.className = 'inner-card';
                card.innerHTML = `
                    <div class="inner-card-row">
                        <a href="#" onclick="removeAction(${official.id})" title="Remove" class="remove-link">
                            <img src="/Images/Admin/remove.png" alt="remove" style="width: 24px; height: 24px;" />
                        </a>
                        <div class="inner-card-title">${official.title}</div>
                        <a href="#" onclick="editAction(${official.id})" title="Edit" class="edit-link">
                            <img src="/Images/Admin/edit-button.png" alt="edit" style="width: 24px; height: 24px;" />
                        </a>
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
