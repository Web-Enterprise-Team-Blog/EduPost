function getRandomColor() {
    var r = Math.floor(Math.random() * 255);
    var g = Math.floor(Math.random() * 255);
    var b = Math.floor(Math.random() * 255);
    return `rgba(${r}, ${g}, ${b}, 0.7)`;
}

function renderCharts(articlesPerFaculty, articlesPerDay) {
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

    var ctxDay = document.getElementById('articlesPerDayChart').getContext('2d');
    var articlesPerDayChart = new Chart(ctxDay, {
        type: 'bar',
        data: {
            labels: articlesPerDay.map(a => a.day),
            datasets: [{
                data: articlesPerDay.map(a => a.count),
                backgroundColor: 'rgba(153, 102, 255, 0.7)',
                borderColor: 'rgba(153, 102, 255, 1)',
                borderWidth: 1
            }]
        },
        options: {
            responsive: true,
            scales: {
                y: {
                    beginAtZero: true
                }
            },
            plugins: {
                legend: {
                    display: false
                },
                title: {
                    display: true,
                    text: 'Articles Per Day (Last 7 Days)'
                }
            }
        },
    });
}
