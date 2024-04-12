function renderCharts(articlesByStatus, articlesPerMonth, approvalRateOverTime, topContributors) {
    console.log("Articles By Status:", articlesByStatus);

    console.log("Monthly Submission:", articlesPerMonth);

    console.log("Approval Rate Over Time:", approvalRateOverTime);

    console.log("Top Contributors:", topContributors);



    var statusLabels = articlesByStatus.map(a => a.status);
    var statusData = articlesByStatus.map(a => a.count);
    var statusColors = ['rgba(255, 99, 132, 0.7)', 'rgba(54, 162, 235, 0.7)', 'rgba(255, 206, 86, 0.7)'];

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
                    position: 'top'
                },
                title: {
                    display: true,
                    text: 'Articles By Status'
                }
            }
        }
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
    


    var months = approvalRateOverTime.map(a => a.month);
    var approvalRates = approvalRateOverTime.map(a => a.approvalRate);
    var declineRates = approvalRateOverTime.map(a => a.declineRate);

    var ctxApprovalRate = document.getElementById('approvalRateChart').getContext('2d');
    var approvalRateChart = new Chart(ctxApprovalRate, {
        type: 'line',
        data: {
            labels: months,
            datasets: [{
                label: 'Approval Rate',
                data: approvalRates,
                backgroundColor: 'rgba(54, 162, 235, 0.7)', 
                borderColor: 'rgba(54, 162, 235, 1)',
                borderWidth: 1,
                fill: false
            },
            {
                label: 'Decline Rate',
                data: declineRates,
                backgroundColor: 'rgba(255, 206, 86, 0.7)',
                borderColor: 'rgba(255, 206, 86, 1)',
                borderWidth: 1,
                fill: false
            }]
        },
        options: {
            responsive: true,
            plugins: {
                legend: {
                    position: 'top'
                },
                title: {
                    display: true,
                    text: 'Approval and Decline Rates Over Time'
                }
            }
        }
    });

    var contributors = topContributors.map(a => a.contributor);
    var counts = topContributors.map(a => a.count);

    var ctxTopContributors = document.getElementById('topContributorsChart').getContext('2d');
    var topContributorsChart = new Chart(ctxTopContributors, {
        type: 'bar',
        data: {
            labels: contributors,
            datasets: [{
                label: 'Submissions',
                data: counts,
                backgroundColor: 'rgba(75, 192, 192, 0.7)',
                borderColor: 'rgba(75, 192, 192, 1)',
                borderWidth: 1
            }]
        },
        options: {
            responsive: true,
            plugins: {
                legend: {
                    position: 'top'
                },
                title: {
                    display: true,
                    text: 'Top Contributors'
                }
            }
        }
    });

}