function toggleFAQ(element) {
    const answer = element.nextElementSibling;
    const toggleIcon = element.querySelector('.faq-toggle');

    if (answer.style.display === "block") {
        answer.style.display = "none";
        toggleIcon.textContent = "+";
    } else {
        answer.style.display = "block";
        toggleIcon.textContent = "-";
    }
}