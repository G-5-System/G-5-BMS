let currentIndex = 3; 

function showMore() {
    const items = document.querySelectorAll('.individual-announcement');
    for (let i = currentIndex; i < currentIndex + 3 && i < items.length; i++) {
        items[i].style.display = 'block'; 
    }
    currentIndex += 3; 
    if (currentIndex >= items.length) {
        document.getElementById('showMoreBtn').style.display = 'none';
    }
}

function cancelFeedback() {
    document.getElementById('feedbackForm').reset();
}