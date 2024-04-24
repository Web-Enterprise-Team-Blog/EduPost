function getRandomColor() {
    var r = Math.floor(Math.random() * 255);
    var g = Math.floor(Math.random() * 255);
    var b = Math.floor(Math.random() * 255);
    return `rgba(${r}, ${g}, ${b}, 0.7)`;
}

function renderCharts(articlesPerFaculty, articlesPerMonth, articlesByStatus, articlesByFaculty) {
    var backgroundColors = articlesPerFaculty.map(() => getRandomColor());
    var borderColors = backgroundColors.map(color => color.replace('0.7', '1'));

    var ctxFaculty = document.getElementById('articlesPerFacultyChart').getContext('2d');
    var articlesPerFacultyChart = new Chart(ctxFaculty, {
        type: 'pie',
        data: {
            labels: articlesPerFaculty.map(a => a.faculty),
            datasets: [{
                data: articlesPerFaculty.map(a => a.count),
                backgroundColor: backgroundColors,
                borderColor: borderColors,
                borderWidth: 1
            }]
        },
        options: {
            responsive: true,
            plugins: {
                legend: {
                    position: 'top',
                },
                title: {
                    display: true,
                    text: 'Articles Per Faculty'
                }
            }
        },
    });

    var months = articlesPerMonth.map(a => a.month);
    var counts = articlesPerMonth.map(a => a.count);

    var ctxMonthlySubmission = document.getElementById('monthlySubmissionChart').getContext('2d');
    var monthlySubmissionChart = new Chart(ctxMonthlySubmission, {
        type: 'bar',
        data: {
            labels: months,
            datasets: [{
                label: 'Submissions',
                data: counts,
                backgroundColor: 'rgba(131, 131, 131, 0.7)',
                borderColor: 'rgba(131, 131, 131, 1)',
                borderWidth: 1
            }]
        },
        options: {
            responsive: true,
            plugins: {
                legend: {
                    display: false
                },
                title: {
                    display: true,
                    text: 'Monthly Submission'
                }
            }
        }
    });

    var statusLabels = articlesByStatus.map(a => a.status);
    var statusData = articlesByStatus.map(a => a.count);


    var statusColors = ['rgba(255, 99, 132, 0.7)', 'rgba(54, 162, 235, 0.7)', 'rgba(255, 206, 86, 0.7)', 'rgba(131, 131, 131, 0.7)'];

    var ctxStatus = document.getElementById('articlesByStatusChart').getContext('2d');
    var articlesByStatusChart = new Chart(ctxStatus, {
        type: 'pie',
        data: {
            labels: statusLabels,
            datasets: [{
                data: statusData,
                backgroundColor: statusColors,
                borderColor: statusColors,
                borderWidth: 1
            }]
        },
        options: {
            responsive: true,
            plugins: {
                legend: {
                    position: 'top',
                },
                title: {
                    display: true,
                    text: 'Articles By Status'
                }
            }
        },
    });

    var facultyLabels = articlesByFaculty.map(a => a.faculty);

    var dataByFaculty = articlesByFaculty.map(a => ({
        faculty: a.faculty,
        pending: a.pending,
        approved: a.approved,
        declined: a.declined,
        expired: a.expired
    }));

    var datasets = [
        {
            label: 'Pending',
            backgroundColor: 'rgba(255, 99, 132, 0.7)',
            data: dataByFaculty.map(a => a.pending)
        },
        {
            label: 'Approved',
            backgroundColor: 'rgba(54, 162, 235, 0.7)',
            data: dataByFaculty.map(a => a.approved)
        },
        {
            label: 'Declined',
            backgroundColor: 'rgba(255, 206, 86, 0.7)',
            data: dataByFaculty.map(a => a.declined)
        }
    ];

    var ctxBar = document.getElementById('articlesByFacultyBarChart').getContext('2d');
    var articlesByFacultyBarChart = new Chart(ctxBar, {
        type: 'bar',
        data: {
            labels: facultyLabels,
            datasets: datasets
        },
        options: {
            responsive: true,
            plugins: {
                legend: {
                    position: 'top',
                },
                title: {
                    display: true,
                    text: 'Articles By Faculty'
                }
            },
            scales: {
                x: {
                    stacked: true
                },
                y: {
                    stacked: true
                }
            }
        },
    });
}
