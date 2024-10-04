let currentIndex = 3; // Number of initially visible items

function showMore() {
    const items = document.querySelectorAll('.individual-announcement');
    for (let i = currentIndex; i < currentIndex + 3 && i < items.length; i++) {
        items[i].style.display = 'block'; // Show the next 3 items
    }
    currentIndex += 3; // Update the current index
    // Hide the button if all items are shown
    if (currentIndex >= items.length) {
        document.getElementById('showMoreBtn').style.display = 'none';
    }
}

function cancelFeedback() {
    document.getElementById('feedbackForm').reset(); // Reset the form
}