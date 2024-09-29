
const applicationsCtx = document.getElementById('applicationsChart').getContext('2d');
const applicationsChart = new Chart(applicationsCtx, {
    type: 'bar',
    data: {
        labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July'],
        datasets: [{
            label: 'User Applications',
            data: [30, 50, 70, 40, 60, 80, 90], 
            backgroundColor: 'rgba(255, 99, 132, 0.2)',
            borderColor: 'rgba(255, 99, 132, 1)',
            borderWidth: 1
        }]
    },
    options: {
        scales: {
            y: {
                beginAtZero: true
            }
        }
    }
});


const inquiriesCtx = document.getElementById('inquiriesChart').getContext('2d');
const inquiriesChart = new Chart(inquiriesCtx, {
    type: 'bar',
    data: {
        labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July'],
        datasets: [{
            label: 'User Inquiries',
            data: [20, 30, 50, 70, 30, 60, 80], 
            backgroundColor: 'rgba(54, 162, 235, 0.2)',
            borderColor: 'rgba(54, 162, 235, 1)',
            borderWidth: 1
        }]
    },
    options: {
        scales: {
            y: {
                beginAtZero: true
            }
        }
    }
});


const feedbacksCtx = document.getElementById('feedbacksChart').getContext('2d');
const feedbacksChart = new Chart(feedbacksCtx, {
    type: 'bar',
    data: {
        labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July'],
        datasets: [{
            label: 'User Feedbacks',
            data: [40, 60, 80, 20, 50, 70, 60], 
            backgroundColor: 'rgba(75, 192, 192, 0.2)',
            borderColor: 'rgba(75, 192, 192, 1)',
            borderWidth: 1
        }]
    },
    options: {
        scales: {
            y: {
                beginAtZero: true
            }
        }
    }
});
