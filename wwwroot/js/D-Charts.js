document.addEventListener('DOMContentLoaded', function () {
    const data = {
        Clearances: parseInt(document.getElementById('clearances').value, 10) || 0,
        Certificates: parseInt(document.getElementById('certificates').value, 10) || 0,
        Ids: parseInt(document.getElementById('ids').value, 10) || 0,
        Complains: parseInt(document.getElementById('complains').value, 10) || 0
    };

    document.getElementById('totalIdRequests').textContent = data.Ids; 
    document.getElementById('totalComplaints').textContent = data.Complains; 
    document.getElementById('totalCertificateRequests').textContent = data.Certificates; 
    document.getElementById('totalClearanceRequests').textContent = data.Clearances; 

    const pieCtx = document.getElementById('myPieChart').getContext('2d');
    const myPieChart = new Chart(pieCtx, {
        type: 'pie',
        data: {
            labels: ['Clearances', 'Certificates', 'IDs', 'Complaints'],
            datasets: [{
                label: 'Totals',
                data: [data.Clearances, data.Certificates, data.Ids, data.Complains],
                backgroundColor: [
                    'rgba(255, 99, 132, 0.7)',
                    'rgba(54, 162, 235, 0.7)',
                    'rgba(255, 206, 86, 0.7)',
                    'rgba(75, 192, 192, 0.7)'
                ],
                borderColor: '#fff', 
                borderWidth: 2
            }]
        },
        options: {
            responsive: true,
            plugins: {
                legend: {
                    position: 'top',
                    labels: {
                        font: {
                            size: 14,
                            weight: 'bold'
                        },
                        color: '#343a40'
                    }
                },
                title: {
                    display: true,
                    text: 'Total Counts (Pie Chart)',
                    font: {
                        size: 18,
                        weight: 'bold'
                    },
                    color: '#343a40'
                }
            }
        }
    });

    const barCtx = document.getElementById('myBarChart').getContext('2d');
    const myBarChart = new Chart(barCtx, {
        type: 'bar',
        data: {
            labels: ['Clearances', 'Certificates', 'IDs', 'Complaints'],
            datasets: [{
                label: 'Total Count',
                data: [data.Clearances, data.Certificates, data.Ids, data.Complains],
                backgroundColor: [
                    'rgba(255, 99, 132, 0.7)',
                    'rgba(54, 162, 235, 0.7)',
                    'rgba(255, 206, 86, 0.7)',
                    'rgba(75, 192, 192, 0.7)'
                ],
                borderColor: '#fff', 
                borderWidth: 2
            }]
        },
        options: {
            responsive: true,
            plugins: {
                legend: {
                    position: 'top',
                    labels: {
                        font: {
                            size: 14,
                            weight: 'bold'
                        },
                        color: '#343a40'
                    }
                },
                title: {
                    display: true,
                    text: 'Total Counts (Bar Chart)',
                    font: {
                        size: 18,
                        weight: 'bold'
                    },
                    color: '#343a40'
                },
                datalabels: {
                    anchor: 'end',
                    align: 'end',
                    formatter: (value) => {
                        return value; 
                    },
                    color: '#343a40', 
                    font: {
                        weight: 'bold',
                        size: 14,
                    },
                }
            },
            scales: {
                y: {
                    beginAtZero: true,
                    ticks: {
                        color: '#343a40', 
                        font: {
                            size: 20
                        }
                    },
                    grid: {
                        color: '#e0e0e0',
                    }
                },
                x: {
                    ticks: {
                        color: '#343a40', 
                        font: {
                            size: 14
                        }
                    },
                    grid: {
                        color: '#e0e0e0',
                    }
                }
            }
        }
    });
});
