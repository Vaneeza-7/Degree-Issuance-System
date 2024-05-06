<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GenerateChart.aspx.cs" Inherits="GenerateChart" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Generate Requests Chart</title>
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@400;700&display=swap" rel="stylesheet">
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
    <style>
        body {
            font-family: 'Montserrat', sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f0f0f0;
        }
        #container {
            width: 100%;
            margin: 0 auto;
        }
        #header {
            background-color: #000;
            color: #fff;
            padding: 20px 10px;
            text-align: center;
            font-size: 14px;
            margin-bottom: 2px;
        }
        #navigation {
            background-color: #000;
            color: #fff;
            padding: 30px 0;
            height: 130vh;
        }
        #navigation ul {
            list-style-type: none;
            padding: 0;
            margin: 0;
        }
        #navigation li {
            margin-bottom: 20px;
        }
        #navigation a {
            color: #fff;
            text-decoration: none;
            font-size: 18px;
            font-weight: bold;
            padding: 10px 20px;
            display: block;
        }
        #navigation a:hover {
            background-color: #333;
        }
        #content {
            padding: 20px;
        }
        .boldish-font {
            font-weight: 500;
        }
    </style>
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="container" class="container-fluid">
            <div class="row">
                <header id="header" class="col-md-12">
                    <h1>One Stop</h1>
                </header>
                <nav id="navigation" class="col-md-2">
                    <ul>
                        <li>
                            <a href="DirectorDashboard.aspx">Home</a>
                        </li>
                        <li>
                            <a href="MonitorRequests.aspx">Monitor Requests</a>
                        </li>
                        <li>
                            <a href="GenerateChart.aspx">Generate Request Report</a>
                        </li>
                        <li>
                            <a href="Default.aspx">Logout</a>
                        </li>
                    </ul>
                </nav>
                <main id="content" class="col-md-10">
                    <h2>Requests Chart</h2>
                    <div class="container mt-5">
                        <canvas id="requestsChart" width="600" height="400"></canvas>
                    </div>

                    <p style="margin-left: 4px; background-color: #343A40; height: 20px"> </p>
                </main>
            </div>
        </div>
    </form>

    <script>
        document.addEventListener("DOMContentLoaded", function () {
            const data = {
                labels: chartData.labels,
                datasets: [{
                    label: 'Requests Status',
                    data: chartData.statuses.map(status => {
                        switch (status) {
                            case 'Pending': return 0.5;
                            case 'Rejected': return 0.25;
                            case 'Approved': return 1;
                            default: return 0;
                        }
                    }),
                    backgroundColor: [
                        'rgba(75, 192, 192, 0.6)',
                        'rgba(255, 99, 132, 0.6)',
                        'rgba(255, 206, 86, 0.6)',
                        'rgba(54, 162, 235, 0.6)',
                        'rgba(153, 102, 255, 0.6)'
                    ],
                    borderColor: [
                        'rgba(75, 192, 192, 1)',
                        'rgba(255, 99, 132, 1)',
                        'rgba(255, 206, 86, 1)',
                        'rgba(54, 162, 235, 1)',
                        'rgba(153, 102, 255, 1)'
                    ],
                    borderWidth: 1
                }]
            };

            const statusMap = chartData.statuses;

            const ctx = document.getElementById('requestsChart').getContext('2d');
            new Chart(ctx, {
                type: 'bar',
                data: data,
                options: {
                    responsive: true,
                    plugins: {
                        legend: {
                            display: false
                        },
                        tooltip: {
                            callbacks: {
                                label: function (tooltipItem) {
                                    const index = tooltipItem.dataIndex;
                                    return `Status: ${statusMap[index]}`;
                                }
                            }
                        }
                    },
                    scales: {
                        x: {
                            title: {
                                display: true,
                                text: 'Date Received',
                                color: '#000',
                                font: {
                                    size: 14
                                }
                            }
                        },
                        y: {
                            beginAtZero: true,
                            max: 1,
                            title: {
                                display: true,
                                text: 'Status',
                                color: '#000',
                                font: {
                                    size: 14
                                }
                            },
                            ticks: {
                                callback: function (value) {
                                    switch (value) {
                                        case 0.25: return 'Rejected';
                                        case 0.5: return 'Pending';
                                        case 1: return 'Approved';
                                        default: return '';
                                    }
                                }
                            }
                        }
                    }
                }
            });
        });
    </script>
</body>
</html>
