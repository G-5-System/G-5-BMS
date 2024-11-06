 function stoggleContent() {
        const faqForm = document.getElementById("faqForm");
    const feedbackTable = document.getElementById("feedbackTable");

    if (faqForm.style.display === "none") {
        faqForm.style.display = "block";
    feedbackTable.style.display = "none";
        } else {
        faqForm.style.display = "none";
    feedbackTable.style.display = "block";
        }
    }

function closeModal() {
    document.getElementById("faqModal").style.display = "none";
}

function openModal() {
    document.getElementById("faqModal").style.display = "block";
}

function stoggleContent() {
    const faqForm = document.getElementById("faqForm");
    const feedbackTable = document.getElementById("feedbackTable");

    if (faqForm.style.display === "none") {
        faqForm.style.display = "block";
        feedbackTable.style.display = "none";
    } else {
        faqForm.style.display = "none";
        feedbackTable.style.display = "block";
    }
}

function addItem() {
    document.getElementById("faqModal").style.display = "block";
}

function submitFAQ() {
    const question = document.getElementById("question").value; // Update to match the input ID
    const answer = document.getElementById("answer").value; // Update to match the input ID

    if (question && answer) {
        addFAQToDatabase(question, answer);
        document.getElementById("question").value = '';
        document.getElementById("answer").value = '';
        closeModal();
    } else {
        alert("Please fill in both fields.");
    }
}

function addFAQToDatabase(question, answer) {
    fetch('/FAQs/Add', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({ question: question, answer: answer }),
    })
        .then(response => response.json())
        .then(data => {
            console.log('Success:', data);
            // Optionally, update the UI here to show the new FAQ
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}
